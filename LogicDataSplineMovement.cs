using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine.PathLine_Bullet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF6 RID: 11766
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSplineMovement.LogicDataSplineMovement_C")]
public class LogicDataSplineMovement : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700200B RID: 8203
	// (get) Token: 0x06017C16 RID: 97302 RVA: 0x0069FDFC File Offset: 0x0069DFFC
	// (set) Token: 0x06017C17 RID: 97303 RVA: 0x0069FE0C File Offset: 0x0069E00C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Duration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Duration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Duration) = value;
		}
	}

	// Token: 0x1700200C RID: 8204
	// (get) Token: 0x06017C18 RID: 97304 RVA: 0x0069FE20 File Offset: 0x0069E020
	// (set) Token: 0x06017C19 RID: 97305 RVA: 0x0069FE59 File Offset: 0x0069E059
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectOnReach
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectOnReach) == null)
			{
				result = (this._EffectOnReach = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_EffectOnReach, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_EffectOnReach, 1);
		}
	}

	// Token: 0x1700200D RID: 8205
	// (get) Token: 0x06017C1A RID: 97306 RVA: 0x0069FE7E File Offset: 0x0069E07E
	// (set) Token: 0x06017C1B RID: 97307 RVA: 0x0069FE8E File Offset: 0x0069E08E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsDestroyReach
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsDestroyReach) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsDestroyReach) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700200E RID: 8206
	// (get) Token: 0x06017C1C RID: 97308 RVA: 0x0069FE9F File Offset: 0x0069E09F
	// (set) Token: 0x06017C1D RID: 97309 RVA: 0x0069FEAF File Offset: 0x0069E0AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsForwardTangent
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsForwardTangent) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsForwardTangent) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700200F RID: 8207
	// (get) Token: 0x06017C1E RID: 97310 RVA: 0x0069FEC0 File Offset: 0x0069E0C0
	// (set) Token: 0x06017C1F RID: 97311 RVA: 0x0069FED0 File Offset: 0x0069E0D0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsSummonOnReach
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsSummonOnReach) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_IsSummonOnReach) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002010 RID: 8208
	// (get) Token: 0x06017C20 RID: 97312 RVA: 0x0069FEE1 File Offset: 0x0069E0E1
	// (set) Token: 0x06017C21 RID: 97313 RVA: 0x0069FEF1 File Offset: 0x0069E0F1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Rotate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Rotate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Rotate) = value;
		}
	}

	// Token: 0x17002011 RID: 8209
	// (get) Token: 0x06017C22 RID: 97314 RVA: 0x0069FF02 File Offset: 0x0069E102
	// (set) Token: 0x06017C23 RID: 97315 RVA: 0x0069FF12 File Offset: 0x0069E112
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Length
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Length);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Length) = value;
		}
	}

	// Token: 0x17002012 RID: 8210
	// (get) Token: 0x06017C24 RID: 97316 RVA: 0x0069FF23 File Offset: 0x0069E123
	// (set) Token: 0x06017C25 RID: 97317 RVA: 0x0069FF33 File Offset: 0x0069E133
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Height
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Height);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_Height) = value;
		}
	}

	// Token: 0x17002013 RID: 8211
	// (get) Token: 0x06017C26 RID: 97318 RVA: 0x0069FF44 File Offset: 0x0069E144
	// (set) Token: 0x06017C27 RID: 97319 RVA: 0x0069FF54 File Offset: 0x0069E154
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_MaxSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_MaxSpeed) = value;
		}
	}

	// Token: 0x17002014 RID: 8212
	// (get) Token: 0x06017C28 RID: 97320 RVA: 0x0069FF65 File Offset: 0x0069E165
	// (set) Token: 0x06017C29 RID: 97321 RVA: 0x0069FF75 File Offset: 0x0069E175
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_MinSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_MinSpeed) = value;
		}
	}

	// Token: 0x17002015 RID: 8213
	// (get) Token: 0x06017C2A RID: 97322 RVA: 0x0069FF86 File Offset: 0x0069E186
	// (set) Token: 0x06017C2B RID: 97323 RVA: 0x0069FF96 File Offset: 0x0069E196
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SelfHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfHeight) = value;
		}
	}

	// Token: 0x17002016 RID: 8214
	// (get) Token: 0x06017C2C RID: 97324 RVA: 0x0069FFA7 File Offset: 0x0069E1A7
	// (set) Token: 0x06017C2D RID: 97325 RVA: 0x0069FFB7 File Offset: 0x0069E1B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SelfLength
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfLength);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfLength) = value;
		}
	}

	// Token: 0x17002017 RID: 8215
	// (get) Token: 0x06017C2E RID: 97326 RVA: 0x0069FFC8 File Offset: 0x0069E1C8
	// (set) Token: 0x06017C2F RID: 97327 RVA: 0x0069FFD8 File Offset: 0x0069E1D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SelfRotate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfRotate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SelfRotate) = value;
		}
	}

	// Token: 0x17002018 RID: 8216
	// (get) Token: 0x06017C30 RID: 97328 RVA: 0x0069FFEC File Offset: 0x0069E1EC
	// (set) Token: 0x06017C31 RID: 97329 RVA: 0x006A0025 File Offset: 0x0069E225
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftClassPtr<BP_BasePathLineBullet_C> SplineTrace
	{
		get
		{
			base.FastCheckIsValid();
			TSoftClassPtr<BP_BasePathLineBullet_C> result;
			if ((result = this._SplineTrace) == null)
			{
				result = (this._SplineTrace = new TSoftClassPtr<BP_BasePathLineBullet_C>(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SplineTrace, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_SplineTrace, 1);
		}
	}

	// Token: 0x17002019 RID: 8217
	// (get) Token: 0x06017C32 RID: 97330 RVA: 0x006A004A File Offset: 0x0069E24A
	// (set) Token: 0x06017C33 RID: 97331 RVA: 0x006A005A File Offset: 0x0069E25A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseTargetLocation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_UseTargetLocation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataSplineMovement.__PropertyOffset_UseTargetLocation) = (value ? 1 : 0);
		}
	}

	// Token: 0x06017C34 RID: 97332 RVA: 0x006A006B File Offset: 0x0069E26B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataSplineMovement._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSplineMovement.LogicDataSplineMovement_C");
		}
		return LogicDataSplineMovement._ClassPtr;
	}

	// Token: 0x06017C35 RID: 97333 RVA: 0x006A0090 File Offset: 0x0069E290
	public LogicDataSplineMovement() : this(BuiltinUtils.AllocNativeUObject(LogicDataSplineMovement.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017C36 RID: 97334 RVA: 0x006A00B8 File Offset: 0x0069E2B8
	public LogicDataSplineMovement(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSplineMovement.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017C37 RID: 97335 RVA: 0x006A00EB File Offset: 0x0069E2EB
	protected LogicDataSplineMovement(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B772 RID: 46962
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataSplineMovement.LogicDataSplineMovement_C";

	// Token: 0x0400B773 RID: 46963
	private static IntPtr _ClassPtr;

	// Token: 0x0400B774 RID: 46964
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B775 RID: 46965
	private static int __PropertyOffset_Duration;

	// Token: 0x0400B776 RID: 46966
	private static int __PropertyOffset_EffectOnReach;

	// Token: 0x0400B777 RID: 46967
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectOnReach;

	// Token: 0x0400B778 RID: 46968
	private static int __PropertyOffset_IsDestroyReach;

	// Token: 0x0400B779 RID: 46969
	private static int __PropertyOffset_IsForwardTangent;

	// Token: 0x0400B77A RID: 46970
	private static int __PropertyOffset_IsSummonOnReach;

	// Token: 0x0400B77B RID: 46971
	private static int __PropertyOffset_Rotate;

	// Token: 0x0400B77C RID: 46972
	private static int __PropertyOffset_Length;

	// Token: 0x0400B77D RID: 46973
	private static int __PropertyOffset_Height;

	// Token: 0x0400B77E RID: 46974
	private static int __PropertyOffset_MaxSpeed;

	// Token: 0x0400B77F RID: 46975
	private static int __PropertyOffset_MinSpeed;

	// Token: 0x0400B780 RID: 46976
	private static int __PropertyOffset_SelfHeight;

	// Token: 0x0400B781 RID: 46977
	private static int __PropertyOffset_SelfLength;

	// Token: 0x0400B782 RID: 46978
	private static int __PropertyOffset_SelfRotate;

	// Token: 0x0400B783 RID: 46979
	private static int __PropertyOffset_SplineTrace;

	// Token: 0x0400B784 RID: 46980
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftClassPtr<BP_BasePathLineBullet_C> _SplineTrace;

	// Token: 0x0400B785 RID: 46981
	private static int __PropertyOffset_UseTargetLocation;
}
