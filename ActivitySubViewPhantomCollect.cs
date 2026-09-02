using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001490 RID: 5264
public class ActivitySubViewPhantomCollect : ActivitySubViewBase
{
	// Token: 0x06009357 RID: 37719 RVA: 0x0026DFD8 File Offset: 0x0026C1D8
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009358 RID: 37720 RVA: 0x0026E0E6 File Offset: 0x0026C2E6
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomCollectUpdate, new Action<PhantomCollectRewardType>(this.OnPhantomCollectUpdate));
	}

	// Token: 0x06009359 RID: 37721 RVA: 0x0026E104 File Offset: 0x0026C304
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomCollectUpdate, new Action<PhantomCollectRewardType>(this.OnPhantomCollectUpdate));
	}

	// Token: 0x0600935A RID: 37722 RVA: 0x0026E122 File Offset: 0x0026C322
	private void OnPhantomCollectUpdate(PhantomCollectRewardType reawrdType)
	{
		this.RefreshTaskLayout();
	}

	// Token: 0x0600935B RID: 37723 RVA: 0x0026E12A File Offset: 0x0026C32A
	protected override void OnSetData()
	{
		this.ActivityData = (ActivityPhantomCollectData)this.ActivityBaseData;
	}

	// Token: 0x0600935C RID: 37724 RVA: 0x0026E140 File Offset: 0x0026C340
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewPhantomCollect.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewPhantomCollect.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600935D RID: 37725 RVA: 0x0026E183 File Offset: 0x0026C383
	protected override void OnStart()
	{
		this.ActivityData = ControllerBase<ActivityPhantomCollectController>.Instance.GetCurrentActivityDataById();
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
	}

	// Token: 0x0600935E RID: 37726 RVA: 0x0026E1BC File Offset: 0x0026C3BC
	protected override void OnRefreshView()
	{
		this.RefreshTimerText();
		this.RefreshTaskLayout();
		this.RefreshMonster();
	}

	// Token: 0x0600935F RID: 37727 RVA: 0x0026E1D0 File Offset: 0x0026C3D0
	public void RefreshTimerText()
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

	// Token: 0x06009360 RID: 37728 RVA: 0x0026E210 File Offset: 0x0026C410
	public void RefreshTaskLayout()
	{
		ActivityPhantomCollectData currentActivityDataById = ControllerBase<ActivityPhantomCollectController>.Instance.GetCurrentActivityDataById();
		this.TaskGenericLayout.RefreshByDataAsync(((currentActivityDataById != null) ? currentActivityDataById.PhantomCollectRewardList : null) ?? new PhantomCollectReward[0], false, null);
	}

	// Token: 0x06009361 RID: 37729 RVA: 0x0026E254 File Offset: 0x0026C454
	public void RefreshMonster()
	{
		int[] collectPhantomList = this.ActivityData.GetCollectPhantomList();
		for (int i = 0; i < 5; i++)
		{
			this.MonsterItemList[i].Refresh(collectPhantomList[i]);
		}
	}

	// Token: 0x04004424 RID: 17444
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<ActivitySubViewPhantomCollectTaskItem, PhantomCollectReward> TaskGenericLayout;

	// Token: 0x04004425 RID: 17445
	[Nullable(2)]
	public ActivityPhantomCollectData ActivityData;

	// Token: 0x04004426 RID: 17446
	[Nullable(2)]
	public ActivityTitleTypeA TitleComponent;

	// Token: 0x04004427 RID: 17447
	[Nullable(1)]
	public List<ActivitySubViewPhantomCollectMonsterItem> MonsterItemList = new List<ActivitySubViewPhantomCollectMonsterItem>();

	// Token: 0x04004428 RID: 17448
	[Nullable(1)]
	private readonly Func<ActivitySubViewPhantomCollectTaskItem> CreateGrid = () => new ActivitySubViewPhantomCollectTaskItem();

	// Token: 0x0200789B RID: 30875
	private class EActivitySubViewPhantomCollect
	{
		// Token: 0x0402977D RID: 169853
		public const int TitleItem = 0;

		// Token: 0x0402977E RID: 169854
		public const int PhantomCollectItem1 = 1;

		// Token: 0x0402977F RID: 169855
		public const int PhantomCollectItem2 = 2;

		// Token: 0x04029780 RID: 169856
		public const int PhantomCollectItem3 = 3;

		// Token: 0x04029781 RID: 169857
		public const int PhantomCollectItem4 = 4;

		// Token: 0x04029782 RID: 169858
		public const int PhantomCollectItem5 = 5;

		// Token: 0x04029783 RID: 169859
		public const int VerticalLayout = 6;
	}
}
