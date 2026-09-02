using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E80 RID: 11904
[NullableContext(1)]
[Nullable(0)]
public class BuffModifierData : IBuffModifierData
{
	// Token: 0x170020FD RID: 8445
	// (get) Token: 0x06018767 RID: 100199 RVA: 0x006DA2C5 File Offset: 0x006D84C5
	// (set) Token: 0x06018768 RID: 100200 RVA: 0x006DA2CD File Offset: 0x006D84CD
	public EAttributeType AttributeId { get; set; }

	// Token: 0x170020FE RID: 8446
	// (get) Token: 0x06018769 RID: 100201 RVA: 0x006DA2D6 File Offset: 0x006D84D6
	// (set) Token: 0x0601876A RID: 100202 RVA: 0x006DA2DE File Offset: 0x006D84DE
	public float[] Value1 { get; set; } = Array.Empty<float>();

	// Token: 0x170020FF RID: 8447
	// (get) Token: 0x0601876B RID: 100203 RVA: 0x006DA2E7 File Offset: 0x006D84E7
	// (set) Token: 0x0601876C RID: 100204 RVA: 0x006DA2EF File Offset: 0x006D84EF
	public float[] Value2 { get; set; } = Array.Empty<float>();

	// Token: 0x17002100 RID: 8448
	// (get) Token: 0x0601876D RID: 100205 RVA: 0x006DA2F8 File Offset: 0x006D84F8
	// (set) Token: 0x0601876E RID: 100206 RVA: 0x006DA300 File Offset: 0x006D8500
	public int[] CalculationPolicy { get; set; } = Array.Empty<int>();
}
