using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02002C4F RID: 11343
[NullableContext(2)]
[Nullable(0)]
public class UiCameraStructure
{
	// Token: 0x06016BB7 RID: 93111 RVA: 0x0064F0DF File Offset: 0x0064D2DF
	[NullableContext(1)]
	public void Initialize(UiCamera ownerUiCamera)
	{
		this.OwnerUiCamera = ownerUiCamera;
		this.CameraActor = this.OwnerUiCamera.GetCameraActor();
		this.OwnActor = this.OnSpawnStructureActor();
		this.SpringArmComponent = this.OnSetSpringArmComponent();
		this.OnInitialize();
	}

	// Token: 0x06016BB8 RID: 93112 RVA: 0x0064F117 File Offset: 0x0064D317
	public void Destroy()
	{
		this.Deactivate();
		this.OnDestroy();
		this.CameraActor = null;
		this.OwnActor = null;
	}

	// Token: 0x06016BB9 RID: 93113 RVA: 0x0064F133 File Offset: 0x0064D333
	public bool IsValid()
	{
		return this.CameraActor != null && this.OwnActor != null && this.CameraActor.IsValid() && this.OwnActor.IsValid();
	}

	// Token: 0x06016BBA RID: 93114 RVA: 0x0064F164 File Offset: 0x0064D364
	public void Activate()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "激活相机结构";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnActivate();
	}

	// Token: 0x06016BBB RID: 93115 RVA: 0x0064F1A8 File Offset: 0x0064D3A8
	public void Deactivate()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "休眠相机结构";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnDeactivate();
	}

	// Token: 0x06016BBC RID: 93116 RVA: 0x0064F1EC File Offset: 0x0064D3EC
	protected virtual void OnActivate()
	{
	}

	// Token: 0x06016BBD RID: 93117 RVA: 0x0064F1EE File Offset: 0x0064D3EE
	protected virtual void OnDeactivate()
	{
	}

	// Token: 0x06016BBE RID: 93118 RVA: 0x0064F1F0 File Offset: 0x0064D3F0
	protected virtual AActor OnSpawnStructureActor()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "没有创建StructureActor";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06016BBF RID: 93119 RVA: 0x0064F230 File Offset: 0x0064D430
	protected virtual USpringArmComponent OnSetSpringArmComponent()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiCamera;
		ELogAuthor author = ELogAuthor.BB;
		string message = "没有实现OnSetSpringArmComponent";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06016BC0 RID: 93120 RVA: 0x0064F26F File Offset: 0x0064D46F
	[NullableContext(1)]
	public USpringArmComponent GetSpringArmComponent()
	{
		return this.SpringArmComponent;
	}

	// Token: 0x06016BC1 RID: 93121 RVA: 0x0064F277 File Offset: 0x0064D477
	protected virtual void OnInitialize()
	{
	}

	// Token: 0x06016BC2 RID: 93122 RVA: 0x0064F279 File Offset: 0x0064D479
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x06016BC3 RID: 93123 RVA: 0x0064F27C File Offset: 0x0064D47C
	[NullableContext(1)]
	protected void AttachToComponent(USceneComponent sceneComponent, FName slotName = default(FName), EAttachmentRule locationRule = EAttachmentRule.SnapToTarget, EAttachmentRule rotationRule = EAttachmentRule.SnapToTarget, EAttachmentRule scaleRule = EAttachmentRule.KeepWorld)
	{
		if (slotName.Equals(default(FName)))
		{
			slotName = FNameUtil.NONE;
		}
		BP_CineCamera_C cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		this.CameraActor.K2_AttachToComponent(sceneComponent, slotName, locationRule, rotationRule, scaleRule, false, true);
	}

	// Token: 0x06016BC4 RID: 93124 RVA: 0x0064F2CE File Offset: 0x0064D4CE
	protected void DetachFromComponent(EDetachmentRule locationRule = EDetachmentRule.KeepWorld, EDetachmentRule rotationRule = EDetachmentRule.KeepWorld, EDetachmentRule scaleRule = EDetachmentRule.KeepWorld)
	{
		BP_CineCamera_C cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		this.CameraActor.K2_DetachFromActor(locationRule, rotationRule, scaleRule);
	}

	// Token: 0x06016BC5 RID: 93125 RVA: 0x0064F2F6 File Offset: 0x0064D4F6
	public void DetachUiCameraSpringActor(EDetachmentRule locationRule, EDetachmentRule rotationRule, EDetachmentRule scaleRule)
	{
		AActor ownActor = this.OwnActor;
		if (ownActor == null)
		{
			return;
		}
		ownActor.K2_DetachFromActor(locationRule, rotationRule, scaleRule);
	}

	// Token: 0x06016BC6 RID: 93126 RVA: 0x0064F30C File Offset: 0x0064D50C
	public void SetActorTransform(FTransformDouble transform)
	{
		FHitResult fhitResult = new FHitResult();
		this.OwnActor.D_K2_SetActorTransform(transform, false, ref fhitResult, false);
	}

	// Token: 0x06016BC7 RID: 93127 RVA: 0x0064F334 File Offset: 0x0064D534
	public void SetActorLocation(FVectorDouble location)
	{
		if (this.OwnActor.D_K2_GetActorLocation().Equals(location, 1E-08))
		{
			return;
		}
		FHitResult fhitResult = new FHitResult();
		this.OwnActor.D_K2_SetActorLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x06016BC8 RID: 93128 RVA: 0x0064F37C File Offset: 0x0064D57C
	public void SetActorRelativeLocation(FVectorDouble location)
	{
		FHitResult fhitResult = new FHitResult();
		if (this.OwnActor.GetParentComponent() != null)
		{
			this.OwnActor.D_K2_SetActorRelativeLocation(location, false, ref fhitResult, false);
			return;
		}
		this.OwnActor.D_K2_SetActorLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x06016BC9 RID: 93129 RVA: 0x0064F3C0 File Offset: 0x0064D5C0
	public void SetCameraActorRelativeLocation(FVectorDouble location)
	{
		FHitResult fhitResult = new FHitResult();
		this.CameraActor.D_K2_SetActorRelativeLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x06016BCA RID: 93130 RVA: 0x0064F3E3 File Offset: 0x0064D5E3
	public void SetActorRotation(FRotator rotation)
	{
		if (UKismetMathLibrary.EqualEqual_RotatorRotator(this.OwnActor.K2_GetActorRotation(), rotation, 0.0001f))
		{
			return;
		}
		this.OwnActor.K2_SetActorRotation(rotation, false);
	}

	// Token: 0x06016BCB RID: 93131 RVA: 0x0064F40C File Offset: 0x0064D60C
	public void SetActorLocationAndRotation(FVectorDouble location, FRotator rotation)
	{
		FHitResult fhitResult = new FHitResult();
		this.OwnActor.D_K2_SetActorLocationAndRotation(location, rotation, true, ref fhitResult, false);
	}

	// Token: 0x06016BCC RID: 93132 RVA: 0x0064F434 File Offset: 0x0064D634
	public void SetUiCameraAnimationRelativeRotation(FRotator rotation)
	{
		FHitResult fhitResult = new FHitResult();
		this.OwnActor.K2_SetActorRelativeRotation(rotation, false, ref fhitResult, false);
	}

	// Token: 0x06016BCD RID: 93133 RVA: 0x0064F458 File Offset: 0x0064D658
	public void SetSprintArmRelativeRotation(FRotator rotation)
	{
		FHitResult fhitResult = new FHitResult();
		this.SpringArmComponent.K2_SetRelativeRotation(rotation, false, ref fhitResult, false);
	}

	// Token: 0x06016BCE RID: 93134 RVA: 0x0064F47C File Offset: 0x0064D67C
	public void SetSpringArmRelativeLocation(FVectorDouble location)
	{
		FHitResult fhitResult = new FHitResult();
		this.SpringArmComponent.D_K2_SetRelativeLocation(location, false, ref fhitResult, false);
	}

	// Token: 0x06016BCF RID: 93135 RVA: 0x0064F49F File Offset: 0x0064D69F
	public void SetCollisionTest(bool bCollisionTest)
	{
		this.SpringArmComponent.bDoCollisionTest = bCollisionTest;
	}

	// Token: 0x06016BD0 RID: 93136 RVA: 0x0064F4AD File Offset: 0x0064D6AD
	public void SetSpringArmLength(float length)
	{
		this.SpringArmComponent.TargetArmLength = length;
	}

	// Token: 0x06016BD1 RID: 93137 RVA: 0x0064F4BB File Offset: 0x0064D6BB
	public float GetSpringArmLength()
	{
		return this.SpringArmComponent.TargetArmLength;
	}

	// Token: 0x06016BD2 RID: 93138 RVA: 0x0064F4C8 File Offset: 0x0064D6C8
	public FVectorDouble GetSpringRelativeLocation()
	{
		FVector relativeLocation = this.SpringArmComponent.RelativeLocation;
		return new FVectorDouble(ref relativeLocation);
	}

	// Token: 0x06016BD3 RID: 93139 RVA: 0x0064F4E8 File Offset: 0x0064D6E8
	public FRotator GetSpringRelativeRotation()
	{
		return this.SpringArmComponent.RelativeRotation;
	}

	// Token: 0x06016BD4 RID: 93140 RVA: 0x0064F4F5 File Offset: 0x0064D6F5
	public FVectorDouble GetActorLocation()
	{
		return this.OwnActor.D_K2_GetActorLocation();
	}

	// Token: 0x06016BD5 RID: 93141 RVA: 0x0064F502 File Offset: 0x0064D702
	public FRotator GetActorRotation()
	{
		return this.OwnActor.K2_GetActorRotation();
	}

	// Token: 0x06016BD6 RID: 93142 RVA: 0x0064F50F File Offset: 0x0064D70F
	[NullableContext(1)]
	public AActor GetOwnActor()
	{
		return this.OwnActor;
	}

	// Token: 0x0400AF40 RID: 44864
	private UiCamera OwnerUiCamera;

	// Token: 0x0400AF41 RID: 44865
	protected BP_CineCamera_C CameraActor;

	// Token: 0x0400AF42 RID: 44866
	protected USpringArmComponent SpringArmComponent;

	// Token: 0x0400AF43 RID: 44867
	protected AActor OwnActor;
}
