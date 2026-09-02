using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.UI.NewModule.UiCameraAnimation;
using UnrealEngine;

// Token: 0x02002C4E RID: 11342
[NullableContext(1)]
[Nullable(0)]
public class UiCameraSpringStructure : UiCameraStructure
{
	// Token: 0x06016BAD RID: 93101 RVA: 0x0064EFA0 File Offset: 0x0064D1A0
	protected override AActor OnSpawnStructureActor()
	{
		UObject world = GlobalData.World;
		FQuat fquat = new FQuat(0f, 0f, 0f, 0f);
		FVector fvector = new FVector(0f);
		FVector fvector2 = new FVector(1f, 1f, 1f);
		FTransform ftransform = new FTransform(ref fquat, ref fvector, ref fvector2);
		BP_UiCameraAnimation_C bp_UiCameraAnimation_C = UGameplayStatics.BeginDeferredActorSpawnFromClass(world, BP_UiCameraAnimation_C.StaticClass(), ftransform, ESpawnActorCollisionHandlingMethod.Undefined, null) as BP_UiCameraAnimation_C;
		bp_UiCameraAnimation_C.SetTickableWhenPaused(true);
		UGameplayStatics.FinishSpawningActor(bp_UiCameraAnimation_C, ftransform);
		this.UiCameraSpringActor = bp_UiCameraAnimation_C;
		USpringArmComponent springArm = this.UiCameraSpringActor.SpringArm;
		if (springArm != null)
		{
			springArm.SetTickableWhenPaused(true);
		}
		UCameraComponent camera = this.UiCameraSpringActor.Camera;
		if (camera != null)
		{
			camera.SetTickableWhenPaused(true);
		}
		return bp_UiCameraAnimation_C;
	}

	// Token: 0x06016BAE RID: 93102 RVA: 0x0064F058 File Offset: 0x0064D258
	protected override USpringArmComponent OnSetSpringArmComponent()
	{
		return this.UiCameraSpringActor.SpringArm;
	}

	// Token: 0x06016BAF RID: 93103 RVA: 0x0064F065 File Offset: 0x0064D265
	protected override void OnInitialize()
	{
	}

	// Token: 0x06016BB0 RID: 93104 RVA: 0x0064F067 File Offset: 0x0064D267
	protected override void OnDestroy()
	{
		Singleton<ActorSystem>.Instance.Put("UiCameraSpringStructure.OnDestroy", this.UiCameraSpringActor, null);
		this.UiCameraSpringActor = null;
	}

	// Token: 0x06016BB1 RID: 93105 RVA: 0x0064F087 File Offset: 0x0064D287
	protected override void OnActivate()
	{
		this.CameraActorAttachToSpringActor();
	}

	// Token: 0x06016BB2 RID: 93106 RVA: 0x0064F08F File Offset: 0x0064D28F
	protected override void OnDeactivate()
	{
		this.CameraActorDetachFromSpringActor();
	}

	// Token: 0x06016BB3 RID: 93107 RVA: 0x0064F098 File Offset: 0x0064D298
	public void CameraActorAttachToSpringActor()
	{
		UCameraComponent camera = this.UiCameraSpringActor.Camera;
		base.AttachToComponent(camera, default(FName), EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld);
	}

	// Token: 0x06016BB4 RID: 93108 RVA: 0x0064F0C4 File Offset: 0x0064D2C4
	public void CameraActorDetachFromSpringActor()
	{
		base.DetachFromComponent(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
	}

	// Token: 0x06016BB5 RID: 93109 RVA: 0x0064F0CF File Offset: 0x0064D2CF
	public BP_UiCameraAnimation_C GetSpringActor()
	{
		return this.UiCameraSpringActor;
	}

	// Token: 0x0400AF3F RID: 44863
	[Nullable(2)]
	private BP_UiCameraAnimation_C UiCameraSpringActor;
}
