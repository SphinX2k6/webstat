using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CC6 RID: 27846
	public class LevelConditionCheckCalabashLevel : LevelConditionBase
	{
		// Token: 0x0604439C RID: 279452 RVA: 0x011B747C File Offset: 0x011B567C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Level");
			return limitParams != null && ModelBase<CalabashModel>.Instance.GetCalabashLevel() >= int.Parse(limitParams);
		}
	}
}
