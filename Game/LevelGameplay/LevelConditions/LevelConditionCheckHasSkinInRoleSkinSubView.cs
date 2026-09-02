using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D11 RID: 27921
	public class LevelConditionCheckHasSkinInRoleSkinSubView : LevelConditionBase
	{
		// Token: 0x06044458 RID: 279640 RVA: 0x011BC322 File Offset: 0x011BA522
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return eventArgs.Length >= 1 && (bool)eventArgs[0];
		}
	}
}
