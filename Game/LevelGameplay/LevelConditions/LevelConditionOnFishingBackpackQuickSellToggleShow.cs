using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBE RID: 28094
	public class LevelConditionOnFishingBackpackQuickSellToggleShow : LevelConditionBase
	{
		// Token: 0x060445C5 RID: 280005 RVA: 0x011C2AF5 File Offset: 0x011C0CF5
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return eventArgs.Length == 1 && eventArgs[0] is bool && (bool)eventArgs[0];
		}
	}
}
