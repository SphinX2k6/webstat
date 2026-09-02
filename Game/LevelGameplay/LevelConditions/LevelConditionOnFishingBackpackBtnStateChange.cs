using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBD RID: 28093
	public class LevelConditionOnFishingBackpackBtnStateChange : LevelConditionBase
	{
		// Token: 0x060445C3 RID: 280003 RVA: 0x011C2AD1 File Offset: 0x011C0CD1
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return eventArgs.Length == 1 && eventArgs[0] is bool && (bool)eventArgs[0];
		}
	}
}
