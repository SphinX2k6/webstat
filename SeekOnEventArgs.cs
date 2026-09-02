using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000033 RID: 51
[NullableContext(2)]
[Nullable(0)]
public struct SeekOnEventArgs
{
	// Token: 0x060000CF RID: 207 RVA: 0x000067C0 File Offset: 0x000049C0
	public SeekOnEventArgs(AActor Actor, int? Handle, bool? SnapToMarker)
	{
		this.Actor = Actor;
		this.Handle = Handle;
		this.SnapToMarker = SnapToMarker;
	}

	// Token: 0x040000B5 RID: 181
	public AActor Actor;

	// Token: 0x040000B6 RID: 182
	public int? Handle;

	// Token: 0x040000B7 RID: 183
	public bool? SnapToMarker;
}
