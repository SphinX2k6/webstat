using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D42 RID: 27970
	public class LevelConditionCheckPositionRolePhantomSkillEquip : LevelConditionBase
	{
		// Token: 0x060444C3 RID: 279747 RVA: 0x011BED78 File Offset: 0x011BCF78
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = int.Parse(inConditionInfo.GetLimitParams("Pos"));
			SceneTeamItem sceneTeamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true)[num - 1];
			return sceneTeamItem != null && sceneTeamItem.IsMyRole() && ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(sceneTeamItem.GetConfigId, num - 1) != 0;
		}
	}
}
