using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200382C RID: 14380
[NullableContext(1)]
[Nullable(0)]
public class __TsActionHandle_SubClassMissingExportProxy : __TsActionHandle_InheritProxy
{
	// Token: 0x0601D4AA RID: 119978 RVA: 0x008C6A88 File Offset: 0x008C4C88
	protected __TsActionHandle_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsActionHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4AB RID: 119979 RVA: 0x008C6ABB File Offset: 0x008C4CBB
	protected __TsActionHandle_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4AC RID: 119980 RVA: 0x008C6AC4 File Offset: 0x008C4CC4
	protected unsafe override void OnPressAction(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPressAction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsActionHandle.__OnPressAction_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsActionHandle.__OnPressAction_FunctionParams*)ptr + 15L / (long)sizeof(TsActionHandle.__OnPressAction_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D4AD RID: 119981 RVA: 0x008C6B54 File Offset: 0x008C4D54
	protected unsafe override void OnReleaseAction(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnReleaseAction"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsActionHandle.__OnReleaseAction_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsActionHandle.__OnReleaseAction_FunctionParams*)ptr + 15L / (long)sizeof(TsActionHandle.__OnReleaseAction_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
