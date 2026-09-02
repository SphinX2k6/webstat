using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF3 RID: 28147
	public class LevelConditionTrapDefenseChallengeStar : LevelConditionBase
	{
		// Token: 0x06044641 RID: 280129 RVA: 0x011C4864 File Offset: 0x011C2A64
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int key;
			int.TryParse(inConditionInfo.GetLimitParams("ChallengeId"), out key);
			TrapDefenseLevelData trapDefenseLevelData;
			if (!ModelBase<TrapDefenseModel>.Instance.LevelDataFromIdMap.TryGetValue(key, out trapDefenseLevelData))
			{
				return false;
			}
			int needNum = inConditionInfo.NeedNum;
			return trapDefenseLevelData.ReachTargetIndexList.Count >= needNum;
		}
	}
}
