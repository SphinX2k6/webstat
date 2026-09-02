using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D03 RID: 27907
	public class LevelConditionCheckFishingRoleTechViewOpen : LevelConditionBase
	{
		// Token: 0x0604443A RID: 279610 RVA: 0x011BBA47 File Offset: 0x011B9C47
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
