using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CDC RID: 27868
	public class LevelConditionCheckDockyardWareHouseHasItem : LevelConditionBase
	{
		// Token: 0x060443E5 RID: 279525 RVA: 0x011B9180 File Offset: 0x011B7380
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			DockyardModel instance = ModelBase<DockyardModel>.Instance;
			return ((instance != null) ? new int?(instance.BackpackUseSize) : null).GetValueOrDefault() > 0;
		}
	}
}
