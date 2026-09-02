using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D29 RID: 3369
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBase.TsAnimNotifyStateBase_C")]
public abstract class TsAnimNotifyStateBase : UKuroAnimNotifyState, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06004547 RID: 17735 RVA: 0x000899F4 File Offset: 0x00087BF4
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SSkillBehaviorCondition> ANS执行的前提条件
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TArray<SSkillBehaviorCondition> result;
			if ((result = this._ANS执行的前提条件) == null)
			{
				result = (this._ANS执行的前提条件 = new TArray<SSkillBehaviorCondition>(base.NativePtr + (IntPtr)TsAnimNotifyStateBase.__PropertyOffset_ANS执行的前提条件, this));
			}
			return result;
		}
	}

	// Token: 0x06004548 RID: 17736 RVA: 0x00089A2D File Offset: 0x00087C2D
	protected bool SetConditionFail(USkeletalMeshComponent meshComp)
	{
		if (this.ConditionFail == null)
		{
			this.ConditionFail = new HashSet<USkeletalMeshComponent>();
		}
		if (meshComp != null)
		{
			this.ConditionFail.Add(meshComp);
		}
		return false;
	}

	// Token: 0x06004549 RID: 17737 RVA: 0x00089A53 File Offset: 0x00087C53
	protected bool GetConditionResult(USkeletalMeshComponent meshComp)
	{
		if (meshComp == null)
		{
			return false;
		}
		HashSet<USkeletalMeshComponent> conditionFail = this.ConditionFail;
		return conditionFail == null || !conditionFail.Contains(meshComp);
	}

	// Token: 0x0600454A RID: 17738 RVA: 0x00089A72 File Offset: 0x00087C72
	protected void ClearConditionResult(USkeletalMeshComponent meshComp)
	{
		if (meshComp != null)
		{
			HashSet<USkeletalMeshComponent> conditionFail = this.ConditionFail;
			if (conditionFail == null)
			{
				return;
			}
			conditionFail.Remove(meshComp);
		}
	}

	// Token: 0x0600454B RID: 17739 RVA: 0x00089A8C File Offset: 0x00087C8C
	protected IBeginSkillBehaviorConditionParam CreateBeginConditionParam(USkeletalMeshComponent meshComp)
	{
		TsBaseCharacter tsBaseCharacter = ((meshComp != null) ? meshComp.GetOwner() : null) as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return null;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		Skill skill = (component != null) ? component.CurrentSkill : null;
		return new BeginSkillBehaviorConditionParam
		{
			Entity = entity,
			SkillComponent = component,
			Skill = skill
		};
	}

	// Token: 0x0600454C RID: 17740 RVA: 0x00089AF8 File Offset: 0x00087CF8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyBeginConditionCheck(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.ANS执行的前提条件 == null || this.ANS执行的前提条件.Num() == 0)
		{
			return true;
		}
		IBeginSkillBehaviorConditionParam beginSkillBehaviorConditionParam = this.CreateBeginConditionParam(meshComp);
		if (beginSkillBehaviorConditionParam == null)
		{
			return this.SetConditionFail(meshComp);
		}
		return SkillBehaviorCondition.SatisfyGroup(this.ANS执行的前提条件, string.Empty, beginSkillBehaviorConditionParam) || this.SetConditionFail(meshComp);
	}

	// Token: 0x0600454D RID: 17741 RVA: 0x00089B4B File Offset: 0x00087D4B
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyTickConditionCheck(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		return this.GetConditionResult(meshComp);
	}

	// Token: 0x0600454E RID: 17742 RVA: 0x00089B54 File Offset: 0x00087D54
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyEndConditionCheck(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		bool conditionResult = this.GetConditionResult(meshComp);
		this.ClearConditionResult(meshComp);
		return conditionResult;
	}

	// Token: 0x0600454F RID: 17743 RVA: 0x00089B64 File Offset: 0x00087D64
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBase.TsAnimNotifyStateBase_C");
		}
		return TsAnimNotifyStateBase._ClassPtr;
	}

	// Token: 0x06004550 RID: 17744 RVA: 0x00089B88 File Offset: 0x00087D88
	public TsAnimNotifyStateBase() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004551 RID: 17745 RVA: 0x00089BB0 File Offset: 0x00087DB0
	[NullableContext(1)]
	public TsAnimNotifyStateBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004552 RID: 17746 RVA: 0x00089BE3 File Offset: 0x00087DE3
	protected TsAnimNotifyStateBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004553 RID: 17747 RVA: 0x00089BEC File Offset: 0x00087DEC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBeginConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyBeginConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBeginConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004554 RID: 17748 RVA: 0x00089C28 File Offset: 0x00087E28
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTickConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyTickConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTickConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004555 RID: 17749 RVA: 0x00089C64 File Offset: 0x00087E64
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEndConditionCheck_Implementation(UKuroAnimNotifyState.__K2_NotifyEndConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEndConditionCheck(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400128C RID: 4748
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<USkeletalMeshComponent> ConditionFail;

	// Token: 0x0400128D RID: 4749
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateBase.TsAnimNotifyStateBase_C";

	// Token: 0x0400128E RID: 4750
	private static IntPtr _ClassPtr;

	// Token: 0x0400128F RID: 4751
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001290 RID: 4752
	private static int __PropertyOffset_ANS执行的前提条件;

	// Token: 0x04001291 RID: 4753
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SSkillBehaviorCondition> _ANS执行的前提条件;
}
