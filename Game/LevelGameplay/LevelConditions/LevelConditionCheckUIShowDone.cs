using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D65 RID: 28005
	public class LevelConditionCheckUIShowDone : LevelConditionBase
	{
		// Token: 0x06044510 RID: 279824 RVA: 0x011C02DC File Offset: 0x011BE4DC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs.Length < 1)
			{
				return false;
			}
			EUiViewName name = (EUiViewName)eventArgs[0];
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			return limitParams != null && !(name != limitParams);
		}
	}
}
