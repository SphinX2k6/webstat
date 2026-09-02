using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE1 RID: 28129
	public class LevelConditionRoleLevel : LevelConditionBase
	{
		// Token: 0x0604461A RID: 280090 RVA: 0x011C3F44 File Offset: 0x011C2144
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
			string limitParams2 = inConditionInfo.GetLimitParams("RoleId");
			int? num = (limitParams2 != null) ? new int?(int.Parse(limitParams2)) : ModelBase<RoleModel>.Instance.GetBattleTeamFirstRoleId();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(num.Value, true);
			if (roleDataById == null)
			{
				return false;
			}
			RoleLevelData levelData = roleDataById.GetLevelData();
			return levelData.GetLevel() != 0 && levelData.GetLevel() >= int.Parse(limitParams);
		}
	}
}
