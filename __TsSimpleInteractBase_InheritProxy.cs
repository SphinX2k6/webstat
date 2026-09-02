using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E1 RID: 14561
public class __TsSimpleInteractBase_InheritProxy : TsSimpleInteractBase
{
	// Token: 0x0601D6FA RID: 120570 RVA: 0x008CC5E0 File Offset: 0x008CA7E0
	[NullableContext(1)]
	public __TsSimpleInteractBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6FB RID: 120571 RVA: 0x008CC613 File Offset: 0x008CA813
	protected __TsSimpleInteractBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D6FC RID: 120572 RVA: 0x008CC61C File Offset: 0x008CA81C
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D6FD RID: 120573 RVA: 0x008CC624 File Offset: 0x008CA824
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D6FE RID: 120574 RVA: 0x008CC644 File Offset: 0x008CA844
	protected override void __CPPCALL_EditorInit_Implementation()
	{
		base.EditorInit_Implementation();
	}

	// Token: 0x0601D6FF RID: 120575 RVA: 0x008CC64C File Offset: 0x008CA84C
	protected unsafe override void __CPPCALL_EditorTick_Implementation(AKuroEffectActor.__EditorTick_FunctionParams* __Params)
	{
		base.EditorTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D700 RID: 120576 RVA: 0x008CC65C File Offset: 0x008CA85C
	protected unsafe override void __CPPCALL_GetBestTransform_Implementation(TsSimpleInteractBase.__GetBestTransform_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->actor);
		__Params->__Result = base.GetBestTransform_Implementation(orCreateUObjectByNativePointer, __Params->moveOffset, __Params->halfHeight, __Params->radius);
	}

	// Token: 0x0601D701 RID: 120577 RVA: 0x008CC694 File Offset: 0x008CA894
	protected override void __CPPCALL_Draw_Implementation()
	{
		base.Draw_Implementation();
	}
}
