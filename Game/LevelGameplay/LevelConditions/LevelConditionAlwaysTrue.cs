using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CB6 RID: 27830
	public class LevelConditionAlwaysTrue : LevelConditionBase
	{
		// Token: 0x0604436E RID: 279406 RVA: 0x011B4373 File Offset: 0x011B2573
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
