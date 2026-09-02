using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200323E RID: 12862
public class PlayerAttributeComponent : BaseAttributeComponent
{
	// Token: 0x0601AC55 RID: 109653 RVA: 0x007FA8BC File Offset: 0x007F8ABC
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
		return true;
	}

	// Token: 0x0601AC56 RID: 109654 RVA: 0x007FA8E8 File Offset: 0x007F8AE8
	public override void UpdateCurrentValue(EAttributeType attrId)
	{
		base.UpdateCurrentValue(attrId);
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItemsByPlayer(this.PlayerId))
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(sceneTeamItem.GetCreatureDataId());
			if (entity != null)
			{
				WorldEntity entity2 = entity.Entity;
				if (entity2 != null)
				{
					BaseAttributeComponent component = entity2.GetComponent<BaseAttributeComponent>();
					if (component != null)
					{
						component.UpdateCurrentValue(attrId);
					}
				}
			}
		}
	}

	// Token: 0x0601AC57 RID: 109655 RVA: 0x007FA978 File Offset: 0x007F8B78
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PlayerAttributeComponent playerAttributeComponent = (PlayerAttributeComponent)componentTemplate;
		if (base.CanResetComponentProperty("PlayerId"))
		{
			this.PlayerId = playerAttributeComponent.PlayerId;
		}
		return true;
	}

	// Token: 0x0400D92D RID: 55597
	private int PlayerId;
}
