using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DE7 RID: 11751
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCameraModify.LogicDataCameraModify_C")]
public class LogicDataCameraModify : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FAE RID: 8110
	// (get) Token: 0x06017B20 RID: 97056 RVA: 0x0069E430 File Offset: 0x0069C630
	// (set) Token: 0x06017B21 RID: 97057 RVA: 0x0069E440 File Offset: 0x0069C640
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletCameraModifyPlayer Player
	{
		get
		{
			return (EBulletCameraModifyPlayer)(*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Player));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Player) = (byte)value;
		}
	}

	// Token: 0x17001FAF RID: 8111
	// (get) Token: 0x06017B22 RID: 97058 RVA: 0x0069E451 File Offset: 0x0069C651
	// (set) Token: 0x06017B23 RID: 97059 RVA: 0x0069E465 File Offset: 0x0069C665
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x17001FB0 RID: 8112
	// (get) Token: 0x06017B24 RID: 97060 RVA: 0x0069E47A File Offset: 0x0069C67A
	// (set) Token: 0x06017B25 RID: 97061 RVA: 0x0069E48A File Offset: 0x0069C68A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Duration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Duration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Duration) = value;
		}
	}

	// Token: 0x17001FB1 RID: 8113
	// (get) Token: 0x06017B26 RID: 97062 RVA: 0x0069E49B File Offset: 0x0069C69B
	// (set) Token: 0x06017B27 RID: 97063 RVA: 0x0069E4AB File Offset: 0x0069C6AB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlendIn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendIn);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendIn) = value;
		}
	}

	// Token: 0x17001FB2 RID: 8114
	// (get) Token: 0x06017B28 RID: 97064 RVA: 0x0069E4BC File Offset: 0x0069C6BC
	// (set) Token: 0x06017B29 RID: 97065 RVA: 0x0069E4CC File Offset: 0x0069C6CC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlendOut
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendOut);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendOut) = value;
		}
	}

	// Token: 0x17001FB3 RID: 8115
	// (get) Token: 0x06017B2A RID: 97066 RVA: 0x0069E4DD File Offset: 0x0069C6DD
	// (set) Token: 0x06017B2B RID: 97067 RVA: 0x0069E4ED File Offset: 0x0069C6ED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float BlendOutInterrupt
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendOutInterrupt);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_BlendOutInterrupt) = value;
		}
	}

	// Token: 0x17001FB4 RID: 8116
	// (get) Token: 0x06017B2C RID: 97068 RVA: 0x0069E500 File Offset: 0x0069C700
	// (set) Token: 0x06017B2D RID: 97069 RVA: 0x0069E539 File Offset: 0x0069C739
	[UProperty(EPropertyFlags.CPF_None)]
	public SCameraModifier_Settings ModifierSettings
	{
		get
		{
			base.FastCheckIsValid();
			SCameraModifier_Settings result;
			if ((result = this._ModifierSettings) == null)
			{
				result = (this._ModifierSettings = new SCameraModifier_Settings(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_ModifierSettings, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_ModifierSettings, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FB5 RID: 8117
	// (get) Token: 0x06017B2E RID: 97070 RVA: 0x0069E561 File Offset: 0x0069C761
	// (set) Token: 0x06017B2F RID: 97071 RVA: 0x0069E571 File Offset: 0x0069C771
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECameraAnsEffectiveClientType ClientType
	{
		get
		{
			return (ECameraAnsEffectiveClientType)(*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_ClientType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_ClientType) = (byte)value;
		}
	}

	// Token: 0x17001FB6 RID: 8118
	// (get) Token: 0x06017B30 RID: 97072 RVA: 0x0069E582 File Offset: 0x0069C782
	// (set) Token: 0x06017B31 RID: 97073 RVA: 0x0069E596 File Offset: 0x0069C796
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CameraAttachSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCameraModify.__PropertyOffset_CameraAttachSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)LogicDataCameraModify.__PropertyOffset_CameraAttachSocket)), value);
		}
	}

	// Token: 0x17001FB7 RID: 8119
	// (get) Token: 0x06017B32 RID: 97074 RVA: 0x0069E5AC File Offset: 0x0069C7AC
	// (set) Token: 0x06017B33 RID: 97075 RVA: 0x0069E5E5 File Offset: 0x0069C7E5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SCameraModifier_Condition> Conditions
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SCameraModifier_Condition> result;
			if ((result = this._Conditions) == null)
			{
				result = (this._Conditions = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)LogicDataCameraModify.__PropertyOffset_Conditions, this));
			}
			return result;
		}
		set
		{
			this.Conditions.CopyAssign(value);
		}
	}

	// Token: 0x06017B34 RID: 97076 RVA: 0x0069E5F3 File Offset: 0x0069C7F3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataCameraModify._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCameraModify.LogicDataCameraModify_C");
		}
		return LogicDataCameraModify._ClassPtr;
	}

	// Token: 0x06017B35 RID: 97077 RVA: 0x0069E618 File Offset: 0x0069C818
	public LogicDataCameraModify() : this(BuiltinUtils.AllocNativeUObject(LogicDataCameraModify.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B36 RID: 97078 RVA: 0x0069E640 File Offset: 0x0069C840
	public LogicDataCameraModify(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCameraModify.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B37 RID: 97079 RVA: 0x0069E673 File Offset: 0x0069C873
	protected LogicDataCameraModify(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6CF RID: 46799
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataCameraModify.LogicDataCameraModify_C";

	// Token: 0x0400B6D0 RID: 46800
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6D1 RID: 46801
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6D2 RID: 46802
	private static int __PropertyOffset_Player;

	// Token: 0x0400B6D3 RID: 46803
	private static int __PropertyOffset_Tag;

	// Token: 0x0400B6D4 RID: 46804
	private static int __PropertyOffset_Duration;

	// Token: 0x0400B6D5 RID: 46805
	private static int __PropertyOffset_BlendIn;

	// Token: 0x0400B6D6 RID: 46806
	private static int __PropertyOffset_BlendOut;

	// Token: 0x0400B6D7 RID: 46807
	private static int __PropertyOffset_BlendOutInterrupt;

	// Token: 0x0400B6D8 RID: 46808
	private static int __PropertyOffset_ModifierSettings;

	// Token: 0x0400B6D9 RID: 46809
	[Nullable(2)]
	private SCameraModifier_Settings _ModifierSettings;

	// Token: 0x0400B6DA RID: 46810
	private static int __PropertyOffset_ClientType;

	// Token: 0x0400B6DB RID: 46811
	private static int __PropertyOffset_CameraAttachSocket;

	// Token: 0x0400B6DC RID: 46812
	private static int __PropertyOffset_Conditions;

	// Token: 0x0400B6DD RID: 46813
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SCameraModifier_Condition> _Conditions;
}
