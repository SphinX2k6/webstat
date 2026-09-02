using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200387F RID: 14463
public class __TsUiNavigationTextChangeListener_InheritProxy : TsUiNavigationTextChangeListener
{
	// Token: 0x0601D5F5 RID: 120309 RVA: 0x008CA2AC File Offset: 0x008C84AC
	[NullableContext(1)]
	public __TsUiNavigationTextChangeListener_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationTextChangeListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5F6 RID: 120310 RVA: 0x008CA2DF File Offset: 0x008C84DF
	protected __TsUiNavigationTextChangeListener_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5F7 RID: 120311 RVA: 0x008CA2E8 File Offset: 0x008C84E8
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601D5F8 RID: 120312 RVA: 0x008CA2F0 File Offset: 0x008C84F0
	protected override void __CPPCALL_StartBP_Implementation()
	{
		base.StartBP_Implementation();
	}

	// Token: 0x0601D5F9 RID: 120313 RVA: 0x008CA2F8 File Offset: 0x008C84F8
	protected unsafe override void __CPPCALL_OnNotifyTextChangeBP_Implementation(UUINavigationTextChangeListener.__OnNotifyTextChangeBP_FunctionParams* __Params)
	{
		string notifyText = FString.ToString((void*)(&__Params->NotifyText));
		base.OnNotifyTextChangeBP_Implementation(notifyText);
	}
}
