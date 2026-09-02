using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.MonsterGroup
{
	// Token: 0x0200572A RID: 22314
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MonsterGroupPatrolModel : ModelBase<MonsterGroupPatrolModel>
	{
		// Token: 0x06038C87 RID: 232583 RVA: 0x00E60E79 File Offset: 0x00E5F079
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06038C88 RID: 232584 RVA: 0x00E60E7C File Offset: 0x00E5F07C
		protected override bool OnClear()
		{
			foreach (MonsterGroupInfo monsterGroupInfo in this.MonsterGroups.Values)
			{
				monsterGroupInfo.Clear();
			}
			this.MonsterEntityInfoMap.Clear();
			this.MonsterGroups.Clear();
			return true;
		}

		// Token: 0x06038C89 RID: 232585 RVA: 0x00E60EE8 File Offset: 0x00E5F0E8
		public void RemoveMonsterGroup(int id)
		{
			if (!this.MonsterGroups.ContainsKey(id))
			{
				return;
			}
			MonsterGroupInfo monsterGroupInfo = this.MonsterGroups[id];
			foreach (KeyValuePair<int, MonsterPatrolInfo> keyValuePair in monsterGroupInfo.GroupInfo)
			{
				this.MonsterEntityInfoMap.Remove(keyValuePair.Value.EntityId);
			}
			monsterGroupInfo.Clear();
			this.MonsterGroups.Remove(id);
		}

		// Token: 0x06038C8A RID: 232586 RVA: 0x00E60F7C File Offset: 0x00E5F17C
		[NullableContext(2)]
		public MonsterGroupInfo GetMonsterGroup(int id)
		{
			if (this.MonsterGroups.Count <= 0)
			{
				return null;
			}
			MonsterGroupInfo result;
			if (!this.MonsterGroups.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06038C8B RID: 232587 RVA: 0x00E60FAC File Offset: 0x00E5F1AC
		[NullableContext(2)]
		public MonsterPatrolInfo GetMonsterInfoByEntityId(int id)
		{
			MonsterPatrolInfo result;
			if (!this.MonsterEntityInfoMap.TryGetValue(id, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06038C8C RID: 232588 RVA: 0x00E60FCC File Offset: 0x00E5F1CC
		public bool TryAddMonsterToGroup(int groupEntityId, int pbDataId)
		{
			MonsterGroupInfo monsterGroupInfo;
			if (!this.MonsterGroups.TryGetValue(groupEntityId, out monsterGroupInfo))
			{
				return false;
			}
			if (!monsterGroupInfo.TryAddMonster(pbDataId))
			{
				return false;
			}
			foreach (KeyValuePair<int, MonsterPatrolInfo> keyValuePair in monsterGroupInfo.GroupInfo)
			{
				MonsterPatrolInfo value = keyValuePair.Value;
				if (value.PbDataId == pbDataId)
				{
					this.MonsterEntityInfoMap[value.EntityId] = value;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGeneratedMonsterPatrolGroup, groupEntityId);
					break;
				}
			}
			return true;
		}

		// Token: 0x06038C8D RID: 232589 RVA: 0x00E6106C File Offset: 0x00E5F26C
		public bool RemoveMemberOnEntityDestroyed(int groupEntityId, int memberEntityId)
		{
			MonsterGroupInfo monsterGroupInfo;
			if (!this.MonsterGroups.TryGetValue(groupEntityId, out monsterGroupInfo))
			{
				this.MonsterEntityInfoMap.Remove(memberEntityId);
				return false;
			}
			return monsterGroupInfo.RemoveMemberByEntityId(memberEntityId);
		}

		// Token: 0x06038C8E RID: 232590 RVA: 0x00E610A0 File Offset: 0x00E5F2A0
		public bool CreateGroup(int entityId, GroupAiComponent groupComp, IReadOnlyList<int> registeredPbDataIds)
		{
			MonsterGroupInfo monsterGroupInfo = new MonsterGroupInfo(entityId);
			monsterGroupInfo.OnMemberRemoved = delegate(int memberEntityId)
			{
				this.MonsterEntityInfoMap.Remove(memberEntityId);
			};
			if (!monsterGroupInfo.Init(groupComp, registeredPbDataIds))
			{
				return false;
			}
			foreach (KeyValuePair<int, MonsterPatrolInfo> keyValuePair in monsterGroupInfo.GroupInfo)
			{
				MonsterPatrolInfo value = keyValuePair.Value;
				this.MonsterEntityInfoMap[value.EntityId] = value;
			}
			this.MonsterGroups[entityId] = monsterGroupInfo;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGeneratedMonsterPatrolGroup, entityId);
			return true;
		}

		// Token: 0x04020599 RID: 132505
		public readonly Dictionary<int, MonsterPatrolInfo> MonsterEntityInfoMap = new Dictionary<int, MonsterPatrolInfo>();

		// Token: 0x0402059A RID: 132506
		public readonly Dictionary<int, MonsterGroupInfo> MonsterGroups = new Dictionary<int, MonsterGroupInfo>();
	}
}
