using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DFA RID: 11770
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataWhirlpool.LogicDataWhirlpool_C")]
public class LogicDataWhirlpool : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002024 RID: 8228
	// (get) Token: 0x06017C58 RID: 97368 RVA: 0x006A0430 File Offset: 0x0069E630
	// (set) Token: 0x06017C59 RID: 97369 RVA: 0x006A0440 File Offset: 0x0069E640
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MoveTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_MoveTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_MoveTime) = value;
		}
	}

	// Token: 0x17002025 RID: 8229
	// (get) Token: 0x06017C5A RID: 97370 RVA: 0x006A0451 File Offset: 0x0069E651
	// (set) Token: 0x06017C5B RID: 97371 RVA: 0x006A0461 File Offset: 0x0069E661
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float WeightLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_WeightLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_WeightLimit) = value;
		}
	}

	// Token: 0x17002026 RID: 8230
	// (get) Token: 0x06017C5C RID: 97372 RVA: 0x006A0472 File Offset: 0x0069E672
	// (set) Token: 0x06017C5D RID: 97373 RVA: 0x006A0486 File Offset: 0x0069E686
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<AkiClient.Game.Aki.Character.BaseCharacter.EVelocityCurveType> VelocityCurve
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_VelocityCurve);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_VelocityCurve) = value;
		}
	}

	// Token: 0x17002027 RID: 8231
	// (get) Token: 0x06017C5E RID: 97374 RVA: 0x006A049B File Offset: 0x0069E69B
	// (set) Token: 0x06017C5F RID: 97375 RVA: 0x006A04AF File Offset: 0x0069E6AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag TagNeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_TagNeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_TagNeed) = value;
		}
	}

	// Token: 0x17002028 RID: 8232
	// (get) Token: 0x06017C60 RID: 97376 RVA: 0x006A04C4 File Offset: 0x0069E6C4
	// (set) Token: 0x06017C61 RID: 97377 RVA: 0x006A04D8 File Offset: 0x0069E6D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName AttackerSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_AttackerSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_AttackerSocketName) = value;
		}
	}

	// Token: 0x17002029 RID: 8233
	// (get) Token: 0x06017C62 RID: 97378 RVA: 0x006A04ED File Offset: 0x0069E6ED
	// (set) Token: 0x06017C63 RID: 97379 RVA: 0x006A04FD File Offset: 0x0069E6FD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CancelByHit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_CancelByHit) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataWhirlpool.__PropertyOffset_CancelByHit) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017C64 RID: 97380 RVA: 0x006A050E File Offset: 0x0069E70E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataWhirlpool._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataWhirlpool.LogicDataWhirlpool_C");
		}
		return LogicDataWhirlpool._ClassPtr;
	}

	// Token: 0x06017C65 RID: 97381 RVA: 0x006A0534 File Offset: 0x0069E734
	public LogicDataWhirlpool() : this(BuiltinUtils.AllocNativeUObject(LogicDataWhirlpool.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C66 RID: 97382 RVA: 0x006A055C File Offset: 0x0069E75C
	[NullableContext(1)]
	public LogicDataWhirlpool(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataWhirlpool.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C67 RID: 97383 RVA: 0x006A058F File Offset: 0x0069E78F
	protected LogicDataWhirlpool(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B79A RID: 47002
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataWhirlpool.LogicDataWhirlpool_C";

	// Token: 0x0400B79B RID: 47003
	private static IntPtr _ClassPtr;

	// Token: 0x0400B79C RID: 47004
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B79D RID: 47005
	private static int __PropertyOffset_MoveTime;

	// Token: 0x0400B79E RID: 47006
	private static int __PropertyOffset_WeightLimit;

	// Token: 0x0400B79F RID: 47007
	private static int __PropertyOffset_VelocityCurve;

	// Token: 0x0400B7A0 RID: 47008
	private static int __PropertyOffset_TagNeed;

	// Token: 0x0400B7A1 RID: 47009
	private static int __PropertyOffset_AttackerSocketName;

	// Token: 0x0400B7A2 RID: 47010
	private static int __PropertyOffset_CancelByHit;
}
