using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x020031EC RID: 12780
[NullableContext(1)]
[Nullable(0)]
public class RoleElementComponent : EntityComponent
{
	// Token: 0x0601A84B RID: 108619 RVA: 0x007D73C4 File Offset: 0x007D55C4
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.AttributeComponent = base.Entity.GetComponent<BaseAttributeComponent>();
		this.BuffComponent = base.Entity.GetComponent<CharacterBuffComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.AddListener(EAttributeType.ElementEnergy, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged), "RoleElementComponent");
		}
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnRoleRevive));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(base.Entity, EEventName.CharHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(base.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		this.SummonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantCustom, 1);
		EntityHandle summonedEntity = this.SummonedEntity;
		WorldEntity worldEntity = (summonedEntity != null) ? summonedEntity.Entity : null;
		if (worldEntity != null && !Singleton<EventSystem>.Instance.HasWithTarget(worldEntity, EEventName.CharHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<global::HitInformation, HitContext>(worldEntity, EEventName.CharHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		}
		this.NeedCheckEnergy = true;
		return true;
	}

	// Token: 0x0601A84C RID: 108620 RVA: 0x007D7560 File Offset: 0x007D5760
	protected override bool OnEnd()
	{
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.RemoveListener(EAttributeType.ElementEnergy, new Action<EAttributeType, float, float>(this.OnElementEnergyChanged));
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRevive, new Action(this.OnRoleRevive));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharBeHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		EntityHandle summonedEntity = this.SummonedEntity;
		if (summonedEntity != null && summonedEntity.Valid)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.SummonedEntity.Entity, EEventName.CharHitLocal, new Action<global::HitInformation, HitContext>(this.CheckEnergyOnce));
		}
		this.SummonedEntity = null;
		this.NeedCheckEnergy = false;
		return true;
	}

	// Token: 0x170023EA RID: 9194
	// (get) Token: 0x0601A84E RID: 108622 RVA: 0x007D7761 File Offset: 0x007D5961
	// (set) Token: 0x0601A84D RID: 108621 RVA: 0x007D7694 File Offset: 0x007D5894
	private bool ElementActivated
	{
		get
		{
			BaseTagComponent tagComponent = this.TagComponent;
			return tagComponent != null && tagComponent.HasExactTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE"]);
		}
		set
		{
			if (this.ElementActivated != value)
			{
				CharacterActorComponent actorComponent = this.ActorComponent;
				if (actorComponent != null && actorComponent.IsAutonomousProxy)
				{
					if (value)
					{
						bool flag = ControllerBase<FormationDataController>.Instance.IsBattleMulti();
						this.QteBuffId = (flag ? 3028L : 3029L);
						CharacterBuffComponent buffComponent = this.BuffComponent;
						if (buffComponent != null)
						{
							buffComponent.AddBuff(this.QteBuffId, new AddBuffParam
							{
								InstigatorId = this.BuffComponent.CreatureDataId,
								Reason = "RoleElementComponent获取激活QTE的Tag"
							});
						}
						if (flag)
						{
							this.MultiQteGuide();
							return;
						}
					}
					else
					{
						CharacterBuffComponent buffComponent2 = this.BuffComponent;
						if (buffComponent2 == null)
						{
							return;
						}
						buffComponent2.RemoveBuff(this.QteBuffId, -1, "RoleElementComponent移除激活QTE的Tag", null, null, null);
					}
				}
			}
		}
	}

	// Token: 0x170023EB RID: 9195
	// (get) Token: 0x0601A84F RID: 108623 RVA: 0x007D7783 File Offset: 0x007D5983
	public EElementType RoleElementType
	{
		get
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			return (EElementType)((attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.ElementPropertyType) : 0f);
		}
	}

	// Token: 0x170023EC RID: 9196
	// (get) Token: 0x0601A850 RID: 108624 RVA: 0x007D779E File Offset: 0x007D599E
	public float RoleElementEnergy
	{
		get
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return 0f;
			}
			return attributeComponent.GetCurrentValue(EAttributeType.ElementEnergy);
		}
	}

	// Token: 0x170023ED RID: 9197
	// (get) Token: 0x0601A851 RID: 108625 RVA: 0x007D77B7 File Offset: 0x007D59B7
	public float RoleElementEnergyMax
	{
		get
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return 0f;
			}
			return attributeComponent.GetCurrentValue(EAttributeType.ElementEnergyMax);
		}
	}

	// Token: 0x0601A852 RID: 108626 RVA: 0x007D77D0 File Offset: 0x007D59D0
	private void OnElementEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		this.CheckEnergyFull(newValue);
		EElementType roleElementType = this.RoleElementType;
		Singleton<EventSystem>.Instance.EmitWithTarget<EElementType, float, float>(base.Entity, EEventName.CharOnElementEnergyChanged, roleElementType, newValue, oldValue);
		Singleton<EventSystem>.Instance.Emit<EElementType, float, float>(EEventName.CharOnElementEnergyChanged, roleElementType, newValue, oldValue);
	}

	// Token: 0x0601A853 RID: 108627 RVA: 0x007D7818 File Offset: 0x007D5A18
	private void CheckEnergyFull(float energy)
	{
		if (energy >= this.TriggerEnergy - 1E-45f)
		{
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			bool flag;
			if (instance == null)
			{
				flag = false;
			}
			else
			{
				SceneTeamItem teamItem = instance.GetTeamItem((long)base.Entity.Id, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.EntityId
				});
				flag = ((teamItem != null) ? new bool?(teamItem.IsControl()) : null).GetValueOrDefault();
			}
			bool flag2 = flag;
			if (!this.ElementActivated && flag2 && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				this.ElementActivated = true;
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (buffComponent == null)
				{
					return;
				}
				buffComponent.TriggerEvents(EBuffTriggerType.ForWhenOneElementActivated, this.BuffComponent, new Partial_RequirementPayload
				{
					ElementType = new EElementType?(this.RoleElementType)
				});
				return;
			}
		}
		else
		{
			this.ElementActivated = false;
		}
	}

	// Token: 0x0601A854 RID: 108628 RVA: 0x007D78D8 File Offset: 0x007D5AD8
	private void OnStateInherit(Entity oldEntity, bool _)
	{
		if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.NeedCheckEnergy = true;
		}
	}

	// Token: 0x0601A855 RID: 108629 RVA: 0x007D78ED File Offset: 0x007D5AED
	private void OnBattleStateChanged(bool inFight)
	{
		this.NeedCheckEnergy = inFight;
		if (!inFight)
		{
			this.ElementActivated = false;
		}
	}

	// Token: 0x0601A856 RID: 108630 RVA: 0x007D7900 File Offset: 0x007D5B00
	private void CheckEnergyOnce(global::HitInformation hitInformation, HitContext hitContext)
	{
		if (this.NeedCheckEnergy)
		{
			this.CheckEnergyFull(this.RoleElementEnergy);
			this.NeedCheckEnergy = false;
		}
	}

	// Token: 0x0601A857 RID: 108631 RVA: 0x007D7920 File Offset: 0x007D5B20
	public void TriggerEvents(Entity newRole)
	{
		RoleElementComponent component = newRole.GetComponent<RoleElementComponent>();
		Partial_RequirementPayload payload = new Partial_RequirementPayload
		{
			ElementType = new EElementType?(this.RoleElementType)
		};
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null)
		{
			buffComponent.TriggerEvents(EBuffTriggerType.ForWhenElementFusionGoDown, (component != null) ? component.BuffComponent : null, payload);
		}
		if (component != null)
		{
			CharacterBuffComponent buffComponent2 = component.BuffComponent;
			if (buffComponent2 == null)
			{
				return;
			}
			buffComponent2.TriggerEvents(EBuffTriggerType.ForWhenElementFusionGoBattle, this.BuffComponent, payload);
		}
	}

	// Token: 0x0601A858 RID: 108632 RVA: 0x007D7987 File Offset: 0x007D5B87
	private void OnRoleRevive()
	{
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent != null && actorComponent.IsAutonomousProxy)
		{
			this.ClearElementEnergy(base.Entity, 0L);
		}
	}

	// Token: 0x0601A859 RID: 108633 RVA: 0x007D79AB File Offset: 0x007D5BAB
	private void OnRoleDead()
	{
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent != null && actorComponent.IsAutonomousProxy)
		{
			this.ClearElementEnergy(base.Entity, 0L);
		}
	}

	// Token: 0x0601A85A RID: 108634 RVA: 0x007D79D0 File Offset: 0x007D5BD0
	public void ClearElementEnergy(Entity instigator, long consumeBuffId = 0L)
	{
		if (consumeBuffId == 0L)
		{
			consumeBuffId = 3027L;
		}
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent == null)
		{
			return;
		}
		long buffId = consumeBuffId;
		AddBuffParam addBuffParam = new AddBuffParam();
		CreatureDataComponent component = instigator.GetComponent<CreatureDataComponent>();
		addBuffParam.InstigatorId = ((component != null) ? component.GetCreatureDataId() : 0L);
		addBuffParam.Reason = "ClearElementEnergy消耗元素能量";
		buffComponent.AddBuff(buffId, addBuffParam);
	}

	// Token: 0x0601A85B RID: 108635 RVA: 0x007D7A24 File Offset: 0x007D5C24
	private void MultiQteGuide()
	{
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		List<SceneTeamItem> list = (instance != null) ? instance.GetTeamItemsInRange(this.ActorComponent.ActorLocationProxy, 5000f) : null;
		if (list != null)
		{
			foreach (SceneTeamItem sceneTeamItem in list)
			{
				if (!sceneTeamItem.IsMyRole())
				{
					EntityHandle entityHandle = sceneTeamItem.EntityHandle;
					if (entityHandle != null)
					{
						WorldEntity entity = entityHandle.Entity;
						if (entity != null)
						{
							CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
							if (component != null)
							{
								component.AddBuff(3025L, new AddBuffParam
								{
									InstigatorId = this.BuffComponent.CreatureDataId,
									Reason = "用于联机QTE引导提示"
								});
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601A85C RID: 108636 RVA: 0x007D7AEC File Offset: 0x007D5CEC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleElementComponent roleElementComponent = (RoleElementComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (roleElementComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (roleElementComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (roleElementComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SummonedEntity"))
		{
			if (roleElementComponent.SummonedEntity == null)
			{
				this.SummonedEntity = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.SummonedEntity), "SummonedEntity"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleElementComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NeedCheckEnergy"))
		{
			this.NeedCheckEnergy = roleElementComponent.NeedCheckEnergy;
		}
		if (base.CanResetComponentProperty("TriggerEnergy"))
		{
			this.TriggerEnergy = roleElementComponent.TriggerEnergy;
		}
		if (base.CanResetComponentProperty("QteBuffId"))
		{
			this.QteBuffId = roleElementComponent.QteBuffId;
		}
		return true;
	}

	// Token: 0x0400D653 RID: 54867
	[Nullable(2)]
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D654 RID: 54868
	[Nullable(2)]
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D655 RID: 54869
	[Nullable(2)]
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400D656 RID: 54870
	[Nullable(2)]
	private EntityHandle SummonedEntity;

	// Token: 0x0400D657 RID: 54871
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x0400D658 RID: 54872
	private bool NeedCheckEnergy;

	// Token: 0x0400D659 RID: 54873
	public float TriggerEnergy;

	// Token: 0x0400D65A RID: 54874
	private long QteBuffId;
}
