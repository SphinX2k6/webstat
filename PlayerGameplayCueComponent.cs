using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003240 RID: 12864
[NullableContext(1)]
[Nullable(0)]
public class PlayerGameplayCueComponent : BaseGameplayCueComponent
{
	// Token: 0x0601AC8D RID: 109709 RVA: 0x007FBE48 File Offset: 0x007FA048
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
		return true;
	}

	// Token: 0x0601AC8E RID: 109710 RVA: 0x007FBE74 File Offset: 0x007FA074
	protected override bool OnStart()
	{
		base.OnStart();
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return true;
	}

	// Token: 0x0601AC8F RID: 109711 RVA: 0x007FBE9A File Offset: 0x007FA09A
	protected override bool OnEnd()
	{
		base.OnEnd();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return true;
	}

	// Token: 0x0601AC90 RID: 109712 RVA: 0x007FBEC0 File Offset: 0x007FA0C0
	[NullableContext(2)]
	protected override EntityHandle GetEntityHandle()
	{
		SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(this.PlayerId);
		long? num;
		if (teamPlayerData == null)
		{
			num = null;
		}
		else
		{
			SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
			if (currentGroup == null)
			{
				num = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
			}
		}
		long? num2 = num;
		return ModelBase<CreatureModel>.Instance.GetEntity(num2.GetValueOrDefault());
	}

	// Token: 0x0601AC91 RID: 109713 RVA: 0x007FBF30 File Offset: 0x007FA130
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		foreach (GameplayCueBase gameplayCueBase in base.GetAllCurrentCueRef())
		{
			if (gameplayCueBase.EntityHandle != newEntityHandle)
			{
				gameplayCueBase.OnChangeRole(newEntityHandle);
			}
		}
	}

	// Token: 0x0601AC92 RID: 109714 RVA: 0x007FBF88 File Offset: 0x007FA188
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PlayerGameplayCueComponent playerGameplayCueComponent = (PlayerGameplayCueComponent)componentTemplate;
		if (base.CanResetComponentProperty("PlayerId"))
		{
			this.PlayerId = playerGameplayCueComponent.PlayerId;
		}
		return true;
	}

	// Token: 0x0400D939 RID: 55609
	protected int PlayerId;
}
