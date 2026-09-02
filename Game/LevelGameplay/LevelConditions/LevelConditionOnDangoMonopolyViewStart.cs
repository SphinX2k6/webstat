using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D80 RID: 28032
	public class LevelConditionOnDangoMonopolyViewStart : LevelConditionBase
	{
		// Token: 0x06044547 RID: 279879 RVA: 0x011C0F6D File Offset: 0x011BF16D
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
