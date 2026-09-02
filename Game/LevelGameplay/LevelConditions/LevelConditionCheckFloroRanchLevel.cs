using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D8D RID: 28045
	public class LevelConditionCheckFloroRanchLevel : LevelConditionBase
	{
		// Token: 0x06044561 RID: 279905 RVA: 0x011C12C8 File Offset: 0x011BF4C8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("TargetLevel");
			int num;
			return limitParams != null && int.TryParse(limitParams, out num) && ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId == num;
		}
	}
}
