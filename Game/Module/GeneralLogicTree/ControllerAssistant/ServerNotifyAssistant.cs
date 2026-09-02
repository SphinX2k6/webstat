using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.GeneralLogicTree.ControllerAssistant
{
	// Token: 0x02005CD5 RID: 23765
	[NullableContext(1)]
	[Nullable(0)]
	public class ServerNotifyAssistant : ControllerAssistantBase
	{
		// Token: 0x0603BEC6 RID: 245446 RVA: 0x00F307B9 File Offset: 0x00F2E9B9
		protected override void OnDestroy()
		{
		}

		// Token: 0x0603BEC7 RID: 245447 RVA: 0x00F307BC File Offset: 0x00F2E9BC
		public override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<UpdateNodeStatusNotify>(ENotifyMessageId.UpdateNodeStatusNotify, new Action<UpdateNodeStatusNotify, Net.CallbackStatus>(this.OnUpdateNodeStatusNotify));
			Singleton<Net>.Instance.Register<UpdateNodeProgressNotify>(ENotifyMessageId.UpdateNodeProgressNotify, new Action<UpdateNodeProgressNotify, Net.CallbackStatus>(this.OnUpdateNodeProgressNotify));
			Singleton<Net>.Instance.Register<UpdateChildQuestNodeStatusNotify>(ENotifyMessageId.UpdateChildQuestNodeStatusNotify, new Action<UpdateChildQuestNodeStatusNotify, Net.CallbackStatus>(this.OnUpdateChildQuestNodeStatusNotify));
			Singleton<Net>.Instance.Register<BtRollbackNotify>(ENotifyMessageId.BtRollbackNotify, new Action<BtRollbackNotify, Net.CallbackStatus>(this.OnRollbackNotify));
			Singleton<Net>.Instance.Register<BtRollbackStartNotify>(ENotifyMessageId.BtRollbackStartNotify, new Action<BtRollbackStartNotify, Net.CallbackStatus>(this.OnBtRollbackStartNotify));
			Singleton<Net>.Instance.Register<BtRollbackInfoNotify>(ENotifyMessageId.BtRollbackInfoNotify, new Action<BtRollbackInfoNotify, Net.CallbackStatus>(this.OnRollbackInfoNotify));
			Singleton<Net>.Instance.Register<BtSuspendNotify>(ENotifyMessageId.BtSuspendNotify, new Action<BtSuspendNotify, Net.CallbackStatus>(this.OnBtSuspendNotify));
			Singleton<Net>.Instance.Register<UpdateTimerInfoNotify>(ENotifyMessageId.UpdateTimerInfoNotify, new Action<UpdateTimerInfoNotify, Net.CallbackStatus>(this.OnUpdateTimerInfoNotify));
			Singleton<Net>.Instance.Register<BtVarUpdateNotify>(ENotifyMessageId.BtVarUpdateNotify, new Action<BtVarUpdateNotify, Net.CallbackStatus>(this.OnBtVarUpdateNotify));
			Singleton<Net>.Instance.Register<BehaviorTreeInfoNotify>(ENotifyMessageId.BehaviorTreeInfoNotify, new Action<BehaviorTreeInfoNotify, Net.CallbackStatus>(this.OnBehaviorTreeInfoNotify));
			Singleton<Net>.Instance.Register<BehaviorTreeDeleteNotify>(ENotifyMessageId.BehaviorTreeDeleteNotify, new Action<BehaviorTreeDeleteNotify, Net.CallbackStatus>(this.OnBehaviorTreeDeleteNotify));
			Singleton<Net>.Instance.Register<AutoQuestNotify>(ENotifyMessageId.AutoQuestNotify, new Action<AutoQuestNotify, Net.CallbackStatus>(this.OnGmStateNotify));
			Singleton<Net>.Instance.Register<ActionOpenSystemBoardNotify>(ENotifyMessageId.ActionOpenSystemBoardNotify, new Action<ActionOpenSystemBoardNotify, Net.CallbackStatus>(this.OnActionOpenSystemBoardNotify));
			Singleton<Net>.Instance.Register<QuestRollBackEndNotify>(ENotifyMessageId.QuestRollBackEndNotify, new Action<QuestRollBackEndNotify, Net.CallbackStatus>(this.OnRollBackEndNotify));
		}

		// Token: 0x0603BEC8 RID: 245448 RVA: 0x00F30954 File Offset: 0x00F2EB54
		public override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateNodeStatusNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateNodeProgressNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateChildQuestNodeStatusNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtRollbackNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtRollbackInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtSuspendNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.UpdateTimerInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtVarUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BehaviorTreeInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BehaviorTreeDeleteNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AutoQuestNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActionOpenSystemBoardNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestRollBackEndNotify);
		}

		// Token: 0x0603BEC9 RID: 245449 RVA: 0x00F30A34 File Offset: 0x00F2EC34
		private unsafe void OnUpdateNodeStatusNotify(UpdateNodeStatusNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到节点状态更新协议时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Quest;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "行为树节点状态更新";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("树Id", behaviorTree.TreeConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("节点Id", notify.NodeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("节点状态", GeneralLogicTreeDefine.btNodeStatusLogString[notify.Status]);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			behaviorTree.UpdateNodeState(ENodeStatusUpdateReason.ServerUpdateNodeStatus, notify.NodeId, notify.Status);
		}

		// Token: 0x0603BECA RID: 245450 RVA: 0x00F30B30 File Offset: 0x00F2ED30
		private void OnUpdateNodeProgressNotify(UpdateNodeProgressNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到节点进度更新协议时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			behaviorTree.UpdateNodeProgress(notify.NodeId, notify.Progress);
		}

		// Token: 0x0603BECB RID: 245451 RVA: 0x00F30B9C File Offset: 0x00F2ED9C
		private unsafe void OnUpdateChildQuestNodeStatusNotify(UpdateChildQuestNodeStatusNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到子任务节点状态更新协议时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", notify.TreeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Quest;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "行为树ChildQuest节点状态更新";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("树Id", behaviorTree.TreeConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("节点Id", notify.NodeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ChildQuest子节点状态", GeneralLogicTreeDefine.btChildQuestNodeStatusLogString[notify.Status]);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			behaviorTree.UpdateChildQuestNodeState(notify.NodeId, notify.Status, ENodeStatusUpdateReason.ServerUpdateNodeStatus);
		}

		// Token: 0x0603BECC RID: 245452 RVA: 0x00F30C9C File Offset: 0x00F2EE9C
		private void OnRollbackNotify(BtRollbackNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "服务器通知回退准备时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", notify.TreeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GeneralLogicTree;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "服务器通知客户端做回退准备";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("treeConfigId", behaviorTree.TreeConfigId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.GeneralLogicTreePrepareRollback, behaviorTree.TreeConfigId);
			behaviorTree.PrepareRollback(new FailReason?(notify.FailReason), new int?(notify.FailNodeId));
		}

		// Token: 0x0603BECD RID: 245453 RVA: 0x00F30D60 File Offset: 0x00F2EF60
		private void OnBtRollbackStartNotify(BtRollbackStartNotify notify, [Nullable(2)] Net.CallbackStatus __)
		{
			if (!notify.IsRollbackSubLevel && !notify.IsRollbackPos)
			{
				return;
			}
			DelayTask task = new DelayTask("OnBtRollbackStartNotify", null, delegate()
			{
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.BehaviorTreeRollback, ELoadingPerform.CameraFade, "BehaviorTreeRollbackNotify", null, Array.Empty<object>());
				return true;
			}, 1000, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x0603BECE RID: 245454 RVA: 0x00F30DC8 File Offset: 0x00F2EFC8
		private void OnRollbackInfoNotify(BtRollbackInfoNotify notify, [Nullable(2)] Net.CallbackStatus __)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到服务器回退通知时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.BehaviorTreeRollback, "BehaviorTreeRollbackNotify", null, null);
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GeneralLogicTree;
			ELogAuthor author2 = ELogAuthor.YSQ;
			string message2 = "服务器通知行为树回退";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("treeConfigId", behaviorTree.TreeConfigId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			GeneralLogicTreeModel instance3 = ModelBase<GeneralLogicTreeModel>.Instance;
			bool flag = behaviorTree.IsTracking();
			instance3.RemoveBehaviorTree(treeIncId, ETreeRemoveReason.TreeRollback);
			BaseBehaviorTree newTree = instance3.CreateBehaviorTree(notify.TreeInfo);
			if (flag)
			{
				if (behaviorTree.BtType == BtType.LevelPlay)
				{
					ModelBase<LevelPlayModel>.Instance.SetTrackLevelPlayId(0);
				}
				else
				{
					BaseBehaviorTree newTree3 = newTree;
					if (newTree3 != null)
					{
						newTree3.SetTrack(true, ESetTrackReason.None);
					}
				}
			}
			ActionTask task = new ActionTask("OnRollbackInfoNotify", delegate()
			{
				ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.BehaviorTreeRollback, "BehaviorTreeRollbackNotify", null, null);
				EventSystem instance4 = Singleton<EventSystem>.Instance;
				EEventName name = EEventName.GeneralLogicTreePrepareRollbackFinish;
				BaseBehaviorTree newTree2 = newTree;
				instance4.Emit<int>(name, (newTree2 != null) ? newTree2.TreeConfigId : 0);
				return true;
			}, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x0603BECF RID: 245455 RVA: 0x00F30EFB File Offset: 0x00F2F0FB
		private void OnRollBackEndNotify(QuestRollBackEndNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnQuestRedDotStateChange, notify.QuestId);
		}

		// Token: 0x0603BED0 RID: 245456 RVA: 0x00F30F14 File Offset: 0x00F2F114
		private void OnBtSuspendNotify(BtSuspendNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "收到服务器挂起通知时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			behaviorTree.UpdateOccupations(notify.NodeId, notify.SuspendType, notify.OccupationInfo);
		}

		// Token: 0x0603BED1 RID: 245457 RVA: 0x00F30F88 File Offset: 0x00F2F188
		private void OnUpdateTimerInfoNotify(UpdateTimerInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "服务器通知更新定时器时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			behaviorTree.UpdateTimer(notify.TimerInfo);
		}

		// Token: 0x0603BED2 RID: 245458 RVA: 0x00F30FF0 File Offset: 0x00F2F1F0
		private void OnBtVarUpdateNotify(BtVarUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			long treeIncId = notify.TreeIncId;
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GeneralLogicTree;
				ELogAuthor author = ELogAuthor.CH;
				string message = "服务器通知更新变量时：行为树不存在，1.检查本地配置是否正确 2.服务端检查协议下发顺序";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", treeIncId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			behaviorTree.UpdateTreeVars(notify);
		}

		// Token: 0x0603BED3 RID: 245459 RVA: 0x00F31050 File Offset: 0x00F2F250
		private void OnBehaviorTreeInfoNotify(BehaviorTreeInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RepeatedField<TreeInfo> treeInfos = notify.TreeInfos;
			if (treeInfos == null || treeInfos.Count == 0)
			{
				return;
			}
			foreach (TreeInfo treeInfo in treeInfos)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.CreateBehaviorTree(treeInfo);
			}
		}

		// Token: 0x0603BED4 RID: 245460 RVA: 0x00F310B0 File Offset: 0x00F2F2B0
		private void OnBehaviorTreeDeleteNotify(BehaviorTreeDeleteNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RepeatedField<long> treeIncIds = notify.TreeIncIds;
			if (treeIncIds == null || treeIncIds.Count == 0)
			{
				return;
			}
			foreach (long treeId in treeIncIds)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.RemoveBehaviorTree(treeId, ETreeRemoveReason.TreeDestroy);
			}
		}

		// Token: 0x0603BED5 RID: 245461 RVA: 0x00F31114 File Offset: 0x00F2F314
		private void OnGmStateNotify(AutoQuestNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<AutoRunModel>.Instance.ShouldFastSkip = notify.IsAuto;
			ModelBase<AutoRunModel>.Instance.SetAutoRunMode(notify.IsAuto ? EAutoRunMode.ServerControlledSkip : EAutoRunMode.Disabled, BtType.Invalid, 0, 0);
			ModelBase<AutoRunModel>.Instance.SetAutoRunState(notify.IsAuto ? EAutoRunState.Running : EAutoRunState.Stopped);
		}

		// Token: 0x0603BED6 RID: 245462 RVA: 0x00F31160 File Offset: 0x00F2F360
		private void OnActionOpenSystemBoardNotify(ActionOpenSystemBoardNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			if (valueOrDefault != 0 && notify.PlayerId != valueOrDefault)
			{
				return;
			}
			ActionOpenSystemParam protoParams = notify.Param;
			if (protoParams == null)
			{
				return;
			}
			switch (protoParams.ActionOpenType)
			{
			case ActionOpenSystemType.ActionOpenSystem:
			{
				OpenSystemBoardData openSystemBoardData = protoParams.OpenSystemBoardData;
				if (openSystemBoardData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.GeneralLogicTree, ELogAuthor.YSQ, "ActionOpenSystemBoardNotify:打开带返回值的确认框时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((EConfirmBoxConfigId)openSystemBoardData.BoardId);
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					this.OpenSystemBoardResultRequest(0, protoParams.IncId);
				};
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					this.OpenSystemBoardResultRequest(1, protoParams.IncId);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			case ActionOpenSystemType.SoaringChallenge:
			{
				SoaringChallengeData soaringChallengeData = protoParams.SoaringChallengeData;
				if (soaringChallengeData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.GeneralLogicTree, ELogAuthor.YSQ, "ActionOpenSystemBoardNotify:打开翱翔结算时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				FlySettlementViewParams param = new FlySettlementViewParams(soaringChallengeData.Score, soaringChallengeData.RankS, soaringChallengeData.RankA, soaringChallengeData.RankB, ModelBase<GeneralLogicTreeModel>.Instance.HistorySoarScore, protoParams.IncId);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FlySettlementView, param, null);
				return;
			}
			case ActionOpenSystemType.FishingHandIn:
			{
				FishingHandInData fishingHandInData = protoParams.FishingHandInData;
				if (fishingHandInData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.GeneralLogicTree, ELogAuthor.XXJ, "ActionOpenSystemBoardNotify:打开捕鱼交付界面时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				ControllerBase<FishingController>.Instance.OpenDockyardInteractView(fishingHandInData.HandInId, protoParams.IncId);
				return;
			}
			case ActionOpenSystemType.GreatSwordChallenge:
			{
				GreatSwordChallengeData greatSwordChallengeData = protoParams.GreatSwordChallengeData;
				if (greatSwordChallengeData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.GeneralLogicTree, ELogAuthor.WMQ, "ActionOpenSystemBoardNotify:打开大剑挑战时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				ControllerBase<GreatSwordController>.Instance.RequestGreatSwordInfoAndOpenView(greatSwordChallengeData.Id, protoParams.IncId);
				return;
			}
			case ActionOpenSystemType.InfrHandIn:
			{
				InfrHandInData infrHandInData = protoParams.InfrHandInData;
				if (infrHandInData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.LYX, "ActionOpenSystemBoardNotify:打开基建交付时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (ModelBase<CreatureModel>.Instance.GetIsLoadingScene())
				{
					ControllerBase<GeneralLogicTreeController>.Instance.OpenSystemBoardResultRequest(0, protoParams.IncId);
					return;
				}
				ControllerBase<InfrastructureController>.Instance.OpenMaterialDelivery(infrHandInData.Type, infrHandInData.Id, protoParams.IncId, InfrastructureDefine.EMaterialDeliveryOpenSource.BigWorld);
				return;
			}
			case ActionOpenSystemType.MotorRaceChallenge:
			{
				MotorRaceChallengeData motorRaceChallengeData = protoParams.MotorRaceChallengeData;
				if (motorRaceChallengeData == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Infrastructure, ELogAuthor.CXJ, "ActionOpenSystemBoardNotify:打开摩托模拟赛结算时，服务端下发参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				MotorSettlementViewParams param2 = new MotorSettlementViewParams(motorRaceChallengeData.Score, motorRaceChallengeData.RankS, motorRaceChallengeData.RankA, motorRaceChallengeData.RankB, (long)protoParams.IncId);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorRaceSettlementView, param2, null);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603BED7 RID: 245463 RVA: 0x00F31464 File Offset: 0x00F2F664
		public void OpenSystemBoardResultRequest(int result, int incId)
		{
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			OpenSystemBoardResultRequest openSystemBoardResultRequest = Aki.Protocol.OpenSystemBoardResultRequest.Create();
			openSystemBoardResultRequest.PlayerId = valueOrDefault;
			openSystemBoardResultRequest.Result = result;
			openSystemBoardResultRequest.IncId = incId;
			Singleton<Net>.Instance.Call<OpenSystemBoardResultResponse>(ERequestMessageId.OpenSystemBoardResultRequest, openSystemBoardResultRequest, delegate(OpenSystemBoardResultResponse response, Net.CallbackStatus _)
			{
				if (response.Code != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 25764, null, false, true);
				}
			}, 0);
		}
	}
}
