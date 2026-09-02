using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.MapRogue;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB8 RID: 28088
	public class LevelConditionCheckGridHasExplored : LevelConditionBase
	{
		// Token: 0x060445B9 RID: 279993 RVA: 0x011C2994 File Offset: 0x011C0B94
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("GridIndex");
			int index = (limitParams != null) ? int.Parse(limitParams) : 0;
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			bool? flag;
			if (gameInfo == null)
			{
				flag = null;
			}
			else
			{
				MapGridData mapGridData = gameInfo.MapGrids[index];
				flag = ((mapGridData != null) ? new bool?(mapGridData.IsExplore) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}
	}
}
