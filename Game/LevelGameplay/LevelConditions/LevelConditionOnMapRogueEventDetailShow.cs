using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB6 RID: 28086
	public class LevelConditionOnMapRogueEventDetailShow : LevelConditionBase
	{
		// Token: 0x060445B5 RID: 279989 RVA: 0x011C295B File Offset: 0x011C0B5B
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return Convert.ToBoolean(eventArgs[0]);
		}
	}
}
