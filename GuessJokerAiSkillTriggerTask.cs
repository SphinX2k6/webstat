using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020010F1 RID: 4337
public class GuessJokerAiSkillTriggerTask : GuessJokerTaskBase
{
	// Token: 0x060070FC RID: 28924 RVA: 0x001D85AF File Offset: 0x001D67AF
	[NullableContext(1)]
	public GuessJokerAiSkillTriggerTask(JokerGuessSkillTriggerAction data)
	{
		this.SkillId = data.JokerSkillId;
		this.SkillRemindCount = data.RemainingSkillNum;
	}

	// Token: 0x060070FD RID: 28925 RVA: 0x001D85D0 File Offset: 0x001D67D0
	protected override void OnExecute()
	{
		GuessJokerAiSkillTriggerTask.<>c__DisplayClass5_0 CS$<>8__locals1 = new GuessJokerAiSkillTriggerTask.<>c__DisplayClass5_0();
		CS$<>8__locals1.<>4__this = this;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GuessJokerCard;
		ELogAuthor author = ELogAuthor.LRC;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Ai技能触发：");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillId);
		defaultInterpolatedStringHandler.AppendLiteral(" 剩余次数：");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillRemindCount);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		List<GuessJokerActionBase> list = new List<GuessJokerActionBase>();
		GuessJokerAiSkillTriggerTask.<>c__DisplayClass5_0 CS$<>8__locals2 = CS$<>8__locals1;
		GuessJokerGamePlayModel instance2 = ModelBase<GuessJokerGamePlayModel>.Instance;
		CS$<>8__locals2.gamePlayView = ((instance2 != null) ? instance2.GetGamePlayView() : null);
		if (CS$<>8__locals1.gamePlayView == null)
		{
			base.FinishTask();
			return;
		}
		CS$<>8__locals1.gamePlayView.UpdateCurrentPlayer(EGuessJokerPlayerType.Ai);
		if (this.SkillId == 120801 || this.SkillId == 151001)
		{
			list.Add(new GuessJokerRoundStartTipAction(EGuessJokerPlayerType.Ai));
		}
		if (ModelBase<GuessJokerGamePlayModel>.Instance.ShouldPlaySkillEffect(this.SkillId))
		{
			list.Add(new GuessJokerCallbackAction(delegate()
			{
				CS$<>8__locals1.<>4__this.IsStartCountDown = true;
				CS$<>8__locals1.<>4__this.FinishTime = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerAiSkillConsiderTime.ToString());
				CS$<>8__locals1.gamePlayView.SetSkillProgress(EGuessJokerPlayerType.Ai, 0f);
				CS$<>8__locals1.gamePlayView.ShowAiSkillProgress(true);
				CS$<>8__locals1.gamePlayView.SetPositionPanelCardsDark(ECardPositionType.PlayerHand, true, null);
			}));
			ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
			{
				new GuessJokerPlotAction(EGuessJokerPlayerType.Ai, EGuessJokerPlotTiming.TriggerSkill, null)
			});
		}
		if (list.Count > 0)
		{
			if (!ModelBase<GuessJokerGamePlayModel>.Instance.ShouldPlaySkillEffect(this.SkillId))
			{
				list.Add(new GuessJokerCallbackAction(new Action(base.FinishTask)));
			}
			ModelBase<GuessJokerGamePlayModel>.Instance.PushActions(list);
			return;
		}
		base.FinishTask();
	}

	// Token: 0x060070FE RID: 28926 RVA: 0x001D8738 File Offset: 0x001D6938
	protected override void OnTick(float deltaTime)
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		GuessJokerGamePlayView guessJokerGamePlayView = (instance != null) ? instance.GetGamePlayView() : null;
		if (guessJokerGamePlayView == null || this.FinishTime <= 0f || !this.IsStartCountDown)
		{
			return;
		}
		this.ThinkTime += deltaTime;
		float progress = this.ThinkTime / this.FinishTime;
		guessJokerGamePlayView.SetSkillProgress(EGuessJokerPlayerType.Ai, progress);
	}

	// Token: 0x060070FF RID: 28927 RVA: 0x001D8794 File Offset: 0x001D6994
	protected override void OnComplete()
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		GuessJokerGamePlayView guessJokerGamePlayView = (instance != null) ? instance.GetGamePlayView() : null;
		if (guessJokerGamePlayView != null)
		{
			guessJokerGamePlayView.ShowAiSkillProgress(false);
			guessJokerGamePlayView.SetPositionPanelCardsDark(ECardPositionType.PlayerHand, false, null);
		}
	}

	// Token: 0x04003655 RID: 13909
	private readonly int SkillId;

	// Token: 0x04003656 RID: 13910
	private readonly int SkillRemindCount;

	// Token: 0x04003657 RID: 13911
	private bool IsStartCountDown;

	// Token: 0x04003658 RID: 13912
	private float ThinkTime;
}
