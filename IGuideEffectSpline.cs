using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F96 RID: 3990
[NullableContext(1)]
public interface IGuideEffectSpline
{
	// Token: 0x170007E4 RID: 2020
	// (get) Token: 0x060065BF RID: 26047
	// (set) Token: 0x060065C0 RID: 26048
	int EffectHandle { get; set; }

	// Token: 0x170007E5 RID: 2021
	// (get) Token: 0x060065C1 RID: 26049
	// (set) Token: 0x060065C2 RID: 26050
	AActor SplineActor { get; set; }

	// Token: 0x170007E6 RID: 2022
	// (get) Token: 0x060065C3 RID: 26051
	// (set) Token: 0x060065C4 RID: 26052
	USplineComponent SplineComp { get; set; }
}
