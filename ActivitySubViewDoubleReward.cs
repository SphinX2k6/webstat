using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001319 RID: 4889
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewDoubleReward : ActivitySubViewBase
{
	// Token: 0x17000B40 RID: 2880
	// (get) Token: 0x0600850C RID: 34060 RVA: 0x00230D3B File Offset: 0x0022EF3B
	// (set) Token: 0x0600850D RID: 34061 RVA: 0x00230D43 File Offset: 0x0022EF43
	protected ActivityDoubleRewardData ActivityData { get; set; }

	// Token: 0x17000B41 RID: 2881
	// (get) Token: 0x0600850E RID: 34062 RVA: 0x00230D4C File Offset: 0x0022EF4C
	// (set) Token: 0x0600850F RID: 34063 RVA: 0x00230D54 File Offset: 0x0022EF54
	private ActivityTitleTypeA TitleComponent { get; set; }

	// Token: 0x17000B42 RID: 2882
	// (get) Token: 0x06008510 RID: 34064 RVA: 0x00230D5D File Offset: 0x0022EF5D
	// (set) Token: 0x06008511 RID: 34065 RVA: 0x00230D65 File Offset: 0x0022EF65
	private ActivityDescriptionTypeA DescriptionComponent { get; set; }

	// Token: 0x06008512 RID: 34066 RVA: 0x00230D70 File Offset: 0x0022EF70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickJump));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickLock));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008513 RID: 34067 RVA: 0x00230EFF File Offset: 0x0022F0FF
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityDoubleRewardData);
	}

	// Token: 0x06008514 RID: 34068 RVA: 0x00230F14 File Offset: 0x0022F114
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewDoubleReward.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewDoubleReward.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008515 RID: 34069 RVA: 0x00230F58 File Offset: 0x0022F158
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		bool flag = !StringUtils.IsEmpty(localConfig.Value.DescTheme);
		this.TitleComponent.SetActivityBaseData(this.ActivityData);
		this.TitleComponent.SetTitleByText(this.ActivityData.GetTitle());
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
		}
		string desc = localConfig.Value.Desc;
		this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		this.OnRefreshView();
	}

	// Token: 0x06008516 RID: 34070 RVA: 0x0023100F File Offset: 0x0022F20F
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06008517 RID: 34071 RVA: 0x00231018 File Offset: 0x0022F218
	protected override void OnRefreshView()
	{
		ValueTuple<string, int, int> numTxtAndParam = this.ActivityData.GetNumTxtAndParam();
		bool flag = this.ActivityData.IsUnLock();
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && ModelBase<FunctionModel>.Instance.IsOpen(10023004));
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), numTxtAndParam.Item1, new <>z__ReadOnlyArray<object>(new object[]
		{
			numTxtAndParam.Item2,
			numTxtAndParam.Item3
		}));
		base.GetItem(4).SetUIActive(flag);
		base.GetItem(5).SetUIActive(!flag);
		base.GetButton(7).RootUIComp.Get().SetUIActive(!flag);
		if (!flag)
		{
			string currentLockConditionText = this.GetCurrentLockConditionText();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), currentLockConditionText, Array.Empty<object>());
		}
		this.RefreshTimerText();
		this.ActivityData.ReadDailyRedDot();
	}

	// Token: 0x06008518 RID: 34072 RVA: 0x0023111C File Offset: 0x0022F31C
	private void RefreshTimerText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06008519 RID: 34073 RVA: 0x00231159 File Offset: 0x0022F359
	private void OnClickJump()
	{
		ModelBase<ActivityModel>.Instance.SendActivityViewJumpClickLogData(this.ActivityData);
		this.ActivityData.JumpToDungeon();
	}

	// Token: 0x0600851A RID: 34074 RVA: 0x00231176 File Offset: 0x0022F376
	private void OnClickLock()
	{
		ControllerBase<ActivityController>.Instance.OpenActivityConditionView(this.ActivityData.Id);
	}

	// Token: 0x020076BB RID: 30395
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028E6A RID: 167530
		public const int TitleItem = 0;

		// Token: 0x04028E6B RID: 167531
		public const int DescriptionItem = 1;

		// Token: 0x04028E6C RID: 167532
		public const int TxtNum = 2;

		// Token: 0x04028E6D RID: 167533
		public const int BtnJump = 3;

		// Token: 0x04028E6E RID: 167534
		public const int ItemDoubleTip = 4;

		// Token: 0x04028E6F RID: 167535
		public const int ItemLockTip = 5;

		// Token: 0x04028E70 RID: 167536
		public const int TxtLockTip = 6;

		// Token: 0x04028E71 RID: 167537
		public const int ButtonLock = 7;
	}
}
