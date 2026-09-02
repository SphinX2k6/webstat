using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7A RID: 28026
	public class LevelConditionOnEnterDangoMatchView : LevelConditionBase
	{
		// Token: 0x0604453B RID: 279867 RVA: 0x011C0E25 File Offset: 0x011BF025
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
