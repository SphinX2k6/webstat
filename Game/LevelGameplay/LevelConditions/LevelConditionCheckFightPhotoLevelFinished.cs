using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D86 RID: 28038
	public class LevelConditionCheckFightPhotoLevelFinished : LevelConditionBase
	{
		// Token: 0x06044553 RID: 279891 RVA: 0x011C10F0 File Offset: 0x011BF2F0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("LevelId");
			int num;
			if (limitParams == null || !int.TryParse(limitParams, out num))
			{
				num = 0;
			}
			FightPhotoActivityData activityData = ControllerBase<FightPhotoController>.Instance.GetActivityData();
			if (activityData == null)
			{
				return false;
			}
			foreach (FightPhotoLevelGroupData fightPhotoLevelGroupData in activityData.GetLevelGroupDataList())
			{
				foreach (FightPhotoLevelData fightPhotoLevelData in fightPhotoLevelGroupData.LevelDataList)
				{
					if (fightPhotoLevelData.LevelId == num)
					{
						return fightPhotoLevelData.IsFinished;
					}
				}
			}
			return false;
		}
	}
}
