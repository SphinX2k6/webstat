using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB5 RID: 23477
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonController : UiControllerBase<InstanceDungeonController>
	{
		// Token: 0x0603B644 RID: 243268 RVA: 0x00F0BA2C File Offset: 0x00F09C2C
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeWakeUp, new Action(this.OnBehaviorTreeWakedUp));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.InputDistribute, new Action<string>(this.OnInputDistribute));
			Singleton<EventSystem>.Instance.Add<InstResultNotify>(EEventName.OnInstResultNotify, new Action<InstResultNotify>(this.EventInstResultNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.LoadingViewOnAfterShow, new Action(this.HandleLoadingViewOnAfterShow));
		}

		// Token: 0x0603B645 RID: 243269 RVA: 0x00F0BAC8 File Offset: 0x00F09CC8
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeWakeUp, new Action(this.OnBehaviorTreeWakedUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.InputDistribute, new Action<string>(this.OnInputDistribute));
			Singleton<EventSystem>.Instance.Remove<InstResultNotify>(EEventName.OnInstResultNotify, new Action<InstResultNotify>(this.EventInstResultNotify));
			Singleton<EventSystem>.Instance.Remove(EEventName.LoadingViewOnAfterShow, new Action(this.HandleLoadingViewOnAfterShow));
		}

		// Token: 0x0603B646 RID: 243270 RVA: 0x00F0BB64 File Offset: 0x00F09D64
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<InstPlayDataNotify>(ENotifyMessageId.InstPlayDataNotify, new Action<InstPlayDataNotify, Net.CallbackStatus>(this.InstPlayDataNotify));
			Singleton<Net>.Instance.Register<InstResultNotify>(ENotifyMessageId.InstResultNotify, new Action<InstResultNotify, Net.CallbackStatus>(this.InstResultNotify));
			Singleton<Net>.Instance.Register<TeleportDungeonActionNotify>(ENotifyMessageId.TeleportDungeonActionNotify, new Action<TeleportDungeonActionNotify, Net.CallbackStatus>(this.TeleportDungeonActionNotify));
			Singleton<Net>.Instance.Register<TeleportDungeonForbidNotify>(ENotifyMessageId.TeleportDungeonForbidNotify, new Action<TeleportDungeonForbidNotify, Net.CallbackStatus>(this.TeleportDungeonForbidNotify));
			Singleton<Net>.Instance.Register<InstSaveDataNotify>(ENotifyMessageId.InstSaveDataNotify, new Action<InstSaveDataNotify, Net.CallbackStatus>(this.InstSaveDataNotify));
		}

		// Token: 0x0603B647 RID: 243271 RVA: 0x00F0BC00 File Offset: 0x00F09E00
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InstPlayDataNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InstResultNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportDungeonActionNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportDungeonForbidNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InstSaveDataNotify);
		}

		// Token: 0x0603B648 RID: 243272 RVA: 0x00F0BC5D File Offset: 0x00F09E5D
		[NullableContext(2)]
		public double GetBeInviteOverdueTime(InstanceBeInviteData info)
		{
			if (info == null)
			{
				return 0.0;
			}
			return ((double)info.GetLimitTimestamp() - Singleton<TimeUtil>.Instance.GetServerTimeStamp()) / 1000.0;
		}

		// Token: 0x0603B649 RID: 243273 RVA: 0x00F0BC88 File Offset: 0x00F09E88
		public void GetInstExchangeRewardRequest(int exchangeCount)
		{
			GetInstExchangeRewardRequest getInstExchangeRewardRequest = new GetInstExchangeRewardRequest();
			getInstExchangeRewardRequest.ExchangeCount = exchangeCount;
			Singleton<Net>.Instance.Call<GetInstExchangeRewardResponse>(ERequestMessageId.GetInstExchangeRewardRequest, getInstExchangeRewardRequest, delegate(GetInstExchangeRewardResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeScrollingTipsView(response.ErrorCode, Array.Empty<string>());
				}
			}, 0);
		}

		// Token: 0x0603B64A RID: 243274 RVA: 0x00F0BCD2 File Offset: 0x00F09ED2
		private void OnInputDistribute(string input)
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance() && input == "功能菜单" && !Singleton<LevelEventLockInputState>.Instance.InputLimitEsc && !ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
			{
				this.OnClickInstanceDungeonExitButton(null, null, true);
			}
		}

		// Token: 0x0603B64B RID: 243275 RVA: 0x00F0BD10 File Offset: 0x00F09F10
		[NullableContext(2)]
		public void OnClickInstanceDungeonExitButton(Action confirmBack = null, Action cancelBack = null, bool isButton = true)
		{
			InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			InstanceDungeonExitHandlerBase instanceDungeonExitHandlerBase;
			if (DungeonExitHandlerDefine.DungeonExitHandlerMap.TryGetValue((EDungeonSubType)instanceDungeon.Value.InstSubType, out instanceDungeonExitHandlerBase) && instanceDungeonExitHandlerBase.Checker())
			{
				InstanceDungeonExitHandlerData instanceDungeonExitHandlerData = new InstanceDungeonExitHandlerData();
				instanceDungeonExitHandlerData.IsButton = isButton;
				instanceDungeonExitHandlerData.ConfirmBack = confirmBack;
				instanceDungeonExitHandlerData.CancelBack = cancelBack;
				instanceDungeonExitHandlerBase.HandleExit(instanceDungeonExitHandlerData);
				return;
			}
			int exitConfirmBoxConfigId = this.GetExitConfirmBoxConfigId();
			this.OpenNormalInstanceDungeonExitConfirmBox(exitConfirmBoxConfigId, confirmBack, cancelBack, isButton);
		}

		// Token: 0x0603B64C RID: 243276 RVA: 0x00F0BD88 File Offset: 0x00F09F88
		[NullableContext(2)]
		public void OpenNormalInstanceDungeonExitConfirmBox(int id, Action confirmBack, Action cancelBack, bool isButton)
		{
			InstanceDungeonController.<>c__DisplayClass11_0 CS$<>8__locals1 = new InstanceDungeonController.<>c__DisplayClass11_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.confirmBack = confirmBack;
			CS$<>8__locals1.cancelBack = cancelBack;
			CS$<>8__locals1.needOpenReChallengeConfirmBox = this.NeedOpenReChallengeConfirmBox();
			InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
			EInstanceFinishState? einstanceFinishState = (instance != null) ? new EInstanceFinishState?(instance.InstanceFinishSuccess) : null;
			InstanceDungeonModel instance2 = ModelBase<InstanceDungeonModel>.Instance;
			object obj;
			if (instance2 == null)
			{
				obj = null;
			}
			else
			{
				InstanceDungeonInfo instanceDungeonInfo = instance2.GetInstanceDungeonInfo();
				obj = ((instanceDungeonInfo != null) ? instanceDungeonInfo.FinishEscAction : null);
			}
			if (obj != null && isButton && einstanceFinishState.GetValueOrDefault() == EInstanceFinishState.Success)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Esc);
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)id);
			Action value = delegate()
			{
				if (CS$<>8__locals1.needOpenReChallengeConfirmBox)
				{
					if (!CS$<>8__locals1.<>4__this.CheckIfExitByOtherModule())
					{
						ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
					}
					Singleton<EventSystem>.Instance.Emit(EEventName.LeaveInstanceDungeonConfirm);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.LeaveInstanceExternalCancel);
				Action cancelBack2 = CS$<>8__locals1.cancelBack;
				if (cancelBack2 == null)
				{
					return;
				}
				cancelBack2();
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[0] = CS$<>8__locals1.cancelBack;
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = new Action(CS$<>8__locals1.<OpenNormalInstanceDungeonExitConfirmBox>g__ConfirmCallback|0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603B64D RID: 243277 RVA: 0x00F0BE78 File Offset: 0x00F0A078
		public bool NeedOpenReChallengeConfirmBox()
		{
			int instSubType = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()).Value.InstSubType;
			return (instSubType == 4 || instSubType == 43) && !ModelBase<GameModeModel>.Instance.IsMulti;
		}

		// Token: 0x0603B64E RID: 243278 RVA: 0x00F0BEC4 File Offset: 0x00F0A0C4
		public int GetExitConfirmBoxConfigId()
		{
			int? currentDungeonExitConfirmId = ModelBase<InstanceDungeonModel>.Instance.GetCurrentDungeonExitConfirmId();
			if (currentDungeonExitConfirmId != null)
			{
				int? num = currentDungeonExitConfirmId;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					return currentDungeonExitConfirmId.Value;
				}
			}
			int result;
			if (this.NeedOpenReChallengeConfirmBox())
			{
				result = 219;
			}
			else
			{
				result = (Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTipWithSkip() ? 296 : 4);
			}
			return result;
		}

		// Token: 0x0603B64F RID: 243279 RVA: 0x00F0BF30 File Offset: 0x00F0A130
		private bool CheckIfExitByOtherModule()
		{
			int id = ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId;
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				id = ModelBase<CreatureModel>.Instance.GetInstanceId();
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
			return (config != null && config.GetValueOrDefault().InstSubType == 19) || (config != null && config.GetValueOrDefault().InstSubType == 20) || (config != null && config.GetValueOrDefault().InstSubType == 24) || (config != null && config.GetValueOrDefault().InstSubType == 21) || (config != null && config.GetValueOrDefault().InstSubType == 22) || (config != null && config.GetValueOrDefault().InstSubType == 25) || (config != null && config.GetValueOrDefault().InstSubType == 33) || (config != null && config.GetValueOrDefault().InstSubType == 42);
		}

		// Token: 0x0603B650 RID: 243280 RVA: 0x00F0C080 File Offset: 0x00F0A280
		[NullableContext(2)]
		[return: Nullable(0)]
		public UniTask<bool> PrewarTeamFightRequest(int instanceId, [Nullable(1)] List<int> roleIds, int entranceId = 0, int posEntityId = 0, TransitionOptionPb transitionOption = null, List<int> towerDefencePhantomId = null)
		{
			InstanceDungeonController.<PrewarTeamFightRequest>d__15 <PrewarTeamFightRequest>d__;
			<PrewarTeamFightRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PrewarTeamFightRequest>d__.<>4__this = this;
			<PrewarTeamFightRequest>d__.instanceId = instanceId;
			<PrewarTeamFightRequest>d__.roleIds = roleIds;
			<PrewarTeamFightRequest>d__.entranceId = entranceId;
			<PrewarTeamFightRequest>d__.posEntityId = posEntityId;
			<PrewarTeamFightRequest>d__.transitionOption = transitionOption;
			<PrewarTeamFightRequest>d__.towerDefencePhantomId = towerDefencePhantomId;
			<PrewarTeamFightRequest>d__.<>1__state = -1;
			<PrewarTeamFightRequest>d__.<>t__builder.Start<InstanceDungeonController.<PrewarTeamFightRequest>d__15>(ref <PrewarTeamFightRequest>d__);
			return <PrewarTeamFightRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B651 RID: 243281 RVA: 0x00F0C0F8 File Offset: 0x00F0A2F8
		[NullableContext(0)]
		public UniTask<bool> SingleInstReChallengeRequest()
		{
			InstanceDungeonController.<SingleInstReChallengeRequest>d__16 <SingleInstReChallengeRequest>d__;
			<SingleInstReChallengeRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SingleInstReChallengeRequest>d__.<>1__state = -1;
			<SingleInstReChallengeRequest>d__.<>t__builder.Start<InstanceDungeonController.<SingleInstReChallengeRequest>d__16>(ref <SingleInstReChallengeRequest>d__);
			return <SingleInstReChallengeRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B652 RID: 243282 RVA: 0x00F0C133 File Offset: 0x00F0A333
		private void OnBehaviorTreeWakedUp()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
				if (instanceDungeonInfo == null)
				{
					return;
				}
				instanceDungeonInfo.SetTrack(true, ESetTrackReason.None);
			}
		}

		// Token: 0x0603B653 RID: 243283 RVA: 0x00F0C15C File Offset: 0x00F0A35C
		private void WorldDone()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ModelBase<InstanceDungeonModel>.Instance.ConstructCurrentDungeonAreaName();
				if (!string.IsNullOrEmpty(ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonName()))
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonAreaView, null, null);
				}
				InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
				ExchangeRewardModel instance2 = ModelBase<ExchangeRewardModel>.Instance;
				instance.CurrentInstanceIsFinish = ((instance2 != null) ? new bool?(instance2.IsFinishInstance(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId)) : null);
				this.ApplyInstanceEnterBuff();
			}
			if (this.TeleportDungeonActionDungeonIdHandle != 0)
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(this.TeleportDungeonActionDungeonIdHandle, false, false, false, null);
				this.TeleportDungeonActionDungeonIdHandle = 0;
			}
		}

		// Token: 0x0603B654 RID: 243284 RVA: 0x00F0C204 File Offset: 0x00F0A404
		private void ApplyInstanceEnterBuff()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null || config.Value.EnterBuff == 0)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity == null)
			{
				return;
			}
			BaseBuffComponent component = worldEntity.GetComponent<BaseBuffComponent>();
			if (component == null)
			{
				return;
			}
			CreatureDataComponent component2 = worldEntity.GetComponent<CreatureDataComponent>();
			long instigatorId = (component2 != null) ? component2.GetCreatureDataId() : 0L;
			component.AddBuffLocal((long)config.Value.EnterBuff, new AddBuffParam
			{
				InstigatorId = instigatorId,
				Reason = "InstanceDungeonEnterBuff"
			});
		}

		// Token: 0x0603B655 RID: 243285 RVA: 0x00F0C2B0 File Offset: 0x00F0A4B0
		private void InstPlayDataNotify(InstPlayDataNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "副本信息通知";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("副本玩法Id:", data.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<InstanceDungeonModel>.Instance.CreateInstanceInfo(data.Id);
		}

		// Token: 0x0603B656 RID: 243286 RVA: 0x00F0C2FE File Offset: 0x00F0A4FE
		private void EventInstResultNotify(InstResultNotify data)
		{
			this.InstResultNotify(data, null);
		}

		// Token: 0x0603B657 RID: 243287 RVA: 0x00F0C308 File Offset: 0x00F0A508
		private void InstResultNotify(InstResultNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "副本结束通知";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("副本Id:", data.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (data.Id != ModelBase<CreatureModel>.Instance.GetInstanceId())
			{
				return;
			}
			ModelBase<InstanceDungeonModel>.Instance.InstanceFinishSuccess = (data.Succ ? EInstanceFinishState.Success : EInstanceFinishState.Fail);
			if (ModelBase<InstanceDungeonModel>.Instance.InstanceFinishSuccess == EInstanceFinishState.Success && !string.IsNullOrEmpty(ControllerBase<OnlineController>.Instance.HandleTips))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("OnlineSomeOneLeaveInstance", Array.Empty<object>());
				ControllerBase<OnlineController>.Instance.HandleTips = "";
			}
			ModelBase<InstanceDungeonModel>.Instance.InstanceRewardHaveTake = data.IsRecReward;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDungeonFinish);
		}

		// Token: 0x0603B658 RID: 243288 RVA: 0x00F0C3CF File Offset: 0x00F0A5CF
		private void HandleLoadingViewOnAfterShow()
		{
			if (this.IsBlackScreenAdded)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("None", "PreWarLeaveScene");
				this.IsBlackScreenAdded = false;
			}
		}

		// Token: 0x0603B659 RID: 243289 RVA: 0x00F0C3F4 File Offset: 0x00F0A5F4
		private void TeleportDungeonActionNotify(TeleportDungeonActionNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			int dungeonId = data.DungeonId;
			this.TeleportDungeonActionHostIdHandle = data.HostPlayerId;
			this.TeleportDungeonActionIncIdHandle = data.IncId;
			SundryModel instance = ModelBase<SundryModel>.Instance;
			if (instance != null && instance.IsBlockTpDungeon())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText("TeleportDungeon被GM屏蔽，跳过执行");
				this.TeleportDungeonRequest(new List<int>(), false);
				return;
			}
			if (this.IsForbidDungeon(dungeonId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInstanceTip", Array.Empty<object>());
				this.TeleportDungeonRequest(new List<int>(), false);
				return;
			}
			if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
			{
				this.TeleportDungeonRequest(new List<int>(), false);
				return;
			}
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null || config.Value.InstType == 0)
			{
				this.TeleportDungeonRequest(new List<int>(), false);
				return;
			}
			this.TeleportDungeonContinueLastInst = data.ContinueLastInst;
			if (data.IsNeedSecondaryConfirmation)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TeleportDungeonConfirm);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = dungeonId;
					this.TeleportDungeonRequest(ModelBase<InstanceDungeonModel>.Instance.LastEnterRoleList ?? new List<int>(), true);
				};
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					this.TeleportDungeonRequest(new List<int>(), false);
					ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			if (!data.IsRegroup)
			{
				TransitionOptionPb transitionOption = data.TransitionOption;
				if (transitionOption != null && transitionOption.TransitionType == TransitionType.Seamless)
				{
					TransitionInSeamlessPb transitionInSeamless = data.TransitionOption.TransitionInSeamless;
					if (transitionInSeamless != null && transitionInSeamless.KeepStates.Contains(KeepMovementState.Kite))
					{
						SeamlessTravelContext seamlessTravelContext = new SeamlessTravelContext();
						seamlessTravelContext.ParseParamsByProto(data.TransitionOption.TransitionInSeamless);
						ControllerBase<SeamlessTravelController>.Instance.EnableSeamlessTravel(seamlessTravelContext, true).ContinueWith(delegate(bool result)
						{
							this.TeleportDungeonRequest(new List<int>(), true);
						});
						return;
					}
				}
				this.TeleportDungeonRequest(ModelBase<InstanceDungeonModel>.Instance.LastEnterRoleList ?? new List<int>(), true);
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.IsFormTeleportAction = true;
			LoadingModel instance2 = ModelBase<LoadingModel>.Instance;
			if (instance2 == null || !instance2.IsLoading)
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(dungeonId, false, false, false, null);
				return;
			}
			this.TeleportDungeonActionDungeonIdHandle = dungeonId;
		}

		// Token: 0x0603B65A RID: 243290 RVA: 0x00F0C624 File Offset: 0x00F0A824
		public void TeleportDungeonRequest(List<int> roleIds, bool isConfirm = true)
		{
			TeleportDungeonActionRequest teleportDungeonActionRequest = new TeleportDungeonActionRequest();
			teleportDungeonActionRequest.IncId = this.TeleportDungeonActionIncIdHandle;
			teleportDungeonActionRequest.HostPlayerId = this.TeleportDungeonActionHostIdHandle;
			teleportDungeonActionRequest.RoleIds.Add(roleIds);
			teleportDungeonActionRequest.IsConfirm = isConfirm;
			teleportDungeonActionRequest.ContinueLastInst = this.TeleportDungeonContinueLastInst;
			Singleton<Net>.Instance.Call<TeleportDungeonActionResponse>(ERequestMessageId.TeleportDungeonActionRequest, teleportDungeonActionRequest, delegate(TeleportDungeonActionResponse response, Net.CallbackStatus _)
			{
				if (response.Code != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.EnterInstResponse, null, true, true);
				}
			}, 0);
			ModelBase<InstanceDungeonModel>.Instance.LastEnterRoleList = roleIds;
			this.TeleportDungeonContinueLastInst = false;
			this.TeleportDungeonActionHostIdHandle = 0;
			this.TeleportDungeonActionIncIdHandle = 0;
		}

		// Token: 0x0603B65B RID: 243291 RVA: 0x00F0C6BE File Offset: 0x00F0A8BE
		public bool IsForbidDungeon(int instanceId)
		{
			if (!this.IsEnableTeleport)
			{
				if (this.PermitList == null)
				{
					return true;
				}
				if (!this.PermitList.Contains(instanceId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603B65C RID: 243292 RVA: 0x00F0C6E3 File Offset: 0x00F0A8E3
		[NullableContext(2)]
		public void UpdateForbidDungeon(bool isEnableTeleport, IList<int> permitList)
		{
			this.IsEnableTeleport = isEnableTeleport;
			this.PermitList = permitList;
		}

		// Token: 0x0603B65D RID: 243293 RVA: 0x00F0C6F4 File Offset: 0x00F0A8F4
		private void TeleportDungeonForbidNotify(TeleportDungeonForbidNotify data, [Nullable(2)] Net.CallbackStatus callbackStatus = null)
		{
			int dungeonId = data.DungeonId;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId);
			string promptId = (config != null && config.Value.InstType == 1) ? "TrialRoleTransmitLimit" : "TrialRoleDungeonsLimit";
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(promptId, Array.Empty<object>());
		}

		// Token: 0x0603B65E RID: 243294 RVA: 0x00F0C754 File Offset: 0x00F0A954
		private void InstSaveDataNotify(InstSaveDataNotify data, [Nullable(2)] Net.CallbackStatus callbackStatus = null)
		{
			InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
			if (instance != null)
			{
				instance.ClearInstanceIdsWithSaveData();
			}
			foreach (long num in data.Ids)
			{
				int num2 = (int)num;
				InstanceDungeonModel instance2 = ModelBase<InstanceDungeonModel>.Instance;
				if (instance2 != null)
				{
					instance2.AddInstanceIdsWithSaveData(new int[]
					{
						num2
					});
				}
			}
		}

		// Token: 0x0603B65F RID: 243295 RVA: 0x00F0C7C8 File Offset: 0x00F0A9C8
		public void UpdateTrialRoleDungeonWhiteList(int[] canEnterDungeonList)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "更新试用角色副本白名单";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DungeonList", canEnterDungeonList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			List<int> trialRoleDungeonWhiteList = ModelBase<InstanceDungeonModel>.Instance.TrialRoleDungeonWhiteList;
			trialRoleDungeonWhiteList.Clear();
			trialRoleDungeonWhiteList.AddRange(canEnterDungeonList);
		}

		// Token: 0x0603B660 RID: 243296 RVA: 0x00F0C814 File Offset: 0x00F0AA14
		public bool SkipTrailRoleCheckEnterDungeon()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (instanceId <= 0)
			{
				return false;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return InstanceDungeonDefine.TrialRoleSkipCheckInstanceType.Contains((EDungeonSubType)config.Value.InstSubType);
		}

		// Token: 0x0603B661 RID: 243297 RVA: 0x00F0C85C File Offset: 0x00F0AA5C
		public bool CanTrialRoleEnterDungeon(int entranceId, int dungeonId)
		{
			if (entranceId <= 0 || dungeonId <= 0)
			{
				return false;
			}
			if (!ModelBase<InstanceDungeonModel>.Instance.TrialRoleDungeonWhiteList.Contains(dungeonId))
			{
				return false;
			}
			bool flag = true;
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (instanceId > 0)
			{
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
				if (config != null && config.GetValueOrDefault().InstSubType == 12 && (config != null && config.GetValueOrDefault().WorldDungeonSubType > 0))
				{
					flag = false;
				}
			}
			InstanceDungeonEntrance? config2 = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetConfig(entranceId);
			return !flag || (config2 != null && config2.Value.FlowId == 2);
		}

		// Token: 0x0603B662 RID: 243298 RVA: 0x00F0C917 File Offset: 0x00F0AB17
		private bool OverrideErrorCodeStateGetter(Aki.Protocol.ErrorCode errorCode)
		{
			return errorCode != Aki.Protocol.ErrorCode.TeamParkMemberErr;
		}

		// Token: 0x0603B663 RID: 243299 RVA: 0x00F0C924 File Offset: 0x00F0AB24
		public void CheckAndShowDungeonArchiveExpireTips(int dungeonId)
		{
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveActivate(dungeonId))
			{
				return;
			}
			if (dungeonId <= 0)
			{
				return;
			}
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveExpire(dungeonId) && !ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveExpireTipsShow(dungeonId))
			{
				string dungeonArchiveExpireLocalTips = ModelBase<InstanceDungeonEntranceModel>.Instance.GetDungeonArchiveExpireLocalTips(dungeonId);
				if (!string.IsNullOrEmpty(dungeonArchiveExpireLocalTips))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(dungeonArchiveExpireLocalTips, Array.Empty<object>());
				}
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetDungeonArchiveExpireTipsShow(dungeonId);
			}
		}

		// Token: 0x0402179D RID: 137117
		private bool IsEnableTeleport = true;

		// Token: 0x0402179E RID: 137118
		private bool IsBlackScreenAdded;

		// Token: 0x0402179F RID: 137119
		[Nullable(2)]
		private IList<int> PermitList = new List<int>();

		// Token: 0x040217A0 RID: 137120
		public int TeleportDungeonActionHostIdHandle;

		// Token: 0x040217A1 RID: 137121
		public int TeleportDungeonActionIncIdHandle;

		// Token: 0x040217A2 RID: 137122
		public int TeleportDungeonActionDungeonIdHandle;

		// Token: 0x040217A3 RID: 137123
		public bool TeleportDungeonContinueLastInst;
	}
}
