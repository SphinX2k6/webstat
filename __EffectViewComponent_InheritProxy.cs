using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003951 RID: 14673
public class __EffectViewComponent_InheritProxy : EffectViewComponent
{
	// Token: 0x0601D912 RID: 121106 RVA: 0x008D2FD4 File Offset: 0x008D11D4
	[NullableContext(1)]
	public __EffectViewComponent_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectViewComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D913 RID: 121107 RVA: 0x008D3007 File Offset: 0x008D1207
	protected __EffectViewComponent_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D914 RID: 121108 RVA: 0x008D3010 File Offset: 0x008D1210
	protected unsafe override void __CPPCALL_EditorTick_Implementation(EffectViewComponent.__EditorTick_FunctionParams* __Params)
	{
		base.EditorTick_Implementation(__Params->deltaSecond);
	}

	// Token: 0x0601D915 RID: 121109 RVA: 0x008D301E File Offset: 0x008D121E
	protected unsafe override void __CPPCALL_SetAutoPlay_Implementation(EffectViewComponent.__SetAutoPlay_FunctionParams* __Params)
	{
		base.SetAutoPlay_Implementation(__Params->autoPlay);
	}

	// Token: 0x0601D916 RID: 121110 RVA: 0x008D302C File Offset: 0x008D122C
	protected override void __CPPCALL_Play_Implementation()
	{
		base.Play_Implementation();
	}

	// Token: 0x0601D917 RID: 121111 RVA: 0x008D3034 File Offset: 0x008D1234
	protected unsafe override void __CPPCALL_Stop_Implementation(EffectViewComponent.__Stop_FunctionParams* __Params)
	{
		base.Stop_Implementation(__Params->immediately);
	}
}
