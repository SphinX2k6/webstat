using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038EC RID: 14572
public class __SceneItemLibrary_SubClassMissingExportProxy : __SceneItemLibrary_InheritProxy
{
	// Token: 0x0601D718 RID: 120600 RVA: 0x008CCA08 File Offset: 0x008CAC08
	[NullableContext(1)]
	protected __SceneItemLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneItemLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D719 RID: 120601 RVA: 0x008CCA3B File Offset: 0x008CAC3B
	protected __SceneItemLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
