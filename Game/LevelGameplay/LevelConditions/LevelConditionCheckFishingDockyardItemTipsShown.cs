using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CFF RID: 27903
	public class LevelConditionCheckFishingDockyardItemTipsShown : LevelConditionBase
	{
		// Token: 0x06044432 RID: 279602 RVA: 0x011BB93A File Offset: 0x011B9B3A
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
