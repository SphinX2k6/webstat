using System;
using System.Runtime.CompilerServices;

// Token: 0x02001E58 RID: 7768
[NullableContext(1)]
[Nullable(0)]
public class HandBookDropItemData
{
	// Token: 0x0600E620 RID: 58912 RVA: 0x003E1EA4 File Offset: 0x003E00A4
	public HandBookDropItemData(string title, string place, TItem[] itemData)
	{
		this.Title = title;
		this.Place = place;
		this.ItemData = itemData;
	}

	// Token: 0x04006ECB RID: 28363
	public string Title;

	// Token: 0x04006ECC RID: 28364
	public string Place;

	// Token: 0x04006ECD RID: 28365
	public TItem[] ItemData;
}
