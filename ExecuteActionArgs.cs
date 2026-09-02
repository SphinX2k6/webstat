using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000032 RID: 50
[NullableContext(2)]
[Nullable(0)]
public struct ExecuteActionArgs
{
	// Token: 0x060000CE RID: 206 RVA: 0x000067A9 File Offset: 0x000049A9
	public ExecuteActionArgs(int? TransitionDuration, EAudioFadeCurve? TransitionFadeCurve, AActor Actor)
	{
		this.TransitionDuration = TransitionDuration;
		this.TransitionFadeCurve = TransitionFadeCurve;
		this.Actor = Actor;
	}

	// Token: 0x040000B2 RID: 178
	public int? TransitionDuration;

	// Token: 0x040000B3 RID: 179
	public EAudioFadeCurve? TransitionFadeCurve;

	// Token: 0x040000B4 RID: 180
	public AActor Actor;
}
