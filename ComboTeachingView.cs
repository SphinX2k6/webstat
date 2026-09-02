using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001891 RID: 6289
[NullableContext(1)]
[Nullable(0)]
public class ComboTeachingView : UiTickViewBase
{
	// Token: 0x0600B459 RID: 46169 RVA: 0x00300A57 File Offset: 0x002FEC57
	public ComboTeachingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B45A RID: 46170 RVA: 0x00300A7C File Offset: 0x002FEC7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600B45B RID: 46171 RVA: 0x00300B18 File Offset: 0x002FED18
	protected override void OnStart()
	{
		ModelBase<ComboTeachingModel>.Instance.IsClose = false;
		string startSequenceName = ModelBase<ComboTeachingModel>.Instance.InitStart ? "Start" : "Start01";
		this.UiViewSequence.StartSequenceName = startSequenceName;
		this.InitDraggablePanel();
		this.RefreshComboList((int)this.OpenParam);
		this.InitComboInputHandler();
	}

	// Token: 0x0600B45C RID: 46172 RVA: 0x00300B72 File Offset: 0x002FED72
	protected override void OnBeforeShow()
	{
		this.OnSelectedUpdate();
	}

	// Token: 0x0600B45D RID: 46173 RVA: 0x00300B7A File Offset: 0x002FED7A
	protected override void OnAddEventListener()
	{
		this.AddTeachingEventListener();
		Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
	}

	// Token: 0x0600B45E RID: 46174 RVA: 0x00300B9E File Offset: 0x002FED9E
	protected override void OnRemoveEventListener()
	{
		this.RemoveTeachingEventListener();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
	}

	// Token: 0x0600B45F RID: 46175 RVA: 0x00300BC4 File Offset: 0x002FEDC4
	protected void AddTeachingEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EInputAction, float>(EEventName.ComboTeachingPress, new Action<EInputAction, float>(this.OnPress));
		Singleton<EventSystem>.Instance.Add<EInputAction, float>(EEventName.ComboTeachingRelease, new Action<EInputAction, float>(this.OnRelease));
		Singleton<EventSystem>.Instance.Add<EInputAction, float>(EEventName.ComboTeachingHold, new Action<EInputAction, float>(this.OnHold));
		Singleton<EventSystem>.Instance.Add<ComboTeachingNode, bool>(EEventName.ComboTeachingNodeEnd, new Action<ComboTeachingNode, bool>(this.OnNodeEnd));
		Singleton<EventSystem>.Instance.Add(EEventName.ComboTeachingIndexUpdate, new Action(this.OnSelectedUpdate));
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnCharEndSkill));
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.SkillAcceptChanged, new Action<int, int, bool>(this.OnNextAttrChanged));
		Singleton<EventSystem>.Instance.Add<global::HitInformation, IAttributeSet>(EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnHit));
		this.TeachingEventAdded = true;
	}

	// Token: 0x0600B460 RID: 46176 RVA: 0x00300CD0 File Offset: 0x002FEED0
	protected void RemoveTeachingEventListener()
	{
		if (!this.TeachingEventAdded)
		{
			return;
		}
		this.TeachingEventAdded = false;
		Singleton<EventSystem>.Instance.Remove<EInputAction, float>(EEventName.ComboTeachingPress, new Action<EInputAction, float>(this.OnPress));
		Singleton<EventSystem>.Instance.Remove<EInputAction, float>(EEventName.ComboTeachingRelease, new Action<EInputAction, float>(this.OnRelease));
		Singleton<EventSystem>.Instance.Remove<EInputAction, float>(EEventName.ComboTeachingHold, new Action<EInputAction, float>(this.OnHold));
		Singleton<EventSystem>.Instance.Remove<ComboTeachingNode, bool>(EEventName.ComboTeachingNodeEnd, new Action<ComboTeachingNode, bool>(this.OnNodeEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.ComboTeachingIndexUpdate, new Action(this.OnSelectedUpdate));
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.SkillAcceptChanged, new Action<int, int, bool>(this.OnNextAttrChanged));
		Singleton<EventSystem>.Instance.Remove<global::HitInformation, IAttributeSet>(EEventName.BulletHit, new Action<global::HitInformation, IAttributeSet>(this.OnHit));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnCharEndSkill));
	}

	// Token: 0x0600B461 RID: 46177 RVA: 0x00300DE3 File Offset: 0x002FEFE3
	protected override void OnBeforeDestroy()
	{
		this.NoCircleAttachView = null;
		ControllerBase<InputController>.Instance.RemoveInputHandler(this.InputHandler);
		ModelBase<ComboTeachingModel>.Instance.OnComboListEnd();
	}

	// Token: 0x0600B462 RID: 46178 RVA: 0x00300E08 File Offset: 0x002FF008
	private void InitDraggablePanel()
	{
		UUIItem item = base.GetItem(0);
		UUIItem item2 = base.GetItem(5);
		this.NoCircleAttachView = new NoCircleAttachView<IComboTeachingInfo, ComboTeachingNode>(item.GetOwner() as AUIBaseActor, false);
		this.NoCircleAttachView.SetControllerItem(item2);
		this.NoCircleAttachView.CreateItems(base.GetItem(3).GetOwner() as AUIBaseActor, -280f, new Func<AActor, int, int, ComboTeachingNode>(this.CreateNoCircleAttachItem), EAttachDirection.Horizontal);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600B463 RID: 46179 RVA: 0x00300E84 File Offset: 0x002FF084
	protected void RefreshComboList(int comboId)
	{
		ComboTeaching value = ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConfig(comboId).Value;
		this.NextGuideId = value.NextRoleGuideID;
		foreach (int guideId in value.GuideIDIter())
		{
			ControllerBase<GuideController>.Instance.TryStartGuide(guideId);
		}
		if (comboId != this.CurComboId)
		{
			this.CurComboId = comboId;
			foreach (IComboTeachingInfo comboTeachingInfo in this.NodeList)
			{
				if (comboTeachingInfo.SuccessHandle != null)
				{
					if (TimerSystem.Instance.Has(comboTeachingInfo.SuccessHandle))
					{
						TimerSystem.Instance.Remove(comboTeachingInfo.SuccessHandle);
					}
					comboTeachingInfo.SuccessHandle = null;
				}
				if (comboTeachingInfo.FailHandle != null)
				{
					if (TimerSystem.Instance.Has(comboTeachingInfo.FailHandle))
					{
						TimerSystem.Instance.Remove(comboTeachingInfo.FailHandle);
					}
					comboTeachingInfo.FailHandle = null;
				}
			}
			this.NodeList.Clear();
			for (int i = 0; i < value.CommandIDLength; i++)
			{
				IComboTeachingInfo item = ModelBase<ComboTeachingModel>.Instance.CreateComboNodeInfo(i, value);
				this.NodeList.Add(item);
			}
		}
		else
		{
			foreach (IComboTeachingInfo comboTeachingInfo2 in this.NodeList)
			{
				comboTeachingInfo2.IsEmit = false;
				comboTeachingInfo2.NeedTickSummon = true;
				if (comboTeachingInfo2.SuccessHandle != null)
				{
					if (TimerSystem.Instance.Has(comboTeachingInfo2.SuccessHandle))
					{
						TimerSystem.Instance.Remove(comboTeachingInfo2.SuccessHandle);
					}
					comboTeachingInfo2.SuccessHandle = null;
				}
				if (comboTeachingInfo2.FailHandle != null)
				{
					if (TimerSystem.Instance.Has(comboTeachingInfo2.FailHandle))
					{
						TimerSystem.Instance.Remove(comboTeachingInfo2.FailHandle);
					}
					comboTeachingInfo2.FailHandle = null;
				}
			}
		}
		this.NoCircleAttachView.ReloadView(this.NodeList.Count, this.NodeList.ToArray(), 0);
		ModelBase<ComboTeachingModel>.Instance.RefreshComboList(comboId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.DescriptionTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.DescriptionContent, Array.Empty<object>());
	}

	// Token: 0x0600B464 RID: 46180 RVA: 0x0030111C File Offset: 0x002FF31C
	protected void InitComboInputHandler()
	{
		this.InputHandler = new ComboTeachingInputHandler();
		ControllerBase<InputController>.Instance.AddInputHandler(this.InputHandler);
	}

	// Token: 0x0600B465 RID: 46181 RVA: 0x0030113C File Offset: 0x002FF33C
	protected void OnPress(EInputAction action, float time)
	{
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnPress(action, time);
	}

	// Token: 0x0600B466 RID: 46182 RVA: 0x0030116C File Offset: 0x002FF36C
	protected void OnRelease(EInputAction action, float time)
	{
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnRelease(action, time);
	}

	// Token: 0x0600B467 RID: 46183 RVA: 0x0030119C File Offset: 0x002FF39C
	protected void OnHold(EInputAction action, float time)
	{
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnHold(action, time);
	}

	// Token: 0x0600B468 RID: 46184 RVA: 0x003011CC File Offset: 0x002FF3CC
	protected void OnNodeEnd(ComboTeachingNode node, bool isSuccess)
	{
		ModelBase<ComboTeachingModel>.Instance.IsEmit = true;
		if (!isSuccess)
		{
			base.GetItem(4).SetUIActive(true);
			node.PlayFailAnimation();
			this.RemoveTeachingEventListener();
			TimerSystem.Instance.Delay(delegate(float _)
			{
				ModelBase<ComboTeachingModel>.Instance.ResetComboConfig();
				ModelBase<ComboTeachingModel>.Instance.IsClose = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.ComboTeachingCloseGuide);
				ModelBase<ComboTeachingModel>.Instance.OnComboListEnd();
				this.RefreshComboList(ModelBase<ComboTeachingModel>.Instance.RecoveryComboId);
				this.AddTeachingEventListener();
				this.OnSelectedUpdate();
				base.GetItem(4).SetUIActive(false);
			}, 1000f, null, null, true, 1f);
			return;
		}
		ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex = ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex + 1;
		if (this.NodeList.Count > ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex)
		{
			this.NoCircleAttachView.AttachToIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex, false);
			return;
		}
		if (this.NextGuideId > 0)
		{
			this.UiViewSequence.CloseSequenceName = "Close01";
			if (ConfigBase<ComboTeachingConfig>.Instance.GetComboTeachingConfig(this.NextGuideId).Value.KeyIDLength == 0)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					this.OpenNextGuideView();
				}, 200f, null, null, true, 1f);
				return;
			}
			this.OpenNextGuideView();
			return;
		}
		else
		{
			if (this.IsSuccess)
			{
				return;
			}
			this.IsSuccess = true;
			ModelBase<ComboTeachingModel>.Instance.ResetComboConfig();
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.NoCircleAttachView.Clear();
				GenericPrompt value = ConfigBase<GenericPromptConfig>.Instance.GetPromptInfoByRawId("12900001").Value;
				TableTextArgNew promptMainTextObjByRawId = ConfigBase<GenericPromptConfig>.Instance.GetPromptMainTextObjByRawId("12900001");
				ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>((EPromptSubViewType)value.TypeId, promptMainTextObjByRawId, null, null, null, new int?(int.Parse("12900001")), delegate()
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.ComboTeachingFinish);
					if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ComboTeachingView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.ComboTeachingView))
					{
						base.CloseMe(null);
					}
					ModelBase<ComboTeachingModel>.Instance.IsClose = true;
					Singleton<EventSystem>.Instance.Emit(EEventName.ComboTeachingCloseGuide);
				}, null, null, false, null);
			}, 1000f, null, null, true, 1f);
			return;
		}
	}

	// Token: 0x0600B469 RID: 46185 RVA: 0x00301314 File Offset: 0x002FF514
	protected void OnSelectedUpdate()
	{
		if (this.NoCircleAttachView == null)
		{
			return;
		}
		foreach (ComboTeachingNode comboTeachingNode in this.NoCircleAttachView.GetItems())
		{
			comboTeachingNode.Refresh();
		}
		int currentNodeIndex = ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex;
		if (currentNodeIndex >= this.NodeList.Count)
		{
			return;
		}
		ModelBase<ComboTeachingModel>.Instance.OnCurIndexChanged(this.NodeList[currentNodeIndex]);
	}

	// Token: 0x0600B46A RID: 46186 RVA: 0x003013A4 File Offset: 0x002FF5A4
	protected void OnCharUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		if (this.IsSuccess)
		{
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(charId);
		if (entity != null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null || component.GetEntityType() > EEntityType.Player)
			{
				return;
			}
		}
		ModelBase<ComboTeachingModel>.Instance.IsEmit = false;
		ModelBase<ComboTeachingModel>.Instance.UseSkillId = (long)skillId;
		ModelBase<ComboTeachingModel>.Instance.PreNextAttr = false;
		ModelBase<ComboTeachingModel>.Instance.NextAttr = false;
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnUseSkill(skillId);
	}

	// Token: 0x0600B46B RID: 46187 RVA: 0x00301430 File Offset: 0x002FF630
	protected void OnCharEndSkill(int charId, int skillId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(charId);
		if (entity != null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null || component.GetEntityType() > EEntityType.Player)
			{
				return;
			}
		}
		ModelBase<ComboTeachingModel>.Instance.UseSkillId = 0L;
		ModelBase<ComboTeachingModel>.Instance.UseSkillTime = 0f;
	}

	// Token: 0x0600B46C RID: 46188 RVA: 0x00301480 File Offset: 0x002FF680
	protected void OnNextAttrChanged(int entityId, int skillId, bool nextAttr)
	{
		if (this.IsSuccess)
		{
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null || component.GetEntityType() > EEntityType.Player)
			{
				return;
			}
		}
		ModelBase<ComboTeachingModel>.Instance.NextAttr = nextAttr;
		ModelBase<ComboTeachingModel>.Instance.NextAttrSkillId = (long)skillId;
	}

	// Token: 0x0600B46D RID: 46189 RVA: 0x003014D4 File Offset: 0x002FF6D4
	protected override void OnTick(float delta)
	{
		if (ModelBase<ComboTeachingModel>.Instance.UseSkillId != 0L)
		{
			ModelBase<ComboTeachingModel>.Instance.UseSkillTime += delta;
		}
		ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime -= delta;
		if (ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime < 0f)
		{
			ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime = 0f;
		}
		if (Global.BaseCharacter != null)
		{
			int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
			if (((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null).IsJump && ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime == 0f)
			{
				ModelBase<ComboTeachingModel>.Instance.BeforeJumpTime = 100f;
			}
		}
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnTick(delta);
	}

	// Token: 0x0600B46E RID: 46190 RVA: 0x003015A4 File Offset: 0x002FF7A4
	public void OnHit(global::HitInformation hitData, [Nullable(2)] IAttributeSet attackerAttribute)
	{
		if (this.IsSuccess)
		{
			return;
		}
		ComboTeachingNode itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex);
		if (itemByShowIndex == null)
		{
			return;
		}
		itemByShowIndex.OnBulletHit(hitData);
	}

	// Token: 0x0600B46F RID: 46191 RVA: 0x003015DB File Offset: 0x002FF7DB
	public void OnOpenLoading()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600B470 RID: 46192 RVA: 0x003015E4 File Offset: 0x002FF7E4
	private ComboTeachingNode CreateNoCircleAttachItem(AActor actor, int index, int showNum)
	{
		return new ComboTeachingNode(actor);
	}

	// Token: 0x0600B471 RID: 46193 RVA: 0x003015EC File Offset: 0x002FF7EC
	private void OpenNextGuideView()
	{
		ModelBase<ComboTeachingModel>.Instance.IsClose = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.ComboTeachingCloseGuide);
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ComboTeachingView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.ComboTeachingView))
		{
			base.CloseMe(delegate(bool success)
			{
				if (success)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.ComboTeachingView, this.NextGuideId, null);
				}
			});
		}
	}

	// Token: 0x04005545 RID: 21829
	private const int DRAGITEM_INTERVAL = -280;

	// Token: 0x04005546 RID: 21830
	private const string SHOW_TIP_ID = "12900001";

	// Token: 0x04005547 RID: 21831
	private const int BEFORE_JUMP_TIME = 100;

	// Token: 0x04005548 RID: 21832
	[Nullable(2)]
	private ComboTeachingInputHandler InputHandler;

	// Token: 0x04005549 RID: 21833
	private int NextGuideId = -1;

	// Token: 0x0400554A RID: 21834
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<IComboTeachingInfo, ComboTeachingNode> NoCircleAttachView;

	// Token: 0x0400554B RID: 21835
	private bool IsSuccess;

	// Token: 0x0400554C RID: 21836
	public List<IComboTeachingInfo> NodeList = new List<IComboTeachingInfo>();

	// Token: 0x0400554D RID: 21837
	private bool TeachingEventAdded;

	// Token: 0x0400554E RID: 21838
	private int CurComboId = -1;

	// Token: 0x02007C0B RID: 31755
	[NullableContext(0)]
	private enum EComboTeachingViewDefine
	{
		// Token: 0x0402A614 RID: 173588
		DragPanel,
		// Token: 0x0402A615 RID: 173589
		TextMain,
		// Token: 0x0402A616 RID: 173590
		TextSub,
		// Token: 0x0402A617 RID: 173591
		NodeItem,
		// Token: 0x0402A618 RID: 173592
		MaskItem,
		// Token: 0x0402A619 RID: 173593
		DragContent
	}
}
