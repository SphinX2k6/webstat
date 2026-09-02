using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E6D RID: 3693
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Define/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Define/CounterAttackCameraData.CounterAttackCameraData_C")]
public class CounterAttackCameraData : UKuroBpDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700064C RID: 1612
	// (get) Token: 0x060059CC RID: 22988 RVA: 0x0010C8D4 File Offset: 0x0010AAD4
	// (set) Token: 0x060059CD RID: 22989 RVA: 0x0010C90D File Offset: 0x0010AB0D
	[UProperty(EPropertyFlags.CPF_None)]
	public SCounterAttackCamera CameraData
	{
		get
		{
			base.FastCheckIsValid();
			SCounterAttackCamera result;
			if ((result = this._CameraData) == null)
			{
				result = (this._CameraData = new SCounterAttackCamera(base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_CameraData, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCounterAttackCamera.StaticStruct(), base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_CameraData, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700064D RID: 1613
	// (get) Token: 0x060059CE RID: 22990 RVA: 0x0010C938 File Offset: 0x0010AB38
	// (set) Token: 0x060059CF RID: 22991 RVA: 0x0010C971 File Offset: 0x0010AB71
	[UProperty(EPropertyFlags.CPF_None)]
	public STimeScale AttackerTimeScale
	{
		get
		{
			base.FastCheckIsValid();
			STimeScale result;
			if ((result = this._AttackerTimeScale) == null)
			{
				result = (this._AttackerTimeScale = new STimeScale(base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_AttackerTimeScale, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_AttackerTimeScale, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700064E RID: 1614
	// (get) Token: 0x060059D0 RID: 22992 RVA: 0x0010C99C File Offset: 0x0010AB9C
	// (set) Token: 0x060059D1 RID: 22993 RVA: 0x0010C9D5 File Offset: 0x0010ABD5
	[UProperty(EPropertyFlags.CPF_None)]
	public STimeScale VictimTimeScale
	{
		get
		{
			base.FastCheckIsValid();
			STimeScale result;
			if ((result = this._VictimTimeScale) == null)
			{
				result = (this._VictimTimeScale = new STimeScale(base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_VictimTimeScale, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(STimeScale.StaticStruct(), base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_VictimTimeScale, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x1700064F RID: 1615
	// (get) Token: 0x060059D2 RID: 22994 RVA: 0x0010C9FD File Offset: 0x0010ABFD
	// (set) Token: 0x060059D3 RID: 22995 RVA: 0x0010CA11 File Offset: 0x0010AC11
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TSubclassOf<UCameraShakeBase> CameraShake
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			return *(base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_CameraShake);
		}
		[param: Nullable(new byte[]
		{
			0,
			1
		})]
		set
		{
			*(base.NativePtr + (IntPtr)CounterAttackCameraData.__PropertyOffset_CameraShake) = value;
		}
	}

	// Token: 0x060059D4 RID: 22996 RVA: 0x0010CA26 File Offset: 0x0010AC26
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (CounterAttackCameraData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Define/CounterAttackCameraData.CounterAttackCameraData_C");
		}
		return CounterAttackCameraData._ClassPtr;
	}

	// Token: 0x060059D5 RID: 22997 RVA: 0x0010CA4C File Offset: 0x0010AC4C
	public CounterAttackCameraData() : this(BuiltinUtils.AllocNativeUObject(CounterAttackCameraData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060059D6 RID: 22998 RVA: 0x0010CA74 File Offset: 0x0010AC74
	public CounterAttackCameraData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackCameraData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060059D7 RID: 22999 RVA: 0x0010CAA7 File Offset: 0x0010ACA7
	protected CounterAttackCameraData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x04002998 RID: 10648
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Define/CounterAttackCameraData.CounterAttackCameraData_C";

	// Token: 0x04002999 RID: 10649
	private static IntPtr _ClassPtr;

	// Token: 0x0400299A RID: 10650
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400299B RID: 10651
	private static int __PropertyOffset_CameraData;

	// Token: 0x0400299C RID: 10652
	[Nullable(2)]
	private SCounterAttackCamera _CameraData;

	// Token: 0x0400299D RID: 10653
	private static int __PropertyOffset_AttackerTimeScale;

	// Token: 0x0400299E RID: 10654
	[Nullable(2)]
	private STimeScale _AttackerTimeScale;

	// Token: 0x0400299F RID: 10655
	private static int __PropertyOffset_VictimTimeScale;

	// Token: 0x040029A0 RID: 10656
	[Nullable(2)]
	private STimeScale _VictimTimeScale;

	// Token: 0x040029A1 RID: 10657
	private static int __PropertyOffset_CameraShake;
}
