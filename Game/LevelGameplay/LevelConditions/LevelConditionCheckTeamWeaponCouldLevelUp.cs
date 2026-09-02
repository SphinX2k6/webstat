using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D58 RID: 27992
	public class LevelConditionCheckTeamWeaponCouldLevelUp : LevelConditionBase
	{
		// Token: 0x060444F6 RID: 279798 RVA: 0x011BFB1C File Offset: 0x011BDD1C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				int getConfigId = sceneTeamItem.GetConfigId;
				WeaponInstance weaponInstance = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(getConfigId, true) as WeaponInstance;
				if (weaponInstance != null && weaponInstance != null)
				{
					List<ItemDataBase> weaponExpItemList = ModelBase<WeaponModel>.Instance.GetWeaponExpItemList(weaponInstance.GetIncId());
					bool flag = false;
					foreach (ItemDataBase itemDataBase in weaponExpItemList)
					{
						if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemDataBase.GetConfigId(), 0) > 0)
						{
							flag = true;
							break;
						}
					}
					if (flag && weaponInstance.GetLevel() < weaponInstance.GetCurrentMaxLevel())
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
