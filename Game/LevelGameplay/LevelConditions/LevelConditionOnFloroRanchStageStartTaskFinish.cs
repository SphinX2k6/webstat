using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8E RID: 28046
	public class LevelConditionOnFloroRanchStageStartTaskFinish : LevelConditionBase
	{
		// Token: 0x06044563 RID: 279907 RVA: 0x011C1306 File Offset: 0x011BF506
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
