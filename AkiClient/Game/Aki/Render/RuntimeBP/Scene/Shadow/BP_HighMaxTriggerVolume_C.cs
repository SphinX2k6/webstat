using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Shadow
{
	// Token: 0x02003A75 RID: 14965
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Shadow/BP_HighMaxTriggerVolume.BP_HighMaxTriggerVolume_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1052)]
	public class BP_HighMaxTriggerVolume_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F354 RID: 127828 RVA: 0x0090B768 File Offset: 0x00909968
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_HighMaxTriggerVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Shadow/BP_HighMaxTriggerVolume.BP_HighMaxTriggerVolume_C");
			}
			return BP_HighMaxTriggerVolume_C._ClassPtr;
		}

		// Token: 0x0601F355 RID: 127829 RVA: 0x0090B78C File Offset: 0x0090998C
		public BP_HighMaxTriggerVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_HighMaxTriggerVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F356 RID: 127830 RVA: 0x0090B7B4 File Offset: 0x009099B4
		[NullableContext(1)]
		public BP_HighMaxTriggerVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_HighMaxTriggerVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E8D RID: 11917
		// (get) Token: 0x0601F357 RID: 127831 RVA: 0x0090B7E8 File Offset: 0x009099E8
		// (set) Token: 0x0601F358 RID: 127832 RVA: 0x0090B821 File Offset: 0x00909A21
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_HighMaxTriggerVolume_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_HighMaxTriggerVolume_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E8E RID: 11918
		// (get) Token: 0x0601F359 RID: 127833 RVA: 0x0090B842 File Offset: 0x00909A42
		// (set) Token: 0x0601F35A RID: 127834 RVA: 0x0090B856 File Offset: 0x00909A56
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_HighMaxTriggerVolume_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_HighMaxTriggerVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E8F RID: 11919
		// (get) Token: 0x0601F35B RID: 127835 RVA: 0x0090B86B File Offset: 0x00909A6B
		// (set) Token: 0x0601F35C RID: 127836 RVA: 0x0090B87B File Offset: 0x00909A7B
		public unsafe float ClampDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_HighMaxTriggerVolume_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_HighMaxTriggerVolume_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0601F35D RID: 127837 RVA: 0x0090B88C File Offset: 0x00909A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRayCastLocation(FVectorDouble TriggerLocation, ref FVectorDouble Location)
		{
			BP_HighMaxTriggerVolume_C.__GetRayCastLocation_FunctionParams* ptr = stackalloc BP_HighMaxTriggerVolume_C.__GetRayCastLocation_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_HighMaxTriggerVolume_C.__GetRayCastLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HighMaxTriggerVolume_C.__GetRayCastLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TriggerLocation = TriggerLocation;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HighMaxTriggerVolume_C.__GetRayCastLocation_NativeFunctionPtr, (void*)ptr);
			Location = ptr->Location;
		}

		// Token: 0x0601F35E RID: 127838 RVA: 0x0090B8F0 File Offset: 0x00909AF0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSceneLightComponent(ref UDirectionalLightComponent Ret)
		{
			BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_FunctionParams* ptr = stackalloc BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_FunctionParams ptr2 = ref *ptr;
			UDirectionalLightComponent udirectionalLightComponent = Ret;
			ptr2.Ret = ((udirectionalLightComponent != null) ? udirectionalLightComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HighMaxTriggerVolume_C.__GetSceneLightComponent_NativeFunctionPtr, (void*)ptr);
			Ret = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDirectionalLightComponent>(ptr->Ret);
		}

		// Token: 0x0601F35F RID: 127839 RVA: 0x0090B954 File Offset: 0x00909B54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F360 RID: 127840 RVA: 0x0090BA10 File Offset: 0x00909C10
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_HighMaxTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F361 RID: 127841 RVA: 0x0090BA9C File Offset: 0x00909C9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_HighMaxTriggerVolume(int EntryPoint)
		{
			BP_HighMaxTriggerVolume_C.__ExecuteUbergraph_BP_HighMaxTriggerVolume_FunctionParams* ptr = stackalloc BP_HighMaxTriggerVolume_C.__ExecuteUbergraph_BP_HighMaxTriggerVolume_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_HighMaxTriggerVolume_C.__ExecuteUbergraph_BP_HighMaxTriggerVolume_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_HighMaxTriggerVolume_C.__ExecuteUbergraph_BP_HighMaxTriggerVolume_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_HighMaxTriggerVolume_C.__ExecuteUbergraph_BP_HighMaxTriggerVolume_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F362 RID: 127842 RVA: 0x0090BAE6 File Offset: 0x00909CE6
		protected BP_HighMaxTriggerVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F7A0 RID: 63392
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Shadow/BP_HighMaxTriggerVolume.BP_HighMaxTriggerVolume_C";

		// Token: 0x0400F7A1 RID: 63393
		private static IntPtr _ClassPtr;

		// Token: 0x0400F7A2 RID: 63394
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F7A3 RID: 63395
		internal static int __PropertyOffset_0;

		// Token: 0x0400F7A4 RID: 63396
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F7A5 RID: 63397
		internal static int __PropertyOffset_1;

		// Token: 0x0400F7A6 RID: 63398
		internal static int __PropertyOffset_2;

		// Token: 0x0400F7A7 RID: 63399
		private static IntPtr __GetRayCastLocation_NativeFunctionPtr;

		// Token: 0x0400F7A8 RID: 63400
		private static IntPtr __GetSceneLightComponent_NativeFunctionPtr;

		// Token: 0x0400F7A9 RID: 63401
		private static IntPtr __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400F7AA RID: 63402
		private static IntPtr __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400F7AB RID: 63403
		private static IntPtr __ExecuteUbergraph_BP_HighMaxTriggerVolume_NativeFunctionPtr;

		// Token: 0x020098A8 RID: 39080
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __GetRayCastLocation_FunctionParams
		{
			// Token: 0x04031EF0 RID: 204528
			[FieldOffset(0)]
			public FVectorDouble TriggerLocation;

			// Token: 0x04031EF1 RID: 204529
			[FieldOffset(24)]
			public FVectorDouble Location;
		}

		// Token: 0x020098A9 RID: 39081
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __GetSceneLightComponent_FunctionParams
		{
			// Token: 0x04031EF2 RID: 204530
			[FieldOffset(0)]
			public IntPtr Ret;
		}

		// Token: 0x020098AA RID: 39082
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031EF3 RID: 204531
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031EF4 RID: 204532
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031EF5 RID: 204533
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031EF6 RID: 204534
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04031EF7 RID: 204535
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04031EF8 RID: 204536
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x020098AB RID: 39083
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04031EF9 RID: 204537
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04031EFA RID: 204538
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04031EFB RID: 204539
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04031EFC RID: 204540
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x020098AC RID: 39084
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_HighMaxTriggerVolume_FunctionParams
		{
			// Token: 0x04031EFD RID: 204541
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
