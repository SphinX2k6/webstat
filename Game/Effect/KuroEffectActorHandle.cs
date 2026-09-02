using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200704C RID: 28748
	[NullableContext(1)]
	[Nullable(0)]
	public class KuroEffectActorHandle
	{
		// Token: 0x06045953 RID: 285011 RVA: 0x0122E42C File Offset: 0x0122C62C
		public KuroEffectActorHandle(int id)
		{
		}

		// Token: 0x06045954 RID: 285012 RVA: 0x0122E43B File Offset: 0x0122C63B
		public bool IsValid()
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_IsValid(this.<id>P);
		}

		// Token: 0x06045955 RID: 285013 RVA: 0x0122E448 File Offset: 0x0122C648
		public void SetActorHiddenInGame(bool hiddenInGame)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_SetActorHiddenInGame(this.<id>P, hiddenInGame);
		}

		// Token: 0x06045956 RID: 285014 RVA: 0x0122E456 File Offset: 0x0122C656
		[NullableContext(2)]
		public void K2_AttachToActor(AActor parent, FName socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_AttachToActor(this.<id>P, parent, socketName, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
		}

		// Token: 0x06045957 RID: 285015 RVA: 0x0122E46D File Offset: 0x0122C66D
		[NullableContext(2)]
		public void K2_AttachToComponent(USceneComponent parent, FName socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_AttachToComponent(this.<id>P, parent, socketName, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
		}

		// Token: 0x06045958 RID: 285016 RVA: 0x0122E484 File Offset: 0x0122C684
		public FVectorDouble GetActorLocation()
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_GetActorLocation(this.<id>P);
		}

		// Token: 0x06045959 RID: 285017 RVA: 0x0122E491 File Offset: 0x0122C691
		public FVectorDouble D_K2_GetActorLocation()
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_GetActorLocation(this.<id>P);
		}

		// Token: 0x0604595A RID: 285018 RVA: 0x0122E49E File Offset: 0x0122C69E
		public FRotator K2_GetActorRotation()
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_GetActorRotation(this.<id>P);
		}

		// Token: 0x0604595B RID: 285019 RVA: 0x0122E4AB File Offset: 0x0122C6AB
		public FVectorDouble D_GetActorScale3D()
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_GetActorScale3D(this.<id>P);
		}

		// Token: 0x0604595C RID: 285020 RVA: 0x0122E4B8 File Offset: 0x0122C6B8
		public bool D_K2_SetActorLocation(in FVectorDouble location, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			sweepHitResult = new FHitResult();
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_SetActorLocation(this.<id>P, location, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x0604595D RID: 285021 RVA: 0x0122E4D1 File Offset: 0x0122C6D1
		public bool K2_SetActorRotation(in FRotator rotation, bool bTeleportPhysics)
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_SetActorRotation(this.<id>P, rotation, bTeleportPhysics);
		}

		// Token: 0x0604595E RID: 285022 RVA: 0x0122E4E0 File Offset: 0x0122C6E0
		public void D_SetActorScale3D(in FVectorDouble scale)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_SetActorScale3D(this.<id>P, scale);
		}

		// Token: 0x0604595F RID: 285023 RVA: 0x0122E4EE File Offset: 0x0122C6EE
		public bool D_K2_SetActorLocationAndRotation(in FVectorDouble location, in FRotator rotation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_SetActorLocationAndRotation(this.<id>P, location, rotation, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045960 RID: 285024 RVA: 0x0122E502 File Offset: 0x0122C702
		public void D_K2_AddActorWorldOffset(in FVectorDouble deltaLocation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_AddActorWorldOffset(this.<id>P, deltaLocation, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045961 RID: 285025 RVA: 0x0122E514 File Offset: 0x0122C714
		public bool D_K2_SetActorTransform(in FTransformDouble transform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			return UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_SetActorTransform(this.<id>P, transform, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045962 RID: 285026 RVA: 0x0122E526 File Offset: 0x0122C726
		public void D_K2_SetActorRelativeLocation(in FVectorDouble relativeLocation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_SetActorRelativeLocation(this.<id>P, relativeLocation, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045963 RID: 285027 RVA: 0x0122E538 File Offset: 0x0122C738
		public void K2_SetActorRelativeRotation(in FRotator relativeRotation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_SetActorRelativeRotation(this.<id>P, relativeRotation, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045964 RID: 285028 RVA: 0x0122E54A File Offset: 0x0122C74A
		public void D_K2_SetActorRelativeTransform(in FTransformDouble relativeTransform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_D_K2_SetActorRelativeTransform(this.<id>P, relativeTransform, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x06045965 RID: 285029 RVA: 0x0122E55C File Offset: 0x0122C75C
		public void K2_AddActorLocalTransform(in FTransform transform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			UKuroEffectSystemHandleHelperLibrary.ActorHandle_K2_AddActorLocalTransform(this.<id>P, transform, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x04026D82 RID: 159106
		[CompilerGenerated]
		private int <id>P = id;
	}
}
