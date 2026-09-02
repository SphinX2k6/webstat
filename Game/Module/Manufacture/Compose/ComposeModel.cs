using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059BB RID: 22971
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeModel : ModelBase<ComposeModel>
	{
		// Token: 0x0603A28B RID: 238219 RVA: 0x00EB99AE File Offset: 0x00EB7BAE
		public void SaveLimitRefreshTime(long refreshTime)
		{
			this.LimitRefreshTime = (double)refreshTime * Singleton<TimeUtil>.Instance.Millisecond;
		}

		// Token: 0x0603A28C RID: 238220 RVA: 0x00EB99C4 File Offset: 0x00EB7BC4
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

		// Token: 0x0603A28D RID: 238221 RVA: 0x00EB9A08 File Offset: 0x00EB7C08
		public double GetRefreshLimitTimeValue()
		{
			if (this.LimitRefreshTime <= 0.0)
			{
				return 1.0;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(this.LimitRefreshTime - serverTime).RemainingTime;
		}

		// Token: 0x0603A28E RID: 238222 RVA: 0x00EB9A54 File Offset: 0x00EB7C54
		protected override bool OnInit()
		{
			this.ComposeEnterFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ComposeEnterStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ComposeEnterFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ComposeEnterFlowId").Value
			};
			this.ComposeSuccessFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ComposeSuccessStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ComposeSuccessFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ComposeSuccessFlowId").Value
			};
			this.ComposeFailFlow = new PlayFlow
			{
				StateId = ConfigCommonParamById.GetIntConfig("ComposeFailStateId").Value,
				FlowListName = ConfigCommonParamById.GetStringConfig("ComposeFailFlowListName"),
				FlowId = ConfigCommonParamById.GetIntConfig("ComposeFailFlowId").Value
			};
			return true;
		}

		// Token: 0x0603A28F RID: 238223 RVA: 0x00EB9B43 File Offset: 0x00EB7D43
		protected override bool OnClear()
		{
			this.ComposeEnterFlow = null;
			this.ComposeSuccessFlow = null;
			this.ComposeFailFlow = null;
			this.ClearComposeRoleItemDataList();
			return true;
		}

		// Token: 0x17009489 RID: 38025
		// (get) Token: 0x0603A290 RID: 238224 RVA: 0x00EB9B61 File Offset: 0x00EB7D61
		// (set) Token: 0x0603A291 RID: 238225 RVA: 0x00EB9B69 File Offset: 0x00EB7D69
		public EComposeViewType CurrentComposeViewType
		{
			get
			{
				return this.ComposeViewType;
			}
			set
			{
				this.ComposeViewType = value;
			}
		}

		// Token: 0x1700948A RID: 38026
		// (get) Token: 0x0603A292 RID: 238226 RVA: 0x00EB9B72 File Offset: 0x00EB7D72
		// (set) Token: 0x0603A293 RID: 238227 RVA: 0x00EB9B7A File Offset: 0x00EB7D7A
		public EComposeListType CurrentComposeListType
		{
			get
			{
				return this.ComposeListType;
			}
			set
			{
				this.ComposeListType = value;
			}
		}

		// Token: 0x0603A294 RID: 238228 RVA: 0x00EB9B83 File Offset: 0x00EB7D83
		public bool IsInPurificationList()
		{
			return ComposeDefine.IsPurificationLikeType(this.ComposeListType);
		}

		// Token: 0x0603A295 RID: 238229 RVA: 0x00EB9B90 File Offset: 0x00EB7D90
		public void CreateComposeDataList(IList<OneSynthesisInfo> composeDataList)
		{
			this.CreateReagentProductionDataList(composeDataList);
			this.CreateStructureDataList(composeDataList);
			this.UpdatePurificationDataList(composeDataList);
			this.UpdateCollectDataList(composeDataList);
			this.CreateExchangeDataList();
		}

		// Token: 0x0603A296 RID: 238230 RVA: 0x00EB9BB4 File Offset: 0x00EB7DB4
		public void UpdateComposeDataList(IList<OneSynthesisInfo> composeDataList)
		{
			this.UpdateReagentProductionDataList(composeDataList);
			this.UpdateStructureDataList(composeDataList);
			this.UpdatePurificationDataList(composeDataList);
			this.UpdateCollectDataList(composeDataList);
		}

		// Token: 0x0603A297 RID: 238231 RVA: 0x00EB9BD4 File Offset: 0x00EB7DD4
		public void UpdateComposeByServerConfig(IList<OneSynthesisConfig> synthesisConfigs)
		{
			using (IEnumerator<OneSynthesisConfig> enumerator = synthesisConfigs.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					OneSynthesisConfig synthesisCfg = enumerator.Current;
					double num = (double)Singleton<MathUtils>.Instance.LongToNumber(synthesisCfg.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
					double num2 = (double)Singleton<MathUtils>.Instance.LongToNumber(synthesisCfg.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
					int num3 = this.ReagentProductionDataList.FindIndex((IReagentProductionData v) => v.ConfigId == synthesisCfg.Id);
					if (num3 != -1)
					{
						if ((num == 0.0 && num2 == 0.0) || Singleton<TimeUtil>.Instance.IsInTimeSpan(num, num2))
						{
							this.ReagentProductionDataList[num3].ExistStartTime = num;
							this.ReagentProductionDataList[num3].ExistEndTime = num2;
						}
						else
						{
							this.ReagentProductionDataList.RemoveAt(num3);
						}
					}
				}
			}
		}

		// Token: 0x0603A298 RID: 238232 RVA: 0x00EB9CE4 File Offset: 0x00EB7EE4
		public void HideComposeDataList(IList<int> hideIdList)
		{
			this.HideStructureDataList(hideIdList);
		}

		// Token: 0x0603A299 RID: 238233 RVA: 0x00EB9CF0 File Offset: 0x00EB7EF0
		public void CreateReagentProductionDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.ReagentProductionDataList == null)
			{
				this.ReagentProductionDataList = new List<IReagentProductionData>();
			}
			this.ReagentProductionDataList.Clear();
			IEnumerable<SynthesisFormula> enumerable = ConfigBase<ComposeConfig>.Instance.GetComposeListByType(1) ?? Array.Empty<SynthesisFormula>();
			Dictionary<int, IReagentProductionData> dictionary = new Dictionary<int, IReagentProductionData>();
			foreach (SynthesisFormula synthesisFormula in enumerable)
			{
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormula.ItemId);
				IReagentProductionData reagentProductionData = new IReagentProductionData
				{
					MainType = EComposeListType.ReagentProduction,
					SubType = ESubComposeDataType.Compose,
					UniqueId = 0,
					ConfigId = synthesisFormula.Id,
					ComposeCount = 0,
					IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, synthesisFormula.Id),
					LastRoleId = 0,
					Quality = config.Value.QualityId,
					EffectType = synthesisFormula.TypeId,
					ExistStartTime = 0.0,
					ExistEndTime = 0.0,
					MadeCountInLimitTime = 0,
					TotalMakeCountInLimitTime = synthesisFormula.LimitCount,
					IsUnlock = 0,
					GroupId = 0,
					IsLimitForever = synthesisFormula.PermanentLimit,
					SortId = synthesisFormula.SortId
				};
				this.ReagentProductionDataList.Add(reagentProductionData);
				dictionary[synthesisFormula.Id] = reagentProductionData;
			}
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				IReagentProductionData reagentProductionData2;
				if (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id).Value.FormulaType == 1 && dictionary.TryGetValue(oneSynthesisInfo.Id, out reagentProductionData2))
				{
					reagentProductionData2.ConfigId = oneSynthesisInfo.Id;
					reagentProductionData2.ComposeCount = oneSynthesisInfo.Count;
					reagentProductionData2.IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, oneSynthesisInfo.Id);
					reagentProductionData2.LastRoleId = oneSynthesisInfo.LastRoleId;
					reagentProductionData2.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
					reagentProductionData2.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
					reagentProductionData2.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
					reagentProductionData2.TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount;
					reagentProductionData2.IsUnlock = 1;
				}
			}
		}

		// Token: 0x0603A29A RID: 238234 RVA: 0x00EB9FAC File Offset: 0x00EB81AC
		public void UpdateReagentProductionDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.ReagentProductionDataList.Count <= 0)
			{
				return;
			}
			bool flag = false;
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				if (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id).Value.FormulaType == 1)
				{
					bool flag2 = false;
					foreach (IReagentProductionData reagentProductionData in this.ReagentProductionDataList)
					{
						if (oneSynthesisInfo.Id == reagentProductionData.ConfigId)
						{
							bool flag3 = reagentProductionData.IsUnlock == 1;
							reagentProductionData.ComposeCount = oneSynthesisInfo.Count;
							reagentProductionData.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
							reagentProductionData.IsUnlock = 1;
							flag2 = true;
							if (!flag3)
							{
								flag = true;
								break;
							}
							break;
						}
					}
					if (!flag2)
					{
						SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id);
						ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormulaById.Value.ItemId);
						IReagentProductionData item = new IReagentProductionData
						{
							MainType = EComposeListType.ReagentProduction,
							SubType = ESubComposeDataType.Compose,
							UniqueId = 0,
							ConfigId = oneSynthesisInfo.Id,
							ComposeCount = oneSynthesisInfo.Count,
							IsNew = true,
							LastRoleId = oneSynthesisInfo.LastRoleId,
							Quality = config.Value.QualityId,
							EffectType = synthesisFormulaById.Value.TypeId,
							ExistStartTime = (double)oneSynthesisInfo.LimitBeginTime * Singleton<TimeUtil>.Instance.Millisecond,
							ExistEndTime = (double)oneSynthesisInfo.LimitEndTime * Singleton<TimeUtil>.Instance.Millisecond,
							MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount,
							TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount,
							IsUnlock = 1,
							GroupId = 0,
							IsLimitForever = synthesisFormulaById.Value.PermanentLimit,
							SortId = synthesisFormulaById.Value.SortId
						};
						flag = true;
						ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, oneSynthesisInfo.Id);
						this.ReagentProductionDataList.Add(item);
					}
				}
			}
			if (flag)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FormulaLearned", Array.Empty<object>());
			}
		}

		// Token: 0x0603A29B RID: 238235 RVA: 0x00EBA22C File Offset: 0x00EB842C
		public void UnlockReagentProductionData(int id)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(id);
			if (synthesisFormulaById.Value.FormulaType != 1)
			{
				return;
			}
			int num = 0;
			while (num < this.ReagentProductionDataList.Count && (this.ReagentProductionDataList[num].SubType != ESubComposeDataType.ComposeMenu || this.ReagentProductionDataList[num].ConfigId != synthesisFormulaById.Value.FormulaItemId))
			{
				num++;
			}
			this.ReagentProductionDataList.RemoveAt(num);
		}

		// Token: 0x0603A29C RID: 238236 RVA: 0x00EBA2B1 File Offset: 0x00EB84B1
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IReagentProductionData> GetReagentProductionDataList()
		{
			return this.ReagentProductionDataList;
		}

		// Token: 0x0603A29D RID: 238237 RVA: 0x00EBA2BC File Offset: 0x00EB84BC
		[NullableContext(2)]
		public IReagentProductionData GetReagentProductionDataById(int itemId)
		{
			foreach (IReagentProductionData reagentProductionData in this.ReagentProductionDataList)
			{
				if (itemId == reagentProductionData.ConfigId)
				{
					return reagentProductionData;
				}
			}
			return null;
		}

		// Token: 0x0603A29E RID: 238238 RVA: 0x00EBA318 File Offset: 0x00EB8518
		public int GetReagentProductionRoleId(int itemId)
		{
			IReagentProductionData reagentProductionDataById = this.GetReagentProductionDataById(itemId);
			if (reagentProductionDataById != null)
			{
				int lastRoleId = reagentProductionDataById.LastRoleId;
				if (reagentProductionDataById.LastRoleId > 0)
				{
					return reagentProductionDataById.LastRoleId;
				}
			}
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
		}

		// Token: 0x0603A29F RID: 238239 RVA: 0x00EBA354 File Offset: 0x00EB8554
		public void CreateExchangeDataList()
		{
			if (this.ExchangeDataList == null)
			{
				this.ExchangeDataList = new List<IExchangeData>();
			}
			this.ExchangeDataList.Clear();
			IEnumerable<MaterialReplace> enumerable = ConfigBase<ComposeConfig>.Instance.GetExchangeList() ?? new MaterialReplace[0];
			Dictionary<int, IExchangeData> dictionary = new Dictionary<int, IExchangeData>();
			foreach (MaterialReplace materialReplace in enumerable)
			{
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(materialReplace.ItemId);
				IExchangeData exchangeData = new IExchangeData
				{
					MainType = EComposeListType.Exchange,
					ConfigId = materialReplace.ItemId,
					IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, materialReplace.ItemId),
					LastRoleId = 0,
					Quality = config.Value.QualityId,
					ExistStartTime = 0.0,
					ExistEndTime = 0.0,
					MadeCountInLimitTime = 0,
					TotalMakeCountInLimitTime = 0,
					IsUnlock = 1,
					ExchangeGroupId = materialReplace.GroupId,
					GroupId = materialReplace.ShowGroupId,
					IsLimitForever = false,
					SortId = materialReplace.SortId
				};
				this.ExchangeDataList.Add(exchangeData);
				dictionary[materialReplace.ItemId] = exchangeData;
			}
		}

		// Token: 0x0603A2A0 RID: 238240 RVA: 0x00EBA4B4 File Offset: 0x00EB86B4
		[NullableContext(2)]
		public IExchangeData GetExchangeDataById(int id)
		{
			foreach (IExchangeData exchangeData in this.ExchangeDataList)
			{
				if (id == exchangeData.ConfigId)
				{
					return exchangeData;
				}
			}
			return null;
		}

		// Token: 0x0603A2A1 RID: 238241 RVA: 0x00EBA510 File Offset: 0x00EB8710
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IExchangeData> GetExchangeDataList()
		{
			return this.ExchangeDataList;
		}

		// Token: 0x0603A2A2 RID: 238242 RVA: 0x00EBA518 File Offset: 0x00EB8718
		public List<ISingleItemInfo> GetExchangeMaterialListByGroupIdAndQualityId(int groupId, int quality)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			List<int> list2;
			if (!this.ExchangeItemBaseMap.TryGetValue(groupId, out list2))
			{
				return list;
			}
			foreach (int configId in list2)
			{
				CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(configId, 0);
				if (commonItemData != null && commonItemData.GetQuality() == quality)
				{
					list.Add(new ISingleItemInfo
					{
						Proto_ItemId = commonItemData.GetConfigId(),
						Proto_ItemNum = commonItemData.GetCount(),
						Proto_IsUnlock = true
					});
				}
			}
			return list;
		}

		// Token: 0x0603A2A3 RID: 238243 RVA: 0x00EBA5C0 File Offset: 0x00EB87C0
		public List<ISingleItemInfo> GetExchangeMaterialListByGroupId(int groupId)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			IReadOnlyList<MaterialReplace> exchangeByGroupId = ConfigBase<ComposeConfig>.Instance.GetExchangeByGroupId(groupId);
			if (exchangeByGroupId == null)
			{
				return list;
			}
			foreach (MaterialReplace materialReplace in exchangeByGroupId)
			{
				CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(materialReplace.ItemId, 0);
				list.Add(new ISingleItemInfo
				{
					Proto_ItemId = materialReplace.ItemId,
					Proto_ItemNum = ((commonItemData != null) ? commonItemData.GetCount() : 0),
					Proto_IsUnlock = true
				});
			}
			return list;
		}

		// Token: 0x0603A2A4 RID: 238244 RVA: 0x00EBA660 File Offset: 0x00EB8860
		public bool CheckCanReagentProduction(int id)
		{
			EBaseItemDataCheckMask checkFlags = (EBaseItemDataCheckMask)239;
			return this.CheckBaseItemData(this.GetReagentProductionDataById(id), checkFlags);
		}

		// Token: 0x0603A2A5 RID: 238245 RVA: 0x00EBA684 File Offset: 0x00EB8884
		public bool CheckCanPurification(int id)
		{
			EBaseItemDataCheckMask checkFlags = (EBaseItemDataCheckMask)239;
			return this.CheckBaseItemData(this.GetPurificationDataById(id), checkFlags);
		}

		// Token: 0x0603A2A6 RID: 238246 RVA: 0x00EBA6A8 File Offset: 0x00EB88A8
		public bool CheckCanStructure(int id)
		{
			EBaseItemDataCheckMask checkFlags = (EBaseItemDataCheckMask)239;
			return this.CheckBaseItemData(this.GetStructureDataById(id), checkFlags);
		}

		// Token: 0x0603A2A7 RID: 238247 RVA: 0x00EBA6CC File Offset: 0x00EB88CC
		public bool CheckCanExchange(int id)
		{
			EBaseItemDataCheckMask checkFlags = (EBaseItemDataCheckMask)19;
			return this.CheckBaseItemData(this.GetExchangeDataById(id), checkFlags);
		}

		// Token: 0x0603A2A8 RID: 238248 RVA: 0x00EBA6EC File Offset: 0x00EB88EC
		public bool CheckBaseItemData(IBaseItemData data, EBaseItemDataCheckMask checkFlags = EBaseItemDataCheckMask.All)
		{
			return true & ((checkFlags & EBaseItemDataCheckMask.Unlock) <= (EBaseItemDataCheckMask)0 || this.CheckUnlock(data)) & ((checkFlags & EBaseItemDataCheckMask.LimitCount) <= (EBaseItemDataCheckMask)0 || this.CheckLimitCount(data)) & ((checkFlags & EBaseItemDataCheckMask.CoinEnough) <= (EBaseItemDataCheckMask)0 || this.CheckCoinEnough(data.ConfigId)) & ((checkFlags & EBaseItemDataCheckMask.ComposeMaterialEnough) <= (EBaseItemDataCheckMask)0 || this.CheckComposeMaterialEnough(data.ConfigId)) & ((checkFlags & EBaseItemDataCheckMask.ExchangeMaterialEnough) <= (EBaseItemDataCheckMask)0 || this.CheckExchangeMaterialEnough(data.ConfigId));
		}

		// Token: 0x0603A2A9 RID: 238249 RVA: 0x00EBA760 File Offset: 0x00EB8960
		public bool CheckCoinEnough(int id)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(id);
			if (synthesisFormulaById == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "合成配方不存在, 跳过CheckCoinEnough检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id=", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			List<OneItemConfig> list = new List<OneItemConfig>();
			for (int i = 0; i < synthesisFormulaById.Value.ConsumeItemsLength; i++)
			{
				list.Add(synthesisFormulaById.Value.ConsumeItems(i).Value);
			}
			return ModelBase<InventoryModel>.Instance.CheckIsCoinEnough(ControllerBase<ComposeController>.Instance.ComposeCoinId, list);
		}

		// Token: 0x0603A2AA RID: 238250 RVA: 0x00EBA809 File Offset: 0x00EB8A09
		public bool CheckLimitCount(IBaseItemData data)
		{
			return data.TotalMakeCountInLimitTime <= 0 || data.MadeCountInLimitTime < data.TotalMakeCountInLimitTime;
		}

		// Token: 0x0603A2AB RID: 238251 RVA: 0x00EBA824 File Offset: 0x00EB8A24
		public bool CheckUnlock(IBaseItemData data)
		{
			return data.IsUnlock > 0;
		}

		// Token: 0x0603A2AC RID: 238252 RVA: 0x00EBA830 File Offset: 0x00EB8A30
		public bool CheckComposeMaterialEnough(int id)
		{
			if (this.IsInPurificationList())
			{
				return this.CheckComposeMaterialEnoughPurification(id);
			}
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(id);
			if (synthesisFormulaById == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "合成配方不存在, 跳过CheckComposeMaterialEnough检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id=", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			for (int i = 0; i < synthesisFormulaById.Value.ConsumeItemsLength; i++)
			{
				OneItemConfig value = synthesisFormulaById.Value.ConsumeItems(i).Value;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(value.ItemId, 0);
				if (value.Count > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603A2AD RID: 238253 RVA: 0x00EBA8EC File Offset: 0x00EB8AEC
		public bool CheckExchangeMaterialEnough(int id)
		{
			IExchangeData exchangeDataById = this.GetExchangeDataById(id);
			if (exchangeDataById == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "置换数据不存在, 跳过CheckExchangeMaterialEnough检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id=", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			foreach (ISingleItemInfo singleItemInfo in this.GetExchangeMaterialListByGroupId(exchangeDataById.ExchangeGroupId))
			{
				if (singleItemInfo.Proto_ItemId != id && singleItemInfo.Proto_ItemNum >= 2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A2AE RID: 238254 RVA: 0x00EBA998 File Offset: 0x00EB8B98
		public void CreateStructureDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.StructureDataList == null)
			{
				this.StructureDataList = new List<IStructureData>();
			}
			this.StructureDataList.Clear();
			IEnumerable<SynthesisFormula> enumerable = ConfigBase<ComposeConfig>.Instance.GetComposeListByType(2) ?? Array.Empty<SynthesisFormula>();
			Dictionary<int, IStructureData> dictionary = new Dictionary<int, IStructureData>();
			foreach (SynthesisFormula synthesisFormula in enumerable)
			{
				if (synthesisFormula.FormulaItemId > 0)
				{
					ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormula.ItemId);
					IStructureData structureData = new IStructureData
					{
						MainType = EComposeListType.Structure,
						SubType = ESubStructureDataType.StructureMenu,
						ConfigId = synthesisFormula.Id,
						StructureCount = 0,
						IsNew = false,
						LastRoleId = 0,
						Quality = config.Value.QualityId,
						ExistStartTime = 0.0,
						ExistEndTime = 0.0,
						MadeCountInLimitTime = 0,
						TotalMakeCountInLimitTime = 0,
						IsUnlock = 0,
						GroupId = 0,
						IsLimitForever = synthesisFormula.PermanentLimit,
						SortId = synthesisFormula.SortId
					};
					dictionary[structureData.ConfigId] = structureData;
					this.StructureDataList.Add(structureData);
				}
			}
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id);
				if (synthesisFormulaById.Value.FormulaType == 2)
				{
					ItemInfo? config2 = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormulaById.Value.ItemId);
					if (dictionary.ContainsKey(oneSynthesisInfo.Id))
					{
						IStructureData structureData2 = dictionary[oneSynthesisInfo.Id];
						structureData2.StructureCount = oneSynthesisInfo.Count;
						structureData2.IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, oneSynthesisInfo.Id);
						structureData2.LastRoleId = oneSynthesisInfo.LastRoleId;
						structureData2.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
						structureData2.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
						structureData2.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
						structureData2.TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount;
						structureData2.IsUnlock = 1;
					}
					else
					{
						IStructureData structureData2 = new IStructureData
						{
							MainType = EComposeListType.Structure,
							SubType = ESubStructureDataType.Structure,
							ConfigId = oneSynthesisInfo.Id,
							StructureCount = oneSynthesisInfo.Count,
							IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, oneSynthesisInfo.Id),
							LastRoleId = oneSynthesisInfo.LastRoleId,
							Quality = config2.Value.QualityId,
							ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond,
							ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond,
							MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount,
							TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount,
							IsUnlock = 1,
							GroupId = 0,
							IsLimitForever = synthesisFormulaById.Value.PermanentLimit,
							SortId = synthesisFormulaById.Value.SortId
						};
						this.StructureDataList.Add(structureData2);
					}
				}
			}
		}

		// Token: 0x0603A2AF RID: 238255 RVA: 0x00EBAD6C File Offset: 0x00EB8F6C
		public void UpdateStructureDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.StructureDataList == null || this.StructureDataList.Count <= 0)
			{
				return;
			}
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id);
				if (synthesisFormulaById.Value.FormulaType == 2)
				{
					bool flag = false;
					bool flag2 = false;
					foreach (IStructureData structureData in this.StructureDataList)
					{
						if (oneSynthesisInfo.Id == structureData.ConfigId)
						{
							structureData.StructureCount = oneSynthesisInfo.Count;
							structureData.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
							flag = true;
							flag2 = (structureData.IsUnlock == 0);
							structureData.IsUnlock = 1;
							break;
						}
					}
					if (flag2 || !flag)
					{
						ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, oneSynthesisInfo.Id);
						ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FormulaLearned", Array.Empty<object>());
					}
					if (!flag)
					{
						ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormulaById.Value.ItemId);
						IStructureData item = new IStructureData
						{
							MainType = EComposeListType.Structure,
							SubType = ESubStructureDataType.Structure,
							ConfigId = oneSynthesisInfo.Id,
							StructureCount = oneSynthesisInfo.Count,
							IsNew = true,
							LastRoleId = oneSynthesisInfo.LastRoleId,
							Quality = config.Value.QualityId,
							ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond,
							ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond,
							MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount,
							TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount,
							IsUnlock = 1,
							GroupId = 0,
							IsLimitForever = synthesisFormulaById.Value.PermanentLimit,
							SortId = synthesisFormulaById.Value.SortId
						};
						this.StructureDataList.Add(item);
					}
				}
			}
		}

		// Token: 0x0603A2B0 RID: 238256 RVA: 0x00EBAFD8 File Offset: 0x00EB91D8
		public void UnlockStructureData(int id)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(id);
			if (synthesisFormulaById.Value.FormulaType != 2)
			{
				return;
			}
			int num = 0;
			while (num < this.StructureDataList.Count && (this.StructureDataList[num].SubType != ESubStructureDataType.StructureMenu || this.StructureDataList[num].ConfigId != synthesisFormulaById.Value.FormulaItemId))
			{
				num++;
			}
			this.StructureDataList.RemoveAt(num);
		}

		// Token: 0x0603A2B1 RID: 238257 RVA: 0x00EBB060 File Offset: 0x00EB9260
		public void HideStructureDataList(IList<int> idList)
		{
			foreach (int num in idList)
			{
				if (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(num).Value.FormulaType == 2)
				{
					int num2 = 0;
					while (num2 < this.StructureDataList.Count && this.StructureDataList[num2].ConfigId != num)
					{
						num2++;
					}
					this.StructureDataList.RemoveAt(num2);
				}
			}
		}

		// Token: 0x0603A2B2 RID: 238258 RVA: 0x00EBB0F8 File Offset: 0x00EB92F8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IStructureData> GetStructureDataList()
		{
			return this.StructureDataList;
		}

		// Token: 0x0603A2B3 RID: 238259 RVA: 0x00EBB100 File Offset: 0x00EB9300
		[NullableContext(2)]
		public IStructureData GetStructureDataById(int id)
		{
			foreach (IStructureData structureData in this.StructureDataList)
			{
				if (id == structureData.ConfigId)
				{
					return structureData;
				}
			}
			return null;
		}

		// Token: 0x0603A2B4 RID: 238260 RVA: 0x00EBB15C File Offset: 0x00EB935C
		public int GetStructureRoleId(int itemId)
		{
			IStructureData structureDataById = this.GetStructureDataById(itemId);
			if (structureDataById != null && structureDataById.LastRoleId > 0)
			{
				return structureDataById.LastRoleId;
			}
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
		}

		// Token: 0x0603A2B5 RID: 238261 RVA: 0x00EBB18E File Offset: 0x00EB938E
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SingleItemInfo> GetCurrentComposeMaterialList()
		{
			if (this.ComposeListType == EComposeListType.Collect)
			{
				return this.CollectComposeMaterialList;
			}
			return this.PurificationComposeMaterialList;
		}

		// Token: 0x0603A2B6 RID: 238262 RVA: 0x00EBB1A6 File Offset: 0x00EB93A6
		public void SetCurrentComposeMaterialList([Nullable(new byte[]
		{
			2,
			1
		})] List<SingleItemInfo> list)
		{
			if (this.ComposeListType == EComposeListType.Collect)
			{
				this.CollectComposeMaterialList = list;
				return;
			}
			this.PurificationComposeMaterialList = list;
		}

		// Token: 0x0603A2B7 RID: 238263 RVA: 0x00EBB1C0 File Offset: 0x00EB93C0
		public void CreatePurificationDataList()
		{
			if (this.PurificationDataList == null)
			{
				this.PurificationDataList = new List<IPurificationData>();
			}
			if (this.CollectDataList == null)
			{
				this.CollectDataList = new List<ICollectData>();
			}
			foreach (SynthesisFormula synthesisFormula in ConfigBase<ComposeConfig>.Instance.GetComposeListByType(3))
			{
				ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(synthesisFormula.ItemId);
				if (synthesisFormula.IsCollect)
				{
					ICollectData item = new ICollectData
					{
						MainType = EComposeListType.Collect,
						ConfigId = synthesisFormula.Id,
						IsUnlock = 0,
						IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, synthesisFormula.Id),
						Quality = config.Value.QualityId,
						LastRoleId = 0,
						ExistStartTime = 0.0,
						ExistEndTime = 0.0,
						MadeCountInLimitTime = 0,
						TotalMakeCountInLimitTime = 0,
						IsLimitForever = synthesisFormula.PermanentLimit,
						GroupId = synthesisFormula.ItemGroup,
						SortId = synthesisFormula.SortId
					};
					this.CollectDataList.Add(item);
				}
				else
				{
					IPurificationData item2 = new IPurificationData
					{
						MainType = EComposeListType.Purification,
						ConfigId = synthesisFormula.Id,
						IsUnlock = 0,
						IsNew = ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, synthesisFormula.Id),
						Quality = config.Value.QualityId,
						LastRoleId = 0,
						ExistStartTime = 0.0,
						ExistEndTime = 0.0,
						MadeCountInLimitTime = 0,
						TotalMakeCountInLimitTime = 0,
						IsLimitForever = synthesisFormula.PermanentLimit,
						GroupId = synthesisFormula.ItemGroup,
						SortId = synthesisFormula.SortId
					};
					this.PurificationDataList.Add(item2);
				}
			}
		}

		// Token: 0x0603A2B8 RID: 238264 RVA: 0x00EBB3D4 File Offset: 0x00EB95D4
		public void UpdatePurificationDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.PurificationDataList == null || this.PurificationDataList.Count <= 0)
			{
				return;
			}
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id);
				if (synthesisFormulaById.Value.FormulaType == 3 && !synthesisFormulaById.Value.IsCollect)
				{
					foreach (IPurificationData purificationData in this.PurificationDataList)
					{
						if (oneSynthesisInfo.Id == purificationData.ConfigId)
						{
							purificationData.IsUnlock = 1;
							purificationData.LastRoleId = oneSynthesisInfo.LastRoleId;
							purificationData.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
							purificationData.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
							purificationData.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
							purificationData.TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0603A2B9 RID: 238265 RVA: 0x00EBB550 File Offset: 0x00EB9750
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IPurificationData> GetPurificationDataList()
		{
			return this.PurificationDataList;
		}

		// Token: 0x0603A2BA RID: 238266 RVA: 0x00EBB558 File Offset: 0x00EB9758
		[NullableContext(2)]
		public IPurificationData GetPurificationDataById(int id)
		{
			foreach (IPurificationData purificationData in this.PurificationDataList)
			{
				if (id == purificationData.ConfigId)
				{
					return purificationData;
				}
			}
			return null;
		}

		// Token: 0x0603A2BB RID: 238267 RVA: 0x00EBB5B4 File Offset: 0x00EB97B4
		public int GetPurificationRoleId(int itemId)
		{
			IPurificationData purificationDataById = this.GetPurificationDataById(itemId);
			if (purificationDataById != null)
			{
				int lastRoleId = purificationDataById.LastRoleId;
				if (purificationDataById.LastRoleId > 0)
				{
					return purificationDataById.LastRoleId;
				}
			}
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
		}

		// Token: 0x0603A2BC RID: 238268 RVA: 0x00EBB5ED File Offset: 0x00EB97ED
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICollectData> GetCollectDataList()
		{
			return this.CollectDataList;
		}

		// Token: 0x0603A2BD RID: 238269 RVA: 0x00EBB5F8 File Offset: 0x00EB97F8
		[NullableContext(2)]
		public ICollectData GetCollectDataById(int id)
		{
			foreach (ICollectData collectData in this.CollectDataList)
			{
				if (id == collectData.ConfigId)
				{
					return collectData;
				}
			}
			return null;
		}

		// Token: 0x0603A2BE RID: 238270 RVA: 0x00EBB654 File Offset: 0x00EB9854
		public int GetCollectRoleId(int itemId)
		{
			ICollectData collectDataById = this.GetCollectDataById(itemId);
			if (collectDataById != null)
			{
				int lastRoleId = collectDataById.LastRoleId;
				if (collectDataById.LastRoleId > 0)
				{
					return collectDataById.LastRoleId;
				}
			}
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
		}

		// Token: 0x0603A2BF RID: 238271 RVA: 0x00EBB690 File Offset: 0x00EB9890
		public void UpdateCollectDataList(IList<OneSynthesisInfo> composeDataList)
		{
			if (this.CollectDataList == null || this.CollectDataList.Count <= 0)
			{
				return;
			}
			foreach (OneSynthesisInfo oneSynthesisInfo in composeDataList)
			{
				SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(oneSynthesisInfo.Id);
				if (synthesisFormulaById.Value.FormulaType == 3 && synthesisFormulaById.Value.IsCollect)
				{
					foreach (ICollectData collectData in this.CollectDataList)
					{
						if (oneSynthesisInfo.Id == collectData.ConfigId)
						{
							collectData.IsUnlock = 1;
							collectData.LastRoleId = oneSynthesisInfo.LastRoleId;
							collectData.ExistStartTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitBeginTime) * Singleton<TimeUtil>.Instance.Millisecond;
							collectData.ExistEndTime = (double)Singleton<MathUtils>.Instance.LongToNumber(oneSynthesisInfo.LimitEndTime) * Singleton<TimeUtil>.Instance.Millisecond;
							collectData.MadeCountInLimitTime = oneSynthesisInfo.LimitSynthesisCount;
							collectData.TotalMakeCountInLimitTime = oneSynthesisInfo.LimitCount;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0603A2C0 RID: 238272 RVA: 0x00EBB80C File Offset: 0x00EB9A0C
		public bool CheckCanCollect(int id)
		{
			EBaseItemDataCheckMask checkFlags = (EBaseItemDataCheckMask)239;
			return this.CheckBaseItemData(this.GetCollectDataById(id), checkFlags);
		}

		// Token: 0x1700948B RID: 38027
		// (get) Token: 0x0603A2C1 RID: 238273 RVA: 0x00EBB82D File Offset: 0x00EB9A2D
		// (set) Token: 0x0603A2C2 RID: 238274 RVA: 0x00EBB835 File Offset: 0x00EB9A35
		public int SelectedComposeLevel
		{
			get
			{
				return this.ComposeLevel;
			}
			set
			{
				this.ComposeLevel = value;
			}
		}

		// Token: 0x0603A2C3 RID: 238275 RVA: 0x00EBB840 File Offset: 0x00EB9A40
		public void CreateComposeLevelInfo(SynthesisLevelInfo composeInfo)
		{
			this.UpdateComposeInfo(composeInfo);
			this.ComposeLevelMap = new Dictionary<int, SynthesisLevel>();
			foreach (SynthesisLevel value in ConfigBase<ComposeConfig>.Instance.GetComposeLevel())
			{
				this.ComposeLevelMap[value.Id] = value;
			}
		}

		// Token: 0x0603A2C4 RID: 238276 RVA: 0x00EBB8B0 File Offset: 0x00EB9AB0
		public void UpdateComposeInfo(SynthesisLevelInfo composeInfo)
		{
			int addExp = 0;
			if (this.ComposeLevelInfo != null)
			{
				this.LastExp = this.ComposeLevelInfo.TotalProficiency;
				addExp = composeInfo.TotalProficiency - this.ComposeLevelInfo.TotalProficiency;
			}
			this.ComposeLevelInfo = new IComposeLevelInfoData
			{
				ComposeLevel = composeInfo.Level,
				TotalProficiency = composeInfo.TotalProficiency,
				AddExp = addExp
			};
		}

		// Token: 0x0603A2C5 RID: 238277 RVA: 0x00EBB915 File Offset: 0x00EB9B15
		[NullableContext(2)]
		public IComposeLevelInfoData GetComposeInfo()
		{
			return this.ComposeLevelInfo;
		}

		// Token: 0x0603A2C6 RID: 238278 RVA: 0x00EBB91D File Offset: 0x00EB9B1D
		public void CleanAddExp()
		{
			this.ComposeLevelInfo.AddExp = 0;
		}

		// Token: 0x0603A2C7 RID: 238279 RVA: 0x00EBB92B File Offset: 0x00EB9B2B
		public SynthesisLevel? GetComposeLevelByLevel(int level)
		{
			return new SynthesisLevel?(this.ComposeLevelMap[level]);
		}

		// Token: 0x0603A2C8 RID: 238280 RVA: 0x00EBB93E File Offset: 0x00EB9B3E
		public int GetComposeMaxLevel()
		{
			return this.ComposeLevelMap.Count;
		}

		// Token: 0x0603A2C9 RID: 238281 RVA: 0x00EBB94C File Offset: 0x00EB9B4C
		public int GetSumExpByLevel(int level)
		{
			int composeMaxLevel = this.GetComposeMaxLevel();
			int num = level + 1;
			if (num > composeMaxLevel)
			{
				num = composeMaxLevel;
			}
			return this.GetComposeLevelByLevel(num).Value.Completeness;
		}

		// Token: 0x0603A2CA RID: 238282 RVA: 0x00EBB984 File Offset: 0x00EB9B84
		public int GetDropIdByLevel(int level)
		{
			int composeMaxLevel = this.GetComposeMaxLevel();
			int num = level + 1;
			if (num > composeMaxLevel)
			{
				return -1;
			}
			return this.GetComposeLevelByLevel(num).Value.DropIds;
		}

		// Token: 0x0603A2CB RID: 238283 RVA: 0x00EBB9BC File Offset: 0x00EB9BBC
		public List<ISingleItemInfo> GetComposeMaterialList(int itemId)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			if (this.IsInPurificationList())
			{
				list = this.GetComposeMaterialListPurification(itemId);
				if (list.Count > 0)
				{
					return list;
				}
			}
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(itemId);
			for (int i = 0; i < synthesisFormulaById.Value.ConsumeItemsLength; i++)
			{
				OneItemConfig value = synthesisFormulaById.Value.ConsumeItems(i).Value;
				list.Add(new ISingleItemInfo
				{
					Proto_ItemId = value.ItemId,
					Proto_ItemNum = value.Count,
					Proto_IsUnlock = true
				});
			}
			return list;
		}

		// Token: 0x0603A2CC RID: 238284 RVA: 0x00EBBA5C File Offset: 0x00EB9C5C
		public void UpdateComposeItemList(IList<SingleItemInfo> itemList)
		{
			if (this.ComposeItemList == null)
			{
				this.ComposeItemList = new List<ICommonPopItemData>();
			}
			this.ComposeItemList.Clear();
			foreach (SingleItemInfo singleItemInfo in itemList)
			{
				this.ComposeItemList.Add(new ICommonPopItemData
				{
					ItemId = singleItemInfo.ItemId,
					ItemNum = singleItemInfo.ItemNum
				});
			}
		}

		// Token: 0x0603A2CD RID: 238285 RVA: 0x00EBBAE4 File Offset: 0x00EB9CE4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonPopItemData> GetComposeItemList()
		{
			return this.ComposeItemList;
		}

		// Token: 0x0603A2CE RID: 238286 RVA: 0x00EBBAEC File Offset: 0x00EB9CEC
		public string GetComposeText(int itemId)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(itemId);
			return ConfigBase<ComposeConfig>.Instance.GetLocalText(synthesisFormulaById.Value.Name);
		}

		// Token: 0x0603A2CF RID: 238287 RVA: 0x00EBBB20 File Offset: 0x00EB9D20
		public int GetComposeId(int itemId)
		{
			return ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(itemId).Value.ItemId;
		}

		// Token: 0x1700948C RID: 38028
		// (get) Token: 0x0603A2D0 RID: 238288 RVA: 0x00EBBB48 File Offset: 0x00EB9D48
		// (set) Token: 0x0603A2D1 RID: 238289 RVA: 0x00EBBB50 File Offset: 0x00EB9D50
		public int CurrentComposeRoleId
		{
			get
			{
				return this.ComposeRoleId;
			}
			set
			{
				this.ComposeRoleId = value;
			}
		}

		// Token: 0x0603A2D2 RID: 238290 RVA: 0x00EBBB5C File Offset: 0x00EB9D5C
		public void UpdateHelpRoleItemDataList()
		{
			if (this.ComposeRoleItemDataList == null)
			{
				this.ComposeRoleItemDataList = new List<ICommonRoleItemData>();
			}
			this.ComposeRoleItemDataList.Clear();
			foreach (RoleInstance roleInstance in ModelBase<RoleModel>.Instance.GetRoleList())
			{
				this.ComposeRoleItemDataList.Add(new ICommonRoleItemData
				{
					RoleId = roleInstance.GetRoleId(),
					RoleName = roleInstance.GetRoleRealName(),
					RoleIcon = roleInstance.GetRoleConfig().RoleHeadIcon,
					IsBuff = false,
					ItemId = 0
				});
			}
		}

		// Token: 0x0603A2D3 RID: 238291 RVA: 0x00EBBBEE File Offset: 0x00EB9DEE
		public void ClearComposeRoleItemDataList()
		{
			this.ComposeRoleItemDataList = null;
		}

		// Token: 0x0603A2D4 RID: 238292 RVA: 0x00EBBBF8 File Offset: 0x00EB9DF8
		public List<ICommonRoleItemData> GetHelpRoleItemDataList(int itemId)
		{
			if (this.ComposeRoleItemDataList == null)
			{
				this.UpdateHelpRoleItemDataList();
			}
			foreach (ICommonRoleItemData commonRoleItemData in this.ComposeRoleItemDataList)
			{
				commonRoleItemData.ItemId = itemId;
				commonRoleItemData.IsBuff = ControllerBase<ComposeController>.Instance.CheckIsBuff(commonRoleItemData.RoleId, itemId);
			}
			this.ComposeRoleItemDataList.Sort(new Comparison<ICommonRoleItemData>(this.SortHelpRoleItemDataList));
			return this.ComposeRoleItemDataList;
		}

		// Token: 0x0603A2D5 RID: 238293 RVA: 0x00EBBC90 File Offset: 0x00EB9E90
		private int SortHelpRoleItemDataList(ICommonRoleItemData dataA, ICommonRoleItemData dataB)
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

		// Token: 0x0603A2D6 RID: 238294 RVA: 0x00EBBCBC File Offset: 0x00EB9EBC
		public List<IBaseItemData> GetSameGroupItem(IBaseItemData data)
		{
			List<IBaseItemData> list = new List<IBaseItemData>();
			int groupId = data.GroupId;
			EComposeListType mainType = data.MainType;
			if (mainType == EComposeListType.Purification)
			{
				using (List<IPurificationData>.Enumerator enumerator = this.PurificationDataList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IPurificationData purificationData = enumerator.Current;
						if (purificationData.GroupId == groupId)
						{
							list.Add(purificationData);
						}
					}
					goto IL_EB;
				}
			}
			if (mainType == EComposeListType.Collect)
			{
				using (List<ICollectData>.Enumerator enumerator2 = this.CollectDataList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						ICollectData collectData = enumerator2.Current;
						if (collectData.GroupId == groupId)
						{
							list.Add(collectData);
						}
					}
					goto IL_EB;
				}
			}
			if (mainType == EComposeListType.Exchange)
			{
				foreach (IExchangeData exchangeData in this.ExchangeDataList)
				{
					if (exchangeData.GroupId == groupId)
					{
						list.Add(exchangeData);
					}
				}
			}
			IL_EB:
			return (from a in list
			orderby a.Quality
			select a).ToList<IBaseItemData>();
		}

		// Token: 0x0603A2D7 RID: 238295 RVA: 0x00EBBE08 File Offset: 0x00EBA008
		public unsafe List<IComposeItemData> CalculateNeedComposeMaterialList(int configId, int count)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(configId);
			if (synthesisFormulaById == null)
			{
				return new List<IComposeItemData>();
			}
			List<IComposeItemData> list = ModelBase<ComposePopupModel>.Instance.CalcMaterialListPurification(synthesisFormulaById.Value.ItemId, count, false, null);
			if (list == null || list.Count <= 0)
			{
				OneItemConfig value = synthesisFormulaById.Value.ConsumeItems(0).Value;
				int num = 1;
				List<IComposeItemData> list2 = new List<IComposeItemData>(num);
				CollectionsMarshal.SetCount<IComposeItemData>(list2, num);
				Span<IComposeItemData> span = CollectionsMarshal.AsSpan<IComposeItemData>(list2);
				int index = 0;
				*span[index] = new IComposeItemData
				{
					ItemId = value.ItemId,
					RequiredNum = value.Count
				};
				return list2;
			}
			return list;
		}

		// Token: 0x0603A2D8 RID: 238296 RVA: 0x00EBBEBC File Offset: 0x00EBA0BC
		[NullableContext(2)]
		public int GetMaxCreateCountPurification(int configId, IBaseItemData itemData = null)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(configId);
			if (synthesisFormulaById == null)
			{
				return 0;
			}
			int maxCreateCountPurification = ModelBase<ComposePopupModel>.Instance.GetMaxCreateCountPurification(synthesisFormulaById.Value.ItemId, false, null);
			if (itemData == null)
			{
				return maxCreateCountPurification;
			}
			if (itemData.TotalMakeCountInLimitTime <= 0)
			{
				return maxCreateCountPurification;
			}
			int val = itemData.TotalMakeCountInLimitTime - itemData.MadeCountInLimitTime;
			return Math.Min(maxCreateCountPurification, val);
		}

		// Token: 0x0603A2D9 RID: 238297 RVA: 0x00EBBF24 File Offset: 0x00EBA124
		private List<ISingleItemInfo> GetComposeMaterialListPurification(int formulaId)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(formulaId);
			if (synthesisFormulaById == null)
			{
				return new List<ISingleItemInfo>();
			}
			return (from material in ModelBase<ComposePopupModel>.Instance.GetComposeMaterialListPurification(synthesisFormulaById.Value.ItemId) ?? new List<IComposeItemData>()
			select new ISingleItemInfo
			{
				Proto_ItemId = material.ItemId,
				Proto_ItemNum = material.RequiredNum,
				Proto_IsUnlock = true
			}).ToList<ISingleItemInfo>();
		}

		// Token: 0x0603A2DA RID: 238298 RVA: 0x00EBBF98 File Offset: 0x00EBA198
		private bool CheckComposeMaterialEnoughPurification(int id)
		{
			if (ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(id) == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "合成配方不存在, 跳过CheckComposeMaterialEnough检查";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id=", id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			return this.GetMaxCreateCountPurification(id, null) > 0;
		}

		// Token: 0x04020FB5 RID: 135093
		public Dictionary<int, List<int>> ExchangeItemBaseMap = new Dictionary<int, List<int>>();

		// Token: 0x04020FB6 RID: 135094
		private double LimitRefreshTime = -1.0;

		// Token: 0x04020FB7 RID: 135095
		public long? CurrentInteractCreatureDataLongId;

		// Token: 0x04020FB8 RID: 135096
		private EComposeViewType ComposeViewType;

		// Token: 0x04020FB9 RID: 135097
		public int LastExp;

		// Token: 0x04020FBA RID: 135098
		[Nullable(2)]
		public PlayFlow ComposeEnterFlow;

		// Token: 0x04020FBB RID: 135099
		[Nullable(2)]
		public PlayFlow ComposeSuccessFlow;

		// Token: 0x04020FBC RID: 135100
		[Nullable(2)]
		public PlayFlow ComposeFailFlow;

		// Token: 0x04020FBD RID: 135101
		private EComposeListType ComposeListType = EComposeListType.Purification;

		// Token: 0x04020FBE RID: 135102
		private List<IReagentProductionData> ReagentProductionDataList = new List<IReagentProductionData>();

		// Token: 0x04020FBF RID: 135103
		private List<IExchangeData> ExchangeDataList = new List<IExchangeData>();

		// Token: 0x04020FC0 RID: 135104
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IStructureData> StructureDataList;

		// Token: 0x04020FC1 RID: 135105
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IPurificationData> PurificationDataList;

		// Token: 0x04020FC2 RID: 135106
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SingleItemInfo> PurificationComposeMaterialList;

		// Token: 0x04020FC3 RID: 135107
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICollectData> CollectDataList;

		// Token: 0x04020FC4 RID: 135108
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<SingleItemInfo> CollectComposeMaterialList;

		// Token: 0x04020FC5 RID: 135109
		private int ComposeLevel;

		// Token: 0x04020FC6 RID: 135110
		[Nullable(2)]
		private Dictionary<int, SynthesisLevel> ComposeLevelMap;

		// Token: 0x04020FC7 RID: 135111
		[Nullable(2)]
		private IComposeLevelInfoData ComposeLevelInfo;

		// Token: 0x04020FC8 RID: 135112
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonPopItemData> ComposeItemList;

		// Token: 0x04020FC9 RID: 135113
		private int ComposeRoleId;

		// Token: 0x04020FCA RID: 135114
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonRoleItemData> ComposeRoleItemDataList;

		// Token: 0x04020FCB RID: 135115
		[Nullable(2)]
		public ISelectedData ComposeSelectItem;

		// Token: 0x04020FCC RID: 135116
		public EUiViewName? ComposeSkipSourceView;
	}
}
