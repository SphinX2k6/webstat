using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D62 RID: 28002
	public class LevelConditionCheckTypeItemPickUp : LevelConditionBase
	{
		// Token: 0x0604450A RID: 279818 RVA: 0x011C01EC File Offset: 0x011BE3EC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Type");
			if (limitParams == null)
			{
				return false;
			}
			int num = int.Parse(limitParams);
			return ConfigBase<ItemConfig>.Instance.GetConfig((int)eventArgs[0]).Value.MainTypeId == num;
		}
	}
}
