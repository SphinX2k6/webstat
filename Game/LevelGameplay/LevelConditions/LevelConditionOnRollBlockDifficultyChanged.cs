using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC8 RID: 28104
	public class LevelConditionOnRollBlockDifficultyChanged : LevelConditionBase
	{
		// Token: 0x060445D9 RID: 280025 RVA: 0x011C2DC8 File Offset: 0x011C0FC8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("Difficulty");
			int num;
			return limitParams != null && int.TryParse(limitParams, out num) && (int)eventArgs[0] == num;
		}
	}
}
