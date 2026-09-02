using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DF9 RID: 28153
	public class LevelConditionCheckTrapDefenseRogueUnlock : LevelConditionBase
	{
		// Token: 0x0604464D RID: 280141 RVA: 0x011C4A6B File Offset: 0x011C2C6B
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<TrapDefenseModel>.Instance.RougeModeData.CanEnterRougeMode();
		}
	}
}
