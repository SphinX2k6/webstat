using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.NewWorld.Character.Common.Blueprint.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003483 RID: 13443
[UClass("/Game/Aki/TypeScript/Game/World/Debug/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/World/Debug/TsEntityDebugInfoManager.TsEntityDebugInfoManager_C")]
public class TsEntityDebugInfoManager : UObject, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C5CD RID: 116173 RVA: 0x00880526 File Offset: 0x0087E726
	static TsEntityDebugInfoManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsEntityDebugInfoManager.CreateStaticDefaultValue), new Action(TsEntityDebugInfoManager.ResetStaticDefaultValue));
	}

	// Token: 0x0601C5CE RID: 116174 RVA: 0x00880545 File Offset: 0x0087E745
	public static void CreateStaticDefaultValue()
	{
		TsEntityDebugInfoManager.Instance = null;
	}

	// Token: 0x0601C5CF RID: 116175 RVA: 0x0088054D File Offset: 0x0087E74D
	public static void ResetStaticDefaultValue()
	{
		TsEntityDebugInfoManager.Instance = null;
	}

	// Token: 0x0601C5D0 RID: 116176 RVA: 0x00880555 File Offset: 0x0087E755
	[NullableContext(1)]
	public static TsEntityDebugInfoManager GetInstance()
	{
		TsEntityDebugInfoManager instance = TsEntityDebugInfoManager.Instance;
		if (instance == null || !instance.IsValid())
		{
			TsEntityDebugInfoManager.Instance = UE.NewObject<TsEntityDebugInfoManager>(GlobalData.World, null, EObjectFlags.RF_NoFlags);
		}
		return TsEntityDebugInfoManager.Instance;
	}

	// Token: 0x0601C5D1 RID: 116177 RVA: 0x00880584 File Offset: 0x0087E784
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual TArray<string> GetDebugEntityNameList()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugEntityNameList"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetDebugEntityNameList_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetDebugEntityNameList_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetDebugEntityNameList_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		TArray<string> result = new TArray<string>(&ptr2->__Result, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601C5D2 RID: 116178 RVA: 0x00880601 File Offset: 0x0087E801
	[NullableContext(1)]
	protected TArray<string> GetDebugEntityNameList_Implementation()
	{
		return Singleton<EntityDebugUtils>.Instance.GetDebugEntityNameList();
	}

	// Token: 0x0601C5D3 RID: 116179 RVA: 0x00880610 File Offset: 0x0087E810
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int GetSelectedEntityId(string label)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetSelectedEntityId"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetSelectedEntityId_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetSelectedEntityId_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetSelectedEntityId_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->label), label);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601C5D4 RID: 116180 RVA: 0x00880692 File Offset: 0x0087E892
	[NullableContext(1)]
	protected int GetSelectedEntityId_Implementation(string label)
	{
		return Singleton<EntityDebugUtils>.Instance.GetSelectedEntityId(label);
	}

	// Token: 0x0601C5D5 RID: 116181 RVA: 0x008806A0 File Offset: 0x0087E8A0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual float GetEntityTimeScale(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetEntityTimeScale"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetEntityTimeScale_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetEntityTimeScale_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetEntityTimeScale_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601C5D6 RID: 116182 RVA: 0x0088071C File Offset: 0x0087E91C
	protected float GetEntityTimeScale_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetEntityTimeScale(entityId);
	}

	// Token: 0x0601C5D7 RID: 116183 RVA: 0x0088072C File Offset: 0x0087E92C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetEntityTimeScale(int entityId, float timeScale)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEntityTimeScale"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__SetEntityTimeScale_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__SetEntityTimeScale_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__SetEntityTimeScale_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
			ptr2->timeScale = timeScale;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C5D8 RID: 116184 RVA: 0x008807A9 File Offset: 0x0087E9A9
	protected void SetEntityTimeScale_Implementation(int entityId, float timeScale)
	{
		Singleton<EntityDebugUtils>.Instance.SetEntityTimeScale(entityId, timeScale);
	}

	// Token: 0x0601C5D9 RID: 116185 RVA: 0x008807B8 File Offset: 0x0087E9B8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual int GetEntityPbDataId(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetEntityPbDataId"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetEntityPbDataId_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetEntityPbDataId_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetEntityPbDataId_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601C5DA RID: 116186 RVA: 0x00880834 File Offset: 0x0087EA34
	protected int GetEntityPbDataId_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetEntityPbDataId(entityId);
	}

	// Token: 0x0601C5DB RID: 116187 RVA: 0x00880844 File Offset: 0x0087EA44
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual string GetInteractionDebugInfos(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetInteractionDebugInfos"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetInteractionDebugInfos_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetInteractionDebugInfos_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetInteractionDebugInfos_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601C5DC RID: 116188 RVA: 0x008808C6 File Offset: 0x0087EAC6
	[NullableContext(1)]
	protected string GetInteractionDebugInfos_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetInteractionDebugInfos(entityId);
	}

	// Token: 0x0601C5DD RID: 116189 RVA: 0x008808D4 File Offset: 0x0087EAD4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual string GetEntityCommonTagDebugString(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetEntityCommonTagDebugString"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetEntityCommonTagDebugString_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetEntityCommonTagDebugString_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetEntityCommonTagDebugString_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601C5DE RID: 116190 RVA: 0x00880956 File Offset: 0x0087EB56
	[NullableContext(1)]
	protected string GetEntityCommonTagDebugString_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetEntityCommonTagDebugString(entityId);
	}

	// Token: 0x0601C5DF RID: 116191 RVA: 0x00880964 File Offset: 0x0087EB64
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual AActor GetDebugEntityActor(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugEntityActor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetDebugEntityActor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetDebugEntityActor_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetDebugEntityActor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601C5E0 RID: 116192 RVA: 0x008809E5 File Offset: 0x0087EBE5
	[NullableContext(2)]
	protected AActor GetDebugEntityActor_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetDebugEntityActor(entityId);
	}

	// Token: 0x0601C5E1 RID: 116193 RVA: 0x008809F4 File Offset: 0x0087EBF4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual string GetDebugBaseInfo(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugBaseInfo"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetDebugBaseInfo_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetDebugBaseInfo_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetDebugBaseInfo_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601C5E2 RID: 116194 RVA: 0x00880A76 File Offset: 0x0087EC76
	[NullableContext(1)]
	protected string GetDebugBaseInfo_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetDebugBaseInfo(entityId);
	}

	// Token: 0x0601C5E3 RID: 116195 RVA: 0x00880A84 File Offset: 0x0087EC84
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual string GetDebugEntityName(int entityId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugEntityName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEntityDebugInfoManager.__GetDebugEntityName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEntityDebugInfoManager.__GetDebugEntityName_FunctionParams*)ptr + 15L / (long)sizeof(TsEntityDebugInfoManager.__GetDebugEntityName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->entityId = entityId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601C5E4 RID: 116196 RVA: 0x00880B06 File Offset: 0x0087ED06
	[NullableContext(2)]
	protected string GetDebugEntityName_Implementation(int entityId)
	{
		return Singleton<EntityDebugUtils>.Instance.GetDebugEntityName(entityId);
	}

	// Token: 0x0601C5E5 RID: 116197 RVA: 0x00880B13 File Offset: 0x0087ED13
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsEntityDebugInfoManager._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/World/Debug/TsEntityDebugInfoManager.TsEntityDebugInfoManager_C");
		}
		return TsEntityDebugInfoManager._ClassPtr;
	}

	// Token: 0x0601C5E6 RID: 116198 RVA: 0x00880B38 File Offset: 0x0087ED38
	public TsEntityDebugInfoManager() : this(BuiltinUtils.AllocNativeUObject(TsEntityDebugInfoManager.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C5E7 RID: 116199 RVA: 0x00880B60 File Offset: 0x0087ED60
	[NullableContext(1)]
	public TsEntityDebugInfoManager(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityDebugInfoManager.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C5E8 RID: 116200 RVA: 0x00880B93 File Offset: 0x0087ED93
	protected TsEntityDebugInfoManager(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C5E9 RID: 116201 RVA: 0x00880B9C File Offset: 0x0087ED9C
	protected unsafe virtual void __CPPCALL_GetDebugEntityNameList_Implementation(TsEntityDebugInfoManager.__GetDebugEntityNameList_FunctionParams* __Params)
	{
		TArray<string> debugEntityNameList_Implementation = this.GetDebugEntityNameList_Implementation();
		if (debugEntityNameList_Implementation == null)
		{
			return;
		}
		debugEntityNameList_Implementation.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601C5EA RID: 116202 RVA: 0x00880BCC File Offset: 0x0087EDCC
	protected unsafe virtual void __CPPCALL_GetSelectedEntityId_Implementation(TsEntityDebugInfoManager.__GetSelectedEntityId_FunctionParams* __Params)
	{
		string label = FString.ToString((void*)(&__Params->label));
		__Params->__Result = this.GetSelectedEntityId_Implementation(label);
	}

	// Token: 0x0601C5EB RID: 116203 RVA: 0x00880BF3 File Offset: 0x0087EDF3
	protected unsafe virtual void __CPPCALL_GetEntityTimeScale_Implementation(TsEntityDebugInfoManager.__GetEntityTimeScale_FunctionParams* __Params)
	{
		__Params->__Result = this.GetEntityTimeScale_Implementation(__Params->entityId);
	}

	// Token: 0x0601C5EC RID: 116204 RVA: 0x00880C07 File Offset: 0x0087EE07
	protected unsafe virtual void __CPPCALL_SetEntityTimeScale_Implementation(TsEntityDebugInfoManager.__SetEntityTimeScale_FunctionParams* __Params)
	{
		this.SetEntityTimeScale_Implementation(__Params->entityId, __Params->timeScale);
	}

	// Token: 0x0601C5ED RID: 116205 RVA: 0x00880C1B File Offset: 0x0087EE1B
	protected unsafe virtual void __CPPCALL_GetEntityPbDataId_Implementation(TsEntityDebugInfoManager.__GetEntityPbDataId_FunctionParams* __Params)
	{
		__Params->__Result = this.GetEntityPbDataId_Implementation(__Params->entityId);
	}

	// Token: 0x0601C5EE RID: 116206 RVA: 0x00880C2F File Offset: 0x0087EE2F
	protected unsafe virtual void __CPPCALL_GetInteractionDebugInfos_Implementation(TsEntityDebugInfoManager.__GetInteractionDebugInfos_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetInteractionDebugInfos_Implementation(__Params->entityId));
	}

	// Token: 0x0601C5EF RID: 116207 RVA: 0x00880C49 File Offset: 0x0087EE49
	protected unsafe virtual void __CPPCALL_GetEntityCommonTagDebugString_Implementation(TsEntityDebugInfoManager.__GetEntityCommonTagDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetEntityCommonTagDebugString_Implementation(__Params->entityId));
	}

	// Token: 0x0601C5F0 RID: 116208 RVA: 0x00880C63 File Offset: 0x0087EE63
	protected unsafe virtual void __CPPCALL_GetDebugEntityActor_Implementation(TsEntityDebugInfoManager.__GetDebugEntityActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor debugEntityActor_Implementation = this.GetDebugEntityActor_Implementation(__Params->entityId);
		ptr = ((debugEntityActor_Implementation != null) ? debugEntityActor_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601C5F1 RID: 116209 RVA: 0x00880C86 File Offset: 0x0087EE86
	protected unsafe virtual void __CPPCALL_GetDebugBaseInfo_Implementation(TsEntityDebugInfoManager.__GetDebugBaseInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetDebugBaseInfo_Implementation(__Params->entityId));
	}

	// Token: 0x0601C5F2 RID: 116210 RVA: 0x00880CA0 File Offset: 0x0087EEA0
	protected unsafe virtual void __CPPCALL_GetDebugEntityName_Implementation(TsEntityDebugInfoManager.__GetDebugEntityName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetDebugEntityName_Implementation(__Params->entityId));
	}

	// Token: 0x0400E43A RID: 58426
	[Nullable(2)]
	private static TsEntityDebugInfoManager Instance;

	// Token: 0x0400E43B RID: 58427
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/World/Debug/TsEntityDebugInfoManager.TsEntityDebugInfoManager_C";

	// Token: 0x0400E43C RID: 58428
	private static IntPtr _ClassPtr;

	// Token: 0x0400E43D RID: 58429
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009675 RID: 38517
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugEntityNameList_FunctionParams
	{
		// Token: 0x04031A82 RID: 203394
		[FieldOffset(0)]
		public byte __Result;
	}

	// Token: 0x02009676 RID: 38518
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSelectedEntityId_FunctionParams
	{
		// Token: 0x04031A83 RID: 203395
		[FieldOffset(0)]
		public FString label;

		// Token: 0x04031A84 RID: 203396
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009677 RID: 38519
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetEntityTimeScale_FunctionParams
	{
		// Token: 0x04031A85 RID: 203397
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A86 RID: 203398
		[FieldOffset(4)]
		public float __Result;
	}

	// Token: 0x02009678 RID: 38520
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetEntityTimeScale_FunctionParams
	{
		// Token: 0x04031A87 RID: 203399
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A88 RID: 203400
		[FieldOffset(4)]
		public float timeScale;
	}

	// Token: 0x02009679 RID: 38521
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetEntityPbDataId_FunctionParams
	{
		// Token: 0x04031A89 RID: 203401
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A8A RID: 203402
		[FieldOffset(4)]
		public int __Result;
	}

	// Token: 0x0200967A RID: 38522
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetInteractionDebugInfos_FunctionParams
	{
		// Token: 0x04031A8B RID: 203403
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A8C RID: 203404
		[FieldOffset(8)]
		public FString __Result;
	}

	// Token: 0x0200967B RID: 38523
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetEntityCommonTagDebugString_FunctionParams
	{
		// Token: 0x04031A8D RID: 203405
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A8E RID: 203406
		[FieldOffset(8)]
		public FString __Result;
	}

	// Token: 0x0200967C RID: 38524
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetDebugEntityActor_FunctionParams
	{
		// Token: 0x04031A8F RID: 203407
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A90 RID: 203408
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x0200967D RID: 38525
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDebugBaseInfo_FunctionParams
	{
		// Token: 0x04031A91 RID: 203409
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A92 RID: 203410
		[FieldOffset(8)]
		public FString __Result;
	}

	// Token: 0x0200967E RID: 38526
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDebugEntityName_FunctionParams
	{
		// Token: 0x04031A93 RID: 203411
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04031A94 RID: 203412
		[FieldOffset(8)]
		public FString __Result;
	}
}
