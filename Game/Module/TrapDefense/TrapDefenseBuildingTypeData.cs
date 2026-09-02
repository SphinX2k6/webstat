using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DA5 RID: 19877
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingTypeData
	{
		// Token: 0x060337A4 RID: 210852 RVA: 0x00CDFB00 File Offset: 0x00CDDD00
		public static TrapDefenseBuildingTypeData Create(ETrapDefenseMachineType type, bool isInDungeon, List<TrapDefenseBuildingDevelopItemData> haveList, ETrapDefensePlacementType? placementType = null)
		{
			TrapDefenseBuildingTypeData trapDefenseBuildingTypeData = new TrapDefenseBuildingTypeData(type, isInDungeon, placementType);
			if (!trapDefenseBuildingTypeData.Init(haveList))
			{
				return null;
			}
			return trapDefenseBuildingTypeData;
		}

		// Token: 0x060337A5 RID: 210853 RVA: 0x00CDFB22 File Offset: 0x00CDDD22
		private TrapDefenseBuildingTypeData(ETrapDefenseMachineType type, bool isInDungeon, ETrapDefensePlacementType? placementType = null)
		{
			this.Type = type;
			this.PlacementType = placementType.GetValueOrDefault();
			this.IsInDungeon = isInDungeon;
		}

		// Token: 0x060337A6 RID: 210854 RVA: 0x00CDFB5C File Offset: 0x00CDDD5C
		public string GetTitleId()
		{
			if (this.Type == ETrapDefenseMachineType.Auxiliary)
			{
				if (!this.IsInDungeon)
				{
					return "TowerDefense_Building_AuxiliaryType_Text";
				}
				return "TowerDefense_Building_AuxiliaryTypeDungeon_Text";
			}
			else
			{
				if (this.PlacementType == ETrapDefensePlacementType.Floor)
				{
					return "TowerDefense_Building_FloorBuildingType_Text";
				}
				if (this.PlacementType == ETrapDefensePlacementType.Wall)
				{
					return "TowerDefense_Building_WallBuildingType_Text";
				}
				return "TowerDefense_Building_TopBuildingType_Text";
			}
		}

		// Token: 0x060337A7 RID: 210855 RVA: 0x00CDFBA9 File Offset: 0x00CDDDA9
		private bool Init(List<TrapDefenseBuildingDevelopItemData> haveList)
		{
			if (!this.IsInDungeon)
			{
				return this.InitNotInDungeon(haveList);
			}
			return this.InitInDungeon();
		}

		// Token: 0x060337A8 RID: 210856 RVA: 0x00CDFBC4 File Offset: 0x00CDDDC4
		private bool InitNotInDungeon(List<TrapDefenseBuildingDevelopItemData> haveList)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData in haveList)
			{
				hashSet.Add(trapDefenseBuildingDevelopItemData.GetDataType());
				this.DataList.Add(trapDefenseBuildingDevelopItemData);
				this.DataMap[trapDefenseBuildingDevelopItemData.GetDataType()] = trapDefenseBuildingDevelopItemData;
			}
			if (this.Type == ETrapDefenseMachineType.Auxiliary)
			{
				using (IEnumerator<TrapDefenseAuxiliaryType> enumerator2 = ConfigBase<TrapDefenseConfig>.Instance.GetAllAuxiliaryTypeList().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						TrapDefenseAuxiliaryType trapDefenseAuxiliaryType = enumerator2.Current;
						if (!hashSet.Contains(trapDefenseAuxiliaryType.Id))
						{
							ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
							{
								MachineType = this.Type,
								DataType = trapDefenseAuxiliaryType.Id,
								Level = 1,
								Branch = 0
							};
							TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData2 = TrapDefenseBuildingDevelopItemData.Create(ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info), this.Type);
							trapDefenseBuildingDevelopItemData2.SetIsUnLock(false);
							this.DataList.Add(trapDefenseBuildingDevelopItemData2);
							this.DataMap[trapDefenseAuxiliaryType.Id] = trapDefenseBuildingDevelopItemData2;
						}
					}
					goto IL_1F1;
				}
			}
			foreach (TrapDefenseBuildingType trapDefenseBuildingType in ConfigBase<TrapDefenseConfig>.Instance.GetAllBuildingTypeList())
			{
				if (this.Type == ETrapDefenseMachineType.Building)
				{
					TrapDefenseBuildingType trapDefenseBuildingType2 = trapDefenseBuildingType;
					if (this.PlacementType != (ETrapDefensePlacementType)trapDefenseBuildingType2.PlacementType)
					{
						continue;
					}
				}
				if (!hashSet.Contains(trapDefenseBuildingType.Id))
				{
					ITrapDefenseMachineIdInfo info2 = new ITrapDefenseMachineIdInfo
					{
						MachineType = this.Type,
						DataType = trapDefenseBuildingType.Id,
						Level = 1,
						Branch = 0
					};
					TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData3 = TrapDefenseBuildingDevelopItemData.Create(ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info2), this.Type);
					trapDefenseBuildingDevelopItemData3.SetIsUnLock(false);
					this.DataList.Add(trapDefenseBuildingDevelopItemData3);
					this.DataMap[trapDefenseBuildingType.Id] = trapDefenseBuildingDevelopItemData3;
				}
			}
			IL_1F1:
			this.SortList();
			return this.DataList.Count > 0;
		}

		// Token: 0x060337A9 RID: 210857 RVA: 0x00CDFE00 File Offset: 0x00CDE000
		private bool InitInDungeon()
		{
			this.DataList = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetInBattleDataByType(this.PlacementType);
			return this.DataList.Count > 0;
		}

		// Token: 0x060337AA RID: 210858 RVA: 0x00CDFE2B File Offset: 0x00CDE02B
		public List<TrapDefenseBuildingDevelopItemData> GetDataList()
		{
			return this.DataList;
		}

		// Token: 0x060337AB RID: 210859 RVA: 0x00CDFE33 File Offset: 0x00CDE033
		public Dictionary<int, TrapDefenseBuildingDevelopItemData> GetDataMap()
		{
			return this.DataMap;
		}

		// Token: 0x060337AC RID: 210860 RVA: 0x00CDFE3C File Offset: 0x00CDE03C
		public void UpdateItemData(int id, bool needEmit = true)
		{
			ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(id);
			if (!this.DataMap.ContainsKey(trapDefenseMachineIdInfo.DataType))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "机关养成更新无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ID", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TrapDefenseBuildingDevelopItemData p = this.DataMap[trapDefenseMachineIdInfo.DataType];
			if (needEmit)
			{
				Singleton<EventSystem>.Instance.Emit<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseOnDevelopUpdate, p);
			}
		}

		// Token: 0x060337AD RID: 210861 RVA: 0x00CDFEBE File Offset: 0x00CDE0BE
		protected void SortList()
		{
			this.DataList.Sort((TrapDefenseBuildingDevelopItemData a, TrapDefenseBuildingDevelopItemData b) => a.GetSortId() - b.GetSortId());
		}

		// Token: 0x0401DD11 RID: 122129
		public bool IsInDungeon;

		// Token: 0x0401DD12 RID: 122130
		public ETrapDefenseMachineType Type;

		// Token: 0x0401DD13 RID: 122131
		public ETrapDefensePlacementType PlacementType;

		// Token: 0x0401DD14 RID: 122132
		protected List<TrapDefenseBuildingDevelopItemData> DataList = new List<TrapDefenseBuildingDevelopItemData>();

		// Token: 0x0401DD15 RID: 122133
		protected Dictionary<int, TrapDefenseBuildingDevelopItemData> DataMap = new Dictionary<int, TrapDefenseBuildingDevelopItemData>();

		// Token: 0x0401DD16 RID: 122134
		[Nullable(2)]
		public TrapDefenseBuildingDevelopItemData CurSelectedData;

		// Token: 0x0401DD17 RID: 122135
		[Nullable(2)]
		public TrapDefenseBuildingDevelopItemData TempSelectedData;
	}
}
