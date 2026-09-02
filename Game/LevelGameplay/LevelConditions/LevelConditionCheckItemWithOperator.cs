using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D23 RID: 27939
	public class LevelConditionCheckItemWithOperator : LevelConditionBase
	{
		// Token: 0x06044481 RID: 279681 RVA: 0x011BD050 File Offset: 0x011BB250
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("ItemID");
			string limitParams2 = inConditionInfo.GetLimitParams("Count");
			string limitParams3 = inConditionInfo.GetLimitParams("Op");
			if (limitParams == null || limitParams2 == null || limitParams3 == null)
			{
				return false;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(int.Parse(limitParams), 0);
			int num = int.Parse(limitParams2);
			return base.CheckCompareValue(limitParams3, (double)itemCountByConfigId, (double)num);
		}
	}
}
