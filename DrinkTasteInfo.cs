using System;

// Token: 0x0200100E RID: 4110
public class DrinkTasteInfo : IDrinkTasteInfo
{
	// Token: 0x17000845 RID: 2117
	// (get) Token: 0x06006AF6 RID: 27382 RVA: 0x001BF5C8 File Offset: 0x001BD7C8
	// (set) Token: 0x06006AF7 RID: 27383 RVA: 0x001BF5D0 File Offset: 0x001BD7D0
	public EDrinksFlavorType Type { get; set; }

	// Token: 0x17000846 RID: 2118
	// (get) Token: 0x06006AF8 RID: 27384 RVA: 0x001BF5D9 File Offset: 0x001BD7D9
	// (set) Token: 0x06006AF9 RID: 27385 RVA: 0x001BF5E1 File Offset: 0x001BD7E1
	public int Value { get; set; }
}
