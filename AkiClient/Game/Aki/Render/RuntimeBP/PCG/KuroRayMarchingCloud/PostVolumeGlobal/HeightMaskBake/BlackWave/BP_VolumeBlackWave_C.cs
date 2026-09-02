using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.PostVolumeGlobal.HeightMaskBake.BlackWave
{
	// Token: 0x02003BEE RID: 15342
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave.BP_VolumeBlackWave_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1084)]
	public class BP_VolumeBlackWave_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022968 RID: 141672 RVA: 0x00969694 File Offset: 0x00967894
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumeBlackWave_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave.BP_VolumeBlackWave_C");
			}
			return BP_VolumeBlackWave_C._ClassPtr;
		}

		// Token: 0x06022969 RID: 141673 RVA: 0x009696B8 File Offset: 0x009678B8
		public BP_VolumeBlackWave_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumeBlackWave_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602296A RID: 141674 RVA: 0x009696E0 File Offset: 0x009678E0
		[NullableContext(1)]
		public BP_VolumeBlackWave_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumeBlackWave_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170041A3 RID: 16803
		// (get) Token: 0x0602296B RID: 141675 RVA: 0x00969714 File Offset: 0x00967914
		// (set) Token: 0x0602296C RID: 141676 RVA: 0x0096974D File Offset: 0x0096794D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumeBlackWave_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumeBlackWave_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170041A4 RID: 16804
		// (get) Token: 0x0602296D RID: 141677 RVA: 0x0096976E File Offset: 0x0096796E
		// (set) Token: 0x0602296E RID: 141678 RVA: 0x00969782 File Offset: 0x00967982
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170041A5 RID: 16805
		// (get) Token: 0x0602296F RID: 141679 RVA: 0x00969797 File Offset: 0x00967997
		// (set) Token: 0x06022970 RID: 141680 RVA: 0x009697AB File Offset: 0x009679AB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170041A6 RID: 16806
		// (get) Token: 0x06022971 RID: 141681 RVA: 0x009697C0 File Offset: 0x009679C0
		// (set) Token: 0x06022972 RID: 141682 RVA: 0x009697D4 File Offset: 0x009679D4
		public unsafe UTexture2D HeightMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170041A7 RID: 16807
		// (get) Token: 0x06022973 RID: 141683 RVA: 0x009697E9 File Offset: 0x009679E9
		// (set) Token: 0x06022974 RID: 141684 RVA: 0x009697FD File Offset: 0x009679FD
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170041A8 RID: 16808
		// (get) Token: 0x06022975 RID: 141685 RVA: 0x00969812 File Offset: 0x00967A12
		// (set) Token: 0x06022976 RID: 141686 RVA: 0x00969826 File Offset: 0x00967A26
		public unsafe UTextureRenderTarget2D CombineRT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170041A9 RID: 16809
		// (get) Token: 0x06022977 RID: 141687 RVA: 0x0096983B File Offset: 0x00967A3B
		// (set) Token: 0x06022978 RID: 141688 RVA: 0x0096984B File Offset: 0x00967A4B
		public unsafe float HeightScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_VolumeBlackWave_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_VolumeBlackWave_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06022979 RID: 141689 RVA: 0x0096985C File Offset: 0x00967A5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeBlackWave_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602297A RID: 141690 RVA: 0x00969870 File Offset: 0x00967A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602297B RID: 141691 RVA: 0x00969885 File Offset: 0x00967A85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeBlackWave_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602297C RID: 141692 RVA: 0x00969899 File Offset: 0x00967A99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602297D RID: 141693 RVA: 0x009698B0 File Offset: 0x00967AB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumeBlackWave(int EntryPoint)
		{
			BP_VolumeBlackWave_C.__ExecuteUbergraph_BP_VolumeBlackWave_FunctionParams* ptr = stackalloc BP_VolumeBlackWave_C.__ExecuteUbergraph_BP_VolumeBlackWave_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_VolumeBlackWave_C.__ExecuteUbergraph_BP_VolumeBlackWave_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeBlackWave_C.__ExecuteUbergraph_BP_VolumeBlackWave_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_C.__ExecuteUbergraph_BP_VolumeBlackWave_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602297E RID: 141694 RVA: 0x009698F7 File Offset: 0x00967AF7
		protected BP_VolumeBlackWave_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401185B RID: 71771
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave.BP_VolumeBlackWave_C";

		// Token: 0x0401185C RID: 71772
		private static IntPtr _ClassPtr;

		// Token: 0x0401185D RID: 71773
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401185E RID: 71774
		internal static int __PropertyOffset_0;

		// Token: 0x0401185F RID: 71775
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011860 RID: 71776
		internal static int __PropertyOffset_1;

		// Token: 0x04011861 RID: 71777
		internal static int __PropertyOffset_2;

		// Token: 0x04011862 RID: 71778
		internal static int __PropertyOffset_3;

		// Token: 0x04011863 RID: 71779
		internal static int __PropertyOffset_4;

		// Token: 0x04011864 RID: 71780
		internal static int __PropertyOffset_5;

		// Token: 0x04011865 RID: 71781
		internal static int __PropertyOffset_6;

		// Token: 0x04011866 RID: 71782
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011867 RID: 71783
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011868 RID: 71784
		private static IntPtr __ExecuteUbergraph_BP_VolumeBlackWave_NativeFunctionPtr;

		// Token: 0x02009BFB RID: 39931
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_VolumeBlackWave_FunctionParams
		{
			// Token: 0x04032455 RID: 205909
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
