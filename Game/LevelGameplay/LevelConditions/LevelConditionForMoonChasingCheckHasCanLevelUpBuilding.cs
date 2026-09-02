using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D91 RID: 28049
	public class LevelConditionForMoonChasingCheckHasCanLevelUpBuilding : LevelConditionBase
	{
		// Token: 0x06044569 RID: 279913 RVA: 0x011C13AC File Offset: 0x011BF5AC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<MoonChasingBuildingModel>.Instance.GetFirstCanLevelUpBuildingId() != null;
		}
	}
}
