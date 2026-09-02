using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069DA RID: 27098
	[NullableContext(2)]
	[Nullable(0)]
	public class AnniversarySubActivityAnniversaryGift : AnniversarySubActivityDataBase
	{
		// Token: 0x060432D4 RID: 275156 RVA: 0x01142B40 File Offset: 0x01140D40
		public AnniversarySubActivityAnniversaryGift(int id) : base(id)
		{
		}

		// Token: 0x1700A1F4 RID: 41460
		// (get) Token: 0x060432D5 RID: 275157 RVA: 0x01142B49 File Offset: 0x01140D49
		public ActivityTimePointRewardData ActivityData
		{
			get
			{
				if (this.ActivityDataCache == null)
				{
					this.ActivityDataCache = (base.GetActivityData() as ActivityTimePointRewardData);
				}
				return this.ActivityDataCache;
			}
		}

		// Token: 0x060432D6 RID: 275158 RVA: 0x01142B6C File Offset: 0x01140D6C
		[NullableContext(0)]
		public override ValueTuple<int, int> GetCurrentProgress()
		{
			int num = 0;
			int num2 = 0;
			IReadOnlyList<TimePointRewardActivity> timePointRewardListByActivityId = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardListByActivityId(this.ActivityId);
			if (timePointRewardListByActivityId != null)
			{
				foreach (TimePointRewardActivity timePointRewardActivity in timePointRewardListByActivityId)
				{
					for (int i = 0; i < timePointRewardActivity.RewardsLength; i++)
					{
						IntPair? intPair = timePointRewardActivity.Rewards(i);
						if (intPair != null && intPair.Value.Item1 == 74)
						{
							num += intPair.Value.Item2;
						}
					}
				}
			}
			ActivityTimePointRewardData activityTimePointRewardData = base.GetActivityData() as ActivityTimePointRewardData;
			List<TimePointRewardData> list = (activityTimePointRewardData != null) ? activityTimePointRewardData.GetRewardDataList() : null;
			if (list != null)
			{
				foreach (TimePointRewardData timePointRewardData in list)
				{
					TimePointRewardActivity? timePointRewardById = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(timePointRewardData.Id);
					if (timePointRewardById != null)
					{
						for (int j = 0; j < timePointRewardById.Value.RewardsLength; j++)
						{
							IntPair? intPair2 = timePointRewardById.Value.Rewards(j);
							if (intPair2 != null && intPair2.Value.Item1 == 74 && timePointRewardData.RewardState == ETimePointRewardState.UnlockAndClaimed)
							{
								num2 += intPair2.Value.Item2;
							}
						}
					}
				}
			}
			return new ValueTuple<int, int>(num2, num);
		}

		// Token: 0x04025701 RID: 153345
		private ActivityTimePointRewardData ActivityDataCache;
	}
}
