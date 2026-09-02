using System;
using System.Runtime.CompilerServices;

// Token: 0x020022B9 RID: 8889
[NullableContext(1)]
[Nullable(0)]
public class MotorTechNodeListData : IMotorTechNodeListData
{
	// Token: 0x170014DB RID: 5339
	// (get) Token: 0x06010CB2 RID: 68786 RVA: 0x00498172 File Offset: 0x00496372
	// (set) Token: 0x06010CB3 RID: 68787 RVA: 0x0049817A File Offset: 0x0049637A
	public int[] TopIds { get; set; }

	// Token: 0x170014DC RID: 5340
	// (get) Token: 0x06010CB4 RID: 68788 RVA: 0x00498183 File Offset: 0x00496383
	// (set) Token: 0x06010CB5 RID: 68789 RVA: 0x0049818B File Offset: 0x0049638B
	public int[] BottomIds { get; set; }

	// Token: 0x170014DD RID: 5341
	// (get) Token: 0x06010CB6 RID: 68790 RVA: 0x00498194 File Offset: 0x00496394
	// (set) Token: 0x06010CB7 RID: 68791 RVA: 0x0049819C File Offset: 0x0049639C
	public int MiddleId { get; set; }
}
