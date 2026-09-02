using System;

// Token: 0x02000C27 RID: 3111
public class TraceHandle
{
	// Token: 0x060035C3 RID: 13763 RVA: 0x00032C91 File Offset: 0x00030E91
	public TraceHandle(int frame = 0, int index = 0)
	{
		this.Frame = frame;
		this.Index = index;
	}

	// Token: 0x040006A6 RID: 1702
	public int Frame;

	// Token: 0x040006A7 RID: 1703
	public int Index;
}
