using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E04 RID: 28164
	public class LevelConditionOnWorldMapGravityBtnShow : LevelConditionBase
	{
		// Token: 0x06044663 RID: 280163 RVA: 0x011C4D69 File Offset: 0x011C2F69
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
