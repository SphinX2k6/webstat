using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using UnrealEngine;

// Token: 0x02003076 RID: 12406
[NullableContext(2)]
[Nullable(0)]
public class CharacterWalkOnAirComponent : EntityComponent
{
	// Token: 0x0601981A RID: 104474 RVA: 0x007638A4 File Offset: 0x00761AA4
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		this.BaseCharacter = this.ActorComp.Actor;
		this.TagComp = component;
		CharacterMoveComponent component2 = base.Entity.GetComponent<CharacterMoveComponent>();
		if (component2 == null || !component2.Valid)
		{
			return false;
		}
		this.RegisterEvent();
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		return true;
	}

	// Token: 0x0601981B RID: 104475 RVA: 0x00763930 File Offset: 0x00761B30
	private void RegisterEvent()
	{
		this.OnWalkOnAirTagNewOrRemove = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中行走"]), new BaseTagComponent.TTagSwitchedCallback(this.OnStateTagsChanged), null);
		this.OnForegroundTagNewOrRemove = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]), new BaseTagComponent.TTagSwitchedCallback(this.OnForegroundTagsChanged), null);
		this.OnSkillTagNewOrRemove = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]), new BaseTagComponent.TTagSwitchedCallback(this.OnDoSkill), null);
		Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
	}

	// Token: 0x0601981C RID: 104476 RVA: 0x00763A55 File Offset: 0x00761C55
	private void OnDoSkill(int tagId, bool tagExists)
	{
		if (tagExists && this.IsWalkOnAir)
		{
			this.SetIsWalkOnAir(false);
		}
	}

	// Token: 0x0601981D RID: 104477 RVA: 0x00763A6C File Offset: 0x00761C6C
	private void UnregisterEvent()
	{
		ITagTask onWalkOnAirTagNewOrRemove = this.OnWalkOnAirTagNewOrRemove;
		if (onWalkOnAirTagNewOrRemove != null)
		{
			onWalkOnAirTagNewOrRemove.EndTask();
		}
		ITagTask onForegroundTagNewOrRemove = this.OnForegroundTagNewOrRemove;
		if (onForegroundTagNewOrRemove != null)
		{
			onForegroundTagNewOrRemove.EndTask();
		}
		ITagTask onSkillTagNewOrRemove = this.OnSkillTagNewOrRemove;
		if (onSkillTagNewOrRemove != null)
		{
			onSkillTagNewOrRemove.EndTask();
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
	}

	// Token: 0x0601981E RID: 104478 RVA: 0x00763B2E File Offset: 0x00761D2E
	private void OnStateTagsChanged(int tagId, bool tagExists)
	{
		this.IsActive = tagExists;
		if (!this.IsActive)
		{
			this.SetIsWalkOnAir(false);
		}
	}

	// Token: 0x0601981F RID: 104479 RVA: 0x00763B46 File Offset: 0x00761D46
	private void OnForegroundTagsChanged(int tagId, bool tagExists)
	{
		if (!tagExists)
		{
			this.SetIsWalkOnAir(false);
		}
	}

	// Token: 0x06019820 RID: 104480 RVA: 0x00763B52 File Offset: 0x00761D52
	private void OnPositionStateChanged(ECharPositionState oldPositionState, ECharPositionState newPositionState)
	{
		if (newPositionState == ECharPositionState.Ground && this.IsWalkOnAir)
		{
			this.StateComp.SetPositionSubState(ECharPositionSubState.WalkOnAir, false);
		}
	}

	// Token: 0x06019821 RID: 104481 RVA: 0x00763B6C File Offset: 0x00761D6C
	[NullableContext(1)]
	private void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
	{
		if (other == null || !other.Valid)
		{
			return;
		}
		this.IsActive = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.空中行走"]);
		if (!this.IsActive)
		{
			this.SetIsWalkOnAir(false);
		}
	}

	// Token: 0x06019822 RID: 104482 RVA: 0x00763BBA File Offset: 0x00761DBA
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		if (!this.IsActive || !this.IsWalkOnAir)
		{
			return;
		}
		this.StateComp.SetPositionSubState(ECharPositionSubState.WalkOnAir, false);
	}

	// Token: 0x06019823 RID: 104483 RVA: 0x00763BDC File Offset: 0x00761DDC
	private void OnCharacterMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		if (!this.IsActive || this.ChangeStateFrame >= Singleton<Time>.Instance.Frame)
		{
			return;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]) && prevMovementMode == EMovementMode.MOVE_Walking && newMovementMode == EMovementMode.MOVE_Falling && !this.ActorComp.InputDirectProxy.IsNearlyZero(9.999999747378752E-05))
		{
			TsBaseCharacter baseCharacter = this.BaseCharacter;
			if ((baseCharacter == null || !baseCharacter.IsKuroForceFlying()) && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) && ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) > 10f)
			{
				CharacterUnifiedStateComponent stateComp = this.StateComp;
				if (stateComp != null && stateComp.IsWalkMode)
				{
					this.CreateAirFloor();
					this.SetIsWalkOnAir(true);
					this.ChangeStateFrame = Singleton<Time>.Instance.Frame + 2;
					return;
				}
			}
		}
		if (newMovementMode != EMovementMode.MOVE_Walking)
		{
			this.SetIsWalkOnAir(false);
		}
	}

	// Token: 0x06019824 RID: 104484 RVA: 0x00763CD0 File Offset: 0x00761ED0
	private void CreateOneAirFloor(int index)
	{
		AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
		if (aactor == null)
		{
			Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Move, base.Entity, "空中行走创建地面失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UBoxComponent uboxComponent = aactor.AddComponentByClass(UBoxComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UBoxComponent;
		uboxComponent.D_SetBoxExtent(CharacterWalkOnAirComponent.DefaultBoxExtent, true);
		uboxComponent.SetCollisionObjectType(KuroCollisionChannel.WorldStaticIgnoreBullet);
		uboxComponent.SetCollisionResponseToAllChannels(ECollisionResponse.ECR_Ignore);
		uboxComponent.SetCollisionResponseToChannel(KuroCollisionChannel.PawnPlayer, ECollisionResponse.ECR_Block);
		while (this.AirFloor.Count <= index)
		{
			this.AirFloor.Add(null);
		}
		this.AirFloor[index] = aactor;
		while (this.BoxComp.Count <= index)
		{
			this.BoxComp.Add(null);
		}
		this.BoxComp[index] = uboxComponent;
	}

	// Token: 0x06019825 RID: 104485 RVA: 0x00763DC4 File Offset: 0x00761FC4
	private void CreateAirFloor()
	{
		if (this.AirFloor.Count > 0)
		{
			return;
		}
		this.ValidAirFloorIndex = 0;
		this.CreateOneAirFloor(0);
		UBoxComponent uboxComponent = this.BoxComp.ElementAtOrDefault(0);
		if (uboxComponent != null)
		{
			uboxComponent.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
		}
		this.CreateOneAirFloor(1);
		UBoxComponent uboxComponent2 = this.BoxComp.ElementAtOrDefault(1);
		if (uboxComponent2 == null)
		{
			return;
		}
		uboxComponent2.SetCollisionEnabled(ECollisionEnabled.NoCollision);
	}

	// Token: 0x06019826 RID: 104486 RVA: 0x00763E24 File Offset: 0x00762024
	private void SetIsWalkOnAir(bool bStart)
	{
		if (bStart == this.IsWalkOnAir)
		{
			if (bStart)
			{
				this.UpdateAirFloorPos(false);
			}
			return;
		}
		this.IsWalkOnAir = bStart;
		if (bStart)
		{
			this.UpdateAirFloorPos(false);
			UBoxComponent uboxComponent = this.BoxComp.ElementAtOrDefault(this.ValidAirFloorIndex);
			if (uboxComponent != null)
			{
				uboxComponent.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
			}
			this.StateComp.SetPositionSubState(ECharPositionSubState.WalkOnAir, false);
			return;
		}
		UBoxComponent uboxComponent2 = this.BoxComp.ElementAtOrDefault(this.ValidAirFloorIndex);
		if (uboxComponent2 != null)
		{
			uboxComponent2.SetCollisionEnabled(ECollisionEnabled.NoCollision);
		}
		this.StateComp.SetPositionSubState(ECharPositionSubState.None, false);
	}

	// Token: 0x06019827 RID: 104487 RVA: 0x00763EAC File Offset: 0x007620AC
	private void UpdateAirFloorPos(bool bUseRecordHeight = false)
	{
		Vector floorLocation = this.ActorComp.FloorLocation;
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(this.ActorComp, floorLocation, -CharacterWalkOnAirComponent.DefaultBoxExtent.Z);
		this.AirFloorPos.DeepCopy(floorLocation);
		Vector gravityDirectForActor = Singleton<GravityUtils>.Instance.GetGravityDirectForActor(this.ActorComp);
		if (bUseRecordHeight)
		{
			double num = floorLocation.DotProduct(gravityDirectForActor);
			floorLocation.AdditionEqual(gravityDirectForActor.Multiply(this.AirFloorHeight - num, Singleton<MathUtils>.Instance.CommonTempVector));
		}
		else
		{
			this.AirFloorHeight = floorLocation.DotProduct(gravityDirectForActor);
		}
		FHitResult fhitResult = new FHitResult();
		AActor aactor = this.AirFloor.ElementAtOrDefault(this.ValidAirFloorIndex);
		if (aactor == null)
		{
			return;
		}
		aactor.D_K2_SetActorLocationAndRotation(floorLocation.ToUeVector(false), this.ActorComp.ActorRotation, false, ref fhitResult, false);
	}

	// Token: 0x06019828 RID: 104488 RVA: 0x00763F70 File Offset: 0x00762170
	private void SwitchAirFloor()
	{
		UBoxComponent uboxComponent = this.BoxComp.ElementAtOrDefault(this.ValidAirFloorIndex);
		if (uboxComponent != null)
		{
			uboxComponent.SetCollisionEnabled(ECollisionEnabled.NoCollision);
		}
		this.ValidAirFloorIndex ^= 1;
		UBoxComponent uboxComponent2 = this.BoxComp.ElementAtOrDefault(this.ValidAirFloorIndex);
		if (uboxComponent2 == null)
		{
			return;
		}
		uboxComponent2.SetCollisionEnabled(ECollisionEnabled.QueryOnly);
	}

	// Token: 0x06019829 RID: 104489 RVA: 0x00763FC4 File Offset: 0x007621C4
	protected override void OnTick(float delta)
	{
		if (!this.IsWalkOnAir)
		{
			return;
		}
		if (Vector.DistSquared(this.AirFloorPos, this.ActorComp.FloorLocation) > 22500.0)
		{
			this.SwitchAirFloor();
			this.UpdateAirFloorPos(true);
		}
		if (this.ChangeStateFrame >= Singleton<Time>.Instance.Frame)
		{
			return;
		}
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.动作状态.行走"]) || ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) <= 0f)
		{
			this.SetIsWalkOnAir(false);
			this.ChangeStateFrame = Singleton<Time>.Instance.Frame + 2;
		}
	}

	// Token: 0x0601982A RID: 104490 RVA: 0x00764062 File Offset: 0x00762262
	protected override bool OnEnd()
	{
		this.UnregisterEvent();
		return true;
	}

	// Token: 0x0601982B RID: 104491 RVA: 0x0076406C File Offset: 0x0076226C
	protected override bool OnClear()
	{
		foreach (AActor actor in this.AirFloor)
		{
			Singleton<ActorSystem>.Instance.Put("OnClearWalkOnAir", actor, null);
		}
		this.AirFloor.Clear();
		this.BoxComp.Clear();
		return true;
	}

	// Token: 0x0601982C RID: 104492 RVA: 0x007640E4 File Offset: 0x007622E4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterWalkOnAirComponent characterWalkOnAirComponent = (CharacterWalkOnAirComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterWalkOnAirComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterWalkOnAirComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnWalkOnAirTagNewOrRemove"))
		{
			if (characterWalkOnAirComponent.OnWalkOnAirTagNewOrRemove == null)
			{
				this.OnWalkOnAirTagNewOrRemove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnWalkOnAirTagNewOrRemove), "OnWalkOnAirTagNewOrRemove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnForegroundTagNewOrRemove"))
		{
			if (characterWalkOnAirComponent.OnForegroundTagNewOrRemove == null)
			{
				this.OnForegroundTagNewOrRemove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnForegroundTagNewOrRemove), "OnForegroundTagNewOrRemove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnSkillTagNewOrRemove"))
		{
			if (characterWalkOnAirComponent.OnSkillTagNewOrRemove == null)
			{
				this.OnSkillTagNewOrRemove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnSkillTagNewOrRemove), "OnSkillTagNewOrRemove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsActive"))
		{
			this.IsActive = characterWalkOnAirComponent.IsActive;
		}
		if (base.CanResetComponentProperty("IsWalkOnAir"))
		{
			this.IsWalkOnAir = characterWalkOnAirComponent.IsWalkOnAir;
		}
		if (base.CanResetComponentProperty("AirFloor"))
		{
			if (characterWalkOnAirComponent.AirFloor == null)
			{
				this.AirFloor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<AActor>>(this.AirFloor), "AirFloor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BoxComp"))
		{
			if (characterWalkOnAirComponent.BoxComp == null)
			{
				this.BoxComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<UBoxComponent>>(this.BoxComp), "BoxComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ValidAirFloorIndex"))
		{
			this.ValidAirFloorIndex = characterWalkOnAirComponent.ValidAirFloorIndex;
		}
		if (base.CanResetComponentProperty("AirFloorPos") && characterWalkOnAirComponent.AirFloorPos != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.AirFloorPos), "AirFloorPos"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AirFloorHeight"))
		{
			this.AirFloorHeight = characterWalkOnAirComponent.AirFloorHeight;
		}
		if (base.CanResetComponentProperty("BaseCharacter"))
		{
			if (characterWalkOnAirComponent.BaseCharacter == null)
			{
				this.BaseCharacter = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.BaseCharacter), "BaseCharacter"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterWalkOnAirComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ChangeStateFrame"))
		{
			this.ChangeStateFrame = characterWalkOnAirComponent.ChangeStateFrame;
		}
		return true;
	}

	// Token: 0x0400CA6B RID: 51819
	private const int STRENGTH_THREADHOLD = 10;

	// Token: 0x0400CA6C RID: 51820
	private const int FRAME_INTERNAL = 2;

	// Token: 0x0400CA6D RID: 51821
	private const int BOX_LENGTH = 200;

	// Token: 0x0400CA6E RID: 51822
	private const int SWITCH_DISTANCE_SQUARE = 22500;

	// Token: 0x0400CA6F RID: 51823
	private static readonly FVectorDouble DefaultBoxExtent = new FVectorDouble(200.0, 200.0, 1.0);

	// Token: 0x0400CA70 RID: 51824
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CA71 RID: 51825
	private BaseTagComponent TagComp;

	// Token: 0x0400CA72 RID: 51826
	private ITagTask OnWalkOnAirTagNewOrRemove;

	// Token: 0x0400CA73 RID: 51827
	private ITagTask OnForegroundTagNewOrRemove;

	// Token: 0x0400CA74 RID: 51828
	private ITagTask OnSkillTagNewOrRemove;

	// Token: 0x0400CA75 RID: 51829
	private bool IsActive;

	// Token: 0x0400CA76 RID: 51830
	private bool IsWalkOnAir;

	// Token: 0x0400CA77 RID: 51831
	[Nullable(1)]
	private List<AActor> AirFloor = new List<AActor>();

	// Token: 0x0400CA78 RID: 51832
	[Nullable(1)]
	private List<UBoxComponent> BoxComp = new List<UBoxComponent>();

	// Token: 0x0400CA79 RID: 51833
	private int ValidAirFloorIndex;

	// Token: 0x0400CA7A RID: 51834
	[Nullable(1)]
	private readonly Vector AirFloorPos = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400CA7B RID: 51835
	private double AirFloorHeight;

	// Token: 0x0400CA7C RID: 51836
	private TsBaseCharacter BaseCharacter;

	// Token: 0x0400CA7D RID: 51837
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400CA7E RID: 51838
	private int ChangeStateFrame;
}
