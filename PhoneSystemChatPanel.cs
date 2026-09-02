using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200258D RID: 9613
[NullableContext(2)]
[Nullable(0)]
public class PhoneSystemChatPanel : UiPanelBase
{
	// Token: 0x06012B26 RID: 76582 RVA: 0x005283A4 File Offset: 0x005265A4
	private void OnClickedBtnMask()
	{
		if (this.IsPlaying)
		{
			if (!this.IsInInputtingAnimation)
			{
				return;
			}
			this.IsInInputtingAnimation = false;
			int inputtingAnimationChatIndex = this.InputtingAnimationChatIndex;
			this.InputtingAnimationChatIndex = -1;
			if (inputtingAnimationChatIndex < 0)
			{
				return;
			}
			if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(inputtingAnimationChatIndex) != 0)
			{
				return;
			}
			ISyncGridProxy proxyByDisplayIndex = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(inputtingAnimationChatIndex);
			if (proxyByDisplayIndex != null)
			{
				PhoneMsgOtherChatItem phoneMsgOtherChatItem = proxyByDisplayIndex as PhoneMsgOtherChatItem;
				if (phoneMsgOtherChatItem != null)
				{
					phoneMsgOtherChatItem.SkipInputtingAnimationTask();
				}
			}
		}
	}

	// Token: 0x1700178F RID: 6031
	// (get) Token: 0x06012B27 RID: 76583 RVA: 0x0052840B File Offset: 0x0052660B
	public bool GetIsPlaying
	{
		get
		{
			return this.IsPlaying;
		}
	}

	// Token: 0x06012B28 RID: 76584 RVA: 0x00528414 File Offset: 0x00526614
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickedBtnMask))
		};
	}

	// Token: 0x06012B29 RID: 76585 RVA: 0x005285D0 File Offset: 0x005267D0
	protected override void OnStart()
	{
		Dictionary<int, UUIItem> dictionary = new Dictionary<int, UUIItem>
		{
			{
				0,
				base.GetItem(0)
			}
		};
		dictionary[0] = base.GetItem(7);
		dictionary[1] = base.GetItem(8);
		dictionary[2] = base.GetItem(9);
		dictionary[3] = base.GetItem(10);
		dictionary[4] = base.GetItem(11);
		dictionary[5] = base.GetItem(12);
		dictionary[6] = base.GetItem(13);
		this.ChatMultiTemplateComponent = new MultiTemplateComponent(base.GetVerticalLayout(5).RootUIComp, dictionary);
		base.GetButton(14).RootUIComp.Get().SetUIActive(true);
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshChatBgShow));
		UUIText text = base.GetText(0);
		text.bGameRichText = true;
		text.richText = true;
		this.VoiceAudioComp = new PhoneMsgAudioComponent();
		this.VoiceAudioComp.Init(new PlotTextAudioComponentContext
		{
			OnAudioStartDelegate = new Action(this.OnVoiceAudioStart),
			OnAudioEndDelegate = new Action(this.OnVoiceAudioEnd),
			OnAudioLoadTimeoutDelegate = new Action(this.OnVoiceAudioLoadTimeout)
		});
		this.ScrollComponent = base.GetScrollViewWithScrollbar(4);
		if (this.ScrollComponent != null)
		{
			this.ScrollComponent.SetCanScroll(true);
			this.ScrollComponent.SetRayCastTargetForScrollView(true);
			this.ScrollComponent.OnScrollViewDownUpCallback.Bind(new Action<ULGUIPointerEventData>(this.OnScrollViewPointerUp));
		}
	}

	// Token: 0x06012B2A RID: 76586 RVA: 0x0052875C File Offset: 0x0052695C
	protected override void OnBeforeShow()
	{
		this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "PhoneSystemChatPanel", ETickingGroup.TG_PrePhysics, true, 0, true);
		base.GetScrollViewWithScrollbar(4).OnLateUpdate.Bind(new Action<float>(this.OnLateTick));
		this.RefreshChatBgShow();
	}

	// Token: 0x06012B2B RID: 76587 RVA: 0x005287B1 File Offset: 0x005269B1
	protected override void OnBeforeHide()
	{
		this.HandleLastData();
		this.CheckToRemoveTicker();
		base.GetScrollViewWithScrollbar(4).OnLateUpdate.Unbind();
		UUIScrollViewWithScrollbarComponent scrollComponent = this.ScrollComponent;
		if (scrollComponent != null)
		{
			scrollComponent.OnScrollViewDownUpCallback.Unbind();
		}
		this.StopVoice();
	}

	// Token: 0x06012B2C RID: 76588 RVA: 0x005287ED File Offset: 0x005269ED
	protected override void OnBeforeDestroy()
	{
		this.Reset();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshChatBgShow));
		this.CheckToRemoveTicker();
	}

	// Token: 0x06012B2D RID: 76589 RVA: 0x00528817 File Offset: 0x00526A17
	private void OnTick(float deltaTime)
	{
		if (this.ReadyToScroll)
		{
			this.ScrollToChatItem(this.NeedScrollToIndex, this.NeedScrollTween);
			this.ReadyToScroll = false;
		}
	}

	// Token: 0x06012B2E RID: 76590 RVA: 0x0052883C File Offset: 0x00526A3C
	private void OnLateTick(float _)
	{
		if (this.NeedScrollToEndOnLateTick)
		{
			base.GetScrollViewWithScrollbar(4).ScrollToEnd();
			this.NeedScrollToEndOnLateTick = false;
			this.NeedScrollOnNextTick = false;
			this.ReadyToScroll = false;
		}
		if (this.NeedScrollOnNextTick)
		{
			this.ReadyToScroll = true;
			this.NeedScrollOnNextTick = false;
		}
		if (this.NeedCheckAdapt && this.CheckLastItemOutOfContent())
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.SetHeightFitToChildren(true);
			}
			this.NeedCheckAdapt = false;
		}
	}

	// Token: 0x06012B2F RID: 76591 RVA: 0x005288B4 File Offset: 0x00526AB4
	private bool CompareContentAndViewPort()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar == null || !scrollViewWithScrollbar.IsValid())
		{
			return false;
		}
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (verticalLayout != null) ? new TWeakObjectPtr<UUIItem>?(verticalLayout.RootUIComp) : null;
		if (tweakObjectPtr == null || tweakObjectPtr == null)
		{
			return false;
		}
		float height = scrollViewWithScrollbar.RootUIComp.Get().GetHeight();
		return tweakObjectPtr.Value.Get().GetHeight() < height;
	}

	// Token: 0x06012B30 RID: 76592 RVA: 0x00528938 File Offset: 0x00526B38
	private bool CheckLastItemOutOfContent()
	{
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (verticalLayout != null) ? new TWeakObjectPtr<UUIItem>?(verticalLayout.RootUIComp) : null;
		if (tweakObjectPtr == null || tweakObjectPtr == null)
		{
			return false;
		}
		MultiTemplateComponent chatMultiTemplateComponent = this.ChatMultiTemplateComponent;
		UUIItem uuiitem = (chatMultiTemplateComponent != null) ? chatMultiTemplateComponent.GetItemByDisplayIndex(this.DisplayedChatScrollViewDataList.Count - 1) : null;
		if (uuiitem == null || !uuiitem.IsValid())
		{
			return false;
		}
		float height = tweakObjectPtr.Value.Get().GetHeight();
		return uuiitem.GetRelativeTransform().GetLocation().Y + uuiitem.GetLocalSpaceBottom() < -height;
	}

	// Token: 0x06012B31 RID: 76593 RVA: 0x005289DC File Offset: 0x00526BDC
	private void RefreshChatBgShow()
	{
		int currentUsingChatBgId = ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatBgId;
		ChatBg? chatBgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(currentUsingChatBgId);
		if (chatBgConfig != null)
		{
			string chatBgPathBig = chatBgConfig.Value.ChatBgPathBig;
			base.SetTextureByPath(chatBgPathBig, base.GetTexture(6), null, null);
		}
	}

	// Token: 0x06012B32 RID: 76594 RVA: 0x00528A34 File Offset: 0x00526C34
	private void CheckNaviBtnBlankShow()
	{
		if (this.DisplayData.ChatDataList.Count <= 0)
		{
			return;
		}
		if (this.DisplayData.ChatDataList[this.DisplayData.ChatDataList.Count - 1] == null)
		{
			return;
		}
		bool uiactive = !this.DisplayData.IsLastFocusableItem();
		UUIItem item = base.GetItem(16);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x06012B33 RID: 76595 RVA: 0x00528A9C File Offset: 0x00526C9C
	private void CheckToRemoveTicker()
	{
		if (this.Ticker != null)
		{
			Singleton<TickSystem>.Instance.Remove(this.Ticker.Id);
			this.Ticker = null;
		}
	}

	// Token: 0x06012B34 RID: 76596 RVA: 0x00528AC4 File Offset: 0x00526CC4
	public void UpdateChatDialogData()
	{
		if (this.DisplayData == null)
		{
			return;
		}
		List<PhoneMsgChatData> chatDataList = this.DisplayData.ChatDataList;
		int count = chatDataList.Count;
		for (int i = 0; i < count; i++)
		{
			chatDataList[i].ChatDialogId = this.DisplayData.ChatDialogId;
		}
	}

	// Token: 0x06012B35 RID: 76597 RVA: 0x00528B10 File Offset: 0x00526D10
	public void UpdateChatScrollViewData()
	{
		if (this.DisplayData == null)
		{
			return;
		}
		List<PhoneMsgChatData> chatDataList = this.DisplayData.ChatDataList;
		this.DisplayedChatScrollViewDataList.Clear();
		int readIndex = this.DisplayData.ReadIndex;
		int num = (readIndex < 0) ? readIndex : (chatDataList.Count - 1);
		this.DisplayData.ReadIndex = num;
		if (num < 0)
		{
			return;
		}
		for (int i = 0; i <= num; i++)
		{
			PhoneMsgChatData data = chatDataList[i];
			IMultiTemplateGridData multiTemplateGridData = this.CreateChatData(data);
			if (multiTemplateGridData != null)
			{
				this.DisplayedChatScrollViewDataList.Add(multiTemplateGridData);
			}
		}
		if (this.DisplayData.IsFinished())
		{
			EndLineChatGridData item = new EndLineChatGridData(true);
			this.DisplayedChatScrollViewDataList.Add(item);
		}
	}

	// Token: 0x06012B36 RID: 76598 RVA: 0x00528BBC File Offset: 0x00526DBC
	public void RefreshChatShow()
	{
		this.UpdateChatDialogData();
		this.RefreshChatDialog();
		this.RefreshChatBg();
	}

	// Token: 0x06012B37 RID: 76599 RVA: 0x00528BD0 File Offset: 0x00526DD0
	private void RefreshChatDialog()
	{
		if (((this.DisplayData != null) ? this.DisplayData.ChatDialogId : 0) <= 0)
		{
			return;
		}
		this.ShowReadChatContents();
	}

	// Token: 0x06012B38 RID: 76600 RVA: 0x00528BF4 File Offset: 0x00526DF4
	private void RefreshChatBg()
	{
		int num = (this.DisplayData != null) ? this.DisplayData.ChatBgId : 0;
		if (num <= 0)
		{
			return;
		}
		ChatBg? chatBgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatBgConfig(num);
		if (chatBgConfig == null)
		{
			return;
		}
		string chatBgPathBig = chatBgConfig.Value.ChatBgPathBig;
		base.SetTextureByPath(chatBgPathBig, base.GetTexture(6), null, null);
	}

	// Token: 0x06012B39 RID: 76601 RVA: 0x00528C5C File Offset: 0x00526E5C
	[NullableContext(1)]
	public void RefreshByData(ShortMessageDisplayData displayData)
	{
		if (this.DisplayData != null)
		{
			this.HandleLastData();
		}
		this.Reset();
		this.DisplayData = displayData;
		this.RefreshOtherInfo();
		this.UpdateChatScrollViewData();
		this.ShowReadChatContents();
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
		if (verticalLayout != null)
		{
			verticalLayout.SetHeightFitToChildren(true);
		}
		this.UpdateProgressToServerAsync(this.DisplayData);
		bool flag = this.DisplayData.IsAllChatRead();
		if (this.DisplayData.ReadIndex < 0 && !flag)
		{
			this.AddMaskEnableTask();
			this.AddAllMessageTasks();
			this.AddMaskDisableTask();
			return;
		}
		this.DisplayData.ReadIndex = this.DisplayData.ChatDataList.Count - 1;
		this.CheckNaviBtnBlankShow();
	}

	// Token: 0x06012B3A RID: 76602 RVA: 0x00528D0C File Offset: 0x00526F0C
	private UniTask HandleLastData()
	{
		PhoneSystemChatPanel.<HandleLastData>d__45 <HandleLastData>d__;
		<HandleLastData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleLastData>d__.<>4__this = this;
		<HandleLastData>d__.<>1__state = -1;
		<HandleLastData>d__.<>t__builder.Start<PhoneSystemChatPanel.<HandleLastData>d__45>(ref <HandleLastData>d__);
		return <HandleLastData>d__.<>t__builder.Task;
	}

	// Token: 0x06012B3B RID: 76603 RVA: 0x00528D50 File Offset: 0x00526F50
	public void Reset()
	{
		this.StopVoice();
		base.CancelAllAsyncTask();
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetCanScroll(true);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetRayCastTargetForScrollView(true);
		}
		this.IsPlaying = false;
		this.NeedScrollOnNextTick = false;
		this.NeedScrollTween = false;
		this.ReadyToScroll = false;
		this.NeedCheckAdapt = false;
		this.NeedScrollToEndOnLateTick = false;
		this.DisplayedChatScrollViewDataList.Clear();
		MultiTemplateComponent chatMultiTemplateComponent = this.ChatMultiTemplateComponent;
		if (chatMultiTemplateComponent == null)
		{
			return;
		}
		chatMultiTemplateComponent.RefreshByData(this.DisplayedChatScrollViewDataList, false);
	}

	// Token: 0x06012B3C RID: 76604 RVA: 0x00528DDC File Offset: 0x00526FDC
	private void AddAllMessageTasks()
	{
		if (this.DisplayData == null)
		{
			return;
		}
		for (int i = this.DisplayData.ReadIndex + 1; i < this.DisplayData.ChatDataList.Count; i++)
		{
			this.AddShowMessageTask(i);
		}
		bool flag = !this.DisplayData.IsLastOption();
		if (flag)
		{
			this.AddEndLineTask();
		}
		this.AddUpdateProgressTask(this.DisplayData);
		if (flag)
		{
			this.AddExecuteEndCallBackTask();
		}
	}

	// Token: 0x06012B3D RID: 76605 RVA: 0x00528E4C File Offset: 0x0052704C
	private void AddShowMessageTask(int chatIndex)
	{
		if (this.DisplayData == null)
		{
			return;
		}
		PhoneMsgChatData phoneMsgChatData = this.DisplayData.ChatDataList[chatIndex];
		EPhoneMsgContentType chatContentType = phoneMsgChatData.ChatContentType;
		this.AddRefreshReadIndexTask(chatIndex);
		if (chatContentType == EPhoneMsgContentType.Tips && phoneMsgChatData.ContentType == EChatMsgType.Task)
		{
			this.AddUpdateProgressTask(this.DisplayData);
		}
		this.AddRefreshChatContentTask(chatIndex);
		switch (chatContentType)
		{
		case EPhoneMsgContentType.Other:
			this.AddShowInputtingAnimationTask(chatIndex);
			this.AddShowSpeakerContentAnimationTask(chatIndex);
			return;
		case EPhoneMsgContentType.Self:
			this.AddShowSpeakerContentAnimationTask(chatIndex);
			return;
		case EPhoneMsgContentType.Tips:
			switch (phoneMsgChatData.ContentType)
			{
			case EChatMsgType.Task:
				this.AddShowTaskAnimationTask(chatIndex);
				return;
			case EChatMsgType.Birthday:
				this.AddShowBirthdayAnimationTask(chatIndex);
				return;
			case EChatMsgType.Reward:
				this.AddShowRewardAnimationTask(chatIndex);
				return;
			case EChatMsgType.Tips:
				this.AddShowSystemTipsAnimationTask(chatIndex);
				return;
			default:
				return;
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x06012B3E RID: 76606 RVA: 0x00528F0C File Offset: 0x0052710C
	private void RefreshOtherInfo()
	{
		if (this.DisplayData == null)
		{
			return;
		}
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(this.DisplayData.ShortMsgId);
		if (phoneMsgConfig == null)
		{
			return;
		}
		int whichChat = phoneMsgConfig.Value.WhichChat;
		ChatPartner? chatPartnerConfigNew = ModelBase<PhoneMsgModel>.Instance.GetChatPartnerConfigNew(whichChat);
		if (chatPartnerConfigNew == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), chatPartnerConfigNew.Value.Name, Array.Empty<object>());
		bool isGroupChat = chatPartnerConfigNew.Value.IsGroupChat;
		base.GetText(1).SetUIActive(!isGroupChat);
		base.GetItem(2).SetUIActive(isGroupChat);
		if (isGroupChat)
		{
			base.GetText(3).SetText(chatPartnerConfigNew.Value.PeopleNum.ToString(), true);
		}
		else
		{
			string desc = chatPartnerConfigNew.Value.Desc;
			if (!string.IsNullOrEmpty(desc))
			{
				base.GetText(1).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), desc, Array.Empty<object>());
			}
			else
			{
				base.GetText(1).SetUIActive(false);
			}
		}
		this.RefreshChatBg();
	}

	// Token: 0x06012B3F RID: 76607 RVA: 0x00529040 File Offset: 0x00527240
	[NullableContext(1)]
	[return: Nullable(2)]
	private IMultiTemplateGridData CreateChatData(PhoneMsgChatData data)
	{
		switch (data.ChatContentType)
		{
		case EPhoneMsgContentType.Other:
			return new OtherChatGridData(data)
			{
				OnItemClickDelegate = new Action<int>(this.OnChatItemClick)
			};
		case EPhoneMsgContentType.Self:
			return new SelfChatGridData(data)
			{
				OnOptionItemClickDelegate = new Action<int, int>(this.OnOptionItemClick),
				OnItemClickDelegate = new Action<int>(this.OnChatItemClick)
			};
		case EPhoneMsgContentType.Tips:
			switch (data.ContentType)
			{
			case EChatMsgType.Task:
				return new TaskChatGridData(data);
			case EChatMsgType.Birthday:
				return new BirthdayChatGridData(data);
			case EChatMsgType.Reward:
				return new RewardChatGridData(data)
				{
					OnRewardClick = new Action(this.OnRewardClick)
				};
			case EChatMsgType.Tips:
				return new TipsChatGridData(data);
			default:
				return null;
			}
			break;
		default:
			return null;
		}
	}

	// Token: 0x06012B40 RID: 76608 RVA: 0x00529101 File Offset: 0x00527301
	private void OnRewardClick()
	{
		this.AddReceiveRewardTask();
	}

	// Token: 0x06012B41 RID: 76609 RVA: 0x00529109 File Offset: 0x00527309
	private void ShowReadChatContents()
	{
		if (this.ChatMultiTemplateComponent == null)
		{
			return;
		}
		this.ChatMultiTemplateComponent.RefreshByData(this.DisplayedChatScrollViewDataList, false);
		this.NeedScrollToEndOnLateTick = true;
	}

	// Token: 0x06012B42 RID: 76610 RVA: 0x00529130 File Offset: 0x00527330
	private void ScrollToChatItem(int index, bool bTween = true)
	{
		if (this.ChatMultiTemplateComponent == null)
		{
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		UUIItem itemByDisplayIndex = this.ChatMultiTemplateComponent.GetItemByDisplayIndex(index);
		if (itemByDisplayIndex == null)
		{
			return;
		}
		scrollViewWithScrollbar.ScrollTo(itemByDisplayIndex, bTween);
	}

	// Token: 0x06012B43 RID: 76611 RVA: 0x0052916C File Offset: 0x0052736C
	private void AddRefreshReadIndexTask(int chatIndex)
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", () => this.RefreshReadIndexAsync(chatIndex), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B44 RID: 76612 RVA: 0x005291B0 File Offset: 0x005273B0
	private UniTask RefreshReadIndexAsync(int chatIndex)
	{
		ShortMessageDisplayData displayData = this.DisplayData;
		if (displayData.ReadIndex >= displayData.ChatDataList.Count - 1)
		{
			displayData.ReadIndex = displayData.ChatDataList.Count - 1;
			return UniTask.CompletedTask;
		}
		displayData.ReadIndex = chatIndex;
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B45 RID: 76613 RVA: 0x00529200 File Offset: 0x00527400
	private void AddRefreshChatContentTask(int chatIndex)
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", () => this.RefreshChatContentAsync(chatIndex), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B46 RID: 76614 RVA: 0x00529244 File Offset: 0x00527444
	private UniTask RefreshChatContentAsync(int chatIndex)
	{
		ShortMessageDisplayData displayData = this.DisplayData;
		if (chatIndex > displayData.ChatDataList.Count - 1)
		{
			return UniTask.CompletedTask;
		}
		IMultiTemplateGridData multiTemplateGridData = this.CreateChatData(displayData.ChatDataList[chatIndex]);
		if (multiTemplateGridData == null)
		{
			return UniTask.CompletedTask;
		}
		this.DisplayedChatScrollViewDataList.Add(multiTemplateGridData);
		this.ChatMultiTemplateComponent.AddItem(multiTemplateGridData);
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B47 RID: 76615 RVA: 0x005292A8 File Offset: 0x005274A8
	private void AddShowInputtingAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowInputtingAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowInputtingAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B48 RID: 76616 RVA: 0x00529308 File Offset: 0x00527508
	private UniTask ShowInputtingAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowInputtingAnimationAsync>d__59 <ShowInputtingAnimationAsync>d__;
		<ShowInputtingAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowInputtingAnimationAsync>d__.<>4__this = this;
		<ShowInputtingAnimationAsync>d__.chatIndex = chatIndex;
		<ShowInputtingAnimationAsync>d__.<>1__state = -1;
		<ShowInputtingAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowInputtingAnimationAsync>d__59>(ref <ShowInputtingAnimationAsync>d__);
		return <ShowInputtingAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B49 RID: 76617 RVA: 0x00529354 File Offset: 0x00527554
	private void OnShowInputtingAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		this.IsInInputtingAnimation = false;
		this.InputtingAnimationChatIndex = -1;
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex) != 0)
		{
			return;
		}
		PhoneMsgOtherChatItem phoneMsgOtherChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as PhoneMsgOtherChatItem;
		if (phoneMsgOtherChatItem != null)
		{
			phoneMsgOtherChatItem.StopInputtingAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B4A RID: 76618 RVA: 0x005293A4 File Offset: 0x005275A4
	private void AddShowSpeakerContentAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowSpeakerContentAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowSpeakerContentAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B4B RID: 76619 RVA: 0x00529404 File Offset: 0x00527604
	private UniTask ShowSpeakerContentAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowSpeakerContentAnimationAsync>d__62 <ShowSpeakerContentAnimationAsync>d__;
		<ShowSpeakerContentAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowSpeakerContentAnimationAsync>d__.<>4__this = this;
		<ShowSpeakerContentAnimationAsync>d__.chatIndex = chatIndex;
		<ShowSpeakerContentAnimationAsync>d__.<>1__state = -1;
		<ShowSpeakerContentAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowSpeakerContentAnimationAsync>d__62>(ref <ShowSpeakerContentAnimationAsync>d__);
		return <ShowSpeakerContentAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B4C RID: 76620 RVA: 0x00529450 File Offset: 0x00527650
	private void OnShowSpeakerContentAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		EChatTemplateType templateIndexByDisplayIndex = (EChatTemplateType)this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex);
		if (templateIndexByDisplayIndex != EChatTemplateType.Other && templateIndexByDisplayIndex != EChatTemplateType.Self)
		{
			return;
		}
		PhoneMsgOtherChatItem phoneMsgOtherChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as PhoneMsgOtherChatItem;
		if (phoneMsgOtherChatItem != null)
		{
			phoneMsgOtherChatItem.StopChatContentAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B4D RID: 76621 RVA: 0x00529498 File Offset: 0x00527698
	private void AddShowSystemTipsAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowSystemTipsAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowSystemTipsAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B4E RID: 76622 RVA: 0x005294F8 File Offset: 0x005276F8
	private UniTask ShowSystemTipsAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowSystemTipsAnimationAsync>d__65 <ShowSystemTipsAnimationAsync>d__;
		<ShowSystemTipsAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowSystemTipsAnimationAsync>d__.<>4__this = this;
		<ShowSystemTipsAnimationAsync>d__.chatIndex = chatIndex;
		<ShowSystemTipsAnimationAsync>d__.<>1__state = -1;
		<ShowSystemTipsAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowSystemTipsAnimationAsync>d__65>(ref <ShowSystemTipsAnimationAsync>d__);
		return <ShowSystemTipsAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B4F RID: 76623 RVA: 0x00529544 File Offset: 0x00527744
	private void OnShowSystemTipsAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex) != 2)
		{
			return;
		}
		TipsChatItem tipsChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as TipsChatItem;
		if (tipsChatItem != null)
		{
			tipsChatItem.StopTipsAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B50 RID: 76624 RVA: 0x00529588 File Offset: 0x00527788
	private void AddShowRewardAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowRewardAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowRewardAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B51 RID: 76625 RVA: 0x005295E8 File Offset: 0x005277E8
	private UniTask ShowRewardAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowRewardAnimationAsync>d__68 <ShowRewardAnimationAsync>d__;
		<ShowRewardAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowRewardAnimationAsync>d__.<>4__this = this;
		<ShowRewardAnimationAsync>d__.chatIndex = chatIndex;
		<ShowRewardAnimationAsync>d__.<>1__state = -1;
		<ShowRewardAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowRewardAnimationAsync>d__68>(ref <ShowRewardAnimationAsync>d__);
		return <ShowRewardAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B52 RID: 76626 RVA: 0x00529634 File Offset: 0x00527834
	private void OnShowRewardAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex) != 5)
		{
			return;
		}
		RewardChatItem rewardChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as RewardChatItem;
		if (rewardChatItem != null)
		{
			rewardChatItem.StopRewardAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B53 RID: 76627 RVA: 0x00529678 File Offset: 0x00527878
	private void AddShowBirthdayAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowBirthdayAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowBirthdayAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B54 RID: 76628 RVA: 0x005296D8 File Offset: 0x005278D8
	private UniTask ShowBirthdayAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowBirthdayAnimationAsync>d__71 <ShowBirthdayAnimationAsync>d__;
		<ShowBirthdayAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowBirthdayAnimationAsync>d__.<>4__this = this;
		<ShowBirthdayAnimationAsync>d__.chatIndex = chatIndex;
		<ShowBirthdayAnimationAsync>d__.<>1__state = -1;
		<ShowBirthdayAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowBirthdayAnimationAsync>d__71>(ref <ShowBirthdayAnimationAsync>d__);
		return <ShowBirthdayAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B55 RID: 76629 RVA: 0x00529724 File Offset: 0x00527924
	private void OnShowBirthdayAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex) != 4)
		{
			return;
		}
		BirthdayChatItem birthdayChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as BirthdayChatItem;
		if (birthdayChatItem != null)
		{
			birthdayChatItem.StopBirthdayAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B56 RID: 76630 RVA: 0x00529768 File Offset: 0x00527968
	private void AddShowTaskAnimationTask(int chatIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.ShowTaskAnimationAsync(chatIndex), delegate()
		{
			if (task != null)
			{
				this.OnShowTaskAnimationCanceled(task.Status, chatIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B57 RID: 76631 RVA: 0x005297C8 File Offset: 0x005279C8
	private UniTask ShowTaskAnimationAsync(int chatIndex)
	{
		PhoneSystemChatPanel.<ShowTaskAnimationAsync>d__74 <ShowTaskAnimationAsync>d__;
		<ShowTaskAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowTaskAnimationAsync>d__.<>4__this = this;
		<ShowTaskAnimationAsync>d__.chatIndex = chatIndex;
		<ShowTaskAnimationAsync>d__.<>1__state = -1;
		<ShowTaskAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowTaskAnimationAsync>d__74>(ref <ShowTaskAnimationAsync>d__);
		return <ShowTaskAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B58 RID: 76632 RVA: 0x00529814 File Offset: 0x00527A14
	private void OnShowTaskAnimationCanceled(EUiAsyncTaskStatus status, int chatIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		if (this.ChatMultiTemplateComponent.GetTemplateIndexByDisplayIndex(chatIndex) != 3)
		{
			return;
		}
		TaskChatItem taskChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatIndex) as TaskChatItem;
		if (taskChatItem != null)
		{
			taskChatItem.StopTaskAnimation();
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B59 RID: 76633 RVA: 0x00529858 File Offset: 0x00527A58
	private void AddEndLineTask()
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", new Func<UniTask>(this.ShowEndLineAsync), delegate()
		{
			if (task != null)
			{
				this.OnEndLineCanceled(task.Status);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B5A RID: 76634 RVA: 0x005298B0 File Offset: 0x00527AB0
	private UniTask ShowEndLineAsync()
	{
		PhoneSystemChatPanel.<ShowEndLineAsync>d__77 <ShowEndLineAsync>d__;
		<ShowEndLineAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowEndLineAsync>d__.<>4__this = this;
		<ShowEndLineAsync>d__.<>1__state = -1;
		<ShowEndLineAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ShowEndLineAsync>d__77>(ref <ShowEndLineAsync>d__);
		return <ShowEndLineAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B5B RID: 76635 RVA: 0x005298F3 File Offset: 0x00527AF3
	private void OnEndLineCanceled(EUiAsyncTaskStatus status)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		this.StopScrollTweenAnimation();
	}

	// Token: 0x06012B5C RID: 76636 RVA: 0x00529900 File Offset: 0x00527B00
	private void AddMaskEnableTask()
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", new Func<UniTask>(this.MaskEnableAsync), delegate()
		{
			this.OnMaskEnableCanceled(EUiAsyncTaskStatus.Running);
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B5D RID: 76637 RVA: 0x00529938 File Offset: 0x00527B38
	private UniTask MaskEnableAsync()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetCanScroll(false);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetRayCastTargetForScrollView(false);
		}
		this.IsPlaying = true;
		UUIItem item = base.GetItem(16);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B5E RID: 76638 RVA: 0x0052998B File Offset: 0x00527B8B
	private void OnMaskEnableCanceled(EUiAsyncTaskStatus status)
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetCanScroll(true);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetRayCastTargetForScrollView(true);
		}
		this.IsPlaying = false;
	}

	// Token: 0x06012B5F RID: 76639 RVA: 0x005299BC File Offset: 0x00527BBC
	private void AddMaskDisableTask()
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", new Func<UniTask>(this.MaskDisableAsync), delegate()
		{
			this.OnMaskDisableCanceled(EUiAsyncTaskStatus.Running);
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B60 RID: 76640 RVA: 0x005299F4 File Offset: 0x00527BF4
	private UniTask MaskDisableAsync()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetCanScroll(true);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetRayCastTargetForScrollView(true);
		}
		this.IsPlaying = false;
		this.CheckNaviBtnBlankShow();
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B61 RID: 76641 RVA: 0x00529A2E File Offset: 0x00527C2E
	private void OnMaskDisableCanceled(EUiAsyncTaskStatus status)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar != null)
		{
			scrollViewWithScrollbar.SetCanScroll(true);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar2 = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar2 != null)
		{
			scrollViewWithScrollbar2.SetRayCastTargetForScrollView(true);
		}
		this.IsPlaying = false;
	}

	// Token: 0x06012B62 RID: 76642 RVA: 0x00529A64 File Offset: 0x00527C64
	[NullableContext(1)]
	private void AddUpdateProgressTask(ShortMessageDisplayData displayData)
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", () => this.UpdateProgressAsync(displayData), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B63 RID: 76643 RVA: 0x00529AA5 File Offset: 0x00527CA5
	[NullableContext(1)]
	private UniTask UpdateProgressAsync(ShortMessageDisplayData displayData)
	{
		return this.UpdateProgressToServerAsync(displayData);
	}

	// Token: 0x06012B64 RID: 76644 RVA: 0x00529AB0 File Offset: 0x00527CB0
	[NullableContext(1)]
	private UniTask UpdateProgressToServerAsync(ShortMessageDisplayData displayData)
	{
		PhoneSystemChatPanel.<UpdateProgressToServerAsync>d__87 <UpdateProgressToServerAsync>d__;
		<UpdateProgressToServerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateProgressToServerAsync>d__.displayData = displayData;
		<UpdateProgressToServerAsync>d__.<>1__state = -1;
		<UpdateProgressToServerAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<UpdateProgressToServerAsync>d__87>(ref <UpdateProgressToServerAsync>d__);
		return <UpdateProgressToServerAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B65 RID: 76645 RVA: 0x00529AF4 File Offset: 0x00527CF4
	private void AddExecuteEndCallBackTask()
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", new Func<UniTask>(this.ExecuteEndCallBackAsync), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B66 RID: 76646 RVA: 0x00529B21 File Offset: 0x00527D21
	private UniTask ExecuteEndCallBackAsync()
	{
		if (this.DisplayData != null)
		{
			Action<int> onMsgReadFinished = this.OnMsgReadFinished;
			if (onMsgReadFinished != null)
			{
				onMsgReadFinished(this.DisplayData.ShortMsgId);
			}
			this.CheckNaviBtnBlankShow();
		}
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B67 RID: 76647 RVA: 0x00529B54 File Offset: 0x00527D54
	private void AddSelectOptionTask(int chatItemIndex, int selectedIndex)
	{
		PhoneSystemChatPanel.<>c__DisplayClass90_0 CS$<>8__locals1 = new PhoneSystemChatPanel.<>c__DisplayClass90_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.chatItemIndex = chatItemIndex;
		CS$<>8__locals1.selectedIndex = selectedIndex;
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", delegate()
		{
			PhoneSystemChatPanel.<>c__DisplayClass90_0.<<AddSelectOptionTask>b__0>d <<AddSelectOptionTask>b__0>d;
			<<AddSelectOptionTask>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddSelectOptionTask>b__0>d.<>4__this = CS$<>8__locals1;
			<<AddSelectOptionTask>b__0>d.<>1__state = -1;
			<<AddSelectOptionTask>b__0>d.<>t__builder.Start<PhoneSystemChatPanel.<>c__DisplayClass90_0.<<AddSelectOptionTask>b__0>d>(ref <<AddSelectOptionTask>b__0>d);
			return <<AddSelectOptionTask>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B68 RID: 76648 RVA: 0x00529B9C File Offset: 0x00527D9C
	private UniTask SelectOptionAsync(int chatItemIndex, int selectedIndex)
	{
		PhoneSystemChatPanel.<SelectOptionAsync>d__91 <SelectOptionAsync>d__;
		<SelectOptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SelectOptionAsync>d__.<>4__this = this;
		<SelectOptionAsync>d__.chatItemIndex = chatItemIndex;
		<SelectOptionAsync>d__.selectedIndex = selectedIndex;
		<SelectOptionAsync>d__.<>1__state = -1;
		<SelectOptionAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<SelectOptionAsync>d__91>(ref <SelectOptionAsync>d__);
		return <SelectOptionAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B69 RID: 76649 RVA: 0x00529BF0 File Offset: 0x00527DF0
	private void AddAnswerItemHideOptionTask(int chatItemIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.AnswerItemHideOptionAsync(chatItemIndex), delegate()
		{
			if (task != null)
			{
				this.OnAnswerItemHideOptionCanceled(task.Status, chatItemIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B6A RID: 76650 RVA: 0x00529C50 File Offset: 0x00527E50
	private UniTask AnswerItemHideOptionAsync(int chatItemIndex)
	{
		PhoneSystemChatPanel.<AnswerItemHideOptionAsync>d__93 <AnswerItemHideOptionAsync>d__;
		<AnswerItemHideOptionAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AnswerItemHideOptionAsync>d__.<>4__this = this;
		<AnswerItemHideOptionAsync>d__.chatItemIndex = chatItemIndex;
		<AnswerItemHideOptionAsync>d__.<>1__state = -1;
		<AnswerItemHideOptionAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<AnswerItemHideOptionAsync>d__93>(ref <AnswerItemHideOptionAsync>d__);
		return <AnswerItemHideOptionAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B6B RID: 76651 RVA: 0x00529C9C File Offset: 0x00527E9C
	private void OnAnswerItemHideOptionCanceled(EUiAsyncTaskStatus status, int chatItemIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		PhoneMsgSelfChatItem phoneMsgSelfChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatItemIndex) as PhoneMsgSelfChatItem;
		if (phoneMsgSelfChatItem != null)
		{
			phoneMsgSelfChatItem.StopOptionHideAnimation();
		}
		this.NeedCheckAdapt = false;
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
		if (verticalLayout == null)
		{
			return;
		}
		verticalLayout.SetHeightFitToChildren(true);
	}

	// Token: 0x06012B6C RID: 76652 RVA: 0x00529CE4 File Offset: 0x00527EE4
	private void AddAnswerItemShowChatContentTask(int chatItemIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.AnswerItemShowChatContentAsync(chatItemIndex), delegate()
		{
			if (task != null)
			{
				this.OnAnswerItemShowChatContentCanceled(task.Status, chatItemIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B6D RID: 76653 RVA: 0x00529D44 File Offset: 0x00527F44
	private UniTask AnswerItemShowChatContentAsync(int chatItemIndex)
	{
		PhoneSystemChatPanel.<AnswerItemShowChatContentAsync>d__96 <AnswerItemShowChatContentAsync>d__;
		<AnswerItemShowChatContentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AnswerItemShowChatContentAsync>d__.<>4__this = this;
		<AnswerItemShowChatContentAsync>d__.chatItemIndex = chatItemIndex;
		<AnswerItemShowChatContentAsync>d__.<>1__state = -1;
		<AnswerItemShowChatContentAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<AnswerItemShowChatContentAsync>d__96>(ref <AnswerItemShowChatContentAsync>d__);
		return <AnswerItemShowChatContentAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B6E RID: 76654 RVA: 0x00529D90 File Offset: 0x00527F90
	private void OnAnswerItemShowChatContentCanceled(EUiAsyncTaskStatus status, int chatItemIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		PhoneMsgSelfChatItem phoneMsgSelfChatItem = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(chatItemIndex) as PhoneMsgSelfChatItem;
		if (phoneMsgSelfChatItem == null)
		{
			return;
		}
		phoneMsgSelfChatItem.StopChatContentAnimation(true);
	}

	// Token: 0x06012B6F RID: 76655 RVA: 0x00529DC0 File Offset: 0x00527FC0
	private void AddAfterAnswerTask(int chatItemIndex)
	{
		UiAsyncTask task = null;
		task = new UiAsyncTask("ChatPerformance", () => this.AfterAnswerAsync(chatItemIndex), delegate()
		{
			if (task != null)
			{
				this.OnAfterAnswerCanceled(task.Status, chatItemIndex);
			}
		});
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B70 RID: 76656 RVA: 0x00529E1D File Offset: 0x0052801D
	private UniTask AfterAnswerAsync(int chatItemIndex)
	{
		this.AddAnswerItemHideOptionTask(chatItemIndex);
		this.AddAnswerItemShowChatContentTask(chatItemIndex);
		this.AddAllMessageTasks();
		this.AddMaskDisableTask();
		return UniTask.CompletedTask;
	}

	// Token: 0x06012B71 RID: 76657 RVA: 0x00529E3E File Offset: 0x0052803E
	private void OnAfterAnswerCanceled(EUiAsyncTaskStatus status, int chatItemIndex)
	{
		if (status != EUiAsyncTaskStatus.Running)
		{
			return;
		}
		base.CancelAllAsyncTask();
	}

	// Token: 0x06012B72 RID: 76658 RVA: 0x00529E4C File Offset: 0x0052804C
	private void AddReceiveRewardTask()
	{
		UiAsyncTask task = new UiAsyncTask("ChatPerformance", new Func<UniTask>(this.ReceiveRewardAsync), null);
		base.RunAsyncTask(task);
	}

	// Token: 0x06012B73 RID: 76659 RVA: 0x00529E7C File Offset: 0x0052807C
	private UniTask ReceiveRewardAsync()
	{
		PhoneSystemChatPanel.<ReceiveRewardAsync>d__102 <ReceiveRewardAsync>d__;
		<ReceiveRewardAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ReceiveRewardAsync>d__.<>4__this = this;
		<ReceiveRewardAsync>d__.<>1__state = -1;
		<ReceiveRewardAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<ReceiveRewardAsync>d__102>(ref <ReceiveRewardAsync>d__);
		return <ReceiveRewardAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B74 RID: 76660 RVA: 0x00529EC0 File Offset: 0x005280C0
	private UniTask PlayScrollTweenAnimationAsync()
	{
		PhoneSystemChatPanel.<PlayScrollTweenAnimationAsync>d__103 <PlayScrollTweenAnimationAsync>d__;
		<PlayScrollTweenAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayScrollTweenAnimationAsync>d__.<>4__this = this;
		<PlayScrollTweenAnimationAsync>d__.<>1__state = -1;
		<PlayScrollTweenAnimationAsync>d__.<>t__builder.Start<PhoneSystemChatPanel.<PlayScrollTweenAnimationAsync>d__103>(ref <PlayScrollTweenAnimationAsync>d__);
		return <PlayScrollTweenAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B75 RID: 76661 RVA: 0x00529F04 File Offset: 0x00528104
	private void SkipPlayScrollTweenAnimation()
	{
		this.StopScrollTweenAnimation();
		this.ScrollToChatItem(this.DisplayedChatScrollViewDataList.Count - 1, false);
		if (this.ScrollTweenCustomPromise != null)
		{
			this.ScrollTweenCustomPromise.SetResult(true);
		}
		if (this.ScrollTweenHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.ScrollTweenHandle);
		}
		this.ScrollTweenHandle = null;
	}

	// Token: 0x06012B76 RID: 76662 RVA: 0x00529F5F File Offset: 0x0052815F
	private void StopScrollTweenAnimation()
	{
		this.NeedScrollTween = false;
		this.NeedScrollOnNextTick = false;
		base.GetScrollViewWithScrollbar(4).StopMovement();
	}

	// Token: 0x06012B77 RID: 76663 RVA: 0x00529F7B File Offset: 0x0052817B
	private void OnOptionItemClick(int chatItemIndex, int selectedIndex)
	{
		if (this.IsPlaying)
		{
			return;
		}
		if (this.DisplayData.ChatDataList[chatItemIndex] == null)
		{
			return;
		}
		this.AddMaskEnableTask();
		this.AddSelectOptionTask(chatItemIndex, selectedIndex);
		this.AddAfterAnswerTask(chatItemIndex);
	}

	// Token: 0x06012B78 RID: 76664 RVA: 0x00529FB0 File Offset: 0x005281B0
	public void LogReport(int shortMessageId, int viewType)
	{
		PhoneMsgConfig instance = ConfigBase<PhoneMsgConfig>.Instance;
		PhoneMsgModel instance2 = ModelBase<PhoneMsgModel>.Instance;
		ShortMessage? phoneMsgConfig = instance.GetPhoneMsgConfig(shortMessageId);
		if (phoneMsgConfig == null)
		{
			return;
		}
		int whichChat = phoneMsgConfig.Value.WhichChat;
		ChatPartner? chatPartnerConfigNew = instance2.GetChatPartnerConfigNew(whichChat);
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = instance2.GetPhoneMsgShortMsgDataByShortMsgId(shortMessageId);
		if (phoneMsgShortMsgDataByShortMsgId == null)
		{
			return;
		}
		OnSelectShortMessageLogEvent onSelectShortMessageLogEvent = new OnSelectShortMessageLogEvent();
		onSelectShortMessageLogEvent.i_id = shortMessageId;
		onSelectShortMessageLogEvent.i_type = ((chatPartnerConfigNew != null && chatPartnerConfigNew.Value.IsGroupChat) ? 1 : 2);
		onSelectShortMessageLogEvent.i_reason = viewType;
		onSelectShortMessageLogEvent.l_received_time = (long)((int)phoneMsgShortMsgDataByShortMsgId.UnLockTime);
		onSelectShortMessageLogEvent.i_role_id = phoneMsgConfig.Value.WhichChat;
		ControllerBase<LogReportController>.Instance.LogReport(onSelectShortMessageLogEvent);
	}

	// Token: 0x06012B79 RID: 76665 RVA: 0x0052A070 File Offset: 0x00528270
	private void OnChatItemClick(int chatItemIndex)
	{
		PhoneMsgChatData phoneMsgChatData = this.DisplayData.ChatDataList[chatItemIndex];
		if (phoneMsgChatData == null)
		{
			return;
		}
		if (phoneMsgChatData.ContentType == EChatMsgType.Voice)
		{
			this.OnVoiceChatItemClick(chatItemIndex);
		}
	}

	// Token: 0x06012B7A RID: 76666 RVA: 0x0052A0A4 File Offset: 0x005282A4
	private void SetPlayerState(EFavorPlayerStatus playerStatus)
	{
		this.CurPlayerStatus = playerStatus;
	}

	// Token: 0x06012B7B RID: 76667 RVA: 0x0052A0B0 File Offset: 0x005282B0
	private void PlayVoice(int index)
	{
		if (!this.IsPlaying)
		{
			this.NeedScrollOnNextTick = true;
			this.NeedScrollToIndex = index;
			this.NeedScrollTween = true;
		}
		PhoneMsgChatData phoneMsgChatData = this.DisplayData.ChatDataList[index];
		PhoneMsgAudioComponent voiceAudioComp = this.VoiceAudioComp;
		if (voiceAudioComp != null)
		{
			voiceAudioComp.StopAudio();
		}
		PhoneMsgAudioComponent voiceAudioComp2 = this.VoiceAudioComp;
		if (voiceAudioComp2 != null)
		{
			voiceAudioComp2.TryPlayPhoneMessageVoice(phoneMsgChatData.TalkItem);
		}
		this.SetPlayerState(EFavorPlayerStatus.Play);
		this.CurPlayingVoiceItemIndex = index;
	}

	// Token: 0x06012B7C RID: 76668 RVA: 0x0052A123 File Offset: 0x00528323
	private void StopVoice()
	{
		PhoneMsgAudioComponent voiceAudioComp = this.VoiceAudioComp;
		if (voiceAudioComp != null)
		{
			voiceAudioComp.StopAudio();
		}
		this.ResetVoicePlaying();
	}

	// Token: 0x06012B7D RID: 76669 RVA: 0x0052A13C File Offset: 0x0052833C
	private EFavorPlayerStatus PlayOrStopVoiceByIndex(int index)
	{
		if (this.CurPlayerStatus == EFavorPlayerStatus.Play && this.CurPlayingVoiceItemIndex == index)
		{
			return EFavorPlayerStatus.Stop;
		}
		return EFavorPlayerStatus.Play;
	}

	// Token: 0x06012B7E RID: 76670 RVA: 0x0052A152 File Offset: 0x00528352
	private void OnVoiceAudioStart()
	{
		this.SetPlayerState(EFavorPlayerStatus.Play);
	}

	// Token: 0x06012B7F RID: 76671 RVA: 0x0052A15B File Offset: 0x0052835B
	private void OnVoiceAudioEnd()
	{
		if (!this.TryJumpToNextUnPlayedVoiceItem())
		{
			this.ResetVoicePlaying();
		}
	}

	// Token: 0x06012B80 RID: 76672 RVA: 0x0052A16B File Offset: 0x0052836B
	private void OnVoiceAudioLoadTimeout()
	{
		this.ResetVoicePlaying();
	}

	// Token: 0x06012B81 RID: 76673 RVA: 0x0052A174 File Offset: 0x00528374
	private void OnVoiceChatItemClick(int itemIndex)
	{
		if (this.VoiceAudioComp == null)
		{
			return;
		}
		PhoneMsgChatData phoneMsgChatData = this.DisplayData.ChatDataList[itemIndex];
		this.IsNeedJump = !phoneMsgChatData.IsVoicePlayed;
		ISyncGridProxy proxyByDisplayIndex = this.ChatMultiTemplateComponent.GetProxyByDisplayIndex(itemIndex);
		EPhoneMsgContentType chatContentType = phoneMsgChatData.ChatContentType;
		IPhoneMsgChatItem phoneMsgChatItem;
		if (chatContentType != EPhoneMsgContentType.Other)
		{
			if (chatContentType != EPhoneMsgContentType.Self)
			{
				return;
			}
			phoneMsgChatItem = (proxyByDisplayIndex as PhoneMsgSelfChatItem);
		}
		else
		{
			phoneMsgChatItem = (proxyByDisplayIndex as PhoneMsgOtherChatItem);
		}
		EFavorPlayerStatus efavorPlayerStatus = this.PlayOrStopVoiceByIndex(itemIndex);
		if (phoneMsgChatItem == null)
		{
			return;
		}
		if (efavorPlayerStatus == EFavorPlayerStatus.Play)
		{
			if (this.CurPlayingVoiceItemIndex >= 0)
			{
				this.StopVoice();
			}
			this.CurPlayingChatItemProxy = phoneMsgChatItem;
			this.CurPlayingChatItemProxy.ShowVoiceTextPanel(delegate
			{
				if (!this.IsPlaying)
				{
					this.NeedScrollOnNextTick = true;
					this.NeedScrollToIndex = itemIndex;
					this.NeedScrollTween = true;
				}
			});
			this.CurPlayingChatItemProxy.PlayVoicePlayingAnimationAsync();
			ModelBase<PhoneMsgModel>.Instance.AddVoiceRedDot(phoneMsgChatData.VoiceEventHash);
			this.PlayVoice(itemIndex);
			return;
		}
		if (efavorPlayerStatus != EFavorPlayerStatus.Stop)
		{
			return;
		}
		this.StopVoice();
	}

	// Token: 0x06012B82 RID: 76674 RVA: 0x0052A274 File Offset: 0x00528474
	private bool TryJumpToNextUnPlayedVoiceItem()
	{
		if (!this.IsNeedJump)
		{
			return false;
		}
		if (this.CurPlayingVoiceItemIndex >= 0 && this.DisplayData != null)
		{
			int count = this.DisplayData.ChatDataList.Count;
			for (int i = this.CurPlayingVoiceItemIndex + 1; i < count; i++)
			{
				PhoneMsgChatData phoneMsgChatData = this.DisplayData.ChatDataList[i];
				if (phoneMsgChatData != null && phoneMsgChatData.ContentType == EChatMsgType.Voice && !phoneMsgChatData.IsVoicePlayed)
				{
					this.IsNeedJump = false;
					this.OnVoiceChatItemClick(i);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06012B83 RID: 76675 RVA: 0x0052A2F8 File Offset: 0x005284F8
	private void OnScrollViewPointerUp(ULGUIPointerEventData eventData)
	{
		if (eventData == null || eventData.dragComponent != null)
		{
			return;
		}
		if (this.CurPlayerStatus == EFavorPlayerStatus.Play)
		{
			this.IsNeedJump = true;
			if (!this.TryJumpToNextUnPlayedVoiceItem())
			{
				this.ResetVoicePlaying();
			}
		}
	}

	// Token: 0x06012B84 RID: 76676 RVA: 0x0052A323 File Offset: 0x00528523
	private void ResetVoicePlaying()
	{
		this.SetPlayerState(EFavorPlayerStatus.Stop);
		IPhoneMsgChatItem curPlayingChatItemProxy = this.CurPlayingChatItemProxy;
		if (curPlayingChatItemProxy != null)
		{
			curPlayingChatItemProxy.SkipVoicePlayingAnimation();
		}
		this.CurPlayingVoiceItemIndex = -1;
		this.CurPlayingChatItemProxy = null;
	}

	// Token: 0x04009233 RID: 37427
	private ShortMessageDisplayData DisplayData;

	// Token: 0x04009234 RID: 37428
	[Nullable(1)]
	private readonly List<IMultiTemplateGridData> DisplayedChatScrollViewDataList = new List<IMultiTemplateGridData>();

	// Token: 0x04009235 RID: 37429
	private Ticker Ticker;

	// Token: 0x04009236 RID: 37430
	private bool NeedScrollOnNextTick;

	// Token: 0x04009237 RID: 37431
	private bool ReadyToScroll;

	// Token: 0x04009238 RID: 37432
	private bool NeedScrollTween;

	// Token: 0x04009239 RID: 37433
	private bool NeedCheckAdapt;

	// Token: 0x0400923A RID: 37434
	private bool NeedScrollToEndOnLateTick;

	// Token: 0x0400923B RID: 37435
	private int NeedScrollToIndex = -1;

	// Token: 0x0400923C RID: 37436
	private bool IsPlaying;

	// Token: 0x0400923D RID: 37437
	private bool IsInInputtingAnimation;

	// Token: 0x0400923E RID: 37438
	private int InputtingAnimationChatIndex = -1;

	// Token: 0x0400923F RID: 37439
	private TimerHandle ScrollTweenHandle;

	// Token: 0x04009240 RID: 37440
	private CustomPromise<bool> ScrollTweenCustomPromise;

	// Token: 0x04009241 RID: 37441
	private EFavorPlayerStatus CurPlayerStatus = EFavorPlayerStatus.Stop;

	// Token: 0x04009242 RID: 37442
	private PhoneMsgAudioComponent VoiceAudioComp;

	// Token: 0x04009243 RID: 37443
	private UUIScrollViewWithScrollbarComponent ScrollComponent;

	// Token: 0x04009244 RID: 37444
	private int CurPlayingVoiceItemIndex = -1;

	// Token: 0x04009245 RID: 37445
	private bool IsNeedJump;

	// Token: 0x04009246 RID: 37446
	private IPhoneMsgChatItem CurPlayingChatItemProxy;

	// Token: 0x04009247 RID: 37447
	private MultiTemplateComponent ChatMultiTemplateComponent;

	// Token: 0x04009248 RID: 37448
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<string> OnAfterOneMsgShow;

	// Token: 0x04009249 RID: 37449
	public Action<int> OnMsgReadFinished;

	// Token: 0x020088B6 RID: 34998
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E2A4 RID: 189092
		NameText,
		// Token: 0x0402E2A5 RID: 189093
		DescriptionText,
		// Token: 0x0402E2A6 RID: 189094
		GroupPanel,
		// Token: 0x0402E2A7 RID: 189095
		GroupNumberText,
		// Token: 0x0402E2A8 RID: 189096
		ChatScrollView,
		// Token: 0x0402E2A9 RID: 189097
		ChatContent,
		// Token: 0x0402E2AA RID: 189098
		ChatBackgroundTexture,
		// Token: 0x0402E2AB RID: 189099
		ChatLeftTemplateItem,
		// Token: 0x0402E2AC RID: 189100
		ChatRightTemplateItem,
		// Token: 0x0402E2AD RID: 189101
		ChatTipsTemplateItem,
		// Token: 0x0402E2AE RID: 189102
		ChatTaskTemplateItem,
		// Token: 0x0402E2AF RID: 189103
		ChatBirthdayTemplateItem,
		// Token: 0x0402E2B0 RID: 189104
		ChatRewardTemplateItem,
		// Token: 0x0402E2B1 RID: 189105
		ChatEndLineTemplateItem,
		// Token: 0x0402E2B2 RID: 189106
		BtnMask,
		// Token: 0x0402E2B3 RID: 189107
		TexChatBgDefault,
		// Token: 0x0402E2B4 RID: 189108
		NaviBtnBlank
	}
}
