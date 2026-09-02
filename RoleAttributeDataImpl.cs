using System;
using System.Runtime.CompilerServices;

// Token: 0x020027CC RID: 10188
[NullableContext(1)]
[Nullable(0)]
public class RoleAttributeDataImpl : IRoleAttributeData
{
	// Token: 0x1700198C RID: 6540
	// (get) Token: 0x06014266 RID: 82534 RVA: 0x005A04A2 File Offset: 0x0059E6A2
	// (set) Token: 0x06014267 RID: 82535 RVA: 0x005A04AA File Offset: 0x0059E6AA
	public string Name { get; set; }

	// Token: 0x1700198D RID: 6541
	// (get) Token: 0x06014268 RID: 82536 RVA: 0x005A04B3 File Offset: 0x0059E6B3
	// (set) Token: 0x06014269 RID: 82537 RVA: 0x005A04BB File Offset: 0x0059E6BB
	public int Level { get; set; }

	// Token: 0x1700198E RID: 6542
	// (get) Token: 0x0601426A RID: 82538 RVA: 0x005A04C4 File Offset: 0x0059E6C4
	// (set) Token: 0x0601426B RID: 82539 RVA: 0x005A04CC File Offset: 0x0059E6CC
	public int BreakLevel { get; set; }

	// Token: 0x1700198F RID: 6543
	// (get) Token: 0x0601426C RID: 82540 RVA: 0x005A04D5 File Offset: 0x0059E6D5
	// (set) Token: 0x0601426D RID: 82541 RVA: 0x005A04DD File Offset: 0x0059E6DD
	public int Exp { get; set; }
}
