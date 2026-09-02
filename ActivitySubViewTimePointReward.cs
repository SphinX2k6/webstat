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

// Token: 0x020015CE RID: 5582
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewTimePointReward : ActivitySubViewBase
{
	// Token: 0x06009D1D RID: 40221 RVA: 0x002922CC File Offset: 0x002904CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009D1E RID: 40222 RVA: 0x00292398 File Offset: 0x00290598
	protected override void OnSetData()
	{
		this.ActivityTimePointRewardData = (this.ActivityBaseData as ActivityTimePointRewardData);
	}

	// Token: 0x06009D1F RID: 40223 RVA: 0x002923AC File Offset: 0x002905AC
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewTimePointReward.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewTimePointReward.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009D20 RID: 40224 RVA: 0x002923F0 File Offset: 0x002905F0
	protected override void OnStart()
	{
		Activity? localConfig = this.ActivityTimePointRewardData.LocalConfig;
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		bool flag = !StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
		}
		UUIText text = base.GetText(1);
		bool flag2 = !StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().Desc : null);
		text.SetUIActive(flag2);
		if (flag2)
		{
			text.ShowTextNew(localConfig.Value.Desc);
		}
	}

	// Token: 0x06009D21 RID: 40225 RVA: 0x002924D1 File Offset: 0x002906D1
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009D22 RID: 40226 RVA: 0x002924EF File Offset: 0x002906EF
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06009D23 RID: 40227 RVA: 0x0029250D File Offset: 0x0029070D
	[NullableContext(1)]
	private TimePointRewardItem InitItem()
	{
		return new TimePointRewardItem
		{
			OnClickToGet = new Action<int>(this.OnGetReward)
		};
	}

	// Token: 0x06009D24 RID: 40228 RVA: 0x00292528 File Offset: 0x00290728
	protected override UniTask OnBeforeShowSelfAsync()
	{
		ActivitySubViewTimePointReward.<OnBeforeShowSelfAsync>d__12 <OnBeforeShowSelfAsync>d__;
		<OnBeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowSelfAsync>d__.<>4__this = this;
		<OnBeforeShowSelfAsync>d__.<>1__state = -1;
		<OnBeforeShowSelfAsync>d__.<>t__builder.Start<ActivitySubViewTimePointReward.<OnBeforeShowSelfAsync>d__12>(ref <OnBeforeShowSelfAsync>d__);
		return <OnBeforeShowSelfAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009D25 RID: 40229 RVA: 0x0029256C File Offset: 0x0029076C
	private UniTask RefreshRewardLayout()
	{
		ActivitySubViewTimePointReward.<RefreshRewardLayout>d__13 <RefreshRewardLayout>d__;
		<RefreshRewardLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRewardLayout>d__.<>4__this = this;
		<RefreshRewardLayout>d__.<>1__state = -1;
		<RefreshRewardLayout>d__.<>t__builder.Start<ActivitySubViewTimePointReward.<RefreshRewardLayout>d__13>(ref <RefreshRewardLayout>d__);
		return <RefreshRewardLayout>d__.<>t__builder.Task;
	}

	// Token: 0x06009D26 RID: 40230 RVA: 0x002925AF File Offset: 0x002907AF
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (this.ActivityBaseData.Id != id)
		{
			return;
		}
		this.RefreshRewardLayout();
	}

	// Token: 0x06009D27 RID: 40231 RVA: 0x002925C7 File Offset: 0x002907C7
	protected override void OnTimer(float gap)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06009D28 RID: 40232 RVA: 0x002925D0 File Offset: 0x002907D0
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

	// Token: 0x06009D29 RID: 40233 RVA: 0x0029260D File Offset: 0x0029080D
	private void OnGetReward(int id)
	{
		ControllerBase<ActivityTimePointRewardController>.Instance.GetRewardById(this.ActivityTimePointRewardData.Id, id);
	}

	// Token: 0x04004860 RID: 18528
	protected ActivityTimePointRewardData ActivityTimePointRewardData;

	// Token: 0x04004861 RID: 18529
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004862 RID: 18530
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TimePointRewardItem, TimePointRewardData> GridLayout;

	// Token: 0x04004863 RID: 18531
	private UiPanelBase BgItem;

	// Token: 0x02007988 RID: 31112
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029BD7 RID: 170967
		public const int TitleItem = 0;

		// Token: 0x04029BD8 RID: 170968
		public const int TextDesc = 1;

		// Token: 0x04029BD9 RID: 170969
		public const int Layout = 2;

		// Token: 0x04029BDA RID: 170970
		public const int LayoutItem = 3;

		// Token: 0x04029BDB RID: 170971
		public const int BgItem = 4;
	}
}
