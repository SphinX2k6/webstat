using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D79 RID: 28025
	public class LevelConditionCheckDangoAbyssProgress : LevelConditionBase
	{
		// Token: 0x06044539 RID: 279865 RVA: 0x011C0DD4 File Offset: 0x011BEFD4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("Progress");
			int num;
			if (limitParams == null || !int.TryParse(limitParams, out num))
			{
				return false;
			}
			DangoAbyssActivityData currentOpenAbyssActivityData = ModelBase<DangoAbyssModel>.Instance.GetCurrentOpenAbyssActivityData();
			return ((currentOpenAbyssActivityData != null) ? currentOpenAbyssActivityData.GetCanChallengeIdList().Length : 0) >= num + 1;
		}
	}
}
