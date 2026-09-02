using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DAE RID: 28078
	public class LevelConditionOnMoraleTempExpItemShow : LevelConditionBase
	{
		// Token: 0x060445A5 RID: 279973 RVA: 0x011C2714 File Offset: 0x011C0914
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
