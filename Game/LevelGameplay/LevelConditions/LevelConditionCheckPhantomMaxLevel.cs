using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D36 RID: 27958
	public class LevelConditionCheckPhantomMaxLevel : LevelConditionBase
	{
		// Token: 0x060444A9 RID: 279721 RVA: 0x011BDC2C File Offset: 0x011BBE2C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ControllerBase<PhantomBattleController>.Instance.CheckHasPhantomMaxLevel();
		}
	}
}
