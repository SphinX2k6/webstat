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

// Token: 0x0200234B RID: 9035
[NullableContext(2)]
[Nullable(0)]
public class OnlineProcessView : UiViewBase
{
	// Token: 0x0601140E RID: 70670 RVA: 0x004BDE11 File Offset: 0x004BC011
	[NullableContext(1)]
	public OnlineProcessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601140F RID: 70671 RVA: 0x004BDE1C File Offset: 0x004BC01C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
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
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
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

	// Token: 0x06011410 RID: 70672 RVA: 0x004BE144 File Offset: 0x004BC344
	private void OnClickXboxButton()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		string text = (cachePlayerData != null) ? cachePlayerData.ThirdPartyUserId : null;
		if (!string.IsNullOrEmpty(text))
		{
			ControllerBase<KuroSdkController>.Instance.OpenProfileCard(text);
		}
	}

	// Token: 0x06011411 RID: 70673 RVA: 0x004BE17C File Offset: 0x004BC37C
	protected override UniTask OnBeforeStartAsync()
	{
		OnlineProcessView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<OnlineProcessView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011412 RID: 70674 RVA: 0x004BE1C0 File Offset: 0x004BC3C0
	protected override void OnStart()
	{
		this.HeadPhotoItem = new PlayerHeadItem(base.GetItem(0).GetOwner());
		base.GetText(4).SetText("", true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "OnlineProcessTitle", Array.Empty<object>());
		this.RefreshPersonalOptionItemLayout();
		this.UpdatePlayerDataShow();
	}

	// Token: 0x06011413 RID: 70675 RVA: 0x004BE220 File Offset: 0x004BC420
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshShieldState));
	}

	// Token: 0x06011414 RID: 70676 RVA: 0x004BE284 File Offset: 0x004BC484
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFriendViewShow, new Action(this.CallBackUpdateFriendViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshShieldState));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshShieldState));
	}

	// Token: 0x06011415 RID: 70677 RVA: 0x004BE2E8 File Offset: 0x004BC4E8
	private void RefreshPersonalOptionItemLayout()
	{
		if (this.PersonalOptionItemLayout != null)
		{
			this.PersonalOptionItemLayout.ClearChildren();
		}
		this.PersonalOptionItemLayout = new GenericLayoutNew<PersonalOptionItem>(base.GetGridLayout(9), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PersonalOptionItem>(this.InitPersonalOptionItem), null);
		this.PersonalOptionItemLayout.RebuildLayoutByDataNew<int>(this.GetOptionDataList(), null);
	}

	// Token: 0x06011416 RID: 70678 RVA: 0x004BE344 File Offset: 0x004BC544
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

	// Token: 0x06011417 RID: 70679 RVA: 0x004BE3B8 File Offset: 0x004BC5B8
	[NullableContext(1)]
	private ILayoutItem<PersonalOptionItem> InitPersonalOptionItem(object optionId, UUIItem uiItem, int index)
	{
		PersonalOptionItem personalOptionItem = new PersonalOptionItem(uiItem);
		personalOptionItem.Refresh((int)optionId, false, index);
		if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.UnShield)
		{
			this.UnShieldBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.Shield)
		{
			this.ShieldBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.Block)
		{
			this.BlockBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.DeleteFriend)
		{
			this.DeleteFriendBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.Report)
		{
			this.ReportBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.LookCard)
		{
			this.LookCardBtn = personalOptionItem;
		}
		else if ((EPersonalOptionDefine)optionId == EPersonalOptionDefine.ChangeRemark)
		{
			this.ChangeRemarkBtn = personalOptionItem;
		}
		return new LayoutItem<PersonalOptionItem>
		{
			Key = index,
			Value = personalOptionItem
		};
	}

	// Token: 0x06011418 RID: 70680 RVA: 0x004BE470 File Offset: 0x004BC670
	private void UpdatePlayerDataShow()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		ModelBase<FriendModel>.Instance.SelectedPlayerId = new int?(cachePlayerData.PlayerId);
		ModelBase<FriendModel>.Instance.SetCurrentOperationPlayerId(cachePlayerData.PlayerId);
		this.ShowNecessaryItem();
		this.HeadPhotoItem.RefreshByHeadPhotoId(cachePlayerData.HeadId);
		base.GetText(5).SetText(cachePlayerData.Level.ToString(), true);
		this.RefreshShieldState(cachePlayerData.PlayerId);
	}

	// Token: 0x06011419 RID: 70681 RVA: 0x004BE4EC File Offset: 0x004BC6EC
	public void RefreshMute()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		bool uiactive = ModelBase<ChatModel>.Instance.IsInMute(cachePlayerData.PlayerId);
		base.GetItem(8).SetUIActive(uiactive);
	}

	// Token: 0x0601141A RID: 70682 RVA: 0x004BE524 File Offset: 0x004BC724
	private void RefreshName()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		bool flag = ModelBase<FriendModel>.Instance.IsMyFriend(cachePlayerData.PlayerId);
		UUIText text = base.GetText(2);
		if (!flag)
		{
			text.SetText((cachePlayerData != null) ? cachePlayerData.Name : null, true);
			text.useChangeColor = false;
			return;
		}
		FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(cachePlayerData.PlayerId);
		string text2 = (friendById != null) ? friendById.FriendRemark : null;
		if (text2 != null && text2 != "")
		{
			text.SetText("(" + text2 + ")", true);
			text.useChangeColor = true;
			return;
		}
		text.SetText((cachePlayerData != null) ? cachePlayerData.Name : null, true);
		text.useChangeColor = false;
	}

	// Token: 0x0601141B RID: 70683 RVA: 0x004BE5D8 File Offset: 0x004BC7D8
	private void RefreshSign()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		string text = (cachePlayerData != null) ? cachePlayerData.Signature : null;
		UUIText text2 = base.GetText(11);
		if (text != null && text != "")
		{
			text2.SetText(text, true);
			return;
		}
		text2.SetText("", true);
	}

	// Token: 0x0601141C RID: 70684 RVA: 0x004BE62C File Offset: 0x004BC82C
	private void RefreshPlayStationItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
			bool flag = ((cachePlayerData != null) ? cachePlayerData.ThirdPartyUserId : null) != "";
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
			string thirdPartyUserId = ModelBase<OnlineModel>.Instance.CachePlayerData.ThirdPartyUserId;
			if (flag && Singleton<Info>.Instance.IsPs5Platform())
			{
				UUIText text = base.GetText(13);
				if (text != null)
				{
					text.SetText(thirdPartyUserId, true);
				}
			}
			else if (flag && Singleton<Info>.Instance.IsXboxPlatform())
			{
				UUIText text2 = base.GetText(19);
				if (text2 != null)
				{
					text2.SetText(thirdPartyUserId, true);
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

	// Token: 0x0601141D RID: 70685 RVA: 0x004BE754 File Offset: 0x004BC954
	private void RefreshPlayerTitle()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Refresh((cachePlayerData != null) ? new int?(cachePlayerData.PlayerTitleId) : null, (cachePlayerData != null) ? new int?(cachePlayerData.PlayerTitleStarLevel) : null, (cachePlayerData != null) ? new int?(cachePlayerData.Sex) : null);
	}

	// Token: 0x0601141E RID: 70686 RVA: 0x004BE7C8 File Offset: 0x004BC9C8
	private void RefreshPlayerCard()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		if (cachePlayerData == null)
		{
			return;
		}
		BackgroundCard? config = ConfigBackgroundCardById.GetConfig(cachePlayerData.CurUsingCardId, true);
		if (config != null)
		{
			base.SetTextureByPath(config.Value.FunctionViewCardPath, base.GetTexture(17), null, null);
		}
	}

	// Token: 0x0601141F RID: 70687 RVA: 0x004BE824 File Offset: 0x004BCA24
	private void ShowNecessaryItem()
	{
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		this.RefreshName();
		this.RefreshSign();
		this.RefreshPlayStationItem();
		this.RefreshPlayerTitle();
		this.RefreshPlayerCard();
		bool uiactive = ModelBase<FriendModel>.Instance.IsMyFriend(cachePlayerData.PlayerId);
		this.ChangeRemarkBtn.GetRootItem().SetUIActive(uiactive);
		this.ShieldBtn.GetRootItem().SetUIActive(false);
		this.ReportBtn.GetRootItem().SetUIActive(true);
		this.BlockBtn.GetRootItem().SetUIActive(false);
		this.DeleteFriendBtn.GetRootItem().SetUIActive(uiactive);
		base.GetButton(6).RootUIComp.Get().SetUIActive(uiactive);
		PersonalOptionItem lookCardBtn = this.LookCardBtn;
		if (lookCardBtn == null)
		{
			return;
		}
		lookCardBtn.SetActive(true);
	}

	// Token: 0x06011420 RID: 70688 RVA: 0x004BE8EC File Offset: 0x004BCAEC
	private void RefreshShieldState(int playerId)
	{
		this.UnShieldBtn.GetRootItem().SetUIActive(false);
		this.ShieldBtn.GetRootItem().SetUIActive(false);
		IOnlinePlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
		int? num = (cachePlayerData != null) ? new int?(cachePlayerData.PlayerId) : null;
		if (playerId == num.GetValueOrDefault() & num != null)
		{
			ModelBase<ChatModel>.Instance.IsInMute(cachePlayerData.PlayerId);
		}
		this.RefreshMute();
	}

	// Token: 0x06011421 RID: 70689 RVA: 0x004BE96B File Offset: 0x004BCB6B
	private void OnClickChatBtn()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.OnlineProcessView, null);
		ControllerBase<ChatController>.Instance.OpenFriendChat(ModelBase<OnlineModel>.Instance.CachePlayerData.PlayerId);
	}

	// Token: 0x06011422 RID: 70690 RVA: 0x004BE996 File Offset: 0x004BCB96
	private void CallBackUpdateFriendViewShow()
	{
		if (ModelBase<OnlineModel>.Instance.CachePlayerData == null)
		{
			base.CloseMe(null);
			return;
		}
		this.UpdatePlayerDataShow();
	}

	// Token: 0x06011423 RID: 70691 RVA: 0x004BE9B2 File Offset: 0x004BCBB2
	protected override void OnBeforeDestroy()
	{
		if (this.PersonalOptionItemLayout != null)
		{
			this.PersonalOptionItemLayout.ClearChildren();
			this.PersonalOptionItemLayout = null;
		}
	}

	// Token: 0x0400878D RID: 34701
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<PersonalOptionItem> PersonalOptionItemLayout;

	// Token: 0x0400878E RID: 34702
	private PersonalOptionItem UnShieldBtn;

	// Token: 0x0400878F RID: 34703
	private PersonalOptionItem ShieldBtn;

	// Token: 0x04008790 RID: 34704
	private PersonalOptionItem BlockBtn;

	// Token: 0x04008791 RID: 34705
	private PersonalOptionItem DeleteFriendBtn;

	// Token: 0x04008792 RID: 34706
	private PersonalOptionItem ReportBtn;

	// Token: 0x04008793 RID: 34707
	private PersonalOptionItem LookCardBtn;

	// Token: 0x04008794 RID: 34708
	private PersonalOptionItem ChangeRemarkBtn;

	// Token: 0x04008795 RID: 34709
	private PlayerHeadItem HeadPhotoItem;

	// Token: 0x04008796 RID: 34710
	private PlayerTitleItem TitleItem;

	// Token: 0x02008663 RID: 34403
	[NullableContext(0)]
	private enum EOnlineProcessViewComponents
	{
		// Token: 0x0402D748 RID: 186184
		HeadPhotoItem,
		// Token: 0x0402D749 RID: 186185
		HeadFrameSprite,
		// Token: 0x0402D74A RID: 186186
		NameText,
		// Token: 0x0402D74B RID: 186187
		BracketNameParent,
		// Token: 0x0402D74C RID: 186188
		BracketNameText,
		// Token: 0x0402D74D RID: 186189
		LevelNumberText,
		// Token: 0x0402D74E RID: 186190
		ChatBtn,
		// Token: 0x0402D74F RID: 186191
		LevelText,
		// Token: 0x0402D750 RID: 186192
		BlockShowItem,
		// Token: 0x0402D751 RID: 186193
		GirdLayout,
		// Token: 0x0402D752 RID: 186194
		Title,
		// Token: 0x0402D753 RID: 186195
		SignText,
		// Token: 0x0402D754 RID: 186196
		PlayStationItem,
		// Token: 0x0402D755 RID: 186197
		PlayStationText,
		// Token: 0x0402D756 RID: 186198
		PlayerTitleItem,
		// Token: 0x0402D757 RID: 186199
		PlayStationTexture,
		// Token: 0x0402D758 RID: 186200
		PcItem,
		// Token: 0x0402D759 RID: 186201
		TexCard,
		// Token: 0x0402D75A RID: 186202
		XboxButton,
		// Token: 0x0402D75B RID: 186203
		XboxText
	}
}
