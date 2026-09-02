using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE8 RID: 11752
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCreateBullet.LogicDataCreateBullet_C")]
public class LogicDataCreateBullet : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FB8 RID: 8120
	// (get) Token: 0x06017B38 RID: 97080 RVA: 0x0069E67C File Offset: 0x0069C87C
	// (set) Token: 0x06017B39 RID: 97081 RVA: 0x0069E68C File Offset: 0x0069C88C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject BulletOwner
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_BulletOwner));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_BulletOwner) = (byte)value;
		}
	}

	// Token: 0x17001FB9 RID: 8121
	// (get) Token: 0x06017B3A RID: 97082 RVA: 0x0069E69D File Offset: 0x0069C89D
	// (set) Token: 0x06017B3B RID: 97083 RVA: 0x0069E6B1 File Offset: 0x0069C8B1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CreateBulletRowName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_CreateBulletRowName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_CreateBulletRowName)), value);
		}
	}

	// Token: 0x17001FBA RID: 8122
	// (get) Token: 0x06017B3C RID: 97084 RVA: 0x0069E6C6 File Offset: 0x0069C8C6
	// (set) Token: 0x06017B3D RID: 97085 RVA: 0x0069E6D6 File Offset: 0x0069C8D6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject BulletTransform
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_BulletTransform));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_BulletTransform) = (byte)value;
		}
	}

	// Token: 0x17001FBB RID: 8123
	// (get) Token: 0x06017B3E RID: 97086 RVA: 0x0069E6E7 File Offset: 0x0069C8E7
	// (set) Token: 0x06017B3F RID: 97087 RVA: 0x0069E6F7 File Offset: 0x0069C8F7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject AttachToActor
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_AttachToActor));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCreateBullet.__PropertyOffset_AttachToActor) = (byte)value;
		}
	}

	// Token: 0x17001FBC RID: 8124
	// (get) Token: 0x06017B40 RID: 97088 RVA: 0x0069E708 File Offset: 0x0069C908
	// (set) Token: 0x06017B41 RID: 97089 RVA: 0x0069E71C File Offset: 0x0069C91C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string AttachToBoneName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_AttachToBoneName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_AttachToBoneName)), value);
		}
	}

	// Token: 0x17001FBD RID: 8125
	// (get) Token: 0x06017B42 RID: 97090 RVA: 0x0069E731 File Offset: 0x0069C931
	// (set) Token: 0x06017B43 RID: 97091 RVA: 0x0069E745 File Offset: 0x0069C945
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string FlashBulletRowName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_FlashBulletRowName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCreateBullet.__PropertyOffset_FlashBulletRowName)), value);
		}
	}

	// Token: 0x06017B44 RID: 97092 RVA: 0x0069E75A File Offset: 0x0069C95A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataCreateBullet._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCreateBullet.LogicDataCreateBullet_C");
		}
		return LogicDataCreateBullet._ClassPtr;
	}

	// Token: 0x06017B45 RID: 97093 RVA: 0x0069E780 File Offset: 0x0069C980
	public LogicDataCreateBullet() : this(BuiltinUtils.AllocNativeUObject(LogicDataCreateBullet.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B46 RID: 97094 RVA: 0x0069E7A8 File Offset: 0x0069C9A8
	public LogicDataCreateBullet(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B47 RID: 97095 RVA: 0x0069E7DB File Offset: 0x0069C9DB
	protected LogicDataCreateBullet(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6DE RID: 46814
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCreateBullet.LogicDataCreateBullet_C";

	// Token: 0x0400B6DF RID: 46815
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6E0 RID: 46816
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6E1 RID: 46817
	private static int __PropertyOffset_BulletOwner;

	// Token: 0x0400B6E2 RID: 46818
	private static int __PropertyOffset_CreateBulletRowName;

	// Token: 0x0400B6E3 RID: 46819
	private static int __PropertyOffset_BulletTransform;

	// Token: 0x0400B6E4 RID: 46820
	private static int __PropertyOffset_AttachToActor;

	// Token: 0x0400B6E5 RID: 46821
	private static int __PropertyOffset_AttachToBoneName;

	// Token: 0x0400B6E6 RID: 46822
	private static int __PropertyOffset_FlashBulletRowName;
}
