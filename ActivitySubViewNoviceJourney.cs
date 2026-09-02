using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001489 RID: 5257
public class ActivitySubViewNoviceJourney : ActivitySubViewBase
{
	// Token: 0x0600931F RID: 37663 RVA: 0x0026D240 File Offset: 0x0026B440
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009320 RID: 37664 RVA: 0x0026D30C File Offset: 0x0026B50C
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityNoviceJourneyData);
	}

	// Token: 0x06009321 RID: 37665 RVA: 0x0026D320 File Offset: 0x0026B520
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewNoviceJourney.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewNoviceJourney.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009322 RID: 37666 RVA: 0x0026D363 File Offset: 0x0026B563
	[NullableContext(1)]
	private NoviceJourneyItem InitItem()
	{
		NoviceJourneyItem noviceJourneyItem = new NoviceJourneyItem();
		noviceJourneyItem.SetActivityData(this.ActivityData);
		return noviceJourneyItem;
	}

	// Token: 0x06009323 RID: 37667 RVA: 0x0026D376 File Offset: 0x0026B576
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.NoticeJourneyReceive, new Action<int>(this.OnNoticeJourneyReceive));
	}

	// Token: 0x06009324 RID: 37668 RVA: 0x0026D394 File Offset: 0x0026B594
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.NoticeJourneyReceive, new Action<int>(this.OnNoticeJourneyReceive));
	}

	// Token: 0x06009325 RID: 37669 RVA: 0x0026D3B2 File Offset: 0x0026B5B2
	private void OnNoticeJourneyReceive(int level)
	{
		this.Layout.GetLayoutItemByKey(level).RefreshCurrentState();
	}

	// Token: 0x06009326 RID: 37670 RVA: 0x0026D3CC File Offset: 0x0026B5CC
	protected override void OnStart()
	{
		this.RemainTime = base.GetText(1);
		this.IsRemainTimeActive = (this.ActivityData.EndShowTime != 0L);
		this.RemainTime.SetUIActive(this.ActivityData.EndShowTime != 0L);
		int? playerLevel = ModelBase<PlayerInfoModel>.Instance.GetPlayerLevel();
		base.GetText(0).SetText(playerLevel.ToString(), true);
		base.GetText(4).SetText(this.ActivityData.GetTitle(), true);
	}

	// Token: 0x06009327 RID: 37671 RVA: 0x0026D452 File Offset: 0x0026B652
	protected override void OnBeforeShow()
	{
		this.SetRemainTimeText();
	}

	// Token: 0x06009328 RID: 37672 RVA: 0x0026D45C File Offset: 0x0026B65C
	protected override void OnBeforeDestroy()
	{
		foreach (NoviceJourneyItem child in this.Layout.GetLayoutItemList())
		{
			base.AddChild(child);
		}
	}

	// Token: 0x06009329 RID: 37673 RVA: 0x0026D4B4 File Offset: 0x0026B6B4
	private void SetRemainTimeActive(bool isActive)
	{
		if (this.IsRemainTimeActive == isActive)
		{
			return;
		}
		this.IsRemainTimeActive = isActive;
		this.RemainTime.SetUIActive(isActive);
	}

	// Token: 0x0600932A RID: 37674 RVA: 0x0026D4D4 File Offset: 0x0026B6D4
	private void SetRemainTimeText()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.SetRemainTimeActive(item);
		if (item)
		{
			this.RemainTime.SetText(item2, true);
		}
	}

	// Token: 0x0600932B RID: 37675 RVA: 0x0026D50B File Offset: 0x0026B70B
	protected override void OnTimer(float gap)
	{
		this.SetRemainTimeText();
	}

	// Token: 0x04004419 RID: 17433
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NoviceJourneyItem, NewbieCourse> Layout;

	// Token: 0x0400441A RID: 17434
	[Nullable(2)]
	private UUIText RemainTime;

	// Token: 0x0400441B RID: 17435
	private bool IsRemainTimeActive = true;

	// Token: 0x0400441C RID: 17436
	[Nullable(2)]
	private ActivityNoviceJourneyData ActivityData;

	// Token: 0x02007891 RID: 30865
	private class EComponents
	{
		// Token: 0x04029753 RID: 169811
		public const int LevelText = 0;

		// Token: 0x04029754 RID: 169812
		public const int RemainTimeText = 1;

		// Token: 0x04029755 RID: 169813
		public const int Layout = 2;

		// Token: 0x04029756 RID: 169814
		public const int GridItem = 3;

		// Token: 0x04029757 RID: 169815
		public const int TitleText = 4;
	}
}
