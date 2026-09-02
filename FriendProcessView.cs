using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CA5 RID: 7333
[NullableContext(2)]
[Nullable(0)]
public class FriendProcessView : UiViewBase
{
	// Token: 0x0600D712 RID: 55058 RVA: 0x0039725B File Offset: 0x0039545B
	[NullableContext(1)]
	public FriendProcessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D713 RID: 55059 RVA: 0x00397264 File Offset: 0x00395464
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickChatBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnClickXboxButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D714 RID: 55060 RVA: 0x0039756C File Offset: 0x0039576C
	private void OnClickXboxButton()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
		if (selectedPlayerOrItemInstance == null)
		{
			return;
		}
		ControllerBase<KuroSdkController>.Instance.OpenProfileCard(selectedPlayerOrItemInstance.GetSdkUserId());
	}

	// Token: 0x0600D715 RID: 55061 RVA: 0x003975AC File Offset: 0x003957AC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBlackListShow, new Action(this.RefreshBlackBtn));
	}

	// Token: 0x0600D716 RID: 55062 RVA: 0x0039762C File Offset: 0x0039582C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBlackListShow, new Action(this.RefreshBlackBtn));
	}

	// Token: 0x0600D717 RID: 55063 RVA: 0x003976AC File Offset: 0x003958AC
	protected override UniTask OnBeforeStartAsync()
	{
		FriendProcessView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FriendProcessView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D718 RID: 55064 RVA: 0x003976F0 File Offset: 0x003958F0
	protected override void OnStart()
	{
		this.HeadPhotoItem = new PlayerHeadItem(base.GetItem(0).GetOwner());
		base.GetText(4).SetText("", true);
		this.RefreshPersonalOptionItemLayout();
		FriendModel instance = ModelBase<FriendModel>.Instance;
		FriendData selectedPlayerOrItemInstance = instance.GetSelectedPlayerOrItemInstance(null, null);
		instance.CachePlayerData = selectedPlayerOrItemInstance;
		Singleton<EventSystem>.Instance.Emit(EEventName.CsSyncCachePlayerData);
		this.UpdatePlayerDataShow();
	}

	// Token: 0x0600D719 RID: 55065 RVA: 0x00397768 File Offset: 0x00395968
	private void RefreshPersonalOptionItemLayout()
	{
		if (this.PersonalOptionItemLayout != null)
		{
			this.PersonalOptionItemLayout.ClearChildren();
		}
		this.PersonalOptionItemLayout = new GenericLayoutNew<PersonalOptionItem>(base.GetGridLayout(9), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PersonalOptionItem>(this.InitPersonalOptionItem), null);
		this.PersonalOptionItemLayout.RebuildLayoutByDataNew<int>(this.GetOptionDataList().ToArray(), null);
	}

	// Token: 0x0600D71A RID: 55066 RVA: 0x003977C8 File Offset: 0x003959C8
	[NullableContext(1)]
	private List<int> GetOptionDataList()
	{
		List<int> processViewFunctionList = ConfigBase<FriendConfig>.Instance.GetProcessViewFunctionList();
		List<int> list = new List<int>();
		foreach (int num in processViewFunctionList)
		{
			if (num != 12 || ModelBase<FunctionModel>.Instance.IsOpen(10060))
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x0600D71B RID: 55067 RVA: 0x0039783C File Offset: 0x00395A3C
	[NullableContext(1)]
	private ILayoutItem<PersonalOptionItem> InitPersonalOptionItem(object optionIntId, UUIItem uiItem, int index)
	{
		int num = (int)optionIntId;
		PersonalOptionItem personalOptionItem = new PersonalOptionItem(uiItem);
		personalOptionItem.Refresh(num, false, index);
		if (num == 1)
		{
			this.UnShieldBtn = personalOptionItem;
		}
		else if (num == 2)
		{
			this.ShieldBtn = personalOptionItem;
		}
		else if (num == 3)
		{
			this.BlockBtn = personalOptionItem;
		}
		else if (num == 4)
		{
			this.DeleteFriendBtn = personalOptionItem;
		}
		else if (num == 5)
		{
			this.ReportBtn = personalOptionItem;
		}
		else if (num == 12)
		{
			this.LookCardBtn = personalOptionItem;
		}
		else if (num == 13)
		{
			this.ChangeRemarkBtn = personalOptionItem;
		}
		return new LayoutItem<PersonalOptionItem>
		{
			Key = index,
			Value = personalOptionItem
		};
	}

	// Token: 0x0600D71C RID: 55068 RVA: 0x003978D4 File Offset: 0x00395AD4
	private void UpdatePlayerDataShow()
	{
		FriendData cachePlayerData = ModelBase<FriendModel>.Instance.CachePlayerData;
		this.ShowNecessaryItem();
		this.HeadPhotoItem.RefreshByHeadPhotoId(cachePlayerData.PlayerHeadPhoto);
		base.GetText(5).SetText(cachePlayerData.PlayerLevel.ToString(), true);
		this.RefreshShieldState(cachePlayerData.PlayerId);
		this.TitleItem.Refresh(new int?(cachePlayerData.PlayerTitleId), new int?(cachePlayerData.PlayerTitleStarLevel), new int?(cachePlayerData.PlayerSex));
		int curCard = cachePlayerData.CurCard;
		if (curCard > 0)
		{
			base.SetTextureByPath(ConfigBackgroundCardById.GetConfig(curCard, true).Value.FunctionViewCardPath, base.GetTexture(17), null, null);
		}
	}

	// Token: 0x0600D71D RID: 55069 RVA: 0x00397994 File Offset: 0x00395B94
	public void RefreshMute()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
		bool uiactive = ModelBase<ChatModel>.Instance.IsInMute(selectedPlayerOrItemInstance.PlayerId);
		base.GetItem(8).SetUIActive(uiactive);
	}

	// Token: 0x0600D71E RID: 55070 RVA: 0x003979DC File Offset: 0x00395BDC
	private void RefreshName()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		UUIText text = base.GetText(2);
		if (ControllerBase<FriendController>.Instance.CheckRemarkIsValid(instance.GetSelectedPlayerOrItemInstance(null, null).FriendRemark))
		{
			text.SetText("(" + instance.GetSelectedPlayerOrItemInstance(null, null).FriendRemark + ")", true);
			text.useChangeColor = true;
			return;
		}
		text.SetText(instance.GetSelectedPlayerOrItemInstance(null, null).PlayerName, true);
		text.useChangeColor = false;
	}

	// Token: 0x0600D71F RID: 55071 RVA: 0x00397A88 File Offset: 0x00395C88
	private void RefreshPlayStationItem()
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			bool flag = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null).GetSdkUserId() != "";
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(flag && Singleton<Info>.Instance.IsPs5Platform());
			}
			UUIButtonComponent button = base.GetButton(18);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag && Singleton<Info>.Instance.IsXboxPlatform());
			}
			string sdkOnlineId = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null).GetSdkOnlineId();
			if (flag && Singleton<Info>.Instance.IsPs5Platform())
			{
				UUIText text = base.GetText(13);
				if (text != null)
				{
					text.SetText(sdkOnlineId, true);
				}
			}
			else if (flag && Singleton<Info>.Instance.IsXboxPlatform())
			{
				UUIText text2 = base.GetText(19);
				if (text2 != null)
				{
					text2.SetText(sdkOnlineId, true);
				}
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(12);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600D720 RID: 55072 RVA: 0x00397BF0 File Offset: 0x00395DF0
	private void RefreshSign()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		FriendData selectedPlayerOrItemInstance = instance.GetSelectedPlayerOrItemInstance(null, null);
		string text = (selectedPlayerOrItemInstance != null) ? selectedPlayerOrItemInstance.Signature : null;
		UUIText text2 = base.GetText(11);
		if (text != null && text != "")
		{
			text2.SetText(text, true);
			return;
		}
		FriendData selectedPlayerOrItemInstance2 = instance.GetSelectedPlayerOrItemInstance(null, null);
		int? num = (selectedPlayerOrItemInstance2 != null) ? new int?(selectedPlayerOrItemInstance2.PlayerId) : null;
		int playerId = ModelBase<FunctionModel>.Instance.PlayerId;
		if (!(num.GetValueOrDefault() == playerId & num != null))
		{
			if (text2 != null)
			{
				text2.SetText("", true);
				return;
			}
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text2, "EmptySign", Array.Empty<object>());
		}
	}

	// Token: 0x0600D721 RID: 55073 RVA: 0x00397CC8 File Offset: 0x00395EC8
	private void ShowNecessaryItem()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		EFriendFilter? filterState = instance.FilterState;
		EUiViewName? showingView = instance.ShowingView;
		this.RefreshName();
		this.RefreshSign();
		this.RefreshPlayStationItem();
		this.ChangeRemarkBtn.GetRootItem().SetUIActive(instance.IsMyFriend(instance.GetSelectedPlayerOrItemInstance(null, null).PlayerId));
		this.ShieldBtn.GetRootItem().SetUIActive(((showingView == EUiViewName.FriendView || showingView == EUiViewName.FriendSearchView) && filterState.GetValueOrDefault() == EFriendFilter.FriendList) || filterState.GetValueOrDefault() == EFriendFilter.FriendRequest);
		this.ReportBtn.GetRootItem().SetUIActive(true);
		if (showingView == EUiViewName.FriendView || showingView == EUiViewName.FriendSearchView || showingView == EUiViewName.FriendBlackListView)
		{
			this.RefreshBlackBtn();
		}
		this.DeleteFriendBtn.GetRootItem().SetUIActive(instance.IsMyFriend(instance.GetSelectedPlayerOrItemInstance(null, null).PlayerId));
		base.GetButton(6).RootUIComp.Get().SetUIActive(instance.IsMyFriend(instance.GetSelectedPlayerOrItemInstance(null, null).PlayerId));
		PersonalOptionItem lookCardBtn = this.LookCardBtn;
		if (lookCardBtn == null)
		{
			return;
		}
		lookCardBtn.SetActive(true);
	}

	// Token: 0x0600D722 RID: 55074 RVA: 0x00397EB0 File Offset: 0x003960B0
	private void RefreshBlackBtn()
	{
		FriendData cachePlayerData = ModelBase<FriendModel>.Instance.CachePlayerData;
		if (!ModelBase<FriendModel>.Instance.HasBlockedPlayer(cachePlayerData.PlayerId))
		{
			this.BlockBtn.GetRootItem().SetUIActive(true);
			return;
		}
		this.BlockBtn.GetRootItem().SetUIActive(false);
	}

	// Token: 0x0600D723 RID: 55075 RVA: 0x00397F00 File Offset: 0x00396100
	private void RefreshShieldState(int playerId)
	{
		this.UnShieldBtn.GetRootItem().SetUIActive(false);
		this.ShieldBtn.GetRootItem().SetUIActive(false);
		EUiViewName? showingView = ModelBase<FriendModel>.Instance.ShowingView;
		if (showingView == EUiViewName.FriendView || showingView == EUiViewName.FriendSearchView)
		{
			FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
			int? num = (selectedPlayerOrItemInstance != null) ? new int?(selectedPlayerOrItemInstance.PlayerId) : null;
			if (playerId == num.GetValueOrDefault() & num != null)
			{
				if (ModelBase<ChatModel>.Instance.IsInMute(selectedPlayerOrItemInstance.PlayerId))
				{
					this.UnShieldBtn.GetRootItem().SetUIActive(true);
				}
				else
				{
					this.ShieldBtn.GetRootItem().SetUIActive(true);
				}
			}
		}
		this.RefreshMute();
	}

	// Token: 0x0600D724 RID: 55076 RVA: 0x00398010 File Offset: 0x00396210
	private void OnClickChatBtn()
	{
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
		if (selectedPlayerOrItemInstance == null)
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendProcessView, null);
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.FriendSearchView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendSearchView, null);
		}
		ControllerBase<ChatController>.Instance.OpenFriendChat(selectedPlayerOrItemInstance.PlayerId);
	}

	// Token: 0x0600D725 RID: 55077 RVA: 0x00398080 File Offset: 0x00396280
	private void CallBackUpdateFriendViewShow()
	{
		if (ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null) == null)
		{
			base.CloseMe(null);
			return;
		}
		this.UpdatePlayerDataShow();
	}

	// Token: 0x0600D726 RID: 55078 RVA: 0x003980B9 File Offset: 0x003962B9
	protected override void OnBeforeDestroy()
	{
		if (this.PersonalOptionItemLayout != null)
		{
			this.PersonalOptionItemLayout.ClearChildren();
			this.PersonalOptionItemLayout = null;
		}
	}

	// Token: 0x040065F2 RID: 26098
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<PersonalOptionItem> PersonalOptionItemLayout;

	// Token: 0x040065F3 RID: 26099
	private PersonalOptionItem UnShieldBtn;

	// Token: 0x040065F4 RID: 26100
	private PersonalOptionItem ShieldBtn;

	// Token: 0x040065F5 RID: 26101
	private PersonalOptionItem BlockBtn;

	// Token: 0x040065F6 RID: 26102
	private PersonalOptionItem DeleteFriendBtn;

	// Token: 0x040065F7 RID: 26103
	private PersonalOptionItem ReportBtn;

	// Token: 0x040065F8 RID: 26104
	private PersonalOptionItem LookCardBtn;

	// Token: 0x040065F9 RID: 26105
	private PersonalOptionItem ChangeRemarkBtn;

	// Token: 0x040065FA RID: 26106
	private PlayerHeadItem HeadPhotoItem;

	// Token: 0x040065FB RID: 26107
	private PlayerTitleItem TitleItem;

	// Token: 0x02007FFA RID: 32762
	[NullableContext(0)]
	private class EFriendProcessViewComponents
	{
		// Token: 0x0402B8C5 RID: 178373
		public const int HeadPhotoItem = 0;

		// Token: 0x0402B8C6 RID: 178374
		public const int HeadFrameSprite = 1;

		// Token: 0x0402B8C7 RID: 178375
		public const int NameText = 2;

		// Token: 0x0402B8C8 RID: 178376
		public const int BracketNameParent = 3;

		// Token: 0x0402B8C9 RID: 178377
		public const int BracketNameText = 4;

		// Token: 0x0402B8CA RID: 178378
		public const int LevelNumberText = 5;

		// Token: 0x0402B8CB RID: 178379
		public const int ChatBtn = 6;

		// Token: 0x0402B8CC RID: 178380
		public const int LevelText = 7;

		// Token: 0x0402B8CD RID: 178381
		public const int BlockShowItem = 8;

		// Token: 0x0402B8CE RID: 178382
		public const int GirdLayout = 9;

		// Token: 0x0402B8CF RID: 178383
		public const int Title = 10;

		// Token: 0x0402B8D0 RID: 178384
		public const int SignText = 11;

		// Token: 0x0402B8D1 RID: 178385
		public const int PlayStationItem = 12;

		// Token: 0x0402B8D2 RID: 178386
		public const int PlayStationText = 13;

		// Token: 0x0402B8D3 RID: 178387
		public const int PlayerTitleItem = 14;

		// Token: 0x0402B8D4 RID: 178388
		public const int PlayStationTexture = 15;

		// Token: 0x0402B8D5 RID: 178389
		public const int PcItem = 16;

		// Token: 0x0402B8D6 RID: 178390
		public const int TexCard = 17;

		// Token: 0x0402B8D7 RID: 178391
		public const int XboxButton = 18;

		// Token: 0x0402B8D8 RID: 178392
		public const int XboxText = 19;
	}
}
