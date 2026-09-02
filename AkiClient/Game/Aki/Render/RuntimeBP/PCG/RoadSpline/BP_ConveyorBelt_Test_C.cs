using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B95 RID: 15253
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt_Test.BP_ConveyorBelt_Test_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1352)]
	public class BP_ConveyorBelt_Test_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021D3A RID: 138554 RVA: 0x00954B17 File Offset: 0x00952D17
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ConveyorBelt_Test_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt_Test.BP_ConveyorBelt_Test_C");
			}
			return BP_ConveyorBelt_Test_C._ClassPtr;
		}

		// Token: 0x06021D3B RID: 138555 RVA: 0x00954B3C File Offset: 0x00952D3C
		public BP_ConveyorBelt_Test_C() : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_Test_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021D3C RID: 138556 RVA: 0x00954B64 File Offset: 0x00952D64
		[NullableContext(1)]
		public BP_ConveyorBelt_Test_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ConveyorBelt_Test_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D3B RID: 15675
		// (get) Token: 0x06021D3D RID: 138557 RVA: 0x00954B98 File Offset: 0x00952D98
		// (set) Token: 0x06021D3E RID: 138558 RVA: 0x00954BD1 File Offset: 0x00952DD1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ConveyorBelt_Test_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ConveyorBelt_Test_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D3C RID: 15676
		// (get) Token: 0x06021D3F RID: 138559 RVA: 0x00954BF2 File Offset: 0x00952DF2
		// (set) Token: 0x06021D40 RID: 138560 RVA: 0x00954C06 File Offset: 0x00952E06
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D3D RID: 15677
		// (get) Token: 0x06021D41 RID: 138561 RVA: 0x00954C1B File Offset: 0x00952E1B
		// (set) Token: 0x06021D42 RID: 138562 RVA: 0x00954C2F File Offset: 0x00952E2F
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D3E RID: 15678
		// (get) Token: 0x06021D43 RID: 138563 RVA: 0x00954C44 File Offset: 0x00952E44
		// (set) Token: 0x06021D44 RID: 138564 RVA: 0x00954C58 File Offset: 0x00952E58
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ConveyorBelt_Test_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06021D45 RID: 138565 RVA: 0x00954C70 File Offset: 0x00952E70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D46 RID: 138566 RVA: 0x00954CB8 File Offset: 0x00952EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D47 RID: 138567 RVA: 0x00954D00 File Offset: 0x00952F00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D48 RID: 138568 RVA: 0x00954D48 File Offset: 0x00952F48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D49 RID: 138569 RVA: 0x00954D90 File Offset: 0x00952F90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D4A RID: 138570 RVA: 0x00954E4C File Offset: 0x0095304C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021D4B RID: 138571 RVA: 0x00954ED8 File Offset: 0x009530D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ConveyorBelt_Test(int EntryPoint)
		{
			BP_ConveyorBelt_Test_C.__ExecuteUbergraph_BP_ConveyorBelt_Test_FunctionParams* ptr = stackalloc BP_ConveyorBelt_Test_C.__ExecuteUbergraph_BP_ConveyorBelt_Test_FunctionParams[(UIntPtr)775] + 15L / (long)sizeof(BP_ConveyorBelt_Test_C.__ExecuteUbergraph_BP_ConveyorBelt_Test_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ConveyorBelt_Test_C.__ExecuteUbergraph_BP_ConveyorBelt_Test_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ConveyorBelt_Test_C.__ExecuteUbergraph_BP_ConveyorBelt_Test_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021D4C RID: 138572 RVA: 0x00954F22 File Offset: 0x00953122
		protected BP_ConveyorBelt_Test_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011124 RID: 69924
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/BP_ConveyorBelt_Test.BP_ConveyorBelt_Test_C";

		// Token: 0x04011125 RID: 69925
		private static IntPtr _ClassPtr;

		// Token: 0x04011126 RID: 69926
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011127 RID: 69927
		internal static int __PropertyOffset_0;

		// Token: 0x04011128 RID: 69928
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011129 RID: 69929
		internal static int __PropertyOffset_1;

		// Token: 0x0401112A RID: 69930
		internal static int __PropertyOffset_2;

		// Token: 0x0401112B RID: 69931
		internal static int __PropertyOffset_3;

		// Token: 0x0401112C RID: 69932
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401112D RID: 69933
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401112E RID: 69934
		private static IntPtr __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401112F RID: 69935
		private static IntPtr __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011130 RID: 69936
		private static IntPtr __ExecuteUbergraph_BP_ConveyorBelt_Test_NativeFunctionPtr;

		// Token: 0x02009B5A RID: 39770
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032341 RID: 205633
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B5B RID: 39771
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032342 RID: 205634
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B5C RID: 39772
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032343 RID: 205635
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032344 RID: 205636
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032345 RID: 205637
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032346 RID: 205638
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032347 RID: 205639
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032348 RID: 205640
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B5D RID: 39773
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__NewBlueprint_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032349 RID: 205641
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403234A RID: 205642
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403234B RID: 205643
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403234C RID: 205644
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B5E RID: 39774
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 760)]
		protected ref struct __ExecuteUbergraph_BP_ConveyorBelt_Test_FunctionParams
		{
			// Token: 0x0403234D RID: 205645
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
