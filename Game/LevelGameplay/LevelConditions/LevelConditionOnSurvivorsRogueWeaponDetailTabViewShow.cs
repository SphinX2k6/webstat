using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DEE RID: 28142
	public class LevelConditionOnSurvivorsRogueWeaponDetailTabViewShow : LevelConditionBase
	{
		// Token: 0x06044637 RID: 280119 RVA: 0x011C451E File Offset: 0x011C271E
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
