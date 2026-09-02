using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8A RID: 28042
	public class LevelConditionCheckFloroRanchRound : LevelConditionBase
	{
		// Token: 0x0604455B RID: 279899 RVA: 0x011C1244 File Offset: 0x011BF444
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("Round");
			int num;
			return limitParams != null && int.TryParse(limitParams, out num) && ModelBase<FloroRanchGamePlayModel>.Instance.TotalDayCount >= num;
		}
	}
}
