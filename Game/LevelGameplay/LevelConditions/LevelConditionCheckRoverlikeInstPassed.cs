using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D4F RID: 27983
	public class LevelConditionCheckRoverlikeInstPassed : LevelConditionBase
	{
		// Token: 0x060444DD RID: 279773 RVA: 0x011BF278 File Offset: 0x011BD478
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("InstId");
			if (string.IsNullOrEmpty(limitParams))
			{
				return false;
			}
			string limitParams2 = inConditionInfo.GetLimitParams("Passed");
			if (string.IsNullOrEmpty(limitParams2))
			{
				return false;
			}
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeLevelSelectData roverlikeLevelSelectData;
			if (instance == null)
			{
				roverlikeLevelSelectData = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverlikeLevelSelectData = ((currentActivityData != null) ? currentActivityData.LevelSelectData : null);
			}
			RoverlikeLevelSelectData roverlikeLevelSelectData2 = roverlikeLevelSelectData;
			if (roverlikeLevelSelectData2 == null)
			{
				return false;
			}
			bool flag = int.Parse(limitParams2) == 1;
			return roverlikeLevelSelectData2.IsPassed(int.Parse(limitParams)) == flag;
		}
	}
}
