using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Tools;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE4 RID: 3556
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillEvent.TsAnimNotifyReSkillEvent_C")]
public class TsAnimNotifyReSkillEvent : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000556 RID: 1366
	// (get) Token: 0x060051C6 RID: 20934 RVA: 0x000BE528 File Offset: 0x000BC728
	// (set) Token: 0x060051C7 RID: 20935 RVA: 0x000BE53C File Offset: 0x000BC73C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 子弹数据名
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹数据名);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹数据名) = value;
		}
	}

	// Token: 0x17000557 RID: 1367
	// (get) Token: 0x060051C8 RID: 20936 RVA: 0x000BE551 File Offset: 0x000BC751
	// (set) Token: 0x060051C9 RID: 20937 RVA: 0x000BE565 File Offset: 0x000BC765
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 子弹出生位置偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹出生位置偏移);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹出生位置偏移) = value;
		}
	}

	// Token: 0x17000558 RID: 1368
	// (get) Token: 0x060051CA RID: 20938 RVA: 0x000BE57A File Offset: 0x000BC77A
	// (set) Token: 0x060051CB RID: 20939 RVA: 0x000BE58E File Offset: 0x000BC78E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FRotator 子弹初速度偏移
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹初速度偏移);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹初速度偏移) = value;
		}
	}

	// Token: 0x17000559 RID: 1369
	// (get) Token: 0x060051CC RID: 20940 RVA: 0x000BE5A4 File Offset: 0x000BC7A4
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> 子弹id数组
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._子弹id数组) == null)
			{
				result = (this._子弹id数组 = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹id数组, this));
			}
			return result;
		}
	}

	// Token: 0x1700055A RID: 1370
	// (get) Token: 0x060051CD RID: 20941 RVA: 0x000BE5E0 File Offset: 0x000BC7E0
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FVector> 子弹出生位置偏移数组
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FVector> result;
			if ((result = this._子弹出生位置偏移数组) == null)
			{
				result = (this._子弹出生位置偏移数组 = new TArray<FVector>(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹出生位置偏移数组, this));
			}
			return result;
		}
	}

	// Token: 0x1700055B RID: 1371
	// (get) Token: 0x060051CE RID: 20942 RVA: 0x000BE61C File Offset: 0x000BC81C
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<FRotator> 子弹初速度偏移数组
	{
		get
		{
			base.FastCheckIsValid();
			TArray<FRotator> result;
			if ((result = this._子弹初速度偏移数组) == null)
			{
				result = (this._子弹初速度偏移数组 = new TArray<FRotator>(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_子弹初速度偏移数组, this));
			}
			return result;
		}
	}

	// Token: 0x1700055C RID: 1372
	// (get) Token: 0x060051CF RID: 20943 RVA: 0x000BE655 File Offset: 0x000BC855
	// (set) Token: 0x060051D0 RID: 20944 RVA: 0x000BE665 File Offset: 0x000BC865
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 使用子弹id数组
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_使用子弹id数组) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_使用子弹id数组) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700055D RID: 1373
	// (get) Token: 0x060051D1 RID: 20945 RVA: 0x000BE676 File Offset: 0x000BC876
	// (set) Token: 0x060051D2 RID: 20946 RVA: 0x000BE686 File Offset: 0x000BC886
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 使用召唤者子弹
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_使用召唤者子弹) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_使用召唤者子弹) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700055E RID: 1374
	// (get) Token: 0x060051D3 RID: 20947 RVA: 0x000BE698 File Offset: 0x000BC898
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<float> 随机子弹权重数组
	{
		get
		{
			base.FastCheckIsValid();
			TArray<float> result;
			if ((result = this._随机子弹权重数组) == null)
			{
				result = (this._随机子弹权重数组 = new TArray<float>(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_随机子弹权重数组, this));
			}
			return result;
		}
	}

	// Token: 0x1700055F RID: 1375
	// (get) Token: 0x060051D4 RID: 20948 RVA: 0x000BE6D1 File Offset: 0x000BC8D1
	// (set) Token: 0x060051D5 RID: 20949 RVA: 0x000BE6E1 File Offset: 0x000BC8E1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 传入当前实体位置
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_传入当前实体位置) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_传入当前实体位置) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000560 RID: 1376
	// (get) Token: 0x060051D6 RID: 20950 RVA: 0x000BE6F2 File Offset: 0x000BC8F2
	// (set) Token: 0x060051D7 RID: 20951 RVA: 0x000BE706 File Offset: 0x000BC906
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 骨骼名字
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_骨骼名字);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_骨骼名字) = value;
		}
	}

	// Token: 0x17000561 RID: 1377
	// (get) Token: 0x060051D8 RID: 20952 RVA: 0x000BE71B File Offset: 0x000BC91B
	// (set) Token: 0x060051D9 RID: 20953 RVA: 0x000BE72F File Offset: 0x000BC92F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName 指定Tag的Component
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_指定Tag的Component);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_指定Tag的Component) = value;
		}
	}

	// Token: 0x17000562 RID: 1378
	// (get) Token: 0x060051DA RID: 20954 RVA: 0x000BE744 File Offset: 0x000BC944
	// (set) Token: 0x060051DB RID: 20955 RVA: 0x000BE754 File Offset: 0x000BC954
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 通知实体子弹动画帧事件
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_通知实体子弹动画帧事件) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyReSkillEvent.__PropertyOffset_通知实体子弹动画帧事件) = (value ? 1 : 0);
		}
	}

	// Token: 0x060051DC RID: 20956 RVA: 0x000BE768 File Offset: 0x000BC968
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
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

	// Token: 0x060051DD RID: 20957 RVA: 0x000BE808 File Offset: 0x000BCA08
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase animation)
	{
		AActor owner = MeshComp.GetOwner();
		if (owner is TsBaseCharacter || owner is TsBaseVehicle)
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			Entity entity;
			if ((entity = ((tsBaseCharacter != null) ? tsBaseCharacter.GetEntityNoBlueprint() : null)) == null)
			{
				TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
				entity = ((tsBaseVehicle != null) ? tsBaseVehicle.GetEntityNoBlueprint() : null);
			}
			Entity entity2 = entity;
			if (entity2 == null || !entity2.Valid)
			{
				return false;
			}
			BaseBuffComponent component = entity2.GetComponent<BaseBuffComponent>();
			long? preContextId = (component != null) ? component.CreateAnimNotifyContent(animation.GetName(), base.exportIndex) : null;
			FTransformDouble initTransform = this.GetInitTransform(owner);
			if (this.使用召唤者子弹)
			{
				long summonerId = entity2.GetComponent<CreatureDataComponent>().GetSummonerId();
				if (summonerId <= 0L)
				{
					return false;
				}
				EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(summonerId);
				entity2 = ((entity3 != null) ? entity3.Entity : null);
				owner = entity2.GetComponent<CharacterActorComponent>().Actor;
				if (entity2 == null || !entity2.Valid)
				{
					return false;
				}
				if (!(owner is TsBaseCharacter))
				{
					return false;
				}
			}
			BaseSkillComponent component2 = entity2.GetComponent<BaseSkillComponent>();
			if (component2 == null || !component2.Valid)
			{
				return false;
			}
			int currentMontageCorrespondingSkillId = component2.GetCurrentMontageCorrespondingSkillId();
			int skillId = (currentMontageCorrespondingSkillId != 0) ? currentMontageCorrespondingSkillId : component2.GetSkillIdWithGroupId(1);
			FVectorDouble? extraTargetLocation = component2.GetExtraTargetLocation(skillId);
			if (this.使用子弹id数组)
			{
				int num = this.子弹id数组.Num();
				int randomIndex = this.GetRandomIndex();
				int num2 = this.子弹出生位置偏移数组.Num();
				int num3 = this.子弹初速度偏移数组.Num();
				if (randomIndex >= 0 && randomIndex < num)
				{
					if (!this.CanCreateBullet(owner, animation, randomIndex))
					{
						return false;
					}
					FVector? locationOffset = null;
					FRotator? beginRotatorOffset = null;
					if (num2 > randomIndex)
					{
						locationOffset = new FVector?(this.子弹出生位置偏移数组.Get(randomIndex));
					}
					if (num3 > randomIndex)
					{
						beginRotatorOffset = new FRotator?(this.子弹初速度偏移数组.Get(randomIndex));
					}
					if (this.通知实体子弹动画帧事件)
					{
						Singleton<EventSystem>.Instance.EmitWithTarget(entity2, EEventName.PreBulletCreateFromAnimNotify);
					}
					int p = this.CreateBulletFromAN(entity2, this.子弹id数组.Get(randomIndex), new FTransformDouble?(initTransform), skillId, false, preContextId, extraTargetLocation, locationOffset, beginRotatorOffset);
					if (this.通知实体子弹动画帧事件)
					{
						Singleton<EventSystem>.Instance.EmitWithTarget<int>(entity2, EEventName.PostBulletCreateFromAnimNotify, p);
					}
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						if (this.CanCreateBullet(owner, animation, i))
						{
							FVector? locationOffset2 = null;
							FRotator? beginRotatorOffset2 = null;
							if (num2 > i)
							{
								locationOffset2 = new FVector?(this.子弹出生位置偏移数组.Get(i));
							}
							if (num3 > i)
							{
								beginRotatorOffset2 = new FRotator?(this.子弹初速度偏移数组.Get(i));
							}
							if (this.通知实体子弹动画帧事件)
							{
								Singleton<EventSystem>.Instance.EmitWithTarget(entity2, EEventName.PreBulletCreateFromAnimNotify);
							}
							int p2 = this.CreateBulletFromAN(entity2, this.子弹id数组.Get(i), new FTransformDouble?(initTransform), skillId, false, preContextId, extraTargetLocation, locationOffset2, beginRotatorOffset2);
							if (this.通知实体子弹动画帧事件)
							{
								Singleton<EventSystem>.Instance.EmitWithTarget<int>(entity2, EEventName.PostBulletCreateFromAnimNotify, p2);
							}
						}
					}
				}
			}
			else
			{
				if (!this.CanCreateBullet(owner, animation, 0))
				{
					return false;
				}
				if (this.通知实体子弹动画帧事件)
				{
					Singleton<EventSystem>.Instance.EmitWithTarget(entity2, EEventName.PreBulletCreateFromAnimNotify);
				}
				int p3 = this.CreateBulletFromAN(entity2, this.子弹数据名.ToString(), new FTransformDouble?(initTransform), skillId, false, preContextId, extraTargetLocation, new FVector?(this.子弹出生位置偏移), new FRotator?(this.子弹初速度偏移));
				if (this.通知实体子弹动画帧事件)
				{
					Singleton<EventSystem>.Instance.EmitWithTarget<int>(entity2, EEventName.PostBulletCreateFromAnimNotify, p3);
				}
			}
			return true;
		}
		else
		{
			if (this.使用子弹id数组 ? (this.子弹id数组.Num() <= 0) : FNameUtil.IsNothing(this.子弹数据名))
			{
				return false;
			}
			BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(owner.GetWorld());
			if (worldType != BP_EWorldType.Editor && worldType != BP_EWorldType.EditorPreview)
			{
				return false;
			}
			UObject outerObject = UKismetSystemLibrary.GetOuterObject(this);
			string path = UKismetSystemLibrary.GetPathName(outerObject);
			Singleton<ResourceSystem>.Instance.LoadTypeAsync(EBpTypeName.BPL_BulletPreview.ToEnumString(), delegate
			{
				if (!this.使用子弹id数组)
				{
					AActor aactor = null;
					BPL_BulletPreview_C.ShowBulletPreview(path, this.子弹数据名, owner, MeshComp, owner.GetWorld(), ref aactor);
					return;
				}
				TArray<string> 子弹id数组 = this.子弹id数组;
				int num4 = 子弹id数组.Num();
				int randomIndex2 = this.GetRandomIndex();
				if (randomIndex2 >= 0 && randomIndex2 < num4)
				{
					AActor aactor2 = null;
					BPL_BulletPreview_C.ShowBulletPreview(path, new FName(子弹id数组.Get(randomIndex2)), owner, MeshComp, owner.GetWorld(), ref aactor2);
					return;
				}
				for (int j = 0; j < num4; j++)
				{
					AActor aactor3 = null;
					BPL_BulletPreview_C.ShowBulletPreview(path, new FName(子弹id数组.Get(j)), owner, MeshComp, owner.GetWorld(), ref aactor3);
				}
			}, "js_undefined");
			return false;
		}
	}

	// Token: 0x060051DE RID: 20958 RVA: 0x000BEC60 File Offset: 0x000BCE60
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

	// Token: 0x060051DF RID: 20959 RVA: 0x000BECDB File Offset: 0x000BCEDB
	protected override string GetNotifyName_Implementation()
	{
		return "添加子弹";
	}

	// Token: 0x060051E0 RID: 20960 RVA: 0x000BECE4 File Offset: 0x000BCEE4
	private FTransformDouble GetInitTransform(AActor actor)
	{
		if (!this.传入当前实体位置)
		{
			return new FTransformDouble();
		}
		USceneComponent usceneComponent = null;
		if (!FNameUtil.IsNothing(this.指定Tag的Component))
		{
			TArray<UActorComponent> componentsByTag = actor.GetComponentsByTag(USceneComponent.StaticClass(), this.指定Tag的Component);
			if (componentsByTag.Num() > 0)
			{
				usceneComponent = (componentsByTag.Get(0) as USceneComponent);
			}
		}
		else
		{
			TsBaseCharacter tsBaseCharacter = actor as TsBaseCharacter;
			USkeletalMeshComponent uskeletalMeshComponent;
			if ((uskeletalMeshComponent = ((tsBaseCharacter != null) ? tsBaseCharacter.Mesh : null)) == null)
			{
				TsBaseVehicle tsBaseVehicle = actor as TsBaseVehicle;
				uskeletalMeshComponent = ((tsBaseVehicle != null) ? tsBaseVehicle.Mesh : null);
			}
			usceneComponent = uskeletalMeshComponent;
		}
		if (usceneComponent != null && usceneComponent.IsValid())
		{
			if (FNameUtil.IsNothing(this.骨骼名字))
			{
				return usceneComponent.D_K2_GetComponentToWorld();
			}
			if (usceneComponent.DoesSocketExist(this.骨骼名字))
			{
				return usceneComponent.D_GetSocketTransform(this.骨骼名字, ERelativeTransformSpace.RTS_World);
			}
		}
		TsBaseCharacter tsBaseCharacter2 = actor as TsBaseCharacter;
		if (tsBaseCharacter2 == null)
		{
			return (actor as TsBaseVehicle).D_GetTransform();
		}
		return tsBaseCharacter2.D_GetTransform();
	}

	// Token: 0x060051E1 RID: 20961 RVA: 0x000BEDBC File Offset: 0x000BCFBC
	private int GetRandomIndex()
	{
		int num = this.随机子弹权重数组.Num();
		if (num <= 0)
		{
			return -1;
		}
		if (num != this.子弹id数组.Num())
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HXY, "随机子弹权重数量对不上！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return -1;
		}
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			float num3 = this.随机子弹权重数组.Get(i);
			if (num3 > 0f)
			{
				num2 += num3;
			}
		}
		float num4 = (float)(new Random().NextDouble() * (double)num2);
		for (int j = 0; j < num; j++)
		{
			float num5 = this.随机子弹权重数组.Get(j);
			if (num5 > 0f)
			{
				num4 -= num5;
				if (num4 <= 0f)
				{
					return j;
				}
			}
		}
		return -1;
	}

	// Token: 0x060051E2 RID: 20962 RVA: 0x000BEE82 File Offset: 0x000BD082
	protected virtual bool CanCreateBullet(AActor owner, UAnimSequenceBase animation, int index)
	{
		return true;
	}

	// Token: 0x060051E3 RID: 20963 RVA: 0x000BEE88 File Offset: 0x000BD088
	protected virtual int CreateBulletFromAN(Entity ownerEntity, string bulletRowName, FTransformDouble? initialTransform, int skillId, bool needSync, long? preContextId, FVectorDouble? targetLocation = null, FVector? locationOffset = null, FRotator? beginRotatorOffset = null)
	{
		long? skillContextId = BulletUtil.GetSkillContextId(ownerEntity, skillId);
		BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
		bulletCreateParams.SkillId = skillId;
		bulletCreateParams.SkillContextId = new long?(skillContextId.GetValueOrDefault());
		bulletCreateParams.SyncType = (needSync ? EBulletSyncType.SyncCreate : EBulletSyncType.Local);
		bulletCreateParams.InitTargetLocation = targetLocation;
		bulletCreateParams.LocationOffset = locationOffset;
		bulletCreateParams.BeginRotatorOffset = beginRotatorOffset;
		BaseSkillComponent component = ownerEntity.GetComponent<BaseSkillComponent>();
		ISkillBattleContext battleContext;
		if (component == null)
		{
			battleContext = null;
		}
		else
		{
			Skill skill = component.GetSkill(skillId);
			battleContext = ((skill != null) ? skill.BattleContext : null);
		}
		bulletCreateParams.BattleContext = battleContext;
		BulletController.BulletCreateParams bulletCreateParams2 = bulletCreateParams;
		BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(ownerEntity, bulletRowName, initialTransform, bulletCreateParams2, preContextId, EBulletCreateSource.Skill);
		if (bulletEntity == null)
		{
			return 0;
		}
		return bulletEntity.Id;
	}

	// Token: 0x060051E4 RID: 20964 RVA: 0x000BEF26 File Offset: 0x000BD126
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyReSkillEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillEvent.TsAnimNotifyReSkillEvent_C");
		}
		return TsAnimNotifyReSkillEvent._ClassPtr;
	}

	// Token: 0x060051E5 RID: 20965 RVA: 0x000BEF4C File Offset: 0x000BD14C
	public TsAnimNotifyReSkillEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyReSkillEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060051E6 RID: 20966 RVA: 0x000BEF74 File Offset: 0x000BD174
	public TsAnimNotifyReSkillEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyReSkillEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060051E7 RID: 20967 RVA: 0x000BEFA7 File Offset: 0x000BD1A7
	protected TsAnimNotifyReSkillEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060051E8 RID: 20968 RVA: 0x000BEFB0 File Offset: 0x000BD1B0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060051E9 RID: 20969 RVA: 0x000BEFE3 File Offset: 0x000BD1E3
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001806 RID: 6150
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyReSkillEvent.TsAnimNotifyReSkillEvent_C";

	// Token: 0x04001807 RID: 6151
	private static IntPtr _ClassPtr;

	// Token: 0x04001808 RID: 6152
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001809 RID: 6153
	private static int __PropertyOffset_子弹数据名;

	// Token: 0x0400180A RID: 6154
	private static int __PropertyOffset_子弹出生位置偏移;

	// Token: 0x0400180B RID: 6155
	private static int __PropertyOffset_子弹初速度偏移;

	// Token: 0x0400180C RID: 6156
	private static int __PropertyOffset_子弹id数组;

	// Token: 0x0400180D RID: 6157
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _子弹id数组;

	// Token: 0x0400180E RID: 6158
	private static int __PropertyOffset_子弹出生位置偏移数组;

	// Token: 0x0400180F RID: 6159
	[Nullable(2)]
	private TArray<FVector> _子弹出生位置偏移数组;

	// Token: 0x04001810 RID: 6160
	private static int __PropertyOffset_子弹初速度偏移数组;

	// Token: 0x04001811 RID: 6161
	[Nullable(2)]
	private TArray<FRotator> _子弹初速度偏移数组;

	// Token: 0x04001812 RID: 6162
	private static int __PropertyOffset_使用子弹id数组;

	// Token: 0x04001813 RID: 6163
	private static int __PropertyOffset_使用召唤者子弹;

	// Token: 0x04001814 RID: 6164
	private static int __PropertyOffset_随机子弹权重数组;

	// Token: 0x04001815 RID: 6165
	[Nullable(2)]
	private TArray<float> _随机子弹权重数组;

	// Token: 0x04001816 RID: 6166
	private static int __PropertyOffset_传入当前实体位置;

	// Token: 0x04001817 RID: 6167
	private static int __PropertyOffset_骨骼名字;

	// Token: 0x04001818 RID: 6168
	private static int __PropertyOffset_指定Tag的Component;

	// Token: 0x04001819 RID: 6169
	private static int __PropertyOffset_通知实体子弹动画帧事件;
}
