using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DFD RID: 28157
	public class LevelConditionOnTrapDefenseBuildingDevelopBottomLayoutShow : LevelConditionBase
	{
		// Token: 0x06044655 RID: 280149 RVA: 0x011C4B26 File Offset: 0x011C2D26
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
