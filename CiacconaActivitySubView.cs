using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CiacconaGal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001298 RID: 4760
[NullableContext(1)]
[Nullable(0)]
public class CiacconaActivitySubView : ActivitySubViewBase
{
	// Token: 0x06007F76 RID: 32630 RVA: 0x0021ACF8 File Offset: 0x00218EF8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007F77 RID: 32631 RVA: 0x0021AED4 File Offset: 0x002190D4
	protected override UniTask OnBeforeStartAsync()
	{
		CiacconaActivitySubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaActivitySubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F78 RID: 32632 RVA: 0x0021AF17 File Offset: 0x00219117
	protected override void OnStart()
	{
		this.Refresh();
	}

	// Token: 0x06007F79 RID: 32633 RVA: 0x0021AF1F File Offset: 0x0021911F
	protected override void OnBeforeDestroy()
	{
		ActivityCircleButtonItem endingRewardItem = this.EndingRewardItem;
		if (endingRewardItem != null)
		{
			endingRewardItem.UnBindRedDot();
		}
		ActivityCircleButtonItem progressRewardItem = this.ProgressRewardItem;
		if (progressRewardItem == null)
		{
			return;
		}
		progressRewardItem.UnBindRedDot();
	}

	// Token: 0x06007F7A RID: 32634 RVA: 0x0021AF42 File Offset: 0x00219142
	protected override void OnRefreshView()
	{
		this.Refresh();
	}

	// Token: 0x06007F7B RID: 32635 RVA: 0x0021AF4C File Offset: 0x0021914C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaActivityStateUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaEndingDataUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaRewardDataUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x06007F7C RID: 32636 RVA: 0x0021AFCC File Offset: 0x002191CC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaActivityStateUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaChapterDataUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaEndingDataUpdate, new Action(this.OnDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaRewardDataUpdate, new Action(this.OnDataUpdate));
	}

	// Token: 0x06007F7D RID: 32637 RVA: 0x0021B04C File Offset: 0x0021924C
	protected override void OnTimer(float _)
	{
		CiacconaGalModel instance = ModelBase<CiacconaGalModel>.Instance;
		ActivityBaseData activityBaseData = this.ActivityBaseData;
		CiacconaGalActivityData activityDataById = instance.GetActivityDataById((activityBaseData != null) ? activityBaseData.Id : 0);
		if (activityDataById != null)
		{
			ActivityCircleButtonItem progressRewardItem = this.ProgressRewardItem;
			if (progressRewardItem != null)
			{
				progressRewardItem.SetUiActive(activityDataById.IsInRewardTime && activityDataById.State2Unlock);
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(activityDataById.State2Unlock && activityDataById.IsInRewardTime);
			}
			this.RefreshRewardTimeText();
		}
	}

	// Token: 0x06007F7E RID: 32638 RVA: 0x0021B0C4 File Offset: 0x002192C4
	private void Refresh()
	{
		this.CommonActivityInfo.SetTitle(this.ActivityBaseData.GetTitle());
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		this.CommonActivityInfo.SetSubTitle(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null), ((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null) ?? "");
		this.CommonActivityInfo.SetDesc(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null), ((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null) ?? "");
		this.CommonActivityInfo.SetReward(true, this.ActivityBaseData.GetPreviewReward(null));
		this.RefreshTimeText();
		CiacconaGalActivityData activityDataById = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(this.ActivityBaseData.Id);
		this.CommonActivityInfo.RefreshFunctionArea();
		CiacconaGalEndingData[] allEndingDataList = ModelBase<CiacconaGalModel>.Instance.GetAllEndingDataList();
		this.LayoutEndings.RefreshByData(allEndingDataList.ToList<CiacconaGalEndingData>(), null, false);
		base.GetItem(7).SetUIActive(false);
		ValueTuple<int, int> progressRewardProgress = ModelBase<CiacconaGalModel>.Instance.GetProgressRewardProgress();
		int item = progressRewardProgress.Item1;
		int item2 = progressRewardProgress.Item2;
		base.GetSprite(6).fillAmount = (float)item / (float)item2;
		UUIText text = base.GetText(5);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetItem(8).SetUIActive(activityDataById.State2Unlock && activityDataById.IsInRewardTime);
		this.RefreshRewardTimeText();
		this.QuestTipsItem.SetContentByTextId(activityDataById.RecommendQuestTipsTextId, Array.Empty<string>());
		this.QuestTipsItem.SetUiActive(activityDataById.RecommendQuestId > 0 && !ModelBase<QuestNewModel>.Instance.CheckQuestFinished(activityDataById.RecommendQuestId));
		ValueTuple<int, int> endingProgress = ModelBase<CiacconaGalModel>.Instance.GetEndingProgress();
		int item3 = endingProgress.Item1;
		int item4 = endingProgress.Item2;
		ActivityCircleButtonItem endingRewardItem = this.EndingRewardItem;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item3);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item4);
		endingRewardItem.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		this.EndingRewardItem.SetUiActive(activityDataById.State3Unlock);
		this.EndingRewardItem.SetRedDotVisible(ModelBase<CiacconaGalModel>.Instance.HasAnyEndingReward());
		ActivityCircleButtonItem progressRewardItem = this.ProgressRewardItem;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(item);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
		progressRewardItem.SetSubText(defaultInterpolatedStringHandler.ToStringAndClear());
		this.ProgressRewardItem.SetUiActive(activityDataById.IsInRewardTime && activityDataById.State2Unlock);
		this.ProgressRewardItem.SetRedDotVisible(ModelBase<CiacconaGalModel>.Instance.HasAnyProgressReward());
	}

	// Token: 0x06007F7F RID: 32639 RVA: 0x0021B3B8 File Offset: 0x002195B8
	private void RefreshTimeText()
	{
		string item = this.GetTimeVisibleAndRemainTime().Item2;
		CiacconaActivityInfoPanel commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return;
		}
		commonActivityInfo.SetTimer(false, item);
	}

	// Token: 0x06007F80 RID: 32640 RVA: 0x0021B3E4 File Offset: 0x002195E4
	private void RefreshRewardTimeText()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Xkjsx_Rewards_Timeless", null);
		string rewardRemainTimeStr = ModelBase<CiacconaGalModel>.Instance.ActivityData.RewardRemainTimeStr;
		string newText = localTextNew + " " + rewardRemainTimeStr;
		UUIText text = base.GetText(12);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x06007F81 RID: 32641 RVA: 0x0021B42C File Offset: 0x0021962C
	private CiacconaEndingIcon GetEndingItem()
	{
		return new CiacconaEndingIcon();
	}

	// Token: 0x06007F82 RID: 32642 RVA: 0x0021B433 File Offset: 0x00219633
	private void OnEndingRewardClick()
	{
		ControllerBase<CiacconaGalController>.Instance.OpenEndingView();
	}

	// Token: 0x06007F83 RID: 32643 RVA: 0x0021B43F File Offset: 0x0021963F
	private void OnProgressRewardClick()
	{
		ControllerBase<CiacconaGalController>.Instance.OpenRewardViewByActivityId(this.ActivityBaseData.Id);
	}

	// Token: 0x06007F84 RID: 32644 RVA: 0x0021B458 File Offset: 0x00219658
	private void OnQuestTipsClick()
	{
		CiacconaGalActivityData activityDataById = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(this.ActivityBaseData.Id);
		if (activityDataById.RecommendQuestId > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, activityDataById.RecommendQuestId, null);
		}
	}

	// Token: 0x06007F85 RID: 32645 RVA: 0x0021B49F File Offset: 0x0021969F
	private void OnDataUpdate()
	{
		this.Refresh();
	}

	// Token: 0x06007F86 RID: 32646 RVA: 0x0021B4A7 File Offset: 0x002196A7
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		CiacconaActivityInfoPanel commonActivityInfo = this.CommonActivityInfo;
		if (commonActivityInfo == null)
		{
			return null;
		}
		return commonActivityInfo.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x04003CFC RID: 15612
	private CiacconaActivityInfoPanel CommonActivityInfo;

	// Token: 0x04003CFD RID: 15613
	private GenericLayout<CiacconaEndingIcon, CiacconaGalEndingData> LayoutEndings;

	// Token: 0x04003CFE RID: 15614
	private ActivityCircleButtonItem EndingRewardItem;

	// Token: 0x04003CFF RID: 15615
	private ActivityCircleButtonItem ProgressRewardItem;

	// Token: 0x04003D00 RID: 15616
	private ActivityQuestTipsItem QuestTipsItem;

	// Token: 0x02007615 RID: 30229
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028B5A RID: 166746
		public const int ItemCommonActivityInfo = 0;

		// Token: 0x04028B5B RID: 166747
		public const int ItemBtnConfirm = 1;

		// Token: 0x04028B5C RID: 166748
		public const int ItemRedDot = 2;

		// Token: 0x04028B5D RID: 166749
		public const int LayoutEndings = 3;

		// Token: 0x04028B5E RID: 166750
		public const int ItemEndingIcon = 4;

		// Token: 0x04028B5F RID: 166751
		public const int TextProgress = 5;

		// Token: 0x04028B60 RID: 166752
		public const int SpriteProgress = 6;

		// Token: 0x04028B61 RID: 166753
		public const int ItemEndings = 7;

		// Token: 0x04028B62 RID: 166754
		public const int ItemProgress = 8;

		// Token: 0x04028B63 RID: 166755
		public const int ItemProgressReward = 9;

		// Token: 0x04028B64 RID: 166756
		public const int ItemEndingReward = 10;

		// Token: 0x04028B65 RID: 166757
		public const int ItemQuestTips = 11;

		// Token: 0x04028B66 RID: 166758
		public const int TextRewardLimitTime = 12;
	}
}
