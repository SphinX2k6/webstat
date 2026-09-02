using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C6F RID: 11375
[NullableContext(1)]
[Nullable(0)]
public class UiModelDecorationParam : IUiModelDecorationParam
{
	// Token: 0x17001DE6 RID: 7654
	// (get) Token: 0x06016D0B RID: 93451 RVA: 0x00654CAD File Offset: 0x00652EAD
	// (set) Token: 0x06016D0C RID: 93452 RVA: 0x00654CB5 File Offset: 0x00652EB5
	public string SocketName { get; set; }

	// Token: 0x17001DE7 RID: 7655
	// (get) Token: 0x06016D0D RID: 93453 RVA: 0x00654CBE File Offset: 0x00652EBE
	// (set) Token: 0x06016D0E RID: 93454 RVA: 0x00654CC6 File Offset: 0x00652EC6
	public USkeletalMesh SkeletalMesh { get; set; }

	// Token: 0x17001DE8 RID: 7656
	// (get) Token: 0x06016D0F RID: 93455 RVA: 0x00654CCF File Offset: 0x00652ECF
	// (set) Token: 0x06016D10 RID: 93456 RVA: 0x00654CD7 File Offset: 0x00652ED7
	public FTransform Transform { get; set; }
}
