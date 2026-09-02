using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon;
using AkiClient.Game.Aki.Character.Vision;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C3 RID: 16835
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BPL_CharacterUtility.BPL_CharacterUtility_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_CharacterUtility_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CB9B RID: 183195 RVA: 0x00AAD236 File Offset: 0x00AAB436
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_CharacterUtility_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BPL_CharacterUtility.BPL_CharacterUtility_C");
			}
			return BPL_CharacterUtility_C._ClassPtr;
		}

		// Token: 0x0602CB9C RID: 183196 RVA: 0x00AAD25C File Offset: 0x00AAB45C
		public BPL_CharacterUtility_C() : this(BuiltinUtils.AllocNativeUObject(BPL_CharacterUtility_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CB9D RID: 183197 RVA: 0x00AAD284 File Offset: 0x00AAB484
		[NullableContext(1)]
		public BPL_CharacterUtility_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_CharacterUtility_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602CB9E RID: 183198 RVA: 0x00AAD2B8 File Offset: 0x00AAB4B8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void CheckNpcSetupTools(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<AActor> ReturnValues)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__CheckNpcSetupTools_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__CheckNpcSetupTools_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_CharacterUtility_C.__CheckNpcSetupTools_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__CheckNpcSetupTools_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<AActor> tarray = ReturnValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ReturnValues);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__CheckNpcSetupTools_NativeFunctionPtr, (void*)ptr);
			TArray<AActor> tarray2 = ReturnValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ReturnValues);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__CheckNpcSetupTools_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CB9F RID: 183199 RVA: 0x00AAD34C File Offset: 0x00AAB54C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void CheckSimpleNpc(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<AActor> ReturnValues)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__CheckSimpleNpc_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__CheckSimpleNpc_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BPL_CharacterUtility_C.__CheckSimpleNpc_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__CheckSimpleNpc_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<AActor> tarray = ReturnValues;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->ReturnValues);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__CheckSimpleNpc_NativeFunctionPtr, (void*)ptr);
			TArray<AActor> tarray2 = ReturnValues;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->ReturnValues);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__CheckSimpleNpc_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBA0 RID: 183200 RVA: 0x00AAD3E0 File Offset: 0x00AAB5E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void UpdateCachePoseEnable(UAnimInstance Target, UObject __WorldContext, ref bool CachePoseEnable)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__UpdateCachePoseEnable_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__UpdateCachePoseEnable_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BPL_CharacterUtility_C.__UpdateCachePoseEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__UpdateCachePoseEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->CachePoseEnable = CachePoseEnable;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__UpdateCachePoseEnable_NativeFunctionPtr, (void*)ptr);
			CachePoseEnable = ptr->CachePoseEnable;
		}

		// Token: 0x0602CBA1 RID: 183201 RVA: 0x00AAD460 File Offset: 0x00AAB660
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetTypeQuery(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			0
		})] ref TArray<TEnumAsByte<EObjectTypeQuery>> NewParam)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__GetTypeQuery_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__GetTypeQuery_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BPL_CharacterUtility_C.__GetTypeQuery_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__GetTypeQuery_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = NewParam;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->NewParam);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__GetTypeQuery_NativeFunctionPtr, (void*)ptr);
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray2 = NewParam;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->NewParam);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__GetTypeQuery_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBA2 RID: 183202 RVA: 0x00AAD4F4 File Offset: 0x00AAB6F4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void UpdatePhysicsClothSimulateEnable(UAnimInstance AnimInstance, bool SrcSimulateEnable, UObject __WorldContext, ref bool DstSimulateEnable)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__UpdatePhysicsClothSimulateEnable_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__UpdatePhysicsClothSimulateEnable_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BPL_CharacterUtility_C.__UpdatePhysicsClothSimulateEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__UpdatePhysicsClothSimulateEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AnimInstance = ((AnimInstance != null) ? AnimInstance.NativePtr : IntPtr.Zero);
			ptr->SrcSimulateEnable = SrcSimulateEnable;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->DstSimulateEnable = DstSimulateEnable;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__UpdatePhysicsClothSimulateEnable_NativeFunctionPtr, (void*)ptr);
			DstSimulateEnable = ptr->DstSimulateEnable;
		}

		// Token: 0x0602CBA3 RID: 183203 RVA: 0x00AAD57C File Offset: 0x00AAB77C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetBlockObjectType(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			0
		})] ref TArray<TEnumAsByte<EObjectTypeQuery>> value)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetBlockObjectType_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetBlockObjectType_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetBlockObjectType_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetBlockObjectType_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = value;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->value);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetBlockObjectType_NativeFunctionPtr, (void*)ptr);
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray2 = value;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->value);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetBlockObjectType_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBA4 RID: 183204 RVA: 0x00AAD610 File Offset: 0x00AAB810
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetAllBulletData(UDataTable dataTable, UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SReBulletDataMain> NewParam)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetAllBulletData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetAllBulletData_FunctionParams[(UIntPtr)2111] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetAllBulletData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetAllBulletData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<SReBulletDataMain> tarray = NewParam;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->NewParam);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetAllBulletData_NativeFunctionPtr, (void*)ptr);
			TArray<SReBulletDataMain> tarray2 = NewParam;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->NewParam);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetAllBulletData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBA5 RID: 183205 RVA: 0x00AAD6BC File Offset: 0x00AAB8BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetCaughtInfo(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SCaughtInfo data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetCaughtInfo_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetCaughtInfo_FunctionParams[(UIntPtr)543] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetCaughtInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetCaughtInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCaughtInfo.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetCaughtInfo_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCaughtInfo.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetCaughtInfo_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBA6 RID: 183206 RVA: 0x00AAD798 File Offset: 0x00AAB998
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetVisionInfo(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SVisionData data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetVisionInfo_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetVisionInfo_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetVisionInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetVisionInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetVisionInfo_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetVisionInfo_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBA7 RID: 183207 RVA: 0x00AAD874 File Offset: 0x00AABA74
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		[return: Nullable(0)]
		public unsafe static TEnumAsByte<EMovementDirection> GetInputMovementDirection(TsBaseCharacter BaseChar, UObject __WorldContext)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__GetInputMovementDirection_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__GetInputMovementDirection_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BPL_CharacterUtility_C.__GetInputMovementDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__GetInputMovementDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BaseChar = ((BaseChar != null) ? BaseChar.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__GetInputMovementDirection_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CBA8 RID: 183208 RVA: 0x00AAD8EC File Offset: 0x00AABAEC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetAllCharacterPartDatas(UDataTable dataTable, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SCharacterPart> partArrayRef, UObject __WorldContext)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_FunctionParams[(UIntPtr)487] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			TArray<SCharacterPart> tarray = partArrayRef;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->partArrayRef);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_NativeFunctionPtr, (void*)ptr);
			TArray<SCharacterPart> tarray2 = partArrayRef;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->partArrayRef);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetAllCharacterPartDatas_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBA9 RID: 183209 RVA: 0x00AAD998 File Offset: 0x00AABB98
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void DtGetAllSkillInfos(UDataTable dataTable, UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SSkillInfo> NewParam)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetAllSkillInfos_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetAllSkillInfos_FunctionParams[(UIntPtr)583] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetAllSkillInfos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetAllSkillInfos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<SSkillInfo> tarray = NewParam;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->NewParam);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetAllSkillInfos_NativeFunctionPtr, (void*)ptr);
			TArray<SSkillInfo> tarray2 = NewParam;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->NewParam);
			}
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetAllSkillInfos_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CBAA RID: 183210 RVA: 0x00AADA44 File Offset: 0x00AABC44
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetNewBulletData(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SReBulletDataMain data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetNewBulletData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetNewBulletData_FunctionParams[(UIntPtr)4047] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetNewBulletData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetNewBulletData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMain.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetNewBulletData_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SReBulletDataMain.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetNewBulletData_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBAB RID: 183211 RVA: 0x00AADB20 File Offset: 0x00AABD20
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetEffectData(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SEffectData data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetEffectData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetEffectData_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetEffectData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetEffectData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectData.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetEffectData_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectData.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetEffectData_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBAC RID: 183212 RVA: 0x00AADBF8 File Offset: 0x00AABDF8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetAttributeModifierData(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SAttributeModifierData data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetAttributeModifierData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetAttributeModifierData_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetAttributeModifierData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetAttributeModifierData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAttributeModifierData.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetAttributeModifierData_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAttributeModifierData.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetAttributeModifierData_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBAD RID: 183213 RVA: 0x00AADCD4 File Offset: 0x00AABED4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetDamageData(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SDamageData data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetDamageData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetDamageData_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetDamageData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetDamageData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->data = data;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetDamageData_NativeFunctionPtr, (void*)ptr);
			data = ptr->data;
			return ptr->__Result;
		}

		// Token: 0x0602CBAE RID: 183214 RVA: 0x00AADD6C File Offset: 0x00AABF6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetSkillInfo(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SSkillInfo data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetSkillInfo_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetSkillInfo_FunctionParams[(UIntPtr)991] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetSkillInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetSkillInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillInfo.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetSkillInfo_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillInfo.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetSkillInfo_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBAF RID: 183215 RVA: 0x00AADE48 File Offset: 0x00AAC048
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetHitEffect(UDataTable dataTable, FName rowName, ref SHitEffect backData, UObject __WorldContext)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetHitEffect_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetHitEffect_FunctionParams[(UIntPtr)383] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetHitEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetHitEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			if (backData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitEffect.StaticStruct(), &ptr->backData, backData.NativePtr, 1, false);
			}
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetHitEffect_NativeFunctionPtr, (void*)ptr);
			if (backData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitEffect.StaticStruct(), backData.NativePtr, &ptr->backData, 1, false);
			}
			return ptr->__Result;
		}

		// Token: 0x0602CBB0 RID: 183216 RVA: 0x00AADF10 File Offset: 0x00AAC110
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetBulletData(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SBulletDataMain data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetBulletData_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetBulletData_FunctionParams[(UIntPtr)1471] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetBulletData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetBulletData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMain.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetBulletData_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SBulletDataMain.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BPL_CharacterUtility_C.__DtGetBulletData_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602CBB1 RID: 183217 RVA: 0x00AADFEC File Offset: 0x00AAC1EC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static bool DtGetMovementSettings(UDataTable dataTable, FName rowName, UObject __WorldContext, ref SMovementSetting_State data)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__DtGetMovementSettings_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__DtGetMovementSettings_FunctionParams[(UIntPtr)3567] + 15L / (long)sizeof(BPL_CharacterUtility_C.__DtGetMovementSettings_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__DtGetMovementSettings_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dataTable = ((dataTable != null) ? dataTable.NativePtr : IntPtr.Zero);
			ptr->rowName = rowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_State.StaticStruct(), &ptr->data, data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__DtGetMovementSettings_NativeFunctionPtr, (void*)ptr);
			if (data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMovementSetting_State.StaticStruct(), data.NativePtr, &ptr->data, 1, false);
			}
			return ptr->__Result;
		}

		// Token: 0x0602CBB2 RID: 183218 RVA: 0x00AAE0B4 File Offset: 0x00AAC2B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetLocalWind(UAnimInstance AnimInstance, UObject __WorldContext, ref FVector LocalWind)
		{
			BPL_CharacterUtility_C.StaticClass();
			BPL_CharacterUtility_C.__GetLocalWind_FunctionParams* ptr = stackalloc BPL_CharacterUtility_C.__GetLocalWind_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BPL_CharacterUtility_C.__GetLocalWind_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_CharacterUtility_C.__GetLocalWind_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AnimInstance = ((AnimInstance != null) ? AnimInstance.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->LocalWind = LocalWind;
			UnrealReflectionUtils.CallVirtualUFunction(BPL_CharacterUtility_C._ClassDefaultObjectPtr, BPL_CharacterUtility_C.__GetLocalWind_NativeFunctionPtr, (void*)ptr);
			LocalWind = ptr->LocalWind;
		}

		// Token: 0x0602CBB3 RID: 183219 RVA: 0x00AAE13F File Offset: 0x00AAC33F
		protected BPL_CharacterUtility_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018EB4 RID: 102068
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BPL_CharacterUtility.BPL_CharacterUtility_C";

		// Token: 0x04018EB5 RID: 102069
		private static IntPtr _ClassPtr;

		// Token: 0x04018EB6 RID: 102070
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018EB7 RID: 102071
		private static IntPtr __CheckNpcSetupTools_NativeFunctionPtr;

		// Token: 0x04018EB8 RID: 102072
		private static IntPtr __CheckSimpleNpc_NativeFunctionPtr;

		// Token: 0x04018EB9 RID: 102073
		private static IntPtr __UpdateCachePoseEnable_NativeFunctionPtr;

		// Token: 0x04018EBA RID: 102074
		private static IntPtr __GetTypeQuery_NativeFunctionPtr;

		// Token: 0x04018EBB RID: 102075
		private static IntPtr __UpdatePhysicsClothSimulateEnable_NativeFunctionPtr;

		// Token: 0x04018EBC RID: 102076
		private static IntPtr __DtGetBlockObjectType_NativeFunctionPtr;

		// Token: 0x04018EBD RID: 102077
		private static IntPtr __DtGetAllBulletData_NativeFunctionPtr;

		// Token: 0x04018EBE RID: 102078
		private static IntPtr __DtGetCaughtInfo_NativeFunctionPtr;

		// Token: 0x04018EBF RID: 102079
		private static IntPtr __DtGetVisionInfo_NativeFunctionPtr;

		// Token: 0x04018EC0 RID: 102080
		private static IntPtr __GetInputMovementDirection_NativeFunctionPtr;

		// Token: 0x04018EC1 RID: 102081
		private static IntPtr __DtGetAllCharacterPartDatas_NativeFunctionPtr;

		// Token: 0x04018EC2 RID: 102082
		private static IntPtr __DtGetAllSkillInfos_NativeFunctionPtr;

		// Token: 0x04018EC3 RID: 102083
		private static IntPtr __DtGetNewBulletData_NativeFunctionPtr;

		// Token: 0x04018EC4 RID: 102084
		private static IntPtr __DtGetEffectData_NativeFunctionPtr;

		// Token: 0x04018EC5 RID: 102085
		private static IntPtr __DtGetAttributeModifierData_NativeFunctionPtr;

		// Token: 0x04018EC6 RID: 102086
		private static IntPtr __DtGetDamageData_NativeFunctionPtr;

		// Token: 0x04018EC7 RID: 102087
		private static IntPtr __DtGetSkillInfo_NativeFunctionPtr;

		// Token: 0x04018EC8 RID: 102088
		private static IntPtr __DtGetHitEffect_NativeFunctionPtr;

		// Token: 0x04018EC9 RID: 102089
		private static IntPtr __DtGetBulletData_NativeFunctionPtr;

		// Token: 0x04018ECA RID: 102090
		private static IntPtr __DtGetMovementSettings_NativeFunctionPtr;

		// Token: 0x04018ECB RID: 102091
		private static IntPtr __GetLocalWind_NativeFunctionPtr;

		// Token: 0x0200A502 RID: 42242
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CheckNpcSetupTools_FunctionParams
		{
			// Token: 0x0403336D RID: 209773
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x0403336E RID: 209774
			[FieldOffset(8)]
			public byte ReturnValues;
		}

		// Token: 0x0200A503 RID: 42243
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __CheckSimpleNpc_FunctionParams
		{
			// Token: 0x0403336F RID: 209775
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04033370 RID: 209776
			[FieldOffset(8)]
			public byte ReturnValues;
		}

		// Token: 0x0200A504 RID: 42244
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateCachePoseEnable_FunctionParams
		{
			// Token: 0x04033371 RID: 209777
			[FieldOffset(0)]
			public IntPtr Target;

			// Token: 0x04033372 RID: 209778
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04033373 RID: 209779
			[FieldOffset(16)]
			public bool CachePoseEnable;
		}

		// Token: 0x0200A505 RID: 42245
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __GetTypeQuery_FunctionParams
		{
			// Token: 0x04033374 RID: 209780
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04033375 RID: 209781
			[FieldOffset(8)]
			public byte NewParam;
		}

		// Token: 0x0200A506 RID: 42246
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __UpdatePhysicsClothSimulateEnable_FunctionParams
		{
			// Token: 0x04033376 RID: 209782
			[FieldOffset(0)]
			public IntPtr AnimInstance;

			// Token: 0x04033377 RID: 209783
			[FieldOffset(8)]
			public bool SrcSimulateEnable;

			// Token: 0x04033378 RID: 209784
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04033379 RID: 209785
			[FieldOffset(24)]
			public bool DstSimulateEnable;
		}

		// Token: 0x0200A507 RID: 42247
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __DtGetBlockObjectType_FunctionParams
		{
			// Token: 0x0403337A RID: 209786
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x0403337B RID: 209787
			[FieldOffset(8)]
			public byte value;
		}

		// Token: 0x0200A508 RID: 42248
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2096)]
		protected ref struct __DtGetAllBulletData_FunctionParams
		{
			// Token: 0x0403337C RID: 209788
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x0403337D RID: 209789
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x0403337E RID: 209790
			[FieldOffset(16)]
			public byte NewParam;
		}

		// Token: 0x0200A509 RID: 42249
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 528)]
		protected ref struct __DtGetCaughtInfo_FunctionParams
		{
			// Token: 0x0403337F RID: 209791
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x04033380 RID: 209792
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x04033381 RID: 209793
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04033382 RID: 209794
			[FieldOffset(32)]
			public byte data;

			// Token: 0x04033383 RID: 209795
			[FieldOffset(272)]
			public bool __Result;
		}

		// Token: 0x0200A50A RID: 42250
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __DtGetVisionInfo_FunctionParams
		{
			// Token: 0x04033384 RID: 209796
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x04033385 RID: 209797
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x04033386 RID: 209798
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04033387 RID: 209799
			[FieldOffset(32)]
			public byte data;

			// Token: 0x04033388 RID: 209800
			[FieldOffset(184)]
			public bool __Result;
		}

		// Token: 0x0200A50B RID: 42251
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetInputMovementDirection_FunctionParams
		{
			// Token: 0x04033389 RID: 209801
			[FieldOffset(0)]
			public IntPtr BaseChar;

			// Token: 0x0403338A RID: 209802
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x0403338B RID: 209803
			[FieldOffset(16)]
			public TEnumAsByte<EMovementDirection> __Result;
		}

		// Token: 0x0200A50C RID: 42252
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 472)]
		protected ref struct __DtGetAllCharacterPartDatas_FunctionParams
		{
			// Token: 0x0403338C RID: 209804
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x0403338D RID: 209805
			[FieldOffset(8)]
			public byte partArrayRef;

			// Token: 0x0403338E RID: 209806
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A50D RID: 42253
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 568)]
		protected ref struct __DtGetAllSkillInfos_FunctionParams
		{
			// Token: 0x0403338F RID: 209807
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x04033390 RID: 209808
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04033391 RID: 209809
			[FieldOffset(16)]
			public byte NewParam;
		}

		// Token: 0x0200A50E RID: 42254
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4032)]
		protected ref struct __DtGetNewBulletData_FunctionParams
		{
			// Token: 0x04033392 RID: 209810
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x04033393 RID: 209811
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x04033394 RID: 209812
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04033395 RID: 209813
			[FieldOffset(32)]
			public byte data;

			// Token: 0x04033396 RID: 209814
			[FieldOffset(2024)]
			public bool __Result;
		}

		// Token: 0x0200A50F RID: 42255
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __DtGetEffectData_FunctionParams
		{
			// Token: 0x04033397 RID: 209815
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x04033398 RID: 209816
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x04033399 RID: 209817
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x0403339A RID: 209818
			[FieldOffset(32)]
			public byte data;

			// Token: 0x0403339B RID: 209819
			[FieldOffset(48)]
			public bool __Result;
		}

		// Token: 0x0200A510 RID: 42256
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __DtGetAttributeModifierData_FunctionParams
		{
			// Token: 0x0403339C RID: 209820
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x0403339D RID: 209821
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x0403339E RID: 209822
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x0403339F RID: 209823
			[FieldOffset(32)]
			public byte data;

			// Token: 0x040333A0 RID: 209824
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A511 RID: 42257
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __DtGetDamageData_FunctionParams
		{
			// Token: 0x040333A1 RID: 209825
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x040333A2 RID: 209826
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x040333A3 RID: 209827
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x040333A4 RID: 209828
			[FieldOffset(32)]
			public SDamageData data;

			// Token: 0x040333A5 RID: 209829
			[FieldOffset(40)]
			public bool __Result;
		}

		// Token: 0x0200A512 RID: 42258
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 976)]
		protected ref struct __DtGetSkillInfo_FunctionParams
		{
			// Token: 0x040333A6 RID: 209830
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x040333A7 RID: 209831
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x040333A8 RID: 209832
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x040333A9 RID: 209833
			[FieldOffset(32)]
			public byte data;

			// Token: 0x040333AA RID: 209834
			[FieldOffset(496)]
			public bool __Result;
		}

		// Token: 0x0200A513 RID: 42259
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 368)]
		protected ref struct __DtGetHitEffect_FunctionParams
		{
			// Token: 0x040333AB RID: 209835
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x040333AC RID: 209836
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x040333AD RID: 209837
			[FieldOffset(20)]
			public byte backData;

			// Token: 0x040333AE RID: 209838
			[FieldOffset(184)]
			public IntPtr __WorldContext;

			// Token: 0x040333AF RID: 209839
			[FieldOffset(192)]
			public bool __Result;
		}

		// Token: 0x0200A514 RID: 42260
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1456)]
		protected ref struct __DtGetBulletData_FunctionParams
		{
			// Token: 0x040333B0 RID: 209840
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x040333B1 RID: 209841
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x040333B2 RID: 209842
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x040333B3 RID: 209843
			[FieldOffset(32)]
			public byte data;

			// Token: 0x040333B4 RID: 209844
			[FieldOffset(736)]
			public bool __Result;
		}

		// Token: 0x0200A515 RID: 42261
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3552)]
		protected ref struct __DtGetMovementSettings_FunctionParams
		{
			// Token: 0x040333B5 RID: 209845
			[FieldOffset(0)]
			public IntPtr dataTable;

			// Token: 0x040333B6 RID: 209846
			[FieldOffset(8)]
			public FName rowName;

			// Token: 0x040333B7 RID: 209847
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x040333B8 RID: 209848
			[FieldOffset(32)]
			public byte data;

			// Token: 0x040333B9 RID: 209849
			[FieldOffset(1784)]
			public bool __Result;
		}

		// Token: 0x0200A516 RID: 42262
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __GetLocalWind_FunctionParams
		{
			// Token: 0x040333BA RID: 209850
			[FieldOffset(0)]
			public IntPtr AnimInstance;

			// Token: 0x040333BB RID: 209851
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x040333BC RID: 209852
			[FieldOffset(16)]
			public FVector LocalWind;
		}
	}
}
