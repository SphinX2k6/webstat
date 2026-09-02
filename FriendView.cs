using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CA7 RID: 7335
[NullableContext(1)]
[Nullable(0)]
public class FriendView : UiViewBase
{
	// Token: 0x0600D73F RID: 55103 RVA: 0x00398B33 File Offset: 0x00396D33
	public FriendView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D740 RID: 55104 RVA: 0x00398B48 File Offset: 0x00396D48
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickCopyUid));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action<EToggleState>(this.OnClickSwitchToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D741 RID: 55105 RVA: 0x00398D64 File Offset: 0x00396F64
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Add(EEventName.FriendApplicationListUpdate, new Action(this.CallBackFriendApplyListUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateRecentlyTeamDataEvent, new Action(this.RefreshRecentlyTeamView));
	}

	// Token: 0x0600D742 RID: 55106 RVA: 0x00398E00 File Offset: 0x00397000
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.FriendApplicationListUpdate, new Action(this.CallBackFriendApplyListUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateRecentlyTeamDataEvent, new Action(this.RefreshRecentlyTeamView));
	}

	// Token: 0x0600D743 RID: 55107 RVA: 0x00398E9C File Offset: 0x0039709C
	protected override UniTask OnBeforeStartAsync()
	{
		FriendView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FriendView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D744 RID: 55108 RVA: 0x00398EDF File Offset: 0x003970DF
	protected override void OnBeforeShow()
	{
		this.RefreshShow();
	}

	// Token: 0x0600D745 RID: 55109 RVA: 0x00398EE8 File Offset: 0x003970E8
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		this.FilterConfigList.Clear();
		if (this.FriendScrollListLayout != null)
		{
			this.FriendScrollListLayout = null;
		}
		ModelBase<FriendModel>.Instance.Clear();
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
		ModelBase<FriendModel>.Instance.ClearTestFriendData();
	}

	// Token: 0x0600D746 RID: 55110 RVA: 0x00398F4F File Offset: 0x0039714F
	private FriendItem CreateFriendItem()
	{
		return new FriendItem(this.ViewInfo.Name, null);
	}

	// Token: 0x0600D747 RID: 55111 RVA: 0x00398F64 File Offset: 0x00397164
	private UniTask InitFilter()
	{
		FriendView.<InitFilter>d__20 <InitFilter>d__;
		<InitFilter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitFilter>d__.<>4__this = this;
		<InitFilter>d__.<>1__state = -1;
		<InitFilter>d__.<>t__builder.Start<FriendView.<InitFilter>d__20>(ref <InitFilter>d__);
		return <InitFilter>d__.<>t__builder.Task;
	}

	// Token: 0x0600D748 RID: 55112 RVA: 0x00398FA7 File Offset: 0x003971A7
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600D749 RID: 55113 RVA: 0x00398FB0 File Offset: 0x003971B0
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600D74A RID: 55114 RVA: 0x00398FB8 File Offset: 0x003971B8
	private void ToggleCallBack(int index)
	{
		FriendFilter friendFilter = this.FilterConfigList[index];
		ModelBase<FriendModel>.Instance.FilterState = new EFriendFilter?((EFriendFilter)friendFilter.Id);
		this.RefreshShow();
	}

	// Token: 0x0600D74B RID: 55115 RVA: 0x00398FF0 File Offset: 0x003971F0
	private CommonTabData GetCommonData(int index)
	{
		FriendFilter friendFilter = this.FilterConfigList[index];
		string textId = null;
		if (friendFilter.Id == 1)
		{
			textId = ConfigBase<TextConfig>.Instance.GetTextContentIdById("FriendFriend");
		}
		else if (friendFilter.Id == 2)
		{
			textId = ConfigBase<TextConfig>.Instance.GetTextContentIdById("FriendApplicationList");
		}
		else if (friendFilter.Id == 3)
		{
			textId = ConfigBase<TextConfig>.Instance.GetTextContentIdById("FriendRecentMultiplayerGame");
		}
		return new CommonTabData(friendFilter.IconPath, new CommonTabTitleData(textId, Array.Empty<object>()), null);
	}

	// Token: 0x0600D74C RID: 55116 RVA: 0x00399078 File Offset: 0x00397278
	private void RefreshShow()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		this.ShowCurrentStateNecessaryItem();
		EFriendFilter? filterState = instance.FilterState;
		if (filterState != null)
		{
			switch (filterState.GetValueOrDefault())
			{
			case EFriendFilter.FriendList:
				this.PlayerSortedIdList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(instance.GetFriendSortedListIds(), EFriendItemOperation.Default);
				this.RefreshScroller(this.PlayerSortedIdList);
				this.ConfirmButtonItem.SetEnableClick(true);
				this.CancelButtonItem.SetEnableClick(true);
				this.ShowFriendsCount();
				break;
			case EFriendFilter.FriendRequest:
				this.PlayerSortedIdList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(instance.GetFriendApplyListIds(), EFriendItemOperation.Default);
				this.FriendApplicationItemList = this.PlayerSortedIdList;
				this.RefreshScroller(this.PlayerSortedIdList);
				this.ConfirmButtonItem.SetEnableClick(this.PlayerSortedIdList.Count > 0);
				this.CancelButtonItem.SetEnableClick(this.PlayerSortedIdList.Count > 0);
				ModelBase<FriendModel>.Instance.MarkDirtyNewApplications();
				this.ShowFriendsCount();
				break;
			case EFriendFilter.RecentMultiple:
			{
				UUIItem friendScrollView = this.FriendScrollView;
				if (friendScrollView != null)
				{
					friendScrollView.SetUIActive(false);
				}
				ControllerBase<FriendController>.Instance.RequestFriendRecentlyTeam();
				break;
			}
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(8), "FriendMyUid", new <>z__ReadOnlySingleElementList<object>(ModelBase<PlayerInfoModel>.Instance.GetId().ToString()));
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshFriendApplicationRedDot);
	}

	// Token: 0x0600D74D RID: 55117 RVA: 0x003991E0 File Offset: 0x003973E0
	private void RefreshBtnShowState()
	{
		bool active = false;
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		if (filterState != null)
		{
			EFriendFilter valueOrDefault = filterState.GetValueOrDefault();
			if (valueOrDefault != EFriendFilter.FriendList)
			{
				if (valueOrDefault == EFriendFilter.FriendRequest)
				{
					active = true;
					this.ConfirmButtonItem.SetLocalText("FriendAllAccept", Array.Empty<object>());
					this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnClickAllAcceptBtn));
					this.CancelButtonItem.SetLocalText("FriendAllIgnore", Array.Empty<object>());
					this.CancelButtonItem.SetFunction(new Action<int>(this.OnClickAllIgnoreBtn));
				}
			}
			else
			{
				active = true;
				this.ConfirmButtonItem.SetLocalText("FriendAddFriend", Array.Empty<object>());
				this.ConfirmButtonItem.SetFunction(new Action<int>(this.OnClickAddFriendBtn));
				this.CancelButtonItem.SetLocalText("FriendBlackList", Array.Empty<object>());
				this.CancelButtonItem.SetFunction(new Action<int>(this.OnClickBlackListBtn));
			}
		}
		this.ConfirmButtonItem.SetActive(active);
		this.CancelButtonItem.SetActive(active);
	}

	// Token: 0x0600D74E RID: 55118 RVA: 0x003992EC File Offset: 0x003974EC
	private void ShowCurrentStateNecessaryItem()
	{
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		string textTableId = "FriendNotAvailableFriend";
		if (filterState != null)
		{
			switch (filterState.GetValueOrDefault())
			{
			case EFriendFilter.FriendRequest:
				textTableId = "FriendNotAvailableFriendApplication";
				break;
			case EFriendFilter.RecentMultiple:
				textTableId = "FriendNotAvailableRecentTeammate";
				break;
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), textTableId, Array.Empty<object>());
		this.RefreshBtnShowState();
	}

	// Token: 0x0600D74F RID: 55119 RVA: 0x0039935C File Offset: 0x0039755C
	private void ShowFriendsCount()
	{
		int friendLimitByViewType = ConfigBase<FriendConfig>.Instance.GetFriendLimitByViewType(ModelBase<FriendModel>.Instance.FilterState.Value);
		UUIText text = base.GetText(1);
		int count = this.PlayerSortedIdList.Count;
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		string textTableId = "FriendCount";
		if (filterState != null)
		{
			switch (filterState.GetValueOrDefault())
			{
			case EFriendFilter.FriendRequest:
				textTableId = "FriendApplicationCount";
				break;
			case EFriendFilter.RecentMultiple:
				textTableId = "FriendMultiplayerCount";
				break;
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId, new <>z__ReadOnlyArray<object>(new object[]
		{
			count,
			friendLimitByViewType
		}));
		base.GetItem(4).SetUIActive(count <= 0);
	}

	// Token: 0x0600D750 RID: 55120 RVA: 0x00399424 File Offset: 0x00397624
	private void OnClickAddFriendBtn(int num)
	{
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		UiPopViewData param = new UiPopViewData();
		if (filterState != null)
		{
			EFriendFilter valueOrDefault = filterState.GetValueOrDefault();
			if (valueOrDefault != EFriendFilter.FriendList)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendSearchView, param, null);
		}
	}

	// Token: 0x0600D751 RID: 55121 RVA: 0x00399470 File Offset: 0x00397670
	private void OnClickAllAcceptBtn(int num)
	{
		this.ConfirmButtonItem.GetRootItem().SetRaycastTarget(false);
		if (this.AllAgreeButtonMaskTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.AllAgreeButtonMaskTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AllAgreeButtonMaskTimerId);
		}
		this.AllAgreeButtonMaskTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float deltaTime)
		{
			this.ConfirmButtonItem.GetRootItem().SetRaycastTarget(true);
		}, 20f, null, null, true, 1f);
		this.RequestSendIdList = new List<int>();
		foreach (FriendItemSt friendItemSt in this.FriendApplicationItemList)
		{
			FriendData friendDataInApplicationById = ModelBase<FriendModel>.Instance.GetFriendDataInApplicationById(friendItemSt.Id);
			if (friendDataInApplicationById != null && (friendDataInApplicationById == null || !friendDataInApplicationById.Debug))
			{
				this.RequestSendIdList.Add(friendItemSt.Id);
			}
		}
		ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(this.RequestSendIdList, FriendApplyOperator.Approve);
	}

	// Token: 0x0600D752 RID: 55122 RVA: 0x00399570 File Offset: 0x00397770
	private void OnClickAllIgnoreBtn(int num)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.IgnoreAllFriendApplication);
		this.CancelButtonItem.GetRootItem().SetRaycastTarget(false);
		if (this.AllIgnoreButtonMaskTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.AllIgnoreButtonMaskTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AllIgnoreButtonMaskTimerId);
		}
		this.AllIgnoreButtonMaskTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float deltaTime)
		{
			this.CancelButtonItem.GetRootItem().SetRaycastTarget(true);
		}, 20f, null, null, true, 1f);
		this.RequestSendIdList = new List<int>();
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			foreach (FriendItemSt friendItemSt in this.FriendApplicationItemList)
			{
				FriendData friendDataInApplicationById = ModelBase<FriendModel>.Instance.GetFriendDataInApplicationById(friendItemSt.Id);
				if (friendDataInApplicationById == null || !friendDataInApplicationById.Debug)
				{
					this.RequestSendIdList.Add(friendItemSt.Id);
				}
			}
			ControllerBase<FriendController>.Instance.RequestFriendApplyHandle(this.RequestSendIdList, FriendApplyOperator.Reject);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D753 RID: 55123 RVA: 0x0039961C File Offset: 0x0039781C
	private void OnClickBlackListBtn(int num)
	{
		EFriendFilter? filterState = ModelBase<FriendModel>.Instance.FilterState;
		UiPopViewData param = new UiPopViewData();
		if (filterState != null)
		{
			EFriendFilter valueOrDefault = filterState.GetValueOrDefault();
			if (valueOrDefault != EFriendFilter.FriendList)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendBlackListView, param, null);
		}
	}

	// Token: 0x0600D754 RID: 55124 RVA: 0x00399668 File Offset: 0x00397868
	private void OnClickCopyUid()
	{
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CopiedMyUid", Array.Empty<object>());
		ULGUIBPLibrary.ClipBoardCopy(ModelBase<PlayerInfoModel>.Instance.GetId().ToString());
	}

	// Token: 0x0600D755 RID: 55125 RVA: 0x003996A6 File Offset: 0x003978A6
	private void CallBackUpdateFriendViewShow()
	{
		this.RefreshShow();
	}

	// Token: 0x0600D756 RID: 55126 RVA: 0x003996B0 File Offset: 0x003978B0
	private void CallBackFriendApplyListUpdate()
	{
		if (ModelBase<FriendModel>.Instance.FilterState.GetValueOrDefault() == EFriendFilter.FriendRequest)
		{
			this.RefreshShow();
		}
	}

	// Token: 0x0600D757 RID: 55127 RVA: 0x003996D8 File Offset: 0x003978D8
	private void RefreshItemMuteState(int playerId)
	{
		int i = 0;
		while (i < this.PlayerSortedIdList.Count)
		{
			if (this.PlayerSortedIdList[i].Id == playerId)
			{
				FriendItem friendItem = this.FriendScrollListLayout.UnsafeGetGridProxy(i, false);
				if (friendItem == null)
				{
					return;
				}
				friendItem.RefreshMute();
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600D758 RID: 55128 RVA: 0x00399728 File Offset: 0x00397928
	private void RefreshScroller(List<FriendItemSt> friendData)
	{
		if (this.FriendScrollListLayout != null && friendData.Count > 0)
		{
			UUIItem friendScrollView = this.FriendScrollView;
			if (friendScrollView != null)
			{
				friendScrollView.SetUIActive(true);
			}
			this.FriendScrollListLayout.RefreshByData(friendData, false, null, false);
			return;
		}
		UUIItem friendScrollView2 = this.FriendScrollView;
		if (friendScrollView2 == null)
		{
			return;
		}
		friendScrollView2.SetUIActive(false);
	}

	// Token: 0x0600D759 RID: 55129 RVA: 0x00399779 File Offset: 0x00397979
	private void RefreshRecentlyTeamView()
	{
		this.PlayerSortedIdList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(ModelBase<FriendModel>.Instance.GetRecentlyTeamIds(), EFriendItemOperation.Default);
		this.RefreshScroller(this.PlayerSortedIdList);
		this.ShowFriendsCount();
	}

	// Token: 0x0600D75A RID: 55130 RVA: 0x003997A8 File Offset: 0x003979A8
	private void OnClickSwitchToggle(EToggleState toggleState)
	{
		bool state = !ControllerBase<KuroSdkController>.Instance.GetSdkFriendOnlyState();
		ControllerBase<KuroSdkController>.Instance.SaveSdkFriendOnlyState(state);
		this.RefreshShow();
	}

	// Token: 0x0600D75B RID: 55131 RVA: 0x003997D4 File Offset: 0x003979D4
	private void RefreshPlayStationShowToggle()
	{
		if (ControllerBase<KuroSdkController>.Instance.SupportSwitchFriendShowType())
		{
			base.GetExtendToggle(10).RootUIComp.Get().SetUIActive(true);
			base.GetText(11).SetUIActive(true);
			if (Singleton<Info>.Instance.IsPs5Platform())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "PlatformFriendOnly_PlayStation", Array.Empty<object>());
			}
			else if (Singleton<Info>.Instance.IsXboxPlatform())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "PlatformFriendOnly_Xbox", Array.Empty<object>());
			}
			this.RefreshToggleBySelectState();
			return;
		}
		base.GetExtendToggle(10).RootUIComp.Get().SetUIActive(false);
		base.GetText(11).SetUIActive(false);
	}

	// Token: 0x0600D75C RID: 55132 RVA: 0x0039989C File Offset: 0x00397A9C
	private void RefreshToggleBySelectState()
	{
		EToggleState state = ControllerBase<KuroSdkController>.Instance.GetSdkFriendOnlyState() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(10).SetToggleState(state, false, false, false);
	}

	// Token: 0x04006600 RID: 26112
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FriendItemSt> PlayerSortedIdList;

	// Token: 0x04006601 RID: 26113
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<FriendItem, FriendItemSt> FriendScrollListLayout;

	// Token: 0x04006602 RID: 26114
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<FriendItemSt> FriendApplicationItemList;

	// Token: 0x04006603 RID: 26115
	[Nullable(2)]
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04006604 RID: 26116
	[Nullable(2)]
	private ButtonItem CancelButtonItem;

	// Token: 0x04006605 RID: 26117
	[Nullable(2)]
	private TimerHandle AllAgreeButtonMaskTimerId;

	// Token: 0x04006606 RID: 26118
	[Nullable(2)]
	private TimerHandle AllIgnoreButtonMaskTimerId;

	// Token: 0x04006607 RID: 26119
	[Nullable(2)]
	private List<int> RequestSendIdList;

	// Token: 0x04006608 RID: 26120
	private List<FriendFilter> FilterConfigList = new List<FriendFilter>();

	// Token: 0x04006609 RID: 26121
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x0400660A RID: 26122
	[Nullable(2)]
	private UUIItem FriendScrollView;

	// Token: 0x02008000 RID: 32768
	[NullableContext(0)]
	private class EFriendViewComponents
	{
		// Token: 0x0402B8F1 RID: 178417
		public const int TabComponent = 0;

		// Token: 0x0402B8F2 RID: 178418
		public const int FriendCountText = 1;

		// Token: 0x0402B8F3 RID: 178419
		public const int FriendScrollView = 2;

		// Token: 0x0402B8F4 RID: 178420
		public const int FriendItemModel = 3;

		// Token: 0x0402B8F5 RID: 178421
		public const int FriendListEmptyBox = 4;

		// Token: 0x0402B8F6 RID: 178422
		public const int EmptyText = 5;

		// Token: 0x0402B8F7 RID: 178423
		public const int ConfirmBtnItem = 6;

		// Token: 0x0402B8F8 RID: 178424
		public const int CancelBtnItem = 7;

		// Token: 0x0402B8F9 RID: 178425
		public const int MyUIDText = 8;

		// Token: 0x0402B8FA RID: 178426
		public const int CopyUIDBtn = 9;

		// Token: 0x0402B8FB RID: 178427
		public const int SwitchPlayStationShowToggle = 10;

		// Token: 0x0402B8FC RID: 178428
		public const int SwitchPlayStationShowToggleText = 11;
	}
}
