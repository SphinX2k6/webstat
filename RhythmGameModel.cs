using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02001143 RID: 4419
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RhythmGameModel : ModelBase<RhythmGameModel>
{
	// Token: 0x170009AA RID: 2474
	// (get) Token: 0x0600745F RID: 29791 RVA: 0x001E7792 File Offset: 0x001E5992
	// (set) Token: 0x06007460 RID: 29792 RVA: 0x001E779A File Offset: 0x001E599A
	public int CurSpeedLevelConfigIndex
	{
		get
		{
			return this.CurSpeedLevelConfigIndexValue;
		}
		set
		{
			if (this.CurSpeedLevelConfigIndexValue == value)
			{
				return;
			}
			this.CurSpeedLevelConfigIndexValue = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRhythmGameSpeedLevelConfigIndexChanged, value);
		}
	}

	// Token: 0x06007461 RID: 29793 RVA: 0x001E77BE File Offset: 0x001E59BE
	private void ClearCache()
	{
		this.ForceTargetActor = null;
		this.CurSplineComponent = null;
		this.RhythmGameConfig = null;
	}

	// Token: 0x06007462 RID: 29794 RVA: 0x001E77D5 File Offset: 0x001E59D5
	protected override bool OnLeaveLevel()
	{
		this.ClearCache();
		return true;
	}

	// Token: 0x06007463 RID: 29795 RVA: 0x001E77DE File Offset: 0x001E59DE
	protected override bool OnChangeMode()
	{
		this.ClearCache();
		return true;
	}

	// Token: 0x06007464 RID: 29796 RVA: 0x001E77E7 File Offset: 0x001E59E7
	public RhythmGameSpeedLevelConfig GetCurrentSpeedLevelConfig()
	{
		return this.RhythmGameConfig.SpeedLevelConfig.Get(this.CurSpeedLevelConfigIndex);
	}

	// Token: 0x06007465 RID: 29797 RVA: 0x001E77FF File Offset: 0x001E59FF
	public RhythmGameSpeedLevelConfig GetSpeedLevelConfigByIndex(int configIndex)
	{
		if (configIndex < 0)
		{
			return null;
		}
		return this.RhythmGameConfig.SpeedLevelConfig.Get(configIndex);
	}

	// Token: 0x06007466 RID: 29798 RVA: 0x001E7818 File Offset: 0x001E5A18
	public int GetScoreMultiplierByLevel(int levelIndex)
	{
		if (levelIndex >= this.ScoreMultipliers.Length)
		{
			return 1;
		}
		return this.ScoreMultipliers[levelIndex];
	}

	// Token: 0x06007467 RID: 29799 RVA: 0x001E7830 File Offset: 0x001E5A30
	public void InitializeScoreMultipliers()
	{
		BP_RhythmGameConfig_C rhythmGameConfig = this.RhythmGameConfig;
		FKuroRhythmGameConfig fkuroRhythmGameConfig = (rhythmGameConfig != null) ? rhythmGameConfig.Config : null;
		if (fkuroRhythmGameConfig == null)
		{
			this.ScoreMultipliers = new int[]
			{
				1,
				1,
				1,
				1,
				1
			};
			return;
		}
		FKuroRhythmGameHiddenScore hiddenScore = fkuroRhythmGameConfig.HiddenScore;
		if (hiddenScore == null)
		{
			this.ScoreMultipliers = new int[]
			{
				1,
				1,
				1,
				1,
				1
			};
			return;
		}
		this.ScoreMultipliers = new int[]
		{
			hiddenScore.Level1ScoreMultiplier,
			hiddenScore.Level2ScoreMultiplier,
			hiddenScore.Level3ScoreMultiplier,
			hiddenScore.Level4ScoreMultiplier,
			hiddenScore.Level5ScoreMultiplier
		};
	}

	// Token: 0x0400380B RID: 14347
	public AActor ForceTargetActor;

	// Token: 0x0400380C RID: 14348
	public USplineComponent CurSplineComponent;

	// Token: 0x0400380D RID: 14349
	[Nullable(1)]
	public Vector SplineLocation = Vector.Create();

	// Token: 0x0400380E RID: 14350
	public BP_RhythmGameConfig_C RhythmGameConfig;

	// Token: 0x0400380F RID: 14351
	public bool OnRoadMode;

	// Token: 0x04003810 RID: 14352
	private int CurSpeedLevelConfigIndexValue;

	// Token: 0x04003811 RID: 14353
	public int FeverCeiling;

	// Token: 0x04003812 RID: 14354
	[Nullable(1)]
	private int[] ScoreMultipliers = Array.Empty<int>();
}
