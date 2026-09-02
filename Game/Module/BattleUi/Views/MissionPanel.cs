using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA5 RID: 24485
	public class MissionPanel : BattleChildViewPanel
	{
		// Token: 0x0603D870 RID: 252016 RVA: 0x00FAA294 File Offset: 0x00FA8494
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D871 RID: 252017 RVA: 0x00FAA340 File Offset: 0x00FA8540
		public override UniTask InitializeAsync()
		{
			MissionPanel.<InitializeAsync>d__8 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<MissionPanel.<InitializeAsync>d__8>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D872 RID: 252018 RVA: 0x00FAA384 File Offset: 0x00FA8584
		private UniTask InitMissionItemView()
		{
			MissionPanel.<InitMissionItemView>d__9 <InitMissionItemView>d__;
			<InitMissionItemView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMissionItemView>d__.<>4__this = this;
			<InitMissionItemView>d__.<>1__state = -1;
			<InitMissionItemView>d__.<>t__builder.Start<MissionPanel.<InitMissionItemView>d__9>(ref <InitMissionItemView>d__);
			return <InitMissionItemView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D873 RID: 252019 RVA: 0x00FAA3C8 File Offset: 0x00FA85C8
		private void RestoreMissionViewItemByData()
		{
			Dictionary<EMissionItemView, IMissionItemViewShowData> allMissionViewData = ModelBase<BattleUiModel>.Instance.GetAllMissionViewData();
			PendingProcessController pendingProcessController = this.Controllers[0] as PendingProcessController;
			if (allMissionViewData != null)
			{
				foreach (IMissionItemViewShowData missionItemViewShowData in allMissionViewData.Values)
				{
					EMissionItemViewDataSource dataSource = missionItemViewShowData.DataSource;
					if (dataSource != EMissionItemViewDataSource.BehaviorTree)
					{
						if (dataSource == EMissionItemViewDataSource.FishingEntrust)
						{
							pendingProcessController.FishingEntrustStartShow((FishingEntrustViewShowData)missionItemViewShowData, ETreeTextExpressReason.None);
						}
					}
					else
					{
						pendingProcessController.BehaviorTreeStartShow((BehaviorTreeViewShowData)missionItemViewShowData, ETreeTextExpressReason.None, true);
					}
				}
			}
		}

		// Token: 0x0603D874 RID: 252020 RVA: 0x00FAA460 File Offset: 0x00FA8660
		public void SetRestoreWhenInit(bool restoreWhenInit)
		{
			this.RestoreWhenInit = restoreWhenInit;
		}

		// Token: 0x0603D875 RID: 252021 RVA: 0x00FAA46C File Offset: 0x00FA866C
		private UniTask AddControllers()
		{
			MissionPanel.<AddControllers>d__12 <AddControllers>d__;
			<AddControllers>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AddControllers>d__.<>4__this = this;
			<AddControllers>d__.<>1__state = -1;
			<AddControllers>d__.<>t__builder.Start<MissionPanel.<AddControllers>d__12>(ref <AddControllers>d__);
			return <AddControllers>d__.<>t__builder.Task;
		}

		// Token: 0x0603D876 RID: 252022 RVA: 0x00FAA4AF File Offset: 0x00FA86AF
		private bool CheckDeleteSameTreeHandle()
		{
			return !base.GetActive();
		}

		// Token: 0x0603D877 RID: 252023 RVA: 0x00FAA4BC File Offset: 0x00FA86BC
		public override void Reset()
		{
			this.PendingShowViewsMap.Clear();
			MissionViewItem[] missionItemViews = this.MissionItemViews;
			for (int i = 0; i < missionItemViews.Length; i++)
			{
				missionItemViews[i].Destroy(null);
			}
			Array.Clear(this.MissionItemViews);
			MissionPanelControllerBase[] controllers = this.Controllers;
			for (int i = 0; i < controllers.Length; i++)
			{
				controllers[i].OnDestroy();
			}
			base.Reset();
		}

		// Token: 0x0603D878 RID: 252024 RVA: 0x00FAA520 File Offset: 0x00FA8720
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			MissionViewItem[] missionItemViews = this.MissionItemViews;
			for (int i = 0; i < missionItemViews.Length; i++)
			{
				missionItemViews[i].OnPanelShow();
			}
			((QuestUpdateTipsController)this.Controllers[1]).OnPanelShow();
		}

		// Token: 0x0603D879 RID: 252025 RVA: 0x00FAA55C File Offset: 0x00FA875C
		protected override void OnHideBattleChildViewPanel()
		{
			MissionViewItem[] missionItemViews = this.MissionItemViews;
			for (int i = 0; i < missionItemViews.Length; i++)
			{
				missionItemViews[i].OnPanelHide();
			}
			((QuestUpdateTipsController)this.Controllers[1]).OnPanelHide();
		}

		// Token: 0x0603D87A RID: 252026 RVA: 0x00FAA598 File Offset: 0x00FA8798
		protected override void AddEvents()
		{
			MissionPanelControllerBase[] controllers = this.Controllers;
			for (int i = 0; i < controllers.Length; i++)
			{
				controllers[i].AddEvents();
			}
			Singleton<EventSystem>.Instance.Add(EEventName.QuestUpdateTipsEndSequenceStart, new Action(this.OnQuestUpdateTipsEndSequenceStart));
			Singleton<EventSystem>.Instance.Add(EEventName.MissionTrackRuleChange, new Action(this.OnMissionTrackRuleChange));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x0603D87B RID: 252027 RVA: 0x00FAA618 File Offset: 0x00FA8818
		protected override void RemoveEvents()
		{
			MissionPanelControllerBase[] controllers = this.Controllers;
			for (int i = 0; i < controllers.Length; i++)
			{
				controllers[i].RemoveEvents();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.QuestUpdateTipsEndSequenceStart, new Action(this.OnQuestUpdateTipsEndSequenceStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.MissionTrackRuleChange, new Action(this.OnMissionTrackRuleChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		}

		// Token: 0x0603D87C RID: 252028 RVA: 0x00FAA696 File Offset: 0x00FA8896
		public override void OnTickBattleChildViewPanel(float delta)
		{
			if (!ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
			{
				return;
			}
			((PendingProcessController)this.Controllers[0]).ProcessCacheList().Forget();
			this.TreeViewTick(delta);
		}

		// Token: 0x0603D87D RID: 252029 RVA: 0x00FAA6C4 File Offset: 0x00FA88C4
		private void TreeViewTick(float delta)
		{
			if (this.MissionItemViews[0] == null)
			{
				return;
			}
			TPendingProcess currentProcess = ((PendingProcessController)this.Controllers[0]).GetCurrentProcess();
			MissionViewItem[] missionItemViews = this.MissionItemViews;
			for (int i = 0; i < missionItemViews.Length; i++)
			{
				missionItemViews[i].OnRefresh(delta, (currentProcess != null) ? currentProcess.ProcessId : 0);
			}
		}

		// Token: 0x0603D87E RID: 252030 RVA: 0x00FAA71C File Offset: 0x00FA891C
		private UniTask<bool> MissionItemViewStartTrackHandle([Nullable(1)] MissionItemViewStartTrackProcess processInfo)
		{
			MissionPanel.<MissionItemViewStartTrackHandle>d__21 <MissionItemViewStartTrackHandle>d__;
			<MissionItemViewStartTrackHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MissionItemViewStartTrackHandle>d__.<>4__this = this;
			<MissionItemViewStartTrackHandle>d__.processInfo = processInfo;
			<MissionItemViewStartTrackHandle>d__.<>1__state = -1;
			<MissionItemViewStartTrackHandle>d__.<>t__builder.Start<MissionPanel.<MissionItemViewStartTrackHandle>d__21>(ref <MissionItemViewStartTrackHandle>d__);
			return <MissionItemViewStartTrackHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D87F RID: 252031 RVA: 0x00FAA768 File Offset: 0x00FA8968
		private UniTask<bool> MissionItemViewRefreshHandle([Nullable(1)] MissionItemViewRefreshProcess process)
		{
			MissionPanel.<MissionItemViewRefreshHandle>d__22 <MissionItemViewRefreshHandle>d__;
			<MissionItemViewRefreshHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MissionItemViewRefreshHandle>d__.<>4__this = this;
			<MissionItemViewRefreshHandle>d__.process = process;
			<MissionItemViewRefreshHandle>d__.<>1__state = -1;
			<MissionItemViewRefreshHandle>d__.<>t__builder.Start<MissionPanel.<MissionItemViewRefreshHandle>d__22>(ref <MissionItemViewRefreshHandle>d__);
			return <MissionItemViewRefreshHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D880 RID: 252032 RVA: 0x00FAA7B4 File Offset: 0x00FA89B4
		private UniTask<bool> MissionItemViewEndTrackHandle([Nullable(1)] MissionItemViewEndTrackProcess processInfo)
		{
			MissionPanel.<MissionItemViewEndTrackHandle>d__23 <MissionItemViewEndTrackHandle>d__;
			<MissionItemViewEndTrackHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<MissionItemViewEndTrackHandle>d__.<>4__this = this;
			<MissionItemViewEndTrackHandle>d__.processInfo = processInfo;
			<MissionItemViewEndTrackHandle>d__.<>1__state = -1;
			<MissionItemViewEndTrackHandle>d__.<>t__builder.Start<MissionPanel.<MissionItemViewEndTrackHandle>d__23>(ref <MissionItemViewEndTrackHandle>d__);
			return <MissionItemViewEndTrackHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D881 RID: 252033 RVA: 0x00FAA800 File Offset: 0x00FA8A00
		private UniTask<bool> CheckPendingShowViews(EMissionItemView viewType, [Nullable(1)] MissionItemViewEndTrackProcess processInfo)
		{
			MissionPanel.<CheckPendingShowViews>d__24 <CheckPendingShowViews>d__;
			<CheckPendingShowViews>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckPendingShowViews>d__.<>4__this = this;
			<CheckPendingShowViews>d__.viewType = viewType;
			<CheckPendingShowViews>d__.processInfo = processInfo;
			<CheckPendingShowViews>d__.<>1__state = -1;
			<CheckPendingShowViews>d__.<>t__builder.Start<MissionPanel.<CheckPendingShowViews>d__24>(ref <CheckPendingShowViews>d__);
			return <CheckPendingShowViews>d__.<>t__builder.Task;
		}

		// Token: 0x0603D882 RID: 252034 RVA: 0x00FAA854 File Offset: 0x00FA8A54
		[NullableContext(1)]
		private void UpdatePendingShowViews(IMissionItemViewShowData showData)
		{
			foreach (KeyValuePair<EMissionItemView, List<IMissionItemViewShowData>> keyValuePair in this.PendingShowViewsMap)
			{
				EMissionItemView emissionItemView;
				List<IMissionItemViewShowData> list;
				keyValuePair.Deconstruct(out emissionItemView, out list);
				EMissionItemView viewType = emissionItemView;
				List<IMissionItemViewShowData> list2 = list;
				int num = this.FindInPendingViewIndex(viewType, showData.Id);
				if (num >= 1)
				{
					list2[num] = showData;
				}
			}
		}

		// Token: 0x0603D883 RID: 252035 RVA: 0x00FAA8D0 File Offset: 0x00FA8AD0
		private int FindInPendingViewIndex(EMissionItemView viewType, long id)
		{
			List<IMissionItemViewShowData> list;
			if (this.PendingShowViewsMap.TryGetValue(viewType, out list))
			{
				return list.FindIndex((IMissionItemViewShowData value) => value.Id == id);
			}
			return -1;
		}

		// Token: 0x0603D884 RID: 252036 RVA: 0x00FAA910 File Offset: 0x00FA8B10
		private UniTask<bool> TryUsePendingViewShow(EMissionItemView viewType, int processId, [Nullable(1)] IMissionItemViewShowData showData, bool bSkipAnim)
		{
			MissionPanel.<TryUsePendingViewShow>d__27 <TryUsePendingViewShow>d__;
			<TryUsePendingViewShow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryUsePendingViewShow>d__.<>4__this = this;
			<TryUsePendingViewShow>d__.viewType = viewType;
			<TryUsePendingViewShow>d__.processId = processId;
			<TryUsePendingViewShow>d__.showData = showData;
			<TryUsePendingViewShow>d__.bSkipAnim = bSkipAnim;
			<TryUsePendingViewShow>d__.<>1__state = -1;
			<TryUsePendingViewShow>d__.<>t__builder.Start<MissionPanel.<TryUsePendingViewShow>d__27>(ref <TryUsePendingViewShow>d__);
			return <TryUsePendingViewShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603D885 RID: 252037 RVA: 0x00FAA974 File Offset: 0x00FA8B74
		private UniTask<bool> UpdatePendingShowView(EMissionItemView viewType, int processId, bool bSkipAnim)
		{
			MissionPanel.<UpdatePendingShowView>d__28 <UpdatePendingShowView>d__;
			<UpdatePendingShowView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdatePendingShowView>d__.<>4__this = this;
			<UpdatePendingShowView>d__.viewType = viewType;
			<UpdatePendingShowView>d__.processId = processId;
			<UpdatePendingShowView>d__.bSkipAnim = bSkipAnim;
			<UpdatePendingShowView>d__.<>1__state = -1;
			<UpdatePendingShowView>d__.<>t__builder.Start<MissionPanel.<UpdatePendingShowView>d__28>(ref <UpdatePendingShowView>d__);
			return <UpdatePendingShowView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D886 RID: 252038 RVA: 0x00FAA9D0 File Offset: 0x00FA8BD0
		private UniTask<bool> ShowQuestUpdateTipsHandle([Nullable(1)] ShowQuestUpdateTipsProcess process)
		{
			MissionPanel.<ShowQuestUpdateTipsHandle>d__29 <ShowQuestUpdateTipsHandle>d__;
			<ShowQuestUpdateTipsHandle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowQuestUpdateTipsHandle>d__.<>4__this = this;
			<ShowQuestUpdateTipsHandle>d__.process = process;
			<ShowQuestUpdateTipsHandle>d__.<>1__state = -1;
			<ShowQuestUpdateTipsHandle>d__.<>t__builder.Start<MissionPanel.<ShowQuestUpdateTipsHandle>d__29>(ref <ShowQuestUpdateTipsHandle>d__);
			return <ShowQuestUpdateTipsHandle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D887 RID: 252039 RVA: 0x00FAAA1C File Offset: 0x00FA8C1C
		private UniTask<bool> StepConditionIndexChange([Nullable(1)] StepConditionIndexChangeProcess process)
		{
			MissionPanel.<StepConditionIndexChange>d__30 <StepConditionIndexChange>d__;
			<StepConditionIndexChange>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StepConditionIndexChange>d__.<>4__this = this;
			<StepConditionIndexChange>d__.process = process;
			<StepConditionIndexChange>d__.<>1__state = -1;
			<StepConditionIndexChange>d__.<>t__builder.Start<MissionPanel.<StepConditionIndexChange>d__30>(ref <StepConditionIndexChange>d__);
			return <StepConditionIndexChange>d__.<>t__builder.Task;
		}

		// Token: 0x0603D888 RID: 252040 RVA: 0x00FAAA68 File Offset: 0x00FA8C68
		private bool CheckMissionItemViewShowEmptyHandle()
		{
			for (int i = 0; i < this.MissionItemViews.Length; i++)
			{
				MissionViewItem missionViewItem = this.MissionItemViews[i];
				Dictionary<EMissionItemView, bool> isShowingMissionViewItems = ModelBase<BattleUiModel>.Instance.IsShowingMissionViewItems;
				if (((isShowingMissionViewItems != null) ? new bool?(isShowingMissionViewItems.GetValueOrDefault((EMissionItemView)i)) : null).GetValueOrDefault() && missionViewItem.CheckVisible())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603D889 RID: 252041 RVA: 0x00FAAACC File Offset: 0x00FA8CCC
		private void OnQuestUpdateTipsEndSequenceStart()
		{
			TPendingProcess currentProcess = ((PendingProcessController)this.Controllers[0]).GetCurrentProcess();
			if (currentProcess == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Quest, ELogAuthor.YSQ, "MissionPanel:任务更新提示结束动画开始时找不到当前正在处理的操作", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ShowQuestUpdateTipsProcess showQuestUpdateTipsProcess = currentProcess as ShowQuestUpdateTipsProcess;
			if (showQuestUpdateTipsProcess == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "MissionPanel:任务更新提示结束动画开始时当前正在处理的操作类型异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("processType", currentProcess.ProcessType);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.UpdatePendingShowViews(showQuestUpdateTipsProcess.Info.MissionViewShowData);
		}

		// Token: 0x0603D88A RID: 252042 RVA: 0x00FAAB59 File Offset: 0x00FA8D59
		private void OnMissionTrackRuleChange()
		{
			this.RestoreMissionViewItemByData();
		}

		// Token: 0x0603D88B RID: 252043 RVA: 0x00FAAB61 File Offset: 0x00FA8D61
		private void OnWorldDoneAndCloseLoading()
		{
			ModelBase<BattleUiModel>.Instance.CheckAndUpdateRule();
		}

		// Token: 0x0603D88C RID: 252044 RVA: 0x00FAAB70 File Offset: 0x00FA8D70
		private UniTask NewDangoAbyssInfo()
		{
			MissionPanel.<NewDangoAbyssInfo>d__35 <NewDangoAbyssInfo>d__;
			<NewDangoAbyssInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDangoAbyssInfo>d__.<>4__this = this;
			<NewDangoAbyssInfo>d__.<>1__state = -1;
			<NewDangoAbyssInfo>d__.<>t__builder.Start<MissionPanel.<NewDangoAbyssInfo>d__35>(ref <NewDangoAbyssInfo>d__);
			return <NewDangoAbyssInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D88D RID: 252045 RVA: 0x00FAABB3 File Offset: 0x00FA8DB3
		protected override bool OnCheckBattleChildViewPanelShowCondition()
		{
			return ModelBase<BattleUiModel>.Instance.IsMissionPanelVisible;
		}

		// Token: 0x0603D88E RID: 252046 RVA: 0x00FAABBF File Offset: 0x00FA8DBF
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			DangoAbyssBattlePanel dangoAbyssBattlePanel = this.DangoAbyssBattlePanel;
			if (dangoAbyssBattlePanel == null)
			{
				return null;
			}
			return dangoAbyssBattlePanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x040228E7 RID: 141543
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]MissionPanelTick", "", "");

		// Token: 0x040228E8 RID: 141544
		private bool RestoreWhenInit = true;

		// Token: 0x040228E9 RID: 141545
		[Nullable(1)]
		private readonly MissionPanelControllerBase[] Controllers = new MissionPanelControllerBase[2];

		// Token: 0x040228EA RID: 141546
		[Nullable(1)]
		private readonly MissionViewItem[] MissionItemViews = new MissionViewItem[3];

		// Token: 0x040228EB RID: 141547
		[Nullable(1)]
		private readonly Dictionary<EMissionItemView, List<IMissionItemViewShowData>> PendingShowViewsMap = new Dictionary<EMissionItemView, List<IMissionItemViewShowData>>();

		// Token: 0x040228EC RID: 141548
		[Nullable(2)]
		private DangoAbyssBattlePanel DangoAbyssBattlePanel;

		// Token: 0x0200BFB8 RID: 49080
		private enum EChildComponent
		{
			// Token: 0x0403B03E RID: 241726
			MissionItemView,
			// Token: 0x0403B03F RID: 241727
			QuestUpdateTips,
			// Token: 0x0403B040 RID: 241728
			MissionItemViewRoot,
			// Token: 0x0403B041 RID: 241729
			ActMissionItem
		}
	}
}
