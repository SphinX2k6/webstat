using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D63 RID: 28003
	public class LevelConditionCheckUIOpen : LevelConditionBase
	{
		// Token: 0x0604450C RID: 279820 RVA: 0x011C024C File Offset: 0x011BE44C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			return limitParams != null && Singleton<UiManager>.Instance.IsViewOpen((EUiViewName)limitParams);
		}
	}
}
