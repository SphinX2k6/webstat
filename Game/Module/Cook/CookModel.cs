using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DFD RID: 24061
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CookModel : ModelBase<CookModel>
	{
		// Token: 0x0603C894 RID: 247956 RVA: 0x00F60883 File Offset: 0x00F5EA83
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603C895 RID: 247957 RVA: 0x00F60886 File Offset: 0x00F5EA86
		protected override bool OnClear()
		{
			this.ClearCookRoleItemDataList();
			return true;
		}

		// Token: 0x170098D7 RID: 39127
		// (get) Token: 0x0603C896 RID: 247958 RVA: 0x00F6088F File Offset: 0x00F5EA8F
		// (set) Token: 0x0603C897 RID: 247959 RVA: 0x00F60897 File Offset: 0x00F5EA97
		public ECookDataType CurrentCookViewType
		{
			get
			{
				return this.CookViewType;
			}
			set
			{
				this.CookViewType = value;
			}
		}

		// Token: 0x170098D8 RID: 39128
		// (get) Token: 0x0603C898 RID: 247960 RVA: 0x00F608A0 File Offset: 0x00F5EAA0
		// (set) Token: 0x0603C899 RID: 247961 RVA: 0x00F608A8 File Offset: 0x00F5EAA8
		public ECookListType CurrentCookListType
		{
			get
			{
				return this.CookListType;
			}
			set
			{
				this.CookListType = value;
			}
		}

		// Token: 0x0603C89A RID: 247962 RVA: 0x00F608B1 File Offset: 0x00F5EAB1
		public CookModel()
		{
			this.LimitRefreshTime = -1.0;
			this.LastExp = 0;
			this.CookViewType = ECookDataType.CookMain;
			this.CookListType = ECookListType.Cooking;
			this.TimeoutCookingDataMap = new Dictionary<int, ECookDataTimeState>();
		}

		// Token: 0x0603C89B RID: 247963 RVA: 0x00F608E8 File Offset: 0x00F5EAE8
		public void SaveLimitRefreshTime(long refreshTime)
		{
			this.LimitRefreshTime = (double)Singleton<MathUtils>.Instance.LongToNumber(refreshTime) * Singleton<TimeUtil>.Instance.Millisecond;
		}

		// Token: 0x0603C89C RID: 247964 RVA: 0x00F60907 File Offset: 0x00F5EB07
		public bool CheckCanCook(int itemId)
		{
			return this.CheckLimitCount(itemId) && this.CheckCoinEnough(itemId) && this.CheckMaterialEnough(itemId);
		}

		// Token: 0x0603C89D RID: 247965 RVA: 0x00F60924 File Offset: 0x00F5EB24
		public bool CheckLimitCount(int itemId)
		{
			ICookingData cookingDataById = this.GetCookingDataById(itemId);
			return cookingDataById.LimitTotalCount <= 0 || cookingDataById.CookCount < cookingDataById.LimitTotalCount;
		}

		// Token: 0x0603C89E RID: 247966 RVA: 0x00F60954 File Offset: 0x00F5EB54
		public bool CheckCoinEnough(int itemId)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId);
			List<OneItemConfig> list = new List<OneItemConfig>();
			for (int i = 0; i < cookFormulaById.ConsumeItemsLength; i++)
			{
				list.Add(cookFormulaById.ConsumeItems(i).Value);
			}
			return ModelBase<InventoryModel>.Instance.CheckIsCoinEnough(ControllerBase<CookController>.Instance.CookCoinId, list);
		}

		// Token: 0x0603C89F RID: 247967 RVA: 0x00F609B0 File Offset: 0x00F5EBB0
		public bool CheckMaterialEnough(int itemId)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId);
			for (int i = 0; i < cookFormulaById.ConsumeItemsLength; i++)
			{
				OneItemConfig value = cookFormulaById.ConsumeItems(i).Value;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(value.ItemId, 0);
				if (value.Count > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C8A0 RID: 247968 RVA: 0x00F60A10 File Offset: 0x00F5EC10
		public bool CheckHasItemTimeoutStateChangedCore()
		{
			List<ICookingData> cookingDataList = this.CookingDataList;
			Dictionary<int, ECookDataTimeState> timeoutCookingDataMap = this.TimeoutCookingDataMap;
			foreach (int key in new List<int>(timeoutCookingDataMap.Keys))
			{
				timeoutCookingDataMap[key]--;
			}
			bool result = false;
			foreach (ICookingData cookingData in cookingDataList)
			{
				if (cookingData.ExistStartTime != 0.0 && cookingData.ExistEndTime != 0.0)
				{
					int itemId = cookingData.ItemId;
					ECookDataTimeState ecookDataTimeState = Singleton<TimeUtil>.Instance.IsInTimeSpan(cookingData.ExistStartTime, cookingData.ExistEndTime) ? ECookDataTimeState.IN : ECookDataTimeState.OUT;
					ECookDataTimeState ecookDataTimeState2;
					if (!timeoutCookingDataMap.TryGetValue(itemId, out ecookDataTimeState2) || ecookDataTimeState2 != ecookDataTimeState - 1)
					{
						result = true;
					}
					timeoutCookingDataMap[itemId] = ecookDataTimeState;
				}
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, ECookDataTimeState> keyValuePair in timeoutCookingDataMap)
			{
				if (keyValuePair.Value == ECookDataTimeState.IN2NIL || keyValuePair.Value == ECookDataTimeState.OUT2NIL)
				{
					list.Add(keyValuePair.Key);
				}
			}
			foreach (int key2 in list)
			{
				timeoutCookingDataMap.Remove(key2);
			}
			return result;
		}

		// Token: 0x0603C8A1 RID: 247969 RVA: 0x00F60BCC File Offset: 0x00F5EDCC
		public void CreateCookingDataList(IReadOnlyList<SingleFoodFormulaInfo> cookFoodDataList)
		{
			if (this.CookingDataList == null)
			{
				this.CookingDataList = new List<ICookingData>();
			}
			this.CookingDataList.Clear();
			IReadOnlyList<CookFormula> readOnlyList = ConfigBase<CookConfig>.Instance.GetCookFormula() ?? new List<CookFormula>();
			Dictionary<int, ICookingData> dictionary = new Dictionary<int, ICookingData>();
			if (readOnlyList != null)
			{
				foreach (CookFormula cookFormula in readOnlyList)
				{
					ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(cookFormula.FoodItemId);
					CookingData cookingData = new CookingData
					{
						MainType = ECookListType.Cooking,
						SubType = ESubCookDataType.CookMenu,
						UniqueId = 0,
						ItemId = cookFormula.Id,
						CookCount = 0,
						IsNew = false,
						LastRoleId = null,
						IsCook = 0,
						Quality = config.Value.QualityId,
						EffectType = cookFormula.TypeId,
						DataId = cookFormula.FoodItemId,
						LimitTotalCount = 0,
						LimitedCount = 0,
						ExistStartTime = 0.0,
						ExistEndTime = 0.0,
						IsUnLock = false
					};
					dictionary.Add(cookingData.ItemId, cookingData);
					this.CookingDataList.Add(cookingData);
				}
			}
			if (cookFoodDataList != null)
			{
				foreach (SingleFoodFormulaInfo singleFoodFormulaInfo in cookFoodDataList)
				{
					CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(singleFoodFormulaInfo.Id);
					ItemInfo? config2 = ConfigBase<ItemConfig>.Instance.GetConfig(cookFormulaById.FoodItemId);
					ICookingData cookingData2;
					if (dictionary.ContainsKey(singleFoodFormulaInfo.Id))
					{
						cookingData2 = dictionary[singleFoodFormulaInfo.Id];
						cookingData2.CookCount = singleFoodFormulaInfo.CookCount;
						cookingData2.IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CookerLevelKey, singleFoodFormulaInfo.Id);
						cookingData2.LastRoleId = new int?(singleFoodFormulaInfo.LastRoleId);
						cookingData2.IsCook = 0;
						cookingData2.LimitTotalCount = singleFoodFormulaInfo.LimitCount;
						cookingData2.LimitedCount = singleFoodFormulaInfo.LimitCookCount;
						cookingData2.DataId = cookFormulaById.FoodItemId;
						cookingData2.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
						cookingData2.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
						cookingData2.IsUnLock = true;
					}
					else
					{
						cookingData2 = new CookingData
						{
							MainType = ECookListType.Cooking,
							SubType = ESubCookDataType.CookFood,
							UniqueId = 0,
							ItemId = singleFoodFormulaInfo.Id,
							CookCount = singleFoodFormulaInfo.CookCount,
							IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CookerLevelKey, singleFoodFormulaInfo.Id),
							LastRoleId = new int?(singleFoodFormulaInfo.LastRoleId),
							IsCook = 0,
							Quality = config2.Value.QualityId,
							EffectType = cookFormulaById.TypeId,
							DataId = cookFormulaById.FoodItemId,
							LimitTotalCount = singleFoodFormulaInfo.LimitCount,
							LimitedCount = singleFoodFormulaInfo.LimitCookCount,
							ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond,
							ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond,
							IsUnLock = true
						};
						this.CookingDataList.Add(cookingData2);
					}
					cookingData2.IsCook = ((this.CheckCanCook(singleFoodFormulaInfo.Id) > false) ? 1 : 0);
				}
			}
		}

		// Token: 0x0603C8A2 RID: 247970 RVA: 0x00F60FB0 File Offset: 0x00F5F1B0
		public void UpdateCookingDataList(IReadOnlyList<SingleFoodFormulaInfo> cookFoodDataList)
		{
			if (this.CookingDataList == null)
			{
				this.CreateCookingDataList(cookFoodDataList);
			}
			if (cookFoodDataList != null)
			{
				foreach (SingleFoodFormulaInfo singleFoodFormulaInfo in cookFoodDataList)
				{
					foreach (ICookingData cookingData in this.CookingDataList)
					{
						if (singleFoodFormulaInfo.Id == cookingData.ItemId)
						{
							cookingData.CookCount = singleFoodFormulaInfo.CookCount;
							cookingData.LimitTotalCount = singleFoodFormulaInfo.LimitCount;
							cookingData.LimitedCount = singleFoodFormulaInfo.LimitCookCount;
							if (!cookingData.IsUnLock)
							{
								CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(singleFoodFormulaInfo.Id);
								cookingData.IsNew = true;
								cookingData.IsUnLock = true;
								cookingData.DataId = cookFormulaById.FoodItemId;
								cookingData.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
								cookingData.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(singleFoodFormulaInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
								ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.CookerLevelKey, singleFoodFormulaInfo.Id);
								ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FormulaLearned", Array.Empty<object>());
							}
							cookingData.IsCook = ((this.CheckCanCook(singleFoodFormulaInfo.Id) > false) ? 1 : 0);
						}
					}
				}
			}
		}

		// Token: 0x0603C8A3 RID: 247971 RVA: 0x00F61154 File Offset: 0x00F5F354
		public void UpdateCookingDataByServerConfig(IReadOnlyList<OneFormulaConfig> formulaConfigs)
		{
			if (formulaConfigs != null)
			{
				using (IEnumerator<OneFormulaConfig> enumerator = formulaConfigs.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						OneFormulaConfig formulaCfg = enumerator.Current;
						double existStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(formulaCfg.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
						double existEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(formulaCfg.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
						int num = this.CookingDataList.FindIndex((ICookingData v) => v.ItemId == formulaCfg.Id);
						if (num != -1)
						{
							this.CookingDataList[num].ExistStartTime = existStartTime;
							this.CookingDataList[num].ExistEndTime = existEndTime;
						}
					}
				}
			}
		}

		// Token: 0x0603C8A4 RID: 247972 RVA: 0x00F61234 File Offset: 0x00F5F434
		public void UnlockCookMenuData(int formulaId)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(formulaId);
			int num = 0;
			while (num < this.CookingDataList.Count && (this.CookingDataList[num].SubType != ESubCookDataType.CookMenu || this.CookingDataList[num].ItemId != cookFormulaById.FormulaItemId))
			{
				num++;
			}
			this.CookingDataList.RemoveAt(num);
		}

		// Token: 0x0603C8A5 RID: 247973 RVA: 0x00F612A1 File Offset: 0x00F5F4A1
		public List<ICookingData> GetCookingDataList()
		{
			return this.CookingDataList;
		}

		// Token: 0x0603C8A6 RID: 247974 RVA: 0x00F612AC File Offset: 0x00F5F4AC
		[NullableContext(2)]
		public ICookingData GetCookingDataById(int itemId)
		{
			foreach (ICookingData cookingData in this.CookingDataList)
			{
				if (itemId == cookingData.ItemId)
				{
					return cookingData;
				}
			}
			return null;
		}

		// Token: 0x0603C8A7 RID: 247975 RVA: 0x00F61308 File Offset: 0x00F5F508
		public int GetCookRoleId(int itemId)
		{
			ICookingData cookingDataById = this.GetCookingDataById(itemId);
			if (cookingDataById != null && cookingDataById.LastRoleId != null)
			{
				int? lastRoleId = cookingDataById.LastRoleId;
				int num = 0;
				if (!(lastRoleId.GetValueOrDefault() == num & lastRoleId != null))
				{
					return cookingDataById.LastRoleId.Value;
				}
			}
			if (ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId() != 0)
			{
				return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
			}
			return 1502;
		}

		// Token: 0x0603C8A8 RID: 247976 RVA: 0x00F61378 File Offset: 0x00F5F578
		public void CreateMachiningDataList()
		{
			if (this.MachiningDataList == null)
			{
				this.MachiningDataList = new List<IMachiningData>();
			}
			foreach (CookProcessed cookProcessed in ConfigBase<CookConfig>.Instance.GetCookProcessed())
			{
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(cookProcessed.FinalItemId);
				MachiningData item = new MachiningData
				{
					MainType = ECookListType.Machining,
					ItemId = cookProcessed.Id,
					IsUnLock = false,
					InteractiveList = new List<int>(),
					UnlockList = new List<int>(),
					IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.CookerLevelKey, cookProcessed.Id),
					IsMachining = ((ControllerBase<CookController>.Instance.CheckCanProcessed(cookProcessed.Id) > false) ? 1 : 0),
					Quality = config.Value.QualityId
				};
				this.MachiningDataList.Add(item);
			}
			this.MachiningDataList.Sort(new Comparison<IMachiningData>(this.SortMachiningData));
		}

		// Token: 0x0603C8A9 RID: 247977 RVA: 0x00F61490 File Offset: 0x00F5F690
		private int SortMachiningData(IMachiningData aMachiningData, IMachiningData bMachiningData)
		{
			int num = (aMachiningData.IsUnLock > false) ? 1 : 0;
			int num2 = (bMachiningData.IsUnLock > false) ? 1 : 0;
			if (num == 1 && num == num2)
			{
				if (aMachiningData.IsMachining != bMachiningData.IsMachining)
				{
					return bMachiningData.IsMachining - aMachiningData.IsMachining;
				}
				if (aMachiningData.Quality == bMachiningData.Quality)
				{
					return aMachiningData.ItemId - bMachiningData.ItemId;
				}
				return aMachiningData.Quality - bMachiningData.Quality;
			}
			else
			{
				if (num != 0 || num != num2)
				{
					return num2 - num;
				}
				if (aMachiningData.Quality == bMachiningData.Quality)
				{
					return aMachiningData.ItemId - bMachiningData.ItemId;
				}
				return aMachiningData.Quality - bMachiningData.Quality;
			}
		}

		// Token: 0x0603C8AA RID: 247978 RVA: 0x00F61534 File Offset: 0x00F5F734
		public void UpdateMachiningDataList(IReadOnlyList<SingleProcessedFoodFormulaInfo> machiningDataList, bool isNew)
		{
			if (machiningDataList != null)
			{
				foreach (SingleProcessedFoodFormulaInfo singleProcessedFoodFormulaInfo in machiningDataList)
				{
					foreach (IMachiningData machiningData in this.MachiningDataList)
					{
						if (singleProcessedFoodFormulaInfo.Id == machiningData.ItemId)
						{
							List<int> list = new List<int>();
							List<int> list2 = new List<int>();
							CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(singleProcessedFoodFormulaInfo.Id);
							if (singleProcessedFoodFormulaInfo.LockState)
							{
								for (int i = 0; i < cookProcessedById.ConsumeItemsIdLength; i++)
								{
									list2.Add(cookProcessedById.ConsumeItemsId(i).Value.ItemId);
								}
								for (int j = 0; j < cookProcessedById.InterationIdLength; j++)
								{
									list.Add(cookProcessedById.InterationId(j));
								}
							}
							else
							{
								if (singleProcessedFoodFormulaInfo.Interations != null)
								{
									foreach (int item in singleProcessedFoodFormulaInfo.Interations)
									{
										list.Add(item);
									}
								}
								foreach (int num in list)
								{
									int num2 = -1;
									for (int k = 0; k < cookProcessedById.InterationIdLength; k++)
									{
										if (cookProcessedById.InterationId(k) == num)
										{
											num2 = k;
											break;
										}
									}
									if (num2 >= 0)
									{
										int itemId = cookProcessedById.ConsumeItemsId(num2).Value.ItemId;
										list2.Add(itemId);
									}
								}
							}
							machiningData.IsUnLock = (list.Count == cookProcessedById.InterationIdLength);
							machiningData.InteractiveList = list;
							machiningData.UnlockList = list2;
							machiningData.IsMachining = ((ControllerBase<CookController>.Instance.CheckCanProcessed(singleProcessedFoodFormulaInfo.Id) > false) ? 1 : 0);
							if (!isNew)
							{
								break;
							}
							machiningData.IsNew = isNew;
							ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.CookerLevelKey, singleProcessedFoodFormulaInfo.Id);
							if (singleProcessedFoodFormulaInfo.LockState)
							{
								ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FormulaLearned", Array.Empty<object>());
								break;
							}
							break;
						}
					}
				}
			}
			this.MachiningDataList.Sort(new Comparison<IMachiningData>(this.SortMachiningData));
		}

		// Token: 0x0603C8AB RID: 247979 RVA: 0x00F617FC File Offset: 0x00F5F9FC
		public List<IMachiningData> GetMachiningDataList()
		{
			return this.MachiningDataList;
		}

		// Token: 0x0603C8AC RID: 247980 RVA: 0x00F61804 File Offset: 0x00F5FA04
		[NullableContext(2)]
		public IMachiningData GetMachiningDataById(int id)
		{
			foreach (IMachiningData machiningData in this.MachiningDataList)
			{
				if (id == machiningData.ItemId)
				{
					return machiningData;
				}
			}
			return null;
		}

		// Token: 0x170098D9 RID: 39129
		// (get) Token: 0x0603C8AD RID: 247981 RVA: 0x00F61860 File Offset: 0x00F5FA60
		// (set) Token: 0x0603C8AE RID: 247982 RVA: 0x00F61868 File Offset: 0x00F5FA68
		public int SelectedCookerLevel
		{
			get
			{
				return this.CookerLevel;
			}
			set
			{
				this.CookerLevel = value;
			}
		}

		// Token: 0x0603C8AF RID: 247983 RVA: 0x00F61874 File Offset: 0x00F5FA74
		public void CreateCookerInfo(CookingInfo cookerInfo)
		{
			this.UpdateCookerInfo(cookerInfo);
			this.CookLevelMap = new Dictionary<int, CookLevel>();
			foreach (CookLevel value in ConfigBase<CookConfig>.Instance.GetCookLevel())
			{
				this.CookLevelMap.Add(value.Id, value);
			}
		}

		// Token: 0x0603C8B0 RID: 247984 RVA: 0x00F618E4 File Offset: 0x00F5FAE4
		public void UpdateCookerInfo(CookingInfo cookerInfo)
		{
			int addExp = 0;
			if (this.CookerInfo != null)
			{
				this.LastExp = this.CookerInfo.TotalProficiencys;
				addExp = cookerInfo.TotalProficiencys - this.CookerInfo.TotalProficiencys;
			}
			this.CookerInfo = new CookerInfoData
			{
				CookingLevel = cookerInfo.CookingLevel,
				TotalProficiencys = cookerInfo.TotalProficiencys,
				AddExp = addExp
			};
		}

		// Token: 0x0603C8B1 RID: 247985 RVA: 0x00F61949 File Offset: 0x00F5FB49
		public ICookerInfoData GetCookerInfo()
		{
			return this.CookerInfo;
		}

		// Token: 0x0603C8B2 RID: 247986 RVA: 0x00F61951 File Offset: 0x00F5FB51
		public void CleanAddExp()
		{
			this.CookerInfo.AddExp = 0;
		}

		// Token: 0x0603C8B3 RID: 247987 RVA: 0x00F6195F File Offset: 0x00F5FB5F
		public CookLevel GetCookLevelByLevel(int level)
		{
			return this.CookLevelMap[level];
		}

		// Token: 0x0603C8B4 RID: 247988 RVA: 0x00F6196D File Offset: 0x00F5FB6D
		public int GetCookerMaxLevel()
		{
			return this.CookLevelMap.Count;
		}

		// Token: 0x0603C8B5 RID: 247989 RVA: 0x00F6197C File Offset: 0x00F5FB7C
		public int GetSumExpByLevel(int level)
		{
			int cookerMaxLevel = this.GetCookerMaxLevel();
			int num = level + 1;
			if (num > cookerMaxLevel)
			{
				num = cookerMaxLevel;
			}
			return this.GetCookLevelByLevel(num).Completeness;
		}

		// Token: 0x0603C8B6 RID: 247990 RVA: 0x00F619AC File Offset: 0x00F5FBAC
		public int GetDropIdByLevel(int level)
		{
			int cookerMaxLevel = this.GetCookerMaxLevel();
			int num = level + 1;
			if (num > cookerMaxLevel)
			{
				return -1;
			}
			return this.GetCookLevelByLevel(num).DropIds;
		}

		// Token: 0x0603C8B7 RID: 247991 RVA: 0x00F619DC File Offset: 0x00F5FBDC
		public void CreateTmpMachiningItemList(List<ISingleItemInfo> itemInfoList)
		{
			if (this.TmpMachiningSlotItemList == null)
			{
				this.TmpMachiningSlotItemList = new List<ISingleItemInfo>();
			}
			this.TmpMachiningSlotItemList.Clear();
			if (this.TmpEmptyMachiningSlotItemList == null)
			{
				this.TmpEmptyMachiningSlotItemList = new List<ISingleItemInfo>();
			}
			this.TmpEmptyMachiningSlotItemList.Clear();
			if (this.TmpEmptyMachiningSlotSelectedNumMap == null)
			{
				this.TmpEmptyMachiningSlotSelectedNumMap = new Dictionary<int, int>();
			}
			this.TmpEmptyMachiningSlotSelectedNumMap.Clear();
			this.TmpMachiningSlotItemList.Clear();
			this.TmpEmptyMachiningSlotItemList.Clear();
			foreach (ISingleItemInfo singleItemInfo in itemInfoList)
			{
				this.TmpMachiningSlotItemList.Add(singleItemInfo);
				if (!singleItemInfo.Proto_IsUnlock)
				{
					this.TmpEmptyMachiningSlotItemList.Add(singleItemInfo);
				}
			}
		}

		// Token: 0x0603C8B8 RID: 247992 RVA: 0x00F61AB4 File Offset: 0x00F5FCB4
		public void UpdateTmpMachiningItemList(int index, ISingleItemInfo itemInfo)
		{
			this.TmpMachiningSlotItemList[index] = itemInfo;
		}

		// Token: 0x0603C8B9 RID: 247993 RVA: 0x00F61AC4 File Offset: 0x00F5FCC4
		public void SubOneTmpMachiningItemSelectNum(int index)
		{
			if (this.TmpMachiningSlotItemList[index] == null)
			{
				return;
			}
			ISingleItemInfo singleItemInfo = this.TmpMachiningSlotItemList[index];
			if (!this.TmpEmptyMachiningSlotSelectedNumMap.ContainsKey(singleItemInfo.Proto_ItemId))
			{
				return;
			}
			int num = this.TmpEmptyMachiningSlotSelectedNumMap[singleItemInfo.Proto_ItemId] - 1;
			this.TmpEmptyMachiningSlotSelectedNumMap[singleItemInfo.Proto_ItemId] = num;
			if (num > 0)
			{
				return;
			}
			this.TmpEmptyMachiningSlotSelectedNumMap.Remove(singleItemInfo.Proto_ItemId);
			singleItemInfo.Proto_IsUnlock = false;
			ISingleItemInfo singleItemInfo2 = new ISingleItemInfo
			{
				Proto_IsUnlock = false,
				Proto_ItemId = 0,
				Proto_ItemNum = 0
			};
			singleItemInfo2.Proto_IsUnlock = singleItemInfo.Proto_IsUnlock;
			singleItemInfo2.Proto_ItemId = singleItemInfo.Proto_ItemId;
			int i;
			for (i = this.TmpEmptyMachiningSlotItemList.IndexOf(singleItemInfo); i < this.TmpEmptyMachiningSlotItemList.Count - 1; i++)
			{
				ISingleItemInfo singleItemInfo3 = this.TmpEmptyMachiningSlotItemList[i + 1];
				ISingleItemInfo singleItemInfo4 = this.TmpEmptyMachiningSlotItemList[i];
				singleItemInfo4.Proto_IsUnlock = singleItemInfo3.Proto_IsUnlock;
				singleItemInfo4.Proto_ItemId = singleItemInfo3.Proto_ItemId;
			}
			this.TmpEmptyMachiningSlotItemList[i].Proto_IsUnlock = singleItemInfo2.Proto_IsUnlock;
			this.TmpEmptyMachiningSlotItemList[i].Proto_ItemId = singleItemInfo2.Proto_ItemId;
		}

		// Token: 0x0603C8BA RID: 247994 RVA: 0x00F61BFE File Offset: 0x00F5FDFE
		public void ClearTmpMachiningItemList()
		{
			this.TmpMachiningSlotItemList.Clear();
			this.TmpEmptyMachiningSlotItemList.Clear();
			this.TmpEmptyMachiningSlotSelectedNumMap.Clear();
		}

		// Token: 0x0603C8BB RID: 247995 RVA: 0x00F61C24 File Offset: 0x00F5FE24
		public void SetEmptyBySelectedItem(int index, bool isUnlock, int? selectedItemId = null, int? selectedCount = null)
		{
			ISingleItemInfo singleItemInfo = this.TmpEmptyMachiningSlotItemList[index];
			if (singleItemInfo == null)
			{
				return;
			}
			if (selectedItemId != null)
			{
				singleItemInfo.Proto_ItemId = selectedItemId.Value;
				if (selectedCount != null)
				{
					this.TmpEmptyMachiningSlotSelectedNumMap[selectedItemId.Value] = selectedCount.Value;
				}
			}
			singleItemInfo.Proto_IsUnlock = isUnlock;
		}

		// Token: 0x0603C8BC RID: 247996 RVA: 0x00F61C84 File Offset: 0x00F5FE84
		[NullableContext(0)]
		public ValueTuple<bool, int> IsSelectNumFromEmpty(int itemId)
		{
			bool item = false;
			int item2 = 0;
			if (this.TmpEmptyMachiningSlotSelectedNumMap.ContainsKey(itemId))
			{
				item = true;
				item2 = this.TmpEmptyMachiningSlotSelectedNumMap[itemId];
			}
			return new ValueTuple<bool, int>(item, item2);
		}

		// Token: 0x0603C8BD RID: 247997 RVA: 0x00F61CBC File Offset: 0x00F5FEBC
		public bool CheckCanProcessedNew(int itemId)
		{
			if (this.TmpEmptyMachiningSlotSelectedNumMap.Count == 0)
			{
				return ControllerBase<CookController>.Instance.CheckCanProcessed(itemId);
			}
			bool result = true;
			foreach (ISingleItemInfo singleItemInfo in this.TmpMachiningSlotItemList)
			{
				if (this.TmpEmptyMachiningSlotSelectedNumMap.ContainsKey(singleItemInfo.Proto_ItemId))
				{
					int num = this.TmpEmptyMachiningSlotSelectedNumMap[singleItemInfo.Proto_ItemId];
					if (singleItemInfo.Proto_ItemNum > num)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0603C8BE RID: 247998 RVA: 0x00F61D58 File Offset: 0x00F5FF58
		public List<ISingleItemInfo> GetTmpMachiningItemList()
		{
			return this.TmpMachiningSlotItemList;
		}

		// Token: 0x0603C8BF RID: 247999 RVA: 0x00F61D60 File Offset: 0x00F5FF60
		public int GetEmptyMachiningItemListNum()
		{
			return this.TmpEmptyMachiningSlotItemList.Count;
		}

		// Token: 0x170098DA RID: 39130
		// (get) Token: 0x0603C8C0 RID: 248000 RVA: 0x00F61D6D File Offset: 0x00F5FF6D
		// (set) Token: 0x0603C8C1 RID: 248001 RVA: 0x00F61D75 File Offset: 0x00F5FF75
		public int? CurrentCookRoleId
		{
			get
			{
				return this.CookRoleId;
			}
			set
			{
				this.CookRoleId = value;
			}
		}

		// Token: 0x0603C8C2 RID: 248002 RVA: 0x00F61D80 File Offset: 0x00F5FF80
		public void UpdateCookRoleItemDataList()
		{
			if (this.CookRoleItemDataList == null)
			{
				this.CookRoleItemDataList = new List<ICookRoleItemData>();
			}
			this.CookRoleItemDataList.Clear();
			foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
			{
				this.CookRoleItemDataList.Add(new CookRoleItemData
				{
					RoleId = roleInstance.GetRoleId(),
					RoleName = roleInstance.GetRoleRealName(),
					RoleIcon = roleInstance.GetRoleConfig().RoleHeadIcon,
					IsBuff = false,
					ItemId = 0
				});
			}
		}

		// Token: 0x0603C8C3 RID: 248003 RVA: 0x00F61E12 File Offset: 0x00F60012
		public void ClearCookRoleItemDataList()
		{
			this.CookRoleItemDataList = null;
		}

		// Token: 0x0603C8C4 RID: 248004 RVA: 0x00F61E1C File Offset: 0x00F6001C
		public List<ICookRoleItemData> GetCookRoleItemDataList(int itemId)
		{
			if (this.CookRoleItemDataList == null)
			{
				this.UpdateCookRoleItemDataList();
			}
			foreach (ICookRoleItemData cookRoleItemData in this.CookRoleItemDataList)
			{
				cookRoleItemData.ItemId = itemId;
				cookRoleItemData.IsBuff = ControllerBase<CookController>.Instance.CheckIsBuff(cookRoleItemData.RoleId, itemId);
			}
			this.CookRoleItemDataList.Sort(new Comparison<ICookRoleItemData>(this.SortCookRoleItemDataList));
			return this.CookRoleItemDataList;
		}

		// Token: 0x0603C8C5 RID: 248005 RVA: 0x00F61EB4 File Offset: 0x00F600B4
		private int SortCookRoleItemDataList(ICookRoleItemData dataA, ICookRoleItemData dataB)
		{
			if (dataA.IsBuff == dataB.IsBuff)
			{
				return dataA.RoleId - dataB.RoleId;
			}
			if (dataA.IsBuff)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x0603C8C6 RID: 248006 RVA: 0x00F61EE0 File Offset: 0x00F600E0
		public List<ISingleItemInfo> GetCookMaterialList(int itemId, ECookListType type)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			if (type == ECookListType.Cooking)
			{
				CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId);
				for (int i = 0; i < cookFormulaById.ConsumeItemsLength; i++)
				{
					OneItemConfig value = cookFormulaById.ConsumeItems(i).Value;
					list.Add(new ISingleItemInfo
					{
						Proto_ItemId = value.ItemId,
						Proto_ItemNum = value.Count,
						Proto_IsUnlock = true
					});
				}
			}
			else
			{
				IMachiningData machiningDataById = this.GetMachiningDataById(itemId);
				CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId);
				for (int j = 0; j < cookProcessedById.ConsumeItemsIdLength; j++)
				{
					OneItemConfig value2 = cookProcessedById.ConsumeItemsId(j).Value;
					list.Add(new ISingleItemInfo
					{
						Proto_ItemId = value2.ItemId,
						Proto_ItemNum = value2.Count,
						Proto_IsUnlock = machiningDataById.UnlockList.Contains(value2.ItemId)
					});
				}
			}
			return list;
		}

		// Token: 0x0603C8C7 RID: 248007 RVA: 0x00F61FD4 File Offset: 0x00F601D4
		public List<ISingleItemInfo> GetMachiningMaterialStudyList(int itemId)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			IMachiningData machiningDataById = this.GetMachiningDataById(itemId);
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId);
			for (int i = 0; i < cookProcessedById.ConsumeItemsIdLength; i++)
			{
				OneItemConfig value = cookProcessedById.ConsumeItemsId(i).Value;
				bool flag = machiningDataById.UnlockList.Contains(value.ItemId);
				list.Add(new ISingleItemInfo
				{
					Proto_ItemId = (flag ? value.ItemId : 0),
					Proto_ItemNum = value.Count,
					Proto_IsUnlock = flag
				});
			}
			return list;
		}

		// Token: 0x0603C8C8 RID: 248008 RVA: 0x00F6206C File Offset: 0x00F6026C
		[NullableContext(2)]
		public string GetRefreshLimitTime()
		{
			if (this.LimitRefreshTime == 0.0)
			{
				return null;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.LimitRefreshTime - serverTime).CountDownText;
		}

		// Token: 0x0603C8C9 RID: 248009 RVA: 0x00F620B0 File Offset: 0x00F602B0
		public double GetRefreshLimitTimeValue()
		{
			if (this.LimitRefreshTime <= 0.0)
			{
				return 1.0;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.LimitRefreshTime - serverTime).RemainingTime;
		}

		// Token: 0x170098DB RID: 39131
		// (get) Token: 0x0603C8CA RID: 248010 RVA: 0x00F620FA File Offset: 0x00F602FA
		// (set) Token: 0x0603C8CB RID: 248011 RVA: 0x00F62102 File Offset: 0x00F60302
		public int CurrentFixId
		{
			get
			{
				return this.FixId;
			}
			set
			{
				this.FixId = value;
			}
		}

		// Token: 0x170098DC RID: 39132
		// (get) Token: 0x0603C8CC RID: 248012 RVA: 0x00F6210B File Offset: 0x00F6030B
		// (set) Token: 0x0603C8CD RID: 248013 RVA: 0x00F62113 File Offset: 0x00F60313
		public long? CurrentEntityId
		{
			get
			{
				return this.EntityId;
			}
			set
			{
				this.EntityId = value;
			}
		}

		// Token: 0x0603C8CE RID: 248014 RVA: 0x00F6211C File Offset: 0x00F6031C
		public void UpdateCookItemList(IReadOnlyList<SingleItemInfo> itemList)
		{
			if (this.CookItemList == null)
			{
				this.CookItemList = new List<ICookPopItem>();
			}
			this.CookItemList.Clear();
			if (itemList != null)
			{
				foreach (SingleItemInfo singleItemInfo in itemList)
				{
					this.CookItemList.Add(new CookPopItem
					{
						ItemId = singleItemInfo.ItemId,
						ItemNum = singleItemInfo.ItemNum
					});
				}
			}
		}

		// Token: 0x0603C8CF RID: 248015 RVA: 0x00F621A8 File Offset: 0x00F603A8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICookPopItem> GetCookItemList()
		{
			return this.CookItemList;
		}

		// Token: 0x040220A0 RID: 139424
		private double LimitRefreshTime;

		// Token: 0x040220A1 RID: 139425
		public int LastExp;

		// Token: 0x040220A2 RID: 139426
		public long? CurrentInteractCreatureDataLongId;

		// Token: 0x040220A3 RID: 139427
		private ECookDataType CookViewType;

		// Token: 0x040220A4 RID: 139428
		private ECookListType CookListType;

		// Token: 0x040220A5 RID: 139429
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICookingData> CookingDataList;

		// Token: 0x040220A6 RID: 139430
		private readonly Dictionary<int, ECookDataTimeState> TimeoutCookingDataMap;

		// Token: 0x040220A7 RID: 139431
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IMachiningData> MachiningDataList;

		// Token: 0x040220A8 RID: 139432
		private int CookerLevel;

		// Token: 0x040220A9 RID: 139433
		[Nullable(2)]
		private Dictionary<int, CookLevel> CookLevelMap;

		// Token: 0x040220AA RID: 139434
		[Nullable(2)]
		private ICookerInfoData CookerInfo;

		// Token: 0x040220AB RID: 139435
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ISingleItemInfo> TmpMachiningSlotItemList;

		// Token: 0x040220AC RID: 139436
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ISingleItemInfo> TmpEmptyMachiningSlotItemList;

		// Token: 0x040220AD RID: 139437
		[Nullable(2)]
		private Dictionary<int, int> TmpEmptyMachiningSlotSelectedNumMap;

		// Token: 0x040220AE RID: 139438
		private int? CookRoleId;

		// Token: 0x040220AF RID: 139439
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICookRoleItemData> CookRoleItemDataList;

		// Token: 0x040220B0 RID: 139440
		private int FixId;

		// Token: 0x040220B1 RID: 139441
		private long? EntityId;

		// Token: 0x040220B2 RID: 139442
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICookPopItem> CookItemList;
	}
}
