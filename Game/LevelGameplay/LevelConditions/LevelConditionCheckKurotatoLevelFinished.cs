using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Kurotato.Data;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D24 RID: 27940
	public class LevelConditionCheckKurotatoLevelFinished : LevelConditionBase
	{
		// Token: 0x06044483 RID: 279683 RVA: 0x011BD0C8 File Offset: 0x011BB2C8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("LevelId");
			if (limitParams == null)
			{
				return false;
			}
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			KurotatoActivityData kurotatoActivityData = (instance != null) ? instance.GetActivityData() : null;
			return kurotatoActivityData != null && kurotatoActivityData.IsLevelFinished(int.Parse(limitParams));
		}
	}
}
