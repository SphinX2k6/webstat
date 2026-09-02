using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EBA RID: 3770
[NullableContext(2)]
[Nullable(0)]
public class SdkPayObject : ISDKPayObject
{
	// Token: 0x170006A4 RID: 1700
	// (get) Token: 0x06005D5A RID: 23898 RVA: 0x00177648 File Offset: 0x00175848
	// (set) Token: 0x06005D5B RID: 23899 RVA: 0x00177650 File Offset: 0x00175850
	public ISDKPayment OrderInfo { get; set; }

	// Token: 0x170006A5 RID: 1701
	// (get) Token: 0x06005D5C RID: 23900 RVA: 0x00177659 File Offset: 0x00175859
	// (set) Token: 0x06005D5D RID: 23901 RVA: 0x00177661 File Offset: 0x00175861
	public ISDKPayRole RoleInfo { get; set; }
}
