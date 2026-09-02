using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CD8 RID: 27864
	public class LevelConditionCheckCurWorldLevel : LevelConditionBase
	{
		// Token: 0x060443DC RID: 279516 RVA: 0x011B8DD0 File Offset: 0x011B6FD0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
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
			int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			return curWorldLevel != 0 && curWorldLevel >= int.Parse(limitParams);
		}
	}
}
