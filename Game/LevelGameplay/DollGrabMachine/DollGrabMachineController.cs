using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED7 RID: 28375
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	[TickController(0)]
	public class DollGrabMachineController : ControllerBase<DollGrabMachineController>
	{
		// Token: 0x1700A40B RID: 41995
		// (get) Token: 0x06044C06 RID: 281606 RVA: 0x011DE5FF File Offset: 0x011DC7FF
		public bool IsGameplayReady
		{
			get
			{
				return this.IsGameplayReadyInternal;
			}
		}

		// Token: 0x1700A40C RID: 41996
		// (get) Token: 0x06044C07 RID: 281607 RVA: 0x011DE607 File Offset: 0x011DC807
		public bool IsEndlessMode
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				return dollGrabMachineComponent != null && dollGrabMachineComponent.IsEndlessMode;
			}
		}

		// Token: 0x1700A40D RID: 41997
		// (get) Token: 0x06044C08 RID: 281608 RVA: 0x011DE61A File Offset: 0x011DC81A
		public int LeaveDollCount
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return 0;
				}
				return dollGrabMachineComponent.LeaveDollCount;
			}
		}

		// Token: 0x1700A40E RID: 41998
		// (get) Token: 0x06044C09 RID: 281609 RVA: 0x011DE62D File Offset: 0x011DC82D
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IGrabItemData> CurrentDropItemList
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return null;
				}
				return dollGrabMachineComponent.CurrentDropItemList;
			}
		}

		// Token: 0x1700A40F RID: 41999
		// (get) Token: 0x06044C0A RID: 281610 RVA: 0x011DE640 File Offset: 0x011DC840
		public float PlayCost
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return 0f;
				}
				return dollGrabMachineComponent.PlayCost;
			}
		}

		// Token: 0x1700A410 RID: 42000
		// (get) Token: 0x06044C0B RID: 281611 RVA: 0x011DE657 File Offset: 0x011DC857
		public bool HasGrabbingActor
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				return dollGrabMachineComponent != null && dollGrabMachineComponent.HasGrabbingActor;
			}
		}

		// Token: 0x1700A411 RID: 42001
		// (get) Token: 0x06044C0C RID: 281612 RVA: 0x011DE66C File Offset: 0x011DC86C
		public EDollGrabMachineClawState? ClawState
		{
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return null;
				}
				DgmClawBaseMoveState clawState = dollGrabMachineComponent.ClawState;
				if (clawState == null)
				{
					return null;
				}
				return new EDollGrabMachineClawState?(clawState.ClawState);
			}
		}

		// Token: 0x1700A412 RID: 42002
		// (get) Token: 0x06044C0D RID: 281613 RVA: 0x011DE6AA File Offset: 0x011DC8AA
		public bool IsDangerousCountdown
		{
			get
			{
				return this.IsDangerousCountdownInternal;
			}
		}

		// Token: 0x1700A413 RID: 42003
		// (get) Token: 0x06044C0E RID: 281614 RVA: 0x011DE6B2 File Offset: 0x011DC8B2
		[Nullable(2)]
		public IDollGrabInfiniteRewardData EndlessRewardData
		{
			[NullableContext(2)]
			get
			{
				SceneItemDollGrabMachineComponent dollGrabMachineComponent = this.DollGrabMachineComponent;
				if (dollGrabMachineComponent == null)
				{
					return null;
				}
				return dollGrabMachineComponent.EndlessRewardData;
			}
		}

		// Token: 0x1700A414 RID: 42004
		// (get) Token: 0x06044C0F RID: 281615 RVA: 0x011DE6C5 File Offset: 0x011DC8C5
		[Nullable(2)]
		public SceneItemDollGrabMachineComponent CurrentDollGrabMachineComponent
		{
			[NullableContext(2)]
			get
			{
				return this.DollGrabMachineComponent;
			}
		}

		// Token: 0x06044C10 RID: 281616 RVA: 0x011DE6D0 File Offset: 0x011DC8D0
		protected override bool OnInit()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineController] 初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<DollGrabModel>.Instance.LoadDollGrabMachineGlobalConfig();
			base.PauseTick();
			return true;
		}

		// Token: 0x06044C11 RID: 281617 RVA: 0x011DE70D File Offset: 0x011DC90D
		public void RegisterDollGrabMachine(SceneItemDollGrabMachineComponent comp)
		{
			if (this.DollGrabMachineComponentSet.Contains(comp))
			{
				return;
			}
			this.DollGrabMachineComponentSet.Add(comp);
			ModelBase<DollGrabModel>.Instance.LoadDollGrabClawSequence(new Action(this.OnDollGrabClawSequenceLoaded));
		}

		// Token: 0x06044C12 RID: 281618 RVA: 0x011DE744 File Offset: 0x011DC944
		public void UnregisterDollGrabMachine(SceneItemDollGrabMachineComponent comp)
		{
			if (!this.DollGrabMachineComponentSet.Contains(comp))
			{
				return;
			}
			this.DollGrabMachineComponentSet.Remove(comp);
			if (this.DollGrabMachineComponent == comp && this.IsInCountdownInternal)
			{
				this.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exception, false);
			}
			if (this.DollGrabMachineComponentSet.Count == 0)
			{
				ModelBase<DollGrabModel>.Instance.DollGrabClawSequence = null;
			}
		}

		// Token: 0x06044C13 RID: 281619 RVA: 0x011DE7A0 File Offset: 0x011DC9A0
		private void OnDollGrabClawSequenceLoaded()
		{
			foreach (SceneItemDollGrabMachineComponent sceneItemDollGrabMachineComponent in this.DollGrabMachineComponentSet)
			{
				sceneItemDollGrabMachineComponent.OnClawSequenceLoaded();
			}
		}

		// Token: 0x06044C14 RID: 281620 RVA: 0x011DE7F0 File Offset: 0x011DC9F0
		public void StartDollGrabMachine(IDollGrab config)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(config.TargetDollGrabMachineId);
			if (!entityByPbDataId || !entityByPbDataId.Entity)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.DollGrabMachine;
				ELogAuthor author = ELogAuthor.FJH;
				string message = "[StartDollGrabMachine] 娃娃机实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", config.TargetDollGrabMachineId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.DollGrabMachineComponent = entityByPbDataId.Entity.GetComponent<SceneItemDollGrabMachineComponent>();
			if (this.DollGrabMachineComponent == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.DollGrabMachine;
				ELogAuthor author2 = ELogAuthor.FJH;
				string message2 = "[StartDollGrabMachine] 娃娃机实体没有SceneItemDollGrabMachineComponent组件";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", config.TargetDollGrabMachineId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnDollGrabEntityDestroy)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnDollGrabEntityDestroy));
			}
			this.DollGrabMachineComponent.StartDissolve();
			TsInteractionUtils.RegisterOpenViewName(EUiViewName.DollGrabMachineView);
			if (this.IsEndlessMode && ControllerBase<GuideController>.Instance.TryStartGuide(34303))
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideFinish));
				Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupBreak, new Action<int>(this.OnGuideFinish));
				Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupRest, new Action<int>(this.OnGuideFinish));
			}
			else
			{
				this.OnGuideFinish(34303);
			}
			if (!Singleton<EventSystem>.Instance.Has<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange)))
			{
				Singleton<EventSystem>.Instance.Add<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			}
		}

		// Token: 0x06044C15 RID: 281621 RVA: 0x011DE9AC File Offset: 0x011DCBAC
		private void OnGuideFinish(int groupId)
		{
			if (groupId != 34303)
			{
				return;
			}
			if (Singleton<EventSystem>.Instance.Has<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideFinish)))
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideFinish));
			}
			if (Singleton<EventSystem>.Instance.Has<int>(EEventName.GuideGroupBreak, new Action<int>(this.OnGuideFinish)))
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.GuideGroupBreak, new Action<int>(this.OnGuideFinish));
			}
			if (Singleton<EventSystem>.Instance.Has<int>(EEventName.GuideGroupRest, new Action<int>(this.OnGuideFinish)))
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.GuideGroupRest, new Action<int>(this.OnGuideFinish));
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineView, null, null);
			if (!Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseDollGrabMachineView)))
			{
				Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseDollGrabMachineView));
			}
			int pbDataId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetPbDataId();
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnDollGrabMachineGameplayStateChanged, pbDataId, true);
		}

		// Token: 0x06044C16 RID: 281622 RVA: 0x011DEADC File Offset: 0x011DCCDC
		private void StartDollGrabMachineInternal()
		{
			DollGarbStartRequest dollGarbStartRequest = DollGarbStartRequest.Create();
			dollGarbStartRequest.EntityIncId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
			this.IsRequesting = true;
			this.IsInCountdownInternal = false;
			Singleton<Net>.Instance.Call<DollGarbStartResponse>(ERequestMessageId.DollGarbStartRequest, dollGarbStartRequest, delegate(DollGarbStartResponse response, Net.CallbackStatus _)
			{
				this.IsRequesting = false;
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[StartDollGrabMachine] 开启玩法请求失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.IsGameplayReadyInternal = true;
				this.DollGrabMachineComponent.OnStartDollGrabMachine();
				this.RemainingTimeInternal = this.DollGrabMachineComponent.TimeLimit * 1000f;
				this.RemainingTimeLimitInternal = this.RemainingTimeInternal;
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabFloatCountDownView, null, null);
				if (!Singleton<EventSystem>.Instance.Has<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnAddRemainingTime)))
				{
					Singleton<EventSystem>.Instance.Add<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnAddRemainingTime));
				}
			}, 0);
		}

		// Token: 0x06044C17 RID: 281623 RVA: 0x011DEB35 File Offset: 0x011DCD35
		public void RegisterTick(SceneItemDollGrabMachineComponent comp)
		{
			if (this.TickComponentSet.Contains(comp))
			{
				return;
			}
			this.TickComponentSet.Add(comp);
			base.ResumeTick();
		}

		// Token: 0x06044C18 RID: 281624 RVA: 0x011DEB59 File Offset: 0x011DCD59
		public void UnregisterTick(SceneItemDollGrabMachineComponent comp)
		{
			if (!this.TickComponentSet.Contains(comp))
			{
				return;
			}
			this.TickComponentSet.Remove(comp);
			if (this.TickComponentSet.Count == 0)
			{
				base.PauseTick();
			}
		}

		// Token: 0x06044C19 RID: 281625 RVA: 0x011DEB8A File Offset: 0x011DCD8A
		public bool CheckRegisterTick(SceneItemDollGrabMachineComponent comp)
		{
			return this.TickComponentSet.Contains(comp);
		}

		// Token: 0x06044C1A RID: 281626 RVA: 0x011DEB98 File Offset: 0x011DCD98
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			if (this.IsGameplayReadyInternal)
			{
				this.RemainingTimeInternal -= delta;
				this.AddRemainingTimeInternal -= delta;
				if (this.AddRemainingTimeInternal < 0f)
				{
					this.AddRemainingTimeInternal = 0f;
				}
				if (this.RemainingTimeInternal <= 0f)
				{
					this.PreExitDollGrabMachine(EDollGrabMachineEndReason.TimeUp, false);
				}
				else
				{
					if (this.RemainingTimeInternal < ModelBase<DollGrabModel>.Instance.DangerousCountdown && !this.IsDangerousCountdown)
					{
						this.ToggleScreenEffect(true);
						this.IsDangerousCountdownInternal = true;
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineDangerousCountdown, true);
					}
					if (this.RemainingTimeInternal >= ModelBase<DollGrabModel>.Instance.DangerousCountdown && this.IsDangerousCountdown)
					{
						this.ToggleScreenEffect(false);
						this.IsDangerousCountdownInternal = false;
						Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnDollGrabMachineDangerousCountdown, false);
					}
				}
			}
			foreach (SceneItemDollGrabMachineComponent sceneItemDollGrabMachineComponent in this.TickComponentSet)
			{
				sceneItemDollGrabMachineComponent.ExecuteTick(delta);
			}
		}

		// Token: 0x06044C1B RID: 281627 RVA: 0x011DECB8 File Offset: 0x011DCEB8
		public void OnClickMoveInput(string name, InputDistributeDefine.EActionType actionType)
		{
			if (!this.IsAllowMoveInput())
			{
				return;
			}
			DgmClawBaseMoveState clawState = this.DollGrabMachineComponent.ClawState;
			if (clawState == null || clawState.ClawState > EDollGrabMachineClawState.Idle)
			{
				DgmClawBaseMoveState clawState2 = this.DollGrabMachineComponent.ClawState;
				if (clawState2 == null || clawState2.ClawState != EDollGrabMachineClawState.Release)
				{
					DgmClawBaseMoveState clawState3 = this.DollGrabMachineComponent.ClawState;
					if (clawState3 == null || clawState3.ClawState != EDollGrabMachineClawState.Grabbing)
					{
						this.DollGrabMachineComponent.ClawMoveDirection.Y = 0f;
						this.DollGrabMachineComponent.ClawMoveDirection.X = 0f;
						this.PressedKey.Clear();
						return;
					}
				}
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.PressedKey.Add(name);
			}
			else
			{
				this.PressedKey.Remove(name);
			}
			this.DollGrabMachineComponent.ClawMoveDirection.Y = 0f;
			this.DollGrabMachineComponent.ClawMoveDirection.X = 0f;
			foreach (string a in this.PressedKey)
			{
				if (a == "向前移动")
				{
					this.DollGrabMachineComponent.ClawMoveDirection.Y -= 1f;
				}
				else if (a == "向后移动")
				{
					this.DollGrabMachineComponent.ClawMoveDirection.Y += 1f;
				}
				else if (a == "向左移动")
				{
					this.DollGrabMachineComponent.ClawMoveDirection.X -= 1f;
				}
				else if (a == "向右移动")
				{
					this.DollGrabMachineComponent.ClawMoveDirection.X += 1f;
				}
			}
		}

		// Token: 0x06044C1C RID: 281628 RVA: 0x011DEE98 File Offset: 0x011DD098
		public void OnAxisMoveInput(string name, float value)
		{
			if (!this.IsAllowMoveInput())
			{
				return;
			}
			DgmClawBaseMoveState clawState = this.DollGrabMachineComponent.ClawState;
			if (clawState == null || clawState.ClawState > EDollGrabMachineClawState.Idle)
			{
				DgmClawBaseMoveState clawState2 = this.DollGrabMachineComponent.ClawState;
				if (clawState2 == null || clawState2.ClawState != EDollGrabMachineClawState.Release)
				{
					DgmClawBaseMoveState clawState3 = this.DollGrabMachineComponent.ClawState;
					if (clawState3 == null || clawState3.ClawState != EDollGrabMachineClawState.Grabbing)
					{
						this.DollGrabMachineComponent.ClawMoveDirection.Y = 0f;
						this.DollGrabMachineComponent.ClawMoveDirection.X = 0f;
						this.PressedKey.Clear();
						return;
					}
				}
			}
			if (name == "NavigationTopDown" || name == "UiMoveForward")
			{
				this.DollGrabMachineComponent.ClawMoveDirection.Y = -value;
				return;
			}
			if (name == "NavigationLeftRight" || name == "UiMoveRight")
			{
				this.DollGrabMachineComponent.ClawMoveDirection.X = value;
			}
		}

		// Token: 0x06044C1D RID: 281629 RVA: 0x011DEF96 File Offset: 0x011DD196
		public bool IsAllowMoveInput()
		{
			return this.IsGameplayReadyInternal && this.DollGrabMachineComponent != null;
		}

		// Token: 0x06044C1E RID: 281630 RVA: 0x011DEFAC File Offset: 0x011DD1AC
		public void OnClickStart()
		{
			if (this.IsRequesting || this.DollGrabMachineComponent == null)
			{
				return;
			}
			DollGarbInsertCoinRequest dollGarbInsertCoinRequest = DollGarbInsertCoinRequest.Create();
			dollGarbInsertCoinRequest.EntityIncId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
			this.IsRequesting = true;
			Singleton<Net>.Instance.Call<DollGarbInsertCoinResponse>(ERequestMessageId.DollGarbInsertCoinRequest, dollGarbInsertCoinRequest, delegate(DollGarbInsertCoinResponse response, Net.CallbackStatus _)
			{
				this.IsRequesting = false;
				if (response == null)
				{
					return;
				}
				ErrorCode errorCode = response.ErrorCode;
				if (errorCode == ErrorCode.Success)
				{
					this.IsInCountdownInternal = true;
					if (!this.IsEndlessMode)
					{
						Singleton<AudioSystem>.Instance.PostEvent("play_interact_crane_game_ui_insert_coin_01");
					}
					Singleton<EventSystem>.Instance.Emit<Action>(EEventName.OnDollGrabMachineStartCoolDown, new Action(this.StartDollGrabMachineInternal));
					return;
				}
				if (errorCode != ErrorCode.ErrNotEnoughItem)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[StartDollGrabMachine] 开启玩法请求失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DollGrabMachineNoEnoughItem);
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					this.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exit, false);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				Singleton<global::Log>.Instance.Error(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[StartDollGrabMachine] 玩家贝币不足", default(ReadOnlySpan<ValueTuple<string, object>>));
			}, 0);
		}

		// Token: 0x06044C1F RID: 281631 RVA: 0x011DF010 File Offset: 0x011DD210
		public void OnClickGrab()
		{
			if (this.IsGameplayReadyInternal && !(!this.DollGrabMachineComponent))
			{
				DgmClawBaseMoveState clawState = this.DollGrabMachineComponent.ClawState;
				if (clawState != null && clawState.ClawState <= EDollGrabMachineClawState.Idle)
				{
					Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_open");
					this.DollGrabMachineComponent.ChangeClawState(EDollGrabMachineClawState.Grabbing);
					return;
				}
			}
		}

		// Token: 0x06044C20 RID: 281632 RVA: 0x011DF06C File Offset: 0x011DD26C
		public void PreExitDollGrabMachine(EDollGrabMachineEndReason reason, bool needResume = false)
		{
			DollGrabMachineController.<>c__DisplayClass51_0 CS$<>8__locals1 = new DollGrabMachineController.<>c__DisplayClass51_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.reason = reason;
			if (this.IsRequesting || this.DollGrabMachineComponent == null)
			{
				if (this.IsRequesting && this.DollGrabMachineComponent != null)
				{
					this.IsCachePreExitReason = new EDollGrabMachineEndReason?(CS$<>8__locals1.reason);
				}
				return;
			}
			if (!this.IsGameplayReadyInternal && !this.IsInCountdownInternal)
			{
				if (CS$<>8__locals1.reason == EDollGrabMachineEndReason.Exit || CS$<>8__locals1.reason == EDollGrabMachineEndReason.Exception)
				{
					this.ExitDollGrabMachine();
				}
				return;
			}
			if (needResume)
			{
				this.IsRequesting = true;
				DollGrabPauseEndRequest dollGrabPauseEndRequest = DollGrabPauseEndRequest.Create();
				dollGrabPauseEndRequest.EntityIncId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
				Singleton<Net>.Instance.Call<DollGrabPauseEndResponse>(ERequestMessageId.DollGrabPauseEndRequest, dollGrabPauseEndRequest, delegate(DollGrabPauseEndResponse response, Net.CallbackStatus _)
				{
					CS$<>8__locals1.<>4__this.IsRequesting = false;
					if (response == null)
					{
						return;
					}
					if (response.ErrorCode != ErrorCode.Success)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.DollGrabMachine;
						ELogAuthor author = ELogAuthor.FJH;
						string message = "[PauseDollGrabMachine] Proto_DollGrabPauseEndRequest fail";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					CS$<>8__locals1.<>4__this.ResumeTick();
					CS$<>8__locals1.<>4__this.DollGrabMachineComponent.ResumeDollGrabMachine();
					Singleton<EventSystem>.Instance.Emit(EEventName.OnDollGrabMachineResume);
					base.<PreExitDollGrabMachine>g__onStopDollGrabMachine|0();
				}, 0);
				return;
			}
			CS$<>8__locals1.<PreExitDollGrabMachine>g__onStopDollGrabMachine|0();
		}

		// Token: 0x06044C21 RID: 281633 RVA: 0x011DF138 File Offset: 0x011DD338
		public void ExitDollGrabMachine()
		{
			if (Singleton<EventSystem>.Instance.Has<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnAddRemainingTime)))
			{
				Singleton<EventSystem>.Instance.Remove<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnAddRemainingTime));
			}
			if (this.DollGrabMachineComponent != null && this.DollGrabMachineComponent.Entity != null)
			{
				this.DollGrabMachineComponent.StopDissolve();
				int pbDataId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetPbDataId();
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnDollGrabMachineGameplayStateChanged, pbDataId, false);
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
				if (entityByPbDataId != null && Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnDollGrabEntityDestroy)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(entityByPbDataId, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnDollGrabEntityDestroy));
				}
			}
			if (Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseDollGrabMachineView)))
			{
				Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseDollGrabMachineView));
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DollGrabMachineView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DollGrabMachineView, null);
			}
			Singleton<EventSystem>.Instance.Remove<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			ModelBase<DollGrabModel>.Instance.ExecuteRestorePlayerCamera("DollGrabMachineFixCamera", delegate
			{
				this.OnStartShowGrabSequence();
			});
		}

		// Token: 0x06044C22 RID: 281634 RVA: 0x011DF29E File Offset: 0x011DD49E
		public void RestartDollGrabMachine()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDollGrabMachineRestart);
		}

		// Token: 0x06044C23 RID: 281635 RVA: 0x011DF2B0 File Offset: 0x011DD4B0
		public void PauseDollGrabMachine(bool isHelp = false)
		{
			if (this.DollGrabMachineComponent == null || this.IsRequesting)
			{
				return;
			}
			if (this.IsGameplayReadyInternal)
			{
				this.IsRequesting = true;
				DollGrabPauseStartRequest dollGrabPauseStartRequest = DollGrabPauseStartRequest.Create();
				dollGrabPauseStartRequest.EntityIncId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
				Singleton<Net>.Instance.Call<DollGrabPauseStartResponse>(ERequestMessageId.DollGrabPauseStartRequest, dollGrabPauseStartRequest, delegate(DollGrabPauseStartResponse response, Net.CallbackStatus _)
				{
					this.IsRequesting = false;
					if (response == null)
					{
						return;
					}
					if (response.ErrorCode != ErrorCode.Success)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.DollGrabMachine;
						ELogAuthor author = ELogAuthor.FJH;
						string message = "[PauseDollGrabMachine] Proto_DollGrabPauseStartRequest fail";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					this.PauseTick();
					this.DollGrabMachineComponent.PauseDollGrabMachine();
					if (isHelp)
					{
						if (this.IsEndlessMode)
						{
							ControllerBase<HelpController>.Instance.OpenHelpById(671);
							this.OnceCloseHelpInfoViewWithCondition(EUiViewName.HelpGuideView);
						}
						else
						{
							Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineHelpInfoView, null, null);
							this.OnceCloseHelpInfoViewWithCondition(EUiViewName.DollGrabMachineHelpInfoView);
						}
					}
					else
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachinePauseView, null, null);
					}
					Singleton<EventSystem>.Instance.Emit(EEventName.OnDollGrabMachinePause);
				}, 0);
				return;
			}
			if (!isHelp)
			{
				this.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exit, false);
				return;
			}
			if (this.IsEndlessMode)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(671);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabMachineHelpInfoView, null, null);
		}

		// Token: 0x06044C24 RID: 281636 RVA: 0x011DF36C File Offset: 0x011DD56C
		public void ResumeDollGrabMachine()
		{
			if (!this.IsGameplayReadyInternal || this.DollGrabMachineComponent == null || this.IsRequesting)
			{
				return;
			}
			this.IsRequesting = true;
			DollGrabPauseEndRequest dollGrabPauseEndRequest = DollGrabPauseEndRequest.Create();
			dollGrabPauseEndRequest.EntityIncId = this.DollGrabMachineComponent.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
			Singleton<Net>.Instance.Call<DollGrabPauseEndResponse>(ERequestMessageId.DollGrabPauseEndRequest, dollGrabPauseEndRequest, delegate(DollGrabPauseEndResponse response, Net.CallbackStatus _)
			{
				this.IsRequesting = false;
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.DollGrabMachine;
					ELogAuthor author = ELogAuthor.FJH;
					string message = "[PauseDollGrabMachine] Proto_DollGrabPauseEndRequest fail";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("errorCode", response.ErrorCode);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				base.ResumeTick();
				this.DollGrabMachineComponent.ResumeDollGrabMachine();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnDollGrabMachineResume);
				if (this.IsCachePreExitReason != null)
				{
					this.PreExitDollGrabMachine(this.IsCachePreExitReason.Value, false);
					this.IsCachePreExitReason = null;
				}
			}, 0);
		}

		// Token: 0x06044C25 RID: 281637 RVA: 0x011DF3D8 File Offset: 0x011DD5D8
		private void OnceCloseHelpInfoViewWithCondition(EUiViewName conditionViewName)
		{
			Action<EUiViewName, int> onCloseHelpInfoView = null;
			onCloseHelpInfoView = delegate(EUiViewName viewName, int viewId)
			{
				if (viewName != conditionViewName)
				{
					return;
				}
				Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, onCloseHelpInfoView);
				this.OnCloseHelpInfoView(viewName, viewId);
			};
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, onCloseHelpInfoView);
		}

		// Token: 0x06044C26 RID: 281638 RVA: 0x011DF425 File Offset: 0x011DD625
		private void OnCloseHelpInfoView(EUiViewName viewName, int viewId)
		{
			if (!this.IsGameplayReadyInternal)
			{
				return;
			}
			if (viewName == EUiViewName.DollGrabMachineHelpInfoView || viewName == EUiViewName.HelpGuideView)
			{
				this.ResumeDollGrabMachine();
			}
		}

		// Token: 0x1700A415 RID: 42005
		// (get) Token: 0x06044C27 RID: 281639 RVA: 0x011DF450 File Offset: 0x011DD650
		public float RemainingTime
		{
			get
			{
				return this.RemainingTimeInternal;
			}
		}

		// Token: 0x1700A416 RID: 42006
		// (get) Token: 0x06044C28 RID: 281640 RVA: 0x011DF458 File Offset: 0x011DD658
		public float RemainingTimeLimit
		{
			get
			{
				return this.RemainingTimeLimitInternal;
			}
		}

		// Token: 0x1700A417 RID: 42007
		// (get) Token: 0x06044C29 RID: 281641 RVA: 0x011DF460 File Offset: 0x011DD660
		public float AddRemainingTime
		{
			get
			{
				return this.AddRemainingTimeInternal;
			}
		}

		// Token: 0x06044C2A RID: 281642 RVA: 0x011DF468 File Offset: 0x011DD668
		private void OnAddRemainingTime(float addTime)
		{
			this.RemainingTimeInternal += addTime;
			this.AddRemainingTimeInternal += addTime;
			if (this.RemainingTimeInternal > this.RemainingTimeLimitInternal)
			{
				this.AddRemainingTimeInternal -= this.RemainingTimeInternal - this.RemainingTimeLimitInternal;
				this.RemainingTimeInternal = this.RemainingTimeLimitInternal;
			}
		}

		// Token: 0x06044C2B RID: 281643 RVA: 0x011DF4C8 File Offset: 0x011DD6C8
		private void ToggleScreenEffect(bool toggle)
		{
			string text = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.倒计时屏幕特效.ToAssetPathName();
			if (text.Length == 0)
			{
				return;
			}
			if (toggle && this.ScreenEffectHandle == null && this.DollGrabMachineComponent != null)
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(this.DollGrabMachineComponent.ActorTransform);
				this.ScreenEffectHandle = new int?(instance.SpawnEffect(world, ftransformDouble, text, "[DollGrabMachineController.ToggleScreenEffect] 开启屏幕特效", new EffectContext(new int?(this.DollGrabMachineComponent.Entity.Id), null, false), global::EEffectType.Scene, null, null, null, false, false));
				return;
			}
			if (!toggle && this.ScreenEffectHandle != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.ScreenEffectHandle.Value, "[DollGrabMachineController.ToggleScreenEffect] 停止屏幕特效", true, null);
				this.ScreenEffectHandle = null;
			}
		}

		// Token: 0x06044C2C RID: 281644 RVA: 0x011DF5A4 File Offset: 0x011DD7A4
		private void OnStartShowGrabSequence()
		{
			if (this.DollGrabMachineComponent == null)
			{
				return;
			}
			if (this.DollGrabMachineComponent.MainDollActor == null)
			{
				this.DollGrabMachineComponent = null;
				return;
			}
			ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.SetUiActive(false);
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.SimpleLevelSequence;
			ELoadingPerform perform = ELoadingPerform.CameraFade;
			string context = "SimpleLevelSequenceProcess";
			Action callback = new Action(this.OnStartShowGrabSequenceInternal);
			object[] array = new object[2];
			int num = 0;
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			array[num] = ((dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.黑幕淡入时间 : 0f);
			array[1] = EFadeInScreenShowType.Black;
			instance.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
		}

		// Token: 0x06044C2D RID: 281645 RVA: 0x011DF638 File Offset: 0x011DD838
		private void OnStartShowGrabSequenceInternal()
		{
			if (this.DollGrabMachineComponent == null || this.DollGrabMachineComponent.MainDollActor == null)
			{
				return;
			}
			FTransformDouble ftransformDouble = new FTransformDouble();
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			FVectorDouble fvectorDouble = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.阿布展示播放位置;
			commonTempVector.FromUeVector(fvectorDouble);
			global::Vector commonTempVector2 = Singleton<MathUtils>.Instance.CommonTempVector;
			FQuat rotation = this.DollGrabMachineComponent.ActorTransform.GetRotation();
			fvectorDouble = Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false);
			FVector fvector = fvectorDouble;
			FVector fvector2 = rotation.RotateVector(fvector);
			commonTempVector2.FromUeVector(fvector2);
			global::Vector commonTempVector3 = Singleton<MathUtils>.Instance.CommonTempVector2;
			fvectorDouble = this.DollGrabMachineComponent.ActorTransform.GetLocation();
			commonTempVector3.FromUeVector(fvectorDouble);
			Singleton<MathUtils>.Instance.CommonTempVector2.Addition(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<MathUtils>.Instance.CommonTempVector);
			fvectorDouble = Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false);
			ftransformDouble.SetTranslation(fvectorDouble);
			AKuroLevelSequenceActor akuroLevelSequenceActor = Singleton<ActorSystem>.Instance.Get<AKuroLevelSequenceActor>(AKuroLevelSequenceActor.StaticClass(), ftransformDouble, null, false);
			if (akuroLevelSequenceActor != null)
			{
				this.ShowSequenceActor = akuroLevelSequenceActor;
				this.ShowSequenceActor.SetSequence(ModelBase<DollGrabModel>.Instance.DollGrabShowSequence);
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.ShowSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
				this.ShowSequenceActor.bOverrideInstanceData = true;
				udefaultLevelSequenceInstanceData.TransformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(ftransformDouble);
				udefaultLevelSequenceInstanceData.TransformOriginActor = this.ShowSequenceActor;
				this.ShowSequenceActor.DefaultInstanceData = udefaultLevelSequenceInstanceData;
				this.SetBindingInGrabSequence();
			}
		}

		// Token: 0x06044C2E RID: 281646 RVA: 0x011DF7B0 File Offset: 0x011DD9B0
		private void SetBindingInGrabSequence()
		{
			if (this.ShowSequenceActor == null || this.DollGrabMachineComponent == null || this.DollGrabMachineComponent.MainDollActor == null)
			{
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineController] OnStartShowGrabSequenceInternal 绑定 播放", default(ReadOnlySpan<ValueTuple<string, object>>));
			TArray<AActor> tarray = new TArray<AActor>();
			tarray.Add(this.DollGrabMachineComponent.MainDollActor);
			this.DollGrabMachineComponent.ToggleShowMainDollActor(true, false);
			this.ShowSequenceActor.SetBindingByTag(new FName("WaWa"), tarray, false, false);
			tarray.Empty(true);
			this.ShowSequenceCamera = ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.GetUnBoundSceneCamera(ESceneSubCameraType.Fix);
			this.ShowSequenceCamera.IsKeepUi = false;
			this.ShowSequenceCamera.FadeIn = 0f;
			this.ShowSequenceCamera.FadeOut = 0f;
			tarray.Add(this.ShowSequenceCamera.Camera);
			this.ShowSequenceActor.SetBindingByTag(new FName("SequenceCamera"), tarray, false, false);
			tarray.Empty(true);
			ULevelSequencePlayer sequencePlayer = this.ShowSequenceActor.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.OnFinished.Add(new Action(this.OnFinishShowGrabSequence));
			}
			BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
			if (dollGrabMachineGlobalConfig != null && dollGrabMachineGlobalConfig.黑幕持续时间 > 0f)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
					ELoadingReason reason = ELoadingReason.SimpleLevelSequence;
					string context = "SimpleLevelSequenceProcess";
					Action callback = null;
					BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig2 = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
					instance.CloseLoading(reason, context, callback, new float?((dollGrabMachineGlobalConfig2 != null) ? dollGrabMachineGlobalConfig2.黑幕淡出时间 : 0f));
				}, dollGrabMachineGlobalConfig.黑幕持续时间 * 1000f, null, null, true, 1f);
			}
			else
			{
				ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SimpleLevelSequence, "SimpleLevelSequenceProcess", null, new float?((dollGrabMachineGlobalConfig != null) ? dollGrabMachineGlobalConfig.黑幕淡出时间 : 0f));
			}
			ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Scene;
			if (cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null)
			{
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.EnterSceneSubCamera(this.ShowSequenceCamera, null);
			}
			else
			{
				ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Scene, 0f, UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
			}
			this.ShowSequenceCamera.IsBinding = true;
			ULevelSequencePlayer sequencePlayer2 = this.ShowSequenceActor.SequencePlayer;
			if (sequencePlayer2 == null)
			{
				return;
			}
			sequencePlayer2.Play();
		}

		// Token: 0x06044C2F RID: 281647 RVA: 0x011DF9F0 File Offset: 0x011DDBF0
		private void OnFinishShowGrabSequence()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineController] OnStartShowGrabSequenceInternal 播放结束", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.SimpleLevelSequence, ELoadingPerform.CameraFade, "SimpleLevelSequenceProcess", delegate
			{
				ULevelSequencePlayer sequencePlayer = this.ShowSequenceActor.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.OnFinished.Remove(new Action(this.OnFinishShowGrabSequence));
				}
				Singleton<ActorSystem>.Instance.Put("DollGrabMachineController.ShowSequenceActorFinish", this.ShowSequenceActor, null);
				this.ShowSequenceActor = null;
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.PlayerComponent.ExitSceneSubCamera(this.ShowSequenceCamera, null, null);
				ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.RemoveBoundSceneCamera(this.ShowSequenceCamera);
				this.ShowSequenceCamera = null;
				this.DollGrabMachineComponent.ToggleShowMainDollActor(false, true);
				BP_DollGrabMachineGlobalConfig_C config = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				if (config != null && config.黑幕持续时间 > 0f)
				{
					TimerSystem.Instance.Delay(delegate(float _)
					{
						ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.SimpleLevelSequence, "SimpleLevelSequenceProcess", new Action(this.OnCompleterShowGrabSequence), new float?(config.黑幕淡出时间));
					}, config.黑幕持续时间 * 1000f, null, null, true, 1f);
					return;
				}
				LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
				ELoadingReason reason = ELoadingReason.SimpleLevelSequence;
				string context = "SimpleLevelSequenceProcess";
				Action callback = new Action(this.OnCompleterShowGrabSequence);
				BP_DollGrabMachineGlobalConfig_C config2 = config;
				instance.CloseLoading(reason, context, callback, new float?((config2 != null) ? config2.黑幕淡出时间 : 0f));
			}, new object[]
			{
				0,
				EFadeInScreenShowType.Black
			});
		}

		// Token: 0x06044C30 RID: 281648 RVA: 0x011DFA54 File Offset: 0x011DDC54
		private void OnCompleterShowGrabSequence()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "[DollGrabMachineController] OnStartShowGrabSequenceInternal 关闭退出黑幕", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DollGrabMachineComponent = null;
			ControllerBase<CameraController>.Instance.MainModel.SceneCamera.DisplayComponent.SetUiActive(true);
		}

		// Token: 0x06044C31 RID: 281649 RVA: 0x011DFAA4 File Offset: 0x011DDCA4
		private void OnTeamLivingStateChange(bool isMyTeam, ETeamGroupType groupType, ETeamLivingState state, ETeamLivingState oldState)
		{
			if (isMyTeam && groupType == ETeamGroupType.Battle && state == ETeamLivingState.Dead)
			{
				this.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exception, false);
				Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "OnTeamLivingStateChange 角色死亡，关闭抓娃娃机", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06044C32 RID: 281650 RVA: 0x011DFAE4 File Offset: 0x011DDCE4
		private void OnDollGrabEntityDestroy(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (handle.Entity == this.DollGrabMachineComponent.Entity)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.DollGrabMachine, ELogAuthor.FJH, "OnDollGrabEntityDestroy 实体销毁，关闭抓娃娃机", default(ReadOnlySpan<ValueTuple<string, object>>));
				ControllerBase<DollGrabMachineController>.Instance.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exception, false);
				Singleton<EventSystem>.Instance.RemoveWithTarget<ERemoveEntityType, EntityHandle>(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnDollGrabEntityDestroy));
			}
		}

		// Token: 0x06044C33 RID: 281651 RVA: 0x011DFB4C File Offset: 0x011DDD4C
		private void OnCloseDollGrabMachineView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.DollGrabMachineView)
			{
				this.PreExitDollGrabMachine(EDollGrabMachineEndReason.Exit, false);
			}
		}

		// Token: 0x040264B5 RID: 156853
		[Nullable(2)]
		private SceneItemDollGrabMachineComponent DollGrabMachineComponent;

		// Token: 0x040264B6 RID: 156854
		private readonly HashSet<string> PressedKey = new HashSet<string>();

		// Token: 0x040264B7 RID: 156855
		private bool IsGameplayReadyInternal;

		// Token: 0x040264B8 RID: 156856
		private bool IsInCountdownInternal;

		// Token: 0x040264B9 RID: 156857
		private readonly HashSet<SceneItemDollGrabMachineComponent> DollGrabMachineComponentSet = new HashSet<SceneItemDollGrabMachineComponent>();

		// Token: 0x040264BA RID: 156858
		private readonly HashSet<SceneItemDollGrabMachineComponent> TickComponentSet = new HashSet<SceneItemDollGrabMachineComponent>();

		// Token: 0x040264BB RID: 156859
		private float RemainingTimeLimitInternal;

		// Token: 0x040264BC RID: 156860
		private float RemainingTimeInternal;

		// Token: 0x040264BD RID: 156861
		private float AddRemainingTimeInternal;

		// Token: 0x040264BE RID: 156862
		private int? ScreenEffectHandle;

		// Token: 0x040264BF RID: 156863
		private bool IsDangerousCountdownInternal;

		// Token: 0x040264C0 RID: 156864
		[Nullable(2)]
		private AKuroLevelSequenceActor ShowSequenceActor;

		// Token: 0x040264C1 RID: 156865
		[Nullable(2)]
		private SceneSubCamera ShowSequenceCamera;

		// Token: 0x040264C2 RID: 156866
		private EDollGrabMachineEndReason? IsCachePreExitReason;

		// Token: 0x040264C3 RID: 156867
		private bool IsRequesting;
	}
}
