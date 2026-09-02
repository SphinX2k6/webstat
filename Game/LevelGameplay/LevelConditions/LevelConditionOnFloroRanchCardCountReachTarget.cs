using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D89 RID: 28041
	public class LevelConditionOnFloroRanchCardCountReachTarget : LevelConditionBase
	{
		// Token: 0x06044559 RID: 279897 RVA: 0x011C1200 File Offset: 0x011BF400
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("TargetCount");
			int num;
			return limitParams != null && int.TryParse(limitParams, out num) && ModelBase<FloroRanchGamePlayModel>.Instance.OwnCardEntityCount >= num;
		}
	}
}
