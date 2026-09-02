using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DEC RID: 28140
	public class LevelConditionCheckSurvivorRogueTalentCanUnlock : LevelConditionBase
	{
		// Token: 0x06044633 RID: 280115 RVA: 0x011C4496 File Offset: 0x011C2696
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
			return activityData != null && activityData.GetTalentTreeRed();
		}
	}
}
