using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DE7 RID: 28135
	public class LevelConditionSelfTagCheck : LevelConditionBase
	{
		// Token: 0x06044629 RID: 280105 RVA: 0x011C43BC File Offset: 0x011C25BC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0 || inTrigger == null)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Tag");
			return limitParams != null && inTrigger.Tags.Contains(FNameUtil.GetDynamicFName(limitParams).Value);
		}
	}
}
