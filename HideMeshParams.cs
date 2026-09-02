using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000D51 RID: 3409
[NullableContext(1)]
[Nullable(0)]
public class HideMeshParams
{
	// Token: 0x0600484F RID: 18511 RVA: 0x00098CEB File Offset: 0x00096EEB
	public HideMeshParams(UMeshComponent meshComp)
	{
		this.MeshComp = meshComp;
	}

	// Token: 0x0400141B RID: 5147
	public readonly List<AActor> Children = new List<AActor>();

	// Token: 0x0400141C RID: 5148
	public int HideKey;

	// Token: 0x0400141D RID: 5149
	public UMeshComponent MeshComp;
}
