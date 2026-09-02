using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F46 RID: 8006
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryPermanentTaskView : UiViewBase
{
	// Token: 0x0600EF94 RID: 61332 RVA: 0x0041795A File Offset: 0x00415B5A
	public HonamiStoryPermanentTaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EF95 RID: 61333 RVA: 0x00417964 File Offset: 0x00415B64
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600EF96 RID: 61334 RVA: 0x00417A54 File Offset: 0x00415C54
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryPermanentTaskView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryPermanentTaskView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF97 RID: 61335 RVA: 0x00417A97 File Offset: 0x00415C97
	private HonamiStoryPermanentTaskItem CreateTaskItem()
	{
		return new HonamiStoryPermanentTaskItem
		{
			OnClickToGet = new Action<int>(this.OnClickGetTaskReward)
		};
	}

	// Token: 0x0600EF98 RID: 61336 RVA: 0x00417AB0 File Offset: 0x00415CB0
	private void RefreshTaskScroll()
	{
		new UiAsyncTask("RefreshProgress", delegate()
		{
			HonamiStoryPermanentTaskView.<<RefreshTaskScroll>b__9_0>d <<RefreshTaskScroll>b__9_0>d;
			<<RefreshTaskScroll>b__9_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshTaskScroll>b__9_0>d.<>4__this = this;
			<<RefreshTaskScroll>b__9_0>d.<>1__state = -1;
			<<RefreshTaskScroll>b__9_0>d.<>t__builder.Start<HonamiStoryPermanentTaskView.<<RefreshTaskScroll>b__9_0>d>(ref <<RefreshTaskScroll>b__9_0>d);
			return <<RefreshTaskScroll>b__9_0>d.<>t__builder.Task;
		}, null).Run();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityData.Id);
	}

	// Token: 0x0600EF99 RID: 61337 RVA: 0x00417AEC File Offset: 0x00415CEC
	private UniTask RefreshTaskScrollAsync()
	{
		HonamiStoryPermanentTaskView.<RefreshTaskScrollAsync>d__10 <RefreshTaskScrollAsync>d__;
		<RefreshTaskScrollAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTaskScrollAsync>d__.<>4__this = this;
		<RefreshTaskScrollAsync>d__.<>1__state = -1;
		<RefreshTaskScrollAsync>d__.<>t__builder.Start<HonamiStoryPermanentTaskView.<RefreshTaskScrollAsync>d__10>(ref <RefreshTaskScrollAsync>d__);
		return <RefreshTaskScrollAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EF9A RID: 61338 RVA: 0x00417B30 File Offset: 0x00415D30
	private void OnClickGetTaskReward(int taskId)
	{
		List<int> permanentTaskIdsByState = this.ActivityData.GetPermanentTaskIdsByState(EActivityTaskState.FinishedAndUnclaimed);
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryPermanentTaskRewardRequest(permanentTaskIdsByState, new Action(this.RefreshTaskScroll));
	}

	// Token: 0x0600EF9B RID: 61339 RVA: 0x00417B61 File Offset: 0x00415D61
	private void OnClickHelpBtn()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(431);
	}

	// Token: 0x0600EF9C RID: 61340 RVA: 0x00417B72 File Offset: 0x00415D72
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04007337 RID: 29495
	[Nullable(2)]
	private HonamiStoryActivityData ActivityData;

	// Token: 0x04007338 RID: 29496
	private PopupCaptionItem CaptionItem;

	// Token: 0x04007339 RID: 29497
	private GenericScrollViewNew<HonamiStoryPermanentTaskItem, HonamiStoryPermanentTaskData> RewardScroll;

	// Token: 0x0400733A RID: 29498
	private HonamiStoryProfitPanel ProfitPanel;

	// Token: 0x020082BF RID: 33471
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C558 RID: 181592
		CaptionItem,
		// Token: 0x0402C559 RID: 181593
		RewardItemScroll,
		// Token: 0x0402C55A RID: 181594
		PnlQuestItem,
		// Token: 0x0402C55B RID: 181595
		PnlEnterProfit,
		// Token: 0x0402C55C RID: 181596
		TxtBozaiTitle,
		// Token: 0x0402C55D RID: 181597
		TxtBozaiDesc
	}
}
