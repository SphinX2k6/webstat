using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003201 RID: 12801
[NullableContext(2)]
[Nullable(0)]
public class RoleStrengthComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601A8D7 RID: 108759 RVA: 0x007DD1A3 File Offset: 0x007DB3A3
	static RoleStrengthComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleStrengthComponent.CreateStaticDefaultValue), new Action(RoleStrengthComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601A8D8 RID: 108760 RVA: 0x007DD1C4 File Offset: 0x007DB3C4
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.BuffComp = base.Entity.CheckGetComponent<CharacterBuffComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.UnifiedStateComponent = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
		this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.StrengthForbiddenGe = -1;
		this.InitStartingGameplayEffect();
		Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.MoveStateChangeHandler));
		Singleton<EventSystem>.Instance.AddWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.PositionStateChangeHandler));
		Singleton<EventSystem>.Instance.AddWithTarget<long>(base.Entity, EEventName.CharSwimStrengthChanged, new Action<long>(this.SwimStrengthChangeHandler));
		ControllerBase<FormationAttributeController>.Instance.AddThresholdListener(EFormationAttributeId.Strength, new TThresholdListener(this.StrengthEmptyCallback), 0f, 0f, "Strength.RoleStrengthComponent");
		ControllerBase<FormationAttributeController>.Instance.AddThresholdListener(EFormationAttributeId.SoarStrength, new TThresholdListener(this.SoarStrengthEmptyCallback), 0f, 0f, "Strength.RoleStrengthComponent");
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.钩锁"], new BaseTagComponent.TTagSwitchedCallback(this.CheckDrowning), null);
		}
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
		return true;
	}

	// Token: 0x0601A8D9 RID: 108761 RVA: 0x007DD338 File Offset: 0x007DB538
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<ECharMoveState, ECharMoveState>(this.MoveStateChangeHandler));
		Singleton<EventSystem>.Instance.RemoveWithTarget<ECharPositionState, ECharPositionState>(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.PositionStateChangeHandler));
		ControllerBase<FormationAttributeController>.Instance.RemoveThresholdListener(EFormationAttributeId.Strength, new TThresholdListener(this.StrengthEmptyCallback));
		ControllerBase<FormationAttributeController>.Instance.RemoveThresholdListener(EFormationAttributeId.SoarStrength, new TThresholdListener(this.SoarStrengthEmptyCallback));
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.钩锁"], new BaseTagComponent.TTagSwitchedCallback(this.CheckDrowning));
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.StateInheritHandle));
		Singleton<EventSystem>.Instance.RemoveWithTarget<long>(base.Entity, EEventName.CharSwimStrengthChanged, new Action<long>(this.SwimStrengthChangeHandler));
		return true;
	}

	// Token: 0x0601A8DA RID: 108762 RVA: 0x007DD429 File Offset: 0x007DB629
	private void InitStartingGameplayEffect()
	{
	}

	// Token: 0x0601A8DB RID: 108763 RVA: 0x007DD42C File Offset: 0x007DB62C
	private void StrengthEmptyCallback(EFormationAttributeId attrId, bool inInterval, float currentRatio)
	{
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (!(num.GetValueOrDefault() == playerId & num != null))
		{
			return;
		}
		if (inInterval)
		{
			switch (this.UnifiedStateComponent.PositionState)
			{
			case ECharPositionState.Ground:
				if (this.UnifiedStateComponent.MoveState == ECharMoveState.Sprint)
				{
					this.UnifiedStateComponent.SetMoveState(ECharMoveState.Run);
				}
				this.EmptyStrengthPunish();
				return;
			case ECharPositionState.Climb:
			case ECharPositionState.Floating:
				this.EmptyStrengthPunish();
				return;
			case ECharPositionState.Air:
				if (this.UnifiedStateComponent.MoveState == ECharMoveState.Glide)
				{
					CharacterGlideComponent component = base.Entity.GetComponent<CharacterGlideComponent>();
					if (component.Valid)
					{
						component.ExitGlideState("Strength");
					}
				}
				this.EmptyStrengthPunish();
				return;
			case ECharPositionState.Water:
				this.CheckDrowning();
				break;
			case ECharPositionState.Ski:
			case ECharPositionState.Ride:
			case ECharPositionState.RailSlide:
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x0601A8DC RID: 108764 RVA: 0x007DD518 File Offset: 0x007DB718
	private void CheckDrowning()
	{
		if (this.UnifiedStateComponent.PositionState == ECharPositionState.Water)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.钩锁"]))
			{
				SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
				int? num;
				if (instance == null)
				{
					num = null;
				}
				else
				{
					EntityHandle getCurrentEntity = instance.GetCurrentEntity;
					num = ((getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null);
				}
				int? num2 = num;
				int id = base.Entity.Id;
				if (num2.GetValueOrDefault() == id & num2 != null)
				{
					if (ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) < 0.01f)
					{
						RoleDeathComponent roleDeathComponent = base.Entity.CheckGetComponent<RoleDeathComponent>();
						if (roleDeathComponent == null)
						{
							return;
						}
						roleDeathComponent.Drowning();
					}
					return;
				}
			}
		}
	}

	// Token: 0x0601A8DD RID: 108765 RVA: 0x007DD5D1 File Offset: 0x007DB7D1
	private void CheckDrowning(int tagId, bool tagExist)
	{
		this.CheckDrowning();
	}

	// Token: 0x0601A8DE RID: 108766 RVA: 0x007DD5DC File Offset: 0x007DB7DC
	private void SoarStrengthEmptyCallback(EFormationAttributeId attrId, bool inInterval, float currentRatio)
	{
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (!(num.GetValueOrDefault() == playerId & num != null))
		{
			return;
		}
		if (inInterval)
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null && unifiedStateComponent.MoveState == ECharMoveState.Soar)
			{
				CharacterGlideComponent component = base.Entity.GetComponent<CharacterGlideComponent>();
				if (component == null)
				{
					return;
				}
				component.ExitSoarState(EMovementMode.MOVE_Falling, "Strength");
			}
		}
	}

	// Token: 0x0601A8DF RID: 108767 RVA: 0x007DD65F File Offset: 0x007DB85F
	private void MoveStateChangeHandler(ECharMoveState oldState, ECharMoveState newState)
	{
		if (this.UnifiedStateComponent.PositionState == ECharPositionState.Water || !this.ActorComp.IsMoveAutonomousProxy)
		{
			return;
		}
		this.NewMoveStateStrengthDecrease(newState);
	}

	// Token: 0x0601A8E0 RID: 108768 RVA: 0x007DD684 File Offset: 0x007DB884
	private void SwimStrengthChangeHandler(long newBuff)
	{
		this.BuffComp.RemoveBuffByHandle(this.StrengthDecreaseGe, -1, null, null, null, null);
		if (newBuff != 0L)
		{
			this.UpdateStrengthDecrease(newBuff);
		}
	}

	// Token: 0x0601A8E1 RID: 108769 RVA: 0x007DD6CC File Offset: 0x007DB8CC
	private void PositionStateChangeHandler(ECharPositionState oldState, ECharPositionState newState)
	{
		float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength);
		if (oldState == ECharPositionState.Water)
		{
			this.BuffComp.RemoveBuffByHandle(this.StrengthDecreaseGe, -1, null, null, null, null);
		}
		if (newState == ECharPositionState.Water && value < 0.01f)
		{
			this.CheckDrowning();
		}
		this.ClearStrengthForbiddenGe();
		switch (newState)
		{
		case ECharPositionState.Ground:
			this.ClearStrengthForbiddenGe();
			return;
		case ECharPositionState.Climb:
			this.AddStrengthForbiddenGe(3011L);
			return;
		case ECharPositionState.Air:
		{
			CharacterBuffComponent buffComp = this.BuffComp;
			if (buffComp != null && buffComp.HasBuffAuthority())
			{
				this.BuffComp.AddBuff(3009L, new AddBuffParam
				{
					InstigatorId = this.BuffComp.CreatureDataId,
					Reason = "进入空中状态"
				});
			}
			this.AddStrengthForbiddenGe(3010L);
			return;
		}
		case ECharPositionState.Water:
			this.AddStrengthForbiddenGe(3011L);
			return;
		default:
			return;
		}
	}

	// Token: 0x0601A8E2 RID: 108770 RVA: 0x007DD7BA File Offset: 0x007DB9BA
	[NullableContext(1)]
	private void StateInheritHandle(Entity oldEntity, bool notInheritMoveAndAnim)
	{
	}

	// Token: 0x0601A8E3 RID: 108771 RVA: 0x007DD7BC File Offset: 0x007DB9BC
	public void EmptyStrengthPunish()
	{
		if (this.BuffComp.HasBuffAuthority() && this.BuffComp.GetBuffTotalStackById(3023L, false) < 1)
		{
			this.BuffComp.AddBuff(3023L, new AddBuffParam
			{
				InstigatorId = this.BuffComp.CreatureDataId,
				Reason = "体力耗尽"
			});
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]));
	}

	// Token: 0x0601A8E4 RID: 108772 RVA: 0x007DD842 File Offset: 0x007DBA42
	public void UpdateStrengthDecrease(long decreaseBuffId)
	{
		this.StrengthDecreaseGe = this.BuffComp.AddBuffLocal(decreaseBuffId, new AddBuffParam
		{
			InstigatorId = this.BuffComp.CreatureDataId,
			Reason = "RoleStrengthComponent.UpdateStrengthDecrease"
		});
	}

	// Token: 0x0601A8E5 RID: 108773 RVA: 0x007DD877 File Offset: 0x007DBA77
	private void AddStrengthForbiddenGe(long buffId)
	{
		this.StrengthForbiddenGe = this.BuffComp.AddBuffLocal(buffId, new AddBuffParam
		{
			InstigatorId = this.BuffComp.CreatureDataId,
			Reason = "RoleStrengthComponent.ToggleStrengthForbiddenGe"
		});
	}

	// Token: 0x0601A8E6 RID: 108774 RVA: 0x007DD8AC File Offset: 0x007DBAAC
	private void ClearStrengthForbiddenGe()
	{
		this.BuffComp.RemoveBuffByHandle(this.StrengthForbiddenGe, -1, null, null, null, null);
	}

	// Token: 0x0601A8E7 RID: 108775 RVA: 0x007DD8E8 File Offset: 0x007DBAE8
	public void NewMoveStateStrengthDecrease(ECharMoveState newState)
	{
		this.BuffComp.RemoveBuffByHandle(this.StrengthDecreaseGe, -1, null, null, null, null);
		if (newState == ECharMoveState.Sprint)
		{
			this.UpdateStrengthDecrease(1201L);
			return;
		}
		if (newState == ECharMoveState.FastClimb)
		{
			this.UpdateStrengthDecrease(1205L);
			return;
		}
		if (newState != ECharMoveState.Glide)
		{
			return;
		}
		this.BuffComp.AddBuff(1212L, new AddBuffParam
		{
			InstigatorId = this.BuffComp.CreatureDataId,
			Reason = "进入滑翔状态"
		});
		this.UpdateStrengthDecrease(1206L);
	}

	// Token: 0x0601A8E8 RID: 108776 RVA: 0x007DD98B File Offset: 0x007DBB8B
	public static void CreateStaticDefaultValue()
	{
		RoleStrengthComponent.ForbidStrengthRecoveryTimeExtra = 0.5f;
	}

	// Token: 0x0601A8E9 RID: 108777 RVA: 0x007DD997 File Offset: 0x007DBB97
	public static void ResetStaticDefaultValue()
	{
		RoleStrengthComponent.ForbidStrengthRecoveryTimeExtra = 0.5f;
	}

	// Token: 0x0601A8EA RID: 108778 RVA: 0x007DD9A4 File Offset: 0x007DBBA4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleStrengthComponent roleStrengthComponent = (RoleStrengthComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (roleStrengthComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComp"))
		{
			if (roleStrengthComponent.BuffComp == null)
			{
				this.BuffComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComp), "BuffComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleStrengthComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (roleStrengthComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (roleStrengthComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StrengthDecreaseGe"))
		{
			this.StrengthDecreaseGe = roleStrengthComponent.StrengthDecreaseGe;
		}
		if (base.CanResetComponentProperty("StrengthForbiddenGe"))
		{
			this.StrengthForbiddenGe = roleStrengthComponent.StrengthForbiddenGe;
		}
		return true;
	}

	// Token: 0x0400D6D3 RID: 54995
	public const float STRENGTH_TOLERANCE = 0.01f;

	// Token: 0x0400D6D4 RID: 54996
	public static float ForbidStrengthRecoveryTimeExtra;

	// Token: 0x0400D6D5 RID: 54997
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D6D6 RID: 54998
	private CharacterBuffComponent BuffComp;

	// Token: 0x0400D6D7 RID: 54999
	private BaseTagComponent TagComponent;

	// Token: 0x0400D6D8 RID: 55000
	private CharacterUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400D6D9 RID: 55001
	private CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400D6DA RID: 55002
	private int StrengthDecreaseGe;

	// Token: 0x0400D6DB RID: 55003
	private int StrengthForbiddenGe;
}
