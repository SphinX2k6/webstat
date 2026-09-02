using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7B RID: 28027
	public class LevelConditionCheckDangoMatchState : LevelConditionBase
	{
		// Token: 0x0604453D RID: 279869 RVA: 0x011C0E30 File Offset: 0x011BF030
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("State"));
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			if (racingBetsSeasonData == null)
			{
				return false;
			}
			RacingBetsLegMatchData curLegMatchData = racingBetsSeasonData.GetCurLegMatchData();
			return curLegMatchData != null && curLegMatchData.GetLegMatchState() == (ERacingBetsLegMatchState)num;
		}
	}
}
