using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.SceneViedoPlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.GodRay
{
	// Token: 0x02003BF3 RID: 15347
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeMediaPlaneLight.BP_KuroVolumeMediaPlaneLight_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_KuroVolumeMediaPlaneLight_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022A9B RID: 141979 RVA: 0x0096B300 File Offset: 0x00969500
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumeMediaPlaneLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeMediaPlaneLight.BP_KuroVolumeMediaPlaneLight_C");
			}
			return BP_KuroVolumeMediaPlaneLight_C._ClassPtr;
		}

		// Token: 0x06022A9C RID: 141980 RVA: 0x0096B324 File Offset: 0x00969524
		public BP_KuroVolumeMediaPlaneLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeMediaPlaneLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022A9D RID: 141981 RVA: 0x0096B34C File Offset: 0x0096954C
		[NullableContext(1)]
		public BP_KuroVolumeMediaPlaneLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeMediaPlaneLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004217 RID: 16919
		// (get) Token: 0x06022A9E RID: 141982 RVA: 0x0096B380 File Offset: 0x00969580
		// (set) Token: 0x06022A9F RID: 141983 RVA: 0x0096B3B9 File Offset: 0x009695B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004218 RID: 16920
		// (get) Token: 0x06022AA0 RID: 141984 RVA: 0x0096B3DA File Offset: 0x009695DA
		// (set) Token: 0x06022AA1 RID: 141985 RVA: 0x0096B3EE File Offset: 0x009695EE
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004219 RID: 16921
		// (get) Token: 0x06022AA2 RID: 141986 RVA: 0x0096B403 File Offset: 0x00969603
		// (set) Token: 0x06022AA3 RID: 141987 RVA: 0x0096B417 File Offset: 0x00969617
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700421A RID: 16922
		// (get) Token: 0x06022AA4 RID: 141988 RVA: 0x0096B42C File Offset: 0x0096962C
		// (set) Token: 0x06022AA5 RID: 141989 RVA: 0x0096B465 File Offset: 0x00969665
		[Nullable(1)]
		public TArray<AStaticMeshActor> VolumeLightMesh
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AStaticMeshActor> result;
				if ((result = this._VolumeLightMesh) == null)
				{
					result = (this._VolumeLightMesh = new TArray<AStaticMeshActor>(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.VolumeLightMesh.CopyAssign(value);
			}
		}

		// Token: 0x1700421B RID: 16923
		// (get) Token: 0x06022AA6 RID: 141990 RVA: 0x0096B473 File Offset: 0x00969673
		// (set) Token: 0x06022AA7 RID: 141991 RVA: 0x0096B487 File Offset: 0x00969687
		public unsafe UMaterialInstance SourceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700421C RID: 16924
		// (get) Token: 0x06022AA8 RID: 141992 RVA: 0x0096B49C File Offset: 0x0096969C
		// (set) Token: 0x06022AA9 RID: 141993 RVA: 0x0096B4B0 File Offset: 0x009696B0
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700421D RID: 16925
		// (get) Token: 0x06022AAA RID: 141994 RVA: 0x0096B4C5 File Offset: 0x009696C5
		// (set) Token: 0x06022AAB RID: 141995 RVA: 0x0096B4D5 File Offset: 0x009696D5
		public unsafe bool bUseMPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700421E RID: 16926
		// (get) Token: 0x06022AAC RID: 141996 RVA: 0x0096B4E6 File Offset: 0x009696E6
		// (set) Token: 0x06022AAD RID: 141997 RVA: 0x0096B4F6 File Offset: 0x009696F6
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700421F RID: 16927
		// (get) Token: 0x06022AAE RID: 141998 RVA: 0x0096B507 File Offset: 0x00969707
		// (set) Token: 0x06022AAF RID: 141999 RVA: 0x0096B51B File Offset: 0x0096971B
		public unsafe UTextureRenderTarget2D Texture_Render_Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004220 RID: 16928
		// (get) Token: 0x06022AB0 RID: 142000 RVA: 0x0096B530 File Offset: 0x00969730
		// (set) Token: 0x06022AB1 RID: 142001 RVA: 0x0096B544 File Offset: 0x00969744
		public unsafe MediaPlayForModel_Special_C BoundMediaPlay
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<MediaPlayForModel_Special_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeMediaPlaneLight_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x06022AB2 RID: 142002 RVA: 0x0096B559 File Offset: 0x00969759
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePlane()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__UpdatePlane_NativeFunctionPtr, null);
		}

		// Token: 0x06022AB3 RID: 142003 RVA: 0x0096B570 File Offset: 0x00969770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVolumeMeshVisibility(bool bNewVisibility)
		{
			BP_KuroVolumeMediaPlaneLight_C.__SetVolumeMeshVisibility_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__SetVolumeMeshVisibility_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__SetVolumeMeshVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bNewVisibility = bNewVisibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__SetVolumeMeshVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022AB4 RID: 142004 RVA: 0x0096B5B6 File Offset: 0x009697B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__UpdateMat_NativeFunctionPtr, null);
		}

		// Token: 0x06022AB5 RID: 142005 RVA: 0x0096B5CA File Offset: 0x009697CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Render()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__Render_NativeFunctionPtr, null);
		}

		// Token: 0x06022AB6 RID: 142006 RVA: 0x0096B5DE File Offset: 0x009697DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022AB7 RID: 142007 RVA: 0x0096B5F2 File Offset: 0x009697F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022AB8 RID: 142008 RVA: 0x0096B607 File Offset: 0x00969807
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022AB9 RID: 142009 RVA: 0x0096B61B File Offset: 0x0096981B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022ABA RID: 142010 RVA: 0x0096B630 File Offset: 0x00969830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022ABB RID: 142011 RVA: 0x0096B678 File Offset: 0x00969878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022ABC RID: 142012 RVA: 0x0096B6C0 File Offset: 0x009698C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022ABD RID: 142013 RVA: 0x0096B708 File Offset: 0x00969908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022ABE RID: 142014 RVA: 0x0096B750 File Offset: 0x00969950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight(int EntryPoint)
		{
			BP_KuroVolumeMediaPlaneLight_C.__ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_FunctionParams* ptr = stackalloc BP_KuroVolumeMediaPlaneLight_C.__ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_KuroVolumeMediaPlaneLight_C.__ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeMediaPlaneLight_C.__ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeMediaPlaneLight_C.__ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022ABF RID: 142015 RVA: 0x0096B797 File Offset: 0x00969997
		protected BP_KuroVolumeMediaPlaneLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401190D RID: 71949
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/GodRay/BP_KuroVolumeMediaPlaneLight.BP_KuroVolumeMediaPlaneLight_C";

		// Token: 0x0401190E RID: 71950
		private static IntPtr _ClassPtr;

		// Token: 0x0401190F RID: 71951
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011910 RID: 71952
		internal static int __PropertyOffset_0;

		// Token: 0x04011911 RID: 71953
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011912 RID: 71954
		internal static int __PropertyOffset_1;

		// Token: 0x04011913 RID: 71955
		internal static int __PropertyOffset_2;

		// Token: 0x04011914 RID: 71956
		internal static int __PropertyOffset_3;

		// Token: 0x04011915 RID: 71957
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AStaticMeshActor> _VolumeLightMesh;

		// Token: 0x04011916 RID: 71958
		internal static int __PropertyOffset_4;

		// Token: 0x04011917 RID: 71959
		internal static int __PropertyOffset_5;

		// Token: 0x04011918 RID: 71960
		internal static int __PropertyOffset_6;

		// Token: 0x04011919 RID: 71961
		internal static int __PropertyOffset_7;

		// Token: 0x0401191A RID: 71962
		internal static int __PropertyOffset_8;

		// Token: 0x0401191B RID: 71963
		internal static int __PropertyOffset_9;

		// Token: 0x0401191C RID: 71964
		private static IntPtr __UpdatePlane_NativeFunctionPtr;

		// Token: 0x0401191D RID: 71965
		private static IntPtr __SetVolumeMeshVisibility_NativeFunctionPtr;

		// Token: 0x0401191E RID: 71966
		private static IntPtr __UpdateMat_NativeFunctionPtr;

		// Token: 0x0401191F RID: 71967
		private static IntPtr __Render_NativeFunctionPtr;

		// Token: 0x04011920 RID: 71968
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011921 RID: 71969
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011922 RID: 71970
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011923 RID: 71971
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011924 RID: 71972
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_NativeFunctionPtr;

		// Token: 0x02009C06 RID: 39942
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __SetVolumeMeshVisibility_FunctionParams
		{
			// Token: 0x04032460 RID: 205920
			[FieldOffset(0)]
			public bool bNewVisibility;
		}

		// Token: 0x02009C07 RID: 39943
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032461 RID: 205921
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C08 RID: 39944
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032462 RID: 205922
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C09 RID: 39945
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumeMediaPlaneLight_FunctionParams
		{
			// Token: 0x04032463 RID: 205923
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
