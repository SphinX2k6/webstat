using System;

// Token: 0x0200117D RID: 4477
public class ActivityLinkageTabData
{
	// Token: 0x060075DB RID: 30171 RVA: 0x001ED738 File Offset: 0x001EB938
	public bool IsInShowTimeChange()
	{
		bool flag = false;
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if ((double)this.StartTimeStamp <= serverTimeStamp && serverTimeStamp <= (double)this.EndTimeStamp)
		{
			flag = true;
		}
		bool result = flag != this.IsInShowTime;
		this.IsInShowTime = flag;
		return result;
	}

	// Token: 0x04003913 RID: 14611
	public int TabId;

	// Token: 0x04003914 RID: 14612
	public long StartTimeStamp;

	// Token: 0x04003915 RID: 14613
	public long EndTimeStamp;

	// Token: 0x04003916 RID: 14614
	public bool IsReceive;

	// Token: 0x04003917 RID: 14615
	public bool IsInShowTime;
}
