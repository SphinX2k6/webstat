using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020024A8 RID: 9384
[NullableContext(1)]
[Nullable(0)]
public class MainPhantomRecommendInfo
{
	// Token: 0x0601234F RID: 74575 RVA: 0x00501F6B File Offset: 0x0050016B
	public int GetUsage()
	{
		return this.Usage;
	}

	// Token: 0x06012350 RID: 74576 RVA: 0x00501F74 File Offset: 0x00500174
	public string GetUsageText()
	{
		double num = (double)(this.Usage - this.Usage % 10) / 100.0;
		if (this.Usage != 0)
		{
			return num.ToString("F1") + "%";
		}
		return "";
	}

	// Token: 0x06012351 RID: 74577 RVA: 0x00501FC1 File Offset: 0x005001C1
	public int GetMonsterId()
	{
		return this.MonsterId;
	}

	// Token: 0x06012352 RID: 74578 RVA: 0x00501FC9 File Offset: 0x005001C9
	public int GetFetterGroupId()
	{
		return this.FetterGroupId;
	}

	// Token: 0x06012353 RID: 74579 RVA: 0x00501FD1 File Offset: 0x005001D1
	public void Phrase(Aki.Protocol.MainPhantomRecommendInfo data)
	{
		this.Usage = data.Usage;
		this.MonsterId = data.MonsterId;
		this.FetterGroupId = data.FetterGroupId;
	}

	// Token: 0x04008E12 RID: 36370
	private int Usage;

	// Token: 0x04008E13 RID: 36371
	private int MonsterId;

	// Token: 0x04008E14 RID: 36372
	private int FetterGroupId;
}
