using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CE1 RID: 27873
	public class LevelConditionCheckDungeon : LevelConditionBase
	{
		// Token: 0x060443F0 RID: 279536 RVA: 0x011B9608 File Offset: 0x011B7808
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Id");
			if (limitParams == null)
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			return int.Parse(limitParams) == instanceId;
		}
	}
}
