using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.QuestNew.Controller;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RecallQuest
{
	// Token: 0x0200528D RID: 21133
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RecallQuestController : UiControllerBase<RecallQuestController>
	{
		// Token: 0x060360A9 RID: 221353 RVA: 0x00D9A814 File Offset: 0x00D98A14
		protected override void OnRegisterNetEvent()
		{
			base.OnRegisterNetEvent();
			Singleton<Net>.Instance.Register<RecallQuestListNotify>(ENotifyMessageId.RecallQuestListNotify, new Action<RecallQuestListNotify, Net.CallbackStatus>(this.OnRecallQuestListNotify));
			Singleton<Net>.Instance.Register<RecallQuestStatusUpdateNotify>(ENotifyMessageId.RecallQuestStatusUpdateNotify, new Action<RecallQuestStatusUpdateNotify, Net.CallbackStatus>(this.OnRecallQuestStatusUpdateNotify));
			Singleton<Net>.Instance.Register<RecallQuestFinishListNotify>(ENotifyMessageId.RecallQuestFinishListNotify, new Action<RecallQuestFinishListNotify, Net.CallbackStatus>(this.OnRecallQuestFinishListNotify));
			Singleton<Net>.Instance.Register<DestroyRecallQuestsNotify>(ENotifyMessageId.DestroyRecallQuestsNotify, new Action<DestroyRecallQuestsNotify, Net.CallbackStatus>(this.OnDestroyRecallQuestsNotify));
			Singleton<Net>.Instance.Register<LeaveQuestRecallNotify>(ENotifyMessageId.LeaveQuestRecallNotify, new Action<LeaveQuestRecallNotify, Net.CallbackStatus>(this.OnLeaveQuestRecallNotify));
			Singleton<Net>.Instance.Register<RecallInfoNotify>(ENotifyMessageId.RecallInfoNotify, new Action<RecallInfoNotify, Net.CallbackStatus>(this.OnRecallInfoNotify));
			Singleton<Net>.Instance.Register<PlayerRecallInfoNotify>(ENotifyMessageId.PlayerRecallInfoNotify, new Action<PlayerRecallInfoNotify, Net.CallbackStatus>(this.OnPlayerRecallInfoNotify));
			Singleton<Net>.Instance.Register<RecallQuestGiveUpNotify>(ENotifyMessageId.RecallQuestGiveUpNotify, new Action<RecallQuestGiveUpNotify, Net.CallbackStatus>(this.OnRecallQuestGiveUpNotify));
			Singleton<Net>.Instance.Register<TraceRecallQuestNotify>(ENotifyMessageId.TraceRecallQuestNotify, new Action<TraceRecallQuestNotify, Net.CallbackStatus>(this.OnTraceRecallQuestNotify));
			Singleton<Net>.Instance.Register<RecallItemBagDeltaNotify>(ENotifyMessageId.RecallItemBagDeltaNotify, new Action<RecallItemBagDeltaNotify, Net.CallbackStatus>(this.OnRecallItemBagDeltaNotify));
			Singleton<Net>.Instance.Register<RecallItemBagRemoveNotify>(ENotifyMessageId.RecallItemBagRemoveNotify, new Action<RecallItemBagRemoveNotify, Net.CallbackStatus>(this.OnRecallItemBagRemoveNotify));
			Singleton<Net>.Instance.Register<RecallExploreSkillRouletteNotify>(ENotifyMessageId.RecallExploreSkillRouletteNotify, new Action<RecallExploreSkillRouletteNotify, Net.CallbackStatus>(this.OnRecallExploreSkillRouletteNotify));
		}

		// Token: 0x060360AA RID: 221354 RVA: 0x00D9A978 File Offset: 0x00D98B78
		protected override void OnUnRegisterNetEvent()
		{
			base.OnUnRegisterNetEvent();
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallQuestListNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TraceRecallQuestNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallQuestStatusUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallQuestFinishListNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DestroyRecallQuestsNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LeaveQuestRecallNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PlayerRecallInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallQuestGiveUpNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallItemBagDeltaNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallItemBagRemoveNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RecallExploreSkillRouletteNotify);
		}

		// Token: 0x060360AB RID: 221355 RVA: 0x00D9AA4B File Offset: 0x00D98C4B
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.DoLeaveLevel, new Action(this.OnDoLeaveLevel));
		}

		// Token: 0x060360AC RID: 221356 RVA: 0x00D9AA85 File Offset: 0x00D98C85
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.DoLeaveLevel, new Action(this.OnDoLeaveLevel));
		}

		// Token: 0x060360AD RID: 221357 RVA: 0x00D9AAC0 File Offset: 0x00D98CC0
		private void SendReadyForGiveUpRequest(int recallId)
		{
			RecallQuestReadyForGiveUpRequest recallQuestReadyForGiveUpRequest = RecallQuestReadyForGiveUpRequest.Create();
			recallQuestReadyForGiveUpRequest.RecallQuestId = recallId;
			Singleton<Net>.Instance.Call<RecallQuestReadyForGiveUpResponse>(ERequestMessageId.RecallQuestReadyForGiveUpRequest, recallQuestReadyForGiveUpRequest, delegate(RecallQuestReadyForGiveUpResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 23868, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060360AE RID: 221358 RVA: 0x00D9AB0C File Offset: 0x00D98D0C
		private unsafe void OnRecallQuestGiveUpNotify(RecallQuestGiveUpNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestRecall;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "回顾任务 GiveUp 通知";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RecallQuestId", notify.RecallQuestId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TreeIncId", notify.TreeIncId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			QuestNewController.HandleGiveUpNotify(notify.RecallQuestId, notify.TreeIncId, notify.FlowIncIds, new Action<int>(this.SendReadyForGiveUpRequest), "任务结束打断剧情");
		}

		// Token: 0x060360AF RID: 221359 RVA: 0x00D9ABA8 File Offset: 0x00D98DA8
		private void OnRecallItemBagDeltaNotify(RecallItemBagDeltaNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RecallInventoryData inventoryData = ModelBase<RecallQuestModel>.Instance.GetInventoryData();
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			List<RewardItemData> list2 = new List<RewardItemData>();
			foreach (RecallItemBagItem recallItemBagItem in notify.Items)
			{
				int count = inventoryData.GetCount(recallItemBagItem.ItemId);
				int num = recallItemBagItem.Count - count;
				inventoryData.SetItem(recallItemBagItem.ItemId, recallItemBagItem.Count);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, recallItemBagItem.ItemId, recallItemBagItem.Count);
				if (num > 0)
				{
					list.Add(new ValueTuple<int, int>(recallItemBagItem.ItemId, num));
					list2.Add(new RewardItemData(recallItemBagItem.ItemId, num, null, EDropItemType.Normal));
				}
			}
			if (list.Count > 0)
			{
				ControllerBase<ItemHintController>.Instance.AddRecallItemList(list.ToArray());
			}
			if (list2.Count > 0)
			{
				ControllerBase<ItemRewardController>.Instance.DispatchPackagedReward(notify.Reason, list2, new List<RewardItemPackage>(), new List<RewardItemData>(), new List<RewardItemData>(), new List<RewardItemData>(), new List<RewardItemData>(), 0, null, null);
			}
		}

		// Token: 0x060360B0 RID: 221360 RVA: 0x00D9ACE0 File Offset: 0x00D98EE0
		private void OnRecallItemBagRemoveNotify(RecallItemBagRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RecallInventoryData inventoryData = ModelBase<RecallQuestModel>.Instance.GetInventoryData();
			foreach (int num in notify.ItemIds)
			{
				inventoryData.RemoveItem(num);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, num, 0);
			}
		}

		// Token: 0x060360B1 RID: 221361 RVA: 0x00D9AD4C File Offset: 0x00D98F4C
		[NullableContext(2)]
		private void OnQueryRecallItemBagResponse(QueryRecallItemBagResponse resp, Net.CallbackStatus status)
		{
			if (resp == null || resp.ErrorCode != ErrorCode.Success)
			{
				return;
			}
			List<ValueTuple<int, int>> list = (from i in resp.Items
			select new ValueTuple<int, int>(i.ItemId, i.Count)).ToList<ValueTuple<int, int>>();
			RecallQuestModel instance = ModelBase<RecallQuestModel>.Instance;
			instance.GetInventoryData().InitFromFullSnapshot(list);
			ModelBase<InventoryModel>.Instance.SetInventoryDataProxy(new RecallInventoryDataProxy(instance.GetInventoryData()));
			foreach (ValueTuple<int, int> valueTuple in list)
			{
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, valueTuple.Item1, valueTuple.Item2);
			}
		}

		// Token: 0x060360B2 RID: 221362 RVA: 0x00D9AE14 File Offset: 0x00D99014
		private void OnWorldDone()
		{
			RecallQuestModel instance = ModelBase<RecallQuestModel>.Instance;
			if (!instance.IsInRecallInstance())
			{
				return;
			}
			if (instance.HasQueriedItemBag)
			{
				return;
			}
			instance.HasQueriedItemBag = true;
			QueryRecallItemBagRequest queryRecallItemBagRequest = QueryRecallItemBagRequest.Create();
			queryRecallItemBagRequest.RecallId = instance.GetCurrentRecallId();
			Singleton<Net>.Instance.Call<QueryRecallItemBagResponse>(ERequestMessageId.QueryRecallItemBagRequest, queryRecallItemBagRequest, new Action<QueryRecallItemBagResponse, Net.CallbackStatus>(this.OnQueryRecallItemBagResponse), 0);
		}

		// Token: 0x060360B3 RID: 221363 RVA: 0x00D9AE6F File Offset: 0x00D9906F
		private void OnDoLeaveLevel()
		{
		}

		// Token: 0x060360B4 RID: 221364 RVA: 0x00D9AE74 File Offset: 0x00D99074
		private void OnRecallQuestListNotify(RecallQuestListNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (!this.IsTrackSlotAttached)
			{
				ModelBase<QuestNewModel>.Instance.AttachTrackSlot(new RecallQuestTrackProxy());
				this.IsTrackSlotAttached = true;
				Singleton<Log>.Instance.Info(ELogModule.QuestRecall, ELogAuthor.YZY, "回顾副本：QuestTrack Slot 已挂载", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			List<QuestListItem> list = new List<QuestListItem>();
			foreach (RecallQuestInfo recallQuestInfo in notify.RecallQuestInfos)
			{
				int recallQuestId = recallQuestInfo.RecallQuestId;
				ERecallQuestStatus status2 = RecallQuestDefine.ToStatus((int)recallQuestInfo.Status);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "下发回顾任务列表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questId", recallQuestId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				list.Add(new QuestListItem
				{
					QuestId = recallQuestId,
					State = RecallQuestDefine.ToProtoQuestState(status2),
					UpdateReason = RecallQuestDefine.ToQuestUpdateReason(ERecallStatusUpdateReason.ReLogin)
				});
			}
			QuestNewController.HandleQuestListNotify(list);
			ModelBase<RecallQuestModel>.Instance.TryReTrackRecallQuest();
		}

		// Token: 0x060360B5 RID: 221365 RVA: 0x00D9AF78 File Offset: 0x00D99178
		private unsafe void OnRecallQuestStatusUpdateNotify(RecallQuestStatusUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (!this.IsTrackSlotAttached)
			{
				ModelBase<QuestNewModel>.Instance.AttachTrackSlot(new RecallQuestTrackProxy());
				this.IsTrackSlotAttached = true;
			}
			int recallQuestId = notify.RecallQuestId;
			ERecallQuestStatus status2 = RecallQuestDefine.ToStatus((int)notify.Status);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestRecall;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "回顾任务状态变更";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("questId", recallQuestId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Status", notify.Status);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			QuestNewController.HandleQuestStateUpdate(new QuestStateUpdateData
			{
				QuestId = recallQuestId,
				State = RecallQuestDefine.ToProtoQuestState(status2),
				UpdateReason = RecallQuestDefine.ToQuestUpdateReason(ERecallStatusUpdateReason.NotifyChange)
			});
		}

		// Token: 0x060360B6 RID: 221366 RVA: 0x00D9B044 File Offset: 0x00D99244
		private void OnRecallQuestFinishListNotify(RecallQuestFinishListNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			FinishListNotifyData finishListNotifyData = new FinishListNotifyData();
			finishListNotifyData.QuestIds = notify.RecallQuestIds.ToList<int>();
			finishListNotifyData.EmitEventName = EEventName.OnQuestFinishListNotify;
			finishListNotifyData.TryChangeTrackedQuest = delegate()
			{
				ControllerBase<QuestNewController>.Instance.TryChangeTrackedQuest2(null);
			};
			QuestNewController.HandleFinishListNotify(finishListNotifyData);
		}

		// Token: 0x060360B7 RID: 221367 RVA: 0x00D9B09C File Offset: 0x00D9929C
		private void OnDestroyRecallQuestsNotify(DestroyRecallQuestsNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			foreach (int num in notify.RecallQuestIds)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "销毁回顾任务";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecallId", num);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
				if (curTrackedQuest != null && curTrackedQuest.Id == num)
				{
					ModelBase<QuestNewModel>.Instance.SetQuestTrackState(num, false, ESetTrackReason.None);
				}
				ModelBase<QuestNewModel>.Instance.RemoveQuest(num);
			}
		}

		// Token: 0x060360B8 RID: 221368 RVA: 0x00D9B140 File Offset: 0x00D99340
		private void OnLeaveQuestRecallNotify(LeaveQuestRecallNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			foreach (int num in notify.DestroyRecallQuestIds)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "离开回顾销毁任务";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecallId", num);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
				if (curTrackedQuest != null && curTrackedQuest.Id == num)
				{
					ModelBase<QuestNewModel>.Instance.SetQuestTrackState(num, false, ESetTrackReason.None);
				}
				ModelBase<QuestNewModel>.Instance.RemoveQuest(num);
			}
			RouletteListDataBase rouletteListDataBase;
			if (ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Explore, out rouletteListDataBase))
			{
				RouletteListDataExplore rouletteListDataExplore = rouletteListDataBase as RouletteListDataExplore;
				if (rouletteListDataExplore != null)
				{
					rouletteListDataExplore.SetExtraItemIdProxy(null);
					Singleton<Log>.Instance.Info(ELogModule.QuestRecall, ELogAuthor.YZY, "退出回顾：探索轮盘 ExtraItemIdProxy 已还原为 Normal", default(ReadOnlySpan<ValueTuple<string, object>>));
					Singleton<EventSystem>.Instance.Emit<int?>(EEventName.OnSpecialItemUpdate, new int?(rouletteListDataExplore.GetExtraItemId()));
				}
			}
			if (!this.IsTrackSlotAttached)
			{
				return;
			}
			QuestNewModel instance2 = ModelBase<QuestNewModel>.Instance;
			if (instance2 != null)
			{
				instance2.DetachTrackSlot();
			}
			this.IsTrackSlotAttached = false;
			Singleton<Log>.Instance.Info(ELogModule.QuestRecall, ELogAuthor.YZY, "回顾副本：QuestTrack Slot 已卸下", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060360B9 RID: 221369 RVA: 0x00D9B284 File Offset: 0x00D99484
		private void OnRecallExploreSkillRouletteNotify(RecallExploreSkillRouletteNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RouletteListDataBase rouletteListDataBase;
			if (!ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Explore, out rouletteListDataBase))
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestRecall, ELogAuthor.YZY, "收到 RecallExploreSkillRouletteNotify 但探索轮盘数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RouletteListDataExplore rouletteListDataExplore = rouletteListDataBase as RouletteListDataExplore;
			if (rouletteListDataExplore == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestRecall, ELogAuthor.YZY, "收到 RecallExploreSkillRouletteNotify 但探索轮盘数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int extraItemId = notify.ExtraItemId;
			RecallExtraItemIdProxy recallExtraItemIdProxy = rouletteListDataExplore.GetExtraItemIdProxy() as RecallExtraItemIdProxy;
			if (recallExtraItemIdProxy != null)
			{
				recallExtraItemIdProxy.ApplyServerSnapshot(extraItemId);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "回顾道具同步：复用现有 Recall Proxy 灌入服务端值";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ExtraItemId", extraItemId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				rouletteListDataExplore.SetExtraItemIdProxy(new RecallExtraItemIdProxy(extraItemId));
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.QuestRecall;
				ELogAuthor author2 = ELogAuthor.YZY;
				string message2 = "进入回顾：切换 ExtraItemIdProxy 为 Recall";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ExtraItemId", extraItemId);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.OnSpecialItemUpdate, new int?(rouletteListDataExplore.GetExtraItemId()));
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, extraItemId, 0);
		}

		// Token: 0x060360BA RID: 221370 RVA: 0x00D9B39C File Offset: 0x00D9959C
		[NullableContext(2)]
		public void SendRecallExploreSkillRouletteSet(int itemId, Action<bool> callback = null)
		{
			RecallExploreSkillRouletteSetRequest recallExploreSkillRouletteSetRequest = RecallExploreSkillRouletteSetRequest.Create();
			recallExploreSkillRouletteSetRequest.ExtraItemId = itemId;
			Singleton<Net>.Instance.Call<RecallExploreSkillRouletteSetResponse>(ERequestMessageId.RecallExploreSkillRouletteSetRequest, recallExploreSkillRouletteSetRequest, delegate(RecallExploreSkillRouletteSetResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else if (response.ErrorId == ErrorCode.Success)
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
				else
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 25665, null, true, true);
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(false);
					return;
				}
			}, 0);
		}

		// Token: 0x060360BB RID: 221371 RVA: 0x00D9B3E0 File Offset: 0x00D995E0
		private void OnRecallInfoNotify(RecallInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestRecall;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "回顾任务信息推送";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecallIds", notify.RecallInfos);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<RecallQuestModel>.Instance.SetPastRecallIds(notify.RecallInfos);
		}

		// Token: 0x060360BC RID: 221372 RVA: 0x00D9B42C File Offset: 0x00D9962C
		private unsafe void OnTraceRecallQuestNotify(TraceRecallQuestNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			int recallQuestId = notify.RecallQuestId;
			Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(recallQuestId);
			if (quest == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "回顾任务跟踪目标修改：本地未找到对应Quest，忽略 Notify";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RecallQuestId", recallQuestId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			if (quest.DungeonId != instanceId)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.QuestRecall;
				ELogAuthor author2 = ELogAuthor.YZY;
				string message2 = "回顾任务跟踪目标修改：Quest绑定的副本与当前副本不一致，忽略 Notify";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RecallQuestId", recallQuestId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Quest.DungeonId", quest.DungeonId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CurInstanceId", instanceId);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.QuestRecall;
			ELogAuthor author3 = ELogAuthor.YZY;
			string message3 = "回顾任务跟踪目标修改";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RecallQuestId", recallQuestId);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			QuestNewController.NotifyTraceQuestFromServer(recallQuestId);
		}

		// Token: 0x060360BD RID: 221373 RVA: 0x00D9B548 File Offset: 0x00D99748
		private void OnPlayerRecallInfoNotify(PlayerRecallInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			int curRecallId = notify.CurRecallId;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.QuestRecall;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "玩家当前回顾信息推送";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurRecallId", curRecallId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<RecallQuestModel>.Instance.SetCurrentRecallId(curRecallId);
		}

		// Token: 0x060360BE RID: 221374 RVA: 0x00D9B594 File Offset: 0x00D99794
		public void RequestRecallQuestFinishAction(int questId, int nodeId, int actionId, ActionTime actTime)
		{
			RecallQuestFinishActionRequest recallQuestFinishActionRequest = RecallQuestFinishActionRequest.Create();
			recallQuestFinishActionRequest.RecallQuestId = questId;
			recallQuestFinishActionRequest.NodeId = nodeId;
			recallQuestFinishActionRequest.ActionId = actionId;
			recallQuestFinishActionRequest.ActTime = actTime;
			Singleton<Net>.Instance.Call<RecallQuestFinishActionResponse>(ERequestMessageId.RecallQuestFinishActionRequest, recallQuestFinishActionRequest, delegate(RecallQuestFinishActionResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 19105, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060360BF RID: 221375 RVA: 0x00D9B5F4 File Offset: 0x00D997F4
		public void RequestRecallAction(int questId, int nodeId, int actionId, ActionTime actTime)
		{
			RecallQuestActionRequest recallQuestActionRequest = RecallQuestActionRequest.Create();
			recallQuestActionRequest.RecallQuestId = questId;
			recallQuestActionRequest.NodeId = nodeId;
			recallQuestActionRequest.ActionId = actionId;
			recallQuestActionRequest.ActTime = actTime;
			Singleton<Net>.Instance.Call<RecallQuestActionResponse>(ERequestMessageId.RecallQuestActionRequest, recallQuestActionRequest, delegate(RecallQuestActionResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 17551, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060360C0 RID: 221376 RVA: 0x00D9B654 File Offset: 0x00D99854
		public void RequestRecallQuestNpcMoveOver(long entityId)
		{
			RecallQuestNpcMoveOverRequest recallQuestNpcMoveOverRequest = RecallQuestNpcMoveOverRequest.Create();
			recallQuestNpcMoveOverRequest.EntityId = entityId;
			Singleton<Net>.Instance.Call<RecallQuestNpcMoveOverResponse>(ERequestMessageId.RecallQuestNpcMoveOverRequest, recallQuestNpcMoveOverRequest, delegate(RecallQuestNpcMoveOverResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 17798, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060360C1 RID: 221377 RVA: 0x00D9B6A0 File Offset: 0x00D998A0
		public void RequestRecallFinishActionEnd(List<int> questIds)
		{
			RecallQuestFinishActionEndRequest recallQuestFinishActionEndRequest = RecallQuestFinishActionEndRequest.Create();
			foreach (int item in questIds)
			{
				recallQuestFinishActionEndRequest.RecallQuestId.Add(item);
			}
			Singleton<Net>.Instance.Call<RecallQuestFinishActionEndResponse>(ERequestMessageId.RecallQuestFinishActionEndRequest, recallQuestFinishActionEndRequest, delegate(RecallQuestFinishActionEndResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 29407, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060360C2 RID: 221378 RVA: 0x00D9B72C File Offset: 0x00D9992C
		public void RequestStartRecall(int recallId, bool bContinue)
		{
			StartRecallRequest startRecallRequest = StartRecallRequest.Create();
			startRecallRequest.RecallId = recallId;
			startRecallRequest.Continue = bContinue;
			Singleton<Net>.Instance.Call<StartRecallResponse>(ERequestMessageId.StartRecallRequest, startRecallRequest, delegate(StartRecallResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29876, null, true, true);
					return;
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestRecall;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "开始回顾";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CanContinue", (response != null) ? new bool?(response.CanContinue) : null);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<RecallQuestModel>.Instance.SetCurrentRecallId(recallId);
				QuestRecallInstCtx questRecallInstCtx = new QuestRecallInstCtx
				{
					RecallId = recallId,
					Continue = (response != null && response.CanContinue)
				};
				EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
				int[] array = (getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null;
				ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.QuestRecallInstCtx = questRecallInstCtx;
				ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(response.EnterInstId, ((array != null) ? array.ToList<int>() : null) ?? new List<int>(), 0, 0, null, null);
			}, 0);
		}

		// Token: 0x0401F0EF RID: 127215
		private bool IsTrackSlotAttached;
	}
}
