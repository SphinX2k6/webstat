using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD3 RID: 28115
	public class LevelConditionOnCardDetailShowWithFactor : LevelConditionBase
	{
		// Token: 0x060445EF RID: 280047 RVA: 0x011C30BA File Offset: 0x011C12BA
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
