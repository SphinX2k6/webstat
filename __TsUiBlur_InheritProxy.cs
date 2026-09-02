using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386F RID: 14447
public class __TsUiBlur_InheritProxy : TsUiBlur
{
	// Token: 0x0601D5B9 RID: 120249 RVA: 0x008C9CC8 File Offset: 0x008C7EC8
	[NullableContext(1)]
	public __TsUiBlur_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiBlur.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5BA RID: 120250 RVA: 0x008C9CFB File Offset: 0x008C7EFB
	protected __TsUiBlur_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5BB RID: 120251 RVA: 0x008C9D04 File Offset: 0x008C7F04
	protected unsafe override void __CPPCALL_SetEnableUiBlur_Implementation(TsUiBlur.__SetEnableUiBlur_FunctionParams* __Params)
	{
		base.SetEnableUiBlur_Implementation(__Params->value);
	}
}
