using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015B4 RID: 5556
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewSevenDayVersionSign : ActivitySubViewBase
{
	// Token: 0x06009C83 RID: 40067 RVA: 0x002901C8 File Offset: 0x0028E3C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009C84 RID: 40068 RVA: 0x00290319 File Offset: 0x0028E519
	protected override void OnSetData()
	{
		this.ActivitySignData = (this.ActivityBaseData as ActivitySevenDaySignData);
	}

	// Token: 0x06009C85 RID: 40069 RVA: 0x0029032C File Offset: 0x0028E52C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewSevenDayVersionSign.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewSevenDayVersionSign.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009C86 RID: 40070 RVA: 0x0029036F File Offset: 0x0028E56F
	protected override void OnStart()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivitySignData);
		this.TitleComponent.SetTitleByText(this.ActivitySignData.GetTitle());
	}

	// Token: 0x06009C87 RID: 40071 RVA: 0x00290398 File Offset: 0x0028E598
	protected override void OnRefreshView()
	{
		this.RefreshReward();
	}

	// Token: 0x06009C88 RID: 40072 RVA: 0x002903A0 File Offset: 0x0028E5A0
	private void RefreshReward()
	{
		for (int i = 0; i < 7; i++)
		{
			OneItemConfig[] rewardByDay = this.ActivitySignData.GetRewardByDay(i);
			SignState? rewardStateByDay = this.ActivitySignData.GetRewardStateByDay(i);
			if (rewardStateByDay != null && rewardByDay != null && rewardByDay.Length != 0)
			{
				SignRewardItemBase signRewardItemBase = this.ItemList[i];
				if (signRewardItemBase != null)
				{
					signRewardItemBase.RefreshByData(rewardByDay[0], rewardStateByDay.Value, i);
				}
			}
		}
	}

	// Token: 0x06009C89 RID: 40073 RVA: 0x00290404 File Offset: 0x0028E604
	protected override void OnTimer(float gap)
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.RefreshTimerText(item, item2);
	}

	// Token: 0x06009C8A RID: 40074 RVA: 0x0029042E File Offset: 0x0028E62E
	public void RefreshTimerText(bool isShow, string timeText)
	{
		this.TitleComponent.SetTimeTextVisible(isShow);
		if (isShow)
		{
			this.TitleComponent.SetTimeTextByText(timeText);
		}
	}

	// Token: 0x06009C8B RID: 40075 RVA: 0x0029044C File Offset: 0x0028E64C
	private bool IsRewardCanGet(int day)
	{
		return this.ActivitySignData.GetRewardStateByDay(day).GetValueOrDefault() == SignState.Unlock;
	}

	// Token: 0x06009C8C RID: 40076 RVA: 0x00290470 File Offset: 0x0028E670
	private void OnClickToGetReward(int index)
	{
		if (this.IsRewardCanGet(index))
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetRewardByDay(this.ActivitySignData.Id, index);
		}
	}

	// Token: 0x040047FF RID: 18431
	private const int SIGN_DAY_COUNT = 7;

	// Token: 0x04004800 RID: 18432
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004801 RID: 18433
	protected SignRewardItemBase[] ItemList;

	// Token: 0x04004802 RID: 18434
	[Nullable(2)]
	protected ActivitySevenDaySignData ActivitySignData;

	// Token: 0x02007979 RID: 31097
	[NullableContext(0)]
	private class EVersionSignComponents
	{
		// Token: 0x04029B94 RID: 170900
		public const int TitleItem = 0;

		// Token: 0x04029B95 RID: 170901
		public const int Item1 = 1;

		// Token: 0x04029B96 RID: 170902
		public const int Item2 = 2;

		// Token: 0x04029B97 RID: 170903
		public const int Item3 = 3;

		// Token: 0x04029B98 RID: 170904
		public const int Item4 = 4;

		// Token: 0x04029B99 RID: 170905
		public const int Item5 = 5;

		// Token: 0x04029B9A RID: 170906
		public const int Item6 = 6;

		// Token: 0x04029B9B RID: 170907
		public const int Item7 = 7;

		// Token: 0x04029B9C RID: 170908
		public const int Content = 8;
	}
}
