using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001890 RID: 6288
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ComboTeachingNode : AutoAttachItem<IComboTeachingInfo>
{
	// Token: 0x0600B43E RID: 46142 RVA: 0x002FFC0B File Offset: 0x002FDE0B
	public ComboTeachingNode(AActor uiItem = null) : base(uiItem)
	{
	}

	// Token: 0x0600B43F RID: 46143 RVA: 0x002FFC20 File Offset: 0x002FDE20
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
	}

	// Token: 0x0600B440 RID: 46144 RVA: 0x002FFD2C File Offset: 0x002FDF2C
	protected override void OnBeforeShow()
	{
		if (this.HasInit && !this.HasAdd)
		{
			this.HasAdd = true;
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
	}

	// Token: 0x0600B441 RID: 46145 RVA: 0x002FFD61 File Offset: 0x002FDF61
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		this.HasAdd = false;
	}

	// Token: 0x0600B442 RID: 46146 RVA: 0x002FFD88 File Offset: 0x002FDF88
	protected UniTask InitAsync()
	{
		ComboTeachingNode.<InitAsync>d__12 <InitAsync>d__;
		<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitAsync>d__.<>4__this = this;
		<InitAsync>d__.<>1__state = -1;
		<InitAsync>d__.<>t__builder.Start<ComboTeachingNode.<InitAsync>d__12>(ref <InitAsync>d__);
		return <InitAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B443 RID: 46147 RVA: 0x002FFDCB File Offset: 0x002FDFCB
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
		this.KeyComponent = null;
	}

	// Token: 0x0600B444 RID: 46148 RVA: 0x002FFDE6 File Offset: 0x002FDFE6
	public override void OnSelect()
	{
	}

	// Token: 0x0600B445 RID: 46149 RVA: 0x002FFDE8 File Offset: 0x002FDFE8
	protected override void OnUnSelect()
	{
	}

	// Token: 0x0600B446 RID: 46150 RVA: 0x002FFDEA File Offset: 0x002FDFEA
	protected override void OnMoveItem()
	{
	}

	// Token: 0x0600B447 RID: 46151 RVA: 0x002FFDEC File Offset: 0x002FDFEC
	protected override void OnRefreshItem(IComboTeachingInfo data)
	{
		this.Data = data;
		if (this.LevelSequencePlayer == null)
		{
			this.InitAsync().ContinueWith(delegate()
			{
				this.InitNode();
				this.Refresh();
			});
			return;
		}
		this.InitNode();
		this.Refresh();
	}

	// Token: 0x0600B448 RID: 46152 RVA: 0x002FFE24 File Offset: 0x002FE024
	public void InitNode()
	{
		if (!this.HasInit && !this.HasAdd)
		{
			this.HasAdd = true;
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}
		this.HasInit = true;
		int index = this.Data.Index;
		ComboTeaching config = this.Data.Config;
		bool isHoldAction = this.Data.IsHoldAction;
		if (index >= config.KeyIDLength || string.IsNullOrEmpty(config.KeyID(index)))
		{
			this.RootItem.SetAlpha(0f);
			return;
		}
		string[] array = config.KeyID(index).Split(';', StringSplitOptions.None);
		string text = array[0];
		string text2 = (array.Length > 1) ? array[1] : null;
		string key = text.Split('#', StringSplitOptions.None)[0];
		EInputAction checkAction;
		ComboTeachingNodeDefine.KeyMap.TryGetValue(key, out checkAction);
		this.CheckAction = checkAction;
		string text3;
		ComboTeachingNodeDefine.ActionMap.TryGetValue(key, out text3);
		if (text3 == null)
		{
			text3 = "";
		}
		if (config.Id == 15111001 && index == 1)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				text3 = "UI键盘F手柄A";
			}
			else
			{
				text3 = "UI左键点击";
			}
		}
		InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
		{
			ActionOrAxisName = text3
		};
		InputMultiKeyItem keyComponent = this.KeyComponent;
		if (keyComponent != null)
		{
			keyComponent.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
		}
		if (isHoldAction)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
		}
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		if (text2 != null && text2.Length > 0)
		{
			int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
			SSkillInfo skillInfo = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint).GetComponent<CharacterSkillComponent>().GetSkillInfo(int.Parse(text2));
			if (skillInfo != null)
			{
				FSoftObjectPath skillIcon = skillInfo.SkillIcon;
				this.SetSpriteByPath((skillIcon != null) ? skillIcon.AssetPathName.ToString() : null, base.GetSprite(0), false, new EUiViewName?(EUiViewName.ComboTeachingView), null);
			}
		}
		if (config.IconTagTextLength > index && config.IconTagText(index) != "")
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), config.IconTagText(index), Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), (index < config.IconTextLength) ? config.IconText(index) : null, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.ReplaceWildCard(base.GetText(7));
		base.GetSprite(3).SetFillAmount(0f);
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(this.Data.IsShowTag);
		}
		base.GetSprite(3).SetUIActive(isHoldAction);
		base.GetItem(10).SetUIActive(isHoldAction);
	}

	// Token: 0x0600B449 RID: 46153 RVA: 0x003000F4 File Offset: 0x002FE2F4
	public void Refresh()
	{
		if (this.Data == null)
		{
			return;
		}
		int currentNodeIndex = ModelBase<ComboTeachingModel>.Instance.CurrentNodeIndex;
		if (currentNodeIndex == this.Data.Index)
		{
			base.GetSprite(1).SetUIActive(false);
			base.GetSprite(2).SetUIActive(false);
			base.GetItem(6).SetUIActive(true);
			return;
		}
		if (currentNodeIndex < this.Data.Index)
		{
			base.GetSprite(1).SetUIActive(false);
			base.GetSprite(2).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			return;
		}
		if (currentNodeIndex > this.Data.Index)
		{
			base.GetSprite(1).SetUIActive(true);
			base.GetSprite(2).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
		}
	}

	// Token: 0x0600B44A RID: 46154 RVA: 0x003001B8 File Offset: 0x002FE3B8
	public void PlayFailAnimation()
	{
		base.GetSprite(2).SetUIActive(true);
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("ClickRigMIs", false, null, false);
	}

	// Token: 0x0600B44B RID: 46155 RVA: 0x003001FC File Offset: 0x002FE3FC
	public void PlaySuccessAnimation()
	{
		base.GetSprite(1).SetUIActive(true);
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("ClickRigMIs", false, null, false);
	}

	// Token: 0x0600B44C RID: 46156 RVA: 0x00300240 File Offset: 0x002FE440
	public void OnPress(EInputAction action, float time)
	{
		CheckKeyCondition param = new CheckKeyCondition
		{
			ActionKey = action,
			ActionType = EComboKeyType.Press
		};
		if (this.Data.SuccessCondition.GetConditionType() == 10)
		{
			this.CheckSuccessDelay(param);
		}
		if (ModelBase<ComboTeachingModel>.Instance.CheckFailCondition(this.Data, EComboTeachingFailCondition.PressKey))
		{
			this.CheckFailDelay(param);
		}
	}

	// Token: 0x0600B44D RID: 46157 RVA: 0x00300298 File Offset: 0x002FE498
	public void OnRelease(EInputAction action, float time)
	{
		this.HoldTime = 0f;
		base.GetSprite(3).SetFillAmount(0f);
		this.LevelSequencePlayer.StopSequenceByKey("LongPress", false, false);
		if (this.Data.IsHoldAction)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
		}
		if (!this.Data.IsEmit && this.Data.IsHoldAction)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(this.Data.IsShowTag);
			}
		}
		base.GetItem(8).SetUIActive(false);
		base.GetItem(6).SetUIActive(true);
		CheckKeyCondition param = new CheckKeyCondition
		{
			ActionKey = action,
			ActionType = EComboKeyType.Release
		};
		if (this.Data.SuccessCondition.GetConditionType() == 10)
		{
			this.CheckSuccessDelay(param);
		}
		if (ModelBase<ComboTeachingModel>.Instance.CheckFailCondition(this.Data, EComboTeachingFailCondition.PressKey))
		{
			this.CheckFailDelay(param);
		}
	}

	// Token: 0x0600B44E RID: 46158 RVA: 0x00300398 File Offset: 0x002FE598
	public void OnHold(EInputAction action, float time)
	{
		if (this.Data.IsHoldAction && action == this.CheckAction)
		{
			this.HoldTime = time;
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(this.Data.IsShowTag);
			}
			base.GetSprite(3).SetFillAmount(this.HoldTime / this.Data.HoldTotalTime);
			if (this.LevelSequencePlayer.GetCurrentSequence() != "LongPress")
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("LongPress", false, null, false);
				base.GetItem(8).SetUIActive(true);
				base.GetItem(6).SetUIActive(false);
			}
			CheckKeyCondition param = new CheckKeyCondition
			{
				ActionKey = action,
				ActionType = EComboKeyType.Hold,
				HoldTime = new float?(time)
			};
			if (this.Data.SuccessCondition.GetConditionType() == 11)
			{
				this.CheckSuccessDelay(param);
			}
			if (ModelBase<ComboTeachingModel>.Instance.CheckFailCondition(this.Data, EComboTeachingFailCondition.HoldKey))
			{
				this.CheckFailDelay(param);
			}
		}
	}

	// Token: 0x0600B44F RID: 46159 RVA: 0x003004AC File Offset: 0x002FE6AC
	public void OnUseSkill(int skillId)
	{
		bool flag = ModelBase<ComboTeachingModel>.Instance.CheckFailCondition(this.Data, EComboTeachingFailCondition.SkillIdChecker);
		if (!this.Data.IsHoldAction && flag)
		{
			this.CheckFailDelay(null);
		}
	}

	// Token: 0x0600B450 RID: 46160 RVA: 0x003004E4 File Offset: 0x002FE6E4
	public void OnTick(float delta)
	{
		if (this.Data.IsEmit)
		{
			return;
		}
		if (this.Data.NeedTickSummon)
		{
			ModelBase<ComboTeachingModel>.Instance.CheckSummonBuffAdd(this.Data);
		}
		if (this.Data.SuccessCondition == null)
		{
			return;
		}
		if (this.Data.SuccessCondition.Type == EComboTeachingCheckType.Update && this.CheckSuccessCondition(null))
		{
			return;
		}
		this.CheckFailCondition();
	}

	// Token: 0x0600B451 RID: 46161 RVA: 0x00300550 File Offset: 0x002FE750
	public void CheckSuccessDelay(IBaseCheckConditionInfo param = null)
	{
		if (this.Data.SuccessDelay == 0f)
		{
			this.CheckSuccessCondition(param);
			return;
		}
		if (this.Data.SuccessHandle != null)
		{
			if (TimerSystem.Instance.Has(this.Data.SuccessHandle))
			{
				TimerSystem.Instance.Remove(this.Data.SuccessHandle);
			}
			this.Data.SuccessHandle = null;
		}
		this.Data.SuccessHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CheckSuccessCondition(param);
		}, this.Data.SuccessDelay, null, null, true, 1f);
	}

	// Token: 0x0600B452 RID: 46162 RVA: 0x0030060C File Offset: 0x002FE80C
	public bool CheckSuccessCondition(IBaseCheckConditionInfo param = null)
	{
		if (!this.Data.SuccessCondition.Check(this.Data, param) || this.Data.IsEmit)
		{
			return false;
		}
		if (!Singleton<EventSystem>.Instance.Emit<ComboTeachingNode, bool>(EEventName.ComboTeachingNodeEnd, this, true))
		{
			return false;
		}
		this.LevelSequencePlayer.StopSequenceByKey("LongPress", false, false);
		this.LevelSequencePlayer.StopCurrentSequence(false, true);
		this.LevelSequencePlayer.PlayLevelSequenceByName("ClickRigMIs", false, null, false);
		base.GetItem(8).SetUIActive(false);
		this.Data.IsEmit = true;
		return true;
	}

	// Token: 0x0600B453 RID: 46163 RVA: 0x003006AC File Offset: 0x002FE8AC
	public void CheckFailCondition()
	{
		if (this.Data.IsEmit)
		{
			return;
		}
		bool flag = false;
		foreach (BaseCheckCondition baseCheckCondition in this.Data.FailUpdateCondition)
		{
			flag = (baseCheckCondition.Check(this.Data, null) || flag);
		}
		if (flag)
		{
			if (!Singleton<EventSystem>.Instance.Emit<ComboTeachingNode, bool>(EEventName.ComboTeachingNodeEnd, this, false))
			{
				return;
			}
			this.LevelSequencePlayer.StopCurrentSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("ClickRigMIs", false, null, false);
			this.Data.IsEmit = true;
		}
	}

	// Token: 0x0600B454 RID: 46164 RVA: 0x00300768 File Offset: 0x002FE968
	public void CheckFailDelay(IBaseCheckConditionInfo param = null)
	{
		if (this.Data.FailDelay == 0f)
		{
			this.CheckFailEventCondition(param);
			return;
		}
		if (this.Data.FailHandle != null)
		{
			if (TimerSystem.Instance.Has(this.Data.FailHandle))
			{
				TimerSystem.Instance.Remove(this.Data.FailHandle);
			}
			this.Data.FailHandle = null;
		}
		this.Data.FailHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.CheckFailEventCondition(param);
		}, this.Data.FailDelay, null, null, true, 1f);
	}

	// Token: 0x0600B455 RID: 46165 RVA: 0x00300824 File Offset: 0x002FEA24
	public void CheckFailEventCondition(IBaseCheckConditionInfo param = null)
	{
		if (this.Data.IsEmit)
		{
			return;
		}
		bool flag = false;
		foreach (BaseCheckCondition baseCheckCondition in this.Data.FailEventCondition)
		{
			flag = (baseCheckCondition.Check(this.Data, param) || flag);
		}
		if (flag)
		{
			if (!Singleton<EventSystem>.Instance.Emit<ComboTeachingNode, bool>(EEventName.ComboTeachingNodeEnd, this, false))
			{
				return;
			}
			this.LevelSequencePlayer.StopCurrentSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("ClickRigMIs", false, null, false);
			this.Data.IsEmit = true;
		}
	}

	// Token: 0x0600B456 RID: 46166 RVA: 0x003008E0 File Offset: 0x002FEAE0
	[NullableContext(1)]
	public void OnBulletHit(HitInformation hitInfo)
	{
		int conditionType = this.Data.SuccessCondition.GetConditionType();
		if (conditionType != 9 && conditionType != 1)
		{
			return;
		}
		CharacterSkillComponent component = hitInfo.Attacker.GetComponent<CharacterSkillComponent>();
		CheckSkillHitCondition checkSkillHitCondition = new CheckSkillHitCondition();
		int? num;
		if (component == null)
		{
			num = null;
		}
		else
		{
			global::Skill currentSkill = component.CurrentSkill;
			num = ((currentSkill != null) ? new int?(currentSkill.SkillId) : null);
		}
		int? num2 = num;
		checkSkillHitCondition.HitSkillId = (long)num2.GetValueOrDefault();
		checkSkillHitCondition.BulletId = hitInfo.BulletId;
		CheckSkillHitCondition param = checkSkillHitCondition;
		this.CheckSuccessDelay(param);
	}

	// Token: 0x0600B457 RID: 46167 RVA: 0x0030096C File Offset: 0x002FEB6C
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		int index = this.Data.Index;
		ComboTeaching config = this.Data.Config;
		if (index >= config.KeyIDLength || string.IsNullOrEmpty(config.KeyID(index)))
		{
			return;
		}
		string key = config.KeyID(index).Split(';', StringSplitOptions.None)[0].Split('#', StringSplitOptions.None)[0];
		EInputAction checkAction;
		ComboTeachingNodeDefine.KeyMap.TryGetValue(key, out checkAction);
		this.CheckAction = checkAction;
		string text;
		ComboTeachingNodeDefine.ActionMap.TryGetValue(key, out text);
		if (text == null)
		{
			text = "";
		}
		if (config.Id == 15111001 && index == 1)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				text = "UI键盘F手柄A";
			}
			else
			{
				text = "UI左键点击";
			}
		}
		InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
		{
			ActionOrAxisName = text
		};
		InputMultiKeyItem keyComponent = this.KeyComponent;
		if (keyComponent == null)
		{
			return;
		}
		keyComponent.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
	}

	// Token: 0x0400553E RID: 21822
	private EInputAction CheckAction = EInputAction.None;

	// Token: 0x0400553F RID: 21823
	private IComboTeachingInfo Data;

	// Token: 0x04005540 RID: 21824
	public float HoldTime;

	// Token: 0x04005541 RID: 21825
	protected bool HasInit;

	// Token: 0x04005542 RID: 21826
	protected bool HasAdd;

	// Token: 0x04005543 RID: 21827
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04005544 RID: 21828
	public InputMultiKeyItem KeyComponent;

	// Token: 0x02007C07 RID: 31751
	[NullableContext(0)]
	private enum EComboTeachingNodeDefine
	{
		// Token: 0x0402A600 RID: 173568
		ActionIcon,
		// Token: 0x0402A601 RID: 173569
		SuccessTexture,
		// Token: 0x0402A602 RID: 173570
		FailTexture,
		// Token: 0x0402A603 RID: 173571
		CdSprite,
		// Token: 0x0402A604 RID: 173572
		TopTagItem,
		// Token: 0x0402A605 RID: 173573
		TopTagText,
		// Token: 0x0402A606 RID: 173574
		SelectedItem,
		// Token: 0x0402A607 RID: 173575
		DescriptionText,
		// Token: 0x0402A608 RID: 173576
		HoldEffectItem,
		// Token: 0x0402A609 RID: 173577
		KeyItem,
		// Token: 0x0402A60A RID: 173578
		CdItem
	}
}
