using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D2B RID: 27947
	public class LevelConditionCheckMapFocusByQuestId : LevelConditionBase
	{
		// Token: 0x06044491 RID: 279697 RVA: 0x011BD4E4 File Offset: 0x011BB6E4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			if (eventArgs.Length < 1)
			{
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("QuestId"));
			int num2 = (int)eventArgs[0];
			return num == num2;
		}
	}
}
