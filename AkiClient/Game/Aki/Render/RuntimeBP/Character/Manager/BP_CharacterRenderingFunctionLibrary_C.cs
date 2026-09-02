using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager
{
	// Token: 0x02003D8E RID: 15758
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Manager/BP_CharacterRenderingFunctionLibrary.BP_CharacterRenderingFunctionLibrary_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_CharacterRenderingFunctionLibrary_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602675C RID: 157532 RVA: 0x009D859B File Offset: 0x009D679B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterRenderingFunctionLibrary_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Manager/BP_CharacterRenderingFunctionLibrary.BP_CharacterRenderingFunctionLibrary_C");
			}
			return BP_CharacterRenderingFunctionLibrary_C._ClassPtr;
		}

		// Token: 0x0602675D RID: 157533 RVA: 0x009D85C0 File Offset: 0x009D67C0
		public BP_CharacterRenderingFunctionLibrary_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterRenderingFunctionLibrary_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602675E RID: 157534 RVA: 0x009D85E8 File Offset: 0x009D67E8
		[NullableContext(1)]
		public BP_CharacterRenderingFunctionLibrary_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterRenderingFunctionLibrary_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602675F RID: 157535 RVA: 0x009D861C File Offset: 0x009D681C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void SetNiagaraSkeletalMeshSimpleNPC(UNiagaraComponent NiagaraComponen, [Nullable(1)] string ParamName, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NiagaraComponen = ((NiagaraComponen != null) ? NiagaraComponen.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->ParamName), ParamName);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CharacterRenderingFunctionLibrary_C.__SetNiagaraSkeletalMeshSimpleNPC_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026760 RID: 157536 RVA: 0x009D86AC File Offset: 0x009D68AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerDataGroup_MeshComponent(UMeshComponent meshComponent, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_MeshComponent_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_MeshComponent_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_MeshComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_MeshComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->meshComponent = ((meshComponent != null) ? meshComponent.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_MeshComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026761 RID: 157537 RVA: 0x009D8724 File Offset: 0x009D6924
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddDataGroup_MeshComponent(USkeletalMeshComponent MeshComponent, PD_CharacterControllerDataGroup_C Data, UObject __WorldContext, ref float HandleId, ref CharRenderingComponent CharRenderComponent)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComponent = ((MeshComponent != null) ? MeshComponent.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ref BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_FunctionParams ptr2 = ref *ptr;
			CharRenderingComponent charRenderingComponent = CharRenderComponent;
			ptr2.CharRenderComponent = ((charRenderingComponent != null) ? charRenderingComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_MeshComponent_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
			CharRenderComponent = BuiltinUtils.GetOrCreateUObjectByNativePointer<CharRenderingComponent>(ptr->CharRenderComponent);
		}

		// Token: 0x06026762 RID: 157538 RVA: 0x009D87E4 File Offset: 0x009D69E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void AddMaterialControllerDataForAllCases(AActor Actor, PD_CharacterControllerData_C Data, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__AddMaterialControllerDataForAllCases_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__AddMaterialControllerDataForAllCases_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__AddMaterialControllerDataForAllCases_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__AddMaterialControllerDataForAllCases_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Actor = ((Actor != null) ? Actor.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__AddMaterialControllerDataForAllCases_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026763 RID: 157539 RVA: 0x009D886C File Offset: 0x009D6A6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void GetLGUIMPC(UObject __WorldContext, ref UMaterialParameterCollection MPC)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_FunctionParams ptr2 = ref *ptr;
			UMaterialParameterCollection umaterialParameterCollection = MPC;
			ptr2.MPC = ((umaterialParameterCollection != null) ? umaterialParameterCollection.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__GetLGUIMPC_NativeFunctionPtr, (void*)ptr);
			MPC = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialParameterCollection>(ptr->MPC);
		}

		// Token: 0x06026764 RID: 157540 RVA: 0x009D88EC File Offset: 0x009D6AEC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void ApplyWeaponLevelMaterial(USkinnedMeshComponent Mesh, PD_WeaponLevelMaterialDatas_C Data, in int Level, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__ApplyWeaponLevelMaterial_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__ApplyWeaponLevelMaterial_FunctionParams[(UIntPtr)751] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__ApplyWeaponLevelMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__ApplyWeaponLevelMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Mesh = ((Mesh != null) ? Mesh.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->Level = Level;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__ApplyWeaponLevelMaterial_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026765 RID: 157541 RVA: 0x009D8980 File Offset: 0x009D6B80
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetFallbackLevelData(int FirstIndex, PD_WeaponLevelMaterialDatas_C Data, UObject __WorldContext, ref SWeaponLevelMaterialData Value)
		{
			BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FirstIndex = FirstIndex;
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			if (Value != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponLevelMaterialData.StaticStruct(), &ptr->Value, Value.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_NativeFunctionPtr, (void*)ptr);
			if (Value != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponLevelMaterialData.StaticStruct(), Value.NativePtr, &ptr->Value, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_CharacterRenderingFunctionLibrary_C.__GetFallbackLevelData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026766 RID: 157542 RVA: 0x009D8A54 File Offset: 0x009D6C54
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyMaterialParems(SWeaponMaterialParams Params, UMaterialInstanceDynamic Material, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_NativeFunctionPtr, (void*)ptr, 1);
			if (Params != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponMaterialParams.StaticStruct(), &ptr->Params, Params.NativePtr, 1, false);
			}
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CharacterRenderingFunctionLibrary_C.__ApplyMaterialParems_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026767 RID: 157543 RVA: 0x009D8AF8 File Offset: 0x009D6CF8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveSimpleHolographicEffect(AActor Target, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveSimpleHolographicEffect_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveSimpleHolographicEffect_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveSimpleHolographicEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveSimpleHolographicEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveSimpleHolographicEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026768 RID: 157544 RVA: 0x009D8B68 File Offset: 0x009D6D68
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void AddSimpleHolographicEffect(AActor Target, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__AddSimpleHolographicEffect_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__AddSimpleHolographicEffect_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__AddSimpleHolographicEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__AddSimpleHolographicEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__AddSimpleHolographicEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026769 RID: 157545 RVA: 0x009D8BD8 File Offset: 0x009D6DD8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerData_MeshComponent(UMeshComponent MeshComponent, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_MeshComponent_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_MeshComponent_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_MeshComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_MeshComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComponent = ((MeshComponent != null) ? MeshComponent.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_MeshComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602676A RID: 157546 RVA: 0x009D8C50 File Offset: 0x009D6E50
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddData_MeshComponent(UMeshComponent MeshComponent, PD_CharacterControllerData_C Data, UObject __WorldContext, ref float HandleId)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_MeshComponent_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_MeshComponent_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_MeshComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_MeshComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComponent = ((MeshComponent != null) ? MeshComponent.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_MeshComponent_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
		}

		// Token: 0x0602676B RID: 157547 RVA: 0x009D8CE8 File Offset: 0x009D6EE8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void SetCharacterStarScarValue(TsBaseCharacter Character, float Value, float SectionIndex, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__SetCharacterStarScarValue_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__SetCharacterStarScarValue_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__SetCharacterStarScarValue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__SetCharacterStarScarValue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->Value = Value;
			ptr->SectionIndex = SectionIndex;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__SetCharacterStarScarValue_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602676C RID: 157548 RVA: 0x009D8D68 File Offset: 0x009D6F68
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerDataGroup_BP(TsBaseCharacter Character, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_BP_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_BP_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_BP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_BP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_BP_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602676D RID: 157549 RVA: 0x009D8DE0 File Offset: 0x009D6FE0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddDataGroup_BP(TsBaseCharacter Character, PD_CharacterControllerDataGroup_C Data, UObject __WorldContext, ref float HandleId)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_BP_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_BP_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_BP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_BP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_BP_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
		}

		// Token: 0x0602676E RID: 157550 RVA: 0x009D8E78 File Offset: 0x009D7078
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerData_BP(TsBaseCharacter Character, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_BP_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_BP_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_BP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_BP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_BP_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602676F RID: 157551 RVA: 0x009D8EF0 File Offset: 0x009D70F0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerDataGroup(ASkeletalMeshActor SkeletalMesh, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkeletalMesh = ((SkeletalMesh != null) ? SkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerDataGroup_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026770 RID: 157552 RVA: 0x009D8F68 File Offset: 0x009D7168
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddData_BP(TsBaseCharacter Character, PD_CharacterControllerData_C Data, UObject __WorldContext, ref float HandleId)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_BP_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_BP_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_BP_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_BP_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_BP_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
		}

		// Token: 0x06026771 RID: 157553 RVA: 0x009D9000 File Offset: 0x009D7200
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddDataGroup(ASkeletalMeshActor SkeletalMesh, PD_CharacterControllerDataGroup_C Data, UObject __WorldContext, ref float HandleId)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkeletalMesh = ((SkeletalMesh != null) ? SkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddDataGroup_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
		}

		// Token: 0x06026772 RID: 157554 RVA: 0x009D9098 File Offset: 0x009D7298
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void RemoveMaterialControllerData(ASkeletalMeshActor SkeletalMesh, float HandleId, UObject __WorldContext)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkeletalMesh = ((SkeletalMesh != null) ? SkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__RemoveMaterialControllerData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026773 RID: 157555 RVA: 0x009D9110 File Offset: 0x009D7310
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void QuickInitAndAddData(ASkeletalMeshActor SkeletalMesh, PD_CharacterControllerData_C Data, UObject __WorldContext, ref float HandleId)
		{
			BP_CharacterRenderingFunctionLibrary_C.StaticClass();
			BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_FunctionParams* ptr = stackalloc BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkeletalMesh = ((SkeletalMesh != null) ? SkeletalMesh.NativePtr : IntPtr.Zero);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ptr->HandleId = HandleId;
			UnrealReflectionUtils.CallVirtualUFunction(BP_CharacterRenderingFunctionLibrary_C._ClassDefaultObjectPtr, BP_CharacterRenderingFunctionLibrary_C.__QuickInitAndAddData_NativeFunctionPtr, (void*)ptr);
			HandleId = ptr->HandleId;
		}

		// Token: 0x06026774 RID: 157556 RVA: 0x009D91A6 File Offset: 0x009D73A6
		protected BP_CharacterRenderingFunctionLibrary_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013FB5 RID: 81845
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Manager/BP_CharacterRenderingFunctionLibrary.BP_CharacterRenderingFunctionLibrary_C";

		// Token: 0x04013FB6 RID: 81846
		private static IntPtr _ClassPtr;

		// Token: 0x04013FB7 RID: 81847
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013FB8 RID: 81848
		private static IntPtr __SetNiagaraSkeletalMeshSimpleNPC_NativeFunctionPtr;

		// Token: 0x04013FB9 RID: 81849
		private static IntPtr __RemoveMaterialControllerDataGroup_MeshComponent_NativeFunctionPtr;

		// Token: 0x04013FBA RID: 81850
		private static IntPtr __QuickInitAndAddDataGroup_MeshComponent_NativeFunctionPtr;

		// Token: 0x04013FBB RID: 81851
		private static IntPtr __AddMaterialControllerDataForAllCases_NativeFunctionPtr;

		// Token: 0x04013FBC RID: 81852
		private static IntPtr __GetLGUIMPC_NativeFunctionPtr;

		// Token: 0x04013FBD RID: 81853
		private static IntPtr __ApplyWeaponLevelMaterial_NativeFunctionPtr;

		// Token: 0x04013FBE RID: 81854
		private static IntPtr __GetFallbackLevelData_NativeFunctionPtr;

		// Token: 0x04013FBF RID: 81855
		private static IntPtr __ApplyMaterialParems_NativeFunctionPtr;

		// Token: 0x04013FC0 RID: 81856
		private static IntPtr __RemoveSimpleHolographicEffect_NativeFunctionPtr;

		// Token: 0x04013FC1 RID: 81857
		private static IntPtr __AddSimpleHolographicEffect_NativeFunctionPtr;

		// Token: 0x04013FC2 RID: 81858
		private static IntPtr __RemoveMaterialControllerData_MeshComponent_NativeFunctionPtr;

		// Token: 0x04013FC3 RID: 81859
		private static IntPtr __QuickInitAndAddData_MeshComponent_NativeFunctionPtr;

		// Token: 0x04013FC4 RID: 81860
		private static IntPtr __SetCharacterStarScarValue_NativeFunctionPtr;

		// Token: 0x04013FC5 RID: 81861
		private static IntPtr __RemoveMaterialControllerDataGroup_BP_NativeFunctionPtr;

		// Token: 0x04013FC6 RID: 81862
		private static IntPtr __QuickInitAndAddDataGroup_BP_NativeFunctionPtr;

		// Token: 0x04013FC7 RID: 81863
		private static IntPtr __RemoveMaterialControllerData_BP_NativeFunctionPtr;

		// Token: 0x04013FC8 RID: 81864
		private static IntPtr __RemoveMaterialControllerDataGroup_NativeFunctionPtr;

		// Token: 0x04013FC9 RID: 81865
		private static IntPtr __QuickInitAndAddData_BP_NativeFunctionPtr;

		// Token: 0x04013FCA RID: 81866
		private static IntPtr __QuickInitAndAddDataGroup_NativeFunctionPtr;

		// Token: 0x04013FCB RID: 81867
		private static IntPtr __RemoveMaterialControllerData_NativeFunctionPtr;

		// Token: 0x04013FCC RID: 81868
		private static IntPtr __QuickInitAndAddData_NativeFunctionPtr;

		// Token: 0x0200A05D RID: 41053
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __SetNiagaraSkeletalMeshSimpleNPC_FunctionParams
		{
			// Token: 0x04032CB4 RID: 208052
			[FieldOffset(0)]
			public IntPtr NiagaraComponen;

			// Token: 0x04032CB5 RID: 208053
			[FieldOffset(8)]
			public FString ParamName;

			// Token: 0x04032CB6 RID: 208054
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A05E RID: 41054
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __RemoveMaterialControllerDataGroup_MeshComponent_FunctionParams
		{
			// Token: 0x04032CB7 RID: 208055
			[FieldOffset(0)]
			public IntPtr meshComponent;

			// Token: 0x04032CB8 RID: 208056
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CB9 RID: 208057
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A05F RID: 41055
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __QuickInitAndAddDataGroup_MeshComponent_FunctionParams
		{
			// Token: 0x04032CBA RID: 208058
			[FieldOffset(0)]
			public IntPtr MeshComponent;

			// Token: 0x04032CBB RID: 208059
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CBC RID: 208060
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CBD RID: 208061
			[FieldOffset(24)]
			public float HandleId;

			// Token: 0x04032CBE RID: 208062
			[FieldOffset(32)]
			public IntPtr CharRenderComponent;
		}

		// Token: 0x0200A060 RID: 41056
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __AddMaterialControllerDataForAllCases_FunctionParams
		{
			// Token: 0x04032CBF RID: 208063
			[FieldOffset(0)]
			public IntPtr Actor;

			// Token: 0x04032CC0 RID: 208064
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CC1 RID: 208065
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A061 RID: 41057
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetLGUIMPC_FunctionParams
		{
			// Token: 0x04032CC2 RID: 208066
			[FieldOffset(0)]
			public IntPtr __WorldContext;

			// Token: 0x04032CC3 RID: 208067
			[FieldOffset(8)]
			public IntPtr MPC;
		}

		// Token: 0x0200A062 RID: 41058
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 736)]
		protected ref struct __ApplyWeaponLevelMaterial_FunctionParams
		{
			// Token: 0x04032CC4 RID: 208068
			[FieldOffset(0)]
			public IntPtr Mesh;

			// Token: 0x04032CC5 RID: 208069
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CC6 RID: 208070
			[FieldOffset(16)]
			public int Level;

			// Token: 0x04032CC7 RID: 208071
			[FieldOffset(24)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A063 RID: 41059
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __GetFallbackLevelData_FunctionParams
		{
			// Token: 0x04032CC8 RID: 208072
			[FieldOffset(0)]
			public int FirstIndex;

			// Token: 0x04032CC9 RID: 208073
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CCA RID: 208074
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CCB RID: 208075
			[FieldOffset(24)]
			public byte Value;
		}

		// Token: 0x0200A064 RID: 41060
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected ref struct __ApplyMaterialParems_FunctionParams
		{
			// Token: 0x04032CCC RID: 208076
			[FieldOffset(0)]
			public byte Params;

			// Token: 0x04032CCD RID: 208077
			[FieldOffset(240)]
			public IntPtr Material;

			// Token: 0x04032CCE RID: 208078
			[FieldOffset(248)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A065 RID: 41061
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __RemoveSimpleHolographicEffect_FunctionParams
		{
			// Token: 0x04032CCF RID: 208079
			[FieldOffset(0)]
			public IntPtr Target;

			// Token: 0x04032CD0 RID: 208080
			[FieldOffset(8)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A066 RID: 41062
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __AddSimpleHolographicEffect_FunctionParams
		{
			// Token: 0x04032CD1 RID: 208081
			[FieldOffset(0)]
			public IntPtr Target;

			// Token: 0x04032CD2 RID: 208082
			[FieldOffset(8)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A067 RID: 41063
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __RemoveMaterialControllerData_MeshComponent_FunctionParams
		{
			// Token: 0x04032CD3 RID: 208083
			[FieldOffset(0)]
			public IntPtr MeshComponent;

			// Token: 0x04032CD4 RID: 208084
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CD5 RID: 208085
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A068 RID: 41064
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __QuickInitAndAddData_MeshComponent_FunctionParams
		{
			// Token: 0x04032CD6 RID: 208086
			[FieldOffset(0)]
			public IntPtr MeshComponent;

			// Token: 0x04032CD7 RID: 208087
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CD8 RID: 208088
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CD9 RID: 208089
			[FieldOffset(24)]
			public float HandleId;
		}

		// Token: 0x0200A069 RID: 41065
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetCharacterStarScarValue_FunctionParams
		{
			// Token: 0x04032CDA RID: 208090
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04032CDB RID: 208091
			[FieldOffset(8)]
			public float Value;

			// Token: 0x04032CDC RID: 208092
			[FieldOffset(12)]
			public float SectionIndex;

			// Token: 0x04032CDD RID: 208093
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A06A RID: 41066
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __RemoveMaterialControllerDataGroup_BP_FunctionParams
		{
			// Token: 0x04032CDE RID: 208094
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04032CDF RID: 208095
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CE0 RID: 208096
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A06B RID: 41067
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __QuickInitAndAddDataGroup_BP_FunctionParams
		{
			// Token: 0x04032CE1 RID: 208097
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04032CE2 RID: 208098
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CE3 RID: 208099
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CE4 RID: 208100
			[FieldOffset(24)]
			public float HandleId;
		}

		// Token: 0x0200A06C RID: 41068
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __RemoveMaterialControllerData_BP_FunctionParams
		{
			// Token: 0x04032CE5 RID: 208101
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04032CE6 RID: 208102
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CE7 RID: 208103
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A06D RID: 41069
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __RemoveMaterialControllerDataGroup_FunctionParams
		{
			// Token: 0x04032CE8 RID: 208104
			[FieldOffset(0)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032CE9 RID: 208105
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CEA RID: 208106
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A06E RID: 41070
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __QuickInitAndAddData_BP_FunctionParams
		{
			// Token: 0x04032CEB RID: 208107
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x04032CEC RID: 208108
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CED RID: 208109
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CEE RID: 208110
			[FieldOffset(24)]
			public float HandleId;
		}

		// Token: 0x0200A06F RID: 41071
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __QuickInitAndAddDataGroup_FunctionParams
		{
			// Token: 0x04032CEF RID: 208111
			[FieldOffset(0)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032CF0 RID: 208112
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CF1 RID: 208113
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CF2 RID: 208114
			[FieldOffset(24)]
			public float HandleId;
		}

		// Token: 0x0200A070 RID: 41072
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __RemoveMaterialControllerData_FunctionParams
		{
			// Token: 0x04032CF3 RID: 208115
			[FieldOffset(0)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032CF4 RID: 208116
			[FieldOffset(8)]
			public float HandleId;

			// Token: 0x04032CF5 RID: 208117
			[FieldOffset(16)]
			public IntPtr __WorldContext;
		}

		// Token: 0x0200A071 RID: 41073
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __QuickInitAndAddData_FunctionParams
		{
			// Token: 0x04032CF6 RID: 208118
			[FieldOffset(0)]
			public IntPtr SkeletalMesh;

			// Token: 0x04032CF7 RID: 208119
			[FieldOffset(8)]
			public IntPtr Data;

			// Token: 0x04032CF8 RID: 208120
			[FieldOffset(16)]
			public IntPtr __WorldContext;

			// Token: 0x04032CF9 RID: 208121
			[FieldOffset(24)]
			public float HandleId;
		}
	}
}
