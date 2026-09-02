using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7E RID: 28030
	public class LevelConditionCheckDangoMonopolyHasFinishedRound : LevelConditionBase
	{
		// Token: 0x06044543 RID: 279875 RVA: 0x011C0F35 File Offset: 0x011BF135
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			ActivityDangoMonopolyData data = ControllerBase<ActivityDangoMonopolyController>.Instance.GetData();
			return ((data != null) ? data.GetFinishedRoundNum() : 0) > 0;
		}
	}
}
