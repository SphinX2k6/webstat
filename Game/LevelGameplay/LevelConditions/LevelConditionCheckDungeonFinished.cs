using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CE2 RID: 27874
	public class LevelConditionCheckDungeonFinished : LevelConditionBase
	{
		// Token: 0x060443F2 RID: 279538 RVA: 0x011B9650 File Offset: 0x011B7850
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("InstanceId");
			if (limitParams == null)
			{
				return false;
			}
			string limitParams2 = inConditionInfo.GetLimitParams("Finish");
			if (limitParams == null)
			{
				return false;
			}
			int instanceId = int.Parse(limitParams);
			bool flag = int.Parse(limitParams2) == 1;
			ExchangeRewardModel instance = ModelBase<ExchangeRewardModel>.Instance;
			bool? flag2 = (instance != null) ? new bool?(instance.IsFinishInstance(instanceId)) : null;
			return flag == flag2.GetValueOrDefault() & flag2 != null;
		}
	}
}
