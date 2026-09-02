using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC
{
	// Token: 0x020040DE RID: 16606
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/GPUNPCData.GPUNPCData_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class GPUNPCData_C : UBakedBoneInstanceDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602BBEB RID: 179179 RVA: 0x00A87FC3 File Offset: 0x00A861C3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GPUNPCData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/GPUNPC/GPUNPCData.GPUNPCData_C");
			}
			return GPUNPCData_C._ClassPtr;
		}

		// Token: 0x0602BBEC RID: 179180 RVA: 0x00A87FE8 File Offset: 0x00A861E8
		public GPUNPCData_C() : this(BuiltinUtils.AllocNativeUObject(GPUNPCData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BBED RID: 179181 RVA: 0x00A88010 File Offset: 0x00A86210
		[NullableContext(1)]
		public GPUNPCData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GPUNPCData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170073F8 RID: 29688
		// (get) Token: 0x0602BBEE RID: 179182 RVA: 0x00A88043 File Offset: 0x00A86243
		// (set) Token: 0x0602BBEF RID: 179183 RVA: 0x00A88057 File Offset: 0x00A86257
		public unsafe USkeletalMesh SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170073F9 RID: 29689
		// (get) Token: 0x0602BBF0 RID: 179184 RVA: 0x00A8806C File Offset: 0x00A8626C
		// (set) Token: 0x0602BBF1 RID: 179185 RVA: 0x00A88080 File Offset: 0x00A86280
		public unsafe PD_NpcSetupData_C NpcSetupData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_NpcSetupData_C>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170073FA RID: 29690
		// (get) Token: 0x0602BBF2 RID: 179186 RVA: 0x00A88095 File Offset: 0x00A86295
		// (set) Token: 0x0602BBF3 RID: 179187 RVA: 0x00A880A9 File Offset: 0x00A862A9
		public unsafe UBakedBoneTexture2D Combined_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBakedBoneTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170073FB RID: 29691
		// (get) Token: 0x0602BBF4 RID: 179188 RVA: 0x00A880BE File Offset: 0x00A862BE
		// (set) Token: 0x0602BBF5 RID: 179189 RVA: 0x00A880D2 File Offset: 0x00A862D2
		public unsafe UBakedBoneMontageInfoAsset BakedBoneMontageInfoAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBakedBoneMontageInfoAsset>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602BBF6 RID: 179190 RVA: 0x00A880E7 File Offset: 0x00A862E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 清空非合批资源()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__清空非合批资源_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBF7 RID: 179191 RVA: 0x00A880FC File Offset: 0x00A862FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasCombinedBakedBoneTexture(ref bool Result)
		{
			GPUNPCData_C.__HasCombinedBakedBoneTexture_FunctionParams* ptr = stackalloc GPUNPCData_C.__HasCombinedBakedBoneTexture_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(GPUNPCData_C.__HasCombinedBakedBoneTexture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__HasCombinedBakedBoneTexture_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__HasCombinedBakedBoneTexture_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602BBF8 RID: 179192 RVA: 0x00A8814C File Offset: 0x00A8634C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTotalNumFrames(ref int OutTotalNumFrames)
		{
			GPUNPCData_C.__GetTotalNumFrames_FunctionParams* ptr = stackalloc GPUNPCData_C.__GetTotalNumFrames_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GPUNPCData_C.__GetTotalNumFrames_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__GetTotalNumFrames_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OutTotalNumFrames = OutTotalNumFrames;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__GetTotalNumFrames_NativeFunctionPtr, (void*)ptr);
			OutTotalNumFrames = ptr->OutTotalNumFrames;
		}

		// Token: 0x0602BBF9 RID: 179193 RVA: 0x00A8819C File Offset: 0x00A8639C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMaxNumTracks(ref int OutMaxNumTracks)
		{
			GPUNPCData_C.__GetMaxNumTracks_FunctionParams* ptr = stackalloc GPUNPCData_C.__GetMaxNumTracks_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GPUNPCData_C.__GetMaxNumTracks_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__GetMaxNumTracks_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OutMaxNumTracks = OutMaxNumTracks;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__GetMaxNumTracks_NativeFunctionPtr, (void*)ptr);
			OutMaxNumTracks = ptr->OutMaxNumTracks;
		}

		// Token: 0x0602BBFA RID: 179194 RVA: 0x00A881EC File Offset: 0x00A863EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMeshesFromNPCSetupData(ref USkeletalMesh OutMainMesh, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMesh> OutSubMeshes)
		{
			GPUNPCData_C.__GetMeshesFromNPCSetupData_FunctionParams* ptr = stackalloc GPUNPCData_C.__GetMeshesFromNPCSetupData_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(GPUNPCData_C.__GetMeshesFromNPCSetupData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__GetMeshesFromNPCSetupData_NativeFunctionPtr, (void*)ptr, 1);
			ref GPUNPCData_C.__GetMeshesFromNPCSetupData_FunctionParams ptr2 = ref *ptr;
			USkeletalMesh uskeletalMesh = OutMainMesh;
			ptr2.OutMainMesh = ((uskeletalMesh != null) ? uskeletalMesh.NativePtr : IntPtr.Zero);
			TArray<USkeletalMesh> tarray = OutSubMeshes;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutSubMeshes);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__GetMeshesFromNPCSetupData_NativeFunctionPtr, (void*)ptr);
			OutMainMesh = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMesh>(ptr->OutMainMesh);
			TArray<USkeletalMesh> tarray2 = OutSubMeshes;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutSubMeshes);
			}
			UnrealReflectionUtils.DestroyStruct(GPUNPCData_C.__GetMeshesFromNPCSetupData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602BBFB RID: 179195 RVA: 0x00A8828C File Offset: 0x00A8648C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasSetSkeletalMesh(ref bool HasSet)
		{
			GPUNPCData_C.__HasSetSkeletalMesh_FunctionParams* ptr = stackalloc GPUNPCData_C.__HasSetSkeletalMesh_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(GPUNPCData_C.__HasSetSkeletalMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__HasSetSkeletalMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HasSet = HasSet;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__HasSetSkeletalMesh_NativeFunctionPtr, (void*)ptr);
			HasSet = ptr->HasSet;
		}

		// Token: 0x0602BBFC RID: 179196 RVA: 0x00A882DC File Offset: 0x00A864DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 生成MainMesh和SubMeshes(ref USkeletalMesh OutMainMesh, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<USkeletalMesh> OutSubMeshes)
		{
			GPUNPCData_C.__生成MainMesh和SubMeshes_FunctionParams* ptr = stackalloc GPUNPCData_C.__生成MainMesh和SubMeshes_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GPUNPCData_C.__生成MainMesh和SubMeshes_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__生成MainMesh和SubMeshes_NativeFunctionPtr, (void*)ptr, 1);
			ref GPUNPCData_C.__生成MainMesh和SubMeshes_FunctionParams ptr2 = ref *ptr;
			USkeletalMesh uskeletalMesh = OutMainMesh;
			ptr2.OutMainMesh = ((uskeletalMesh != null) ? uskeletalMesh.NativePtr : IntPtr.Zero);
			TArray<USkeletalMesh> tarray = OutSubMeshes;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->OutSubMeshes);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__生成MainMesh和SubMeshes_NativeFunctionPtr, (void*)ptr);
			OutMainMesh = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMesh>(ptr->OutMainMesh);
			TArray<USkeletalMesh> tarray2 = OutSubMeshes;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->OutSubMeshes);
			}
			UnrealReflectionUtils.DestroyStruct(GPUNPCData_C.__生成MainMesh和SubMeshes_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602BBFD RID: 179197 RVA: 0x00A8837C File Offset: 0x00A8657C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 随机起始动画时间噪声贴图(ref UTexture2D OutNoiseTex, ref int OutNoiseIndex)
		{
			GPUNPCData_C.__随机起始动画时间噪声贴图_FunctionParams* ptr = stackalloc GPUNPCData_C.__随机起始动画时间噪声贴图_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GPUNPCData_C.__随机起始动画时间噪声贴图_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GPUNPCData_C.__随机起始动画时间噪声贴图_NativeFunctionPtr, (void*)ptr, 1);
			ref GPUNPCData_C.__随机起始动画时间噪声贴图_FunctionParams ptr2 = ref *ptr;
			UTexture2D utexture2D = OutNoiseTex;
			ptr2.OutNoiseTex = ((utexture2D != null) ? utexture2D.NativePtr : IntPtr.Zero);
			ptr->OutNoiseIndex = OutNoiseIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GPUNPCData_C.__随机起始动画时间噪声贴图_NativeFunctionPtr, (void*)ptr);
			OutNoiseTex = BuiltinUtils.GetOrCreateUObjectByNativePointer<UTexture2D>(ptr->OutNoiseTex);
			OutNoiseIndex = ptr->OutNoiseIndex;
		}

		// Token: 0x0602BBFE RID: 179198 RVA: 0x00A883F0 File Offset: 0x00A865F0
		protected GPUNPCData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040181A3 RID: 98723
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/GPUNPCData.GPUNPCData_C";

		// Token: 0x040181A4 RID: 98724
		private static IntPtr _ClassPtr;

		// Token: 0x040181A5 RID: 98725
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040181A6 RID: 98726
		internal static int __PropertyOffset_0;

		// Token: 0x040181A7 RID: 98727
		internal static int __PropertyOffset_1;

		// Token: 0x040181A8 RID: 98728
		internal static int __PropertyOffset_2;

		// Token: 0x040181A9 RID: 98729
		internal static int __PropertyOffset_3;

		// Token: 0x040181AA RID: 98730
		private static IntPtr __清空非合批资源_NativeFunctionPtr;

		// Token: 0x040181AB RID: 98731
		private static IntPtr __HasCombinedBakedBoneTexture_NativeFunctionPtr;

		// Token: 0x040181AC RID: 98732
		private static IntPtr __GetTotalNumFrames_NativeFunctionPtr;

		// Token: 0x040181AD RID: 98733
		private static IntPtr __GetMaxNumTracks_NativeFunctionPtr;

		// Token: 0x040181AE RID: 98734
		private static IntPtr __GetMeshesFromNPCSetupData_NativeFunctionPtr;

		// Token: 0x040181AF RID: 98735
		private static IntPtr __HasSetSkeletalMesh_NativeFunctionPtr;

		// Token: 0x040181B0 RID: 98736
		private static IntPtr __生成MainMesh和SubMeshes_NativeFunctionPtr;

		// Token: 0x040181B1 RID: 98737
		private static IntPtr __随机起始动画时间噪声贴图_NativeFunctionPtr;

		// Token: 0x0200A3CC RID: 41932
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasCombinedBakedBoneTexture_FunctionParams
		{
			// Token: 0x040331B6 RID: 209334
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A3CD RID: 41933
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetTotalNumFrames_FunctionParams
		{
			// Token: 0x040331B7 RID: 209335
			[FieldOffset(0)]
			public int OutTotalNumFrames;
		}

		// Token: 0x0200A3CE RID: 41934
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetMaxNumTracks_FunctionParams
		{
			// Token: 0x040331B8 RID: 209336
			[FieldOffset(0)]
			public int OutMaxNumTracks;
		}

		// Token: 0x0200A3CF RID: 41935
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetMeshesFromNPCSetupData_FunctionParams
		{
			// Token: 0x040331B9 RID: 209337
			[FieldOffset(0)]
			public IntPtr OutMainMesh;

			// Token: 0x040331BA RID: 209338
			[FieldOffset(8)]
			public byte OutSubMeshes;
		}

		// Token: 0x0200A3D0 RID: 41936
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __HasSetSkeletalMesh_FunctionParams
		{
			// Token: 0x040331BB RID: 209339
			[FieldOffset(0)]
			public bool HasSet;
		}

		// Token: 0x0200A3D1 RID: 41937
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __生成MainMesh和SubMeshes_FunctionParams
		{
			// Token: 0x040331BC RID: 209340
			[FieldOffset(0)]
			public IntPtr OutMainMesh;

			// Token: 0x040331BD RID: 209341
			[FieldOffset(8)]
			public byte OutSubMeshes;
		}

		// Token: 0x0200A3D2 RID: 41938
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __随机起始动画时间噪声贴图_FunctionParams
		{
			// Token: 0x040331BE RID: 209342
			[FieldOffset(0)]
			public IntPtr OutNoiseTex;

			// Token: 0x040331BF RID: 209343
			[FieldOffset(8)]
			public int OutNoiseIndex;
		}
	}
}
