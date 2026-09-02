using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D05 RID: 27909
	public class LevelConditionCheckFishingWareHouseItemListLength : LevelConditionBase
	{
		// Token: 0x0604443E RID: 279614 RVA: 0x011BBAD2 File Offset: 0x011B9CD2
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<DockyardModel>.Instance.GetWareHouseDataList().Count > 0;
		}
	}
}
