using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE4 RID: 11748
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAdditiveAccelerate.LogicDataAdditiveAccelerate_C")]
public class LogicDataAdditiveAccelerate : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FA3 RID: 8099
	// (get) Token: 0x06017AFE RID: 97022 RVA: 0x0069DFF8 File Offset: 0x0069C1F8
	// (set) Token: 0x06017AFF RID: 97023 RVA: 0x0069E00C File Offset: 0x0069C20C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Acceleration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataAdditiveAccelerate.__PropertyOffset_Acceleration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataAdditiveAccelerate.__PropertyOffset_Acceleration) = value;
		}
	}

	// Token: 0x17001FA4 RID: 8100
	// (get) Token: 0x06017B00 RID: 97024 RVA: 0x0069E021 File Offset: 0x0069C221
	// (set) Token: 0x06017B01 RID: 97025 RVA: 0x0069E035 File Offset: 0x0069C235
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveVector AccelerationCurve
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataAdditiveAccelerate.__PropertyOffset_AccelerationCurve);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataAdditiveAccelerate.__PropertyOffset_AccelerationCurve, value);
		}
	}

	// Token: 0x06017B02 RID: 97026 RVA: 0x0069E04A File Offset: 0x0069C24A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataAdditiveAccelerate._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAdditiveAccelerate.LogicDataAdditiveAccelerate_C");
		}
		return LogicDataAdditiveAccelerate._ClassPtr;
	}

	// Token: 0x06017B03 RID: 97027 RVA: 0x0069E070 File Offset: 0x0069C270
	public LogicDataAdditiveAccelerate() : this(BuiltinUtils.AllocNativeUObject(LogicDataAdditiveAccelerate.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B04 RID: 97028 RVA: 0x0069E098 File Offset: 0x0069C298
	[NullableContext(1)]
	public LogicDataAdditiveAccelerate(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataAdditiveAccelerate.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B05 RID: 97029 RVA: 0x0069E0CB File Offset: 0x0069C2CB
	protected LogicDataAdditiveAccelerate(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6B6 RID: 46774
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAdditiveAccelerate.LogicDataAdditiveAccelerate_C";

	// Token: 0x0400B6B7 RID: 46775
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6B8 RID: 46776
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6B9 RID: 46777
	private static int __PropertyOffset_Acceleration;

	// Token: 0x0400B6BA RID: 46778
	private static int __PropertyOffset_AccelerationCurve;
}
