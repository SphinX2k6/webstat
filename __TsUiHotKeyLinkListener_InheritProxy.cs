using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003883 RID: 14467
public class __TsUiHotKeyLinkListener_InheritProxy : TsUiHotKeyLinkListener
{
	// Token: 0x0601D605 RID: 120325 RVA: 0x008CA3F8 File Offset: 0x008C85F8
	[NullableContext(1)]
	public __TsUiHotKeyLinkListener_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyLinkListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D606 RID: 120326 RVA: 0x008CA42B File Offset: 0x008C862B
	protected __TsUiHotKeyLinkListener_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
