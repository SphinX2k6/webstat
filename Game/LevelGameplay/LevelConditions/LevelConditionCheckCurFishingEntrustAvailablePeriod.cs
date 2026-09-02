using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D00 RID: 27904
	public class LevelConditionCheckCurFishingEntrustAvailablePeriod : LevelConditionBase
	{
		// Token: 0x06044434 RID: 279604 RVA: 0x011BB94C File Offset: 0x011B9B4C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ExceptedPeriod");
			if (limitParams == null)
			{
				return false;
			}
			int currentTraceEntrust = ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust;
			if (currentTraceEntrust == 0)
			{
				return false;
			}
			FishingEntrust? fishingEntrust = ConfigBase<FishingConfig>.Instance.GetFishingEntrust(currentTraceEntrust);
			return limitParams.ToUpper() == (fishingEntrust.Value.IsNight ? "NIGHT" : "DAY");
		}
	}
}
