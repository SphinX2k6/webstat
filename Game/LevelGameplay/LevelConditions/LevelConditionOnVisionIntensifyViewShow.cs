using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CBA RID: 27834
	public class LevelConditionOnVisionIntensifyViewShow : LevelConditionBase
	{
		// Token: 0x06044376 RID: 279414 RVA: 0x011B455F File Offset: 0x011B275F
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
