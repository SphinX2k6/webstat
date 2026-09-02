using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200681E RID: 26654
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class FishingModel : ModelBase<FishingModel>
	{
		// Token: 0x060426E3 RID: 272099 RVA: 0x01108C9F File Offset: 0x01106E9F
		public void SetFishingLevelUpInfo(FishingLevelUpData data)
		{
			if (this.LastFishingLevelUpDataInternal == null)
			{
				this.LastFishingLevelUpDataInternal = data;
				return;
			}
			this.LastFishingLevelUpDataInternal.CurrentLevel = data.CurrentLevel;
		}

		// Token: 0x060426E4 RID: 272100 RVA: 0x01108CC2 File Offset: 0x01106EC2
		[NullableContext(2)]
		public FishingLevelUpData GetFishingLevelUpInfo()
		{
			return this.LastFishingLevelUpDataInternal;
		}

		// Token: 0x060426E5 RID: 272101 RVA: 0x01108CCA File Offset: 0x01106ECA
		public void ClearLastFishingExp()
		{
			this.LastFishingLevelUpDataInternal = null;
		}

		// Token: 0x060426E6 RID: 272102 RVA: 0x01108CD4 File Offset: 0x01106ED4
		protected override bool OnInit()
		{
			this.FishingReputationItemId = ConfigCommonParamById.GetIntConfig("FishingSailingExpItemId").Value;
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("FishingShipFixCost");
			this.FishingShipFixItem = intArrayConfig[0];
			this.FishingShipFixCost = ConfigCommonParamById.GetIntConfig("FishingShipFixCostCount").Value;
			this.TempFishingPointLimit = ConfigCommonParamById.GetIntConfig("FishingMaxBaitCount").GetValueOrDefault();
			this.FishingSlotCountTech = ConfigCommonParamById.GetIntConfig("FishingSlotCountTech").GetValueOrDefault();
			this.FishingBagRedPercentage = ConfigCommonParamById.GetIntConfig("FishingBagRedPercentage").GetValueOrDefault();
			this.InitTechNodeMap();
			return true;
		}

		// Token: 0x060426E7 RID: 272103 RVA: 0x01108D78 File Offset: 0x01106F78
		private void InitTechNodeMap()
		{
			foreach (FishingTech fishingTech in ConfigBase<FishingConfig>.Instance.GetFishingTechList())
			{
				if (fishingTech.Type == 4 || fishingTech.Type == 5)
				{
					List<IFishingTechNode> list;
					if (!this.RoleTechNodeMap.TryGetValue(fishingTech.Type, out list))
					{
						list = new List<IFishingTechNode>();
					}
					FishingTechNode item = new FishingTechNode
					{
						ConfigId = fishingTech.Id,
						NodeType = (EFishingTechNodeType)fishingTech.Type,
						Area = fishingTech.Area,
						PreNode = fishingTech.PreNode
					};
					list.Add(item);
					this.RoleTechNodeMap[fishingTech.Type] = list;
				}
				else
				{
					List<IFishingTechNode> list2;
					if (!this.NormalTechNodeMap.TryGetValue(fishingTech.Area, out list2))
					{
						list2 = new List<IFishingTechNode>();
					}
					FishingTechNode item2 = new FishingTechNode
					{
						ConfigId = fishingTech.Id,
						NodeType = (EFishingTechNodeType)fishingTech.Type,
						Area = fishingTech.Area,
						PreNode = fishingTech.PreNode
					};
					list2.Add(item2);
					this.NormalTechNodeMap[fishingTech.Area] = list2;
				}
			}
		}

		// Token: 0x060426E8 RID: 272104 RVA: 0x01108ED0 File Offset: 0x011070D0
		public int GetFishingReputationLevelByItemCount(int itemCount)
		{
			IEnumerable<FishingReputation> allFishingReputation = ConfigBase<FishingConfig>.Instance.GetAllFishingReputation();
			int num = 1;
			foreach (FishingReputation fishingReputation in allFishingReputation)
			{
				if (itemCount >= fishingReputation.Exp && num <= fishingReputation.Level)
				{
					num = fishingReputation.Level;
				}
			}
			return num;
		}

		// Token: 0x060426E9 RID: 272105 RVA: 0x01108F3C File Offset: 0x0110713C
		public int GetConfigMaxFishingReputationLevel()
		{
			IEnumerable<FishingReputation> allFishingReputation = ConfigBase<FishingConfig>.Instance.GetAllFishingReputation();
			int num = 0;
			foreach (FishingReputation fishingReputation in allFishingReputation)
			{
				if (num <= fishingReputation.Level)
				{
					num = fishingReputation.Level;
				}
			}
			return num;
		}

		// Token: 0x060426EA RID: 272106 RVA: 0x01108F9C File Offset: 0x0110719C
		private void SetCageData(int sceneId, List<OneFishCage> cages)
		{
			Dictionary<int, DockyardCageData> dictionary;
			if (!this.CageDataMapMap.TryGetValue(sceneId, out dictionary))
			{
				dictionary = new Dictionary<int, DockyardCageData>();
			}
			foreach (OneFishCage oneFishCage in cages)
			{
				DockyardCageData value = new DockyardCageData(oneFishCage);
				dictionary[oneFishCage.Id] = value;
			}
			this.CageDataMapMap[sceneId] = dictionary;
		}

		// Token: 0x060426EB RID: 272107 RVA: 0x0110901C File Offset: 0x0110721C
		public void SetCageDataMapFromServer(Dictionary<int, SceneFishCageInfo> dataMap)
		{
			this.CageDataMapMap.Clear();
			foreach (int num in dataMap.Keys)
			{
				RepeatedField<OneFishCage> cages = dataMap[num].Cages;
				this.SetCageData(num, cages.ToList<OneFishCage>());
			}
		}

		// Token: 0x060426EC RID: 272108 RVA: 0x01109090 File Offset: 0x01107290
		public void AddCageDataFromServer(int sceneId, OneFishCage cageInfo)
		{
			Dictionary<int, DockyardCageData> dictionary;
			if (!this.CageDataMapMap.TryGetValue(sceneId, out dictionary))
			{
				dictionary = new Dictionary<int, DockyardCageData>();
			}
			dictionary[cageInfo.Id] = new DockyardCageData(cageInfo);
			this.CageDataMapMap[sceneId] = dictionary;
		}

		// Token: 0x060426ED RID: 272109 RVA: 0x011090D4 File Offset: 0x011072D4
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetDataByCage(int configId, int uniqueId)
		{
			DockyardCageData cageDataByConfigId = this.GetCageDataByConfigId(configId);
			if (cageDataByConfigId == null)
			{
				return null;
			}
			return cageDataByConfigId.GetData(uniqueId);
		}

		// Token: 0x060426EE RID: 272110 RVA: 0x011090F8 File Offset: 0x011072F8
		[NullableContext(2)]
		public DockyardCageData GetCageDataByConfigId(int configId)
		{
			int id = ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.Id;
			Dictionary<int, DockyardCageData> dictionary;
			if (!this.CageDataMapMap.TryGetValue(id, out dictionary))
			{
				return null;
			}
			DockyardCageData result;
			if (dictionary.TryGetValue(configId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060426EF RID: 272111 RVA: 0x01109144 File Offset: 0x01107344
		public List<DockyardItemBlockOriginalData> GetCageDataList(int entityId)
		{
			DockyardCageData cageDataByConfigId = this.GetCageDataByConfigId(entityId);
			if (cageDataByConfigId == null)
			{
				return new List<DockyardItemBlockOriginalData>();
			}
			return cageDataByConfigId.GetDataList();
		}

		// Token: 0x060426F0 RID: 272112 RVA: 0x01109168 File Offset: 0x01107368
		private void CreateInteractData(HandInInfo data)
		{
			Dictionary<int, DockyardItemBlockOriginalData> dictionary;
			if (!this.InteractDataMapMap.TryGetValue(data.Id, out dictionary))
			{
				dictionary = new Dictionary<int, DockyardItemBlockOriginalData>();
			}
			foreach (FishingItemInfo data2 in data.FishingItems)
			{
				DockyardItemBlockOriginalData dockyardItemBlockOriginalData = new DockyardItemBlockOriginalData(data2);
				dictionary[dockyardItemBlockOriginalData.IncId] = dockyardItemBlockOriginalData;
			}
			this.InteractDataMapMap[data.Id] = dictionary;
		}

		// Token: 0x060426F1 RID: 272113 RVA: 0x011091F0 File Offset: 0x011073F0
		public void SetInteractData(List<HandInInfo> dataList)
		{
			foreach (HandInInfo data in dataList)
			{
				this.CreateInteractData(data);
			}
		}

		// Token: 0x060426F2 RID: 272114 RVA: 0x01109240 File Offset: 0x01107440
		public void UpdateInteractData(HandInInfo data)
		{
			Dictionary<int, DockyardItemBlockOriginalData> dictionary;
			if (!this.InteractDataMapMap.TryGetValue(data.Id, out dictionary))
			{
				dictionary = new Dictionary<int, DockyardItemBlockOriginalData>();
			}
			dictionary.Clear();
			foreach (FishingItemInfo data2 in data.FishingItems)
			{
				DockyardItemBlockOriginalData dockyardItemBlockOriginalData = new DockyardItemBlockOriginalData(data2);
				dictionary[dockyardItemBlockOriginalData.IncId] = dockyardItemBlockOriginalData;
			}
			this.InteractDataMapMap[data.Id] = dictionary;
		}

		// Token: 0x060426F3 RID: 272115 RVA: 0x011092CC File Offset: 0x011074CC
		[NullableContext(2)]
		public DockyardItemBlockOriginalData GetDataByInteract(int configId, int uniqueId)
		{
			Dictionary<int, DockyardItemBlockOriginalData> dictionary;
			if (!this.InteractDataMapMap.TryGetValue(configId, out dictionary))
			{
				return null;
			}
			DockyardItemBlockOriginalData result;
			if (dictionary.TryGetValue(uniqueId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060426F4 RID: 272116 RVA: 0x011092FC File Offset: 0x011074FC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, DockyardItemBlockOriginalData> GetDataMapByInteract(int configId)
		{
			Dictionary<int, DockyardItemBlockOriginalData> result;
			if (this.InteractDataMapMap.TryGetValue(configId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060426F5 RID: 272117 RVA: 0x0110931C File Offset: 0x0110751C
		public void SetAllFishingPointData(Dictionary<int, SceneFishPointInfo> dataMap)
		{
			this.ClearAllFishingPointData();
			foreach (int num in dataMap.Keys)
			{
				RepeatedField<OneFishPointInfo> fishPoints = dataMap[num].FishPoints;
				RepeatedField<TempFishPointInfo> tempFishPoints = dataMap[num].TempFishPoints;
				HashSet<int> hashSet;
				if (!this.FishingPointSceneId2PbEntityId.TryGetValue(num, out hashSet))
				{
					hashSet = new HashSet<int>();
					this.FishingPointSceneId2PbEntityId[num] = hashSet;
				}
				foreach (OneFishPointInfo fishPoint in fishPoints)
				{
					this.SetOneFishingPointData(num, hashSet, fishPoint);
				}
				foreach (TempFishPointInfo fishPoint2 in tempFishPoints)
				{
					this.SetTempFishingPointData(num, fishPoint2);
				}
			}
		}

		// Token: 0x060426F6 RID: 272118 RVA: 0x01109430 File Offset: 0x01107630
		private void ClearAllFishingPointData()
		{
			this.FishingPointDataPbEntityIdMap.Clear();
			this.FishingPointSceneId2PbEntityId.Clear();
			this.FishingPointId2EntityId.Clear();
			this.TempFishingPointDataMap.Clear();
		}

		// Token: 0x060426F7 RID: 272119 RVA: 0x01109460 File Offset: 0x01107660
		public void RefreshFishingPointData(int sceneId, OneFishPointInfo fishPoint)
		{
			HashSet<int> hashSet;
			if (!this.FishingPointSceneId2PbEntityId.TryGetValue(sceneId, out hashSet))
			{
				hashSet = new HashSet<int>();
				this.FishingPointSceneId2PbEntityId[sceneId] = hashSet;
			}
			this.SetOneFishingPointData(sceneId, hashSet, fishPoint);
		}

		// Token: 0x060426F8 RID: 272120 RVA: 0x0110949C File Offset: 0x0110769C
		private void SetOneFishingPointData(int sceneId, HashSet<int> pbEntityIdSet, OneFishPointInfo fishPoint)
		{
			int entityConfigId = fishPoint.EntityConfigId;
			FishingPointData fishingPointData;
			if (!this.FishingPointDataPbEntityIdMap.TryGetValue(entityConfigId, out fishingPointData))
			{
				fishingPointData = new FishingPointData();
				fishingPointData.SceneId = sceneId;
				pbEntityIdSet.Add(entityConfigId);
				this.FishingPointDataPbEntityIdMap[entityConfigId] = fishingPointData;
				this.FishingPointId2EntityId[fishPoint.Id] = entityConfigId;
			}
			fishingPointData.Refresh(fishPoint);
			this.RefreshFishPointEntity(entityConfigId, fishingPointData);
		}

		// Token: 0x060426F9 RID: 272121 RVA: 0x01109504 File Offset: 0x01107704
		public void RemoveOneFishingPointData(int sceneId, OneFishPointInfo fishPoint)
		{
			int entityConfigId = fishPoint.EntityConfigId;
			FishingPointData fishingPointData;
			if (this.FishingPointDataPbEntityIdMap.TryGetValue(entityConfigId, out fishingPointData))
			{
				fishingPointData.Refresh(fishPoint);
				this.RefreshFishPointEntity(entityConfigId, fishingPointData);
			}
			if (this.FishingPointDataPbEntityIdMap.Remove(entityConfigId))
			{
				HashSet<int> hashSet;
				if (this.FishingPointSceneId2PbEntityId.TryGetValue(sceneId, out hashSet))
				{
					hashSet.Remove(entityConfigId);
				}
				this.FishingPointId2EntityId.Remove(fishPoint.Id);
			}
		}

		// Token: 0x060426FA RID: 272122 RVA: 0x01109570 File Offset: 0x01107770
		private void RefreshFishPointEntity(int pbEntityId, FishingPointData fishData)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbEntityId);
			if (entityByPbDataId != null && entityByPbDataId.Valid)
			{
				SceneItemFishingPointComponent component = entityByPbDataId.Entity.GetComponent<SceneItemFishingPointComponent>();
				if (component == null)
				{
					return;
				}
				component.RefreshFishingPoint(fishData);
			}
		}

		// Token: 0x060426FB RID: 272123 RVA: 0x011095AC File Offset: 0x011077AC
		[NullableContext(2)]
		public FishingPointData GetFishingPointDataById(int configId)
		{
			int key;
			if (!this.FishingPointId2EntityId.TryGetValue(configId, out key))
			{
				return null;
			}
			FishingPointData result;
			if (this.FishingPointDataPbEntityIdMap.TryGetValue(key, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060426FC RID: 272124 RVA: 0x011095E0 File Offset: 0x011077E0
		public int GetFishingPointEntityIdByConfigId(int configId)
		{
			int result;
			if (this.FishingPointId2EntityId.TryGetValue(configId, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x060426FD RID: 272125 RVA: 0x01109600 File Offset: 0x01107800
		public bool GetFishingPointHaveFinishingIdByConfigId(int configId)
		{
			int key;
			FishingPointData fishingPointData;
			return !this.FishingPointId2EntityId.TryGetValue(configId, out key) || !this.FishingPointDataPbEntityIdMap.TryGetValue(key, out fishingPointData) || fishingPointData.CurrentCount <= 0;
		}

		// Token: 0x060426FE RID: 272126 RVA: 0x01109640 File Offset: 0x01107840
		[NullableContext(2)]
		public FishingPointData GetFishingPointDataByPbEntityId(int pbEntityId)
		{
			FishingPointData result;
			if (this.FishingPointDataPbEntityIdMap.TryGetValue(pbEntityId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060426FF RID: 272127 RVA: 0x01109660 File Offset: 0x01107860
		public List<FishingPointData> GetAllFishingPointDataBySceneId(int sceneId)
		{
			List<FishingPointData> list = new List<FishingPointData>();
			HashSet<int> hashSet;
			if (!this.FishingPointSceneId2PbEntityId.TryGetValue(sceneId, out hashSet))
			{
				return list;
			}
			foreach (int key in hashSet)
			{
				FishingPointData item;
				if (this.FishingPointDataPbEntityIdMap.TryGetValue(key, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06042700 RID: 272128 RVA: 0x011096D8 File Offset: 0x011078D8
		public void SetTempFishingPointData(int sceneId, TempFishPointInfo fishPoint)
		{
			long entityId = fishPoint.EntityId;
			TempFishingPointData tempFishingPointData;
			if (!this.TempFishingPointDataMap.TryGetValue(entityId, out tempFishingPointData))
			{
				tempFishingPointData = new TempFishingPointData();
				tempFishingPointData.SceneId = sceneId;
				this.TempFishingPointDataMap[entityId] = tempFishingPointData;
			}
			tempFishingPointData.Refresh(fishPoint);
		}

		// Token: 0x06042701 RID: 272129 RVA: 0x01109720 File Offset: 0x01107920
		public void RemoveTempFishingPointData(TempFishPointInfo fishPoint)
		{
			long entityId = fishPoint.EntityId;
			this.TempFishingPointDataMap.Remove(entityId);
		}

		// Token: 0x06042702 RID: 272130 RVA: 0x01109744 File Offset: 0x01107944
		[NullableContext(2)]
		public TempFishingPointData GetTempFishingPointDataByCreatureDataId(long creatureDataId)
		{
			TempFishingPointData result;
			if (this.TempFishingPointDataMap.TryGetValue(creatureDataId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06042703 RID: 272131 RVA: 0x01109764 File Offset: 0x01107964
		public int GetTempFishingPointLimit()
		{
			return this.TempFishingPointLimit;
		}

		// Token: 0x06042704 RID: 272132 RVA: 0x0110976C File Offset: 0x0110796C
		public int GetTempFishingPointNum()
		{
			return this.TempFishingPointDataMap.Count;
		}

		// Token: 0x06042705 RID: 272133 RVA: 0x0110977C File Offset: 0x0110797C
		public void SetFishingTechData(List<FishingTechInfo> dataList)
		{
			this.FishingTechDataMap.Clear();
			foreach (FishingTechInfo fishingTechInfo in dataList)
			{
				int nodeId = fishingTechInfo.NodeId;
				foreach (int techEffectId in ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId).Effect())
				{
					FishingTechEffect? fishingTechEffect = new FishingTechEffect?(ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId));
					if (fishingTechEffect != null && this.NeedCheckEffectType.Contains(fishingTechEffect.Value.Type))
					{
						HashSet<int> hashSet;
						if (!this.EffectType2TechIdsMap.TryGetValue(fishingTechEffect.Value.Type, out hashSet))
						{
							hashSet = new HashSet<int>();
							this.EffectType2TechIdsMap[fishingTechEffect.Value.Type] = hashSet;
						}
						hashSet.Add(nodeId);
					}
				}
				this.FishingTechDataMap[nodeId] = fishingTechInfo;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, fishingTechInfo.NodeId);
			}
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.MainRole);
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.Phoebe);
		}

		// Token: 0x06042706 RID: 272134 RVA: 0x011098DC File Offset: 0x01107ADC
		public void UpdateFishingTechData(FishingTechInfo data)
		{
			this.FishingTechDataMap[data.NodeId] = data;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRefresh, data.NodeId);
		}

		// Token: 0x06042707 RID: 272135 RVA: 0x01109908 File Offset: 0x01107B08
		public bool GetFishingTechUnlock(int techId)
		{
			FishingTechInfo valueOrDefault = this.FishingTechDataMap.GetValueOrDefault(techId);
			return (ConfigBase<FishingConfig>.Instance.GetFishingTechById(techId).UnlockCondition <= 0 || (valueOrDefault != null && valueOrDefault.Unlock)) && ((valueOrDefault != null) ? valueOrDefault.Level : 0) > 0;
		}

		// Token: 0x06042708 RID: 272136 RVA: 0x0110995C File Offset: 0x01107B5C
		public bool GetFishingTechUnlockByEffectType(EFishingTechType type)
		{
			IReadOnlyList<FishingTech> fishingTechList = ConfigBase<FishingConfig>.Instance.GetFishingTechList();
			IReadOnlyList<FishingTechEffect> fishingTechEffectByType = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectByType((int)type);
			if (fishingTechEffectByType.Count <= 0)
			{
				return false;
			}
			int id = fishingTechEffectByType[0].Id;
			foreach (FishingTech fishingTech in fishingTechList)
			{
				if (fishingTech.Effect().Contains(id))
				{
					return this.GetFishingTechUnlock(fishingTech.Id);
				}
			}
			return false;
		}

		// Token: 0x06042709 RID: 272137 RVA: 0x011099FC File Offset: 0x01107BFC
		public int GetFishingCurrentLevelTechEffectByEffectType(EFishingTechType type)
		{
			IReadOnlyList<FishingTech> fishingTechList = ConfigBase<FishingConfig>.Instance.GetFishingTechList();
			IReadOnlyList<FishingTechEffect> fishingTechEffectByType = ConfigBase<FishingConfig>.Instance.GetFishingTechEffectByType((int)type);
			if (fishingTechEffectByType.Count <= 0)
			{
				return 0;
			}
			int id = fishingTechEffectByType[0].Id;
			foreach (FishingTech fishingTech in fishingTechList)
			{
				if (fishingTech.Effect().Contains(id))
				{
					FishingTechInfo fishingTechInfo;
					this.FishingTechDataMap.TryGetValue(fishingTech.Id, out fishingTechInfo);
					int num = (fishingTechInfo != null) ? fishingTechInfo.Level : 0;
					if (num <= 0)
					{
						return 0;
					}
					return fishingTech.Effect(num - 1);
				}
			}
			return 0;
		}

		// Token: 0x1700A181 RID: 41345
		// (get) Token: 0x0604270A RID: 272138 RVA: 0x01109AC8 File Offset: 0x01107CC8
		public int UnlockFishingTechCount
		{
			get
			{
				int num = 0;
				using (Dictionary<int, FishingTechInfo>.ValueCollection.Enumerator enumerator = this.FishingTechDataMap.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Level > 0)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x1700A182 RID: 41346
		// (get) Token: 0x0604270B RID: 272139 RVA: 0x01109B28 File Offset: 0x01107D28
		public int AllFishingTechCount
		{
			get
			{
				return ConfigBase<FishingConfig>.Instance.GetFishingTechList().Count;
			}
		}

		// Token: 0x0604270C RID: 272140 RVA: 0x01109B3C File Offset: 0x01107D3C
		public bool GetTechNodeCanLevelUp(int nodeId)
		{
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId);
			FishingTechInfo fishingTechInfo;
			this.FishingTechDataMap.TryGetValue(nodeId, out fishingTechInfo);
			if (((fishingTechInfo != null) ? fishingTechInfo.Level : 0) >= fishingTechById.EffectLength || !this.GetNodePreNodeUnlock(nodeId))
			{
				return false;
			}
			int techEffectId = fishingTechById.Effect(fishingTechInfo.Level);
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId).Consume())
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < keyValuePair.Value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0604270D RID: 272141 RVA: 0x01109C04 File Offset: 0x01107E04
		public bool GetRoleTechNodeCanLevelUp(EFishingTechNodeType type)
		{
			foreach (KeyValuePair<int, FishingTechInfo> keyValuePair in this.FishingTechDataMap)
			{
				int key = keyValuePair.Key;
				FishingTechInfo value = keyValuePair.Value;
				FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(key);
				if (fishingTechById.Type == (int)type && value.Level < fishingTechById.EffectLength && this.GetNodePreNodeUnlock(key))
				{
					int techEffectId = fishingTechById.Effect(value.Level);
					foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId).Consume())
					{
						if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair2.Key, 0) >= keyValuePair2.Value)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0604270E RID: 272142 RVA: 0x01109D18 File Offset: 0x01107F18
		public void RefreshTechCanLevelUp()
		{
			foreach (KeyValuePair<int, FishingTechInfo> keyValuePair in this.FishingTechDataMap)
			{
				int key = keyValuePair.Key;
				FishingTechInfo value = keyValuePair.Value;
				FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(key);
				if (value.Level < fishingTechById.EffectLength && this.GetNodePreNodeUnlock(key))
				{
					int techEffectId = fishingTechById.Effect(value.Level);
					foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId).Consume())
					{
						if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair2.Key, 0) >= keyValuePair2.Value)
						{
							Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFishingTechNodeRedDotRefresh, key);
						}
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.MainRole);
			Singleton<EventSystem>.Instance.Emit<EFishingTechNodeType>(EEventName.OnFishingRoleTechRefresh, EFishingTechNodeType.Phoebe);
		}

		// Token: 0x0604270F RID: 272143 RVA: 0x01109E4C File Offset: 0x0110804C
		public int GetTechNodeCurrentLevel(int nodeId)
		{
			FishingTechInfo fishingTechInfo;
			this.FishingTechDataMap.TryGetValue(nodeId, out fishingTechInfo);
			if (fishingTechInfo == null)
			{
				return 0;
			}
			return fishingTechInfo.Level;
		}

		// Token: 0x06042710 RID: 272144 RVA: 0x01109E74 File Offset: 0x01108074
		public int GetTechNodeMaxLevel(int nodeId)
		{
			return ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId).EffectLength;
		}

		// Token: 0x06042711 RID: 272145 RVA: 0x01109E94 File Offset: 0x01108094
		[NullableContext(2)]
		public IFishingTechNode GetFirstNode()
		{
			List<IFishingTechNode> list;
			if (!this.NormalTechNodeMap.TryGetValue(0, out list))
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.LJQ, "捕鱼活动获取首科技节点失败，请检查科技树配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return list[0];
		}

		// Token: 0x06042712 RID: 272146 RVA: 0x01109ED8 File Offset: 0x011080D8
		[NullableContext(2)]
		public IFishingTechNode GetLastNode()
		{
			List<IFishingTechNode> list;
			if (!this.NormalTechNodeMap.TryGetValue(4, out list))
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.LJQ, "捕鱼活动获取尾科技节点失败，请检查科技树配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return list[0];
		}

		// Token: 0x06042713 RID: 272147 RVA: 0x01109F1C File Offset: 0x0110811C
		public IFishingTechNode GetFirstUnlockNode()
		{
			IFishingTechNode result = null;
			foreach (List<IFishingTechNode> list in this.NormalTechNodeMap.Values)
			{
				foreach (IFishingTechNode fishingTechNode in list)
				{
					if (fishingTechNode.NodeType != EFishingTechNodeType.Secondary)
					{
						FishingTechInfo fishingTechInfo;
						this.FishingTechDataMap.TryGetValue(fishingTechNode.ConfigId, out fishingTechInfo);
						if (fishingTechInfo == null || fishingTechInfo.Level <= 0)
						{
							return fishingTechNode;
						}
						result = fishingTechNode;
					}
				}
			}
			return result;
		}

		// Token: 0x06042714 RID: 272148 RVA: 0x01109FDC File Offset: 0x011081DC
		[NullableContext(2)]
		public IFishingTechNode GetNormalTechNodeById(int nodeId)
		{
			foreach (List<IFishingTechNode> list in this.NormalTechNodeMap.Values)
			{
				foreach (IFishingTechNode fishingTechNode in list)
				{
					if (fishingTechNode.ConfigId == nodeId)
					{
						return fishingTechNode;
					}
				}
			}
			return null;
		}

		// Token: 0x06042715 RID: 272149 RVA: 0x0110A074 File Offset: 0x01108274
		[NullableContext(2)]
		public IFishingTechNode GetRoleTechNodeById(int nodeId)
		{
			foreach (List<IFishingTechNode> list in this.RoleTechNodeMap.Values)
			{
				foreach (IFishingTechNode fishingTechNode in list)
				{
					if (fishingTechNode.ConfigId == nodeId)
					{
						return fishingTechNode;
					}
				}
			}
			return null;
		}

		// Token: 0x06042716 RID: 272150 RVA: 0x0110A10C File Offset: 0x0110830C
		public bool GetNodePreNodeUnlock(int nodeId)
		{
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId);
			if (fishingTechById.PreNode != 0)
			{
				return this.GetFishingTechUnlock(fishingTechById.PreNode);
			}
			if (ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId).UnlockCondition <= 0)
			{
				return true;
			}
			FishingTechInfo fishingTechInfo;
			this.FishingTechDataMap.TryGetValue(nodeId, out fishingTechInfo);
			return fishingTechInfo != null && fishingTechInfo.Unlock;
		}

		// Token: 0x06042717 RID: 272151 RVA: 0x0110A170 File Offset: 0x01108370
		public bool GetNodeLevelUpItemEnough(int nodeId)
		{
			FishingTech fishingTechById = ConfigBase<FishingConfig>.Instance.GetFishingTechById(nodeId);
			FishingTechInfo fishingTechInfo;
			this.FishingTechDataMap.TryGetValue(nodeId, out fishingTechInfo);
			int techEffectId;
			if (fishingTechInfo != null && fishingTechInfo.Level == 0)
			{
				techEffectId = fishingTechById.Effect(0);
			}
			else
			{
				techEffectId = fishingTechById.Effect(fishingTechInfo.Level);
			}
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<FishingConfig>.Instance.GetFishingTechEffectById(techEffectId).Consume())
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < keyValuePair.Value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x1700A183 RID: 41347
		// (get) Token: 0x06042718 RID: 272152 RVA: 0x0110A230 File Offset: 0x01108430
		public bool IsInDock
		{
			get
			{
				return this.DockIdInternal > 0;
			}
		}

		// Token: 0x1700A184 RID: 41348
		// (get) Token: 0x06042719 RID: 272153 RVA: 0x0110A23B File Offset: 0x0110843B
		// (set) Token: 0x0604271A RID: 272154 RVA: 0x0110A243 File Offset: 0x01108443
		public int DockId
		{
			get
			{
				return this.DockIdInternal;
			}
			set
			{
				this.DockIdInternal = value;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.FishingRefreshDockId, this.DockIdInternal);
			}
		}

		// Token: 0x0604271B RID: 272155 RVA: 0x0110A262 File Offset: 0x01108462
		public FishingShipData GetShipData()
		{
			return this.ShipData;
		}

		// Token: 0x0604271C RID: 272156 RVA: 0x0110A26A File Offset: 0x0110846A
		public void SaveLocalSailingIsFix(bool isAutoFix)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.SailingIsFix, isAutoFix);
		}

		// Token: 0x0604271D RID: 272157 RVA: 0x0110A278 File Offset: 0x01108478
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"occupyGridCount",
			"maxGridCount"
		})]
		public ValueTuple<int, int> GetShipCapacityInfoTuple(int entityId)
		{
			int backpackUseSize = ModelBase<DockyardModel>.Instance.BackpackUseSize;
			int backpackSize = ModelBase<DockyardModel>.Instance.BackpackSize;
			return new ValueTuple<int, int>(backpackUseSize, backpackSize);
		}

		// Token: 0x0604271E RID: 272158 RVA: 0x0110A2A0 File Offset: 0x011084A0
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"occupyGridCount",
			"maxGridCount"
		})]
		public ValueTuple<int, int> GetShipCageCapacityInfoTuple(int configId)
		{
			DockyardCageData cageDataByConfigId = this.GetCageDataByConfigId(configId);
			if (cageDataByConfigId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Fishing;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[捕鱼系统]->获取笼子容量错误，未找到对应实体的笼子数据。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", configId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new ValueTuple<int, int>(0, 0);
			}
			OneFishCage data = cageDataByConfigId.Data;
			int count = data.Items.Count;
			int maxCount = data.MaxCount;
			return new ValueTuple<int, int>(count, maxCount);
		}

		// Token: 0x0604271F RID: 272159 RVA: 0x0110A310 File Offset: 0x01108510
		public long GetShipCageNextHarvestTimeStamp(int configId)
		{
			DockyardCageData cageDataByConfigId = this.GetCageDataByConfigId(configId);
			if (cageDataByConfigId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Fishing;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[捕鱼系统]->获取笼子容量错误，未找到对应实体的笼子数据。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", configId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0L;
			}
			return cageDataByConfigId.Data.NextUpdateTime;
		}

		// Token: 0x06042720 RID: 272160 RVA: 0x0110A368 File Offset: 0x01108568
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"occupyGridCount",
			"maxGridCount"
		})]
		public ValueTuple<int, int> GetFishingPointCapacityInfoTuple(int entityId)
		{
			FishingPointData fishingPointDataByPbEntityId = this.GetFishingPointDataByPbEntityId(entityId);
			if (fishingPointDataByPbEntityId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Fishing;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[捕鱼系统]->获取捕鱼点容量错误，未找到对应捕鱼点数据。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new ValueTuple<int, int>(0, 0);
			}
			int currentCount = fishingPointDataByPbEntityId.CurrentCount;
			int maxCount = fishingPointDataByPbEntityId.MaxCount;
			return new ValueTuple<int, int>(currentCount, maxCount);
		}

		// Token: 0x06042721 RID: 272161 RVA: 0x0110A3CC File Offset: 0x011085CC
		public unsafe string GetFishingPointAppearTimeLocalKey(int entityId)
		{
			int showItem = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigByEntityId(entityId).Value.ShowItem;
			EFishingAppearTimeType time = (EFishingAppearTimeType)ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(showItem).Value.Time;
			if (time == EFishingAppearTimeType.WholeDay)
			{
				return "Fishing_WholeDay";
			}
			if (time == EFishingAppearTimeType.DayOnly)
			{
				return "Fishing_OnlyDay";
			}
			if (time == EFishingAppearTimeType.NightOnly)
			{
				return "Fishing_OnlyNight";
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Fishing;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[捕鱼系统]->获取鱼点的出没时间文本Key错误。";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("展示道具", showItem);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("出没时间", time);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return string.Empty;
		}

		// Token: 0x06042722 RID: 272162 RVA: 0x0110A4B4 File Offset: 0x011086B4
		public string GetFishingPointNameLocalKey(int entityId)
		{
			int showItem = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigByEntityId(entityId).Value.ShowItem;
			return ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(showItem).Value.Name;
		}

		// Token: 0x06042723 RID: 272163 RVA: 0x0110A4FC File Offset: 0x011086FC
		public string GetFishingPointTechNameLocalKey(int entityId)
		{
			int unlockTech = ConfigBase<FishingConfig>.Instance.GetFishingPointConfigByEntityId(entityId).Value.UnlockTech;
			return ConfigBase<FishingConfig>.Instance.GetFishingTagConfig(unlockTech).Value.Name;
		}

		// Token: 0x06042724 RID: 272164 RVA: 0x0110A544 File Offset: 0x01108744
		public bool IsOnShipVehicle()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			return characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsOnVehicle;
		}

		// Token: 0x06042725 RID: 272165 RVA: 0x0110A580 File Offset: 0x01108780
		public void SetHandBookData(FishingIllustratedInfo info)
		{
			foreach (OneFishingIllustratedInfo oneFishingIllustratedInfo in info.IllustratedList)
			{
				if (oneFishingIllustratedInfo.Id > 0)
				{
					FishingHandBook value = new FishingHandBook
					{
						Id = oneFishingIllustratedInfo.Id,
						MaxSize = oneFishingIllustratedInfo.MaxSize,
						MinSize = oneFishingIllustratedInfo.MinSize
					};
					this.FishingItemHandBookDataMap[oneFishingIllustratedInfo.Id] = value;
				}
			}
			foreach (FishingIllustratedRewardInfo fishingIllustratedRewardInfo in info.RewardedId)
			{
				FishingReward value2 = new FishingReward
				{
					Id = fishingIllustratedRewardInfo.Id,
					IsFinished = fishingIllustratedRewardInfo.IsFinished,
					IsTaken = fishingIllustratedRewardInfo.IsTaken,
					Current = fishingIllustratedRewardInfo.Current,
					Target = fishingIllustratedRewardInfo.Target
				};
				this.FishingItemHandBookRewardMap[fishingIllustratedRewardInfo.Id] = value2;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.FishingRefreshHandBookRewardView);
			ModelBase<FishingModel>.Instance.FishingItemHandBookUnlockTraceList = info.UnlockDetections.ToList<int>();
		}

		// Token: 0x06042726 RID: 272166 RVA: 0x0110A6C4 File Offset: 0x011088C4
		public void RefreshHandBookData(OneFishingIllustratedInfo data)
		{
			if (data.Id <= 0)
			{
				return;
			}
			FishingHandBook value = new FishingHandBook
			{
				Id = data.Id,
				MaxSize = data.MaxSize,
				MinSize = data.MinSize
			};
			this.FishingItemHandBookDataMap[data.Id] = value;
		}

		// Token: 0x06042727 RID: 272167 RVA: 0x0110A718 File Offset: 0x01108918
		public List<int> GetFishingItemIdList()
		{
			List<int> list = new List<int>();
			foreach (FishingItem fishingItem in ConfigBase<FishingConfig>.Instance.GetAllFishingItemConfig())
			{
				if (fishingItem.IllustratedNum > 0)
				{
					list.Add(fishingItem.Id);
				}
			}
			return list;
		}

		// Token: 0x06042728 RID: 272168 RVA: 0x0110A780 File Offset: 0x01108980
		public List<IFishingHandBookItemData> GetFishingItemList()
		{
			List<IFishingHandBookItemData> list = new List<IFishingHandBookItemData>();
			foreach (FishingItem fishingItem in ConfigBase<FishingConfig>.Instance.GetAllFishingItemConfig())
			{
				if (fishingItem.IllustratedNum > 0)
				{
					FishingHandBookItemData item = new FishingHandBookItemData
					{
						Id = fishingItem.Id,
						Type = fishingItem.Category,
						Area = fishingItem.Area().ToList<int>(),
						Tech = fishingItem.Tech().ToList<int>(),
						Time = fishingItem.Time,
						HandBookId = fishingItem.IllustratedNum
					};
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x1700A185 RID: 41349
		// (get) Token: 0x06042729 RID: 272169 RVA: 0x0110A840 File Offset: 0x01108A40
		public int AllFishingItemCount
		{
			get
			{
				int num = 0;
				foreach (FishingItem fishingItem in ConfigBase<FishingConfig>.Instance.GetAllFishingItemConfig())
				{
					if (fishingItem.IllustratedNum > 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x1700A186 RID: 41350
		// (get) Token: 0x0604272A RID: 272170 RVA: 0x0110A89C File Offset: 0x01108A9C
		public int UnLockFishingItemCount
		{
			get
			{
				return this.FishingItemHandBookDataMap.Count;
			}
		}

		// Token: 0x0604272B RID: 272171 RVA: 0x0110A8AC File Offset: 0x01108AAC
		public List<EFishingSize> GetSizeIsGoldSize(int itemId)
		{
			List<EFishingSize> list = new List<EFishingSize>();
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(itemId);
			if (fishingItemConfig.Value.SizeWeightLength < 3)
			{
				return list;
			}
			IFishingHandBook fishingHandBook;
			if (!this.FishingItemHandBookDataMap.TryGetValue(itemId, out fishingHandBook))
			{
				return list;
			}
			IntArray? intArray = fishingItemConfig.Value.SizeWeight(0);
			if (fishingHandBook.MinSize <= intArray.Value.ArrayInt(1))
			{
				list.Add(EFishingSize.Silver);
			}
			IntArray? intArray2 = fishingItemConfig.Value.SizeWeight(2);
			if (fishingHandBook.MaxSize >= intArray2.Value.ArrayInt(0))
			{
				list.Add(EFishingSize.Golden);
			}
			return list;
		}

		// Token: 0x0604272C RID: 272172 RVA: 0x0110A958 File Offset: 0x01108B58
		public int GetHandBookRewardHaveTakenCount()
		{
			int num = 0;
			using (Dictionary<int, IFishingReward>.ValueCollection.Enumerator enumerator = this.FishingItemHandBookRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsTaken)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0604272D RID: 272173 RVA: 0x0110A9B8 File Offset: 0x01108BB8
		public void RefreshHandBookDataReward(FishingIllustratedRewardInfo data)
		{
			FishingReward value = new FishingReward
			{
				Id = data.Id,
				IsFinished = data.IsFinished,
				IsTaken = data.IsTaken,
				Current = data.Current,
				Target = data.Target
			};
			this.FishingItemHandBookRewardMap[data.Id] = value;
			Singleton<EventSystem>.Instance.Emit(EEventName.FishingRefreshHandBookRewardView);
		}

		// Token: 0x0604272E RID: 272174 RVA: 0x0110AA2C File Offset: 0x01108C2C
		public bool GetHandBookRewardRedDotState()
		{
			foreach (IFishingReward fishingReward in this.FishingItemHandBookRewardMap.Values)
			{
				if (fishingReward.IsFinished && !fishingReward.IsTaken)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604272F RID: 272175 RVA: 0x0110AA94 File Offset: 0x01108C94
		public bool IsAllHandBookRewardTaken()
		{
			using (Dictionary<int, IFishingReward>.ValueCollection.Enumerator enumerator = this.FishingItemHandBookRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsTaken)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04024FBF RID: 151487
		public int FishingReputationItemId;

		// Token: 0x04024FC0 RID: 151488
		public int FishingShipFixItem;

		// Token: 0x04024FC1 RID: 151489
		public int FishingShipFixCost;

		// Token: 0x04024FC2 RID: 151490
		public Dictionary<int, List<IFishingTechNode>> NormalTechNodeMap = new Dictionary<int, List<IFishingTechNode>>();

		// Token: 0x04024FC3 RID: 151491
		public Dictionary<int, List<IFishingTechNode>> RoleTechNodeMap = new Dictionary<int, List<IFishingTechNode>>();

		// Token: 0x04024FC4 RID: 151492
		[Nullable(2)]
		private FishingLevelUpData LastFishingLevelUpDataInternal;

		// Token: 0x04024FC5 RID: 151493
		public int FishingSlotCountTech;

		// Token: 0x04024FC6 RID: 151494
		public int FishingBagRedPercentage;

		// Token: 0x04024FC7 RID: 151495
		private Dictionary<int, Dictionary<int, DockyardCageData>> CageDataMapMap = new Dictionary<int, Dictionary<int, DockyardCageData>>();

		// Token: 0x04024FC8 RID: 151496
		private Dictionary<int, Dictionary<int, DockyardItemBlockOriginalData>> InteractDataMapMap = new Dictionary<int, Dictionary<int, DockyardItemBlockOriginalData>>();

		// Token: 0x04024FC9 RID: 151497
		private Dictionary<int, FishingPointData> FishingPointDataPbEntityIdMap = new Dictionary<int, FishingPointData>();

		// Token: 0x04024FCA RID: 151498
		private Dictionary<int, HashSet<int>> FishingPointSceneId2PbEntityId = new Dictionary<int, HashSet<int>>();

		// Token: 0x04024FCB RID: 151499
		private Dictionary<int, int> FishingPointId2EntityId = new Dictionary<int, int>();

		// Token: 0x04024FCC RID: 151500
		private int TempFishingPointLimit;

		// Token: 0x04024FCD RID: 151501
		private Dictionary<long, TempFishingPointData> TempFishingPointDataMap = new Dictionary<long, TempFishingPointData>();

		// Token: 0x04024FCE RID: 151502
		private Dictionary<int, FishingTechInfo> FishingTechDataMap = new Dictionary<int, FishingTechInfo>();

		// Token: 0x04024FCF RID: 151503
		private HashSet<int> NeedCheckEffectType = new HashSet<int>(new int[]
		{
			11,
			10
		});

		// Token: 0x04024FD0 RID: 151504
		public Dictionary<int, HashSet<int>> EffectType2TechIdsMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x04024FD1 RID: 151505
		private int DockIdInternal;

		// Token: 0x04024FD2 RID: 151506
		private FishingShipData ShipData = new FishingShipData();

		// Token: 0x04024FD3 RID: 151507
		public ESailTime LocalSailingTime;

		// Token: 0x04024FD4 RID: 151508
		public Dictionary<int, IFishingHandBook> FishingItemHandBookDataMap = new Dictionary<int, IFishingHandBook>();

		// Token: 0x04024FD5 RID: 151509
		public Dictionary<int, IFishingReward> FishingItemHandBookRewardMap = new Dictionary<int, IFishingReward>();

		// Token: 0x04024FD6 RID: 151510
		public List<int> FishingItemHandBookUnlockTraceList = new List<int>();

		// Token: 0x04024FD7 RID: 151511
		public List<int> RoleTalkIds;

		// Token: 0x04024FD8 RID: 151512
		public List<int> UnlockPort = new List<int>();

		// Token: 0x04024FD9 RID: 151513
		public int CurrentShipSkin;

		// Token: 0x04024FDA RID: 151514
		public List<int> UnlockShipSkin = new List<int>();
	}
}
