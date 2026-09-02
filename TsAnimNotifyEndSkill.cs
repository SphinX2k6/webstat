using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCB RID: 3531
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEndSkill.TsAnimNotifyEndSkill_C")]
public class TsAnimNotifyEndSkill : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005078 RID: 20600 RVA: 0x000B9BC4 File Offset: 0x000B7DC4
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

	// Token: 0x06005079 RID: 20601 RVA: 0x000B9C64 File Offset: 0x000B7E64
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
			CharacterBuffComponent component3 = entity.GetComponent<CharacterBuffComponent>();
			if (component == null || !component.Valid || (component2 == null || !component2.Valid) || (component3 == null || !component3.Valid) || component2.IsSkillMontageInvalid(animation.GetName()))
			{
				return false;
			}
			string pathName = UKismetSystemLibrary.GetPathName(animation);
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.极限闪避"]) && (pathName.Contains("Move_F") || pathName.Contains("Move_B")))
			{
				return false;
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity2 = entity;
			string message = "结束技能帧事件";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "技能ID";
			Skill currentSkill = component2.CurrentSkill;
			ptr = new ValueTuple<string, object>(item, (currentSkill != null) ? new int?(currentSkill.SkillId) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "技能名称";
			Skill currentSkill2 = component2.CurrentSkill;
			ptr2 = new ValueTuple<string, object>(item2, (currentSkill2 != null) ? currentSkill2.SkillName : null);
			instance.Info(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			component2.IsMainSkillReadyEnd = true;
			if (component3.HasBuffAuthority())
			{
				component3.RemoveBuff(1101006002L, -1, "从TsAnimNotifyEndSkill蓝图移除Buff", null, null, null);
			}
			component2.SetCurrentPriority(0);
			component2.CallAnimBreakPoint();
		}
		return true;
	}

	// Token: 0x0600507A RID: 20602 RVA: 0x000B9E20 File Offset: 0x000B8020
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

	// Token: 0x0600507B RID: 20603 RVA: 0x000B9E9B File Offset: 0x000B809B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "结束技能";
	}

	// Token: 0x0600507C RID: 20604 RVA: 0x000B9EA2 File Offset: 0x000B80A2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyEndSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEndSkill.TsAnimNotifyEndSkill_C");
		}
		return TsAnimNotifyEndSkill._ClassPtr;
	}

	// Token: 0x0600507D RID: 20605 RVA: 0x000B9EC8 File Offset: 0x000B80C8
	public TsAnimNotifyEndSkill() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEndSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600507E RID: 20606 RVA: 0x000B9EF0 File Offset: 0x000B80F0
	[NullableContext(1)]
	public TsAnimNotifyEndSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEndSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600507F RID: 20607 RVA: 0x000B9F23 File Offset: 0x000B8123
	protected TsAnimNotifyEndSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005080 RID: 20608 RVA: 0x000B9F2C File Offset: 0x000B812C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005081 RID: 20609 RVA: 0x000B9F5F File Offset: 0x000B815F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001789 RID: 6025
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEndSkill.TsAnimNotifyEndSkill_C";

	// Token: 0x0400178A RID: 6026
	private static IntPtr _ClassPtr;

	// Token: 0x0400178B RID: 6027
	private static IntPtr _ClassDefaultObjectPtr;
}
