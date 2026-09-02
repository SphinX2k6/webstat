using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DBC RID: 28092
	public class LevelConditionOnEnterOrExitBattle : LevelConditionBase
	{
		// Token: 0x060445C1 RID: 280001 RVA: 0x011C2A88 File Offset: 0x011C0C88
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("CheckValue");
			if (limitParams == null)
			{
				return false;
			}
			bool flag = limitParams == "TRUE";
			return (bool)eventArgs[0] == flag;
		}
	}
}
