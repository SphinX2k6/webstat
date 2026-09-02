using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006051 RID: 24657
	[NullableContext(1)]
	[Nullable(0)]
	public class MissionPanelStep : StepBaseItem
	{
		// Token: 0x0603E349 RID: 254793 RVA: 0x00FE226D File Offset: 0x00FE046D
		public MissionPanelStep(EMissionItemView viewId, int stepId) : base(viewId, stepId)
		{
		}

		// Token: 0x0603E34A RID: 254794 RVA: 0x00FE2282 File Offset: 0x00FE0482
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
		}

		// Token: 0x0603E34B RID: 254795 RVA: 0x00FE22C0 File Offset: 0x00FE04C0
		protected override UniTask OnBeforeStartAsync()
		{
			MissionPanelStep.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MissionPanelStep.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E34C RID: 254796 RVA: 0x00FE2304 File Offset: 0x00FE0504
		protected override void OnBeforeDestroy()
		{
			if (this.ChildSteps != null)
			{
				foreach (MissionPanelChildStep missionPanelChildStep in this.ChildSteps)
				{
					missionPanelChildStep.Destroy(null);
				}
			}
			LevelSequencePlayer titleSequencePlayer = this.TitleSequencePlayer;
			if (titleSequencePlayer != null)
			{
				titleSequencePlayer.Clear();
			}
			this.TitleSequencePlayer = null;
		}

		// Token: 0x0603E34D RID: 254797 RVA: 0x00FE2378 File Offset: 0x00FE0578
		protected override void OnAfterShow()
		{
			this.TitleSequencePlayer.ResumeSequence();
			foreach (MissionPanelChildStep missionPanelChildStep in this.ChildSteps)
			{
				missionPanelChildStep.Show(null);
			}
		}

		// Token: 0x0603E34E RID: 254798 RVA: 0x00FE23D4 File Offset: 0x00FE05D4
		protected override void OnAfterHide()
		{
			this.TitleSequencePlayer.PauseSequence();
			foreach (MissionPanelChildStep missionPanelChildStep in this.ChildSteps)
			{
				missionPanelChildStep.Hide(null);
			}
		}

		// Token: 0x0603E34F RID: 254799 RVA: 0x00FE2430 File Offset: 0x00FE0630
		public override void OnTick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			base.OnTick(delta);
			foreach (MissionPanelChildStep missionPanelChildStep in this.ChildSteps)
			{
				missionPanelChildStep.OnTick(delta);
			}
		}

		// Token: 0x0603E350 RID: 254800 RVA: 0x00FE2494 File Offset: 0x00FE0694
		public void Update()
		{
			base.UpdateByConfig();
			if (this.ShowData != null && this.ShowData.SubStepInfos != null)
			{
				for (int i = 0; i < this.ShowData.SubStepInfos.Count; i++)
				{
					this.ChildSteps[i].UpdateByConfig();
				}
			}
		}

		// Token: 0x0603E351 RID: 254801 RVA: 0x00FE24E8 File Offset: 0x00FE06E8
		public UniTask StartShow(IMissionItemViewShowData showData, bool bSkipAnim)
		{
			MissionPanelStep.<StartShow>d__13 <StartShow>d__;
			<StartShow>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartShow>d__.<>4__this = this;
			<StartShow>d__.showData = showData;
			<StartShow>d__.bSkipAnim = bSkipAnim;
			<StartShow>d__.<>1__state = -1;
			<StartShow>d__.<>t__builder.Start<MissionPanelStep.<StartShow>d__13>(ref <StartShow>d__);
			return <StartShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E352 RID: 254802 RVA: 0x00FE253C File Offset: 0x00FE073C
		public override UniTask OnReset()
		{
			MissionPanelStep.<OnReset>d__14 <OnReset>d__;
			<OnReset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnReset>d__.<>4__this = this;
			<OnReset>d__.<>1__state = -1;
			<OnReset>d__.<>t__builder.Start<MissionPanelStep.<OnReset>d__14>(ref <OnReset>d__);
			return <OnReset>d__.<>t__builder.Task;
		}

		// Token: 0x0603E353 RID: 254803 RVA: 0x00FE2580 File Offset: 0x00FE0780
		public UniTask ExecuteSequenceOnUpdate(IMissionItemViewShowData showData, Action<IMissionItemViewShowData> updateParentData, bool bSkipAnim)
		{
			MissionPanelStep.<ExecuteSequenceOnUpdate>d__15 <ExecuteSequenceOnUpdate>d__;
			<ExecuteSequenceOnUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteSequenceOnUpdate>d__.<>4__this = this;
			<ExecuteSequenceOnUpdate>d__.showData = showData;
			<ExecuteSequenceOnUpdate>d__.updateParentData = updateParentData;
			<ExecuteSequenceOnUpdate>d__.bSkipAnim = bSkipAnim;
			<ExecuteSequenceOnUpdate>d__.<>1__state = -1;
			<ExecuteSequenceOnUpdate>d__.<>t__builder.Start<MissionPanelStep.<ExecuteSequenceOnUpdate>d__15>(ref <ExecuteSequenceOnUpdate>d__);
			return <ExecuteSequenceOnUpdate>d__.<>t__builder.Task;
		}

		// Token: 0x0603E354 RID: 254804 RVA: 0x00FE25DC File Offset: 0x00FE07DC
		private UniTask PlayStartSequence(bool bSkipAnim)
		{
			MissionPanelStep.<PlayStartSequence>d__16 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.bSkipAnim = bSkipAnim;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<MissionPanelStep.<PlayStartSequence>d__16>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603E355 RID: 254805 RVA: 0x00FE2628 File Offset: 0x00FE0828
		[NullableContext(0)]
		private UniTask<bool> PlayCloseSequence(bool bSkipAnim)
		{
			MissionPanelStep.<PlayCloseSequence>d__17 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.bSkipAnim = bSkipAnim;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<MissionPanelStep.<PlayCloseSequence>d__17>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603E356 RID: 254806 RVA: 0x00FE2674 File Offset: 0x00FE0874
		private UniTask PlayChildStepStartSequence(bool bSkipAnim)
		{
			MissionPanelStep.<PlayChildStepStartSequence>d__18 <PlayChildStepStartSequence>d__;
			<PlayChildStepStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayChildStepStartSequence>d__.<>4__this = this;
			<PlayChildStepStartSequence>d__.bSkipAnim = bSkipAnim;
			<PlayChildStepStartSequence>d__.<>1__state = -1;
			<PlayChildStepStartSequence>d__.<>t__builder.Start<MissionPanelStep.<PlayChildStepStartSequence>d__18>(ref <PlayChildStepStartSequence>d__);
			return <PlayChildStepStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603E357 RID: 254807 RVA: 0x00FE26C0 File Offset: 0x00FE08C0
		private UniTask PlayAllChildStepCloseSequence([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<MissionViewStepTextInfoBase> subTitles, bool bSkipAnim)
		{
			MissionPanelStep.<PlayAllChildStepCloseSequence>d__19 <PlayAllChildStepCloseSequence>d__;
			<PlayAllChildStepCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAllChildStepCloseSequence>d__.<>4__this = this;
			<PlayAllChildStepCloseSequence>d__.subTitles = subTitles;
			<PlayAllChildStepCloseSequence>d__.bSkipAnim = bSkipAnim;
			<PlayAllChildStepCloseSequence>d__.<>1__state = -1;
			<PlayAllChildStepCloseSequence>d__.<>t__builder.Start<MissionPanelStep.<PlayAllChildStepCloseSequence>d__19>(ref <PlayAllChildStepCloseSequence>d__);
			return <PlayAllChildStepCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0603E358 RID: 254808 RVA: 0x00FE2714 File Offset: 0x00FE0914
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				CustomPromise<bool> titleSequenceStartPromise = this.TitleSequenceStartPromise;
				if (titleSequenceStartPromise != null && titleSequenceStartPromise.IsPending)
				{
					this.TitleSequenceStartPromise.SetResult(true);
					return;
				}
			}
			else if (sequenceName == "Close" || sequenceName == "Finish")
			{
				CustomPromise<bool> titleSequenceClosePromise = this.TitleSequenceClosePromise;
				if (titleSequenceClosePromise != null && titleSequenceClosePromise.IsPending)
				{
					this.TitleSequenceClosePromise.SetResult(true);
				}
			}
		}

		// Token: 0x0603E359 RID: 254809 RVA: 0x00FE278C File Offset: 0x00FE098C
		private UniTask UpdateSelfData(IMissionItemViewShowData showData)
		{
			MissionPanelStep.<UpdateSelfData>d__21 <UpdateSelfData>d__;
			<UpdateSelfData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateSelfData>d__.<>4__this = this;
			<UpdateSelfData>d__.showData = showData;
			<UpdateSelfData>d__.<>1__state = -1;
			<UpdateSelfData>d__.<>t__builder.Start<MissionPanelStep.<UpdateSelfData>d__21>(ref <UpdateSelfData>d__);
			return <UpdateSelfData>d__.<>t__builder.Task;
		}

		// Token: 0x0603E35A RID: 254810 RVA: 0x00FE27D8 File Offset: 0x00FE09D8
		private UniTask UpdateChildSteps()
		{
			MissionPanelStep.<UpdateChildSteps>d__22 <UpdateChildSteps>d__;
			<UpdateChildSteps>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateChildSteps>d__.<>4__this = this;
			<UpdateChildSteps>d__.<>1__state = -1;
			<UpdateChildSteps>d__.<>t__builder.Start<MissionPanelStep.<UpdateChildSteps>d__22>(ref <UpdateChildSteps>d__);
			return <UpdateChildSteps>d__.<>t__builder.Task;
		}

		// Token: 0x0603E35B RID: 254811 RVA: 0x00FE281C File Offset: 0x00FE0A1C
		private UniTask DisableAllChildSteps()
		{
			MissionPanelStep.<DisableAllChildSteps>d__23 <DisableAllChildSteps>d__;
			<DisableAllChildSteps>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DisableAllChildSteps>d__.<>4__this = this;
			<DisableAllChildSteps>d__.<>1__state = -1;
			<DisableAllChildSteps>d__.<>t__builder.Start<MissionPanelStep.<DisableAllChildSteps>d__23>(ref <DisableAllChildSteps>d__);
			return <DisableAllChildSteps>d__.<>t__builder.Task;
		}

		// Token: 0x0603E35C RID: 254812 RVA: 0x00FE285F File Offset: 0x00FE0A5F
		public override bool CheckVisible()
		{
			return this.Config != null && !string.IsNullOrEmpty(Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.Config.TidTitle)) && base.CheckVisible();
		}

		// Token: 0x0603E35D RID: 254813 RVA: 0x00FE2890 File Offset: 0x00FE0A90
		private bool CheckCurrentFinished()
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = this.ShowData as BehaviorTreeViewShowData;
			if (behaviorTreeViewShowData == null)
			{
				return true;
			}
			BehaviorTreeStepTextInfo mainStepInfo = behaviorTreeViewShowData.MainStepInfo;
			IQuestScheduleType questScheduleType = (mainStepInfo != null) ? mainStepInfo.QuestScheduleType : null;
			if (questScheduleType == null)
			{
				return true;
			}
			IQuestScheduleChildQuestCompleted questScheduleChildQuestCompleted = questScheduleType as IQuestScheduleChildQuestCompleted;
			if (questScheduleChildQuestCompleted != null)
			{
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
				if (behaviorTree != null)
				{
					BehaviorNodeBase node = behaviorTree.GetNode(questScheduleChildQuestCompleted.ChildQuestId);
					if (node != null)
					{
						return node.IsSuccess;
					}
				}
			}
			return true;
		}

		// Token: 0x0603E35E RID: 254814 RVA: 0x00FE290C File Offset: 0x00FE0B0C
		public UniTask ChildStepConditionIndexChange(int stepId, int? curConditionTextIndex)
		{
			MissionPanelStep.<ChildStepConditionIndexChange>d__26 <ChildStepConditionIndexChange>d__;
			<ChildStepConditionIndexChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChildStepConditionIndexChange>d__.<>4__this = this;
			<ChildStepConditionIndexChange>d__.stepId = stepId;
			<ChildStepConditionIndexChange>d__.curConditionTextIndex = curConditionTextIndex;
			<ChildStepConditionIndexChange>d__.<>1__state = -1;
			<ChildStepConditionIndexChange>d__.<>t__builder.Start<MissionPanelStep.<ChildStepConditionIndexChange>d__26>(ref <ChildStepConditionIndexChange>d__);
			return <ChildStepConditionIndexChange>d__.<>t__builder.Task;
		}

		// Token: 0x04022DE0 RID: 142816
		private readonly List<MissionPanelChildStep> ChildSteps = new List<MissionPanelChildStep>();

		// Token: 0x04022DE1 RID: 142817
		[Nullable(2)]
		protected LevelSequencePlayer TitleSequencePlayer;

		// Token: 0x04022DE2 RID: 142818
		[Nullable(2)]
		private CustomPromise<bool> TitleSequenceStartPromise;

		// Token: 0x04022DE3 RID: 142819
		[Nullable(2)]
		private CustomPromise<bool> TitleSequenceClosePromise;

		// Token: 0x0200C11A RID: 49434
		[NullableContext(0)]
		private enum EChildComponent
		{
			// Token: 0x0403B767 RID: 243559
			ChildStep = 2,
			// Token: 0x0403B768 RID: 243560
			TitleNode
		}
	}
}
