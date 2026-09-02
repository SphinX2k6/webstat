using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C4D RID: 23629
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class InfrastructureModel : ModelBase<InfrastructureModel>
	{
		// Token: 0x170097D8 RID: 38872
		// (get) Token: 0x0603BAF4 RID: 244468 RVA: 0x00F1E66D File Offset: 0x00F1C86D
		public int TracedRoadId
		{
			get
			{
				return this.TracedRoadIdInner;
			}
		}

		// Token: 0x170097D9 RID: 38873
		// (get) Token: 0x0603BAF5 RID: 244469 RVA: 0x00F1E675 File Offset: 0x00F1C875
		public int RecommendRoadId
		{
			get
			{
				return this.RecommendRoadIdInner;
			}
		}

		// Token: 0x170097DA RID: 38874
		// (get) Token: 0x0603BAF6 RID: 244470 RVA: 0x00F1E67D File Offset: 0x00F1C87D
		public long FireExp
		{
			get
			{
				return this.FireExpInner;
			}
		}

		// Token: 0x170097DB RID: 38875
		// (get) Token: 0x0603BAF7 RID: 244471 RVA: 0x00F1E685 File Offset: 0x00F1C885
		public int FireLevel
		{
			get
			{
				if (this.FireLevelInner <= 0)
				{
					return 1;
				}
				return this.FireLevelInner;
			}
		}

		// Token: 0x170097DC RID: 38876
		// (get) Token: 0x0603BAF8 RID: 244472 RVA: 0x00F1E698 File Offset: 0x00F1C898
		public long FireLevelReachTime
		{
			get
			{
				return this.FireLevelReachTimeInner;
			}
		}

		// Token: 0x170097DD RID: 38877
		// (get) Token: 0x0603BAF9 RID: 244473 RVA: 0x00F1E6A0 File Offset: 0x00F1C8A0
		public InfrStatusPb FireStatus
		{
			get
			{
				return this.FireStatusInner;
			}
		}

		// Token: 0x170097DE RID: 38878
		// (get) Token: 0x0603BAFA RID: 244474 RVA: 0x00F1E6A8 File Offset: 0x00F1C8A8
		public long MoneyCount
		{
			get
			{
				return this.MoneyCountInner;
			}
		}

		// Token: 0x170097DF RID: 38879
		// (get) Token: 0x0603BAFB RID: 244475 RVA: 0x00F1E6B0 File Offset: 0x00F1C8B0
		public long MoneyHistorySpent
		{
			get
			{
				return this.MoneyHistorySpentInner;
			}
		}

		// Token: 0x170097E0 RID: 38880
		// (get) Token: 0x0603BAFC RID: 244476 RVA: 0x00F1E6B8 File Offset: 0x00F1C8B8
		public bool NeedHighlightTrackedRoad
		{
			get
			{
				return this.NeedHighlightTrackedRoadInner;
			}
		}

		// Token: 0x0603BAFD RID: 244477 RVA: 0x00F1E6C0 File Offset: 0x00F1C8C0
		public void SetNeedHighlightTrackedRoad(bool value)
		{
			this.NeedHighlightTrackedRoadInner = value;
		}

		// Token: 0x0603BAFE RID: 244478 RVA: 0x00F1E6C9 File Offset: 0x00F1C8C9
		public int GetInfrRecordObservatoryLevel()
		{
			return LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.InfrRecordObservatoryLevel, 1);
		}

		// Token: 0x0603BAFF RID: 244479 RVA: 0x00F1E6D8 File Offset: 0x00F1C8D8
		public bool GetShopHasNewRedDot()
		{
			int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.InfrRecordObservatoryLevel, 1);
			return this.FireLevel > player;
		}

		// Token: 0x0603BB00 RID: 244480 RVA: 0x00F1E6FC File Offset: 0x00F1C8FC
		public void RefreshShopHasNewRedDot()
		{
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.InfrRecordObservatoryLevel, this.FireLevel);
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureShopRedDotUpdate);
			if (this.ActivityData != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityData.Id);
			}
		}

		// Token: 0x0603BB01 RID: 244481 RVA: 0x00F1E750 File Offset: 0x00F1C950
		public bool GetLibraryTaskRedDot()
		{
			using (Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData>.ValueCollection.Enumerator enumerator = this.LibraryTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == InfrTaskStatusPb.InfrTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603BB02 RID: 244482 RVA: 0x00F1E7B0 File Offset: 0x00F1C9B0
		public bool GetPhoneTaskRedDot()
		{
			using (Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData>.ValueCollection.Enumerator enumerator = this.PhoneTaskDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == InfrTaskStatusPb.InfrTaskFinish)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603BB03 RID: 244483 RVA: 0x00F1E810 File Offset: 0x00F1CA10
		public List<int> GetUnreadArchives()
		{
			return this.UnreadArchives;
		}

		// Token: 0x0603BB04 RID: 244484 RVA: 0x00F1E818 File Offset: 0x00F1CA18
		public void SetArchiveRead(int[] archiveIds)
		{
			this.UnreadArchives = (from id in this.UnreadArchives
			where !archiveIds.Contains(id)
			select id).ToList<int>();
		}

		// Token: 0x0603BB05 RID: 244485 RVA: 0x00F1E854 File Offset: 0x00F1CA54
		public bool GetArchiveIsUnRead(int archiveId)
		{
			return this.UnreadArchives.Contains(archiveId);
		}

		// Token: 0x170097E1 RID: 38881
		// (get) Token: 0x0603BB06 RID: 244486 RVA: 0x00F1E862 File Offset: 0x00F1CA62
		public int InteractingRoadId
		{
			get
			{
				return this.InteractingRoadIdInner;
			}
		}

		// Token: 0x0603BB07 RID: 244487 RVA: 0x00F1E86A File Offset: 0x00F1CA6A
		public void SetInteractingRoadId(int roadId)
		{
			this.InteractingRoadIdInner = roadId;
		}

		// Token: 0x0603BB08 RID: 244488 RVA: 0x00F1E873 File Offset: 0x00F1CA73
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603BB09 RID: 244489 RVA: 0x00F1E876 File Offset: 0x00F1CA76
		public void SetInfrastructureData(InfrPb data)
		{
			this.SetRoadData(data.RoadInfo);
			this.SetFireData(data.FireInfo);
			this.SetLibraryData(data.LibraryInfo);
		}

		// Token: 0x0603BB0A RID: 244490 RVA: 0x00F1E89C File Offset: 0x00F1CA9C
		[NullableContext(2)]
		public InfrastructureDefine.IInfrRoadData GetRoadDataByRoadId(int roadId)
		{
			InfrastructureDefine.IInfrRoadData result;
			this.RoadDataMap.TryGetValue(roadId, out result);
			return result;
		}

		// Token: 0x0603BB0B RID: 244491 RVA: 0x00F1E8BC File Offset: 0x00F1CABC
		public void SetRoadData(InfrRoadPb data)
		{
			this.RoadDataMap.Clear();
			foreach (InfrOneRoad infrOneRoad in data.Roads)
			{
				this.RoadDataMap[infrOneRoad.RoadId] = new InfrastructureDefine.InfrRoadData
				{
					RoadId = infrOneRoad.RoadId,
					Status = infrOneRoad.Status,
					CompleteTime = (int)Singleton<MathUtils>.Instance.LongToBigInt(infrOneRoad.CompleteTime),
					TotalGiftCount = (int)Singleton<MathUtils>.Instance.LongToBigInt(infrOneRoad.TotalGiftCount),
					LastGiftTime = (int)Singleton<MathUtils>.Instance.LongToBigInt(infrOneRoad.LastGiftTime)
				};
			}
			this.TracedRoadIdInner = data.ManualTraceRoad;
			this.RecommendRoadIdInner = data.RecommendRoad;
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureRoadDataUpdate);
		}

		// Token: 0x0603BB0C RID: 244492 RVA: 0x00F1E9AC File Offset: 0x00F1CBAC
		public void ChangeTraceRoad(int roadId)
		{
			this.TracedRoadIdInner = roadId;
		}

		// Token: 0x0603BB0D RID: 244493 RVA: 0x00F1E9B8 File Offset: 0x00F1CBB8
		public List<int> GetHasUnlockRoadAndNotPlaySeqMark()
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.InfrRoadMarkUnlockRecord, null) ?? new HashSet<int>();
			List<int> list = new List<int>();
			foreach (InfrastructureDefine.IInfrRoadData infrRoadData in this.RoadDataMap.Values)
			{
				if (infrRoadData.Status == InfrStatusPb.InfrStatusProgress && !hashSet.Contains(infrRoadData.RoadId))
				{
					list.Add(infrRoadData.RoadId);
				}
			}
			return list;
		}

		// Token: 0x0603BB0E RID: 244494 RVA: 0x00F1EA48 File Offset: 0x00F1CC48
		public void SetUnlockRoadMarkPlaySeq(int roadId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.InfrRoadMarkUnlockRecord, null) ?? new HashSet<int>();
			hashSet.Add(roadId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.InfrRoadMarkUnlockRecord, hashSet);
		}

		// Token: 0x0603BB0F RID: 244495 RVA: 0x00F1EA80 File Offset: 0x00F1CC80
		public bool GetRoadMaterialEnough(int roadId)
		{
			IEnumerable<KeyValuePair<int, int>> source = ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(roadId).Value.Requirement().ToList<KeyValuePair<int, int>>();
			InventoryModel inventoryModel = ModelBase<InventoryModel>.Instance;
			return source.All((KeyValuePair<int, int> item) => inventoryModel.GetItemCountByConfigId(item.Key, 0) >= item.Value);
		}

		// Token: 0x0603BB10 RID: 244496 RVA: 0x00F1EACF File Offset: 0x00F1CCCF
		public List<int> GetCompleteRoadIds()
		{
			return (from id in this.RoadDataMap.Keys
			where this.RoadDataMap[id].Status == InfrStatusPb.InfrStatusComplete
			select id).ToList<int>();
		}

		// Token: 0x0603BB11 RID: 244497 RVA: 0x00F1EAF4 File Offset: 0x00F1CCF4
		public void SetFireData(InfrFirePb data)
		{
			this.FireExpInner = Singleton<MathUtils>.Instance.LongToBigInt(data.FireExp);
			this.FireLevelInner = data.FireLevel;
			this.FireLevelReachTimeInner = Singleton<MathUtils>.Instance.LongToBigInt(data.FireLevelReachTime);
			this.FireStatusInner = data.FireStatus;
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureFireDataUpdate);
		}

		// Token: 0x0603BB12 RID: 244498 RVA: 0x00F1EB55 File Offset: 0x00F1CD55
		public void AddFireLevel(InfrFireAddNotify data)
		{
			this.SetFireData(data.FireInfo);
		}

		// Token: 0x0603BB13 RID: 244499 RVA: 0x00F1EB63 File Offset: 0x00F1CD63
		public void SetFireShopCoinData(FireShopCoinNotify data)
		{
			this.MoneyCountInner = Singleton<MathUtils>.Instance.LongToBigInt(data.MoneyCount);
			this.MoneyHistorySpentInner = Singleton<MathUtils>.Instance.LongToBigInt(data.MoneyHistorySpent);
		}

		// Token: 0x0603BB14 RID: 244500 RVA: 0x00F1EB91 File Offset: 0x00F1CD91
		public void SetLibraryData(InfrLibraryPb data)
		{
			this.SetArchiveTaskData(data.ArchiveTasks.ToArray<InfrTaskPb>());
			this.SetPhoneTaskData(data.PhoneTasks.ToArray<InfrTaskPb>());
			this.SetUnreadArchives(data.UnreadArchives.ToArray<int>());
		}

		// Token: 0x0603BB15 RID: 244501 RVA: 0x00F1EBC8 File Offset: 0x00F1CDC8
		public void SetArchiveTaskData(InfrTaskPb[] data)
		{
			this.LibraryTaskDataMap.Clear();
			foreach (InfrTaskPb infrTaskPb in data)
			{
				this.LibraryTaskDataMap[infrTaskPb.TaskId] = new InfrastructureDefine.InfrLibraryTaskData
				{
					TaskId = infrTaskPb.TaskId,
					Target = infrTaskPb.Target,
					Status = infrTaskPb.Status
				};
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureArchiveTaskUpdate);
		}

		// Token: 0x0603BB16 RID: 244502 RVA: 0x00F1EC40 File Offset: 0x00F1CE40
		public void SetPhoneTaskData(InfrTaskPb[] data)
		{
			this.PhoneTaskDataMap.Clear();
			foreach (InfrTaskPb infrTaskPb in data)
			{
				this.PhoneTaskDataMap[infrTaskPb.TaskId] = new InfrastructureDefine.InfrLibraryTaskData
				{
					TaskId = infrTaskPb.TaskId,
					Target = infrTaskPb.Target,
					Status = infrTaskPb.Status
				};
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructurePhoneTaskUpdate);
		}

		// Token: 0x0603BB17 RID: 244503 RVA: 0x00F1ECB6 File Offset: 0x00F1CEB6
		public void SetUnreadArchives(int[] data)
		{
			this.UnreadArchives = data.ToList<int>();
		}

		// Token: 0x0603BB18 RID: 244504 RVA: 0x00F1ECC4 File Offset: 0x00F1CEC4
		public void SetLibraryTaskData(InfrLibraryTaskUpdateNotify data)
		{
			this.SetArchiveTaskData(data.ArchiveTasks.ToArray<InfrTaskPb>());
			this.SetPhoneTaskData(data.PhoneTasks.ToArray<InfrTaskPb>());
		}

		// Token: 0x0603BB19 RID: 244505 RVA: 0x00F1ECE8 File Offset: 0x00F1CEE8
		[NullableContext(2)]
		public InfrastructureDefine.IInfrLibraryTaskData GetLibraryTaskDataByTaskId(int taskId)
		{
			InfrastructureDefine.IInfrLibraryTaskData result;
			this.LibraryTaskDataMap.TryGetValue(taskId, out result);
			return result;
		}

		// Token: 0x0603BB1A RID: 244506 RVA: 0x00F1ED08 File Offset: 0x00F1CF08
		public List<InfrastructureDefine.IInfrLibraryTaskData> GetLibraryTaskDataByTaskState(InfrTaskStatusPb taskState)
		{
			return (from task in this.LibraryTaskDataMap.Values
			where task.Status == taskState
			select task).ToList<InfrastructureDefine.IInfrLibraryTaskData>();
		}

		// Token: 0x0603BB1B RID: 244507 RVA: 0x00F1ED43 File Offset: 0x00F1CF43
		public List<InfrastructureDefine.IInfrLibraryTaskData> GetLibraryTaskData()
		{
			return this.LibraryTaskDataMap.Values.ToList<InfrastructureDefine.IInfrLibraryTaskData>();
		}

		// Token: 0x0603BB1C RID: 244508 RVA: 0x00F1ED58 File Offset: 0x00F1CF58
		[NullableContext(2)]
		public InfrastructureDefine.IInfrLibraryTaskData GetPhoneTaskDataByTaskId(int taskId)
		{
			InfrastructureDefine.IInfrLibraryTaskData result;
			this.PhoneTaskDataMap.TryGetValue(taskId, out result);
			return result;
		}

		// Token: 0x0603BB1D RID: 244509 RVA: 0x00F1ED78 File Offset: 0x00F1CF78
		public List<InfrastructureDefine.IInfrLibraryTaskData> GetPhoneTaskDataByTaskState(InfrTaskStatusPb taskState)
		{
			return (from task in this.PhoneTaskDataMap.Values
			where task.Status == taskState
			select task).ToList<InfrastructureDefine.IInfrLibraryTaskData>();
		}

		// Token: 0x0603BB1E RID: 244510 RVA: 0x00F1EDB3 File Offset: 0x00F1CFB3
		public List<InfrastructureDefine.IInfrLibraryTaskData> GetPhoneTaskData()
		{
			return this.PhoneTaskDataMap.Values.ToList<InfrastructureDefine.IInfrLibraryTaskData>();
		}

		// Token: 0x0603BB1F RID: 244511 RVA: 0x00F1EDC5 File Offset: 0x00F1CFC5
		public List<PayShopGoods> GetShopDataList(int level, bool isSort = true)
		{
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.InfrFireShop, level, isSort);
			if (ModelBase<PayShopModel>.Instance.ReadShopItemCheckFlag(PayShopDefine.EPayShopTabType.InfrFireShop, 1))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.InfrastructureFireShopRefresh);
			}
			return payShopTabData;
		}

		// Token: 0x0603BB20 RID: 244512 RVA: 0x00F1EDFC File Offset: 0x00F1CFFC
		public int GetAllShopCurrencyNum()
		{
			PayShopGoods[] array = (from item in ConfigBase<InfrastructureConfig>.Instance.GetAllLevelConfigs()
			select item.Level into level
			where level > 1
			select level).SelectMany((int level) => this.GetShopDataList(level, false)).ToArray<PayShopGoods>();
			int num = 0;
			foreach (PayShopGoods payShopGoods in array)
			{
				IPriceData priceData = payShopGoods.GetPriceData();
				if (priceData.CurrencyId == 80700004)
				{
					num += priceData.NowPrice * payShopGoods.GetGoodsData().BuyLimit;
				}
			}
			return num;
		}

		// Token: 0x0603BB21 RID: 244513 RVA: 0x00F1EEB3 File Offset: 0x00F1D0B3
		public void SetActivityData(InfrastructureActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x0603BB22 RID: 244514 RVA: 0x00F1EEBC File Offset: 0x00F1D0BC
		[NullableContext(2)]
		public InfrastructureActivityData GetActivityData()
		{
			if (this.ActivityData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.LYX, "InfrastructureActivityData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.ActivityData;
		}

		// Token: 0x0603BB23 RID: 244515 RVA: 0x00F1EEF8 File Offset: 0x00F1D0F8
		public int GetOpenShopId()
		{
			return 219;
		}

		// Token: 0x0603BB24 RID: 244516 RVA: 0x00F1EEFF File Offset: 0x00F1D0FF
		public void UpdateActivityTaskData(InfrThemeActivityTaskDataUpdateNotify data)
		{
			InfrastructureActivityData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.UpdateActivityTaskData(data.ActivityTask);
			}
			if (this.ActivityData != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityData.Id);
			}
		}

		// Token: 0x0603BB25 RID: 244517 RVA: 0x00F1EF3B File Offset: 0x00F1D13B
		public IActivityRewardViewData GetScoreRewardData()
		{
			return new ActivityRewardViewData
			{
				DataPageList = new List<IActivityRewardDataPage>
				{
					this.GetCollectionRewardViewData(),
					this.GetRoleMessageViewData()
				},
				Source = EActivityRewardSource.Infrastructure,
				TitleTextId = "PrefabTextItem_1336900617_Text"
			};
		}

		// Token: 0x0603BB26 RID: 244518 RVA: 0x00F1EF7C File Offset: 0x00F1D17C
		private IActivityRewardDataPage GetCollectionRewardViewData()
		{
			List<IActivityRewardData> list = new List<IActivityRewardData>();
			foreach (InfrArchiveTask infrArchiveTask in ConfigBase<InfrastructureConfig>.Instance.GetInfrArchiveTaskList())
			{
				InfrastructureDefine.IInfrLibraryTaskData libraryTaskDataByTaskId = this.GetLibraryTaskDataByTaskId(infrArchiveTask.TaskId);
				List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(infrArchiveTask.TaskReward);
				InfrTaskStatusPb infrTaskStatusPb = (libraryTaskDataByTaskId != null) ? libraryTaskDataByTaskId.Status : InfrTaskStatusPb.InfrTaskRunning;
				ActivityRewardData activityRewardData = new ActivityRewardData();
				activityRewardData.Id = new int?(infrArchiveTask.TaskId);
				activityRewardData.NameText = "";
				activityRewardData.NameTextId = "BuildArchives_GeneralTask";
				activityRewardData.NameTextArgs = new string[]
				{
					infrArchiveTask.Target.ToString()
				};
				activityRewardData.RewardList = dropPackagePreviewItemList.ToArray();
				activityRewardData.RewardState = InfrastructureDefine.infrTaskStateToRewardStateResolver[infrTaskStatusPb];
				activityRewardData.RewardButtonTextId = InfrastructureDefine.infrTaskStateToRewardText[infrTaskStatusPb];
				activityRewardData.RewardButtonRedDot = new bool?(infrTaskStatusPb == InfrTaskStatusPb.InfrTaskTaken);
				activityRewardData.ClickFunction = delegate()
				{
					ControllerBase<InfrastructureController>.Instance.RequestInfrastructureArchiveTaskReward().Forget<bool>();
				};
				ActivityRewardData item = activityRewardData;
				list.Add(item);
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BuildRoadFile_RecordsPage", null);
			return new ActivityRewardDataPage
			{
				TabName = localTextNew,
				DataList = list
			};
		}

		// Token: 0x0603BB27 RID: 244519 RVA: 0x00F1F0F4 File Offset: 0x00F1D2F4
		private IActivityRewardDataPage GetRoleMessageViewData()
		{
			List<IActivityRewardData> list = new List<IActivityRewardData>();
			foreach (InfrPhoneTask infrPhoneTask in ConfigBase<InfrastructureConfig>.Instance.GetInfrPhoneTaskList())
			{
				InfrastructureDefine.IInfrLibraryTaskData phoneTaskDataByTaskId = this.GetPhoneTaskDataByTaskId(infrPhoneTask.TaskId);
				List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(infrPhoneTask.TaskReward);
				InfrTaskStatusPb infrTaskStatusPb = (phoneTaskDataByTaskId != null) ? phoneTaskDataByTaskId.Status : InfrTaskStatusPb.InfrTaskRunning;
				ActivityRewardData activityRewardData = new ActivityRewardData();
				activityRewardData.Id = new int?(infrPhoneTask.TaskId);
				activityRewardData.NameText = "";
				activityRewardData.NameTextId = "BuildArchives_GeneralCommunication";
				activityRewardData.NameTextArgs = new string[]
				{
					infrPhoneTask.Target.ToString()
				};
				activityRewardData.RewardList = dropPackagePreviewItemList.ToArray();
				activityRewardData.RewardState = InfrastructureDefine.infrTaskStateToRewardStateResolver[infrTaskStatusPb];
				activityRewardData.RewardButtonTextId = InfrastructureDefine.infrTaskStateToRewardText[infrTaskStatusPb];
				activityRewardData.RewardButtonRedDot = new bool?(infrTaskStatusPb == InfrTaskStatusPb.InfrTaskTaken);
				activityRewardData.ClickFunction = delegate()
				{
					ControllerBase<InfrastructureController>.Instance.RequestInfrastructurePhoneTaskReward().Forget<bool>();
				};
				ActivityRewardData item = activityRewardData;
				list.Add(item);
			}
			return new ActivityRewardDataPage
			{
				TabName = ConfigMultiTextLang.GetLocalTextNew("BuildRoadFile_MessagePage", null),
				DataList = list
			};
		}

		// Token: 0x0603BB28 RID: 244520 RVA: 0x00F1F268 File Offset: 0x00F1D468
		public bool GetArchiveRedDot()
		{
			IEnumerable<InfrArchiveTask> infrArchiveTaskList = ConfigBase<InfrastructureConfig>.Instance.GetInfrArchiveTaskList();
			IReadOnlyList<InfrPhoneTask> infrPhoneTaskList = ConfigBase<InfrastructureConfig>.Instance.GetInfrPhoneTaskList();
			bool flag = infrArchiveTaskList.Any(delegate(InfrArchiveTask taskConfig)
			{
				InfrastructureDefine.IInfrLibraryTaskData libraryTaskDataByTaskId = this.GetLibraryTaskDataByTaskId(taskConfig.TaskId);
				return libraryTaskDataByTaskId != null && libraryTaskDataByTaskId.Status == InfrTaskStatusPb.InfrTaskFinish;
			});
			bool flag2 = infrPhoneTaskList.Any(delegate(InfrPhoneTask taskConfig)
			{
				InfrastructureDefine.IInfrLibraryTaskData phoneTaskDataByTaskId = this.GetPhoneTaskDataByTaskId(taskConfig.TaskId);
				return phoneTaskDataByTaskId != null && phoneTaskDataByTaskId.Status == InfrTaskStatusPb.InfrTaskFinish;
			});
			return flag || flag2;
		}

		// Token: 0x0603BB29 RID: 244521 RVA: 0x00F1F2B0 File Offset: 0x00F1D4B0
		public int GetCurrentQuestId()
		{
			InfrLevel? levelConfigById = ConfigBase<InfrastructureConfig>.Instance.GetLevelConfigById(this.FireLevel);
			if (levelConfigById.Value.QuestIdsLength == 0)
			{
				return 0;
			}
			int j = 0;
			for (int i = 0; i < levelConfigById.Value.QuestIdsLength; i++)
			{
				int questId = levelConfigById.Value.QuestIds(i);
				global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
				if (quest != null && quest.CanShowInUiPanel())
				{
					j = i;
					break;
				}
			}
			return levelConfigById.Value.QuestIds(j);
		}

		// Token: 0x0603BB2A RID: 244522 RVA: 0x00F1F340 File Offset: 0x00F1D540
		public InfrastructureLoadingPanel CreateLoadingPanel()
		{
			if (this.LoadingPanel != null)
			{
				this.DestroyLoadingPanel();
				Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.LYX, "LoadingPanel is not undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.LoadingPanel = new InfrastructureLoadingPanel();
			return this.LoadingPanel;
		}

		// Token: 0x0603BB2B RID: 244523 RVA: 0x00F1F38B File Offset: 0x00F1D58B
		public void CloseLoadingPanel()
		{
			InfrastructureLoadingPanel loadingPanel = this.LoadingPanel;
			if (loadingPanel == null)
			{
				return;
			}
			loadingPanel.CloseSelf();
		}

		// Token: 0x0603BB2C RID: 244524 RVA: 0x00F1F39D File Offset: 0x00F1D59D
		public void DestroyLoadingPanel()
		{
			InfrastructureLoadingPanel loadingPanel = this.LoadingPanel;
			if (loadingPanel != null)
			{
				loadingPanel.Destroy(null);
			}
			this.LoadingPanel = null;
		}

		// Token: 0x04021908 RID: 137480
		private int InteractingRoadIdInner;

		// Token: 0x04021909 RID: 137481
		[Nullable(2)]
		private InfrastructureLoadingPanel LoadingPanel;

		// Token: 0x0402190A RID: 137482
		private readonly Dictionary<int, InfrastructureDefine.IInfrRoadData> RoadDataMap = new Dictionary<int, InfrastructureDefine.IInfrRoadData>();

		// Token: 0x0402190B RID: 137483
		private int TracedRoadIdInner;

		// Token: 0x0402190C RID: 137484
		private int RecommendRoadIdInner;

		// Token: 0x0402190D RID: 137485
		public bool NeedHighlightTrackedRoadInner;

		// Token: 0x0402190E RID: 137486
		private long FireExpInner;

		// Token: 0x0402190F RID: 137487
		private int FireLevelInner;

		// Token: 0x04021910 RID: 137488
		private long FireLevelReachTimeInner;

		// Token: 0x04021911 RID: 137489
		private InfrStatusPb FireStatusInner;

		// Token: 0x04021912 RID: 137490
		private long MoneyCountInner;

		// Token: 0x04021913 RID: 137491
		private long MoneyHistorySpentInner;

		// Token: 0x04021914 RID: 137492
		private readonly Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData> LibraryTaskDataMap = new Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData>();

		// Token: 0x04021915 RID: 137493
		private readonly Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData> PhoneTaskDataMap = new Dictionary<int, InfrastructureDefine.IInfrLibraryTaskData>();

		// Token: 0x04021916 RID: 137494
		private List<int> UnreadArchives = new List<int>();

		// Token: 0x04021917 RID: 137495
		[Nullable(2)]
		private InfrastructureActivityData ActivityData;
	}
}
