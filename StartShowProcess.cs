using System;

// Token: 0x02001DFE RID: 7678
public class StartShowProcess : PendingProcess
{
	// Token: 0x0600E2CF RID: 58063 RVA: 0x003D170F File Offset: 0x003CF90F
	public StartShowProcess(double endTime) : base(EProcessType.StartShow)
	{
	}

	// Token: 0x04006D12 RID: 27922
	public readonly double EndTime = endTime;
}
