using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B6 RID: 14518
public class __LogicDataSummonRandom_SubClassMissingExportProxy : __LogicDataSummonRandom_InheritProxy
{
	// Token: 0x0601D66F RID: 120431 RVA: 0x008CB040 File Offset: 0x008C9240
	[NullableContext(1)]
	protected __LogicDataSummonRandom_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSummonRandom.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D670 RID: 120432 RVA: 0x008CB073 File Offset: 0x008C9273
	protected __LogicDataSummonRandom_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
