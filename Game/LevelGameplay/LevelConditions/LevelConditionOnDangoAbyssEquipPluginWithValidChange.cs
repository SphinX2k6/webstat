using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D77 RID: 28023
	public class LevelConditionOnDangoAbyssEquipPluginWithValidChange : LevelConditionBase
	{
		// Token: 0x06044535 RID: 279861 RVA: 0x011C0DB0 File Offset: 0x011BEFB0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[1];
		}
	}
}
