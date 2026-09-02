using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D19 RID: 27929
	public class LevelConditionCheckInstanceState : LevelConditionBase
	{
		// Token: 0x06044467 RID: 279655 RVA: 0x011BC7D4 File Offset: 0x011BA9D4
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("InstanceId");
			if (limitParams == null)
			{
				return false;
			}
			int instanceId = int.Parse(limitParams);
			string limitParams2 = inConditionInfo.GetLimitParams("State");
			int num = (limitParams2 != null) ? int.Parse(limitParams2) : 0;
			if (num != 1)
			{
				return num == 2 && !ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceFinished(instanceId);
			}
			return ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceFinished(instanceId);
		}
	}
}
