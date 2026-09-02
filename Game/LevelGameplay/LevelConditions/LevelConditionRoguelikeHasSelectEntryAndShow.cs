using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DDF RID: 28127
	public class LevelConditionRoguelikeHasSelectEntryAndShow : LevelConditionBase
	{
		// Token: 0x06044616 RID: 280086 RVA: 0x011C3E9B File Offset: 0x011C209B
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
