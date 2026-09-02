using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D26 RID: 27942
	public class LevelConditionCheckLevel : LevelConditionBase
	{
		// Token: 0x06044487 RID: 279687 RVA: 0x011BD188 File Offset: 0x011BB388
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Level");
			if (limitParams == null)
			{
				return false;
			}
			int? numberPropById = ModelBase<PlayerInfoModel>.Instance.GetNumberPropById(EPlayerInfoNumber.Level);
			int? num = numberPropById;
			int num2 = 0;
			if (num.GetValueOrDefault() == num2 & num != null)
			{
				return false;
			}
			num = numberPropById;
			num2 = int.Parse(limitParams);
			return num.GetValueOrDefault() >= num2 & num != null;
		}
	}
}
