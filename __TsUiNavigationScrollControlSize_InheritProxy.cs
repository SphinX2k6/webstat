using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003885 RID: 14469
public class __TsUiNavigationScrollControlSize_InheritProxy : TsUiNavigationScrollControlSize
{
	// Token: 0x0601D609 RID: 120329 RVA: 0x008CA470 File Offset: 0x008C8670
	[NullableContext(1)]
	public __TsUiNavigationScrollControlSize_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationScrollControlSize.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D60A RID: 120330 RVA: 0x008CA4A3 File Offset: 0x008C86A3
	protected __TsUiNavigationScrollControlSize_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D60B RID: 120331 RVA: 0x008CA4AC File Offset: 0x008C86AC
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601D60C RID: 120332 RVA: 0x008CA4B4 File Offset: 0x008C86B4
	protected unsafe override void __CPPCALL_LateUpdateBP_Implementation(ULGUIBehaviour.__LateUpdateBP_FunctionParams* __Params)
	{
		base.LateUpdateBP_Implementation(__Params->DeltaTime);
	}

	// Token: 0x0601D60D RID: 120333 RVA: 0x008CA4C2 File Offset: 0x008C86C2
	protected override void __CPPCALL_OnDisableBP_Implementation()
	{
		base.OnDisableBP_Implementation();
	}
}
