using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038EB RID: 14571
public class __SceneItemLibrary_InheritProxy : SceneItemLibrary
{
	// Token: 0x0601D716 RID: 120598 RVA: 0x008CC9CC File Offset: 0x008CABCC
	[NullableContext(1)]
	public __SceneItemLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SceneItemLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D717 RID: 120599 RVA: 0x008CC9FF File Offset: 0x008CABFF
	protected __SceneItemLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
