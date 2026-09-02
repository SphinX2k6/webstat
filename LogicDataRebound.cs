using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF0 RID: 11760
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataRebound.LogicDataRebound_C")]
public class LogicDataRebound : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FE2 RID: 8162
	// (get) Token: 0x06017BAC RID: 97196 RVA: 0x0069F2D8 File Offset: 0x0069D4D8
	// (set) Token: 0x06017BAD RID: 97197 RVA: 0x0069F311 File Offset: 0x0069D511
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> BulletRowName
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._BulletRowName) == null)
			{
				result = (this._BulletRowName = new TArray<string>(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_BulletRowName, this));
			}
			return result;
		}
		set
		{
			this.BulletRowName.CopyAssign(value);
		}
	}

	// Token: 0x17001FE3 RID: 8163
	// (get) Token: 0x06017BAE RID: 97198 RVA: 0x0069F320 File Offset: 0x0069D520
	// (set) Token: 0x06017BAF RID: 97199 RVA: 0x0069F359 File Offset: 0x0069D559
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectRebound
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectRebound) == null)
			{
				result = (this._EffectRebound = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_EffectRebound, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_EffectRebound, 1);
		}
	}

	// Token: 0x17001FE4 RID: 8164
	// (get) Token: 0x06017BB0 RID: 97200 RVA: 0x0069F37E File Offset: 0x0069D57E
	// (set) Token: 0x06017BB1 RID: 97201 RVA: 0x0069F392 File Offset: 0x0069D592
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector PositionOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_PositionOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_PositionOffset) = value;
		}
	}

	// Token: 0x17001FE5 RID: 8165
	// (get) Token: 0x06017BB2 RID: 97202 RVA: 0x0069F3A7 File Offset: 0x0069D5A7
	// (set) Token: 0x06017BB3 RID: 97203 RVA: 0x0069F3BB File Offset: 0x0069D5BB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator RotationOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_RotationOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_RotationOffset) = value;
		}
	}

	// Token: 0x17001FE6 RID: 8166
	// (get) Token: 0x06017BB4 RID: 97204 RVA: 0x0069F3D0 File Offset: 0x0069D5D0
	// (set) Token: 0x06017BB5 RID: 97205 RVA: 0x0069F409 File Offset: 0x0069D609
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftClassPtr<UCameraShakeBase> ScreenShake
	{
		get
		{
			base.FastCheckIsValid();
			TSoftClassPtr<UCameraShakeBase> result;
			if ((result = this._ScreenShake) == null)
			{
				result = (this._ScreenShake = new TSoftClassPtr<UCameraShakeBase>(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_ScreenShake, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_ScreenShake, 1);
		}
	}

	// Token: 0x17001FE7 RID: 8167
	// (get) Token: 0x06017BB6 RID: 97206 RVA: 0x0069F430 File Offset: 0x0069D630
	// (set) Token: 0x06017BB7 RID: 97207 RVA: 0x0069F469 File Offset: 0x0069D669
	[UProperty(EPropertyFlags.CPF_None)]
	public SCounterAttackCamera CameraModified
	{
		get
		{
			base.FastCheckIsValid();
			SCounterAttackCamera result;
			if ((result = this._CameraModified) == null)
			{
				result = (this._CameraModified = new SCounterAttackCamera(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_CameraModified, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCounterAttackCamera.StaticStruct(), base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_CameraModified, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FE8 RID: 8168
	// (get) Token: 0x06017BB8 RID: 97208 RVA: 0x0069F491 File Offset: 0x0069D691
	// (set) Token: 0x06017BB9 RID: 97209 RVA: 0x0069F4A1 File Offset: 0x0069D6A1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ReboundBitMask
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_ReboundBitMask);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataRebound.__PropertyOffset_ReboundBitMask) = value;
		}
	}

	// Token: 0x06017BBA RID: 97210 RVA: 0x0069F4B2 File Offset: 0x0069D6B2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataRebound._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataRebound.LogicDataRebound_C");
		}
		return LogicDataRebound._ClassPtr;
	}

	// Token: 0x06017BBB RID: 97211 RVA: 0x0069F4D8 File Offset: 0x0069D6D8
	public LogicDataRebound() : this(BuiltinUtils.AllocNativeUObject(LogicDataRebound.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017BBC RID: 97212 RVA: 0x0069F500 File Offset: 0x0069D700
	public LogicDataRebound(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataRebound.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017BBD RID: 97213 RVA: 0x0069F533 File Offset: 0x0069D733
	protected LogicDataRebound(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B72A RID: 46890
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataRebound.LogicDataRebound_C";

	// Token: 0x0400B72B RID: 46891
	private static IntPtr _ClassPtr;

	// Token: 0x0400B72C RID: 46892
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B72D RID: 46893
	private static int __PropertyOffset_BulletRowName;

	// Token: 0x0400B72E RID: 46894
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _BulletRowName;

	// Token: 0x0400B72F RID: 46895
	private static int __PropertyOffset_EffectRebound;

	// Token: 0x0400B730 RID: 46896
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectRebound;

	// Token: 0x0400B731 RID: 46897
	private static int __PropertyOffset_PositionOffset;

	// Token: 0x0400B732 RID: 46898
	private static int __PropertyOffset_RotationOffset;

	// Token: 0x0400B733 RID: 46899
	private static int __PropertyOffset_ScreenShake;

	// Token: 0x0400B734 RID: 46900
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftClassPtr<UCameraShakeBase> _ScreenShake;

	// Token: 0x0400B735 RID: 46901
	private static int __PropertyOffset_CameraModified;

	// Token: 0x0400B736 RID: 46902
	[Nullable(2)]
	private SCounterAttackCamera _CameraModified;

	// Token: 0x0400B737 RID: 46903
	private static int __PropertyOffset_ReboundBitMask;
}
