using System;
using System.Runtime.CompilerServices;

// Token: 0x020019C6 RID: 6598
[NullableContext(2)]
[Nullable(0)]
public class MediumItemPrice : IMediumItemPrice
{
	// Token: 0x17000F75 RID: 3957
	// (get) Token: 0x0600BD65 RID: 48485 RVA: 0x00323EC5 File Offset: 0x003220C5
	// (set) Token: 0x0600BD66 RID: 48486 RVA: 0x00323ECD File Offset: 0x003220CD
	public int CurPrice { get; set; }

	// Token: 0x17000F76 RID: 3958
	// (get) Token: 0x0600BD67 RID: 48487 RVA: 0x00323ED6 File Offset: 0x003220D6
	// (set) Token: 0x0600BD68 RID: 48488 RVA: 0x00323EDE File Offset: 0x003220DE
	public int? OriginalPrice { get; set; }

	// Token: 0x17000F77 RID: 3959
	// (get) Token: 0x0600BD69 RID: 48489 RVA: 0x00323EE7 File Offset: 0x003220E7
	// (set) Token: 0x0600BD6A RID: 48490 RVA: 0x00323EEF File Offset: 0x003220EF
	public string TexPath { get; set; }

	// Token: 0x17000F78 RID: 3960
	// (get) Token: 0x0600BD6B RID: 48491 RVA: 0x00323EF8 File Offset: 0x003220F8
	// (set) Token: 0x0600BD6C RID: 48492 RVA: 0x00323F00 File Offset: 0x00322100
	public bool? CurrencyNotEnough { get; set; }
}
