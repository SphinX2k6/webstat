using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8B RID: 28043
	public class LevelConditionCheckFloroRanchHasTechCanUnlock : LevelConditionBase
	{
		// Token: 0x0604455D RID: 279901 RVA: 0x011C1288 File Offset: 0x011BF488
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
			return activityData != null && activityData.HasAnyTechPointCanUnlock();
		}
	}
}
