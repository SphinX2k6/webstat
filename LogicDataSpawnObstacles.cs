using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.TypeScript.Game.NewWorld.Bullet.LogicDataClass;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF4 RID: 11764
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpawnObstacles.LogicDataSpawnObstacles_C")]
public class LogicDataSpawnObstacles : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002000 RID: 8192
	// (get) Token: 0x06017BF8 RID: 97272 RVA: 0x0069FB68 File Offset: 0x0069DD68
	// (set) Token: 0x06017BF9 RID: 97273 RVA: 0x0069FB78 File Offset: 0x0069DD78
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletLogicObstacles Model
	{
		get
		{
			return (EBulletLogicObstacles)(*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_Model));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_Model) = (byte)value;
		}
	}

	// Token: 0x17002001 RID: 8193
	// (get) Token: 0x06017BFA RID: 97274 RVA: 0x0069FB89 File Offset: 0x0069DD89
	// (set) Token: 0x06017BFB RID: 97275 RVA: 0x0069FB9D File Offset: 0x0069DD9D
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UStaticMesh Mesh
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataSpawnObstacles.__PropertyOffset_Mesh);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataSpawnObstacles.__PropertyOffset_Mesh, value);
		}
	}

	// Token: 0x17002002 RID: 8194
	// (get) Token: 0x06017BFC RID: 97276 RVA: 0x0069FBB2 File Offset: 0x0069DDB2
	// (set) Token: 0x06017BFD RID: 97277 RVA: 0x0069FBC6 File Offset: 0x0069DDC6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector Size
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_Size);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_Size) = value;
		}
	}

	// Token: 0x17002003 RID: 8195
	// (get) Token: 0x06017BFE RID: 97278 RVA: 0x0069FBDB File Offset: 0x0069DDDB
	// (set) Token: 0x06017BFF RID: 97279 RVA: 0x0069FBEF File Offset: 0x0069DDEF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName ProfileName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_ProfileName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_ProfileName) = value;
		}
	}

	// Token: 0x17002004 RID: 8196
	// (get) Token: 0x06017C00 RID: 97280 RVA: 0x0069FC04 File Offset: 0x0069DE04
	// (set) Token: 0x06017C01 RID: 97281 RVA: 0x0069FC14 File Offset: 0x0069DE14
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ShowModel
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_ShowModel) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_ShowModel) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002005 RID: 8197
	// (get) Token: 0x06017C02 RID: 97282 RVA: 0x0069FC25 File Offset: 0x0069DE25
	// (set) Token: 0x06017C03 RID: 97283 RVA: 0x0069FC35 File Offset: 0x0069DE35
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedAttach
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_NeedAttach) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_NeedAttach) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002006 RID: 8198
	// (get) Token: 0x06017C04 RID: 97284 RVA: 0x0069FC46 File Offset: 0x0069DE46
	// (set) Token: 0x06017C05 RID: 97285 RVA: 0x0069FC56 File Offset: 0x0069DE56
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CanStandOn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_CanStandOn) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_CanStandOn) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002007 RID: 8199
	// (get) Token: 0x06017C06 RID: 97286 RVA: 0x0069FC67 File Offset: 0x0069DE67
	// (set) Token: 0x06017C07 RID: 97287 RVA: 0x0069FC77 File Offset: 0x0069DE77
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsAirWall
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_IsAirWall) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSpawnObstacles.__PropertyOffset_IsAirWall) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017C08 RID: 97288 RVA: 0x0069FC88 File Offset: 0x0069DE88
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSpawnObstacles._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpawnObstacles.LogicDataSpawnObstacles_C");
		}
		return LogicDataSpawnObstacles._ClassPtr;
	}

	// Token: 0x06017C09 RID: 97289 RVA: 0x0069FCAC File Offset: 0x0069DEAC
	public LogicDataSpawnObstacles() : this(BuiltinUtils.AllocNativeUObject(LogicDataSpawnObstacles.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C0A RID: 97290 RVA: 0x0069FCD4 File Offset: 0x0069DED4
	[NullableContext(1)]
	public LogicDataSpawnObstacles(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpawnObstacles.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C0B RID: 97291 RVA: 0x0069FD07 File Offset: 0x0069DF07
	protected LogicDataSpawnObstacles(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B761 RID: 46945
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSpawnObstacles.LogicDataSpawnObstacles_C";

	// Token: 0x0400B762 RID: 46946
	private static IntPtr _ClassPtr;

	// Token: 0x0400B763 RID: 46947
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B764 RID: 46948
	private static int __PropertyOffset_Model;

	// Token: 0x0400B765 RID: 46949
	private static int __PropertyOffset_Mesh;

	// Token: 0x0400B766 RID: 46950
	private static int __PropertyOffset_Size;

	// Token: 0x0400B767 RID: 46951
	private static int __PropertyOffset_ProfileName;

	// Token: 0x0400B768 RID: 46952
	private static int __PropertyOffset_ShowModel;

	// Token: 0x0400B769 RID: 46953
	private static int __PropertyOffset_NeedAttach;

	// Token: 0x0400B76A RID: 46954
	private static int __PropertyOffset_CanStandOn;

	// Token: 0x0400B76B RID: 46955
	private static int __PropertyOffset_IsAirWall;
}
