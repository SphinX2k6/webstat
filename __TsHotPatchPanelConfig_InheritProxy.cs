using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003971 RID: 14705
public class __TsHotPatchPanelConfig_InheritProxy : TsHotPatchPanelConfig
{
	// Token: 0x0601DA00 RID: 121344 RVA: 0x008D6580 File Offset: 0x008D4780
	[NullableContext(1)]
	public __TsHotPatchPanelConfig_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHotPatchPanelConfig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA01 RID: 121345 RVA: 0x008D65B3 File Offset: 0x008D47B3
	protected __TsHotPatchPanelConfig_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601DA02 RID: 121346 RVA: 0x008D65BC File Offset: 0x008D47BC
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601DA03 RID: 121347 RVA: 0x008D65C4 File Offset: 0x008D47C4
	protected override void __CPPCALL_OnEnableBP_Implementation()
	{
		base.OnEnableBP_Implementation();
	}

	// Token: 0x0601DA04 RID: 121348 RVA: 0x008D65CC File Offset: 0x008D47CC
	protected override void __CPPCALL_OnDisableBP_Implementation()
	{
		base.OnDisableBP_Implementation();
	}
}
