using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform.PlatformSdk;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf;
using Google.Protobuf.Collections;

// Token: 0x02001838 RID: 6200
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ChatController : UiControllerBase<ChatController>
{
	// Token: 0x0600B0FD RID: 45309 RVA: 0x002F3D9D File Offset: 0x002F1F9D
	protected override bool OnClear()
	{
		if (this.DelayPrivateChatDataRequestTimer != null && TimerSystem.GameplayTimeInstance.Has(this.DelayPrivateChatDataRequestTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.DelayPrivateChatDataRequestTimer);
			this.DelayPrivateChatDataRequestTimer = null;
		}
		return true;
	}

	// Token: 0x0600B0FE RID: 45310 RVA: 0x002F3DD4 File Offset: 0x002F1FD4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSelectChatFriend, this.OnSelectChatFriend);
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, this.OnOpenView);
		Singleton<EventSystem>.Instance.Add(EEventName.OnEnterTeam, new Action(this.OnEnterTeam));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveTeam, new Action(this.OnLeaveTeam));
		Singleton<EventSystem>.Instance.Add(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveFriend, this.OnRemoveFriend);
		Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleByResetToBattleView, this.OnPlayerDead);
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetFriendInitData, new Action(this.OnGetFriendInitData));
		Singleton<EventSystem>.Instance.Add<WorldTeamPlayerInfoChangeNotify>(EEventName.OnWorldTeamPlayerInfoChanged, new Action<WorldTeamPlayerInfoChangeNotify>(this.OnWorldTeamPlayerInfoChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncChatEnterTeam, new Action(this.OnEnterTeam));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncChatLeaveTeam, new Action(this.OnLeaveTeam));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncChatEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Add(EEventName.TsSyncChatLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Add<double, double, double, double>(EEventName.TsSyncTime, new Action<double, double, double, double>(this.OnTsSyncTime));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.TsSyncAddMutePlayer, new Action<int>(this.TsSyncAddMutePlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.TsSyncRemoveMutePlayer, new Action<int>(this.TsSyncRemoveMutePlayer));
	}

	// Token: 0x0600B0FF RID: 45311 RVA: 0x002F3FA4 File Offset: 0x002F21A4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnSelectChatFriend, this.OnSelectChatFriend);
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, this.OnOpenView);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterTeam, new Action(this.OnEnterTeam));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveTeam, new Action(this.OnLeaveTeam));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRemoveFriend, this.OnRemoveFriend);
		Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleByResetToBattleView, this.OnPlayerDead);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetFriendInitData, new Action(this.OnGetFriendInitData));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnWorldTeamPlayerInfoChanged, new Action<WorldTeamPlayerInfoChangeNotify>(this.OnWorldTeamPlayerInfoChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncChatEnterTeam, new Action(this.OnEnterTeam));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncChatLeaveTeam, new Action(this.OnLeaveTeam));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncChatEnterOnlineWorld, new Action(this.OnEnterOnlineWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncChatLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncTime, new Action<double, double, double, double>(this.OnTsSyncTime));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncAddMutePlayer, new Action<int>(this.TsSyncAddMutePlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncRemoveMutePlayer, new Action<int>(this.TsSyncRemoveMutePlayer));
	}

	// Token: 0x0600B100 RID: 45312 RVA: 0x002F4174 File Offset: 0x002F2374
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<PrivateMessageNotify>(ENotifyMessageId.PrivateMessageNotify, new Action<PrivateMessageNotify, Net.CallbackStatus>(this.PrivateMessageNotify));
		Singleton<Net>.Instance.Register<ChannelChatMessageNotify>(ENotifyMessageId.ChannelChatMessageNotify, new Action<ChannelChatMessageNotify, Net.CallbackStatus>(this.ChannelChatMessageNotify));
		Singleton<Net>.Instance.Register<PrivateChatHistoryNotify>(ENotifyMessageId.PrivateChatHistoryNotify, new Action<PrivateChatHistoryNotify, Net.CallbackStatus>(this.PrivateChatHistoryNotify));
		Singleton<Net>.Instance.Register<ChannelChatHistoryNotify>(ENotifyMessageId.ChannelChatHistoryNotify, new Action<ChannelChatHistoryNotify, Net.CallbackStatus>(this.ChannelChatHistoryNotify));
		Singleton<Net>.Instance.Register<ChatMutePlayerListNotify>(ENotifyMessageId.ChatMutePlayerListNotify, new Action<ChatMutePlayerListNotify, Net.CallbackStatus>(this.ChatMutePlayerListNotify));
		Singleton<Net>.Instance.Register<BanChatNotify>(ENotifyMessageId.BanChatNotify, new Action<BanChatNotify, Net.CallbackStatus>(this.BanChatNotify));
		Singleton<Net>.Instance.Register<PrivateChatClearNotify>(ENotifyMessageId.PrivateChatClearNotify, new Action<PrivateChatClearNotify, Net.CallbackStatus>(this.PrivateChatClearNotify));
	}

	// Token: 0x0600B101 RID: 45313 RVA: 0x002F4248 File Offset: 0x002F2448
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PrivateMessageNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ChannelChatMessageNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PrivateChatHistoryNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ChannelChatHistoryNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ChatMutePlayerListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BanChatNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PrivateChatClearNotify);
	}

	// Token: 0x0600B102 RID: 45314 RVA: 0x002F42C5 File Offset: 0x002F24C5
	private void OnEnterOnlineWorld()
	{
		if (ModelBase<ChatModel>.Instance.GetWorldChatRoom() == null)
		{
			ModelBase<ChatModel>.Instance.SetWorldChatRoom(ModelBase<ChatModel>.Instance.NewWorldChatRoom());
		}
	}

	// Token: 0x0600B103 RID: 45315 RVA: 0x002F42E8 File Offset: 0x002F24E8
	private void OnLeaveOnlineWorld()
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		instance.SetWorldChatRoom(null);
		instance.SetTeamChatRowDataVisible(false);
		WorldChatRoom worldChatRoom = instance.GetWorldChatRoom();
		if (worldChatRoom != null)
		{
			instance.SetChatRoomRedDot(worldChatRoom, false);
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatView, null);
		}
	}

	// Token: 0x0600B104 RID: 45316 RVA: 0x002F433C File Offset: 0x002F253C
	private void OnEnterTeam()
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		instance.SetTeamChatRoom(instance.NewTeamChatRoom());
	}

	// Token: 0x0600B105 RID: 45317 RVA: 0x002F4350 File Offset: 0x002F2550
	private void OnLeaveTeam()
	{
		ChatModel instance = ModelBase<ChatModel>.Instance;
		instance.SetTeamChatRoom(null);
		instance.SetTeamChatRowDataVisible(false);
		TeamChatRoom teamChatRoom = instance.GetTeamChatRoom();
		if (teamChatRoom != null)
		{
			instance.SetChatRoomRedDot(teamChatRoom, false);
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatView, null);
		}
	}

	// Token: 0x0600B106 RID: 45318 RVA: 0x002F43A4 File Offset: 0x002F25A4
	private void OnTsSyncTime(double serverTime, double flowTime, double predictedServerCombatTimeOffset, double predictedServerStopTimeOffset)
	{
		Singleton<Time>.Instance.SyncTime(serverTime, flowTime, predictedServerCombatTimeOffset, predictedServerStopTimeOffset);
	}

	// Token: 0x0600B107 RID: 45319 RVA: 0x002F43B5 File Offset: 0x002F25B5
	private void TsSyncAddMutePlayer(int playerId)
	{
		ModelBase<ChatModel>.Instance.AddMutePlayer(playerId);
	}

	// Token: 0x0600B108 RID: 45320 RVA: 0x002F43C2 File Offset: 0x002F25C2
	private void TsSyncRemoveMutePlayer(int playerId)
	{
		ModelBase<ChatModel>.Instance.RemoveMutePlayer(playerId);
	}

	// Token: 0x0600B109 RID: 45321 RVA: 0x002F43D0 File Offset: 0x002F25D0
	public void PrivateChatRequest(ChatContentType chatContentType, string content, int targetPlayerId)
	{
		List<int> limitedPlayerIdList = new List<int>();
		if (!ModelBase<KuroSdkModel>.Instance.GetPlayerChatPermission(targetPlayerId))
		{
			limitedPlayerIdList.Add(targetPlayerId);
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("CommunicationRectricted", null));
				this.OpenThirdPartyMessageBox().Forget();
				return;
			}
			if (targetPlayerId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "PrivateChatRequest 私聊对象玩家Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetPlayerId", targetPlayerId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			PrivateChatRequest privateChatRequest = Aki.Protocol.PrivateChatRequest.Create();
			privateChatRequest.ChatContentType = chatContentType;
			privateChatRequest.Content = content;
			privateChatRequest.TargetUID = targetPlayerId;
			privateChatRequest.XboxBlockedPlayerIds.AddRange(limitedPlayerIdList);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Chat;
			ELogAuthor author2 = ELogAuthor.LJQ;
			string message2 = "PrivateChatRequest 客户端请求私聊聊天";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("request", privateChatRequest);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<Net>.Instance.Call<PrivateChatResponse>(ERequestMessageId.PrivateChatRequest, privateChatRequest, new Action<PrivateChatResponse, Net.CallbackStatus>(base.<PrivateChatRequest>g__ResponseCallback|1), 0);
		});
	}

	// Token: 0x0600B10A RID: 45322 RVA: 0x002F4450 File Offset: 0x002F2650
	private UniTask OpenThirdPartyMessageBox()
	{
		ChatController.<OpenThirdPartyMessageBox>d__19 <OpenThirdPartyMessageBox>d__;
		<OpenThirdPartyMessageBox>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OpenThirdPartyMessageBox>d__.<>1__state = -1;
		<OpenThirdPartyMessageBox>d__.<>t__builder.Start<ChatController.<OpenThirdPartyMessageBox>d__19>(ref <OpenThirdPartyMessageBox>d__);
		return <OpenThirdPartyMessageBox>d__.<>t__builder.Task;
	}

	// Token: 0x0600B10B RID: 45323 RVA: 0x002F448C File Offset: 0x002F268C
	public void ChannelChatRequest(ChatContentType chatContentType, string content, SubChatChannelType subChannelType)
	{
		List<int> list = new List<int>();
		if (subChannelType == SubChatChannelType.MatchTeam)
		{
			MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
			if (matchTeamInfo == null)
			{
				goto IL_CB;
			}
			using (IEnumerator<MatchPlayerInfo> enumerator = matchTeamInfo.PlayerInfos.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MatchPlayerInfo matchPlayerInfo = enumerator.Current;
					list.Add(matchPlayerInfo.PlayerId);
				}
				goto IL_CB;
			}
		}
		if (subChannelType == SubChatChannelType.WorldTeam)
		{
			List<OnlineTeamData> teamList = ModelBase<OnlineModel>.Instance.GetTeamList();
			if (teamList != null)
			{
				foreach (OnlineTeamData onlineTeamData in teamList)
				{
					list.Add(onlineTeamData.PlayerId);
				}
			}
		}
		IL_CB:
		List<int> limitedPlayerIdList = new List<int>();
		foreach (int num in list)
		{
			if (!ModelBase<KuroSdkModel>.Instance.GetPlayerChatPermission(num))
			{
				limitedPlayerIdList.Add(num);
			}
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("CommunicationRectricted", null));
				this.OpenThirdPartyMessageBox().Forget();
				return;
			}
			ChannelChatRequest channelChatRequest = Aki.Protocol.ChannelChatRequest.Create();
			channelChatRequest.ChannelType = ChatChannelType.Team;
			channelChatRequest.SubChannelType = subChannelType;
			channelChatRequest.ChatContentType = chatContentType;
			channelChatRequest.Content = content;
			channelChatRequest.XboxBlockedPlayerIds.AddRange(limitedPlayerIdList);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Chat;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "ChannelChatRequest 客户端请求队伍聊天";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", channelChatRequest);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Net instance2 = Singleton<Net>.Instance;
			ERequestMessageId requestMessageId = ERequestMessageId.ChannelChatRequest;
			IMessage message2 = channelChatRequest;
			Action<ChannelChatResponse, Net.CallbackStatus> handle;
			if ((handle = ChatController.<>O.<0>__ResponseCallback) == null)
			{
				handle = (ChatController.<>O.<0>__ResponseCallback = new Action<ChannelChatResponse, Net.CallbackStatus>(ChatController.<ChannelChatRequest>g__ResponseCallback|20_1));
			}
			instance2.Call<ChannelChatResponse>(requestMessageId, message2, handle, 0);
		});
	}

	// Token: 0x0600B10C RID: 45324 RVA: 0x002F4600 File Offset: 0x002F2800
	private UniTask OnPrivateMessageNotify(PrivateMessageNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ChatController.<OnPrivateMessageNotify>d__21 <OnPrivateMessageNotify>d__;
		<OnPrivateMessageNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPrivateMessageNotify>d__.<>4__this = this;
		<OnPrivateMessageNotify>d__.notify = notify;
		<OnPrivateMessageNotify>d__.<>1__state = -1;
		<OnPrivateMessageNotify>d__.<>t__builder.Start<ChatController.<OnPrivateMessageNotify>d__21>(ref <OnPrivateMessageNotify>d__);
		return <OnPrivateMessageNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600B10D RID: 45325 RVA: 0x002F464C File Offset: 0x002F284C
	private void PrivateMessageNotify(PrivateMessageNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PrivateMessageNotify 私聊聊天服务端通知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateMessageNotify 玩家没有UGC权限，无法接收私聊消息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				return;
			}
			this.OnPrivateMessageNotify(notify, status).Forget();
		});
	}

	// Token: 0x0600B10E RID: 45326 RVA: 0x002F46F0 File Offset: 0x002F28F0
	private UniTask OnChannelChatMessageNotify(ChannelChatMessageNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ChatController.<OnChannelChatMessageNotify>d__23 <OnChannelChatMessageNotify>d__;
		<OnChannelChatMessageNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnChannelChatMessageNotify>d__.notify = notify;
		<OnChannelChatMessageNotify>d__.<>1__state = -1;
		<OnChannelChatMessageNotify>d__.<>t__builder.Start<ChatController.<OnChannelChatMessageNotify>d__23>(ref <OnChannelChatMessageNotify>d__);
		return <OnChannelChatMessageNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600B10F RID: 45327 RVA: 0x002F4734 File Offset: 0x002F2934
	private void ChannelChatMessageNotify(ChannelChatMessageNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "ChannelChatMessageNotify 队伍聊天服务端通知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				return;
			}
			ControllerBase<ChatController>.Instance.OnChannelChatMessageNotify(notify, status).Forget();
		});
	}

	// Token: 0x0600B110 RID: 45328 RVA: 0x002F47A4 File Offset: 0x002F29A4
	public void PrivateChatHistoryRequest(int playerId)
	{
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateMessageNotify 玩家没有UGC权限，无法接收私聊消息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Action<PrivateChatHistoryResponse, Net.CallbackStatus> <>9__1;
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				return;
			}
			PrivateChatHistoryRequest privateChatHistoryRequest = Aki.Protocol.PrivateChatHistoryRequest.Create();
			privateChatHistoryRequest.TargetUID = playerId;
			this.IsInRequestHistory = true;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Chat;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "PrivateChatHistoryRequest 客户端请求最近的私聊记录";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", privateChatHistoryRequest);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<PrivateChatHistoryResponse, Net.CallbackStatus> action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(PrivateChatHistoryResponse response, Net.CallbackStatus _)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Chat;
					ELogAuthor author2 = ELogAuthor.LJQ;
					string message2 = "PrivateChatHistoryResponse 私聊聊天历史服务端回应";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("response", response);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
					{
						return;
					}
					this.IsInRequestHistory = false;
					ChatModel instance3 = ModelBase<ChatModel>.Instance;
					PrivateChatHistoryContentProto privateChatHistoryContentProto = (response != null) ? response.Data : null;
					int num = (privateChatHistoryContentProto != null) ? privateChatHistoryContentProto.TargetUID : 0;
					if (num == 0)
					{
						return;
					}
					PrivateChatRoom privateChatRoom = instance3.GetPrivateChatRoom(num);
					if (privateChatRoom == null)
					{
						return;
					}
					RepeatedField<ChatContentProto> repeatedField = (privateChatHistoryContentProto != null) ? privateChatHistoryContentProto.Chats : null;
					if (repeatedField == null || repeatedField.Count <= 0)
					{
						return;
					}
					this.SavePrivateHistoryChatAndOpenChatPad(privateChatRoom, repeatedField.ToList<ChatContentProto>(), playerId).Forget();
				});
			}
			Action<PrivateChatHistoryResponse, Net.CallbackStatus> handle = action;
			Singleton<Net>.Instance.Call<PrivateChatHistoryResponse>(ERequestMessageId.PrivateChatHistoryRequest, privateChatHistoryRequest, handle, 0);
		});
	}

	// Token: 0x0600B111 RID: 45329 RVA: 0x002F4814 File Offset: 0x002F2A14
	private UniTask SavePrivateHistoryChatAndOpenChatPad(PrivateChatRoom chatRoom, List<ChatContentProto> data, int playerId)
	{
		ChatController.<SavePrivateHistoryChatAndOpenChatPad>d__26 <SavePrivateHistoryChatAndOpenChatPad>d__;
		<SavePrivateHistoryChatAndOpenChatPad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SavePrivateHistoryChatAndOpenChatPad>d__.<>4__this = this;
		<SavePrivateHistoryChatAndOpenChatPad>d__.chatRoom = chatRoom;
		<SavePrivateHistoryChatAndOpenChatPad>d__.data = data;
		<SavePrivateHistoryChatAndOpenChatPad>d__.playerId = playerId;
		<SavePrivateHistoryChatAndOpenChatPad>d__.<>1__state = -1;
		<SavePrivateHistoryChatAndOpenChatPad>d__.<>t__builder.Start<ChatController.<SavePrivateHistoryChatAndOpenChatPad>d__26>(ref <SavePrivateHistoryChatAndOpenChatPad>d__);
		return <SavePrivateHistoryChatAndOpenChatPad>d__.<>t__builder.Task;
	}

	// Token: 0x0600B112 RID: 45330 RVA: 0x002F4870 File Offset: 0x002F2A70
	private UniTask OnPrivateChatHistoryNotify(PrivateChatHistoryNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ChatController.<OnPrivateChatHistoryNotify>d__27 <OnPrivateChatHistoryNotify>d__;
		<OnPrivateChatHistoryNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPrivateChatHistoryNotify>d__.<>4__this = this;
		<OnPrivateChatHistoryNotify>d__.notify = notify;
		<OnPrivateChatHistoryNotify>d__.<>1__state = -1;
		<OnPrivateChatHistoryNotify>d__.<>t__builder.Start<ChatController.<OnPrivateChatHistoryNotify>d__27>(ref <OnPrivateChatHistoryNotify>d__);
		return <OnPrivateChatHistoryNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600B113 RID: 45331 RVA: 0x002F48BC File Offset: 0x002F2ABC
	private void PrivateChatHistoryNotify(PrivateChatHistoryNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateChatHistoryNotify 服务端推送最近的私人聊天历史记录", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateMessageNotify 玩家没有UGC权限，无法接收私聊消息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				return;
			}
			this.OnPrivateChatHistoryNotify(notify, status).Forget();
		});
	}

	// Token: 0x0600B114 RID: 45332 RVA: 0x002F4950 File Offset: 0x002F2B50
	private UniTask OnChannelChatHistoryNotify(ChannelChatHistoryNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ChatController.<OnChannelChatHistoryNotify>d__29 <OnChannelChatHistoryNotify>d__;
		<OnChannelChatHistoryNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnChannelChatHistoryNotify>d__.notify = notify;
		<OnChannelChatHistoryNotify>d__.<>1__state = -1;
		<OnChannelChatHistoryNotify>d__.<>t__builder.Start<ChatController.<OnChannelChatHistoryNotify>d__29>(ref <OnChannelChatHistoryNotify>d__);
		return <OnChannelChatHistoryNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600B115 RID: 45333 RVA: 0x002F4994 File Offset: 0x002F2B94
	private void ChannelChatHistoryNotify(ChannelChatHistoryNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "ChannelChatHistoryNotify 服务端推送最近的队伍聊天历史记录", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (!ControllerBase<KuroSdkController>.Instance.CheckPrivilege(ESdkPrivilege.UserGeneratedContent))
		{
			Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateMessageNotify 玩家没有UGC权限，无法接收私聊消息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ControllerBase<KuroSdkController>.Instance.GetCommunicationRestricted(ModelBase<PlayerInfoModel>.Instance.GetThirdPartyAccountId(), delegate(ESdkCommunicationRestricted state)
		{
			if (state == ESdkCommunicationRestricted.Yes)
			{
				return;
			}
			ControllerBase<ChatController>.Instance.OnChannelChatHistoryNotify(notify, status).Forget();
		});
	}

	// Token: 0x0600B116 RID: 45334 RVA: 0x002F4A20 File Offset: 0x002F2C20
	private void ChatMutePlayerListNotify(ChatMutePlayerListNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "ChatMutePlayerListNotify 服务端通知屏蔽列表";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ChatModel instance2 = ModelBase<ChatModel>.Instance;
		instance2.ClearAllMutePlayer();
		foreach (int playerId in notify.PlayerId)
		{
			instance2.AddMutePlayer(playerId);
		}
	}

	// Token: 0x0600B117 RID: 45335 RVA: 0x002F4AA4 File Offset: 0x002F2CA4
	public void ChatMutePlayerRequest(int playerId, bool bMute)
	{
		ChatMutePlayerRequest chatMutePlayerRequest = Aki.Protocol.ChatMutePlayerRequest.Create();
		chatMutePlayerRequest.TargetUID = playerId;
		chatMutePlayerRequest.Mute = bMute;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "ChatMutePlayerRequest 客户端请求屏蔽";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", chatMutePlayerRequest);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<ChatMutePlayerResponse>(ERequestMessageId.ChatMutePlayerRequest, chatMutePlayerRequest, new Action<ChatMutePlayerResponse, Net.CallbackStatus>(this.ChatMutePlayerResponse), 0);
		if (bMute)
		{
			ModelBase<ChatModel>.Instance.AddMutePlayer(playerId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CsRequestAddMutePlayer, playerId);
			return;
		}
		ModelBase<ChatModel>.Instance.RemoveMutePlayer(playerId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.CsRequestRemoveMutePlayer, playerId);
	}

	// Token: 0x0600B118 RID: 45336 RVA: 0x002F4B48 File Offset: 0x002F2D48
	[NullableContext(2)]
	private void ChatMutePlayerResponse(ChatMutePlayerResponse response, Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "ChatMutePlayerResponse 服务端屏蔽回应";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		RepeatedField<int> repeatedField = (response != null) ? response.RemoveMutes : null;
		if (repeatedField == null || repeatedField.Count == 0)
		{
			return;
		}
		ChatModel instance2 = ModelBase<ChatModel>.Instance;
		foreach (int num in repeatedField)
		{
			instance2.RemoveMutePlayer(num);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CsRequestRemoveMutePlayer, num);
		}
	}

	// Token: 0x0600B119 RID: 45337 RVA: 0x002F4BEC File Offset: 0x002F2DEC
	public void ChatReportPush(int targetPlayerId)
	{
	}

	// Token: 0x0600B11A RID: 45338 RVA: 0x002F4BEE File Offset: 0x002F2DEE
	private void BanChatNotify(BanChatNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		this.ShowBanTips(notify.BanEndTime);
	}

	// Token: 0x0600B11B RID: 45339 RVA: 0x002F4BFC File Offset: 0x002F2DFC
	private void ShowBanTips(long time)
	{
		Number a = (float)Singleton<MathUtils>.Instance.LongToBigInt(time);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat8(a - Singleton<TimeUtil>.Instance.GetServerTime());
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Text_BanChatTextTime_Text", new object[]
		{
			remainTimeDataFormat.CountDownText
		});
	}

	// Token: 0x0600B11C RID: 45340 RVA: 0x002F4C60 File Offset: 0x002F2E60
	private void PrivateChatClearNotify(PrivateChatClearNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PrivateMessageNotify 私聊聊天服务端通知删除信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", notify);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (int num in notify.PlayerId)
		{
			ModelBase<ChatModel>.Instance.DeletePrivateChat(num);
			PrivateChatRoom privateChatRoom = ModelBase<ChatModel>.Instance.GetPrivateChatRoom(num);
			if (privateChatRoom != null)
			{
				privateChatRoom.Close();
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnClosePrivateChatRoom, num);
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRefreshChatRowData, false);
	}

	// Token: 0x0600B11D RID: 45341 RVA: 0x002F4D14 File Offset: 0x002F2F14
	public void PrivateChatOperateRequest(PrivateChatOperateType operateType, int targetPlayerId)
	{
		PrivateChatOperateRequest privateChatOperateRequest = Aki.Protocol.PrivateChatOperateRequest.Create();
		privateChatOperateRequest.OperateType = operateType;
		privateChatOperateRequest.TarPlayerId = targetPlayerId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PrivateChatOperateRequest 客户端请求聊天操作";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("request", privateChatOperateRequest);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<PrivateChatOperateResponse>(ERequestMessageId.PrivateChatOperateRequest, privateChatOperateRequest, new Action<PrivateChatOperateResponse, Net.CallbackStatus>(this.PrivateChatOperateResponse), 0);
		if (operateType == PrivateChatOperateType.CloseChat)
		{
			ModelBase<ChatModel>.Instance.ClosePrivateChatRoom(targetPlayerId);
		}
	}

	// Token: 0x0600B11E RID: 45342 RVA: 0x002F4D8C File Offset: 0x002F2F8C
	[NullableContext(2)]
	private void PrivateChatOperateResponse(PrivateChatOperateResponse response, Net.CallbackStatus status)
	{
		if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.ErrBanChatDefault)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "PrivateChatOperateResponse 聊天操作回应";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600B11F RID: 45343 RVA: 0x002F4DD3 File Offset: 0x002F2FD3
	public void OpenFriendChat(int friendPlayerId)
	{
		ModelBase<ChatModel>.Instance.SelectedPrivateChatFriend(friendPlayerId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatView, null, null);
	}

	// Token: 0x0600B120 RID: 45344 RVA: 0x002F4DF4 File Offset: 0x002F2FF4
	public void TryActiveDeleteFriendTips(int playerId)
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			return;
		}
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			return;
		}
		if (!(joinedChatRoom is PrivateChatRoom))
		{
			return;
		}
		if (((PrivateChatRoom)joinedChatRoom).GetTargetPlayerId() != playerId)
		{
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("DeleteFriendText", Array.Empty<object>());
	}

	// Token: 0x0600B121 RID: 45345 RVA: 0x002F4E4E File Offset: 0x002F304E
	private void OnGetFriendInitData()
	{
		this.PrivateChatDataRequest();
	}

	// Token: 0x0600B122 RID: 45346 RVA: 0x002F4E58 File Offset: 0x002F3058
	private void PrivateChatDataRequest()
	{
		PrivateChatDataRequest message = Aki.Protocol.PrivateChatDataRequest.Create();
		Singleton<Net>.Instance.Call<PrivateChatDataResponse>(ERequestMessageId.PrivateChatDataRequest, message, delegate(PrivateChatDataResponse response, Net.CallbackStatus _)
		{
			if (response == null || !response.LoadSucc)
			{
				if (this.DelayPrivateChatDataRequestTimer != null && TimerSystem.GameplayTimeInstance.Has(this.DelayPrivateChatDataRequestTimer))
				{
					return;
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message2 = "PrivateChatDataResponse 服务端加载聊天数据失败，等待一段时间后重新请求";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DelayTime", 60000);
				instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.DelayPrivateChatDataRequestTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnDelayPrivateChatDataRequest), 60000f, null, null, true, 1f);
			}
		}, 0);
	}

	// Token: 0x0600B123 RID: 45347 RVA: 0x002F4E88 File Offset: 0x002F3088
	private void OnDelayPrivateChatDataRequest(float delta)
	{
		Singleton<Log>.Instance.Info(ELogModule.Chat, ELogAuthor.LJQ, "PrivateChatDataResponse 开始重新请求", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.PrivateChatDataRequest();
		this.DelayPrivateChatDataRequestTimer = null;
	}

	// Token: 0x0600B124 RID: 45348 RVA: 0x002F4EC0 File Offset: 0x002F30C0
	private void OnWorldTeamPlayerInfoChanged(WorldTeamPlayerInfoChangeNotify message)
	{
		int playerId = message.PlayerId;
		ChatPlayerData chatPlayerData = ModelBase<ChatModel>.Instance.GetChatPlayerData(playerId);
		if (chatPlayerData == null)
		{
			return;
		}
		switch (message.ChangeType)
		{
		case WorldTeamPlayerChangeType.Name:
			chatPlayerData.SetPlayerName(message.StringValue);
			break;
		case WorldTeamPlayerChangeType.Head:
			chatPlayerData.SetPlayerIcon(new int?(message.IntValue));
			break;
		case WorldTeamPlayerChangeType.PlayerTitle:
			chatPlayerData.SetPlayerTitle(message.StringValue);
			break;
		case WorldTeamPlayerChangeType.Sex:
			chatPlayerData.SetSex(message.IntValue);
			break;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnChatPlayerInfoChanged, playerId);
	}

	// Token: 0x0600B125 RID: 45349 RVA: 0x002F4F58 File Offset: 0x002F3158
	public void RequestChatOption(int playerId)
	{
		ControllerBase<FriendController>.Instance.RequestPlayerCurrentDeactivationState(playerId, delegate(bool deactivation)
		{
			if (deactivation)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("PlayerDeleteSelf", null);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new string[]
				{
					localTextNew
				}, null, null, null, null, null, false, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatOption, playerId, null);
		});
	}

	// Token: 0x0600B127 RID: 45351 RVA: 0x002F5038 File Offset: 0x002F3238
	[NullableContext(2)]
	[CompilerGenerated]
	internal static void <ChannelChatRequest>g__ResponseCallback|20_1(ChannelChatResponse response, Net.CallbackStatus _)
	{
		if (response != null && response.ErrorCode <= Aki.Protocol.ErrorCode.Success)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Chat;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "ChannelChatRequest 队伍聊天服务端回应";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response", response);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.ErrBanChatDefault)
		{
			ControllerBase<ChatController>.Instance.ShowBanTips((response != null) ? response.BanEndTime : 0L);
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView((response != null) ? response.ErrorCode : Aki.Protocol.ErrorCode.Success, 25893, null, true, true);
	}

	// Token: 0x040053F5 RID: 21493
	public bool IsInRequestHistory;

	// Token: 0x040053F6 RID: 21494
	[Nullable(2)]
	private TimerHandle DelayPrivateChatDataRequestTimer;

	// Token: 0x040053F7 RID: 21495
	private readonly Action OnPlayerDead = delegate()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ChatView))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatView, null);
	};

	// Token: 0x040053F8 RID: 21496
	private readonly Action<int> OnSelectChatFriend = delegate(int playerId)
	{
		ModelBase<ChatModel>.Instance.SelectedPrivateChatFriend(playerId);
	};

	// Token: 0x040053F9 RID: 21497
	private readonly Action<EUiViewName, int> OnOpenView = delegate(EUiViewName viewName, int id)
	{
		if (viewName != EUiViewName.ChatView)
		{
			return;
		}
		ModelBase<ChatModel>.Instance.IsOpenedChatView = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshChatRedDot);
	};

	// Token: 0x040053FA RID: 21498
	private readonly Action<int> OnRemoveFriend = delegate(int playerId)
	{
		ModelBase<ChatModel>.Instance.RemovePrivateChatRoom(playerId);
	};

	// Token: 0x02007BD5 RID: 31701
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402A529 RID: 173353
		[Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		public static Action<ChannelChatResponse, Net.CallbackStatus> <0>__ResponseCallback;
	}
}
