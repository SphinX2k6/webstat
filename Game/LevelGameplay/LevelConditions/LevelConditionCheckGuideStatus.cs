using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Guide.GroupInfo;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D0E RID: 27918
	public class LevelConditionCheckGuideStatus : LevelConditionBase
	{
		// Token: 0x06044452 RID: 279634 RVA: 0x011BC0B4 File Offset: 0x011BA2B4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("GuideGroupId");
			string limitParams2 = inConditionInfo.GetLimitParams("Status");
			string text = inConditionInfo.GetLimitParamsOpe("Status");
			if (limitParams == null || limitParams2 == null)
			{
				return false;
			}
			if (text == null)
			{
				text = "";
			}
			return ModelBase<GuideModel>.Instance.CheckGroupStatus(int.Parse(limitParams), (EGuideGroupState)int.Parse(limitParams2), text);
		}
	}
}
