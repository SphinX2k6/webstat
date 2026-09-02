using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D6D RID: 28013
	public class LevelConditionOnCiacconaChapterRestart : LevelConditionBase
	{
		// Token: 0x06044520 RID: 279840 RVA: 0x011C0521 File Offset: 0x011BE721
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
