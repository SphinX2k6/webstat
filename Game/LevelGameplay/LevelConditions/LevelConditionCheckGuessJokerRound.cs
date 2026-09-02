using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D0D RID: 27917
	public class LevelConditionCheckGuessJokerRound : LevelConditionBase
	{
		// Token: 0x06044450 RID: 279632 RVA: 0x011BC01C File Offset: 0x011BA21C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "LevelConditionCheckExploreSkillFlag配置错误！条件的参数不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num = int.Parse(inConditionInfo.GetLimitParams("Round"));
			int roundNumber = ModelBase<GuessJokerGamePlayModel>.Instance.RoundNumber;
			bool flag = int.Parse(inConditionInfo.GetLimitParams("Tutorial")) == 1;
			bool flag2 = ModelBase<GuessJokerGamePlayModel>.Instance.IsInFirstTutorial();
			return roundNumber == num && flag == flag2;
		}
	}
}
