using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF7 RID: 11767
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSuiGuang.LogicDataSuiGuang_C")]
public class LogicDataSuiGuang : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700201A RID: 8218
	// (get) Token: 0x06017C38 RID: 97336 RVA: 0x006A00F4 File Offset: 0x0069E2F4
	// (set) Token: 0x06017C39 RID: 97337 RVA: 0x006A0104 File Offset: 0x0069E304
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IncludeBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSuiGuang.__PropertyOffset_IncludeBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSuiGuang.__PropertyOffset_IncludeBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700201B RID: 8219
	// (get) Token: 0x06017C3A RID: 97338 RVA: 0x006A0115 File Offset: 0x0069E315
	// (set) Token: 0x06017C3B RID: 97339 RVA: 0x006A0129 File Offset: 0x0069E329
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag NeedTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSuiGuang.__PropertyOffset_NeedTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSuiGuang.__PropertyOffset_NeedTag) = value;
		}
	}

	// Token: 0x1700201C RID: 8220
	// (get) Token: 0x06017C3C RID: 97340 RVA: 0x006A013E File Offset: 0x0069E33E
	// (set) Token: 0x06017C3D RID: 97341 RVA: 0x006A0152 File Offset: 0x0069E352
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string NewBulletId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataSuiGuang.__PropertyOffset_NewBulletId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataSuiGuang.__PropertyOffset_NewBulletId)), value);
		}
	}

	// Token: 0x06017C3E RID: 97342 RVA: 0x006A0167 File Offset: 0x0069E367
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSuiGuang._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSuiGuang.LogicDataSuiGuang_C");
		}
		return LogicDataSuiGuang._ClassPtr;
	}

	// Token: 0x06017C3F RID: 97343 RVA: 0x006A018C File Offset: 0x0069E38C
	public LogicDataSuiGuang() : this(BuiltinUtils.AllocNativeUObject(LogicDataSuiGuang.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C40 RID: 97344 RVA: 0x006A01B4 File Offset: 0x0069E3B4
	public LogicDataSuiGuang(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSuiGuang.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C41 RID: 97345 RVA: 0x006A01E7 File Offset: 0x0069E3E7
	protected LogicDataSuiGuang(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B786 RID: 46982
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSuiGuang.LogicDataSuiGuang_C";

	// Token: 0x0400B787 RID: 46983
	private static IntPtr _ClassPtr;

	// Token: 0x0400B788 RID: 46984
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B789 RID: 46985
	private static int __PropertyOffset_IncludeBullet;

	// Token: 0x0400B78A RID: 46986
	private static int __PropertyOffset_NeedTag;

	// Token: 0x0400B78B RID: 46987
	private static int __PropertyOffset_NewBulletId;
}
