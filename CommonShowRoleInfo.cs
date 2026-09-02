using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D01 RID: 7425
[NullableContext(1)]
[Nullable(0)]
public class CommonShowRoleInfo : ICommonShowRoleInfo
{
	// Token: 0x1700115F RID: 4447
	// (get) Token: 0x0600D9FE RID: 55806 RVA: 0x003A7A9D File Offset: 0x003A5C9D
	// (set) Token: 0x0600D9FF RID: 55807 RVA: 0x003A7AA5 File Offset: 0x003A5CA5
	public IGachaViewOpenData ResultViewData { get; set; }

	// Token: 0x17001160 RID: 4448
	// (get) Token: 0x0600DA00 RID: 55808 RVA: 0x003A7AAE File Offset: 0x003A5CAE
	// (set) Token: 0x0600DA01 RID: 55809 RVA: 0x003A7AB6 File Offset: 0x003A5CB6
	public GachaResult[] GachaResult { get; set; }
}
