using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.NPC.Animal;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002E15 RID: 11797
[NullableContext(2)]
[Nullable(0)]
public class AnimalPerformComponent : BasePerformComponent
{
	// Token: 0x06017DC9 RID: 97737 RVA: 0x006AE4AC File Offset: 0x006AC6AC
	public void HandlePendingDestroy()
	{
		if (!this.PendingDestroy && !this.PlayDeathAnimOnDestroy)
		{
			ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(base.Entity);
			return;
		}
		base.Entity.GetComponent<BaseTagComponent>().AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.特殊表现.销毁消失"]));
		if (this.PlayDeathAnimOnDestroy)
		{
			AnimalDeathSyncComponent component = base.Entity.GetComponent<AnimalDeathSyncComponent>();
			if (component == null)
			{
				return;
			}
			component.PlayDieAnimation();
		}
	}

	// Token: 0x06017DCA RID: 97738 RVA: 0x006AE51C File Offset: 0x006AC71C
	protected override bool OnInitData(IEntityArgs args = null)
	{
		object param = args.GetP1<CreateEntityData>().GetParam<AnimalPerformComponent>();
		AnimalComponent animalComponent = (param != null) ? (param as AnimalComponent) : null;
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.CanLookAtPlayer = (animalComponent != null && animalComponent.IsStare);
		this.MaterialMap = new Dictionary<int, string>();
		if (animalComponent != null)
		{
			ICollectAnimalConfig specialAnimalConfig = animalComponent.SpecialAnimalConfig;
			ESpecialAnimalType? especialAnimalType = (specialAnimalConfig != null) ? new ESpecialAnimalType?(specialAnimalConfig.Type) : null;
			ESpecialAnimalType especialAnimalType2 = ESpecialAnimalType.CollectAnimal;
			if (especialAnimalType.GetValueOrDefault() == especialAnimalType2 & especialAnimalType != null)
			{
				this.PartToBoneMap = new Dictionary<int, string>();
				this.PartEnableMap = new Dictionary<int, bool>();
				foreach (ICollectAnimalPartsConfig collectAnimalPartsConfig in animalComponent.SpecialAnimalConfig.PartsMap)
				{
					this.PartToBoneMap[(int)collectAnimalPartsConfig.Slot] = collectAnimalPartsConfig.Skeleton;
					Dictionary<int, bool> partEnableMap = this.PartEnableMap;
					int slot = (int)collectAnimalPartsConfig.Slot;
					int[] pbAnimalInitialPartIds = component.PbAnimalInitialPartIds;
					partEnableMap[slot] = (pbAnimalInitialPartIds != null && pbAnimalInitialPartIds.Contains((int)collectAnimalPartsConfig.Slot));
				}
			}
		}
		this.PlayDeathAnimOnDestroy = ((animalComponent != null) ? animalComponent.PlayDeathAnimOnDestroy : null).GetValueOrDefault();
		return true;
	}

	// Token: 0x06017DCB RID: 97739 RVA: 0x006AE674 File Offset: 0x006AC874
	protected unsafe override bool OnStart()
	{
		base.OnStart();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Animal, ELogAuthor.CJH, "[AnimalPerformComponent] 初始化失败 Actor Component Undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		if (this.AnimComp == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Animal;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "[AnimalPerformComponent] 初始化失败 Animation Component Undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.AnimComp.EnableSightDirect = this.CanLookAtPlayer;
		ABP_BaseAnimal_C abp_BaseAnimal_C = this.AnimComp.MainAnimInstance as ABP_BaseAnimal_C;
		if (abp_BaseAnimal_C != null)
		{
			foreach (KeyValuePair<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> keyValuePair in abp_BaseAnimal_C.材质配置)
			{
				FGameplayTag fgameplayTag;
				TSoftObjectPtr<PD_CharacterControllerData_C> tsoftObjectPtr;
				keyValuePair.Deconstruct(out fgameplayTag, out tsoftObjectPtr);
				FGameplayTag tag = fgameplayTag;
				TSoftObjectPtr<PD_CharacterControllerData_C> tsoftObjectPtr2 = tsoftObjectPtr;
				if (!tag.TagName.ToString().Contains("动物."))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Animal;
					ELogAuthor author2 = ELogAuthor.CJH;
					string message2 = "[AnimalPerformComponent] 材质GameplayTag不符合规范";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
				else
				{
					this.MaterialMap[tag.TagId()] = tsoftObjectPtr2.ToAssetPathName();
				}
			}
		}
		this.PerceptionComp = base.Entity.GetComponent<PawnPerceptionComponent>();
		if (this.PerceptionComp == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Animal;
			ELogAuthor author3 = ELogAuthor.CJH;
			string message3 = "[AnimalPerformComponent] 初始化失败 Perception Component Undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return false;
		}
		this.PerceptionComp.SetSightRange(300f);
		this.GameplayTagComp = base.Entity.GetComponent<BaseTagComponent>();
		if (this.GameplayTagComp == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Animal;
			ELogAuthor author4 = ELogAuthor.CJH;
			string message4 = "[AnimalPerformComponent] 初始化失败 GameplayTag Component Undefined";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("CreatureDataId", this.ActorComp.CreatureData.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("PlayerId", this.ActorComp.CreatureData.GetPlayerId());
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return false;
		}
		foreach (KeyValuePair<int, string> keyValuePair2 in this.MaterialMap)
		{
			this.GameplayTagComp.AddTagAddOrRemoveListener(keyValuePair2.Key, new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChange), null);
		}
		this.GameplayTagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["动物.Common.特殊表现.销毁消失"], new BaseTagComponent.TTagSwitchedCallback(this.OnDestroyDisappearTagAdd), null);
		this.GameplayTagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"], new BaseTagComponent.TTagSwitchedCallback(this.OnDyingTagAdd), null);
		this.AddEvents();
		return true;
	}

	// Token: 0x06017DCC RID: 97740 RVA: 0x006AEB5C File Offset: 0x006ACD5C
	protected override void OnActivate()
	{
		if (base.Entity.GetComponent<CreatureDataComponent>().GetEntityType() == EEntityType.Monster)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.ActorComp.SetAutonomous(true, null);
			this.AddBlurCollision();
		}
		this.UpdateAllPartsHideState();
	}

	// Token: 0x06017DCD RID: 97741 RVA: 0x006AEBAA File Offset: 0x006ACDAA
	protected override void OnTick(float delta)
	{
		if (!this.CanLookAtPlayer)
		{
			return;
		}
		if (this.PerceptionComp.IsInSightRange && this.IsInSightDirection())
		{
			this.SightTarget(Global.BaseCharacter.CharacterActorComponent);
			return;
		}
		this.SightTarget(null);
	}

	// Token: 0x06017DCE RID: 97742 RVA: 0x006AEBE4 File Offset: 0x006ACDE4
	private bool IsInSightDirection()
	{
		CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
		this.TempDirect.FromUeVector(characterActorComponent.ActorLocationProxy);
		this.TempDirect.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.TempDirect.Z = 0.0;
		this.TempDirect.Normalize(9.99999993922529E-09);
		return Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.TempDirect, this.ActorComp.ActorForwardProxy) <= 80.0;
	}

	// Token: 0x06017DCF RID: 97743 RVA: 0x006AEC76 File Offset: 0x006ACE76
	private void SightTarget(BaseActorComponent target)
	{
		if (!this.CanLookAtPlayer)
		{
			return;
		}
		this.AnimComp.SetSightTargetItem(target);
	}

	// Token: 0x06017DD0 RID: 97744 RVA: 0x006AEC90 File Offset: 0x006ACE90
	protected override bool OnEnd()
	{
		this.RemoveBlurCollision();
		this.RemoveEvents();
		foreach (KeyValuePair<int, string> keyValuePair in this.MaterialMap)
		{
			this.GameplayTagComp.RemoveTagAddOrRemoveListener(keyValuePair.Key, new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayTagChange));
		}
		this.GameplayTagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"], new BaseTagComponent.TTagSwitchedCallback(this.OnDyingTagAdd));
		return true;
	}

	// Token: 0x06017DD1 RID: 97745 RVA: 0x006AED30 File Offset: 0x006ACF30
	[NullableContext(1)]
	private void AddMaterialControllerData(string materialPath)
	{
		if (this.MaterialHandle > -1)
		{
			this.RemoveMaterialControllerData();
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(materialPath, delegate([Nullable(2)] PD_CharacterControllerData_C data, string _)
		{
			if (data == null || !data.IsValid())
			{
				return;
			}
			if (this.ActorComp != null)
			{
				TsBaseCharacter actor = this.ActorComp.Actor;
				if (actor != null && actor.IsValid())
				{
					this.MaterialHandle = this.ActorComp.Actor.CharRenderingComponent.AddMaterialControllerData(data);
				}
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06017DD2 RID: 97746 RVA: 0x006AED60 File Offset: 0x006ACF60
	private void RemoveMaterialControllerData()
	{
		if (this.MaterialHandle > -1)
		{
			this.ActorComp.Actor.CharRenderingComponent.RemoveMaterialControllerData(this.MaterialHandle);
		}
		this.MaterialHandle = -1;
	}

	// Token: 0x06017DD3 RID: 97747 RVA: 0x006AED8D File Offset: 0x006ACF8D
	private void OnDyingTagAdd(int tagId, bool gameplayTagExist)
	{
		if (!gameplayTagExist)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnAnimalDying, base.Entity);
	}

	// Token: 0x06017DD4 RID: 97748 RVA: 0x006AEDAC File Offset: 0x006ACFAC
	private void OnDestroyDisappearTagAdd(int tagId, bool gameplayTagExist)
	{
		if (!gameplayTagExist)
		{
			return;
		}
		if (this.PendingDestroy)
		{
			this.GameplayTagComp.AddTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_INVISIBILITY));
			this.ActorComp.Actor.CapsuleComponent.SetCollisionProfileName(Singleton<CharacterNameDefines>.Instance.VANISH_PAWN, true);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Entity entity = base.Entity;
				if (entity == null || !entity.Valid)
				{
					return;
				}
				ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(base.Entity);
			}, 2000f, null, null, true, 1f);
			return;
		}
		ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(base.Entity);
	}

	// Token: 0x06017DD5 RID: 97749 RVA: 0x006AEE30 File Offset: 0x006AD030
	private void OnGameplayTagChange(int tagId, bool gameplayTagExist)
	{
		string materialPath;
		if (!this.MaterialMap.TryGetValue(tagId, out materialPath))
		{
			return;
		}
		if (gameplayTagExist)
		{
			this.AddMaterialControllerData(materialPath);
			if (tagId == AnimalPerformComponent.GAMEPLAY_TAG_DISAPPEAR)
			{
				this.GameplayTagComp.AddTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_INVISIBILITY));
				this.ActorComp.Actor.CapsuleComponent.SetCollisionProfileName(Singleton<CharacterNameDefines>.Instance.VANISH_PAWN, true);
				return;
			}
		}
		else
		{
			this.RemoveMaterialControllerData();
			if (tagId == AnimalPerformComponent.GAMEPLAY_TAG_DISAPPEAR)
			{
				this.GameplayTagComp.RemoveTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_INVISIBILITY));
				this.ActorComp.Actor.CapsuleComponent.SetCollisionProfileName(Singleton<CharacterNameDefines>.Instance.PAWN, true);
			}
		}
	}

	// Token: 0x06017DD6 RID: 97750 RVA: 0x006AEEDC File Offset: 0x006AD0DC
	private void OnChangeModeFinish()
	{
		if (base.Entity.GetComponent<CreatureDataComponent>().GetEntityType() == EEntityType.Monster)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.ActorComp.SetAutonomous(true, null);
			this.AddBlurCollision();
			return;
		}
		this.RemoveBlurCollision();
	}

	// Token: 0x06017DD7 RID: 97751 RVA: 0x006AEF2C File Offset: 0x006AD12C
	[NullableContext(1)]
	private void OnFriendHit(BulletInfo bulletInfo)
	{
		if (bulletInfo.CollisionInfo.DamageId == 0L)
		{
			return;
		}
		bool flag = false;
		CreatureDataComponent component = bulletInfo.Attacker.GetComponent<CreatureDataComponent>();
		if ((component != null && component.IsRole()) || (component != null && component.IsVision()))
		{
			flag = true;
		}
		else if (component != null)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(component.GetSummonerId());
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			bool flag2;
			if (worldEntity == null)
			{
				flag2 = false;
			}
			else
			{
				CreatureDataComponent component2 = worldEntity.GetComponent<CreatureDataComponent>();
				flag2 = ((component2 != null) ? new bool?(component2.IsRole()) : null).GetValueOrDefault();
			}
			if (flag2)
			{
				flag = true;
			}
		}
		if (flag)
		{
			this.GameplayTagComp.AddTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_ON_HIT));
		}
	}

	// Token: 0x06017DD8 RID: 97752 RVA: 0x006AEFD8 File Offset: 0x006AD1D8
	[NullableContext(1)]
	private void OnAnimalDying(Entity entity)
	{
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (entity.Id == base.Entity.Id)
		{
			return;
		}
		global::Vector actorLocationProxy = entity.GetComponent<CharacterActorComponent>().ActorLocationProxy;
		this.ActorComp.ActorLocationProxy.Subtraction(actorLocationProxy, this.TempDirect);
		if (this.TempDirect.Size() > 500.0)
		{
			return;
		}
		this.GameplayTagComp.AddTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_ALERT));
	}

	// Token: 0x06017DD9 RID: 97753 RVA: 0x006AF05C File Offset: 0x006AD25C
	private void AddBlurCollision()
	{
		if (this.HaveBlurEvent)
		{
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.Valid)
		{
			TsBaseCharacter actor = this.ActorComp.Actor;
			if (actor != null && actor.IsValid())
			{
				if (!UKuroStaticLibrary.IsObjectClassByName(this.ActorComp.Actor, Singleton<CharacterNameDefines>.Instance.BP_COMMONPET))
				{
					return;
				}
				UBoxComponent blurCollision = (this.ActorComp.Actor as BP_CommonPet_C).BlurCollision;
				blurCollision.OnComponentBeginOverlap.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int, bool, FHitResult>(this.OnBlurBegin));
				blurCollision.OnComponentEndOverlap.Add(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int>(this.OnBlurEnd));
				this.HaveBlurEvent = true;
				return;
			}
		}
	}

	// Token: 0x06017DDA RID: 97754 RVA: 0x006AF10C File Offset: 0x006AD30C
	private void RemoveBlurCollision()
	{
		if (!this.HaveBlurEvent)
		{
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.Valid)
		{
			TsBaseCharacter actor = this.ActorComp.Actor;
			if (actor != null && actor.IsValid())
			{
				if (!UKuroStaticLibrary.IsObjectClassByName(this.ActorComp.Actor, Singleton<CharacterNameDefines>.Instance.BP_COMMONPET))
				{
					return;
				}
				UBoxComponent blurCollision = (this.ActorComp.Actor as BP_CommonPet_C).BlurCollision;
				blurCollision.OnComponentBeginOverlap.Remove(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int, bool, FHitResult>(this.OnBlurBegin));
				blurCollision.OnComponentEndOverlap.Remove(new Action<UPrimitiveComponent, AActor, UPrimitiveComponent, int>(this.OnBlurEnd));
				this.HaveBlurEvent = false;
				return;
			}
		}
	}

	// Token: 0x06017DDB RID: 97755 RVA: 0x006AF1BC File Offset: 0x006AD3BC
	private void OnBlurBegin(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp, int otherBodyIndex, bool bFromSweep, [Nullable(1)] FHitResult sweepResult)
	{
		if (this.IsAnotherClientPlayer(otherActor) && !this.GameplayTagComp.HasTag(AnimalPerformComponent.GAMEPLAY_TAG_BLUR))
		{
			this.GameplayTagComp.AddTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_BLUR));
		}
	}

	// Token: 0x06017DDC RID: 97756 RVA: 0x006AF1EE File Offset: 0x006AD3EE
	private void OnBlurEnd(UPrimitiveComponent overlappedComponent, AActor otherActor, UPrimitiveComponent otherComp, int otherBodyIndex)
	{
		if (this.IsAnotherClientPlayer(otherActor) && this.GameplayTagComp.HasTag(AnimalPerformComponent.GAMEPLAY_TAG_BLUR))
		{
			this.GameplayTagComp.RemoveTag(new int?(AnimalPerformComponent.GAMEPLAY_TAG_BLUR));
		}
	}

	// Token: 0x06017DDD RID: 97757 RVA: 0x006AF224 File Offset: 0x006AD424
	public unsafe void SetUiOpenPerformance(EUiViewName uiViewName, int boardId)
	{
		AnimalStateMachineComponent component = base.Entity.GetComponent<AnimalStateMachineComponent>();
		if (component.CurrentState() == EAnimalEcologicalState.系统UI)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Animal;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "开启系统UI失败，系统UI已开启";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ConfigID", this.ActorComp.CreatureData.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("已开启系统UI", uiViewName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		(component.GetState(EAnimalPerformState.SystemUi) as AnimalPerformSystemUiState).SystemUiViewName = new EUiViewName?(uiViewName);
		component.SwitchState(EAnimalPerformState.SystemUi);
	}

	// Token: 0x06017DDE RID: 97758 RVA: 0x006AF2D4 File Offset: 0x006AD4D4
	[NullableContext(1)]
	public void InitFeedingAnimalConfig(int[] itemIds, string[] gameplayTags)
	{
		(base.Entity.GetComponent<AnimalStateMachineComponent>().GetState(EAnimalPerformState.SystemUi) as AnimalPerformSystemUiState).InitFeedingAnimalConfig(itemIds, gameplayTags);
	}

	// Token: 0x06017DDF RID: 97759 RVA: 0x006AF2F4 File Offset: 0x006AD4F4
	private bool IsAnotherClientPlayer(AActor otherActor)
	{
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(otherActor, false);
		if (entityByActor == null || !entityByActor.Valid)
		{
			return false;
		}
		if (!entityByActor.Entity.GetComponent<CreatureDataComponent>().IsRole())
		{
			return false;
		}
		CharacterActorComponent component = entityByActor.Entity.GetComponent<CharacterActorComponent>();
		return component != null && component.Valid && !component.IsAutonomousProxy;
	}

	// Token: 0x06017DE0 RID: 97760 RVA: 0x006AF358 File Offset: 0x006AD558
	private void AddEvents()
	{
		if (!this.EventsInited)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<BulletInfo>(base.Entity, EEventName.BulletHitSpecialCharacter, new Action<BulletInfo>(this.OnFriendHit));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
			Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnAnimalDying, new Action<Entity>(this.OnAnimalDying));
			this.EventsInited = true;
		}
	}

	// Token: 0x06017DE1 RID: 97761 RVA: 0x006AF3D0 File Offset: 0x006AD5D0
	private void RemoveEvents()
	{
		if (this.EventsInited)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<BulletInfo>(base.Entity, EEventName.BulletHitSpecialCharacter, new Action<BulletInfo>(this.OnFriendHit));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
			Singleton<EventSystem>.Instance.Remove<Entity>(EEventName.OnAnimalDying, new Action<Entity>(this.OnAnimalDying));
			this.EventsInited = false;
		}
	}

	// Token: 0x06017DE2 RID: 97762 RVA: 0x006AF448 File Offset: 0x006AD648
	public bool GetIsPartShow(int partId)
	{
		Dictionary<int, bool> partEnableMap = this.PartEnableMap;
		bool flag;
		return partEnableMap != null && partEnableMap.TryGetValue(partId, out flag) && flag;
	}

	// Token: 0x06017DE3 RID: 97763 RVA: 0x006AF470 File Offset: 0x006AD670
	private void UpdateAllPartsHideState()
	{
		if (this.PartEnableMap == null || this.PartToBoneMap == null)
		{
			return;
		}
		foreach (KeyValuePair<int, bool> keyValuePair in this.PartEnableMap)
		{
			int key = keyValuePair.Key;
			bool value = keyValuePair.Value;
			string key2;
			if (this.PartToBoneMap.TryGetValue(key, out key2))
			{
				FName? dynamicFName = FNameUtil.GetDynamicFName(key2);
				if (dynamicFName != null)
				{
					this.SetHideBone(dynamicFName.Value, !value);
				}
			}
		}
	}

	// Token: 0x06017DE4 RID: 97764 RVA: 0x006AF510 File Offset: 0x006AD710
	public void ShowPart(int partId)
	{
		Dictionary<int, string> partToBoneMap = this.PartToBoneMap;
		string key;
		if (partToBoneMap != null && partToBoneMap.TryGetValue(partId, out key))
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(key);
			if (dynamicFName != null)
			{
				this.SetHideBone(dynamicFName.Value, false);
				if (this.PartEnableMap != null)
				{
					this.PartEnableMap[partId] = true;
				}
			}
		}
	}

	// Token: 0x06017DE5 RID: 97765 RVA: 0x006AF568 File Offset: 0x006AD768
	public void HidePart(int partId)
	{
		Dictionary<int, string> partToBoneMap = this.PartToBoneMap;
		string key;
		if (partToBoneMap != null && partToBoneMap.TryGetValue(partId, out key))
		{
			FName? dynamicFName = FNameUtil.GetDynamicFName(key);
			if (dynamicFName != null)
			{
				this.SetHideBone(dynamicFName.Value, true);
				if (this.PartEnableMap != null)
				{
					this.PartEnableMap[partId] = false;
				}
			}
		}
	}

	// Token: 0x06017DE6 RID: 97766 RVA: 0x006AF5C0 File Offset: 0x006AD7C0
	private void SetHideBone(FName boneName, bool hide)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		bool flag;
		if (actorComp == null)
		{
			flag = true;
		}
		else
		{
			TsBaseCharacter actor = actorComp.Actor;
			bool? flag2;
			if (actor == null)
			{
				flag2 = null;
			}
			else
			{
				USkeletalMeshComponent mesh = actor.Mesh;
				flag2 = ((mesh != null) ? new bool?(mesh.IsValid()) : null);
			}
			bool? flag3 = flag2;
			flag = !flag3.GetValueOrDefault();
		}
		if (flag || boneName == null)
		{
			return;
		}
		if (this.ActorComp.Actor.Mesh.IsBoneHiddenByName(boneName) == hide)
		{
			return;
		}
		if (hide)
		{
			this.ActorComp.Actor.Mesh.HideBoneByName(boneName, EPhysBodyOp.PBO_None);
			return;
		}
		this.ActorComp.Actor.Mesh.UnHideBoneByName(boneName);
	}

	// Token: 0x06017DE7 RID: 97767 RVA: 0x006AF674 File Offset: 0x006AD874
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		AnimalPerformComponent animalPerformComponent = (AnimalPerformComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (animalPerformComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerceptionComp"))
		{
			if (animalPerformComponent.PerceptionComp == null)
			{
				this.PerceptionComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnPerceptionComponent>(this.PerceptionComp), "PerceptionComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("GameplayTagComp"))
		{
			if (animalPerformComponent.GameplayTagComp == null)
			{
				this.GameplayTagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.GameplayTagComp), "GameplayTagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CanLookAtPlayer"))
		{
			this.CanLookAtPlayer = animalPerformComponent.CanLookAtPlayer;
		}
		if (base.CanResetComponentProperty("TempDirect") && animalPerformComponent.TempDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempDirect), "TempDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MaterialHandle"))
		{
			this.MaterialHandle = animalPerformComponent.MaterialHandle;
		}
		if (base.CanResetComponentProperty("EventsInited"))
		{
			this.EventsInited = animalPerformComponent.EventsInited;
		}
		if (base.CanResetComponentProperty("MaterialMap"))
		{
			if (animalPerformComponent.MaterialMap == null)
			{
				this.MaterialMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, string>>(this.MaterialMap), "MaterialMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartToBoneMap"))
		{
			if (animalPerformComponent.PartToBoneMap == null)
			{
				this.PartToBoneMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, string>>(this.PartToBoneMap), "PartToBoneMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartEnableMap"))
		{
			if (animalPerformComponent.PartEnableMap == null)
			{
				this.PartEnableMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, bool>>(this.PartEnableMap), "PartEnableMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HaveBlurEvent"))
		{
			this.HaveBlurEvent = animalPerformComponent.HaveBlurEvent;
		}
		if (base.CanResetComponentProperty("PendingDestroy"))
		{
			this.PendingDestroy = animalPerformComponent.PendingDestroy;
		}
		if (base.CanResetComponentProperty("PlayDeathAnimOnDestroy"))
		{
			this.PlayDeathAnimOnDestroy = animalPerformComponent.PlayDeathAnimOnDestroy;
		}
		return true;
	}

	// Token: 0x0400B913 RID: 47379
	private const int DEFAULT_SIGHT_RANGE = 300;

	// Token: 0x0400B914 RID: 47380
	private const int SIGHT_OPEN_DEGREE = 80;

	// Token: 0x0400B915 RID: 47381
	private static readonly int GAMEPLAY_TAG_DISAPPEAR = GameplayTagDefine.EGameplayTagId["动物.Common.特殊表现.消失"];

	// Token: 0x0400B916 RID: 47382
	private static readonly int GAMEPLAY_TAG_BLUR = GameplayTagDefine.EGameplayTagId["动物.Common.特殊表现.虚化"];

	// Token: 0x0400B917 RID: 47383
	private const int DESTROY_DISAPPEAR_TIME = 2000;

	// Token: 0x0400B918 RID: 47384
	private static readonly int GAMEPLAY_TAG_INVISIBILITY = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身.不被子弹命中"];

	// Token: 0x0400B919 RID: 47385
	private static readonly int GAMEPLAY_TAG_ON_HIT = GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.受到攻击"];

	// Token: 0x0400B91A RID: 47386
	private const int ALERT_RANGE = 500;

	// Token: 0x0400B91B RID: 47387
	private static readonly int GAMEPLAY_TAG_ALERT = GameplayTagDefine.EGameplayTagId["动物.Common.通知标识.警觉"];

	// Token: 0x0400B91C RID: 47388
	private CharacterActorComponent ActorComp;

	// Token: 0x0400B91D RID: 47389
	private PawnPerceptionComponent PerceptionComp;

	// Token: 0x0400B91E RID: 47390
	private BaseTagComponent GameplayTagComp;

	// Token: 0x0400B91F RID: 47391
	private bool CanLookAtPlayer;

	// Token: 0x0400B920 RID: 47392
	[Nullable(1)]
	private readonly global::Vector TempDirect = global::Vector.Create();

	// Token: 0x0400B921 RID: 47393
	private int MaterialHandle = -1;

	// Token: 0x0400B922 RID: 47394
	private bool EventsInited;

	// Token: 0x0400B923 RID: 47395
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> MaterialMap;

	// Token: 0x0400B924 RID: 47396
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> PartToBoneMap;

	// Token: 0x0400B925 RID: 47397
	private Dictionary<int, bool> PartEnableMap;

	// Token: 0x0400B926 RID: 47398
	private bool HaveBlurEvent;

	// Token: 0x0400B927 RID: 47399
	public bool PendingDestroy = true;

	// Token: 0x0400B928 RID: 47400
	public bool PlayDeathAnimOnDestroy;
}
