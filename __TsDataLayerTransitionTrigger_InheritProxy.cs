using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038ED RID: 14573
public class __TsDataLayerTransitionTrigger_InheritProxy : TsDataLayerTransitionTrigger
{
	// Token: 0x0601D71A RID: 120602 RVA: 0x008CCA44 File Offset: 0x008CAC44
	[NullableContext(1)]
	public __TsDataLayerTransitionTrigger_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDataLayerTransitionTrigger.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D71B RID: 120603 RVA: 0x008CCA77 File Offset: 0x008CAC77
	protected __TsDataLayerTransitionTrigger_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D71C RID: 120604 RVA: 0x008CCA80 File Offset: 0x008CAC80
	protected unsafe override void __CPPCALL_SetMatForActivatingDataLayers_Implementation(TsDataLayerTransitionTrigger.__SetMatForActivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		base.SetMatForActivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D71D RID: 120605 RVA: 0x008CCAA0 File Offset: 0x008CACA0
	protected unsafe override void __CPPCALL_WasMatForActivatingDataLayersSet_Implementation(TsDataLayerTransitionTrigger.__WasMatForActivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasMatForActivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601D71E RID: 120606 RVA: 0x008CCAB0 File Offset: 0x008CACB0
	protected unsafe override void __CPPCALL_SetMatForDeactivatingDataLayers_Implementation(TsDataLayerTransitionTrigger.__SetMatForDeactivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		base.SetMatForDeactivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D71F RID: 120607 RVA: 0x008CCAD0 File Offset: 0x008CACD0
	protected unsafe override void __CPPCALL_WasMatForDeactivatingDataLayersSet_Implementation(TsDataLayerTransitionTrigger.__WasMatForDeactivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasMatForDeactivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601D720 RID: 120608 RVA: 0x008CCAE0 File Offset: 0x008CACE0
	protected unsafe override void __CPPCALL_SetSeqForSourceIn_Implementation(TsDataLayerTransitionTrigger.__SetSeqForSourceIn_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		base.SetSeqForSourceIn_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601D721 RID: 120609 RVA: 0x008CCB0E File Offset: 0x008CAD0E
	protected unsafe override void __CPPCALL_WasSeqForSourceInSet_Implementation(TsDataLayerTransitionTrigger.__WasSeqForSourceInSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasSeqForSourceInSet_Implementation();
	}

	// Token: 0x0601D722 RID: 120610 RVA: 0x008CCB1C File Offset: 0x008CAD1C
	protected unsafe override void __CPPCALL_SetSeqForSourceOut_Implementation(TsDataLayerTransitionTrigger.__SetSeqForSourceOut_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		base.SetSeqForSourceOut_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601D723 RID: 120611 RVA: 0x008CCB4A File Offset: 0x008CAD4A
	protected unsafe override void __CPPCALL_WasSeqForSourceOutSet_Implementation(TsDataLayerTransitionTrigger.__WasSeqForSourceOutSet_FunctionParams* __Params)
	{
		__Params->__Result = base.WasSeqForSourceOutSet_Implementation();
	}
}
