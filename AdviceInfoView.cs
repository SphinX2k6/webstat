using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001784 RID: 6020
[NullableContext(1)]
[Nullable(0)]
public class AdviceInfoView : UiViewBase
{
	// Token: 0x0600A9A2 RID: 43426 RVA: 0x002D398C File Offset: 0x002D1B8C
	public AdviceInfoView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600A9A3 RID: 43427 RVA: 0x002D3998 File Offset: 0x002D1B98
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickDisLikeBtn)),
			new ValueTuple<int, Delegate>(7, new Action<EToggleState>(this.OnClickLikeBtn))
		};
	}

	// Token: 0x0600A9A4 RID: 43428 RVA: 0x002D3AB4 File Offset: 0x002D1CB4
	protected override void OnStart()
	{
		this.TimerId = null;
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		if (extendToggle != null)
		{
			extendToggle.SetToggleGroup(null);
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(7);
		if (extendToggle2 != null)
		{
			extendToggle2.CanExecuteChange.Unbind();
			extendToggle2.CanExecuteChange.Bind(new Func<bool>(this.CanClickLikeToggle));
			extendToggle2.SetToggleGroup(null);
		}
		UUIText text = base.GetText(8);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		this.ListCurrentEntityBattleTag();
	}

	// Token: 0x0600A9A5 RID: 43429 RVA: 0x002D3B28 File Offset: 0x002D1D28
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAdviceEntityNotify, new Action(this.OnReceiveEntityRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAdviceVoteNotify, new Action(this.OnReceiveEntityRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.CreateViewInstance, new Action<UiViewBase>(this.OnCreateViewInstance));
		Singleton<EventSystem>.Instance.Add(EEventName.UiSceneStartLoad, new Action(this.OnShowUiScene));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshAdviceInfoView, new Action(this.RefreshAdviceInfoView));
	}

	// Token: 0x0600A9A6 RID: 43430 RVA: 0x002D3BD8 File Offset: 0x002D1DD8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAdviceEntityNotify, new Action(this.OnReceiveEntityRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAdviceVoteNotify, new Action(this.OnReceiveEntityRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.CreateViewInstance, new Action<UiViewBase>(this.OnCreateViewInstance));
		Singleton<EventSystem>.Instance.Remove(EEventName.UiSceneStartLoad, new Action(this.OnShowUiScene));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAdviceInfoView, new Action(this.RefreshAdviceInfoView));
	}

	// Token: 0x0600A9A7 RID: 43431 RVA: 0x002D3C86 File Offset: 0x002D1E86
	private void OnChangeRoleCompleted(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		this.ListCurrentEntityBattleTag();
	}

	// Token: 0x0600A9A8 RID: 43432 RVA: 0x002D3C90 File Offset: 0x002D1E90
	private void ListCurrentEntityBattleTag()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null && getCurrentEntity.Valid)
		{
			WorldEntity entity = getCurrentEntity.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				this.IsPlayerEnterFight = baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
				this.RemoveEnterFightTask();
				if (this.IsPlayerEnterFight)
				{
					base.CloseMe(null);
					return;
				}
				this.ListenPlayerEnterFight(getCurrentEntity);
			}
		}
	}

	// Token: 0x0600A9A9 RID: 43433 RVA: 0x002D3D04 File Offset: 0x002D1F04
	private void ListenPlayerEnterFight(EntityHandle playerEntityHandle)
	{
		WorldEntity entity = playerEntityHandle.Entity;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null)
		{
			this.EnterFightTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]), new BaseTagComponent.TTagSwitchedCallback(this.OnPlayerEnterFight), null);
		}
	}

	// Token: 0x0600A9AA RID: 43434 RVA: 0x002D3D54 File Offset: 0x002D1F54
	private void RemoveEnterFightTask()
	{
		if (this.EnterFightTask != null)
		{
			((ITagTask)this.EnterFightTask).EndTask();
			this.EnterFightTask = null;
		}
	}

	// Token: 0x0600A9AB RID: 43435 RVA: 0x002D3D75 File Offset: 0x002D1F75
	private void OnPlayerEnterFight(int tagId, bool tagExists)
	{
		this.IsPlayerEnterFight = tagExists;
		if (tagExists)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600A9AC RID: 43436 RVA: 0x002D3D88 File Offset: 0x002D1F88
	private bool CanClickLikeToggle()
	{
		return true;
	}

	// Token: 0x0600A9AD RID: 43437 RVA: 0x002D3D8C File Offset: 0x002D1F8C
	private void OnClickDisLikeBtn(EToggleState state)
	{
		int currentEntityId = ModelBase<AdviceModel>.Instance.GetCurrentEntityId();
		Entity entity = Singleton<EntitySystem>.Instance.Get(currentEntityId);
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		long valueOrDefault = num2.GetValueOrDefault();
		AdviceEntityData currentEntityAdviceData = ModelBase<AdviceModel>.Instance.GetCurrentEntityAdviceData();
		bool flag;
		if (currentEntityAdviceData == null)
		{
			flag = true;
		}
		else
		{
			AdviceData adviceData = currentEntityAdviceData.GetAdviceData();
			flag = (adviceData == null || adviceData.GetAdviceBigId() == null);
		}
		if (flag)
		{
			return;
		}
		long value = currentEntityAdviceData.GetAdviceData().GetAdviceBigId().Value;
		long[] upVoteIds = ModelBase<AdviceModel>.Instance.GetUpVoteIds();
		bool flag2 = false;
		long[] array = upVoteIds;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == value)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			return;
		}
		long entityId = Singleton<MathUtils>.Instance.NumberToLong(valueOrDefault);
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		ControllerBase<AdviceController>.Instance.RequestVote(entityId, value, PbAdviceVoteType.Cancel);
	}

	// Token: 0x0600A9AE RID: 43438 RVA: 0x002D3E94 File Offset: 0x002D2094
	private void OnClickLikeBtn(EToggleState state)
	{
		int currentEntityId = ModelBase<AdviceModel>.Instance.GetCurrentEntityId();
		Entity entity = Singleton<EntitySystem>.Instance.Get(currentEntityId);
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		long valueOrDefault = num2.GetValueOrDefault();
		AdviceEntityData currentEntityAdviceData = ModelBase<AdviceModel>.Instance.GetCurrentEntityAdviceData();
		bool flag;
		if (currentEntityAdviceData == null)
		{
			flag = true;
		}
		else
		{
			AdviceData adviceData = currentEntityAdviceData.GetAdviceData();
			flag = (adviceData == null || adviceData.GetAdviceBigId() == null);
		}
		if (flag)
		{
			return;
		}
		long value = currentEntityAdviceData.GetAdviceData().GetAdviceBigId().Value;
		long entityId = Singleton<MathUtils>.Instance.NumberToLong(valueOrDefault);
		UUIExtendToggle extendToggle = base.GetExtendToggle(7);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		long[] upVoteIds = ModelBase<AdviceModel>.Instance.GetUpVoteIds();
		bool flag2 = false;
		long[] array = upVoteIds;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == value)
			{
				flag2 = true;
				break;
			}
		}
		if (flag2)
		{
			ControllerBase<AdviceController>.Instance.RequestVote(entityId, value, PbAdviceVoteType.Cancel);
			return;
		}
		ControllerBase<AdviceController>.Instance.RequestVote(entityId, value, PbAdviceVoteType.Up);
	}

	// Token: 0x0600A9AF RID: 43439 RVA: 0x002D3FAA File Offset: 0x002D21AA
	private void RefreshAdviceInfoView()
	{
		this.InitView();
	}

	// Token: 0x0600A9B0 RID: 43440 RVA: 0x002D3FB2 File Offset: 0x002D21B2
	private void OnReceiveEntityRefresh()
	{
		this.RefreshLikeToggle();
		this.RefreshLikeNum();
	}

	// Token: 0x0600A9B1 RID: 43441 RVA: 0x002D3FC0 File Offset: 0x002D21C0
	private void RefreshLikeToggle()
	{
		long[] upVoteIds = ModelBase<AdviceModel>.Instance.GetUpVoteIds();
		AdviceEntityData currentEntityAdviceData = ModelBase<AdviceModel>.Instance.GetCurrentEntityAdviceData();
		bool flag;
		if (currentEntityAdviceData == null)
		{
			flag = true;
		}
		else
		{
			AdviceData adviceData = currentEntityAdviceData.GetAdviceData();
			flag = (adviceData == null || adviceData.GetAdviceBigId() == null);
		}
		if (flag)
		{
			return;
		}
		long value = currentEntityAdviceData.GetAdviceData().GetAdviceBigId().Value;
		bool flag2 = false;
		long[] array = upVoteIds;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == value)
			{
				flag2 = true;
				break;
			}
		}
		if (!flag2)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(7);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		else
		{
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(7);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			return;
		}
	}

	// Token: 0x0600A9B2 RID: 43442 RVA: 0x002D4071 File Offset: 0x002D2271
	protected override void OnAfterShow()
	{
		this.InitView();
	}

	// Token: 0x0600A9B3 RID: 43443 RVA: 0x002D407C File Offset: 0x002D227C
	private void InitView()
	{
		this.InitTimer();
		this.ActorStartPosition = null;
		ModelBase<InteractionModel>.Instance.SetInteractionHintDisable(true);
		AdviceEntityData currentEntityAdviceData = ModelBase<AdviceModel>.Instance.GetCurrentEntityAdviceData();
		if (currentEntityAdviceData != null)
		{
			this.AdviceDataInstance = currentEntityAdviceData.GetAdviceData();
		}
		this.RefreshView();
	}

	// Token: 0x0600A9B4 RID: 43444 RVA: 0x002D40C1 File Offset: 0x002D22C1
	private void InitTimer()
	{
		this.RemoveTimer();
		if (this.TimerId == null)
		{
			this.TimerId = TimerSystem.Instance.Forever(new TTimerAction(this.TimerCheck), 500f, 1f, null, null, true);
		}
	}

	// Token: 0x0600A9B5 RID: 43445 RVA: 0x002D40FA File Offset: 0x002D22FA
	private void RemoveTimer()
	{
		if (this.TimerId != null)
		{
			TimerSystem.Instance.Remove(this.TimerId);
			this.TimerId = null;
		}
	}

	// Token: 0x0600A9B6 RID: 43446 RVA: 0x002D411C File Offset: 0x002D231C
	private void CachePlayerCurrentPosition()
	{
		if (this.ActorStartPosition != null)
		{
			return;
		}
		global::Vector vector = global::Vector.Create();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) != null)
		{
			vector.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
		}
		this.ActorStartPosition = vector;
	}

	// Token: 0x0600A9B7 RID: 43447 RVA: 0x002D4164 File Offset: 0x002D2364
	private void RefreshView()
	{
		this.RefreshLikeNum();
		this.RefreshText();
		this.RefreshEmojiTexture();
		this.RefreshLikeToggle();
		this.RefreshPlayerName();
	}

	// Token: 0x0600A9B8 RID: 43448 RVA: 0x002D4184 File Offset: 0x002D2384
	private void RefreshLikeNum()
	{
		if (this.AdviceDataInstance == null)
		{
			return;
		}
		long vote = this.AdviceDataInstance.GetVote();
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetText(vote.ToString(), true);
		}
		FColor color = FColor.FromHex((vote >= (long)ConfigBase<AdviceConfig>.Instance.GetAdviceHighNum()) ? "F9D751" : "FFFFFF");
		UUIText text2 = base.GetText(5);
		if (text2 == null)
		{
			return;
		}
		text2.SetColor(color);
	}

	// Token: 0x0600A9B9 RID: 43449 RVA: 0x002D41F2 File Offset: 0x002D23F2
	private void RefreshText()
	{
		UUIText text = base.GetText(4);
		if (text == null)
		{
			return;
		}
		text.SetText(this.AdviceDataInstance.GetAdviceShowText(), true);
	}

	// Token: 0x0600A9BA RID: 43450 RVA: 0x002D4214 File Offset: 0x002D2414
	private void RefreshPlayerName()
	{
		AdviceEntityData currentEntityAdviceData = ModelBase<AdviceModel>.Instance.GetCurrentEntityAdviceData();
		string newText = ((currentEntityAdviceData != null) ? currentEntityAdviceData.GetPlayerName() : null) ?? "";
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600A9BB RID: 43451 RVA: 0x002D4254 File Offset: 0x002D2454
	private void RefreshEmojiTexture()
	{
		if (this.AdviceDataInstance == null)
		{
			return;
		}
		if (this.AdviceDataInstance.GetAdviceExpressionId() > 0)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(this.AdviceDataInstance.GetAdviceExpressionId());
			if (expressionConfig != null)
			{
				base.SetTextureByPath(expressionConfig.Value.ExpressionTexturePath, base.GetTexture(1), null, null);
				return;
			}
		}
		else
		{
			UUITexture texture2 = base.GetTexture(1);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(false);
		}
	}

	// Token: 0x0600A9BC RID: 43452 RVA: 0x002D42E3 File Offset: 0x002D24E3
	private void TimerCheck(float deltaTime)
	{
		this.CachePlayerCurrentPosition();
		this.CheckEntityDistanceIfNeedClose();
		this.CheckPlayerIfMoveAndSetInteractState();
	}

	// Token: 0x0600A9BD RID: 43453 RVA: 0x002D42F8 File Offset: 0x002D24F8
	private void CheckPlayerIfMoveAndSetInteractState()
	{
		if (ModelBase<InteractionModel>.Instance.IsHideInteractHint && this.ActorStartPosition != null)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) != null)
			{
				global::Vector actorLocationProxy = baseCharacter.CharacterActorComponent.ActorLocationProxy;
				if (!this.CheckPositionInRange(actorLocationProxy.X, this.ActorStartPosition.X, 3) || !this.CheckPositionInRange(actorLocationProxy.Y, this.ActorStartPosition.Y, 3) || !this.CheckPositionInRange(actorLocationProxy.Z, this.ActorStartPosition.Z, 3))
				{
					ModelBase<InteractionModel>.Instance.SetInteractionHintDisable(false);
				}
			}
		}
	}

	// Token: 0x0600A9BE RID: 43454 RVA: 0x002D4398 File Offset: 0x002D2598
	private bool CheckPositionInRange(double current, double target, int off)
	{
		int num = (int)Math.Ceiling(current) - (int)Math.Ceiling(target);
		return num < off && num > -1 * off;
	}

	// Token: 0x0600A9BF RID: 43455 RVA: 0x002D43C4 File Offset: 0x002D25C4
	private void CheckEntityDistanceIfNeedClose()
	{
		int currentEntityId = ModelBase<AdviceModel>.Instance.GetCurrentEntityId();
		Entity entity = Singleton<EntitySystem>.Instance.Get(currentEntityId);
		if (entity == null)
		{
			base.CloseMe(null);
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		AActor aactor = (component != null) ? component.Owner : null;
		if (baseCharacter != null && aactor != null)
		{
			FVectorDouble v = aactor.D_K2_GetActorLocation();
			FVectorDouble v2 = baseCharacter.D_K2_GetActorLocation();
			double num = UKismetMathLibrary.D_Vector_Distance(v, v2);
			int adviceViewCloseDistance = ConfigBase<AdviceConfig>.Instance.GetAdviceViewCloseDistance();
			if (num > (double)adviceViewCloseDistance)
			{
				base.CloseMe(null);
			}
		}
	}

	// Token: 0x0600A9C0 RID: 43456 RVA: 0x002D443F File Offset: 0x002D263F
	private void OnCreateViewInstance(UiViewBase view)
	{
		UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(view.ViewInfo.Name);
		if (uiViewInfo != null && uiViewInfo.Type == ELayerType.Normal)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600A9C1 RID: 43457 RVA: 0x002D446E File Offset: 0x002D266E
	private void OnShowUiScene()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A9C2 RID: 43458 RVA: 0x002D4477 File Offset: 0x002D2677
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimer();
		this.RemoveEnterFightTask();
		ModelBase<InteractionModel>.Instance.SetInteractionHintDisable(false);
	}

	// Token: 0x04004FE5 RID: 20453
	private const int CHECKTIMEGAP = 500;

	// Token: 0x04004FE6 RID: 20454
	private const int ROLEMOVERAGE = 3;

	// Token: 0x04004FE7 RID: 20455
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x04004FE8 RID: 20456
	[Nullable(2)]
	private AdviceData AdviceDataInstance;

	// Token: 0x04004FE9 RID: 20457
	[Nullable(2)]
	private object EnterFightTask;

	// Token: 0x04004FEA RID: 20458
	private bool IsPlayerEnterFight;

	// Token: 0x04004FEB RID: 20459
	[Nullable(2)]
	private global::Vector ActorStartPosition;

	// Token: 0x02007AE6 RID: 31462
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A15D RID: 172381
		public const int ContentItem = 0;

		// Token: 0x0402A15E RID: 172382
		public const int EmojiTexture = 1;

		// Token: 0x0402A15F RID: 172383
		public const int NameText = 2;

		// Token: 0x0402A160 RID: 172384
		public const int TextLayout = 3;

		// Token: 0x0402A161 RID: 172385
		public const int ContentText = 4;

		// Token: 0x0402A162 RID: 172386
		public const int LikeNumText = 5;

		// Token: 0x0402A163 RID: 172387
		public const int DislikeToggle = 6;

		// Token: 0x0402A164 RID: 172388
		public const int LikeToggle = 7;

		// Token: 0x0402A165 RID: 172389
		public const int ContentText2 = 8;
	}
}
