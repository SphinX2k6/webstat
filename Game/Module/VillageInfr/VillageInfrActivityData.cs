using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C02 RID: 19458
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrActivityData : ActivityBaseData
	{
		// Token: 0x06032C78 RID: 207992 RVA: 0x00CB8A4F File Offset: 0x00CB6C4F
		protected override void OnInit(ActivityData data)
		{
		}

		// Token: 0x06032C79 RID: 207993 RVA: 0x00CB8A51 File Offset: 0x00CB6C51
		protected override void PhraseEx(ActivityData data)
		{
		}

		// Token: 0x06032C7A RID: 207994 RVA: 0x00CB8A53 File Offset: 0x00CB6C53
		public override bool GetExDataRedPointShowState()
		{
			return this.CheckRedDot();
		}

		// Token: 0x06032C7B RID: 207995 RVA: 0x00CB8A5C File Offset: 0x00CB6C5C
		public bool CheckRedDot()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
			return instance.HasTreeCanLevelUp() || instance.GetCanVillageLevelUp() || instance.HasScoreReward() || instance.GetTaskRedDot();
		}

		// Token: 0x06032C7C RID: 207996 RVA: 0x00CB8A9C File Offset: 0x00CB6C9C
		protected override bool GetExDataFinishShowState()
		{
			VillageInfrModel instance = ModelBase<VillageInfrModel>.Instance;
			VillageInfrConfig instance2 = ConfigBase<VillageInfrConfig>.Instance;
			bool flag = false;
			using (List<IVillageInfrTreeData>.Enumerator enumerator = instance.GetAllTreeData().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != InfrV2StatusPb.InfrV2StatusComplete)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				return false;
			}
			if (instance.GetVillageLevel() < instance2.GetInfrMaxLevel())
			{
				return false;
			}
			bool flag2 = false;
			foreach (InfrV2ScoreReward infrV2ScoreReward in instance2.GetScoreReward())
			{
				if (!instance.IsScoreRewardReceived(infrV2ScoreReward.Id))
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				return false;
			}
			bool flag3 = false;
			using (List<VillageInfrLimitTaskData>.Enumerator enumerator3 = instance.GetActivityTaskDataList().GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					if (enumerator3.Current.Status != ConditionTaskState.ConditionTaskTaken)
					{
						flag3 = true;
						break;
					}
				}
			}
			return !flag3;
		}

		// Token: 0x06032C7D RID: 207997 RVA: 0x00CB8BC0 File Offset: 0x00CB6DC0
		public override ERedDotName? GetExternalButtonRedPointName()
		{
			return new ERedDotName?(ERedDotName.VillageInfr);
		}
	}
}
