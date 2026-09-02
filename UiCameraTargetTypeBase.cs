using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C36 RID: 11318
[NullableContext(1)]
[Nullable(0)]
public abstract class UiCameraTargetTypeBase
{
	// Token: 0x06016AE4 RID: 92900
	[return: Nullable(2)]
	public abstract AActor GetTargetActor(SUiCameraAnimationSettings config);

	// Token: 0x06016AE5 RID: 92901
	[NullableContext(2)]
	public abstract string GetTargetBodyKey();

	// Token: 0x06016AE6 RID: 92902
	[return: Nullable(2)]
	public abstract USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config);
}
