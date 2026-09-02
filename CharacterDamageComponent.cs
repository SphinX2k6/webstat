using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DeadRevive;

// Token: 0x02002EB1 RID: 11953
[NullableContext(2)]
[Nullable(0)]
public class CharacterDamageComponent : BaseDamageComponent
{
	// Token: 0x17002119 RID: 8473
	// (get) Token: 0x06018870 RID: 100464 RVA: 0x006E1C43 File Offset: 0x006DFE43
	private new CharacterActorComponent ActorComponent
	{
		get
		{
			return this.ActorComponent as CharacterActorComponent;
		}
	}

	// Token: 0x06018871 RID: 100465 RVA: 0x006E1C50 File Offset: 0x006DFE50
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.ActorComponent = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.HitComponent = base.Entity.CheckGetComponent<CharacterHitComponent>();
		this.UnifiedStateComponent = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.MoveComponent = base.Entity.GetComponent<CharacterMoveComponent>();
		this.FallingSpeedThreshold = this.GetFallingSpeedThreshold();
		return true;
	}

	// Token: 0x06018872 RID: 100466 RVA: 0x006E1CB8 File Offset: 0x006DFEB8
	protected override void OnTick(float delta)
	{
		CharacterMoveComponent moveComponent = this.MoveComponent;
		if ((((moveComponent != null) ? moveComponent.GravityDirect : null) ?? global::Vector.DownVectorProxy).DotProduct(this.ActorComponent.ActorVelocityProxy) >= this.FallingSpeedThreshold)
		{
			if (this.FallingStartTime == 0.0)
			{
				this.FallingStartTime = Singleton<Time>.Instance.WorldTimeSeconds;
				return;
			}
		}
		else
		{
			this.FallingStartTime = 0.0;
		}
	}

	// Token: 0x06018873 RID: 100467 RVA: 0x006E1D2C File Offset: 0x006DFF2C
	public void FallInjure()
	{
		if (!this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌"]))
		{
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (((unifiedStateComponent != null) ? unifiedStateComponent.IsInGame : null).GetValueOrDefault() && !ModelBase<DeadReviveModel>.Instance.SkipFallInjure)
			{
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.跌落无伤"]))
				{
					return;
				}
				CharacterMoveComponent moveComponent = this.MoveComponent;
				double num = (((moveComponent != null) ? moveComponent.GravityUp : null) ?? global::Vector.UpVectorProxy).DotProduct(this.ActorComponent.ActorVelocityProxy);
				double fallingHeight = this.GetFallingHeight();
				if (-num < this.FallingSpeedThreshold)
				{
					this.FallingStartTime = 0.0;
				}
				double num2 = (this.FallingStartTime != 0.0) ? (Singleton<Time>.Instance.WorldTimeSeconds - this.FallingStartTime) : 0.0;
				double num3 = Math.Ceiling(this.CalculateFallInjure(-num, fallingHeight, num2));
				UeMovementTickManageComponent component = base.Entity.GetComponent<UeMovementTickManageComponent>();
				if (component != null)
				{
					component.DumpVelocityCacheInfo("跌落伤害处理", false);
				}
				if (num3 <= 0.0)
				{
					return;
				}
				long creatureDataId = this.CreatureDataComponent.GetCreatureDataId();
				base.Entity.GetComponent<CharacterMovementSyncComponent>().CollectSampleAndSend(false);
				ControllerBase<CreatureController>.Instance.LandingDamageRequest(creatureDataId, num, (int)(num2 * 1000.0));
				Singleton<EventSystem>.Instance.EmitWithTarget<float, bool>(base.Entity, EEventName.CharOnFallInjure, (float)num3, false);
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (buffComponent != null)
				{
					buffComponent.RemoveBuffByEffectType(EExtraEffectId.Frozen, "跌落伤害移除冰冻buff");
				}
				this.HitComponent.NeedCalculateFallInjure = false;
				return;
			}
		}
	}

	// Token: 0x06018874 RID: 100468 RVA: 0x006E1ECC File Offset: 0x006E00CC
	private double CalculateFallInjure(double lastSpeedZ, double height, double time)
	{
		float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
		double num;
		if (this.CreatureDataComponent.IsRealMonster())
		{
			num = Calculation.LandingDamageCalculationMonster(height, (double)currentValue);
		}
		else
		{
			num = Calculation.LandingDamageCalculationRole(lastSpeedZ, time, (double)currentValue);
		}
		if (num <= 0.0)
		{
			return 0.0;
		}
		return num;
	}

	// Token: 0x06018875 RID: 100469 RVA: 0x006E1F2C File Offset: 0x006E012C
	private double GetFallingHeight()
	{
		if (!this.HitComponent.NeedCalculateFallInjure)
		{
			return 0.0;
		}
		double z = this.HitComponent.BeHitLocation.Z;
		double z2 = this.ActorComponent.ActorLocationProxy.Z;
		if (z <= z2)
		{
			return 0.0;
		}
		return z - z2;
	}

	// Token: 0x06018876 RID: 100470 RVA: 0x006E1F83 File Offset: 0x006E0183
	private double GetFallingSpeedThreshold()
	{
		return (double)ConfigCommonParamById.GetIntArrayConfig("landing_damage_args_role")[1];
	}

	// Token: 0x06018877 RID: 100471 RVA: 0x006E1F98 File Offset: 0x006E0198
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterDamageComponent characterDamageComponent = (CharacterDamageComponent)componentTemplate;
		if (base.CanResetComponentProperty("HitComponent"))
		{
			if (characterDamageComponent.HitComponent == null)
			{
				this.HitComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterHitComponent>(this.HitComponent), "HitComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (characterDamageComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComponent"))
		{
			if (characterDamageComponent.MoveComponent == null)
			{
				this.MoveComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComponent), "MoveComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FallingSpeedThreshold"))
		{
			this.FallingSpeedThreshold = characterDamageComponent.FallingSpeedThreshold;
		}
		if (base.CanResetComponentProperty("FallingStartTime"))
		{
			this.FallingStartTime = characterDamageComponent.FallingStartTime;
		}
		return true;
	}

	// Token: 0x0400BD71 RID: 48497
	private CharacterHitComponent HitComponent;

	// Token: 0x0400BD72 RID: 48498
	private CharacterUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400BD73 RID: 48499
	private CharacterMoveComponent MoveComponent;

	// Token: 0x0400BD74 RID: 48500
	private double FallingSpeedThreshold;

	// Token: 0x0400BD75 RID: 48501
	private double FallingStartTime;
}
