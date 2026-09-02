using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E02 RID: 28162
	public class LevelConditionTrapDefenseTotalStar : LevelConditionBase
	{
		// Token: 0x0604465F RID: 280159 RVA: 0x011C4D04 File Offset: 0x011C2F04
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = int.Parse(inConditionInfo.GetLimitParams("ActivityId"));
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null || instance.GetActivityId() != num)
			{
				return false;
			}
			int needNum = inConditionInfo.NeedNum;
			return ModelBase<TrapDefenseModel>.Instance.GetAllGetStarByLevel() >= needNum;
		}
	}
}
