using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E91 RID: 20113
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerDefenseEventMonsterModel : TowerDefenseEventEntityModel, ITowerDefenseEventMonsterInfo, ITowerDefenseEventCombatInfo, ITowerDefenseEventConfigInfo
	{
		// Token: 0x17008916 RID: 35094
		// (get) Token: 0x06033F6C RID: 212844 RVA: 0x00D002C6 File Offset: 0x00CFE4C6
		// (set) Token: 0x06033F6D RID: 212845 RVA: 0x00D002CE File Offset: 0x00CFE4CE
		public int ConfigId { get; set; }

		// Token: 0x17008917 RID: 35095
		// (get) Token: 0x06033F6E RID: 212846 RVA: 0x00D002D7 File Offset: 0x00CFE4D7
		// (set) Token: 0x06033F6F RID: 212847 RVA: 0x00D002DF File Offset: 0x00CFE4DF
		public ETowerDefenseEventMonsterDeathType DeathType { get; set; }

		// Token: 0x17008918 RID: 35096
		// (get) Token: 0x06033F70 RID: 212848 RVA: 0x00D002E8 File Offset: 0x00CFE4E8
		// (set) Token: 0x06033F71 RID: 212849 RVA: 0x00D002F0 File Offset: 0x00CFE4F0
		public int BuffRadius { get; set; }

		// Token: 0x17008919 RID: 35097
		// (get) Token: 0x06033F72 RID: 212850 RVA: 0x00D002F9 File Offset: 0x00CFE4F9
		// (set) Token: 0x06033F73 RID: 212851 RVA: 0x00D00301 File Offset: 0x00CFE501
		public List<int> BuffIds { get; set; }

		// Token: 0x1700891A RID: 35098
		// (get) Token: 0x06033F74 RID: 212852 RVA: 0x00D0030A File Offset: 0x00CFE50A
		// (set) Token: 0x06033F75 RID: 212853 RVA: 0x00D00312 File Offset: 0x00CFE512
		public List<int> SpawnIds { get; set; }

		// Token: 0x1700891B RID: 35099
		// (get) Token: 0x06033F76 RID: 212854 RVA: 0x00D0031B File Offset: 0x00CFE51B
		// (set) Token: 0x06033F77 RID: 212855 RVA: 0x00D00323 File Offset: 0x00CFE523
		public int PolluteRadius { get; set; }

		// Token: 0x06033F78 RID: 212856 RVA: 0x00D0032C File Offset: 0x00CFE52C
		[NullableContext(1)]
		public static TowerDefenseEventMonsterModel InitFromConfigId(int configId)
		{
			TowerDefenseEventMonsterModel towerDefenseEventMonsterModel = TowerDefenseEventMonsterModel.MonsterPool.Get() ?? TowerDefenseEventMonsterModel.MonsterPool.Create();
			towerDefenseEventMonsterModel.ConfigId = configId;
			return towerDefenseEventMonsterModel;
		}

		// Token: 0x06033F79 RID: 212857 RVA: 0x00D00350 File Offset: 0x00CFE550
		[NullableContext(1)]
		[return: Nullable(2)]
		public new static ITowerDefenseEventCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			EntityComponentPb entityComponentPb;
			if (!componentDataMap.ContainsKey("SimpleCombatComponentPb") || !componentDataMap.TryGetValue("TrapDefenseComponentPb", out entityComponentPb))
			{
				return null;
			}
			if (entityComponentPb.TrapDefenseComponentPb.MonsterPbData == null)
			{
				return null;
			}
			TowerDefenseEventMonsterModel towerDefenseEventMonsterModel = TowerDefenseEventMonsterModel.MonsterPool.Get() ?? TowerDefenseEventMonsterModel.MonsterPool.Create();
			towerDefenseEventMonsterModel.InitFromProto(entityData, componentDataMap);
			return towerDefenseEventMonsterModel;
		}

		// Token: 0x06033F7A RID: 212858 RVA: 0x00D003AA File Offset: 0x00CFE5AA
		public new static void Clear()
		{
			TowerDefenseEventMonsterModel.MonsterPool.Clear();
		}

		// Token: 0x06033F7B RID: 212859 RVA: 0x00D003B8 File Offset: 0x00CFE5B8
		[NullableContext(1)]
		protected override void InitFromProto(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
		{
			base.InitFromProto(entityData, componentDataMap);
			TrapDefenseComponentPb trapDefenseComponentPb = componentDataMap["TrapDefenseComponentPb"].TrapDefenseComponentPb;
			this.ConfigId = trapDefenseComponentPb.MonsterPbData.ConfigId;
			this.DeathType = ETowerDefenseEventMonsterDeathType.Normal;
			this.BuffRadius = 0;
			this.BuffIds = null;
			this.SpawnIds = null;
			this.PolluteRadius = 0;
		}

		// Token: 0x06033F7C RID: 212860 RVA: 0x00D00414 File Offset: 0x00CFE614
		[NullableContext(1)]
		public override void Update(ITowerDefenseEventCombatInfo other)
		{
			base.Update(other);
			ITowerDefenseEventMonsterInfo towerDefenseEventMonsterInfo = other as ITowerDefenseEventMonsterInfo;
			if (towerDefenseEventMonsterInfo != null)
			{
				this.ConfigId = towerDefenseEventMonsterInfo.ConfigId;
				this.DeathType = towerDefenseEventMonsterInfo.DeathType;
				this.BuffRadius = towerDefenseEventMonsterInfo.BuffRadius;
				this.BuffIds = towerDefenseEventMonsterInfo.BuffIds;
				this.SpawnIds = towerDefenseEventMonsterInfo.SpawnIds;
				this.PolluteRadius = towerDefenseEventMonsterInfo.PolluteRadius;
				return;
			}
			this.ConfigId = 0;
			this.DeathType = ETowerDefenseEventMonsterDeathType.Normal;
			this.BuffRadius = 0;
			this.BuffIds = null;
			this.SpawnIds = null;
			this.PolluteRadius = 0;
		}

		// Token: 0x06033F7D RID: 212861 RVA: 0x00D004A5 File Offset: 0x00CFE6A5
		public override void Reset()
		{
			base.Reset();
			this.ConfigId = 0;
			this.DeathType = ETowerDefenseEventMonsterDeathType.Normal;
			this.BuffRadius = 0;
			this.BuffIds = null;
			this.SpawnIds = null;
			this.PolluteRadius = 0;
		}

		// Token: 0x06033F7E RID: 212862 RVA: 0x00D004D7 File Offset: 0x00CFE6D7
		public override void Release()
		{
			this.Reset();
			TowerDefenseEventMonsterModel.MonsterPool.Put(this);
		}

		// Token: 0x06033F7F RID: 212863 RVA: 0x00D004EB File Offset: 0x00CFE6EB
		[NullableContext(1)]
		public new ITowerDefenseEventCombatInfo Clone()
		{
			TowerDefenseEventMonsterModel towerDefenseEventMonsterModel = TowerDefenseEventMonsterModel.MonsterPool.Get() ?? TowerDefenseEventMonsterModel.MonsterPool.Create();
			towerDefenseEventMonsterModel.Update(this);
			return towerDefenseEventMonsterModel;
		}

		// Token: 0x0401E0AD RID: 123053
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Pool<TowerDefenseEventMonsterModel> MonsterPool = new Pool<TowerDefenseEventMonsterModel>(100, () => new TowerDefenseEventMonsterModel(), null);
	}
}
