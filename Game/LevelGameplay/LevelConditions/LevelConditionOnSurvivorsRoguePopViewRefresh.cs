using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DEB RID: 28139
	public class LevelConditionOnSurvivorsRoguePopViewRefresh : LevelConditionBase
	{
		// Token: 0x06044631 RID: 280113 RVA: 0x011C443C File Offset: 0x011C263C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = (int)eventArgs[0];
			int num2 = int.Parse(inConditionInfo.GetLimitParams("Type"));
			int num3 = int.Parse(inConditionInfo.GetLimitParams("LevelId"));
			int curLevelId = ModelBase<SurvivorsRogueModel>.Instance.CurLevelId;
			return num == num2 && (num3 == 0 || num3 == curLevelId);
		}
	}
}
