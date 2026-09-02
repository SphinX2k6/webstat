using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DD1 RID: 28113
	public class LevelConditionOnViewClose : LevelConditionBase
	{
		// Token: 0x060445EB RID: 280043 RVA: 0x011C3068 File Offset: 0x011C1268
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			string b = (eventArgs.Length != 0) ? ((EUiViewName)eventArgs[0]) : string.Empty;
			return limitParams == b;
		}
	}
}
