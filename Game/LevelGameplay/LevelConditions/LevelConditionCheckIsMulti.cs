using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D20 RID: 27936
	public class LevelConditionCheckIsMulti : LevelConditionBase
	{
		// Token: 0x06044477 RID: 279671 RVA: 0x011BCAD0 File Offset: 0x011BACD0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<GameModeModel>.Instance.IsMulti;
		}
	}
}
