using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003563 RID: 13667
public class __TsDecoratorCheckSkillUsable_InheritProxy : TsDecoratorCheckSkillUsable
{
	// Token: 0x0601CBA7 RID: 117671 RVA: 0x008B1AFC File Offset: 0x008AFCFC
	[NullableContext(1)]
	public __TsDecoratorCheckSkillUsable_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckSkillUsable.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBA8 RID: 117672 RVA: 0x008B1B2F File Offset: 0x008AFD2F
	protected __TsDecoratorCheckSkillUsable_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CBA9 RID: 117673 RVA: 0x008B1B38 File Offset: 0x008AFD38
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
