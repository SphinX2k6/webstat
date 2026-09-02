using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE9 RID: 11753
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyBullet.LogicDataDestroyBullet_C")]
public class LogicDataDestroyBullet : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FBE RID: 8126
	// (get) Token: 0x06017B48 RID: 97096 RVA: 0x0069E7E4 File Offset: 0x0069C9E4
	// (set) Token: 0x06017B49 RID: 97097 RVA: 0x0069E7F4 File Offset: 0x0069C9F4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject BulletOwner
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataDestroyBullet.__PropertyOffset_BulletOwner));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataDestroyBullet.__PropertyOffset_BulletOwner) = (byte)value;
		}
	}

	// Token: 0x17001FBF RID: 8127
	// (get) Token: 0x06017B4A RID: 97098 RVA: 0x0069E805 File Offset: 0x0069CA05
	// (set) Token: 0x06017B4B RID: 97099 RVA: 0x0069E819 File Offset: 0x0069CA19
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string DestroyBulletRowName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataDestroyBullet.__PropertyOffset_DestroyBulletRowName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataDestroyBullet.__PropertyOffset_DestroyBulletRowName)), value);
		}
	}

	// Token: 0x17001FC0 RID: 8128
	// (get) Token: 0x06017B4C RID: 97100 RVA: 0x0069E82E File Offset: 0x0069CA2E
	// (set) Token: 0x06017B4D RID: 97101 RVA: 0x0069E83E File Offset: 0x0069CA3E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SummonChildBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataDestroyBullet.__PropertyOffset_SummonChildBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataDestroyBullet.__PropertyOffset_SummonChildBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017B4E RID: 97102 RVA: 0x0069E84F File Offset: 0x0069CA4F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataDestroyBullet._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyBullet.LogicDataDestroyBullet_C");
		}
		return LogicDataDestroyBullet._ClassPtr;
	}

	// Token: 0x06017B4F RID: 97103 RVA: 0x0069E874 File Offset: 0x0069CA74
	public LogicDataDestroyBullet() : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyBullet.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B50 RID: 97104 RVA: 0x0069E89C File Offset: 0x0069CA9C
	public LogicDataDestroyBullet(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B51 RID: 97105 RVA: 0x0069E8CF File Offset: 0x0069CACF
	protected LogicDataDestroyBullet(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6E7 RID: 46823
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataDestroyBullet.LogicDataDestroyBullet_C";

	// Token: 0x0400B6E8 RID: 46824
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6E9 RID: 46825
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6EA RID: 46826
	private static int __PropertyOffset_BulletOwner;

	// Token: 0x0400B6EB RID: 46827
	private static int __PropertyOffset_DestroyBulletRowName;

	// Token: 0x0400B6EC RID: 46828
	private static int __PropertyOffset_SummonChildBullet;
}
