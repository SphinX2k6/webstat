using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Cave
{
	// Token: 0x02003B1F RID: 15135
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Cave/BP_CaveTriggerVolume.BP_CaveTriggerVolume_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1085)]
	public class BP_CaveTriggerVolume_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020880 RID: 133248 RVA: 0x0092EC9F File Offset: 0x0092CE9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CaveTriggerVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Cave/BP_CaveTriggerVolume.BP_CaveTriggerVolume_C");
			}
			return BP_CaveTriggerVolume_C._ClassPtr;
		}

		// Token: 0x06020881 RID: 133249 RVA: 0x0092ECC4 File Offset: 0x0092CEC4
		public BP_CaveTriggerVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_CaveTriggerVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020882 RID: 133250 RVA: 0x0092ECEC File Offset: 0x0092CEEC
		[NullableContext(1)]
		public BP_CaveTriggerVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CaveTriggerVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035FD RID: 13821
		// (get) Token: 0x06020883 RID: 133251 RVA: 0x0092ED20 File Offset: 0x0092CF20
		// (set) Token: 0x06020884 RID: 133252 RVA: 0x0092ED59 File Offset: 0x0092CF59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170035FE RID: 13822
		// (get) Token: 0x06020885 RID: 133253 RVA: 0x0092ED7A File Offset: 0x0092CF7A
		// (set) Token: 0x06020886 RID: 133254 RVA: 0x0092ED8E File Offset: 0x0092CF8E
		public unsafe UTextRenderComponent TextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170035FF RID: 13823
		// (get) Token: 0x06020887 RID: 133255 RVA: 0x0092EDA3 File Offset: 0x0092CFA3
		// (set) Token: 0x06020888 RID: 133256 RVA: 0x0092EDB7 File Offset: 0x0092CFB7
		public unsafe UStaticMeshComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003600 RID: 13824
		// (get) Token: 0x06020889 RID: 133257 RVA: 0x0092EDCC File Offset: 0x0092CFCC
		// (set) Token: 0x0602088A RID: 133258 RVA: 0x0092EDE0 File Offset: 0x0092CFE0
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CaveTriggerVolume_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003601 RID: 13825
		// (get) Token: 0x0602088B RID: 133259 RVA: 0x0092EDF5 File Offset: 0x0092CFF5
		// (set) Token: 0x0602088C RID: 133260 RVA: 0x0092EE05 File Offset: 0x0092D005
		public unsafe float MobileCSMDistanceOld
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003602 RID: 13826
		// (get) Token: 0x0602088D RID: 133261 RVA: 0x0092EE16 File Offset: 0x0092D016
		// (set) Token: 0x0602088E RID: 133262 RVA: 0x0092EE26 File Offset: 0x0092D026
		public unsafe float MobileCSMDistanceNew
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003603 RID: 13827
		// (get) Token: 0x0602088F RID: 133263 RVA: 0x0092EE37 File Offset: 0x0092D037
		// (set) Token: 0x06020890 RID: 133264 RVA: 0x0092EE47 File Offset: 0x0092D047
		public unsafe float RayTraceLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003604 RID: 13828
		// (get) Token: 0x06020891 RID: 133265 RVA: 0x0092EE58 File Offset: 0x0092D058
		// (set) Token: 0x06020892 RID: 133266 RVA: 0x0092EE68 File Offset: 0x0092D068
		public unsafe bool UseCustomCoef
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003605 RID: 13829
		// (get) Token: 0x06020893 RID: 133267 RVA: 0x0092EE79 File Offset: 0x0092D079
		// (set) Token: 0x06020894 RID: 133268 RVA: 0x0092EE89 File Offset: 0x0092D089
		public unsafe ECaveOrRoomLoadType LoadType
		{
			get
			{
				return (ECaveOrRoomLoadType)(*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_8));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_8) = (byte)value;
			}
		}

		// Token: 0x17003606 RID: 13830
		// (get) Token: 0x06020895 RID: 133269 RVA: 0x0092EE9A File Offset: 0x0092D09A
		// (set) Token: 0x06020896 RID: 133270 RVA: 0x0092EEAA File Offset: 0x0092D0AA
		public unsafe float AdjustValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003607 RID: 13831
		// (get) Token: 0x06020897 RID: 133271 RVA: 0x0092EEBB File Offset: 0x0092D0BB
		// (set) Token: 0x06020898 RID: 133272 RVA: 0x0092EECB File Offset: 0x0092D0CB
		public unsafe bool IsRoom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CaveTriggerVolume_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020899 RID: 133273 RVA: 0x0092EEDC File Offset: 0x0092D0DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRayCastLocation(FVectorDouble TriggerLocation, ref FVectorDouble Location)
		{
			BP_CaveTriggerVolume_C.__GetRayCastLocation_FunctionParams* ptr = stackalloc BP_CaveTriggerVolume_C.__GetRayCastLocation_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_CaveTriggerVolume_C.__GetRayCastLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CaveTriggerVolume_C.__GetRayCastLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TriggerLocation = TriggerLocation;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CaveTriggerVolume_C.__GetRayCastLocation_NativeFunctionPtr, (void*)ptr);
			Location = ptr->Location;
		}

		// Token: 0x0602089A RID: 133274 RVA: 0x0092EF40 File Offset: 0x0092D140
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSceneLightComponent(ref UDirectionalLightComponent Ret)
		{
			BP_CaveTriggerVolume_C.__GetSceneLightComponent_FunctionParams* ptr = stackalloc BP_CaveTriggerVolume_C.__GetSceneLightComponent_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_CaveTriggerVolume_C.__GetSceneLightComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CaveTriggerVolume_C.__GetSceneLightComponent_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_CaveTriggerVolume_C.__GetSceneLightComponent_FunctionParams ptr2 = ref *ptr;
			UDirectionalLightComponent udirectionalLightComponent = Ret;
			ptr2.Ret = ((udirectionalLightComponent != null) ? udirectionalLightComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CaveTriggerVolume_C.__GetSceneLightComponent_NativeFunctionPtr, (void*)ptr);
			Ret = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDirectionalLightComponent>(ptr->Ret);
		}

		// Token: 0x0602089B RID: 133275 RVA: 0x0092EFA4 File Offset: 0x0092D1A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602089C RID: 133276 RVA: 0x0092F030 File Offset: 0x0092D230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CaveTriggerVolume_C.__BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602089D RID: 133277 RVA: 0x0092F0EC File Offset: 0x0092D2EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CaveTriggerVolume(int EntryPoint)
		{
			BP_CaveTriggerVolume_C.__ExecuteUbergraph_BP_CaveTriggerVolume_FunctionParams* ptr = stackalloc BP_CaveTriggerVolume_C.__ExecuteUbergraph_BP_CaveTriggerVolume_FunctionParams[(UIntPtr)1919] + 15L / (long)sizeof(BP_CaveTriggerVolume_C.__ExecuteUbergraph_BP_CaveTriggerVolume_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CaveTriggerVolume_C.__ExecuteUbergraph_BP_CaveTriggerVolume_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CaveTriggerVolume_C.__ExecuteUbergraph_BP_CaveTriggerVolume_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602089E RID: 133278 RVA: 0x0092F136 File Offset: 0x0092D336
		protected BP_CaveTriggerVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010455 RID: 66645
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Cave/BP_CaveTriggerVolume.BP_CaveTriggerVolume_C";

		// Token: 0x04010456 RID: 66646
		private static IntPtr _ClassPtr;

		// Token: 0x04010457 RID: 66647
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010458 RID: 66648
		internal static int __PropertyOffset_0;

		// Token: 0x04010459 RID: 66649
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401045A RID: 66650
		internal static int __PropertyOffset_1;

		// Token: 0x0401045B RID: 66651
		internal static int __PropertyOffset_2;

		// Token: 0x0401045C RID: 66652
		internal static int __PropertyOffset_3;

		// Token: 0x0401045D RID: 66653
		internal static int __PropertyOffset_4;

		// Token: 0x0401045E RID: 66654
		internal static int __PropertyOffset_5;

		// Token: 0x0401045F RID: 66655
		internal static int __PropertyOffset_6;

		// Token: 0x04010460 RID: 66656
		internal static int __PropertyOffset_7;

		// Token: 0x04010461 RID: 66657
		internal static int __PropertyOffset_8;

		// Token: 0x04010462 RID: 66658
		internal static int __PropertyOffset_9;

		// Token: 0x04010463 RID: 66659
		internal static int __PropertyOffset_10;

		// Token: 0x04010464 RID: 66660
		private static IntPtr __GetRayCastLocation_NativeFunctionPtr;

		// Token: 0x04010465 RID: 66661
		private static IntPtr __GetSceneLightComponent_NativeFunctionPtr;

		// Token: 0x04010466 RID: 66662
		private static IntPtr __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010467 RID: 66663
		private static IntPtr __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010468 RID: 66664
		private static IntPtr __ExecuteUbergraph_BP_CaveTriggerVolume_NativeFunctionPtr;

		// Token: 0x020099C9 RID: 39369
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __GetRayCastLocation_FunctionParams
		{
			// Token: 0x04032074 RID: 204916
			[FieldOffset(0)]
			public FVectorDouble TriggerLocation;

			// Token: 0x04032075 RID: 204917
			[FieldOffset(24)]
			public FVectorDouble Location;
		}

		// Token: 0x020099CA RID: 39370
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __GetSceneLightComponent_FunctionParams
		{
			// Token: 0x04032076 RID: 204918
			[FieldOffset(0)]
			public IntPtr Ret;
		}

		// Token: 0x020099CB RID: 39371
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032077 RID: 204919
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032078 RID: 204920
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032079 RID: 204921
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403207A RID: 204922
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x020099CC RID: 39372
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_CaveTriggerVolume_Box_K2Node_ComponentBoundEvent_1_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403207B RID: 204923
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403207C RID: 204924
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403207D RID: 204925
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403207E RID: 204926
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403207F RID: 204927
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032080 RID: 204928
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x020099CD RID: 39373
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1904)]
		protected ref struct __ExecuteUbergraph_BP_CaveTriggerVolume_FunctionParams
		{
			// Token: 0x04032081 RID: 204929
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
