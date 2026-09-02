using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D88 RID: 28040
	public class LevelConditionOnViewReadyForGuide : LevelConditionBase
	{
		// Token: 0x06044557 RID: 279895 RVA: 0x011C11DB File Offset: 0x011BF3DB
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return inConditionInfo.GetLimitParams("Tag") == eventArgs[0] as string;
		}
	}
}
