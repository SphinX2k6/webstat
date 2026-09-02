using System;

// Token: 0x02001774 RID: 6004
public class AdviceMotionSelectData
{
	// Token: 0x0600A8F4 RID: 43252 RVA: 0x002CFEE0 File Offset: 0x002CE0E0
	public AdviceMotionSelectData(int index)
	{
		this.Index = index;
	}

	// Token: 0x0600A8F5 RID: 43253 RVA: 0x002CFEEF File Offset: 0x002CE0EF
	public int GetIndex()
	{
		return this.Index;
	}

	// Token: 0x04004F93 RID: 20371
	private readonly int Index;
}
