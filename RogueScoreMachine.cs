using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001FB5 RID: 8117
[NullableContext(2)]
[Nullable(0)]
public class RogueScoreMachine
{
	// Token: 0x0600F476 RID: 62582 RVA: 0x0042DFAA File Offset: 0x0042C1AA
	[NullableContext(1)]
	public void SetUpdateCallback(Action<float, BattleScoreLevelConf?> updateScore, Action playUpAnim)
	{
		this.UpdateScore = updateScore;
		this.PlayUpAnim = playUpAnim;
	}

	// Token: 0x0600F477 RID: 62583 RVA: 0x0042DFBC File Offset: 0x0042C1BC
	public void UpdateTargetScore(float score, BattleScoreLevelConf? scoreLevelConfig)
	{
		if (scoreLevelConfig != null && score >= (float)scoreLevelConfig.Value.LowerUpperLimits(1))
		{
			this.TargetScore = (float)scoreLevelConfig.Value.LowerUpperLimits(1);
		}
		else
		{
			this.TargetScore = score;
		}
		this.TargetScoreActionConfig = scoreLevelConfig;
		if (this.CurScore == this.TargetScore)
		{
			return;
		}
		bool flag = this.TargetScore > this.CurScore;
		if (flag)
		{
			Action playUpAnim = this.PlayUpAnim;
			if (playUpAnim != null)
			{
				playUpAnim();
			}
		}
		if (this.CurScoreActionConfig == null && this.TargetScoreActionConfig == null)
		{
			return;
		}
		int num = (this.CurScoreActionConfig != null) ? this.CurScoreActionConfig.GetValueOrDefault().Level : 0;
		if (Math.Abs(((this.TargetScoreActionConfig != null) ? this.TargetScoreActionConfig.GetValueOrDefault().Level : 0) - num) > 1)
		{
			this.JumpToTarget();
			return;
		}
		bool flag2 = false;
		if (this.CurScoreActionConfig == null)
		{
			this.CurScore = (float)this.TargetScoreActionConfig.Value.LowerUpperLimits(0);
			this.CurScoreActionConfig = this.TargetScoreActionConfig;
			if (this.CurScore == this.TargetScore)
			{
				this.Speed = 0f;
				Action<float, BattleScoreLevelConf?> updateScore = this.UpdateScore;
				if (updateScore == null)
				{
					return;
				}
				updateScore(this.CurScore, this.CurScoreActionConfig);
				return;
			}
			else
			{
				flag2 = true;
			}
		}
		if (Math.Abs(score - this.CurScore) >= 1000f)
		{
			this.JumpToTarget();
			return;
		}
		if (flag)
		{
			this.Speed = (this.TargetScore - this.CurScore) / 300f;
		}
		else
		{
			this.Speed = (this.TargetScore - this.CurScore) / 1000f;
		}
		if (flag2)
		{
			Action<float, BattleScoreLevelConf?> updateScore2 = this.UpdateScore;
			if (updateScore2 != null)
			{
				updateScore2(this.CurScore, this.CurScoreActionConfig);
			}
			this.UpdateFrame = Singleton<Time>.Instance.Frame;
		}
	}

	// Token: 0x0600F478 RID: 62584 RVA: 0x0042E19C File Offset: 0x0042C39C
	private void JumpToTarget()
	{
		this.CurScore = this.TargetScore;
		this.CurScoreActionConfig = this.TargetScoreActionConfig;
		this.Speed = 0f;
		Action<float, BattleScoreLevelConf?> updateScore = this.UpdateScore;
		if (updateScore == null)
		{
			return;
		}
		updateScore(this.CurScore, this.CurScoreActionConfig);
	}

	// Token: 0x0600F479 RID: 62585 RVA: 0x0042E1E8 File Offset: 0x0042C3E8
	public void Tick(float delta)
	{
		if (this.Speed == 0f || this.UpdateFrame == Singleton<Time>.Instance.Frame)
		{
			return;
		}
		this.CurScore += this.Speed * delta;
		int? num = (this.CurScoreActionConfig != null) ? new int?(this.CurScoreActionConfig.GetValueOrDefault().Level) : null;
		int? num2 = (this.TargetScoreActionConfig != null) ? new int?(this.TargetScoreActionConfig.GetValueOrDefault().Level) : null;
		if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
		{
			int num3 = this.CurScoreActionConfig.Value.LowerUpperLimits(0);
			int num4 = this.CurScoreActionConfig.Value.LowerUpperLimits(1);
			if (this.Speed > 0f)
			{
				if (this.CurScore >= (float)num4)
				{
					this.CurScoreActionConfig = this.TargetScoreActionConfig;
				}
			}
			else if (this.CurScore < (float)num3)
			{
				this.CurScoreActionConfig = this.TargetScoreActionConfig;
			}
		}
		if (this.Speed > 0f)
		{
			if (this.CurScore >= this.TargetScore)
			{
				this.CurScore = this.TargetScore;
				this.Speed = 0f;
			}
		}
		else if (this.CurScore <= this.TargetScore)
		{
			this.CurScore = this.TargetScore;
			this.Speed = 0f;
		}
		Action<float, BattleScoreLevelConf?> updateScore = this.UpdateScore;
		if (updateScore == null)
		{
			return;
		}
		updateScore(this.CurScore, this.CurScoreActionConfig);
	}

	// Token: 0x0600F47A RID: 62586 RVA: 0x0042E385 File Offset: 0x0042C585
	public void ResetScore()
	{
		this.CurScore = 0f;
		this.TargetScore = 0f;
		this.CurScoreActionConfig = null;
		this.TargetScoreActionConfig = null;
	}

	// Token: 0x040075AB RID: 30123
	private const int SERVER_SCORE_UP_INTERVAL = 300;

	// Token: 0x040075AC RID: 30124
	private const int SERVER_SCORE_DOWN_INTERVAL = 1000;

	// Token: 0x040075AD RID: 30125
	private const int MAX_SCORE_DIFF = 1000;

	// Token: 0x040075AE RID: 30126
	private Action<float, BattleScoreLevelConf?> UpdateScore;

	// Token: 0x040075AF RID: 30127
	private Action PlayUpAnim;

	// Token: 0x040075B0 RID: 30128
	private int UpdateFrame;

	// Token: 0x040075B1 RID: 30129
	private float CurScore;

	// Token: 0x040075B2 RID: 30130
	private float TargetScore;

	// Token: 0x040075B3 RID: 30131
	private BattleScoreLevelConf? CurScoreActionConfig;

	// Token: 0x040075B4 RID: 30132
	private BattleScoreLevelConf? TargetScoreActionConfig;

	// Token: 0x040075B5 RID: 30133
	private float Speed;
}
