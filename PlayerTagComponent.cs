using System;
using System.Runtime.CompilerServices;

// Token: 0x02003242 RID: 12866
[NullableContext(2)]
[Nullable(0)]
public class PlayerTagComponent : BaseTagComponent
{
	// Token: 0x0601AC9A RID: 109722 RVA: 0x007FC201 File Offset: 0x007FA401
	protected override bool OnCreate(IEntityArgs args = null)
	{
		this.TagContainer.AddAnyExactTagListener(new TAnyTagChangeCallback(this.OnAnyExactTagChanged));
		return true;
	}

	// Token: 0x0601AC9B RID: 109723 RVA: 0x007FC21C File Offset: 0x007FA41C
	protected override bool OnInitData(IEntityArgs args = null)
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
		return true;
	}

	// Token: 0x0601AC9C RID: 109724 RVA: 0x007FC248 File Offset: 0x007FA448
	protected override bool OnClear()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Character;
		ELogAuthor author = ELogAuthor.ZQR;
		string message = "清理编队tag";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerId", this.PlayerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		foreach (int tagId in this.TagContainer.GetAllExactTags())
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItemsByPlayer(this.PlayerId))
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				if (entityHandle != null)
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null)
					{
						BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
						if (component != null)
						{
							component.TagContainer.RemoveExactTag(ETagChannel.Player, tagId);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0601AC9D RID: 109725 RVA: 0x007FC338 File Offset: 0x007FA538
	public Entity GetEntity()
	{
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)this.PlayerId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.PlayerId,
			IsControl = new bool?(true)
		});
		if (teamItem == null)
		{
			return null;
		}
		EntityHandle entityHandle = teamItem.EntityHandle;
		if (entityHandle == null)
		{
			return null;
		}
		return entityHandle.Entity;
	}

	// Token: 0x0601AC9E RID: 109726 RVA: 0x007FC384 File Offset: 0x007FA584
	public BaseTagComponent GetCurrentTagComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseTagComponent>();
	}

	// Token: 0x0601AC9F RID: 109727 RVA: 0x007FC397 File Offset: 0x007FA597
	public bool TagContainerHasTag(int tagId)
	{
		return base.HasTag(tagId);
	}

	// Token: 0x0601ACA0 RID: 109728 RVA: 0x007FC3A0 File Offset: 0x007FA5A0
	public override bool HasTag(int tagId)
	{
		BaseTagComponent currentTagComponent = this.GetCurrentTagComponent();
		return currentTagComponent != null && currentTagComponent.HasTag(tagId);
	}

	// Token: 0x0601ACA1 RID: 109729 RVA: 0x007FC3B4 File Offset: 0x007FA5B4
	protected void OnAnyExactTagChanged(int tagId, int newCount, int oldCount, int exactTagId)
	{
		if (tagId == 0 || oldCount == newCount)
		{
			return;
		}
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItemsByPlayer(this.PlayerId))
		{
			EntityHandle entityHandle = sceneTeamItem.EntityHandle;
			if (entityHandle != null)
			{
				WorldEntity entity = entityHandle.Entity;
				if (entity != null)
				{
					BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
					if (component != null)
					{
						component.TagContainer.UpdateExactTag(ETagChannel.Player, tagId, newCount - oldCount);
					}
				}
			}
		}
	}

	// Token: 0x0601ACA2 RID: 109730 RVA: 0x007FC444 File Offset: 0x007FA644
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PlayerTagComponent playerTagComponent = (PlayerTagComponent)componentTemplate;
		if (base.CanResetComponentProperty("PlayerId"))
		{
			this.PlayerId = playerTagComponent.PlayerId;
		}
		return true;
	}

	// Token: 0x0400D93B RID: 55611
	public int PlayerId;

	// Token: 0x0400D93C RID: 55612
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat OnAnyExactTagChangedStat = Stat.Create("PlayerTagComponent.OnAnyExactTagChanged", "", "");
}
