using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030C2 RID: 12482
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SkeletalMeshComponentPool : SceneComponentPool<USkeletalMeshComponent>
{
	// Token: 0x06019B98 RID: 105368 RVA: 0x0077C8BF File Offset: 0x0077AABF
	protected override void ActiveComponent(USkeletalMeshComponent component)
	{
		component.SetHiddenInGame(false, false);
		component.SetComponentTickEnabled(true);
	}

	// Token: 0x06019B99 RID: 105369 RVA: 0x0077C8D0 File Offset: 0x0077AAD0
	protected override void CleanComponent(USkeletalMeshComponent component)
	{
		component.SetSkeletalMesh(null, true);
		component.SetAnimClass(default(UClassStackOnlyPtr));
		component.SetHiddenInGame(true, false);
		component.SetComponentTickEnabled(false);
	}

	// Token: 0x06019B9A RID: 105370 RVA: 0x0077C904 File Offset: 0x0077AB04
	[NullableContext(2)]
	protected override USkeletalMeshComponent CreateComponent()
	{
		if (!base.CheckPoolRange())
		{
			return null;
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.ActorInternal.AddComponentByClass(USkeletalMeshComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as USkeletalMeshComponent;
		MeshComponentUtils.RelativeAttachComponentOnSafe(uskeletalMeshComponent, this.AttachComponentInternal, "");
		return uskeletalMeshComponent;
	}
}
