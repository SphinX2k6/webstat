using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200124D RID: 4685
public class ActivitySubViewBeginnerBook : ActivitySubViewBase
{
	// Token: 0x06007CE1 RID: 31969 RVA: 0x0020E3B4 File Offset: 0x0020C5B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007CE2 RID: 31970 RVA: 0x0020E4A1 File Offset: 0x0020C6A1
	protected override void OnSetData()
	{
		this.ActivityData = (this.ActivityBaseData as ActivityBeginnerBookData);
	}

	// Token: 0x06007CE3 RID: 31971 RVA: 0x0020E4B4 File Offset: 0x0020C6B4
	protected override void OnStart()
	{
		base.GetText(0).SetText(this.ActivityData.GetTitle(), true);
		this.TargetLayout = new GenericLayout<ActivityBeginnerTargetItem, int>(base.GetVerticalLayout(2), this.InitItem, base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		this.RemainTime = base.GetText(1);
		this.IsRemainTimeActive = (this.ActivityData.EndShowTime != 0L);
		this.RemainTime.SetUIActive(this.ActivityData.EndShowTime != 0L);
		this.SetRemainTimeText();
	}

	// Token: 0x06007CE4 RID: 31972 RVA: 0x0020E580 File Offset: 0x0020C780
	protected override UniTask OnBeforeShowSelfAsync()
	{
		ActivitySubViewBeginnerBook.<OnBeforeShowSelfAsync>d__8 <OnBeforeShowSelfAsync>d__;
		<OnBeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowSelfAsync>d__.<>4__this = this;
		<OnBeforeShowSelfAsync>d__.<>1__state = -1;
		<OnBeforeShowSelfAsync>d__.<>t__builder.Start<ActivitySubViewBeginnerBook.<OnBeforeShowSelfAsync>d__8>(ref <OnBeforeShowSelfAsync>d__);
		return <OnBeforeShowSelfAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007CE5 RID: 31973 RVA: 0x0020E5C3 File Offset: 0x0020C7C3
	protected override void OnRefreshView()
	{
		GenericLayout<ActivityBeginnerTargetItem, int> targetLayout = this.TargetLayout;
		if (targetLayout == null)
		{
			return;
		}
		targetLayout.RefreshByData(this.ActivityData.AllBeginnerTargetList, delegate
		{
			GenericLayout<ActivityBeginnerTargetItem, int> targetLayout2 = this.TargetLayout;
			List<ActivityBeginnerTargetItem> list = (targetLayout2 != null) ? targetLayout2.GetLayoutItemList() : null;
			ActivityBeginnerBookData activityBeginnerBookData = this.ActivityBaseData as ActivityBeginnerBookData;
			foreach (ActivityBeginnerTargetItem activityBeginnerTargetItem in list)
			{
				activityBeginnerTargetItem.SetEnableJump(activityBeginnerBookData.GetEnableJump(activityBeginnerTargetItem.DataId));
				activityBeginnerTargetItem.SetFinish(activityBeginnerBookData.GetFinishState(activityBeginnerTargetItem.DataId));
			}
		}, false);
	}

	// Token: 0x06007CE6 RID: 31974 RVA: 0x0020E5ED File Offset: 0x0020C7ED
	private void SetRemainTimeActive(bool isActive)
	{
		if (this.IsRemainTimeActive == isActive)
		{
			return;
		}
		this.IsRemainTimeActive = isActive;
		this.RemainTime.SetUIActive(isActive);
	}

	// Token: 0x06007CE7 RID: 31975 RVA: 0x0020E60C File Offset: 0x0020C80C
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

	// Token: 0x06007CE8 RID: 31976 RVA: 0x0020E643 File Offset: 0x0020C843
	protected override void OnTimer(float gap)
	{
		this.SetRemainTimeText();
	}

	// Token: 0x04003BB7 RID: 15287
	[Nullable(2)]
	private UUIText RemainTime;

	// Token: 0x04003BB8 RID: 15288
	private bool IsRemainTimeActive = true;

	// Token: 0x04003BB9 RID: 15289
	[Nullable(2)]
	private ActivityBeginnerBookData ActivityData;

	// Token: 0x04003BBA RID: 15290
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityBeginnerTargetItem, int> TargetLayout;

	// Token: 0x04003BBB RID: 15291
	[Nullable(1)]
	private readonly Func<ActivityBeginnerTargetItem> InitItem = () => new ActivityBeginnerTargetItem();

	// Token: 0x020075C7 RID: 30151
	private class EChildType
	{
		// Token: 0x04028A0F RID: 166415
		public const int TitleText = 0;

		// Token: 0x04028A10 RID: 166416
		public const int RemainTimeText = 1;

		// Token: 0x04028A11 RID: 166417
		public const int TargetLayout = 2;

		// Token: 0x04028A12 RID: 166418
		public const int LayouetItem = 3;

		// Token: 0x04028A13 RID: 166419
		public const int FemaleItem = 4;

		// Token: 0x04028A14 RID: 166420
		public const int MaleItem = 5;
	}
}
