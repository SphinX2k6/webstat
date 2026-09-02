using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003873 RID: 14451
public class __TsUiSceneDangoActor_InheritProxy : TsUiSceneDangoActor
{
	// Token: 0x0601D5C7 RID: 120263 RVA: 0x008C9E6C File Offset: 0x008C806C
	[NullableContext(1)]
	public __TsUiSceneDangoActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiSceneDangoActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5C8 RID: 120264 RVA: 0x008C9E9F File Offset: 0x008C809F
	protected __TsUiSceneDangoActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5C9 RID: 120265 RVA: 0x008C9EA8 File Offset: 0x008C80A8
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}
}
