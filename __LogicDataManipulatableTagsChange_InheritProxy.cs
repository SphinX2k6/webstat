using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A3 RID: 14499
public class __LogicDataManipulatableTagsChange_InheritProxy : LogicDataManipulatableTagsChange
{
	// Token: 0x0601D649 RID: 120393 RVA: 0x008CABCC File Offset: 0x008C8DCC
	[NullableContext(1)]
	public __LogicDataManipulatableTagsChange_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableTagsChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D64A RID: 120394 RVA: 0x008CABFF File Offset: 0x008C8DFF
	protected __LogicDataManipulatableTagsChange_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
