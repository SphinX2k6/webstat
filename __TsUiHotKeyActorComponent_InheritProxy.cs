using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003881 RID: 14465
public class __TsUiHotKeyActorComponent_InheritProxy : TsUiHotKeyActorComponent
{
	// Token: 0x0601D5FC RID: 120316 RVA: 0x008CA358 File Offset: 0x008C8558
	[NullableContext(1)]
	public __TsUiHotKeyActorComponent_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHotKeyActorComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5FD RID: 120317 RVA: 0x008CA38B File Offset: 0x008C858B
	protected __TsUiHotKeyActorComponent_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5FE RID: 120318 RVA: 0x008CA394 File Offset: 0x008C8594
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601D5FF RID: 120319 RVA: 0x008CA39C File Offset: 0x008C859C
	protected override void __CPPCALL_StartBP_Implementation()
	{
		base.StartBP_Implementation();
	}

	// Token: 0x0601D600 RID: 120320 RVA: 0x008CA3A4 File Offset: 0x008C85A4
	protected override void __CPPCALL_OnEnableBP_Implementation()
	{
		base.OnEnableBP_Implementation();
	}

	// Token: 0x0601D601 RID: 120321 RVA: 0x008CA3AC File Offset: 0x008C85AC
	protected override void __CPPCALL_OnDisableBP_Implementation()
	{
		base.OnDisableBP_Implementation();
	}

	// Token: 0x0601D602 RID: 120322 RVA: 0x008CA3B4 File Offset: 0x008C85B4
	protected override void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		base.OnPreDestroyBP_Implementation();
	}
}
