using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBA RID: 28090
	public class LevelConditionOnChangeBossRushBuff : LevelConditionBase
	{
		// Token: 0x060445BD RID: 279997 RVA: 0x011C2A40 File Offset: 0x011C0C40
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("Tab");
			return limitParams != null && (EUiTabViewName)eventArgs[0] == (EUiTabViewName)limitParams;
		}
	}
}
