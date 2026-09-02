using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC2 RID: 15042
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorSkeletalmeshDestructible.SSceneInteractionActorSkeletalMeshDestructible")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SSceneInteractionActorSkeletalMeshDestructible : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201CD RID: 131533 RVA: 0x0092292F File Offset: 0x00920B2F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionActorSkeletalMeshDestructible._ScriptStructPtr != 0) ? SSceneInteractionActorSkeletalMeshDestructible._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorSkeletalmeshDestructible.SSceneInteractionActorSkeletalMeshDestructible", ref SSceneInteractionActorSkeletalMeshDestructible._ScriptStructPtr);
		}

		// Token: 0x170033FC RID: 13308
		// (get) Token: 0x060201CE RID: 131534 RVA: 0x00922954 File Offset: 0x00920B54
		// (set) Token: 0x060201CF RID: 131535 RVA: 0x00922997 File Offset: 0x00920B97
		public TArray<AKuroDestructibleActor> PlayDestructionAllImmediately
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AKuroDestructibleActor> result;
				if ((result = this._PlayDestructionAllImmediately) == null)
				{
					result = (this._PlayDestructionAllImmediately = new TArray<AKuroDestructibleActor>(base.NativePtr + (IntPtr)SSceneInteractionActorSkeletalMeshDestructible.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PlayDestructionAllImmediately.CopyAssign(value);
			}
		}

		// Token: 0x170033FD RID: 13309
		// (get) Token: 0x060201D0 RID: 131536 RVA: 0x009229A8 File Offset: 0x00920BA8
		// (set) Token: 0x060201D1 RID: 131537 RVA: 0x009229EB File Offset: 0x00920BEB
		public TArray<AKuroDestructibleActor> CanPlayDestructionWhenHit
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AKuroDestructibleActor> result;
				if ((result = this._CanPlayDestructionWhenHit) == null)
				{
					result = (this._CanPlayDestructionWhenHit = new TArray<AKuroDestructibleActor>(base.NativePtr + (IntPtr)SSceneInteractionActorSkeletalMeshDestructible.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CanPlayDestructionWhenHit.CopyAssign(value);
			}
		}

		// Token: 0x170033FE RID: 13310
		// (get) Token: 0x060201D2 RID: 131538 RVA: 0x009229FC File Offset: 0x00920BFC
		// (set) Token: 0x060201D3 RID: 131539 RVA: 0x00922A3F File Offset: 0x00920C3F
		public SSceneInteractionDestructibleInfo HitInfo
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionDestructibleInfo result;
				if ((result = this._HitInfo) == null)
				{
					result = (this._HitInfo = new SSceneInteractionDestructibleInfo(base.NativePtr + (IntPtr)SSceneInteractionActorSkeletalMeshDestructible.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionDestructibleInfo.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionActorSkeletalMeshDestructible.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060201D4 RID: 131540 RVA: 0x00922A60 File Offset: 0x00920C60
		public SSceneInteractionActorSkeletalMeshDestructible()
		{
		}

		// Token: 0x060201D5 RID: 131541 RVA: 0x00922A68 File Offset: 0x00920C68
		public SSceneInteractionActorSkeletalMeshDestructible(TArray<AKuroDestructibleActor> PlayDestructionAllImmediately, TArray<AKuroDestructibleActor> CanPlayDestructionWhenHit, SSceneInteractionDestructibleInfo HitInfo)
		{
			this.PlayDestructionAllImmediately = PlayDestructionAllImmediately;
			this.CanPlayDestructionWhenHit = CanPlayDestructionWhenHit;
			this.HitInfo = HitInfo;
		}

		// Token: 0x060201D6 RID: 131542 RVA: 0x00922A85 File Offset: 0x00920C85
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionActorSkeletalMeshDestructible.StaticStruct();
		}

		// Token: 0x060201D7 RID: 131543 RVA: 0x00922A91 File Offset: 0x00920C91
		[NullableContext(2)]
		public SSceneInteractionActorSkeletalMeshDestructible(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201D8 RID: 131544 RVA: 0x00922A9B File Offset: 0x00920C9B
		public SSceneInteractionActorSkeletalMeshDestructible(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201D9 RID: 131545 RVA: 0x00922AA6 File Offset: 0x00920CA6
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionActorSkeletalMeshDestructible(Pointer, false, true);
		}

		// Token: 0x060201DA RID: 131546 RVA: 0x00922AB0 File Offset: 0x00920CB0
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionActorSkeletalMeshDestructible(Pointer, MemoryOwner);
		}

		// Token: 0x0401000E RID: 65550
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionActorSkeletalmeshDestructible.SSceneInteractionActorSkeletalMeshDestructible";

		// Token: 0x0401000F RID: 65551
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010010 RID: 65552
		internal static int __PropertyOffset_0;

		// Token: 0x04010011 RID: 65553
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AKuroDestructibleActor> _PlayDestructionAllImmediately;

		// Token: 0x04010012 RID: 65554
		internal static int __PropertyOffset_1;

		// Token: 0x04010013 RID: 65555
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AKuroDestructibleActor> _CanPlayDestructionWhenHit;

		// Token: 0x04010014 RID: 65556
		internal static int __PropertyOffset_2;

		// Token: 0x04010015 RID: 65557
		[Nullable(2)]
		private SSceneInteractionDestructibleInfo _HitInfo;
	}
}
