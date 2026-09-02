using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE3 RID: 28131
	public class LevelConditionRouletteEquipItemId : LevelConditionBase
	{
		// Token: 0x0604461F RID: 280095 RVA: 0x011C40AC File Offset: 0x011C22AC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num;
			return inConditionInfo.LimitParamsLength != 0 && int.TryParse(inConditionInfo.GetLimitParams("ItemId"), out num) && ModelBase<RouletteModel>.Instance.CurrentEquipItemId == num;
		}
	}
}
