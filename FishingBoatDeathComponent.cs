using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003287 RID: 12935
[NullableContext(2)]
[Nullable(0)]
public class FishingBoatDeathComponent : BaseDeathComponent
{
	// Token: 0x0601B137 RID: 110903 RVA: 0x0081D0CC File Offset: 0x0081B2CC
	protected override bool OnInit()
	{
		this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		this.SkillComponent = base.Entity.GetComponent<BaseSkillComponent>();
		this.BuffComponent = base.Entity.GetComponent<CharacterBuffComponent>();
		this.AttributeComponent = base.Entity.GetComponent<BaseAttributeComponent>();
		return true;
	}

	// Token: 0x0601B138 RID: 110904 RVA: 0x0081D130 File Offset: 0x0081B330
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		if (this.CreatureDataComponent.GetLivingStatus().GetValueOrDefault() == LivingStatus.Dead)
		{
			this.ExecuteDeath(null);
		}
		return true;
	}

	// Token: 0x0601B139 RID: 110905 RVA: 0x0081D170 File Offset: 0x0081B370
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
		BaseSkillComponent skillComponent = this.SkillComponent;
		if (skillComponent != null)
		{
			skillComponent.StopAllSkills("RoleDeathComponent.ExecuteDeath");
		}
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null)
		{
			buffComponent.RemoveAllDurationBuffs("实体死亡清理持续型buff");
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.ClearSpecialEnergy();
		}
		base.PlayDeathMontageWithType(ECharacterDeathMontageType.Die, null, preMessageId, null);
		return true;
	}

	// Token: 0x0601B13A RID: 110906 RVA: 0x0081D200 File Offset: 0x0081B400
	public void ExecuteRevive()
	{
		Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.LYY, "执行捕鱼船复活", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.IsDeadInternal = false;
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]));
	}

	// Token: 0x0601B13B RID: 110907 RVA: 0x0081D258 File Offset: 0x0081B458
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		FishingBoatDeathComponent fishingBoatDeathComponent = (FishingBoatDeathComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (fishingBoatDeathComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (fishingBoatDeathComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComponent"))
		{
			if (fishingBoatDeathComponent.SkillComponent == null)
			{
				this.SkillComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComponent), "SkillComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (fishingBoatDeathComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (fishingBoatDeathComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DC23 RID: 56355
	private CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400DC24 RID: 56356
	private BaseTagComponent TagComponent;

	// Token: 0x0400DC25 RID: 56357
	private BaseSkillComponent SkillComponent;

	// Token: 0x0400DC26 RID: 56358
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400DC27 RID: 56359
	private BaseAttributeComponent AttributeComponent;
}
