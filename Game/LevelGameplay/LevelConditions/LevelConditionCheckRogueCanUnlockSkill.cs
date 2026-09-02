using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D49 RID: 27977
	public class LevelConditionCheckRogueCanUnlockSkill : LevelConditionBase
	{
		// Token: 0x060444D1 RID: 279761 RVA: 0x011BF0D2 File Offset: 0x011BD2D2
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<RoguelikeModel>.Instance.CheckHasCanUnlockSkill();
		}
	}
}
