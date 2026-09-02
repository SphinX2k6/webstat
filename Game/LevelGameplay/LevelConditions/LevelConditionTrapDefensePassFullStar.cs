using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E01 RID: 28161
	public class LevelConditionTrapDefensePassFullStar : LevelConditionBase
	{
		// Token: 0x0604465D RID: 280157 RVA: 0x011C4CBC File Offset: 0x011C2EBC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int key;
			int.TryParse(inConditionInfo.GetLimitParams("ChallengeId"), out key);
			TrapDefenseLevelData trapDefenseLevelData;
			return ModelBase<TrapDefenseModel>.Instance.LevelDataFromIdMap.TryGetValue(key, out trapDefenseLevelData) && trapDefenseLevelData.IsFullStarPassed();
		}
	}
}
