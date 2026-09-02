using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E1 RID: 27105
	[NullableContext(2)]
	[Nullable(0)]
	public class AnniversarySubActivityWuWuPack : AnniversarySubActivityDataBase
	{
		// Token: 0x060432F4 RID: 275188 RVA: 0x011436B7 File Offset: 0x011418B7
		public AnniversarySubActivityWuWuPack(int id) : base(id)
		{
		}

		// Token: 0x1700A1F8 RID: 41464
		// (get) Token: 0x060432F5 RID: 275189 RVA: 0x011436C0 File Offset: 0x011418C0
		public WuWuLogisticsActivityData ActivityData
		{
			get
			{
				if (this.ActivityDataCache == null)
				{
					this.ActivityDataCache = (base.GetActivityData() as WuWuLogisticsActivityData);
				}
				return this.ActivityDataCache;
			}
		}

		// Token: 0x060432F6 RID: 275190 RVA: 0x011436E1 File Offset: 0x011418E1
		public void ClickOpenView()
		{
		}

		// Token: 0x060432F7 RID: 275191 RVA: 0x011436E4 File Offset: 0x011418E4
		[NullableContext(0)]
		public override ValueTuple<int, int> GetCurrentProgress()
		{
			int num = 0;
			int num2 = 0;
			IReadOnlyList<WuWuTaskPackage> allTaskPackage = ConfigBase<WuWuLogisticsConfig>.Instance.GetAllTaskPackage();
			if (allTaskPackage == null)
			{
				return new ValueTuple<int, int>(num2, num);
			}
			foreach (WuWuTaskPackage wuWuTaskPackage in allTaskPackage)
			{
				if (wuWuTaskPackage.DropId > 0)
				{
					foreach (TItem titem in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(wuWuTaskPackage.DropId))
					{
						if (titem.ItemData.ItemId == 74)
						{
							num += titem.Count;
							WuWuLogisticsActivityData activityData = this.ActivityData;
							WuWuTaskPackData wuWuTaskPackData = (activityData != null) ? activityData.GetTaskPackById(wuWuTaskPackage.Id) : null;
							if (wuWuTaskPackData != null && wuWuTaskPackData.HadReward)
							{
								num2 += titem.Count;
							}
						}
					}
				}
				IReadOnlyList<WuWuWeekTask> weekTaskByWrapId = ConfigBase<WuWuLogisticsConfig>.Instance.GetWeekTaskByWrapId(wuWuTaskPackage.Id);
				if (weekTaskByWrapId != null)
				{
					foreach (WuWuWeekTask wuWuWeekTask in weekTaskByWrapId)
					{
						if (wuWuWeekTask.DropId > 0)
						{
							foreach (TItem titem2 in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(wuWuWeekTask.DropId))
							{
								if (titem2.ItemData.ItemId == 74)
								{
									num += titem2.Count;
									WuWuLogisticsActivityData activityData2 = this.ActivityData;
									WuWuTaskPackData wuWuTaskPackData2 = (activityData2 != null) ? activityData2.GetTaskPackById(wuWuTaskPackage.Id) : null;
									if (wuWuTaskPackData2 != null && wuWuTaskPackData2.HadReward)
									{
										num2 += titem2.Count;
									}
								}
							}
						}
					}
				}
			}
			return new ValueTuple<int, int>(num2, num);
		}

		// Token: 0x04025709 RID: 153353
		private WuWuLogisticsActivityData ActivityDataCache;
	}
}
