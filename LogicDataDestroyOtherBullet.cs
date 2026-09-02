using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DEA RID: 11754
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyOtherBullet.LogicDataDestroyOtherBullet_C")]
public class LogicDataDestroyOtherBullet : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FC1 RID: 8129
	// (get) Token: 0x06017B52 RID: 97106 RVA: 0x0069E8D8 File Offset: 0x0069CAD8
	// (set) Token: 0x06017B53 RID: 97107 RVA: 0x0069E8E8 File Offset: 0x0069CAE8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECamp Camp
	{
		get
		{
			return (ECamp)(*(base.NativePtr + (IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_Camp));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_Camp) = (byte)value;
		}
	}

	// Token: 0x17001FC2 RID: 8130
	// (get) Token: 0x06017B54 RID: 97108 RVA: 0x0069E8F9 File Offset: 0x0069CAF9
	// (set) Token: 0x06017B55 RID: 97109 RVA: 0x0069E90D File Offset: 0x0069CB0D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BulletId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_BulletId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_BulletId)), value);
		}
	}

	// Token: 0x17001FC3 RID: 8131
	// (get) Token: 0x06017B56 RID: 97110 RVA: 0x0069E922 File Offset: 0x0069CB22
	// (set) Token: 0x06017B57 RID: 97111 RVA: 0x0069E932 File Offset: 0x0069CB32
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SummonChildBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_SummonChildBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataDestroyOtherBullet.__PropertyOffset_SummonChildBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017B58 RID: 97112 RVA: 0x0069E943 File Offset: 0x0069CB43
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataDestroyOtherBullet._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyOtherBullet.LogicDataDestroyOtherBullet_C");
		}
		return LogicDataDestroyOtherBullet._ClassPtr;
	}

	// Token: 0x06017B59 RID: 97113 RVA: 0x0069E968 File Offset: 0x0069CB68
	public LogicDataDestroyOtherBullet() : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyOtherBullet.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B5A RID: 97114 RVA: 0x0069E990 File Offset: 0x0069CB90
	public LogicDataDestroyOtherBullet(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyOtherBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B5B RID: 97115 RVA: 0x0069E9C3 File Offset: 0x0069CBC3
	protected LogicDataDestroyOtherBullet(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6ED RID: 46829
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyOtherBullet.LogicDataDestroyOtherBullet_C";

	// Token: 0x0400B6EE RID: 46830
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6EF RID: 46831
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6F0 RID: 46832
	private static int __PropertyOffset_Camp;

	// Token: 0x0400B6F1 RID: 46833
	private static int __PropertyOffset_BulletId;

	// Token: 0x0400B6F2 RID: 46834
	private static int __PropertyOffset_SummonChildBullet;
}
