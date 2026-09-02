using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF4 RID: 28148
	public class LevelConditionCheckTrapDefenseTalentCanUnlock : LevelConditionBase
	{
		// Token: 0x06044643 RID: 280131 RVA: 0x011C48BC File Offset: 0x011C2ABC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<TrapDefenseModel>.Instance.TalentTreeData.HasAnyNodeCanUnlockAndAfford();
		}
	}
}
