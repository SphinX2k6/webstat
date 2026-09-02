using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

// Token: 0x02001282 RID: 4738
public class MoonCelebrationAwardSubView : ActivitySubViewBase
{
	// Token: 0x06007ED5 RID: 32469 RVA: 0x002194DC File Offset: 0x002176DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardAllBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnRewardItemClickBtnA));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnRewardItemClickBtnB));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007ED6 RID: 32470 RVA: 0x00219716 File Offset: 0x00217916
	protected override void OnSetData()
	{
		this.ActivityTimePointRewardData = (this.ActivityBaseData as ActivityTimePointRewardData);
	}

	// Token: 0x06007ED7 RID: 32471 RVA: 0x00219729 File Offset: 0x00217929
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007ED8 RID: 32472 RVA: 0x00219747 File Offset: 0x00217947
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
	}

	// Token: 0x06007ED9 RID: 32473 RVA: 0x00219765 File Offset: 0x00217965
	protected override void OnStart()
	{
		base.GetText(10).SetText(this.ActivityBaseData.GetTitle(), true);
		this.RefreshTimeTitle();
		this.RefreshRewardItem();
		this.RefreshRewardState();
	}

	// Token: 0x06007EDA RID: 32474 RVA: 0x00219794 File Offset: 0x00217994
	private void RefreshRewardItem()
	{
		List<TimePointRewardData> rewardDataList = this.ActivityTimePointRewardData.GetRewardDataList();
		TimePointRewardActivity value = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(rewardDataList[0].Id).Value;
		bool flag = false;
		for (int i = 0; i < value.RewardItemLength; i++)
		{
			int key = value.RewardItem(i).Value.Key;
			int value2 = value.RewardItem(i).Value.Value;
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(key);
			if (config != null)
			{
				if (!flag)
				{
					base.SetTextureByPath(config.Value.Icon, base.GetTexture(8), null, null);
					base.GetText(5).SetText("X" + value2.ToString(), true);
					flag = true;
					this.ItemDataIdA = key;
				}
				else
				{
					base.SetTextureByPath(config.Value.Icon, base.GetTexture(9), null, null);
					base.GetText(7).SetText("X" + value2.ToString(), true);
					this.ItemDataIdB = key;
				}
			}
		}
	}

	// Token: 0x06007EDB RID: 32475 RVA: 0x002198E4 File Offset: 0x00217AE4
	private void RefreshRewardState()
	{
		List<TimePointRewardData> rewardDataList = this.ActivityTimePointRewardData.GetRewardDataList();
		bool flag = rewardDataList[0].RewardState == ETimePointRewardState.Lock;
		base.GetText(2).SetUIActive(flag);
		if (flag)
		{
			double num = (double)rewardDataList[0].RewardTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			this.SetTimeText(num);
			if (num <= 1.0)
			{
				rewardDataList[0].HasUnlock = true;
			}
			base.GetButton(0).SetSelfInteractive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Moon_Reward_Lock", Array.Empty<object>());
			base.GetItem(11).SetUIActive(true);
			return;
		}
		bool flag2 = rewardDataList[0].RewardState == ETimePointRewardState.UnlockAndUnClaimed;
		base.GetButton(0).SetSelfInteractive(flag2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), flag2 ? "Moon_Reward_Unlock" : "Moon_Reward_Finish", Array.Empty<object>());
		base.GetItem(11).SetUIActive(false);
		if (!flag2)
		{
			base.GetButton(4).SetSelfInteractive(false);
			base.GetButton(6).SetSelfInteractive(false);
		}
	}

	// Token: 0x06007EDC RID: 32476 RVA: 0x002199FC File Offset: 0x00217BFC
	private void OnClickRewardAllBtn()
	{
		List<TimePointRewardData> rewardDataList = this.ActivityTimePointRewardData.GetRewardDataList();
		if (rewardDataList[0].RewardState != ETimePointRewardState.UnlockAndUnClaimed)
		{
			return;
		}
		ControllerBase<ActivityTimePointRewardController>.Instance.GetRewardById(this.ActivityTimePointRewardData.Id, rewardDataList[0].Id);
	}

	// Token: 0x06007EDD RID: 32477 RVA: 0x00219A46 File Offset: 0x00217C46
	private void OnRewardItemClickBtnA()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemDataIdA, true, null);
	}

	// Token: 0x06007EDE RID: 32478 RVA: 0x00219A5A File Offset: 0x00217C5A
	private void OnRewardItemClickBtnB()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemDataIdB, true, null);
	}

	// Token: 0x06007EDF RID: 32479 RVA: 0x00219A70 File Offset: 0x00217C70
	private void SetTimeText(double leftTime)
	{
		double num = leftTime * Singleton<TimeUtil>.Instance.Millisecond;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (num >= 86400.0)
		{
			double num2 = num / Singleton<TimeUtil>.Instance.Hour;
			double num3 = Math.Floor(num2 / Singleton<TimeUtil>.Instance.OneDayHourCount);
			double value = Math.Ceiling(num2 - num3 * Singleton<TimeUtil>.Instance.OneDayHourCount);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(2);
			string textStringId = "CelebrationAwardLeftTimeDay";
			object[] array = new object[2];
			int num4 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num5 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(value);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array[num5] = defaultInterpolatedStringHandler.ToStringAndClear();
			instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlyArray<object>(array));
			return;
		}
		if (num >= 3600.0)
		{
			double num6 = num / Singleton<TimeUtil>.Instance.Minute;
			double num7 = Math.Floor(num6 / Singleton<TimeUtil>.Instance.Minute);
			double value2 = Math.Ceiling(num6 - num7 * Singleton<TimeUtil>.Instance.Minute);
			LguiUtil instance2 = Singleton<LguiUtil>.Instance;
			UUIText text2 = base.GetText(2);
			string textStringId2 = "CelebrationAwardLeftTimeHour";
			object[] array2 = new object[2];
			int num8 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num7);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array2[num8] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num9 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array2[num9] = defaultInterpolatedStringHandler.ToStringAndClear();
			instance2.SetLocalTextNew(text2, textStringId2, new <>z__ReadOnlyArray<object>(array2));
			return;
		}
		if (num >= 60.0)
		{
			double num10 = num;
			double num11 = Math.Floor(num / Singleton<TimeUtil>.Instance.Minute);
			double value3 = Math.Ceiling(num10 - num11 * Singleton<TimeUtil>.Instance.Minute);
			LguiUtil instance3 = Singleton<LguiUtil>.Instance;
			UUIText text3 = base.GetText(2);
			string textStringId3 = "CelebrationAwardLeftTimeSecond";
			object[] array3 = new object[2];
			int num12 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num11);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array3[num12] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num13 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(value3);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array3[num13] = defaultInterpolatedStringHandler.ToStringAndClear();
			instance3.SetLocalTextNew(text3, textStringId3, new <>z__ReadOnlyArray<object>(array3));
			return;
		}
		LguiUtil instance4 = Singleton<LguiUtil>.Instance;
		UUIText text4 = base.GetText(2);
		string textStringId4 = "CelebrationAwardLeftTimeLessSecond";
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#f39233>");
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Max(Math.Floor(num), 1.0));
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		instance4.SetLocalTextNew(text4, textStringId4, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
	}

	// Token: 0x06007EE0 RID: 32480 RVA: 0x00219D46 File Offset: 0x00217F46
	private void OnRefreshCommonActivityRedDot(int id)
	{
		if (this.ActivityBaseData.Id != id)
		{
			return;
		}
		this.RefreshRewardItem();
		this.RefreshRewardState();
	}

	// Token: 0x06007EE1 RID: 32481 RVA: 0x00219D64 File Offset: 0x00217F64
	private void RefreshTimeTitle()
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityTimePointRewardData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(3).SetUIActive(item);
		if (item)
		{
			base.GetText(3).SetText(item2, true);
		}
	}

	// Token: 0x06007EE2 RID: 32482 RVA: 0x00219DAD File Offset: 0x00217FAD
	protected override void OnTimer(float gap)
	{
		this.RefreshRewardState();
		this.RefreshTimeTitle();
	}

	// Token: 0x04003CCE RID: 15566
	[Nullable(2)]
	protected ActivityTimePointRewardData ActivityTimePointRewardData;

	// Token: 0x04003CCF RID: 15567
	private int ItemDataIdA;

	// Token: 0x04003CD0 RID: 15568
	private int ItemDataIdB;

	// Token: 0x02007605 RID: 30213
	private class EComponentDefine
	{
		// Token: 0x04028B11 RID: 166673
		public const int GetBtn = 0;

		// Token: 0x04028B12 RID: 166674
		public const int GetText = 1;

		// Token: 0x04028B13 RID: 166675
		public const int TimeText = 2;

		// Token: 0x04028B14 RID: 166676
		public const int TitleTimeText = 3;

		// Token: 0x04028B15 RID: 166677
		public const int RewardBtnA = 4;

		// Token: 0x04028B16 RID: 166678
		public const int ItemACountText = 5;

		// Token: 0x04028B17 RID: 166679
		public const int RewardBtnB = 6;

		// Token: 0x04028B18 RID: 166680
		public const int ItemBCountText = 7;

		// Token: 0x04028B19 RID: 166681
		public const int ItemATexture = 8;

		// Token: 0x04028B1A RID: 166682
		public const int ItemBTexture = 9;

		// Token: 0x04028B1B RID: 166683
		public const int TitleText = 10;

		// Token: 0x04028B1C RID: 166684
		public const int TipsItem = 11;
	}
}
