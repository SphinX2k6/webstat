using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001362 RID: 4962
[NullableContext(1)]
[Nullable(0)]
public class SevenHillsMainView : UiViewBase
{
	// Token: 0x0600880D RID: 34829 RVA: 0x0023E494 File Offset: 0x0023C694
	public SevenHillsMainView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600880E RID: 34830 RVA: 0x0023E4A0 File Offset: 0x0023C6A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIInturnAnimController));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600880F RID: 34831 RVA: 0x0023E5D0 File Offset: 0x0023C7D0
	protected override UniTask OnBeforeStartAsync()
	{
		SevenHillsMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SevenHillsMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008810 RID: 34832 RVA: 0x0023E614 File Offset: 0x0023C814
	protected virtual void RefreshTitleIcon()
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("SevenHillsIconPath");
		if (!string.IsNullOrEmpty(stringConfig))
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetTitleIcon(stringConfig);
		}
	}

	// Token: 0x06008811 RID: 34833 RVA: 0x0023E648 File Offset: 0x0023C848
	protected override void OnBeforeShow()
	{
		int scoreItemCount = this.ActivityBaseData.GetScoreItemCount();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(scoreItemCount.ToString(), true);
		}
		int scoreItemTotal = this.ActivityBaseData.ScoreItemTotal;
		UUIText text2 = base.GetText(4);
		if (text2 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(scoreItemTotal);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		this.RewardBoxLayout.RefreshByData(this.ActivityBaseData.GetAllScoreRewardData(), null, false);
	}

	// Token: 0x06008812 RID: 34834 RVA: 0x0023E6D8 File Offset: 0x0023C8D8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<RewardPopupData>(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardLayout));
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008813 RID: 34835 RVA: 0x0023E73C File Offset: 0x0023C93C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRewardPopUp, new Action<RewardPopupData>(this.OnRefreshRewardPopUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardLayout));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008814 RID: 34836 RVA: 0x0023E79D File Offset: 0x0023C99D
	private SevenHillsRewardBoxItem CreateRewardBoxItem()
	{
		return new SevenHillsRewardBoxItem
		{
			ActivityData = this.ActivityBaseData
		};
	}

	// Token: 0x06008815 RID: 34837 RVA: 0x0023E7B0 File Offset: 0x0023C9B0
	private SevenHillsStageItem CreateStageItem()
	{
		return new SevenHillsStageItem
		{
			ActivityData = this.ActivityBaseData,
			OnClickStageItem = new Action<int>(this.OnClickStageItem)
		};
	}

	// Token: 0x06008816 RID: 34838 RVA: 0x0023E7D6 File Offset: 0x0023C9D6
	private void OnRefreshRewardPopUp(RewardPopupData data)
	{
		this.RewardPopup.Refresh(data);
	}

	// Token: 0x06008817 RID: 34839 RVA: 0x0023E7E4 File Offset: 0x0023C9E4
	private void OnRefreshRewardLayout(int activityId)
	{
		if (this.ActivityBaseData != null && this.ActivityBaseData.Id == activityId)
		{
			this.RewardBoxLayout.RefreshByData(this.ActivityBaseData.GetAllScoreRewardData(), null, false);
		}
	}

	// Token: 0x06008818 RID: 34840 RVA: 0x0023E814 File Offset: 0x0023CA14
	protected virtual void OnClickStageItem(int stageId)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SevenHillsStageTaskView, new object[]
		{
			this.ActivityBaseData,
			stageId
		}, null);
	}

	// Token: 0x06008819 RID: 34841 RVA: 0x0023E83E File Offset: 0x0023CA3E
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "Start" || param == "showviewStart")
		{
			UUIInturnAnimController uiInturnAnimController = base.GetUiInturnAnimController(7);
			if (uiInturnAnimController == null)
			{
				return;
			}
			uiInturnAnimController.Play("", -1, false);
		}
	}

	// Token: 0x04003FFF RID: 16383
	[Nullable(2)]
	protected ActivityLongShanData ActivityBaseData;

	// Token: 0x04004000 RID: 16384
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004001 RID: 16385
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SevenHillsRewardBoxItem, LongShanScoreRewardData> RewardBoxLayout;

	// Token: 0x04004002 RID: 16386
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SevenHillsStageItem, int> StageLayout;

	// Token: 0x04004003 RID: 16387
	[Nullable(2)]
	private CommonRewardPopup RewardPopup;

	// Token: 0x0200770F RID: 30479
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402900B RID: 167947
		public const int ItemCaption = 0;

		// Token: 0x0402900C RID: 167948
		public const int LayoutRewardBox = 1;

		// Token: 0x0402900D RID: 167949
		public const int ItemRewardBox = 2;

		// Token: 0x0402900E RID: 167950
		public const int TextCount = 3;

		// Token: 0x0402900F RID: 167951
		public const int TextTotal = 4;

		// Token: 0x04029010 RID: 167952
		public const int LayoutStage = 5;

		// Token: 0x04029011 RID: 167953
		public const int ItemStage = 6;

		// Token: 0x04029012 RID: 167954
		public const int ListAnimController = 7;
	}
}
