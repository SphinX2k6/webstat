using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200606C RID: 24684
	[NullableContext(1)]
	[Nullable(0)]
	public class PendingProcessController : MissionPanelControllerBase
	{
		// Token: 0x0603E3F9 RID: 254969 RVA: 0x00FE4098 File Offset: 0x00FE2298
		public PendingProcessController(Func<bool> checkDeleteSameTreeHandle, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<MissionItemViewStartTrackProcess, UniTask<bool>> missionItemViewStartTrackHandle, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<MissionItemViewEndTrackProcess, UniTask<bool>> missionItemViewEndTrackHandle, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<MissionItemViewRefreshProcess, UniTask<bool>> missionItemViewRefreshHandle, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<ShowQuestUpdateTipsProcess, UniTask<bool>> showQuestUpdateTipsHandle, [Nullable(new byte[]
		{
			1,
			1,
			0
		})] Func<StepConditionIndexChangeProcess, UniTask<bool>> stepConditionIndexChange)
		{
		}

		// Token: 0x17009ACA RID: 39626
		// (get) Token: 0x0603E3FA RID: 254970 RVA: 0x00FE40EF File Offset: 0x00FE22EF
		protected override EMissionPanelControllerType ControllerType
		{
			get
			{
				return EMissionPanelControllerType.PendingProcessController;
			}
		}

		// Token: 0x0603E3FB RID: 254971 RVA: 0x00FE40F2 File Offset: 0x00FE22F2
		public override void OnDestroy()
		{
			this.CurProcess = null;
			this.ProcessQueue.Clear();
			this.AddToFirstProcessQueue.Clear();
		}

		// Token: 0x0603E3FC RID: 254972 RVA: 0x00FE4114 File Offset: 0x00FE2314
		public override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, new Action<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(this.BehaviorTreeStartShow));
			Singleton<EventSystem>.Instance.Add<FishingEntrustViewShowData, ETreeTextExpressReason>(EEventName.FishingEntrustStartShowTrackText, new Action<FishingEntrustViewShowData, ETreeTextExpressReason>(this.FishingEntrustStartShow));
			Singleton<EventSystem>.Instance.Add<int, ETreeTextExpressReason>(EEventName.FishingEntrustEndShowTrackText, new Action<int, ETreeTextExpressReason>(this.FishingEntrustEndShow));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Add<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, new Action<long, ETreeTextExpressReason, bool>(this.BehaviorTreeEndShow));
			Singleton<EventSystem>.Instance.Add<BehaviorTreeViewShowData, bool>(EEventName.GeneralLogicTreeUpdateShowTrackText, new Action<BehaviorTreeViewShowData, bool>(this.OnLogicTreeUpdateShow));
			Singleton<EventSystem>.Instance.Add<QuestUpdateTipsShowData>(EEventName.QuestUpdateInfoAdd, new Action<QuestUpdateTipsShowData>(this.ShowQuestUpdateTips));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFishingSailing, new Action<int>(this.OnFishingSailing));
			Singleton<EventSystem>.Instance.Add<EMissionItemView, int, int?>(EEventName.MissionPanelStepConditionIndexChange, new Action<EMissionItemView, int, int?>(this.OnStepConditionIndexChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.FocusQuestChange, new Action<int>(this.OnFocusQuestChange));
		}

		// Token: 0x0603E3FD RID: 254973 RVA: 0x00FE423C File Offset: 0x00FE243C
		public override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, new Action<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(this.BehaviorTreeStartShow));
			Singleton<EventSystem>.Instance.Remove<FishingEntrustViewShowData, ETreeTextExpressReason>(EEventName.FishingEntrustStartShowTrackText, new Action<FishingEntrustViewShowData, ETreeTextExpressReason>(this.FishingEntrustStartShow));
			Singleton<EventSystem>.Instance.Remove<int, ETreeTextExpressReason>(EEventName.FishingEntrustEndShowTrackText, new Action<int, ETreeTextExpressReason>(this.FishingEntrustEndShow));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Remove<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, new Action<long, ETreeTextExpressReason, bool>(this.BehaviorTreeEndShow));
			Singleton<EventSystem>.Instance.Remove<BehaviorTreeViewShowData, bool>(EEventName.GeneralLogicTreeUpdateShowTrackText, new Action<BehaviorTreeViewShowData, bool>(this.OnLogicTreeUpdateShow));
			Singleton<EventSystem>.Instance.Remove<QuestUpdateTipsShowData>(EEventName.QuestUpdateInfoAdd, new Action<QuestUpdateTipsShowData>(this.ShowQuestUpdateTips));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnFishingSailing, new Action<int>(this.OnFishingSailing));
			Singleton<EventSystem>.Instance.Remove<EMissionItemView, int, int?>(EEventName.MissionPanelStepConditionIndexChange, new Action<EMissionItemView, int, int?>(this.OnStepConditionIndexChange));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.FocusQuestChange, new Action<int>(this.OnFocusQuestChange));
		}

		// Token: 0x0603E3FE RID: 254974 RVA: 0x00FE4361 File Offset: 0x00FE2561
		private void OnDriveFishingShipStateChanged(bool isDriving)
		{
			if (isDriving)
			{
				ModelBase<FishingQuestModel>.Instance.StartShowTrackText(ModelBase<FishingQuestModel>.Instance.CurrentTraceEntrust, ETreeTextExpressReason.DrivingStateChange);
				return;
			}
			this.FishingEntrustEndShow(this.FishingEntrustViewShowId, ETreeTextExpressReason.DrivingStateChange);
		}

		// Token: 0x0603E3FF RID: 254975 RVA: 0x00FE4389 File Offset: 0x00FE2589
		private void OnFishingSailing(int id)
		{
			this.FishingEntrustEndShow(this.FishingEntrustViewShowId, ETreeTextExpressReason.OnFishingSailing);
			if (id > 0)
			{
				ModelBase<FishingQuestModel>.Instance.StartShowTrackText(id, ETreeTextExpressReason.OnFishingSailing);
			}
		}

		// Token: 0x0603E400 RID: 254976 RVA: 0x00FE43A8 File Offset: 0x00FE25A8
		public void FishingEntrustStartShow(FishingEntrustViewShowData showData, ETreeTextExpressReason reason)
		{
			if (!ModelBase<FishingModel>.Instance.GetShipData().IsShipDriving())
			{
				return;
			}
			if (reason - ETreeTextExpressReason.DrivingStateChange > 1 && Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FishingDockView) != null)
			{
				return;
			}
			bool isSkipAnim = ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
			if ((long)this.FishingEntrustViewShowId == showData.Id)
			{
				this.AddNewProcess(new MissionItemViewRefreshProcess(showData, isSkipAnim));
			}
			else
			{
				this.AddNewProcess(new MissionItemViewStartTrackProcess(showData, reason, isSkipAnim));
			}
			this.FishingEntrustViewShowId = (int)showData.Id;
		}

		// Token: 0x0603E401 RID: 254977 RVA: 0x00FE4428 File Offset: 0x00FE2628
		private void FishingEntrustEndShow(int id, ETreeTextExpressReason reason)
		{
			bool isSkipAnim = ModelBase<AutoRunModel>.Instance.GetAutoRunMode() > EAutoRunMode.Disabled;
			if (reason != ETreeTextExpressReason.DrivingStateChange)
			{
				if (reason == ETreeTextExpressReason.OnFishingSailing)
				{
					isSkipAnim = true;
				}
				else if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FishingDockView) != null)
				{
					return;
				}
			}
			this.AddNewProcess(new MissionItemViewEndTrackProcess((long)id, (int)reason, isSkipAnim));
			this.FishingEntrustViewShowId = 0;
		}

		// Token: 0x0603E402 RID: 254978 RVA: 0x00FE4478 File Offset: 0x00FE2678
		public void BehaviorTreeStartShow(BehaviorTreeViewShowData showData, ETreeTextExpressReason reason, bool bSkipAnim)
		{
			if (this.<checkDeleteSameTreeHandle>P())
			{
				this.DeleteSameTreeProcess(showData.Id);
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(showData.Id), false);
			if (behaviorTree != null && behaviorTree.GetBlackBoard().ContainTag(EBehaviorTreeTag.BindingLevelPlayTrack))
			{
				this.DeleteSameTreeProcess(showData.Id);
			}
			this.AddNewProcess(new MissionItemViewStartTrackProcess(showData, reason, bSkipAnim));
		}

		// Token: 0x0603E403 RID: 254979 RVA: 0x00FE44E4 File Offset: 0x00FE26E4
		private void BehaviorTreeEndShow(long treeIncId, ETreeTextExpressReason reason, bool bSkipAnim)
		{
			if (this.<checkDeleteSameTreeHandle>P())
			{
				this.DeleteSameTreeProcess(treeIncId);
			}
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
			if (behaviorTree != null && behaviorTree.GetBlackBoard().ContainTag(EBehaviorTreeTag.BindingLevelPlayTrack))
			{
				this.DeleteSameTreeProcess(treeIncId);
			}
			this.AddNewProcess(new MissionItemViewEndTrackProcess(treeIncId, (int)reason, bSkipAnim));
		}

		// Token: 0x0603E404 RID: 254980 RVA: 0x00FE4540 File Offset: 0x00FE2740
		private void DeleteSameTreeProcess(long id)
		{
			if (this.ProcessQueue.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.ProcessQueue.Count; i++)
			{
				TPendingProcess tpendingProcess = this.ProcessQueue[i];
				bool flag = false;
				MissionItemViewStartTrackProcess missionItemViewStartTrackProcess = tpendingProcess as MissionItemViewStartTrackProcess;
				if (missionItemViewStartTrackProcess == null)
				{
					MissionItemViewRefreshProcess missionItemViewRefreshProcess = tpendingProcess as MissionItemViewRefreshProcess;
					if (missionItemViewRefreshProcess == null)
					{
						MissionItemViewEndTrackProcess missionItemViewEndTrackProcess = tpendingProcess as MissionItemViewEndTrackProcess;
						if (missionItemViewEndTrackProcess == null)
						{
							ShowQuestUpdateTipsProcess showQuestUpdateTipsProcess = tpendingProcess as ShowQuestUpdateTipsProcess;
							if (showQuestUpdateTipsProcess != null)
							{
								flag = (showQuestUpdateTipsProcess.Info.MissionViewShowData.Id == id);
							}
						}
						else
						{
							flag = (missionItemViewEndTrackProcess.Id == id);
						}
					}
					else
					{
						flag = (missionItemViewRefreshProcess.ShowData.Id == id);
					}
				}
				else
				{
					flag = (missionItemViewStartTrackProcess.ShowData.Id == id);
				}
				bool flag2 = this.CurProcess != null && this.CurProcess.ProcessId == tpendingProcess.ProcessId;
				if (flag && !flag2)
				{
					this.ProcessQueue.RemoveAt(i);
				}
			}
		}

		// Token: 0x0603E405 RID: 254981 RVA: 0x00FE462F File Offset: 0x00FE282F
		private void OnLogicTreeUpdateShow(BehaviorTreeViewShowData showData, bool bSkipAnim)
		{
			this.AddNewProcess(new MissionItemViewRefreshProcess(showData, bSkipAnim));
		}

		// Token: 0x0603E406 RID: 254982 RVA: 0x00FE463E File Offset: 0x00FE283E
		private void ShowQuestUpdateTips(QuestUpdateTipsShowData info)
		{
			this.AddNewProcess(new ShowQuestUpdateTipsProcess(info));
		}

		// Token: 0x0603E407 RID: 254983 RVA: 0x00FE464C File Offset: 0x00FE284C
		private void OnStepConditionIndexChange(EMissionItemView viewId, int stepId, int? curConditionTextIndex)
		{
			this.AddNewProcessToFirst(new StepConditionIndexChangeProcess(viewId, stepId, curConditionTextIndex));
		}

		// Token: 0x0603E408 RID: 254984 RVA: 0x00FE465C File Offset: 0x00FE285C
		private void OnFocusQuestChange(int questId)
		{
			if (questId == 0 || this.ProcessQueue.Count == 0)
			{
				return;
			}
			for (int i = this.ProcessQueue.Count - 1; i >= 0; i--)
			{
				TPendingProcess tpendingProcess = this.ProcessQueue[i];
				ShowQuestUpdateTipsProcess showQuestUpdateTipsProcess = tpendingProcess as ShowQuestUpdateTipsProcess;
				if (showQuestUpdateTipsProcess != null && questId != showQuestUpdateTipsProcess.Info.QuestId && this.CurProcess != tpendingProcess)
				{
					this.ProcessQueue.RemoveAt(i);
				}
			}
		}

		// Token: 0x0603E409 RID: 254985 RVA: 0x00FE46CC File Offset: 0x00FE28CC
		private void AddNewProcess(TPendingProcess processInfo)
		{
			foreach (PendingProcessControllerRuleConfigBase pendingProcessControllerRuleConfigBase in Singleton<PendingProcessControllerRuleConfigInstance>.Instance.PendingProcessExCheckList)
			{
				if (pendingProcessControllerRuleConfigBase.IsActive() && !pendingProcessControllerRuleConfigBase.PendingProgressExCheck(processInfo))
				{
					return;
				}
			}
			this.ProcessQueue.Add(processInfo);
		}

		// Token: 0x0603E40A RID: 254986 RVA: 0x00FE4738 File Offset: 0x00FE2938
		private void AddNewProcessToFirst(TPendingProcess processInfo)
		{
			if (this.CurProcess != null)
			{
				this.AddToFirstProcessQueue.Push(processInfo);
				return;
			}
			this.ProcessQueue.Insert(0, processInfo);
		}

		// Token: 0x0603E40B RID: 254987 RVA: 0x00FE475C File Offset: 0x00FE295C
		public UniTask ProcessCacheList()
		{
			PendingProcessController.<ProcessCacheList>d__29 <ProcessCacheList>d__;
			<ProcessCacheList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessCacheList>d__.<>4__this = this;
			<ProcessCacheList>d__.<>1__state = -1;
			<ProcessCacheList>d__.<>t__builder.Start<PendingProcessController.<ProcessCacheList>d__29>(ref <ProcessCacheList>d__);
			return <ProcessCacheList>d__.<>t__builder.Task;
		}

		// Token: 0x0603E40C RID: 254988 RVA: 0x00FE479F File Offset: 0x00FE299F
		[NullableContext(2)]
		public TPendingProcess GetCurrentProcess()
		{
			return this.CurProcess;
		}

		// Token: 0x04022E4B RID: 142923
		[CompilerGenerated]
		private Func<bool> <checkDeleteSameTreeHandle>P = checkDeleteSameTreeHandle;

		// Token: 0x04022E4C RID: 142924
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[CompilerGenerated]
		private Func<MissionItemViewStartTrackProcess, UniTask<bool>> <missionItemViewStartTrackHandle>P = missionItemViewStartTrackHandle;

		// Token: 0x04022E4D RID: 142925
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[CompilerGenerated]
		private Func<MissionItemViewEndTrackProcess, UniTask<bool>> <missionItemViewEndTrackHandle>P = missionItemViewEndTrackHandle;

		// Token: 0x04022E4E RID: 142926
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[CompilerGenerated]
		private Func<MissionItemViewRefreshProcess, UniTask<bool>> <missionItemViewRefreshHandle>P = missionItemViewRefreshHandle;

		// Token: 0x04022E4F RID: 142927
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[CompilerGenerated]
		private Func<ShowQuestUpdateTipsProcess, UniTask<bool>> <showQuestUpdateTipsHandle>P = showQuestUpdateTipsHandle;

		// Token: 0x04022E50 RID: 142928
		[Nullable(new byte[]
		{
			1,
			1,
			0
		})]
		[CompilerGenerated]
		private Func<StepConditionIndexChangeProcess, UniTask<bool>> <stepConditionIndexChange>P = stepConditionIndexChange;

		// Token: 0x04022E51 RID: 142929
		private readonly List<TPendingProcess> ProcessQueue = new List<TPendingProcess>();

		// Token: 0x04022E52 RID: 142930
		private readonly Queue<TPendingProcess> AddToFirstProcessQueue = new Queue<TPendingProcess>(4);

		// Token: 0x04022E53 RID: 142931
		[Nullable(2)]
		private TPendingProcess CurProcess;

		// Token: 0x04022E54 RID: 142932
		private int FishingEntrustViewShowId;
	}
}
