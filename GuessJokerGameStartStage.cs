using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001100 RID: 4352
public class GuessJokerGameStartStage : GuessJokerStageBase
{
	// Token: 0x06007146 RID: 28998 RVA: 0x001D9B4F File Offset: 0x001D7D4F
	[NullableContext(1)]
	public GuessJokerGameStartStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007147 RID: 28999 RVA: 0x001D9B58 File Offset: 0x001D7D58
	protected override void OnEnter()
	{
		int levelId = ModelBase<GuessJokerGamePlayModel>.Instance.GetLevelId();
		GuessJokerLevel? jokerLevelById = ConfigBase<GuessJokerConfig>.Instance.GetJokerLevelById(levelId);
		if (jokerLevelById != null)
		{
			GuessJokerAiConfig? jokerAiConfigByRoleId = ConfigBase<GuessJokerConfig>.Instance.GetJokerAiConfigByRoleId(jokerLevelById.Value.AiRole);
			if (jokerAiConfigByRoleId != null)
			{
				ModelBase<GuessJokerGamePlayModel>.Instance.ShowOnlyGuessJokerNpc(jokerAiConfigByRoleId.Value.NpcId);
			}
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.OpenGamePlayView(delegate
		{
			ModelBase<GuessJokerGamePlayModel>.Instance.ChangeState(EGuessJokerCardStateType.DealCards);
		});
	}
}
