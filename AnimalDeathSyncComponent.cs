using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002E14 RID: 11796
[NullableContext(1)]
[Nullable(0)]
public class AnimalDeathSyncComponent : BaseDeathComponent
{
	// Token: 0x06017DBE RID: 97726 RVA: 0x006AE094 File Offset: 0x006AC294
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.UnifiedStateComponent = base.Entity.CheckGetComponent<BaseUnifiedStateComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(base.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
		if (base.Entity.CheckGetComponent<CreatureDataComponent>().GetLivingStatus().GetValueOrDefault() == LivingStatus.Dead)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.ExecuteDeath(null);
			}, null, null);
		}
		this.HadPlayDeathAnim = false;
		return true;
	}

	// Token: 0x06017DBF RID: 97727 RVA: 0x006AE128 File Offset: 0x006AC328
	private void OnBeHit(global::HitInformation hitData, HitContext hitContext)
	{
		if (hitData.DamageId == 0L)
		{
			return;
		}
		if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.通用无敌"]) || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
		{
			return;
		}
		CharacterAiComponent component = base.Entity.GetComponent<CharacterAiComponent>();
		if (component != null)
		{
			component.DisableAi("动物死亡");
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]));
		}
		ControllerBase<CreatureController>.Instance.AnimalDieRequest(base.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId(), base.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy);
	}

	// Token: 0x06017DC0 RID: 97728 RVA: 0x006AE1E1 File Offset: 0x006AC3E1
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<global::HitInformation, HitContext>(base.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.OnBeHit));
		return true;
	}

	// Token: 0x06017DC1 RID: 97729 RVA: 0x006AE204 File Offset: 0x006AC404
	public override bool ExecuteDeath(long? preMessageId)
	{
		if (!base.ExecuteDeath(preMessageId))
		{
			return false;
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]));
		}
		BaseUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null)
		{
			unifiedStateComponent.ResetCharState();
		}
		this.PlayDieAnimation();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.CharOnRoleDead, base.Entity.Id);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf);
		return true;
	}

	// Token: 0x06017DC2 RID: 97730 RVA: 0x006AE28C File Offset: 0x006AC48C
	public void PlayDieAnimation()
	{
		if (this.HadPlayDeathAnim)
		{
			return;
		}
		this.HadPlayDeathAnim = true;
		if (!this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不播放死亡动画"]))
		{
			BaseMontageComponent montageComponent = this.MontageComponent;
			if (montageComponent != null && montageComponent.Valid)
			{
				if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.消失"]))
				{
					TimerSystem.Instance.Delay(new TTimerAction(this.OnDeathEnded), 1600f, null, null, true, 1f);
					return;
				}
				if (this.UnifiedStateComponent.PositionState == global::ECharPositionState.Water)
				{
					base.PlayDeathMontageWithType(ECharacterDeathMontageType.DieInWater, new Action<bool>(this.OnDeathEnded), null, new bool?(true));
					return;
				}
				base.PlayDeathMontageWithType(ECharacterDeathMontageType.Die, new Action<bool>(this.OnDeathEnded), null, new bool?(true));
				return;
			}
		}
		this.OnDeathEnded(0f);
	}

	// Token: 0x06017DC3 RID: 97731 RVA: 0x006AE37C File Offset: 0x006AC57C
	public void OnDeathEnded(float delta)
	{
		this.OnDeathEndedInternal();
	}

	// Token: 0x06017DC4 RID: 97732 RVA: 0x006AE384 File Offset: 0x006AC584
	public void OnDeathEnded(bool bInterrupted)
	{
		this.OnDeathEndedInternal();
	}

	// Token: 0x06017DC5 RID: 97733 RVA: 0x006AE38C File Offset: 0x006AC58C
	private void OnDeathEndedInternal()
	{
		base.Entity.Disable("[BaseAttributeComponent.DieAnimationFinished] 死亡动画播放完后隐藏");
		BaseAnimationComponent component = base.Entity.GetComponent<BaseAnimationComponent>();
		if (component != null)
		{
			component.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.Death);
		}
		ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(base.Entity);
		this.HadPlayDeathAnim = false;
	}

	// Token: 0x06017DC6 RID: 97734 RVA: 0x006AE3D8 File Offset: 0x006AC5D8
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		AnimalDeathSyncComponent animalDeathSyncComponent = (AnimalDeathSyncComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (animalDeathSyncComponent.TagComponent == null)
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
			if (animalDeathSyncComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HadPlayDeathAnim"))
		{
			this.HadPlayDeathAnim = animalDeathSyncComponent.HadPlayDeathAnim;
		}
		return true;
	}

	// Token: 0x0400B90F RID: 47375
	private const int DISAPPEAR_REMOVE_DELAY = 1600;

	// Token: 0x0400B910 RID: 47376
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x0400B911 RID: 47377
	[Nullable(2)]
	private BaseUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400B912 RID: 47378
	private bool HadPlayDeathAnim;
}
