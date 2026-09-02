using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DEF RID: 11759
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableTagsChange.LogicDataManipulatableTagsChange_C")]
public class LogicDataManipulatableTagsChange : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FDE RID: 8158
	// (get) Token: 0x06017BA0 RID: 97184 RVA: 0x0069F0C0 File Offset: 0x0069D2C0
	// (set) Token: 0x06017BA1 RID: 97185 RVA: 0x0069F0F9 File Offset: 0x0069D2F9
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer ExistTagsCondition
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._ExistTagsCondition) == null)
			{
				result = (this._ExistTagsCondition = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_ExistTagsCondition, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_ExistTagsCondition, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FDF RID: 8159
	// (get) Token: 0x06017BA2 RID: 97186 RVA: 0x0069F124 File Offset: 0x0069D324
	// (set) Token: 0x06017BA3 RID: 97187 RVA: 0x0069F15D File Offset: 0x0069D35D
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer UnExistTagsCondition
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._UnExistTagsCondition) == null)
			{
				result = (this._UnExistTagsCondition = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_UnExistTagsCondition, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_UnExistTagsCondition, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FE0 RID: 8160
	// (get) Token: 0x06017BA4 RID: 97188 RVA: 0x0069F188 File Offset: 0x0069D388
	// (set) Token: 0x06017BA5 RID: 97189 RVA: 0x0069F1C1 File Offset: 0x0069D3C1
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer AddTags
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._AddTags) == null)
			{
				result = (this._AddTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_AddTags, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_AddTags, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FE1 RID: 8161
	// (get) Token: 0x06017BA6 RID: 97190 RVA: 0x0069F1EC File Offset: 0x0069D3EC
	// (set) Token: 0x06017BA7 RID: 97191 RVA: 0x0069F225 File Offset: 0x0069D425
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer RemoveTags
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._RemoveTags) == null)
			{
				result = (this._RemoveTags = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_RemoveTags, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataManipulatableTagsChange.__PropertyOffset_RemoveTags, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06017BA8 RID: 97192 RVA: 0x0069F24D File Offset: 0x0069D44D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataManipulatableTagsChange._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableTagsChange.LogicDataManipulatableTagsChange_C");
		}
		return LogicDataManipulatableTagsChange._ClassPtr;
	}

	// Token: 0x06017BA9 RID: 97193 RVA: 0x0069F274 File Offset: 0x0069D474
	public LogicDataManipulatableTagsChange() : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableTagsChange.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017BAA RID: 97194 RVA: 0x0069F29C File Offset: 0x0069D49C
	public LogicDataManipulatableTagsChange(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableTagsChange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017BAB RID: 97195 RVA: 0x0069F2CF File Offset: 0x0069D4CF
	protected LogicDataManipulatableTagsChange(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B71F RID: 46879
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataManipulatableTagsChange.LogicDataManipulatableTagsChange_C";

	// Token: 0x0400B720 RID: 46880
	private static IntPtr _ClassPtr;

	// Token: 0x0400B721 RID: 46881
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B722 RID: 46882
	private static int __PropertyOffset_ExistTagsCondition;

	// Token: 0x0400B723 RID: 46883
	[Nullable(2)]
	private FGameplayTagContainer _ExistTagsCondition;

	// Token: 0x0400B724 RID: 46884
	private static int __PropertyOffset_UnExistTagsCondition;

	// Token: 0x0400B725 RID: 46885
	[Nullable(2)]
	private FGameplayTagContainer _UnExistTagsCondition;

	// Token: 0x0400B726 RID: 46886
	private static int __PropertyOffset_AddTags;

	// Token: 0x0400B727 RID: 46887
	[Nullable(2)]
	private FGameplayTagContainer _AddTags;

	// Token: 0x0400B728 RID: 46888
	private static int __PropertyOffset_RemoveTags;

	// Token: 0x0400B729 RID: 46889
	[Nullable(2)]
	private FGameplayTagContainer _RemoveTags;
}
