using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EDD RID: 3805
[NullableContext(2)]
public interface ISDKPayObject
{
	// Token: 0x170006E4 RID: 1764
	// (get) Token: 0x06005E00 RID: 24064
	// (set) Token: 0x06005E01 RID: 24065
	ISDKPayment OrderInfo { get; set; }

	// Token: 0x170006E5 RID: 1765
	// (get) Token: 0x06005E02 RID: 24066
	// (set) Token: 0x06005E03 RID: 24067
	ISDKPayRole RoleInfo { get; set; }
}
