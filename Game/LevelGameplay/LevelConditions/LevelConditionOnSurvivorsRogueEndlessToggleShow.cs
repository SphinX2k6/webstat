using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE9 RID: 28137
	public class LevelConditionOnSurvivorsRogueEndlessToggleShow : LevelConditionBase
	{
		// Token: 0x0604462D RID: 280109 RVA: 0x011C4415 File Offset: 0x011C2615
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
