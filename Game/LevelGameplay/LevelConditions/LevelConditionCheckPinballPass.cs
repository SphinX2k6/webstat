using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D38 RID: 27960
	public class LevelConditionCheckPinballPass : LevelConditionBase
	{
		// Token: 0x060444AD RID: 279725 RVA: 0x011BDC58 File Offset: 0x011BBE58
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("LevelId");
			int num;
			return !string.IsNullOrEmpty(limitParams) && int.TryParse(limitParams, out num) && num > 0 && ModelBase<PinballModel>.Instance.ActivityData.IsLevelPassed(num);
		}
	}
}
