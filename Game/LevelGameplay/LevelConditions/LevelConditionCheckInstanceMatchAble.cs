using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D18 RID: 27928
	public class LevelConditionCheckInstanceMatchAble : LevelConditionBase
	{
		// Token: 0x06044465 RID: 279653 RVA: 0x011BC75C File Offset: 0x011BA95C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("EntranceId");
			if (limitParams == null)
			{
				return false;
			}
			int num = int.Parse(limitParams);
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			int selectInstanceId = instance.SelectInstanceId;
			int entranceId = instance.EntranceId;
			InstanceDungeon? instanceDungeon;
			return num == entranceId && (ConfigInstanceDungeonById.GetConfig(selectInstanceId, true) == null || instanceDungeon.GetValueOrDefault().OnlineType != InstOnlineType.Single);
		}
	}
}
