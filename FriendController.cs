using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extensions;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C96 RID: 7318
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FriendController : ControllerBase<FriendController>
{
	// Token: 0x0600D611 RID: 54801 RVA: 0x00392868 File Offset: 0x00390A68
	protected override bool OnInit()
	{
		this.OnAddEvents();
		this.OnRegisterNetEvent();
		return true;
	}

	// Token: 0x0600D612 RID: 54802 RVA: 0x00392877 File Offset: 0x00390A77
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		this.OnUnRegisterNetEvent();
		this.CancelTimer();
		this.FirstCheckFriendState = false;
		this.PastWorldMutiState = false;
		return true;
	}

	// Token: 0x0600D613 RID: 54803 RVA: 0x0039289A File Offset: 0x00390A9A
	private void InitTimer()
	{
		this.CancelTimer();
		this.CheckFriendTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRequestFriendDataTimer), 30000f, 1f, null, null, true);
	}

	// Token: 0x0600D614 RID: 54804 RVA: 0x003928CB File Offset: 0x00390ACB
	private void OnRequestFriendDataTimer(float delta)
	{
		this.RequestAllFriend(false, null);
	}

	// Token: 0x0600D615 RID: 54805 RVA: 0x003928D5 File Offset: 0x00390AD5
	private void CancelTimer()
	{
		if (this.CheckFriendTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CheckFriendTimer);
			this.CheckFriendTimer = null;
		}
	}

	// Token: 0x0600D616 RID: 54806 RVA: 0x003928F8 File Offset: 0x00390AF8
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotStart, new Action(this.ValidateRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.ScenePlayerChanged, new Action(this.OnRefreshOnlineTeamList));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.LoadTestFriendsByGm, new Action<int>(this.CallBackLoadTestFriendsByGm));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsOnRequestFriendInfoResponse, new Action<FArrayBuffer>(this.TsOnRequestFriendInfoResponse));
		Singleton<EventSystem>.Instance.Add<int, string>(EEventName.TsSyncChangePlayerRemark, new Action<int, string>(this.OnTsSyncChangePlayerRemark));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsSyncResponseSearchBasicData, new Action<FArrayBuffer>(this.OnTsSyncResponseSearchBasicData));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsSyncResponseSearchSdkData, new Action<FArrayBuffer>(this.OnTsSyncResponseSearchSdkData));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsResponseBlockData, new Action<FArrayBuffer>(this.OnTsResponseBlockData));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsResponseFriendRecentlyTeam, new Action<FArrayBuffer>(this.TsResponseFriendRecentlyTeam));
	}

	// Token: 0x0600D617 RID: 54807 RVA: 0x00392A58 File Offset: 0x00390C58
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotStart, new Action(this.ValidateRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.ScenePlayerChanged, new Action(this.OnRefreshOnlineTeamList));
		Singleton<EventSystem>.Instance.Remove(EEventName.LoadTestFriendsByGm, new Action<int>(this.CallBackLoadTestFriendsByGm));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsOnRequestFriendInfoResponse, new Action<FArrayBuffer>(this.TsOnRequestFriendInfoResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncChangePlayerRemark, new Action<int, string>(this.OnTsSyncChangePlayerRemark));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncResponseSearchBasicData, new Action<FArrayBuffer>(this.OnTsSyncResponseSearchBasicData));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncResponseSearchSdkData, new Action<FArrayBuffer>(this.OnTsSyncResponseSearchSdkData));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsResponseBlockData, new Action<FArrayBuffer>(this.OnTsResponseBlockData));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsResponseFriendRecentlyTeam, new Action<FArrayBuffer>(this.TsResponseFriendRecentlyTeam));
	}

	// Token: 0x0600D618 RID: 54808 RVA: 0x00392BB5 File Offset: 0x00390DB5
	private void OnRefreshOnlineTeamList()
	{
		this.RequestAllFriend(true, null);
	}

	// Token: 0x0600D619 RID: 54809 RVA: 0x00392BC0 File Offset: 0x00390DC0
	private void OnWorldDone()
	{
		if (!this.FirstCheckFriendState)
		{
			this.FirstCheckFriendState = true;
			return;
		}
		if (this.PastWorldMutiState != ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.RequestAllFriend(true, new Action(FriendController.<OnWorldDone>g__callback|15_0));
		}
		this.PastWorldMutiState = ModelBase<GameModeModel>.Instance.IsMulti;
	}

	// Token: 0x0600D61A RID: 54810 RVA: 0x00392C12 File Offset: 0x00390E12
	private void OnDataDone()
	{
		this.RequestAllFriend(true, new Action(FriendController.<OnDataDone>g__callback|16_0));
		this.InitTimer();
	}

	// Token: 0x0600D61B RID: 54811 RVA: 0x00392C2D File Offset: 0x00390E2D
	private void ValidateRedDot()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
	}

	// Token: 0x0600D61C RID: 54812 RVA: 0x00392C40 File Offset: 0x00390E40
	protected void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<FriendAddedNotify>(ENotifyMessageId.FriendAddedNotify, new Action<FriendAddedNotify, Net.CallbackStatus>(this.FriendAddedNotify));
		Singleton<Net>.Instance.Register<FriendDeletedNotify>(ENotifyMessageId.FriendDeletedNotify, new Action<FriendDeletedNotify, Net.CallbackStatus>(this.FriendDeletedNotify));
		Singleton<Net>.Instance.Register<FriendApplyReceivedNotify>(ENotifyMessageId.FriendApplyReceivedNotify, new Action<FriendApplyReceivedNotify, Net.CallbackStatus>(this.FriendApplyReceivedNotify));
		Singleton<Net>.Instance.Register<FriendApplyDeletedNotify>(ENotifyMessageId.FriendApplyDeletedNotify, new Action<FriendApplyDeletedNotify, Net.CallbackStatus>(this.FriendApplyDeletedNotify));
	}

	// Token: 0x0600D61D RID: 54813 RVA: 0x00392CC0 File Offset: 0x00390EC0
	protected void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FriendAddedNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FriendDeletedNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FriendApplyReceivedNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FriendApplyDeletedNotify);
	}

	// Token: 0x0600D61E RID: 54814 RVA: 0x00392D10 File Offset: 0x00390F10
	[NullableContext(2)]
	public void RequestAllFriend(bool force = false, Action call = null)
	{
		if ((Singleton<TimeUtil>.Instance.GetServerTime() <= this.TargetRequestTimeStamp || !ModelBase<LoginModel>.Instance.IsLoginStatus(LoginDefine.ELoginStatus.EnterGameRet)) && !force)
		{
			return;
		}
		float num = 2.5f;
		if (force && Singleton<TimeUtil>.Instance.GetServerTime() - this.LastSendTime < (double)num)
		{
			TimerSystem.GameplayTimeInstance.Delay(delegate(float delta)
			{
				this.RequestAllFriend(force, call);
			}, 2500f, null, null, true, 1f);
			return;
		}
		FriendAllRequest message = FriendAllRequest.Create();
		this.TargetRequestTimeStamp = Singleton<TimeUtil>.Instance.GetServerTime() + 300.0;
		this.LastSendTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return;
		}
		Singleton<Net>.Instance.Call<FriendAllResponse>(ERequestMessageId.FriendAllRequest, message, delegate(FriendAllResponse response, Net.CallbackStatus _)
		{
			Action call2 = call;
			if (call2 != null)
			{
				call2();
			}
			this.OnRequestAllFriendResponse(response);
		}, 0);
	}

	// Token: 0x0600D61F RID: 54815 RVA: 0x00392E04 File Offset: 0x00391004
	[NullableContext(2)]
	private UniTask OnRequestAllFriendResponse(FriendAllResponse message)
	{
		FriendController.<OnRequestAllFriendResponse>d__23 <OnRequestAllFriendResponse>d__;
		<OnRequestAllFriendResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnRequestAllFriendResponse>d__.message = message;
		<OnRequestAllFriendResponse>d__.<>1__state = -1;
		<OnRequestAllFriendResponse>d__.<>t__builder.Start<FriendController.<OnRequestAllFriendResponse>d__23>(ref <OnRequestAllFriendResponse>d__);
		return <OnRequestAllFriendResponse>d__.<>t__builder.Task;
	}

	// Token: 0x0600D620 RID: 54816 RVA: 0x00392E47 File Offset: 0x00391047
	private void FriendAddedNotify(FriendAddedNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnFriendAddedNotify(message);
	}

	// Token: 0x0600D621 RID: 54817 RVA: 0x00392E54 File Offset: 0x00391054
	private UniTask OnFriendAddedNotify(FriendAddedNotify message)
	{
		FriendController.<OnFriendAddedNotify>d__25 <OnFriendAddedNotify>d__;
		<OnFriendAddedNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnFriendAddedNotify>d__.message = message;
		<OnFriendAddedNotify>d__.<>1__state = -1;
		<OnFriendAddedNotify>d__.<>t__builder.Start<FriendController.<OnFriendAddedNotify>d__25>(ref <OnFriendAddedNotify>d__);
		return <OnFriendAddedNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600D622 RID: 54818 RVA: 0x00392E98 File Offset: 0x00391098
	private void FriendDeletedNotify(FriendDeletedNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		int id = message.Id;
		ControllerBase<ChatController>.Instance.TryActiveDeleteFriendTips(id);
		ModelBase<FriendModel>.Instance.DeleteFriend(id);
	}

	// Token: 0x0600D623 RID: 54819 RVA: 0x00392EC2 File Offset: 0x003910C2
	private void FriendApplyReceivedNotify(FriendApplyReceivedNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OnFriendApplyReceivedNotify(message);
	}

	// Token: 0x0600D624 RID: 54820 RVA: 0x00392ECC File Offset: 0x003910CC
	private UniTask OnFriendApplyReceivedNotify(FriendApplyReceivedNotify message)
	{
		FriendController.<OnFriendApplyReceivedNotify>d__28 <OnFriendApplyReceivedNotify>d__;
		<OnFriendApplyReceivedNotify>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnFriendApplyReceivedNotify>d__.message = message;
		<OnFriendApplyReceivedNotify>d__.<>1__state = -1;
		<OnFriendApplyReceivedNotify>d__.<>t__builder.Start<FriendController.<OnFriendApplyReceivedNotify>d__28>(ref <OnFriendApplyReceivedNotify>d__);
		return <OnFriendApplyReceivedNotify>d__.<>t__builder.Task;
	}

	// Token: 0x0600D625 RID: 54821 RVA: 0x00392F0F File Offset: 0x0039110F
	private void FriendApplyDeletedNotify(FriendApplyDeletedNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<FriendModel>.Instance.DeleteFriendApplication(message.Id);
	}

	// Token: 0x0600D626 RID: 54822 RVA: 0x00392F24 File Offset: 0x00391124
	public void RequestFriendApplyAddSend(int id, FriendApplyWay fromWhere)
	{
		if (this.LastApplyAddFriendRequestTime != 0.0 && Singleton<Time>.Instance.Now - this.LastApplyAddFriendRequestTime <= 1000.0)
		{
			return;
		}
		this.LastApplyAddFriendRequestTime = Singleton<Time>.Instance.Now;
		FriendApplySendRequest message = FriendApplySendRequest.Create();
		message.Id = id;
		message.Way = fromWhere;
		Singleton<Net>.Instance.Call<FriendApplySendResponse>(ERequestMessageId.FriendApplySendRequest, message, delegate(FriendApplySendResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrReceiverApplyListCountMax)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RecipientFriendListFull", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrFriendApplySended)
				{
					ModelBase<FriendModel>.Instance.AddPlayerToApplyFriendList(message.Id);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendApplicationSent", Array.Empty<object>());
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.ApplicationSent, message.Id);
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrAlreadyOnFriendApplyList)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendApplicationSent", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrIsBlockedPlayer)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsBlockedPlayer", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrYouAreBlocked)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("YouAreBlocked", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrFriendApplyRequestLimit)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ApplicationTimesLimit", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrAlreadyOnFriendList)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("AlreadyOnFriendList", Array.Empty<object>());
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18648, null, true, true);
			}
			ModelBase<FriendModel>.Instance.AddPlayerToApplyFriendList(message.Id);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendApplicationSent", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ApplicationSent, message.Id);
		}, 0);
	}

	// Token: 0x0600D627 RID: 54823 RVA: 0x00392FBC File Offset: 0x003911BC
	public void RequestFriendApplyHandle(List<int> ids, FriendApplyOperator operation)
	{
		FriendApplyHandleRequest message = FriendApplyHandleRequest.Create();
		if (ids.Count == 0)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.FriendApplicationListUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
			return;
		}
		message.Ids.AddRange(ids);
		message.Operator = operation;
		Singleton<Net>.Instance.Call<FriendApplyHandleResponse>(ERequestMessageId.FriendApplyHandleRequest, message, delegate(FriendApplyHandleResponse response, Net.CallbackStatus _)
		{
			string errorCodeShowString = this.GetErrorCodeShowString(response.ErrorCode);
			bool flag = message.Ids.Count > 1;
			int num = 0;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (KeyValuePair<int, Aki.Protocol.ErrorCode> keyValuePair in response.HandledMap)
			{
				dictionary.Add(keyValuePair.Key, (int)keyValuePair.Value);
			}
			Singleton<EventSystem>.Instance.Emit<int, IReadOnlyDictionary<int, int>>(EEventName.CsRequestFriendHandle, (int)message.Operator, dictionary);
			if (message.Operator == FriendApplyOperator.Approve)
			{
				foreach (KeyValuePair<int, Aki.Protocol.ErrorCode> keyValuePair2 in response.HandledMap)
				{
					Aki.Protocol.ErrorCode value = keyValuePair2.Value;
					if (value == Aki.Protocol.ErrorCode.Success)
					{
						FriendData friendDataInApplicationById = ModelBase<FriendModel>.Instance.GetFriendDataInApplicationById(keyValuePair2.Key);
						if (friendDataInApplicationById != null)
						{
							ModelBase<FriendModel>.Instance.AddFriend(friendDataInApplicationById);
						}
					}
					else
					{
						if (value == Aki.Protocol.ErrorCode.ErrPlayerAccountDeactivation)
						{
							ModelBase<FriendModel>.Instance.DeleteFriendApplication(keyValuePair2.Key);
						}
						if (errorCodeShowString == "")
						{
							errorCodeShowString = this.GetErrorCodeShowString(value);
						}
					}
				}
			}
			foreach (KeyValuePair<int, Aki.Protocol.ErrorCode> keyValuePair3 in response.HandledMap)
			{
				Aki.Protocol.ErrorCode value2 = keyValuePair3.Value;
				if (value2 == Aki.Protocol.ErrorCode.Success)
				{
					num++;
					ModelBase<FriendModel>.Instance.DeleteFriendApplication(keyValuePair3.Key);
					if (message.Operator == FriendApplyOperator.Approve)
					{
						ModelBase<FriendModel>.Instance.AddPlayerToApproveFriendList(keyValuePair3.Key);
					}
					else if (message.Operator == FriendApplyOperator.Reject)
					{
						ModelBase<FriendModel>.Instance.AddPlayerToRefuseFriendList(keyValuePair3.Key);
					}
				}
				else if (errorCodeShowString == "")
				{
					errorCodeShowString = this.GetErrorCodeShowString(value2);
				}
			}
			if (errorCodeShowString != "")
			{
				if (!flag)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(errorCodeShowString, Array.Empty<object>());
				}
				else if (flag && num == 0)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode(errorCodeShowString, Array.Empty<object>());
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FriendApplicationListUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
			if (operation == FriendApplyOperator.Reject)
			{
				Singleton<EventSystem>.Instance.Emit<EFriendItemOperation, IReadOnlyList<int>>(EEventName.ApplicationHandled, EFriendItemOperation.Refuse, ids);
				return;
			}
			if (operation == FriendApplyOperator.Approve)
			{
				Singleton<EventSystem>.Instance.Emit<EFriendItemOperation, IReadOnlyList<int>>(EEventName.ApplicationHandled, EFriendItemOperation.Approve, ids);
			}
		}, 0);
	}

	// Token: 0x0600D628 RID: 54824 RVA: 0x00393066 File Offset: 0x00391266
	private string GetErrorCodeShowString(Aki.Protocol.ErrorCode errorCode)
	{
		if (errorCode == Aki.Protocol.ErrorCode.Success)
		{
			return "";
		}
		if (errorCode == Aki.Protocol.ErrorCode.ErrInitiatorFriendListCountMax)
		{
			return "ApplicantFriendListFull";
		}
		if (errorCode == Aki.Protocol.ErrorCode.ErrFriendListCountMax)
		{
			return "FriendListFull";
		}
		if (errorCode == Aki.Protocol.ErrorCode.ErrPlayerAccountDeactivation)
		{
			return "PlayerDeleteSelf";
		}
		return "FriendApplicationInvalid";
	}

	// Token: 0x0600D629 RID: 54825 RVA: 0x003930A0 File Offset: 0x003912A0
	public void LocalRemoveApplicationFriend(int friend)
	{
		ModelBase<FriendModel>.Instance.DeleteFriendApplication(friend);
		Singleton<EventSystem>.Instance.Emit(EEventName.FriendApplicationListUpdate);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
	}

	// Token: 0x0600D62A RID: 54826 RVA: 0x003930D0 File Offset: 0x003912D0
	[NullableContext(0)]
	public UniTask<Aki.Protocol.ErrorCode> RequestFriendRemarkChange(int? id, [Nullable(1)] string remark)
	{
		FriendController.<RequestFriendRemarkChange>d__34 <RequestFriendRemarkChange>d__;
		<RequestFriendRemarkChange>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
		<RequestFriendRemarkChange>d__.id = id;
		<RequestFriendRemarkChange>d__.remark = remark;
		<RequestFriendRemarkChange>d__.<>1__state = -1;
		<RequestFriendRemarkChange>d__.<>t__builder.Start<FriendController.<RequestFriendRemarkChange>d__34>(ref <RequestFriendRemarkChange>d__);
		return <RequestFriendRemarkChange>d__.<>t__builder.Task;
	}

	// Token: 0x0600D62B RID: 54827 RVA: 0x0039311C File Offset: 0x0039131C
	public void RequestFriendDelete(int id)
	{
		FriendDeleteRequest friendDeleteRequest = FriendDeleteRequest.Create();
		friendDeleteRequest.Id = id;
		Singleton<Net>.Instance.Call<FriendDeleteResponse>(ERequestMessageId.FriendDeleteRequest, friendDeleteRequest, delegate(FriendDeleteResponse response, Net.CallbackStatus _)
		{
			this.OnRequestFriendDeleteResponse(response, id);
		}, 0);
	}

	// Token: 0x0600D62C RID: 54828 RVA: 0x0039316C File Offset: 0x0039136C
	private void OnRequestFriendDeleteResponse(FriendDeleteResponse response, int id)
	{
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendDeleteSuccess", Array.Empty<object>());
			ModelBase<FriendModel>.Instance.DeleteFriend(id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CsRequestFriendDelete, id);
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrNotOnFriendList)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOnFriendList", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26528, null, true, true);
	}

	// Token: 0x0600D62D RID: 54829 RVA: 0x0039320C File Offset: 0x0039140C
	public void RequestBlackList()
	{
		BlockListRequest message = BlockListRequest.Create();
		Singleton<Net>.Instance.Call<BlockListResponse>(ERequestMessageId.BlockListRequest, message, delegate(BlockListResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16482, null, true, true);
				return;
			}
			this.OnBlackListResponse(response);
		}, 0);
	}

	// Token: 0x0600D62E RID: 54830 RVA: 0x0039323C File Offset: 0x0039143C
	private UniTask OnBlackListResponse(BlockListResponse message)
	{
		FriendController.<OnBlackListResponse>d__38 <OnBlackListResponse>d__;
		<OnBlackListResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBlackListResponse>d__.message = message;
		<OnBlackListResponse>d__.<>1__state = -1;
		<OnBlackListResponse>d__.<>t__builder.Start<FriendController.<OnBlackListResponse>d__38>(ref <OnBlackListResponse>d__);
		return <OnBlackListResponse>d__.<>t__builder.Task;
	}

	// Token: 0x0600D62F RID: 54831 RVA: 0x00393280 File Offset: 0x00391480
	public void RequestBlockPlayer(int playerId)
	{
		BlockPlayerRequest blockPlayerRequest = BlockPlayerRequest.Create();
		blockPlayerRequest.Id = playerId;
		Singleton<Net>.Instance.Call<BlockPlayerResponse>(ERequestMessageId.BlockPlayerRequest, blockPlayerRequest, delegate(BlockPlayerResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				this.OnBlockPlayerResponse(playerId, response);
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrIsBlockedPlayer)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsBlockedPlayer", Array.Empty<object>());
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBlackListShow);
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrBlockListCountMax)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BlackListFull", Array.Empty<object>());
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBlackListShow);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26142, null, true, true);
		}, 0);
	}

	// Token: 0x0600D630 RID: 54832 RVA: 0x003932D0 File Offset: 0x003914D0
	private UniTask OnBlockPlayerResponse(int playerId, BlockPlayerResponse response)
	{
		FriendController.<OnBlockPlayerResponse>d__40 <OnBlockPlayerResponse>d__;
		<OnBlockPlayerResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBlockPlayerResponse>d__.playerId = playerId;
		<OnBlockPlayerResponse>d__.response = response;
		<OnBlockPlayerResponse>d__.<>1__state = -1;
		<OnBlockPlayerResponse>d__.<>t__builder.Start<FriendController.<OnBlockPlayerResponse>d__40>(ref <OnBlockPlayerResponse>d__);
		return <OnBlockPlayerResponse>d__.<>t__builder.Task;
	}

	// Token: 0x0600D631 RID: 54833 RVA: 0x0039331C File Offset: 0x0039151C
	public void RequestUnBlockPlayer(int playerId)
	{
		UnblockPlayerRequest unblockPlayerRequest = UnblockPlayerRequest.Create();
		unblockPlayerRequest.Id = playerId;
		Singleton<Net>.Instance.Call<UnblockPlayerResponse>(ERequestMessageId.UnblockPlayerRequest, unblockPlayerRequest, delegate(UnblockPlayerResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RemoveFromBlackListSucceeded", new object[]
				{
					ModelBase<FriendModel>.Instance.GetBlockedPlayerById(playerId).GetBlockedPlayerData.PlayerName
				});
				ModelBase<FriendModel>.Instance.DeleteBlockedPlayer(playerId);
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBlackListShow);
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrIsNotBlockedPlayer)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsNotBlockedPlayer", Array.Empty<object>());
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBlackListShow);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15081, null, true, true);
		}, 0);
	}

	// Token: 0x0600D632 RID: 54834 RVA: 0x00393368 File Offset: 0x00391568
	public void RequestSearchPlayerBasicInfoBySdkId(string thirdPartyId)
	{
		if (Singleton<Info>.Instance.IsPs5Platform())
		{
			PlayerPsnInfoGetRequest playerPsnInfoGetRequest = PlayerPsnInfoGetRequest.Create();
			playerPsnInfoGetRequest.PsnOnlineId = thirdPartyId;
			Singleton<Net>.Instance.Call<PlayerPsnInfoGetResponse>(ERequestMessageId.PlayerPsnInfoGetRequest, playerPsnInfoGetRequest, delegate(PlayerPsnInfoGetResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					this.OnSearchPlayerBasicInfoResponse(response.Info);
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.InvalidUserId)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InvalidUserId", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrCanNotGetSelfBasicInfo)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CanNotSearchSelf", Array.Empty<object>());
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21106, null, true, true);
			}, 0);
			return;
		}
		if (Singleton<Info>.Instance.IsXboxPlatform())
		{
			PlayerXboxInfoGetRequest playerXboxInfoGetRequest = PlayerXboxInfoGetRequest.Create();
			playerXboxInfoGetRequest.XboxOnlineId = thirdPartyId;
			Singleton<Net>.Instance.Call<PlayerXboxInfoGetResponse>(ERequestMessageId.PlayerXboxInfoGetRequest, playerXboxInfoGetRequest, delegate(PlayerXboxInfoGetResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					this.OnSearchPlayerBasicInfoResponse(response.Info);
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.InvalidUserId)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InvalidUserId", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrCanNotGetSelfBasicInfo)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CanNotSearchSelf", Array.Empty<object>());
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19269, null, true, true);
			}, 0);
		}
	}

	// Token: 0x0600D633 RID: 54835 RVA: 0x003933E4 File Offset: 0x003915E4
	public void RequestPlayerCurrentDeactivationState(int playerId, Action<bool> callback)
	{
		PlayerBasicInfoGetRequest playerBasicInfoGetRequest = PlayerBasicInfoGetRequest.Create();
		playerBasicInfoGetRequest.Id = playerId;
		Singleton<Net>.Instance.Call<PlayerBasicInfoGetResponse>(ERequestMessageId.PlayerBasicInfoGetRequest, playerBasicInfoGetRequest, delegate(PlayerBasicInfoGetResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPlayerAccountDeactivation)
			{
				callback(true);
				return;
			}
			callback(false);
		}, 0);
	}

	// Token: 0x0600D634 RID: 54836 RVA: 0x00393428 File Offset: 0x00391628
	public void RequestSearchPlayerBasicInfo(int playerId, bool silenceQuery = false)
	{
		PlayerBasicInfoGetRequest playerBasicInfoGetRequest = PlayerBasicInfoGetRequest.Create();
		playerBasicInfoGetRequest.Id = playerId;
		Singleton<Net>.Instance.Call<PlayerBasicInfoGetResponse>(ERequestMessageId.PlayerBasicInfoGetRequest, playerBasicInfoGetRequest, delegate(PlayerBasicInfoGetResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success && !silenceQuery)
			{
				if (response.ErrorCode == Aki.Protocol.ErrorCode.InvalidUserId)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InvalidUserId", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrCanNotGetSelfBasicInfo)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CanNotSearchSelf", Array.Empty<object>());
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPlayerAccountDeactivation)
				{
					string localTextNew = ConfigMultiTextLang.GetLocalTextNew("PlayerDeleteSelf", null);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new <>z__ReadOnlySingleElementList<object>(localTextNew), null, null, null, null, null, false, null);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27753, null, true, true);
				return;
			}
			else
			{
				if (response.ErrorCode > Aki.Protocol.ErrorCode.Success & silenceQuery)
				{
					return;
				}
				this.OnSearchPlayerBasicInfoResponse(response.Info);
				return;
			}
		}, 0);
	}

	// Token: 0x0600D635 RID: 54837 RVA: 0x00393474 File Offset: 0x00391674
	[NullableContext(2)]
	private UniTask OnSearchPlayerBasicInfoResponse(PlayerDetails info)
	{
		FriendController.<OnSearchPlayerBasicInfoResponse>d__45 <OnSearchPlayerBasicInfoResponse>d__;
		<OnSearchPlayerBasicInfoResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnSearchPlayerBasicInfoResponse>d__.info = info;
		<OnSearchPlayerBasicInfoResponse>d__.<>1__state = -1;
		<OnSearchPlayerBasicInfoResponse>d__.<>t__builder.Start<FriendController.<OnSearchPlayerBasicInfoResponse>d__45>(ref <OnSearchPlayerBasicInfoResponse>d__);
		return <OnSearchPlayerBasicInfoResponse>d__.<>t__builder.Task;
	}

	// Token: 0x0600D636 RID: 54838 RVA: 0x003934B8 File Offset: 0x003916B8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, EFriendOfflineSection> GetOfflineSection(long offlineTimeStamp)
	{
		int num = Singleton<TimeUtil>.Instance.CalculateDayTimeStampGapBetweenNow((double)offlineTimeStamp, false);
		EFriendOfflineSection item = EFriendOfflineSection.Today;
		string item2 = "FriendOfflineToday";
		if (num <= 1)
		{
			item = EFriendOfflineSection.Today;
			item2 = "FriendOfflineToday";
		}
		else if (num > 1 && num <= 7)
		{
			item = EFriendOfflineSection.InWeek;
			item2 = "FriendOfflineInWeek";
		}
		else if (num > 1 && num <= 30)
		{
			item = EFriendOfflineSection.InMonth;
			item2 = "FriendOfflineInMonth";
		}
		else if (num > 30)
		{
			item = EFriendOfflineSection.OverMonth;
			item2 = "FriendOfflineOverMonth";
		}
		return new ValueTuple<string, EFriendOfflineSection>(item2, item);
	}

	// Token: 0x0600D637 RID: 54839 RVA: 0x00393522 File Offset: 0x00391722
	public bool CheckRemarkIsValid(string remark)
	{
		return !string.IsNullOrEmpty(remark);
	}

	// Token: 0x0600D638 RID: 54840 RVA: 0x00393530 File Offset: 0x00391730
	public List<FriendItemSt> CreateFriendItemSt(IReadOnlyList<int> ids, EFriendItemOperation operationType)
	{
		List<FriendItemSt> list = new List<FriendItemSt>();
		foreach (int id in ids)
		{
			list.Add(new FriendItemSt
			{
				Id = id,
				OperationType = operationType
			});
		}
		return list;
	}

	// Token: 0x0600D639 RID: 54841 RVA: 0x00393594 File Offset: 0x00391794
	public bool CheckHasAnyApplied(int[] playerIdList)
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		foreach (int id in playerIdList)
		{
			if (instance.HasFriendApplication(id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600D63A RID: 54842 RVA: 0x003935C8 File Offset: 0x003917C8
	public List<int> GetSortedFriendListByRules(List<int> originalList, Func<int, int, int> callback)
	{
		List<int> list = new List<int>();
		for (int i = originalList.Count - 1; i >= 0; i--)
		{
			list.Add(originalList[i]);
		}
		list.Sort((int a, int b) => callback(a, b));
		return list;
	}

	// Token: 0x0600D63B RID: 54843 RVA: 0x0039361C File Offset: 0x0039181C
	public List<int> GetSortedBlackOrApplyList(List<int> originalList)
	{
		List<int> list = new List<int>();
		for (int i = originalList.Count - 1; i >= 0; i--)
		{
			list.Add(originalList[i]);
		}
		return list;
	}

	// Token: 0x0600D63C RID: 54844 RVA: 0x00393650 File Offset: 0x00391850
	public int FriendListSortHook(int a, int b)
	{
		FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(a);
		FriendData friendById2 = ModelBase<FriendModel>.Instance.GetFriendById(b);
		return this.FriendSortCondition(friendById, friendById2);
	}

	// Token: 0x0600D63D RID: 54845 RVA: 0x00393680 File Offset: 0x00391880
	private int FriendSortCondition(FriendData aData, FriendData bData)
	{
		if (aData == null || bData == null)
		{
			return 1;
		}
		if (aData.PlayerIsOnline != bData.PlayerIsOnline)
		{
			if (aData.PlayerIsOnline || !bData.PlayerIsOnline)
			{
				return -1;
			}
			return 1;
		}
		else if (aData.PlayerIsOnline && bData.PlayerIsOnline)
		{
			if (aData.PlayerLevel == bData.PlayerLevel)
			{
				return aData.PlayerId - bData.PlayerId;
			}
			return -(aData.PlayerLevel - bData.PlayerLevel);
		}
		else
		{
			if (this.GetOfflineSection(aData.PlayerLastOfflineTime).Item2 != this.GetOfflineSection(bData.PlayerLastOfflineTime).Item2)
			{
				return -(this.GetOfflineSection(aData.PlayerLastOfflineTime).Item2 - this.GetOfflineSection(bData.PlayerLastOfflineTime).Item2);
			}
			if (aData.PlayerLevel == bData.PlayerLevel)
			{
				return aData.PlayerId - bData.PlayerId;
			}
			return -(aData.PlayerLevel - bData.PlayerLevel);
		}
	}

	// Token: 0x0600D63E RID: 54846 RVA: 0x00393768 File Offset: 0x00391968
	private void CallBackLoadTestFriendsByGm(int count)
	{
		ModelBase<FriendModel>.Instance.ClearTestFriendData();
		for (int i = 0; i < count; i++)
		{
			FriendData friendData = new FriendData();
			friendData.PlayerId = i + 1;
			FriendData friendData2 = friendData;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendLiteral("测试员");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
			friendData2.PlayerName = defaultInterpolatedStringHandler.ToStringAndClear();
			FriendData friendData3 = friendData;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("仅供展示使用");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
			friendData3.FriendRemark = defaultInterpolatedStringHandler.ToStringAndClear();
			friendData.PlayerLevel = 1;
			friendData.PlayerIsOnline = true;
			friendData.PlayerLastOfflineTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
			friendData.Debug = true;
			FriendApplyData friendApplyData = new FriendApplyData();
			FriendBlackListData friendBlackListData = new FriendBlackListData();
			friendApplyData.ApplyPlayerData = friendData;
			friendApplyData.ApplyCreatedTime = friendData.PlayerLastOfflineTime + (long)i;
			friendApplyData.Fresh = false;
			friendBlackListData.GetBlockedPlayerData = friendData;
			ModelBase<FriendModel>.Instance.AddFriend(friendData);
			ModelBase<FriendModel>.Instance.AddFriendApplication(friendApplyData);
			ModelBase<FriendModel>.Instance.AddToBlackList(friendBlackListData);
			ModelBase<FriendModel>.Instance.AddFriendSearchResults(friendData);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBlackListShow);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.SearchPlayerInfo, count);
		ModelBase<FriendModel>.Instance.TestDataLoaded = true;
	}

	// Token: 0x0600D63F RID: 54847 RVA: 0x003938BC File Offset: 0x00391ABC
	public void RequestFriendRecentlyTeam()
	{
		FriendRecentlyTeamRequest message = FriendRecentlyTeamRequest.Create();
		Singleton<Net>.Instance.Call<FriendRecentlyTeamResponse>(ERequestMessageId.FriendRecentlyTeamRequest, message, new Action<FriendRecentlyTeamResponse, Net.CallbackStatus>(FriendController.<RequestFriendRecentlyTeam>g__response|55_0), 0);
	}

	// Token: 0x0600D640 RID: 54848 RVA: 0x003938EC File Offset: 0x00391AEC
	public string GetOfflineTimeString(int day)
	{
		if (day <= 1)
		{
			return "FriendOfflineToday";
		}
		if (day > 1 && day <= 30)
		{
			return "FriendOfflineSomeDay";
		}
		if (day > 30)
		{
			return "FriendOfflineOverMonth";
		}
		return "FriendOfflineToday";
	}

	// Token: 0x0600D641 RID: 54849 RVA: 0x00393918 File Offset: 0x00391B18
	private void TsOnRequestFriendInfoResponse(FArrayBuffer buffer)
	{
		FriendAllResponse friendAllResponse = FriendAllResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (friendAllResponse == null)
		{
			return;
		}
		this.OnRequestAllFriendResponse(friendAllResponse);
	}

	// Token: 0x0600D642 RID: 54850 RVA: 0x00393944 File Offset: 0x00391B44
	private void OnTsSyncChangePlayerRemark(int uid, string remark)
	{
		if (ModelBase<FriendModel>.Instance.IsMyFriend(uid))
		{
			ModelBase<FriendModel>.Instance.GetFriendById(uid).FriendRemark = remark;
			Singleton<EventSystem>.Instance.Emit<int, string>(EEventName.CsRequestChangeFriendRemark, uid, remark);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
	}

	// Token: 0x0600D643 RID: 54851 RVA: 0x00393994 File Offset: 0x00391B94
	private void OnTsSyncResponseSearchBasicData(FArrayBuffer buffer)
	{
		PlayerBasicInfoGetResponse playerBasicInfoGetResponse = PlayerBasicInfoGetResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (playerBasicInfoGetResponse == null)
		{
			return;
		}
		this.OnSearchPlayerBasicInfoResponse(playerBasicInfoGetResponse.Info);
	}

	// Token: 0x0600D644 RID: 54852 RVA: 0x003939C4 File Offset: 0x00391BC4
	private void OnTsSyncResponseSearchSdkData(FArrayBuffer buffer)
	{
		PlayerPsnInfoGetResponse playerPsnInfoGetResponse = PlayerPsnInfoGetResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (playerPsnInfoGetResponse == null)
		{
			return;
		}
		this.OnSearchPlayerBasicInfoResponse(playerPsnInfoGetResponse.Info);
	}

	// Token: 0x0600D645 RID: 54853 RVA: 0x003939F4 File Offset: 0x00391BF4
	private void OnTsResponseBlockData(FArrayBuffer buffer)
	{
		BlockListResponse blockListResponse = BlockListResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (blockListResponse == null)
		{
			return;
		}
		this.OnBlackListResponse(blockListResponse);
	}

	// Token: 0x0600D646 RID: 54854 RVA: 0x00393A20 File Offset: 0x00391C20
	private void TsResponseFriendRecentlyTeam(FArrayBuffer buffer)
	{
		FriendRecentlyTeamResponse friendRecentlyTeamResponse = FriendRecentlyTeamResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (friendRecentlyTeamResponse == null)
		{
			return;
		}
		if (friendRecentlyTeamResponse.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<FriendModel>.Instance.InitRecentlyTeamDataByResponse(friendRecentlyTeamResponse.Infos.ToArray<RecentlyTeamInfo>());
		}
	}

	// Token: 0x0600D648 RID: 54856 RVA: 0x00393A68 File Offset: 0x00391C68
	[CompilerGenerated]
	internal static void <OnWorldDone>g__callback|15_0()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetFriendInitData);
	}

	// Token: 0x0600D649 RID: 54857 RVA: 0x00393A7A File Offset: 0x00391C7A
	[CompilerGenerated]
	internal static void <OnDataDone>g__callback|16_0()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetFriendInitData);
	}

	// Token: 0x0600D64D RID: 54861 RVA: 0x00393BAF File Offset: 0x00391DAF
	[NullableContext(2)]
	[CompilerGenerated]
	internal static void <RequestFriendRecentlyTeam>g__response|55_0(FriendRecentlyTeamResponse response, Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
		{
			ModelBase<FriendModel>.Instance.InitRecentlyTeamDataByResponse(response.Infos.ToArray<RecentlyTeamInfo>());
			return;
		}
		ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26034, null, true, true);
	}

	// Token: 0x0400659C RID: 26012
	private const int CHECKGAP = 30000;

	// Token: 0x0400659D RID: 26013
	private const int APPLYFRIENDCD = 1000;

	// Token: 0x0400659E RID: 26014
	private const int SERVERREQUESTCD = 2500;

	// Token: 0x0400659F RID: 26015
	[Nullable(2)]
	private TimerHandle CheckFriendTimer;

	// Token: 0x040065A0 RID: 26016
	private bool FirstCheckFriendState;

	// Token: 0x040065A1 RID: 26017
	private bool PastWorldMutiState;

	// Token: 0x040065A2 RID: 26018
	private double LastApplyAddFriendRequestTime;

	// Token: 0x040065A3 RID: 26019
	private double TargetRequestTimeStamp;

	// Token: 0x040065A4 RID: 26020
	private double LastSendTime;
}
