using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D23 RID: 3363
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttach.TsAnimNotifyStateAttach_C")]
public class TsAnimNotifyStateAttach : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060044BE RID: 17598 RVA: 0x000871F0 File Offset: 0x000853F0
	static TsAnimNotifyStateAttach()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAttach.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAttach.ResetStaticDefaultValue));
	}

	// Token: 0x060044BF RID: 17599 RVA: 0x00087223 File Offset: 0x00085423
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAttach.IsInit = false;
		TsAnimNotifyStateAttach.CacheMap = new Dictionary<AActor, AttachParams>();
	}

	// Token: 0x060044C0 RID: 17600 RVA: 0x00087235 File Offset: 0x00085435
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAttach.IsInit = false;
		TsAnimNotifyStateAttach.CacheMap = null;
	}

	// Token: 0x17000340 RID: 832
	// (get) Token: 0x060044C1 RID: 17601 RVA: 0x00087243 File Offset: 0x00085443
	// (set) Token: 0x060044C2 RID: 17602 RVA: 0x00087257 File Offset: 0x00085457
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag GameplayTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_GameplayTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_GameplayTag) = value;
		}
	}

	// Token: 0x17000341 RID: 833
	// (get) Token: 0x060044C3 RID: 17603 RVA: 0x0008726C File Offset: 0x0008546C
	// (set) Token: 0x060044C4 RID: 17604 RVA: 0x00087280 File Offset: 0x00085480
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName AttachSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_AttachSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_AttachSocketName) = value;
		}
	}

	// Token: 0x17000342 RID: 834
	// (get) Token: 0x060044C5 RID: 17605 RVA: 0x00087295 File Offset: 0x00085495
	// (set) Token: 0x060044C6 RID: 17606 RVA: 0x000872A9 File Offset: 0x000854A9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector AttachSocketOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_AttachSocketOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttach.__PropertyOffset_AttachSocketOffset) = value;
		}
	}

	// Token: 0x060044C7 RID: 17607 RVA: 0x000872C0 File Offset: 0x000854C0
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

	// Token: 0x060044C8 RID: 17608 RVA: 0x00087368 File Offset: 0x00085568
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || (characterActorComponent == null || !characterActorComponent.IsAutonomousProxy))
		{
			return false;
		}
		CharacterSkillComponent component = characterActorComponent.Entity.GetComponent<CharacterSkillComponent>();
		if (component != null && component.Valid)
		{
			EntityHandle skillTarget = component.SkillTarget;
			if (((skillTarget != null) ? skillTarget.Entity : null) != null)
			{
				WorldEntity entity = component.SkillTarget.Entity;
				EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
				if (handleByEntity == null || !handleByEntity.Valid)
				{
					return false;
				}
				CharacterActorComponent component2 = entity.GetComponent<CharacterActorComponent>();
				if (component2 == null || !component2.Valid)
				{
					return false;
				}
				CharacterAttachComponent component3 = entity.GetComponent<CharacterAttachComponent>();
				if (component3 == null || !component3.Valid)
				{
					return false;
				}
				Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
				CharacterAttachComponent characterAttachComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterAttachComponent>() : null;
				if (characterAttachComponent == null || !characterAttachComponent.Valid)
				{
					return false;
				}
				CharacterPartComponent component4 = entity.GetComponent<CharacterPartComponent>();
				if (component4 == null || !component4.Valid)
				{
					return false;
				}
				this.AttachSocketName = this.GetAttachSocketName();
				CharacterPart partByCombineBoneName = component4.GetPartByCombineBoneName(this.AttachSocketName.ToString());
				if (partByCombineBoneName == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "部位表中不存在合体部位配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AttachSocketName", this.AttachSocketName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				AttachParams attachParams = new AttachParams();
				attachParams.Initialize(characterActorComponent, this.GetAttachTargetLocation(component2), totalDuration);
				TsAnimNotifyStateAttach.Initialize();
				TsAnimNotifyStateAttach.CacheMap.Add(owner, attachParams);
				characterAttachComponent.StartAttachToTarget(handleByEntity, this.AttachSocketName, this.AttachSocketOffset, partByCombineBoneName.Index, new FGameplayTag?(this.GameplayTag));
				return true;
			}
		}
		return false;
	}

	// Token: 0x060044C9 RID: 17609 RVA: 0x0008754C File Offset: 0x0008574C
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

	// Token: 0x060044CA RID: 17610 RVA: 0x000875F4 File Offset: 0x000857F4
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		CharacterAnimationComponent component = characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		CharacterSkillComponent component2 = characterActorComponent.Entity.GetComponent<CharacterSkillComponent>();
		if (component2 != null && component2.Valid)
		{
			EntityHandle skillTarget = component2.SkillTarget;
			if (((skillTarget != null) ? skillTarget.Entity : null) != null)
			{
				WorldEntity entity = component2.SkillTarget.Entity;
				CharacterAttachComponent component3 = entity.GetComponent<CharacterAttachComponent>();
				if (component3 == null || !component3.Valid)
				{
					return false;
				}
				CharacterActorComponent component4 = entity.GetComponent<CharacterActorComponent>();
				if (component4 == null || !component4.Valid)
				{
					return false;
				}
				AttachParams attachParams;
				if (!TsAnimNotifyStateAttach.CacheMap.TryGetValue(tsBaseCharacter, out attachParams))
				{
					return false;
				}
				attachParams.UpdateAttachLocation(characterActorComponent, this.GetAttachTargetLocation(component4));
				characterActorComponent.AddActorWorldOffset(attachParams.StepFrameLocationOffset(characterActorComponent, frameDeltaTime).ToUeVector(false), "TsAnimNotifyStateAttach", false);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060044CB RID: 17611 RVA: 0x00087704 File Offset: 0x00085904
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

	// Token: 0x060044CC RID: 17612 RVA: 0x000877A4 File Offset: 0x000859A4
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		CharacterSkillComponent component = characterActorComponent.Entity.GetComponent<CharacterSkillComponent>();
		if (component != null && component.Valid)
		{
			EntityHandle skillTarget = component.SkillTarget;
			if (((skillTarget != null) ? skillTarget.Entity : null) != null)
			{
				WorldEntity entity = component.SkillTarget.Entity;
				CharacterAttachComponent component2 = entity.GetComponent<CharacterAttachComponent>();
				if (component2 == null || !component2.Valid)
				{
					return false;
				}
				CharacterActorComponent component3 = entity.GetComponent<CharacterActorComponent>();
				if (component3 == null || !component3.Valid)
				{
					return false;
				}
				Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
				CharacterAttachComponent characterAttachComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterAttachComponent>() : null;
				if (characterAttachComponent == null || !characterAttachComponent.Valid)
				{
					return false;
				}
				AttachParams attachParams;
				if (!TsAnimNotifyStateAttach.CacheMap.TryGetValue(owner, out attachParams))
				{
					return false;
				}
				long? preMessageId = characterActorComponent.Entity.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
				attachParams.UpdateAttachLocation(characterActorComponent, this.GetAttachTargetLocation(component3));
				characterActorComponent.AddActorWorldOffset(attachParams.StepFrameLocationOffset(characterActorComponent, 9999f).ToUeVector(false), "TsAnimNotifyStateAttach", false);
				characterAttachComponent.AttachToTarget(ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity), preMessageId, true);
				Dictionary<AActor, AttachParams> cacheMap = TsAnimNotifyStateAttach.CacheMap;
				if (cacheMap != null)
				{
					cacheMap.Remove(owner);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060044CD RID: 17613 RVA: 0x00087914 File Offset: 0x00085B14
	private FName GetAttachSocketName()
	{
		if (this.AttachSocketName == null || StringUtils.IsNothing(this.AttachSocketName.ToString()))
		{
			return new FName(this.ATTACH_SOCKET_NAME);
		}
		return this.AttachSocketName;
	}

	// Token: 0x060044CE RID: 17614 RVA: 0x00087964 File Offset: 0x00085B64
	private Vector GetAttachTargetLocation(CharacterActorComponent targetActorComp)
	{
		Vector tmpVector = TsAnimNotifyStateAttach.TmpVector1;
		FVector attachSocketOffset = this.AttachSocketOffset;
		tmpVector.FromUeVector(attachSocketOffset);
		Vector tmpVector2 = TsAnimNotifyStateAttach.TmpVector2;
		FVectorDouble socketLocation = targetActorComp.GetSocketLocation(this.AttachSocketName);
		tmpVector2.DeepCopy(socketLocation);
		TsAnimNotifyStateAttach.TmpVector2.AdditionEqual(TsAnimNotifyStateAttach.TmpVector1);
		return TsAnimNotifyStateAttach.TmpVector2;
	}

	// Token: 0x060044CF RID: 17615 RVA: 0x000879B4 File Offset: 0x00085BB4
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

	// Token: 0x060044D0 RID: 17616 RVA: 0x00087A2F File Offset: 0x00085C2F
	protected override string GetNotifyName_Implementation()
	{
		return "绑定到目标身上";
	}

	// Token: 0x060044D1 RID: 17617 RVA: 0x00087A36 File Offset: 0x00085C36
	private static void Initialize()
	{
		if (TsAnimNotifyStateAttach.IsInit)
		{
			return;
		}
		TsAnimNotifyStateAttach.CacheMap = new Dictionary<AActor, AttachParams>();
		TsAnimNotifyStateAttach.IsInit = true;
	}

	// Token: 0x060044D2 RID: 17618 RVA: 0x00087A50 File Offset: 0x00085C50
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAttach._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttach.TsAnimNotifyStateAttach_C");
		}
		return TsAnimNotifyStateAttach._ClassPtr;
	}

	// Token: 0x060044D3 RID: 17619 RVA: 0x00087A74 File Offset: 0x00085C74
	public TsAnimNotifyStateAttach() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttach.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060044D4 RID: 17620 RVA: 0x00087A9C File Offset: 0x00085C9C
	public TsAnimNotifyStateAttach(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttach.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060044D5 RID: 17621 RVA: 0x00087ACF File Offset: 0x00085CCF
	protected TsAnimNotifyStateAttach(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060044D6 RID: 17622 RVA: 0x00087AF4 File Offset: 0x00085CF4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060044D7 RID: 17623 RVA: 0x00087B30 File Offset: 0x00085D30
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060044D8 RID: 17624 RVA: 0x00087B6C File Offset: 0x00085D6C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060044D9 RID: 17625 RVA: 0x00087B9F File Offset: 0x00085D9F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001246 RID: 4678
	private const float MAX_ANIM_TIME = 9999f;

	// Token: 0x04001247 RID: 4679
	private string ATTACH_SOCKET_NAME = Singleton<CharacterNameDefines>.Instance.ROOT.ToString();

	// Token: 0x04001248 RID: 4680
	private static bool IsInit;

	// Token: 0x04001249 RID: 4681
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<AActor, AttachParams> CacheMap;

	// Token: 0x0400124A RID: 4682
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x0400124B RID: 4683
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400124C RID: 4684
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttach.TsAnimNotifyStateAttach_C";

	// Token: 0x0400124D RID: 4685
	private static IntPtr _ClassPtr;

	// Token: 0x0400124E RID: 4686
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400124F RID: 4687
	private static int __PropertyOffset_GameplayTag;

	// Token: 0x04001250 RID: 4688
	private static int __PropertyOffset_AttachSocketName;

	// Token: 0x04001251 RID: 4689
	private static int __PropertyOffset_AttachSocketOffset;
}
