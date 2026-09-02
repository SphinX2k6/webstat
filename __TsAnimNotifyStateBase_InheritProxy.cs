using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020036A3 RID: 13987
public class __TsAnimNotifyStateBase_InheritProxy : TsAnimNotifyStateBase
{
	// Token: 0x0601CF8E RID: 118670 RVA: 0x008BB700 File Offset: 0x008B9900
	[NullableContext(1)]
	public __TsAnimNotifyStateBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CF8F RID: 118671 RVA: 0x008BB733 File Offset: 0x008B9933
	protected __TsAnimNotifyStateBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CF90 RID: 118672 RVA: 0x008BB73C File Offset: 0x008B993C
	protected unsafe override void __CPPCALL_K2_NotifyBeginConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyBeginConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_NotifyBeginConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601CF91 RID: 118673 RVA: 0x008BB778 File Offset: 0x008B9978
	protected unsafe override void __CPPCALL_K2_NotifyTickConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyTickConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_NotifyTickConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x0601CF92 RID: 118674 RVA: 0x008BB7B4 File Offset: 0x008B99B4
	protected unsafe override void __CPPCALL_K2_NotifyEndConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyEndConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_NotifyEndConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
