using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003953 RID: 14675
public class __SceneInteractionDebugTool_InheritProxy : SceneInteractionDebugTool
{
	// Token: 0x0601D91E RID: 121118 RVA: 0x008D3258 File Offset: 0x008D1458
	[NullableContext(1)]
	public __SceneInteractionDebugTool_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneInteractionDebugTool.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D91F RID: 121119 RVA: 0x008D328B File Offset: 0x008D148B
	protected __SceneInteractionDebugTool_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D920 RID: 121120 RVA: 0x008D3294 File Offset: 0x008D1494
	protected override void __CPPCALL_AttachInteraction_Implementation()
	{
		base.AttachInteraction_Implementation();
	}

	// Token: 0x0601D921 RID: 121121 RVA: 0x008D329C File Offset: 0x008D149C
	protected override void __CPPCALL_RemoveInteraction_Implementation()
	{
		base.RemoveInteraction_Implementation();
	}
}
