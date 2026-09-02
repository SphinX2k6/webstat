using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DA7 RID: 28071
	public class LevelConditionIsPlayer : LevelConditionBase
	{
		// Token: 0x06044596 RID: 279958 RVA: 0x011C2408 File Offset: 0x011C0608
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0 || inTrigger == null)
			{
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (inConditionInfo.GetLimitParams("IsPlayer") == "1")
			{
				return baseCharacter == inTrigger;
			}
			return baseCharacter != inTrigger;
		}
	}
}
