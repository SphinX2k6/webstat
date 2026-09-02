using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DF1 RID: 11761
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShakeScreen.LogicDataShakeScreen_C")]
public class LogicDataShakeScreen : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FE9 RID: 8169
	// (get) Token: 0x06017BBE RID: 97214 RVA: 0x0069F53C File Offset: 0x0069D73C
	// (set) Token: 0x06017BBF RID: 97215 RVA: 0x0069F54C File Offset: 0x0069D74C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Count
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Count);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Count) = value;
		}
	}

	// Token: 0x17001FEA RID: 8170
	// (get) Token: 0x06017BC0 RID: 97216 RVA: 0x0069F55D File Offset: 0x0069D75D
	// (set) Token: 0x06017BC1 RID: 97217 RVA: 0x0069F571 File Offset: 0x0069D771
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string Epicenter
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataShakeScreen.__PropertyOffset_Epicenter)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataShakeScreen.__PropertyOffset_Epicenter)), value);
		}
	}

	// Token: 0x17001FEB RID: 8171
	// (get) Token: 0x06017BC2 RID: 97218 RVA: 0x0069F586 File Offset: 0x0069D786
	// (set) Token: 0x06017BC3 RID: 97219 RVA: 0x0069F596 File Offset: 0x0069D796
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Falloff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Falloff);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Falloff) = value;
		}
	}

	// Token: 0x17001FEC RID: 8172
	// (get) Token: 0x06017BC4 RID: 97220 RVA: 0x0069F5A7 File Offset: 0x0069D7A7
	// (set) Token: 0x06017BC5 RID: 97221 RVA: 0x0069F5B7 File Offset: 0x0069D7B7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float InnerRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_InnerRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_InnerRadius) = value;
		}
	}

	// Token: 0x17001FED RID: 8173
	// (get) Token: 0x06017BC6 RID: 97222 RVA: 0x0069F5C8 File Offset: 0x0069D7C8
	// (set) Token: 0x06017BC7 RID: 97223 RVA: 0x0069F5D8 File Offset: 0x0069D7D8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Interval
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Interval);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Interval) = value;
		}
	}

	// Token: 0x17001FEE RID: 8174
	// (get) Token: 0x06017BC8 RID: 97224 RVA: 0x0069F5E9 File Offset: 0x0069D7E9
	// (set) Token: 0x06017BC9 RID: 97225 RVA: 0x0069F5F9 File Offset: 0x0069D7F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OrientShakeTowardsEpicenter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_OrientShakeTowardsEpicenter) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_OrientShakeTowardsEpicenter) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FEF RID: 8175
	// (get) Token: 0x06017BCA RID: 97226 RVA: 0x0069F60A File Offset: 0x0069D80A
	// (set) Token: 0x06017BCB RID: 97227 RVA: 0x0069F61A File Offset: 0x0069D81A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OuterRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_OuterRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_OuterRadius) = value;
		}
	}

	// Token: 0x17001FF0 RID: 8176
	// (get) Token: 0x06017BCC RID: 97228 RVA: 0x0069F62C File Offset: 0x0069D82C
	// (set) Token: 0x06017BCD RID: 97229 RVA: 0x0069F665 File Offset: 0x0069D865
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftClassPtr<UMatineeCameraShake> Shake
	{
		get
		{
			base.FastCheckIsValid();
			TSoftClassPtr<UMatineeCameraShake> result;
			if ((result = this._Shake) == null)
			{
				result = (this._Shake = new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Shake, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)LogicDataShakeScreen.__PropertyOffset_Shake, 1);
		}
	}

	// Token: 0x06017BCE RID: 97230 RVA: 0x0069F68A File Offset: 0x0069D88A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataShakeScreen._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShakeScreen.LogicDataShakeScreen_C");
		}
		return LogicDataShakeScreen._ClassPtr;
	}

	// Token: 0x06017BCF RID: 97231 RVA: 0x0069F6B0 File Offset: 0x0069D8B0
	public LogicDataShakeScreen() : this(BuiltinUtils.AllocNativeUObject(LogicDataShakeScreen.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017BD0 RID: 97232 RVA: 0x0069F6D8 File Offset: 0x0069D8D8
	public LogicDataShakeScreen(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShakeScreen.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017BD1 RID: 97233 RVA: 0x0069F70B File Offset: 0x0069D90B
	protected LogicDataShakeScreen(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B738 RID: 46904
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataShakeScreen.LogicDataShakeScreen_C";

	// Token: 0x0400B739 RID: 46905
	private static IntPtr _ClassPtr;

	// Token: 0x0400B73A RID: 46906
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B73B RID: 46907
	private static int __PropertyOffset_Count;

	// Token: 0x0400B73C RID: 46908
	private static int __PropertyOffset_Epicenter;

	// Token: 0x0400B73D RID: 46909
	private static int __PropertyOffset_Falloff;

	// Token: 0x0400B73E RID: 46910
	private static int __PropertyOffset_InnerRadius;

	// Token: 0x0400B73F RID: 46911
	private static int __PropertyOffset_Interval;

	// Token: 0x0400B740 RID: 46912
	private static int __PropertyOffset_OrientShakeTowardsEpicenter;

	// Token: 0x0400B741 RID: 46913
	private static int __PropertyOffset_OuterRadius;

	// Token: 0x0400B742 RID: 46914
	private static int __PropertyOffset_Shake;

	// Token: 0x0400B743 RID: 46915
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftClassPtr<UMatineeCameraShake> _Shake;
}
