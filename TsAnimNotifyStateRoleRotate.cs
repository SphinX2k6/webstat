using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D6D RID: 3437
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRoleRotate.TsAnimNotifyStateRoleRotate_C")]
public class TsAnimNotifyStateRoleRotate : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x06004A57 RID: 19031 RVA: 0x000A202F File Offset: 0x000A022F
	// (set) Token: 0x06004A58 RID: 19032 RVA: 0x000A203F File Offset: 0x000A023F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 旋转速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_旋转速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_旋转速度) = value;
		}
	}

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06004A59 RID: 19033 RVA: 0x000A2050 File Offset: 0x000A0250
	// (set) Token: 0x06004A5A RID: 19034 RVA: 0x000A2060 File Offset: 0x000A0260
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否自动朝向目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_是否自动朝向目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_是否自动朝向目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06004A5B RID: 19035 RVA: 0x000A2074 File Offset: 0x000A0274
	// (set) Token: 0x06004A5C RID: 19036 RVA: 0x000A20AD File Offset: 0x000A02AD
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	private FGameplayTagContainer TagContainer
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._TagContainer) == null)
			{
				result = (this._TagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_TagContainer, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_TagContainer, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06004A5D RID: 19037 RVA: 0x000A20D5 File Offset: 0x000A02D5
	// (set) Token: 0x06004A5E RID: 19038 RVA: 0x000A20E5 File Offset: 0x000A02E5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 在横板模式中禁用
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_在横板模式中禁用) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_在横板模式中禁用) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06004A5F RID: 19039 RVA: 0x000A20F6 File Offset: 0x000A02F6
	// (set) Token: 0x06004A60 RID: 19040 RVA: 0x000A2106 File Offset: 0x000A0306
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 只在横板模式中生效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_只在横板模式中生效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRoleRotate.__PropertyOffset_只在横板模式中生效) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004A61 RID: 19041 RVA: 0x000A2118 File Offset: 0x000A0318
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004A62 RID: 19042 RVA: 0x000A21C0 File Offset: 0x000A03C0
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
			if (entityNoBlueprint == null || !entityNoBlueprint.Valid)
			{
				return false;
			}
			if (this.在横板模式中禁用)
			{
				CharacterSplineMoveComponent component = entityNoBlueprint.GetComponent<CharacterSplineMoveComponent>();
				if (component != null && component.Active)
				{
					return false;
				}
			}
			else if (this.只在横板模式中生效)
			{
				CharacterSplineMoveComponent component2 = entityNoBlueprint.GetComponent<CharacterSplineMoveComponent>();
				if (component2 == null || !component2.Active)
				{
					return false;
				}
			}
			CharacterSkillComponent component3 = entityNoBlueprint.GetComponent<CharacterSkillComponent>();
			if (component3 != null && component3.Valid)
			{
				component3.SetSkillRotateToTarget(this.是否自动朝向目标, false, 0f, 0f, 0f);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004A63 RID: 19043 RVA: 0x000A2270 File Offset: 0x000A0470
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

	// Token: 0x06004A64 RID: 19044 RVA: 0x000A2318 File Offset: 0x000A0518
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			UBaseAbilitySystemComponent abilitySystemComponent = tsBaseCharacter.AbilitySystemComponent;
			bool flag;
			if (abilitySystemComponent == null)
			{
				flag = true;
			}
			else
			{
				FGameplayTagContainer tagContainer = this.TagContainer;
				flag = !abilitySystemComponent.HasAnyGameplayTag(tagContainer);
			}
			if (flag)
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
				if (entity == null || !entity.Valid)
				{
					return false;
				}
				if (this.在横板模式中禁用)
				{
					CharacterSplineMoveComponent component = entity.GetComponent<CharacterSplineMoveComponent>();
					if (component != null && component.Active)
					{
						return false;
					}
				}
				else if (this.只在横板模式中生效)
				{
					CharacterSplineMoveComponent component2 = entity.GetComponent<CharacterSplineMoveComponent>();
					if (component2 == null || !component2.Active)
					{
						return false;
					}
				}
				CharacterSkillComponent component3 = entity.GetComponent<CharacterSkillComponent>();
				if (component3 == null || !component3.Valid)
				{
					return false;
				}
				CharacterUnifiedStateComponent component4 = entity.GetComponent<CharacterUnifiedStateComponent>();
				if (component4 != null && component4.PositionState == ECharPositionState.Ride)
				{
					return false;
				}
				if (this.是否自动朝向目标)
				{
					BaseSkillComponent baseSkillComponent = component3;
					EntityHandle skillTargetForAns = component3.GetSkillTargetForAns();
					baseSkillComponent.SetSkillRotateToTarget(skillTargetForAns != null && skillTargetForAns.Valid, false, 0f, 0f, 0f);
					component3.SetSkillRotateSpeed(this.旋转速度);
				}
				else
				{
					CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
					Vector inputDirectProxy = characterActorComponent2.InputDirectProxy;
					if (!inputDirectProxy.IsNearlyZero(9.999999747378752E-05))
					{
						Vector actorForwardProxy = characterActorComponent2.ActorForwardProxy;
						double d = Singleton<MathUtils>.Instance.Clamp(actorForwardProxy.DotProduct(inputDirectProxy), -1.0, 1.0);
						Singleton<GravityUtils>.Instance.RotatorInterpConstantToForActor(characterActorComponent2, characterActorComponent2.ActorRotationProxy, characterActorComponent2.InputRotatorProxy, frameDeltaTime, (float)Math.Acos(d) * 57.29578f / 180f * this.旋转速度, this.TmpRotator);
						return characterActorComponent2.SetActorRotationWithPriority(this.TmpRotator.ToUeRotator(), "TsAnimNotifyStateRoleRotate", ESetRotationPriority.Movement, true, false);
					}
				}
				return true;
			}
		}
		return true;
	}

	// Token: 0x06004A65 RID: 19045 RVA: 0x000A24E4 File Offset: 0x000A06E4
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

	// Token: 0x06004A66 RID: 19046 RVA: 0x000A2584 File Offset: 0x000A0784
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			CharacterSkillComponent characterSkillComponent;
			if (characterActorComponent == null)
			{
				characterSkillComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				characterSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
			CharacterSkillComponent characterSkillComponent2 = characterSkillComponent;
			if (characterSkillComponent2 != null && characterSkillComponent2.Valid)
			{
				characterSkillComponent2.SetSkillCanRotate(false);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004A67 RID: 19047 RVA: 0x000A25D4 File Offset: 0x000A07D4
	private void Init()
	{
		this.TmpRotator = Rotator.Create();
	}

	// Token: 0x06004A68 RID: 19048 RVA: 0x000A25E1 File Offset: 0x000A07E1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRoleRotate._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRoleRotate.TsAnimNotifyStateRoleRotate_C");
		}
		return TsAnimNotifyStateRoleRotate._ClassPtr;
	}

	// Token: 0x06004A69 RID: 19049 RVA: 0x000A2608 File Offset: 0x000A0808
	public TsAnimNotifyStateRoleRotate() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRoleRotate.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004A6A RID: 19050 RVA: 0x000A2630 File Offset: 0x000A0830
	[NullableContext(1)]
	public TsAnimNotifyStateRoleRotate(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRoleRotate.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004A6B RID: 19051 RVA: 0x000A2663 File Offset: 0x000A0863
	protected TsAnimNotifyStateRoleRotate(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004A6C RID: 19052 RVA: 0x000A266C File Offset: 0x000A086C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004A6D RID: 19053 RVA: 0x000A26A8 File Offset: 0x000A08A8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004A6E RID: 19054 RVA: 0x000A26E4 File Offset: 0x000A08E4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400150A RID: 5386
	private Rotator TmpRotator;

	// Token: 0x0400150B RID: 5387
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRoleRotate.TsAnimNotifyStateRoleRotate_C";

	// Token: 0x0400150C RID: 5388
	private static IntPtr _ClassPtr;

	// Token: 0x0400150D RID: 5389
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400150E RID: 5390
	private static int __PropertyOffset_旋转速度;

	// Token: 0x0400150F RID: 5391
	private static int __PropertyOffset_是否自动朝向目标;

	// Token: 0x04001510 RID: 5392
	private static int __PropertyOffset_TagContainer;

	// Token: 0x04001511 RID: 5393
	private FGameplayTagContainer _TagContainer;

	// Token: 0x04001512 RID: 5394
	private static int __PropertyOffset_在横板模式中禁用;

	// Token: 0x04001513 RID: 5395
	private static int __PropertyOffset_只在横板模式中生效;
}
