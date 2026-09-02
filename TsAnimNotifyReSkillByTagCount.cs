using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE3 RID: 3555
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillByTagCount.TsAnimNotifyReSkillByTagCount_C")]
public class TsAnimNotifyReSkillByTagCount : TsAnimNotifyReSkillEvent, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000553 RID: 1363
	// (get) Token: 0x060051B9 RID: 20921 RVA: 0x000BE297 File Offset: 0x000BC497
	// (set) Token: 0x060051BA RID: 20922 RVA: 0x000BE2AB File Offset: 0x000BC4AB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 层数Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillByTagCount.__PropertyOffset_层数Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillByTagCount.__PropertyOffset_层数Tag) = value;
		}
	}

	// Token: 0x17000554 RID: 1364
	// (get) Token: 0x060051BB RID: 20923 RVA: 0x000BE2C0 File Offset: 0x000BC4C0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> 子弹数组Tag条件
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._子弹数组Tag条件) == null)
			{
				result = (this._子弹数组Tag条件 = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyReSkillByTagCount.__PropertyOffset_子弹数组Tag条件, this));
			}
			return result;
		}
	}

	// Token: 0x17000555 RID: 1365
	// (get) Token: 0x060051BC RID: 20924 RVA: 0x000BE2F9 File Offset: 0x000BC4F9
	// (set) Token: 0x060051BD RID: 20925 RVA: 0x000BE30D File Offset: 0x000BC50D
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string 子弹数据名Tag条件
	{
		[NullableContext(2)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyReSkillByTagCount.__PropertyOffset_子弹数据名Tag条件)));
		}
		[NullableContext(2)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyReSkillByTagCount.__PropertyOffset_子弹数据名Tag条件)), value);
		}
	}

	// Token: 0x060051BE RID: 20926 RVA: 0x000BE324 File Offset: 0x000BC524
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060051BF RID: 20927 RVA: 0x000BE39F File Offset: 0x000BC59F
	protected override string GetNotifyName_Implementation()
	{
		return "根据Tag层数添加子弹";
	}

	// Token: 0x060051C0 RID: 20928 RVA: 0x000BE3A8 File Offset: 0x000BC5A8
	protected override bool CanCreateBullet(AActor owner, UAnimSequenceBase animation, int index)
	{
		FGameplayTag 层数Tag = this.层数Tag;
		if (StringUtils.IsNothing(this.层数Tag.TagName.ToString()))
		{
			return true;
		}
		BaseTagComponent component = (owner as TsBaseCharacter).GetEntityNoBlueprint().GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "动画Character没有Tag组件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AnimSequence", UKismetSystemLibrary.GetPathName(animation));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		int tagId = this.层数Tag.TagId();
		if (!base.使用子弹id数组)
		{
			int tagCount = component.GetTagCount(tagId);
			string 子弹数据名Tag条件 = this.子弹数据名Tag条件;
			return BulletUtil.TagStackCountCondition(tagCount, 子弹数据名Tag条件);
		}
		int num = this.子弹数组Tag条件.Num();
		if (index < num)
		{
			int tagCount2 = component.GetTagCount(tagId);
			string stackCountConditionConf = this.子弹数组Tag条件.Get(index);
			return BulletUtil.TagStackCountCondition(tagCount2, stackCountConditionConf);
		}
		return true;
	}

	// Token: 0x060051C1 RID: 20929 RVA: 0x000BE48C File Offset: 0x000BC68C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyReSkillByTagCount._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillByTagCount.TsAnimNotifyReSkillByTagCount_C");
		}
		return TsAnimNotifyReSkillByTagCount._ClassPtr;
	}

	// Token: 0x060051C2 RID: 20930 RVA: 0x000BE4B0 File Offset: 0x000BC6B0
	public TsAnimNotifyReSkillByTagCount() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyReSkillByTagCount.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060051C3 RID: 20931 RVA: 0x000BE4D8 File Offset: 0x000BC6D8
	public TsAnimNotifyReSkillByTagCount(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyReSkillByTagCount.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060051C4 RID: 20932 RVA: 0x000BE50B File Offset: 0x000BC70B
	protected TsAnimNotifyReSkillByTagCount(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060051C5 RID: 20933 RVA: 0x000BE514 File Offset: 0x000BC714
	[NullableContext(0)]
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017FF RID: 6143
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillByTagCount.TsAnimNotifyReSkillByTagCount_C";

	// Token: 0x04001800 RID: 6144
	private static IntPtr _ClassPtr;

	// Token: 0x04001801 RID: 6145
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001802 RID: 6146
	private static int __PropertyOffset_层数Tag;

	// Token: 0x04001803 RID: 6147
	private static int __PropertyOffset_子弹数组Tag条件;

	// Token: 0x04001804 RID: 6148
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _子弹数组Tag条件;

	// Token: 0x04001805 RID: 6149
	private static int __PropertyOffset_子弹数据名Tag条件;
}
