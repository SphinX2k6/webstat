using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE8 RID: 28136
	public class LevelConditionStartShootTarget : LevelConditionBase
	{
		// Token: 0x0604462B RID: 280107 RVA: 0x011C440A File Offset: 0x011C260A
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
