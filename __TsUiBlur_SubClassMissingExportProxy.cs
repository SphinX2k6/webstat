using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003870 RID: 14448
public class __TsUiBlur_SubClassMissingExportProxy : __TsUiBlur_InheritProxy
{
	// Token: 0x0601D5BC RID: 120252 RVA: 0x008C9D14 File Offset: 0x008C7F14
	[NullableContext(1)]
	protected __TsUiBlur_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiBlur.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5BD RID: 120253 RVA: 0x008C9D47 File Offset: 0x008C7F47
	protected __TsUiBlur_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5BE RID: 120254 RVA: 0x008C9D50 File Offset: 0x008C7F50
	public unsafe override void SetEnableUiBlur(bool value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEnableUiBlur"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsUiBlur.__SetEnableUiBlur_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsUiBlur.__SetEnableUiBlur_FunctionParams*)ptr + 15L / (long)sizeof(TsUiBlur.__SetEnableUiBlur_FunctionParams) & -16L);
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
