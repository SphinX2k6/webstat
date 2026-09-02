using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038F1 RID: 14577
public class __TsTransitionWorldPartitionTriggerVolume_InheritProxy : TsTransitionWorldPartitionTriggerVolume
{
	// Token: 0x0601D732 RID: 120626 RVA: 0x008CD024 File Offset: 0x008CB224
	[NullableContext(1)]
	public __TsTransitionWorldPartitionTriggerVolume_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTransitionWorldPartitionTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D733 RID: 120627 RVA: 0x008CD057 File Offset: 0x008CB257
	protected __TsTransitionWorldPartitionTriggerVolume_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D734 RID: 120628 RVA: 0x008CD060 File Offset: 0x008CB260
	protected unsafe override void __CPPCALL_SetMatForActivatingDataLayers_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetMatForActivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		base.SetMatForActivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D735 RID: 120629 RVA: 0x008CD080 File Offset: 0x008CB280
	protected unsafe override void __CPPCALL_WasMatForActivatingDataLayersSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasMatForActivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasMatForActivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601D736 RID: 120630 RVA: 0x008CD090 File Offset: 0x008CB290
	protected unsafe override void __CPPCALL_SetMatForDeactivatingDataLayers_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetMatForDeactivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		base.SetMatForDeactivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D737 RID: 120631 RVA: 0x008CD0B0 File Offset: 0x008CB2B0
	protected unsafe override void __CPPCALL_WasMatForDeactivatingDataLayersSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasMatForDeactivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasMatForDeactivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601D738 RID: 120632 RVA: 0x008CD0C0 File Offset: 0x008CB2C0
	protected unsafe override void __CPPCALL_SetSeqForSourceIn_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceIn_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		base.SetSeqForSourceIn_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601D739 RID: 120633 RVA: 0x008CD0EE File Offset: 0x008CB2EE
	protected unsafe override void __CPPCALL_WasSeqForSourceInSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceInSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasSeqForSourceInSet_Implementation();
	}

	// Token: 0x0601D73A RID: 120634 RVA: 0x008CD0FC File Offset: 0x008CB2FC
	protected unsafe override void __CPPCALL_SetSeqForSourceOut_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceOut_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		base.SetSeqForSourceOut_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601D73B RID: 120635 RVA: 0x008CD12A File Offset: 0x008CB32A
	protected unsafe override void __CPPCALL_WasSeqForSourceOutSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceOutSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasSeqForSourceOutSet_Implementation();
	}

	// Token: 0x0601D73C RID: 120636 RVA: 0x008CD138 File Offset: 0x008CB338
	protected override void __CPPCALL_OnStateChanged_Implementation()
	{
		base.OnStateChanged_Implementation();
	}
}
