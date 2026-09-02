using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007045 RID: 28741
	[NullableContext(1)]
	[Nullable(0)]
	public static class EffectHandleExtension
	{
		// Token: 0x060458CB RID: 284875 RVA: 0x0122D3DE File Offset: 0x0122B5DE
		public static bool IsValid([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.IsValid();
			}
			return self.IsT2 && self.AsT2.IsValid();
		}

		// Token: 0x060458CC RID: 284876 RVA: 0x0122D40D File Offset: 0x0122B60D
		public static void SetActorHiddenInGame([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, bool hiddenInGame)
		{
			if (self.IsT1)
			{
				self.AsT1.SetActorHiddenInGame(hiddenInGame);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.SetActorHiddenInGame(hiddenInGame);
			}
		}

		// Token: 0x060458CD RID: 284877 RVA: 0x0122D43C File Offset: 0x0122B63C
		[NullableContext(2)]
		public static void K2_AttachToActor([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, AActor parent, in FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
		{
			if (self.IsT1)
			{
				self.AsT1.K2_AttachToActor(parent, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.K2_AttachToActor(parent, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, true);
			}
		}

		// Token: 0x060458CE RID: 284878 RVA: 0x0122D4C4 File Offset: 0x0122B6C4
		[NullableContext(2)]
		public static void K2_AttachToComponent([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, USceneComponent parent, FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies)
		{
			if (self.IsT1)
			{
				self.AsT1.K2_AttachToComponent(parent, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.K2_AttachToComponent(parent, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, true);
			}
		}

		// Token: 0x060458CF RID: 284879 RVA: 0x0122D540 File Offset: 0x0122B740
		public static FVectorDouble GetActorLocation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.GetActorLocation();
			}
			if (self.IsT2)
			{
				return self.AsT2.D_K2_GetActorLocation();
			}
			return default(FVectorDouble);
		}

		// Token: 0x060458D0 RID: 284880 RVA: 0x0122D584 File Offset: 0x0122B784
		public static FVectorDouble D_K2_GetActorLocation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.D_K2_GetActorLocation();
			}
			if (self.IsT2)
			{
				return self.AsT2.D_K2_GetActorLocation();
			}
			return default(FVectorDouble);
		}

		// Token: 0x060458D1 RID: 284881 RVA: 0x0122D5C8 File Offset: 0x0122B7C8
		public static FRotator K2_GetActorRotation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.K2_GetActorRotation();
			}
			if (self.IsT2)
			{
				return self.AsT2.K2_GetActorRotation();
			}
			return default(FRotator);
		}

		// Token: 0x060458D2 RID: 284882 RVA: 0x0122D60C File Offset: 0x0122B80C
		public static FVectorDouble D_GetActorScale3D([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self)
		{
			if (self.IsT1)
			{
				return self.AsT1.D_GetActorScale3D();
			}
			if (self.IsT2)
			{
				return self.AsT2.D_GetActorScale3D();
			}
			return default(FVectorDouble);
		}

		// Token: 0x060458D3 RID: 284883 RVA: 0x0122D64E File Offset: 0x0122B84E
		public static bool D_K2_SetActorLocation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FVectorDouble location, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				return self.AsT1.D_K2_SetActorLocation(location, bSweep, ref sweepHitResult, bTeleport);
			}
			return self.IsT2 && self.AsT2.D_K2_SetActorLocation(location, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x060458D4 RID: 284884 RVA: 0x0122D68C File Offset: 0x0122B88C
		public static bool K2_SetActorRotation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FRotator rotation, bool bTeleportPhysics)
		{
			if (self.IsT1)
			{
				return self.AsT1.K2_SetActorRotation(rotation, bTeleportPhysics);
			}
			return self.IsT2 && self.AsT2.K2_SetActorRotation(rotation, bTeleportPhysics);
		}

		// Token: 0x060458D5 RID: 284885 RVA: 0x0122D6C4 File Offset: 0x0122B8C4
		public static void D_SetActorScale3D([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FVectorDouble scale)
		{
			if (self.IsT1)
			{
				self.AsT1.D_SetActorScale3D(scale);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.D_SetActorScale3D(scale);
			}
		}

		// Token: 0x060458D6 RID: 284886 RVA: 0x0122D6F8 File Offset: 0x0122B8F8
		public static bool D_K2_SetActorLocationAndRotation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FVectorDouble location, in FRotator rotation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				return self.AsT1.D_K2_SetActorLocationAndRotation(location, rotation, false, ref sweepHitResult, true);
			}
			return self.IsT2 && self.AsT2.D_K2_SetActorLocationAndRotation(location, rotation, false, ref sweepHitResult, true);
		}

		// Token: 0x060458D7 RID: 284887 RVA: 0x0122D748 File Offset: 0x0122B948
		public static void D_K2_AddActorWorldOffset([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FVectorDouble deltaLocation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				self.AsT1.D_K2_AddActorWorldOffset(deltaLocation, bSweep, ref sweepHitResult, bTeleport);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.D_K2_AddActorWorldOffset(deltaLocation, bSweep, ref sweepHitResult, bTeleport);
			}
		}

		// Token: 0x060458D8 RID: 284888 RVA: 0x0122D784 File Offset: 0x0122B984
		public static bool D_K2_SetActorTransform([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FTransformDouble transform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				return self.AsT1.D_K2_SetActorTransform(transform, bSweep, ref sweepHitResult, bTeleport);
			}
			return self.IsT2 && self.AsT2.D_K2_SetActorTransform(transform, bSweep, ref sweepHitResult, bTeleport);
		}

		// Token: 0x060458D9 RID: 284889 RVA: 0x0122D7BD File Offset: 0x0122B9BD
		public static void D_K2_SetActorRelativeLocation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FVectorDouble relativeLocation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				self.AsT1.D_K2_SetActorRelativeLocation(relativeLocation, bSweep, ref sweepHitResult, bTeleport);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.D_K2_SetActorRelativeLocation(relativeLocation, bSweep, ref sweepHitResult, bTeleport);
			}
		}

		// Token: 0x060458DA RID: 284890 RVA: 0x0122D7F9 File Offset: 0x0122B9F9
		public static void K2_SetActorRelativeRotation([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FRotator relativeRotation, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				self.AsT1.K2_SetActorRelativeRotation(relativeRotation, bSweep, ref sweepHitResult, bTeleport);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.K2_SetActorRelativeRotation(relativeRotation, bSweep, ref sweepHitResult, bTeleport);
			}
		}

		// Token: 0x060458DB RID: 284891 RVA: 0x0122D835 File Offset: 0x0122BA35
		public static void D_K2_SetActorRelativeTransform([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FTransformDouble relativeTransform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				self.AsT1.D_K2_SetActorRelativeTransform(relativeTransform, bSweep, ref sweepHitResult, bTeleport);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.D_K2_SetActorRelativeTransform(relativeTransform, bSweep, ref sweepHitResult, bTeleport);
			}
		}

		// Token: 0x060458DC RID: 284892 RVA: 0x0122D86C File Offset: 0x0122BA6C
		public static void K2_AddActorLocalTransform([Nullable(new byte[]
		{
			0,
			1,
			1
		})] this OneOf<KuroEffectActorHandle, AActor> self, in FTransform transform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport)
		{
			if (self.IsT1)
			{
				self.AsT1.K2_AddActorLocalTransform(transform, bSweep, ref sweepHitResult, bTeleport);
				return;
			}
			if (self.IsT2)
			{
				self.AsT2.K2_AddActorLocalTransform(transform, bSweep, ref sweepHitResult, bTeleport);
			}
		}
	}
}
