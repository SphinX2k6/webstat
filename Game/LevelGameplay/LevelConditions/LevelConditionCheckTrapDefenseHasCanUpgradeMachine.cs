using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF5 RID: 28149
	public class LevelConditionCheckTrapDefenseHasCanUpgradeMachine : LevelConditionBase
	{
		// Token: 0x06044645 RID: 280133 RVA: 0x011C48D8 File Offset: 0x011C2AD8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			List<List<TrapDefenseBuildingDevelopItemData>> haveList = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetHaveList();
			for (int i = 0; i < haveList.Count; i++)
			{
				List<TrapDefenseBuildingDevelopItemData> list = haveList[i];
				int num = 0;
				if (num < list.Count)
				{
					return !list[num].GetIsMaxLevel(false);
				}
			}
			return false;
		}
	}
}
