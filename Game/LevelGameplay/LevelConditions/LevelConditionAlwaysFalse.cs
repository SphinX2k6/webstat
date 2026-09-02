using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB5 RID: 27829
	public class LevelConditionAlwaysFalse : LevelConditionBase
	{
		// Token: 0x0604436C RID: 279404 RVA: 0x011B4368 File Offset: 0x011B2568
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			return false;
		}
	}
}
