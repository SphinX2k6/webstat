using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A98 RID: 6808
[NullableContext(1)]
[Nullable(0)]
public class DailyActivityDefine
{
	// Token: 0x04005D66 RID: 23910
	public const int DAILY_ACTIVITY_HELP = 27;

	// Token: 0x04005D67 RID: 23911
	public const string REWARD_BACKGROUND_COLOR_UNFINISHED = "00000033";

	// Token: 0x04005D68 RID: 23912
	public const string REWARD_BACKGROUND_COLOR_FINISHED = "F3EAAB1E";

	// Token: 0x04005D69 RID: 23913
	public const int WEEKLY_REFRESH_TIME_STORAGE_KEY = 999;

	// Token: 0x02007D56 RID: 32086
	[NullableContext(0)]
	public class RewardTuple
	{
		// Token: 0x0402AB72 RID: 174962
		public int Id;

		// Token: 0x0402AB73 RID: 174963
		public int Num;

		// Token: 0x0402AB74 RID: 174964
		public bool Received;

		// Token: 0x0402AB75 RID: 174965
		public bool IsDoubleRewardVisible;
	}

	// Token: 0x02007D57 RID: 32087
	public interface IActivityGoalData
	{
		// Token: 0x1700A820 RID: 43040
		// (get) Token: 0x06047D60 RID: 294240
		// (set) Token: 0x06047D61 RID: 294241
		int Id { get; set; }

		// Token: 0x1700A821 RID: 43041
		// (get) Token: 0x06047D62 RID: 294242
		// (set) Token: 0x06047D63 RID: 294243
		int Goal { get; set; }

		// Token: 0x1700A822 RID: 43042
		// (get) Token: 0x06047D64 RID: 294244
		// (set) Token: 0x06047D65 RID: 294245
		List<TItem> Rewards { get; set; }

		// Token: 0x1700A823 RID: 43043
		// (get) Token: 0x06047D66 RID: 294246
		// (set) Token: 0x06047D67 RID: 294247
		bool Achieved { get; set; }

		// Token: 0x1700A824 RID: 43044
		// (get) Token: 0x06047D68 RID: 294248
		// (set) Token: 0x06047D69 RID: 294249
		EDailyActiveState State { get; set; }
	}

	// Token: 0x02007D58 RID: 32088
	[Nullable(0)]
	public class ActivityGoalData
	{
		// Token: 0x1700A825 RID: 43045
		// (get) Token: 0x06047D6A RID: 294250 RVA: 0x0132A342 File Offset: 0x01328542
		// (set) Token: 0x06047D6B RID: 294251 RVA: 0x0132A34A File Offset: 0x0132854A
		public int Id { get; set; }

		// Token: 0x1700A826 RID: 43046
		// (get) Token: 0x06047D6C RID: 294252 RVA: 0x0132A353 File Offset: 0x01328553
		// (set) Token: 0x06047D6D RID: 294253 RVA: 0x0132A35B File Offset: 0x0132855B
		public int Goal { get; set; }

		// Token: 0x1700A827 RID: 43047
		// (get) Token: 0x06047D6E RID: 294254 RVA: 0x0132A364 File Offset: 0x01328564
		// (set) Token: 0x06047D6F RID: 294255 RVA: 0x0132A36C File Offset: 0x0132856C
		public List<TItem> Rewards { get; set; }

		// Token: 0x1700A828 RID: 43048
		// (get) Token: 0x06047D70 RID: 294256 RVA: 0x0132A375 File Offset: 0x01328575
		// (set) Token: 0x06047D71 RID: 294257 RVA: 0x0132A37D File Offset: 0x0132857D
		public bool Achieved { get; set; }

		// Token: 0x1700A829 RID: 43049
		// (get) Token: 0x06047D72 RID: 294258 RVA: 0x0132A386 File Offset: 0x01328586
		// (set) Token: 0x06047D73 RID: 294259 RVA: 0x0132A38E File Offset: 0x0132858E
		public EDailyActiveState State { get; set; }
	}

	// Token: 0x02007D59 RID: 32089
	[NullableContext(0)]
	public enum EDailyActivityMainTab
	{
		// Token: 0x0402AB7C RID: 174972
		Daily = 1,
		// Token: 0x0402AB7D RID: 174973
		Weekly
	}

	// Token: 0x02007D5A RID: 32090
	public interface IDailyActivityMainTabData
	{
		// Token: 0x1700A82A RID: 43050
		// (get) Token: 0x06047D75 RID: 294261
		// (set) Token: 0x06047D76 RID: 294262
		DailyActivityDefine.EDailyActivityMainTab TabType { get; set; }

		// Token: 0x1700A82B RID: 43051
		// (get) Token: 0x06047D77 RID: 294263
		// (set) Token: 0x06047D78 RID: 294264
		bool IsFinished { get; set; }
	}

	// Token: 0x02007D5B RID: 32091
	[NullableContext(0)]
	public class DailyActivityMainTabData : DailyActivityDefine.IDailyActivityMainTabData
	{
		// Token: 0x1700A82C RID: 43052
		// (get) Token: 0x06047D79 RID: 294265 RVA: 0x0132A39F File Offset: 0x0132859F
		// (set) Token: 0x06047D7A RID: 294266 RVA: 0x0132A3A7 File Offset: 0x013285A7
		public DailyActivityDefine.EDailyActivityMainTab TabType { get; set; }

		// Token: 0x1700A82D RID: 43053
		// (get) Token: 0x06047D7B RID: 294267 RVA: 0x0132A3B0 File Offset: 0x013285B0
		// (set) Token: 0x06047D7C RID: 294268 RVA: 0x0132A3B8 File Offset: 0x013285B8
		public bool IsFinished { get; set; }
	}

	// Token: 0x02007D5C RID: 32092
	public interface IActivityRewardPanelDataAdapter
	{
		// Token: 0x1700A82E RID: 43054
		// (get) Token: 0x06047D7E RID: 294270
		double CurrentValue { get; }

		// Token: 0x1700A82F RID: 43055
		// (get) Token: 0x06047D7F RID: 294271
		double MaxValue { get; }

		// Token: 0x1700A830 RID: 43056
		// (get) Token: 0x06047D80 RID: 294272
		IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> GoalMap { get; }

		// Token: 0x06047D81 RID: 294273
		List<int> GetCanRewardIdList();

		// Token: 0x06047D82 RID: 294274
		void RequestReward(List<int> idList, Action onClose);

		// Token: 0x06047D83 RID: 294275
		List<TItem> GetRewardById(int id);
	}
}
