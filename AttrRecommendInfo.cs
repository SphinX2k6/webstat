using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020024A7 RID: 9383
[NullableContext(1)]
[Nullable(0)]
public class AttrRecommendInfo
{
	// Token: 0x06012349 RID: 74569 RVA: 0x00501ED8 File Offset: 0x005000D8
	public int GetAttrId()
	{
		return this.AttrId;
	}

	// Token: 0x0601234A RID: 74570 RVA: 0x00501EE0 File Offset: 0x005000E0
	public int GetUsage()
	{
		return this.Usage;
	}

	// Token: 0x0601234B RID: 74571 RVA: 0x00501EE8 File Offset: 0x005000E8
	public string GetUsageText()
	{
		double num = (double)(this.Usage - this.Usage % 10) / 100.0;
		if (this.Usage != 0)
		{
			return num.ToString("F1") + "%";
		}
		return "";
	}

	// Token: 0x0601234C RID: 74572 RVA: 0x00501F35 File Offset: 0x00500135
	public int GetAddType()
	{
		return this.AddType;
	}

	// Token: 0x0601234D RID: 74573 RVA: 0x00501F3D File Offset: 0x0050013D
	public void Phrase(PhantomAttrRecommendInfo data)
	{
		this.AttrId = data.AttrType;
		this.Usage = data.Usage;
		this.AddType = data.AddType;
	}

	// Token: 0x04008E0F RID: 36367
	private int AttrId;

	// Token: 0x04008E10 RID: 36368
	private int Usage;

	// Token: 0x04008E11 RID: 36369
	private int AddType;
}
