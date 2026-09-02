using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D00 RID: 7424
[NullableContext(1)]
public interface ICommonShowRoleInfo
{
	// Token: 0x1700115D RID: 4445
	// (get) Token: 0x0600D9FA RID: 55802
	// (set) Token: 0x0600D9FB RID: 55803
	IGachaViewOpenData ResultViewData { get; set; }

	// Token: 0x1700115E RID: 4446
	// (get) Token: 0x0600D9FC RID: 55804
	// (set) Token: 0x0600D9FD RID: 55805
	GachaResult[] GachaResult { get; set; }
}
