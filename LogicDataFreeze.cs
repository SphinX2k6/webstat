using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DED RID: 11757
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataFreeze.LogicDataFreeze_C")]
public class LogicDataFreeze : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FD6 RID: 8150
	// (get) Token: 0x06017B88 RID: 97160 RVA: 0x0069EDB8 File Offset: 0x0069CFB8
	// (set) Token: 0x06017B89 RID: 97161 RVA: 0x0069EDC8 File Offset: 0x0069CFC8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject Target
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_Target));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_Target) = (byte)value;
		}
	}

	// Token: 0x17001FD7 RID: 8151
	// (get) Token: 0x06017B8A RID: 97162 RVA: 0x0069EDDC File Offset: 0x0069CFDC
	// (set) Token: 0x06017B8B RID: 97163 RVA: 0x0069EE15 File Offset: 0x0069D015
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer Tags
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._Tags) == null)
			{
				result = (this._Tags = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_Tags, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_Tags, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FD8 RID: 8152
	// (get) Token: 0x06017B8C RID: 97164 RVA: 0x0069EE3D File Offset: 0x0069D03D
	// (set) Token: 0x06017B8D RID: 97165 RVA: 0x0069EE4D File Offset: 0x0069D04D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FreezeTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_FreezeTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataFreeze.__PropertyOffset_FreezeTime) = value;
		}
	}

	// Token: 0x06017B8E RID: 97166 RVA: 0x0069EE5E File Offset: 0x0069D05E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataFreeze._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataFreeze.LogicDataFreeze_C");
		}
		return LogicDataFreeze._ClassPtr;
	}

	// Token: 0x06017B8F RID: 97167 RVA: 0x0069EE84 File Offset: 0x0069D084
	public LogicDataFreeze() : this(BuiltinUtils.AllocNativeUObject(LogicDataFreeze.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B90 RID: 97168 RVA: 0x0069EEAC File Offset: 0x0069D0AC
	public LogicDataFreeze(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataFreeze.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B91 RID: 97169 RVA: 0x0069EEDF File Offset: 0x0069D0DF
	protected LogicDataFreeze(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B70D RID: 46861
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataFreeze.LogicDataFreeze_C";

	// Token: 0x0400B70E RID: 46862
	private static IntPtr _ClassPtr;

	// Token: 0x0400B70F RID: 46863
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B710 RID: 46864
	private static int __PropertyOffset_Target;

	// Token: 0x0400B711 RID: 46865
	private static int __PropertyOffset_Tags;

	// Token: 0x0400B712 RID: 46866
	[Nullable(2)]
	private FGameplayTagContainer _Tags;

	// Token: 0x0400B713 RID: 46867
	private static int __PropertyOffset_FreezeTime;
}
