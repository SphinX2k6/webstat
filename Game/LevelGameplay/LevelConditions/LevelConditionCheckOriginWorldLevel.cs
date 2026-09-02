using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D34 RID: 27956
	public class LevelConditionCheckOriginWorldLevel : LevelConditionBase
	{
		// Token: 0x060444A5 RID: 279717 RVA: 0x011BDB7C File Offset: 0x011BBD7C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Level");
			if (limitParams == null)
			{
				return false;
			}
			int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
			return originWorldLevel != 0 && originWorldLevel >= int.Parse(limitParams);
		}
	}
}
