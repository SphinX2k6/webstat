using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB5 RID: 28085
	public class LevelConditionOnMovieRogueMapMoveEnd : LevelConditionBase
	{
		// Token: 0x060445B3 RID: 279987 RVA: 0x011C2946 File Offset: 0x011C0B46
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return !Convert.ToBoolean(eventArgs[0]);
		}
	}
}
