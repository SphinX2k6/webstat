using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D01 RID: 27905
	public class LevelConditionCheckFishingEntrustState : LevelConditionBase
	{
		// Token: 0x06044436 RID: 279606 RVA: 0x011BB9B8 File Offset: 0x011B9BB8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("EntrustId");
			string limitParams2 = inConditionInfo.GetLimitParams("EntrustState");
			int key;
			int num;
			if (!int.TryParse(limitParams, out key) || !int.TryParse(limitParams2, out num))
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelCondition, ELogAuthor.HYF, "CheckFishingEntrustState条件参数错误, 无法解析为数值", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			EFishingEntrustState efishingEntrustState;
			if (!ModelBase<FishingQuestModel>.Instance.CurrentEntrusts.TryGetValue(key, out efishingEntrustState))
			{
				return num == -1;
			}
			return efishingEntrustState == (EFishingEntrustState)num;
		}

		// Token: 0x040260E8 RID: 155880
		private const int NONE_OR_FINISHED = -1;
	}
}
