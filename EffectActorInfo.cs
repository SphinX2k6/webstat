using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Audio;
using UnrealEngine;

// Token: 0x02000E75 RID: 3701
[NullableContext(1)]
[Nullable(0)]
public class EffectActorInfo : IEffectActorInfo
{
	// Token: 0x17000663 RID: 1635
	// (get) Token: 0x06005A14 RID: 23060 RVA: 0x00160F88 File Offset: 0x0015F188
	// (set) Token: 0x06005A15 RID: 23061 RVA: 0x00160F90 File Offset: 0x0015F190
	public int ActorUid { get; set; }

	// Token: 0x17000664 RID: 1636
	// (get) Token: 0x06005A16 RID: 23062 RVA: 0x00160F99 File Offset: 0x0015F199
	// (set) Token: 0x06005A17 RID: 23063 RVA: 0x00160FA1 File Offset: 0x0015F1A1
	public AActor Actor { get; set; }

	// Token: 0x17000665 RID: 1637
	// (get) Token: 0x06005A18 RID: 23064 RVA: 0x00160FAA File Offset: 0x0015F1AA
	// (set) Token: 0x06005A19 RID: 23065 RVA: 0x00160FB2 File Offset: 0x0015F1B2
	public UAkComponent AkComponent { get; set; }

	// Token: 0x17000666 RID: 1638
	// (get) Token: 0x06005A1A RID: 23066 RVA: 0x00160FBB File Offset: 0x0015F1BB
	// (set) Token: 0x06005A1B RID: 23067 RVA: 0x00160FC3 File Offset: 0x0015F1C3
	public TArray<FVector> Locations { get; set; }

	// Token: 0x17000667 RID: 1639
	// (get) Token: 0x06005A1C RID: 23068 RVA: 0x00160FCC File Offset: 0x0015F1CC
	// (set) Token: 0x06005A1D RID: 23069 RVA: 0x00160FD4 File Offset: 0x0015F1D4
	public HashSet<int> EffectUidList { get; set; }

	// Token: 0x17000668 RID: 1640
	// (get) Token: 0x06005A1E RID: 23070 RVA: 0x00160FDD File Offset: 0x0015F1DD
	// (set) Token: 0x06005A1F RID: 23071 RVA: 0x00160FE5 File Offset: 0x0015F1E5
	public int AudioHandle { get; set; }

	// Token: 0x17000669 RID: 1641
	// (get) Token: 0x06005A20 RID: 23072 RVA: 0x00160FEE File Offset: 0x0015F1EE
	// (set) Token: 0x06005A21 RID: 23073 RVA: 0x00160FF6 File Offset: 0x0015F1F6
	public IAudioInfo EffectModel { get; set; }

	// Token: 0x1700066A RID: 1642
	// (get) Token: 0x06005A22 RID: 23074 RVA: 0x00160FFF File Offset: 0x0015F1FF
	// (set) Token: 0x06005A23 RID: 23075 RVA: 0x00161007 File Offset: 0x0015F207
	public ERoleAudioPriorityType? Priority { get; set; }
}
