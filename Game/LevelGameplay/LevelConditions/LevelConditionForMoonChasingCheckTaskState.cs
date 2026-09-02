using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D94 RID: 28052
	public class LevelConditionForMoonChasingCheckTaskState : LevelConditionBase
	{
		// Token: 0x0604456F RID: 279919 RVA: 0x011C14E0 File Offset: 0x011BF6E0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("TargetState");
			string limitParams2 = inConditionInfo.GetLimitParams("TargetCount");
			string limitParams3 = inConditionInfo.GetLimitParams("Op");
			if (limitParams == null || limitParams2 == null || limitParams3 == null)
			{
				return false;
			}
			EEditTeamDataUnLockState eeditTeamDataUnLockState = (EEditTeamDataUnLockState)int.Parse(limitParams);
			int num = int.Parse(limitParams2);
			int num2 = 0;
			using (List<EditTeamData>.Enumerator enumerator = ModelBase<MoonChasingBusinessModel>.Instance.GetHelpEditTeamDataList(false).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetTeamDataUnLockState() == eeditTeamDataUnLockState)
					{
						num2++;
					}
				}
			}
			return base.CheckCompareValue(limitParams3, (double)num2, (double)num);
		}
	}
}
