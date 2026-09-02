using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D4C RID: 27980
	public class LevelConditionCheckRoleOwned : LevelConditionBase
	{
		// Token: 0x060444D7 RID: 279767 RVA: 0x011BF184 File Offset: 0x011BD384
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Owned");
			if (limitParams == null)
			{
				return false;
			}
			string limitParams2 = inConditionInfo.GetLimitParams("RoleId");
			if (limitParams2 == null)
			{
				return false;
			}
			int roleId = int.Parse(limitParams2);
			bool flag = int.Parse(limitParams) == 1;
			return ModelBase<RoleModel>.Instance.IsRoleOwned(roleId) == flag;
		}
	}
}
