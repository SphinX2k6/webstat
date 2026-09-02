using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D2F RID: 27951
	public class LevelConditionCheckNewbieGuideV2 : LevelConditionBase
	{
		// Token: 0x0604449B RID: 279707 RVA: 0x011BD9FC File Offset: 0x011BBBFC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("CheckValue");
			return limitParams != null && ModelBase<PlayerInfoModel>.Instance.NewbieGuideV2 == (limitParams == "TRUE");
		}
	}
}
