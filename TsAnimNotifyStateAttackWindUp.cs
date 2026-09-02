using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D27 RID: 3367
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttackWindUp.TsAnimNotifyStateAttackWindUp_C")]
public class TsAnimNotifyStateAttackWindUp : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004515 RID: 17685 RVA: 0x00088A47 File Offset: 0x00086C47
	static TsAnimNotifyStateAttackWindUp()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAttackWindUp.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAttackWindUp.ResetStaticDefaultValue));
	}

	// Token: 0x06004516 RID: 17686 RVA: 0x00088A66 File Offset: 0x00086C66
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAttackWindUp.entityEffectMap = new Dictionary<int, int>();
	}

	// Token: 0x06004517 RID: 17687 RVA: 0x00088A72 File Offset: 0x00086C72
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAttackWindUp.entityEffectMap = null;
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06004518 RID: 17688 RVA: 0x00088A7C File Offset: 0x00086C7C
	// (set) Token: 0x06004519 RID: 17689 RVA: 0x00088AB5 File Offset: 0x00086CB5
	[UProperty(EPropertyFlags.CPF_None)]
	public SCounterWindupAttack Info
	{
		get
		{
			base.FastCheckIsValid();
			SCounterWindupAttack result;
			if ((result = this._Info) == null)
			{
				result = (this._Info = new SCounterWindupAttack(base.NativePtr + (IntPtr)TsAnimNotifyStateAttackWindUp.__PropertyOffset_Info, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SCounterWindupAttack.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateAttackWindUp.__PropertyOffset_Info, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x0600451A RID: 17690 RVA: 0x00088AE0 File Offset: 0x00086CE0
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

	// Token: 0x0600451B RID: 17691 RVA: 0x00088B88 File Offset: 0x00086D88
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.Info == null)
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		CharacterActorComponent characterActorComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Entity entity = characterActorComponent.Entity;
		CharacterHitComponent component = entity.GetComponent<CharacterHitComponent>();
		BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		long? num = (component2 != null) ? component2.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
		component.SetWindupAttackInfo(this.Info, num.GetValueOrDefault());
		component.SetCounterAttackEndTime(totalDuration);
		TSoftObjectPtr<UEffectModelBase> effect = this.Info.Effect;
		if (ObjectUtils.SoftObjectReferenceValid<UEffectModelBase>(effect))
		{
			SkeletalMeshEffectContext skeletalMeshEffectContext;
			if (owner is TsBaseCharacter)
			{
				CharacterActorComponent characterActorComponent2 = (owner as TsBaseCharacter).CharacterActorComponent;
				if (((characterActorComponent2 != null) ? characterActorComponent2.Entity : null) != null)
				{
					CharacterActorComponent characterActorComponent3 = (owner as TsBaseCharacter).CharacterActorComponent;
					skeletalMeshEffectContext = new SkeletalMeshEffectContext((characterActorComponent3 != null) ? new int?(characterActorComponent3.Entity.Id) : null, null, false);
					goto IL_12A;
				}
			}
			skeletalMeshEffectContext = new SkeletalMeshEffectContext(null, null, false);
			IL_12A:
			skeletalMeshEffectContext.SkeletalMeshComp = meshComp;
			skeletalMeshEffectContext.SourceObject = owner;
			skeletalMeshEffectContext.CreateFromType = EEffectCreateFromType.An;
			string path = effect.ToAssetPathName();
			FTransformDouble socketTransform = characterActorComponent.GetSocketTransform(this.Info.SocketName);
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(socketTransform);
			int num2 = instance.SpawnEffect(world, ftransformDouble, path, "[TsAnimNotifyStateAttackWindUp.K2_NotifyBegin]", skeletalMeshEffectContext, EEffectType.Fight, null, null, null, false, false);
			TsAnimNotifyStateAttackWindUp.entityEffectMap.Add(entity.Id, num2);
			if (this.Info.EffectAttach)
			{
				this.SetupEffectTransform(Singleton<EffectSystem>.Instance.GetEffectActor(num2), characterActorComponent.SkeletalMesh);
			}
		}
		return true;
	}

	// Token: 0x0600451C RID: 17692 RVA: 0x00088D5C File Offset: 0x00086F5C
	private void SetupEffectTransform(object effectActor, USkeletalMeshComponent meshComp)
	{
		AActor aactor = effectActor as AActor;
		if (aactor != null)
		{
			aactor.K2_AttachToComponent(meshComp, this.Info.SocketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
		}
		FTransformDouble ftransformDouble = UKismetMathLibrary.Conv_TransformToTransformDouble(this.Info.RelativeTransform);
		FHitResult fhitResult = new FHitResult();
		if (aactor == null)
		{
			return;
		}
		aactor.D_K2_SetActorRelativeTransform(ftransformDouble, false, ref fhitResult, true);
	}

	// Token: 0x0600451D RID: 17693 RVA: 0x00088DB4 File Offset: 0x00086FB4
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

	// Token: 0x0600451E RID: 17694 RVA: 0x00088E54 File Offset: 0x00087054
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.Info == null)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		CharacterActorComponent characterActorComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Entity entity = characterActorComponent.Entity;
		CharacterHitComponent component = entity.GetComponent<CharacterHitComponent>();
		CharacterSkillComponent component2 = entity.GetComponent<CharacterSkillComponent>();
		if (component2 == null || !component2.Valid || (component == null || !component.Valid))
		{
			return false;
		}
		component.WindupAttackEnd();
		int handle;
		if (TsAnimNotifyStateAttackWindUp.entityEffectMap.TryGetValue(entity.Id, out handle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, "[TsAnimNotifyStateAttackWindUp.K2_NotifyEnd]", false, null);
			TsAnimNotifyStateAttackWindUp.entityEffectMap.Remove(entity.Id);
		}
		return true;
	}

	// Token: 0x0600451F RID: 17695 RVA: 0x00088F1C File Offset: 0x0008711C
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

	// Token: 0x06004520 RID: 17696 RVA: 0x00088F97 File Offset: 0x00087197
	protected override string GetNotifyName_Implementation()
	{
		return "前摇配置";
	}

	// Token: 0x06004521 RID: 17697 RVA: 0x00088F9E File Offset: 0x0008719E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAttackWindUp._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttackWindUp.TsAnimNotifyStateAttackWindUp_C");
		}
		return TsAnimNotifyStateAttackWindUp._ClassPtr;
	}

	// Token: 0x06004522 RID: 17698 RVA: 0x00088FC4 File Offset: 0x000871C4
	public TsAnimNotifyStateAttackWindUp() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttackWindUp.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004523 RID: 17699 RVA: 0x00088FEC File Offset: 0x000871EC
	public TsAnimNotifyStateAttackWindUp(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttackWindUp.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004524 RID: 17700 RVA: 0x0008901F File Offset: 0x0008721F
	protected TsAnimNotifyStateAttackWindUp(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004525 RID: 17701 RVA: 0x00089028 File Offset: 0x00087228
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004526 RID: 17702 RVA: 0x00089064 File Offset: 0x00087264
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004527 RID: 17703 RVA: 0x00089097 File Offset: 0x00087297
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001275 RID: 4725
	private static Dictionary<int, int> entityEffectMap;

	// Token: 0x04001276 RID: 4726
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttackWindUp.TsAnimNotifyStateAttackWindUp_C";

	// Token: 0x04001277 RID: 4727
	private static IntPtr _ClassPtr;

	// Token: 0x04001278 RID: 4728
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001279 RID: 4729
	private static int __PropertyOffset_Info;

	// Token: 0x0400127A RID: 4730
	[Nullable(2)]
	private SCounterWindupAttack _Info;
}
