using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E03 RID: 28163
	public class LevelConditionVisionIntensifyTabOpen : LevelConditionBase
	{
		// Token: 0x06044661 RID: 280161 RVA: 0x011C4D5E File Offset: 0x011C2F5E
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
