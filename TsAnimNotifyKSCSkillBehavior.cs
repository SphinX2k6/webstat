using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD7 RID: 3543
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyKSCSkillBehavior.TsAnimNotifyKSCSkillBehavior_C")]
public class TsAnimNotifyKSCSkillBehavior : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700053C RID: 1340
	// (get) Token: 0x0600510E RID: 20750 RVA: 0x000BBC5F File Offset: 0x000B9E5F
	// (set) Token: 0x0600510F RID: 20751 RVA: 0x000BBC73 File Offset: 0x000B9E73
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe KscBpDataBase Action
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<KscBpDataBase>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyKSCSkillBehavior.__PropertyOffset_Action);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyKSCSkillBehavior.__PropertyOffset_Action, value);
		}
	}

	// Token: 0x06005110 RID: 20752 RVA: 0x000BBC88 File Offset: 0x000B9E88
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

	// Token: 0x06005111 RID: 20753 RVA: 0x000BBD28 File Offset: 0x000B9F28
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		KscBpDataBase action = this.Action;
		if (action == null)
		{
			this.Warn((meshComp != null) ? meshComp.GetOwner() : null, "KSC技能行为执行失败: 未配置Action", Array.Empty<ValueTuple<string, object>>());
			return false;
		}
		KscSkillData kscSkillData = action as KscSkillData;
		if (kscSkillData != null)
		{
			return this.ExecuteSkillAction(meshComp, kscSkillData);
		}
		KscBulletData kscBulletData = action as KscBulletData;
		if (kscBulletData != null)
		{
			return this.ExecuteBulletAction(meshComp, kscBulletData);
		}
		this.Warn((meshComp != null) ? meshComp.GetOwner() : null, "KSC技能行为执行失败: 未支持的Action类型", new ValueTuple<string, object>[]
		{
			new ValueTuple<string, object>("action", action)
		});
		return false;
	}

	// Token: 0x06005112 RID: 20754 RVA: 0x000BBDB4 File Offset: 0x000B9FB4
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

	// Token: 0x06005113 RID: 20755 RVA: 0x000BBE2F File Offset: 0x000BA02F
	protected override string GetNotifyName_Implementation()
	{
		return "KSC技能行为";
	}

	// Token: 0x06005114 RID: 20756 RVA: 0x000BBE38 File Offset: 0x000BA038
	private bool ExecuteSkillAction(USkeletalMeshComponent meshComp, KscSkillData action)
	{
		KscNotifyCharacterContext characterContext = this.GetCharacterContext(meshComp, "技能");
		if (characterContext == null)
		{
			return false;
		}
		TowerDefensePlayerController.DoSkill(characterContext.Entity, action.SkillIndex);
		return true;
	}

	// Token: 0x06005115 RID: 20757 RVA: 0x000BBE6C File Offset: 0x000BA06C
	private bool ExecuteBulletAction(USkeletalMeshComponent meshComp, KscBulletData action)
	{
		if (action.BulletConfigId <= 0)
		{
			this.Warn(meshComp.GetOwner(), "KSC子弹行为执行失败: BulletConfigId非法", new ValueTuple<string, object>[]
			{
				new ValueTuple<string, object>("BulletConfigId", action.BulletConfigId)
			});
			return false;
		}
		KscNotifyCharacterContext characterContext = this.GetCharacterContext(meshComp, "子弹");
		if (characterContext == null)
		{
			return false;
		}
		UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		if (kuroBulletWorld == null)
		{
			this.Warn(characterContext.Owner, "KSC子弹行为执行失败: BulletWorld不存在", Array.Empty<ValueTuple<string, object>>());
			return false;
		}
		CreatureDataComponent component = characterContext.Entity.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetCreatureDataId()) : null;
		if (num != null)
		{
			long? num2 = num;
			long num3 = 0L;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				AKSC_Entity kscEntityHandle = ControllerBase<KuroSimpleCombatController>.Instance.GetKscEntityHandle(num.Value);
				if (kscEntityHandle == null)
				{
					this.Warn(characterContext.Owner, "KSC子弹行为执行失败: 无已绑定的KSC实体", new ValueTuple<string, object>[]
					{
						new ValueTuple<string, object>("creatureId", num.Value),
						new ValueTuple<string, object>("hasSubModel", ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel != null)
					});
					return false;
				}
				UKSC_Bullet_Context uksc_Bullet_Context = kuroBulletWorld.PoolGet(UKSC_Bullet_Context.StaticClass()) as UKSC_Bullet_Context;
				if (uksc_Bullet_Context == null)
				{
					this.Warn(characterContext.Owner, "KSC子弹行为执行失败: 无法从BulletWorld对象池获取BulletContext", Array.Empty<ValueTuple<string, object>>());
					return false;
				}
				uksc_Bullet_Context.Owner = new TWeakObjectPtr<AKSC_Entity>(kscEntityHandle);
				uksc_Bullet_Context.SkillTargetEntityId = 0;
				FBulletSpawnParams fbulletSpawnParams = new FBulletSpawnParams();
				fbulletSpawnParams.InitialTransform = this.ResolveBulletSpawnTransform(meshComp, characterContext.Owner, action);
				kuroBulletWorld.CreateBullet(uksc_Bullet_Context, (long)action.BulletConfigId, fbulletSpawnParams);
				return true;
			}
		}
		this.Warn(characterContext.Owner, "KSC子弹行为执行失败: 无法获取CreatureDataId", new ValueTuple<string, object>[]
		{
			new ValueTuple<string, object>("entityId", characterContext.Entity.Id)
		});
		return false;
	}

	// Token: 0x06005116 RID: 20758 RVA: 0x000BC054 File Offset: 0x000BA254
	private FTransformDouble ResolveBulletSpawnTransform(USkeletalMeshComponent meshComp, TsBaseCharacter owner, KscBulletData action)
	{
		FTransformDouble result = owner.D_GetTransform();
		string meshComponentName = action.LaunchMeshComponentName.Trim();
		string text = action.LaunchBoneOrSocketName.Trim();
		if (text.Length == 0)
		{
			return result;
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.FindLaunchMeshComponent(owner, meshComp, meshComponentName);
		if (uskeletalMeshComponent == null)
		{
			this.Warn(owner, "KSC子弹行为执行警告: 发射骨骼网格体不存在，回退RootTransform", new ValueTuple<string, object>[]
			{
				new ValueTuple<string, object>("LaunchMeshComponentName", action.LaunchMeshComponentName),
				new ValueTuple<string, object>("LaunchBoneOrSocketName", action.LaunchBoneOrSocketName)
			});
			return result;
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(text);
		if (dynamicFName == null)
		{
			this.Warn(owner, "KSC子弹行为执行警告: 发射骨骼/Socket名字非法，回退RootTransform", new ValueTuple<string, object>[]
			{
				new ValueTuple<string, object>("LaunchMeshComponentName", action.LaunchMeshComponentName),
				new ValueTuple<string, object>("LaunchBoneOrSocketName", action.LaunchBoneOrSocketName)
			});
			return result;
		}
		if (uskeletalMeshComponent.DoesSocketExist(dynamicFName.Value) || uskeletalMeshComponent.GetBoneIndex(dynamicFName.Value) >= 0)
		{
			return uskeletalMeshComponent.D_GetSocketTransform(dynamicFName.Value, ERelativeTransformSpace.RTS_World);
		}
		this.Warn(owner, "KSC子弹行为执行警告: 发射骨骼/Socket不存在，回退RootTransform", new ValueTuple<string, object>[]
		{
			new ValueTuple<string, object>("LaunchMeshComponentName", action.LaunchMeshComponentName),
			new ValueTuple<string, object>("LaunchBoneOrSocketName", action.LaunchBoneOrSocketName),
			new ValueTuple<string, object>("ResolvedMeshComponent", uskeletalMeshComponent)
		});
		return result;
	}

	// Token: 0x06005117 RID: 20759 RVA: 0x000BC1B0 File Offset: 0x000BA3B0
	[return: Nullable(2)]
	private USkeletalMeshComponent FindLaunchMeshComponent(TsBaseCharacter owner, USkeletalMeshComponent currentMeshComp, string meshComponentName)
	{
		if (meshComponentName.Length == 0 || meshComponentName == "None")
		{
			CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
			if (characterActorComponent == null)
			{
				return null;
			}
			return characterActorComponent.SkeletalMesh;
		}
		else
		{
			if (currentMeshComp.GetName() == meshComponentName)
			{
				return currentMeshComp;
			}
			TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			int num = tarray.Num();
			for (int i = 0; i < num; i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
				if (uskeletalMeshComponent != null && uskeletalMeshComponent.GetName() == meshComponentName)
				{
					return uskeletalMeshComponent;
				}
			}
			CharacterActorComponent characterActorComponent2 = owner.CharacterActorComponent;
			if (characterActorComponent2 == null)
			{
				return null;
			}
			return characterActorComponent2.SkeletalMesh;
		}
	}

	// Token: 0x06005118 RID: 20760 RVA: 0x000BC24C File Offset: 0x000BA44C
	[return: Nullable(2)]
	private KscNotifyCharacterContext GetCharacterContext(USkeletalMeshComponent meshComp, string actionType)
	{
		AActor owner = meshComp.GetOwner();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			this.Warn(owner, "KSC" + actionType + "行为执行失败: Owner不是TsBaseCharacter", Array.Empty<ValueTuple<string, object>>());
			return null;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			this.Warn(owner, "KSC" + actionType + "行为执行失败: 缺少角色实体", Array.Empty<ValueTuple<string, object>>());
			return null;
		}
		return new KscNotifyCharacterContext
		{
			Owner = tsBaseCharacter,
			Entity = entity
		};
	}

	// Token: 0x06005119 RID: 20761 RVA: 0x000BC2CF File Offset: 0x000BA4CF
	private void Warn([Nullable(2)] UObject obj, string log, [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] params ValueTuple<string, object>[] pairs)
	{
		KscLog.Warn(KscLog.EModule.Skill, ELogAuthor.TZQ, obj, log, pairs);
	}

	// Token: 0x0600511A RID: 20762 RVA: 0x000BC2E1 File Offset: 0x000BA4E1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyKSCSkillBehavior._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyKSCSkillBehavior.TsAnimNotifyKSCSkillBehavior_C");
		}
		return TsAnimNotifyKSCSkillBehavior._ClassPtr;
	}

	// Token: 0x0600511B RID: 20763 RVA: 0x000BC308 File Offset: 0x000BA508
	public TsAnimNotifyKSCSkillBehavior() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyKSCSkillBehavior.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600511C RID: 20764 RVA: 0x000BC330 File Offset: 0x000BA530
	public TsAnimNotifyKSCSkillBehavior(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyKSCSkillBehavior.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600511D RID: 20765 RVA: 0x000BC363 File Offset: 0x000BA563
	protected TsAnimNotifyKSCSkillBehavior(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600511E RID: 20766 RVA: 0x000BC36C File Offset: 0x000BA56C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600511F RID: 20767 RVA: 0x000BC39F File Offset: 0x000BA59F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017C3 RID: 6083
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyKSCSkillBehavior.TsAnimNotifyKSCSkillBehavior_C";

	// Token: 0x040017C4 RID: 6084
	private static IntPtr _ClassPtr;

	// Token: 0x040017C5 RID: 6085
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017C6 RID: 6086
	private static int __PropertyOffset_Action;
}
