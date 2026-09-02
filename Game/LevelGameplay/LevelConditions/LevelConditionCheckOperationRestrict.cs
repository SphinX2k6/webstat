using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D33 RID: 27955
	public class LevelConditionCheckOperationRestrict : LevelConditionBase
	{
		// Token: 0x060444A3 RID: 279715 RVA: 0x011BDB65 File Offset: 0x011BBD65
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return Singleton<LevelEventLockInputState>.Instance.IsLockInput();
		}
	}
}
