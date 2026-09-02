using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PermanentRogue;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB3 RID: 28083
	public class LevelConditionCheckMovieRogueFinishedEndingCount : LevelConditionBase
	{
		// Token: 0x060445AF RID: 279983 RVA: 0x011C28DC File Offset: 0x011C0ADC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			int newSeasonId = ModelBase<ActivityPermanentRogueModel>.Instance.GetNewSeasonId();
			string limitParams = inConditionInfo.GetLimitParams("TargetCount");
			int num = (limitParams != null) ? int.Parse(limitParams) : 0;
			return ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingCount(newSeasonId)[0] >= num;
		}
	}
}
