using System;

// Token: 0x02001A28 RID: 6696
public class SmallItemGridLockAndDeprecate : ISmallItemGridLockAndDeprecate
{
	// Token: 0x17000FB3 RID: 4019
	// (get) Token: 0x0600C00C RID: 49164 RVA: 0x0032C5AC File Offset: 0x0032A7AC
	// (set) Token: 0x0600C00D RID: 49165 RVA: 0x0032C5B4 File Offset: 0x0032A7B4
	public bool? IsLock { get; set; }

	// Token: 0x17000FB4 RID: 4020
	// (get) Token: 0x0600C00E RID: 49166 RVA: 0x0032C5BD File Offset: 0x0032A7BD
	// (set) Token: 0x0600C00F RID: 49167 RVA: 0x0032C5C5 File Offset: 0x0032A7C5
	public bool? IsDeprecate { get; set; }
}
