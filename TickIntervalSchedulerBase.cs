using System;
using System.Runtime.CompilerServices;

// Token: 0x020034DE RID: 13534
public class TickIntervalSchedulerBase
{
	// Token: 0x0601C956 RID: 117078 RVA: 0x00891728 File Offset: 0x0088F928
	public void SetBaseConfigs(double maxNoIntervalCount, double averageOtherTickCount, double noIntervalThreshold)
	{
		this.MaxNoIntervalCount = Math.Max(0.0, maxNoIntervalCount);
		this.AverageOtherTickCount = Math.Max(1.0, averageOtherTickCount);
		this.NoIntervalThreshold = noIntervalThreshold;
	}

	// Token: 0x0601C957 RID: 117079 RVA: 0x0089175B File Offset: 0x0088F95B
	public void SetCountDelta(double newDelta)
	{
		this.CurrentCountDelta = Singleton<MathUtils>.Instance.Clamp(newDelta * this.DeltaRatio, this.MinTickCountDelta, this.MaxTickCountDelta);
	}

	// Token: 0x0601C958 RID: 117080 RVA: 0x00891781 File Offset: 0x0088F981
	public void Schedule()
	{
		this.GetScores();
		this.ScheduleTickInterval();
	}

	// Token: 0x0601C959 RID: 117081 RVA: 0x0089178F File Offset: 0x0088F98F
	public virtual void ChangeTickFramePeriodByFrameRate(double frameRate)
	{
	}

	// Token: 0x0601C95A RID: 117082 RVA: 0x00891791 File Offset: 0x0088F991
	protected virtual void GetScores()
	{
	}

	// Token: 0x0601C95B RID: 117083 RVA: 0x00891793 File Offset: 0x0088F993
	protected virtual void ScheduleTickInterval()
	{
	}

	// Token: 0x0400E63B RID: 58939
	protected double MaxNoIntervalCount;

	// Token: 0x0400E63C RID: 58940
	protected double AverageOtherTickCount;

	// Token: 0x0400E63D RID: 58941
	protected double NoIntervalThreshold;

	// Token: 0x0400E63E RID: 58942
	protected double MinTickCountDelta;

	// Token: 0x0400E63F RID: 58943
	protected double MaxTickCountDelta;

	// Token: 0x0400E640 RID: 58944
	protected double CurrentCountDelta;

	// Token: 0x0400E641 RID: 58945
	protected double DeltaRatio = 1.0;

	// Token: 0x0400E642 RID: 58946
	[Nullable(1)]
	private readonly Stat Stat = Stat.CreateNoFlameGraph(typeof(TickIntervalSchedulerBase).Name, "", "");
}
