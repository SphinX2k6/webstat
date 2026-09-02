using System;
using System.Runtime.CompilerServices;

// Token: 0x0200328E RID: 12942
[NullableContext(1)]
[Nullable(0)]
public class WaterfallMoveParams : IWaterfallMoveParams
{
	// Token: 0x170024DE RID: 9438
	// (get) Token: 0x0601B177 RID: 110967 RVA: 0x0081EC3D File Offset: 0x0081CE3D
	// (set) Token: 0x0601B178 RID: 110968 RVA: 0x0081EC45 File Offset: 0x0081CE45
	public int SplineId { get; set; }

	// Token: 0x170024DF RID: 9439
	// (get) Token: 0x0601B179 RID: 110969 RVA: 0x0081EC4E File Offset: 0x0081CE4E
	// (set) Token: 0x0601B17A RID: 110970 RVA: 0x0081EC56 File Offset: 0x0081CE56
	public Vector Direct { get; set; }

	// Token: 0x170024E0 RID: 9440
	// (get) Token: 0x0601B17B RID: 110971 RVA: 0x0081EC5F File Offset: 0x0081CE5F
	// (set) Token: 0x0601B17C RID: 110972 RVA: 0x0081EC67 File Offset: 0x0081CE67
	[Nullable(2)]
	public Vector ChangeGravity { [NullableContext(2)] get; [NullableContext(2)] set; }
}
