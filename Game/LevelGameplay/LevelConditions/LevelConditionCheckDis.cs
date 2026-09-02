using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CDB RID: 27867
	public class LevelConditionCheckDis : LevelConditionBase
	{
		// Token: 0x060443E3 RID: 279523 RVA: 0x011B90DC File Offset: 0x011B72DC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0 || inTrigger == null)
			{
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("Distance");
			string limitParams2 = inConditionInfo.GetLimitParams("CheckWay");
			if (limitParams == null || limitParams2 == null)
			{
				return false;
			}
			float distanceTo = Global.BaseCharacter.GetDistanceTo(inTrigger);
			if (limitParams2 == "1")
			{
				return float.Parse(limitParams) >= distanceTo;
			}
			if (!(limitParams2 == "2"))
			{
				return limitParams2 == "3" && float.Parse(limitParams) != distanceTo;
			}
			return float.Parse(limitParams) <= distanceTo;
		}
	}
}
