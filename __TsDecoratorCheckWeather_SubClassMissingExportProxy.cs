using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003566 RID: 13670
public class __TsDecoratorCheckWeather_SubClassMissingExportProxy : __TsDecoratorCheckWeather_InheritProxy
{
	// Token: 0x0601CBAF RID: 117679 RVA: 0x008B1C18 File Offset: 0x008AFE18
	[NullableContext(1)]
	protected __TsDecoratorCheckWeather_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckWeather.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBB0 RID: 117680 RVA: 0x008B1C4B File Offset: 0x008AFE4B
	protected __TsDecoratorCheckWeather_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
