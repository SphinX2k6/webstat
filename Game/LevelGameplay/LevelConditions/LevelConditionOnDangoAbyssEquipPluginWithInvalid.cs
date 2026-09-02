using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D78 RID: 28024
	public class LevelConditionOnDangoAbyssEquipPluginWithInvalid : LevelConditionBase
	{
		// Token: 0x06044537 RID: 279863 RVA: 0x011C0DC2 File Offset: 0x011BEFC2
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
