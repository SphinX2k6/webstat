using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E62 RID: 11874
[NullableContext(1)]
[Nullable(0)]
public class BuffApplyInfo
{
	// Token: 0x170020C8 RID: 8392
	// (get) Token: 0x06018636 RID: 99894 RVA: 0x006D2F23 File Offset: 0x006D1123
	// (set) Token: 0x06018637 RID: 99895 RVA: 0x006D2F2B File Offset: 0x006D112B
	public long InstigatorId { get; set; }

	// Token: 0x170020C9 RID: 8393
	// (get) Token: 0x06018638 RID: 99896 RVA: 0x006D2F34 File Offset: 0x006D1134
	// (set) Token: 0x06018639 RID: 99897 RVA: 0x006D2F3C File Offset: 0x006D113C
	public ApplyGEType ApplyType { get; set; }

	// Token: 0x170020CA RID: 8394
	// (get) Token: 0x0601863A RID: 99898 RVA: 0x006D2F45 File Offset: 0x006D1145
	// (set) Token: 0x0601863B RID: 99899 RVA: 0x006D2F4D File Offset: 0x006D114D
	public string Reason { get; set; } = string.Empty;
}
