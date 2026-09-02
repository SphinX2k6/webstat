using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D9E RID: 28062
	public class LevelConditionPickupInTowerDefenceBattle : LevelConditionBase
	{
		// Token: 0x06044584 RID: 279940 RVA: 0x011C1B00 File Offset: 0x011BFD00
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
