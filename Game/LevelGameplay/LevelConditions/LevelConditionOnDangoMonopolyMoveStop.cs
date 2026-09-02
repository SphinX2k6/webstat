using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7F RID: 28031
	public class LevelConditionOnDangoMonopolyMoveStop : LevelConditionBase
	{
		// Token: 0x06044545 RID: 279877 RVA: 0x011C0F58 File Offset: 0x011BF158
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return !(bool)eventArgs[0];
		}
	}
}
