using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCD RID: 28109
	public class LevelConditionOnTakingPhoto : LevelConditionBase
	{
		// Token: 0x060445E3 RID: 280035 RVA: 0x011C2FD4 File Offset: 0x011C11D4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
