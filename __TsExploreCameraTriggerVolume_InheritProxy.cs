using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038EF RID: 14575
public class __TsExploreCameraTriggerVolume_InheritProxy : TsExploreCameraTriggerVolume
{
	// Token: 0x0601D72E RID: 120622 RVA: 0x008CCFAC File Offset: 0x008CB1AC
	[NullableContext(1)]
	public __TsExploreCameraTriggerVolume_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsExploreCameraTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D72F RID: 120623 RVA: 0x008CCFDF File Offset: 0x008CB1DF
	protected __TsExploreCameraTriggerVolume_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
