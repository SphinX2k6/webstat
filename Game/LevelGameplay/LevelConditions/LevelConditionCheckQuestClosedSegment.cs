using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D44 RID: 27972
	public class LevelConditionCheckQuestClosedSegment : LevelConditionBase
	{
		// Token: 0x060444C7 RID: 279751 RVA: 0x011BEE19 File Offset: 0x011BD019
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<GeneralLogicTreeModel>.Instance.IsInClosedSegmentOccupation();
		}
	}
}
