using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F52 RID: 12114
[NullableContext(2)]
[Nullable(0)]
public abstract class PassiveEffects : BuffEffect, IBuffTrigger
{
	// Token: 0x06018C78 RID: 101496 RVA: 0x007013BC File Offset: 0x006FF5BC
	public override void OnCreated()
	{
		BaseBuffComponent baseBuffComponent = this.OwnerBuffComponent as BaseBuffComponent;
		if (baseBuffComponent == null)
		{
			return;
		}
		baseBuffComponent.AddTrigger(this.ActiveHandleId, this.EventType, this);
	}

	// Token: 0x06018C79 RID: 101497 RVA: 0x007013E0 File Offset: 0x006FF5E0
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		ownerBuffComponent.RemoveTrigger(this.ActiveHandleId, this.EventType);
	}

	// Token: 0x06018C7A RID: 101498 RVA: 0x007013FE File Offset: 0x006FF5FE
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018C7B RID: 101499 RVA: 0x00701411 File Offset: 0x006FF611
	protected IBuffComponent GetEffectTarget()
	{
		return this.GetTargetByType(this.TargetType);
	}

	// Token: 0x06018C7C RID: 101500 RVA: 0x0070141F File Offset: 0x006FF61F
	protected IBuffComponent GetTargetByType(EPassiveEffectTargetType targetType)
	{
		switch (targetType)
		{
		case EPassiveEffectTargetType.ForSelf:
			return this.OwnerBuffComponent;
		case EPassiveEffectTargetType.ForTarget:
			return base.OpponentBuffComponent;
		case EPassiveEffectTargetType.ForBuffInstigator:
			return this.InstigatorBuffComponent;
		case EPassiveEffectTargetType.ForBuffHolderTarget:
			return this.GetBuffHolderSkillTarget();
		default:
			return null;
		}
	}

	// Token: 0x06018C7D RID: 101501 RVA: 0x00701458 File Offset: 0x006FF658
	protected IBuffComponent GetBuffHolderSkillTarget()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		EntityHandle entityHandle;
		if (ownerBuffComponent == null)
		{
			entityHandle = null;
		}
		else
		{
			Entity entity = ownerBuffComponent.GetEntity();
			if (entity == null)
			{
				entityHandle = null;
			}
			else
			{
				CharacterSkillComponent characterSkillComponent = entity.CheckGetComponent<CharacterSkillComponent>();
				entityHandle = ((characterSkillComponent != null) ? characterSkillComponent.SkillTarget : null);
			}
		}
		EntityHandle entityHandle2 = entityHandle;
		if (entityHandle2 == null)
		{
			return this.OwnerBuffComponent;
		}
		WorldEntity entity2 = entityHandle2.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.CheckGetComponent<BaseBuffComponent>();
	}

	// Token: 0x06018C7E RID: 101502 RVA: 0x007014AC File Offset: 0x006FF6AC
	[NullableContext(1)]
	protected string GetDebugTriggerString()
	{
		string result;
		switch (this.EventType)
		{
		case EBuffTriggerType.ForAfterDamageAsAttacker:
			result = "造成伤害后";
			break;
		case EBuffTriggerType.ForAfterDamageAsVictim:
			result = "受到伤害后";
			break;
		case EBuffTriggerType.ForSkillStart:
			result = "技能开始时";
			break;
		case EBuffTriggerType.ForSkillEnd:
			result = "技能结束时";
			break;
		case EBuffTriggerType.ForGoBattle:
			result = "上场后";
			break;
		case EBuffTriggerType.ForGoDown:
			result = "下场后";
			break;
		case EBuffTriggerType.ForKillingEnemy:
			result = "击杀单位后";
			break;
		case EBuffTriggerType.ForWhenAppendShield:
			result = "护盾添加时";
			break;
		case EBuffTriggerType.ForWhenRemoveShield:
			result = "护盾消失时";
			break;
		case EBuffTriggerType.ForWhenOneElementActivated:
			result = "生成元素球时";
			break;
		case EBuffTriggerType.ForWhenElementFusionGoDown:
			result = "触发协奏反应下场后";
			break;
		case EBuffTriggerType.ForWhenCounter:
			result = "弹刀时";
			break;
		case EBuffTriggerType.ForWhenBeCountered:
			result = "被弹刀时";
			break;
		case EBuffTriggerType.ForWhenElementFusionGoBattle:
			result = "触发协奏反应上场后";
			break;
		case EBuffTriggerType.WhenOwnerDie:
			result = "持有者死亡时";
			break;
		case EBuffTriggerType.WhenCompanionDie:
			result = "小队有人死亡时";
			break;
		case EBuffTriggerType.WhenBulletHit:
			result = "被子弹命中时";
			break;
		case EBuffTriggerType.ForOnStage:
			result = "角色上场时";
			break;
		case EBuffTriggerType.BeforeBulletHit:
			result = "被子弹命中前";
			break;
		default:
			result = "";
			break;
		}
		return result;
	}

	// Token: 0x06018C7F RID: 101503 RVA: 0x007015BF File Offset: 0x006FF7BF
	[NullableContext(1)]
	protected PassiveEffects(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x17002186 RID: 8582
	// (get) Token: 0x06018C80 RID: 101504 RVA: 0x007015CE File Offset: 0x006FF7CE
	public new int ActiveHandleId
	{
		get
		{
			return this.ActiveHandleId;
		}
	}

	// Token: 0x17002187 RID: 8583
	// (get) Token: 0x06018C81 RID: 101505 RVA: 0x007015D6 File Offset: 0x006FF7D6
	public new BaseBuffComponent InstigatorBuffComponent
	{
		get
		{
			return base.InstigatorBuffComponent;
		}
	}

	// Token: 0x06018C82 RID: 101506 RVA: 0x007015DE File Offset: 0x006FF7DE
	[NullableContext(1)]
	public bool TryExecute(Partial_RequirementPayload payload, IBuffComponent opponentBuffComp)
	{
		return base.TryExecute(payload, opponentBuffComp, Array.Empty<object>());
	}

	// Token: 0x0400C104 RID: 49412
	public EBuffTriggerType EventType;

	// Token: 0x0400C105 RID: 49413
	public EPassiveEffectTargetType TargetType;
}
