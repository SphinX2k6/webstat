using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D12 RID: 27922
	public class LevelConditionCheckHasUnlockAffixInBossRush : LevelConditionBase
	{
		// Token: 0x0604445A RID: 279642 RVA: 0x011BC33C File Offset: 0x011BA53C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("ActivityId"));
			return num != 0 && (ModelBase<ActivityModel>.Instance.GetActivityById(num) as BossRushData).GetUnlockedBuffIndices().Length > 1;
		}
	}
}
