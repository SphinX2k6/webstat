using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000D3C RID: 3388
[NullableContext(1)]
[Nullable(0)]
public class DetectStateBox
{
	// Token: 0x060046F6 RID: 18166 RVA: 0x0009299B File Offset: 0x00090B9B
	public DetectStateBox(UTraceBoxElement boxElement)
	{
		this.BoxElement = boxElement;
	}

	// Token: 0x0400137B RID: 4987
	public Vector Offset = Vector.Create();

	// Token: 0x0400137C RID: 4988
	public Vector CurrentPosition = Vector.Create();

	// Token: 0x0400137D RID: 4989
	public Vector LastFramePosition = Vector.Create();

	// Token: 0x0400137E RID: 4990
	public readonly UTraceBoxElement BoxElement;
}
