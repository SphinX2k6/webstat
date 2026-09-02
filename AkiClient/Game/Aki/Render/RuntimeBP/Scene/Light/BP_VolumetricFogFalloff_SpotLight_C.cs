using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA3 RID: 15011
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogFalloff_SpotLight.BP_VolumetricFogFalloff_SpotLight_C")]
	[UnrealStructLayout(1128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1128)]
	public class BP_VolumetricFogFalloff_SpotLight_C : ASpotLight, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FD9B RID: 130459 RVA: 0x0091BE48 File Offset: 0x0091A048
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricFogFalloff_SpotLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogFalloff_SpotLight.BP_VolumetricFogFalloff_SpotLight_C");
			}
			return BP_VolumetricFogFalloff_SpotLight_C._ClassPtr;
		}

		// Token: 0x0601FD9C RID: 130460 RVA: 0x0091BE6C File Offset: 0x0091A06C
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricFogFalloff_SpotLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FD9D RID: 130461 RVA: 0x0091BE74 File Offset: 0x0091A074
		public BP_VolumetricFogFalloff_SpotLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogFalloff_SpotLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FD9E RID: 130462 RVA: 0x0091BE9C File Offset: 0x0091A09C
		[NullableContext(1)]
		public BP_VolumetricFogFalloff_SpotLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogFalloff_SpotLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003279 RID: 12921
		// (get) Token: 0x0601FD9F RID: 130463 RVA: 0x0091BED0 File Offset: 0x0091A0D0
		// (set) Token: 0x0601FDA0 RID: 130464 RVA: 0x0091BF09 File Offset: 0x0091A109
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700327A RID: 12922
		// (get) Token: 0x0601FDA1 RID: 130465 RVA: 0x0091BF2A File Offset: 0x0091A12A
		// (set) Token: 0x0601FDA2 RID: 130466 RVA: 0x0091BF3E File Offset: 0x0091A13E
		[Nullable(2)]
		public unsafe UKuroGameBudgetComponent KuroGameBudget
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGameBudgetComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700327B RID: 12923
		// (get) Token: 0x0601FDA3 RID: 130467 RVA: 0x0091BF53 File Offset: 0x0091A153
		// (set) Token: 0x0601FDA4 RID: 130468 RVA: 0x0091BF63 File Offset: 0x0091A163
		public unsafe float VolumetricFogIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700327C RID: 12924
		// (get) Token: 0x0601FDA5 RID: 130469 RVA: 0x0091BF74 File Offset: 0x0091A174
		// (set) Token: 0x0601FDA6 RID: 130470 RVA: 0x0091BF84 File Offset: 0x0091A184
		public unsafe float currentDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700327D RID: 12925
		// (get) Token: 0x0601FDA7 RID: 130471 RVA: 0x0091BF95 File Offset: 0x0091A195
		// (set) Token: 0x0601FDA8 RID: 130472 RVA: 0x0091BFA5 File Offset: 0x0091A1A5
		public unsafe float brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700327E RID: 12926
		// (get) Token: 0x0601FDA9 RID: 130473 RVA: 0x0091BFB6 File Offset: 0x0091A1B6
		// (set) Token: 0x0601FDAA RID: 130474 RVA: 0x0091BFCA File Offset: 0x0091A1CA
		public unsafe FVectorDouble CameraVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700327F RID: 12927
		// (get) Token: 0x0601FDAB RID: 130475 RVA: 0x0091BFDF File Offset: 0x0091A1DF
		// (set) Token: 0x0601FDAC RID: 130476 RVA: 0x0091BFEF File Offset: 0x0091A1EF
		public unsafe float DistanceEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003280 RID: 12928
		// (get) Token: 0x0601FDAD RID: 130477 RVA: 0x0091C000 File Offset: 0x0091A200
		// (set) Token: 0x0601FDAE RID: 130478 RVA: 0x0091C010 File Offset: 0x0091A210
		public unsafe float DistanceStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogFalloff_SpotLight_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0601FDAF RID: 130479 RVA: 0x0091C024 File Offset: 0x0091A224
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FDB0 RID: 130480 RVA: 0x0091C06C File Offset: 0x0091A26C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FDB1 RID: 130481 RVA: 0x0091C0B2 File Offset: 0x0091A2B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SpotLightFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__SpotLightFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601FDB2 RID: 130482 RVA: 0x0091C0C6 File Offset: 0x0091A2C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FDB3 RID: 130483 RVA: 0x0091C0DA File Offset: 0x0091A2DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FDB4 RID: 130484 RVA: 0x0091C0EF File Offset: 0x0091A2EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FDB5 RID: 130485 RVA: 0x0091C103 File Offset: 0x0091A303
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FDB6 RID: 130486 RVA: 0x0091C118 File Offset: 0x0091A318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FDB7 RID: 130487 RVA: 0x0091C160 File Offset: 0x0091A360
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FDB8 RID: 130488 RVA: 0x0091C1A7 File Offset: 0x0091A3A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimerEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__TimerEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0601FDB9 RID: 130489 RVA: 0x0091C1BC File Offset: 0x0091A3BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight(int EntryPoint)
		{
			BP_VolumetricFogFalloff_SpotLight_C.__ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_FunctionParams* ptr = stackalloc BP_VolumetricFogFalloff_SpotLight_C.__ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_VolumetricFogFalloff_SpotLight_C.__ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogFalloff_SpotLight_C.__ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogFalloff_SpotLight_C.__ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FDBA RID: 130490 RVA: 0x0091C203 File Offset: 0x0091A403
		protected BP_VolumetricFogFalloff_SpotLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FD9F RID: 64927
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FDA0 RID: 64928
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogFalloff_SpotLight.BP_VolumetricFogFalloff_SpotLight_C";

		// Token: 0x0400FDA1 RID: 64929
		private static IntPtr _ClassPtr;

		// Token: 0x0400FDA2 RID: 64930
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FDA3 RID: 64931
		internal static int __PropertyOffset_0;

		// Token: 0x0400FDA4 RID: 64932
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FDA5 RID: 64933
		internal static int __PropertyOffset_1;

		// Token: 0x0400FDA6 RID: 64934
		internal static int __PropertyOffset_2;

		// Token: 0x0400FDA7 RID: 64935
		internal static int __PropertyOffset_3;

		// Token: 0x0400FDA8 RID: 64936
		internal static int __PropertyOffset_4;

		// Token: 0x0400FDA9 RID: 64937
		internal static int __PropertyOffset_5;

		// Token: 0x0400FDAA RID: 64938
		internal static int __PropertyOffset_6;

		// Token: 0x0400FDAB RID: 64939
		internal static int __PropertyOffset_7;

		// Token: 0x0400FDAC RID: 64940
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FDAD RID: 64941
		private static IntPtr __SpotLightFunction_NativeFunctionPtr;

		// Token: 0x0400FDAE RID: 64942
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FDAF RID: 64943
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FDB0 RID: 64944
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FDB1 RID: 64945
		private static IntPtr __TimerEvent_NativeFunctionPtr;

		// Token: 0x0400FDB2 RID: 64946
		private static IntPtr __ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_NativeFunctionPtr;

		// Token: 0x0200992C RID: 39212
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F8B RID: 204683
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200992D RID: 39213
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F8C RID: 204684
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200992E RID: 39214
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricFogFalloff_SpotLight_FunctionParams
		{
			// Token: 0x04031F8D RID: 204685
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
