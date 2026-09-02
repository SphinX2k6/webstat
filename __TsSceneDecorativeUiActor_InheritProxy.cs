using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003863 RID: 14435
public class __TsSceneDecorativeUiActor_InheritProxy : TsSceneDecorativeUiActor
{
	// Token: 0x0601D595 RID: 120213 RVA: 0x008C97C8 File Offset: 0x008C79C8
	[NullableContext(1)]
	public __TsSceneDecorativeUiActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneDecorativeUiActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D596 RID: 120214 RVA: 0x008C97FB File Offset: 0x008C79FB
	protected __TsSceneDecorativeUiActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D597 RID: 120215 RVA: 0x008C9804 File Offset: 0x008C7A04
	protected override void __CPPCALL_Create3dUi_Implementation()
	{
		base.Create3dUi_Implementation();
	}

	// Token: 0x0601D598 RID: 120216 RVA: 0x008C980C File Offset: 0x008C7A0C
	protected override void __CPPCALL_Destroy3dUi_Implementation()
	{
		base.Destroy3dUi_Implementation();
	}

	// Token: 0x0601D599 RID: 120217 RVA: 0x008C9814 File Offset: 0x008C7A14
	protected override void __CPPCALL_DrawDistance_Implementation()
	{
		base.DrawDistance_Implementation();
	}
}
