using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB8 RID: 23480
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonEntranceController : UiControllerBase<InstanceDungeonEntranceController>
	{
		// Token: 0x0603B677 RID: 243319 RVA: 0x00F0D093 File Offset: 0x00F0B293
		protected override bool OnInit()
		{
			this.PowerIconPath = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(5).IconSmall;
			this.RegisterInstanceSubViewBuilder();
			return true;
		}

		// Token: 0x0603B678 RID: 243320 RVA: 0x00F0D0B2 File Offset: 0x00F0B2B2
		protected override bool OnClear()
		{
			this.SettleCache = null;
			this.PowerIconPath = null;
			this.UnRegisterInstanceSubViewBuilder();
			return true;
		}

		// Token: 0x0603B679 RID: 243321 RVA: 0x00F0D0C9 File Offset: 0x00F0B2C9
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.OpenViewLimit), "InstanceDungeonEntranceController.OpenViewLimit");
		}

		// Token: 0x0603B67A RID: 243322 RVA: 0x00F0D0EB File Offset: 0x00F0B2EB
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.All, new Func<EUiViewName, object, bool>(this.OpenViewLimit));
		}

		// Token: 0x0603B67B RID: 243323 RVA: 0x00F0D108 File Offset: 0x00F0B308
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnline));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.TeleportComplete));
		}

		// Token: 0x0603B67C RID: 243324 RVA: 0x00F0D1A4 File Offset: 0x00F0B3A4
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnline));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPowerChanged, new Action(this.OnPowerChanged));
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.TeleportComplete));
		}

		// Token: 0x0603B67D RID: 243325 RVA: 0x00F0D240 File Offset: 0x00F0B440
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<InstDataNotify>(ENotifyMessageId.InstDataNotify, new Action<InstDataNotify, Net.CallbackStatus>(this.InstDataNotify));
			Singleton<Net>.Instance.Register<UpdateEnterInfoNotify>(ENotifyMessageId.UpdateEnterInfoNotify, new Action<UpdateEnterInfoNotify, Net.CallbackStatus>(this.UpdateEnterInfoNotify));
			Singleton<Net>.Instance.Register<MatchFailNotify>(ENotifyMessageId.MatchFailNotify, new Action<MatchFailNotify, Net.CallbackStatus>(this.MatchFailNotify));
			Singleton<Net>.Instance.Register<MatchTeamNotify>(ENotifyMessageId.MatchTeamNotify, new Action<MatchTeamNotify, Net.CallbackStatus>(this.MatchTeamNotify));
			Singleton<Net>.Instance.Register<MatchingNotify>(ENotifyMessageId.MatchingNotify, new Action<MatchingNotify, Net.CallbackStatus>(this.MatchingNotify));
			Singleton<Net>.Instance.Register<MatchTeamStateNotify>(ENotifyMessageId.MatchTeamStateNotify, new Action<MatchTeamStateNotify, Net.CallbackStatus>(this.MatchTeamStateNotify));
			Singleton<Net>.Instance.Register<MatchConfirmNotify>(ENotifyMessageId.MatchConfirmNotify, new Action<MatchConfirmNotify, Net.CallbackStatus>(this.MatchConfirmNotify));
			Singleton<Net>.Instance.Register<MatchChangeRoleNotify>(ENotifyMessageId.MatchChangeRoleNotify, new Action<MatchChangeRoleNotify, Net.CallbackStatus>(this.MatchChangeRoleNotify));
			Singleton<Net>.Instance.Register<MatchChangeReadyNotify>(ENotifyMessageId.MatchChangeReadyNotify, new Action<MatchChangeReadyNotify, Net.CallbackStatus>(this.MatchChangeReadyNotify));
			Singleton<Net>.Instance.Register<LeaveMatchTeamNotify>(ENotifyMessageId.LeaveMatchTeamNotify, new Action<LeaveMatchTeamNotify, Net.CallbackStatus>(this.LeaveMatchTeamNotify));
			Singleton<Net>.Instance.Register<EnterMatchTeamNotify>(ENotifyMessageId.EnterMatchTeamNotify, new Action<EnterMatchTeamNotify, Net.CallbackStatus>(this.EnterMatchTeamNotify));
			Singleton<Net>.Instance.Register<TeamMatchFlagNotify>(ENotifyMessageId.TeamMatchFlagNotify, new Action<TeamMatchFlagNotify, Net.CallbackStatus>(this.TeamMatchFlagNotify));
			Singleton<Net>.Instance.Register<EntranceStateNotify>(ENotifyMessageId.EntranceStateNotify, new Action<EntranceStateNotify, Net.CallbackStatus>(this.EntranceStateNotify));
			Singleton<Net>.Instance.Register<InstSettleNotify>(ENotifyMessageId.InstSettleNotify, new Action<InstSettleNotify, Net.CallbackStatus>(this.InstSettleNotify));
			Singleton<Net>.Instance.Register<TeamMatchInviteNotify>(ENotifyMessageId.TeamMatchInviteNotify, new Action<TeamMatchInviteNotify, Net.CallbackStatus>(this.TeamMatchInviteNotify));
			Singleton<Net>.Instance.Register<StartMatchNotify>(ENotifyMessageId.StartMatchNotify, new Action<StartMatchNotify, Net.CallbackStatus>(this.StartMatchNotify));
			Singleton<Net>.Instance.Register<CancelMatchNotify>(ENotifyMessageId.CancelMatchNotify, new Action<CancelMatchNotify, Net.CallbackStatus>(this.CancelMatchNotify));
			Singleton<Net>.Instance.Register<TeamMatchAcceptInviteNotify>(ENotifyMessageId.TeamMatchAcceptInviteNotify, new Action<TeamMatchAcceptInviteNotify, Net.CallbackStatus>(this.TeamMatchAcceptInviteNotify));
			Singleton<Net>.Instance.Register<TeamMatchInviteRetToHostNotify>(ENotifyMessageId.TeamMatchInviteRetToHostNotify, new Action<TeamMatchInviteRetToHostNotify, Net.CallbackStatus>(this.TeamMatchInviteRetToHostNotify));
		}

		// Token: 0x0603B67E RID: 243326 RVA: 0x00F0D464 File Offset: 0x00F0B664
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InstDataNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateEnterInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchFailNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchTeamNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchingNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchTeamStateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchConfirmNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchChangeRoleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchChangeReadyNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LeaveMatchTeamNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EnterMatchTeamNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamMatchFlagNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntranceStateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InstSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamMatchInviteNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.StartMatchNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CancelMatchNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamMatchInviteRetToHostNotify);
		}

		// Token: 0x0603B67F RID: 243327 RVA: 0x00F0D591 File Offset: 0x00F0B791
		private void RegisterInstanceSubViewBuilder()
		{
			this.InstanceSubViewCache.Add(EInstanceEntranceSubViewType.MowingRisk, () => new MowingRiskInstanceView());
		}

		// Token: 0x0603B680 RID: 243328 RVA: 0x00F0D5C2 File Offset: 0x00F0B7C2
		private void UnRegisterInstanceSubViewBuilder()
		{
			this.InstanceSubViewCache.Clear();
		}

		// Token: 0x0603B681 RID: 243329 RVA: 0x00F0D5CF File Offset: 0x00F0B7CF
		private void OnWorldDone()
		{
			this.IsShowSettlePower = false;
			if (this.SettleCache != null)
			{
				this.InstSettleNotify(this.SettleCache, null);
				this.SettleCache = null;
			}
		}

		// Token: 0x0603B682 RID: 243330 RVA: 0x00F0D5F4 File Offset: 0x00F0B7F4
		private void WorldDoneAndCloseLoading()
		{
			if (this.HandleExitMatch)
			{
				this.HandleExitMatch = false;
				this.LeaveMatchTeamRequest();
			}
			if (this.HandleTipsExitMatchId != 0)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.HandleTipsExitMatchId).Value.MapName, null);
				ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
				string id = "CancelMatch";
				object[] parameters;
				if (localTextNew == null)
				{
					parameters = Array.Empty<object>();
				}
				else
				{
					(parameters = new object[1])[0] = localTextNew;
				}
				instance.ShowTipsById(id, parameters);
				this.HandleTipsExitMatchId = 0;
			}
		}

		// Token: 0x0603B683 RID: 243331 RVA: 0x00F0D670 File Offset: 0x00F0B870
		private void OnPowerChanged()
		{
			if (this.IsShowSettlePower)
			{
				List<IRewardExploreConfirmButton> buttonList = this.InitSettleViewButtonList(this.IsShowSettleSuccess);
				ControllerBase<ItemRewardController>.Instance.SetButtonList(buttonList);
				int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
				int? instancePowerCost = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(instanceId);
				if (ModelBase<PowerModel>.Instance.IsPowerEnough(instancePowerCost) && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ConfirmBoxView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.ConfirmBoxView, null);
				}
			}
		}

		// Token: 0x0603B684 RID: 243332 RVA: 0x00F0D6E2 File Offset: 0x00F0B8E2
		private void TeleportComplete(TeleportContext teleportContext)
		{
			if (this.HandleExitMatch)
			{
				this.HandleExitMatch = false;
				this.LeaveMatchTeamRequest();
			}
		}

		// Token: 0x0603B685 RID: 243333 RVA: 0x00F0D6FA File Offset: 0x00F0B8FA
		private void OnLeaveOnline()
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
		}

		// Token: 0x0603B686 RID: 243334 RVA: 0x00F0D718 File Offset: 0x00F0B918
		[NullableContext(0)]
		public UniTask<bool> EnterEntrance(int entranceId, int entranceEntityId = 0, [Nullable(2)] Action cb = null)
		{
			InstanceDungeonEntranceController.<EnterEntrance>d__31 <EnterEntrance>d__;
			<EnterEntrance>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterEntrance>d__.<>4__this = this;
			<EnterEntrance>d__.entranceId = entranceId;
			<EnterEntrance>d__.entranceEntityId = entranceEntityId;
			<EnterEntrance>d__.cb = cb;
			<EnterEntrance>d__.<>1__state = -1;
			<EnterEntrance>d__.<>t__builder.Start<InstanceDungeonEntranceController.<EnterEntrance>d__31>(ref <EnterEntrance>d__);
			return <EnterEntrance>d__.<>t__builder.Task;
		}

		// Token: 0x0603B687 RID: 243335 RVA: 0x00F0D774 File Offset: 0x00F0B974
		[NullableContext(0)]
		private UniTask<bool> StartEntranceFlow()
		{
			InstanceDungeonEntranceController.<StartEntranceFlow>d__32 <StartEntranceFlow>d__;
			<StartEntranceFlow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartEntranceFlow>d__.<>4__this = this;
			<StartEntranceFlow>d__.<>1__state = -1;
			<StartEntranceFlow>d__.<>t__builder.Start<InstanceDungeonEntranceController.<StartEntranceFlow>d__32>(ref <StartEntranceFlow>d__);
			return <StartEntranceFlow>d__.<>t__builder.Task;
		}

		// Token: 0x0603B688 RID: 243336 RVA: 0x00F0D7B8 File Offset: 0x00F0B9B8
		public void ContinueEntranceFlow()
		{
			int entranceId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			InstanceDungeonEntranceFlowBase instanceDungeonEntranceFlow = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetInstanceDungeonEntranceFlow(entranceId);
			if (instanceDungeonEntranceFlow == null)
			{
				return;
			}
			instanceDungeonEntranceFlow.Flow();
		}

		// Token: 0x0603B689 RID: 243337 RVA: 0x00F0D7E8 File Offset: 0x00F0B9E8
		public void RevertEntranceFlowStep()
		{
			int entranceId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			if (entranceId == 0)
			{
				return;
			}
			InstanceDungeonEntranceFlowBase instanceDungeonEntranceFlow = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetInstanceDungeonEntranceFlow(entranceId);
			if (instanceDungeonEntranceFlow == null)
			{
				return;
			}
			instanceDungeonEntranceFlow.RevertStep();
		}

		// Token: 0x0603B68A RID: 243338 RVA: 0x00F0D81C File Offset: 0x00F0BA1C
		public void RestartEntranceFlow()
		{
			int entranceId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			if (entranceId == 0)
			{
				return;
			}
			InstanceDungeonEntranceFlowBase instanceDungeonEntranceFlow = ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetInstanceDungeonEntranceFlow(entranceId);
			if (instanceDungeonEntranceFlow == null)
			{
				return;
			}
			instanceDungeonEntranceFlow.Start();
		}

		// Token: 0x0603B68B RID: 243339 RVA: 0x00F0D84E File Offset: 0x00F0BA4E
		public void OnEditBattleViewClose()
		{
			ConfigBase<InstanceDungeonEntranceConfig>.Instance.OnEditBattleViewClose();
		}

		// Token: 0x0603B68C RID: 243340 RVA: 0x00F0D85C File Offset: 0x00F0BA5C
		[NullableContext(0)]
		public UniTask<bool> EnterInstanceDungeon()
		{
			InstanceDungeonEntranceController.<EnterInstanceDungeon>d__37 <EnterInstanceDungeon>d__;
			<EnterInstanceDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterInstanceDungeon>d__.<>1__state = -1;
			<EnterInstanceDungeon>d__.<>t__builder.Start<InstanceDungeonEntranceController.<EnterInstanceDungeon>d__37>(ref <EnterInstanceDungeon>d__);
			return <EnterInstanceDungeon>d__.<>t__builder.Task;
		}

		// Token: 0x0603B68D RID: 243341 RVA: 0x00F0D898 File Offset: 0x00F0BA98
		[NullableContext(0)]
		public UniTask<bool> EnterInstanceDungeonByAutoRole()
		{
			InstanceDungeonEntranceController.<EnterInstanceDungeonByAutoRole>d__38 <EnterInstanceDungeonByAutoRole>d__;
			<EnterInstanceDungeonByAutoRole>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterInstanceDungeonByAutoRole>d__.<>1__state = -1;
			<EnterInstanceDungeonByAutoRole>d__.<>t__builder.Start<InstanceDungeonEntranceController.<EnterInstanceDungeonByAutoRole>d__38>(ref <EnterInstanceDungeonByAutoRole>d__);
			return <EnterInstanceDungeonByAutoRole>d__.<>t__builder.Task;
		}

		// Token: 0x0603B68E RID: 243342 RVA: 0x00F0D8D4 File Offset: 0x00F0BAD4
		[NullableContext(0)]
		public UniTask<bool> LeaveInstanceDungeon()
		{
			InstanceDungeonEntranceController.<LeaveInstanceDungeon>d__39 <LeaveInstanceDungeon>d__;
			<LeaveInstanceDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LeaveInstanceDungeon>d__.<>4__this = this;
			<LeaveInstanceDungeon>d__.<>1__state = -1;
			<LeaveInstanceDungeon>d__.<>t__builder.Start<InstanceDungeonEntranceController.<LeaveInstanceDungeon>d__39>(ref <LeaveInstanceDungeon>d__);
			return <LeaveInstanceDungeon>d__.<>t__builder.Task;
		}

		// Token: 0x0603B68F RID: 243343 RVA: 0x00F0D918 File Offset: 0x00F0BB18
		[NullableContext(0)]
		public UniTask<bool> LeaveInstanceDungeonRequest(LeaveInstWay leaveWay = LeaveInstWay.Default)
		{
			InstanceDungeonEntranceController.<LeaveInstanceDungeonRequest>d__40 <LeaveInstanceDungeonRequest>d__;
			<LeaveInstanceDungeonRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LeaveInstanceDungeonRequest>d__.leaveWay = leaveWay;
			<LeaveInstanceDungeonRequest>d__.<>1__state = -1;
			<LeaveInstanceDungeonRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<LeaveInstanceDungeonRequest>d__40>(ref <LeaveInstanceDungeonRequest>d__);
			return <LeaveInstanceDungeonRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B690 RID: 243344 RVA: 0x00F0D95C File Offset: 0x00F0BB5C
		[NullableContext(0)]
		public UniTask<bool> RestartInstanceDungeon()
		{
			InstanceDungeonEntranceController.<RestartInstanceDungeon>d__41 <RestartInstanceDungeon>d__;
			<RestartInstanceDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RestartInstanceDungeon>d__.<>1__state = -1;
			<RestartInstanceDungeon>d__.<>t__builder.Start<InstanceDungeonEntranceController.<RestartInstanceDungeon>d__41>(ref <RestartInstanceDungeon>d__);
			return <RestartInstanceDungeon>d__.<>t__builder.Task;
		}

		// Token: 0x0603B691 RID: 243345 RVA: 0x00F0D998 File Offset: 0x00F0BB98
		[NullableContext(0)]
		public UniTask<bool> InstEntranceDetailRequest(int entranceId)
		{
			InstanceDungeonEntranceController.<InstEntranceDetailRequest>d__42 <InstEntranceDetailRequest>d__;
			<InstEntranceDetailRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<InstEntranceDetailRequest>d__.entranceId = entranceId;
			<InstEntranceDetailRequest>d__.<>1__state = -1;
			<InstEntranceDetailRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<InstEntranceDetailRequest>d__42>(ref <InstEntranceDetailRequest>d__);
			return <InstEntranceDetailRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B692 RID: 243346 RVA: 0x00F0D9DC File Offset: 0x00F0BBDC
		[NullableContext(0)]
		public UniTask<bool> MatchChangeRoleRequest([Nullable(1)] List<int> roleId)
		{
			InstanceDungeonEntranceController.<MatchChangeRoleRequest>d__43 <MatchChangeRoleRequest>d__;
			<MatchChangeRoleRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MatchChangeRoleRequest>d__.roleId = roleId;
			<MatchChangeRoleRequest>d__.<>1__state = -1;
			<MatchChangeRoleRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<MatchChangeRoleRequest>d__43>(ref <MatchChangeRoleRequest>d__);
			return <MatchChangeRoleRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B693 RID: 243347 RVA: 0x00F0DA20 File Offset: 0x00F0BC20
		[NullableContext(0)]
		public UniTask<bool> MatchChangeReadyRequest(bool isReady)
		{
			InstanceDungeonEntranceController.<MatchChangeReadyRequest>d__44 <MatchChangeReadyRequest>d__;
			<MatchChangeReadyRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MatchChangeReadyRequest>d__.isReady = isReady;
			<MatchChangeReadyRequest>d__.<>1__state = -1;
			<MatchChangeReadyRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<MatchChangeReadyRequest>d__44>(ref <MatchChangeReadyRequest>d__);
			return <MatchChangeReadyRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B694 RID: 243348 RVA: 0x00F0DA64 File Offset: 0x00F0BC64
		[NullableContext(0)]
		public UniTask<bool> LeaveMatchTeamRequest()
		{
			InstanceDungeonEntranceController.<LeaveMatchTeamRequest>d__45 <LeaveMatchTeamRequest>d__;
			<LeaveMatchTeamRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LeaveMatchTeamRequest>d__.<>1__state = -1;
			<LeaveMatchTeamRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<LeaveMatchTeamRequest>d__45>(ref <LeaveMatchTeamRequest>d__);
			return <LeaveMatchTeamRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B695 RID: 243349 RVA: 0x00F0DAA0 File Offset: 0x00F0BCA0
		[NullableContext(0)]
		public UniTask<bool> KickMatchTeamPlayerRequest(int playerId)
		{
			InstanceDungeonEntranceController.<KickMatchTeamPlayerRequest>d__46 <KickMatchTeamPlayerRequest>d__;
			<KickMatchTeamPlayerRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<KickMatchTeamPlayerRequest>d__.playerId = playerId;
			<KickMatchTeamPlayerRequest>d__.<>1__state = -1;
			<KickMatchTeamPlayerRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<KickMatchTeamPlayerRequest>d__46>(ref <KickMatchTeamPlayerRequest>d__);
			return <KickMatchTeamPlayerRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B696 RID: 243350 RVA: 0x00F0DAE4 File Offset: 0x00F0BCE4
		[NullableContext(0)]
		public UniTask<bool> SetMatchTeamMatchFlagRequest(bool isMatch)
		{
			InstanceDungeonEntranceController.<SetMatchTeamMatchFlagRequest>d__47 <SetMatchTeamMatchFlagRequest>d__;
			<SetMatchTeamMatchFlagRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SetMatchTeamMatchFlagRequest>d__.isMatch = isMatch;
			<SetMatchTeamMatchFlagRequest>d__.<>1__state = -1;
			<SetMatchTeamMatchFlagRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<SetMatchTeamMatchFlagRequest>d__47>(ref <SetMatchTeamMatchFlagRequest>d__);
			return <SetMatchTeamMatchFlagRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B697 RID: 243351 RVA: 0x00F0DB28 File Offset: 0x00F0BD28
		[NullableContext(0)]
		public UniTask<bool> EnterMatchInstRequest()
		{
			InstanceDungeonEntranceController.<EnterMatchInstRequest>d__48 <EnterMatchInstRequest>d__;
			<EnterMatchInstRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterMatchInstRequest>d__.<>1__state = -1;
			<EnterMatchInstRequest>d__.<>t__builder.Start<InstanceDungeonEntranceController.<EnterMatchInstRequest>d__48>(ref <EnterMatchInstRequest>d__);
			return <EnterMatchInstRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603B698 RID: 243352 RVA: 0x00F0DB64 File Offset: 0x00F0BD64
		[NullableContext(1)]
		public bool CheckInstanceShieldView(string viewName)
		{
			if (!this.LimitOpenView)
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			return instanceId != 0 && ConfigBase<InstanceDungeonConfig>.Instance.CheckViewShield(instanceId, (EUiViewName)viewName);
		}

		// Token: 0x0603B699 RID: 243353 RVA: 0x00F0DB9C File Offset: 0x00F0BD9C
		public void RestoreDungeonEntranceEntity()
		{
			int entranceEntityId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceEntityId;
			if (entranceEntityId == 0)
			{
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entranceEntityId);
			if (entityById == null || !entityById.IsInit)
			{
				return;
			}
			DungeonEntranceComponent component = entityById.Entity.GetComponent<DungeonEntranceComponent>();
			if (component == null)
			{
				return;
			}
			component.Restore();
		}

		// Token: 0x0603B69A RID: 243354 RVA: 0x00F0DBE8 File Offset: 0x00F0BDE8
		[NullableContext(1)]
		public void RegisterDungeonEntranceRestoreCb(Action cb)
		{
			int entranceEntityId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceEntityId;
			if (entranceEntityId == 0)
			{
				cb();
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entranceEntityId);
			if (entityById == null || !entityById.IsInit)
			{
				cb();
				return;
			}
			DungeonEntranceComponent component = entityById.Entity.GetComponent<DungeonEntranceComponent>();
			if (component != null)
			{
				component.RegisterRestoreCb(cb);
				return;
			}
			cb();
		}

		// Token: 0x0603B69B RID: 243355 RVA: 0x00F0DC48 File Offset: 0x00F0BE48
		[NullableContext(0)]
		private UniTask<bool> StartMatchRequestAsync(int instanceId, bool inviteTeamWorld = false, bool checkSubpack = true)
		{
			InstanceDungeonEntranceController.<StartMatchRequestAsync>d__52 <StartMatchRequestAsync>d__;
			<StartMatchRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartMatchRequestAsync>d__.<>4__this = this;
			<StartMatchRequestAsync>d__.instanceId = instanceId;
			<StartMatchRequestAsync>d__.inviteTeamWorld = inviteTeamWorld;
			<StartMatchRequestAsync>d__.checkSubpack = checkSubpack;
			<StartMatchRequestAsync>d__.<>1__state = -1;
			<StartMatchRequestAsync>d__.<>t__builder.Start<InstanceDungeonEntranceController.<StartMatchRequestAsync>d__52>(ref <StartMatchRequestAsync>d__);
			return <StartMatchRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B69C RID: 243356 RVA: 0x00F0DCA3 File Offset: 0x00F0BEA3
		public void StartMatchRequest(int instanceId, bool inviteTeamWorld = false, bool checkSubpack = true)
		{
			this.StartMatchRequestAsync(instanceId, inviteTeamWorld, checkSubpack);
		}

		// Token: 0x0603B69D RID: 243357 RVA: 0x00F0DCB0 File Offset: 0x00F0BEB0
		public void CancelMatchRequest()
		{
			CancelMatchRequest message = new CancelMatchRequest();
			Singleton<Net>.Instance.Call<CancelMatchResponse>(ERequestMessageId.CancelMatchRequest, message, delegate(CancelMatchResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.CancelMatchResponse, null, true, true);
					return;
				}
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
			}, 0);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId()).Value.MapName, null);
			ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
			string id = "CancelMatch";
			object[] parameters;
			if (localTextNew == null)
			{
				parameters = Array.Empty<object>();
			}
			else
			{
				(parameters = new object[1])[0] = localTextNew;
			}
			instance.ShowTipsById(id, parameters);
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingId(0);
		}

		// Token: 0x0603B69E RID: 243358 RVA: 0x00F0DD4C File Offset: 0x00F0BF4C
		public void MatchConfirmRequest(bool isAccept)
		{
			MatchConfirmRequest matchConfirmRequest = new MatchConfirmRequest();
			matchConfirmRequest.IsAccept = isAccept;
			Singleton<Net>.Instance.Call<MatchConfirmResponse>(ERequestMessageId.MatchConfirmRequest, matchConfirmRequest, delegate(MatchConfirmResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.MatchConfirmResponse, null, true, true);
					ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
					return;
				}
				ModelBase<InstanceDungeonModel>.Instance.SetMatchingPlayerConfirmState(ModelBase<CreatureModel>.Instance.GetPlayerId(), true);
				if (!isAccept)
				{
					ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
					return;
				}
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Waiting);
			}, 0);
		}

		// Token: 0x0603B69F RID: 243359 RVA: 0x00F0DD98 File Offset: 0x00F0BF98
		public void TeamChallengeRequest(int instanceId, bool isInviteTeammate)
		{
			TeamChallengeRequest teamChallengeRequest = new TeamChallengeRequest();
			teamChallengeRequest.InstId = instanceId;
			teamChallengeRequest.InstEnterId = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId;
			teamChallengeRequest.IsInviteTeammate = isInviteTeammate;
			Singleton<Net>.Instance.Call<TeamChallengeResponse>(ERequestMessageId.TeamChallengeRequest, teamChallengeRequest, delegate(TeamChallengeResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.TeamChallengeResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603B6A0 RID: 243360 RVA: 0x00F0DDFC File Offset: 0x00F0BFFC
		public void TeamMatchAcceptInviteRequest(bool isAccept, bool isClickCancel)
		{
			TeamMatchAcceptInviteRequest teamMatchAcceptInviteRequest = new TeamMatchAcceptInviteRequest();
			teamMatchAcceptInviteRequest.InstId = ModelBase<InstanceDungeonModel>.Instance.GetInstanceId();
			if (isAccept)
			{
				teamMatchAcceptInviteRequest.AcceptResult = EMatchAcceptInviteResult.Accept;
			}
			else if (isClickCancel)
			{
				teamMatchAcceptInviteRequest.AcceptResult = EMatchAcceptInviteResult.ActiveRefuse;
			}
			else
			{
				teamMatchAcceptInviteRequest.AcceptResult = EMatchAcceptInviteResult.TimeOutRefuse;
			}
			teamMatchAcceptInviteRequest.HostId = ModelBase<OnlineModel>.Instance.OwnerId;
			Singleton<Net>.Instance.Call<TeamMatchAcceptInviteResponse>(ERequestMessageId.TeamMatchAcceptInviteRequest, teamMatchAcceptInviteRequest, delegate(TeamMatchAcceptInviteResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.TeamMatchAcceptInviteResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603B6A1 RID: 243361 RVA: 0x00F0DE80 File Offset: 0x00F0C080
		public void TeamMatchInviteRequest()
		{
			TeamMatchInviteRequest teamMatchInviteRequest = new TeamMatchInviteRequest();
			teamMatchInviteRequest.InstId = ModelBase<InstanceDungeonModel>.Instance.GetInstanceId();
			Singleton<Net>.Instance.Call<TeamMatchInviteResponse>(ERequestMessageId.TeamMatchInviteRequest, teamMatchInviteRequest, delegate(TeamMatchInviteResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.TeamMatchInviteResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603B6A2 RID: 243362 RVA: 0x00F0DED4 File Offset: 0x00F0C0D4
		private void MatchFailNotify(MatchFailNotify data, Net.CallbackStatus status)
		{
			if (data.Reason == MatchFailReason.TimeOut)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchingTimeOut", Array.Empty<object>());
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
			ModelBase<InstanceDungeonModel>.Instance.ResetData();
		}

		// Token: 0x0603B6A3 RID: 243363 RVA: 0x00F0DF24 File Offset: 0x00F0C124
		public void MatchTeamNotify(MatchTeamNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetMatchTeamInfo(data.TeamInfo);
			ModelBase<InstanceDungeonModel>.Instance.InitMatchingTeamConfirmReadyState(data.TeamInfo.PlayerInfos);
			ModelBase<KuroSdkModel>.Instance.OnMatchTeamNotify(data.TeamInfo);
			int matchingId = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId();
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckInstanceIdIsTowerDefense(matchingId))
			{
				ControllerBase<TowerDefenseController>.Instance.SetIsUiFlowOpen(true);
			}
			if (ModelBase<InstanceDungeonModel>.Instance.GetMatchingPlayerConfirmStateByPlayerId(ModelBase<PlayerInfoModel>.Instance.GetId().Value).GetValueOrDefault())
			{
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.ConfirmToReady);
				if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InstanceDungeonEntranceView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.EditBattleTeamView))
				{
					this.OpenEditBattleView();
					int instanceId = ModelBase<InstanceDungeonModel>.Instance.GetInstanceId();
					if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.CheckInstanceIdIsTowerDefense(instanceId))
					{
						ControllerBase<TowerDefenseController>.Instance.SetIsUiFlowOpen(true);
					}
					return;
				}
			}
			else
			{
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.MatchConfirm);
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineMatchSuccessView))
				{
					return;
				}
				if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InstanceDungeonEntranceView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.EditBattleTeamView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.DangoAbyssInsSelectView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.MultiMotorChoseLevelView) && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TowerDefenseLevelView))
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineMatchSuccessView, null, null);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
		}

		// Token: 0x0603B6A4 RID: 243364 RVA: 0x00F0E09F File Offset: 0x00F0C29F
		private void MatchingNotify(MatchingNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Matching);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
		}

		// Token: 0x0603B6A5 RID: 243365 RVA: 0x00F0E0BC File Offset: 0x00F0C2BC
		public void MatchTeamStateNotify(MatchTeamStateNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetMatchTeamState(data.TeamState);
			if (data.TeamState == MatchTeamState.ReadyConfirm)
			{
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.ConfirmToReady);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
				if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InstanceDungeonEntranceView))
				{
					this.OpenEditBattleView();
					if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.OnlineMatchSuccessView))
					{
						Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMatchSuccessView, null);
					}
					return;
				}
			}
			else if (data.TeamState == MatchTeamState.WaiteConfirm)
			{
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Waiting);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
		}

		// Token: 0x0603B6A6 RID: 243366 RVA: 0x00F0E15C File Offset: 0x00F0C35C
		private void MatchConfirmNotify(MatchConfirmNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetMatchingPlayerConfirmState(data.ConfirmId, true);
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int confirmId = data.ConfirmId;
			int? num = id;
			if ((confirmId == num.GetValueOrDefault() & num != null) && ModelBase<InstanceDungeonModel>.Instance.GetMatchingTeamReady())
			{
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.ConfirmToReady);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
				if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InstanceDungeonEntranceView))
				{
					this.OpenEditBattleView();
					if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineMatchSuccessView))
					{
						Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineMatchSuccessView, null);
					}
				}
			}
		}

		// Token: 0x0603B6A7 RID: 243367 RVA: 0x00F0E1FF File Offset: 0x00F0C3FF
		private void MatchChangeRoleNotify(MatchChangeRoleNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetMatchTeamInfoPlayerRole(data.PlayerId, data.RoleInfo);
		}

		// Token: 0x0603B6A8 RID: 243368 RVA: 0x00F0E218 File Offset: 0x00F0C418
		private void MatchChangeReadyNotify(MatchChangeReadyNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetPrewarPlayerReadyState(data.PlayerId, data.IsReady);
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.PrewarReadyChanged, data.PlayerId, data.IsReady);
			ModelBase<InstanceDungeonModel>.Instance.SetPlayerUiState(data.PlayerId, data.IsReady ? EMatchPlayerUiState.Ready : EMatchPlayerUiState.Wait);
		}

		// Token: 0x0603B6A9 RID: 243369 RVA: 0x00F0E274 File Offset: 0x00F0C474
		private void LeaveMatchTeamNotify(LeaveMatchTeamNotify data, Net.CallbackStatus status)
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (data.PlayerId == playerId)
			{
				if (!ModelBase<InstanceDungeonModel>.Instance.IsMatchTeamHost() && data.LeaveReason == MatchPlayerLeaveReason.HostLeave)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LeaderExitMatching", Array.Empty<object>());
				}
				if (data.LeaveReason == MatchPlayerLeaveReason.BeKick)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MatchLeaveTeamByKickOut", Array.Empty<object>());
				}
				ModelBase<InstanceDungeonModel>.Instance.ResetData();
				ControllerBase<EditBattleTeamController>.Instance.ExitEditBattleTeam(false);
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetMatchingState(EInstanceMatchState.Default);
				ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				ModelBase<OnlineModel>.Instance.ClearPlayerTeleportState();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingChange);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnLeaveTeam);
				this.HandleExitMatch = false;
				return;
			}
			string matchTeamName = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamName(data.PlayerId);
			ScrollingTipsController instance = ControllerBase<ScrollingTipsController>.Instance;
			string id = "OthersLeaveMatchTeam";
			object[] parameters;
			if (matchTeamName == null)
			{
				parameters = Array.Empty<object>();
			}
			else
			{
				(parameters = new object[1])[0] = matchTeamName;
			}
			instance.ShowTipsById(id, parameters);
			ModelBase<InstanceDungeonModel>.Instance.RemovePrewarFormationDataByPlayer(data.PlayerId);
			ModelBase<OnlineModel>.Instance.DeletePlayerTeleportState(data.PlayerId);
			Singleton<EventSystem>.Instance.Emit(EEventName.PrewarFormationChanged);
		}

		// Token: 0x0603B6AA RID: 243370 RVA: 0x00F0E3A0 File Offset: 0x00F0C5A0
		private void EnterMatchTeamNotify(EnterMatchTeamNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonModel>.Instance.SetMatchingPlayerConfirmState(data.PlayerInfo.PlayerId, false);
			ModelBase<InstanceDungeonModel>.Instance.SetPrewarPlayerReadyState(data.PlayerInfo.PlayerId, false);
			ModelBase<InstanceDungeonModel>.Instance.AddPrewarFormationDataByPlayerInfo(data.PlayerInfo, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.PrewarFormationChanged);
		}

		// Token: 0x0603B6AB RID: 243371 RVA: 0x00F0E3FC File Offset: 0x00F0C5FC
		private void TeamMatchFlagNotify(TeamMatchFlagNotify data, Net.CallbackStatus status)
		{
			MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
			if (matchTeamInfo != null)
			{
				int hostId = matchTeamInfo.HostId;
				ModelBase<InstanceDungeonModel>.Instance.SetPlayerUiState(hostId, data.MatchFlag ? EMatchPlayerUiState.Matching : EMatchPlayerUiState.Wait);
				ModelBase<InstanceDungeonEntranceModel>.Instance.SetEditBattleTeamMatching(data.MatchFlag);
				return;
			}
			if (data.MatchFlag)
			{
				this.StartMatch(data.InstId);
				return;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.CancelMatchingTimer();
			if (!ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LeaderCancelMatch", Array.Empty<object>());
			}
		}

		// Token: 0x0603B6AC RID: 243372 RVA: 0x00F0E488 File Offset: 0x00F0C688
		private unsafe void InstSettleNotify(InstSettleNotify data, Net.CallbackStatus status)
		{
			if (this.IsSettleExternalProcess)
			{
				this.IsSettleExternalProcess = false;
				return;
			}
			this.IsShowSettleSuccess = data.IsSuccess;
			if (!ModelBase<GameModeModel>.Instance.WorldDone)
			{
				Singleton<Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.LJQ, "副本结算通知时，世界未加载完成", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SettleCache = data;
				return;
			}
			if (data.RewardFailTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonRewardTimeNotEnough", Array.Empty<object>());
				return;
			}
			ModelBase<InstanceDungeonEntranceModel>.Instance.SyncSettleRewardItemList(data.RewardItems);
			if (!data.IsSuccess)
			{
				this.OpenInstanceDungeonFailView();
				return;
			}
			List<IRewardExploreConfirmButton> buttonInfoList = this.InitSettleViewButtonList(data.IsSuccess);
			if (ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()).Value.SettleButtonType == 5)
			{
				return;
			}
			List<RewardItemData> list = new List<RewardItemData>();
			MapField<int, RewardItemInfoList> rewardItems = data.RewardItems;
			foreach (int num in rewardItems.Keys)
			{
				RewardItemInfoList rewardItemInfoList = rewardItems[num];
				RepeatedField<RewardItemInfo> repeatedField = (rewardItemInfoList != null) ? rewardItemInfoList.ItemList : null;
				if (repeatedField != null)
				{
					int dropItemType = num;
					foreach (RewardItemInfo rewardItemInfo in repeatedField)
					{
						RewardItemData item = new RewardItemData(rewardItemInfo.ItemId, rewardItemInfo.Count, new int?(rewardItemInfo.IncrId), (EDropItemType)dropItemType);
						list.Add(item);
					}
				}
			}
			bool value = false;
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (instanceId != 0)
			{
				InstanceDungeon? instanceDungeon;
				int value2 = (ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId) != null) ? instanceDungeon.GetValueOrDefault().InstSubType : 0;
				IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("MultiRewardLevelInstType");
				value = (intArrayConfig != null && intArrayConfig.Contains(value2));
			}
			string tip = null;
			if (data.Magnification > 1)
			{
				DoubleDropFrom from = data.From;
				if (from != DoubleDropFrom.DoubleActivity)
				{
					if (from == DoubleDropFrom.FromRegress)
					{
						if (instanceId != 0)
						{
							ValueTuple<bool, int, int, string, string> regressDoubleDropTuple = ModelBase<ActivityRegressModel>.Instance.GetRegressDoubleDropTuple(instanceId);
							bool item2 = regressDoubleDropTuple.Item1;
							int item3 = regressDoubleDropTuple.Item2;
							int item4 = regressDoubleDropTuple.Item3;
							string item5 = regressDoubleDropTuple.Item4;
							string item6 = regressDoubleDropTuple.Item5;
							if (item2)
							{
								string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(item6, Array.Empty<string>());
								string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText(item5, new string[]
								{
									item3.ToString(),
									item4.ToString()
								});
								tip = multiText + multiText2;
							}
						}
					}
				}
				else
				{
					ActivityDoubleRewardController instance = ControllerBase<ActivityDoubleRewardController>.Instance;
					int num2 = 2;
					List<int> list2 = new List<int>(num2);
					CollectionsMarshal.SetCount<int>(list2, num2);
					Span<int> span = CollectionsMarshal.AsSpan<int>(list2);
					int num3 = 0;
					*span[num3] = 1;
					num3++;
					*span[num3] = 2;
					tip = instance.GetDungeonUpActivityFullTip(list2, true);
				}
			}
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView((list.Count > 0) ? 3004 : 3007, true, list, null, null, buttonInfoList, null, null, null, tip, null, new bool?(ModelBase<GameModeModel>.Instance.IsMulti), null, null, new bool?(value), null, null);
		}

		// Token: 0x0603B6AD RID: 243373 RVA: 0x00F0E7B8 File Offset: 0x00F0C9B8
		[NullableContext(0)]
		public UniTask<bool> OpenInstanceDungeonFailView()
		{
			InstanceDungeonEntranceController.<OpenInstanceDungeonFailView>d__70 <OpenInstanceDungeonFailView>d__;
			<OpenInstanceDungeonFailView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenInstanceDungeonFailView>d__.<>4__this = this;
			<OpenInstanceDungeonFailView>d__.<>1__state = -1;
			<OpenInstanceDungeonFailView>d__.<>t__builder.Start<InstanceDungeonEntranceController.<OpenInstanceDungeonFailView>d__70>(ref <OpenInstanceDungeonFailView>d__);
			return <OpenInstanceDungeonFailView>d__.<>t__builder.Task;
		}

		// Token: 0x0603B6AE RID: 243374 RVA: 0x00F0E7FC File Offset: 0x00F0C9FC
		[NullableContext(1)]
		private void EntranceStateNotify(EntranceStateNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			long id = data.Id;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(id);
			if (entity == null)
			{
				return;
			}
			int? num = null;
			switch (data.State)
			{
			case EntranceState.NotUnlock:
				num = new int?(GameplayTagDefine.EGameplayTagId["物体.物体阶段.不可解锁"]);
				break;
			case EntranceState.Unlockable:
				num = new int?(GameplayTagDefine.EGameplayTagId["物体.物体阶段.可解锁"]);
				break;
			case EntranceState.Unlocked:
				num = new int?(GameplayTagDefine.EGameplayTagId["物体.物体阶段.已解锁"]);
				break;
			default:
				num = new int?(GameplayTagDefine.EGameplayTagId["物体.物体阶段.不可解锁"]);
				break;
			}
			LockComponent component = entity.Entity.GetComponent<LockComponent>();
			if (component != null)
			{
				component.ChangeLockTag(num.Value);
			}
		}

		// Token: 0x0603B6AF RID: 243375 RVA: 0x00F0E8BF File Offset: 0x00F0CABF
		private void InstDataNotify(InstDataNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.InitInstanceDataList(data.EnterInfos);
		}

		// Token: 0x0603B6B0 RID: 243376 RVA: 0x00F0E8D1 File Offset: 0x00F0CAD1
		private void UpdateEnterInfoNotify(UpdateEnterInfoNotify data, Net.CallbackStatus status)
		{
			ModelBase<InstanceDungeonEntranceModel>.Instance.InitInstanceDataList(data.EnterInfos);
		}

		// Token: 0x0603B6B1 RID: 243377 RVA: 0x00F0E8E4 File Offset: 0x00F0CAE4
		private void TeamMatchInviteNotify(TeamMatchInviteNotify data, Net.CallbackStatus status)
		{
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			instance.CancelMatchingTimer();
			ModelBase<InstanceDungeonModel>.Instance.SetInstanceId(data.InstId);
			instance.SetMatchingId(data.InstId);
			if (ModelBase<PlotModel>.Instance.IsInPlot)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.OnlineChallengeApplyView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineChallengeApplyView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineChallengeApplyView, null, null);
		}

		// Token: 0x0603B6B2 RID: 243378 RVA: 0x00F0E958 File Offset: 0x00F0CB58
		[NullableContext(1)]
		private void TeamMatchInviteRetToHostNotify(TeamMatchInviteRetToHostNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(data.ErrorCode);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType(EPromptSubViewType.FloatLinePrompt, null, null, new object[]
			{
				textByErrorId
			}, null, null, null);
		}

		// Token: 0x0603B6B3 RID: 243379 RVA: 0x00F0E999 File Offset: 0x00F0CB99
		[NullableContext(1)]
		private void StartMatchNotify(StartMatchNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			this.StartMatch(data.InstId);
		}

		// Token: 0x0603B6B4 RID: 243380 RVA: 0x00F0E9A8 File Offset: 0x00F0CBA8
		[NullableContext(1)]
		private void CancelMatchNotify(CancelMatchNotify data, [Nullable(2)] Net.CallbackStatus status)
		{
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			if (!ModelBase<OnlineModel>.Instance.GetIsMyTeam() && instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("LeaderCancelMatch", Array.Empty<object>());
			}
			if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				int matchingId = instance.GetMatchingId();
				if (matchingId != 0)
				{
					this.HandleTipsExitMatchId = matchingId;
				}
			}
			instance.CancelMatchingTimer();
		}

		// Token: 0x0603B6B5 RID: 243381 RVA: 0x00F0EA08 File Offset: 0x00F0CC08
		private void TeamMatchAcceptInviteNotify(TeamMatchAcceptInviteNotify data, Net.CallbackStatus status)
		{
			if (data.AcceptResult != EMatchAcceptInviteResult.Accept)
			{
				string name = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(data.PlayerId).Name;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RefuseInviteMatch", new object[]
				{
					name
				});
			}
		}

		// Token: 0x0603B6B6 RID: 243382 RVA: 0x00F0EA4C File Offset: 0x00F0CC4C
		[NullableContext(1)]
		public bool OpenViewLimit(EUiViewName viewName, object arg)
		{
			if (this.CheckInstanceShieldView(viewName))
			{
				if (Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTipWithSkip())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("IOSCannotUseTips", Array.Empty<object>());
				}
				else
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonShieldViewCantOpen", Array.Empty<object>());
				}
				return false;
			}
			return true;
		}

		// Token: 0x0603B6B7 RID: 243383 RVA: 0x00F0EAA0 File Offset: 0x00F0CCA0
		public void OpenEditBattleView()
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingId();
			if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				this.HandleExitMatch = true;
				return;
			}
			MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
			Aki.Protocol.Vector vector = (matchTeamInfo != null) ? matchTeamInfo.Location : null;
			MatchTeamInfo matchTeamInfo2 = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
			Aki.Protocol.Rotator rotator = (matchTeamInfo2 != null) ? matchTeamInfo2.Rotation : null;
			if (vector != null && rotator != null)
			{
				global::Vector vector2 = global::Vector.Create(vector);
				global::Rotator rotator2 = global::Rotator.Create(rotator);
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				CharacterDriveVehicleComponent characterDriveVehicleComponent;
				if (getCurrentEntity == null)
				{
					characterDriveVehicleComponent = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					characterDriveVehicleComponent = ((entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null);
				}
				CharacterDriveVehicleComponent characterDriveVehicleComponent2 = characterDriveVehicleComponent;
				if (characterDriveVehicleComponent2 != null)
				{
					Entity vehicleEntity = characterDriveVehicleComponent2.VehicleEntity;
					if (vehicleEntity != null && vehicleEntity.Valid)
					{
						BaseVehiclePerformComponent component = characterDriveVehicleComponent2.VehicleEntity.GetComponent<BaseVehiclePerformComponent>();
						if (component != null)
						{
							component.TryLeaveAtOnce(characterDriveVehicleComponent2.Entity, ELeaveVehicleType.StandUp, "InstanceDungeonEntranceController.OpenEditBattleView", false);
						}
					}
				}
				ControllerBase<TeleportController>.Instance.TeleportPlayer(new ITeleportContextParam
				{
					ClientReason = "InstanceDungeonEntranceController.OpenEditBattleView",
					TargetPosition = vector2.ToUeVector(false),
					TargetRotation = rotator2.ToUeRotator(),
					TeleportMode = new ETeleportMode?(ETeleportMode.Loading)
				}).ContinueWith(delegate(bool _)
				{
					ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
					ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(instanceId, true, true, false, null);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTeam);
				});
				return;
			}
			ModelBase<EditBattleTeamModel>.Instance.InstanceMultiEnter = true;
			ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(instanceId, true, true, false, null);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnEnterTeam);
		}

		// Token: 0x0603B6B8 RID: 243384 RVA: 0x00F0EC14 File Offset: 0x00F0CE14
		[NullableContext(1)]
		private List<IRewardExploreConfirmButton> InitSettleViewButtonList(bool isSuccess)
		{
			List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId());
			int settleButtonType = config.Value.SettleButtonType;
			bool isMulti = ModelBase<GameModeModel>.Instance.IsMulti;
			if (!isSuccess || isMulti || settleButtonType == 3 || settleButtonType == 1 || settleButtonType == 4)
			{
				RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
				{
					ButtonTextId = "Text_ButtonTextExit_Text",
					DescriptionTextId = "GenericPromptTypes_2_GeneralText",
					DescriptionArgs = null,
					TimeDown = new int?(config.Value.AutoLeaveTime * Singleton<TimeUtil>.Instance.InverseMillisecond),
					IsTimeDownCloseView = true,
					OnTimeDownOnCallback = delegate
					{
						this.LeaveInstanceDungeon();
					},
					IsClickedCloseView = false,
					OnClickedCallback = delegate(int index)
					{
						this.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
						{
							if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
							{
								Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
							}
						});
					}
				};
				list.Add(item);
			}
			if (isMulti)
			{
				string buttonTextId = ModelBase<CreatureModel>.Instance.IsMyWorld() ? "Text_ContinueChallenge_Text" : "Text_SuggestContinueChallenge_Text";
				List<object> list2 = new List<object>();
				int powerCount = ModelBase<PowerModel>.Instance.PowerCount;
				list2.Add(powerCount);
				string item2 = "<texture=" + this.PowerIconPath + "/>";
				list2.Add(item2);
				RewardExploreConfirmButtonData item3 = new RewardExploreConfirmButtonData
				{
					ButtonTextId = buttonTextId,
					DescriptionTextId = "Text_RemainText_Text",
					DescriptionArgs = list2,
					IsTimeDownCloseView = false,
					IsClickedCloseView = false,
					OnClickedCallback = new Action<int>(this.SettleViewButtonSuccessOnMultiCallBack),
					ClickCd = new int?(ModelBase<OnlineModel>.Instance.ApplyCd * Singleton<TimeUtil>.Instance.InverseMillisecond)
				};
				list.Add(item3);
				return list;
			}
			if (!isSuccess || settleButtonType == 4)
			{
				this.IsShowSettlePower = true;
				List<object> list3 = new List<object>();
				string text = ModelBase<PowerModel>.Instance.PowerCount.ToString();
				int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
				int? instancePowerCost = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(instanceId);
				if (!ModelBase<PowerModel>.Instance.IsPowerEnough(instancePowerCost))
				{
					text = "<color=#c25757>" + text + "</color>";
				}
				list3.Add(text);
				string item4 = "<texture=" + this.PowerIconPath + "/>";
				list3.Add(item4);
				RewardExploreConfirmButtonData item5 = new RewardExploreConfirmButtonData
				{
					ButtonTextId = "Text_ChallengeAgain_Text",
					DescriptionTextId = (((instancePowerCost ?? 0) != 0) ? "Text_RemainText_Text" : null),
					DescriptionArgs = (((instancePowerCost ?? 0) != 0) ? list3 : null),
					IsTimeDownCloseView = false,
					IsClickedCloseView = false,
					OnClickedCallback = delegate(int index)
					{
						int? instancePowerCost2 = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(instanceId);
						if (!ModelBase<PowerModel>.Instance.IsPowerEnough(instancePowerCost2) && !ModelBase<InstanceDungeonModel>.Instance.HidePowerLackConfirmBox)
						{
							ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.InstancePowerNotEnough);
							confirmBoxDataNew.ShowPowerItem = true;
							confirmBoxDataNew.SetTextArgs(new string[]
							{
								instancePowerCost2.ToString(),
								ModelBase<PowerModel>.Instance.PowerCount.ToString()
							});
							confirmBoxDataNew.FunctionMap.Add(1, delegate
							{
							});
							confirmBoxDataNew.FunctionMap.Add(2, delegate
							{
								this.RestartInstanceDungeon().ContinueWith(delegate(bool _)
								{
									if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
									{
										Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
									}
								});
							});
							confirmBoxDataNew.HasToggle = true;
							confirmBoxDataNew.ToggleText = ConfigBase<TextConfig>.Instance.GetTextById("PlotSkipConfirmToggle");
							confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
							{
								ModelBase<InstanceDungeonModel>.Instance.HidePowerLackConfirmBox = isSelectOn;
							});
							ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
							return;
						}
						if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanChallenge(instanceId))
						{
							ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InstanceDungeonLackChallengeTimes", Array.Empty<object>());
							return;
						}
						this.RestartInstanceDungeon().ContinueWith(delegate(bool _)
						{
							if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
							{
								Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
							}
						});
					}
				};
				list.Add(item5);
			}
			if (isSuccess && (settleButtonType == 2 || settleButtonType == 3))
			{
				RewardExploreConfirmButtonData item6 = new RewardExploreConfirmButtonData
				{
					ButtonTextId = "Text_KeepOnButton_Text",
					DescriptionTextId = null,
					IsTimeDownCloseView = false,
					IsClickedCloseView = false,
					OnClickedCallback = delegate(int index)
					{
						if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
						{
							Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
							this.IsShowSettlePower = false;
						}
					}
				};
				list.Add(item6);
			}
			return list;
		}

		// Token: 0x0603B6B9 RID: 243385 RVA: 0x00F0EF30 File Offset: 0x00F0D130
		public void SettleViewButtonSuccessOnMultiCallBack(int index)
		{
			if (!ModelBase<OnlineModel>.Instance.AllowInitiate)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotInvite", Array.Empty<object>());
				return;
			}
			bool flag = ModelBase<CreatureModel>.Instance.IsMyWorld();
			double nextInitiateLeftTime = ModelBase<OnlineModel>.Instance.NextInitiateLeftTime;
			if (nextInitiateLeftTime > 0.0)
			{
				if (flag)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NextInviteTime", new object[]
					{
						Singleton<TimeUtil>.Instance.GetCoolDown(nextInitiateLeftTime)
					});
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NextSuggestTime", new object[]
				{
					Singleton<TimeUtil>.Instance.GetCoolDown(nextInitiateLeftTime)
				});
				return;
			}
			else
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineChallengeApplyView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineChallengeApplyView, null);
				}
				if (ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(ModelBase<PlayerInfoModel>.Instance.GetId().Value).GetValueOrDefault() == EContinuingChallenge.Pending)
				{
					ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Settle);
					return;
				}
				if (flag)
				{
					ControllerBase<OnlineController>.Instance.InviteRechallengeRequest();
					return;
				}
				ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Settle);
				return;
			}
		}

		// Token: 0x0603B6BA RID: 243386 RVA: 0x00F0F038 File Offset: 0x00F0D238
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IRewardExploreBar> InitBarData()
		{
			List<IRewardExploreBar> list = new List<IRewardExploreBar>();
			IReadOnlyList<TrainingData> trainingDataList = ModelBase<TrainingDegreeModel>.Instance.GetTrainingDataList();
			if (trainingDataList == null)
			{
				return null;
			}
			foreach (TrainingData trainingData in trainingDataList)
			{
				RewardExploreBar item = new RewardExploreBar
				{
					TrainingData = trainingData
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0603B6BB RID: 243387 RVA: 0x00F0F0A8 File Offset: 0x00F0D2A8
		private void StartMatch(int instId)
		{
			InstanceDungeonEntranceController.<>c__DisplayClass86_0 CS$<>8__locals1 = new InstanceDungeonEntranceController.<>c__DisplayClass86_0();
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instId).Value.MapName, null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("TeamLeaderMatch", new object[]
			{
				localTextNew
			});
			CS$<>8__locals1.entranceModel = ModelBase<InstanceDungeonEntranceModel>.Instance;
			CS$<>8__locals1.entranceModel.SetMatchingId(instId);
			CS$<>8__locals1.entranceModel.SetMatchingState(EInstanceMatchState.Matching);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMatchingBegin);
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineWorldHallView) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InstanceDungeonEntranceView) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EditBattleTeamView))
			{
				CS$<>8__locals1.entranceModel.MatchingTime = 0;
				CS$<>8__locals1.entranceModel.OnStopTimer = new Func<bool>(CS$<>8__locals1.<StartMatch>g__StopTimer|0);
				this.StartMatchTimer(null);
			}
		}

		// Token: 0x0603B6BC RID: 243388 RVA: 0x00F0F188 File Offset: 0x00F0D388
		public void StartMatchTimer(Action handle = null)
		{
			InstanceDungeonEntranceModel entranceModel = ModelBase<InstanceDungeonEntranceModel>.Instance;
			if (entranceModel.MatchingTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(entranceModel.MatchingTimer);
			}
			entranceModel.MatchingTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (entranceModel.OnStopTimer == null)
				{
					if (entranceModel.MatchingTimer != null)
					{
						TimerSystem.GameplayTimeInstance.Remove(entranceModel.MatchingTimer);
					}
					entranceModel.OnStopTimer = null;
					entranceModel.OnStopHandle = null;
					entranceModel.MatchingTimer = null;
					return;
				}
				if (entranceModel.OnStopTimer())
				{
					if (entranceModel.MatchingTimer != null)
					{
						TimerSystem.GameplayTimeInstance.Remove(entranceModel.MatchingTimer);
					}
					entranceModel.MatchingTimer = null;
					if (entranceModel.OnStopHandle != null)
					{
						entranceModel.OnStopHandle();
					}
					return;
				}
				entranceModel.MatchingTimeIncrease();
				Action handle2 = handle;
				if (handle2 == null)
				{
					return;
				}
				handle2();
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x0603B6BD RID: 243389 RVA: 0x00F0F200 File Offset: 0x00F0D400
		private UniTask OpenThirdPartyMessageBox(ESdkPrivilege privilege)
		{
			InstanceDungeonEntranceController.<OpenThirdPartyMessageBox>d__88 <OpenThirdPartyMessageBox>d__;
			<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenThirdPartyMessageBox>d__.privilege = privilege;
			<OpenThirdPartyMessageBox>d__.<>1__state = -1;
			<OpenThirdPartyMessageBox>d__.<>t__builder.Start<InstanceDungeonEntranceController.<OpenThirdPartyMessageBox>d__88>(ref <OpenThirdPartyMessageBox>d__);
			return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
		}

		// Token: 0x0603B6BE RID: 243390 RVA: 0x00F0F244 File Offset: 0x00F0D444
		public IInstanceDungeonEntranceAbility CreateInstanceSubViewByType(EInstanceEntranceSubViewType t)
		{
			Func<IInstanceDungeonEntranceAbility> func;
			if (this.InstanceSubViewCache.TryGetValue(t, out func))
			{
				return func();
			}
			return null;
		}

		// Token: 0x0603B6BF RID: 243391 RVA: 0x00F0F26C File Offset: 0x00F0D46C
		public string GetInstanceSubtitleTextIdByInstanceId(int id)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
			if (config == null)
			{
				return null;
			}
			if (config.Value.InstSubType == 22)
			{
				return ModelBase<MowingRiskModel>.Instance.BuildInstanceSubtitleTextIdByInstanceId(id);
			}
			return null;
		}

		// Token: 0x0603B6C0 RID: 243392 RVA: 0x00F0F2B0 File Offset: 0x00F0D4B0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetInstanceSubtitleArgsByInstanceId(int id)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(id);
			if (config == null)
			{
				return null;
			}
			if (config.Value.InstSubType == 22)
			{
				return ModelBase<MowingRiskModel>.Instance.BuildInstanceSubtitleTextArgsByInstanceId(id);
			}
			return null;
		}

		// Token: 0x0603B6C1 RID: 243393 RVA: 0x00F0F2F4 File Offset: 0x00F0D4F4
		public string GetIconRightPathGetter(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null)
			{
				return null;
			}
			if (config.Value.InstSubType == 28)
			{
				return ModelBase<SolarSpeedModel>.Instance.GetIconPathInInstanceSeriesItemByInstanceId(instanceId);
			}
			return null;
		}

		// Token: 0x0603B6C2 RID: 243394 RVA: 0x00F0F338 File Offset: 0x00F0D538
		public bool GetInstanceItemLockStateGetter(int instanceId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType != 28 && !ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instanceId);
		}

		// Token: 0x0603B6C3 RID: 243395 RVA: 0x00F0F37F File Offset: 0x00F0D57F
		public bool CheckRightTitleAvailableByInstanceId(int instanceId)
		{
			return ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) != 9000;
		}

		// Token: 0x0603B6C4 RID: 243396 RVA: 0x00F0F398 File Offset: 0x00F0D598
		public TPictureItemDataGetter GetPictureItemDataGetter(int instanceId)
		{
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) == 9000)
			{
				return () => ModelBase<SolarSpeedModel>.Instance.GetInfoPicturePathByInstanceId(instanceId);
			}
			return null;
		}

		// Token: 0x0603B6C5 RID: 243397 RVA: 0x00F0F3D8 File Offset: 0x00F0D5D8
		public TDescWidelyItemDataGetter GetDescWidelyItemDataGetter(int instanceId)
		{
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) != 9000)
			{
				return null;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null)
			{
				return null;
			}
			return () => config.Value.DungeonDesc;
		}

		// Token: 0x0603B6C6 RID: 243398 RVA: 0x00F0F42C File Offset: 0x00F0D62C
		public TTitleWidelyItemDataGetter GetTitleWidelyItemDataGetter(int instanceId)
		{
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) != 9000)
			{
				return null;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null)
			{
				return null;
			}
			return () => config.Value.MapName;
		}

		// Token: 0x0603B6C7 RID: 243399 RVA: 0x00F0F480 File Offset: 0x00F0D680
		public TScoreListItemDataGetter GetScoreListItemDataGetter(int instanceId)
		{
			if (ConfigBase<InstanceDungeonEntranceConfig>.Instance.GetEntranceIdByInstanceId(instanceId) == 9000)
			{
				return delegate()
				{
					SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
					int? historyRankByInstanceId = instance.GetHistoryRankByInstanceId(instanceId);
					if (historyRankByInstanceId != null)
					{
						int? num = historyRankByInstanceId;
						int num2 = 0;
						if (!(num.GetValueOrDefault() == num2 & num != null))
						{
							int? historyHighScoreByInstanceId = instance.GetHistoryHighScoreByInstanceId(instanceId);
							int valueOrDefault = instance.GetHistoryLapRecordByInstanceId(instanceId).GetValueOrDefault();
							string medalPathId = (historyRankByInstanceId == null) ? null : instance.GetMedalPathByRank(historyRankByInstanceId.Value);
							return new InstanceDungeonScoreListItemData
							{
								TitleTextId1 = "LianjiPaoku_Top_Rank",
								TitleTextId2 = "LianjiPaoku_Top_Score",
								TitleTextId3 = "LianjiPaoku_Top_Time",
								ScoreText1 = (((historyRankByInstanceId != null) ? historyRankByInstanceId.GetValueOrDefault().ToString() : null) ?? ""),
								ScoreText2 = (((historyHighScoreByInstanceId != null) ? historyHighScoreByInstanceId.GetValueOrDefault().ToString() : null) ?? ""),
								ScoreText3 = ((valueOrDefault == 0) ? (ConfigMultiTextLang.GetLocalTextNew("LianjiPaoku_Top_Time_No_Time", null) ?? "") : Singleton<TimeUtil>.Instance.GetTimeString((double)valueOrDefault)),
								MedalPathId = medalPathId
							};
						}
					}
					return null;
				};
			}
			return null;
		}

		// Token: 0x040217BD RID: 137149
		private const int ONE_SECONDS = 1000;

		// Token: 0x040217BE RID: 137150
		private const int INSTANCE_SUCCESS = 3004;

		// Token: 0x040217BF RID: 137151
		private const int INSTANCE_FAIL = 3005;

		// Token: 0x040217C0 RID: 137152
		private const int INSTANCE_SUCCESS_NO_REWARD = 3007;

		// Token: 0x040217C1 RID: 137153
		private const int SETTLE_TYPE_ONETIME = 1;

		// Token: 0x040217C2 RID: 137154
		private const int SETTLE_TYPE_ROLETRIAL = 2;

		// Token: 0x040217C3 RID: 137155
		private const int SETTLE_TYPE_NONE = 3;

		// Token: 0x040217C4 RID: 137156
		public const int SETTLE_TYPE_MATERIALS = 4;

		// Token: 0x040217C5 RID: 137157
		private const int SETTLE_TYPE_CLOSE = 5;

		// Token: 0x040217C6 RID: 137158
		private InstSettleNotify SettleCache;

		// Token: 0x040217C7 RID: 137159
		public bool LimitOpenView = true;

		// Token: 0x040217C8 RID: 137160
		private string PowerIconPath;

		// Token: 0x040217C9 RID: 137161
		private bool IsShowSettlePower;

		// Token: 0x040217CA RID: 137162
		private bool IsShowSettleSuccess;

		// Token: 0x040217CB RID: 137163
		public bool IsSettleExternalProcess;

		// Token: 0x040217CC RID: 137164
		[Nullable(1)]
		private readonly Dictionary<EInstanceEntranceSubViewType, Func<IInstanceDungeonEntranceAbility>> InstanceSubViewCache = new Dictionary<EInstanceEntranceSubViewType, Func<IInstanceDungeonEntranceAbility>>();

		// Token: 0x040217CD RID: 137165
		public int HandleTipsExitMatchId;

		// Token: 0x040217CE RID: 137166
		public bool HandleExitMatch;
	}
}
