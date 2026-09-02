using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DEE RID: 3566
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySkillBehavior.TsAnimNotifySkillBehavior_C")]
public class TsAnimNotifySkillBehavior : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700056F RID: 1391
	// (get) Token: 0x0600525C RID: 21084 RVA: 0x000C0768 File Offset: 0x000BE968
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehavior> 技能行为
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehavior> result;
			if ((result = this._技能行为) == null)
			{
				result = (this._技能行为 = new TArray<SSkillBehavior>(base.NativePtr + (IntPtr)TsAnimNotifySkillBehavior.__PropertyOffset_技能行为, this));
			}
			return result;
		}
	}

	// Token: 0x0600525D RID: 21085 RVA: 0x000C07A4 File Offset: 0x000BE9A4
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

	// Token: 0x0600525E RID: 21086 RVA: 0x000C0844 File Offset: 0x000BEA44
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
		CharacterSkillComponent component3 = entity.GetComponent<CharacterSkillComponent>();
		Skill skill = (component3 != null) ? component3.CurrentSkill : null;
		if (component == null || skill == null || component.IsSkillMontageInvalid(animation.GetName()))
		{
			return false;
		}
		long? skillBehaviorAnimNotifyMessageId = (component2 != null) ? component2.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		skill.SkillBehaviorAnimNotifyMessageId = skillBehaviorAnimNotifyMessageId;
		BeginSkillBehaviorConditionParam param = new BeginSkillBehaviorConditionParam
		{
			Entity = entity,
			SkillComponent = component,
			Skill = skill
		};
		BeginSkillBehaviorActionParam param2 = new BeginSkillBehaviorActionParam
		{
			Entity = entity,
			SkillComponent = component,
			Skill = skill
		};
		for (int i = 0; i < this.技能行为.Num(); i++)
		{
			SSkillBehavior sskillBehavior = this.技能行为.Get(i);
			if (SkillBehaviorCondition.SatisfyGroup(sskillBehavior.SkillBehaviorConditionGroup, sskillBehavior.SkillBehaviorConditionFormula, param))
			{
				SkillBehaviorAction.BeginGroup(sskillBehavior.SkillBehaviorActionGroup, param2);
				if (!sskillBehavior.SkillBehaviorContinue)
				{
					break;
				}
			}
		}
		return true;
	}

	// Token: 0x0600525F RID: 21087 RVA: 0x000C096C File Offset: 0x000BEB6C
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

	// Token: 0x06005260 RID: 21088 RVA: 0x000C09E7 File Offset: 0x000BEBE7
	protected override string GetNotifyName_Implementation()
	{
		return "技能行为";
	}

	// Token: 0x06005261 RID: 21089 RVA: 0x000C09EE File Offset: 0x000BEBEE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySkillBehavior._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySkillBehavior.TsAnimNotifySkillBehavior_C");
		}
		return TsAnimNotifySkillBehavior._ClassPtr;
	}

	// Token: 0x06005262 RID: 21090 RVA: 0x000C0A14 File Offset: 0x000BEC14
	public TsAnimNotifySkillBehavior() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySkillBehavior.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005263 RID: 21091 RVA: 0x000C0A3C File Offset: 0x000BEC3C
	public TsAnimNotifySkillBehavior(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySkillBehavior.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005264 RID: 21092 RVA: 0x000C0A6F File Offset: 0x000BEC6F
	protected TsAnimNotifySkillBehavior(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005265 RID: 21093 RVA: 0x000C0A78 File Offset: 0x000BEC78
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005266 RID: 21094 RVA: 0x000C0AAB File Offset: 0x000BECAB
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001841 RID: 6209
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySkillBehavior.TsAnimNotifySkillBehavior_C";

	// Token: 0x04001842 RID: 6210
	private static IntPtr _ClassPtr;

	// Token: 0x04001843 RID: 6211
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001844 RID: 6212
	private static int __PropertyOffset_技能行为;

	// Token: 0x04001845 RID: 6213
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehavior> _技能行为;
}
