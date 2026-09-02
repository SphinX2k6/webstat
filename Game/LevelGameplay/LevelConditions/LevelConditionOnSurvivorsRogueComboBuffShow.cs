using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DEA RID: 28138
	public class LevelConditionOnSurvivorsRogueComboBuffShow : LevelConditionBase
	{
		// Token: 0x0604462F RID: 280111 RVA: 0x011C4427 File Offset: 0x011C2627
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
