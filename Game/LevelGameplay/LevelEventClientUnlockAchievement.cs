using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A02 RID: 27138
	public class LevelEventClientUnlockAchievement : LevelEventBase
	{
		// Token: 0x060433C4 RID: 275396 RVA: 0x01149949 File Offset: 0x01147B49
		public LevelEventClientUnlockAchievement(int id) : base(id)
		{
		}

		// Token: 0x060433C5 RID: 275397 RVA: 0x01149954 File Offset: 0x01147B54
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int worldOwner = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			if (!(id.GetValueOrDefault() == worldOwner & id != null))
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CH, "[LevelEventClientUnlockAchievement] 副机不跑", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ClientUnlockAchievementSystemItem clientUnlockAchievementSystemItem = inParams as ClientUnlockAchievementSystemItem;
			if (clientUnlockAchievementSystemItem == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "[LevelEventClientUnlockAchievement] 参数不合法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AchievementData achievementData = ModelBase<AchievementModel>.Instance.GetAchievementData(clientUnlockAchievementSystemItem.Id);
			if (achievementData == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.CH, "[LevelEventClientUnlockAchievement] 成就数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (achievementData.GetFinishState() != EAchievementStateEnum.UnFinished)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CH, "[LevelEventClientUnlockAchievement] 成就已解锁", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AchievementFinishRequest achievementFinishRequest = AchievementFinishRequest.Create();
			achievementFinishRequest.Id = clientUnlockAchievementSystemItem.Id;
			Singleton<Net>.Instance.Call<AchievementFinishResponse>(ERequestMessageId.AchievementFinishRequest, achievementFinishRequest, null, 0);
		}
	}
}
