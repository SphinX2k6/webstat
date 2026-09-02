using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D0F RID: 27919
	public class LevelConditionCheckHasFirstPhantomAtPosition : LevelConditionBase
	{
		// Token: 0x06044454 RID: 279636 RVA: 0x011BC124 File Offset: 0x011BA324
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
			if (int.Parse(inConditionInfo.GetLimitParams("IsFull")) == 1)
			{
				foreach (SceneTeamItem sceneTeamItem in teamItems)
				{
					if (ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(sceneTeamItem.GetConfigId, 0) == 0)
					{
						return false;
					}
				}
				return true;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("Position"));
			bool flag = int.Parse(inConditionInfo.GetLimitParams("Available")) == 1;
			if (num > teamItems.Count)
			{
				return false;
			}
			SceneTeamItem sceneTeamItem2 = teamItems[num - 1];
			return ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(sceneTeamItem2.GetConfigId, 0) != 0 == flag;
		}
	}
}
