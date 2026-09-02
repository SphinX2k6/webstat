using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001281 RID: 4737
[NullableContext(1)]
[Nullable(0)]
public class AwardPanel : UiPanelBase
{
	// Token: 0x06007EC8 RID: 32456 RVA: 0x00218B98 File Offset: 0x00216D98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickItem1));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickItem2));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickItem3));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickReceive));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007EC9 RID: 32457 RVA: 0x00218E5C File Offset: 0x0021705C
	protected override UniTask OnBeforeStartAsync()
	{
		AwardPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AwardPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007ECA RID: 32458 RVA: 0x00218E9F File Offset: 0x0021709F
	public void SetActivityId(int activeId)
	{
		this.ActivityId = new int?(activeId);
	}

	// Token: 0x06007ECB RID: 32459 RVA: 0x00218EB0 File Offset: 0x002170B0
	public void Refresh(TimePointRewardData data)
	{
		this.Data = data;
		TimePointRewardActivity? timePointRewardById = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(this.Data.Id);
		if (timePointRewardById == null)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			IntPair value = timePointRewardById.Value.Rewards(i).Value;
			this.AwardItems[i].Refresh(this.Data, value);
		}
	}

	// Token: 0x06007ECC RID: 32460 RVA: 0x00218F24 File Offset: 0x00217124
	public void RefreshState(TimePointRewardData data, string tipsTextId)
	{
		bool flag = data.RewardState == ETimePointRewardState.Lock;
		bool uiactive = data.RewardState == ETimePointRewardState.UnlockAndUnClaimed;
		bool uiactive2 = data.RewardState == ETimePointRewardState.UnlockAndClaimed;
		base.GetItem(10).SetUIActive(flag);
		base.GetItem(11).SetUIActive(uiactive);
		base.GetItem(12).SetUIActive(uiactive2);
		base.GetItem(13).SetUIActive(uiactive2);
		base.GetItem(14).SetUIActive(uiactive2);
		base.GetItem(8).SetUIActive(uiactive);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), tipsTextId, Array.Empty<object>());
		base.GetItem(6).SetUIActive(flag);
		base.GetItem(4).SetUIActive(flag);
		if (flag)
		{
			double num = (double)data.RewardTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			this.SetTimeText(num);
			if (num <= 1.0)
			{
				data.HasUnlock = true;
			}
		}
		if (ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(data.Id) == null)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			this.AwardItems[i].RefreshState(data);
		}
		base.GetItem(0).SetUIActive(data.RewardState == ETimePointRewardState.UnlockAndUnClaimed);
		this.RefreshItemBtn(data);
	}

	// Token: 0x06007ECD RID: 32461 RVA: 0x00219060 File Offset: 0x00217260
	private void RefreshItemBtn(TimePointRewardData data)
	{
		for (int i = 0; i < 3; i++)
		{
			this.AwardItems[i].RefreshState(data);
		}
	}

	// Token: 0x06007ECE RID: 32462 RVA: 0x0021908C File Offset: 0x0021728C
	private void SetTimeText(double leftTime)
	{
		double num = leftTime * Singleton<TimeUtil>.Instance.Millisecond;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (num >= 86400.0)
		{
			double num2 = num / Singleton<TimeUtil>.Instance.Hour;
			double num3 = Math.Floor(num2 / Singleton<TimeUtil>.Instance.OneDayHourCount);
			double value = Math.Floor(num2 - num3 * Singleton<TimeUtil>.Instance.OneDayHourCount);
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIText text = base.GetText(5);
			string textStringId = "AnniversaryWelfare_LeftTime_Day";
			object[] array = new object[2];
			int num4 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num5 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
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
			double value2 = Math.Floor(num6 - num7 * Singleton<TimeUtil>.Instance.Minute);
			LguiUtil instance2 = Singleton<LguiUtil>.Instance;
			UUIText text2 = base.GetText(5);
			string textStringId2 = "AnniversaryWelfare_LeftTime_Hour";
			object[] array2 = new object[2];
			int num8 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num7);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array2[num8] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num9 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
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
			double value3 = Math.Floor(num10 - num11 * Singleton<TimeUtil>.Instance.Minute);
			LguiUtil instance3 = Singleton<LguiUtil>.Instance;
			UUIText text3 = base.GetText(5);
			string textStringId3 = "AnniversaryWelfare_LeftTime_Second";
			object[] array3 = new object[2];
			int num12 = 0;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num11);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array3[num12] = defaultInterpolatedStringHandler.ToStringAndClear();
			int num13 = 1;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=");
			defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
			defaultInterpolatedStringHandler.AppendLiteral(">");
			defaultInterpolatedStringHandler.AppendFormatted<double>(value3);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			array3[num13] = defaultInterpolatedStringHandler.ToStringAndClear();
			instance3.SetLocalTextNew(text3, textStringId3, new <>z__ReadOnlyArray<object>(array3));
			return;
		}
		LguiUtil instance4 = Singleton<LguiUtil>.Instance;
		UUIText text4 = base.GetText(5);
		string textStringId4 = "AnniversaryWelfare_LeftTime_LessSecond";
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=");
		defaultInterpolatedStringHandler.AppendFormatted("#ffe04f");
		defaultInterpolatedStringHandler.AppendLiteral(">");
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Max(Math.Floor(num), 1.0));
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		instance4.SetLocalTextNew(text4, textStringId4, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
	}

	// Token: 0x06007ECF RID: 32463 RVA: 0x0021940A File Offset: 0x0021760A
	private void OnClickReceive()
	{
		if (this.Data.RewardState != ETimePointRewardState.UnlockAndUnClaimed)
		{
			return;
		}
		ControllerBase<ActivityTimePointRewardController>.Instance.GetRewardById(this.ActivityId.Value, this.Data.Id);
	}

	// Token: 0x06007ED0 RID: 32464 RVA: 0x0021943B File Offset: 0x0021763B
	private void OnClickItem1()
	{
		this.OnClickItem(0);
	}

	// Token: 0x06007ED1 RID: 32465 RVA: 0x00219444 File Offset: 0x00217644
	private void OnClickItem2()
	{
		this.OnClickItem(1);
	}

	// Token: 0x06007ED2 RID: 32466 RVA: 0x0021944D File Offset: 0x0021764D
	private void OnClickItem3()
	{
		this.OnClickItem(2);
	}

	// Token: 0x06007ED3 RID: 32467 RVA: 0x00219458 File Offset: 0x00217658
	private void OnClickItem(int awardIndex)
	{
		if (this.Data == null)
		{
			return;
		}
		TimePointRewardActivity? timePointRewardById = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(this.Data.Id);
		if (timePointRewardById == null)
		{
			return;
		}
		IntPair? intPair = timePointRewardById.Value.Rewards(awardIndex);
		if (intPair == null)
		{
			return;
		}
		int item = intPair.Value.Item1;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(item, true, null);
	}

	// Token: 0x04003CCA RID: 15562
	[Nullable(2)]
	private TimePointRewardData Data;

	// Token: 0x04003CCB RID: 15563
	private int? ActivityId;

	// Token: 0x04003CCC RID: 15564
	private readonly List<AwardItem> AwardItems = new List<AwardItem>();

	// Token: 0x04003CCD RID: 15565
	private const int REWARD_COUNT = 3;

	// Token: 0x02007603 RID: 30211
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028AFE RID: 166654
		public const int CommonRedDotItem = 0;

		// Token: 0x04028AFF RID: 166655
		public const int RewardBtn1 = 1;

		// Token: 0x04028B00 RID: 166656
		public const int RewardBtn2 = 2;

		// Token: 0x04028B01 RID: 166657
		public const int RewardBtn3 = 3;

		// Token: 0x04028B02 RID: 166658
		public const int TimeItem = 4;

		// Token: 0x04028B03 RID: 166659
		public const int TimeCountText = 5;

		// Token: 0x04028B04 RID: 166660
		public const int TimeTipsItem = 6;

		// Token: 0x04028B05 RID: 166661
		public const int TimeTipsText = 7;

		// Token: 0x04028B06 RID: 166662
		public const int RewardReceiveItem = 8;

		// Token: 0x04028B07 RID: 166663
		public const int RewardSelfBtn = 9;

		// Token: 0x04028B08 RID: 166664
		public const int UnClaimableItem = 10;

		// Token: 0x04028B09 RID: 166665
		public const int ClaimableItem = 11;

		// Token: 0x04028B0A RID: 166666
		public const int ClaimedItem = 12;

		// Token: 0x04028B0B RID: 166667
		public const int ClaimedMaskItem = 13;

		// Token: 0x04028B0C RID: 166668
		public const int ClaimedTextItem = 14;
	}
}
