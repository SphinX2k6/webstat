using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC7 RID: 3527
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableUiMotorSoarWing.TsAnimNotifyDisableUiMotorSoarWing_C")]
public class TsAnimNotifyDisableUiMotorSoarWing : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005042 RID: 20546 RVA: 0x000B9248 File Offset: 0x000B7448
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsSkeletalObserver))
		{
			return false;
		}
		UiDecorationLoadComponent uiDecorationLoadComponent = (owner as TsSkeletalObserver).Model.CheckGetComponent<UiDecorationLoadComponent>();
		object obj;
		if (uiDecorationLoadComponent == null)
		{
			obj = null;
		}
		else
		{
			UiModelActorComponent attachActorComponent = uiDecorationLoadComponent.GetAttachActorComponent();
			obj = ((attachActorComponent != null) ? attachActorComponent.Owner : null);
		}
		object obj2 = obj;
		UiMotorSoarWingComponent uiMotorSoarWingComponent = (obj2 != null) ? obj2.CheckGetComponent<UiMotorSoarWingComponent>() : null;
		if (uiMotorSoarWingComponent == null)
		{
			return false;
		}
		uiMotorSoarWingComponent.SetActive(false);
		return true;
	}

	// Token: 0x06005043 RID: 20547 RVA: 0x000B92A8 File Offset: 0x000B74A8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "隐藏Ui摩托翱翔翼";
	}

	// Token: 0x06005044 RID: 20548 RVA: 0x000B92AF File Offset: 0x000B74AF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDisableUiMotorSoarWing._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableUiMotorSoarWing.TsAnimNotifyDisableUiMotorSoarWing_C");
		}
		return TsAnimNotifyDisableUiMotorSoarWing._ClassPtr;
	}

	// Token: 0x06005045 RID: 20549 RVA: 0x000B92D4 File Offset: 0x000B74D4
	public TsAnimNotifyDisableUiMotorSoarWing() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableUiMotorSoarWing.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005046 RID: 20550 RVA: 0x000B92FC File Offset: 0x000B74FC
	[NullableContext(1)]
	public TsAnimNotifyDisableUiMotorSoarWing(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableUiMotorSoarWing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005047 RID: 20551 RVA: 0x000B932F File Offset: 0x000B752F
	protected TsAnimNotifyDisableUiMotorSoarWing(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005048 RID: 20552 RVA: 0x000B9338 File Offset: 0x000B7538
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005049 RID: 20553 RVA: 0x000B936B File Offset: 0x000B756B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001772 RID: 6002
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableUiMotorSoarWing.TsAnimNotifyDisableUiMotorSoarWing_C";

	// Token: 0x04001773 RID: 6003
	private static IntPtr _ClassPtr;

	// Token: 0x04001774 RID: 6004
	private static IntPtr _ClassDefaultObjectPtr;
}
