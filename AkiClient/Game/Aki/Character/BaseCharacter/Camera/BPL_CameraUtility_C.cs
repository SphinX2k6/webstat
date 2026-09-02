using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042E7 RID: 17127
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/BPL_CameraUtility.BPL_CameraUtility_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_CameraUtility_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D6D8 RID: 186072 RVA: 0x00ABFC6A File Offset: 0x00ABDE6A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_CameraUtility_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Camera/BPL_CameraUtility.BPL_CameraUtility_C");
			}
			return BPL_CameraUtility_C._ClassPtr;
		}

		// Token: 0x0602D6D9 RID: 186073 RVA: 0x00ABFC90 File Offset: 0x00ABDE90
		public BPL_CameraUtility_C() : this(BuiltinUtils.AllocNativeUObject(BPL_CameraUtility_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D6DA RID: 186074 RVA: 0x00ABFCB8 File Offset: 0x00ABDEB8
		[NullableContext(1)]
		public BPL_CameraUtility_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_CameraUtility_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D6DB RID: 186075 RVA: 0x00ABFCEC File Offset: 0x00ABDEEC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetCameraConfigList([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SCameraConfig> CameraSettings, UDataTable DataTable, UObject __WorldContext)
		{
			BPL_CameraUtility_C.StaticClass();
			BPL_CameraUtility_C.__DtGetCameraConfigList_FunctionParams* ptr = stackalloc BPL_CameraUtility_C.__DtGetCameraConfigList_FunctionParams[(UIntPtr)2247] + 15L / (long)sizeof(BPL_CameraUtility_C.__DtGetCameraConfigList_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CameraUtility_C.__DtGetCameraConfigList_NativeFunctionPtr, (void*)ptr, 1);
			TArray<SCameraConfig> tarray = CameraSettings;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->CameraSettings);
			}
			ptr->DataTable = ((DataTable != null) ? DataTable.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CameraUtility_C._ClassDefaultObjectPtr, BPL_CameraUtility_C.__DtGetCameraConfigList_NativeFunctionPtr, (void*)ptr);
			TArray<SCameraConfig> tarray2 = CameraSettings;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->CameraSettings);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CameraUtility_C.__DtGetCameraConfigList_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602D6DC RID: 186076 RVA: 0x00ABFD98 File Offset: 0x00ABDF98
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetCameraConfigs([Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SCamera_Setting> CameraSettings, UDataTable DataTable, UObject __WorldContext)
		{
			BPL_CameraUtility_C.StaticClass();
			BPL_CameraUtility_C.__DtGetCameraConfigs_FunctionParams* ptr = stackalloc BPL_CameraUtility_C.__DtGetCameraConfigs_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BPL_CameraUtility_C.__DtGetCameraConfigs_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CameraUtility_C.__DtGetCameraConfigs_NativeFunctionPtr, (void*)ptr, 1);
			TArray<SCamera_Setting> tarray = CameraSettings;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->CameraSettings);
			}
			ptr->DataTable = ((DataTable != null) ? DataTable.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CameraUtility_C._ClassDefaultObjectPtr, BPL_CameraUtility_C.__DtGetCameraConfigs_NativeFunctionPtr, (void*)ptr);
			TArray<SCamera_Setting> tarray2 = CameraSettings;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->CameraSettings);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CameraUtility_C.__DtGetCameraConfigs_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602D6DD RID: 186077 RVA: 0x00ABFE44 File Offset: 0x00ABE044
		protected BPL_CameraUtility_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040197B7 RID: 104375
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Camera/BPL_CameraUtility.BPL_CameraUtility_C";

		// Token: 0x040197B8 RID: 104376
		private static IntPtr _ClassPtr;

		// Token: 0x040197B9 RID: 104377
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040197BA RID: 104378
		private static IntPtr __DtGetCameraConfigList_NativeFunctionPtr;

		// Token: 0x040197BB RID: 104379
		private static IntPtr __DtGetCameraConfigs_NativeFunctionPtr;

		// Token: 0x0200A528 RID: 42280
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2232)]
		protected ref struct __DtGetCameraConfigList_FunctionParams
		{
			// Token: 0x040333D4 RID: 209876
			[FieldOffset(0)]
			public byte CameraSettings;

			// Token: 0x040333D5 RID: 209877
			[FieldOffset(16)]
			public IntPtr DataTable;

			// Token: 0x040333D6 RID: 209878
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A529 RID: 42281
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __DtGetCameraConfigs_FunctionParams
		{
			// Token: 0x040333D7 RID: 209879
			[FieldOffset(0)]
			public byte CameraSettings;

			// Token: 0x040333D8 RID: 209880
			[FieldOffset(16)]
			public IntPtr DataTable;

			// Token: 0x040333D9 RID: 209881
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}
	}
}
