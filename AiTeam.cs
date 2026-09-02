using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02000D17 RID: 3351
[NullableContext(1)]
[Nullable(0)]
public class AiTeam
{
	// Token: 0x06004407 RID: 17415 RVA: 0x0008398C File Offset: 0x00081B8C
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		if (oldEntityHandle == null)
		{
			return;
		}
		AiScheduleGroup aiScheduleGroup;
		if (this.TeamScheduleGroups.TryGetValue(oldEntityHandle, out aiScheduleGroup))
		{
			this.TeamScheduleGroups.Remove(oldEntityHandle);
			this.TeamScheduleGroups[newEntityHandle] = aiScheduleGroup;
			aiScheduleGroup.Target = newEntityHandle;
		}
	}

	// Token: 0x06004408 RID: 17416 RVA: 0x000839D0 File Offset: 0x00081BD0
	public void Init(int levelId)
	{
		ConfigBase<AiConfig>.Instance.LoadAiTeamConfigNew(this, levelId);
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		foreach (AiTeamAreaNew aiTeamAreaNew in this.AiTeamAreas)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			this.AreaCharTypeToPriority.Add(dictionary);
			int num = 0;
			foreach (int key in aiTeamAreaNew.CharTypes())
			{
				num = (dictionary[key] = num + 1);
			}
		}
	}

	// Token: 0x06004409 RID: 17417 RVA: 0x00083A8C File Offset: 0x00081C8C
	public void Clear()
	{
		this.TeamMemberToGroup.Clear();
		this.TeamScheduleGroups.Clear();
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x0600440A RID: 17418 RVA: 0x00083AC0 File Offset: 0x00081CC0
	public void AddMember(AiController aiController)
	{
		this.TeamMemberToGroup[aiController] = null;
	}

	// Token: 0x0600440B RID: 17419 RVA: 0x00083AD0 File Offset: 0x00081CD0
	public void RemoveMember(AiController ai)
	{
		if (!this.TeamMemberToGroup.Remove(ai))
		{
			return;
		}
		foreach (KeyValuePair<EntityHandle, AiScheduleGroup> keyValuePair in this.TeamScheduleGroups)
		{
			keyValuePair.Value.Remove(ai);
		}
	}

	// Token: 0x0600440C RID: 17420 RVA: 0x00083B3C File Offset: 0x00081D3C
	public void Tick()
	{
		this.ReorganizeGroup();
		foreach (KeyValuePair<EntityHandle, AiScheduleGroup> keyValuePair in this.TeamScheduleGroups)
		{
			keyValuePair.Value.ScheduleGroup();
		}
	}

	// Token: 0x0600440D RID: 17421 RVA: 0x00083B9C File Offset: 0x00081D9C
	private void ReorganizeGroup()
	{
		foreach (KeyValuePair<EntityHandle, AiScheduleGroup> keyValuePair in this.TeamScheduleGroups)
		{
			keyValuePair.Value.CheckTargetAndRemove();
		}
		foreach (KeyValuePair<AiController, AiScheduleGroup> keyValuePair2 in this.TeamMemberToGroup)
		{
			AiController key = keyValuePair2.Key;
			EntityHandle currentTarget = key.AiHateList.GetCurrentTarget();
			if (currentTarget == null || !currentTarget.Valid)
			{
				this.TeamMemberToGroup[key] = null;
			}
			else
			{
				WorldEntity entity = currentTarget.Entity;
				BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null)
				{
					if (baseActorComponent.CreatureData.GetEntityType() != EEntityType.Player)
					{
						ControllerBase<BlackboardController>.Instance.SetBooleanValueByEntity(key.CharAiDesignComp.Entity.Id, "TeamAttacker", true);
						this.TeamMemberToGroup[key] = null;
					}
					else
					{
						AiScheduleGroup aiScheduleGroup;
						if (!this.TeamScheduleGroups.TryGetValue(currentTarget, out aiScheduleGroup))
						{
							aiScheduleGroup = new AiScheduleGroup(this, currentTarget);
							this.TeamScheduleGroups[currentTarget] = aiScheduleGroup;
						}
						aiScheduleGroup.TryAdd(key);
						this.TeamMemberToGroup[key] = aiScheduleGroup;
					}
				}
			}
		}
		List<EntityHandle> list = new List<EntityHandle>();
		foreach (KeyValuePair<EntityHandle, AiScheduleGroup> keyValuePair3 in this.TeamScheduleGroups)
		{
			if (keyValuePair3.Value.IsEmpty())
			{
				list.Add(keyValuePair3.Key);
			}
		}
		foreach (EntityHandle key2 in list)
		{
			this.TeamScheduleGroups.Remove(key2);
		}
	}

	// Token: 0x0600440E RID: 17422 RVA: 0x00083DB4 File Offset: 0x00081FB4
	[return: Nullable(2)]
	public AiAreaMemberData GetAiTeamAreaMemberData(AiController ai)
	{
		AiScheduleGroup aiScheduleGroup;
		this.TeamMemberToGroup.TryGetValue(ai, out aiScheduleGroup);
		if (aiScheduleGroup == null)
		{
			return null;
		}
		return aiScheduleGroup.GetMemberData(ai);
	}

	// Token: 0x040011EE RID: 4590
	public int TeamId;

	// Token: 0x040011EF RID: 4591
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	public readonly Dictionary<AiController, AiScheduleGroup> TeamMemberToGroup = new Dictionary<AiController, AiScheduleGroup>();

	// Token: 0x040011F0 RID: 4592
	public AiTeamLevelNew? AiTeamLevel;

	// Token: 0x040011F1 RID: 4593
	[Nullable(2)]
	public List<AiTeamAreaNew> AiTeamAreas;

	// Token: 0x040011F2 RID: 4594
	[Nullable(2)]
	public List<AiTeamAttack> AiTeamAttacks;

	// Token: 0x040011F3 RID: 4595
	public readonly List<Dictionary<int, int>> AreaCharTypeToPriority = new List<Dictionary<int, int>>();

	// Token: 0x040011F4 RID: 4596
	private readonly Dictionary<EntityHandle, AiScheduleGroup> TeamScheduleGroups = new Dictionary<EntityHandle, AiScheduleGroup>();
}
