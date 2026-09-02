using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CBE RID: 27838
	public class LevelConditionCheckActivityOpen : LevelConditionBase
	{
		// Token: 0x0604438C RID: 279436 RVA: 0x011B6B34 File Offset: 0x011B4D34
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("ActivityId");
			if (limitParams == null)
			{
				return false;
			}
			int id = int.Parse(limitParams);
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(id);
			return activityById != null && !activityById.CheckIfClose();
		}
	}
}
