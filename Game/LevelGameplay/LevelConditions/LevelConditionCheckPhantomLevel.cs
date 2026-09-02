using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D35 RID: 27957
	public class LevelConditionCheckPhantomLevel : LevelConditionBase
	{
		// Token: 0x060444A7 RID: 279719 RVA: 0x011BDBCC File Offset: 0x011BBDCC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("ItemId");
			string limitParams2 = inConditionInfo.GetLimitParams("Level");
			int itemId = (limitParams != null) ? int.Parse(limitParams) : 0;
			int level = (limitParams2 != null) ? int.Parse(limitParams2) : 0;
			return ControllerBase<PhantomBattleController>.Instance.CheckPhantomLevelSatisfied(itemId, level);
		}
	}
}
