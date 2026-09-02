using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D39 RID: 27961
	public class LevelConditionCheckPinballWeaponCount : LevelConditionBase
	{
		// Token: 0x060444AF RID: 279727 RVA: 0x011BDCB0 File Offset: 0x011BBEB0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Count");
			int num;
			return !string.IsNullOrEmpty(limitParams) && int.TryParse(limitParams, out num) && num >= 0 && ModelBase<PinballModel>.Instance.GetAllWeaponDataList().Count >= num;
		}
	}
}
