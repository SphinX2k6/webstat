using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DFE RID: 28158
	public class LevelConditionCheckTrapDefenseTalentUnlock : LevelConditionBase
	{
		// Token: 0x06044657 RID: 280151 RVA: 0x011C4B38 File Offset: 0x011C2D38
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			TrapDefenseTalentTreeNodeData trapDefenseTalentTreeNodeData;
			return int.TryParse(inConditionInfo.GetLimitParams("TalentId"), out num) && num != 0 && ModelBase<TrapDefenseModel>.Instance.TalentTreeData.NodeIdMap.TryGetValue(num, out trapDefenseTalentTreeNodeData) && trapDefenseTalentTreeNodeData.IsUnlock;
		}
	}
}
