using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DCB RID: 28107
	public class LevelConditionOnShowPhantomInFormation : LevelConditionBase
	{
		// Token: 0x060445DF RID: 280031 RVA: 0x011C2ED5 File Offset: 0x011C10D5
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
