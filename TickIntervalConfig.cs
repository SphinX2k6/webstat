using System;

// Token: 0x02000C25 RID: 3109
public class TickIntervalConfig
{
	// Token: 0x060035BB RID: 13755 RVA: 0x00032A88 File Offset: 0x00030C88
	public TickIntervalConfig(int tickPerFrameThreshold, int tickFramePeriod, double tickPerFrameThresholdRadio, double tickFramePeriodRatio, int maxInterval)
	{
		this.TickPerFrameThreshold = tickPerFrameThreshold;
		this.TickFramePeriod = tickFramePeriod;
		this.TickPerFrameThresholdRadio = tickPerFrameThresholdRadio;
		this.TickFramePeriodRatio = tickFramePeriodRatio;
		this.MaxInterval = maxInterval;
	}

	// Token: 0x060035BC RID: 13756 RVA: 0x00032AB8 File Offset: 0x00030CB8
	public double GetScore(double distance, double radio)
	{
		return Math.Min((double)this.MaxInterval, Math.Max(0.0, distance - (double)this.TickPerFrameThreshold) / (double)this.TickFramePeriod + Math.Max(0.0, radio - this.TickPerFrameThresholdRadio) / this.TickFramePeriodRatio);
	}

	// Token: 0x0400069C RID: 1692
	public int TickPerFrameThreshold;

	// Token: 0x0400069D RID: 1693
	public int TickFramePeriod;

	// Token: 0x0400069E RID: 1694
	public double TickPerFrameThresholdRadio;

	// Token: 0x0400069F RID: 1695
	public double TickFramePeriodRatio;

	// Token: 0x040006A0 RID: 1696
	public int MaxInterval;
}
