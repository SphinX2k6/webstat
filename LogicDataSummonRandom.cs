using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF8 RID: 11768
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSummonRandom.LogicDataSummonRandom_C")]
public class LogicDataSummonRandom : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700201D RID: 8221
	// (get) Token: 0x06017C42 RID: 97346 RVA: 0x006A01F0 File Offset: 0x0069E3F0
	// (set) Token: 0x06017C43 RID: 97347 RVA: 0x006A0200 File Offset: 0x0069E400
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SummonIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_SummonIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_SummonIndex) = value;
		}
	}

	// Token: 0x1700201E RID: 8222
	// (get) Token: 0x06017C44 RID: 97348 RVA: 0x006A0211 File Offset: 0x0069E411
	// (set) Token: 0x06017C45 RID: 97349 RVA: 0x006A0221 File Offset: 0x0069E421
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_SkillId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_SkillId) = value;
		}
	}

	// Token: 0x1700201F RID: 8223
	// (get) Token: 0x06017C46 RID: 97350 RVA: 0x006A0232 File Offset: 0x0069E432
	// (set) Token: 0x06017C47 RID: 97351 RVA: 0x006A0242 File Offset: 0x0069E442
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsVisible
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_IsVisible) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_IsVisible) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002020 RID: 8224
	// (get) Token: 0x06017C48 RID: 97352 RVA: 0x006A0253 File Offset: 0x0069E453
	// (set) Token: 0x06017C49 RID: 97353 RVA: 0x006A0263 File Offset: 0x0069E463
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DestroySummonOnDestroy
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_DestroySummonOnDestroy) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSummonRandom.__PropertyOffset_DestroySummonOnDestroy) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017C4A RID: 97354 RVA: 0x006A0274 File Offset: 0x0069E474
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSummonRandom._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSummonRandom.LogicDataSummonRandom_C");
		}
		return LogicDataSummonRandom._ClassPtr;
	}

	// Token: 0x06017C4B RID: 97355 RVA: 0x006A0298 File Offset: 0x0069E498
	public LogicDataSummonRandom() : this(BuiltinUtils.AllocNativeUObject(LogicDataSummonRandom.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C4C RID: 97356 RVA: 0x006A02C0 File Offset: 0x0069E4C0
	[NullableContext(1)]
	public LogicDataSummonRandom(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSummonRandom.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C4D RID: 97357 RVA: 0x006A02F3 File Offset: 0x0069E4F3
	protected LogicDataSummonRandom(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B78C RID: 46988
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSummonRandom.LogicDataSummonRandom_C";

	// Token: 0x0400B78D RID: 46989
	private static IntPtr _ClassPtr;

	// Token: 0x0400B78E RID: 46990
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B78F RID: 46991
	private static int __PropertyOffset_SummonIndex;

	// Token: 0x0400B790 RID: 46992
	private static int __PropertyOffset_SkillId;

	// Token: 0x0400B791 RID: 46993
	private static int __PropertyOffset_IsVisible;

	// Token: 0x0400B792 RID: 46994
	private static int __PropertyOffset_DestroySummonOnDestroy;
}
