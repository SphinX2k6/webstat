using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Vision;
using AkiClient.Game.Aki.Data.AI.Struct;
using AkiClient.Game.Aki.Data.Condition.Struct;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Fight.Struct;
using AkiClient.Game.Aki.Data.GMOrder.Struct;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using AkiClient.Game.Aki.Data.Manipulate;
using AkiClient.Game.Aki.Data.Parkour;
using AkiClient.Game.Aki.Data.Role.Struct;
using AkiClient.Game.Aki.Data.Scene3DUI.Struct;
using AkiClient.Game.Aki.Data.Server.Struct;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using AkiClient.Game.Aki.GamePlay.Cipher;
using AkiClient.Game.Aki.Sequence.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B3 RID: 14771
	[UnrealObjectPath("/Game/Aki/UI/Framework/DataTableUtil.DataTableUtil_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class DataTableUtil_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DD25 RID: 122149 RVA: 0x008E1C86 File Offset: 0x008DFE86
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DataTableUtil_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Framework/DataTableUtil.DataTableUtil_C");
			}
			return DataTableUtil_C._ClassPtr;
		}

		// Token: 0x0601DD26 RID: 122150 RVA: 0x008E1CAC File Offset: 0x008DFEAC
		public DataTableUtil_C() : this(BuiltinUtils.AllocNativeUObject(DataTableUtil_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DD27 RID: 122151 RVA: 0x008E1CD4 File Offset: 0x008DFED4
		[NullableContext(1)]
		public DataTableUtil_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DataTableUtil_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0601DD28 RID: 122152 RVA: 0x008E1D08 File Offset: 0x008DFF08
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadDecorationConfig([Nullable(1)] string Row, UObject __WorldContext, ref bool bSucc, ref SDecorationConfig result)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadDecorationConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadDecorationConfig_FunctionParams[(UIntPtr)791] + 15L / (long)sizeof(DataTableUtil_C.__LoadDecorationConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadDecorationConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Row), Row);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bSucc = bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SDecorationConfig.StaticStruct(), &ptr->result, result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadDecorationConfig_NativeFunctionPtr, (void*)ptr);
			bSucc = ptr->bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SDecorationConfig.StaticStruct(), result.NativePtr, &ptr->result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadDecorationConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD29 RID: 122153 RVA: 0x008E1DDC File Offset: 0x008DFFDC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetDataTableOnEditor([Nullable(1)] string path, UObject __WorldContext, ref UDataTable Return)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__GetDataTableOnEditor_FunctionParams* ptr = stackalloc DataTableUtil_C.__GetDataTableOnEditor_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(DataTableUtil_C.__GetDataTableOnEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__GetDataTableOnEditor_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->path), path);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref DataTableUtil_C.__GetDataTableOnEditor_FunctionParams ptr2 = ref *ptr;
			UDataTable udataTable = Return;
			ptr2.Return = ((udataTable != null) ? udataTable.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__GetDataTableOnEditor_NativeFunctionPtr, (void*)ptr);
			Return = BuiltinUtils.GetOrCreateUObjectByNativePointer<UDataTable>(ptr->Return);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__GetDataTableOnEditor_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD2A RID: 122154 RVA: 0x008E1E7C File Offset: 0x008E007C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadAiWeaponSocketConfigs(FName RowName, in int Key, UObject __WorldContext, ref SWeaponSocketItem Weapon)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAiWeaponSocketConfigs_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAiWeaponSocketConfigs_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(DataTableUtil_C.__LoadAiWeaponSocketConfigs_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAiWeaponSocketConfigs_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->Key = Key;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (Weapon != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponSocketItem.StaticStruct(), &ptr->Weapon, Weapon.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAiWeaponSocketConfigs_NativeFunctionPtr, (void*)ptr);
			if (Weapon != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponSocketItem.StaticStruct(), Weapon.NativePtr, &ptr->Weapon, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAiWeaponSocketConfigs_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD2B RID: 122155 RVA: 0x008E1F44 File Offset: 0x008E0144
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadAiWeaponSocket(FName RowName, UObject __WorldContext, ref SAiWeaponSocket Out_Row)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAiWeaponSocket_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAiWeaponSocket_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(DataTableUtil_C.__LoadAiWeaponSocket_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAiWeaponSocket_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiWeaponSocket.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAiWeaponSocket_NativeFunctionPtr, (void*)ptr);
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiWeaponSocket.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAiWeaponSocket_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD2C RID: 122156 RVA: 0x008E2004 File Offset: 0x008E0204
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadAllAiWeaponSockets(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TMap<int, SAiWeaponSocket> Sockets)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAllAiWeaponSockets_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAllAiWeaponSockets_FunctionParams[(UIntPtr)359] + 15L / (long)sizeof(DataTableUtil_C.__LoadAllAiWeaponSockets_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAllAiWeaponSockets_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TMap<int, SAiWeaponSocket> tmap = Sockets;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->Sockets);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAllAiWeaponSockets_NativeFunctionPtr, (void*)ptr);
			TMap<int, SAiWeaponSocket> tmap2 = Sockets;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->Sockets);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAllAiWeaponSockets_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD2D RID: 122157 RVA: 0x008E209C File Offset: 0x008E029C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static SSceneUITagConfig LoadSceneUITagConfig(string RowName, [Nullable(2)] UObject __WorldContext, ref bool bFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadSceneUITagConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadSceneUITagConfig_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(DataTableUtil_C.__LoadSceneUITagConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadSceneUITagConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->RowName), RowName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bFound = bFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadSceneUITagConfig_NativeFunctionPtr, (void*)ptr);
			bFound = ptr->bFound;
			SSceneUITagConfig result = new SSceneUITagConfig(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadSceneUITagConfig_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD2E RID: 122158 RVA: 0x008E2134 File Offset: 0x008E0334
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static SSceneDecorationConfig LoadSceneDecorationConfig(string RowName, [Nullable(2)] UObject __WorldContext, ref bool bFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadSceneDecorationConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadSceneDecorationConfig_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(DataTableUtil_C.__LoadSceneDecorationConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadSceneDecorationConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->RowName), RowName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bFound = bFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadSceneDecorationConfig_NativeFunctionPtr, (void*)ptr);
			bFound = ptr->bFound;
			SSceneDecorationConfig result = new SSceneDecorationConfig(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadSceneDecorationConfig_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD2F RID: 122159 RVA: 0x008E21D0 File Offset: 0x008E03D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadManipulateItemConfig([Nullable(1)] string inRow, UObject __WorldContext, ref SManipulateConfig outConfig, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadManipulateItemConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadManipulateItemConfig_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(DataTableUtil_C.__LoadManipulateItemConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadManipulateItemConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SManipulateConfig.StaticStruct(), &ptr->outConfig, outConfig.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadManipulateItemConfig_NativeFunctionPtr, (void*)ptr);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SManipulateConfig.StaticStruct(), outConfig.NativePtr, &ptr->outConfig, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadManipulateItemConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD30 RID: 122160 RVA: 0x008E22A4 File Offset: 0x008E04A4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadManipulatePrecastConfig([Nullable(1)] string inRow, UObject __WorldContext, ref SManipulateConfig outConfig, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadManipulatePrecastConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadManipulatePrecastConfig_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(DataTableUtil_C.__LoadManipulatePrecastConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadManipulatePrecastConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SManipulateConfig.StaticStruct(), &ptr->outConfig, outConfig.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadManipulatePrecastConfig_NativeFunctionPtr, (void*)ptr);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SManipulateConfig.StaticStruct(), outConfig.NativePtr, &ptr->outConfig, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadManipulatePrecastConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD31 RID: 122161 RVA: 0x008E2378 File Offset: 0x008E0578
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadCharacterFightInfo(UDataTable CharacterFightInfo, [Nullable(1)] string CharacterResourcePath, UObject __WorldContext, ref SCharacterFightInfo outInfo, ref bool outIsFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadCharacterFightInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadCharacterFightInfo_FunctionParams[(UIntPtr)1543] + 15L / (long)sizeof(DataTableUtil_C.__LoadCharacterFightInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadCharacterFightInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CharacterFightInfo = ((CharacterFightInfo != null) ? CharacterFightInfo.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->CharacterResourcePath), CharacterResourcePath);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCharacterFightInfo.StaticStruct(), &ptr->outInfo, outInfo.NativePtr, 1, false);
			}
			ptr->outIsFound = outIsFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadCharacterFightInfo_NativeFunctionPtr, (void*)ptr);
			if (outInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCharacterFightInfo.StaticStruct(), outInfo.NativePtr, &ptr->outInfo, 1, false);
			}
			outIsFound = ptr->outIsFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadCharacterFightInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD32 RID: 122162 RVA: 0x008E2464 File Offset: 0x008E0664
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static TArray<SSkillMontage> LoadAllSkillMontages([Nullable(2)] UObject __WorldContext)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAllSkillMontages_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAllSkillMontages_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(DataTableUtil_C.__LoadAllSkillMontages_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAllSkillMontages_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAllSkillMontages_NativeFunctionPtr, (void*)ptr);
			TArray<SSkillMontage> result = new TArray<SSkillMontage>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAllSkillMontages_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD33 RID: 122163 RVA: 0x008E24E0 File Offset: 0x008E06E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadParkourConfig(FName RowName, UObject __WorldContext, ref SParkourConfig 输出行, ref bool found)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadParkourConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadParkourConfig_FunctionParams[(UIntPtr)535] + 15L / (long)sizeof(DataTableUtil_C.__LoadParkourConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadParkourConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RowName = RowName;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (输出行 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SParkourConfig.StaticStruct(), &ptr->输出行, 输出行.NativePtr, 1, false);
			}
			ptr->found = found;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadParkourConfig_NativeFunctionPtr, (void*)ptr);
			if (输出行 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SParkourConfig.StaticStruct(), 输出行.NativePtr, &ptr->输出行, 1, false);
			}
			found = ptr->found;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadParkourConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD34 RID: 122164 RVA: 0x008E25B0 File Offset: 0x008E07B0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static TArray<SCamp> LoadAllCampConfigs([Nullable(2)] UObject __WorldContext)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAllCampConfigs_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAllCampConfigs_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(DataTableUtil_C.__LoadAllCampConfigs_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAllCampConfigs_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAllCampConfigs_NativeFunctionPtr, (void*)ptr);
			TArray<SCamp> result = new TArray<SCamp>(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAllCampConfigs_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD35 RID: 122165 RVA: 0x008E262C File Offset: 0x008E082C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetCampNum(int Camp, UObject __WorldContext, ref ECamp Num)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__GetCampNum_FunctionParams* ptr = stackalloc DataTableUtil_C.__GetCampNum_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(DataTableUtil_C.__GetCampNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__GetCampNum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Camp = Camp;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->Num = Num;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__GetCampNum_NativeFunctionPtr, (void*)ptr);
			Num = ptr->Num;
		}

		// Token: 0x0601DD36 RID: 122166 RVA: 0x008E26A8 File Offset: 0x008E08A8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadHitMapConfig(int MapId, UObject __WorldContext, ref SHitMapping result, ref bool found)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadHitMapConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadHitMapConfig_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(DataTableUtil_C.__LoadHitMapConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadHitMapConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MapId = MapId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitMapping.StaticStruct(), &ptr->result, result.NativePtr, 1, false);
			}
			ptr->found = found;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadHitMapConfig_NativeFunctionPtr, (void*)ptr);
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SHitMapping.StaticStruct(), result.NativePtr, &ptr->result, 1, false);
			}
			found = ptr->found;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadHitMapConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD37 RID: 122167 RVA: 0x008E2778 File Offset: 0x008E0978
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadCampConfig(int CampNum, UObject __WorldContext, ref SCamp CampInfo, ref bool Found)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadCampConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadCampConfig_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(DataTableUtil_C.__LoadCampConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadCampConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CampNum = CampNum;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (CampInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamp.StaticStruct(), &ptr->CampInfo, CampInfo.NativePtr, 1, false);
			}
			ptr->Found = Found;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadCampConfig_NativeFunctionPtr, (void*)ptr);
			if (CampInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCamp.StaticStruct(), CampInfo.NativePtr, &ptr->CampInfo, 1, false);
			}
			Found = ptr->Found;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadCampConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD38 RID: 122168 RVA: 0x008E2848 File Offset: 0x008E0A48
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadAIConfig([Nullable(1)] string inConfigId, UObject __WorldContext, ref SAIConfig Out_Row, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadAIConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadAIConfig_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(DataTableUtil_C.__LoadAIConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadAIConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inConfigId), inConfigId);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAIConfig.StaticStruct(), &ptr->Out_Row, Out_Row.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadAIConfig_NativeFunctionPtr, (void*)ptr);
			if (Out_Row != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SAIConfig.StaticStruct(), Out_Row.NativePtr, &ptr->Out_Row, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadAIConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD39 RID: 122169 RVA: 0x008E291C File Offset: 0x008E0B1C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static SUiCameraAnimationBlendSettings LoadUiCameraAnimationBlendSettings(string RowName, [Nullable(2)] UObject __WorldContext, ref bool bFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_FunctionParams[(UIntPtr)447] + 15L / (long)sizeof(DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->RowName), RowName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bFound = bFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_NativeFunctionPtr, (void*)ptr);
			bFound = ptr->bFound;
			SUiCameraAnimationBlendSettings result = new SUiCameraAnimationBlendSettings(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadUiCameraAnimationBlendSettings_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD3A RID: 122170 RVA: 0x008E29B8 File Offset: 0x008E0BB8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static SUiCameraAnimationSettings LoadUiCameraAnimationSettings(string RowName, [Nullable(2)] UObject __WorldContext, ref bool bFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadUiCameraAnimationSettings_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadUiCameraAnimationSettings_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(DataTableUtil_C.__LoadUiCameraAnimationSettings_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadUiCameraAnimationSettings_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->RowName), RowName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bFound = bFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadUiCameraAnimationSettings_NativeFunctionPtr, (void*)ptr);
			bFound = ptr->bFound;
			SUiCameraAnimationSettings result = new SUiCameraAnimationSettings(&ptr->__Result, true, true);
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadUiCameraAnimationSettings_NativeFunctionPtr, (void*)ptr, 1);
			return result;
		}

		// Token: 0x0601DD3B RID: 122171 RVA: 0x008E2A54 File Offset: 0x008E0C54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadInteractionConfig([Nullable(1)] string inRow, UObject __WorldContext, ref SInteractionConfig ouConfig, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadInteractionConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadInteractionConfig_FunctionParams[(UIntPtr)479] + 15L / (long)sizeof(DataTableUtil_C.__LoadInteractionConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadInteractionConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (ouConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SInteractionConfig.StaticStruct(), &ptr->ouConfig, ouConfig.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadInteractionConfig_NativeFunctionPtr, (void*)ptr);
			if (ouConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SInteractionConfig.StaticStruct(), ouConfig.NativePtr, &ptr->ouConfig, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadInteractionConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD3C RID: 122172 RVA: 0x008E2B28 File Offset: 0x008E0D28
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadCipherInfo([Nullable(1)] string inRow, UObject __WorldContext, ref SCipherGameplay outConfig, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadCipherInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadCipherInfo_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(DataTableUtil_C.__LoadCipherInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadCipherInfo_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCipherGameplay.StaticStruct(), &ptr->outConfig, outConfig.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadCipherInfo_NativeFunctionPtr, (void*)ptr);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SCipherGameplay.StaticStruct(), outConfig.NativePtr, &ptr->outConfig, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadCipherInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD3D RID: 122173 RVA: 0x008E2BFC File Offset: 0x008E0DFC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadConditionGroupInfo([Nullable(1)] string inRow, UObject __WorldContext, ref SConditionGroup outConfig, ref bool outFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadConditionGroupInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadConditionGroupInfo_FunctionParams[(UIntPtr)223] + 15L / (long)sizeof(DataTableUtil_C.__LoadConditionGroupInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadConditionGroupInfo_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SConditionGroup.StaticStruct(), &ptr->outConfig, outConfig.NativePtr, 1, false);
			}
			ptr->outFound = outFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadConditionGroupInfo_NativeFunctionPtr, (void*)ptr);
			if (outConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SConditionGroup.StaticStruct(), outConfig.NativePtr, &ptr->outConfig, 1, false);
			}
			outFound = ptr->outFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadConditionGroupInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD3E RID: 122174 RVA: 0x008E2CD0 File Offset: 0x008E0ED0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadGmOrderInfo(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SGMOrderInfo> gmInfoList1)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadGmOrderInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadGmOrderInfo_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(DataTableUtil_C.__LoadGmOrderInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadGmOrderInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<SGMOrderInfo> tarray = gmInfoList1;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->gmInfoList1);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadGmOrderInfo_NativeFunctionPtr, (void*)ptr);
			TArray<SGMOrderInfo> tarray2 = gmInfoList1;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->gmInfoList1);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadGmOrderInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD3F RID: 122175 RVA: 0x008E2D64 File Offset: 0x008E0F64
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadSeqNetworksInfo(UDataTable inSeqNetwork, [Nullable(1)] string inRow, UObject __WorldContext, ref SSequencesNetwork outInfo, ref bool outIsFound)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadSeqNetworksInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadSeqNetworksInfo_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(DataTableUtil_C.__LoadSeqNetworksInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadSeqNetworksInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inSeqNetwork = ((inSeqNetwork != null) ? inSeqNetwork.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->inRow), inRow);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (outInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSequencesNetwork.StaticStruct(), &ptr->outInfo, outInfo.NativePtr, 1, false);
			}
			ptr->outIsFound = outIsFound;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadSeqNetworksInfo_NativeFunctionPtr, (void*)ptr);
			if (outInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SSequencesNetwork.StaticStruct(), outInfo.NativePtr, &ptr->outInfo, 1, false);
			}
			outIsFound = ptr->outIsFound;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadSeqNetworksInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD40 RID: 122176 RVA: 0x008E2E50 File Offset: 0x008E1050
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadVisionInfo([Nullable(1)] string phantomId, UObject __WorldContext, ref SVisionData visionConfig, ref bool found)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadVisionInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadVisionInfo_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(DataTableUtil_C.__LoadVisionInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadVisionInfo_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->phantomId), phantomId);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (visionConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), &ptr->visionConfig, visionConfig.NativePtr, 1, false);
			}
			ptr->found = found;
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadVisionInfo_NativeFunctionPtr, (void*)ptr);
			if (visionConfig != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SVisionData.StaticStruct(), visionConfig.NativePtr, &ptr->visionConfig, 1, false);
			}
			found = ptr->found;
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadVisionInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD41 RID: 122177 RVA: 0x008E2F24 File Offset: 0x008E1124
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadServerInfo(UObject __WorldContext, [Nullable(new byte[]
		{
			2,
			1
		})] ref TArray<SServerInfo> NewParam)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadServerInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadServerInfo_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(DataTableUtil_C.__LoadServerInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadServerInfo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			TArray<SServerInfo> tarray = NewParam;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->NewParam);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadServerInfo_NativeFunctionPtr, (void*)ptr);
			TArray<SServerInfo> tarray2 = NewParam;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->NewParam);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadServerInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD42 RID: 122178 RVA: 0x008E2FBC File Offset: 0x008E11BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadModelConfig([Nullable(1)] string Row, UObject __WorldContext, ref bool bSucc, ref SModelConfig result)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadModelConfig_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadModelConfig_FunctionParams[(UIntPtr)2359] + 15L / (long)sizeof(DataTableUtil_C.__LoadModelConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadModelConfig_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Row), Row);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bSucc = bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SModelConfig.StaticStruct(), &ptr->result, result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadModelConfig_NativeFunctionPtr, (void*)ptr);
			bSucc = ptr->bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SModelConfig.StaticStruct(), result.NativePtr, &ptr->result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadModelConfig_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD43 RID: 122179 RVA: 0x008E3090 File Offset: 0x008E1290
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void LoadRoleQualityInfo([Nullable(1)] string Row, UObject __WorldContext, ref bool bSucc, ref SRoleQualityInfo result)
		{
			DataTableUtil_C.StaticClass();
			DataTableUtil_C.__LoadRoleQualityInfo_FunctionParams* ptr = stackalloc DataTableUtil_C.__LoadRoleQualityInfo_FunctionParams[(UIntPtr)327] + 15L / (long)sizeof(DataTableUtil_C.__LoadRoleQualityInfo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(DataTableUtil_C.__LoadRoleQualityInfo_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Row), Row);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->bSucc = bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SRoleQualityInfo.StaticStruct(), &ptr->result, result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(DataTableUtil_C._ClassDefaultObjectPtr, DataTableUtil_C.__LoadRoleQualityInfo_NativeFunctionPtr, (void*)ptr);
			bSucc = ptr->bSucc;
			if (result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SRoleQualityInfo.StaticStruct(), result.NativePtr, &ptr->result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(DataTableUtil_C.__LoadRoleQualityInfo_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD44 RID: 122180 RVA: 0x008E3163 File Offset: 0x008E1363
		protected DataTableUtil_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E981 RID: 59777
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Framework/DataTableUtil.DataTableUtil_C";

		// Token: 0x0400E982 RID: 59778
		private static IntPtr _ClassPtr;

		// Token: 0x0400E983 RID: 59779
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E984 RID: 59780
		private static IntPtr __LoadDecorationConfig_NativeFunctionPtr;

		// Token: 0x0400E985 RID: 59781
		private static IntPtr __GetDataTableOnEditor_NativeFunctionPtr;

		// Token: 0x0400E986 RID: 59782
		private static IntPtr __LoadAiWeaponSocketConfigs_NativeFunctionPtr;

		// Token: 0x0400E987 RID: 59783
		private static IntPtr __LoadAiWeaponSocket_NativeFunctionPtr;

		// Token: 0x0400E988 RID: 59784
		private static IntPtr __LoadAllAiWeaponSockets_NativeFunctionPtr;

		// Token: 0x0400E989 RID: 59785
		private static IntPtr __LoadSceneUITagConfig_NativeFunctionPtr;

		// Token: 0x0400E98A RID: 59786
		private static IntPtr __LoadSceneDecorationConfig_NativeFunctionPtr;

		// Token: 0x0400E98B RID: 59787
		private static IntPtr __LoadManipulateItemConfig_NativeFunctionPtr;

		// Token: 0x0400E98C RID: 59788
		private static IntPtr __LoadManipulatePrecastConfig_NativeFunctionPtr;

		// Token: 0x0400E98D RID: 59789
		private static IntPtr __LoadCharacterFightInfo_NativeFunctionPtr;

		// Token: 0x0400E98E RID: 59790
		private static IntPtr __LoadAllSkillMontages_NativeFunctionPtr;

		// Token: 0x0400E98F RID: 59791
		private static IntPtr __LoadParkourConfig_NativeFunctionPtr;

		// Token: 0x0400E990 RID: 59792
		private static IntPtr __LoadAllCampConfigs_NativeFunctionPtr;

		// Token: 0x0400E991 RID: 59793
		private static IntPtr __GetCampNum_NativeFunctionPtr;

		// Token: 0x0400E992 RID: 59794
		private static IntPtr __LoadHitMapConfig_NativeFunctionPtr;

		// Token: 0x0400E993 RID: 59795
		private static IntPtr __LoadCampConfig_NativeFunctionPtr;

		// Token: 0x0400E994 RID: 59796
		private static IntPtr __LoadAIConfig_NativeFunctionPtr;

		// Token: 0x0400E995 RID: 59797
		private static IntPtr __LoadUiCameraAnimationBlendSettings_NativeFunctionPtr;

		// Token: 0x0400E996 RID: 59798
		private static IntPtr __LoadUiCameraAnimationSettings_NativeFunctionPtr;

		// Token: 0x0400E997 RID: 59799
		private static IntPtr __LoadInteractionConfig_NativeFunctionPtr;

		// Token: 0x0400E998 RID: 59800
		private static IntPtr __LoadCipherInfo_NativeFunctionPtr;

		// Token: 0x0400E999 RID: 59801
		private static IntPtr __LoadConditionGroupInfo_NativeFunctionPtr;

		// Token: 0x0400E99A RID: 59802
		private static IntPtr __LoadGmOrderInfo_NativeFunctionPtr;

		// Token: 0x0400E99B RID: 59803
		private static IntPtr __LoadSeqNetworksInfo_NativeFunctionPtr;

		// Token: 0x0400E99C RID: 59804
		private static IntPtr __LoadVisionInfo_NativeFunctionPtr;

		// Token: 0x0400E99D RID: 59805
		private static IntPtr __LoadServerInfo_NativeFunctionPtr;

		// Token: 0x0400E99E RID: 59806
		private static IntPtr __LoadModelConfig_NativeFunctionPtr;

		// Token: 0x0400E99F RID: 59807
		private static IntPtr __LoadRoleQualityInfo_NativeFunctionPtr;

		// Token: 0x020096DC RID: 38620
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 776)]
		protected ref struct __LoadDecorationConfig_FunctionParams
		{
			// Token: 0x04031BCF RID: 203727
			[FieldOffset(0)]
			public FString Row;

			// Token: 0x04031BD0 RID: 203728
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BD1 RID: 203729
			[FieldOffset(24)]
			public bool bSucc;

			// Token: 0x04031BD2 RID: 203730
			[FieldOffset(32)]
			public byte result;
		}

		// Token: 0x020096DD RID: 38621
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetDataTableOnEditor_FunctionParams
		{
			// Token: 0x04031BD3 RID: 203731
			[FieldOffset(0)]
			public FString path;

			// Token: 0x04031BD4 RID: 203732
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BD5 RID: 203733
			[FieldOffset(24)]
			public IntPtr Return;
		}

		// Token: 0x020096DE RID: 38622
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __LoadAiWeaponSocketConfigs_FunctionParams
		{
			// Token: 0x04031BD6 RID: 203734
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04031BD7 RID: 203735
			[FieldOffset(12)]
			public int Key;

			// Token: 0x04031BD8 RID: 203736
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BD9 RID: 203737
			[FieldOffset(24)]
			public byte Weapon;
		}

		// Token: 0x020096DF RID: 38623
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __LoadAiWeaponSocket_FunctionParams
		{
			// Token: 0x04031BDA RID: 203738
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04031BDB RID: 203739
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BDC RID: 203740
			[FieldOffset(24)]
			public byte Out_Row;
		}

		// Token: 0x020096E0 RID: 38624
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 344)]
		protected ref struct __LoadAllAiWeaponSockets_FunctionParams
		{
			// Token: 0x04031BDD RID: 203741
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04031BDE RID: 203742
			[FieldOffset(8)]
			public byte Sockets;
		}

		// Token: 0x020096E1 RID: 38625
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __LoadSceneUITagConfig_FunctionParams
		{
			// Token: 0x04031BDF RID: 203743
			[FieldOffset(0)]
			public FString RowName;

			// Token: 0x04031BE0 RID: 203744
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BE1 RID: 203745
			[FieldOffset(24)]
			public byte __Result;

			// Token: 0x04031BE2 RID: 203746
			[FieldOffset(40)]
			public bool bFound;
		}

		// Token: 0x020096E2 RID: 38626
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __LoadSceneDecorationConfig_FunctionParams
		{
			// Token: 0x04031BE3 RID: 203747
			[FieldOffset(0)]
			public FString RowName;

			// Token: 0x04031BE4 RID: 203748
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BE5 RID: 203749
			[FieldOffset(24)]
			public byte __Result;

			// Token: 0x04031BE6 RID: 203750
			[FieldOffset(72)]
			public bool bFound;
		}

		// Token: 0x020096E3 RID: 38627
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __LoadManipulateItemConfig_FunctionParams
		{
			// Token: 0x04031BE7 RID: 203751
			[FieldOffset(0)]
			public FString inRow;

			// Token: 0x04031BE8 RID: 203752
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BE9 RID: 203753
			[FieldOffset(24)]
			public byte outConfig;

			// Token: 0x04031BEA RID: 203754
			[FieldOffset(64)]
			public bool outFound;
		}

		// Token: 0x020096E4 RID: 38628
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __LoadManipulatePrecastConfig_FunctionParams
		{
			// Token: 0x04031BEB RID: 203755
			[FieldOffset(0)]
			public FString inRow;

			// Token: 0x04031BEC RID: 203756
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BED RID: 203757
			[FieldOffset(24)]
			public byte outConfig;

			// Token: 0x04031BEE RID: 203758
			[FieldOffset(64)]
			public bool outFound;
		}

		// Token: 0x020096E5 RID: 38629
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1528)]
		protected ref struct __LoadCharacterFightInfo_FunctionParams
		{
			// Token: 0x04031BEF RID: 203759
			[FieldOffset(0)]
			public IntPtr CharacterFightInfo;

			// Token: 0x04031BF0 RID: 203760
			[FieldOffset(8)]
			public FString CharacterResourcePath;

			// Token: 0x04031BF1 RID: 203761
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04031BF2 RID: 203762
			[FieldOffset(32)]
			public byte outInfo;

			// Token: 0x04031BF3 RID: 203763
			[FieldOffset(768)]
			public bool outIsFound;
		}

		// Token: 0x020096E6 RID: 38630
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __LoadAllSkillMontages_FunctionParams
		{
			// Token: 0x04031BF4 RID: 203764
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04031BF5 RID: 203765
			[FieldOffset(8)]
			public byte __Result;
		}

		// Token: 0x020096E7 RID: 38631
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 520)]
		protected ref struct __LoadParkourConfig_FunctionParams
		{
			// Token: 0x04031BF6 RID: 203766
			[FieldOffset(0)]
			public FName RowName;

			// Token: 0x04031BF7 RID: 203767
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031BF8 RID: 203768
			[FieldOffset(24)]
			public byte 输出行;

			// Token: 0x04031BF9 RID: 203769
			[FieldOffset(264)]
			public bool found;
		}

		// Token: 0x020096E8 RID: 38632
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __LoadAllCampConfigs_FunctionParams
		{
			// Token: 0x04031BFA RID: 203770
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04031BFB RID: 203771
			[FieldOffset(8)]
			public byte __Result;
		}

		// Token: 0x020096E9 RID: 38633
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __GetCampNum_FunctionParams
		{
			// Token: 0x04031BFC RID: 203772
			[FieldOffset(0)]
			public int Camp;

			// Token: 0x04031BFD RID: 203773
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04031BFE RID: 203774
			[FieldOffset(16)]
			public TEnumAsByte<ECamp> Num;
		}

		// Token: 0x020096EA RID: 38634
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __LoadHitMapConfig_FunctionParams
		{
			// Token: 0x04031BFF RID: 203775
			[FieldOffset(0)]
			public int MapId;

			// Token: 0x04031C00 RID: 203776
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04031C01 RID: 203777
			[FieldOffset(16)]
			public byte result;

			// Token: 0x04031C02 RID: 203778
			[FieldOffset(56)]
			public bool found;
		}

		// Token: 0x020096EB RID: 38635
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __LoadCampConfig_FunctionParams
		{
			// Token: 0x04031C03 RID: 203779
			[FieldOffset(0)]
			public int CampNum;

			// Token: 0x04031C04 RID: 203780
			[FieldOffset(8)]
			public IntPtr __WorldContext;

			// Token: 0x04031C05 RID: 203781
			[FieldOffset(16)]
			public byte CampInfo;

			// Token: 0x04031C06 RID: 203782
			[FieldOffset(32)]
			public bool Found;
		}

		// Token: 0x020096EC RID: 38636
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __LoadAIConfig_FunctionParams
		{
			// Token: 0x04031C07 RID: 203783
			[FieldOffset(0)]
			public FString inConfigId;

			// Token: 0x04031C08 RID: 203784
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C09 RID: 203785
			[FieldOffset(24)]
			public byte Out_Row;

			// Token: 0x04031C0A RID: 203786
			[FieldOffset(104)]
			public bool outFound;
		}

		// Token: 0x020096ED RID: 38637
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 432)]
		protected ref struct __LoadUiCameraAnimationBlendSettings_FunctionParams
		{
			// Token: 0x04031C0B RID: 203787
			[FieldOffset(0)]
			public FString RowName;

			// Token: 0x04031C0C RID: 203788
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C0D RID: 203789
			[FieldOffset(24)]
			public byte __Result;

			// Token: 0x04031C0E RID: 203790
			[FieldOffset(216)]
			public bool bFound;
		}

		// Token: 0x020096EE RID: 38638
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __LoadUiCameraAnimationSettings_FunctionParams
		{
			// Token: 0x04031C0F RID: 203791
			[FieldOffset(0)]
			public FString RowName;

			// Token: 0x04031C10 RID: 203792
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C11 RID: 203793
			[FieldOffset(24)]
			public byte __Result;

			// Token: 0x04031C12 RID: 203794
			[FieldOffset(472)]
			public bool bFound;
		}

		// Token: 0x020096EF RID: 38639
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 464)]
		protected ref struct __LoadInteractionConfig_FunctionParams
		{
			// Token: 0x04031C13 RID: 203795
			[FieldOffset(0)]
			public FString inRow;

			// Token: 0x04031C14 RID: 203796
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C15 RID: 203797
			[FieldOffset(24)]
			public byte ouConfig;

			// Token: 0x04031C16 RID: 203798
			[FieldOffset(232)]
			public bool outFound;
		}

		// Token: 0x020096F0 RID: 38640
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __LoadCipherInfo_FunctionParams
		{
			// Token: 0x04031C17 RID: 203799
			[FieldOffset(0)]
			public FString inRow;

			// Token: 0x04031C18 RID: 203800
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C19 RID: 203801
			[FieldOffset(24)]
			public byte outConfig;

			// Token: 0x04031C1A RID: 203802
			[FieldOffset(112)]
			public bool outFound;
		}

		// Token: 0x020096F1 RID: 38641
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 208)]
		protected ref struct __LoadConditionGroupInfo_FunctionParams
		{
			// Token: 0x04031C1B RID: 203803
			[FieldOffset(0)]
			public FString inRow;

			// Token: 0x04031C1C RID: 203804
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C1D RID: 203805
			[FieldOffset(24)]
			public byte outConfig;

			// Token: 0x04031C1E RID: 203806
			[FieldOffset(104)]
			public bool outFound;
		}

		// Token: 0x020096F2 RID: 38642
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __LoadGmOrderInfo_FunctionParams
		{
			// Token: 0x04031C1F RID: 203807
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04031C20 RID: 203808
			[FieldOffset(8)]
			public byte gmInfoList1;
		}

		// Token: 0x020096F3 RID: 38643
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __LoadSeqNetworksInfo_FunctionParams
		{
			// Token: 0x04031C21 RID: 203809
			[FieldOffset(0)]
			public IntPtr inSeqNetwork;

			// Token: 0x04031C22 RID: 203810
			[FieldOffset(8)]
			public FString inRow;

			// Token: 0x04031C23 RID: 203811
			[FieldOffset(24)]
			public IntPtr __WorldContext;

			// Token: 0x04031C24 RID: 203812
			[FieldOffset(32)]
			public byte outInfo;

			// Token: 0x04031C25 RID: 203813
			[FieldOffset(160)]
			public bool outIsFound;
		}

		// Token: 0x020096F4 RID: 38644
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __LoadVisionInfo_FunctionParams
		{
			// Token: 0x04031C26 RID: 203814
			[FieldOffset(0)]
			public FString phantomId;

			// Token: 0x04031C27 RID: 203815
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C28 RID: 203816
			[FieldOffset(24)]
			public byte visionConfig;

			// Token: 0x04031C29 RID: 203817
			[FieldOffset(176)]
			public bool found;
		}

		// Token: 0x020096F5 RID: 38645
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __LoadServerInfo_FunctionParams
		{
			// Token: 0x04031C2A RID: 203818
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04031C2B RID: 203819
			[FieldOffset(8)]
			public byte NewParam;
		}

		// Token: 0x020096F6 RID: 38646
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2344)]
		protected ref struct __LoadModelConfig_FunctionParams
		{
			// Token: 0x04031C2C RID: 203820
			[FieldOffset(0)]
			public FString Row;

			// Token: 0x04031C2D RID: 203821
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C2E RID: 203822
			[FieldOffset(24)]
			public bool bSucc;

			// Token: 0x04031C2F RID: 203823
			[FieldOffset(32)]
			public byte result;
		}

		// Token: 0x020096F7 RID: 38647
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 312)]
		protected ref struct __LoadRoleQualityInfo_FunctionParams
		{
			// Token: 0x04031C30 RID: 203824
			[FieldOffset(0)]
			public FString Row;

			// Token: 0x04031C31 RID: 203825
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04031C32 RID: 203826
			[FieldOffset(24)]
			public bool bSucc;

			// Token: 0x04031C33 RID: 203827
			[FieldOffset(32)]
			public byte result;
		}
	}
}
