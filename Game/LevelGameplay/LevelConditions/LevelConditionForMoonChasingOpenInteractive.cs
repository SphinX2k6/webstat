using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D95 RID: 28053
	public class LevelConditionForMoonChasingOpenInteractive : LevelConditionBase
	{
		// Token: 0x06044571 RID: 279921 RVA: 0x011C1598 File Offset: 0x011BF798
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
