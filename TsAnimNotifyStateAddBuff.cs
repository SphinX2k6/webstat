using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.CombatMessage;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D1A RID: 3354
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddBuff.TsAnimNotifyStateAddBuff_C")]
public class TsAnimNotifyStateAddBuff : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700032F RID: 815
	// (get) Token: 0x06004432 RID: 17458 RVA: 0x0008482F File Offset: 0x00082A2F
	// (set) Token: 0x06004433 RID: 17459 RVA: 0x0008483F File Offset: 0x00082A3F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe long BuffId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddBuff.__PropertyOffset_BuffId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddBuff.__PropertyOffset_BuffId) = value;
		}
	}

	// Token: 0x17000330 RID: 816
	// (get) Token: 0x06004434 RID: 17460 RVA: 0x00084850 File Offset: 0x00082A50
	// (set) Token: 0x06004435 RID: 17461 RVA: 0x00084860 File Offset: 0x00082A60
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ESkillBehaviorBuffTargetType 施加目标
	{
		get
		{
			return (ESkillBehaviorBuffTargetType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddBuff.__PropertyOffset_施加目标));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddBuff.__PropertyOffset_施加目标) = (byte)value;
		}
	}

	// Token: 0x06004436 RID: 17462 RVA: 0x00084874 File Offset: 0x00082A74
	[NullableContext(2)]
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

	// Token: 0x06004437 RID: 17463 RVA: 0x0008491C File Offset: 0x00082B1C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
			CharacterBuffComponent buffTarget = this.GetBuffTarget(entity);
			if (component == null || buffTarget == null)
			{
				return true;
			}
			if (!component.HasBuffAuthority() && !ControllerBase<SkillMessageController>.Instance.CloseMonsterServerLogic)
			{
				return true;
			}
			long? preMessageId = component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
			BaseBuffComponent baseBuffComponent = buffTarget;
			long buffId = this.BuffId;
			AddBuffParam addBuffParam = new AddBuffParam();
			addBuffParam.InstigatorId = component.CreatureDataId;
			addBuffParam.PreMessageId = preMessageId;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("动画");
			defaultInterpolatedStringHandler.AppendFormatted<UAnimSequenceBase>(animation);
			defaultInterpolatedStringHandler.AppendLiteral("的ANS添加");
			addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
			baseBuffComponent.AddBuff(buffId, addBuffParam);
		}
		return true;
	}

	// Token: 0x06004438 RID: 17464 RVA: 0x000849EC File Offset: 0x00082BEC
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

	// Token: 0x06004439 RID: 17465 RVA: 0x00084A8C File Offset: 0x00082C8C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			CharacterBuffComponent buffTarget = this.GetBuffTarget(entity);
			if (characterBuffComponent == null || buffTarget == null)
			{
				return true;
			}
			if (!characterBuffComponent.HasBuffAuthority() && !ControllerBase<SkillMessageController>.Instance.CloseMonsterServerLogic)
			{
				return true;
			}
			if (buffTarget.Valid)
			{
				buffTarget.RemoveBuff(this.BuffId, -1, "动画" + ((animation != null) ? animation.GetName() : null) + "的ANS移除", null, null, null);
			}
		}
		return true;
	}

	// Token: 0x0600443A RID: 17466 RVA: 0x00084B40 File Offset: 0x00082D40
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

	// Token: 0x0600443B RID: 17467 RVA: 0x00084BBB File Offset: 0x00082DBB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "添加BUFF";
	}

	// Token: 0x0600443C RID: 17468 RVA: 0x00084BC4 File Offset: 0x00082DC4
	[NullableContext(2)]
	private CharacterBuffComponent GetBuffTarget(Entity entity)
	{
		if (this.施加目标 == ESkillBehaviorBuffTargetType.技能目标)
		{
			object obj;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
				if (component == null)
				{
					obj = null;
				}
				else
				{
					EntityHandle skillTarget = component.SkillTarget;
					obj = ((skillTarget != null) ? skillTarget.Entity : null);
				}
			}
			object obj2 = obj;
			if (obj2 == null)
			{
				return null;
			}
			return obj2.GetComponent<CharacterBuffComponent>();
		}
		else
		{
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<CharacterBuffComponent>();
		}
	}

	// Token: 0x0600443D RID: 17469 RVA: 0x00084C15 File Offset: 0x00082E15
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddBuff._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddBuff.TsAnimNotifyStateAddBuff_C");
		}
		return TsAnimNotifyStateAddBuff._ClassPtr;
	}

	// Token: 0x0600443E RID: 17470 RVA: 0x00084C3C File Offset: 0x00082E3C
	public TsAnimNotifyStateAddBuff() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddBuff.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600443F RID: 17471 RVA: 0x00084C64 File Offset: 0x00082E64
	[NullableContext(1)]
	public TsAnimNotifyStateAddBuff(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004440 RID: 17472 RVA: 0x00084C97 File Offset: 0x00082E97
	protected TsAnimNotifyStateAddBuff(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004441 RID: 17473 RVA: 0x00084CA0 File Offset: 0x00082EA0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004442 RID: 17474 RVA: 0x00084CDC File Offset: 0x00082EDC
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004443 RID: 17475 RVA: 0x00084D0F File Offset: 0x00082F0F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001202 RID: 4610
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddBuff.TsAnimNotifyStateAddBuff_C";

	// Token: 0x04001203 RID: 4611
	private static IntPtr _ClassPtr;

	// Token: 0x04001204 RID: 4612
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001205 RID: 4613
	private static int __PropertyOffset_BuffId;

	// Token: 0x04001206 RID: 4614
	private static int __PropertyOffset_施加目标;
}
