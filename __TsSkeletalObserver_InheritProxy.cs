using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386B RID: 14443
public class __TsSkeletalObserver_InheritProxy : TsSkeletalObserver
{
	// Token: 0x0601D5AF RID: 120239 RVA: 0x008C9BC0 File Offset: 0x008C7DC0
	[NullableContext(1)]
	public __TsSkeletalObserver_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSkeletalObserver.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5B0 RID: 120240 RVA: 0x008C9BF3 File Offset: 0x008C7DF3
	protected __TsSkeletalObserver_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5B1 RID: 120241 RVA: 0x008C9BFC File Offset: 0x008C7DFC
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}
}
