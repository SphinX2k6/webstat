using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D83 RID: 28035
	public class LevelConditionDistanceLess : LevelConditionBase
	{
		// Token: 0x0604454D RID: 279885 RVA: 0x011C0F98 File Offset: 0x011BF198
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("StartTarget");
			string limitParams2 = inConditionInfo.GetLimitParams("EndTargetTag");
			string limitParams3 = inConditionInfo.GetLimitParams("Distance");
			if (limitParams == null || limitParams2 == null)
			{
				return false;
			}
			AActor aactor = inTrigger;
			if (limitParams != "Trigger")
			{
				aactor = LevelGeneralCommons.FindTargetWithTag(limitParams);
			}
			if (aactor == null)
			{
				return false;
			}
			AActor aactor2 = LevelGeneralCommons.FindTargetWithTag(limitParams2);
			return aactor2 != null && aactor.GetDistanceTo(aactor2) < float.Parse(limitParams3);
		}
	}
}
