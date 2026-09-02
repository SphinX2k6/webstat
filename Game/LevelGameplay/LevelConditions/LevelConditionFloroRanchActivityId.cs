using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8F RID: 28047
	public class LevelConditionFloroRanchActivityId : LevelConditionBase
	{
		// Token: 0x06044565 RID: 279909 RVA: 0x011C1318 File Offset: 0x011BF518
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ActivityID");
			int num;
			return limitParams != null && int.TryParse(limitParams, out num) && num == ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId;
		}
	}
}
