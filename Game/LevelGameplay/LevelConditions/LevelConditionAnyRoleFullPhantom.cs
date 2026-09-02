using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB8 RID: 27832
	public class LevelConditionAnyRoleFullPhantom : LevelConditionBase
	{
		// Token: 0x06044372 RID: 279410 RVA: 0x011B440C File Offset: 0x011B260C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("CheckValue");
			if (limitParams == null)
			{
				return false;
			}
			bool flag = limitParams == "TRUE";
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				PhantomRoleEquipmentData battleDataById = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(sceneTeamItem.GetConfigId);
				if (battleDataById == null || !battleDataById.CheckHasEmpty())
				{
					return flag;
				}
			}
			return !flag;
		}
	}
}
