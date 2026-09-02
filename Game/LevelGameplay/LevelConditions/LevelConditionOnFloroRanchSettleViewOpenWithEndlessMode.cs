using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8C RID: 28044
	public class LevelConditionOnFloroRanchSettleViewOpenWithEndlessMode : LevelConditionBase
	{
		// Token: 0x0604455F RID: 279903 RVA: 0x011C12B5 File Offset: 0x011BF4B5
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
