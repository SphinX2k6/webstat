using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Friend;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CA2 RID: 7330
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FriendItem : GridProxyAbstract<FriendItemSt>
{
	// Token: 0x0600D6D7 RID: 54999 RVA: 0x003958F0 File Offset: 0x00393AF0
	public FriendItem(EUiViewName belongView, UUIItem uiItem = null)
	{
		this.BelongView = new EUiViewName?(belongView);
		ModelBase<FriendModel>.Instance.ShowingView = this.BelongView;
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600D6D8 RID: 55000 RVA: 0x00395944 File Offset: 0x00393B44
	protected unsafe override void OnRegisterComponent()
	{
		int num = 21;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickFriendItemBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D6D9 RID: 55001 RVA: 0x00395C6C File Offset: 0x00393E6C
	protected override UniTask OnBeforeStartAsync()
	{
		FriendItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FriendItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D6DA RID: 55002 RVA: 0x00395CB0 File Offset: 0x00393EB0
	protected override void OnStart()
	{
		this.ConfirmBtn = new ButtonAndTextItem(base.GetItem(11));
		this.TeamItem = new TeamItem(base.GetItem(10));
		this.ConfirmBtn.BindCallback(new Action(this.OnClickConfirmButton));
		this.HeadPhotoItem = new PlayerHeadItem(base.GetItem(0).GetOwner());
		List<UUIItem> list = new List<UUIItem>();
		list.Add(base.GetItem(6));
		list.Add(base.GetItem(7));
		list.Add(base.GetItem(14));
		list.Add(base.GetItem(15));
		list.Add(base.GetItem(16));
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			this.ButtonList.Add(new ButtonAndSpriteItem(list[i]));
		}
		this.ButtonInfoList.Add(new FunctionButtonInfo("SP_RefuseFriend", new Func<bool>(this.GetRefuseButtonState), new Action(this.OnClickRefuseBtn)));
		this.ButtonInfoList.Add(new FunctionButtonInfo("SP_RemoveFriend", new Func<bool>(this.GetRemoveButtonState), new Action(this.OnClickRemoveBtn)));
		this.ButtonInfoList.Add(new FunctionButtonInfo("SP_AddFriend", new Func<bool>(this.GetAddButtonState), new Action(this.OnClickAddBtn)));
		this.ButtonInfoList.Add(new FunctionButtonInfo("SP_AgreeFriend", new Func<bool>(this.GetAgreeButtonState), new Action(this.OnClickAgreeBtn)));
		this.ButtonInfoList.Add(new FunctionButtonInfo("SP_ChatFriend", new Func<bool>(this.GetChatButtonState), new Action(this.OnClickChatButton)));
	}

	// Token: 0x0600D6DB RID: 55003 RVA: 0x00395E66 File Offset: 0x00394066
	private void OnClickConfirmButton()
	{
		if (this.GetPlayerData().PlayerIsOnline && this.IfCanEnterOtherWorld())
		{
			ControllerBase<OnlineController>.Instance.ApplyJoinWorldRequest(this.GetPlayerData().PlayerId, WorldEnterWay.LobbyJoin);
		}
	}

	// Token: 0x0600D6DC RID: 55004 RVA: 0x00395E93 File Offset: 0x00394093
	[NullableContext(1)]
	public override void Refresh(FriendItemSt playerData, bool isSelected, int gridIndex)
	{
		this.UpdateItem(playerData.Id);
		if (playerData.OperationType == EFriendItemOperation.SendApply)
		{
			this.RefreshOnSent();
			return;
		}
		if (playerData.OperationType == EFriendItemOperation.Approve || playerData.OperationType == EFriendItemOperation.Refuse)
		{
			this.RefreshButtonList();
		}
	}

	// Token: 0x0600D6DD RID: 55005 RVA: 0x00395ECC File Offset: 0x003940CC
	public void RefreshMute()
	{
		bool uiactive = ModelBase<ChatModel>.Instance.IsInMute(this.GetPlayerData().PlayerId);
		base.GetItem(1).SetUIActive(uiactive);
	}

	// Token: 0x0600D6DE RID: 55006 RVA: 0x00395EFC File Offset: 0x003940FC
	private void UpdateItem(int playerDataId)
	{
		this.FriendInstanceId = playerDataId;
		FriendData playerData = this.GetPlayerData();
		this.ShowNecessaryItem();
		if (playerData != null)
		{
			this.HeadPhotoItem.RefreshByHeadPhotoId(playerData.PlayerHeadPhoto);
			base.GetText(3).SetText("Lv." + playerData.PlayerLevel.ToString(), true);
			if (this.IsInBlackList)
			{
				PlayerTitleItem titleItem = this.TitleItem;
				if (titleItem != null)
				{
					titleItem.GetRootItem().SetUIActive(false);
				}
			}
			else
			{
				PlayerTitleItem titleItem2 = this.TitleItem;
				if (titleItem2 != null)
				{
					titleItem2.Refresh(new int?(playerData.PlayerTitleId), new int?(playerData.PlayerTitleStarLevel), new int?(playerData.PlayerSex));
				}
			}
		}
		this.RefreshOnlineStateShow();
	}

	// Token: 0x0600D6DF RID: 55007 RVA: 0x00395FB4 File Offset: 0x003941B4
	private void ShowNecessaryItem()
	{
		this.RefreshMute();
		this.RefreshRedPoint();
		this.RefreshName();
		this.RefreshConfirmButtonText();
		this.RefreshConfirmButtonShowState();
		this.RefreshButtonList();
		this.RefreshTeamItem();
		this.RefreshPlayerSign();
		this.RefreshCurdCard();
		this.RefreshThirdPartyItem();
		this.RefreshPcItem();
	}

	// Token: 0x0600D6E0 RID: 55008 RVA: 0x00396003 File Offset: 0x00394203
	private void RefreshPlayerSign()
	{
		base.GetText(9).SetText(this.GetPlayerData().Signature, true);
		base.GetItem(13).SetUIActive(this.GetPlayerData().Signature.Length > 0);
	}

	// Token: 0x0600D6E1 RID: 55009 RVA: 0x00396040 File Offset: 0x00394240
	private void RefreshCurdCard()
	{
		int curCard = this.GetPlayerData().CurCard;
		if (curCard > 0)
		{
			base.SetTextureByPath(ConfigBackgroundCardById.GetConfig(curCard, true).Value.LongCardPath, base.GetTexture(8), null, null);
		}
	}

	// Token: 0x0600D6E2 RID: 55010 RVA: 0x0039608C File Offset: 0x0039428C
	private void RefreshTeamItem()
	{
		if (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() != EFriendFilter.RecentMultiple)
		{
			this.TeamItem.SetActive(false);
			return;
		}
		this.TeamItem.SetActive(true);
		this.TeamItem.RefreshView(this.GetPlayerData());
	}

	// Token: 0x0600D6E3 RID: 55011 RVA: 0x003960D8 File Offset: 0x003942D8
	[NullableContext(1)]
	private bool UpdateButton(ButtonAndSpriteItem button, FunctionButtonInfo buttonInfo)
	{
		if (buttonInfo.StateFunc())
		{
			button.RefreshSprite(buttonInfo.SpritePath);
			button.BindCallback(buttonInfo.CallBack);
			return true;
		}
		return false;
	}

	// Token: 0x0600D6E4 RID: 55012 RVA: 0x00396104 File Offset: 0x00394304
	private void RefreshButtonList()
	{
		for (int i = 0; i < this.ButtonList.Count; i++)
		{
			ButtonAndSpriteItem buttonAndSpriteItem = this.ButtonList[i];
			FunctionButtonInfo functionButtonInfo = this.ButtonInfoList[i];
			this.UpdateButton(buttonAndSpriteItem, functionButtonInfo);
			bool uiactive = functionButtonInfo.StateFunc();
			buttonAndSpriteItem.GetRootItem().SetUIActive(uiactive);
		}
	}

	// Token: 0x0600D6E5 RID: 55013 RVA: 0x00396162 File Offset: 0x00394362
	private bool GetChatButtonState()
	{
		return ModelBase<FriendModel>.Instance.IsMyFriend(this.GetPlayerData().PlayerId);
	}

	// Token: 0x0600D6E6 RID: 55014 RVA: 0x0039617C File Offset: 0x0039437C
	private bool GetRemoveButtonState()
	{
		return this.BelongView == EUiViewName.FriendBlackListView;
	}

	// Token: 0x0600D6E7 RID: 55015 RVA: 0x003961B0 File Offset: 0x003943B0
	private bool GetRefuseButtonState()
	{
		return (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.FriendRequest && this.BelongView == EUiViewName.FriendView) || (this.BelongView == EUiViewName.FriendSearchView && ModelBase<FriendModel>.Instance.HasFriendApplication(this.GetPlayerData().PlayerId));
	}

	// Token: 0x0600D6E8 RID: 55016 RVA: 0x00396240 File Offset: 0x00394440
	private bool GetAddButtonState()
	{
		return !ModelBase<FriendModel>.Instance.IsMyFriend(this.GetPlayerData().PlayerId) && !ModelBase<FriendModel>.Instance.HasFriendApplication(this.GetPlayerData().PlayerId) && (this.BelongView == EUiViewName.FriendSearchView || (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.RecentMultiple && this.BelongView == EUiViewName.FriendView));
	}

	// Token: 0x0600D6E9 RID: 55017 RVA: 0x003962EC File Offset: 0x003944EC
	private bool GetAgreeButtonState()
	{
		return (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.FriendRequest && this.BelongView == EUiViewName.FriendView) || (this.BelongView == EUiViewName.FriendSearchView && ModelBase<FriendModel>.Instance.HasFriendApplication(this.GetPlayerData().PlayerId));
	}

	// Token: 0x0600D6EA RID: 55018 RVA: 0x0039637C File Offset: 0x0039457C
	private void RefreshConfirmButtonShowState()
	{
		bool flag = false;
		if (this.BelongView == EUiViewName.FriendView && (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.FriendList || ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.RecentMultiple))
		{
			flag = true;
		}
		this.ConfirmBtn.SetActive(flag);
		if (flag)
		{
			this.RefreshConfirmButtonEnable();
		}
	}

	// Token: 0x0600D6EB RID: 55019 RVA: 0x003963F4 File Offset: 0x003945F4
	private void RefreshConfirmButtonEnable()
	{
		this.ConfirmBtn.RefreshEnable(this.GetPlayerData().PlayerIsOnline && this.IfCanEnterOtherWorld() && ModelBase<FunctionModel>.Instance.IsOpen(10021));
	}

	// Token: 0x0600D6EC RID: 55020 RVA: 0x00396428 File Offset: 0x00394628
	private void RefreshConfirmButtonText()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10021))
		{
			this.ConfirmBtn.RefreshText("FriendOnlineDisable", Array.Empty<object>());
			return;
		}
		if (!this.GetPlayerData().PlayerIsOnline)
		{
			this.ConfirmBtn.RefreshText("OfflineText", Array.Empty<object>());
			return;
		}
		if (!this.IfCanEnterOtherWorld())
		{
			this.ConfirmBtn.RefreshText("ApplyBtnDisable", new object[]
			{
				this.GetPlayerData().WorldLevel - ModelBase<OnlineModel>.Instance.EnterDiff
			});
			return;
		}
		this.ConfirmBtn.RefreshText("FriendApplyJoin", Array.Empty<object>());
	}

	// Token: 0x0600D6ED RID: 55021 RVA: 0x003964D1 File Offset: 0x003946D1
	private bool IfCanEnterOtherWorld()
	{
		return ModelBase<OnlineModel>.Instance.CanJoinOtherWorld(ModelBase<WorldLevelModel>.Instance.OriginWorldLevel, this.GetPlayerData().WorldLevel);
	}

	// Token: 0x0600D6EE RID: 55022 RVA: 0x003964F4 File Offset: 0x003946F4
	private void RefreshName()
	{
		UUIText text = base.GetText(2);
		FriendController instance = ControllerBase<FriendController>.Instance;
		FriendData playerData = this.GetPlayerData();
		if (instance.CheckRemarkIsValid(((playerData != null) ? playerData.FriendRemark : null) ?? ""))
		{
			text.SetText("(" + this.GetPlayerData().FriendRemark + ")", true);
			return;
		}
		UUIText uuitext = text;
		FriendData playerData2 = this.GetPlayerData();
		uuitext.SetText(((playerData2 != null) ? playerData2.PlayerName : null) ?? "", true);
	}

	// Token: 0x0600D6EF RID: 55023 RVA: 0x00396574 File Offset: 0x00394774
	private void RefreshRedPoint()
	{
	}

	// Token: 0x0600D6F0 RID: 55024 RVA: 0x00396578 File Offset: 0x00394778
	private void RefreshOnlineStateShow()
	{
		bool playerIsOnline = this.GetPlayerData().PlayerIsOnline;
		UUIText text = base.GetText(5);
		if (this.BelongView == EUiViewName.FriendBlackListView)
		{
			text.SetText("", true);
		}
		else if (playerIsOnline)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "FriendOnline", Array.Empty<object>());
		}
		else
		{
			FriendData playerData = this.GetPlayerData();
			if (playerData.PlayerLastOfflineTime == 0L)
			{
				text.SetText("", true);
			}
			else
			{
				ValueTuple<string, int> offlineStrAndGap = FriendModel.GetOfflineStrAndGap(playerData.PlayerLastOfflineTime);
				Singleton<LguiUtil>.Instance.SetLocalText(text, offlineStrAndGap.Item1, new <>z__ReadOnlySingleElementList<object>(offlineStrAndGap.Item2));
			}
		}
		base.GetText(2).useChangeColor = !playerIsOnline;
		base.GetText(3).useChangeColor = !playerIsOnline;
		text.useChangeColor = !playerIsOnline;
		this.RefreshOnLinePoint();
	}

	// Token: 0x0600D6F1 RID: 55025 RVA: 0x0039666C File Offset: 0x0039486C
	private void RefreshOnLinePoint()
	{
		UUISprite sprite = base.GetSprite(4);
		bool uiactive = true;
		string text = null;
		if (this.BelongView == EUiViewName.FriendBlackListView)
		{
			uiactive = false;
		}
		else if (this.GetPlayerData().PlayerIsOnline)
		{
			text = "SP_FriendOnline";
		}
		else
		{
			text = "SP_FriendOffline";
		}
		sprite.SetUIActive(uiactive);
		if (!string.IsNullOrEmpty(text))
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}
	}

	// Token: 0x0600D6F2 RID: 55026 RVA: 0x003966FE File Offset: 0x003948FE
	private FriendData GetPlayerData()
	{
		return ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), this.BelongView);
	}

	// Token: 0x0600D6F3 RID: 55027 RVA: 0x0039671C File Offset: 0x0039491C
	private void OnClickRefuseBtn()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), null);
		if (selectedPlayerOrItemInstance != null && selectedPlayerOrItemInstance.Debug)
		{
			return;
		}
		FriendData playerData = this.GetPlayerData();
		if (playerData != null)
		{
			this.RequestSendIdList = new List<int>();
			this.RequestSendIdList.Add(playerData.PlayerId);
			ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(this.RequestSendIdList, FriendApplyOperator.Reject);
			return;
		}
		ControllerBase<FriendController>.Instance.LocalRemoveApplicationFriend(this.FriendInstanceId);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendRequestOutOfDate", Array.Empty<object>());
	}

	// Token: 0x0600D6F4 RID: 55028 RVA: 0x003967B4 File Offset: 0x003949B4
	private void OnClickAgreeBtn()
	{
		FriendData playerData = this.GetPlayerData();
		if (ModelBase<FriendModel>.Instance.HasFriend(this.FriendInstanceId))
		{
			ControllerBase<FriendController>.Instance.LocalRemoveApplicationFriend(this.FriendInstanceId);
			if (playerData != null)
			{
				Singleton<EventSystem>.Instance.Emit<EFriendItemOperation, IReadOnlyList<int>>(EEventName.ApplicationHandled, EFriendItemOperation.Approve, new <>z__ReadOnlySingleElementList<int>(playerData.PlayerId));
			}
		}
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), null);
		if (selectedPlayerOrItemInstance != null && selectedPlayerOrItemInstance.Debug)
		{
			return;
		}
		if (playerData == null)
		{
			ControllerBase<FriendController>.Instance.LocalRemoveApplicationFriend(this.FriendInstanceId);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendRequestOutOfDate", Array.Empty<object>());
			return;
		}
		int friendListCount = ModelBase<FriendModel>.Instance.GetFriendListCount();
		int friendLimitByViewType = ConfigBase<FriendConfig>.Instance.GetFriendLimitByViewType(EFriendFilter.FriendList);
		if (friendListCount + 1 > friendLimitByViewType)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendListFull", Array.Empty<object>());
			return;
		}
		this.RequestSendIdList = new List<int>();
		this.RequestSendIdList.Add(playerData.PlayerId);
		ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(this.RequestSendIdList, FriendApplyOperator.Approve);
	}

	// Token: 0x0600D6F5 RID: 55029 RVA: 0x003968BC File Offset: 0x00394ABC
	private void OnClickAddBtn()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), null);
		if (selectedPlayerOrItemInstance != null && selectedPlayerOrItemInstance.Debug)
		{
			return;
		}
		FriendApplyWay fromWhere = FriendApplyWay.Search;
		if (this.BelongView == EUiViewName.FriendView && ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.RecentMultiple)
		{
			fromWhere = FriendApplyWay.RecentlyTeam;
		}
		FriendData playerData = this.GetPlayerData();
		if (playerData != null)
		{
			int friendListCount = ModelBase<FriendModel>.Instance.GetFriendListCount();
			int friendLimitByViewType = ConfigBase<FriendConfig>.Instance.GetFriendLimitByViewType(EFriendFilter.FriendList);
			if (friendListCount + 1 > friendLimitByViewType)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendListFull", Array.Empty<object>());
				return;
			}
			ControllerBase<FriendController>.Instance.RequestFriendApplyAddSend(playerData.PlayerId, fromWhere);
		}
	}

	// Token: 0x0600D6F6 RID: 55030 RVA: 0x00396988 File Offset: 0x00394B88
	private void OnClickRemoveBtn()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), null);
		if (selectedPlayerOrItemInstance != null && selectedPlayerOrItemInstance.Debug)
		{
			return;
		}
		FriendData playerData = this.GetPlayerData();
		if (playerData != null)
		{
			ControllerBase<FriendController>.Instance.RequestUnBlockPlayer(playerData.PlayerId);
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsNotBlockedPlayer", Array.Empty<object>());
	}

	// Token: 0x0600D6F7 RID: 55031 RVA: 0x003969F4 File Offset: 0x00394BF4
	private void OnClickChatButton()
	{
		FriendData playerData = this.GetPlayerData();
		if (playerData == null)
		{
			return;
		}
		ControllerBase<ChatController>.Instance.OpenFriendChat(playerData.PlayerId);
	}

	// Token: 0x0600D6F8 RID: 55032 RVA: 0x00396A1C File Offset: 0x00394C1C
	private void RefreshPcItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			FriendData playerData = this.GetPlayerData();
			if (((playerData != null) ? playerData.GetSdkUserId() : null) != "")
			{
				UUIItem item = base.GetItem(19);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(19);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
				return;
			}
		}
		else
		{
			UUIItem item3 = base.GetItem(19);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600D6F9 RID: 55033 RVA: 0x00396A90 File Offset: 0x00394C90
	private void RefreshThirdPartyItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			FriendData playerData = this.GetPlayerData();
			bool flag = ((playerData != null) ? playerData.GetSdkUserId() : null) != "";
			UUITexture texture = base.GetTexture(17);
			if (texture != null)
			{
				texture.SetUIActive(flag);
			}
			UUIText text = base.GetText(18);
			if (text != null)
			{
				text.SetUIActive(flag);
			}
			if (flag)
			{
				FriendData playerData2 = this.GetPlayerData();
				string newText = ((playerData2 != null) ? playerData2.GetSdkOnlineId() : null) ?? "";
				UUIText text2 = base.GetText(18);
				if (text2 != null)
				{
					text2.SetText(newText, true);
				}
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(17), null, null);
			string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set2);
			UUIText text3 = base.GetText(18);
			if (text3 == null)
			{
				return;
			}
			text3.SetColor(FColor.FromHex(thirdPartyTextColor));
			return;
		}
		else
		{
			UUITexture texture2 = base.GetTexture(17);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIText text4 = base.GetText(18);
			if (text4 == null)
			{
				return;
			}
			text4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600D6FA RID: 55034 RVA: 0x00396B98 File Offset: 0x00394D98
	private void OnClickFriendItemBtn()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(new int?(this.FriendInstanceId), null);
		if (selectedPlayerOrItemInstance != null && selectedPlayerOrItemInstance.Debug)
		{
			return;
		}
		FriendData playerData = this.GetPlayerData();
		if (playerData == null)
		{
			this.ShowFindNullFriendTipsByViewType();
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
			return;
		}
		int playerId = playerData.PlayerId;
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
			ModelBase<FriendModel>.Instance.SelectedPlayerId = new int?(this.FriendInstanceId);
			ModelBase<FriendModel>.Instance.SetCurrentOperationPlayerId(this.FriendInstanceId);
			ModelBase<FriendModel>.Instance.ShowingView = this.BelongView;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendProcessView, null, null);
		});
	}

	// Token: 0x0600D6FB RID: 55035 RVA: 0x00396C14 File Offset: 0x00394E14
	private void ShowFindNullFriendTipsByViewType()
	{
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		if (filterState.GetValueOrDefault() == EFriendFilter.FriendList)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendDeleteEach", Array.Empty<object>());
			return;
		}
		if (filterState.GetValueOrDefault() == EFriendFilter.FriendRequest)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FriendRequestOutOfDate", Array.Empty<object>());
		}
	}

	// Token: 0x0600D6FC RID: 55036 RVA: 0x00396C69 File Offset: 0x00394E69
	private void RefreshOnSent()
	{
		if (ModelBase<FriendModel>.Instance.CurrentApplyFriendListHasPlayer(this.FriendInstanceId))
		{
			this.RefreshButtonList();
		}
	}

	// Token: 0x0600D6FD RID: 55037 RVA: 0x00396C83 File Offset: 0x00394E83
	public void SetIsInBlackList(bool isInBlackList)
	{
		this.IsInBlackList = isInBlackList;
	}

	// Token: 0x040065E4 RID: 26084
	private ButtonAndTextItem ConfirmBtn;

	// Token: 0x040065E5 RID: 26085
	private TeamItem TeamItem;

	// Token: 0x040065E6 RID: 26086
	protected int FriendInstanceId;

	// Token: 0x040065E7 RID: 26087
	protected EUiViewName? BelongView;

	// Token: 0x040065E8 RID: 26088
	private List<int> RequestSendIdList;

	// Token: 0x040065E9 RID: 26089
	private PlayerHeadItem HeadPhotoItem;

	// Token: 0x040065EA RID: 26090
	private PlayerTitleItem TitleItem;

	// Token: 0x040065EB RID: 26091
	[Nullable(1)]
	private readonly List<ButtonAndSpriteItem> ButtonList = new List<ButtonAndSpriteItem>();

	// Token: 0x040065EC RID: 26092
	[Nullable(1)]
	private readonly List<FunctionButtonInfo> ButtonInfoList = new List<FunctionButtonInfo>();

	// Token: 0x040065ED RID: 26093
	private bool IsInBlackList;

	// Token: 0x02007FF6 RID: 32758
	[NullableContext(0)]
	private class EItemComponents
	{
		// Token: 0x0402B8A4 RID: 178340
		public const int HeadPhotoItem = 0;

		// Token: 0x0402B8A5 RID: 178341
		public const int ShieldNode = 1;

		// Token: 0x0402B8A6 RID: 178342
		public const int NameText = 2;

		// Token: 0x0402B8A7 RID: 178343
		public const int LevelText = 3;

		// Token: 0x0402B8A8 RID: 178344
		public const int OnlineStateSprite = 4;

		// Token: 0x0402B8A9 RID: 178345
		public const int OnlineStateText = 5;

		// Token: 0x0402B8AA RID: 178346
		public const int FirstButtonItem = 6;

		// Token: 0x0402B8AB RID: 178347
		public const int SecondButtonItem = 7;

		// Token: 0x0402B8AC RID: 178348
		public const int PlayerTextureBg = 8;

		// Token: 0x0402B8AD RID: 178349
		public const int PlayerSignText = 9;

		// Token: 0x0402B8AE RID: 178350
		public const int TeamItem = 10;

		// Token: 0x0402B8AF RID: 178351
		public const int ConfirmBtnItem = 11;

		// Token: 0x0402B8B0 RID: 178352
		public const int FriendItemButton = 12;

		// Token: 0x0402B8B1 RID: 178353
		public const int SignItem = 13;

		// Token: 0x0402B8B2 RID: 178354
		public const int ThirdButtonItem = 14;

		// Token: 0x0402B8B3 RID: 178355
		public const int ForthButtonItem = 15;

		// Token: 0x0402B8B4 RID: 178356
		public const int FifthButtonItem = 16;

		// Token: 0x0402B8B5 RID: 178357
		public const int ThirdPartyTexture = 17;

		// Token: 0x0402B8B6 RID: 178358
		public const int ThirdPartyText = 18;

		// Token: 0x0402B8B7 RID: 178359
		public const int PcItem = 19;

		// Token: 0x0402B8B8 RID: 178360
		public const int PlayerTitleItem = 20;
	}
}
