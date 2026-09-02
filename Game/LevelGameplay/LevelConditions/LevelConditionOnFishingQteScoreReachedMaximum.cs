using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBF RID: 28095
	public class LevelConditionOnFishingQteScoreReachedMaximum : LevelConditionBase
	{
		// Token: 0x060445C7 RID: 280007 RVA: 0x011C2B19 File Offset: 0x011C0D19
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
