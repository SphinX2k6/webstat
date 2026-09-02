using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003911 RID: 14609
public class __AnimNotifyAddTransferEffect_InheritProxy : AnimNotifyAddTransferEffect
{
	// Token: 0x0601D801 RID: 120833 RVA: 0x008CF86C File Offset: 0x008CDA6C
	[NullableContext(1)]
	public __AnimNotifyAddTransferEffect_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddTransferEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D802 RID: 120834 RVA: 0x008CF89F File Offset: 0x008CDA9F
	protected __AnimNotifyAddTransferEffect_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D803 RID: 120835 RVA: 0x008CF8A8 File Offset: 0x008CDAA8
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName_Implementation());
	}
}
