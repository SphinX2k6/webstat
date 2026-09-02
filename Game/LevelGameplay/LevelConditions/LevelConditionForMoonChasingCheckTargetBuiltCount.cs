using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D90 RID: 28048
	public class LevelConditionForMoonChasingCheckTargetBuiltCount : LevelConditionBase
	{
		// Token: 0x06044567 RID: 279911 RVA: 0x011C1358 File Offset: 0x011BF558
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("TargetBuiltCount");
			string limitParams2 = inConditionInfo.GetLimitParams("Op");
			if (limitParams == null || limitParams2 == null)
			{
				return false;
			}
			int num = int.Parse(limitParams);
			return base.CheckCompareValue(limitParams2, (double)ModelBase<MoonChasingBuildingModel>.Instance.GetBuiltBuildingCount(), (double)num);
		}
	}
}
