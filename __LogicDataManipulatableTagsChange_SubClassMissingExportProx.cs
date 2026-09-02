using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A4 RID: 14500
public class __LogicDataManipulatableTagsChange_SubClassMissingExportProxy : __LogicDataManipulatableTagsChange_InheritProxy
{
	// Token: 0x0601D64B RID: 120395 RVA: 0x008CAC08 File Offset: 0x008C8E08
	[NullableContext(1)]
	protected __LogicDataManipulatableTagsChange_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableTagsChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D64C RID: 120396 RVA: 0x008CAC3B File Offset: 0x008C8E3B
	protected __LogicDataManipulatableTagsChange_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
