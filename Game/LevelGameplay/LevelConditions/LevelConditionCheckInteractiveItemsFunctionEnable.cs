using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D1B RID: 27931
	public class LevelConditionCheckInteractiveItemsFunctionEnable : LevelConditionBase
	{
		// Token: 0x0604446B RID: 279659 RVA: 0x011BC8BC File Offset: 0x011BAABC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("CheckValue");
			return !string.IsNullOrEmpty(limitParams) && limitParams == "TRUE" == ModelBase<InventoryModel>.Instance.GetInteractiveItemsFunctionEnable();
		}
	}
}
