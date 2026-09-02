using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D4A RID: 27978
	public class LevelConditionCheckRogueTerm : LevelConditionBase
	{
		// Token: 0x060444D3 RID: 279763 RVA: 0x011BF0E6 File Offset: 0x011BD2E6
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return true;
		}
	}
}
