using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F97 RID: 3991
[NullableContext(1)]
[Nullable(0)]
public class GuideEffectSpline : IGuideEffectSpline
{
	// Token: 0x170007E7 RID: 2023
	// (get) Token: 0x060065C5 RID: 26053 RVA: 0x001996EE File Offset: 0x001978EE
	// (set) Token: 0x060065C6 RID: 26054 RVA: 0x001996F6 File Offset: 0x001978F6
	public int EffectHandle { get; set; }

	// Token: 0x170007E8 RID: 2024
	// (get) Token: 0x060065C7 RID: 26055 RVA: 0x001996FF File Offset: 0x001978FF
	// (set) Token: 0x060065C8 RID: 26056 RVA: 0x00199707 File Offset: 0x00197907
	public AActor SplineActor { get; set; }

	// Token: 0x170007E9 RID: 2025
	// (get) Token: 0x060065C9 RID: 26057 RVA: 0x00199710 File Offset: 0x00197910
	// (set) Token: 0x060065CA RID: 26058 RVA: 0x00199718 File Offset: 0x00197918
	public USplineComponent SplineComp { get; set; }
}
