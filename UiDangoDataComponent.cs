using System;

// Token: 0x02002C96 RID: 11414
public class UiDangoDataComponent : UiModelComponentBase
{
	// Token: 0x17001E2E RID: 7726
	// (get) Token: 0x06016E86 RID: 93830 RVA: 0x0065A196 File Offset: 0x00658396
	// (set) Token: 0x06016E87 RID: 93831 RVA: 0x0065A19E File Offset: 0x0065839E
	public int DangoId
	{
		get
		{
			return this.DangoIdInternal;
		}
		set
		{
			this.DangoIdInternal = value;
		}
	}

	// Token: 0x0400B0AD RID: 45229
	private int DangoIdInternal;
}
