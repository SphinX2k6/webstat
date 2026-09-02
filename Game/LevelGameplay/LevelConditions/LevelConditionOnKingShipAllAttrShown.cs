using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DAB RID: 28075
	public class LevelConditionOnKingShipAllAttrShown : LevelConditionBase
	{
		// Token: 0x0604459F RID: 279967 RVA: 0x011C25FB File Offset: 0x011C07FB
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
