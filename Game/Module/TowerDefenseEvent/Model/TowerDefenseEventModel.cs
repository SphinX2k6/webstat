using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E95 RID: 20117
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class TowerDefenseEventModel : ModelBase<TowerDefenseEventModel>
	{
		// Token: 0x06033FBF RID: 212927 RVA: 0x00D00E24 File Offset: 0x00CFF024
		public void InitInstance(TrapDefenseActivity? config)
		{
			this.Waves.Clear();
			if (config != null)
			{
				IReadOnlyList<TrapDefenseWave> configList = ConfigTrapDefenseWaveByTrapDefenseLevelId.GetConfigList(config.Value.Id, true);
				if (configList != null && configList.Count > 0)
				{
					foreach (TrapDefenseWave item in configList)
					{
						this.Waves.Add(item);
					}
					this.Waves.Sort((TrapDefenseWave a, TrapDefenseWave b) => a.WaveId - b.WaveId);
				}
			}
		}

		// Token: 0x1700892D RID: 35117
		// (get) Token: 0x06033FC0 RID: 212928 RVA: 0x00D00ED4 File Offset: 0x00CFF0D4
		public int CurrentTrapCount
		{
			get
			{
				return this.TrapEntities.Count;
			}
		}

		// Token: 0x06033FC1 RID: 212929 RVA: 0x00D00EE4 File Offset: 0x00CFF0E4
		public bool HasPlaceToBuildTrap()
		{
			long maxTrapCount = ModelBase<TrapDefenseModel>.Instance.BattleData.GetMaxTrapCount();
			return (long)this.CurrentTrapCount < maxTrapCount;
		}

		// Token: 0x06033FC2 RID: 212930 RVA: 0x00D00F0C File Offset: 0x00CFF10C
		public void GetWaveSplineIds(List<int> splineIds)
		{
			splineIds.Clear();
			int batch = ModelBase<TrapDefenseModel>.Instance.BattleData.GetBatch();
			if (batch < 1 || batch > this.Waves.Count)
			{
				return;
			}
			splineIds.AddRange(this.Waves[batch - 1].GetSplineListBytes());
		}

		// Token: 0x06033FC3 RID: 212931 RVA: 0x00D00F64 File Offset: 0x00CFF164
		public bool IsEnoughGoldToBuildTrap(ITowerDefenseEventTrapBaseInfo baseInfo)
		{
			long goldNum = ModelBase<TrapDefenseModel>.Instance.BattleData.GetGoldNum();
			TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData;
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.InBuildingDataMap.TryGetValue(baseInfo.TrapId, out trapDefenseBuildingDevelopItemData);
			return trapDefenseBuildingDevelopItemData != null && (long)trapDefenseBuildingDevelopItemData.GetBuildingCost(true) <= goldNum;
		}

		// Token: 0x06033FC4 RID: 212932 RVA: 0x00D00FB1 File Offset: 0x00CFF1B1
		public bool ValidateBuildTrap(ITowerDefenseEventTrapBaseInfo baseInfo)
		{
			return this.HasPlaceToBuildTrap() && this.IsEnoughGoldToBuildTrap(baseInfo);
		}

		// Token: 0x06033FC5 RID: 212933 RVA: 0x00D00FC4 File Offset: 0x00CFF1C4
		[return: Nullable(2)]
		public string TryAddEntity(ITowerDefenseEventCombatInfo entityModel)
		{
			if (entityModel == null || !entityModel.IsValid())
			{
				return "实体数据无效";
			}
			long uid = entityModel.Uid;
			if (!this.AllEntities.TryAdd(uid, entityModel))
			{
				return "实体数据已存在";
			}
			ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = entityModel as ITowerDefenseEventTrapInfo;
			if (towerDefenseEventTrapInfo != null)
			{
				this.TrapEntities[uid] = towerDefenseEventTrapInfo;
			}
			return null;
		}

		// Token: 0x06033FC6 RID: 212934 RVA: 0x00D01018 File Offset: 0x00CFF218
		[NullableContext(2)]
		public ITowerDefenseEventCombatInfo GetEntity(long uid)
		{
			ITowerDefenseEventCombatInfo result;
			this.AllEntities.TryGetValue(uid, out result);
			return result;
		}

		// Token: 0x06033FC7 RID: 212935 RVA: 0x00D01038 File Offset: 0x00CFF238
		public void GetAllEntities(List<ITowerDefenseEventCombatInfo> entities)
		{
			entities.Clear();
			foreach (ITowerDefenseEventCombatInfo item in this.AllEntities.Values)
			{
				entities.Add(item);
			}
		}

		// Token: 0x06033FC8 RID: 212936 RVA: 0x00D01098 File Offset: 0x00CFF298
		public bool HasAnyTrapByType(int type)
		{
			using (Dictionary<long, ITowerDefenseEventTrapInfo>.ValueCollection.Enumerator enumerator = this.TrapEntities.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.TrapId == type)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033FC9 RID: 212937 RVA: 0x00D010F8 File Offset: 0x00CFF2F8
		[NullableContext(2)]
		public ITowerDefenseEventCombatInfo RemoveEntity(long uid)
		{
			ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo;
			this.AllEntities.TryGetValue(uid, out towerDefenseEventCombatInfo);
			if (towerDefenseEventCombatInfo != null)
			{
				this.AllEntities.Remove(uid);
				ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo;
				this.TrapEntities.Remove(uid, out towerDefenseEventTrapInfo);
			}
			return towerDefenseEventCombatInfo;
		}

		// Token: 0x06033FCA RID: 212938 RVA: 0x00D01134 File Offset: 0x00CFF334
		public bool HasEntity(int uid)
		{
			return this.AllEntities.ContainsKey((long)uid);
		}

		// Token: 0x06033FCB RID: 212939 RVA: 0x00D01144 File Offset: 0x00CFF344
		public int? GetMachineIdByIndex(int index)
		{
			List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
			if (index < 0 || index >= slotData.Count)
			{
				return null;
			}
			TrapDefenseBuildingDevelopItemData slotData2 = slotData[index].GetSlotData();
			if (slotData2 == null)
			{
				return null;
			}
			return new int?(slotData2.Id);
		}

		// Token: 0x0401E0C1 RID: 123073
		private readonly List<TrapDefenseWave> Waves = new List<TrapDefenseWave>();

		// Token: 0x0401E0C2 RID: 123074
		private readonly Dictionary<long, ITowerDefenseEventCombatInfo> AllEntities = new Dictionary<long, ITowerDefenseEventCombatInfo>();

		// Token: 0x0401E0C3 RID: 123075
		private readonly Dictionary<long, ITowerDefenseEventTrapInfo> TrapEntities = new Dictionary<long, ITowerDefenseEventTrapInfo>();
	}
}
