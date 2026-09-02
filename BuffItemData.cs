using System;

// Token: 0x020017C4 RID: 6084
public class BuffItemData
{
	// Token: 0x0600AC65 RID: 44133 RVA: 0x002DFC2C File Offset: 0x002DDE2C
	public BuffItemData(int itemConfigId, double endCdTimeStamp, double totalCdTime)
	{
		this.ItemConfigIdInternal = itemConfigId;
		this.TotalCdTime = totalCdTime;
		this.SetEndCdTimeStamp(endCdTimeStamp);
	}

	// Token: 0x17000DED RID: 3565
	// (get) Token: 0x0600AC66 RID: 44134 RVA: 0x002DFC49 File Offset: 0x002DDE49
	public int ItemConfigId
	{
		get
		{
			return this.ItemConfigIdInternal;
		}
	}

	// Token: 0x17000DEE RID: 3566
	// (get) Token: 0x0600AC67 RID: 44135 RVA: 0x002DFC51 File Offset: 0x002DDE51
	public double EndCdTimeStamp
	{
		get
		{
			return this.EndCdTimeStampInternal;
		}
	}

	// Token: 0x0600AC68 RID: 44136 RVA: 0x002DFC59 File Offset: 0x002DDE59
	public void SetEndCdTimeStamp(double endCdTimeStamp)
	{
		this.EndCdTimeStampInternal = endCdTimeStamp / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
		this.StartCdTimeStampInternal = Singleton<TimeUtil>.Instance.GetServerTime();
		this.StartCdWorldTime = Singleton<Time>.Instance.WorldTimeSeconds;
	}

	// Token: 0x0600AC69 RID: 44137 RVA: 0x002DFC8E File Offset: 0x002DDE8E
	public void SetTotalCdTime(double totalCdTime)
	{
		this.TotalCdTime = totalCdTime;
	}

	// Token: 0x0600AC6A RID: 44138 RVA: 0x002DFC97 File Offset: 0x002DDE97
	public double GetBuffItemRemainCdTime()
	{
		return Math.Max(this.EndCdTimeStampInternal - (Singleton<Time>.Instance.WorldTimeSeconds - this.StartCdWorldTime + this.StartCdTimeStampInternal), 0.0);
	}

	// Token: 0x0600AC6B RID: 44139 RVA: 0x002DFCC6 File Offset: 0x002DDEC6
	public double GetBuffItemTotalCdTime()
	{
		return this.TotalCdTime;
	}

	// Token: 0x040051A6 RID: 20902
	private readonly int ItemConfigIdInternal;

	// Token: 0x040051A7 RID: 20903
	private double EndCdTimeStampInternal;

	// Token: 0x040051A8 RID: 20904
	private double StartCdTimeStampInternal;

	// Token: 0x040051A9 RID: 20905
	private double StartCdWorldTime;

	// Token: 0x040051AA RID: 20906
	private double TotalCdTime;
}
