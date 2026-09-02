using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FCC RID: 20428
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SheriffModel : ModelBase<SheriffModel>
	{
		// Token: 0x06034ADA RID: 215770 RVA: 0x00D3533C File Offset: 0x00D3353C
		public SheriffActivityData GetActivityData()
		{
			return ControllerBase<SheriffController>.Instance.GetActivityData();
		}

		// Token: 0x06034ADB RID: 215771 RVA: 0x00D35348 File Offset: 0x00D33548
		public List<int> GetClueListByAnomalyId(int anomalyId)
		{
			if (this.ClueListMap.Count == 0)
			{
				foreach (SheriffClue sheriffClue in ConfigBase<SheriffConfig>.Instance.GetAllClueConfig())
				{
					if (!this.ClueListMap.ContainsKey(sheriffClue.SheriffAnomalyId))
					{
						this.ClueListMap[sheriffClue.SheriffAnomalyId] = new List<int>();
					}
					this.ClueListMap[sheriffClue.SheriffAnomalyId].Add(sheriffClue.Id);
				}
			}
			List<int> result;
			if (this.ClueListMap.TryGetValue(anomalyId, out result))
			{
				return result;
			}
			return new List<int>();
		}

		// Token: 0x06034ADC RID: 215772 RVA: 0x00D35400 File Offset: 0x00D33600
		public int GetAnomalyProgressPercent(int anomalyId)
		{
			SheriffAnomalyInfo anomalyInfo = this.GetAnomalyInfo(anomalyId);
			if (anomalyInfo == null)
			{
				return 0;
			}
			return anomalyInfo.Progress;
		}

		// Token: 0x06034ADD RID: 215773 RVA: 0x00D35414 File Offset: 0x00D33614
		public bool CheckGameplayActivated(int anomalyId)
		{
			SheriffAnomalyInfo anomalyInfo = this.GetAnomalyInfo(anomalyId);
			return anomalyInfo != null && anomalyInfo.State > ESheriffAnomalyState.UnActivated;
		}

		// Token: 0x06034ADE RID: 215774 RVA: 0x00D35438 File Offset: 0x00D33638
		public bool CheckInBehaviorTreeRange(int anomalyId)
		{
			SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId).Value;
			return ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, value.MainBTId) != null;
		}

		// Token: 0x06034ADF RID: 215775 RVA: 0x00D35470 File Offset: 0x00D33670
		public bool IsBehaviorTreeTracking(int anomalyId)
		{
			SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId).Value;
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, value.MainBTId);
			return behaviorTreeByConfigId != null && behaviorTreeByConfigId.IsTracking();
		}

		// Token: 0x06034AE0 RID: 215776 RVA: 0x00D354B0 File Offset: 0x00D336B0
		public string GetCurrentBehaviorTreeNodeText(int anomalyId)
		{
			SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId).Value;
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, value.MainBTId);
			if (behaviorTreeByConfigId == null)
			{
				return "";
			}
			string result = "";
			foreach (BehaviorNodeBase behaviorNodeBase in behaviorTreeByConfigId.GetCurrentActiveChildQuestNodes())
			{
				if (!StringUtils.IsBlank(behaviorNodeBase.MultiTrackText) && behaviorNodeBase.TrackTextConfig != null)
				{
					result = behaviorNodeBase.TrackTextConfig;
				}
			}
			return result;
		}

		// Token: 0x06034AE1 RID: 215777 RVA: 0x00D35554 File Offset: 0x00D33754
		public bool CheckInReasoningNode(int anomalyId)
		{
			SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId).Value;
			BaseBehaviorTree behaviorTreeByConfigId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeByConfigId(BtType.LevelPlay, value.MainBTId);
			if (behaviorTreeByConfigId == null)
			{
				return false;
			}
			string btparamName = value.BTParamName;
			VarDefinePb treeVarByKey = behaviorTreeByConfigId.GetTreeVarByKey(btparamName);
			return treeVarByKey != null && treeVarByKey != null && treeVarByKey.Boolean;
		}

		// Token: 0x17008A98 RID: 35480
		// (get) Token: 0x06034AE2 RID: 215778 RVA: 0x00D355AE File Offset: 0x00D337AE
		public PayShopDefine.EPayShopTabType ShopId
		{
			get
			{
				return PayShopDefine.EPayShopTabType.SheriffShop;
			}
		}

		// Token: 0x06034AE3 RID: 215779 RVA: 0x00D355B5 File Offset: 0x00D337B5
		public List<PayShopGoods> GetShopDataList(int level)
		{
			return ModelBase<PayShopModel>.Instance.GetPayShopTabData(this.ShopId, level, true);
		}

		// Token: 0x06034AE4 RID: 215780 RVA: 0x00D355CC File Offset: 0x00D337CC
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Spent",
			"AllNum",
			"Held"
		})]
		public ValueTuple<int, int, int> GetShopGoodsPriceInfo()
		{
			List<int> payShopInfoMoney = ModelBase<PayShopModel>.Instance.GetPayShopInfoMoney(this.ShopId);
			int num = (payShopInfoMoney.Count > 0) ? payShopInfoMoney[0] : 0;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
			int num2 = 0;
			int num3 = 0;
			foreach (int tabId in ModelBase<PayShopModel>.Instance.GetPayShopTabIdList(this.ShopId, false))
			{
				foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData(this.ShopId, tabId, false))
				{
					IPriceData priceData = payShopGoods.GetPriceData();
					if (priceData.CurrencyId == num)
					{
						PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
						num3 += priceData.NowPrice * goodsData.BuyLimit;
						num2 += priceData.NowPrice * goodsData.BoughtCount;
					}
				}
			}
			return new ValueTuple<int, int, int>(num2, num3, itemCountByConfigId);
		}

		// Token: 0x06034AE5 RID: 215781 RVA: 0x00D356F8 File Offset: 0x00D338F8
		public int GetShopItemCount()
		{
			int num = 0;
			foreach (int num2 in this.ZoneItemCountMap.Values)
			{
				num += num2;
			}
			return num;
		}

		// Token: 0x06034AE6 RID: 215782 RVA: 0x00D35750 File Offset: 0x00D33950
		public int GetShopCurrencyId()
		{
			List<int> payShopInfoMoney = ModelBase<PayShopModel>.Instance.GetPayShopInfoMoney(this.ShopId);
			if (payShopInfoMoney.Count <= 0)
			{
				return 0;
			}
			return payShopInfoMoney[0];
		}

		// Token: 0x06034AE7 RID: 215783 RVA: 0x00D35780 File Offset: 0x00D33980
		private bool HasShopAffordableGoods()
		{
			int shopCurrencyId = this.GetShopCurrencyId();
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(shopCurrencyId, 0);
			foreach (int tabId in ModelBase<PayShopModel>.Instance.GetPayShopTabIdList(this.ShopId, false))
			{
				foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData(this.ShopId, tabId, false))
				{
					if (!payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && !payShopGoods.IsSoldOut() && payShopGoods.CheckGoodIfShow())
					{
						IPriceData priceData = payShopGoods.GetPriceData();
						if (priceData.CurrencyId == shopCurrencyId && itemCountByConfigId >= priceData.NowPrice)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06034AE8 RID: 215784 RVA: 0x00D35884 File Offset: 0x00D33A84
		public bool CheckShopRedDot()
		{
			return !this.ShopRedDotChecked && this.HasShopAffordableGoods();
		}

		// Token: 0x06034AE9 RID: 215785 RVA: 0x00D35896 File Offset: 0x00D33A96
		public void ReArmShopRedDot()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SheriffShopView))
			{
				return;
			}
			this.ShopRedDotChecked = false;
			this.EmitShopRedDotRefresh();
		}

		// Token: 0x06034AEA RID: 215786 RVA: 0x00D358B7 File Offset: 0x00D33AB7
		public void ClearShopRedDot()
		{
			this.ShopRedDotChecked = true;
			this.EmitShopRedDotRefresh();
		}

		// Token: 0x06034AEB RID: 215787 RVA: 0x00D358C8 File Offset: 0x00D33AC8
		private void EmitShopRedDotRefresh()
		{
			int activityId = ControllerBase<SheriffController>.Instance.ActivityId;
			if (activityId > 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSheriffShopRedDotRefresh);
		}

		// Token: 0x06034AEC RID: 215788 RVA: 0x00D35908 File Offset: 0x00D33B08
		public void UpdateZoneInfo(List<SheriffZoneInfo> info)
		{
			foreach (SheriffZoneInfo sheriffZoneInfo in info)
			{
				this.UpdateAnomalyInfo(sheriffZoneInfo.AnomalyInfos.ToList<SheriffAnomalyInfo>(), new int?(sheriffZoneInfo.ZoneId));
				this.UpdateCriminalInfo(sheriffZoneInfo.CriminalInfos.ToList<SheriffCriminalInfo>(), new int?(sheriffZoneInfo.ZoneId));
				this.ZoneItemCountMap[sheriffZoneInfo.ZoneId] = (int)sheriffZoneInfo.ItemCount;
			}
		}

		// Token: 0x06034AED RID: 215789 RVA: 0x00D359A0 File Offset: 0x00D33BA0
		public void UpdateZoneItemCount(int zoneId, int itemCount)
		{
			this.ZoneItemCountMap[zoneId] = itemCount;
		}

		// Token: 0x06034AEE RID: 215790 RVA: 0x00D359B0 File Offset: 0x00D33BB0
		public void UpdateAnomalyInfo(List<SheriffAnomalyInfo> info, int? zoneId = null)
		{
			int num = info.Count - 1;
			for (int i = 0; i < info.Count; i++)
			{
				SheriffAnomalyInfo sheriffAnomalyInfo = info[i];
				if (!this.AnomalyInfoMap.ContainsKey(sheriffAnomalyInfo.AnomalyId))
				{
					this.AnomalyInfoMap[sheriffAnomalyInfo.AnomalyId] = new SheriffAnomalyInfo();
				}
				SheriffAnomalyInfo sheriffAnomalyInfo2 = this.AnomalyInfoMap[sheriffAnomalyInfo.AnomalyId];
				if (i == num)
				{
					List<int> clueIds = sheriffAnomalyInfo2.ClueIds;
					this.LastCacheAnomaly = sheriffAnomalyInfo.AnomalyId;
					List<int> list = (sheriffAnomalyInfo.ClueIds != null) ? new List<int>(sheriffAnomalyInfo.ClueIds) : new List<int>();
					int lastCacheClue = 0;
					foreach (int num2 in list)
					{
						if (!clueIds.Contains(num2))
						{
							lastCacheClue = num2;
							break;
						}
					}
					this.LastCacheClue = lastCacheClue;
				}
				sheriffAnomalyInfo2.UpdateByProto(sheriffAnomalyInfo, zoneId);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Sheriff;
			ELogAuthor author = ELogAuthor.WHJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 2);
			defaultInterpolatedStringHandler.AppendLiteral("UpdateAnomalyInfo LastCacheAnomaly=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastCacheAnomaly);
			defaultInterpolatedStringHandler.AppendLiteral(" LastCacheClue=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastCacheClue);
			instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06034AEF RID: 215791 RVA: 0x00D35B10 File Offset: 0x00D33D10
		public void UpdateCriminalInfo(List<SheriffCriminalInfo> info, int? zoneId = null)
		{
			foreach (SheriffCriminalInfo sheriffCriminalInfo in info)
			{
				if (!this.CriminalInfoMap.ContainsKey(sheriffCriminalInfo.CriminalId))
				{
					this.CriminalInfoMap[sheriffCriminalInfo.CriminalId] = new SheriffCriminalInfo();
				}
				SheriffCriminalInfo sheriffCriminalInfo2 = this.CriminalInfoMap[sheriffCriminalInfo.CriminalId];
				sheriffCriminalInfo2.UpdateByProto(sheriffCriminalInfo, zoneId);
				SheriffAnomalyInfo sheriffAnomalyInfo;
				if (this.AnomalyInfoMap.TryGetValue(sheriffCriminalInfo2.AnomalyId, out sheriffAnomalyInfo))
				{
					sheriffAnomalyInfo.CalAnomalyState();
				}
			}
		}

		// Token: 0x06034AF0 RID: 215792 RVA: 0x00D35BB8 File Offset: 0x00D33DB8
		[NullableContext(2)]
		public SheriffAnomalyInfo GetAnomalyInfo(int anomalyId)
		{
			SheriffAnomalyInfo result;
			this.AnomalyInfoMap.TryGetValue(anomalyId, out result);
			return result;
		}

		// Token: 0x06034AF1 RID: 215793 RVA: 0x00D35BD8 File Offset: 0x00D33DD8
		[NullableContext(2)]
		public SheriffCriminalInfo GetCriminalInfo(int criminalId)
		{
			SheriffCriminalInfo result;
			this.CriminalInfoMap.TryGetValue(criminalId, out result);
			return result;
		}

		// Token: 0x06034AF2 RID: 215794 RVA: 0x00D35BF8 File Offset: 0x00D33DF8
		public void CheckNeedOpenReportPop()
		{
			foreach (KeyValuePair<int, SheriffAnomalyInfo> keyValuePair in this.AnomalyInfoMap)
			{
				int num;
				SheriffAnomalyInfo sheriffAnomalyInfo;
				keyValuePair.Deconstruct(out num, out sheriffAnomalyInfo);
				SheriffAnomalyInfo sheriffAnomalyInfo2 = sheriffAnomalyInfo;
				if (sheriffAnomalyInfo2.NeedOpenReport)
				{
					sheriffAnomalyInfo2.NeedOpenReport = false;
					ControllerBase<SheriffController>.Instance.OpenSheriffReportPop(sheriffAnomalyInfo2.CriminalId, false);
					break;
				}
			}
		}

		// Token: 0x06034AF3 RID: 215795 RVA: 0x00D35C74 File Offset: 0x00D33E74
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"ArrestedCount",
			"TotalCount"
		})]
		public ValueTuple<int, int> GetCriminalProgress()
		{
			int num = 0;
			int num2 = 0;
			foreach (SheriffCriminalInfo sheriffCriminalInfo in this.CriminalInfoMap.Values)
			{
				SheriffAnomalyInfo anomalyInfo = this.GetAnomalyInfo(sheriffCriminalInfo.AnomalyId);
				if (anomalyInfo != null && anomalyInfo.MarkId != 0)
				{
					num2++;
					if (sheriffCriminalInfo.State == ESheriffCriminalState.Arrested)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x06034AF4 RID: 215796 RVA: 0x00D35CFC File Offset: 0x00D33EFC
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"CompletedCount",
			"TotalCount"
		})]
		public ValueTuple<int, int> GetAnomalyProgress()
		{
			int num = 0;
			int num2 = 0;
			foreach (SheriffAnomalyInfo sheriffAnomalyInfo in this.AnomalyInfoMap.Values)
			{
				if (sheriffAnomalyInfo.MarkId != 0)
				{
					num2++;
					if (sheriffAnomalyInfo.State == ESheriffAnomalyState.Completed)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x06034AF5 RID: 215797 RVA: 0x00D35D74 File Offset: 0x00D33F74
		public List<SheriffCriminalInfo> GetCriminalList(int zoneId)
		{
			return this.CriminalInfoMap.Values.Where(delegate(SheriffCriminalInfo item)
			{
				if (item.ZoneId == zoneId)
				{
					SheriffAnomalyInfo anomalyInfo = this.GetAnomalyInfo(item.AnomalyId);
					return anomalyInfo == null || anomalyInfo.MarkId != 0;
				}
				return false;
			}).ToList<SheriffCriminalInfo>();
		}

		// Token: 0x06034AF6 RID: 215798 RVA: 0x00D35DB8 File Offset: 0x00D33FB8
		public SheriffQuestState GetQuestState(int zoneId, ESheriffQuestType questType)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			IReadOnlyList<SheriffQuest> questConfigByZoneId = ConfigBase<SheriffConfig>.Instance.GetQuestConfigByZoneId(zoneId);
			if (questConfigByZoneId != null)
			{
				foreach (SheriffQuest sheriffQuest in questConfigByZoneId)
				{
					if (sheriffQuest.QuestType == (int)questType)
					{
						list2.Add(sheriffQuest.QuestId);
						if (!ModelBase<QuestNewModel>.Instance.CheckQuestFinished(sheriffQuest.QuestId))
						{
							list.Add(sheriffQuest.QuestId);
						}
					}
				}
			}
			return new SheriffQuestState
			{
				UnFinishList = list,
				TotalList = list2
			};
		}

		// Token: 0x06034AF7 RID: 215799 RVA: 0x00D35E60 File Offset: 0x00D34060
		public int GetTodoCount()
		{
			int num = 0;
			foreach (SheriffAnomalyInfo sheriffAnomalyInfo in this.AnomalyInfoMap.Values)
			{
				if (sheriffAnomalyInfo.MarkId != 0 && sheriffAnomalyInfo.State != ESheriffAnomalyState.Completed && sheriffAnomalyInfo.State != ESheriffAnomalyState.Lock)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06034AF8 RID: 215800 RVA: 0x00D35ED4 File Offset: 0x00D340D4
		public int GetTargetAnomalyMarkId()
		{
			foreach (SheriffAnomalyInfo sheriffAnomalyInfo in this.AnomalyInfoMap.Values)
			{
				if (!this.CheckInBehaviorTreeRange(sheriffAnomalyInfo.AnomalyId))
				{
					MapModel instance = ModelBase<MapModel>.Instance;
					if (instance == null || !instance.IsMarkTracking(sheriffAnomalyInfo.MarkId))
					{
						continue;
					}
				}
				return sheriffAnomalyInfo.MarkId;
			}
			int num = 0;
			foreach (SheriffAnomalyInfo sheriffAnomalyInfo2 in this.AnomalyInfoMap.Values)
			{
				if (sheriffAnomalyInfo2.MarkId != 0)
				{
					if (num == 0)
					{
						num = sheriffAnomalyInfo2.MarkId;
					}
					if (sheriffAnomalyInfo2.State != ESheriffAnomalyState.Completed && sheriffAnomalyInfo2.State != ESheriffAnomalyState.Lock)
					{
						return sheriffAnomalyInfo2.MarkId;
					}
				}
			}
			return num;
		}

		// Token: 0x06034AF9 RID: 215801 RVA: 0x00D35FD0 File Offset: 0x00D341D0
		public int GetAnomalyCurrentPercent(int anomalyId)
		{
			SheriffAnomalyInfo anomalyInfo = this.GetAnomalyInfo(anomalyId);
			if (anomalyInfo == null)
			{
				return 0;
			}
			return anomalyInfo.Progress;
		}

		// Token: 0x06034AFA RID: 215802 RVA: 0x00D35FF0 File Offset: 0x00D341F0
		public int GetTargetMapMarkIdByQuestIds(List<int> questIds)
		{
			int num = 0;
			if (questIds.Count == 0)
			{
				return num;
			}
			int num2 = 1000;
			global::Vector playerPosition = ModelBase<WorldMapModel>.Instance.GetPlayerPosition();
			playerPosition.DivisionEqual((double)num2);
			double num3 = double.MaxValue;
			foreach (int questId in questIds)
			{
				SheriffQuest? questConfigByQuestId = ConfigBase<SheriffConfig>.Instance.GetQuestConfigByQuestId(questId);
				MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(questConfigByQuestId.Value.MarkId);
				if (ModelBase<QuestNewModel>.Instance.IsTrackingQuest(questId))
				{
					num = configMark.Value.MarkId;
					break;
				}
				QuestMarkCreateInfo markByQuestId = ModelBase<MapModel>.Instance.GetMarkByQuestId(questId);
				if (markByQuestId != null && markByQuestId.MarkId != null)
				{
					TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
					int? num4 = (curTrackMark != null) ? new int?(curTrackMark.MarkId) : null;
					int? markId = markByQuestId.MarkId;
					if (num4.GetValueOrDefault() == markId.GetValueOrDefault() & num4 != null == (markId != null))
					{
						num = configMark.Value.MarkId;
						break;
					}
				}
				global::Vector entityPosition = ModelBase<WorldMapModel>.Instance.GetEntityPosition(configMark.Value.EntityConfigId, configMark.Value.MapId);
				entityPosition.DivisionEqual((double)(num2 * 100));
				double num5 = global::Vector.DistSquared(playerPosition, entityPosition);
				if (num5 < num3)
				{
					num3 = num5;
					num = configMark.Value.MarkId;
				}
			}
			if (num == 0)
			{
				return ConfigBase<SheriffConfig>.Instance.GetQuestConfigByQuestId(questIds[0]).Value.MarkId;
			}
			return num;
		}

		// Token: 0x06034AFB RID: 215803 RVA: 0x00D361D8 File Offset: 0x00D343D8
		public bool IsShortcutShowMainBoard(BaseBehaviorTree tree)
		{
			ITrackCustomBoard currentNodeCustomTrackBoard = tree.GetCurrentNodeCustomTrackBoard();
			if (((currentNodeCustomTrackBoard != null) ? currentNodeCustomTrackBoard.SheriffMainBoard : null) != null)
			{
				return true;
			}
			foreach (BehaviorNodeBase behaviorNodeBase in tree.GetCurrentActiveLogicNodes())
			{
				LogicNodeBase logicNodeBase = behaviorNodeBase as LogicNodeBase;
				if (logicNodeBase != null)
				{
					ITrackCustomBoardOnBtLogicNode trackCustomBoard = logicNodeBase.TrackCustomBoard;
					if (((trackCustomBoard != null) ? trackCustomBoard.SheriffMainBoard : null) != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0401E5EE RID: 124398
		protected Dictionary<int, List<int>> ClueListMap = new Dictionary<int, List<int>>();

		// Token: 0x0401E5EF RID: 124399
		protected Dictionary<int, SheriffAnomalyInfo> AnomalyInfoMap = new Dictionary<int, SheriffAnomalyInfo>();

		// Token: 0x0401E5F0 RID: 124400
		protected Dictionary<int, SheriffCriminalInfo> CriminalInfoMap = new Dictionary<int, SheriffCriminalInfo>();

		// Token: 0x0401E5F1 RID: 124401
		protected Dictionary<int, int> ZoneItemCountMap = new Dictionary<int, int>();

		// Token: 0x0401E5F2 RID: 124402
		public Dictionary<int, ESheriffAnomalyState> GmAnomalyStateMap = new Dictionary<int, ESheriffAnomalyState>();

		// Token: 0x0401E5F3 RID: 124403
		public int LastCacheAnomaly;

		// Token: 0x0401E5F4 RID: 124404
		public int LastCacheClue;

		// Token: 0x0401E5F5 RID: 124405
		private bool ShopRedDotChecked = true;
	}
}
