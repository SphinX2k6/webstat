using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7C RID: 28028
	public class LevelConditionCheckDangoMatchPlayerNumType : LevelConditionBase
	{
		// Token: 0x0604453F RID: 279871 RVA: 0x011C0E88 File Offset: 0x011BF088
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("Type"));
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			if (racingBetsSeasonData == null)
			{
				return false;
			}
			RacingBetsLegMatchData curLegMatchData = racingBetsSeasonData.GetCurLegMatchData();
			if (curLegMatchData == null)
			{
				return false;
			}
			ERacingBetsLegMatchState legMatchState = curLegMatchData.GetLegMatchState();
			return curLegMatchData.GetRacingBetsMainViewActorShowType(legMatchState) == (ERacingBetsMainViewShowType)num;
		}
	}
}
