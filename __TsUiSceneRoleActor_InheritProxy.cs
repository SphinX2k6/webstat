using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003875 RID: 14453
public class __TsUiSceneRoleActor_InheritProxy : TsUiSceneRoleActor
{
	// Token: 0x0601D5CC RID: 120268 RVA: 0x008C9EF4 File Offset: 0x008C80F4
	[NullableContext(1)]
	public __TsUiSceneRoleActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiSceneRoleActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5CD RID: 120269 RVA: 0x008C9F27 File Offset: 0x008C8127
	protected __TsUiSceneRoleActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5CE RID: 120270 RVA: 0x008C9F30 File Offset: 0x008C8130
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D5CF RID: 120271 RVA: 0x008C9F3E File Offset: 0x008C813E
	protected unsafe override void __CPPCALL_IsShowUiWepaonEffect_Implementation(TsUiSceneRoleActor.__IsShowUiWepaonEffect_FunctionParams* __Params)
	{
		__Params->__Result = base.IsShowUiWepaonEffect_Implementation();
	}
}
