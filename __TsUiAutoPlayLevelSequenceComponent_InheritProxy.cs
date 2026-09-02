using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003871 RID: 14449
public class __TsUiAutoPlayLevelSequenceComponent_InheritProxy : TsUiAutoPlayLevelSequenceComponent
{
	// Token: 0x0601D5BF RID: 120255 RVA: 0x008C9DC8 File Offset: 0x008C7FC8
	[NullableContext(1)]
	public __TsUiAutoPlayLevelSequenceComponent_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiAutoPlayLevelSequenceComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5C0 RID: 120256 RVA: 0x008C9DFB File Offset: 0x008C7FFB
	protected __TsUiAutoPlayLevelSequenceComponent_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5C1 RID: 120257 RVA: 0x008C9E04 File Offset: 0x008C8004
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601D5C2 RID: 120258 RVA: 0x008C9E0C File Offset: 0x008C800C
	protected unsafe override void __CPPCALL_OnUIActiveInHierarchyBP_Implementation(ULGUIBehaviour.__OnUIActiveInHierarchyBP_FunctionParams* __Params)
	{
		base.OnUIActiveInHierarchyBP_Implementation(__Params->activeOrInactive);
	}

	// Token: 0x0601D5C3 RID: 120259 RVA: 0x008C9E1A File Offset: 0x008C801A
	protected override void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		base.OnPreDestroyBP_Implementation();
	}

	// Token: 0x0601D5C4 RID: 120260 RVA: 0x008C9E22 File Offset: 0x008C8022
	protected unsafe override void __CPPCALL_UpdateBP_Implementation(ULGUIBehaviour.__UpdateBP_FunctionParams* __Params)
	{
		base.UpdateBP_Implementation(__Params->DeltaTime);
	}
}
