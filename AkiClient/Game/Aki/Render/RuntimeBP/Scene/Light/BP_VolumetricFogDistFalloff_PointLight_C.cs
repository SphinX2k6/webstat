using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA1 RID: 15009
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_PointLight.BP_VolumetricFogDistFalloff_PointLight_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1120)]
	public class BP_VolumetricFogDistFalloff_PointLight_C : APointLight, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FD5D RID: 130397 RVA: 0x0091B6EC File Offset: 0x009198EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricFogDistFalloff_PointLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_PointLight.BP_VolumetricFogDistFalloff_PointLight_C");
			}
			return BP_VolumetricFogDistFalloff_PointLight_C._ClassPtr;
		}

		// Token: 0x0601FD5E RID: 130398 RVA: 0x0091B710 File Offset: 0x00919910
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricFogDistFalloff_PointLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FD5F RID: 130399 RVA: 0x0091B718 File Offset: 0x00919918
		public BP_VolumetricFogDistFalloff_PointLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogDistFalloff_PointLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FD60 RID: 130400 RVA: 0x0091B740 File Offset: 0x00919940
		[NullableContext(1)]
		public BP_VolumetricFogDistFalloff_PointLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogDistFalloff_PointLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700326A RID: 12906
		// (get) Token: 0x0601FD61 RID: 130401 RVA: 0x0091B774 File Offset: 0x00919974
		// (set) Token: 0x0601FD62 RID: 130402 RVA: 0x0091B7AD File Offset: 0x009199AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700326B RID: 12907
		// (get) Token: 0x0601FD63 RID: 130403 RVA: 0x0091B7CE File Offset: 0x009199CE
		// (set) Token: 0x0601FD64 RID: 130404 RVA: 0x0091B7E2 File Offset: 0x009199E2
		[Nullable(2)]
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700326C RID: 12908
		// (get) Token: 0x0601FD65 RID: 130405 RVA: 0x0091B7F7 File Offset: 0x009199F7
		// (set) Token: 0x0601FD66 RID: 130406 RVA: 0x0091B807 File Offset: 0x00919A07
		public unsafe float VolumetricFogIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700326D RID: 12909
		// (get) Token: 0x0601FD67 RID: 130407 RVA: 0x0091B818 File Offset: 0x00919A18
		// (set) Token: 0x0601FD68 RID: 130408 RVA: 0x0091B828 File Offset: 0x00919A28
		public unsafe float DistanceStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700326E RID: 12910
		// (get) Token: 0x0601FD69 RID: 130409 RVA: 0x0091B839 File Offset: 0x00919A39
		// (set) Token: 0x0601FD6A RID: 130410 RVA: 0x0091B849 File Offset: 0x00919A49
		public unsafe float brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700326F RID: 12911
		// (get) Token: 0x0601FD6B RID: 130411 RVA: 0x0091B85A File Offset: 0x00919A5A
		// (set) Token: 0x0601FD6C RID: 130412 RVA: 0x0091B86E File Offset: 0x00919A6E
		public unsafe FVectorDouble CameraVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003270 RID: 12912
		// (get) Token: 0x0601FD6D RID: 130413 RVA: 0x0091B883 File Offset: 0x00919A83
		// (set) Token: 0x0601FD6E RID: 130414 RVA: 0x0091B893 File Offset: 0x00919A93
		public unsafe float DistanceEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003271 RID: 12913
		// (get) Token: 0x0601FD6F RID: 130415 RVA: 0x0091B8A4 File Offset: 0x00919AA4
		// (set) Token: 0x0601FD70 RID: 130416 RVA: 0x0091B8B4 File Offset: 0x00919AB4
		public unsafe float currentDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_PointLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0601FD71 RID: 130417 RVA: 0x0091B8C8 File Offset: 0x00919AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FD72 RID: 130418 RVA: 0x0091B910 File Offset: 0x00919B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FD73 RID: 130419 RVA: 0x0091B956 File Offset: 0x00919B56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PointFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__PointFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD74 RID: 130420 RVA: 0x0091B96A File Offset: 0x00919B6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD75 RID: 130421 RVA: 0x0091B97E File Offset: 0x00919B7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD76 RID: 130422 RVA: 0x0091B993 File Offset: 0x00919B93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD77 RID: 130423 RVA: 0x0091B9A7 File Offset: 0x00919BA7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD78 RID: 130424 RVA: 0x0091B9BC File Offset: 0x00919BBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FD79 RID: 130425 RVA: 0x0091BA04 File Offset: 0x00919C04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD7A RID: 130426 RVA: 0x0091BA4B File Offset: 0x00919C4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimerEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__TimerEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD7B RID: 130427 RVA: 0x0091BA60 File Offset: 0x00919C60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight(int EntryPoint)
		{
			BP_VolumetricFogDistFalloff_PointLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_PointLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_PointLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_PointLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_PointLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD7C RID: 130428 RVA: 0x0091BAA7 File Offset: 0x00919CA7
		protected BP_VolumetricFogDistFalloff_PointLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FD78 RID: 64888
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FD79 RID: 64889
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_PointLight.BP_VolumetricFogDistFalloff_PointLight_C";

		// Token: 0x0400FD7A RID: 64890
		private static IntPtr _ClassPtr;

		// Token: 0x0400FD7B RID: 64891
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FD7C RID: 64892
		internal static int __PropertyOffset_0;

		// Token: 0x0400FD7D RID: 64893
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FD7E RID: 64894
		internal static int __PropertyOffset_1;

		// Token: 0x0400FD7F RID: 64895
		internal static int __PropertyOffset_2;

		// Token: 0x0400FD80 RID: 64896
		internal static int __PropertyOffset_3;

		// Token: 0x0400FD81 RID: 64897
		internal static int __PropertyOffset_4;

		// Token: 0x0400FD82 RID: 64898
		internal static int __PropertyOffset_5;

		// Token: 0x0400FD83 RID: 64899
		internal static int __PropertyOffset_6;

		// Token: 0x0400FD84 RID: 64900
		internal static int __PropertyOffset_7;

		// Token: 0x0400FD85 RID: 64901
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FD86 RID: 64902
		private static IntPtr __PointFunction_NativeFunctionPtr;

		// Token: 0x0400FD87 RID: 64903
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FD88 RID: 64904
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FD89 RID: 64905
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FD8A RID: 64906
		private static IntPtr __TimerEvent_NativeFunctionPtr;

		// Token: 0x0400FD8B RID: 64907
		private static IntPtr __ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_NativeFunctionPtr;

		// Token: 0x02009926 RID: 39206
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F85 RID: 204677
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x02009927 RID: 39207
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F86 RID: 204678
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009928 RID: 39208
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricFogDistFalloff_PointLight_FunctionParams
		{
			// Token: 0x04031F87 RID: 204679
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
