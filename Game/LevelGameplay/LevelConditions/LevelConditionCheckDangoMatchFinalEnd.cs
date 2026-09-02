using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D7D RID: 28029
	public class LevelConditionCheckDangoMatchFinalEnd : LevelConditionBase
	{
		// Token: 0x06044541 RID: 279873 RVA: 0x011C0EE8 File Offset: 0x011BF0E8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
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
			bool flag = ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(curLegMatchData.Id);
			bool flag2 = curLegMatchData.GetLegMatchState() == ERacingBetsLegMatchState.EndOfMatch;
			return flag && flag2;
		}
	}
}
