using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D81 RID: 28033
	public class LevelConditionOnDangoMonopolyViewShowProcessEnd : LevelConditionBase
	{
		// Token: 0x06044549 RID: 279881 RVA: 0x011C0F78 File Offset: 0x011BF178
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return !(bool)eventArgs[0];
		}
	}
}
