using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CFE RID: 7422
[NullableContext(2)]
[Nullable(0)]
public class GachaTagInfo
{
	// Token: 0x0600D9F4 RID: 55796 RVA: 0x003A7976 File Offset: 0x003A5B76
	public GachaTagInfo(EGachaTagKind kind, string text = null, int? discountPct = null)
	{
		this.Kind = kind;
		this.Text = text;
		this.DiscountPct = discountPct;
	}

	// Token: 0x04006802 RID: 26626
	public EGachaTagKind Kind;

	// Token: 0x04006803 RID: 26627
	public string Text;

	// Token: 0x04006804 RID: 26628
	public int? DiscountPct;
}
