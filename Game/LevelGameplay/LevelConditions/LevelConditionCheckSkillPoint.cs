using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D52 RID: 27986
	public class LevelConditionCheckSkillPoint : LevelConditionBase
	{
		// Token: 0x060444E3 RID: 279779 RVA: 0x011BF50C File Offset: 0x011BD70C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
