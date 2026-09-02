using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D02 RID: 27906
	public class LevelConditionCheckFishingQteBtnHitValidArea : LevelConditionBase
	{
		// Token: 0x06044438 RID: 279608 RVA: 0x011BBA35 File Offset: 0x011B9C35
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
