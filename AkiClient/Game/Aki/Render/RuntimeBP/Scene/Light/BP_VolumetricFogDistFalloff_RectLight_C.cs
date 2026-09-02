using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AA2 RID: 15010
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_RectLight.BP_VolumetricFogDistFalloff_RectLight_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1108)]
	public class BP_VolumetricFogDistFalloff_RectLight_C : ARectLight, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601FD7D RID: 130429 RVA: 0x0091BAB0 File Offset: 0x00919CB0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumetricFogDistFalloff_RectLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_RectLight.BP_VolumetricFogDistFalloff_RectLight_C");
			}
			return BP_VolumetricFogDistFalloff_RectLight_C._ClassPtr;
		}

		// Token: 0x0601FD7E RID: 130430 RVA: 0x0091BAD4 File Offset: 0x00919CD4
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_VolumetricFogDistFalloff_RectLight_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601FD7F RID: 130431 RVA: 0x0091BADC File Offset: 0x00919CDC
		public BP_VolumetricFogDistFalloff_RectLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogDistFalloff_RectLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FD80 RID: 130432 RVA: 0x0091BB04 File Offset: 0x00919D04
		[NullableContext(1)]
		public BP_VolumetricFogDistFalloff_RectLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumetricFogDistFalloff_RectLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003272 RID: 12914
		// (get) Token: 0x0601FD81 RID: 130433 RVA: 0x0091BB38 File Offset: 0x00919D38
		// (set) Token: 0x0601FD82 RID: 130434 RVA: 0x0091BB71 File Offset: 0x00919D71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003273 RID: 12915
		// (get) Token: 0x0601FD83 RID: 130435 RVA: 0x0091BB92 File Offset: 0x00919D92
		// (set) Token: 0x0601FD84 RID: 130436 RVA: 0x0091BBA2 File Offset: 0x00919DA2
		public unsafe float VolumetricFogIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003274 RID: 12916
		// (get) Token: 0x0601FD85 RID: 130437 RVA: 0x0091BBB3 File Offset: 0x00919DB3
		// (set) Token: 0x0601FD86 RID: 130438 RVA: 0x0091BBC3 File Offset: 0x00919DC3
		public unsafe float brightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17003275 RID: 12917
		// (get) Token: 0x0601FD87 RID: 130439 RVA: 0x0091BBD4 File Offset: 0x00919DD4
		// (set) Token: 0x0601FD88 RID: 130440 RVA: 0x0091BBE8 File Offset: 0x00919DE8
		public unsafe FVectorDouble CameraVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003276 RID: 12918
		// (get) Token: 0x0601FD89 RID: 130441 RVA: 0x0091BBFD File Offset: 0x00919DFD
		// (set) Token: 0x0601FD8A RID: 130442 RVA: 0x0091BC0D File Offset: 0x00919E0D
		public unsafe float currentDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003277 RID: 12919
		// (get) Token: 0x0601FD8B RID: 130443 RVA: 0x0091BC1E File Offset: 0x00919E1E
		// (set) Token: 0x0601FD8C RID: 130444 RVA: 0x0091BC2E File Offset: 0x00919E2E
		public unsafe float DistanceEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003278 RID: 12920
		// (get) Token: 0x0601FD8D RID: 130445 RVA: 0x0091BC3F File Offset: 0x00919E3F
		// (set) Token: 0x0601FD8E RID: 130446 RVA: 0x0091BC4F File Offset: 0x00919E4F
		public unsafe float DistanceStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumetricFogDistFalloff_RectLight_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0601FD8F RID: 130447 RVA: 0x0091BC60 File Offset: 0x00919E60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601FD90 RID: 130448 RVA: 0x0091BCA8 File Offset: 0x00919EA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601FD91 RID: 130449 RVA: 0x0091BCEE File Offset: 0x00919EEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RectLightFunction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__RectLightFunction_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD92 RID: 130450 RVA: 0x0091BD02 File Offset: 0x00919F02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD93 RID: 130451 RVA: 0x0091BD16 File Offset: 0x00919F16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD94 RID: 130452 RVA: 0x0091BD2B File Offset: 0x00919F2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD95 RID: 130453 RVA: 0x0091BD3F File Offset: 0x00919F3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601FD96 RID: 130454 RVA: 0x0091BD54 File Offset: 0x00919F54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601FD97 RID: 130455 RVA: 0x0091BD9C File Offset: 0x00919F9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD98 RID: 130456 RVA: 0x0091BDE3 File Offset: 0x00919FE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TimerEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__TimerEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0601FD99 RID: 130457 RVA: 0x0091BDF8 File Offset: 0x00919FF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight(int EntryPoint)
		{
			BP_VolumetricFogDistFalloff_RectLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_FunctionParams* ptr = stackalloc BP_VolumetricFogDistFalloff_RectLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_VolumetricFogDistFalloff_RectLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumetricFogDistFalloff_RectLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumetricFogDistFalloff_RectLight_C.__ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601FD9A RID: 130458 RVA: 0x0091BE3F File Offset: 0x0091A03F
		protected BP_VolumetricFogDistFalloff_RectLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FD8C RID: 64908
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FD8D RID: 64909
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_VolumetricFogDistFalloff_RectLight.BP_VolumetricFogDistFalloff_RectLight_C";

		// Token: 0x0400FD8E RID: 64910
		private static IntPtr _ClassPtr;

		// Token: 0x0400FD8F RID: 64911
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FD90 RID: 64912
		internal static int __PropertyOffset_0;

		// Token: 0x0400FD91 RID: 64913
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FD92 RID: 64914
		internal static int __PropertyOffset_1;

		// Token: 0x0400FD93 RID: 64915
		internal static int __PropertyOffset_2;

		// Token: 0x0400FD94 RID: 64916
		internal static int __PropertyOffset_3;

		// Token: 0x0400FD95 RID: 64917
		internal static int __PropertyOffset_4;

		// Token: 0x0400FD96 RID: 64918
		internal static int __PropertyOffset_5;

		// Token: 0x0400FD97 RID: 64919
		internal static int __PropertyOffset_6;

		// Token: 0x0400FD98 RID: 64920
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FD99 RID: 64921
		private static IntPtr __RectLightFunction_NativeFunctionPtr;

		// Token: 0x0400FD9A RID: 64922
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FD9B RID: 64923
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400FD9C RID: 64924
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FD9D RID: 64925
		private static IntPtr __TimerEvent_NativeFunctionPtr;

		// Token: 0x0400FD9E RID: 64926
		private static IntPtr __ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_NativeFunctionPtr;

		// Token: 0x02009929 RID: 39209
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F88 RID: 204680
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200992A RID: 39210
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031F89 RID: 204681
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200992B RID: 39211
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_VolumetricFogDistFalloff_RectLight_FunctionParams
		{
			// Token: 0x04031F8A RID: 204682
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
