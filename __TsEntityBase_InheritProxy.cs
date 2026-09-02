using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003977 RID: 14711
public class __TsEntityBase_InheritProxy : TsEntityBase
{
	// Token: 0x0601DA0F RID: 121359 RVA: 0x008D6700 File Offset: 0x008D4900
	[NullableContext(1)]
	public __TsEntityBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA10 RID: 121360 RVA: 0x008D6733 File Offset: 0x008D4933
	protected __TsEntityBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601DA11 RID: 121361 RVA: 0x008D673C File Offset: 0x008D493C
	protected override void __CPPCALL_EditorInit_Implementation()
	{
		base.EditorInit_Implementation();
	}

	// Token: 0x0601DA12 RID: 121362 RVA: 0x008D6744 File Offset: 0x008D4944
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}
}
