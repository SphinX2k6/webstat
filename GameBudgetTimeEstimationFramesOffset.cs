using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02000BC5 RID: 3013
public class GameBudgetTimeEstimationFramesOffset : IGameBudgetTimeEstimation
{
	// Token: 0x06003131 RID: 12593 RVA: 0x0001B81C File Offset: 0x00019A1C
	public GameBudgetTimeEstimationFramesOffset()
	{
		this.GtOffsetToleranceTime = this.GtFrameConsumeBaseTimeMs * this.GtOffsetToleranceTimePercentage;
	}

	// Token: 0x06003132 RID: 12594 RVA: 0x0001B888 File Offset: 0x00019A88
	public void Initialize()
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetBudgetTime(this.TickBudgetTime);
	}

	// Token: 0x06003133 RID: 12595 RVA: 0x0001B898 File Offset: 0x00019A98
	public void SetMaximumFrameRate(int fps)
	{
		this.GtFrameConsumeBaseTimeMs = 1000f / (float)fps * (Singleton<Info>.Instance.IsMobilePlatform() ? 0.8f : 0.95f);
		this.GtFrameMaxBudgetTimeMs = this.GtFrameConsumeBaseTimeMs / (Singleton<Info>.Instance.IsMobilePlatform() ? 2.33f : 1.5f);
		this.TickBudgetTime = (float)Math.Floor((double)(this.GtFrameConsumeBaseTimeMs / 2f));
		this.GtOffsetToleranceTime = this.GtFrameConsumeBaseTimeMs * this.GtOffsetToleranceTimePercentage;
		this.GtAverageConsumeTimeStatisticsFrameCount = fps;
		this.CurrentConsumeTimesPointer = -1;
		this.GtHistoryConsumeTimes.Clear();
		this.GtAverageOffsetTime = 0f;
		UKuroGameBudgetAllocatorCSharpInterface.SetBudgetTime(this.TickBudgetTime);
	}

	// Token: 0x06003134 RID: 12596 RVA: 0x0001B94C File Offset: 0x00019B4C
	public void UpdateBudgetTime(float delta)
	{
		float lastFrameGameThreadConsumeTime = UKuroGameBudgetAllocatorCSharpInterface.GetLastFrameGameThreadConsumeTime();
		if (this.GtHistoryConsumeTimes.Count < this.GtAverageConsumeTimeStatisticsFrameCount)
		{
			this.GtHistoryConsumeTimes.Add(lastFrameGameThreadConsumeTime - this.GtFrameConsumeBaseTimeMs);
			if (this.GtHistoryConsumeTimes.Count == this.GtAverageConsumeTimeStatisticsFrameCount)
			{
				float num = 0f;
				for (int i = 0; i < this.GtHistoryConsumeTimes.Count; i++)
				{
					num += this.GtHistoryConsumeTimes[i];
				}
				this.GtAverageOffsetTime = num / (float)this.GtAverageConsumeTimeStatisticsFrameCount;
				this.CurrentConsumeTimesPointer = -1;
			}
			return;
		}
		this.CurrentConsumeTimesPointer++;
		if (this.CurrentConsumeTimesPointer >= this.GtAverageConsumeTimeStatisticsFrameCount)
		{
			this.CurrentConsumeTimesPointer = 0;
		}
		if (this.CurrentConsumeTimesPointer >= this.GtHistoryConsumeTimes.Count)
		{
			return;
		}
		float num2 = this.GtHistoryConsumeTimes[this.CurrentConsumeTimesPointer];
		float num3 = lastFrameGameThreadConsumeTime - this.GtFrameConsumeBaseTimeMs;
		this.GtHistoryConsumeTimes[this.CurrentConsumeTimesPointer] = num3;
		this.GtAverageOffsetTime += (num3 - num2) / (float)this.GtAverageConsumeTimeStatisticsFrameCount;
		if (this.GtAverageOffsetTime < -this.GtOffsetToleranceTime)
		{
			float num4 = (this.GtOffsetToleranceTime - this.GtAverageOffsetTime) / this.GtOffsetToleranceTime;
			this.TickBudgetTime += this.GtOffsetToleranceTime * num4 / (float)this.GtAverageConsumeTimeStatisticsFrameCount;
		}
		else if (this.GtAverageOffsetTime > this.GtOffsetToleranceTime)
		{
			float num5 = (this.GtAverageOffsetTime - this.GtOffsetToleranceTime) / this.GtOffsetToleranceTime;
			this.TickBudgetTime -= this.GtOffsetToleranceTime * num5 / (float)this.GtAverageConsumeTimeStatisticsFrameCount;
		}
		this.TickBudgetTime = MathCommon.Clamp(this.TickBudgetTime, 0f, this.GtFrameMaxBudgetTimeMs);
		UKuroGameBudgetAllocatorCSharpInterface.SetBudgetTime(this.TickBudgetTime);
		bool debugEnabled = this.DebugEnabled;
	}

	// Token: 0x0400044C RID: 1100
	private float GtFrameConsumeBaseTimeMs = 16.6f;

	// Token: 0x0400044D RID: 1101
	private float GtFrameMaxBudgetTimeMs = 5f;

	// Token: 0x0400044E RID: 1102
	private int GtAverageConsumeTimeStatisticsFrameCount = 60;

	// Token: 0x0400044F RID: 1103
	private float GtAverageOffsetTime;

	// Token: 0x04000450 RID: 1104
	private readonly float GtOffsetToleranceTimePercentage = 0.033333335f;

	// Token: 0x04000451 RID: 1105
	private float GtOffsetToleranceTime;

	// Token: 0x04000452 RID: 1106
	private int CurrentConsumeTimesPointer = -1;

	// Token: 0x04000453 RID: 1107
	[Nullable(1)]
	private readonly List<float> GtHistoryConsumeTimes = new List<float>();

	// Token: 0x04000454 RID: 1108
	public float TickBudgetTime = 8f;

	// Token: 0x04000455 RID: 1109
	private readonly bool DebugEnabled;
}
