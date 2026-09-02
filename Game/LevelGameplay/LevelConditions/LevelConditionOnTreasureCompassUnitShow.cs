using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCF RID: 28111
	public class LevelConditionOnTreasureCompassUnitShow : LevelConditionBase
	{
		// Token: 0x060445E7 RID: 280039 RVA: 0x011C2FEA File Offset: 0x011C11EA
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return eventArgs.Length == 1 && eventArgs[0] is bool && (bool)eventArgs[0];
		}
	}
}
