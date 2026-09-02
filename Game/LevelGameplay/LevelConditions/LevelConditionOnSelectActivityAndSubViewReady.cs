using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCA RID: 28106
	public class LevelConditionOnSelectActivityAndSubViewReady : LevelConditionBase
	{
		// Token: 0x060445DD RID: 280029 RVA: 0x011C2E90 File Offset: 0x011C1090
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			return inConditionInfo.LimitParamsLength != 0 && int.TryParse(inConditionInfo.GetLimitParams("ActivityId"), out num) && num != 0 && (int)eventArgs[0] == num;
		}
	}
}
