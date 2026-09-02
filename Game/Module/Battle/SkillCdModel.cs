using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F43 RID: 24387
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillCdModel : ModelBase<SkillCdModel>
	{
		// Token: 0x0603D449 RID: 250953 RVA: 0x00F94D9C File Offset: 0x00F92F9C
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603D44A RID: 250954 RVA: 0x00F94D9F File Offset: 0x00F92F9F
		protected override bool OnLeaveLevel()
		{
			this.InstanceDungeonSkillCdData.Clear();
			this.InstanceDungeonPassiveSkillCdData.Clear();
			return true;
		}

		// Token: 0x0603D44B RID: 250955 RVA: 0x00F94DB8 File Offset: 0x00F92FB8
		protected override bool OnClear()
		{
			this.MainWorldSkillCdData.Clear();
			this.MainWorldPassiveSkillCdData.Clear();
			this.InstanceDungeonSkillCdData.Clear();
			this.InstanceDungeonPassiveSkillCdData.Clear();
			return true;
		}

		// Token: 0x0603D44C RID: 250956 RVA: 0x00F94DE7 File Offset: 0x00F92FE7
		public WorldSkillCdData GetCurWorldSkillCdData()
		{
			if (!this.IsUseMainWorldData())
			{
				return this.InstanceDungeonSkillCdData;
			}
			return this.MainWorldSkillCdData;
		}

		// Token: 0x0603D44D RID: 250957 RVA: 0x00F94DFE File Offset: 0x00F92FFE
		public WorldPassiveSkillCdData GetCurWorldPassiveSkillCdData()
		{
			if (!this.IsUseMainWorldData())
			{
				return this.InstanceDungeonPassiveSkillCdData;
			}
			return this.MainWorldPassiveSkillCdData;
		}

		// Token: 0x0603D44E RID: 250958 RVA: 0x00F94E15 File Offset: 0x00F93015
		public void HandlePlayerSkillInfoPbNotify(PlayerSkillInfoPbNotify notify)
		{
			this.MainWorldSkillCdData.HandlePlayerSkillInfoPbNotify(notify);
		}

		// Token: 0x0603D44F RID: 250959 RVA: 0x00F94E23 File Offset: 0x00F93023
		public void HandlePassiveSkillNotify(PassiveSkillNotify notify)
		{
			this.MainWorldPassiveSkillCdData.HandlePassiveSkillNotify(notify);
		}

		// Token: 0x0603D450 RID: 250960 RVA: 0x00F94E34 File Offset: 0x00F93034
		private bool IsUseMainWorldData()
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			return instanceId == 0 || ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.ShareAttri != 0;
		}

		// Token: 0x0603D451 RID: 250961 RVA: 0x00F94E70 File Offset: 0x00F93070
		[NullableContext(2)]
		public GroupSkillCdInfo GetGroupSkillCdInfoBySkillId(int entityId, int skillId)
		{
			WorldSkillCdData curWorldSkillCdData = this.GetCurWorldSkillCdData();
			SkillCdData allShareSkillCdData = curWorldSkillCdData.AllShareSkillCdData;
			int key;
			if (allShareSkillCdData.SkillId2GroupIdMap.TryGetValue(skillId, out key))
			{
				return allShareSkillCdData.GroupSkillCdInfoMap.GetValueOrDefault(key);
			}
			if (curWorldSkillCdData.EntitySkillCdMap.TryGetValue(entityId, out allShareSkillCdData) && allShareSkillCdData.SkillId2GroupIdMap.TryGetValue(skillId, out key))
			{
				return allShareSkillCdData.GroupSkillCdInfoMap.GetValueOrDefault(key);
			}
			return null;
		}

		// Token: 0x040225D2 RID: 140754
		private readonly WorldSkillCdData MainWorldSkillCdData = new WorldSkillCdData();

		// Token: 0x040225D3 RID: 140755
		private readonly WorldPassiveSkillCdData MainWorldPassiveSkillCdData = new WorldPassiveSkillCdData();

		// Token: 0x040225D4 RID: 140756
		private readonly WorldSkillCdData InstanceDungeonSkillCdData = new WorldSkillCdData();

		// Token: 0x040225D5 RID: 140757
		private readonly WorldPassiveSkillCdData InstanceDungeonPassiveSkillCdData = new WorldPassiveSkillCdData();

		// Token: 0x040225D6 RID: 140758
		public bool SkillDebugMode;
	}
}
