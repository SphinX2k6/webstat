using System;

// Token: 0x02001773 RID: 6003
public class AdviceSelectItemData
{
	// Token: 0x0600A8F2 RID: 43250 RVA: 0x002CFEC9 File Offset: 0x002CE0C9
	public AdviceSelectItemData(EAdviceSelectItemEnum index)
	{
		this.Index = index;
	}

	// Token: 0x0600A8F3 RID: 43251 RVA: 0x002CFED8 File Offset: 0x002CE0D8
	public EAdviceSelectItemEnum GetIndex()
	{
		return this.Index;
	}

	// Token: 0x04004F92 RID: 20370
	private readonly EAdviceSelectItemEnum Index;
}
