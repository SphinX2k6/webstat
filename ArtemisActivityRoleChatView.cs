using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020011A7 RID: 4519
[NullableContext(1)]
[Nullable(0)]
public class ArtemisActivityRoleChatView : UiViewBase
{
	// Token: 0x060076D7 RID: 30423 RVA: 0x001F171A File Offset: 0x001EF91A
	public ArtemisActivityRoleChatView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060076D8 RID: 30424 RVA: 0x001F1724 File Offset: 0x001EF924
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIArtText)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
	}

	// Token: 0x060076D9 RID: 30425 RVA: 0x001F17EC File Offset: 0x001EF9EC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnArtemisStateRefresh, new Action(this.OnStateRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
	}

	// Token: 0x060076DA RID: 30426 RVA: 0x001F1826 File Offset: 0x001EFA26
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnArtemisStateRefresh, new Action(this.OnStateRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
	}

	// Token: 0x060076DB RID: 30427 RVA: 0x001F1860 File Offset: 0x001EFA60
	private void OnStateRefresh()
	{
		this.UpdateShowDayContent(ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex);
		this.RefreshDayTabsState();
	}

	// Token: 0x060076DC RID: 30428 RVA: 0x001F1878 File Offset: 0x001EFA78
	protected override UniTask OnBeforeStartAsync()
	{
		ArtemisActivityRoleChatView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ArtemisActivityRoleChatView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060076DD RID: 30429 RVA: 0x001F18BB File Offset: 0x001EFABB
	protected override void OnBeforeShow()
	{
		this.RefreshDays();
		this.UpdateShowDayContent(ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex);
		this.SetCurrentContentBg(ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex + 1);
	}

	// Token: 0x060076DE RID: 30430 RVA: 0x001F18E5 File Offset: 0x001EFAE5
	protected override void OnBeforeDestroy()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor == null)
		{
			return;
		}
		rootActor.OnSequencePlayEvent.Unbind();
	}

	// Token: 0x060076DF RID: 30431 RVA: 0x001F18FC File Offset: 0x001EFAFC
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "Dele_M")
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ArtemisActivityRoleChatView, false);
		}
	}

	// Token: 0x060076E0 RID: 30432 RVA: 0x001F1920 File Offset: 0x001EFB20
	private void InitCaption()
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			this.CaptionItem = new PopupCaptionItem(item);
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.CaptionItem.SetTitle(this.ArtemisData.GetTitle());
		}
	}

	// Token: 0x060076E1 RID: 30433 RVA: 0x001F1974 File Offset: 0x001EFB74
	private void InitDaysScrollView()
	{
		if (this.DaysScroll != null)
		{
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		if (scrollViewWithScrollbar != null)
		{
			this.DaysScroll = new GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData>(scrollViewWithScrollbar, new Func<ArtemisDaysItem>(this.CreateDaysItem), null, false, null);
		}
	}

	// Token: 0x060076E2 RID: 30434 RVA: 0x001F19B0 File Offset: 0x001EFBB0
	private ArtemisDaysItem CreateDaysItem()
	{
		ArtemisDaysItem artemisDaysItem = new ArtemisDaysItem();
		artemisDaysItem.SetClickCallback(new Action<int>(this.OnDayItemClick));
		return artemisDaysItem;
	}

	// Token: 0x060076E3 RID: 30435 RVA: 0x001F19C9 File Offset: 0x001EFBC9
	private void RefreshDays()
	{
		this.RefreshDayTabsState();
	}

	// Token: 0x060076E4 RID: 30436 RVA: 0x001F19D4 File Offset: 0x001EFBD4
	private void RefreshDayTabsState()
	{
		ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
		IReadOnlyList<Artemis> readOnlyList = (instance != null) ? instance.GetArtemisGroupByActivityId(this.ArtemisData.GetCacheActivityId) : null;
		if (readOnlyList == null || readOnlyList.Count == 0 || this.DaysScroll == null)
		{
			return;
		}
		List<IArtemisDayItemData> list = new List<IArtemisDayItemData>();
		foreach (Artemis artemis in readOnlyList)
		{
			ArtemisDayItemData artemisDayItemData = new ArtemisDayItemData();
			artemisDayItemData.Index = artemis.OpenDay;
			ArtemisActivityData artemisData = this.ArtemisData;
			artemisDayItemData.State = ((artemisData != null) ? artemisData.GetArtemisStatus(artemis.OpenDay) : null);
			ArtemisDayItemData item = artemisDayItemData;
			list.Add(item);
		}
		GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> daysScroll = this.DaysScroll;
		if (daysScroll == null)
		{
			return;
		}
		daysScroll.RefreshByData(list, delegate
		{
			GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> daysScroll2 = this.DaysScroll;
			UUIItem uuiitem = (daysScroll2 != null) ? daysScroll2.GetItemByIndex(ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex) : null;
			if (uuiitem != null)
			{
				GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> daysScroll3 = this.DaysScroll;
				if (daysScroll3 == null)
				{
					return;
				}
				daysScroll3.LateScrollTo(uuiitem, null, false);
			}
		}, false);
	}

	// Token: 0x060076E5 RID: 30437 RVA: 0x001F1AB0 File Offset: 0x001EFCB0
	private void OnDayItemClick(int index)
	{
		if (!this.CheckUnlockDayItem(index))
		{
			return;
		}
		if (ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex != index)
		{
			ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex = index;
			this.UpdateShowDayContent(index);
			this.SetCurrentContentBg(index + 1);
		}
		this.RefreshDayTabsState();
	}

	// Token: 0x060076E6 RID: 30438 RVA: 0x001F1AEC File Offset: 0x001EFCEC
	private void SetCurrentContentBg(int index)
	{
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		string text;
		if (instance == null)
		{
			text = null;
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("T_ChatBallBg_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(index);
			text = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		string path = text;
		base.TrySetTextureByPath(path, base.GetTexture(6), null, null);
	}

	// Token: 0x060076E7 RID: 30439 RVA: 0x001F1B48 File Offset: 0x001EFD48
	private bool CheckUnlockDayItem(int index)
	{
		ArtemisActivityData artemisData = this.ArtemisData;
		EArtemisState? eartemisState = (artemisData != null) ? artemisData.GetArtemisStatus(index) : null;
		EArtemisState eartemisState2 = EArtemisState.Lock;
		if (!(eartemisState.GetValueOrDefault() == eartemisState2 & eartemisState != null))
		{
			return true;
		}
		ArtemisActivityData artemisData2 = this.ArtemisData;
		int num = (artemisData2 != null) ? artemisData2.GetUnlockIndex : 0;
		ArtemisActivityData artemisData3 = this.ArtemisData;
		int num2 = (artemisData3 != null) ? artemisData3.GetRewardedIndex : 0;
		if (index > num2 && index < num)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Activity_ArtemisChatLockedTips_1", null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
			return false;
		}
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew("Activity_ArtemisChatLockedTips_2", null);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew2);
		return false;
	}

	// Token: 0x060076E8 RID: 30440 RVA: 0x001F1BEC File Offset: 0x001EFDEC
	private void UpdateShowDayContent(int index)
	{
		GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> daysScroll = this.DaysScroll;
		if (daysScroll != null)
		{
			daysScroll.SelectGridProxy(index, false);
		}
		this.SwitchChatContent(index);
		this.SetUnlockDayLogEvent();
	}

	// Token: 0x060076E9 RID: 30441 RVA: 0x001F1C10 File Offset: 0x001EFE10
	private void SwitchChatContent(int index)
	{
		if (index < 0)
		{
			return;
		}
		this.SetTitleCurrentDayIndex();
		ArtemisActivityData artemisData = this.ArtemisData;
		EArtemisState? eartemisState = (artemisData != null) ? artemisData.GetArtemisStatus(index) : null;
		if (eartemisState != null)
		{
			EArtemisState valueOrDefault = eartemisState.GetValueOrDefault();
			if (valueOrDefault != EArtemisState.Unlock)
			{
				if (valueOrDefault != EArtemisState.Rewarded)
				{
					return;
				}
				ArtemisDialogueBoxPanel dialoguePanel = this.DialoguePanel;
				if (dialoguePanel != null)
				{
					dialoguePanel.SetShowRewardItems(true);
				}
				ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
				ArtemisActivityData artemisData2 = this.ArtemisData;
				Artemis? artemisByActivityIdAndDay = instance.GetArtemisByActivityIdAndDay((artemisData2 != null) ? artemisData2.GetCacheActivityId : 0, index);
				List<TItem> list = (artemisByActivityIdAndDay != null) ? this.GetRewardItem(artemisByActivityIdAndDay.Value.DropId) : new List<TItem>();
				ArtemisDialogueBoxPanel dialoguePanel2 = this.DialoguePanel;
				if (dialoguePanel2 != null)
				{
					dialoguePanel2.SetRewardItems(list ?? new List<TItem>(), true);
				}
				ArtemisDialogueBoxPanel dialoguePanel3 = this.DialoguePanel;
				if (dialoguePanel3 != null)
				{
					dialoguePanel3.ScrollToTop(false);
				}
				bool isLockStatus = false;
				bool isShowEffect = false;
				ArtemisActivityData artemisData3 = this.ArtemisData;
				this.ShowDialogue(isLockStatus, isShowEffect, (artemisData3 != null) ? artemisData3.GetCacheActivityId : 0, index);
			}
			else
			{
				ArtemisDialogueBoxPanel dialoguePanel4 = this.DialoguePanel;
				if (dialoguePanel4 != null)
				{
					dialoguePanel4.SetShowRewardItems(false);
				}
				ArtemisDialogueBoxPanel dialoguePanel5 = this.DialoguePanel;
				if (dialoguePanel5 != null)
				{
					dialoguePanel5.ScrollToTop(true);
				}
				bool isLockStatus2 = true;
				bool isShowEffect2 = true;
				ArtemisActivityData artemisData4 = this.ArtemisData;
				this.ShowDialogue(isLockStatus2, isShowEffect2, (artemisData4 != null) ? artemisData4.GetCacheActivityId : 0, index);
				if (!this.WaitFixedFinish)
				{
					this.WaitFixedFinish = true;
					int value = ConfigCommonParamById.GetIntConfig("ArtemisWaitFixedTime").Value;
					if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ArtemisActivityCertificationView))
					{
						Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ArtemisActivityRoleChatView, true);
						TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
						{
							Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ArtemisActivityRoleChatView, false);
							ArtemisActivityCertificationViewParams param = new ArtemisActivityCertificationViewParams
							{
								IsPlayFixedDone = false,
								Callback = new Action(this.FinishCertificationView)
							};
							Singleton<UiManager>.Instance.OpenView(EUiViewName.ArtemisActivityCertificationView, param, null);
						}, (float)(value * 1000), null, null, true, 1f);
						return;
					}
				}
			}
		}
	}

	// Token: 0x060076EA RID: 30442 RVA: 0x001F1DC0 File Offset: 0x001EFFC0
	private void FinishCertificationView()
	{
		int currentDayIndex = ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex;
		ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
		Artemis? artemis = (instance != null) ? instance.GetArtemisByActivityIdAndDay(this.ArtemisData.GetCacheActivityId, currentDayIndex) : null;
		if (artemis == null)
		{
			return;
		}
		ArtemisQteViewParams param = new ArtemisQteViewParams
		{
			GamePlayId = artemis.Value.QteId,
			Index = currentDayIndex,
			CallBack = new Action(this.FinishFixed)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ArtemisQteView, param, delegate(bool _, int _)
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ArtemisActivityCertificationView, null);
		});
	}

	// Token: 0x060076EB RID: 30443 RVA: 0x001F1E6C File Offset: 0x001F006C
	private void FinishFixed()
	{
		ArtemisActivityCertificationViewParams param = new ArtemisActivityCertificationViewParams
		{
			Callback = new Action(this.FinishFixedSuccess),
			IsPlayFixedDone = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ArtemisActivityCertificationView, param, null);
	}

	// Token: 0x060076EC RID: 30444 RVA: 0x001F1EAC File Offset: 0x001F00AC
	private void FinishFixedSuccess()
	{
		int currentDayIndex = ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex;
		GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> daysScroll = this.DaysScroll;
		ArtemisDaysItem artemisDaysItem = (daysScroll != null) ? daysScroll.GetScrollItemByIndex(currentDayIndex) : null;
		if (artemisDaysItem != null && artemisDaysItem != null)
		{
			artemisDaysItem.LoadMaterial(false);
		}
		ControllerBase<ArtemisActivityController>.Instance.RequestArtemisStatus(this.ArtemisData, currentDayIndex + 1, delegate(bool isError)
		{
			this.WaitFixedFinish = false;
			if (isError)
			{
				base.CloseMe(null);
			}
		});
	}

	// Token: 0x060076ED RID: 30445 RVA: 0x001F1F04 File Offset: 0x001F0104
	private void OnCloseRewardView()
	{
		base.PlaySequence("Fix_Done", null, false);
		ArtemisDialogueBoxPanel dialoguePanel = this.DialoguePanel;
		if (dialoguePanel != null)
		{
			dialoguePanel.PlayFixDoneSequence();
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.ArtemisActivityRoleChatView, true);
	}

	// Token: 0x060076EE RID: 30446 RVA: 0x001F1F3C File Offset: 0x001F013C
	private void SetTitleCurrentDayIndex()
	{
		UUIArtText artText = base.GetArtText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (artText != null)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex + 1);
			artText.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
		IReadOnlyList<Artemis> readOnlyList = (instance != null) ? instance.GetArtemisGroupByActivityId(this.ArtemisData.GetCacheActivityId) : null;
		UUIArtText artText2 = base.GetArtText(2);
		if (artText2 == null)
		{
			return;
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/0");
		defaultInterpolatedStringHandler.AppendFormatted<int>((readOnlyList != null) ? readOnlyList.Count : 0);
		artText2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x060076EF RID: 30447 RVA: 0x001F1FE8 File Offset: 0x001F01E8
	[NullableContext(2)]
	public List<TItem> GetRewardItem(int dropId)
	{
		if (dropId == 0)
		{
			return new List<TItem>();
		}
		CSharpScript.Game.Module.Reward.RewardConfig instance = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance;
		List<TItem> list = (instance != null) ? instance.GetDropPackagePreviewItemList(dropId) : null;
		if (list == null || list.Count == 0)
		{
			return new List<TItem>();
		}
		return list;
	}

	// Token: 0x060076F0 RID: 30448 RVA: 0x001F2023 File Offset: 0x001F0223
	private void SetDialogueUiActive(bool isShow)
	{
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isShow);
	}

	// Token: 0x060076F1 RID: 30449 RVA: 0x001F2038 File Offset: 0x001F0238
	private void ShowDialogue(bool isLockStatus, bool isShowEffect, int activityId, int index)
	{
		this.SetDialogueUiActive(true);
		ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
		Artemis? artemis = (instance != null) ? instance.GetArtemisByActivityIdAndDay(activityId, index) : null;
		int[] ids = (artemis != null) ? (artemis.Value.GetChatIdsArray() ?? Array.Empty<int>()) : Array.Empty<int>();
		ArtemisDialogueBoxPanel dialoguePanel = this.DialoguePanel;
		if (dialoguePanel == null)
		{
			return;
		}
		dialoguePanel.ShowDialogue(ids, isLockStatus, isShowEffect);
	}

	// Token: 0x060076F2 RID: 30450 RVA: 0x001F20A8 File Offset: 0x001F02A8
	private void SetUnlockDayLogEvent()
	{
		ArtemisActivityConfig instance = ConfigBase<ArtemisActivityConfig>.Instance;
		Artemis? artemis = (instance != null) ? instance.GetArtemisByActivityIdAndDay(this.ArtemisData.GetCacheActivityId, ControllerBase<ArtemisActivityController>.Instance.CurrentDayIndex) : null;
		if (artemis == null)
		{
			return;
		}
		int getCacheActivityId = this.ArtemisData.GetCacheActivityId;
		Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.FirstUnlockArtemisDayMap, null) ?? new Dictionary<int, int>();
		int num;
		if (dictionary.TryGetValue(getCacheActivityId, out num) && num >= artemis.Value.Id)
		{
			return;
		}
		dictionary[getCacheActivityId] = artemis.Value.Id;
		LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.FirstUnlockArtemisDayMap, dictionary);
		ArtemisLevelUnlockLogEvent artemisLevelUnlockLogEvent = new ArtemisLevelUnlockLogEvent();
		artemisLevelUnlockLogEvent.i_id = artemis.Value.Id;
		ControllerBase<LogReportController>.Instance.LogReport(artemisLevelUnlockLogEvent);
	}

	// Token: 0x0400397A RID: 14714
	protected ArtemisActivityData ArtemisData;

	// Token: 0x0400397B RID: 14715
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400397C RID: 14716
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ArtemisDaysItem, IArtemisDayItemData> DaysScroll;

	// Token: 0x0400397D RID: 14717
	[Nullable(2)]
	private ArtemisDialogueBoxPanel DialoguePanel;

	// Token: 0x0400397E RID: 14718
	private bool WaitFixedFinish;

	// Token: 0x020074FD RID: 29949
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402863D RID: 165437
		public const int CaptionItem = 0;

		// Token: 0x0402863E RID: 165438
		public const int ArtisticText1 = 1;

		// Token: 0x0402863F RID: 165439
		public const int ArtisticText2 = 2;

		// Token: 0x04028640 RID: 165440
		public const int DaysScroll = 3;

		// Token: 0x04028641 RID: 165441
		public const int DaysItem = 4;

		// Token: 0x04028642 RID: 165442
		public const int DialogBoxParent = 5;

		// Token: 0x04028643 RID: 165443
		public const int PlaneTexture = 6;

		// Token: 0x04028644 RID: 165444
		public const int TitleText = 7;
	}
}
