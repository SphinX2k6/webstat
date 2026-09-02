using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC3 RID: 28099
	public class LevelConditionOnNormalTopViewChange : LevelConditionBase
	{
		// Token: 0x060445CF RID: 280015 RVA: 0x011C2C84 File Offset: 0x011C0E84
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs.Length < 1)
			{
				return false;
			}
			EUiViewName left = (EUiViewName)inConditionInfo.GetLimitParams("UIName");
			EUiViewName right = (EUiViewName)eventArgs[0];
			return left == right;
		}
	}
}
