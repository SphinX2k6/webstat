using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002FF8 RID: 12280
[NullableContext(2)]
[Nullable(0)]
public class IStopMontageParam : IActionParamMap
{
	// Token: 0x170021AE RID: 8622
	// (get) Token: 0x06019057 RID: 102487 RVA: 0x0071981C File Offset: 0x00717A1C
	// (set) Token: 0x06019058 RID: 102488 RVA: 0x00719824 File Offset: 0x00717A24
	public EStopMethod? Method { get; set; }

	// Token: 0x170021AF RID: 8623
	// (get) Token: 0x06019059 RID: 102489 RVA: 0x0071982D File Offset: 0x00717A2D
	// (set) Token: 0x0601905A RID: 102490 RVA: 0x00719835 File Offset: 0x00717A35
	public UAnimMontage Montage { get; set; }

	// Token: 0x170021B0 RID: 8624
	// (get) Token: 0x0601905B RID: 102491 RVA: 0x0071983E File Offset: 0x00717A3E
	// (set) Token: 0x0601905C RID: 102492 RVA: 0x00719846 File Offset: 0x00717A46
	public int? HandleId { get; set; }

	// Token: 0x170021B1 RID: 8625
	// (get) Token: 0x0601905D RID: 102493 RVA: 0x0071984F File Offset: 0x00717A4F
	// (set) Token: 0x0601905E RID: 102494 RVA: 0x00719857 File Offset: 0x00717A57
	public float? BlendOutTime { get; set; }

	// Token: 0x170021B2 RID: 8626
	// (get) Token: 0x0601905F RID: 102495 RVA: 0x00719860 File Offset: 0x00717A60
	// (set) Token: 0x06019060 RID: 102496 RVA: 0x00719868 File Offset: 0x00717A68
	public float? Delay { get; set; }

	// Token: 0x170021B3 RID: 8627
	// (get) Token: 0x06019061 RID: 102497 RVA: 0x00719871 File Offset: 0x00717A71
	// (set) Token: 0x06019062 RID: 102498 RVA: 0x00719879 File Offset: 0x00717A79
	public bool? ImmediatelyCallback { get; set; }
}
