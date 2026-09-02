using System;
using System.Runtime.CompilerServices;

// Token: 0x020020E8 RID: 8424
[NullableContext(1)]
[Nullable(0)]
public class LoginInfo : ILoginInfo
{
	// Token: 0x1700135F RID: 4959
	// (get) Token: 0x0601016A RID: 65898 RVA: 0x0046A1ED File Offset: 0x004683ED
	// (set) Token: 0x0601016B RID: 65899 RVA: 0x0046A1F5 File Offset: 0x004683F5
	public int LoginCode { get; set; }

	// Token: 0x17001360 RID: 4960
	// (get) Token: 0x0601016C RID: 65900 RVA: 0x0046A1FE File Offset: 0x004683FE
	// (set) Token: 0x0601016D RID: 65901 RVA: 0x0046A206 File Offset: 0x00468406
	public string Uid { get; set; }

	// Token: 0x17001361 RID: 4961
	// (get) Token: 0x0601016E RID: 65902 RVA: 0x0046A20F File Offset: 0x0046840F
	// (set) Token: 0x0601016F RID: 65903 RVA: 0x0046A217 File Offset: 0x00468417
	public string UserName { get; set; }

	// Token: 0x17001362 RID: 4962
	// (get) Token: 0x06010170 RID: 65904 RVA: 0x0046A220 File Offset: 0x00468420
	// (set) Token: 0x06010171 RID: 65905 RVA: 0x0046A228 File Offset: 0x00468428
	public string Token { get; set; }
}
