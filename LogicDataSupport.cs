using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF9 RID: 11769
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSupport.LogicDataSupport_C")]
public class LogicDataSupport : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002021 RID: 8225
	// (get) Token: 0x06017C4E RID: 97358 RVA: 0x006A02FC File Offset: 0x0069E4FC
	// (set) Token: 0x06017C4F RID: 97359 RVA: 0x006A0310 File Offset: 0x0069E510
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x17002022 RID: 8226
	// (get) Token: 0x06017C50 RID: 97360 RVA: 0x006A0325 File Offset: 0x0069E525
	// (set) Token: 0x06017C51 RID: 97361 RVA: 0x006A0335 File Offset: 0x0069E535
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECamp Camp
	{
		get
		{
			return (ECamp)(*(base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Camp));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Camp) = (byte)value;
		}
	}

	// Token: 0x17002023 RID: 8227
	// (get) Token: 0x06017C52 RID: 97362 RVA: 0x006A0348 File Offset: 0x0069E548
	// (set) Token: 0x06017C53 RID: 97363 RVA: 0x006A0381 File Offset: 0x0069E581
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> Effect
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._Effect) == null)
			{
				result = (this._Effect = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Effect, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataSupport.__PropertyOffset_Effect, 1);
		}
	}

	// Token: 0x06017C54 RID: 97364 RVA: 0x006A03A6 File Offset: 0x0069E5A6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSupport._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSupport.LogicDataSupport_C");
		}
		return LogicDataSupport._ClassPtr;
	}

	// Token: 0x06017C55 RID: 97365 RVA: 0x006A03CC File Offset: 0x0069E5CC
	public LogicDataSupport() : this(BuiltinUtils.AllocNativeUObject(LogicDataSupport.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C56 RID: 97366 RVA: 0x006A03F4 File Offset: 0x0069E5F4
	public LogicDataSupport(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSupport.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C57 RID: 97367 RVA: 0x006A0427 File Offset: 0x0069E627
	protected LogicDataSupport(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B793 RID: 46995
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSupport.LogicDataSupport_C";

	// Token: 0x0400B794 RID: 46996
	private static IntPtr _ClassPtr;

	// Token: 0x0400B795 RID: 46997
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B796 RID: 46998
	private static int __PropertyOffset_Tag;

	// Token: 0x0400B797 RID: 46999
	private static int __PropertyOffset_Camp;

	// Token: 0x0400B798 RID: 47000
	private static int __PropertyOffset_Effect;

	// Token: 0x0400B799 RID: 47001
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _Effect;
}
