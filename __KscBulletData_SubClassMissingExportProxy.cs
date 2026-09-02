using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003842 RID: 14402
public class __KscBulletData_SubClassMissingExportProxy : __KscBulletData_InheritProxy
{
	// Token: 0x0601D512 RID: 120082 RVA: 0x008C7EA4 File Offset: 0x008C60A4
	[NullableContext(1)]
	protected __KscBulletData_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBulletData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D513 RID: 120083 RVA: 0x008C7ED7 File Offset: 0x008C60D7
	protected __KscBulletData_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
