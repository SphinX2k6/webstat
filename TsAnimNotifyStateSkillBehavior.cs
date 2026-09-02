using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D8A RID: 3466
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkillBehavior.TsAnimNotifyStateSkillBehavior_C")]
public class TsAnimNotifyStateSkillBehavior : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004C7F RID: 19583 RVA: 0x000AACCB File Offset: 0x000A8ECB
	static TsAnimNotifyStateSkillBehavior()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateSkillBehavior.CreateStaticDefaultValue), new Action(TsAnimNotifyStateSkillBehavior.ResetStaticDefaultValue));
	}

	// Token: 0x06004C80 RID: 19584 RVA: 0x000AACEA File Offset: 0x000A8EEA
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateSkillBehavior._skillBehaviorMap = new Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, bool>>();
	}

	// Token: 0x06004C81 RID: 19585 RVA: 0x000AACF6 File Offset: 0x000A8EF6
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateSkillBehavior._skillBehaviorMap = null;
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06004C82 RID: 19586 RVA: 0x000AAD00 File Offset: 0x000A8F00
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehavior> 技能行为
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehavior> result;
			if ((result = this._技能行为) == null)
			{
				result = (this._技能行为 = new TArray<SSkillBehavior>(base.NativePtr + (IntPtr)TsAnimNotifyStateSkillBehavior.__PropertyOffset_技能行为, this));
			}
			return result;
		}
	}

	// Token: 0x06004C83 RID: 19587 RVA: 0x000AAD3C File Offset: 0x000A8F3C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004C84 RID: 19588 RVA: 0x000AADE4 File Offset: 0x000A8FE4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
		CharacterSkillComponent component3 = entity.GetComponent<CharacterSkillComponent>();
		Skill skill = (component3 != null) ? component3.CurrentSkill : null;
		if (component == null || skill == null || component.IsSkillMontageInvalid(animation.GetName()))
		{
			return false;
		}
		if (TsAnimNotifyStateSkillBehavior._skillBehaviorMap == null)
		{
			return false;
		}
		Dictionary<UAnimNotifyState, bool> dictionary;
		if (!TsAnimNotifyStateSkillBehavior._skillBehaviorMap.TryGetValue(meshComp, out dictionary))
		{
			dictionary = new Dictionary<UAnimNotifyState, bool>();
			TsAnimNotifyStateSkillBehavior._skillBehaviorMap[meshComp] = dictionary;
		}
		bool flag;
		if (dictionary.TryGetValue(this, out flag) && flag)
		{
			return false;
		}
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
				dictionary[this] = true;
				long? skillBehaviorAnimNotifyMessageId = (component2 != null) ? component2.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
				skill.SkillBehaviorAnimNotifyMessageId = skillBehaviorAnimNotifyMessageId;
				SkillBehaviorAction.BeginGroup(sskillBehavior.SkillBehaviorActionGroup, param2);
				if (!sskillBehavior.SkillBehaviorContinue)
				{
					break;
				}
			}
		}
		return true;
	}

	// Token: 0x06004C85 RID: 19589 RVA: 0x000AAF50 File Offset: 0x000A9150
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
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

	// Token: 0x06004C86 RID: 19590 RVA: 0x000AAFF0 File Offset: 0x000A91F0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!(meshComp.GetOwner() is TsBaseCharacter))
		{
			return false;
		}
		Dictionary<UAnimNotifyState, bool> dictionary;
		if (TsAnimNotifyStateSkillBehavior._skillBehaviorMap != null && TsAnimNotifyStateSkillBehavior._skillBehaviorMap.TryGetValue(meshComp, out dictionary))
		{
			dictionary.Remove(this);
			if (dictionary.Count == 0)
			{
				TsAnimNotifyStateSkillBehavior._skillBehaviorMap.Remove(meshComp);
			}
		}
		return true;
	}

	// Token: 0x06004C87 RID: 19591 RVA: 0x000AB040 File Offset: 0x000A9240
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004C88 RID: 19592 RVA: 0x000AB0BB File Offset: 0x000A92BB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "技能行为";
	}

	// Token: 0x06004C89 RID: 19593 RVA: 0x000AB0C2 File Offset: 0x000A92C2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSkillBehavior._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkillBehavior.TsAnimNotifyStateSkillBehavior_C");
		}
		return TsAnimNotifyStateSkillBehavior._ClassPtr;
	}

	// Token: 0x06004C8A RID: 19594 RVA: 0x000AB0E8 File Offset: 0x000A92E8
	public TsAnimNotifyStateSkillBehavior() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSkillBehavior.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C8B RID: 19595 RVA: 0x000AB110 File Offset: 0x000A9310
	[NullableContext(1)]
	public TsAnimNotifyStateSkillBehavior(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSkillBehavior.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C8C RID: 19596 RVA: 0x000AB143 File Offset: 0x000A9343
	protected TsAnimNotifyStateSkillBehavior(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C8D RID: 19597 RVA: 0x000AB14C File Offset: 0x000A934C
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004C8E RID: 19598 RVA: 0x000AB188 File Offset: 0x000A9388
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C8F RID: 19599 RVA: 0x000AB1BB File Offset: 0x000A93BB
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015E9 RID: 5609
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private static Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, bool>> _skillBehaviorMap;

	// Token: 0x040015EA RID: 5610
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSkillBehavior.TsAnimNotifyStateSkillBehavior_C";

	// Token: 0x040015EB RID: 5611
	private static IntPtr _ClassPtr;

	// Token: 0x040015EC RID: 5612
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015ED RID: 5613
	private static int __PropertyOffset_技能行为;

	// Token: 0x040015EE RID: 5614
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehavior> _技能行为;
}
