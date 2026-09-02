using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D57 RID: 27991
	public class LevelConditionCheckTeamRoleCouldLevelUp : LevelConditionBase
	{
		// Token: 0x060444F4 RID: 279796 RVA: 0x011BFA4C File Offset: 0x011BDC4C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			ItemInfo[] roleCostExpList = ModelBase<RoleModel>.Instance.GetRoleCostExpList();
			bool flag = false;
			foreach (ItemInfo itemInfo in roleCostExpList)
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemInfo.Id, 0) > 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				int getConfigId = sceneTeamItem.GetConfigId;
				RoleLevelData levelData = ModelBase<RoleModel>.Instance.GetRoleDataById(getConfigId, true).GetLevelData();
				if (levelData.GetLevel() < levelData.GetCurrentMaxLevel())
				{
					return true;
				}
			}
			return false;
		}
	}
}
