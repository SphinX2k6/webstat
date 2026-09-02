using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Extensions;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002409 RID: 9225
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PersonalController : UiControllerBase<PersonalController>
{
	// Token: 0x06011DB2 RID: 73138 RVA: 0x004E95E4 File Offset: 0x004E77E4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenSet));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.PlayerTitleRequest));
		Singleton<EventSystem>.Instance.Add(EEventName.BattleViewActiveSequenceFinish, new Action(this.ShowTitleGetView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleUnlock, new Action(this.ShowTitleGetView));
		Singleton<EventSystem>.Instance.Add<FArrayBuffer>(EEventName.TsSyncHeadInfo, new Action<FArrayBuffer>(this.TsSyncHeadInfo));
	}

	// Token: 0x06011DB3 RID: 73139 RVA: 0x004E969C File Offset: 0x004E789C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnLoadingNetDataDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenSet));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.PlayerTitleRequest));
		Singleton<EventSystem>.Instance.Remove(EEventName.BattleViewActiveSequenceFinish, new Action(this.ShowTitleGetView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleUnlock, new Action(this.ShowTitleGetView));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncHeadInfo, new Action<FArrayBuffer>(this.TsSyncHeadInfo));
	}

	// Token: 0x06011DB4 RID: 73140 RVA: 0x004E9751 File Offset: 0x004E7951
	private void OnLoadingNetDataDone()
	{
		this.PlayerHeadRequest();
	}

	// Token: 0x06011DB5 RID: 73141 RVA: 0x004E975C File Offset: 0x004E795C
	private void PlayerHeadRequest()
	{
		PlayerHeadRequest message = Aki.Protocol.PlayerHeadRequest.Create();
		Singleton<Net>.Instance.Call<PlayerHeadResponse>(ERequestMessageId.PlayerHeadRequest, message, delegate(PlayerHeadResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<PersonalModel>.Instance.InitPlayerHeadData(response.PlayerHeadIds.ToArray<int>());
		}, 0);
	}

	// Token: 0x06011DB6 RID: 73142 RVA: 0x004E97A0 File Offset: 0x004E79A0
	public void SendBirthdayInitRequest(int birthday)
	{
		BirthdayInitRequest birthdayInitRequest = BirthdayInitRequest.Create();
		birthdayInitRequest.Birthday = birthday;
		Singleton<Net>.Instance.Call<BirthdayInitResponse>(ERequestMessageId.BirthdayInitRequest, birthdayInitRequest, delegate(BirthdayInitResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.SetBirthday(birthday);
				ModelBase<BirthdayModel>.Instance.ResetBirthday();
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17137, null, true, true);
		}, 0);
	}

	// Token: 0x06011DB7 RID: 73143 RVA: 0x004E97EC File Offset: 0x004E79EC
	public void SendBirthdayShowSetRequest(bool display)
	{
		BirthdayShowSetRequest birthdayShowSetRequest = BirthdayShowSetRequest.Create();
		birthdayShowSetRequest.DisPlay = display;
		Singleton<Net>.Instance.Call<BirthdayShowSetResponse>(ERequestMessageId.BirthdayShowSetRequest, birthdayShowSetRequest, delegate(BirthdayShowSetResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.SetBirthdayDisplay(display);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24192, null, true, true);
		}, 0);
	}

	// Token: 0x06011DB8 RID: 73144 RVA: 0x004E9838 File Offset: 0x004E7A38
	[NullableContext(1)]
	public void SendRoleShowListUpdateRequest(List<int> roleList)
	{
		RoleShowListUpdateRequest roleShowListUpdateRequest = RoleShowListUpdateRequest.Create();
		roleShowListUpdateRequest.RoleList.AddRange(roleList);
		Singleton<Net>.Instance.Call<RoleShowListUpdateResponse>(ERequestMessageId.RoleShowListUpdateRequest, roleShowListUpdateRequest, delegate(RoleShowListUpdateResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.UpdateRoleShowList(roleList.ToArray());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17207, null, true, true);
		}, 0);
	}

	// Token: 0x06011DB9 RID: 73145 RVA: 0x004E9888 File Offset: 0x004E7A88
	public UniTask<bool> SendRoleShowListUpdateRequestAsync([Nullable(1)] List<int> roleList)
	{
		PersonalController.<SendRoleShowListUpdateRequestAsync>d__7 <SendRoleShowListUpdateRequestAsync>d__;
		<SendRoleShowListUpdateRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SendRoleShowListUpdateRequestAsync>d__.roleList = roleList;
		<SendRoleShowListUpdateRequestAsync>d__.<>1__state = -1;
		<SendRoleShowListUpdateRequestAsync>d__.<>t__builder.Start<PersonalController.<SendRoleShowListUpdateRequestAsync>d__7>(ref <SendRoleShowListUpdateRequestAsync>d__);
		return <SendRoleShowListUpdateRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011DBA RID: 73146 RVA: 0x004E98CC File Offset: 0x004E7ACC
	public void SendChangeCardRequest(int cardId)
	{
		ChangeCardRequest changeCardRequest = ChangeCardRequest.Create();
		changeCardRequest.CardId = cardId;
		Singleton<Net>.Instance.Call<ChangeCardResponse>(ERequestMessageId.ChangeCardRequest, changeCardRequest, delegate(ChangeCardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.SetCurCardId(cardId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29217, null, true, true);
		}, 0);
	}

	// Token: 0x06011DBB RID: 73147 RVA: 0x004E9918 File Offset: 0x004E7B18
	public void SendReadCardRequest(int cardId)
	{
		ReadCardRequest readCardRequest = ReadCardRequest.Create();
		readCardRequest.CardId = cardId;
		Singleton<Net>.Instance.Call<ReadCardResponse>(ERequestMessageId.ReadCardRequest, readCardRequest, delegate(ReadCardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.UpdateCardUnlockList(cardId, true);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22941, null, true, true);
		}, 0);
	}

	// Token: 0x06011DBC RID: 73148 RVA: 0x004E9964 File Offset: 0x004E7B64
	[NullableContext(1)]
	public void SendModifySignatureRequest(string sign)
	{
		ModifySignatureRequest modifySignatureRequest = ModifySignatureRequest.Create();
		modifySignatureRequest.Signature = sign;
		Singleton<Net>.Instance.Call<ModifySignatureResponse>(ERequestMessageId.ModifySignatureRequest, modifySignatureRequest, delegate(ModifySignatureResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.SetSignature(sign);
				return;
			}
			if (response.ErrorCode == ErrorCode.ContainsDirtyWord || response.ErrorCode == ErrorCode.ErrRoleInvalidNameLength)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NotElegantName", Array.Empty<object>());
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22846, null, true, true);
		}, 0);
	}

	// Token: 0x06011DBD RID: 73149 RVA: 0x004E99B0 File Offset: 0x004E7BB0
	public UniTask<ErrorCode> RequestModifySignature([Nullable(1)] string sign)
	{
		PersonalController.<RequestModifySignature>d__11 <RequestModifySignature>d__;
		<RequestModifySignature>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<RequestModifySignature>d__.sign = sign;
		<RequestModifySignature>d__.<>1__state = -1;
		<RequestModifySignature>d__.<>t__builder.Start<PersonalController.<RequestModifySignature>d__11>(ref <RequestModifySignature>d__);
		return <RequestModifySignature>d__.<>t__builder.Task;
	}

	// Token: 0x06011DBE RID: 73150 RVA: 0x004E99F4 File Offset: 0x004E7BF4
	public void SendChangeHeadPhotoRequest(int headPhotoId)
	{
		ChangeHeadPhotoRequest changeHeadPhotoRequest = ChangeHeadPhotoRequest.Create();
		changeHeadPhotoRequest.HeadPhotoId = headPhotoId;
		Singleton<Net>.Instance.Call<ChangeHeadPhotoResponse>(ERequestMessageId.ChangeHeadPhotoRequest, changeHeadPhotoRequest, delegate(ChangeHeadPhotoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == ErrorCode.Success)
			{
				ModelBase<PersonalModel>.Instance.SetHeadPhotoId(headPhotoId);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22077, null, true, true);
		}, 0);
	}

	// Token: 0x06011DBF RID: 73151 RVA: 0x004E9A40 File Offset: 0x004E7C40
	public UniTask<ErrorCode> RequestModifyName([Nullable(1)] string name)
	{
		PersonalController.<RequestModifyName>d__13 <RequestModifyName>d__;
		<RequestModifyName>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<RequestModifyName>d__.name = name;
		<RequestModifyName>d__.<>1__state = -1;
		<RequestModifyName>d__.<>t__builder.Start<PersonalController.<RequestModifyName>d__13>(ref <RequestModifyName>d__);
		return <RequestModifyName>d__.<>t__builder.Task;
	}

	// Token: 0x06011DC0 RID: 73152 RVA: 0x004E9A83 File Offset: 0x004E7C83
	public bool CheckCardIsUsing(int cardId)
	{
		return ModelBase<PersonalModel>.Instance.GetCurCardId() == cardId;
	}

	// Token: 0x06011DC1 RID: 73153 RVA: 0x004E9A94 File Offset: 0x004E7C94
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<UnlockCardNotify>(ENotifyMessageId.UnlockCardNotify, delegate(UnlockCardNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.AddCardUnlockList(notify.CardId, false);
		});
		Singleton<Net>.Instance.Register<HeadIdUpdateNotify>(ENotifyMessageId.HeadIdUpdateNotify, delegate(HeadIdUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.SetHeadPhotoId(notify.HeadId);
		});
		Singleton<Net>.Instance.Register<RoleShowListUpdateNotify>(ENotifyMessageId.RoleShowListUpdateNotify, delegate(RoleShowListUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.SetRoleShowList(notify.RoleShowList.ToList<Aki.Protocol.RoleShowEntry>());
		});
		Singleton<Net>.Instance.Register<SignatureUpdateNotify>(ENotifyMessageId.SignatureUpdateNotify, delegate(SignatureUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.SetSignature(notify.Signature);
		});
		Singleton<Net>.Instance.Register<NameModifyNotify>(ENotifyMessageId.NameModifyNotify, delegate(NameModifyNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PlayerInfoModel>.Instance.SetPlayerName(notify.Name);
			ModelBase<PersonalModel>.Instance.SetModifyNameInfo(notify.LastModifyNameTime, string.Empty);
		});
		Singleton<Net>.Instance.Register<PlayerHeadAddNotify>(ENotifyMessageId.PlayerHeadAddNotify, delegate(PlayerHeadAddNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.UpdatePlayerHeadData(notify.AddPlayerHeadIds.ToArray<int>());
		});
		Singleton<Net>.Instance.Register<DressPlayerTitleUpdateNotify>(ENotifyMessageId.DressPlayerTitleUpdateNotify, delegate(DressPlayerTitleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.SetDressedPlayerTitle(notify.PlayerTitleId, new int?(notify.PlayerTitleExtraParam));
		});
		Singleton<Net>.Instance.Register<PlayerTitleUpdateNotify>(ENotifyMessageId.PlayerTitleUpdateNotify, delegate(PlayerTitleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.UpdateUnDressedPlayerTitleList(notify.PlayerTitleInfos.ToArray<PlayerTitleInfo>());
		});
		Singleton<Net>.Instance.Register<PlayerTitleInfoUpdateNotify>(ENotifyMessageId.PlayerTitleInfoUpdateNotify, delegate(PlayerTitleInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<PersonalModel>.Instance.InitPlayerTitleData(notify.PlayerTitleInfo.ToArray<PlayerTitleInfo>(), notify.PlayerTitleLimitInfos.ToArray<PlayerTitleLimitInfo>());
		});
	}

	// Token: 0x06011DC2 RID: 73154 RVA: 0x004E9C48 File Offset: 0x004E7E48
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UnlockCardNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HeadIdUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleShowListUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SignatureUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NameModifyNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerHeadAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DressPlayerTitleUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerTitleUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerTitleInfoUpdateNotify);
	}

	// Token: 0x06011DC3 RID: 73155 RVA: 0x004E9CE5 File Offset: 0x004E7EE5
	private void OnFunctionOpenSet(EFunctionType id, bool isOpen)
	{
		this.PlayerTitleRequest(id, isOpen);
	}

	// Token: 0x06011DC4 RID: 73156 RVA: 0x004E9CF0 File Offset: 0x004E7EF0
	private void PlayerTitleRequest(EFunctionType id, bool isOpen)
	{
		if (id != EFunctionType.PlayerTitle)
		{
			return;
		}
		if (!isOpen)
		{
			return;
		}
		PlayerTitleRequest message = Aki.Protocol.PlayerTitleRequest.Create();
		Singleton<Net>.Instance.Call<PlayerTitleResponse>(ERequestMessageId.PlayerTitleRequest, message, delegate(PlayerTitleResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<PersonalModel>.Instance.InitPlayerTitleData(response.PlayerTitleInfo.ToArray<PlayerTitleInfo>(), response.PlayerTitleLimitInfos.ToArray<PlayerTitleLimitInfo>());
		}, 0);
	}

	// Token: 0x06011DC5 RID: 73157 RVA: 0x004E9D40 File Offset: 0x004E7F40
	public void SendChangePlayerTitleRequest(int playerTitleId)
	{
		ChangePlayerTitleRequest changePlayerTitleRequest = ChangePlayerTitleRequest.Create();
		changePlayerTitleRequest.PlayerTitleId = playerTitleId;
		Singleton<Net>.Instance.Call<ChangePlayerTitleResponse>(ERequestMessageId.ChangePlayerTitleRequest, changePlayerTitleRequest, delegate(ChangePlayerTitleResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25847, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06011DC6 RID: 73158 RVA: 0x004E9D8A File Offset: 0x004E7F8A
	private void ShowTitleGetView()
	{
		this.TryOpenTitleGetView();
	}

	// Token: 0x06011DC7 RID: 73159 RVA: 0x004E9D94 File Offset: 0x004E7F94
	public void TryOpenTitleGetView()
	{
		List<PersonalPlayerTitleData> currentNewUnLockTitleArray = ModelBase<PersonalModel>.Instance.CurrentNewUnLockTitleArray;
		while (currentNewUnLockTitleArray.Count > 0)
		{
			PersonalPlayerTitleData param = currentNewUnLockTitleArray[0];
			currentNewUnLockTitleArray.RemoveAt(0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalPlayerTitleUnLockTipsView, param, null);
		}
	}

	// Token: 0x06011DC8 RID: 73160 RVA: 0x004E9DD8 File Offset: 0x004E7FD8
	private void TsSyncHeadInfo(FArrayBuffer buffer)
	{
		PlayerHeadResponse playerHeadResponse = PlayerHeadResponse.Parser.ParseFrom(buffer.ToByteArray());
		if (playerHeadResponse == null)
		{
			return;
		}
		ModelBase<PersonalModel>.Instance.InitPlayerHeadData(playerHeadResponse.PlayerHeadIds.ToArray<int>());
	}
}
