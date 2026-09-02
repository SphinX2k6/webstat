using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DC7 RID: 28103
	public class LevelConditionOnPlayerUseSkill : LevelConditionBase
	{
		// Token: 0x060445D7 RID: 280023 RVA: 0x011C2D6C File Offset: 0x011C0F6C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			long num;
			long.TryParse(inConditionInfo.GetLimitParams("SkillId"), out num);
			long? num2 = (eventArgs[1] != null) ? new long?(Convert.ToInt64(eventArgs[1])) : null;
			long num3 = num;
			long? num4 = num2;
			return num3 == num4.GetValueOrDefault() & num4 != null;
		}
	}
}
