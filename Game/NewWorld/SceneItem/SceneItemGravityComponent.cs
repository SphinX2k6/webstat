using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Custom;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047F9 RID: 18425
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemGravityComponent : EntityComponent
	{
		// Token: 0x0602FDB5 RID: 196021 RVA: 0x00B86E7C File Offset: 0x00B8507C
		protected override bool OnInitData(IEntityArgs args = null)
		{
			TrampleComponent trampleComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemGravityComponent>() as TrampleComponent;
			if (trampleComponent == null)
			{
				return false;
			}
			this.CreatureDataComp = base.Entity.CheckGetComponent<CreatureDataComponent>();
			this.CompConfig = trampleComponent;
			this.AnimConfigMsTime = this.CompConfig.DownTime / 0.001f;
			if (this.CompConfig.UpTime != null)
			{
				this.UpAnimConfigMsTime = ((this.CompConfig.UpTime.Value > 0f) ? (this.CompConfig.UpTime.Value / 0.001f) : 0f);
			}
			else
			{
				this.UpAnimConfigMsTime = this.AnimConfigMsTime;
			}
			if (this.CompConfig.ShowLandTipRadius != null)
			{
				this.ShowLandTipRange = (float)this.CompConfig.ShowLandTipRadius.EnterRadius;
				this.HideLandTipRange = (float)this.CompConfig.ShowLandTipRadius.LeaveRadius;
			}
			return true;
		}

		// Token: 0x0602FDB6 RID: 196022 RVA: 0x00B86F70 File Offset: 0x00B85170
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<SceneItemActorComponent>();
			this.TagComp = base.Entity.CheckGetComponent<LevelTagComponent>();
			this.StateComp = base.Entity.CheckGetComponent<SceneItemStateComponent>();
			this.PropComp = base.Entity.CheckGetComponent<SceneItemPropertyComponent>();
			if (!Singleton<EventSystem>.Instance.HasWithTarget<bool, EntityHandle>(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<bool, EntityHandle>(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal));
			}
			if (!Singleton<RangeComponentMessageManager>.Instance.HasMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trample, new TMessageRegisterCallback(this.OnServerMessageEmit)))
			{
				Singleton<RangeComponentMessageManager>.Instance.RegisterMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trample, new TMessageRegisterCallback(this.OnServerMessageEmit));
			}
			return true;
		}

		// Token: 0x0602FDB7 RID: 196023 RVA: 0x00B87048 File Offset: 0x00B85248
		protected override void OnActivate()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Temp;
				ELogAuthor author = ELogAuthor.CH;
				string message = "SceneItemGravityComponent.OnActivate: 重复添加事件";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Singleton<EventSystem>.Instance.AddWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.OnSceneItemLockPropChange));
			if (!Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			if (this.ActorComp.GetIsSceneInteractionLoadCompleted())
			{
				this.OnSceneInteractionLoadCompleted();
			}
			TrampleComponent compConfig = this.CompConfig;
			if (((compConfig != null) ? compConfig.ShowLandTipRadius : null) != null)
			{
				this.CheckDistanceTimerHandle = TimerSystem.Instance.Forever(delegate(float _)
				{
					this.CheckPlayerDistance();
				}, 100f, 1f, null, null, true);
			}
		}

		// Token: 0x0602FDB8 RID: 196024 RVA: 0x00B8719C File Offset: 0x00B8539C
		protected override bool OnEnd()
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget<bool, EntityHandle>(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<bool, EntityHandle>(base.Entity, EEventName.OnEntityInOutRangeLocal, new Action<bool, EntityHandle>(this.OnEntityInOutRangeLocal));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<bool>(base.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.OnSceneItemLockPropChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.OnSceneItemLockPropChange, new Action<bool>(this.OnSceneItemLockPropChange));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<int, bool>(base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnSceneItemStateChange));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnSceneInteractionLoadCompleted, new Action(this.OnSceneInteractionLoadCompleted));
			}
			if (Singleton<RangeComponentMessageManager>.Instance.HasMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trample, new TMessageRegisterCallback(this.OnServerMessageEmit)))
			{
				Singleton<RangeComponentMessageManager>.Instance.UnRegisterMessage(base.Entity, AccessRangeType.RangeEnter, AccessRangeResultType.Trample, new TMessageRegisterCallback(this.OnServerMessageEmit));
			}
			if (this.CheckDistanceTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.CheckDistanceTimerHandle);
				this.CheckDistanceTimerHandle = null;
			}
			this.CloseCountDownTip();
			return true;
		}

		// Token: 0x0602FDB9 RID: 196025 RVA: 0x00B87322 File Offset: 0x00B85522
		protected override void OnTick(float delta)
		{
			this.TickState(delta * this.CustomTimeDilation);
		}

		// Token: 0x0602FDBA RID: 196026 RVA: 0x00B87334 File Offset: 0x00B85534
		protected override void OnChangeTimeDilation(float timeDilation)
		{
			PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
			this.CustomTimeDilation = ((component != null) ? (timeDilation * component.CurrentTimeScale) : 1f);
		}

		// Token: 0x0602FDBB RID: 196027 RVA: 0x00B87365 File Offset: 0x00B85565
		private void OnSceneItemStateChange(int stateId, bool isReady)
		{
			this.OnSceneItemStateChange();
		}

		// Token: 0x0602FDBC RID: 196028 RVA: 0x00B8736D File Offset: 0x00B8556D
		private void OnSceneItemStateChange()
		{
			this.HandleServerChangedState();
		}

		// Token: 0x0602FDBD RID: 196029 RVA: 0x00B87375 File Offset: 0x00B85575
		private void OnSceneItemLockPropChange(bool bLock)
		{
			this.EnableStateTick("[SceneItemGravityComponent] 锁定属性改变");
		}

		// Token: 0x0602FDBE RID: 196030 RVA: 0x00B87382 File Offset: 0x00B85582
		private void OnSceneInteractionLoadCompleted()
		{
			this.EnableStateTick("[SceneItemGravityComponent] 场景交互物加载完毕");
			if (this.StateComp.State != SceneItemStateComponent.ESceneItemState.Born)
			{
				this.OnSceneItemStateChange();
			}
		}

		// Token: 0x0602FDBF RID: 196031 RVA: 0x00B873A4 File Offset: 0x00B855A4
		private void HandleServerChangedState()
		{
			switch (this.StateComp.State)
			{
			case SceneItemStateComponent.ESceneItemState.Normal:
				this.ChangeTransition(true);
				return;
			case SceneItemStateComponent.ESceneItemState.Active:
				this.ChangeAnimState(SceneItemGravityComponent.ESceneItemGravityState.AtBottom);
				return;
			case SceneItemStateComponent.ESceneItemState.Destroy:
				break;
			case SceneItemStateComponent.ESceneItemState.Completed:
				this.CloseCountDownTip();
				this.DisableStateTick("[SceneItemGravityComponent] 重力机关处于完成态");
				return;
			case SceneItemStateComponent.ESceneItemState.Custom:
			{
				LevelTagComponent tagComp = this.TagComp;
				if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.静默"]))
				{
					this.CloseCountDownTip();
					this.DisableStateTick("[SceneItemGravityComponent] 重力机关处于静默态");
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0602FDC0 RID: 196032 RVA: 0x00B87430 File Offset: 0x00B85630
		public void ChangeTransition(bool isUp)
		{
			switch (this.AnimState)
			{
			case SceneItemGravityComponent.ESceneItemGravityState.AtTop:
			case SceneItemGravityComponent.ESceneItemGravityState.Rising:
				if (!isUp)
				{
					this.ChangeAnimState(SceneItemGravityComponent.ESceneItemGravityState.Falling);
					return;
				}
				break;
			case SceneItemGravityComponent.ESceneItemGravityState.AtBottom:
			case SceneItemGravityComponent.ESceneItemGravityState.Falling:
				if (isUp)
				{
					this.ChangeAnimState(SceneItemGravityComponent.ESceneItemGravityState.Rising);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0602FDC1 RID: 196033 RVA: 0x00B87470 File Offset: 0x00B85670
		private unsafe void ChangeAnimState(SceneItemGravityComponent.ESceneItemGravityState targetAnimState)
		{
			if (!this.GetIsLoadComplete())
			{
				return;
			}
			if (this.AnimState == targetAnimState)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SceneItemGravityComponent] ChangeAnimState";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "PbDataId";
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FromAnimState", this.AnimState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ToAnimState", targetAnimState);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (targetAnimState == SceneItemGravityComponent.ESceneItemGravityState.Rising && this.UpAnimConfigMsTime <= 0f)
			{
				this.CloseCountDownTip();
				this.ChangePerformTagByState(this.AnimState, SceneItemGravityComponent.ESceneItemGravityState.AtTop);
				this.AnimState = SceneItemGravityComponent.ESceneItemGravityState.AtTop;
				this.TickState(0f);
				return;
			}
			if (targetAnimState == SceneItemGravityComponent.ESceneItemGravityState.Falling)
			{
				this.OpenCountDownTip();
			}
			if (targetAnimState == SceneItemGravityComponent.ESceneItemGravityState.Rising)
			{
				this.CloseCountDownTip();
			}
			this.ChangePerformTagByState(this.AnimState, targetAnimState);
			this.AnimState = targetAnimState;
			this.TickState(0f);
		}

		// Token: 0x0602FDC2 RID: 196034 RVA: 0x00B87598 File Offset: 0x00B85798
		private void TickState(float delta = 0f)
		{
			if (!this.GetIsLoadComplete())
			{
				this.DisableStateTick("[SceneItemGravityComponent] 场景交互物未初始化");
				return;
			}
			if (!this.GetIsSelfEnable())
			{
				this.DisableStateTick("[SceneItemGravityComponent] 重力机关被停用(完成态或被锁定或静默)");
				return;
			}
			switch (this.AnimState)
			{
			case SceneItemGravityComponent.ESceneItemGravityState.AtTop:
				this.TickAtTop(delta);
				return;
			case SceneItemGravityComponent.ESceneItemGravityState.AtBottom:
				this.TickAtBottom(delta);
				return;
			case SceneItemGravityComponent.ESceneItemGravityState.Rising:
				this.TickRising(delta);
				return;
			case SceneItemGravityComponent.ESceneItemGravityState.Falling:
				this.TickFalling(delta);
				return;
			default:
				return;
			}
		}

		// Token: 0x0602FDC3 RID: 196035 RVA: 0x00B8760A File Offset: 0x00B8580A
		private void TickAtTop(float delta)
		{
			this.DownAnimPlayedMsTime = 0f;
			this.CloseCountDownTip();
			this.DisableStateTick("[SceneItemGravityComponent] 到达顶部");
		}

		// Token: 0x0602FDC4 RID: 196036 RVA: 0x00B87628 File Offset: 0x00B85828
		private void TickAtBottom(float delta)
		{
			this.DownAnimPlayedMsTime = this.AnimConfigMsTime;
			if (this.IsCountDownTipOpen)
			{
				Singleton<EventSystem>.Instance.Emit<float>(EEventName.OnUnOpenedAreaCountDownUpdate, 0f);
				this.IsCountDownTipOpen = false;
			}
			this.DisableStateTick("[SceneItemGravityComponent] 到达底部");
		}

		// Token: 0x0602FDC5 RID: 196037 RVA: 0x00B87668 File Offset: 0x00B85868
		private void TickRising(float delta)
		{
			float num = (this.AnimConfigMsTime > 0f) ? (delta * (this.AnimConfigMsTime / this.UpAnimConfigMsTime)) : delta;
			this.DownAnimPlayedMsTime = Singleton<MathUtils>.Instance.Clamp(this.DownAnimPlayedMsTime - num, 0f, this.AnimConfigMsTime);
			this.EnableStateTick("[SceneItemGravityComponent] 上升中");
			if (this.DownAnimPlayedMsTime <= 0f)
			{
				this.ChangeAnimState(SceneItemGravityComponent.ESceneItemGravityState.AtTop);
			}
		}

		// Token: 0x0602FDC6 RID: 196038 RVA: 0x00B876D7 File Offset: 0x00B858D7
		private void TickFalling(float delta)
		{
			this.DownAnimPlayedMsTime = Singleton<MathUtils>.Instance.Clamp(this.DownAnimPlayedMsTime + delta, 0f, this.AnimConfigMsTime);
			this.UpdateCountDownTip();
			this.EnableStateTick("[SceneItemGravityComponent] 下降中");
		}

		// Token: 0x0602FDC7 RID: 196039 RVA: 0x00B8770D File Offset: 0x00B8590D
		private void ChangePerformTagByState(SceneItemGravityComponent.ESceneItemGravityState fromState, SceneItemGravityComponent.ESceneItemGravityState toState)
		{
			this.ChangeRiseAndFallPerformByState(toState);
			this.ChangeInOutTopAndBottomPerformTagByState(fromState, toState);
		}

		// Token: 0x0602FDC8 RID: 196040 RVA: 0x00B87720 File Offset: 0x00B85920
		private void ChangeRiseAndFallPerformByState(SceneItemGravityComponent.ESceneItemGravityState toState)
		{
			if (this.TagComp == null)
			{
				return;
			}
			int? tagId = null;
			int? tagId2 = null;
			if (toState > SceneItemGravityComponent.ESceneItemGravityState.AtBottom)
			{
				if (toState - SceneItemGravityComponent.ESceneItemGravityState.Rising <= 1)
				{
					if (toState == SceneItemGravityComponent.ESceneItemGravityState.Falling)
					{
						tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升"]);
						tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降"]);
					}
					else
					{
						tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降"]);
						tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升"]);
					}
					bool flag = this.TagComp.HasTag(tagId2.Value);
					bool flag2 = !this.TagComp.HasTag(tagId.Value);
					if (flag || flag2)
					{
						float? num = null;
						if (flag)
						{
							num = this.ActorComp.GetActiveTagSequencePlaybackProgress(GameplayTagUtils.GetGameplayTagById(tagId2.Value).Value);
							this.TagComp.RemoveTag(tagId2);
						}
						if (flag2)
						{
							this.TagComp.AddTag(tagId);
							if (num != null && num.GetValueOrDefault() != 0f)
							{
								float? num2 = num;
								float num3 = (float)1;
								if (num2.GetValueOrDefault() < num3 & num2 != null)
								{
									float progress = Singleton<MathUtils>.Instance.Clamp(1f - num.Value, 0f, 1f);
									this.ActorComp.SetActiveTagSequencePlaybackProgress(GameplayTagUtils.GetGameplayTagById(tagId.Value).Value, progress);
								}
							}
							float durationSecond = (toState == SceneItemGravityComponent.ESceneItemGravityState.Rising) ? this.GetUpTimeSec() : this.CompConfig.DownTime;
							this.ActorComp.SetActiveTagSequenceDurationTime(GameplayTagUtils.GetGameplayTagById(tagId.Value).Value, durationSecond);
							return;
						}
					}
				}
			}
			else
			{
				if (toState == SceneItemGravityComponent.ESceneItemGravityState.AtTop)
				{
					tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升"]);
				}
				else
				{
					tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降"]);
				}
				if (this.TagComp.HasTag(tagId2.Value))
				{
					this.ActorComp.SetActiveTagSequencePlaybackProgress(GameplayTagUtils.GetGameplayTagById(tagId2.Value).Value, 1f);
					this.TagComp.RemoveTag(tagId2);
					return;
				}
				foreach (int num4 in new int[]
				{
					GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升"],
					GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降"]
				})
				{
					if (this.TagComp.HasTag(num4))
					{
						this.TagComp.RemoveTag(new int?(num4));
					}
				}
				this.TagComp.AddTag(tagId2);
				this.ActorComp.SetActiveTagSequencePlaybackProgress(GameplayTagUtils.GetGameplayTagById(tagId2.Value).Value, 1f);
				this.TagComp.RemoveTag(tagId2);
			}
		}

		// Token: 0x0602FDC9 RID: 196041 RVA: 0x00B87A05 File Offset: 0x00B85C05
		[NullableContext(1)]
		private void OnServerMessageEmit(AccessRangeType accessRangeType, AccessRangeResultType accessRangeResultType, Entity otherEntity, ErrorCode errorCode)
		{
			if (errorCode == ErrorCode.ErrOnlineInteractNotOpen || errorCode == ErrorCode.ErrOnlineInteractNoPermission || errorCode == ErrorCode.ErrInteractMultiGameMode)
			{
				ControllerBase<LevelGamePlayController>.Instance.ShowFakeErrorCodeTips(600064);
			}
		}

		// Token: 0x0602FDCA RID: 196042 RVA: 0x00B87A34 File Offset: 0x00B85C34
		private void ChangeInOutTopAndBottomPerformTagByState(SceneItemGravityComponent.ESceneItemGravityState fromState, SceneItemGravityComponent.ESceneItemGravityState toState)
		{
			if (this.TagComp == null)
			{
				return;
			}
			int? tagId = null;
			int? tagId2 = null;
			switch (fromState)
			{
			case SceneItemGravityComponent.ESceneItemGravityState.AtTop:
				tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升到顶"]);
				if (toState == SceneItemGravityComponent.ESceneItemGravityState.Falling)
				{
					tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.顶部下降"]);
				}
				break;
			case SceneItemGravityComponent.ESceneItemGravityState.AtBottom:
				tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降到底"]);
				if (toState == SceneItemGravityComponent.ESceneItemGravityState.Rising)
				{
					tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.底部上升"]);
				}
				break;
			case SceneItemGravityComponent.ESceneItemGravityState.Rising:
				tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.底部上升"]);
				if (toState == SceneItemGravityComponent.ESceneItemGravityState.AtTop)
				{
					tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.上升到顶"]);
				}
				break;
			case SceneItemGravityComponent.ESceneItemGravityState.Falling:
				tagId2 = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.顶部下降"]);
				if (toState == SceneItemGravityComponent.ESceneItemGravityState.AtBottom)
				{
					tagId = new int?(GameplayTagDefine.EGameplayTagId["关卡.Common.表现.踩踏机关.下降到底"]);
				}
				break;
			}
			if (tagId2 != null && this.TagComp.HasTag(tagId2.Value))
			{
				this.TagComp.RemoveTag(tagId2);
			}
			if (tagId != null && !this.TagComp.HasTag(tagId.Value))
			{
				this.TagComp.AddTag(tagId);
			}
		}

		// Token: 0x0602FDCB RID: 196043 RVA: 0x00B87B93 File Offset: 0x00B85D93
		private bool GetIsLoadComplete()
		{
			SceneItemActorComponent actorComp = this.ActorComp;
			return actorComp != null && actorComp.GetIsSceneInteractionLoadCompleted();
		}

		// Token: 0x0602FDCC RID: 196044 RVA: 0x00B87BA8 File Offset: 0x00B85DA8
		private bool GetIsSelfEnable()
		{
			return this.StateComp != null && this.PropComp != null && this.TagComp != null && !this.StateComp.IsInState(SceneItemStateComponent.ESceneItemState.Completed) && !this.PropComp.IsLocked && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["关卡.Common.状态.静默"]);
		}

		// Token: 0x0602FDCD RID: 196045 RVA: 0x00B87C08 File Offset: 0x00B85E08
		private float GetUpTimeSec()
		{
			if (this.CompConfig.UpTime == null)
			{
				return this.CompConfig.DownTime;
			}
			if (this.CompConfig.UpTime.Value <= 0f)
			{
				return 0f;
			}
			return this.CompConfig.UpTime.Value;
		}

		// Token: 0x0602FDCE RID: 196046 RVA: 0x00B87C6C File Offset: 0x00B85E6C
		[NullableContext(1)]
		private void OnEntityInOutRangeLocal(bool isEnter, EntityHandle handle)
		{
			WorldEntity entity = handle.Entity;
			if (((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null) == null && !isEnter)
			{
				return;
			}
			bool? stopTeleControlMove = this.CompConfig.StopTeleControlMove;
			bool flag = false;
			if (stopTeleControlMove.GetValueOrDefault() == flag & stopTeleControlMove != null)
			{
				return;
			}
			SceneItemManipulatableComponent sceneItemManipulatableComponent = (entity != null) ? entity.GetComponent<SceneItemManipulatableComponent>() : null;
			SceneItemActorComponent sceneItemActorComponent = (entity != null) ? entity.GetComponent<SceneItemActorComponent>() : null;
			if (sceneItemManipulatableComponent != null && sceneItemActorComponent != null && sceneItemActorComponent.IsAutonomousProxy)
			{
				sceneItemManipulatableComponent.ForceStopDropping();
			}
		}

		// Token: 0x0602FDCF RID: 196047 RVA: 0x00B87CE5 File Offset: 0x00B85EE5
		private bool IsStateTickEnabled()
		{
			return this.TickDisableHandle == null;
		}

		// Token: 0x0602FDD0 RID: 196048 RVA: 0x00B87CF5 File Offset: 0x00B85EF5
		[NullableContext(1)]
		private void EnableStateTick(string reason)
		{
			if (!this.IsStateTickEnabled() && base.Enable(this.TickDisableHandle, reason))
			{
				this.TickDisableHandle = null;
			}
		}

		// Token: 0x0602FDD1 RID: 196049 RVA: 0x00B87D1A File Offset: 0x00B85F1A
		[NullableContext(1)]
		private void DisableStateTick(string reason)
		{
			if (this.IsStateTickEnabled())
			{
				this.TickDisableHandle = new int?(base.Disable(reason));
			}
		}

		// Token: 0x0602FDD2 RID: 196050 RVA: 0x00B87D38 File Offset: 0x00B85F38
		private void CheckPlayerDistance()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return;
			}
			AActor aactor = baseCharacter;
			SceneItemActorComponent actorComp = this.ActorComp;
			float distanceTo = aactor.GetDistanceTo((actorComp != null) ? actorComp.Owner : null);
			if (!this.ShowingLandTip || distanceTo <= this.HideLandTipRange)
			{
				if (!this.ShowingLandTip && distanceTo < this.ShowLandTipRange)
				{
					this.ShowingLandTip = true;
					ManipulaterModel instance = ModelBase<ManipulaterModel>.Instance;
					if (instance == null)
					{
						return;
					}
					instance.AddShowLandTipsCount(base.Entity);
				}
				return;
			}
			this.ShowingLandTip = false;
			ManipulaterModel instance2 = ModelBase<ManipulaterModel>.Instance;
			if (instance2 == null)
			{
				return;
			}
			instance2.RemoveShowLandTipsCount(base.Entity);
		}

		// Token: 0x0602FDD3 RID: 196051 RVA: 0x00B87DC4 File Offset: 0x00B85FC4
		private void OpenCountDownTip()
		{
			TrampleComponent compConfig = this.CompConfig;
			ICountDownTextTip countDownTextTip = (compConfig != null) ? compConfig.TrampleTipOption : null;
			if (countDownTextTip == null)
			{
				return;
			}
			if (countDownTextTip.Type != ETrampleTipType.CountDownTextTip)
			{
				return;
			}
			if (this.IsCountDownTipOpen)
			{
				return;
			}
			ICountDownTextTip countDownTextTip2 = countDownTextTip;
			UnOpenedAreaCountDownFloatTipsParam param = new UnOpenedAreaCountDownFloatTipsParam
			{
				TidCountDownTip = countDownTextTip2.TidCountDownTip
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.UnOpenedAreaCountDownFloatTips, param, null);
			this.IsCountDownTipOpen = true;
		}

		// Token: 0x0602FDD4 RID: 196052 RVA: 0x00B87E26 File Offset: 0x00B86026
		private void CloseCountDownTip()
		{
			if (!this.IsCountDownTipOpen)
			{
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.UnOpenedAreaCountDownFloatTips, null);
			this.IsCountDownTipOpen = false;
		}

		// Token: 0x0602FDD5 RID: 196053 RVA: 0x00B87E48 File Offset: 0x00B86048
		private void UpdateCountDownTip()
		{
			if (!this.IsCountDownTipOpen)
			{
				return;
			}
			float p = (this.AnimConfigMsTime - this.DownAnimPlayedMsTime) * 0.001f;
			Singleton<EventSystem>.Instance.Emit<float>(EEventName.OnUnOpenedAreaCountDownUpdate, p);
		}

		// Token: 0x17008204 RID: 33284
		// (get) Token: 0x0602FDD6 RID: 196054 RVA: 0x00B87E83 File Offset: 0x00B86083
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> ActivateActions
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				TrampleComponent compConfig = this.CompConfig;
				if (compConfig == null)
				{
					return null;
				}
				return compConfig.EnterActions;
			}
		}

		// Token: 0x17008205 RID: 33285
		// (get) Token: 0x0602FDD7 RID: 196055 RVA: 0x00B87E96 File Offset: 0x00B86096
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ActionInfo> DeactivateActions
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				TrampleComponent compConfig = this.CompConfig;
				if (compConfig == null)
				{
					return null;
				}
				return compConfig.ExitActions;
			}
		}

		// Token: 0x0602FDD8 RID: 196056 RVA: 0x00B87EAC File Offset: 0x00B860AC
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemGravityComponent sceneItemGravityComponent = (SceneItemGravityComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemGravityComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemGravityComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (sceneItemGravityComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (sceneItemGravityComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PropComp"))
			{
				if (sceneItemGravityComponent.PropComp == null)
				{
					this.PropComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemPropertyComponent>(this.PropComp), "PropComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CompConfig"))
			{
				if (sceneItemGravityComponent.CompConfig == null)
				{
					this.CompConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TrampleComponent>(this.CompConfig), "CompConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimState"))
			{
				this.AnimState = sceneItemGravityComponent.AnimState;
			}
			if (base.CanResetComponentProperty("AnimConfigMsTime"))
			{
				this.AnimConfigMsTime = sceneItemGravityComponent.AnimConfigMsTime;
			}
			if (base.CanResetComponentProperty("UpAnimConfigMsTime"))
			{
				this.UpAnimConfigMsTime = sceneItemGravityComponent.UpAnimConfigMsTime;
			}
			if (base.CanResetComponentProperty("DownAnimPlayedMsTime"))
			{
				this.DownAnimPlayedMsTime = sceneItemGravityComponent.DownAnimPlayedMsTime;
			}
			if (base.CanResetComponentProperty("TickDisableHandle"))
			{
				this.TickDisableHandle = sceneItemGravityComponent.TickDisableHandle;
			}
			if (base.CanResetComponentProperty("CustomTimeDilation"))
			{
				this.CustomTimeDilation = sceneItemGravityComponent.CustomTimeDilation;
			}
			if (base.CanResetComponentProperty("IsCountDownTipOpen"))
			{
				this.IsCountDownTipOpen = sceneItemGravityComponent.IsCountDownTipOpen;
			}
			if (base.CanResetComponentProperty("ShowLandTipRange"))
			{
				this.ShowLandTipRange = sceneItemGravityComponent.ShowLandTipRange;
			}
			if (base.CanResetComponentProperty("HideLandTipRange"))
			{
				this.HideLandTipRange = sceneItemGravityComponent.HideLandTipRange;
			}
			if (base.CanResetComponentProperty("ShowingLandTip"))
			{
				this.ShowingLandTip = sceneItemGravityComponent.ShowingLandTip;
			}
			if (base.CanResetComponentProperty("CheckDistanceTimerHandle"))
			{
				if (sceneItemGravityComponent.CheckDistanceTimerHandle == null)
				{
					this.CheckDistanceTimerHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.CheckDistanceTimerHandle), "CheckDistanceTimerHandle"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B74E RID: 112462
		private const int CHECK_DISTANCE_INTERVAL = 100;

		// Token: 0x0401B74F RID: 112463
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B750 RID: 112464
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B751 RID: 112465
		private LevelTagComponent TagComp;

		// Token: 0x0401B752 RID: 112466
		private SceneItemStateComponent StateComp;

		// Token: 0x0401B753 RID: 112467
		private SceneItemPropertyComponent PropComp;

		// Token: 0x0401B754 RID: 112468
		private TrampleComponent CompConfig;

		// Token: 0x0401B755 RID: 112469
		private SceneItemGravityComponent.ESceneItemGravityState AnimState;

		// Token: 0x0401B756 RID: 112470
		private float AnimConfigMsTime;

		// Token: 0x0401B757 RID: 112471
		private float UpAnimConfigMsTime;

		// Token: 0x0401B758 RID: 112472
		private float DownAnimPlayedMsTime;

		// Token: 0x0401B759 RID: 112473
		private int? TickDisableHandle;

		// Token: 0x0401B75A RID: 112474
		private float CustomTimeDilation = 1f;

		// Token: 0x0401B75B RID: 112475
		private bool IsCountDownTipOpen;

		// Token: 0x0401B75C RID: 112476
		private float ShowLandTipRange = -1f;

		// Token: 0x0401B75D RID: 112477
		private float HideLandTipRange = -1f;

		// Token: 0x0401B75E RID: 112478
		private bool ShowingLandTip;

		// Token: 0x0401B75F RID: 112479
		private TimerHandle CheckDistanceTimerHandle;

		// Token: 0x0200A8CC RID: 43212
		[NullableContext(0)]
		private enum ESceneItemGravityState
		{
			// Token: 0x040345C2 RID: 214466
			AtTop,
			// Token: 0x040345C3 RID: 214467
			AtBottom,
			// Token: 0x040345C4 RID: 214468
			Rising,
			// Token: 0x040345C5 RID: 214469
			Falling
		}
	}
}
