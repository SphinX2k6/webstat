using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003AD0 RID: 15056
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_3_0.BP_InteractFoliageActor_3_0_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1360)]
	public class BP_InteractFoliageActor_3_0_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602030A RID: 131850 RVA: 0x00924AD3 File Offset: 0x00922CD3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractFoliageActor_3_0_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_3_0.BP_InteractFoliageActor_3_0_C");
			}
			return BP_InteractFoliageActor_3_0_C._ClassPtr;
		}

		// Token: 0x0602030B RID: 131851 RVA: 0x00924AF8 File Offset: 0x00922CF8
		public BP_InteractFoliageActor_3_0_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_3_0_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602030C RID: 131852 RVA: 0x00924B20 File Offset: 0x00922D20
		[NullableContext(1)]
		public BP_InteractFoliageActor_3_0_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_3_0_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700345B RID: 13403
		// (get) Token: 0x0602030D RID: 131853 RVA: 0x00924B54 File Offset: 0x00922D54
		// (set) Token: 0x0602030E RID: 131854 RVA: 0x00924B8D File Offset: 0x00922D8D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700345C RID: 13404
		// (get) Token: 0x0602030F RID: 131855 RVA: 0x00924BAE File Offset: 0x00922DAE
		// (set) Token: 0x06020310 RID: 131856 RVA: 0x00924BC2 File Offset: 0x00922DC2
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700345D RID: 13405
		// (get) Token: 0x06020311 RID: 131857 RVA: 0x00924BD7 File Offset: 0x00922DD7
		// (set) Token: 0x06020312 RID: 131858 RVA: 0x00924BEB File Offset: 0x00922DEB
		public unsafe USkeletalMeshComponent SkeletalMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700345E RID: 13406
		// (get) Token: 0x06020313 RID: 131859 RVA: 0x00924C00 File Offset: 0x00922E00
		// (set) Token: 0x06020314 RID: 131860 RVA: 0x00924C14 File Offset: 0x00922E14
		public unsafe UStaticMeshComponent StaticMeshFoliage
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700345F RID: 13407
		// (get) Token: 0x06020315 RID: 131861 RVA: 0x00924C29 File Offset: 0x00922E29
		// (set) Token: 0x06020316 RID: 131862 RVA: 0x00924C3D File Offset: 0x00922E3D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003460 RID: 13408
		// (get) Token: 0x06020317 RID: 131863 RVA: 0x00924C52 File Offset: 0x00922E52
		// (set) Token: 0x06020318 RID: 131864 RVA: 0x00924C66 File Offset: 0x00922E66
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_3_0_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003461 RID: 13409
		// (get) Token: 0x06020319 RID: 131865 RVA: 0x00924C7B File Offset: 0x00922E7B
		// (set) Token: 0x0602031A RID: 131866 RVA: 0x00924C8B File Offset: 0x00922E8B
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003462 RID: 13410
		// (get) Token: 0x0602031B RID: 131867 RVA: 0x00924C9C File Offset: 0x00922E9C
		// (set) Token: 0x0602031C RID: 131868 RVA: 0x00924CAC File Offset: 0x00922EAC
		public unsafe float CachedQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InteractFoliageActor_3_0_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602031D RID: 131869 RVA: 0x00924CC0 File Offset: 0x00922EC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AdaptQualityLevel(ref bool bShouldTick)
		{
			BP_InteractFoliageActor_3_0_C.__AdaptQualityLevel_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__AdaptQualityLevel_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__AdaptQualityLevel_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bShouldTick = bShouldTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__AdaptQualityLevel_NativeFunctionPtr, (void*)ptr);
			bShouldTick = ptr->bShouldTick;
		}

		// Token: 0x0602031E RID: 131870 RVA: 0x00924D10 File Offset: 0x00922F10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeActiveFoliageNum(float ChangeNum)
		{
			BP_InteractFoliageActor_3_0_C.__ChangeActiveFoliageNum_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__ChangeActiveFoliageNum_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__ChangeActiveFoliageNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ChangeNum = ChangeNum;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__ChangeActiveFoliageNum_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602031F RID: 131871 RVA: 0x00924D56 File Offset: 0x00922F56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020320 RID: 131872 RVA: 0x00924D6A File Offset: 0x00922F6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020321 RID: 131873 RVA: 0x00924D7F File Offset: 0x00922F7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020322 RID: 131874 RVA: 0x00924D93 File Offset: 0x00922F93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020323 RID: 131875 RVA: 0x00924DA8 File Offset: 0x00922FA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CallChange(float Weight)
		{
			BP_InteractFoliageActor_3_0_C.__CallChange_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__CallChange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__CallChange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__CallChange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__CallChange_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020324 RID: 131876 RVA: 0x00924DF0 File Offset: 0x00922FF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020325 RID: 131877 RVA: 0x00924EAC File Offset: 0x009230AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020326 RID: 131878 RVA: 0x00924F38 File Offset: 0x00923138
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InteractFoliageActor_3_0(int EntryPoint)
		{
			BP_InteractFoliageActor_3_0_C.__ExecuteUbergraph_BP_InteractFoliageActor_3_0_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_3_0_C.__ExecuteUbergraph_BP_InteractFoliageActor_3_0_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_InteractFoliageActor_3_0_C.__ExecuteUbergraph_BP_InteractFoliageActor_3_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_3_0_C.__ExecuteUbergraph_BP_InteractFoliageActor_3_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InteractFoliageActor_3_0_C.__ExecuteUbergraph_BP_InteractFoliageActor_3_0_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020327 RID: 131879 RVA: 0x00924F82 File Offset: 0x00923182
		protected BP_InteractFoliageActor_3_0_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040100C3 RID: 65731
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_3_0.BP_InteractFoliageActor_3_0_C";

		// Token: 0x040100C4 RID: 65732
		private static IntPtr _ClassPtr;

		// Token: 0x040100C5 RID: 65733
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040100C6 RID: 65734
		internal static int __PropertyOffset_0;

		// Token: 0x040100C7 RID: 65735
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040100C8 RID: 65736
		internal static int __PropertyOffset_1;

		// Token: 0x040100C9 RID: 65737
		internal static int __PropertyOffset_2;

		// Token: 0x040100CA RID: 65738
		internal static int __PropertyOffset_3;

		// Token: 0x040100CB RID: 65739
		internal static int __PropertyOffset_4;

		// Token: 0x040100CC RID: 65740
		internal static int __PropertyOffset_5;

		// Token: 0x040100CD RID: 65741
		internal static int __PropertyOffset_6;

		// Token: 0x040100CE RID: 65742
		internal static int __PropertyOffset_7;

		// Token: 0x040100CF RID: 65743
		private static IntPtr __AdaptQualityLevel_NativeFunctionPtr;

		// Token: 0x040100D0 RID: 65744
		private static IntPtr __ChangeActiveFoliageNum_NativeFunctionPtr;

		// Token: 0x040100D1 RID: 65745
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040100D2 RID: 65746
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040100D3 RID: 65747
		private static IntPtr __CallChange_NativeFunctionPtr;

		// Token: 0x040100D4 RID: 65748
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100D5 RID: 65749
		private static IntPtr __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040100D6 RID: 65750
		private static IntPtr __ExecuteUbergraph_BP_InteractFoliageActor_3_0_NativeFunctionPtr;

		// Token: 0x0200996A RID: 39274
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AdaptQualityLevel_FunctionParams
		{
			// Token: 0x04031FE0 RID: 204768
			[FieldOffset(0)]
			public bool bShouldTick;
		}

		// Token: 0x0200996B RID: 39275
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __ChangeActiveFoliageNum_FunctionParams
		{
			// Token: 0x04031FE1 RID: 204769
			[FieldOffset(0)]
			public float ChangeNum;
		}

		// Token: 0x0200996C RID: 39276
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __CallChange_FunctionParams
		{
			// Token: 0x04031FE2 RID: 204770
			[FieldOffset(0)]
			public float Weight;
		}

		// Token: 0x0200996D RID: 39277
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FE3 RID: 204771
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FE4 RID: 204772
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FE5 RID: 204773
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FE6 RID: 204774
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031FE7 RID: 204775
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031FE8 RID: 204776
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x0200996E RID: 39278
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_InteractFoliageActor_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031FE9 RID: 204777
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031FEA RID: 204778
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031FEB RID: 204779
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031FEC RID: 204780
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x0200996F RID: 39279
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __ExecuteUbergraph_BP_InteractFoliageActor_3_0_FunctionParams
		{
			// Token: 0x04031FED RID: 204781
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
