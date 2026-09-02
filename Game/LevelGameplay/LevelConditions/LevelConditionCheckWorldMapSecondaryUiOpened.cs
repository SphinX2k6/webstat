using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D6A RID: 28010
	public class LevelConditionCheckWorldMapSecondaryUiOpened : LevelConditionBase
	{
		// Token: 0x0604451A RID: 279834 RVA: 0x011C04F9 File Offset: 0x011BE6F9
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
