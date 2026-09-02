using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CE7 RID: 27879
	public class LevelConditionCheckEncircleCurrentChallengeId : LevelConditionBase
	{
		// Token: 0x060443FF RID: 279551 RVA: 0x011B9A98 File Offset: 0x011B7C98
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "LevelConditionCheckEncircleCurrentChallengeId配置错误！条件的参数不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("ChallengeId");
			if (limitParams == null)
			{
				return false;
			}
			int num;
			int.TryParse(limitParams, out num);
			return Singleton<EncirclePlayLevelController>.Instance.GetCurrentChallengeId() == num;
		}
	}
}
