using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE6 RID: 11750
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBulletCollision.LogicDataBulletCollision_C")]
public class LogicDataBulletCollision : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FA6 RID: 8102
	// (get) Token: 0x06017B0C RID: 97036 RVA: 0x0069E180 File Offset: 0x0069C380
	// (set) Token: 0x06017B0D RID: 97037 RVA: 0x0069E190 File Offset: 0x0069C390
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DestroyType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_DestroyType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_DestroyType) = value;
		}
	}

	// Token: 0x17001FA7 RID: 8103
	// (get) Token: 0x06017B0E RID: 97038 RVA: 0x0069E1A4 File Offset: 0x0069C3A4
	// (set) Token: 0x06017B0F RID: 97039 RVA: 0x0069E1DD File Offset: 0x0069C3DD
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> BulletRowName
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._BulletRowName) == null)
			{
				result = (this._BulletRowName = new TArray<string>(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_BulletRowName, this));
			}
			return result;
		}
		set
		{
			this.BulletRowName.CopyAssign(value);
		}
	}

	// Token: 0x17001FA8 RID: 8104
	// (get) Token: 0x06017B10 RID: 97040 RVA: 0x0069E1EC File Offset: 0x0069C3EC
	// (set) Token: 0x06017B11 RID: 97041 RVA: 0x0069E225 File Offset: 0x0069C425
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectCollision
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectCollision) == null)
			{
				result = (this._EffectCollision = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_EffectCollision, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_EffectCollision, 1);
		}
	}

	// Token: 0x17001FA9 RID: 8105
	// (get) Token: 0x06017B12 RID: 97042 RVA: 0x0069E24A File Offset: 0x0069C44A
	// (set) Token: 0x06017B13 RID: 97043 RVA: 0x0069E25E File Offset: 0x0069C45E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector PositionOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_PositionOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_PositionOffset) = value;
		}
	}

	// Token: 0x17001FAA RID: 8106
	// (get) Token: 0x06017B14 RID: 97044 RVA: 0x0069E273 File Offset: 0x0069C473
	// (set) Token: 0x06017B15 RID: 97045 RVA: 0x0069E287 File Offset: 0x0069C487
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator RotationOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_RotationOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_RotationOffset) = value;
		}
	}

	// Token: 0x17001FAB RID: 8107
	// (get) Token: 0x06017B16 RID: 97046 RVA: 0x0069E29C File Offset: 0x0069C49C
	// (set) Token: 0x06017B17 RID: 97047 RVA: 0x0069E2D5 File Offset: 0x0069C4D5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftClassPtr<UCameraShakeBase> ScreenShake
	{
		get
		{
			base.FastCheckIsValid();
			TSoftClassPtr<UCameraShakeBase> result;
			if ((result = this._ScreenShake) == null)
			{
				result = (this._ScreenShake = new TSoftClassPtr<UCameraShakeBase>(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_ScreenShake, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_ScreenShake, 1);
		}
	}

	// Token: 0x17001FAC RID: 8108
	// (get) Token: 0x06017B18 RID: 97048 RVA: 0x0069E2FC File Offset: 0x0069C4FC
	// (set) Token: 0x06017B19 RID: 97049 RVA: 0x0069E335 File Offset: 0x0069C535
	[UProperty(EPropertyFlags.CPF_None)]
	public SCounterAttackCamera CameraModified
	{
		get
		{
			base.FastCheckIsValid();
			SCounterAttackCamera result;
			if ((result = this._CameraModified) == null)
			{
				result = (this._CameraModified = new SCounterAttackCamera(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_CameraModified, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCounterAttackCamera.StaticStruct(), base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_CameraModified, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FAD RID: 8109
	// (get) Token: 0x06017B1A RID: 97050 RVA: 0x0069E360 File Offset: 0x0069C560
	// (set) Token: 0x06017B1B RID: 97051 RVA: 0x0069E399 File Offset: 0x0069C599
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> TriggerBulletIds
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._TriggerBulletIds) == null)
			{
				result = (this._TriggerBulletIds = new TArray<string>(base.NativePtr + (IntPtr)LogicDataBulletCollision.__PropertyOffset_TriggerBulletIds, this));
			}
			return result;
		}
		set
		{
			this.TriggerBulletIds.CopyAssign(value);
		}
	}

	// Token: 0x06017B1C RID: 97052 RVA: 0x0069E3A7 File Offset: 0x0069C5A7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataBulletCollision._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBulletCollision.LogicDataBulletCollision_C");
		}
		return LogicDataBulletCollision._ClassPtr;
	}

	// Token: 0x06017B1D RID: 97053 RVA: 0x0069E3CC File Offset: 0x0069C5CC
	public LogicDataBulletCollision() : this(BuiltinUtils.AllocNativeUObject(LogicDataBulletCollision.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B1E RID: 97054 RVA: 0x0069E3F4 File Offset: 0x0069C5F4
	public LogicDataBulletCollision(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBulletCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B1F RID: 97055 RVA: 0x0069E427 File Offset: 0x0069C627
	protected LogicDataBulletCollision(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6BF RID: 46783
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataBulletCollision.LogicDataBulletCollision_C";

	// Token: 0x0400B6C0 RID: 46784
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6C1 RID: 46785
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6C2 RID: 46786
	private static int __PropertyOffset_DestroyType;

	// Token: 0x0400B6C3 RID: 46787
	private static int __PropertyOffset_BulletRowName;

	// Token: 0x0400B6C4 RID: 46788
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _BulletRowName;

	// Token: 0x0400B6C5 RID: 46789
	private static int __PropertyOffset_EffectCollision;

	// Token: 0x0400B6C6 RID: 46790
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectCollision;

	// Token: 0x0400B6C7 RID: 46791
	private static int __PropertyOffset_PositionOffset;

	// Token: 0x0400B6C8 RID: 46792
	private static int __PropertyOffset_RotationOffset;

	// Token: 0x0400B6C9 RID: 46793
	private static int __PropertyOffset_ScreenShake;

	// Token: 0x0400B6CA RID: 46794
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftClassPtr<UCameraShakeBase> _ScreenShake;

	// Token: 0x0400B6CB RID: 46795
	private static int __PropertyOffset_CameraModified;

	// Token: 0x0400B6CC RID: 46796
	[Nullable(2)]
	private SCounterAttackCamera _CameraModified;

	// Token: 0x0400B6CD RID: 46797
	private static int __PropertyOffset_TriggerBulletIds;

	// Token: 0x0400B6CE RID: 46798
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _TriggerBulletIds;
}
