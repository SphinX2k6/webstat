using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E03 RID: 7683
public class NoUiTimer : LogicTreeTimerBase
{
	// Token: 0x0600E2E7 RID: 58087 RVA: 0x003D1AD7 File Offset: 0x003CFCD7
	[NullableContext(1)]
	public NoUiTimer(long treeIncId, string timerType, bool needTick = true, double intervalTime = 20.0) : base(treeIncId, timerType, needTick, intervalTime)
	{
	}

	// Token: 0x0600E2E8 RID: 58088 RVA: 0x003D1AE4 File Offset: 0x003CFCE4
	public override void StartShowTimer(double endTime, double pauseTime)
	{
		this.TimerEndTime = endTime;
		this.TimerPauseTime = pauseTime;
	}

	// Token: 0x0600E2E9 RID: 58089 RVA: 0x003D1AF4 File Offset: 0x003CFCF4
	public override double GetRemainTime()
	{
		double val = (this.TimerEndTime - Singleton<TimeUtil>.Instance.GetServerStopTimeStamp()) / 1000.0;
		double val2 = (this.TimerPauseTime != 0.0) ? ((this.TimerEndTime - this.TimerPauseTime) / 1000.0) : -1.0;
		return Math.Max(val, Math.Max(val2, 0.0));
	}

	// Token: 0x04006D1B RID: 27931
	private double TimerEndTime;

	// Token: 0x04006D1C RID: 27932
	private double TimerPauseTime;
}
