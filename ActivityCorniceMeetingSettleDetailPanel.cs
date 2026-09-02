using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020012B2 RID: 4786
public class ActivityCorniceMeetingSettleDetailPanel : UiPanelBase
{
	// Token: 0x06008076 RID: 32886 RVA: 0x0021EDC4 File Offset: 0x0021CFC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
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
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008077 RID: 32887 RVA: 0x0021EED4 File Offset: 0x0021D0D4
	protected override void OnStart()
	{
		if (this.Data == null)
		{
			return;
		}
		ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(this.Data.LevelPlayId);
		if (levelEntryData == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_ItemCost_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			levelEntryData.CurrentScore.ToString(),
			(levelEntryData != null) ? new int?(levelEntryData.GetMaxScoreConfig()) : null
		}));
		string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)this.Data.RemainingTime);
		base.GetText(1).SetText(timeString, true);
		base.GetItem(5).SetUIActive(levelEntryData.CurrentScore >= levelEntryData.GetMaxScoreConfig());
		base.GetItem(4).SetUIActive(levelEntryData.CurrentScore > 0);
		base.GetItem(3).SetUIActive(this.Data.NewRemainingTimeRecord && !this.Data.NewScoreRecord);
		base.GetItem(2).SetUIActive(this.Data.NewScoreRecord);
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x04003D50 RID: 15696
	[Nullable(1)]
	public CorniceChallengeEndNotify Data;

	// Token: 0x0200762B RID: 30251
	private class EChildComponents
	{
		// Token: 0x04028BBA RID: 166842
		public const int TxtScore = 0;

		// Token: 0x04028BBB RID: 166843
		public const int TxtTime = 1;

		// Token: 0x04028BBC RID: 166844
		public const int ScoreNewRecordItem = 2;

		// Token: 0x04028BBD RID: 166845
		public const int TimeNewRecordItem = 3;

		// Token: 0x04028BBE RID: 166846
		public const int ScorePanelItem = 4;

		// Token: 0x04028BBF RID: 166847
		public const int TimePanelItem = 5;

		// Token: 0x04028BC0 RID: 166848
		public const int TxtFailTipsItem = 6;
	}
}
