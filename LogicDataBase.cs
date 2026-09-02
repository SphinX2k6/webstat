using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.TypeScript.Game.NewWorld.Bullet.LogicDataClass;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE5 RID: 11749
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBase.LogicDataBase_C")]
public class LogicDataBase : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FA5 RID: 8101
	// (get) Token: 0x06017B06 RID: 97030 RVA: 0x0069E0D4 File Offset: 0x0069C2D4
	// (set) Token: 0x06017B07 RID: 97031 RVA: 0x0069E0E4 File Offset: 0x0069C2E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletLogicStage ExecuteStage
	{
		get
		{
			return (EBulletLogicStage)(*(base.NativePtr + (IntPtr)LogicDataBase.__PropertyOffset_ExecuteStage));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataBase.__PropertyOffset_ExecuteStage) = (byte)value;
		}
	}

	// Token: 0x06017B08 RID: 97032 RVA: 0x0069E0F5 File Offset: 0x0069C2F5
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBase.LogicDataBase_C");
		}
		return LogicDataBase._ClassPtr;
	}

	// Token: 0x06017B09 RID: 97033 RVA: 0x0069E11C File Offset: 0x0069C31C
	public LogicDataBase() : this(BuiltinUtils.AllocNativeUObject(LogicDataBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B0A RID: 97034 RVA: 0x0069E144 File Offset: 0x0069C344
	[NullableContext(1)]
	public LogicDataBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B0B RID: 97035 RVA: 0x0069E177 File Offset: 0x0069C377
	protected LogicDataBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6BB RID: 46779
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBase.LogicDataBase_C";

	// Token: 0x0400B6BC RID: 46780
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6BD RID: 46781
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6BE RID: 46782
	private static int __PropertyOffset_ExecuteStage;
}
