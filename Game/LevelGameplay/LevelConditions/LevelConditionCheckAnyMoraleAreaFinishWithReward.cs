using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DAD RID: 28077
	public class LevelConditionCheckAnyMoraleAreaFinishWithReward : LevelConditionBase
	{
		// Token: 0x060445A3 RID: 279971 RVA: 0x011C26A4 File Offset: 0x011C08A4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			foreach (MoraleAreaData moraleAreaData in ModelBase<MoraleModel>.Instance.AreaDataList)
			{
				if (moraleAreaData.HighDifficultyFlagSomeActive() && moraleAreaData.IsExistBox())
				{
					return true;
				}
			}
			return false;
		}
	}
}
