using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB9 RID: 28089
	public class LevelConditionOnActivitySubViewDone : LevelConditionBase
	{
		// Token: 0x060445BB RID: 279995 RVA: 0x011C2A08 File Offset: 0x011C0C08
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ActivityId");
			return limitParams != null && int.Parse(limitParams) == (int)eventArgs[0];
		}
	}
}
