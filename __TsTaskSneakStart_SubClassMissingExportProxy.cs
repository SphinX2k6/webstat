using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200366A RID: 13930
public class __TsTaskSneakStart_SubClassMissingExportProxy : __TsTaskSneakStart_InheritProxy
{
	// Token: 0x0601CE7D RID: 118397 RVA: 0x008B80F8 File Offset: 0x008B62F8
	[NullableContext(1)]
	protected __TsTaskSneakStart_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSneakStart.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE7E RID: 118398 RVA: 0x008B812B File Offset: 0x008B632B
	protected __TsTaskSneakStart_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
