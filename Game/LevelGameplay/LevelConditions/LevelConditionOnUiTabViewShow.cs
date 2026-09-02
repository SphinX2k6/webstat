using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD0 RID: 28112
	public class LevelConditionOnUiTabViewShow : LevelConditionBase
	{
		// Token: 0x060445E9 RID: 280041 RVA: 0x011C3010 File Offset: 0x011C1210
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			EUiTabViewName? euiTabViewName = eventArgs[0] as EUiTabViewName?;
			string limitParams = inConditionInfo.GetLimitParams("TabViewName");
			return ((euiTabViewName != null) ? euiTabViewName.GetValueOrDefault().ToString() : null) == limitParams;
		}
	}
}
