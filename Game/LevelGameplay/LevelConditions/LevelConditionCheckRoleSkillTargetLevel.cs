using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D4D RID: 27981
	public class LevelConditionCheckRoleSkillTargetLevel : LevelConditionBase
	{
		// Token: 0x060444D9 RID: 279769 RVA: 0x011BF1E8 File Offset: 0x011BD3E8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Level");
			int level = (limitParams != null) ? int.Parse(limitParams) : 0;
			return ControllerBase<RoleController>.Instance.CheckRoleSkillTargetLevel(level);
		}
	}
}
