using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001622 RID: 5666
[NullableContext(1)]
[Nullable(0)]
public class ActivityVersionPreheatSubView : ActivitySubViewBase
{
	// Token: 0x06009FBF RID: 40895 RVA: 0x0029B850 File Offset: 0x00299A50
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009FC0 RID: 40896 RVA: 0x0029B980 File Offset: 0x00299B80
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityVersionPreheatSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityVersionPreheatSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009FC1 RID: 40897 RVA: 0x0029B9C3 File Offset: 0x00299BC3
	protected override void OnBeforeDestroy()
	{
		this.QuestItemList.Clear();
	}

	// Token: 0x06009FC2 RID: 40898 RVA: 0x0029B9D0 File Offset: 0x00299BD0
	protected override void OnStart()
	{
	}

	// Token: 0x06009FC3 RID: 40899 RVA: 0x0029B9D2 File Offset: 0x00299BD2
	protected override void OnRefreshView()
	{
		this.RefreshQuests();
		this.RefreshActivityInfo();
		this.RefreshBonus();
	}

	// Token: 0x06009FC4 RID: 40900 RVA: 0x0029B9E8 File Offset: 0x00299BE8
	protected override void OnTimer(float gap)
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.ActivityInfoItem.RefreshSubTitleExternal(item, item2);
	}

	// Token: 0x06009FC5 RID: 40901 RVA: 0x0029BA18 File Offset: 0x00299C18
	private unsafe void RefreshQuests()
	{
		List<VersionPreheatQuestData> list = ModelBase<VersionPreheatModel>.Instance.BuildQuestDataList();
		if (this.QuestItemList.Count != list.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.VersionPreheat;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "任务数据个数与任务ui个数不匹配，隐藏全部任务面板";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("item count", this.QuestItemList.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("data count", list.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			foreach (VersionPreheatQuestItem versionPreheatQuestItem in this.QuestItemList)
			{
				versionPreheatQuestItem.SetUiActive(false);
			}
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			VersionPreheatQuestData data = list[i];
			this.QuestItemList[i].RefreshExternalAsync(data);
		}
	}

	// Token: 0x06009FC6 RID: 40902 RVA: 0x0029BB28 File Offset: 0x00299D28
	private void RefreshActivityInfo()
	{
		VersionPreheatActivityInfoData data = ModelBase<VersionPreheatModel>.Instance.BuildActivityInfoData();
		this.ActivityInfoItem.RefreshExternal(data);
	}

	// Token: 0x06009FC7 RID: 40903 RVA: 0x0029BB4C File Offset: 0x00299D4C
	private void RefreshBonus()
	{
		VersionPreheatModel instance = ModelBase<VersionPreheatModel>.Instance;
		bool isBonusAvailable = instance.IsBonusAvailable;
		this.BonusItem.SetUiActive(isBonusAvailable);
		if (isBonusAvailable)
		{
			VersionPreheatBonusData data = instance.BuildBonusQuestData();
			this.BonusItem.RefreshExternalAsync(data);
		}
	}

	// Token: 0x04004966 RID: 18790
	private List<VersionPreheatQuestItem> QuestItemList = new List<VersionPreheatQuestItem>();

	// Token: 0x04004967 RID: 18791
	private VersionPreheatBonusItem BonusItem;

	// Token: 0x04004968 RID: 18792
	private VersionPreheatActivityItem ActivityInfoItem;

	// Token: 0x04004969 RID: 18793
	private readonly int[] PreheatItemIndexList = new int[]
	{
		0,
		1,
		2,
		3,
		4,
		5
	};

	// Token: 0x020079D7 RID: 31191
	[NullableContext(0)]
	internal class EComponent
	{
		// Token: 0x04029D35 RID: 171317
		public const int PreheatItem1 = 0;

		// Token: 0x04029D36 RID: 171318
		public const int PreheatItem2 = 1;

		// Token: 0x04029D37 RID: 171319
		public const int PreheatItem3 = 2;

		// Token: 0x04029D38 RID: 171320
		public const int PreheatItem4 = 3;

		// Token: 0x04029D39 RID: 171321
		public const int PreheatItem5 = 4;

		// Token: 0x04029D3A RID: 171322
		public const int PreheatItem6 = 5;

		// Token: 0x04029D3B RID: 171323
		public const int BonusItem = 6;

		// Token: 0x04029D3C RID: 171324
		public const int ActivityInfoItem = 7;
	}
}
