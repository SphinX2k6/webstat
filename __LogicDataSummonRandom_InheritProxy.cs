using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B5 RID: 14517
public class __LogicDataSummonRandom_InheritProxy : LogicDataSummonRandom
{
	// Token: 0x0601D66D RID: 120429 RVA: 0x008CB004 File Offset: 0x008C9204
	[NullableContext(1)]
	public __LogicDataSummonRandom_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSummonRandom.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D66E RID: 120430 RVA: 0x008CB037 File Offset: 0x008C9237
	protected __LogicDataSummonRandom_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
