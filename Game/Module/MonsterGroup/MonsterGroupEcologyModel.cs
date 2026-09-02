using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.MonsterGroup
{
	// Token: 0x02005728 RID: 22312
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MonsterGroupEcologyModel : ModelBase<MonsterGroupEcologyModel>
	{
		// Token: 0x06038C7F RID: 232575 RVA: 0x00E60D2B File Offset: 0x00E5EF2B
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06038C80 RID: 232576 RVA: 0x00E60D30 File Offset: 0x00E5EF30
		protected override bool OnClear()
		{
			foreach (KeyValuePair<int, MonsterGroupEcologyInfo> keyValuePair in this.EcologyGroups)
			{
				keyValuePair.Value.Clear();
			}
			this.EcologyGroups.Clear();
			return true;
		}

		// Token: 0x06038C81 RID: 232577 RVA: 0x00E60D94 File Offset: 0x00E5EF94
		[NullableContext(2)]
		public MonsterGroupEcologyInfo GetEcologyGroup(int groupEntityId)
		{
			MonsterGroupEcologyInfo result;
			this.EcologyGroups.TryGetValue(groupEntityId, out result);
			return result;
		}

		// Token: 0x06038C82 RID: 232578 RVA: 0x00E60DB4 File Offset: 0x00E5EFB4
		public void RemoveEcologyGroup(int groupEntityId)
		{
			MonsterGroupEcologyInfo monsterGroupEcologyInfo;
			if (!this.EcologyGroups.TryGetValue(groupEntityId, out monsterGroupEcologyInfo))
			{
				return;
			}
			monsterGroupEcologyInfo.Clear();
			this.EcologyGroups.Remove(groupEntityId);
		}

		// Token: 0x06038C83 RID: 232579 RVA: 0x00E60DE8 File Offset: 0x00E5EFE8
		public bool RemoveMemberOnEntityDestroyed(int groupEntityId, int memberEntityId)
		{
			MonsterGroupEcologyInfo monsterGroupEcologyInfo;
			return this.EcologyGroups.TryGetValue(groupEntityId, out monsterGroupEcologyInfo) && monsterGroupEcologyInfo.RemoveMemberByEntityId(memberEntityId);
		}

		// Token: 0x06038C84 RID: 232580 RVA: 0x00E60E10 File Offset: 0x00E5F010
		public bool TryAddMemberToEcologyGroup(int groupEntityId, int pbDataId)
		{
			MonsterGroupEcologyInfo monsterGroupEcologyInfo;
			return this.EcologyGroups.TryGetValue(groupEntityId, out monsterGroupEcologyInfo) && monsterGroupEcologyInfo.TryAddMember(pbDataId);
		}

		// Token: 0x06038C85 RID: 232581 RVA: 0x00E60E38 File Offset: 0x00E5F038
		public bool GenerateAddEcologyGroup(int entityId, GroupAiComponent groupComp, IReadOnlyList<int> registeredPbDataIds)
		{
			MonsterGroupEcologyInfo monsterGroupEcologyInfo = new MonsterGroupEcologyInfo(entityId);
			if (!monsterGroupEcologyInfo.Init(groupComp, registeredPbDataIds))
			{
				return false;
			}
			this.EcologyGroups[entityId] = monsterGroupEcologyInfo;
			return true;
		}

		// Token: 0x04020592 RID: 132498
		public readonly Dictionary<int, MonsterGroupEcologyInfo> EcologyGroups = new Dictionary<int, MonsterGroupEcologyInfo>();
	}
}
