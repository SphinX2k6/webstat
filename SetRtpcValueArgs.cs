using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000034 RID: 52
[NullableContext(2)]
[Nullable(0)]
public struct SetRtpcValueArgs
{
	// Token: 0x060000D0 RID: 208 RVA: 0x000067D7 File Offset: 0x000049D7
	public SetRtpcValueArgs(int? TransitionDuration, EAudioFadeCurve? TransitionFadeCurve, AActor Actor)
	{
		this.TransitionDuration = TransitionDuration;
		this.TransitionFadeCurve = TransitionFadeCurve;
		this.Actor = Actor;
	}

	// Token: 0x040000B8 RID: 184
	public int? TransitionDuration;

	// Token: 0x040000B9 RID: 185
	public EAudioFadeCurve? TransitionFadeCurve;

	// Token: 0x040000BA RID: 186
	public AActor Actor;
}
