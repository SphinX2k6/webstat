using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F1D RID: 7965
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryActivityView : ActivitySubViewBase
{
	// Token: 0x17001229 RID: 4649
	// (get) Token: 0x0600EE2B RID: 60971 RVA: 0x00410CD4 File Offset: 0x0040EED4
	protected new HonamiStoryActivityData ActivityBaseData
	{
		get
		{
			return this.ActivityBaseData as HonamiStoryActivityData;
		}
	}

	// Token: 0x0600EE2C RID: 60972 RVA: 0x00410CE4 File Offset: 0x0040EEE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EE2D RID: 60973 RVA: 0x00410DF4 File Offset: 0x0040EFF4
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryActivityView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryActivityView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE2E RID: 60974 RVA: 0x00410E37 File Offset: 0x0040F037
	protected override void OnBeforeShow()
	{
		this.SwitchGenderItem();
	}

	// Token: 0x0600EE2F RID: 60975 RVA: 0x00410E40 File Offset: 0x0040F040
	protected override void OnRefreshView()
	{
		this.RefreshPermanentScore();
		this.RefreshCondition();
		this.CommonInfoPanel.SetFunctionRedDotVisible(this.ActivityBaseData.CheckAllFunctionRedDot());
		this.PermanentRewardBtn.SetRedDotVisible(this.ActivityBaseData.IsPermanentTaskHasRedDot());
		this.LimitRewardBtn.SetRedDotVisible(this.ActivityBaseData.IsLimitTaskHasRedDot());
	}

	// Token: 0x0600EE30 RID: 60976 RVA: 0x00410E9B File Offset: 0x0040F09B
	protected override void OnTimer(float _)
	{
		this.RefreshTimeText();
	}

	// Token: 0x0600EE31 RID: 60977 RVA: 0x00410EA4 File Offset: 0x0040F0A4
	private void RefreshTimeText()
	{
		bool uiactive = this.ActivityBaseData.CheckIfInLimitTime();
		base.GetItem(1).SetUIActive(uiactive);
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndRewardTime, "{0}");
		ButtonItem limitRewardBtn = this.LimitRewardBtn;
		if (limitRewardBtn == null)
		{
			return;
		}
		limitRewardBtn.SetText(remainTimeText);
	}

	// Token: 0x0600EE32 RID: 60978 RVA: 0x00410EF8 File Offset: 0x0040F0F8
	private void SwitchGenderItem()
	{
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(6).SetUIActive(!flag);
		base.GetSpine(3).SetAutoPlay(false);
		base.GetSpine(4).SetAutoPlay(false);
		if (flag)
		{
			base.GetSpine(3).SetAutoPlay(true);
			return;
		}
		base.GetSpine(4).SetAutoPlay(true);
	}

	// Token: 0x0600EE33 RID: 60979 RVA: 0x00410F68 File Offset: 0x0040F168
	private void RefreshPermanentScore()
	{
		int count = this.ActivityBaseData.GetPermanentTaskIdsByState(EActivityTaskState.FinishedAndClaimed).Count;
		int permanentTaskTotalNum = this.ActivityBaseData.GetPermanentTaskTotalNum();
		this.PermanentRewardBtn.SetText(count.ToString() + "/" + permanentTaskTotalNum.ToString());
	}

	// Token: 0x0600EE34 RID: 60980 RVA: 0x00410FB8 File Offset: 0x0040F1B8
	private void RefreshCondition()
	{
		ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
		ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
		{
			UnlockBtnTextId = "LongShanStage_Join01",
			UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
		};
		functional.RefreshGeneralPerformance(parameters);
	}

	// Token: 0x0600EE35 RID: 60981 RVA: 0x00410FFC File Offset: 0x0040F1FC
	private void OnConfirmBtnClick()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		int markId = this.ActivityBaseData.MarkId;
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(markId),
			MarkType = EMarkType.SmallTeleport
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
	}

	// Token: 0x0600EE36 RID: 60982 RVA: 0x0041106C File Offset: 0x0040F26C
	private void OnLimitRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryLimitTaskView, null, null);
	}

	// Token: 0x0600EE37 RID: 60983 RVA: 0x0041107F File Offset: 0x0040F27F
	private void OnPermanentRewardBtnClick(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryPermanentTaskView, null, null);
	}

	// Token: 0x04007254 RID: 29268
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04007255 RID: 29269
	private ButtonItem LimitRewardBtn;

	// Token: 0x04007256 RID: 29270
	private ButtonItem PermanentRewardBtn;

	// Token: 0x0200828A RID: 33418
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C46E RID: 181358
		CommonActionInfo,
		// Token: 0x0402C46F RID: 181359
		ItemLimitRewardBtn,
		// Token: 0x0402C470 RID: 181360
		ItemPermanentRewardBtn,
		// Token: 0x0402C471 RID: 181361
		MaleSpine,
		// Token: 0x0402C472 RID: 181362
		FemaleSpine,
		// Token: 0x0402C473 RID: 181363
		MaleItem,
		// Token: 0x0402C474 RID: 181364
		FemaleItem
	}
}
