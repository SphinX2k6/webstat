using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003146 RID: 12614
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillFeiXue : SpecialSkillBase
{
	// Token: 0x0601A1DE RID: 106974 RVA: 0x007A9C81 File Offset: 0x007A7E81
	[NullableContext(1)]
	public SpecialSkillFeiXue(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1DF RID: 106975 RVA: 0x007A9C98 File Offset: 0x007A7E98
	public override void OnStart()
	{
		this.Entity = this.SpecialSkillComponent.Entity;
		this.AttributeComponent = this.Entity.GetComponent<BaseAttributeComponent>();
		this.TagComponent = this.Entity.GetComponent<RoleTagComponent>();
		this.ActorComponent = this.Entity.CheckGetComponent<CharacterActorComponent>();
		RoleEnergyComponent component = this.Entity.GetComponent<RoleEnergyComponent>();
		if (component != null)
		{
			component.SetEnableRefreshStarScarByEnergy(false);
		}
		RoleTagComponent tagComponent = this.TagComponent;
		this.HasMorphTag = (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.状态标识.神刀解放"]));
		RoleTagComponent tagComponent2 = this.TagComponent;
		this.HasEnableMorphTag = (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.状态标识.拔刀解禁"]));
		this.RefreshStarScarMaterial();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.AddListener(EAttributeType.Energy, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty), null);
		}
		BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
		if (attributeComponent2 != null)
		{
			attributeComponent2.AddListener(EAttributeType.EnergyMax, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty), null);
		}
		this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.状态标识.神刀解放"], new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChange));
		this.ListenForTagAddOrRemove(GameplayTagDefine.EGameplayTagId["角色.R2T1TaidaonvMd10011.状态标识.拔刀解禁"], new BaseTagComponent.TTagSwitchedCallback(this.OnEnableMorphTagChange));
	}

	// Token: 0x0601A1E0 RID: 106976 RVA: 0x007A9DD8 File Offset: 0x007A7FD8
	public override void OnEnd()
	{
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.RemoveListener(EAttributeType.Energy, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty));
		}
		BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
		if (attributeComponent2 != null)
		{
			attributeComponent2.RemoveListener(EAttributeType.EnergyMax, new Action<EAttributeType, float, float>(this.RefreshStarScarMaterialProperty));
		}
		this.ClearAllTagTask();
	}

	// Token: 0x0601A1E1 RID: 106977 RVA: 0x007A9E2C File Offset: 0x007A802C
	[NullableContext(1)]
	protected void ListenForTagAddOrRemove(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
	{
		RoleTagComponent tagComponent = this.TagComponent;
		if (tagComponent == null)
		{
			return;
		}
		ITagTask item = tagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null);
		this.TagTaskList.Add(item);
	}

	// Token: 0x0601A1E2 RID: 106978 RVA: 0x007A9E60 File Offset: 0x007A8060
	protected void ClearAllTagTask()
	{
		if (this.TagTaskList != null)
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
		}
	}

	// Token: 0x0601A1E3 RID: 106979 RVA: 0x007A9EC4 File Offset: 0x007A80C4
	private void RefreshStarScarMaterialProperty(EAttributeType attribute, float newValue, float oldValue)
	{
		this.RefreshStarScarMaterial();
	}

	// Token: 0x0601A1E4 RID: 106980 RVA: 0x007A9ECC File Offset: 0x007A80CC
	public void RefreshStarScarMaterial()
	{
		if (this.AttributeComponent == null)
		{
			return;
		}
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
		actor.CharRenderingComponent.SetStarScarEnergy(this.GetEnergyPercent());
	}

	// Token: 0x0601A1E5 RID: 106981 RVA: 0x007A9EFC File Offset: 0x007A80FC
	private float GetEnergyPercent()
	{
		if (this.HasMorphTag)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.Energy);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.EnergyMax);
			return currentValue / currentValue2;
		}
		if (this.HasEnableMorphTag)
		{
			return 1f;
		}
		return 0f;
	}

	// Token: 0x0601A1E6 RID: 106982 RVA: 0x007A9F42 File Offset: 0x007A8142
	private void OnMorphTagChange(int tagId, bool tagExist)
	{
		this.HasMorphTag = tagExist;
		this.RefreshStarScarMaterial();
	}

	// Token: 0x0601A1E7 RID: 106983 RVA: 0x007A9F51 File Offset: 0x007A8151
	private void OnEnableMorphTagChange(int tagId, bool tagExist)
	{
		this.HasEnableMorphTag = tagExist;
		this.RefreshStarScarMaterial();
	}

	// Token: 0x0400D19D RID: 53661
	private Entity Entity;

	// Token: 0x0400D19E RID: 53662
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D19F RID: 53663
	private RoleTagComponent TagComponent;

	// Token: 0x0400D1A0 RID: 53664
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D1A1 RID: 53665
	[Nullable(1)]
	private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

	// Token: 0x0400D1A2 RID: 53666
	private bool HasMorphTag;

	// Token: 0x0400D1A3 RID: 53667
	private bool HasEnableMorphTag;
}
