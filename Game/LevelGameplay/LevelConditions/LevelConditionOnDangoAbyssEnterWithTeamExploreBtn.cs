using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D75 RID: 28021
	public class LevelConditionOnDangoAbyssEnterWithTeamExploreBtn : LevelConditionBase
	{
		// Token: 0x06044531 RID: 279857 RVA: 0x011C0D5C File Offset: 0x011BEF5C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
