using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386D RID: 14445
public class __TsTowerDefenseEventActor_InheritProxy : TsTowerDefenseEventActor
{
	// Token: 0x0601D5B4 RID: 120244 RVA: 0x008C9C48 File Offset: 0x008C7E48
	[NullableContext(1)]
	public __TsTowerDefenseEventActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTowerDefenseEventActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5B5 RID: 120245 RVA: 0x008C9C7B File Offset: 0x008C7E7B
	protected __TsTowerDefenseEventActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5B6 RID: 120246 RVA: 0x008C9C84 File Offset: 0x008C7E84
	protected override void __CPPCALL_OnLevelShown_Implementation()
	{
		base.OnLevelShown_Implementation();
	}
}
