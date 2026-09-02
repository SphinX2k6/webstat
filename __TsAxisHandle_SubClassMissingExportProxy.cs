using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200382E RID: 14382
public class __TsAxisHandle_SubClassMissingExportProxy : __TsAxisHandle_InheritProxy
{
	// Token: 0x0601D4B1 RID: 119985 RVA: 0x008C6C30 File Offset: 0x008C4E30
	[NullableContext(1)]
	protected __TsAxisHandle_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAxisHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4B2 RID: 119986 RVA: 0x008C6C63 File Offset: 0x008C4E63
	protected __TsAxisHandle_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4B3 RID: 119987 RVA: 0x008C6C6C File Offset: 0x008C4E6C
	protected unsafe override void OnInputAxis(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnInputAxis"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAxisHandle.__OnInputAxis_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAxisHandle.__OnInputAxis_FunctionParams*)ptr + 15L / (long)sizeof(TsAxisHandle.__OnInputAxis_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
