using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D6B RID: 28011
	public class LevelConditionOnCiacconaAvgInspirationChoiceShow : LevelConditionBase
	{
		// Token: 0x0604451C RID: 279836 RVA: 0x011C0504 File Offset: 0x011BE704
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
