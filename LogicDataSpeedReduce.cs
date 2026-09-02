using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF5 RID: 11765
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpeedReduce.LogicDataSpeedReduce_C")]
public class LogicDataSpeedReduce : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002008 RID: 8200
	// (get) Token: 0x06017C0C RID: 97292 RVA: 0x0069FD10 File Offset: 0x0069DF10
	// (set) Token: 0x06017C0D RID: 97293 RVA: 0x0069FD20 File Offset: 0x0069DF20
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SpeedDampingRatio
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_SpeedDampingRatio);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_SpeedDampingRatio) = value;
		}
	}

	// Token: 0x17002009 RID: 8201
	// (get) Token: 0x06017C0E RID: 97294 RVA: 0x0069FD31 File Offset: 0x0069DF31
	// (set) Token: 0x06017C0F RID: 97295 RVA: 0x0069FD41 File Offset: 0x0069DF41
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsNotThroughObstacles
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_IsNotThroughObstacles) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_IsNotThroughObstacles) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700200A RID: 8202
	// (get) Token: 0x06017C10 RID: 97296 RVA: 0x0069FD52 File Offset: 0x0069DF52
	// (set) Token: 0x06017C11 RID: 97297 RVA: 0x0069FD62 File Offset: 0x0069DF62
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_MinSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpeedReduce.__PropertyOffset_MinSpeed) = value;
		}
	}

	// Token: 0x06017C12 RID: 97298 RVA: 0x0069FD73 File Offset: 0x0069DF73
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSpeedReduce._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpeedReduce.LogicDataSpeedReduce_C");
		}
		return LogicDataSpeedReduce._ClassPtr;
	}

	// Token: 0x06017C13 RID: 97299 RVA: 0x0069FD98 File Offset: 0x0069DF98
	public LogicDataSpeedReduce() : this(BuiltinUtils.AllocNativeUObject(LogicDataSpeedReduce.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C14 RID: 97300 RVA: 0x0069FDC0 File Offset: 0x0069DFC0
	[NullableContext(1)]
	public LogicDataSpeedReduce(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpeedReduce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C15 RID: 97301 RVA: 0x0069FDF3 File Offset: 0x0069DFF3
	protected LogicDataSpeedReduce(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B76C RID: 46956
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpeedReduce.LogicDataSpeedReduce_C";

	// Token: 0x0400B76D RID: 46957
	private static IntPtr _ClassPtr;

	// Token: 0x0400B76E RID: 46958
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B76F RID: 46959
	private static int __PropertyOffset_SpeedDampingRatio;

	// Token: 0x0400B770 RID: 46960
	private static int __PropertyOffset_IsNotThroughObstacles;

	// Token: 0x0400B771 RID: 46961
	private static int __PropertyOffset_MinSpeed;
}
