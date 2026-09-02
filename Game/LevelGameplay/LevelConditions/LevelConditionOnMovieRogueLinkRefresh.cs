using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB4 RID: 28084
	public class LevelConditionOnMovieRogueLinkRefresh : LevelConditionBase
	{
		// Token: 0x060445B1 RID: 279985 RVA: 0x011C2934 File Offset: 0x011C0B34
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return Convert.ToBoolean(eventArgs[0]);
		}
	}
}
