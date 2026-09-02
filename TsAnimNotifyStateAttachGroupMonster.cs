using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D26 RID: 3366
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachGroupMonster.TsAnimNotifyStateAttachGroupMonster_C")]
public class TsAnimNotifyStateAttachGroupMonster : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060044FD RID: 17661 RVA: 0x00088318 File Offset: 0x00086518
	static TsAnimNotifyStateAttachGroupMonster()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAttachGroupMonster.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAttachGroupMonster.ResetStaticDefaultValue));
	}

	// Token: 0x060044FE RID: 17662 RVA: 0x0008834B File Offset: 0x0008654B
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAttachGroupMonster.IsInit = false;
		TsAnimNotifyStateAttachGroupMonster.CacheMap = new Dictionary<AActor, AttachGroupMonsterParams>();
	}

	// Token: 0x060044FF RID: 17663 RVA: 0x0008835D File Offset: 0x0008655D
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAttachGroupMonster.IsInit = false;
		TsAnimNotifyStateAttachGroupMonster.CacheMap = null;
	}

	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06004500 RID: 17664 RVA: 0x0008836B File Offset: 0x0008656B
	// (set) Token: 0x06004501 RID: 17665 RVA: 0x0008837F File Offset: 0x0008657F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag GameplayTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_GameplayTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_GameplayTag) = value;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06004502 RID: 17666 RVA: 0x00088394 File Offset: 0x00086594
	// (set) Token: 0x06004503 RID: 17667 RVA: 0x000883A8 File Offset: 0x000865A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName AttachSocketName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_AttachSocketName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_AttachSocketName) = value;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06004504 RID: 17668 RVA: 0x000883BD File Offset: 0x000865BD
	// (set) Token: 0x06004505 RID: 17669 RVA: 0x000883D1 File Offset: 0x000865D1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector AttachSocketOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_AttachSocketOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAttachGroupMonster.__PropertyOffset_AttachSocketOffset) = value;
		}
	}

	// Token: 0x06004506 RID: 17670 RVA: 0x000883E8 File Offset: 0x000865E8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
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
		BaseGroupAiComponent component = characterActorComponent.Entity.GetComponent<BaseGroupAiComponent>();
		EntityHandle entityHandle = (component != null) ? component.GetEcologyAttachTarget() : null;
		WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
		if (entityHandle == null || !entityHandle.Valid || (worldEntity == null || !worldEntity.Valid))
		{
			return false;
		}
		CharacterActorComponent component2 = worldEntity.GetComponent<CharacterActorComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		CharacterAttachComponent component3 = worldEntity.GetComponent<CharacterAttachComponent>();
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
		CharacterPartComponent component4 = worldEntity.GetComponent<CharacterPartComponent>();
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
		AttachGroupMonsterParams attachGroupMonsterParams = new AttachGroupMonsterParams();
		attachGroupMonsterParams.Initialize(characterActorComponent, this.GetAttachTargetLocation(component2), totalDuration);
		TsAnimNotifyStateAttachGroupMonster.Initialize();
		TsAnimNotifyStateAttachGroupMonster.CacheMap.Add(owner, attachGroupMonsterParams);
		characterAttachComponent.StartAttachToTarget(entityHandle, this.AttachSocketName, this.AttachSocketOffset, partByCombineBoneName.Index, new FGameplayTag?(this.GameplayTag));
		return true;
	}

	// Token: 0x06004507 RID: 17671 RVA: 0x000885B4 File Offset: 0x000867B4
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
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
		CharacterAnimationComponent component = characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		BaseGroupAiComponent component2 = characterActorComponent.Entity.GetComponent<BaseGroupAiComponent>();
		WorldEntity worldEntity;
		if (component2 == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle ecologyAttachTarget = component2.GetEcologyAttachTarget();
			worldEntity = ((ecologyAttachTarget != null) ? ecologyAttachTarget.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null || !worldEntity2.Valid)
		{
			return false;
		}
		CharacterAttachComponent component3 = worldEntity2.GetComponent<CharacterAttachComponent>();
		if (component3 == null || !component3.Valid)
		{
			return false;
		}
		CharacterActorComponent component4 = worldEntity2.GetComponent<CharacterActorComponent>();
		if (component4 == null || !component4.Valid)
		{
			return false;
		}
		AttachGroupMonsterParams attachGroupMonsterParams;
		if (!TsAnimNotifyStateAttachGroupMonster.CacheMap.TryGetValue(owner, out attachGroupMonsterParams))
		{
			return false;
		}
		attachGroupMonsterParams.UpdateAttachLocation(characterActorComponent, this.GetAttachTargetLocation(component4));
		characterActorComponent.AddActorWorldOffset(attachGroupMonsterParams.StepFrameLocationOffset(characterActorComponent, frameDeltaTime).ToUeVector(false), "TsAnimNotifyStateAttachGroupMonster", false);
		return true;
	}

	// Token: 0x06004508 RID: 17672 RVA: 0x000886C0 File Offset: 0x000868C0
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
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
		BaseGroupAiComponent component = characterActorComponent.Entity.GetComponent<BaseGroupAiComponent>();
		WorldEntity worldEntity;
		if (component == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle ecologyAttachTarget = component.GetEcologyAttachTarget();
			worldEntity = ((ecologyAttachTarget != null) ? ecologyAttachTarget.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null || !worldEntity2.Valid)
		{
			return false;
		}
		CharacterAttachComponent component2 = worldEntity2.GetComponent<CharacterAttachComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		CharacterActorComponent component3 = worldEntity2.GetComponent<CharacterActorComponent>();
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
		AttachGroupMonsterParams attachGroupMonsterParams;
		if (!TsAnimNotifyStateAttachGroupMonster.CacheMap.TryGetValue(owner, out attachGroupMonsterParams))
		{
			return false;
		}
		long? preMessageId = characterActorComponent.Entity.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
		attachGroupMonsterParams.UpdateAttachLocation(characterActorComponent, this.GetAttachTargetLocation(component3));
		characterActorComponent.AddActorWorldOffset(attachGroupMonsterParams.StepFrameLocationOffset(characterActorComponent, 9999f).ToUeVector(false), "TsAnimNotifyStateAttachGroupMonster", false);
		characterAttachComponent.AttachToTarget(ModelBase<CharacterModel>.Instance.GetHandleByEntity(worldEntity2), preMessageId, true);
		Dictionary<AActor, AttachGroupMonsterParams> cacheMap = TsAnimNotifyStateAttachGroupMonster.CacheMap;
		if (cacheMap != null)
		{
			cacheMap.Remove(owner);
		}
		return true;
	}

	// Token: 0x06004509 RID: 17673 RVA: 0x00088824 File Offset: 0x00086A24
	private FName GetAttachSocketName()
	{
		if (this.AttachSocketName == null || StringUtils.IsNothing(this.AttachSocketName.ToString()))
		{
			return new FName(this.ATTACH_SOCKET_NAME);
		}
		return this.AttachSocketName;
	}

	// Token: 0x0600450A RID: 17674 RVA: 0x00088874 File Offset: 0x00086A74
	private Vector GetAttachTargetLocation(CharacterActorComponent targetActorComp)
	{
		Vector tmpVector = TsAnimNotifyStateAttachGroupMonster.TmpVector1;
		FVector attachSocketOffset = this.AttachSocketOffset;
		tmpVector.FromUeVector(attachSocketOffset);
		Vector tmpVector2 = TsAnimNotifyStateAttachGroupMonster.TmpVector2;
		FVectorDouble socketLocation = targetActorComp.GetSocketLocation(this.AttachSocketName);
		tmpVector2.DeepCopy(socketLocation);
		TsAnimNotifyStateAttachGroupMonster.TmpVector2.AdditionEqual(TsAnimNotifyStateAttachGroupMonster.TmpVector1);
		return TsAnimNotifyStateAttachGroupMonster.TmpVector2;
	}

	// Token: 0x0600450B RID: 17675 RVA: 0x000888C2 File Offset: 0x00086AC2
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "绑定到怪物组队长身上";
	}

	// Token: 0x0600450C RID: 17676 RVA: 0x000888C9 File Offset: 0x00086AC9
	private static void Initialize()
	{
		if (TsAnimNotifyStateAttachGroupMonster.IsInit)
		{
			return;
		}
		TsAnimNotifyStateAttachGroupMonster.CacheMap = new Dictionary<AActor, AttachGroupMonsterParams>();
		TsAnimNotifyStateAttachGroupMonster.IsInit = true;
	}

	// Token: 0x0600450D RID: 17677 RVA: 0x000888E3 File Offset: 0x00086AE3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAttachGroupMonster._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachGroupMonster.TsAnimNotifyStateAttachGroupMonster_C");
		}
		return TsAnimNotifyStateAttachGroupMonster._ClassPtr;
	}

	// Token: 0x0600450E RID: 17678 RVA: 0x00088908 File Offset: 0x00086B08
	public TsAnimNotifyStateAttachGroupMonster() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttachGroupMonster.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600450F RID: 17679 RVA: 0x00088930 File Offset: 0x00086B30
	public TsAnimNotifyStateAttachGroupMonster(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAttachGroupMonster.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004510 RID: 17680 RVA: 0x00088963 File Offset: 0x00086B63
	protected TsAnimNotifyStateAttachGroupMonster(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004511 RID: 17681 RVA: 0x00088988 File Offset: 0x00086B88
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004512 RID: 17682 RVA: 0x000889C4 File Offset: 0x00086BC4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004513 RID: 17683 RVA: 0x00088A00 File Offset: 0x00086C00
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004514 RID: 17684 RVA: 0x00088A33 File Offset: 0x00086C33
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x04001269 RID: 4713
	private const float MAX_ANIM_TIME = 9999f;

	// Token: 0x0400126A RID: 4714
	private string ATTACH_SOCKET_NAME = Singleton<CharacterNameDefines>.Instance.ROOT.ToString();

	// Token: 0x0400126B RID: 4715
	private static bool IsInit;

	// Token: 0x0400126C RID: 4716
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<AActor, AttachGroupMonsterParams> CacheMap;

	// Token: 0x0400126D RID: 4717
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x0400126E RID: 4718
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x0400126F RID: 4719
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAttachGroupMonster.TsAnimNotifyStateAttachGroupMonster_C";

	// Token: 0x04001270 RID: 4720
	private static IntPtr _ClassPtr;

	// Token: 0x04001271 RID: 4721
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001272 RID: 4722
	private static int __PropertyOffset_GameplayTag;

	// Token: 0x04001273 RID: 4723
	private static int __PropertyOffset_AttachSocketName;

	// Token: 0x04001274 RID: 4724
	private static int __PropertyOffset_AttachSocketOffset;
}
