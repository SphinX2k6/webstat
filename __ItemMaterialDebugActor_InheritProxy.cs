using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200395D RID: 14685
public class __ItemMaterialDebugActor_InheritProxy : ItemMaterialDebugActor
{
	// Token: 0x0601D937 RID: 121143 RVA: 0x008D35D4 File Offset: 0x008D17D4
	[NullableContext(1)]
	public __ItemMaterialDebugActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDebugActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D938 RID: 121144 RVA: 0x008D3607 File Offset: 0x008D1807
	protected __ItemMaterialDebugActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D939 RID: 121145 RVA: 0x008D3610 File Offset: 0x008D1810
	protected override void __CPPCALL_DisableAllActorData_Implementation()
	{
		base.DisableAllActorData_Implementation();
	}

	// Token: 0x0601D93A RID: 121146 RVA: 0x008D3618 File Offset: 0x008D1818
	protected override void __CPPCALL_DisableActorData_Implementation()
	{
		base.DisableActorData_Implementation();
	}

	// Token: 0x0601D93B RID: 121147 RVA: 0x008D3620 File Offset: 0x008D1820
	protected override void __CPPCALL_EnableActorData_Implementation()
	{
		base.EnableActorData_Implementation();
	}

	// Token: 0x0601D93C RID: 121148 RVA: 0x008D3628 File Offset: 0x008D1828
	protected override void __CPPCALL_SimpleMaterialControllerDisable_Implementation()
	{
		base.SimpleMaterialControllerDisable_Implementation();
	}

	// Token: 0x0601D93D RID: 121149 RVA: 0x008D3630 File Offset: 0x008D1830
	protected override void __CPPCALL_SimpleMaterialControllerUpdate_Implementation()
	{
		base.SimpleMaterialControllerUpdate_Implementation();
	}
}
