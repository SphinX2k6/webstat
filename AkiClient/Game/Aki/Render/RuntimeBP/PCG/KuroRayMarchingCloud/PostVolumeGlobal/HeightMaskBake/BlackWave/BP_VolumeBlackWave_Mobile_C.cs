using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.PostVolumeGlobal.HeightMaskBake.BlackWave
{
	// Token: 0x02003BEF RID: 15343
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave_Mobile.BP_VolumeBlackWave_Mobile_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class BP_VolumeBlackWave_Mobile_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602297F RID: 141695 RVA: 0x00969900 File Offset: 0x00967B00
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_VolumeBlackWave_Mobile_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave_Mobile.BP_VolumeBlackWave_Mobile_C");
			}
			return BP_VolumeBlackWave_Mobile_C._ClassPtr;
		}

		// Token: 0x06022980 RID: 141696 RVA: 0x00969924 File Offset: 0x00967B24
		public BP_VolumeBlackWave_Mobile_C() : this(BuiltinUtils.AllocNativeUObject(BP_VolumeBlackWave_Mobile_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022981 RID: 141697 RVA: 0x0096994C File Offset: 0x00967B4C
		[NullableContext(1)]
		public BP_VolumeBlackWave_Mobile_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_VolumeBlackWave_Mobile_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170041AA RID: 16810
		// (get) Token: 0x06022982 RID: 141698 RVA: 0x00969980 File Offset: 0x00967B80
		// (set) Token: 0x06022983 RID: 141699 RVA: 0x009699B9 File Offset: 0x00967BB9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_VolumeBlackWave_Mobile_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_VolumeBlackWave_Mobile_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170041AB RID: 16811
		// (get) Token: 0x06022984 RID: 141700 RVA: 0x009699DA File Offset: 0x00967BDA
		// (set) Token: 0x06022985 RID: 141701 RVA: 0x009699EE File Offset: 0x00967BEE
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170041AC RID: 16812
		// (get) Token: 0x06022986 RID: 141702 RVA: 0x00969A03 File Offset: 0x00967C03
		// (set) Token: 0x06022987 RID: 141703 RVA: 0x00969A17 File Offset: 0x00967C17
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170041AD RID: 16813
		// (get) Token: 0x06022988 RID: 141704 RVA: 0x00969A2C File Offset: 0x00967C2C
		// (set) Token: 0x06022989 RID: 141705 RVA: 0x00969A40 File Offset: 0x00967C40
		public unsafe UTexture2D HeightMask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170041AE RID: 16814
		// (get) Token: 0x0602298A RID: 141706 RVA: 0x00969A55 File Offset: 0x00967C55
		// (set) Token: 0x0602298B RID: 141707 RVA: 0x00969A69 File Offset: 0x00967C69
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_VolumeBlackWave_Mobile_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x0602298C RID: 141708 RVA: 0x00969A7E File Offset: 0x00967C7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeBlackWave_Mobile_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602298D RID: 141709 RVA: 0x00969A92 File Offset: 0x00967C92
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_Mobile_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602298E RID: 141710 RVA: 0x00969AA7 File Offset: 0x00967CA7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_VolumeBlackWave_Mobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602298F RID: 141711 RVA: 0x00969ABB File Offset: 0x00967CBB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_Mobile_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022990 RID: 141712 RVA: 0x00969AD0 File Offset: 0x00967CD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_VolumeBlackWave_Mobile(int EntryPoint)
		{
			BP_VolumeBlackWave_Mobile_C.__ExecuteUbergraph_BP_VolumeBlackWave_Mobile_FunctionParams* ptr = stackalloc BP_VolumeBlackWave_Mobile_C.__ExecuteUbergraph_BP_VolumeBlackWave_Mobile_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_VolumeBlackWave_Mobile_C.__ExecuteUbergraph_BP_VolumeBlackWave_Mobile_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_VolumeBlackWave_Mobile_C.__ExecuteUbergraph_BP_VolumeBlackWave_Mobile_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_VolumeBlackWave_Mobile_C.__ExecuteUbergraph_BP_VolumeBlackWave_Mobile_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022991 RID: 141713 RVA: 0x00969B17 File Offset: 0x00967D17
		protected BP_VolumeBlackWave_Mobile_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011869 RID: 71785
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/HeightMaskBake/BlackWave/BP_VolumeBlackWave_Mobile.BP_VolumeBlackWave_Mobile_C";

		// Token: 0x0401186A RID: 71786
		private static IntPtr _ClassPtr;

		// Token: 0x0401186B RID: 71787
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401186C RID: 71788
		internal static int __PropertyOffset_0;

		// Token: 0x0401186D RID: 71789
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401186E RID: 71790
		internal static int __PropertyOffset_1;

		// Token: 0x0401186F RID: 71791
		internal static int __PropertyOffset_2;

		// Token: 0x04011870 RID: 71792
		internal static int __PropertyOffset_3;

		// Token: 0x04011871 RID: 71793
		internal static int __PropertyOffset_4;

		// Token: 0x04011872 RID: 71794
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011873 RID: 71795
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011874 RID: 71796
		private static IntPtr __ExecuteUbergraph_BP_VolumeBlackWave_Mobile_NativeFunctionPtr;

		// Token: 0x02009BFC RID: 39932
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_VolumeBlackWave_Mobile_FunctionParams
		{
			// Token: 0x04032456 RID: 205910
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
