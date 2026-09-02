using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DFF RID: 28159
	public class LevelConditionCheckTrapDefenseMachineLevel : LevelConditionBase
	{
		// Token: 0x06044659 RID: 280153 RVA: 0x011C4B88 File Offset: 0x011C2D88
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("MachineId");
			string limitParams2 = inConditionInfo.GetLimitParams("TargetLevel");
			string limitParams3 = inConditionInfo.GetLimitParams("Op");
			int num;
			int num2;
			if (!int.TryParse(limitParams, out num) || num == 0 || !int.TryParse(limitParams2, out num2) || num2 == 0)
			{
				return false;
			}
			List<List<TrapDefenseBuildingDevelopItemData>> haveList = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetHaveList();
			for (int i = 1; i < haveList.Count; i++)
			{
				List<TrapDefenseBuildingDevelopItemData> list = haveList[i];
				for (int j = 0; j < list.Count; j++)
				{
					TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData = list[j];
					if (trapDefenseBuildingDevelopItemData.Id == num || num == -1)
					{
						int level = trapDefenseBuildingDevelopItemData.GetLevel();
						bool flag;
						if (!(limitParams3 == "="))
						{
							if (!(limitParams3 == ">"))
							{
								flag = (limitParams3 == "<" && level < num2);
							}
							else
							{
								flag = (level > num2);
							}
						}
						else
						{
							flag = (level == num2);
						}
						if (num != -1 || flag)
						{
							return flag;
						}
					}
				}
			}
			return false;
		}
	}
}
