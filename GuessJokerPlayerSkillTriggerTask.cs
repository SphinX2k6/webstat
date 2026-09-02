using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020010F4 RID: 4340
public class GuessJokerPlayerSkillTriggerTask : GuessJokerTaskBase
{
	// Token: 0x0600710A RID: 28938 RVA: 0x001D8D84 File Offset: 0x001D6F84
	[NullableContext(1)]
	public GuessJokerPlayerSkillTriggerTask(JokerGuessSkillTriggerAction data)
	{
		this.TaskType = EGuessJokerTaskType.Interactive;
		this.SkillId = data.JokerSkillId;
		this.SkillRemindCount = data.RemainingSkillNum;
		this.HasPlayerChosen = false;
		this.FinishTime = (float)GuessJokerUtils.GetJokerParamConfig(EGuessJokerParamKey.GuessJokerPlayerSkillConsiderTime.ToString());
	}

	// Token: 0x0600710B RID: 28939 RVA: 0x001D8DDC File Offset: 0x001D6FDC
	protected override void OnExecute()
	{
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, string.Format("玩家技能触发：{0} 剩余次数：{1}", this.SkillId, this.SkillRemindCount), default(ReadOnlySpan<ValueTuple<string, object>>));
		GuessJokerGamePlayView gamePlayView = ModelBase<GuessJokerGamePlayModel>.Instance.GetGamePlayView();
		if (gamePlayView == null)
		{
			base.FinishTask();
			return;
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(true);
		gamePlayView.SetCurrentSkillInfo(this.SkillId, this.SkillRemindCount);
		gamePlayView.ShowSkillInteractivePanel(true);
		gamePlayView.SetSkillProgress(EGuessJokerPlayerType.Me, 0f);
		GuessJokerController controller = ControllerBase<GuessJokerController>.Instance;
		Action <>9__1;
		gamePlayView.SetPlayerSkillRequestCallback(delegate(bool isUse)
		{
			if (this.IsFinished() || this.IsAutoAbandoning)
			{
				Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "任务已完成或正在自动放弃，忽略玩家点击", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!this.CanSendRequest())
			{
				Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, "技能请求进行中，忽略重复点击", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SetRequestFinished(true);
			GuessJokerController controller = controller;
			int skillId = this.SkillId;
			Action callback;
			if ((callback = <>9__1) == null)
			{
				callback = (<>9__1 = delegate()
				{
					this.HasPlayerChosen = true;
					gamePlayView.ShowSkillInteractivePanel(false);
					this.FinishTask();
				});
			}
			controller.JokerGuessUseSkillRequest(skillId, isUse, callback);
		});
		ModelBase<GuessJokerGamePlayModel>.Instance.PushPlotActions(new GuessJokerPlotAction[]
		{
			new GuessJokerPlotAction(EGuessJokerPlayerType.Me, EGuessJokerPlotTiming.TriggerSkill, null)
		});
	}

	// Token: 0x0600710C RID: 28940 RVA: 0x001D8ED4 File Offset: 0x001D70D4
	protected override void OnTick(float deltaTime)
	{
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		GuessJokerGamePlayView guessJokerGamePlayView = (instance != null) ? instance.GetGamePlayView() : null;
		if (guessJokerGamePlayView == null || this.FinishTime <= 0f)
		{
			return;
		}
		this.ThinkTime += deltaTime;
		float progress = Math.Min(1f, this.ThinkTime / this.FinishTime);
		guessJokerGamePlayView.SetSkillProgress(EGuessJokerPlayerType.Me, progress);
	}

	// Token: 0x0600710D RID: 28941 RVA: 0x001D8F34 File Offset: 0x001D7134
	protected override void OnComplete()
	{
		GuessJokerPlayerSkillTriggerTask.<>c__DisplayClass8_0 CS$<>8__locals1 = new GuessJokerPlayerSkillTriggerTask.<>c__DisplayClass8_0();
		GuessJokerPlayerSkillTriggerTask.<>c__DisplayClass8_0 CS$<>8__locals2 = CS$<>8__locals1;
		GuessJokerGamePlayModel instance = ModelBase<GuessJokerGamePlayModel>.Instance;
		CS$<>8__locals2.gamePlayView = ((instance != null) ? instance.GetGamePlayView() : null);
		if (CS$<>8__locals1.gamePlayView != null)
		{
			this.IsAutoAbandoning = true;
			if (!this.HasPlayerChosen)
			{
				ControllerBase<GuessJokerController>.Instance.JokerGuessUseSkillRequest(this.SkillId, false, delegate
				{
					CS$<>8__locals1.gamePlayView.ShowSkillInteractivePanel(false);
					CS$<>8__locals1.gamePlayView.SetSkillProgress(EGuessJokerPlayerType.Me, 0f);
				});
			}
			else
			{
				CS$<>8__locals1.gamePlayView.ShowSkillInteractivePanel(false);
				CS$<>8__locals1.gamePlayView.SetSkillProgress(EGuessJokerPlayerType.Me, 0f);
			}
		}
		ModelBase<GuessJokerGamePlayModel>.Instance.SetNpcEnterInteractiveStage(false);
	}

	// Token: 0x0400365A RID: 13914
	private readonly int SkillId;

	// Token: 0x0400365B RID: 13915
	private readonly int SkillRemindCount;

	// Token: 0x0400365C RID: 13916
	private bool HasPlayerChosen;

	// Token: 0x0400365D RID: 13917
	private bool IsAutoAbandoning;

	// Token: 0x0400365E RID: 13918
	private float ThinkTime;
}
