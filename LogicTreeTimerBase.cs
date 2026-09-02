using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E02 RID: 7682
[NullableContext(1)]
[Nullable(0)]
public class LogicTreeTimerBase
{
	// Token: 0x170011B8 RID: 4536
	// (get) Token: 0x0600E2DF RID: 58079 RVA: 0x003D1A5C File Offset: 0x003CFC5C
	public string TimerType
	{
		get
		{
			return this.InnerTimerType;
		}
	}

	// Token: 0x0600E2E0 RID: 58080 RVA: 0x003D1A64 File Offset: 0x003CFC64
	public LogicTreeTimerBase(long treeIncId, string timerType, bool needTick = true, double intervalTime = 20.0)
	{
		this.TreeId = treeIncId;
		this.InnerTimerType = timerType;
		this.TimerId = TimerSystem.Instance.Forever(new TTimerAction(this.Tick), (float)((int)intervalTime), 1f, null, null, true);
	}

	// Token: 0x0600E2E1 RID: 58081 RVA: 0x003D1AA2 File Offset: 0x003CFCA2
	public virtual void Destroy()
	{
		if (this.TimerId != null)
		{
			TimerSystem.Instance.Remove(this.TimerId);
		}
	}

	// Token: 0x0600E2E2 RID: 58082 RVA: 0x003D1ABD File Offset: 0x003CFCBD
	private void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x0600E2E3 RID: 58083 RVA: 0x003D1AC6 File Offset: 0x003CFCC6
	public virtual void StartShowTimer(double endTime, double pauseTime)
	{
	}

	// Token: 0x0600E2E4 RID: 58084 RVA: 0x003D1AC8 File Offset: 0x003CFCC8
	public virtual void EndShowTimer()
	{
	}

	// Token: 0x0600E2E5 RID: 58085 RVA: 0x003D1ACA File Offset: 0x003CFCCA
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x0600E2E6 RID: 58086 RVA: 0x003D1ACC File Offset: 0x003CFCCC
	public virtual double GetRemainTime()
	{
		return 0.0;
	}

	// Token: 0x04006D18 RID: 27928
	protected readonly long TreeId;

	// Token: 0x04006D19 RID: 27929
	[Nullable(2)]
	protected readonly TimerHandle TimerId;

	// Token: 0x04006D1A RID: 27930
	protected readonly string InnerTimerType;
}
