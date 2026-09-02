using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002333 RID: 9011
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class OnlineController : UiControllerBase<OnlineController>
{
	// Token: 0x0601128D RID: 70285 RVA: 0x004B5FB0 File Offset: 0x004B41B0
	protected override bool OnInit()
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("netstate_push_interval");
		int inverseMillisecond = Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.PingPushInterval = ((intConfig != null) ? new float?((float)(intConfig.GetValueOrDefault() * inverseMillisecond)) : null);
		intConfig = ConfigCommonParamById.GetIntConfig("netstate_great");
		this.NetGreatDefine = ((intConfig != null) ? new float?((float)intConfig.GetValueOrDefault()) : null);
		intConfig = ConfigCommonParamById.GetIntConfig("netstate_good");
		this.NetGoodDefine = ((intConfig != null) ? new float?((float)intConfig.GetValueOrDefault()) : null);
		intConfig = ConfigCommonParamById.GetIntConfig("netstate_weak");
		this.NetWeaktDefine = ((intConfig != null) ? new float?((float)intConfig.GetValueOrDefault()) : null);
		this.JoinSessionDelegate = global::DelegateUtils.ToManualReleaseDelegate<FJoinSessionCallBack>(new Action<string, string>(this.AddJoinSessionDelegate));
		UKuroStaticPS5Library.AddJoinSessionDelegate(this.JoinSessionDelegate);
		return true;
	}

	// Token: 0x0601128E RID: 70286 RVA: 0x004B60B5 File Offset: 0x004B42B5
	protected override bool OnClear()
	{
		if (this.JoinSessionDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<string, string>(this.AddJoinSessionDelegate));
			this.JoinSessionDelegate = null;
		}
		UKuroStaticPS5Library.ClearJoinSessionDelegate();
		return true;
	}

	// Token: 0x0601128F RID: 70287 RVA: 0x004B60E0 File Offset: 0x004B42E0
	private unsafe void AddJoinSessionDelegate(string userId, string playerSession)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PS5 PlaySession 点击加入事件触发 ";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("userId:", userId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("playerSession", playerSession);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		UKuroStaticPS5Library.ClearJoinSessionHandle();
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.LoginView) || ModelBase<LoadingModel>.Instance.IsLoadingView || ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = playerSession;
			Singleton<EventSystem>.Instance.Emit(EEventName.PlayStationJoinSessionEvent);
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 登录或加载界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 副本中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 大世界申请联机", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TryApplyJoinWorldRequest(playerSession).Forget();
	}

	// Token: 0x06011290 RID: 70288 RVA: 0x004B61F4 File Offset: 0x004B43F4
	public unsafe static void OnThirdPartyJoinSessionEvent(string userId, string playerSession)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Login;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PS5 PlaySession 点击加入事件触发 ";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("userId:", userId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("playerSession", playerSession);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "OnThirdPartyJoinSessionEvent 玩家没有UGC权限", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<OnlineController>.Instance.OpenThirdPartyMessageBox(ESdkPrivilege.UserGeneratedContent).Forget();
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.LoginView) || ModelBase<LoadingModel>.Instance.IsLoadingView || ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.Init))
		{
			ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = playerSession;
			Singleton<EventSystem>.Instance.Emit(EEventName.PlayStationJoinSessionEvent);
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 登录或加载界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 副本中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Login, ELogAuthor.LJQ, "PS5 PlaySession 点击加入事件触发 大世界申请联机", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<OnlineController>.Instance.TryApplyJoinWorldRequest(playerSession).Forget();
	}

	// Token: 0x06011291 RID: 70289 RVA: 0x004B6340 File Offset: 0x004B4540
	private UniTask TryApplyJoinWorldRequest(string playerSession)
	{
		OnlineController.<TryApplyJoinWorldRequest>d__19 <TryApplyJoinWorldRequest>d__;
		<TryApplyJoinWorldRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryApplyJoinWorldRequest>d__.<>4__this = this;
		<TryApplyJoinWorldRequest>d__.playerSession = playerSession;
		<TryApplyJoinWorldRequest>d__.<>1__state = -1;
		<TryApplyJoinWorldRequest>d__.<>t__builder.Start<OnlineController.<TryApplyJoinWorldRequest>d__19>(ref <TryApplyJoinWorldRequest>d__);
		return <TryApplyJoinWorldRequest>d__.<>t__builder.Task;
	}

	// Token: 0x06011292 RID: 70290 RVA: 0x004B638C File Offset: 0x004B458C
	private UniTask OpenThirdPartyMessageBox(ESdkPrivilege privilege)
	{
		OnlineController.<OpenThirdPartyMessageBox>d__20 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.privilege = privilege;
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<OnlineController.<OpenThirdPartyMessageBox>d__20>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x06011293 RID: 70291 RVA: 0x004B63D0 File Offset: 0x004B45D0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ScenePlayerLeaveScene, new Action<int>(this.ScenePlayerLeaveScene));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.OnCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSetGameModeDataDone, new Action(this.OnSetGameModeDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		Singleton<EventSystem>.Instance.Add(EEventName.CsRequestJoinWorld, new Action<int, int>(this.CsRequestJoinWorld));
	}

	// Token: 0x06011294 RID: 70292 RVA: 0x004B64C0 File Offset: 0x004B46C0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ScenePlayerLeaveScene, new Action<int>(this.ScenePlayerLeaveScene));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.WorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoadingView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFinishLoadingState, new Action(this.OnCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSetGameModeDataDone, new Action(this.OnSetGameModeDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.CsRequestJoinWorld, new Action<int, int>(this.CsRequestJoinWorld));
	}

	// Token: 0x06011295 RID: 70293 RVA: 0x004B6594 File Offset: 0x004B4794
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ApplyJoinWorldNotify>(ENotifyMessageId.ApplyJoinWorldNotify, new Action<ApplyJoinWorldNotify, Net.CallbackStatus>(this.ApplyJoinWorldNotify));
		Singleton<Net>.Instance.Register<AgreeJoinResultNotify>(ENotifyMessageId.AgreeJoinResultNotify, new Action<AgreeJoinResultNotify, Net.CallbackStatus>(this.AgreeJoinResultNotify));
		Singleton<Net>.Instance.Register<AllApplyJoinNotify>(ENotifyMessageId.AllApplyJoinNotify, new Action<AllApplyJoinNotify, Net.CallbackStatus>(this.AllApplyJoinNotify));
		Singleton<Net>.Instance.Register<JoinWorldTeamNotify>(ENotifyMessageId.JoinWorldTeamNotify, new Action<JoinWorldTeamNotify, Net.CallbackStatus>(this.JoinWorldTeamNotify));
		Singleton<Net>.Instance.Register<PlayerLeaveWorldTeamNotify>(ENotifyMessageId.PlayerLeaveWorldTeamNotify, new Action<PlayerLeaveWorldTeamNotify, Net.CallbackStatus>(this.PlayerLeaveWorldTeamNotify));
		Singleton<Net>.Instance.Register<PlayerEnterWorldTeamNotify>(ENotifyMessageId.PlayerEnterWorldTeamNotify, new Action<PlayerEnterWorldTeamNotify, Net.CallbackStatus>(this.PlayerEnterWorldTeamNotify));
		Singleton<Net>.Instance.Register<WorldTeamPlayerInfoChangeNotify>(ENotifyMessageId.WorldTeamPlayerInfoChangeNotify, new Action<WorldTeamPlayerInfoChangeNotify, Net.CallbackStatus>(this.WorldTeamPlayerInfoChangeNotify));
		Singleton<Net>.Instance.Register<ReceiveRechallengeNotify>(ENotifyMessageId.ReceiveRechallengeNotify, new Action<ReceiveRechallengeNotify, Net.CallbackStatus>(this.ReceiveRechallengeNotify));
		Singleton<Net>.Instance.Register<InviteRechallengeNotify>(ENotifyMessageId.InviteRechallengeNotify, new Action<InviteRechallengeNotify, Net.CallbackStatus>(this.InviteRechallengeNotify));
		Singleton<Net>.Instance.Register<ReceiveRechallengePlayerIdsNotify>(ENotifyMessageId.ReceiveRechallengePlayerIdsNotify, new Action<ReceiveRechallengePlayerIdsNotify, Net.CallbackStatus>(this.ReceiveRechallengePlayerIdsNotify));
		Singleton<Net>.Instance.Register<PlayerNetStateNotify>(ENotifyMessageId.PlayerNetStateNotify, new Action<PlayerNetStateNotify, Net.CallbackStatus>(this.PlayerNetStateNotify));
		Singleton<Net>.Instance.Register<MatchChangePlayerUiStateNotify>(ENotifyMessageId.MatchChangePlayerUiStateNotify, new Action<MatchChangePlayerUiStateNotify, Net.CallbackStatus>(this.MatchChangePlayerUiStateNotify));
		Singleton<Net>.Instance.Register<PlayerTeleportStateNotify>(ENotifyMessageId.PlayerTeleportStateNotify, new Action<PlayerTeleportStateNotify, Net.CallbackStatus>(this.PlayerTeleportStateNotify));
		Singleton<Net>.Instance.Register<ApplyerEnterSceneNotify>(ENotifyMessageId.ApplyerEnterSceneNotify, new Action<ApplyerEnterSceneNotify, Net.CallbackStatus>(this.ApplyerEnterSceneNotify));
		Singleton<Net>.Instance.Register<PlayerPsnSessionNotify>(ENotifyMessageId.PlayerPsnSessionNotify, new Action<PlayerPsnSessionNotify, Net.CallbackStatus>(this.PlayerPsnSessionNotify));
		Singleton<Net>.Instance.Register<SyncPlayerLocationNotify>(ENotifyMessageId.SyncPlayerLocationNotify, new Action<SyncPlayerLocationNotify, Net.CallbackStatus>(this.SyncPlayerLocationNotify));
		Singleton<Net>.Instance.Register<ClientVersionNoMatchNotify>(ENotifyMessageId.ClientVersionNoMatchNotify, new Action<ClientVersionNoMatchNotify, Net.CallbackStatus>(this.ClientVersionNoMatchNotify));
		Singleton<Net>.Instance.Register<PlayerGravityUpdateNotify>(ENotifyMessageId.PlayerGravityUpdateNotify, new Action<PlayerGravityUpdateNotify, Net.CallbackStatus>(this.PlayerGravityUpdateNotify));
		Singleton<Net>.Instance.Register<TeamTeleportStartNotify>(ENotifyMessageId.TeamTeleportStartNotify, new Action<TeamTeleportStartNotify, Net.CallbackStatus>(this.OnTeamTeleportStartNotify));
	}

	// Token: 0x06011296 RID: 70294 RVA: 0x004B67B8 File Offset: 0x004B49B8
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ApplyJoinWorldNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AgreeJoinResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerLeaveWorldTeamNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.JoinWorldTeamNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AllApplyJoinNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerEnterWorldTeamNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WorldTeamPlayerInfoChangeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ReceiveRechallengeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InviteRechallengeNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ReceiveRechallengePlayerIdsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerNetStateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MatchChangePlayerUiStateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerTeleportStateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ApplyerEnterSceneNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SyncPlayerLocationNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ClientVersionNoMatchNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerGravityUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeamTeleportStartNotify);
	}

	// Token: 0x06011297 RID: 70295 RVA: 0x004B68E8 File Offset: 0x004B4AE8
	private void WorldDone()
	{
		ModelBase<OnlineModel>.Instance.SetPermissionsSetting((WorldEnterPermission)ModelBase<FunctionModel>.Instance.GetWorldPermission().GetValueOrDefault());
		this.RefreshWorldPermissionSetting();
		ModelBase<OnlineModel>.Instance.ClearOtherScenePlayerDataList();
	}

	// Token: 0x06011298 RID: 70296 RVA: 0x004B6924 File Offset: 0x004B4B24
	private void RefreshWorldPermissionSetting()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.Multiplayer))
		{
			ControllerBase<OnlineController>.Instance.WorldEnterPermissionsRequest(WorldEnterPermission.ForbidJoin);
			Singleton<Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.YZY, "通信受限，禁止加入联机", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			ControllerBase<OnlineController>.Instance.WorldEnterPermissionsRequest(WorldEnterPermission.ForbidJoin);
			Singleton<Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.YZY, "ugcPrivilege受限，禁止加入联机", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				ControllerBase<OnlineController>.Instance.WorldEnterPermissionsRequest(WorldEnterPermission.ForbidJoin);
				Singleton<Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.YZY, "通信受限，禁止加入联机", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		});
	}

	// Token: 0x06011299 RID: 70297 RVA: 0x004B69D0 File Offset: 0x004B4BD0
	private void WorldDoneAndCloseLoading()
	{
		string thirdGameAutoLoginId = ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId;
		if (thirdGameAutoLoginId != "-1")
		{
			this.TryApplyJoinWorldRequest(thirdGameAutoLoginId).ContinueWith(delegate()
			{
				ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = "-1";
			}).Forget();
		}
		if (this.NoMatchType != null)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.GetConfirmBoxIdByNoMatchType());
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			this.NoMatchType = null;
		}
		if (this.SingleOnlineTipsHandle)
		{
			this.ShowOnlineModeTips();
			this.SingleOnlineTipsHandle = false;
		}
		this.RefreshSingleConfirm();
	}

	// Token: 0x0601129A RID: 70298 RVA: 0x004B6A71 File Offset: 0x004B4C71
	private EConfirmBoxConfigId GetConfirmBoxIdByNoMatchType()
	{
		if (this.NoMatchType.GetValueOrDefault() == TeamType.MatchTeam)
		{
			return EConfirmBoxConfigId.ClientVersionNoMatchTeam;
		}
		return EConfirmBoxConfigId.ClientVersionNoMatchOnline;
	}

	// Token: 0x0601129B RID: 70299 RVA: 0x004B6A8C File Offset: 0x004B4C8C
	private void OnCloseLoadingView()
	{
		if (Singleton<PlatformSdkManagerNew>.Instance.IsSdkOn && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			if (this.NotifyPlayStationPremiumTimer != null)
			{
				this.NotifyPlayStationPremiumTimer.Remove();
				this.NotifyPlayStationPremiumTimer = null;
			}
			this.NotifyPlayStationPremiumTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.NotifyPlayStationPremium();
			}, this.NOTIFY_PLAYSTATION_CD, 1f, null, null, true);
		}
	}

	// Token: 0x0601129C RID: 70300 RVA: 0x004B6AF8 File Offset: 0x004B4CF8
	private void ScenePlayerLeaveScene(int playerId)
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return;
		}
		ModelBase<OnlineModel>.Instance.SetContinuingChallengeConfirmState(playerId, EContinuingChallenge.Leave);
		ModelBase<OnlineModel>.Instance.SetAllowInitiate(false);
		Singleton<EventSystem>.Instance.Emit<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, playerId, EContinuingChallenge.Leave);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineChallengePlayer);
		if (ModelBase<InstanceDungeonModel>.Instance.InstanceFinishSuccess != EInstanceFinishState.Success)
		{
			this.HandleTips = "OnlineSomeOneLeaveInstance";
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("OnlineSomeOneLeaveInstance", Array.Empty<object>());
	}

	// Token: 0x0601129D RID: 70301 RVA: 0x004B6B78 File Offset: 0x004B4D78
	private void OnCloseLoading()
	{
		if (this.TipsCache == null)
		{
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById(this.TipsCache[0].Value.Item1, this.TipsCache[0].Value.Item2);
		this.TipsCache = null;
	}

	// Token: 0x0601129E RID: 70302 RVA: 0x004B6BCB File Offset: 0x004B4DCB
	private void OnSetGameModeDataDone()
	{
		if (this.IsFirstSetMode)
		{
			this.IsFirstSetMode = false;
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<OnlineController>.Instance.CheckPlatformCanopen();
			}
		}
	}

	// Token: 0x0601129F RID: 70303 RVA: 0x004B6BF3 File Offset: 0x004B4DF3
	private void OnInputAnyKey(bool bPress, FKey key)
	{
		ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = "-1";
		Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
	}

	// Token: 0x060112A0 RID: 70304 RVA: 0x004B6C20 File Offset: 0x004B4E20
	[NullableContext(0)]
	public UniTask<bool> RefreshWorldList()
	{
		OnlineController.<RefreshWorldList>d__36 <RefreshWorldList>d__;
		<RefreshWorldList>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RefreshWorldList>d__.<>4__this = this;
		<RefreshWorldList>d__.<>1__state = -1;
		<RefreshWorldList>d__.<>t__builder.Start<OnlineController.<RefreshWorldList>d__36>(ref <RefreshWorldList>d__);
		return <RefreshWorldList>d__.<>t__builder.Task;
	}

	// Token: 0x060112A1 RID: 70305 RVA: 0x004B6C64 File Offset: 0x004B4E64
	protected override void OnTick(float delta)
	{
		if (!ModelBase<GameModeModel>.Instance.WorldDone || !ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		float? lastPingPush = this.LastPingPush;
		float? pingPushInterval = this.PingPushInterval;
		if (lastPingPush.GetValueOrDefault() > pingPushInterval.GetValueOrDefault() & (lastPingPush != null & pingPushInterval != null))
		{
			this.LastPingPush -= this.PingPushInterval.Value;
			this.PlayerNetStatePush();
		}
		this.LastPingPush += delta;
	}

	// Token: 0x060112A2 RID: 70306 RVA: 0x004B6D2C File Offset: 0x004B4F2C
	[NullableContext(0)]
	public UniTask<bool> LobbyListRequest(bool isFriend)
	{
		OnlineController.<LobbyListRequest>d__38 <LobbyListRequest>d__;
		<LobbyListRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LobbyListRequest>d__.<>4__this = this;
		<LobbyListRequest>d__.isFriend = isFriend;
		<LobbyListRequest>d__.<>1__state = -1;
		<LobbyListRequest>d__.<>t__builder.Start<OnlineController.<LobbyListRequest>d__38>(ref <LobbyListRequest>d__);
		return <LobbyListRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060112A3 RID: 70307 RVA: 0x004B6D78 File Offset: 0x004B4F78
	private UniTask OnLobbyListRequest(LobbyListResponse response, bool isFriend)
	{
		OnlineController.<OnLobbyListRequest>d__39 <OnLobbyListRequest>d__;
		<OnLobbyListRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnLobbyListRequest>d__.response = response;
		<OnLobbyListRequest>d__.isFriend = isFriend;
		<OnLobbyListRequest>d__.<>1__state = -1;
		<OnLobbyListRequest>d__.<>t__builder.Start<OnlineController.<OnLobbyListRequest>d__39>(ref <OnLobbyListRequest>d__);
		return <OnLobbyListRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060112A4 RID: 70308 RVA: 0x004B6DC4 File Offset: 0x004B4FC4
	public void WorldEnterPermissionsRequest(WorldEnterPermission type)
	{
		WorldEnterPermissionsRequest worldEnterPermissionsRequest = Aki.Protocol.WorldEnterPermissionsRequest.Create();
		worldEnterPermissionsRequest.Type = type;
		Singleton<Net>.Instance.Call<WorldEnterPermissionsResponse>(ERequestMessageId.WorldEnterPermissionsRequest, worldEnterPermissionsRequest, delegate(WorldEnterPermissionsResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24761, null, true, true);
				return;
			}
			ModelBase<OnlineModel>.Instance.SetPermissionsSetting(response.Type);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshPermissionsSetting);
		}, 0);
	}

	// Token: 0x060112A5 RID: 70309 RVA: 0x004B6E10 File Offset: 0x004B5010
	public void ApplyJoinWorldRequest(int worldId, WorldEnterWay entryWay)
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti && !ControllerBase<OnlineController>.Instance.CheckPlatformCanopen())
		{
			return;
		}
		if (!ModelBase<SubPackageDownLoadModel>.Instance.CheckOnlineHaveSubPackage())
		{
			return;
		}
		ApplyJoinWorldRequest applyJoinWorldRequest = Aki.Protocol.ApplyJoinWorldRequest.Create();
		applyJoinWorldRequest.PlayerId = worldId;
		applyJoinWorldRequest.Ways = entryWay;
		Singleton<Net>.Instance.Call<ApplyJoinWorldResponse>(ERequestMessageId.ApplyJoinWorldRequest, applyJoinWorldRequest, delegate(ApplyJoinWorldResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28357, response.ErrorParams.ToArray<string>(), true, true);
			}
		}, 0);
	}

	// Token: 0x060112A6 RID: 70310 RVA: 0x004B6E88 File Offset: 0x004B5088
	private bool CheckTowerViewIfOpen()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CycleTowerView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CycleTowerChallengeView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CycleTowerTeamView) || (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SingleTimeTowerView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SingleTimeTowerChallengeView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SingleTimeTowerTeamView));
	}

	// Token: 0x060112A7 RID: 70311 RVA: 0x004B6F00 File Offset: 0x004B5100
	public void ApplyJoinWorldNotify(ApplyJoinWorldNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnApplyJoinNotify(message).Forget();
	}

	// Token: 0x060112A8 RID: 70312 RVA: 0x004B6F10 File Offset: 0x004B5110
	private UniTask OnApplyJoinNotify(ApplyJoinWorldNotify message)
	{
		OnlineController.<OnApplyJoinNotify>d__44 <OnApplyJoinNotify>d__;
		<OnApplyJoinNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnApplyJoinNotify>d__.<>4__this = this;
		<OnApplyJoinNotify>d__.message = message;
		<OnApplyJoinNotify>d__.<>1__state = -1;
		<OnApplyJoinNotify>d__.<>t__builder.Start<OnlineController.<OnApplyJoinNotify>d__44>(ref <OnApplyJoinNotify>d__);
		return <OnApplyJoinNotify>d__.<>t__builder.Task;
	}

	// Token: 0x060112A9 RID: 70313 RVA: 0x004B6F5C File Offset: 0x004B515C
	public void AgreeJoinResultNotify(AgreeJoinResultNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		if (message.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ApplyRefused", new object[]
			{
				message.PlayerName
			});
			return;
		}
		this.TipsCache = new ValueTuple<string, object[]>?[1];
		this.TipsCache[0] = new ValueTuple<string, object[]>?(new ValueTuple<string, object[]>("EnteringOtherWorld", new object[]
		{
			message.PlayerName
		}));
	}

	// Token: 0x060112AA RID: 70314 RVA: 0x004B6FC6 File Offset: 0x004B51C6
	public void AllApplyJoinNotify(AllApplyJoinNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnAllApplyJoinNotify(message).Forget();
	}

	// Token: 0x060112AB RID: 70315 RVA: 0x004B6FD4 File Offset: 0x004B51D4
	public UniTask OnAllApplyJoinNotify(AllApplyJoinNotify message)
	{
		OnlineController.<OnAllApplyJoinNotify>d__47 <OnAllApplyJoinNotify>d__;
		<OnAllApplyJoinNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnAllApplyJoinNotify>d__.message = message;
		<OnAllApplyJoinNotify>d__.<>1__state = -1;
		<OnAllApplyJoinNotify>d__.<>t__builder.Start<OnlineController.<OnAllApplyJoinNotify>d__47>(ref <OnAllApplyJoinNotify>d__);
		return <OnAllApplyJoinNotify>d__.<>t__builder.Task;
	}

	// Token: 0x060112AC RID: 70316 RVA: 0x004B7018 File Offset: 0x004B5218
	public void LobbyQueryPlayersRequest(int playerId)
	{
		LobbyQueryPlayersRequest lobbyQueryPlayersRequest = Aki.Protocol.LobbyQueryPlayersRequest.Create();
		lobbyQueryPlayersRequest.PlayerId = playerId;
		Singleton<Net>.Instance.Call<LobbyQueryPlayersResponse>(ERequestMessageId.LobbyQueryPlayersRequest, lobbyQueryPlayersRequest, delegate(LobbyQueryPlayersResponse response, Net.CallbackStatus _)
		{
			this.OnQueryPlayersResponse(response, playerId).Forget();
		}, 0);
	}

	// Token: 0x060112AD RID: 70317 RVA: 0x004B7068 File Offset: 0x004B5268
	private UniTask OnQueryPlayersResponse(LobbyQueryPlayersResponse response, int playerId)
	{
		OnlineController.<OnQueryPlayersResponse>d__49 <OnQueryPlayersResponse>d__;
		<OnQueryPlayersResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnQueryPlayersResponse>d__.response = response;
		<OnQueryPlayersResponse>d__.playerId = playerId;
		<OnQueryPlayersResponse>d__.<>1__state = -1;
		<OnQueryPlayersResponse>d__.<>t__builder.Start<OnlineController.<OnQueryPlayersResponse>d__49>(ref <OnQueryPlayersResponse>d__);
		return <OnQueryPlayersResponse>d__.<>t__builder.Task;
	}

	// Token: 0x060112AE RID: 70318 RVA: 0x004B70B4 File Offset: 0x004B52B4
	public void AgreeJoinResultRequest(int applyPlayerId, bool result)
	{
		if (result && !ModelBase<GameModeModel>.Instance.IsMulti && !ControllerBase<OnlineController>.Instance.CheckPlatformCanopen())
		{
			return;
		}
		if (!ModelBase<SubPackageDownLoadModel>.Instance.CheckOnlineHaveSubPackage())
		{
			return;
		}
		AgreeJoinResultRequest agreeJoinResultRequest = Aki.Protocol.AgreeJoinResultRequest.Create();
		agreeJoinResultRequest.PlayerId = applyPlayerId;
		agreeJoinResultRequest.Result = result;
		Singleton<Net>.Instance.Call<AgreeJoinResultResponse>(ERequestMessageId.AgreeJoinResultRequest, agreeJoinResultRequest, delegate(AgreeJoinResultResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27568, null, true, true);
				return;
			}
			ModelBase<OnlineModel>.Instance.DeleteCurrentApplyListById(applyPlayerId);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshApply);
		}, 0);
	}

	// Token: 0x060112AF RID: 70319 RVA: 0x004B7130 File Offset: 0x004B5330
	public void MatchChangePlayerUiStateRequest(EMatchPlayerUiState matchUiState)
	{
		MatchChangePlayerUiStateRequest matchChangePlayerUiStateRequest = Aki.Protocol.MatchChangePlayerUiStateRequest.Create();
		matchChangePlayerUiStateRequest.MatchUiState = matchUiState;
		Singleton<Net>.Instance.Call<MatchChangePlayerUiStateResponse>(ERequestMessageId.MatchChangePlayerUiStateRequest, matchChangePlayerUiStateRequest, delegate(MatchChangePlayerUiStateResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27568, null, true, true);
				return;
			}
			int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			ModelBase<InstanceDungeonModel>.Instance.SetPlayerUiState(value, matchUiState);
		}, 0);
	}

	// Token: 0x060112B0 RID: 70320 RVA: 0x004B7179 File Offset: 0x004B5379
	public void JoinWorldTeamNotify(JoinWorldTeamNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnJoinWorldTeamNotify(message).Forget();
	}

	// Token: 0x060112B1 RID: 70321 RVA: 0x004B7188 File Offset: 0x004B5388
	private UniTask OnJoinWorldTeamNotify(JoinWorldTeamNotify message)
	{
		OnlineController.<OnJoinWorldTeamNotify>d__53 <OnJoinWorldTeamNotify>d__;
		<OnJoinWorldTeamNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnJoinWorldTeamNotify>d__.<>4__this = this;
		<OnJoinWorldTeamNotify>d__.message = message;
		<OnJoinWorldTeamNotify>d__.<>1__state = -1;
		<OnJoinWorldTeamNotify>d__.<>t__builder.Start<OnlineController.<OnJoinWorldTeamNotify>d__53>(ref <OnJoinWorldTeamNotify>d__);
		return <OnJoinWorldTeamNotify>d__.<>t__builder.Task;
	}

	// Token: 0x060112B2 RID: 70322 RVA: 0x004B71D4 File Offset: 0x004B53D4
	public void PlayerLeaveWorldTeamNotify(PlayerLeaveWorldTeamNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int playerId = message.PlayerId;
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
		if (currentTeamListById.IsSelf)
		{
			if (!ModelBase<GameModeModel>.Instance.WorldDone)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "离开队伍时世界未加载完成", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ShowBackLoginConfirmBox();
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineWorldHallView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineWorldHallView, null);
			}
			if (playerId != ModelBase<OnlineModel>.Instance.OwnerId)
			{
				if (message.Reason == WorldTeamLeaveReason.Dissolve)
				{
					this.TipsCache = new ValueTuple<string, object[]>?[1];
					this.TipsCache[0] = new ValueTuple<string, object[]>?(new ValueTuple<string, object[]>("LeaderExitOnlineTeam", new object[]
					{
						currentTeamListById.Name
					}));
				}
				else
				{
					this.TipsCache = new ValueTuple<string, object[]>?[1];
					this.TipsCache[0] = new ValueTuple<string, object[]>?(new ValueTuple<string, object[]>("OnlineSimulationPassiveExit", new object[0]));
				}
			}
			ModelBase<OnlineModel>.Instance.SetTeamOwnerId(-1);
			ModelBase<OnlineModel>.Instance.ClearOnlineTeamMap();
			ModelBase<OnlineModel>.Instance.ClearPlayerTeleportState();
			ModelBase<OnlineModel>.Instance.ClearWorldTeamPlayerFightInfo();
			ModelBase<OnlineModel>.Instance.ClearOtherScenePlayerDataList();
			this.HaveSingleConfirm = false;
			this.ClearOnlineTipsTimer();
			this.ClearOnlineConfirmTimer();
			this.LeavePlayerSession();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnLeaveOnlineWorld);
		}
		else
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ExitOnlineTeam", new object[]
			{
				currentTeamListById.Name
			});
			ModelBase<OnlineModel>.Instance.ResetTeamDataPlayer(currentTeamListById.PlayerNumber);
			ModelBase<OnlineModel>.Instance.DeleteCurrentTeamListById(playerId);
			ModelBase<OnlineModel>.Instance.DeleteWorldTeamPlayerFightInfo(playerId);
			ModelBase<OnlineModel>.Instance.DeleteOtherScenePlayerDataList(playerId);
			ModelBase<OnlineModel>.Instance.DeletePlayerTeleportState(playerId);
		}
		this.RefreshSingleConfirm();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineTeamList);
	}

	// Token: 0x060112B3 RID: 70323 RVA: 0x004B7397 File Offset: 0x004B5597
	public void PlayerEnterWorldTeamNotify(PlayerEnterWorldTeamNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnPlayerEnterWorldTeamNotify(message).Forget();
	}

	// Token: 0x060112B4 RID: 70324 RVA: 0x004B73A8 File Offset: 0x004B55A8
	private UniTask OnPlayerEnterWorldTeamNotify(PlayerEnterWorldTeamNotify message)
	{
		OnlineController.<OnPlayerEnterWorldTeamNotify>d__56 <OnPlayerEnterWorldTeamNotify>d__;
		<OnPlayerEnterWorldTeamNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayerEnterWorldTeamNotify>d__.message = message;
		<OnPlayerEnterWorldTeamNotify>d__.<>1__state = -1;
		<OnPlayerEnterWorldTeamNotify>d__.<>t__builder.Start<OnlineController.<OnPlayerEnterWorldTeamNotify>d__56>(ref <OnPlayerEnterWorldTeamNotify>d__);
		return <OnPlayerEnterWorldTeamNotify>d__.<>t__builder.Task;
	}

	// Token: 0x060112B5 RID: 70325 RVA: 0x004B73EC File Offset: 0x004B55EC
	public void WorldTeamPlayerInfoChangeNotify(WorldTeamPlayerInfoChangeNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(message.PlayerId);
		if (currentTeamListById == null)
		{
			return;
		}
		switch (message.ChangeType)
		{
		case WorldTeamPlayerChangeType.Name:
			currentTeamListById.Name = message.StringValue;
			break;
		case WorldTeamPlayerChangeType.Head:
			currentTeamListById.HeadId = message.IntValue;
			break;
		case WorldTeamPlayerChangeType.Level:
			currentTeamListById.Level = message.IntValue;
			break;
		case WorldTeamPlayerChangeType.Signature:
			currentTeamListById.Signature = message.StringValue;
			break;
		case WorldTeamPlayerChangeType.PlayerTitle:
			currentTeamListById.SetPlayerTitleInfo(message.StringValue);
			break;
		case WorldTeamPlayerChangeType.Sex:
			currentTeamListById.Sex = message.IntValue;
			break;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineTeamList);
		Singleton<EventSystem>.Instance.Emit<WorldTeamPlayerInfoChangeNotify>(EEventName.OnWorldTeamPlayerInfoChanged, message);
	}

	// Token: 0x060112B6 RID: 70326 RVA: 0x004B74A8 File Offset: 0x004B56A8
	public void ReceiveRechallengeNotify(ReceiveRechallengeNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int playerId = message.PlayerId;
		if (message.Result != ERechallengeResultResult.Accept)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineChallengeStateView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineChallengeStateView, null);
			}
			int num = playerId;
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			int? num2 = (instance != null) ? instance.GetId() : null;
			if (!(num == num2.GetValueOrDefault() & num2 != null))
			{
				string name = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId).Name;
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RefuseInviteMatch", new object[]
				{
					name
				});
			}
			return;
		}
		ModelBase<OnlineModel>.Instance.SetContinuingChallengeConfirmState(playerId, EContinuingChallenge.Accept);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineChallengePlayer);
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (playerId == ModelBase<OnlineModel>.Instance.OwnerId)
		{
			EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(id.Value);
			EContinuingChallenge econtinuingChallenge = EContinuingChallenge.Accept;
			if (continuingChallengeConfirmState.GetValueOrDefault() == econtinuingChallenge & continuingChallengeConfirmState != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineChallengeStateView, null, null);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, playerId, EContinuingChallenge.Accept);
	}

	// Token: 0x060112B7 RID: 70327 RVA: 0x004B75C4 File Offset: 0x004B57C4
	public void InviteRechallengeNotify(InviteRechallengeNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineChallengePlayer);
		EContinuingChallenge? econtinuingChallenge = continuingChallengeConfirmState;
		EContinuingChallenge econtinuingChallenge2 = EContinuingChallenge.Accept;
		if ((econtinuingChallenge.GetValueOrDefault() == econtinuingChallenge2 & econtinuingChallenge != null) && ModelBase<OnlineModel>.Instance.GetIsMyTeam())
		{
			return;
		}
		ModelBase<OnlineModel>.Instance.SetChallengeApplyPlayerId(message.InviterPlayerId);
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineChallengeStateView))
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineChallengeApplyView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineChallengeApplyView, null, null);
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshSuggestChallengePlayerInfo);
		}
	}

	// Token: 0x060112B8 RID: 70328 RVA: 0x004B7678 File Offset: 0x004B5878
	public void ReceiveRechallengePlayerIdsNotify(ReceiveRechallengePlayerIdsNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<OnlineModel>.Instance.ResetContinuingChallengeConfirmState();
		foreach (int playerId in message.PlayerIds)
		{
			ModelBase<OnlineModel>.Instance.SetContinuingChallengeConfirmState(playerId, EContinuingChallenge.Accept);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineChallengePlayer);
		}
	}

	// Token: 0x060112B9 RID: 70329 RVA: 0x004B76E4 File Offset: 0x004B58E4
	public void PlayerNetStateNotify(PlayerNetStateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(message.PlayerId);
		if (currentTeamListById == null)
		{
			return;
		}
		currentTeamListById.PingState = message.PingState;
		Singleton<EventSystem>.Instance.Emit<int, ENetPingState>(EEventName.OnRefreshPlayerPing, message.PlayerId, currentTeamListById.PingState);
	}

	// Token: 0x060112BA RID: 70330 RVA: 0x004B7730 File Offset: 0x004B5930
	public bool CheckPlayerNetHealthy(int playerId)
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (id.GetValueOrDefault() == playerId & id != null)
		{
			ENetPingState netPingState = this.GetNetPingState(Singleton<Net>.Instance.RttMs);
			return this.IsNetStateGood(netPingState);
		}
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
		return currentTeamListById != null && this.IsNetStateGood(currentTeamListById.PingState);
	}

	// Token: 0x060112BB RID: 70331 RVA: 0x004B7794 File Offset: 0x004B5994
	public bool IsNetStateGood(ENetPingState pingState)
	{
		return pingState == ENetPingState.Great || pingState == ENetPingState.Good;
	}

	// Token: 0x060112BC RID: 70332 RVA: 0x004B77A0 File Offset: 0x004B59A0
	public void MatchChangePlayerUiStateNotify(MatchChangePlayerUiStateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<InstanceDungeonModel>.Instance.SetPlayerUiState(message.PlayerId, message.MatchUiState);
	}

	// Token: 0x060112BD RID: 70333 RVA: 0x004B77B8 File Offset: 0x004B59B8
	public void PlayerTeleportStateNotify(PlayerTeleportStateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int playerId = message.PlayerId;
		ModelBase<OnlineModel>.Instance.SetPlayerTeleportState(playerId, message.TeleportState);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRefreshPlayerUiState, playerId);
		int num = playerId;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (num == id.GetValueOrDefault() & id != null)
		{
			return;
		}
		bool flag = message.TeleportState == EPlayerTeleportState.Default;
		ModelBase<OnlineModel>.Instance.SetRoleActivated(playerId, flag);
		if (flag)
		{
			if (message.CurRolePosInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiPlayerTeam;
				ELogAuthor author = ELogAuthor.WCL;
				string message2 = "队友传送完成通知缺失位置信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerId", playerId);
				instance.Error(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToBigInt(message.CurRolePosInfo.EntityId));
			if (entity != null && entity.Entity != null)
			{
				if (entity.IsInit)
				{
					CharacterActorComponent component = entity.Entity.GetComponent<CharacterActorComponent>();
					global::Vector vector = global::Vector.Create((double)message.CurRolePosInfo.Location.X, (double)message.CurRolePosInfo.Location.Y, (double)message.CurRolePosInfo.Location.Z);
					if (!component.FixBornLocation("队友传送完成", true, vector, true, false, true))
					{
						component.TeleportTo(vector.ToUeVector(false), component.ActorRotationProxy.ToUeRotator(), "队友传送完成(地面修正失败)");
					}
				}
				CharacterMovementSyncComponent component2 = entity.Entity.GetComponent<CharacterMovementSyncComponent>();
				if (component2 == null)
				{
					return;
				}
				component2.ClearReplaySamples();
			}
		}
	}

	// Token: 0x060112BE RID: 70334 RVA: 0x004B7930 File Offset: 0x004B5B30
	public void ApplyerEnterSceneNotify(ApplyerEnterSceneNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(message.ErrorCode);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new string[]
		{
			textByErrorId
		}, null, null, null, null, null, false, null);
	}

	// Token: 0x060112BF RID: 70335 RVA: 0x004B797D File Offset: 0x004B5B7D
	public void PlayerPsnSessionNotify(PlayerPsnSessionNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<OnlineModel>.Instance.GetIsMyTeam())
		{
			this.JoinPlayerSession(message.PsnSessionId);
		}
	}

	// Token: 0x060112C0 RID: 70336 RVA: 0x004B79A4 File Offset: 0x004B5BA4
	public void SyncPlayerLocationNotify(SyncPlayerLocationNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (PlayerLocation playerLocation in message.LocationList)
		{
			OtherScenePlayerData otherScenePlayerData = ModelBase<OnlineModel>.Instance.GetOtherScenePlayerDataByPlayerId(playerLocation.PlayerId);
			if (otherScenePlayerData == null)
			{
				otherScenePlayerData = new OtherScenePlayerData(playerLocation.PlayerId, playerLocation.MapId, playerLocation.Location, playerLocation.AreaId);
				ModelBase<OnlineModel>.Instance.PushOtherScenePlayerDataList(otherScenePlayerData);
			}
			global::Vector vector = global::Vector.Create(playerLocation.Location);
			otherScenePlayerData.SetLocation(vector);
			otherScenePlayerData.MapId = playerLocation.MapId;
			otherScenePlayerData.Area = playerLocation.AreaId;
			Singleton<EventSystem>.Instance.Emit<int, global::Vector>(EEventName.ScenePlayerLocationChanged, playerLocation.PlayerId, vector);
		}
	}

	// Token: 0x060112C1 RID: 70337 RVA: 0x004B7A70 File Offset: 0x004B5C70
	public void ClientVersionNoMatchNotify(ClientVersionNoMatchNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		TeamType? noMatchType = this.NoMatchType;
		TeamType teamType = TeamType.WorldTeam;
		if (!(noMatchType.GetValueOrDefault() == teamType & noMatchType != null))
		{
			this.NoMatchType = new TeamType?(message.TeamType);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.MultiPlayerTeam;
		ELogAuthor author = ELogAuthor.CX;
		string message2 = "客户端版本不匹配";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Proto_ClientVersionNoMatchNotify", message);
		instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060112C2 RID: 70338 RVA: 0x004B7AD4 File Offset: 0x004B5CD4
	public void PlayerGravityUpdateNotify(PlayerGravityUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.MultiPlayerTeam;
		ELogAuthor author = ELogAuthor.LJQ;
		string message2 = "PlayerGravityUpdateNotify";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("message.Proto_CurGravityDirection", message.CurGravityDirection);
		instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<OnlineModel>.Instance.SetPlayerGravityIsNormal(message.CurGravityDirection);
	}

	// Token: 0x060112C3 RID: 70339 RVA: 0x004B7B1C File Offset: 0x004B5D1C
	private void OnTeamTeleportStartNotify(TeamTeleportStartNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
		int? num = (instance != null) ? instance.GetId() : null;
		int playerId = message.PlayerId;
		if (!(num.GetValueOrDefault() == playerId & num != null))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.TeamTeleportCountDown, null, null, null, null, null, null, null, new int?(message.TimeoutSec), false, null);
		}
	}

	// Token: 0x060112C4 RID: 70340 RVA: 0x004B7B88 File Offset: 0x004B5D88
	public void ApplyRechallengeRequest(ApplyRechallengeReason reson)
	{
		ModelBase<OnlineModel>.Instance.RefreshInitiateTime();
		ApplyRechallengeRequest applyRechallengeRequest = Aki.Protocol.ApplyRechallengeRequest.Create();
		applyRechallengeRequest.Reason = reson;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshOnlineChallengePlayer);
		Singleton<Net>.Instance.Call<ApplyRechallengeResponse>(ERequestMessageId.ApplyRechallengeRequest, applyRechallengeRequest, delegate(ApplyRechallengeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19903, null, true, true);
			}
			if (!ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveSuggest", Array.Empty<object>());
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveInvite", Array.Empty<object>());
		}, 0);
	}

	// Token: 0x060112C5 RID: 70341 RVA: 0x004B7BEC File Offset: 0x004B5DEC
	public void ReceiveRechallengeRequest(bool isAccept, bool isClickCancel)
	{
		ReceiveRechallengeRequest receiveRechallengeRequest = Aki.Protocol.ReceiveRechallengeRequest.Create();
		if (isAccept)
		{
			receiveRechallengeRequest.Result = ERechallengeResultResult.Accept;
		}
		else if (isClickCancel)
		{
			receiveRechallengeRequest.Result = ERechallengeResultResult.ActiveRefuse;
		}
		else
		{
			receiveRechallengeRequest.Result = ERechallengeResultResult.TimeOutRefuse;
		}
		Singleton<Net>.Instance.Call<ReceiveRechallengeResponse>(ERequestMessageId.ReceiveRechallengeRequest, receiveRechallengeRequest, delegate(ReceiveRechallengeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26619, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060112C6 RID: 70342 RVA: 0x004B7C50 File Offset: 0x004B5E50
	public void InviteRechallengeRequest()
	{
		ModelBase<OnlineModel>.Instance.RefreshInitiateTime();
		InviteRechallengeRequest message = Aki.Protocol.InviteRechallengeRequest.Create();
		Singleton<Net>.Instance.Call<InviteRechallengeResponse>(ERequestMessageId.InviteRechallengeRequest, message, delegate(InviteRechallengeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20735, null, true, true);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineChallengeStateView, null, null);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineChallengeApplyView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineChallengeApplyView, null);
			}
		}, 0);
	}

	// Token: 0x060112C7 RID: 70343 RVA: 0x004B7CA0 File Offset: 0x004B5EA0
	public void LeaveWorldTeamRequest(int playerId, WorldTeamLeaveReason? reason = null)
	{
		LeaveWorldTeamRequest leaveWorldTeamRequest = Aki.Protocol.LeaveWorldTeamRequest.Create();
		leaveWorldTeamRequest.PlayerId = playerId;
		leaveWorldTeamRequest.Reason = reason.GetValueOrDefault();
		Singleton<Net>.Instance.Call<LeaveWorldTeamResponse>(ERequestMessageId.LeaveWorldTeamRequest, leaveWorldTeamRequest, delegate(LeaveWorldTeamResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28377, null, true, true);
				return;
			}
			ModelBase<OnlineModel>.Instance.ClearOnlineTeamMap();
		}, 0);
	}

	// Token: 0x060112C8 RID: 70344 RVA: 0x004B7CF8 File Offset: 0x004B5EF8
	public void KickWorldTeamRequest(int playerId)
	{
		KickWorldTeamRequest kickWorldTeamRequest = Aki.Protocol.KickWorldTeamRequest.Create();
		kickWorldTeamRequest.PlayerId = playerId;
		Singleton<Net>.Instance.Call<KickWorldTeamResponse>(ERequestMessageId.KickWorldTeamRequest, kickWorldTeamRequest, delegate(KickWorldTeamResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16243, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060112C9 RID: 70345 RVA: 0x004B7D44 File Offset: 0x004B5F44
	public void PlayerCreatePsnSessionRequest(string playerSessionId)
	{
		PlayerCreatePsnSessionRequest playerCreatePsnSessionRequest = Aki.Protocol.PlayerCreatePsnSessionRequest.Create();
		playerCreatePsnSessionRequest.PsnSessionId = playerSessionId;
		Singleton<Net>.Instance.Call<PlayerCreatePsnSessionResponse>(ERequestMessageId.PlayerCreatePsnSessionRequest, playerCreatePsnSessionRequest, delegate(PlayerCreatePsnSessionResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x060112CA RID: 70346 RVA: 0x004B7D90 File Offset: 0x004B5F90
	public void PlayerNetStatePush()
	{
		PlayerNetStatePush playerNetStatePush = Aki.Protocol.PlayerNetStatePush.Create();
		float rttMs = Singleton<Net>.Instance.RttMs;
		playerNetStatePush.RttMs = (int)rttMs;
		Singleton<Net>.Instance.Send(EPushMessageId.PlayerNetStatePush, playerNetStatePush);
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		ENetPingState netPingState = this.GetNetPingState(rttMs);
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(value);
		if (currentTeamListById != null && currentTeamListById.PingState != netPingState)
		{
			currentTeamListById.PingState = netPingState;
			Singleton<EventSystem>.Instance.Emit<int, ENetPingState>(EEventName.OnRefreshPlayerPing, value, netPingState);
		}
	}

	// Token: 0x060112CB RID: 70347 RVA: 0x004B7E18 File Offset: 0x004B6018
	public ENetPingState GetNetPingState(float rttMs)
	{
		if (rttMs < 0f)
		{
			return ENetPingState.Unknown;
		}
		float? num = this.NetGreatDefine;
		if (rttMs <= num.GetValueOrDefault() & num != null)
		{
			return ENetPingState.Great;
		}
		num = this.NetGoodDefine;
		if (rttMs <= num.GetValueOrDefault() & num != null)
		{
			return ENetPingState.Good;
		}
		num = this.NetWeaktDefine;
		if (rttMs <= num.GetValueOrDefault() & num != null)
		{
			return ENetPingState.Poor;
		}
		return ENetPingState.Unknown;
	}

	// Token: 0x060112CC RID: 70348 RVA: 0x004B7E90 File Offset: 0x004B6090
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.OnlineWorldHallView, new Func<EUiViewName, object, bool>(this.CanOpenView), "OnlineController.CanOpenView");
	}

	// Token: 0x060112CD RID: 70349 RVA: 0x004B7EB2 File Offset: 0x004B60B2
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.OnlineWorldHallView, new Func<EUiViewName, object, bool>(this.CanOpenView));
	}

	// Token: 0x060112CE RID: 70350 RVA: 0x004B7ED0 File Offset: 0x004B60D0
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.Multiplayer))
		{
			Singleton<Log>.Instance.Info(ELogModule.MultiPlayerTeam, ELogAuthor.YZY, "多人在线权限不足，拒绝申请", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OpenThirdPartyMessageBox(ESdkPrivilege.Multiplayer).Forget();
			return false;
		}
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.Communications))
		{
			Singleton<Log>.Instance.Info(ELogModule.MultiPlayerTeam, ELogAuthor.YZY, "通信受限，拒绝申请", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OpenThirdPartyMessageBox(ESdkPrivilege.Communications).Forget();
			return false;
		}
		if (ModelBase<SceneTeamModel>.Instance.IsPhantomTeam || ModelBase<SceneTeamModel>.Instance.HasPhantomRole())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterOnlineTip", Array.Empty<object>());
			return false;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<FunctionModel>.Instance.IsOpen(10021))
		{
			return false;
		}
		if (!ModelBase<GameModeModel>.Instance.IsMulti && ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("OnlineDisabledByInstance", Array.Empty<object>());
			return false;
		}
		return this.ShowTipsWhenOnlineDisabled(null);
	}

	// Token: 0x060112CF RID: 70351 RVA: 0x004B7FD4 File Offset: 0x004B61D4
	public bool CheckPlatformCanopen()
	{
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.Multiplayer))
		{
			Singleton<Log>.Instance.Info(ELogModule.MultiPlayerTeam, ELogAuthor.YZY, "多人在线权限不足，拒绝申请", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OpenThirdPartyMessageBox(ESdkPrivilege.Multiplayer).Forget();
			return false;
		}
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		int? num = (platformSdk != null) ? new int?(platformSdk.CheckUserPremium()) : null;
		if (num.GetValueOrDefault() == -1)
		{
			this.CheckoutCommerceDialogPremiumMode();
		}
		int? num2 = num;
		int num3 = 0;
		return num2.GetValueOrDefault() >= num3 & num2 != null;
	}

	// Token: 0x060112D0 RID: 70352 RVA: 0x004B8068 File Offset: 0x004B6268
	public bool ShowTipsWhenOnlineDisabled(EDisableOnlineType[] ignoreCheckList = null)
	{
		if (!ModelBase<OnlineModel>.Instance.IsOnlineDisabled())
		{
			return true;
		}
		IReadOnlyDictionary<DisableOnlineSource, EDisableOnlineType> onlineDisabledSource = ModelBase<OnlineModel>.Instance.GetOnlineDisabledSource();
		if (onlineDisabledSource == null)
		{
			return true;
		}
		Dictionary<DisableOnlineSource, EDisableOnlineType> dictionary = new Dictionary<DisableOnlineSource, EDisableOnlineType>();
		using (IEnumerator<KeyValuePair<DisableOnlineSource, EDisableOnlineType>> enumerator = onlineDisabledSource.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<DisableOnlineSource, EDisableOnlineType> kvp = enumerator.Current;
				if (ignoreCheckList == null || !Array.Exists<EDisableOnlineType>(ignoreCheckList, (EDisableOnlineType x) => x == kvp.Value))
				{
					dictionary.Add(kvp.Key, kvp.Value);
				}
			}
		}
		if (dictionary.Count == 0)
		{
			return true;
		}
		foreach (KeyValuePair<DisableOnlineSource, EDisableOnlineType> keyValuePair in onlineDisabledSource)
		{
			EDisableOnlineType value = keyValuePair.Value;
			if (value != EDisableOnlineType.NonOnlineQuest)
			{
				if (value != EDisableOnlineType.NonOnlinePlay)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById(OnlineDefine.onlineDisabledSourceTipsId[(int)keyValuePair.Value], Array.Empty<object>());
				}
				else
				{
					string name = ModelBase<LevelPlayModel>.Instance.GetProcessingLevelPlayInfo(keyValuePair.Key.TreeId).Name;
					if (OnlineController.CheckStringEmptyOrDnt(name))
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_OnlineDisabledByNonOnlinePlay_Fallback_Text", Array.Empty<object>());
					}
					else
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsById(OnlineDefine.onlineDisabledSourceTipsId[(int)keyValuePair.Value], new object[]
						{
							name
						});
					}
				}
			}
			else
			{
				string name2 = ModelBase<QuestNewModel>.Instance.GetQuest(keyValuePair.Key.TreeId).Name;
				if (OnlineController.CheckStringEmptyOrDnt(name2))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_OnlineDisabledByNonOnlineQuest_Fallback_Text", Array.Empty<object>());
				}
				else
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById(OnlineDefine.onlineDisabledSourceTipsId[(int)keyValuePair.Value], new object[]
					{
						name2
					});
				}
			}
		}
		return false;
	}

	// Token: 0x060112D1 RID: 70353 RVA: 0x004B826C File Offset: 0x004B646C
	private static bool CheckStringEmptyOrDnt(string stringContent)
	{
		return StringUtils.IsEmpty(stringContent) || stringContent.StartsWith("dnt/");
	}

	// Token: 0x060112D2 RID: 70354 RVA: 0x004B8288 File Offset: 0x004B6488
	private void ShowBackLoginConfirmBox()
	{
		ConfirmBoxDataNew confirmBoxDataNew;
		if (Singleton<Info>.Instance.IsXboxPlatform())
		{
			confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.XboxExitGame);
		}
		else
		{
			confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.LeaveMultiOnLoading);
		}
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			ControllerBase<KuroSdkController>.Instance.PostKuroSdkEvent(EKuroSdkEventKey.KUROSDKEXIT);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
	}

	// Token: 0x060112D3 RID: 70355 RVA: 0x004B82F4 File Offset: 0x004B64F4
	public string CreatePlayerSession()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		return ControllerBase<KuroSdkController>.Instance.CreatePlayerSession(id);
	}

	// Token: 0x060112D4 RID: 70356 RVA: 0x004B8317 File Offset: 0x004B6517
	public void LeavePlayerSession()
	{
		ControllerBase<KuroSdkController>.Instance.LeavePlayerSession();
		if (this.NotifyPlayStationPremiumTimer != null)
		{
			this.NotifyPlayStationPremiumTimer.Remove();
			this.NotifyPlayStationPremiumTimer = null;
		}
	}

	// Token: 0x060112D5 RID: 70357 RVA: 0x004B833E File Offset: 0x004B653E
	public void JoinPlayerSession(string playerSession)
	{
		ControllerBase<KuroSdkController>.Instance.JoinPlayerSession(playerSession);
	}

	// Token: 0x060112D6 RID: 70358 RVA: 0x004B834C File Offset: 0x004B654C
	public void CheckJoinSession()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		string thirdGameAutoLoginId = (platformSdk != null) ? platformSdk.CheckJoinSession() : null;
		ModelBase<LoginModel>.Instance.ThirdGameAutoLoginId = thirdGameAutoLoginId;
	}

	// Token: 0x060112D7 RID: 70359 RVA: 0x004B837B File Offset: 0x004B657B
	public void NotifyPlayStationPremium()
	{
		PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
		if (platformSdk == null)
		{
			return;
		}
		platformSdk.NotifyPlayStationPremium(ModelBase<KuroSdkModel>.Instance.PlayStationPlayOnlyState);
	}

	// Token: 0x060112D8 RID: 70360 RVA: 0x004B839B File Offset: 0x004B659B
	public string GetPlayerIdByPlayerSessionId(string playerSessionId)
	{
		return ControllerBase<KuroSdkController>.Instance.GetPlayerIdByPlayerSessionId(playerSessionId);
	}

	// Token: 0x060112D9 RID: 70361 RVA: 0x004B83A8 File Offset: 0x004B65A8
	public void CheckoutCommerceDialogPremiumMode()
	{
		this.CheckoutDialogTimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			ESdkDialogResult esdkDialogResult = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().PollCheckoutDialogResult();
			if (esdkDialogResult != ESdkDialogResult.Waiting)
			{
				if (esdkDialogResult == ESdkDialogResult.Yes)
				{
					TimerSystem.GameplayTimeInstance.Remove(this.CheckoutDialogTimerHandle);
					this.CheckoutDialogTimerHandle = null;
					return;
				}
				TimerSystem.GameplayTimeInstance.Remove(this.CheckoutDialogTimerHandle);
				this.CheckoutDialogTimerHandle = null;
			}
		}, 500f, 1f, null, null, true);
	}

	// Token: 0x060112DA RID: 70362 RVA: 0x004B83D4 File Offset: 0x004B65D4
	private void RefreshSingleConfirm()
	{
		if (this.HaveSingleConfirm)
		{
			return;
		}
		if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() != 1)
		{
			this.ClearOnlineConfirmTimer();
			return;
		}
		if (this.SingleConfirmTimer != null)
		{
			return;
		}
		this.SingleConfirmTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				this.StartShowOnlineModeTips();
				return;
			}
			if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() != 1)
			{
				this.ClearOnlineConfirmTimer();
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.OnlineSingleConfirm);
			confirmBoxDataNew.FunctionMap.Add(0, new Action(this.<RefreshSingleConfirm>g__stayWorldCallBack|99_1));
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
				this.LeaveWorldTeamRequest(valueOrDefault, null);
			});
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.<RefreshSingleConfirm>g__stayWorldCallBack|99_1));
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
			else
			{
				this.StartShowOnlineModeTips();
			}
			this.ClearOnlineConfirmTimer();
			this.HaveSingleConfirm = true;
		}, this.ONLINE_SING_LONG_TIME, null, "OnlineSingleConfirm", true, 1f);
	}

	// Token: 0x060112DB RID: 70363 RVA: 0x004B8435 File Offset: 0x004B6635
	private void StartShowOnlineModeTips()
	{
		this.ClearOnlineTipsTimer();
		this.SingleOnlineTipsTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.ShowOnlineModeTips();
		}, this.ONLINE_SING_TIPS_TIMER_INTERVAL, 1f, null, null, true);
	}

	// Token: 0x060112DC RID: 70364 RVA: 0x004B8468 File Offset: 0x004B6668
	private void ShowOnlineModeTips()
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.ClearOnlineTipsTimer();
			return;
		}
		if (ModelBase<OnlineModel>.Instance.GetCurrentTeamSize() != 1)
		{
			this.ShowTipsInterval = 0.0;
			return;
		}
		this.ShowTipsInterval += (double)this.ONLINE_SING_TIPS_TIMER_INTERVAL;
		if (this.ShowTipsInterval < (double)this.ONLINE_SING_TIPS_TIME)
		{
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			this.SingleOnlineTipsHandle = true;
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("OnlineSingleTips", Array.Empty<object>());
		this.ShowTipsInterval = 0.0;
	}

	// Token: 0x060112DD RID: 70365 RVA: 0x004B8500 File Offset: 0x004B6700
	private void ClearOnlineTipsTimer()
	{
		if (this.SingleOnlineTipsTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SingleOnlineTipsTimer);
		}
		this.SingleOnlineTipsTimer = null;
	}

	// Token: 0x060112DE RID: 70366 RVA: 0x004B8522 File Offset: 0x004B6722
	private void ClearOnlineConfirmTimer()
	{
		if (this.SingleConfirmTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.SingleConfirmTimer);
		}
		this.SingleConfirmTimer = null;
	}

	// Token: 0x060112DF RID: 70367 RVA: 0x004B8544 File Offset: 0x004B6744
	private void CsRequestJoinWorld(int worldId, int worldEnterWay)
	{
		this.ApplyJoinWorldRequest(worldId, (WorldEnterWay)worldEnterWay);
	}

	// Token: 0x060112E4 RID: 70372 RVA: 0x004B86E0 File Offset: 0x004B68E0
	[CompilerGenerated]
	private void <RefreshSingleConfirm>g__stayWorldCallBack|99_1()
	{
		this.StartShowOnlineModeTips();
	}

	// Token: 0x040086F8 RID: 34552
	private int LIST_REQUEST_CD = 5;

	// Token: 0x040086F9 RID: 34553
	private float NOTIFY_PLAYSTATION_CD = (float)Singleton<TimeUtil>.Instance.InverseMillisecond;

	// Token: 0x040086FA RID: 34554
	private float ONLINE_SING_LONG_TIME = (float)(300 * Singleton<TimeUtil>.Instance.InverseMillisecond);

	// Token: 0x040086FB RID: 34555
	private float ONLINE_SING_TIPS_TIME = (float)(1200 * Singleton<TimeUtil>.Instance.InverseMillisecond);

	// Token: 0x040086FC RID: 34556
	public float ONLINE_SING_TIPS_TIMER_INTERVAL = (float)(60 * Singleton<TimeUtil>.Instance.InverseMillisecond);

	// Token: 0x040086FD RID: 34557
	private double TargetRequestTimeStamp;

	// Token: 0x040086FE RID: 34558
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1,
		1
	})]
	private ValueTuple<string, object[]>?[] TipsCache;

	// Token: 0x040086FF RID: 34559
	private float? PingPushInterval;

	// Token: 0x04008700 RID: 34560
	private float? LastPingPush;

	// Token: 0x04008701 RID: 34561
	private float? NetGreatDefine;

	// Token: 0x04008702 RID: 34562
	private float? NetGoodDefine;

	// Token: 0x04008703 RID: 34563
	private float? NetWeaktDefine;

	// Token: 0x04008704 RID: 34564
	[Nullable(2)]
	private TimerHandle NotifyPlayStationPremiumTimer;

	// Token: 0x04008705 RID: 34565
	private TeamType? NoMatchType;

	// Token: 0x04008706 RID: 34566
	[Nullable(2)]
	private FJoinSessionCallBack JoinSessionDelegate;

	// Token: 0x04008707 RID: 34567
	[Nullable(2)]
	public string HandleTips;

	// Token: 0x04008708 RID: 34568
	public bool IsFirstSetMode;

	// Token: 0x04008709 RID: 34569
	[Nullable(2)]
	private TimerHandle CheckoutDialogTimerHandle;

	// Token: 0x0400870A RID: 34570
	[Nullable(2)]
	private TimerHandle SingleConfirmTimer;

	// Token: 0x0400870B RID: 34571
	[Nullable(2)]
	private TimerHandle SingleOnlineTipsTimer;

	// Token: 0x0400870C RID: 34572
	private bool SingleOnlineTipsHandle;

	// Token: 0x0400870D RID: 34573
	private bool HaveSingleConfirm;

	// Token: 0x0400870E RID: 34574
	private double ShowTipsInterval;
}
