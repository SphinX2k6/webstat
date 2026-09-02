using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E00 RID: 28160
	public class LevelConditionOnTrapDefenseMainLevelViewOpen : LevelConditionBase
	{
		// Token: 0x0604465B RID: 280155 RVA: 0x011C4CA7 File Offset: 0x011C2EA7
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
