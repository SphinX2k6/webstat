using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC1 RID: 28097
	public class LevelConditionOnGuideTriggerEvent : LevelConditionBase
	{
		// Token: 0x060445CB RID: 280011 RVA: 0x011C2BA8 File Offset: 0x011C0DA8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			if (eventArgs.Length == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Name");
			return (string)eventArgs.GetValueOrDefault(0, null) == limitParams;
		}
	}
}
