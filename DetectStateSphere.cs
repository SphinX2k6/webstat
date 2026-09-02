using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000D3E RID: 3390
[NullableContext(1)]
[Nullable(0)]
public class DetectStateSphere
{
	// Token: 0x0600471E RID: 18206 RVA: 0x00093463 File Offset: 0x00091663
	public DetectStateSphere(UTraceSphereElement sphereElement)
	{
		this.SphereElement = sphereElement;
	}

	// Token: 0x0400138E RID: 5006
	public readonly Vector Offset = Vector.Create();

	// Token: 0x0400138F RID: 5007
	public readonly Vector CurrentPosition = Vector.Create();

	// Token: 0x04001390 RID: 5008
	public readonly Vector LastFramePosition = Vector.Create();

	// Token: 0x04001391 RID: 5009
	public readonly UTraceSphereElement SphereElement;
}
