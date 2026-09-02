using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDF RID: 3551
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveSummonedEntity.TsAnimNotifyRemoveSummonedEntity_C")]
public class TsAnimNotifyRemoveSummonedEntity : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700054C RID: 1356
	// (get) Token: 0x06005182 RID: 20866 RVA: 0x000BD713 File Offset: 0x000BB913
	// (set) Token: 0x06005183 RID: 20867 RVA: 0x000BD723 File Offset: 0x000BB923
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 技能ID
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_技能ID);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_技能ID) = value;
		}
	}

	// Token: 0x1700054D RID: 1357
	// (get) Token: 0x06005184 RID: 20868 RVA: 0x000BD734 File Offset: 0x000BB934
	// (set) Token: 0x06005185 RID: 20869 RVA: 0x000BD744 File Offset: 0x000BB944
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否用当前Montage对应的技能ID
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_是否用当前Montage对应的技能ID) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_是否用当前Montage对应的技能ID) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700054E RID: 1358
	// (get) Token: 0x06005186 RID: 20870 RVA: 0x000BD755 File Offset: 0x000BB955
	// (set) Token: 0x06005187 RID: 20871 RVA: 0x000BD765 File Offset: 0x000BB965
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 召唤者实体ID
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_召唤者实体ID);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_召唤者实体ID) = value;
		}
	}

	// Token: 0x1700054F RID: 1359
	// (get) Token: 0x06005188 RID: 20872 RVA: 0x000BD776 File Offset: 0x000BB976
	// (set) Token: 0x06005189 RID: 20873 RVA: 0x000BD786 File Offset: 0x000BB986
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否把当前播放动画的角色实体作为召唤者
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_是否把当前播放动画的角色实体作为召唤者) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_是否把当前播放动画的角色实体作为召唤者) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000550 RID: 1360
	// (get) Token: 0x0600518A RID: 20874 RVA: 0x000BD797 File Offset: 0x000BB997
	// (set) Token: 0x0600518B RID: 20875 RVA: 0x000BD7A7 File Offset: 0x000BB9A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int 要删除的实体ID
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_要删除的实体ID);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_要删除的实体ID) = value;
		}
	}

	// Token: 0x17000551 RID: 1361
	// (get) Token: 0x0600518C RID: 20876 RVA: 0x000BD7B8 File Offset: 0x000BB9B8
	// (set) Token: 0x0600518D RID: 20877 RVA: 0x000BD7C8 File Offset: 0x000BB9C8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 删除所有召唤者通过SkillId生成的实体
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_删除所有召唤者通过SkillId生成的实体) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRemoveSummonedEntity.__PropertyOffset_删除所有召唤者通过SkillId生成的实体) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600518E RID: 20878 RVA: 0x000BD7DC File Offset: 0x000BB9DC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600518F RID: 20879 RVA: 0x000BD87C File Offset: 0x000BBA7C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		int skillId = this.技能ID;
		int num = this.召唤者实体ID;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null && entity.Valid)
			{
				if (this.是否把当前播放动画的角色实体作为召唤者)
				{
					num = entity.Id;
				}
				if (this.是否用当前Montage对应的技能ID)
				{
					CharacterSkillComponent characterSkillComponent = entity.CheckGetComponent<CharacterSkillComponent>();
					if (characterSkillComponent != null)
					{
						skillId = characterSkillComponent.GetCurrentMontageCorrespondingSkillId();
					}
				}
			}
		}
		if (ModelBase<CreatureModel>.Instance.GetServerEntityId(num) == 0L)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("不存在召唤者实体");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear());
			return false;
		}
		IReadOnlyList<int> readOnlyList;
		if (this.删除所有召唤者通过SkillId生成的实体)
		{
			readOnlyList = ModelBase<BulletModel>.Instance.GetSummonEntityIds(num);
		}
		else
		{
			readOnlyList = new <>z__ReadOnlySingleElementList<int>(this.要删除的实体ID);
		}
		foreach (int num2 in readOnlyList)
		{
			if (ModelBase<CreatureModel>.Instance.GetServerEntityId(num2) == 0L)
			{
				this.LogInternal("不存在要删除的实体");
			}
			else
			{
				ControllerBase<CreatureController>.Instance.RemoveSummonEntityRequest(skillId, num, num2).Forget<bool>();
			}
		}
		return true;
	}

	// Token: 0x06005190 RID: 20880 RVA: 0x000BD9B8 File Offset: 0x000BBBB8
	[NullableContext(1)]
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

	// Token: 0x06005191 RID: 20881 RVA: 0x000BDA33 File Offset: 0x000BBC33
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "删除技能召唤的实体";
	}

	// Token: 0x06005192 RID: 20882 RVA: 0x000BDA3C File Offset: 0x000BBC3C
	[NullableContext(1)]
	private unsafe void LogInternal(string message)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.XDW;
		string message2 = "[TsAnimNotifyRemoveSummonEntity]" + message;
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.技能ID", this.技能ID);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.召唤者实体ID", this.召唤者实体ID);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.要删除的实体ID", this.要删除的实体ID);
		instance.Warn(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06005193 RID: 20883 RVA: 0x000BDAD8 File Offset: 0x000BBCD8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyRemoveSummonedEntity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveSummonedEntity.TsAnimNotifyRemoveSummonedEntity_C");
		}
		return TsAnimNotifyRemoveSummonedEntity._ClassPtr;
	}

	// Token: 0x06005194 RID: 20884 RVA: 0x000BDAFC File Offset: 0x000BBCFC
	public TsAnimNotifyRemoveSummonedEntity() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRemoveSummonedEntity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005195 RID: 20885 RVA: 0x000BDB24 File Offset: 0x000BBD24
	[NullableContext(1)]
	public TsAnimNotifyRemoveSummonedEntity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRemoveSummonedEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005196 RID: 20886 RVA: 0x000BDB57 File Offset: 0x000BBD57
	protected TsAnimNotifyRemoveSummonedEntity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005197 RID: 20887 RVA: 0x000BDB60 File Offset: 0x000BBD60
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005198 RID: 20888 RVA: 0x000BDB93 File Offset: 0x000BBD93
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017EB RID: 6123
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRemoveSummonedEntity.TsAnimNotifyRemoveSummonedEntity_C";

	// Token: 0x040017EC RID: 6124
	private static IntPtr _ClassPtr;

	// Token: 0x040017ED RID: 6125
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017EE RID: 6126
	private static int __PropertyOffset_技能ID;

	// Token: 0x040017EF RID: 6127
	private static int __PropertyOffset_是否用当前Montage对应的技能ID;

	// Token: 0x040017F0 RID: 6128
	private static int __PropertyOffset_召唤者实体ID;

	// Token: 0x040017F1 RID: 6129
	private static int __PropertyOffset_是否把当前播放动画的角色实体作为召唤者;

	// Token: 0x040017F2 RID: 6130
	private static int __PropertyOffset_要删除的实体ID;

	// Token: 0x040017F3 RID: 6131
	private static int __PropertyOffset_删除所有召唤者通过SkillId生成的实体;
}
