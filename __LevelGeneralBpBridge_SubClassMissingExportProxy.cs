using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Interaction.Struct;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384E RID: 14414
[NullableContext(1)]
[Nullable(0)]
public class __LevelGeneralBpBridge_SubClassMissingExportProxy : __LevelGeneralBpBridge_InheritProxy
{
	// Token: 0x0601D533 RID: 120115 RVA: 0x008C8308 File Offset: 0x008C6508
	protected __LevelGeneralBpBridge_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBpBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D534 RID: 120116 RVA: 0x008C833B File Offset: 0x008C653B
	protected __LevelGeneralBpBridge_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D535 RID: 120117 RVA: 0x008C8344 File Offset: 0x008C6544
	public unsafe override bool HandleCoditionInteractOption(SInteractionOption inInteractOptionConfig, string inInteractionConfigId, float inOptionIndex, AActor inTrigger)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleCoditionInteractOption"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleCoditionInteractOption_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(SInteractionOption.StaticStruct(), &ptr2->inInteractOptionConfig, (inInteractOptionConfig != null) ? inInteractOptionConfig.NativePtr : ((IntPtr)0), 1, false);
			FString.CopyFrom((void*)(&ptr2->inInteractionConfigId), inInteractionConfigId);
			ptr2->inOptionIndex = inOptionIndex;
			*(&ptr2->inTrigger) = ((inTrigger != null) ? inTrigger.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D536 RID: 120118 RVA: 0x008C8408 File Offset: 0x008C6608
	public unsafe override void TriggerLevelGeneralEvents(float inEventGroupId, AActor inTrigger)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TriggerLevelGeneralEvents"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__TriggerLevelGeneralEvents_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inEventGroupId = inEventGroupId;
			*(&ptr2->inTrigger) = ((inTrigger != null) ? inTrigger.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D537 RID: 120119 RVA: 0x008C8494 File Offset: 0x008C6694
	public unsafe override void HandleConditionalEventListen(TMap<int, int> inTargetMap)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleConditionalEventListen"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleConditionalEventListen_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			if (inTargetMap != null)
			{
				inTargetMap.CopyTo(&ptr2->inTargetMap, default(UScriptStructStackOnlyPtr));
			}
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D538 RID: 120120 RVA: 0x008C8520 File Offset: 0x008C6720
	public unsafe override void HandleConditionPush(int inConditionGroupId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("HandleConditionPush"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		LevelGeneralBpBridge.__HandleConditionPush_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((LevelGeneralBpBridge.__HandleConditionPush_FunctionParams*)ptr + 15L / (long)sizeof(LevelGeneralBpBridge.__HandleConditionPush_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inConditionGroupId = inConditionGroupId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D539 RID: 120121 RVA: 0x008C8598 File Offset: 0x008C6798
	public unsafe override void OpenInteractHints()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OpenInteractHints"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D53A RID: 120122 RVA: 0x008C8608 File Offset: 0x008C6808
	public unsafe override void CloseInteractHints()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CloseInteractHints"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
