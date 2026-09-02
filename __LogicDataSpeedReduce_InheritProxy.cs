using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AF RID: 14511
public class __LogicDataSpeedReduce_InheritProxy : LogicDataSpeedReduce
{
	// Token: 0x0601D661 RID: 120417 RVA: 0x008CAE9C File Offset: 0x008C909C
	[NullableContext(1)]
	public __LogicDataSpeedReduce_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpeedReduce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D662 RID: 120418 RVA: 0x008CAECF File Offset: 0x008C90CF
	protected __LogicDataSpeedReduce_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
