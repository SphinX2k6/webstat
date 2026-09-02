using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396E RID: 14702
[NullableContext(1)]
[Nullable(0)]
public class __TsEntityDebugInfoManager_SubClassMissingExportProxy : __TsEntityDebugInfoManager_InheritProxy
{
	// Token: 0x0601D9F0 RID: 121328 RVA: 0x008D5FB4 File Offset: 0x008D41B4
	protected __TsEntityDebugInfoManager_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityDebugInfoManager.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9F1 RID: 121329 RVA: 0x008D5FE7 File Offset: 0x008D41E7
	protected __TsEntityDebugInfoManager_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D9F2 RID: 121330 RVA: 0x008D5FF0 File Offset: 0x008D41F0
	public unsafe override TArray<string> GetDebugEntityNameList()
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		TArray<string> result = new TArray<string>(&ptr2->__Result, true, true);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601D9F3 RID: 121331 RVA: 0x008D6070 File Offset: 0x008D4270
	public unsafe override int GetSelectedEntityId(string label)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D9F4 RID: 121332 RVA: 0x008D60F4 File Offset: 0x008D42F4
	public unsafe override float GetEntityTimeScale(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D9F5 RID: 121333 RVA: 0x008D6174 File Offset: 0x008D4374
	public unsafe override void SetEntityTimeScale(int entityId, float timeScale)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9F6 RID: 121334 RVA: 0x008D61F4 File Offset: 0x008D43F4
	public unsafe override int GetEntityPbDataId(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D9F7 RID: 121335 RVA: 0x008D6274 File Offset: 0x008D4474
	public unsafe override string GetInteractionDebugInfos(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601D9F8 RID: 121336 RVA: 0x008D62F8 File Offset: 0x008D44F8
	public unsafe override string GetEntityCommonTagDebugString(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601D9F9 RID: 121337 RVA: 0x008D637C File Offset: 0x008D457C
	[NullableContext(2)]
	public unsafe override AActor GetDebugEntityActor(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601D9FA RID: 121338 RVA: 0x008D6400 File Offset: 0x008D4600
	public unsafe override string GetDebugBaseInfo(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x0601D9FB RID: 121339 RVA: 0x008D6484 File Offset: 0x008D4684
	[NullableContext(2)]
	public unsafe override string GetDebugEntityName(int entityId)
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
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}
}
