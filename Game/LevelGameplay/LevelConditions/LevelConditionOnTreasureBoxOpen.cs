using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCE RID: 28110
	public class LevelConditionOnTreasureBoxOpen : LevelConditionBase
	{
		// Token: 0x060445E5 RID: 280037 RVA: 0x011C2FDF File Offset: 0x011C11DF
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
