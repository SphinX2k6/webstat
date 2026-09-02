using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003852 RID: 14418
[NullableContext(1)]
[Nullable(0)]
public class __TsLevelGamePlayBridge_SubClassMissingExportProxy : __TsLevelGamePlayBridge_InheritProxy
{
	// Token: 0x0601D54D RID: 120141 RVA: 0x008C8978 File Offset: 0x008C6B78
	protected __TsLevelGamePlayBridge_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLevelGamePlayBridge.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D54E RID: 120142 RVA: 0x008C89AB File Offset: 0x008C6BAB
	protected __TsLevelGamePlayBridge_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D54F RID: 120143 RVA: 0x008C89B4 File Offset: 0x008C6BB4
	public unsafe override void UpdateGamePlayTimerBridge(float inGamePlayTimerId, float inActivate)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UpdateGamePlayTimerBridge"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__UpdateGamePlayTimerBridge_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inGamePlayTimerId = inGamePlayTimerId;
			ptr2->inActivate = inActivate;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D550 RID: 120144 RVA: 0x008C8A34 File Offset: 0x008C6C34
	public unsafe override float GetDragonPoolState(float inDragonId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDragonPoolState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__GetDragonPoolState_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->inDragonId = inDragonId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D551 RID: 120145 RVA: 0x008C8AB4 File Offset: 0x008C6CB4
	public unsafe override void ApplyScanEffect(AActor inActor)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ApplyScanEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams*)ptr + 15L / (long)sizeof(TsLevelGamePlayBridge.__ApplyScanEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->inActor) = ((inActor != null) ? inActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D552 RID: 120146 RVA: 0x008C8B3C File Offset: 0x008C6D3C
	public unsafe override void ClearAllScanEffects()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ClearAllScanEffects"), out num);
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
