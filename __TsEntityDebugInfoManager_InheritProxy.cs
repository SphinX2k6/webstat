using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396D RID: 14701
public class __TsEntityDebugInfoManager_InheritProxy : TsEntityDebugInfoManager
{
	// Token: 0x0601D9E4 RID: 121316 RVA: 0x008D5E58 File Offset: 0x008D4058
	[NullableContext(1)]
	public __TsEntityDebugInfoManager_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityDebugInfoManager.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9E5 RID: 121317 RVA: 0x008D5E8B File Offset: 0x008D408B
	protected __TsEntityDebugInfoManager_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D9E6 RID: 121318 RVA: 0x008D5E94 File Offset: 0x008D4094
	protected unsafe override void __CPPCALL_GetDebugEntityNameList_Implementation(TsEntityDebugInfoManager.__GetDebugEntityNameList_FunctionParams* __Params)
	{
		TArray<string> debugEntityNameList_Implementation = base.GetDebugEntityNameList_Implementation();
		if (debugEntityNameList_Implementation == null)
		{
			return;
		}
		debugEntityNameList_Implementation.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x0601D9E7 RID: 121319 RVA: 0x008D5EC4 File Offset: 0x008D40C4
	protected unsafe override void __CPPCALL_GetSelectedEntityId_Implementation(TsEntityDebugInfoManager.__GetSelectedEntityId_FunctionParams* __Params)
	{
		string label = FString.ToString((void*)(&__Params->label));
		__Params->__Result = base.GetSelectedEntityId_Implementation(label);
	}

	// Token: 0x0601D9E8 RID: 121320 RVA: 0x008D5EEB File Offset: 0x008D40EB
	protected unsafe override void __CPPCALL_GetEntityTimeScale_Implementation(TsEntityDebugInfoManager.__GetEntityTimeScale_FunctionParams* __Params)
	{
		__Params->__Result = base.GetEntityTimeScale_Implementation(__Params->entityId);
	}

	// Token: 0x0601D9E9 RID: 121321 RVA: 0x008D5EFF File Offset: 0x008D40FF
	protected unsafe override void __CPPCALL_SetEntityTimeScale_Implementation(TsEntityDebugInfoManager.__SetEntityTimeScale_FunctionParams* __Params)
	{
		base.SetEntityTimeScale_Implementation(__Params->entityId, __Params->timeScale);
	}

	// Token: 0x0601D9EA RID: 121322 RVA: 0x008D5F13 File Offset: 0x008D4113
	protected unsafe override void __CPPCALL_GetEntityPbDataId_Implementation(TsEntityDebugInfoManager.__GetEntityPbDataId_FunctionParams* __Params)
	{
		__Params->__Result = base.GetEntityPbDataId_Implementation(__Params->entityId);
	}

	// Token: 0x0601D9EB RID: 121323 RVA: 0x008D5F27 File Offset: 0x008D4127
	protected unsafe override void __CPPCALL_GetInteractionDebugInfos_Implementation(TsEntityDebugInfoManager.__GetInteractionDebugInfos_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetInteractionDebugInfos_Implementation(__Params->entityId));
	}

	// Token: 0x0601D9EC RID: 121324 RVA: 0x008D5F41 File Offset: 0x008D4141
	protected unsafe override void __CPPCALL_GetEntityCommonTagDebugString_Implementation(TsEntityDebugInfoManager.__GetEntityCommonTagDebugString_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetEntityCommonTagDebugString_Implementation(__Params->entityId));
	}

	// Token: 0x0601D9ED RID: 121325 RVA: 0x008D5F5B File Offset: 0x008D415B
	protected unsafe override void __CPPCALL_GetDebugEntityActor_Implementation(TsEntityDebugInfoManager.__GetDebugEntityActor_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor debugEntityActor_Implementation = base.GetDebugEntityActor_Implementation(__Params->entityId);
		ptr = ((debugEntityActor_Implementation != null) ? debugEntityActor_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D9EE RID: 121326 RVA: 0x008D5F7E File Offset: 0x008D417E
	protected unsafe override void __CPPCALL_GetDebugBaseInfo_Implementation(TsEntityDebugInfoManager.__GetDebugBaseInfo_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetDebugBaseInfo_Implementation(__Params->entityId));
	}

	// Token: 0x0601D9EF RID: 121327 RVA: 0x008D5F98 File Offset: 0x008D4198
	protected unsafe override void __CPPCALL_GetDebugEntityName_Implementation(TsEntityDebugInfoManager.__GetDebugEntityName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetDebugEntityName_Implementation(__Params->entityId));
	}
}
