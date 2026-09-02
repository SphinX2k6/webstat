using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D69 RID: 28009
	public class LevelConditionCheckWeeklyChallenge : LevelConditionBase
	{
		// Token: 0x06044518 RID: 279832 RVA: 0x011C04CF File Offset: 0x011BE6CF
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.WeeklyChallenge) && ModelBase<WeeklyChallengeModel>.Instance.WeeklyConfigId != 0;
		}
	}
}
