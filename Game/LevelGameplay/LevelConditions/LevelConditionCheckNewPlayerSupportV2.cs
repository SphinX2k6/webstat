using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D30 RID: 27952
	public class LevelConditionCheckNewPlayerSupportV2 : LevelConditionBase
	{
		// Token: 0x0604449D RID: 279709 RVA: 0x011BDA48 File Offset: 0x011BBC48
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Has");
			if (limitParams == null)
			{
				return false;
			}
			bool flag = int.Parse(limitParams) == 1;
			return ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.NewPlayerSupportActivityV2).Count > 0 == flag;
		}
	}
}
