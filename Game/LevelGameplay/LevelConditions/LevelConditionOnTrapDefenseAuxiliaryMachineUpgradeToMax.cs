using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF6 RID: 28150
	public class LevelConditionOnTrapDefenseAuxiliaryMachineUpgradeToMax : LevelConditionBase
	{
		// Token: 0x06044647 RID: 280135 RVA: 0x011C4938 File Offset: 0x011C2B38
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData = eventArgs[0] as TrapDefenseBuildingDevelopItemData;
			return trapDefenseBuildingDevelopItemData != null && (trapDefenseBuildingDevelopItemData.GetHasBranch() && trapDefenseBuildingDevelopItemData.GetIsUnlock()) && !trapDefenseBuildingDevelopItemData.IsBuilding;
		}
	}
}
