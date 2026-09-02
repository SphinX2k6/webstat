using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A16 RID: 10774
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SignalDecodeModel : ModelBase<SignalDecodeModel>
{
	// Token: 0x060157EF RID: 88047 RVA: 0x005F5864 File Offset: 0x005F3A64
	public void GameplayStart(string id)
	{
		this.CurrentGameplayId = id;
		CatchSignalGameplay? gameplayConfig = ConfigBase<SignalDecodeConfig>.Instance.GetGameplayConfig(id);
		if (gameplayConfig == null)
		{
			return;
		}
		this.CurrentGameplayType = (ESignalGameplayType)gameplayConfig.Value.Type;
		this.CurrentMorseCode = (gameplayConfig.Value.MorseCode ?? "");
		this.CurrentDifficulty = gameplayConfig.Value.Difficulty;
		CatchSignalDifficulty? difficultyConfig = ConfigBase<SignalDecodeConfig>.Instance.GetDifficultyConfig(gameplayConfig.Value.Difficulty);
		if (difficultyConfig == null)
		{
			return;
		}
		this.TargetCompletion = difficultyConfig.Value.TargetCompletion;
		this.Speed = difficultyConfig.Value.SpeedRate * 100f;
		this.StartDecisionSize = difficultyConfig.Value.PressTimeWindow;
		this.EndDecisionSize = difficultyConfig.Value.ReleaseTimeWindow;
	}

	// Token: 0x0400A56B RID: 42347
	public string CurrentGameplayId = "";

	// Token: 0x0400A56C RID: 42348
	public ESignalGameplayType CurrentGameplayType = ESignalGameplayType.Catch;

	// Token: 0x0400A56D RID: 42349
	public string CurrentMorseCode = "";

	// Token: 0x0400A56E RID: 42350
	public int CurrentDifficulty;

	// Token: 0x0400A56F RID: 42351
	public int TargetCompletion = 100;

	// Token: 0x0400A570 RID: 42352
	public float Speed = 100f;

	// Token: 0x0400A571 RID: 42353
	public int StartDecisionSize;

	// Token: 0x0400A572 RID: 42354
	public int EndDecisionSize;
}
