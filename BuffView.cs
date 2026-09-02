using System;

// Token: 0x020014CF RID: 5327
public class BuffView : IBuffView
{
	// Token: 0x17000C97 RID: 3223
	// (get) Token: 0x060094D3 RID: 38099 RVA: 0x00270465 File Offset: 0x0026E665
	// (set) Token: 0x060094D4 RID: 38100 RVA: 0x0027046D File Offset: 0x0026E66D
	public int BuffId { get; set; }

	// Token: 0x17000C98 RID: 3224
	// (get) Token: 0x060094D5 RID: 38101 RVA: 0x00270476 File Offset: 0x0026E676
	// (set) Token: 0x060094D6 RID: 38102 RVA: 0x0027047E File Offset: 0x0026E67E
	public EPinballBuffType BuffType { get; set; }

	// Token: 0x17000C99 RID: 3225
	// (get) Token: 0x060094D7 RID: 38103 RVA: 0x00270487 File Offset: 0x0026E687
	// (set) Token: 0x060094D8 RID: 38104 RVA: 0x0027048F File Offset: 0x0026E68F
	public int BuffCount { get; set; }

	// Token: 0x17000C9A RID: 3226
	// (get) Token: 0x060094D9 RID: 38105 RVA: 0x00270498 File Offset: 0x0026E698
	// (set) Token: 0x060094DA RID: 38106 RVA: 0x002704A0 File Offset: 0x0026E6A0
	public int Sort { get; set; }
}
