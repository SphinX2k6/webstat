using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CD6 RID: 27862
	public class LevelConditionCheckComboTeachingState : LevelConditionBase
	{
		// Token: 0x060443D8 RID: 279512 RVA: 0x011B8D2B File Offset: 0x011B6F2B
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<ComboTeachingModel>.Instance.IsClose;
		}
	}
}
