using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C6E RID: 11374
[NullableContext(1)]
public interface IUiModelDecorationParam
{
	// Token: 0x17001DE3 RID: 7651
	// (get) Token: 0x06016D05 RID: 93445
	// (set) Token: 0x06016D06 RID: 93446
	string SocketName { get; set; }

	// Token: 0x17001DE4 RID: 7652
	// (get) Token: 0x06016D07 RID: 93447
	// (set) Token: 0x06016D08 RID: 93448
	USkeletalMesh SkeletalMesh { get; set; }

	// Token: 0x17001DE5 RID: 7653
	// (get) Token: 0x06016D09 RID: 93449
	// (set) Token: 0x06016D0A RID: 93450
	FTransform Transform { get; set; }
}
