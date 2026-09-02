using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.MingSu;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D84 RID: 28036
	public class LevelConditionDragonPoolState : LevelConditionBase
	{
		// Token: 0x0604454F RID: 279887 RVA: 0x011C1020 File Offset: 0x011BF220
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("DragonPoolId");
			string limitParams2 = inConditionInfo.GetLimitParams("State");
			return limitParams != null && limitParams2 != null && ModelBase<MingSuModel>.Instance.GetTargetDragonPoolActiveById(int.Parse(limitParams)) == int.Parse(limitParams2);
		}
	}
}
