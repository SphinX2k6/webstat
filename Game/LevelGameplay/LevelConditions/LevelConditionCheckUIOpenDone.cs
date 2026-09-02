using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D64 RID: 28004
	public class LevelConditionCheckUIOpenDone : LevelConditionBase
	{
		// Token: 0x0604450E RID: 279822 RVA: 0x011C0284 File Offset: 0x011BE484
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs.Length < 1)
			{
				return false;
			}
			EUiViewName name = (EUiViewName)eventArgs[0];
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			return limitParams != null && !(name != limitParams) && Singleton<UiManager>.Instance.IsViewOpen((EUiViewName)limitParams);
		}
	}
}
