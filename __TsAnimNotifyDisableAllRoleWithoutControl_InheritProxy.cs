using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037B3 RID: 14259
public class __TsAnimNotifyDisableAllRoleWithoutControl_InheritProxy : TsAnimNotifyDisableAllRoleWithoutControl
{
	// Token: 0x0601D335 RID: 119605 RVA: 0x008C3A74 File Offset: 0x008C1C74
	[NullableContext(1)]
	public __TsAnimNotifyDisableAllRoleWithoutControl_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableAllRoleWithoutControl.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D336 RID: 119606 RVA: 0x008C3AA7 File Offset: 0x008C1CA7
	protected __TsAnimNotifyDisableAllRoleWithoutControl_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D337 RID: 119607 RVA: 0x008C3AB0 File Offset: 0x008C1CB0
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D338 RID: 119608 RVA: 0x008C3AE3 File Offset: 0x008C1CE3
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName_Implementation());
	}
}
