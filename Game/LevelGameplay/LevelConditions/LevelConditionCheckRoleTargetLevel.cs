using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D4E RID: 27982
	public class LevelConditionCheckRoleTargetLevel : LevelConditionBase
	{
		// Token: 0x060444DB RID: 279771 RVA: 0x011BF230 File Offset: 0x011BD430
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Level");
			int level = (limitParams != null) ? int.Parse(limitParams) : 0;
			return ControllerBase<RoleController>.Instance.CheckRoleTargetLevel(level);
		}
	}
}
