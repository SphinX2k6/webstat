using System;

// Token: 0x02000BDE RID: 3038
public class TimeLimit
{
	// Token: 0x060031F2 RID: 12786 RVA: 0x000203BB File Offset: 0x0001E5BB
	public TimeLimit(long? microSecond = null)
	{
		if (microSecond != null)
		{
			this.TimeLimitMicroSecond = microSecond.Value;
		}
	}

	// Token: 0x060031F3 RID: 12787 RVA: 0x000203E0 File Offset: 0x0001E5E0
	public void SetEnable(bool enabled)
	{
		this.Enabled = enabled;
	}

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x060031F4 RID: 12788 RVA: 0x000203E9 File Offset: 0x0001E5E9
	public double CurrentCost
	{
		get
		{
			return this.CurrentCostMicroSecond;
		}
	}

	// Token: 0x060031F5 RID: 12789 RVA: 0x000203F1 File Offset: 0x0001E5F1
	public void ResetCost()
	{
		this.CurrentCostMicroSecond = 0.0;
	}

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060031F7 RID: 12791 RVA: 0x0002040B File Offset: 0x0001E60B
	// (set) Token: 0x060031F6 RID: 12790 RVA: 0x00020402 File Offset: 0x0001E602
	public long Limit
	{
		get
		{
			return this.TimeLimitMicroSecond;
		}
		set
		{
			this.TimeLimitMicroSecond = value;
		}
	}

	// Token: 0x060031F8 RID: 12792 RVA: 0x00020413 File Offset: 0x0001E613
	public void AddCost(double newCostMicroSecond)
	{
		this.CurrentCostMicroSecond += newCostMicroSecond;
	}

	// Token: 0x060031F9 RID: 12793 RVA: 0x00020423 File Offset: 0x0001E623
	public bool IsTimeLimitExceeded()
	{
		return this.Enabled && this.TimeLimitMicroSecond > 0L && this.CurrentCostMicroSecond >= (double)this.TimeLimitMicroSecond;
	}

	// Token: 0x040004E2 RID: 1250
	private double CurrentCostMicroSecond;

	// Token: 0x040004E3 RID: 1251
	private long TimeLimitMicroSecond;

	// Token: 0x040004E4 RID: 1252
	private bool Enabled = true;
}
