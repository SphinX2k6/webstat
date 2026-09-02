using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE3 RID: 11747
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAddBuff.LogicDataAddBuff_C")]
public class LogicDataAddBuff : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FA2 RID: 8098
	// (get) Token: 0x06017AF8 RID: 97016 RVA: 0x0069DF4C File Offset: 0x0069C14C
	// (set) Token: 0x06017AF9 RID: 97017 RVA: 0x0069DF5C File Offset: 0x0069C15C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataAddBuff.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataAddBuff.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x06017AFA RID: 97018 RVA: 0x0069DF6D File Offset: 0x0069C16D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataAddBuff._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAddBuff.LogicDataAddBuff_C");
		}
		return LogicDataAddBuff._ClassPtr;
	}

	// Token: 0x06017AFB RID: 97019 RVA: 0x0069DF94 File Offset: 0x0069C194
	public LogicDataAddBuff() : this(BuiltinUtils.AllocNativeUObject(LogicDataAddBuff.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017AFC RID: 97020 RVA: 0x0069DFBC File Offset: 0x0069C1BC
	[NullableContext(1)]
	public LogicDataAddBuff(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataAddBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017AFD RID: 97021 RVA: 0x0069DFEF File Offset: 0x0069C1EF
	protected LogicDataAddBuff(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6B2 RID: 46770
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataAddBuff.LogicDataAddBuff_C";

	// Token: 0x0400B6B3 RID: 46771
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6B4 RID: 46772
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6B5 RID: 46773
	private static int __PropertyOffset_BuffId;
}
