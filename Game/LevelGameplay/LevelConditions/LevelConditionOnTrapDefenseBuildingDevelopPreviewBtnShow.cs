using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DFB RID: 28155
	public class LevelConditionOnTrapDefenseBuildingDevelopPreviewBtnShow : LevelConditionBase
	{
		// Token: 0x06044651 RID: 280145 RVA: 0x011C4AD7 File Offset: 0x011C2CD7
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return (bool)eventArgs[0];
		}
	}
}
