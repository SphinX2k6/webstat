using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020025B6 RID: 9654
[NullableContext(1)]
[Nullable(0)]
public class PartConditionResult : IPartConditionResult
{
	// Token: 0x170017A1 RID: 6049
	// (get) Token: 0x06012D6C RID: 77164 RVA: 0x00534F33 File Offset: 0x00533133
	// (set) Token: 0x06012D6D RID: 77165 RVA: 0x00534F3B File Offset: 0x0053313B
	public bool Satisfied { get; set; }

	// Token: 0x170017A2 RID: 6050
	// (get) Token: 0x06012D6E RID: 77166 RVA: 0x00534F44 File Offset: 0x00533144
	// (set) Token: 0x06012D6F RID: 77167 RVA: 0x00534F4C File Offset: 0x0053314C
	public List<Vector> PartPositions { get; set; } = new List<Vector>();
}
