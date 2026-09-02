using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluffyBallInteraction
{
	// Token: 0x02003D18 RID: 15640
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluffyBallInteraction/BP_FluffyBall_Interaction.BP_FluffyBall_Interaction_C")]
	[UnrealStructLayout(1472, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1468)]
	public class BP_FluffyBall_Interaction_C : AKuroBPActor, IUnrealUObject, IUnrealObject, IBulletHitActorInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06025C13 RID: 154643 RVA: 0x009C4207 File Offset: 0x009C2407
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FluffyBall_Interaction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluffyBallInteraction/BP_FluffyBall_Interaction.BP_FluffyBall_Interaction_C");
			}
			return BP_FluffyBall_Interaction_C._ClassPtr;
		}

		// Token: 0x06025C14 RID: 154644 RVA: 0x009C422B File Offset: 0x009C242B
		int IBulletHitActorInterface.InterfaceOffset()
		{
			return BP_FluffyBall_Interaction_C.__InterfaceOffset_IBulletHitActorInterface;
		}

		// Token: 0x06025C15 RID: 154645 RVA: 0x009C4234 File Offset: 0x009C2434
		public BP_FluffyBall_Interaction_C() : this(BuiltinUtils.AllocNativeUObject(BP_FluffyBall_Interaction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025C16 RID: 154646 RVA: 0x009C425C File Offset: 0x009C245C
		[NullableContext(1)]
		public BP_FluffyBall_Interaction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FluffyBall_Interaction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700538B RID: 21387
		// (get) Token: 0x06025C17 RID: 154647 RVA: 0x009C4290 File Offset: 0x009C2490
		// (set) Token: 0x06025C18 RID: 154648 RVA: 0x009C42C9 File Offset: 0x009C24C9
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700538C RID: 21388
		// (get) Token: 0x06025C19 RID: 154649 RVA: 0x009C42EA File Offset: 0x009C24EA
		// (set) Token: 0x06025C1A RID: 154650 RVA: 0x009C42FE File Offset: 0x009C24FE
		public unsafe UStaticMeshComponent SM_Dai_Pro_113AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700538D RID: 21389
		// (get) Token: 0x06025C1B RID: 154651 RVA: 0x009C4313 File Offset: 0x009C2513
		// (set) Token: 0x06025C1C RID: 154652 RVA: 0x009C4327 File Offset: 0x009C2527
		public unsafe USphereComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700538E RID: 21390
		// (get) Token: 0x06025C1D RID: 154653 RVA: 0x009C433C File Offset: 0x009C253C
		// (set) Token: 0x06025C1E RID: 154654 RVA: 0x009C4350 File Offset: 0x009C2550
		public unsafe UNiagaraComponent NS_Fx_FluffyBall
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700538F RID: 21391
		// (get) Token: 0x06025C1F RID: 154655 RVA: 0x009C4365 File Offset: 0x009C2565
		// (set) Token: 0x06025C20 RID: 154656 RVA: 0x009C4379 File Offset: 0x009C2579
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17005390 RID: 21392
		// (get) Token: 0x06025C21 RID: 154657 RVA: 0x009C438E File Offset: 0x009C258E
		// (set) Token: 0x06025C22 RID: 154658 RVA: 0x009C439E File Offset: 0x009C259E
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005391 RID: 21393
		// (get) Token: 0x06025C23 RID: 154659 RVA: 0x009C43AF File Offset: 0x009C25AF
		// (set) Token: 0x06025C24 RID: 154660 RVA: 0x009C43C3 File Offset: 0x009C25C3
		public unsafe FVector BulletPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005392 RID: 21394
		// (get) Token: 0x06025C25 RID: 154661 RVA: 0x009C43D8 File Offset: 0x009C25D8
		// (set) Token: 0x06025C26 RID: 154662 RVA: 0x009C43E8 File Offset: 0x009C25E8
		public unsafe bool Hit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005393 RID: 21395
		// (get) Token: 0x06025C27 RID: 154663 RVA: 0x009C43F9 File Offset: 0x009C25F9
		// (set) Token: 0x06025C28 RID: 154664 RVA: 0x009C440D File Offset: 0x009C260D
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17005394 RID: 21396
		// (get) Token: 0x06025C29 RID: 154665 RVA: 0x009C4422 File Offset: 0x009C2622
		// (set) Token: 0x06025C2A RID: 154666 RVA: 0x009C4436 File Offset: 0x009C2636
		public unsafe UMaterialInstanceDynamic DMI_LOD0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FluffyBall_Interaction_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17005395 RID: 21397
		// (get) Token: 0x06025C2B RID: 154667 RVA: 0x009C444B File Offset: 0x009C264B
		// (set) Token: 0x06025C2C RID: 154668 RVA: 0x009C445F File Offset: 0x009C265F
		public unsafe FTransformDouble BaseTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005396 RID: 21398
		// (get) Token: 0x06025C2D RID: 154669 RVA: 0x009C4474 File Offset: 0x009C2674
		// (set) Token: 0x06025C2E RID: 154670 RVA: 0x009C4488 File Offset: 0x009C2688
		public unsafe FVector RotationDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FluffyBall_Interaction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06025C2F RID: 154671 RVA: 0x009C44A0 File Offset: 0x009C26A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParams(float dt)
		{
			BP_FluffyBall_Interaction_C.__UpdateParams_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__UpdateParams_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__UpdateParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__UpdateParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__UpdateParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C30 RID: 154672 RVA: 0x009C44E6 File Offset: 0x009C26E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x06025C31 RID: 154673 RVA: 0x009C44FC File Offset: 0x009C26FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HitDetection(FVectorDouble HitPos)
		{
			BP_FluffyBall_Interaction_C.__HitDetection_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__HitDetection_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__HitDetection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__HitDetection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitPos = HitPos;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__HitDetection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C32 RID: 154674 RVA: 0x009C4545 File Offset: 0x009C2745
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025C33 RID: 154675 RVA: 0x009C4559 File Offset: 0x009C2759
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025C34 RID: 154676 RVA: 0x009C456E File Offset: 0x009C276E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025C35 RID: 154677 RVA: 0x009C4582 File Offset: 0x009C2782
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025C36 RID: 154678 RVA: 0x009C4598 File Offset: 0x009C2798
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C37 RID: 154679 RVA: 0x009C45E0 File Offset: 0x009C27E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C38 RID: 154680 RVA: 0x009C4628 File Offset: 0x009C2828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBulletHit(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025C39 RID: 154681 RVA: 0x009C467C File Offset: 0x009C287C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnBulletHit_Implementation(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C3A RID: 154682 RVA: 0x009C46D0 File Offset: 0x009C28D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FluffyBall_Interaction(int EntryPoint)
		{
			BP_FluffyBall_Interaction_C.__ExecuteUbergraph_BP_FluffyBall_Interaction_FunctionParams* ptr = stackalloc BP_FluffyBall_Interaction_C.__ExecuteUbergraph_BP_FluffyBall_Interaction_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_FluffyBall_Interaction_C.__ExecuteUbergraph_BP_FluffyBall_Interaction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FluffyBall_Interaction_C.__ExecuteUbergraph_BP_FluffyBall_Interaction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FluffyBall_Interaction_C.__ExecuteUbergraph_BP_FluffyBall_Interaction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025C3B RID: 154683 RVA: 0x009C471A File Offset: 0x009C291A
		protected BP_FluffyBall_Interaction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013814 RID: 79892
		internal static int __InterfaceOffset_IBulletHitActorInterface;

		// Token: 0x04013815 RID: 79893
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluffyBallInteraction/BP_FluffyBall_Interaction.BP_FluffyBall_Interaction_C";

		// Token: 0x04013816 RID: 79894
		private static IntPtr _ClassPtr;

		// Token: 0x04013817 RID: 79895
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013818 RID: 79896
		internal static int __PropertyOffset_0;

		// Token: 0x04013819 RID: 79897
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401381A RID: 79898
		internal static int __PropertyOffset_1;

		// Token: 0x0401381B RID: 79899
		internal static int __PropertyOffset_2;

		// Token: 0x0401381C RID: 79900
		internal static int __PropertyOffset_3;

		// Token: 0x0401381D RID: 79901
		internal static int __PropertyOffset_4;

		// Token: 0x0401381E RID: 79902
		internal static int __PropertyOffset_5;

		// Token: 0x0401381F RID: 79903
		internal static int __PropertyOffset_6;

		// Token: 0x04013820 RID: 79904
		internal static int __PropertyOffset_7;

		// Token: 0x04013821 RID: 79905
		internal static int __PropertyOffset_8;

		// Token: 0x04013822 RID: 79906
		internal static int __PropertyOffset_9;

		// Token: 0x04013823 RID: 79907
		internal static int __PropertyOffset_10;

		// Token: 0x04013824 RID: 79908
		internal static int __PropertyOffset_11;

		// Token: 0x04013825 RID: 79909
		private static IntPtr __UpdateParams_NativeFunctionPtr;

		// Token: 0x04013826 RID: 79910
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x04013827 RID: 79911
		private static IntPtr __HitDetection_NativeFunctionPtr;

		// Token: 0x04013828 RID: 79912
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013829 RID: 79913
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401382A RID: 79914
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401382B RID: 79915
		private static IntPtr __OnBulletHit_NativeFunctionPtr;

		// Token: 0x0401382C RID: 79916
		private static IntPtr __ExecuteUbergraph_BP_FluffyBall_Interaction_NativeFunctionPtr;

		// Token: 0x02009FA3 RID: 40867
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __UpdateParams_FunctionParams
		{
			// Token: 0x04032B52 RID: 207698
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009FA4 RID: 40868
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __HitDetection_FunctionParams
		{
			// Token: 0x04032B53 RID: 207699
			[FieldOffset(0)]
			public FVectorDouble HitPos;
		}

		// Token: 0x02009FA5 RID: 40869
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B54 RID: 207700
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009FA6 RID: 40870
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnBulletHit_FunctionParams
		{
			// Token: 0x04032B55 RID: 207701
			[FieldOffset(0)]
			public int BulletEntityId;

			// Token: 0x04032B56 RID: 207702
			[FieldOffset(8)]
			public FVectorDouble HitPoint;
		}

		// Token: 0x02009FA7 RID: 40871
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __ExecuteUbergraph_BP_FluffyBall_Interaction_FunctionParams
		{
			// Token: 0x04032B57 RID: 207703
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
