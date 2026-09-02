using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DEE RID: 11758
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableCreateBullet.LogicDataManipulatableCreateBullet_C")]
public class LogicDataManipulatableCreateBullet : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FD9 RID: 8153
	// (get) Token: 0x06017B92 RID: 97170 RVA: 0x0069EEE8 File Offset: 0x0069D0E8
	// (set) Token: 0x06017B93 RID: 97171 RVA: 0x0069EF21 File Offset: 0x0069D121
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer ExistTagsCondition
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._ExistTagsCondition) == null)
			{
				result = (this._ExistTagsCondition = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_ExistTagsCondition, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_ExistTagsCondition, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FDA RID: 8154
	// (get) Token: 0x06017B94 RID: 97172 RVA: 0x0069EF4C File Offset: 0x0069D14C
	// (set) Token: 0x06017B95 RID: 97173 RVA: 0x0069EF85 File Offset: 0x0069D185
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer UnExistTagsCondition
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._UnExistTagsCondition) == null)
			{
				result = (this._UnExistTagsCondition = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_UnExistTagsCondition, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_UnExistTagsCondition, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FDB RID: 8155
	// (get) Token: 0x06017B96 RID: 97174 RVA: 0x0069EFAD File Offset: 0x0069D1AD
	// (set) Token: 0x06017B97 RID: 97175 RVA: 0x0069EFBD File Offset: 0x0069D1BD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject BulletOwner
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_BulletOwner));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_BulletOwner) = (byte)value;
		}
	}

	// Token: 0x17001FDC RID: 8156
	// (get) Token: 0x06017B98 RID: 97176 RVA: 0x0069EFD0 File Offset: 0x0069D1D0
	// (set) Token: 0x06017B99 RID: 97177 RVA: 0x0069F009 File Offset: 0x0069D209
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> CreateBulletRowName
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._CreateBulletRowName) == null)
			{
				result = (this._CreateBulletRowName = new TArray<string>(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_CreateBulletRowName, this));
			}
			return result;
		}
		set
		{
			this.CreateBulletRowName.CopyAssign(value);
		}
	}

	// Token: 0x17001FDD RID: 8157
	// (get) Token: 0x06017B9A RID: 97178 RVA: 0x0069F017 File Offset: 0x0069D217
	// (set) Token: 0x06017B9B RID: 97179 RVA: 0x0069F027 File Offset: 0x0069D227
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EBulletObject BulletTransform
	{
		get
		{
			return (EBulletObject)(*(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_BulletTransform));
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataManipulatableCreateBullet.__PropertyOffset_BulletTransform) = (byte)value;
		}
	}

	// Token: 0x06017B9C RID: 97180 RVA: 0x0069F038 File Offset: 0x0069D238
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataManipulatableCreateBullet._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableCreateBullet.LogicDataManipulatableCreateBullet_C");
		}
		return LogicDataManipulatableCreateBullet._ClassPtr;
	}

	// Token: 0x06017B9D RID: 97181 RVA: 0x0069F05C File Offset: 0x0069D25C
	public LogicDataManipulatableCreateBullet() : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableCreateBullet.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B9E RID: 97182 RVA: 0x0069F084 File Offset: 0x0069D284
	public LogicDataManipulatableCreateBullet(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B9F RID: 97183 RVA: 0x0069F0B7 File Offset: 0x0069D2B7
	protected LogicDataManipulatableCreateBullet(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B714 RID: 46868
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableCreateBullet.LogicDataManipulatableCreateBullet_C";

	// Token: 0x0400B715 RID: 46869
	private static IntPtr _ClassPtr;

	// Token: 0x0400B716 RID: 46870
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B717 RID: 46871
	private static int __PropertyOffset_ExistTagsCondition;

	// Token: 0x0400B718 RID: 46872
	[Nullable(2)]
	private FGameplayTagContainer _ExistTagsCondition;

	// Token: 0x0400B719 RID: 46873
	private static int __PropertyOffset_UnExistTagsCondition;

	// Token: 0x0400B71A RID: 46874
	[Nullable(2)]
	private FGameplayTagContainer _UnExistTagsCondition;

	// Token: 0x0400B71B RID: 46875
	private static int __PropertyOffset_BulletOwner;

	// Token: 0x0400B71C RID: 46876
	private static int __PropertyOffset_CreateBulletRowName;

	// Token: 0x0400B71D RID: 46877
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _CreateBulletRowName;

	// Token: 0x0400B71E RID: 46878
	private static int __PropertyOffset_BulletTransform;
}
