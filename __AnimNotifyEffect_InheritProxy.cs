using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003919 RID: 14617
public class __AnimNotifyEffect_InheritProxy : AnimNotifyEffect
{
	// Token: 0x0601D88D RID: 120973 RVA: 0x008D1F98 File Offset: 0x008D0198
	[NullableContext(1)]
	public __AnimNotifyEffect_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D88E RID: 120974 RVA: 0x008D1FCB File Offset: 0x008D01CB
	protected __AnimNotifyEffect_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D88F RID: 120975 RVA: 0x008D1FD4 File Offset: 0x008D01D4
	protected unsafe override void __CPPCALL_K2_ValidateAssets_Implementation(UKuroAnimNotify.__K2_ValidateAssets_FunctionParams* __Params)
	{
		__Params->__Result = base.K2_ValidateAssets_Implementation();
	}

	// Token: 0x0601D890 RID: 120976 RVA: 0x008D1FE4 File Offset: 0x008D01E4
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D891 RID: 120977 RVA: 0x008D2017 File Offset: 0x008D0217
	protected unsafe override void __CPPCALL_K2_PostChangeProperty_Implementation(UKuroAnimNotify.__K2_PostChangeProperty_FunctionParams* __Params)
	{
		__Params->__Result = base.K2_PostChangeProperty_Implementation(__Params->PropertyName);
	}

	// Token: 0x0601D892 RID: 120978 RVA: 0x008D202B File Offset: 0x008D022B
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName_Implementation());
	}
}
