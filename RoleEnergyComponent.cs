using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020031EE RID: 12782
[NullableContext(2)]
[Nullable(0)]
public class RoleEnergyComponent : EntityComponent
{
	// Token: 0x0601A85F RID: 108639 RVA: 0x007D7C90 File Offset: 0x007D5E90
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.CheckGetComponent<CharacterActorComponent>();
		this.AttributeComponent = base.Entity.CheckGetComponent<BaseAttributeComponent>();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.AddListeners(RoleEnergyConstants.energyAttrIds, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty), "RoleEnergyComponent");
		}
		this.RefreshStarScarMaterialProperty(EAttributeType.None, 0f, 0f);
		return true;
	}

	// Token: 0x0601A860 RID: 108640 RVA: 0x007D7CF8 File Offset: 0x007D5EF8
	protected override bool OnEnd()
	{
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.RemoveListeners(RoleEnergyConstants.energyAttrIds, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty));
		}
		return true;
	}

	// Token: 0x0601A861 RID: 108641 RVA: 0x007D7D1D File Offset: 0x007D5F1D
	private void RefreshStarScarMaterialProperty(EAttributeType attribute, float newValue, float oldValue)
	{
		this.RefreshStarScarMaterial();
	}

	// Token: 0x0601A862 RID: 108642 RVA: 0x007D7D28 File Offset: 0x007D5F28
	public void RefreshStarScarMaterial()
	{
		if (!this.EnableRefreshStarScarByEnergy)
		{
			return;
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.Energy) : 0f;
		BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
		float num2 = (attributeComponent2 != null) ? attributeComponent2.GetCurrentValue(EAttributeType.EnergyMax) : 1f;
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent == null)
		{
			return;
		}
		TsBaseCharacter actor = actorComponent.Actor;
		if (actor == null)
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = actor.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.SetStarScarEnergy(num / num2);
	}

	// Token: 0x0601A863 RID: 108643 RVA: 0x007D7D97 File Offset: 0x007D5F97
	public void SetEnableRefreshStarScarByEnergy(bool enable)
	{
		this.EnableRefreshStarScarByEnergy = enable;
	}

	// Token: 0x0601A864 RID: 108644 RVA: 0x007D7DA0 File Offset: 0x007D5FA0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleEnergyComponent roleEnergyComponent = (RoleEnergyComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (roleEnergyComponent.ActorComponent == null)
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
			if (roleEnergyComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnableRefreshStarScarByEnergy"))
		{
			this.EnableRefreshStarScarByEnergy = roleEnergyComponent.EnableRefreshStarScarByEnergy;
		}
		return true;
	}

	// Token: 0x0400D65C RID: 54876
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D65D RID: 54877
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D65E RID: 54878
	private bool EnableRefreshStarScarByEnergy = true;
}
