using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBB RID: 28091
	public class LevelConditionOnCostInsufficient : LevelConditionBase
	{
		// Token: 0x060445BF RID: 279999 RVA: 0x011C2A7A File Offset: 0x011C0C7A
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
