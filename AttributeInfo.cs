using System;
using System.Runtime.CompilerServices;

// Token: 0x02002890 RID: 10384
[NullableContext(2)]
[Nullable(0)]
public class AttributeInfo : IAttributeInfo
{
	// Token: 0x17001AE3 RID: 6883
	// (get) Token: 0x060148F2 RID: 84210 RVA: 0x005B2BF7 File Offset: 0x005B0DF7
	// (set) Token: 0x060148F3 RID: 84211 RVA: 0x005B2BFF File Offset: 0x005B0DFF
	public string Name { get; set; }

	// Token: 0x17001AE4 RID: 6884
	// (get) Token: 0x060148F4 RID: 84212 RVA: 0x005B2C08 File Offset: 0x005B0E08
	// (set) Token: 0x060148F5 RID: 84213 RVA: 0x005B2C10 File Offset: 0x005B0E10
	public string IconPath { get; set; }

	// Token: 0x17001AE5 RID: 6885
	// (get) Token: 0x060148F6 RID: 84214 RVA: 0x005B2C19 File Offset: 0x005B0E19
	// (set) Token: 0x060148F7 RID: 84215 RVA: 0x005B2C21 File Offset: 0x005B0E21
	public bool? ShowArrow { get; set; }

	// Token: 0x17001AE6 RID: 6886
	// (get) Token: 0x060148F8 RID: 84216 RVA: 0x005B2C2A File Offset: 0x005B0E2A
	// (set) Token: 0x060148F9 RID: 84217 RVA: 0x005B2C32 File Offset: 0x005B0E32
	public string PreText { get; set; }

	// Token: 0x17001AE7 RID: 6887
	// (get) Token: 0x060148FA RID: 84218 RVA: 0x005B2C3B File Offset: 0x005B0E3B
	// (set) Token: 0x060148FB RID: 84219 RVA: 0x005B2C43 File Offset: 0x005B0E43
	public string CurText { get; set; }

	// Token: 0x17001AE8 RID: 6888
	// (get) Token: 0x060148FC RID: 84220 RVA: 0x005B2C4C File Offset: 0x005B0E4C
	// (set) Token: 0x060148FD RID: 84221 RVA: 0x005B2C54 File Offset: 0x005B0E54
	public bool? IsNormalBg { get; set; }

	// Token: 0x17001AE9 RID: 6889
	// (get) Token: 0x060148FE RID: 84222 RVA: 0x005B2C5D File Offset: 0x005B0E5D
	// (set) Token: 0x060148FF RID: 84223 RVA: 0x005B2C65 File Offset: 0x005B0E65
	public bool? InnerShowBg { get; set; }

	// Token: 0x17001AEA RID: 6890
	// (get) Token: 0x06014900 RID: 84224 RVA: 0x005B2C6E File Offset: 0x005B0E6E
	// (set) Token: 0x06014901 RID: 84225 RVA: 0x005B2C76 File Offset: 0x005B0E76
	public bool? IsLine { get; set; }
}
