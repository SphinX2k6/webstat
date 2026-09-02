using System;

// Token: 0x020011E9 RID: 4585
public class BabelTowerSelectInfo : IBabelTowerSelectInfo
{
	// Token: 0x17000A39 RID: 2617
	// (get) Token: 0x06007947 RID: 31047 RVA: 0x001FCDA8 File Offset: 0x001FAFA8
	// (set) Token: 0x06007948 RID: 31048 RVA: 0x001FCDB0 File Offset: 0x001FAFB0
	public EBabelTowerDeTermState State { get; set; }

	// Token: 0x17000A3A RID: 2618
	// (get) Token: 0x06007949 RID: 31049 RVA: 0x001FCDB9 File Offset: 0x001FAFB9
	// (set) Token: 0x0600794A RID: 31050 RVA: 0x001FCDC1 File Offset: 0x001FAFC1
	public int SelectIndex { get; set; }
}
