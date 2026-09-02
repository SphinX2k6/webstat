using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Ui.PhoneMessage.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200256B RID: 9579
[NullableContext(1)]
[Nullable(0)]
public class PhoneMsgPanelViewBig : UiViewBase
{
	// Token: 0x060129FF RID: 76287 RVA: 0x00522369 File Offset: 0x00520569
	public PhoneMsgPanelViewBig(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012A00 RID: 76288 RVA: 0x00522384 File Offset: 0x00520584
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnSetClick))
		};
	}

	// Token: 0x06012A01 RID: 76289 RVA: 0x005224B4 File Offset: 0x005206B4
	protected override UniTask OnBeforeStartAsync()
	{
		PhoneMsgPanelViewBig.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhoneMsgPanelViewBig.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A02 RID: 76290 RVA: 0x005224F7 File Offset: 0x005206F7
	protected override void OnBeforeShow()
	{
		this.RefreshRedDot();
	}

	// Token: 0x06012A03 RID: 76291 RVA: 0x00522500 File Offset: 0x00520700
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneHaveMsgToRemove, new Action(this.OnHandleMessagesToDelete));
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Add(EEventName.PhoneMsgDialogAndBgRedDotUpdate, new Action(this.RefreshRedDot));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgFilterChanged, new Action(this.OnFilterChanged));
	}

	// Token: 0x06012A04 RID: 76292 RVA: 0x00522580 File Offset: 0x00520780
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneHaveMsgToRemove, new Action(this.OnHandleMessagesToDelete));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhoneMsgDialogAndBgRedDotUpdate, new Action(this.RefreshRedDot));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgFilterChanged, new Action(this.OnFilterChanged));
	}

	// Token: 0x06012A05 RID: 76293 RVA: 0x005225FD File Offset: 0x005207FD
	private void RefreshRedDot()
	{
		base.GetItem(8).SetUIActive(ModelBase<PhoneMsgModel>.Instance.IsChatShowHasRedDot());
	}

	// Token: 0x06012A06 RID: 76294 RVA: 0x00522618 File Offset: 0x00520818
	private void OnFilterChanged()
	{
		ModelBase<PhoneMsgModel>.Instance.SortChatPartnerAndMessages();
		List<int> allChatPartnerIds = ModelBase<PhoneMsgModel>.Instance.GetAllChatPartnerIds();
		this.ChatPartnerTabItemDataList = new List<ChatPartnerTabItemData>();
		int count = allChatPartnerIds.Count;
		for (int i = 0; i < count; i++)
		{
			int chatPartnerId = allChatPartnerIds[i];
			if (ModelBase<PhoneMsgModel>.Instance.IsThisChatPartnerCanShow(chatPartnerId))
			{
				ChatPartnerTabItemData item = new ChatPartnerTabItemData(chatPartnerId);
				this.ChatPartnerTabItemDataList.Add(item);
			}
		}
		if (ModelBase<PhoneMsgModel>.Instance.SelectedFilterIdSet.Count != 0)
		{
			PhoneSystemChatPanel chatPanel = this.ChatPanel;
			if (chatPanel != null)
			{
				chatPanel.SetUiActive(false);
			}
			base.GetItem(1).SetUIActive(true);
			this.CurSelectTogChatItem = null;
			this.CurrentShowShortMessageId = 0;
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnPhoneMsgChatTabClick, 0, 0);
		}
		GenericScrollViewNew<PhoneSystemChatPartnerTabItem, ChatPartnerTabItemData> chatPartnerTabItemList = this.ChatPartnerTabItemList;
		if (chatPartnerTabItemList != null)
		{
			GenericLayout<PhoneSystemChatPartnerTabItem, ChatPartnerTabItemData> genericLayout = chatPartnerTabItemList.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.DeselectCurrentGridProxy();
			}
		}
		this.ChatPartnerTabItemList.RefreshByDataAsync(this.ChatPartnerTabItemDataList, false);
		if (ModelBase<PhoneMsgModel>.Instance.SelectedFilterIdSet.Count == 0 && this.CurrentShowShortMessageId != 0)
		{
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(this.CurrentShowShortMessageId);
			if (phoneMsgConfig == null)
			{
				return;
			}
			int whichChat = phoneMsgConfig.Value.WhichChat;
			this.SelectAndScrollToChatPartner(whichChat);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnPhoneMsgChatTabClick, this.CurrentShowShortMessageId, whichChat);
		}
	}

	// Token: 0x06012A07 RID: 76295 RVA: 0x00522768 File Offset: 0x00520968
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x06012A08 RID: 76296 RVA: 0x00522782 File Offset: 0x00520982
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		this.SetChatSelectPanelBlackMarkEnable(false);
	}

	// Token: 0x06012A09 RID: 76297 RVA: 0x0052278C File Offset: 0x0052098C
	private void InitChatPartnerTabDataList()
	{
		ModelBase<PhoneMsgModel>.Instance.SortChatPartnerAndMessages();
		List<int> allChatPartnerIds = ModelBase<PhoneMsgModel>.Instance.GetAllChatPartnerIds();
		this.ChatPartnerTabItemDataList = new List<ChatPartnerTabItemData>();
		int count = allChatPartnerIds.Count;
		for (int i = 0; i < count; i++)
		{
			ChatPartnerTabItemData item = new ChatPartnerTabItemData(allChatPartnerIds[i]);
			this.ChatPartnerTabItemDataList.Add(item);
		}
	}

	// Token: 0x06012A0A RID: 76298 RVA: 0x005227E8 File Offset: 0x005209E8
	private UniTask CreateAndRefreshChatPartnerTab()
	{
		PhoneMsgPanelViewBig.<CreateAndRefreshChatPartnerTab>d__21 <CreateAndRefreshChatPartnerTab>d__;
		<CreateAndRefreshChatPartnerTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAndRefreshChatPartnerTab>d__.<>4__this = this;
		<CreateAndRefreshChatPartnerTab>d__.<>1__state = -1;
		<CreateAndRefreshChatPartnerTab>d__.<>t__builder.Start<PhoneMsgPanelViewBig.<CreateAndRefreshChatPartnerTab>d__21>(ref <CreateAndRefreshChatPartnerTab>d__);
		return <CreateAndRefreshChatPartnerTab>d__.<>t__builder.Task;
	}

	// Token: 0x06012A0B RID: 76299 RVA: 0x0052282B File Offset: 0x00520A2B
	private PhoneSystemChatPartnerTabItem CreateChatPartnerTabItem()
	{
		PhoneSystemChatPartnerTabItem phoneSystemChatPartnerTabItem = new PhoneSystemChatPartnerTabItem();
		phoneSystemChatPartnerTabItem.SetClickCallBack(new Action<int>(this.HandleSelectGridProxy));
		phoneSystemChatPartnerTabItem.OnSetSelectCallBack = new Action(this.AfterHandleSelectGridProxy);
		phoneSystemChatPartnerTabItem.SetRefreshMainPanelFunc(new Action<int, TogChatTalkItem>(this.OnSelectUpdateChatPanel));
		return phoneSystemChatPartnerTabItem;
	}

	// Token: 0x06012A0C RID: 76300 RVA: 0x00522868 File Offset: 0x00520A68
	private void HandleSelectGridProxy(int index)
	{
		if (this.ChatPartnerTabItemList.GetSelectedIndex() == index)
		{
			this.ChatPartnerTabItemList.GetGenericLayout().DeselectCurrentGridProxy();
			return;
		}
		this.CurrentIndex = index;
		this.ChatPartnerTabItemList.SelectGridProxy(index, false);
	}

	// Token: 0x06012A0D RID: 76301 RVA: 0x0052289D File Offset: 0x00520A9D
	private void AfterHandleSelectGridProxy()
	{
		this.TryScrollToCanSee(this.CurrentIndex);
	}

	// Token: 0x06012A0E RID: 76302 RVA: 0x005228AC File Offset: 0x00520AAC
	private void TryScrollToCanSee(int index)
	{
		UUIItem item = this.ChatPartnerTabItemList.GetItemByIndex(index);
		if (item != null)
		{
			TTimerAction <>9__1;
			this.ChatPartnerTabItemList.BindLateUpdate(delegate(float delta)
			{
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate(float _)
					{
						if (this.ChatPartnerTabItemList.IsItemInViewport(item, 1f) != EOutOfBoundsType.NotOut)
						{
							this.ChatPartnerTabItemList.ScrollToTopByIndex(index);
						}
					});
				}
				gameplayTimeInstance.Next(action, null, null);
				this.ChatPartnerTabItemList.UnBindLateUpdate();
			});
		}
	}

	// Token: 0x06012A0F RID: 76303 RVA: 0x00522903 File Offset: 0x00520B03
	public void OnSelectUpdateChatPanel(int shortMessageId, TogChatTalkItem tog)
	{
		this.CurSelectTogChatItem = tog;
		this.CheckAndCloseTips(shortMessageId);
		if (this.CurrentShowShortMessageId == shortMessageId)
		{
			return;
		}
		this.UpdateChatPanel(shortMessageId);
	}

	// Token: 0x06012A10 RID: 76304 RVA: 0x00522925 File Offset: 0x00520B25
	public void CheckAndCloseTips(int shortMessageId)
	{
	}

	// Token: 0x06012A11 RID: 76305 RVA: 0x00522927 File Offset: 0x00520B27
	public void OnHandleMessagesToDelete()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Message_ForceCloseTips", Array.Empty<object>());
		base.CloseMe(null);
	}

	// Token: 0x06012A12 RID: 76306 RVA: 0x00522944 File Offset: 0x00520B44
	public void RefreshCurSelectChatTabTextShow(string lastChatText)
	{
		if (this.CurSelectTogChatItem == null)
		{
			return;
		}
		this.CurSelectTogChatItem.SetShowChatText(lastChatText);
	}

	// Token: 0x06012A13 RID: 76307 RVA: 0x0052295C File Offset: 0x00520B5C
	public void RefreshTargetChatItemText(int shortMessageId)
	{
		if (this.CurrentShowShortMessageId == shortMessageId)
		{
			return;
		}
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(shortMessageId);
		int? num = (phoneMsgConfig != null) ? new int?(phoneMsgConfig.Value.WhichChat) : null;
		if (num == null)
		{
			return;
		}
		GenericScrollViewNew<PhoneSystemChatPartnerTabItem, ChatPartnerTabItemData> chatPartnerTabItemList = this.ChatPartnerTabItemList;
		PhoneSystemChatPartnerTabItem phoneSystemChatPartnerTabItem = (chatPartnerTabItemList != null) ? chatPartnerTabItemList.GetScrollItemByKey(num.Value) : null;
		if (phoneSystemChatPartnerTabItem == null)
		{
			return;
		}
		phoneSystemChatPartnerTabItem.RefreshShowChatText(shortMessageId, EGetLastChatTextType.FromLastCanReadIndex);
		this.CurrentShowShortMessageId = shortMessageId;
	}

	// Token: 0x06012A14 RID: 76308 RVA: 0x005229E8 File Offset: 0x00520BE8
	public UniTask UpdateChatPanel(int shortMessageId)
	{
		PhoneMsgPanelViewBig.<UpdateChatPanel>d__32 <UpdateChatPanel>d__;
		<UpdateChatPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateChatPanel>d__.<>4__this = this;
		<UpdateChatPanel>d__.shortMessageId = shortMessageId;
		<UpdateChatPanel>d__.<>1__state = -1;
		<UpdateChatPanel>d__.<>t__builder.Start<PhoneMsgPanelViewBig.<UpdateChatPanel>d__32>(ref <UpdateChatPanel>d__);
		return <UpdateChatPanel>d__.<>t__builder.Task;
	}

	// Token: 0x06012A15 RID: 76309 RVA: 0x00522A33 File Offset: 0x00520C33
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012A16 RID: 76310 RVA: 0x00522A3C File Offset: 0x00520C3C
	private void OnSetClick()
	{
		if (this.ChatPanel != null && this.ChatPanel.GetIsPlaying)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Message_ForbidSetting", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhoneMsgSettingView, null, null);
	}

	// Token: 0x06012A17 RID: 76311 RVA: 0x00522A7C File Offset: 0x00520C7C
	private void LogReportOpenPhoneView(EPhoneMsgOpenWay openWay, EPhoneMsgViewType reason)
	{
		OnOpenPhoneViewLogEvent onOpenPhoneViewLogEvent = new OnOpenPhoneViewLogEvent();
		onOpenPhoneViewLogEvent.i_open_way = (int)openWay;
		onOpenPhoneViewLogEvent.i_reason = (int)reason;
		ControllerBase<LogReportController>.Instance.LogReport(onOpenPhoneViewLogEvent);
	}

	// Token: 0x06012A18 RID: 76312 RVA: 0x00522AA8 File Offset: 0x00520CA8
	public PhoneSystemChatProxy GetProxy()
	{
		return this.Proxy;
	}

	// Token: 0x06012A19 RID: 76313 RVA: 0x00522AB0 File Offset: 0x00520CB0
	public void SetChatSelectPanelBlackMarkEnable(bool isEnable)
	{
		foreach (PhoneSystemChatPartnerTabItem phoneSystemChatPartnerTabItem in this.ChatPartnerTabItemList.GetScrollItemList())
		{
			phoneSystemChatPartnerTabItem.SetChangeAlpha(isEnable);
		}
	}

	// Token: 0x06012A1A RID: 76314 RVA: 0x00522B08 File Offset: 0x00520D08
	private void SelectAndScrollToChatPartner(int chatPartnerId)
	{
		for (int i = 0; i < this.ChatPartnerTabItemDataList.Count; i++)
		{
			if (this.ChatPartnerTabItemDataList[i].ChatPartnerId == chatPartnerId)
			{
				this.ChatPartnerTabItemList.SelectGridProxy(i, false);
				this.TryScrollToCanSee(i);
			}
		}
	}

	// Token: 0x04009188 RID: 37256
	private int CurrentShowShortMessageId;

	// Token: 0x04009189 RID: 37257
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400918A RID: 37258
	[Nullable(2)]
	private PhoneSystemChatPanel ChatPanel;

	// Token: 0x0400918B RID: 37259
	[Nullable(2)]
	private TogChatTalkItem CurSelectTogChatItem;

	// Token: 0x0400918C RID: 37260
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PhoneSystemChatPartnerTabItem, ChatPartnerTabItemData> ChatPartnerTabItemList;

	// Token: 0x0400918D RID: 37261
	private List<ChatPartnerTabItemData> ChatPartnerTabItemDataList = new List<ChatPartnerTabItemData>();

	// Token: 0x0400918E RID: 37262
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x0400918F RID: 37263
	private PhoneSystemChatProxy Proxy;

	// Token: 0x04009190 RID: 37264
	[Nullable(2)]
	private PhoneViewFilterEntry FilterPanel;

	// Token: 0x04009191 RID: 37265
	private int CurrentIndex = -1;

	// Token: 0x02008883 RID: 34947
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E1BB RID: 188859
		ItemCaption,
		// Token: 0x0402E1BC RID: 188860
		PanelNull,
		// Token: 0x0402E1BD RID: 188861
		TabScroll,
		// Token: 0x0402E1BE RID: 188862
		Content,
		// Token: 0x0402E1BF RID: 188863
		ChatPartnerTabItem,
		// Token: 0x0402E1C0 RID: 188864
		BtnSet,
		// Token: 0x0402E1C1 RID: 188865
		PanelPhoneSystemChatPanel,
		// Token: 0x0402E1C2 RID: 188866
		Null,
		// Token: 0x0402E1C3 RID: 188867
		SettingBtnRedDotItem,
		// Token: 0x0402E1C4 RID: 188868
		ItemFilter,
		// Token: 0x0402E1C5 RID: 188869
		PartnerEmpty
	}
}
