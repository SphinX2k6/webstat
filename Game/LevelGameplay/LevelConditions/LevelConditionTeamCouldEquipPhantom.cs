using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF0 RID: 28144
	public class LevelConditionTeamCouldEquipPhantom : LevelConditionBase
	{
		// Token: 0x0604463B RID: 280123 RVA: 0x011C4698 File Offset: 0x011C2898
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (ModelBase<PhantomBattleModel>.Instance.GetUnEquipVisionArray().Length == 0)
			{
				return false;
			}
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
			for (int i = 0; i < teamItems.Count; i++)
			{
				SceneTeamItem sceneTeamItem = teamItems[i];
				PhantomRoleEquipmentData battleDataById = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(sceneTeamItem.GetConfigId);
				if (battleDataById != null && battleDataById.CheckHasEmpty())
				{
					return true;
				}
			}
			return false;
		}
	}
}
