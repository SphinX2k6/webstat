using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D1E RID: 27934
	public class LevelConditionCheckIsHasRecommendRecActivity : LevelConditionBase
	{
		// Token: 0x06044473 RID: 279667 RVA: 0x011BCA7D File Offset: 0x011BAC7D
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			return ModelBase<ActivityModel>.Instance.IsHasShowingRecommendRecActivity();
		}
	}
}
