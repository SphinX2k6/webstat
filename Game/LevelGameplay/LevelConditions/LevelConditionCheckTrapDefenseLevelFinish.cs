using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF8 RID: 28152
	public class LevelConditionCheckTrapDefenseLevelFinish : LevelConditionBase
	{
		// Token: 0x0604464B RID: 280139 RVA: 0x011C49AC File Offset: 0x011C2BAC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			if (!int.TryParse(inConditionInfo.GetLimitParams("TargetLevelId"), out num) || num == 0)
			{
				return false;
			}
			bool flag = false;
			List<TrapDefenseLevelData> levelDataList = ModelBase<TrapDefenseModel>.Instance.LevelModeData.LevelDataList;
			for (int i = 0; i < levelDataList.Count; i++)
			{
				TrapDefenseLevelData trapDefenseLevelData = levelDataList[i];
				if (trapDefenseLevelData.Id == num)
				{
					flag = trapDefenseLevelData.IsPassed;
					break;
				}
			}
			bool flag2 = false;
			List<TrapDefenseLevelData> levelDataList2 = ModelBase<TrapDefenseModel>.Instance.RougeModeData.LevelDataList;
			for (int j = 0; j < levelDataList2.Count; j++)
			{
				TrapDefenseLevelData trapDefenseLevelData2 = levelDataList2[j];
				if (trapDefenseLevelData2.Id == num)
				{
					flag2 = trapDefenseLevelData2.IsPassed;
					break;
				}
			}
			return flag || flag2;
		}
	}
}
