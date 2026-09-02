using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DED RID: 28141
	public class LevelConditionCheckSurvivorRogueHasWeaponBond : LevelConditionBase
	{
		// Token: 0x06044635 RID: 280117 RVA: 0x011C44B8 File Offset: 0x011C26B8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			List<ISurvivorsWeaponGridData> weaponGridDataList = ModelBase<SurvivorsRogueModel>.Instance.GainData.GetWeaponGridDataList(null, null);
			for (int i = 0; i < weaponGridDataList.Count; i++)
			{
				int? bondPosition = weaponGridDataList[i].BondPosition;
				int num = 0;
				if (!(bondPosition.GetValueOrDefault() == num & bondPosition != null))
				{
					return true;
				}
			}
			return false;
		}
	}
}
