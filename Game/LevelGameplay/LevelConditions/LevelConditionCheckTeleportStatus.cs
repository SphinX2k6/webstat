using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D5A RID: 27994
	public class LevelConditionCheckTeleportStatus : LevelConditionBase
	{
		// Token: 0x060444FA RID: 279802 RVA: 0x011BFCC4 File Offset: 0x011BDEC4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("TeleportId");
			string limitParams2 = inConditionInfo.GetLimitParams("State");
			if (limitParams == null)
			{
				return false;
			}
			if (((limitParams2 != null) ? int.Parse(limitParams2) : 0) == 1)
			{
				return ModelBase<MapModel>.Instance.CheckTeleportUnlocked(int.Parse(limitParams));
			}
			return !ModelBase<MapModel>.Instance.CheckTeleportUnlocked(int.Parse(limitParams));
		}
	}
}
