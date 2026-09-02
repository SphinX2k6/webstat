using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F37 RID: 7991
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryLimitTaskView : UiViewBase
{
	// Token: 0x0600EEE5 RID: 61157 RVA: 0x00414F29 File Offset: 0x00413129
	public HonamiStoryLimitTaskView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600EEE6 RID: 61158 RVA: 0x00414F34 File Offset: 0x00413134
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EEE7 RID: 61159 RVA: 0x00414FE0 File Offset: 0x004131E0
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryLimitTaskView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryLimitTaskView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EEE8 RID: 61160 RVA: 0x00415023 File Offset: 0x00413223
	private HonamiStoryLimitTaskItem CreateTaskItem()
	{
		return new HonamiStoryLimitTaskItem
		{
			OnClickToGet = new Action<int>(this.OnClickGetTaskReward)
		};
	}

	// Token: 0x0600EEE9 RID: 61161 RVA: 0x0041503C File Offset: 0x0041323C
	private void RefreshTaskScroll()
	{
		new UiAsyncTask("RefreshProgress", delegate()
		{
			HonamiStoryLimitTaskView.<<RefreshTaskScroll>b__9_0>d <<RefreshTaskScroll>b__9_0>d;
			<<RefreshTaskScroll>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshTaskScroll>b__9_0>d.<>4__this = this;
			<<RefreshTaskScroll>b__9_0>d.<>1__state = -1;
			<<RefreshTaskScroll>b__9_0>d.<>t__builder.Start<HonamiStoryLimitTaskView.<<RefreshTaskScroll>b__9_0>d>(ref <<RefreshTaskScroll>b__9_0>d);
			return <<RefreshTaskScroll>b__9_0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x0600EEEA RID: 61162 RVA: 0x0041505C File Offset: 0x0041325C
	private UniTask RefreshTaskScrollAsync()
	{
		HonamiStoryLimitTaskView.<RefreshTaskScrollAsync>d__10 <RefreshTaskScrollAsync>d__;
		<RefreshTaskScrollAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTaskScrollAsync>d__.<>4__this = this;
		<RefreshTaskScrollAsync>d__.<>1__state = -1;
		<RefreshTaskScrollAsync>d__.<>t__builder.Start<HonamiStoryLimitTaskView.<RefreshTaskScrollAsync>d__10>(ref <RefreshTaskScrollAsync>d__);
		return <RefreshTaskScrollAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EEEB RID: 61163 RVA: 0x0041509F File Offset: 0x0041329F
	private void RefreshProgressItem()
	{
		new UiAsyncTask("RefreshProgress", delegate()
		{
			HonamiStoryLimitTaskView.<<RefreshProgressItem>b__11_0>d <<RefreshProgressItem>b__11_0>d;
			<<RefreshProgressItem>b__11_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshProgressItem>b__11_0>d.<>4__this = this;
			<<RefreshProgressItem>b__11_0>d.<>1__state = -1;
			<<RefreshProgressItem>b__11_0>d.<>t__builder.Start<HonamiStoryLimitTaskView.<<RefreshProgressItem>b__11_0>d>(ref <<RefreshProgressItem>b__11_0>d);
			return <<RefreshProgressItem>b__11_0>d.<>t__builder.Task;
		}, null).Run();
	}

	// Token: 0x0600EEEC RID: 61164 RVA: 0x004150C0 File Offset: 0x004132C0
	private UniTask RefreshProgressItemAsync()
	{
		HonamiStoryLimitTaskView.<RefreshProgressItemAsync>d__12 <RefreshProgressItemAsync>d__;
		<RefreshProgressItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshProgressItemAsync>d__.<>4__this = this;
		<RefreshProgressItemAsync>d__.<>1__state = -1;
		<RefreshProgressItemAsync>d__.<>t__builder.Start<HonamiStoryLimitTaskView.<RefreshProgressItemAsync>d__12>(ref <RefreshProgressItemAsync>d__);
		return <RefreshProgressItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EEED RID: 61165 RVA: 0x00415104 File Offset: 0x00413304
	private void OnClickGetTaskReward(int taskId)
	{
		List<int> finishedLimitTaskIds = this.ActivityData.GetFinishedLimitTaskIds();
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryLimitTaskRewardRequest(finishedLimitTaskIds, delegate
		{
			this.RefreshTaskScroll();
			this.RefreshProgressItem();
		});
	}

	// Token: 0x0600EEEE RID: 61166 RVA: 0x00415134 File Offset: 0x00413334
	private void OnClickGetProgressReward()
	{
		List<int> finishedScoreRewardIds = this.ActivityData.GetFinishedScoreRewardIds();
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryScoreRewardRequest(finishedScoreRewardIds, new Action(this.RefreshProgressItem));
	}

	// Token: 0x0600EEEF RID: 61167 RVA: 0x00415164 File Offset: 0x00413364
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(431);
	}

	// Token: 0x0600EEF0 RID: 61168 RVA: 0x00415175 File Offset: 0x00413375
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x040072EC RID: 29420
	[Nullable(2)]
	private HonamiStoryActivityData ActivityData;

	// Token: 0x040072ED RID: 29421
	private PopupCaptionItem CaptionItem;

	// Token: 0x040072EE RID: 29422
	private HonamiStoryLimitTaskProItem ProgressItem;

	// Token: 0x040072EF RID: 29423
	private GenericScrollViewNew<HonamiStoryLimitTaskItem, HonamiStoryLimitTaskData> RewardScroll;

	// Token: 0x020082A8 RID: 33448
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C4F9 RID: 181497
		CaptionItem,
		// Token: 0x0402C4FA RID: 181498
		RewardItemScroll,
		// Token: 0x0402C4FB RID: 181499
		PnlQuestItem,
		// Token: 0x0402C4FC RID: 181500
		PnlBottomReward
	}
}
