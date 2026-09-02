using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006064 RID: 24676
	[NullableContext(2)]
	[Nullable(0)]
	public class MissionViewItem : BattleChildView
	{
		// Token: 0x17009ABC RID: 39612
		// (get) Token: 0x0603E3B2 RID: 254898 RVA: 0x00FE2D40 File Offset: 0x00FE0F40
		public long? ShowDataId
		{
			get
			{
				IMissionItemViewShowData showData = this.ShowData;
				if (showData == null)
				{
					return null;
				}
				return new long?(showData.Id);
			}
		}

		// Token: 0x17009ABD RID: 39613
		// (get) Token: 0x0603E3B3 RID: 254899 RVA: 0x00FE2D6B File Offset: 0x00FE0F6B
		public IMissionItemViewShowData ShowData
		{
			get
			{
				return ModelBase<BattleUiModel>.Instance.GetMissionViewData(this.ViewType);
			}
		}

		// Token: 0x0603E3B4 RID: 254900 RVA: 0x00FE2D80 File Offset: 0x00FE0F80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnShortcutKeyClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E3B5 RID: 254901 RVA: 0x00FE2F74 File Offset: 0x00FE1174
		protected override UniTask OnBeforeStartAsync()
		{
			MissionViewItem.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MissionViewItem.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3B6 RID: 254902 RVA: 0x00FE2FB7 File Offset: 0x00FE11B7
		private void InitController()
		{
			this.ShortcutKeyController.Init(this.ViewType, base.GetItem(11), base.GetSprite(10), base.GetText(2));
		}

		// Token: 0x0603E3B7 RID: 254903 RVA: 0x00FE2FE4 File Offset: 0x00FE11E4
		private void InitRegistryComponentsState()
		{
			base.GetText(2).SetAlpha(1f);
			base.GetItem(1).SetUIActive(false);
			this.ProcessItem = base.GetItem(5);
			this.ProcessItem.SetUIActive(true);
			this.CompleteItem = base.GetItem(4);
			this.CompleteItem.SetUIActive(false);
			base.GetUiNiagara(7).SetNiagaraUIActive(true, false);
		}

		// Token: 0x0603E3B8 RID: 254904 RVA: 0x00FE3050 File Offset: 0x00FE1250
		private UniTask InitMissionPanelStep()
		{
			MissionViewItem.<InitMissionPanelStep>d__28 <InitMissionPanelStep>d__;
			<InitMissionPanelStep>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMissionPanelStep>d__.<>4__this = this;
			<InitMissionPanelStep>d__.<>1__state = -1;
			<InitMissionPanelStep>d__.<>t__builder.Start<MissionViewItem.<InitMissionPanelStep>d__28>(ref <InitMissionPanelStep>d__);
			return <InitMissionPanelStep>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3B9 RID: 254905 RVA: 0x00FE3094 File Offset: 0x00FE1294
		private UniTask InitFishingEntrustNavigation()
		{
			MissionViewItem.<InitFishingEntrustNavigation>d__29 <InitFishingEntrustNavigation>d__;
			<InitFishingEntrustNavigation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFishingEntrustNavigation>d__.<>4__this = this;
			<InitFishingEntrustNavigation>d__.<>1__state = -1;
			<InitFishingEntrustNavigation>d__.<>t__builder.Start<MissionViewItem.<InitFishingEntrustNavigation>d__29>(ref <InitFishingEntrustNavigation>d__);
			return <InitFishingEntrustNavigation>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3BA RID: 254906 RVA: 0x00FE30D8 File Offset: 0x00FE12D8
		protected override void OnStart()
		{
			base.GetText(6).OnSelfLanguageChange.Bind(new Action(this.SetCompleteQuestName));
			base.GetText(8).OnSelfLanguageChange.Bind(new Action(this.UpdateTotalTitleText_ForBind));
			this.TotalTitleSequencePlayer = new LevelSequencePlayer(this.ProcessItem);
			this.TotalTitleSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnTotalTitleSequenceClose), false);
			this.QuestFinishSequencePlayer = new LevelSequencePlayer(this.CompleteItem);
			this.QuestFinishSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnFinishSequenceClose), false);
		}

		// Token: 0x0603E3BB RID: 254907 RVA: 0x00FE3174 File Offset: 0x00FE1374
		protected override void OnBeforeDestroy()
		{
			this.ShortcutKeyController.Dispose();
			MissionPanelStep missionPanelStep = this.MissionPanelStep;
			if (missionPanelStep != null)
			{
				missionPanelStep.Destroy(null);
			}
			this.FishingEntrustNavigationItem.Destroy(null);
			AUIBaseActor rootActor = this.RootActor;
			if (rootActor != null)
			{
				rootActor.OnSequencePlayEvent.Unbind();
			}
			LevelSequencePlayer totalTitleSequencePlayer = this.TotalTitleSequencePlayer;
			if (totalTitleSequencePlayer != null)
			{
				totalTitleSequencePlayer.Clear();
			}
			this.TotalTitleSequencePlayer = null;
		}

		// Token: 0x0603E3BC RID: 254908 RVA: 0x00FE31D8 File Offset: 0x00FE13D8
		public void OnPanelShow()
		{
			this.IsPanelShow = true;
			this.AddEvents();
			this.QuestFinishSequencePlayer.ResumeSequence();
			this.TotalTitleSequencePlayer.ResumeSequence();
			this.MissionPanelStepVisibleProcessQueue.Push(MissionViewItem.EProcessType.Show);
			this.ShortcutKeyController.OnPanelShow();
			this.UpdateTotalTitleText();
		}

		// Token: 0x0603E3BD RID: 254909 RVA: 0x00FE3226 File Offset: 0x00FE1426
		public void OnPanelHide()
		{
			this.IsPanelShow = false;
			this.RemoveEvents();
			this.QuestFinishSequencePlayer.PauseSequence();
			this.TotalTitleSequencePlayer.PauseSequence();
			this.MissionPanelStepVisibleProcessQueue.Push(MissionViewItem.EProcessType.Hide);
			this.ShortcutKeyController.OnPanelHide();
		}

		// Token: 0x0603E3BE RID: 254910 RVA: 0x00FE3264 File Offset: 0x00FE1464
		private void ProcessMissionPanelStepVisibleProcess()
		{
			if (this.MissionPanelStepVisibleProcessQueue.Empty)
			{
				return;
			}
			MissionViewItem.EProcessType eprocessType = this.MissionPanelStepVisibleProcessQueue.Pop();
			if (eprocessType != MissionViewItem.EProcessType.Show)
			{
				if (eprocessType != MissionViewItem.EProcessType.Hide)
				{
					return;
				}
				this.LastStepShowState = this.MissionPanelStep.IsShowOrShowing;
				this.MissionPanelStep.Hide(null);
			}
			else if (this.LastStepShowState)
			{
				MissionPanelStep missionPanelStep = this.MissionPanelStep;
				if (missionPanelStep == null)
				{
					return;
				}
				missionPanelStep.Show(null);
				return;
			}
		}

		// Token: 0x0603E3BF RID: 254911 RVA: 0x00FE32CC File Offset: 0x00FE14CC
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.OnLogicTreeChildQuestNodeStatusChange));
			Singleton<EventSystem>.Instance.Add<GeneralContext, ChildQuestNodeProgress>(EEventName.OnLogicTreeNodeProgressChange, new Action<GeneralContext, ChildQuestNodeProgress>(this.OnNodeProgressChanged));
			Singleton<EventSystem>.Instance.Add<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnLogicTreeNodeStatusChange));
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeAddTag, new Action<EBehaviorTreeTag>(this.OnGeneralLogicTreeCommunicateTagChange));
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeRemoveTag, new Action<EBehaviorTreeTag>(this.OnGeneralLogicTreeCommunicateTagChange));
			Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnForceRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.MissionPanelStepTitleAnimStart, new Action<long>(this.OnMissionPanelStepTitleAnimStart));
			Singleton<EventSystem>.Instance.Add(EEventName.MissionPanelStepTitleAnimEnd, new Action<long>(this.OnMissionPanelStepTitleAnimEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuestStageNameChange, new Action<int>(this.OnQuestStageNameChange));
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.ShortcutKeyController.UpdateShortcutButton));
			}
		}

		// Token: 0x0603E3C0 RID: 254912 RVA: 0x00FE3404 File Offset: 0x00FE1604
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeChildQuestNodeStatusChange, new Action<GeneralContext, ChildQuestNodeStatus, ChildQuestNodeStatus, ENodeStatusUpdateReason>(this.OnLogicTreeChildQuestNodeStatusChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeNodeProgressChange, new Action<GeneralContext, ChildQuestNodeProgress>(this.OnNodeProgressChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnLogicTreeNodeStatusChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeAddTag, new Action<EBehaviorTreeTag>(this.OnGeneralLogicTreeCommunicateTagChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeRemoveTag, new Action<EBehaviorTreeTag>(this.OnGeneralLogicTreeCommunicateTagChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeViewForceRefresh, new Action<long>(this.OnForceRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.MissionPanelStepTitleAnimStart, new Action<long>(this.OnMissionPanelStepTitleAnimStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.MissionPanelStepTitleAnimEnd, new Action<long>(this.OnMissionPanelStepTitleAnimEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStageNameChange, new Action<int>(this.OnQuestStageNameChange));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.ShortcutKeyController.UpdateShortcutButton));
		}

		// Token: 0x0603E3C1 RID: 254913 RVA: 0x00FE352E File Offset: 0x00FE172E
		private void OnShortcutKeyClick()
		{
			this.ShortcutKeyController.OnShortcutKeyClick();
		}

		// Token: 0x0603E3C2 RID: 254914 RVA: 0x00FE353B File Offset: 0x00FE173B
		[NullableContext(1)]
		private void OnLogicTreeChildQuestNodeStatusChange(GeneralContext context, ChildQuestNodeStatus _2, ChildQuestNodeStatus _3, ENodeStatusUpdateReason _4)
		{
			this.OnChildQuestNodeStatusChanged(context);
		}

		// Token: 0x0603E3C3 RID: 254915 RVA: 0x00FE3544 File Offset: 0x00FE1744
		[NullableContext(1)]
		private void OnLogicTreeNodeStatusChange(GeneralContext context, NodeStatus _2, NodeStatus _3, ENodeStatusUpdateReason _4)
		{
			this.OnChildQuestNodeStatusChanged(context);
		}

		// Token: 0x0603E3C4 RID: 254916 RVA: 0x00FE3550 File Offset: 0x00FE1750
		[NullableContext(1)]
		private void OnChildQuestNodeStatusChanged(GeneralContext context)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext != null)
			{
				long treeIncId = generalLogicTreeContext.TreeIncId;
				long? showDataId = this.ShowDataId;
				if (treeIncId == showDataId.GetValueOrDefault() & showDataId != null)
				{
					this.ShortcutKeyController.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
					return;
				}
			}
		}

		// Token: 0x0603E3C5 RID: 254917 RVA: 0x00FE3598 File Offset: 0x00FE1798
		[NullableContext(1)]
		private void OnNodeProgressChanged(GeneralContext context, ChildQuestNodeProgress progress)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext != null)
			{
				long treeIncId = generalLogicTreeContext.TreeIncId;
				long? showDataId = this.ShowDataId;
				if (treeIncId == showDataId.GetValueOrDefault() & showDataId != null)
				{
					if (this.CurProcessId != 0)
					{
						return;
					}
					this.OnTickImp(0);
					return;
				}
			}
		}

		// Token: 0x0603E3C6 RID: 254918 RVA: 0x00FE35E0 File Offset: 0x00FE17E0
		private void OnGeneralLogicTreeCommunicateTagChange(EBehaviorTreeTag tag)
		{
			if (tag != EBehaviorTreeTag.CanCommunicateAgain)
			{
				return;
			}
			this.ShortcutKeyController.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
		}

		// Token: 0x0603E3C7 RID: 254919 RVA: 0x00FE35F4 File Offset: 0x00FE17F4
		private void OnMissionPanelStepTitleAnimStart(long id)
		{
			long? showDataId = this.ShowDataId;
			if (!(showDataId.GetValueOrDefault() == id & showDataId != null))
			{
				return;
			}
			if (base.GetText(8).IsUIActiveSelf())
			{
				return;
			}
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x0603E3C8 RID: 254920 RVA: 0x00FE3640 File Offset: 0x00FE1840
		private void OnMissionPanelStepTitleAnimEnd(long id)
		{
			long? showDataId = this.ShowDataId;
			if (!(showDataId.GetValueOrDefault() == id & showDataId != null))
			{
				return;
			}
			if (base.GetText(8).IsUIActiveSelf())
			{
				return;
			}
			this.SetIcon();
		}

		// Token: 0x0603E3C9 RID: 254921 RVA: 0x00FE3680 File Offset: 0x00FE1880
		[NullableContext(1)]
		private void OnTotalTitleSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				CustomPromise<bool> totalSequenceStartPromise = this.TotalSequenceStartPromise;
				if (totalSequenceStartPromise != null && totalSequenceStartPromise.IsPending)
				{
					this.TotalSequenceStartPromise.SetResult(true);
					return;
				}
			}
			else if (sequenceName == "Close")
			{
				CustomPromise<bool> totalSequenceClosePromise = this.TotalSequenceClosePromise;
				if (totalSequenceClosePromise != null && totalSequenceClosePromise.IsPending)
				{
					this.TotalSequenceClosePromise.SetResult(true);
				}
			}
		}

		// Token: 0x0603E3CA RID: 254922 RVA: 0x00FE36E8 File Offset: 0x00FE18E8
		[NullableContext(1)]
		private void OnFinishSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				CustomPromise<bool> questFinishStartPromise = this.QuestFinishStartPromise;
				if (questFinishStartPromise != null && questFinishStartPromise.IsPending)
				{
					this.QuestFinishStartPromise.SetResult(true);
					return;
				}
			}
			else if (sequenceName == "Close")
			{
				CustomPromise<bool> questFinishClosePromise = this.QuestFinishClosePromise;
				if (questFinishClosePromise != null && questFinishClosePromise.IsPending)
				{
					this.QuestFinishClosePromise.SetResult(true);
				}
			}
		}

		// Token: 0x0603E3CB RID: 254923 RVA: 0x00FE3750 File Offset: 0x00FE1950
		[NullableContext(1)]
		private void UpdateSelfData(IMissionItemViewShowData showData)
		{
			this.SetShowData(showData);
			this.SetIcon();
			this.ShortcutKeyController.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
		}

		// Token: 0x0603E3CC RID: 254924 RVA: 0x00FE376C File Offset: 0x00FE196C
		private void SetShowData(IMissionItemViewShowData showData = null)
		{
			ModelBase<BattleUiModel>.Instance.SetMissionViewData(this.ViewType, showData);
		}

		// Token: 0x0603E3CD RID: 254925 RVA: 0x00FE3780 File Offset: 0x00FE1980
		private void SetIcon()
		{
			if (this.ShowData == null)
			{
				return;
			}
			int trackIconConfigId = this.ShowData.TrackIconConfigId;
			if (trackIconConfigId == 0)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(0);
			if (MissionViewStepTextUtil.CheckShowConfigEmpty(this.ShowData))
			{
				sprite.SetUIActive(false);
				return;
			}
			sprite.SetUIActive(true);
			this.SetSpriteByPath(ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(trackIconConfigId), sprite, false, null, null);
		}

		// Token: 0x0603E3CE RID: 254926 RVA: 0x00FE37E8 File Offset: 0x00FE19E8
		[NullableContext(0)]
		public UniTask<bool> StartShow(int processId, [Nullable(1)] IMissionItemViewShowData showData, bool bSkipAnim)
		{
			MissionViewItem.<StartShow>d__50 <StartShow>d__;
			<StartShow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<StartShow>d__.<>4__this = this;
			<StartShow>d__.processId = processId;
			<StartShow>d__.showData = showData;
			<StartShow>d__.bSkipAnim = bSkipAnim;
			<StartShow>d__.<>1__state = -1;
			<StartShow>d__.<>t__builder.Start<MissionViewItem.<StartShow>d__50>(ref <StartShow>d__);
			return <StartShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3CF RID: 254927 RVA: 0x00FE3844 File Offset: 0x00FE1A44
		[NullableContext(0)]
		public UniTask<bool> OnLogicTreeUpdateShow(int processId, [Nullable(1)] IMissionItemViewShowData showData, bool bSkipAnim)
		{
			MissionViewItem.<OnLogicTreeUpdateShow>d__51 <OnLogicTreeUpdateShow>d__;
			<OnLogicTreeUpdateShow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnLogicTreeUpdateShow>d__.<>4__this = this;
			<OnLogicTreeUpdateShow>d__.processId = processId;
			<OnLogicTreeUpdateShow>d__.showData = showData;
			<OnLogicTreeUpdateShow>d__.bSkipAnim = bSkipAnim;
			<OnLogicTreeUpdateShow>d__.<>1__state = -1;
			<OnLogicTreeUpdateShow>d__.<>t__builder.Start<MissionViewItem.<OnLogicTreeUpdateShow>d__51>(ref <OnLogicTreeUpdateShow>d__);
			return <OnLogicTreeUpdateShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3D0 RID: 254928 RVA: 0x00FE38A0 File Offset: 0x00FE1AA0
		[NullableContext(0)]
		public UniTask<bool> EndShow(int processId, bool bSkipAnim, ETreeTextExpressReason? reason = null)
		{
			MissionViewItem.<EndShow>d__52 <EndShow>d__;
			<EndShow>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EndShow>d__.<>4__this = this;
			<EndShow>d__.processId = processId;
			<EndShow>d__.bSkipAnim = bSkipAnim;
			<EndShow>d__.reason = reason;
			<EndShow>d__.<>1__state = -1;
			<EndShow>d__.<>t__builder.Start<MissionViewItem.<EndShow>d__52>(ref <EndShow>d__);
			return <EndShow>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3D1 RID: 254929 RVA: 0x00FE38FC File Offset: 0x00FE1AFC
		public UniTask ChildStepConditionIndexChange(int stepId, int? curConditionTextIndex)
		{
			MissionViewItem.<ChildStepConditionIndexChange>d__53 <ChildStepConditionIndexChange>d__;
			<ChildStepConditionIndexChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChildStepConditionIndexChange>d__.<>4__this = this;
			<ChildStepConditionIndexChange>d__.stepId = stepId;
			<ChildStepConditionIndexChange>d__.curConditionTextIndex = curConditionTextIndex;
			<ChildStepConditionIndexChange>d__.<>1__state = -1;
			<ChildStepConditionIndexChange>d__.<>t__builder.Start<MissionViewItem.<ChildStepConditionIndexChange>d__53>(ref <ChildStepConditionIndexChange>d__);
			return <ChildStepConditionIndexChange>d__.<>t__builder.Task;
		}

		// Token: 0x0603E3D2 RID: 254930 RVA: 0x00FE394F File Offset: 0x00FE1B4F
		private void OnQuestStageNameChange(int questId)
		{
			this.UpdateTotalTitleText();
		}

		// Token: 0x0603E3D3 RID: 254931 RVA: 0x00FE3958 File Offset: 0x00FE1B58
		private void UpdateTotalTitleText_ForBind()
		{
			this.UpdateTotalTitleText();
		}

		// Token: 0x0603E3D4 RID: 254932 RVA: 0x00FE3964 File Offset: 0x00FE1B64
		private bool UpdateTotalTitleText()
		{
			UUIText text = base.GetText(8);
			UUIItem item = base.GetItem(9);
			string totalTitleText = this.GetTotalTitleText();
			text.SetText(totalTitleText, true);
			if (string.IsNullOrEmpty(totalTitleText))
			{
				text.SetUIActive(false);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return false;
			}
			text.SetUIActive(true);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			return true;
		}

		// Token: 0x0603E3D5 RID: 254933 RVA: 0x00FE39BE File Offset: 0x00FE1BBE
		[NullableContext(1)]
		private string GetTotalTitleText()
		{
			if (this.ShowData == null || string.IsNullOrEmpty(this.ShowData.TitleTextKey))
			{
				return string.Empty;
			}
			return Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.ShowData.TitleTextKey);
		}

		// Token: 0x0603E3D6 RID: 254934 RVA: 0x00FE39F8 File Offset: 0x00FE1BF8
		public void OnRefresh(float delta, int curProcessId)
		{
			this.ProcessMissionPanelStepVisibleProcess();
			if (!this.IsPanelShow)
			{
				return;
			}
			this.MissionPanelStep.OnTick(delta);
			if (this.CurTickTime > 1000f)
			{
				this.CurTickTime -= 1000f;
				this.OnTickImp(curProcessId);
			}
			this.CurTickTime += delta;
		}

		// Token: 0x0603E3D7 RID: 254935 RVA: 0x00FE3A54 File Offset: 0x00FE1C54
		private void OnTickImp(int curProcessId)
		{
			if (curProcessId != 0 && curProcessId == this.CurProcessId)
			{
				return;
			}
			if (!this.CheckVisible())
			{
				UUIItem processItem = this.ProcessItem;
				if (processItem == null)
				{
					return;
				}
				processItem.SetUIActive(false);
				return;
			}
			else
			{
				this.MissionPanelStep.Update();
				this.ShortcutKeyController.UpdateTrackTargetShortcutKey();
				this.ShortcutKeyController.RefreshFastReturnShortcutKey();
				UUIItem processItem2 = this.ProcessItem;
				if (processItem2 == null)
				{
					return;
				}
				processItem2.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603E3D8 RID: 254936 RVA: 0x00FE3ABC File Offset: 0x00FE1CBC
		private void SetCompleteQuestName()
		{
			BehaviorTreeViewShowData behaviorTreeViewShowData = this.ShowData as BehaviorTreeViewShowData;
			if (behaviorTreeViewShowData == null || behaviorTreeViewShowData.BtType != BtType.Quest)
			{
				return;
			}
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(behaviorTreeViewShowData.TreeConfigId);
			base.GetText(6).SetText(((quest != null) ? quest.Name : null) ?? string.Empty, true);
		}

		// Token: 0x0603E3D9 RID: 254937 RVA: 0x00FE3B18 File Offset: 0x00FE1D18
		private void SetNiagaraColor(float _)
		{
			if (this.ShowData == null)
			{
				return;
			}
			TaskMark? questMarkConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestMarkConfig(this.ShowData.TrackIconConfigId);
			if (questMarkConfig == null)
			{
				return;
			}
			UUINiagara uiNiagara = base.GetUiNiagara(7);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetColor(FColor.FromHex(questMarkConfig.Value.TrackTextStartEffectColor));
			uiNiagara.ActivateSystem(true);
		}

		// Token: 0x0603E3DA RID: 254938 RVA: 0x00FE3B7C File Offset: 0x00FE1D7C
		private void OnForceRefresh(long treeIncId)
		{
			IMissionItemViewShowData showData = this.ShowData;
			long? num = (showData != null) ? new long?(showData.Id) : null;
			if (!(treeIncId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			if (this.CurProcessId != 0)
			{
				return;
			}
			this.OnTickImp(0);
		}

		// Token: 0x0603E3DB RID: 254939 RVA: 0x00FE3BD0 File Offset: 0x00FE1DD0
		public bool CheckVisible()
		{
			if (!ModelBase<BattleUiModel>.Instance.IsMissionPanelVisible)
			{
				return false;
			}
			if (this.ShowData != null)
			{
				Dictionary<EMissionItemView, bool> isShowingMissionViewItems = ModelBase<BattleUiModel>.Instance.IsShowingMissionViewItems;
				if (isShowingMissionViewItems != null && isShowingMissionViewItems.GetValueOrDefault(this.ViewType))
				{
					BehaviorTreeViewShowData behaviorTreeViewShowData = this.ShowData as BehaviorTreeViewShowData;
					if (behaviorTreeViewShowData != null)
					{
						if (behaviorTreeViewShowData.BtType == BtType.Quest && ControllerBase<GameModeController>.Instance.IsInInstance())
						{
							return false;
						}
						LogicTreeContainer logicTreeContainer = Singleton<GeneralLogicTreeUtil>.Instance.GetLogicTreeContainer(behaviorTreeViewShowData.BtType, behaviorTreeViewShowData.TreeConfigId);
						if (logicTreeContainer == null || !logicTreeContainer.CanShowTrackExpression())
						{
							return false;
						}
					}
					return !MissionViewStepTextUtil.CheckShowConfigEmpty(this.ShowData);
				}
			}
			return false;
		}

		// Token: 0x04022E2B RID: 142891
		[Nullable(1)]
		private readonly MissionViewItem.ShortcutKeyControllerImpl ShortcutKeyController = new MissionViewItem.ShortcutKeyControllerImpl();

		// Token: 0x04022E2C RID: 142892
		private UUIItem ProcessItem;

		// Token: 0x04022E2D RID: 142893
		private UUIItem CompleteItem;

		// Token: 0x04022E2E RID: 142894
		protected LevelSequencePlayer TotalTitleSequencePlayer;

		// Token: 0x04022E2F RID: 142895
		protected LevelSequencePlayer QuestFinishSequencePlayer;

		// Token: 0x04022E30 RID: 142896
		private MissionPanelStep MissionPanelStep;

		// Token: 0x04022E31 RID: 142897
		[Nullable(1)]
		private readonly FishingEntrustNavigationItem FishingEntrustNavigationItem = new FishingEntrustNavigationItem();

		// Token: 0x04022E32 RID: 142898
		private int CurProcessId;

		// Token: 0x04022E33 RID: 142899
		private float CurTickTime;

		// Token: 0x04022E34 RID: 142900
		public EMissionItemView ViewType;

		// Token: 0x04022E35 RID: 142901
		private bool IsPanelShow;

		// Token: 0x04022E36 RID: 142902
		private bool LastStepShowState;

		// Token: 0x04022E37 RID: 142903
		private CustomPromise<bool> TotalSequenceStartPromise;

		// Token: 0x04022E38 RID: 142904
		private CustomPromise<bool> TotalSequenceClosePromise;

		// Token: 0x04022E39 RID: 142905
		private CustomPromise<bool> QuestFinishStartPromise;

		// Token: 0x04022E3A RID: 142906
		private CustomPromise<bool> QuestFinishClosePromise;

		// Token: 0x04022E3B RID: 142907
		[Nullable(1)]
		private readonly Queue<MissionViewItem.EProcessType> MissionPanelStepVisibleProcessQueue = new Queue<MissionViewItem.EProcessType>(4);

		// Token: 0x0200C128 RID: 49448
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B7B0 RID: 243632
			Icon,
			// Token: 0x0403B7B1 RID: 243633
			ParentStep,
			// Token: 0x0403B7B2 RID: 243634
			ShortcutKeyText,
			// Token: 0x0403B7B3 RID: 243635
			ShortcutKeyButton,
			// Token: 0x0403B7B4 RID: 243636
			CompleteItem,
			// Token: 0x0403B7B5 RID: 243637
			ProcessItem,
			// Token: 0x0403B7B6 RID: 243638
			CompleteQuestName,
			// Token: 0x0403B7B7 RID: 243639
			StartNiagara,
			// Token: 0x0403B7B8 RID: 243640
			TotalTitleText,
			// Token: 0x0403B7B9 RID: 243641
			TotalTitleTextNode,
			// Token: 0x0403B7BA RID: 243642
			ShortcutKeyMobileSprite,
			// Token: 0x0403B7BB RID: 243643
			ShortcutKeyRoot
		}

		// Token: 0x0200C129 RID: 49449
		[NullableContext(0)]
		private enum EProcessType
		{
			// Token: 0x0403B7BD RID: 243645
			Show,
			// Token: 0x0403B7BE RID: 243646
			Hide
		}

		// Token: 0x0200C12A RID: 49450
		[Nullable(0)]
		private class ShortcutKeyControllerImpl
		{
			// Token: 0x1700AA3C RID: 43580
			// (get) Token: 0x0604E49C RID: 320668 RVA: 0x015AD872 File Offset: 0x015ABA72
			public IMissionItemViewShowData ShowData
			{
				get
				{
					return ModelBase<BattleUiModel>.Instance.GetMissionViewData(this.ViewType);
				}
			}

			// Token: 0x0604E49D RID: 320669 RVA: 0x015AD884 File Offset: 0x015ABA84
			[NullableContext(1)]
			public void Init(EMissionItemView viewType, UUIItem shortcutKeyRoot, UUISprite shortcutKeySprite, UUIText shortcutTextComp)
			{
				this.ViewType = viewType;
				this.ShortcutKeyRoot = shortcutKeyRoot;
				this.ShortcutKeySprite = shortcutKeySprite;
				this.ShortcutTextComp = shortcutTextComp;
			}

			// Token: 0x0604E49E RID: 320670 RVA: 0x015AD8A3 File Offset: 0x015ABAA3
			public void OnPanelShow()
			{
				this.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
			}

			// Token: 0x0604E49F RID: 320671 RVA: 0x015AD8AD File Offset: 0x015ABAAD
			public void OnPanelHide()
			{
				this.SetUpShortcutKeyByType(EActiveNodeShortcutShow.None);
			}

			// Token: 0x0604E4A0 RID: 320672 RVA: 0x015AD8B6 File Offset: 0x015ABAB6
			public void OnProcessStart()
			{
				this.SetUpShortcutKeyByType(EActiveNodeShortcutShow.None);
			}

			// Token: 0x0604E4A1 RID: 320673 RVA: 0x015AD8BF File Offset: 0x015ABABF
			public void OnProcessEnd()
			{
				this.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
			}

			// Token: 0x0604E4A2 RID: 320674 RVA: 0x015AD8C9 File Offset: 0x015ABAC9
			public void Dispose()
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
				ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}

			// Token: 0x0604E4A3 RID: 320675 RVA: 0x015AD901 File Offset: 0x015ABB01
			[NullableContext(1)]
			private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
			{
				if (actionType != InputDistributeDefine.EActionType.Release)
				{
					return;
				}
				this.OnShortcutKeyClick();
			}

			// Token: 0x0604E4A4 RID: 320676 RVA: 0x015AD90E File Offset: 0x015ABB0E
			public void UpdateShortcutButton(EInputControllerType last = EInputControllerType.None, EInputControllerType now = EInputControllerType.None)
			{
				this.UpdateCurShortcutType();
				this.SetUpShortcutKeyByType(this.CurShortcutType);
			}

			// Token: 0x0604E4A5 RID: 320677 RVA: 0x015AD924 File Offset: 0x015ABB24
			private void UpdateCurShortcutType()
			{
				this.CurShortcutType = EActiveNodeShortcutShow.None;
				IMissionItemViewShowData showData = this.ShowData;
				if (showData != null && showData.DataSource == EMissionItemViewDataSource.BehaviorTree)
				{
					BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					if (behaviorTree != null)
					{
						this.CurShortcutType = behaviorTree.GetCurrentNodeShortcutShow();
					}
				}
			}

			// Token: 0x0604E4A6 RID: 320678 RVA: 0x015AD97C File Offset: 0x015ABB7C
			private void SetUpShortcutKeyByType(EActiveNodeShortcutShow type)
			{
				BaseBehaviorTree baseBehaviorTree = null;
				IMissionItemViewShowData showData = this.ShowData;
				if (showData != null && showData.DataSource == EMissionItemViewDataSource.BehaviorTree)
				{
					baseBehaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
				}
				switch (type)
				{
				case EActiveNodeShortcutShow.None:
					ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					this.ShortcutKeyRoot.SetUIActive(false);
					return;
				case EActiveNodeShortcutShow.GiveUp:
				{
					string text = baseBehaviorTree.GetGiveUpText();
					if (string.IsNullOrEmpty(text))
					{
						text = ConfigBase<TextConfig>.Instance.GetTextById("GeneralLogicTreeGiveUp");
					}
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("玩法放弃");
						if (actionBinding == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							return;
						}
						InputKey pcKey = actionBinding.GetPcKey();
						if (pcKey == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.GeneralLogicTree;
							ELogAuthor author = ELogAuthor.YSQ;
							string message = "pcKey为空";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionMapping", "玩法放弃");
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							return;
						}
						string newText = "<texture=" + pcKey.GetKeyIconPath() + "/>" + text;
						this.ShortcutTextComp.SetText(newText, true);
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						string newText2 = this.GetGamepadShortcutString("玩法放弃", text) ?? text;
						this.ShortcutTextComp.SetText(newText2, true);
					}
					else
					{
						string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("FightMissionStop");
						string newText3 = "<texture=" + resourcePath + "/>" + text;
						this.ShortcutTextComp.SetText(newText3, true);
					}
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					this.ShortcutKeyRoot.SetUIActive(true);
					ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					return;
				}
				case EActiveNodeShortcutShow.Communicate:
				{
					InputActionBinding actionBinding2 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding2 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.GeneralLogicTree;
						ELogAuthor author2 = ELogAuthor.YSQ;
						string message2 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string textById = ConfigBase<TextConfig>.Instance.GetTextById("QuestCommunicateCallback");
					string newText4 = textById;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey2 = actionBinding2.GetPcKey();
						if (pcKey2 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.GeneralLogicTree;
							ELogAuthor author3 = ELogAuthor.YSQ;
							string message3 = "pcKey为空";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
							return;
						}
						string keyIconPath = pcKey2.GetKeyIconPath();
						newText4 = "<texture=" + keyIconPath + "/>" + textById;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText4 = (this.GetGamepadShortcutString("任务追踪", textById) ?? textById);
					}
					this.ShortcutTextComp.SetText(newText4, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.ChallengeAgain:
				{
					string text2 = baseBehaviorTree.GetGiveUpText();
					if (string.IsNullOrEmpty(text2))
					{
						text2 = ConfigBase<TextConfig>.Instance.GetTextById("ChallengeAgain");
					}
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputActionBinding actionBinding3 = Singleton<InputSettingsManager>.Instance.GetActionBinding("重新挑战");
						if (actionBinding3 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							return;
						}
						InputKey pcKey3 = actionBinding3.GetPcKey();
						if (pcKey3 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance4 = Singleton<Log>.Instance;
							ELogModule module4 = ELogModule.GeneralLogicTree;
							ELogAuthor author4 = ELogAuthor.YSQ;
							string message4 = "pcKey为空";
							ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("actionMapping", "重新挑战");
							instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
							return;
						}
						string newText5 = "<texture=" + pcKey3.GetKeyIconPath() + "/>" + text2;
						this.ShortcutTextComp.SetText(newText5, true);
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						string newText6 = this.GetGamepadShortcutString("重新挑战", text2) ?? text2;
						this.ShortcutTextComp.SetText(newText6, true);
					}
					else
					{
						string newText7 = ConfigBase<TextConfig>.Instance.GetTextById("ChallengeAgain_mobile") ?? text2;
						this.ShortcutTextComp.SetText(newText7, true);
					}
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.TrackTarget:
					if (this.RefreshTrackTarget())
					{
						ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
						ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
						return;
					}
					this.ShortcutKeyRoot.SetUIActive(false);
					return;
				case EActiveNodeShortcutShow.PhoneMessage:
				{
					InputActionBinding actionBinding4 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding4 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.GeneralLogicTree;
						ELogAuthor author5 = ELogAuthor.YSQ;
						string message5 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text3 = ConfigBase<TextConfig>.Instance.GetTextById("QuestTrack_ReadMessage") ?? string.Empty;
					string newText8 = text3;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey4 = actionBinding4.GetPcKey();
						if (pcKey4 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance6 = Singleton<Log>.Instance;
							ELogModule module6 = ELogModule.GeneralLogicTree;
							ELogAuthor author6 = ELogAuthor.YSQ;
							string message6 = "pcKey为空";
							ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance6.Error(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
							return;
						}
						string keyIconPath2 = pcKey4.GetKeyIconPath();
						newText8 = "<texture=" + keyIconPath2 + "/>" + text3;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText8 = (this.GetGamepadShortcutString("任务追踪", text3) ?? text3);
					}
					this.ShortcutTextComp.SetText(newText8, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.FastReturn:
				{
					InputActionBinding actionBinding5 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding5 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance7 = Singleton<Log>.Instance;
						ELogModule module7 = ELogModule.GeneralLogicTree;
						ELogAuthor author7 = ELogAuthor.HYF;
						string message7 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple7 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance7.Error(module7, author7, message7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple7));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					FastReturnResolved fastReturnResolved = FastReturnUtil.Resolve(baseBehaviorTree);
					string id = (((fastReturnResolved != null) ? fastReturnResolved.TrackReturnDungeon : null) != null) ? "QuestTrack_DungeonQuickReturn" : "QuestTrack_QuestQuickReturn";
					string text4 = ConfigBase<TextConfig>.Instance.GetTextById(id) ?? "快速返回";
					string text5 = (!string.IsNullOrEmpty((fastReturnResolved != null) ? fastReturnResolved.TidTip : null)) ? (Singleton<PublicUtil>.Instance.GetConfigTextByKey(fastReturnResolved.TidTip) ?? text4) : text4;
					string newText9 = text5;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey5 = actionBinding5.GetPcKey();
						if (pcKey5 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance8 = Singleton<Log>.Instance;
							ELogModule module8 = ELogModule.GeneralLogicTree;
							ELogAuthor author8 = ELogAuthor.HYF;
							string message8 = "pcKey为空";
							ValueTuple<string, object> valueTuple8 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance8.Error(module8, author8, message8, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple8));
							return;
						}
						string keyIconPath3 = pcKey5.GetKeyIconPath();
						newText9 = "<texture=" + keyIconPath3 + "/>" + text5;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText9 = (this.GetGamepadShortcutString("任务追踪", text5) ?? text5);
					}
					this.ShortcutTextComp.SetText(newText9, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.QuestMultiLineView:
				{
					InputActionBinding actionBinding6 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding6 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance9 = Singleton<Log>.Instance;
						ELogModule module9 = ELogModule.GeneralLogicTree;
						ELogAuthor author9 = ELogAuthor.YSQ;
						string message9 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple9 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance9.Error(module9, author9, message9, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple9));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text6 = ConfigBase<TextConfig>.Instance.GetTextById("QuestBranch_Track") ?? "查看分线";
					string newText10 = text6;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey6 = actionBinding6.GetPcKey();
						if (pcKey6 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance10 = Singleton<Log>.Instance;
							ELogModule module10 = ELogModule.GeneralLogicTree;
							ELogAuthor author10 = ELogAuthor.YSQ;
							string message10 = "pcKey为空";
							ValueTuple<string, object> valueTuple10 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance10.Error(module10, author10, message10, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple10));
							return;
						}
						string keyIconPath4 = pcKey6.GetKeyIconPath();
						newText10 = "<texture=" + keyIconPath4 + "/>" + text6;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText10 = (this.GetGamepadShortcutString("任务追踪", text6) ?? text6);
					}
					this.ShortcutTextComp.SetText(newText10, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.SheriffAnomalyProgress:
				{
					InputActionBinding actionBinding7 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding7 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance11 = Singleton<Log>.Instance;
						ELogModule module11 = ELogModule.GeneralLogicTree;
						ELogAuthor author11 = ELogAuthor.SYB;
						string message11 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple11 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance11.Error(module11, author11, message11, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple11));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text7 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Sheriff_HudDesc_2") ?? "查看案情进展";
					string newText11 = text7;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey7 = actionBinding7.GetPcKey();
						if (pcKey7 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance12 = Singleton<Log>.Instance;
							ELogModule module12 = ELogModule.GeneralLogicTree;
							ELogAuthor author12 = ELogAuthor.SYB;
							string message12 = "pcKey为空";
							ValueTuple<string, object> valueTuple12 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance12.Error(module12, author12, message12, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple12));
							return;
						}
						string keyIconPath5 = pcKey7.GetKeyIconPath();
						newText11 = "<texture=" + keyIconPath5 + "/>" + text7;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText11 = (this.GetGamepadShortcutString("任务追踪", text7) ?? text7);
					}
					this.ShortcutTextComp.SetText(newText11, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.SheriffReasoningBoard:
				{
					InputActionBinding actionBinding8 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding8 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance13 = Singleton<Log>.Instance;
						ELogModule module13 = ELogModule.GeneralLogicTree;
						ELogAuthor author13 = ELogAuthor.WHJ;
						string message13 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple13 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance13.Error(module13, author13, message13, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple13));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text8 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Sheriff_HudDesc_3") ?? string.Empty;
					string newText12 = text8;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey8 = actionBinding8.GetPcKey();
						if (pcKey8 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance14 = Singleton<Log>.Instance;
							ELogModule module14 = ELogModule.GeneralLogicTree;
							ELogAuthor author14 = ELogAuthor.WHJ;
							string message14 = "pcKey为空";
							ValueTuple<string, object> valueTuple14 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance14.Error(module14, author14, message14, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple14));
							return;
						}
						string keyIconPath6 = pcKey8.GetKeyIconPath();
						newText12 = "<texture=" + keyIconPath6 + "/>" + text8;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText12 = (this.GetGamepadShortcutString("任务追踪", text8) ?? text8);
					}
					this.ShortcutTextComp.SetText(newText12, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.SheriffMainBoard:
				{
					InputActionBinding actionBinding9 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding9 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance15 = Singleton<Log>.Instance;
						ELogModule module15 = ELogModule.GeneralLogicTree;
						ELogAuthor author15 = ELogAuthor.CB;
						string message15 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple15 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance15.Error(module15, author15, message15, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple15));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text9 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Inference_Desc_34") ?? "进入明慎台";
					string newText13 = text9;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey9 = actionBinding9.GetPcKey();
						if (pcKey9 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance16 = Singleton<Log>.Instance;
							ELogModule module16 = ELogModule.GeneralLogicTree;
							ELogAuthor author16 = ELogAuthor.CB;
							string message16 = "pcKey为空";
							ValueTuple<string, object> valueTuple16 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance16.Error(module16, author16, message16, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple16));
							return;
						}
						string keyIconPath7 = pcKey9.GetKeyIconPath();
						newText13 = "<texture=" + keyIconPath7 + "/>" + text9;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText13 = (this.GetGamepadShortcutString("任务追踪", text9) ?? text9);
					}
					this.ShortcutTextComp.SetText(newText13, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				case EActiveNodeShortcutShow.SheriffClueDetail:
				{
					InputActionBinding actionBinding10 = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
					if (actionBinding10 == null)
					{
						this.ShortcutKeyRoot.SetUIActive(false);
						Log instance17 = Singleton<Log>.Instance;
						ELogModule module17 = ELogModule.GeneralLogicTree;
						ELogAuthor author17 = ELogAuthor.WHJ;
						string message17 = "找不到actionBinding配置";
						ValueTuple<string, object> valueTuple17 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance17.Error(module17, author17, message17, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple17));
						return;
					}
					ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
					string text10 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Inference_Desc_35") ?? string.Empty;
					string newText14 = text10;
					if (Singleton<Info>.Instance.IsInKeyBoard())
					{
						InputKey pcKey10 = actionBinding10.GetPcKey();
						if (pcKey10 == null)
						{
							this.ShortcutKeyRoot.SetUIActive(false);
							Log instance18 = Singleton<Log>.Instance;
							ELogModule module18 = ELogModule.GeneralLogicTree;
							ELogAuthor author18 = ELogAuthor.CB;
							string message18 = "pcKey为空";
							ValueTuple<string, object> valueTuple18 = new ValueTuple<string, object>("actionMapping", "任务追踪");
							instance18.Error(module18, author18, message18, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple18));
							return;
						}
						string keyIconPath8 = pcKey10.GetKeyIconPath();
						newText14 = "<texture=" + keyIconPath8 + "/>" + text10;
					}
					else if (Singleton<Info>.Instance.IsInGamepad())
					{
						newText14 = (this.GetGamepadShortcutString("任务追踪", text10) ?? text10);
					}
					this.ShortcutTextComp.SetText(newText14, true);
					this.ShortcutTextComp.SetAlpha(1f);
					this.ShortcutTextComp.SetUIActive(true);
					this.ShortcutKeyRoot.SetUIActive(true);
					this.ShortcutKeySprite.SetUIActive(false);
					return;
				}
				default:
					return;
				}
			}

			// Token: 0x0604E4A7 RID: 320679 RVA: 0x015AE994 File Offset: 0x015ACB94
			public void UpdateTrackTargetShortcutKey()
			{
				this.RefreshTrackTarget();
			}

			// Token: 0x0604E4A8 RID: 320680 RVA: 0x015AE9A0 File Offset: 0x015ACBA0
			public void RefreshFastReturnShortcutKey()
			{
				if (this.ShowData == null || this.ShowData.DataSource != EMissionItemViewDataSource.BehaviorTree)
				{
					return;
				}
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
				if (behaviorTree == null)
				{
					return;
				}
				bool flag = FastReturnUtil.Resolve(behaviorTree) != null;
				bool flag2 = this.CurShortcutType == EActiveNodeShortcutShow.FastReturn;
				if (flag == flag2)
				{
					return;
				}
				this.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
			}

			// Token: 0x0604E4A9 RID: 320681 RVA: 0x015AEA04 File Offset: 0x015ACC04
			private bool RefreshTrackTarget()
			{
				if (this.CurShortcutType != EActiveNodeShortcutShow.TrackTarget)
				{
					return false;
				}
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("任务追踪");
				if (actionBinding == null)
				{
					this.ShortcutKeyRoot.SetUIActive(false);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GeneralLogicTree;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "找不到actionBinding配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionMapping", "任务追踪");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				if (this.ShowData == null || this.ShowData.DataSource != EMissionItemViewDataSource.BehaviorTree)
				{
					return false;
				}
				BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
				if (behaviorTree == null)
				{
					return false;
				}
				int closestMapMarkId = behaviorTree.GetClosestMapMarkId();
				global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
				if (playerLocation == null)
				{
					return false;
				}
				this.QueryResult = ModelBase<MapModel>.Instance.QueryNearestTeleporter(closestMapMarkId, EMarkType.Quest, playerLocation);
				bool flag = this.QueryResult.Info == null;
				string newText = string.Empty;
				switch (Singleton<Info>.Instance.InputControllerMainType)
				{
				case EInputControllerMainType.Keyboard:
				{
					InputKey pcKey = actionBinding.GetPcKey();
					if (pcKey == null)
					{
						this.ShortcutTextComp.SetUIActive(false);
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.GeneralLogicTree;
						ELogAuthor author2 = ELogAuthor.YSQ;
						string message2 = "pcKey为空";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("actionMapping", "任务追踪");
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return false;
					}
					string keyIconPath = pcKey.GetKeyIconPath();
					string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(flag ? "FastTravel_CurrentLocationIsCloser" : "FastTravel_ClickToFastTravel");
					newText = "<texture=" + keyIconPath + "/>" + multiTextByKey;
					break;
				}
				case EInputControllerMainType.Gamepad:
				{
					string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(flag ? "FastTravel_CurrentLocationIsCloser" : "FastTravel_ClickToFastTravel");
					newText = (this.GetGamepadShortcutString("任务追踪", multiTextByKey2) ?? multiTextByKey2);
					break;
				}
				case EInputControllerMainType.Touch:
					newText = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(flag ? "FastTravel_CurrentLocationIsCloser" : "FastTravel_ClickToFastTravel_Mobile");
					break;
				}
				this.ShortcutTextComp.SetText(newText, true);
				this.ShortcutTextComp.SetAlpha(1f);
				this.ShortcutTextComp.SetUIActive(true);
				this.ShortcutKeyRoot.SetUIActive(true);
				this.ShortcutKeySprite.SetUIActive(Singleton<Info>.Instance.InputControllerMainType == EInputControllerMainType.Touch);
				return true;
			}

			// Token: 0x0604E4AA RID: 320682 RVA: 0x015AEC30 File Offset: 0x015ACE30
			[NullableContext(1)]
			[return: Nullable(2)]
			private string GetGamepadShortcutString(string actionName, string sourceString)
			{
				InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
				if (combinationActionBindingByActionName == null)
				{
					return null;
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				combinationActionBindingByActionName.GetCurrentPlatformKeyNameMap(dictionary);
				string value = actionName;
				string value2 = actionName;
				using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, string> keyValuePair = enumerator.Current;
						string text;
						string text2;
						keyValuePair.Deconstruct(out text, out text2);
						string key = text;
						string key2 = text2;
						InputKey key3 = Singleton<InputSettings>.Instance.GetKey(key);
						InputKey key4 = Singleton<InputSettings>.Instance.GetKey(key2);
						if (key3 != null)
						{
							value = key3.GetKeyIconPath();
						}
						if (key4 != null)
						{
							value2 = key4.GetKeyIconPath();
						}
					}
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 3);
				defaultInterpolatedStringHandler.AppendLiteral("<texture=");
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("/>+<texture=");
				defaultInterpolatedStringHandler.AppendFormatted(value2);
				defaultInterpolatedStringHandler.AppendLiteral("/>");
				defaultInterpolatedStringHandler.AppendFormatted(sourceString);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}

			// Token: 0x0604E4AB RID: 320683 RVA: 0x015AED34 File Offset: 0x015ACF34
			public void OnShortcutKeyClick()
			{
				if (this.ShowData == null || this.ShowData.DataSource != EMissionItemViewDataSource.BehaviorTree)
				{
					return;
				}
				if (this.IsRequesting)
				{
					return;
				}
				this.IsRequesting = true;
				BaseBehaviorTree tree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
				if (tree == null)
				{
					return;
				}
				switch (this.CurShortcutType)
				{
				case EActiveNodeShortcutShow.GiveUp:
				{
					ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PlayEnd);
					confirmBoxDataNew.SetCloseFunction(delegate
					{
						if (tree.ContainTag(EBehaviorTreeTag.RollbackWaiting))
						{
							Singleton<EventSystem>.Instance.EmitWithTarget(tree.GetBlackBoard(), EEventName.GeneralLogicTreeRollbackWaitingUpdate);
						}
					});
					confirmBoxDataNew.FunctionMap[1] = delegate()
					{
						this.IsRequesting = false;
					};
					Action<bool> <>9__3;
					confirmBoxDataNew.FunctionMap[2] = delegate()
					{
						if (this.ShowData == null || tree.ContainTag(EBehaviorTreeTag.RollbackWaiting))
						{
							this.IsRequesting = false;
							return;
						}
						GeneralLogicTreeController instance = ControllerBase<GeneralLogicTreeController>.Instance;
						long id = this.ShowData.Id;
						Action<bool> callback;
						if ((callback = <>9__3) == null)
						{
							callback = (<>9__3 = delegate(bool _)
							{
								this.IsRequesting = false;
							});
						}
						instance.RequestGiveUp(id, callback);
					};
					ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
					return;
				}
				case EActiveNodeShortcutShow.Communicate:
				{
					int? currentCommunicateId = tree.GetBlackBoard().GetCurrentCommunicateId();
					if (currentCommunicateId != null)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.CommunicateAgain, currentCommunicateId.Value);
						this.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
						this.IsRequesting = false;
						return;
					}
					break;
				}
				case EActiveNodeShortcutShow.ChallengeAgain:
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.ChallengeAgain, "重新挑战");
					this.UpdateShortcutButton(EInputControllerType.None, EInputControllerType.None);
					this.IsRequesting = false;
					return;
				case EActiveNodeShortcutShow.TrackTarget:
					if (this.QueryResult != null && this.QueryResult.Info != null)
					{
						ControllerBase<WorldMapController>.Instance.FocusNearestTargetOnWorldMap(this.QueryResult);
						this.IsRequesting = false;
						return;
					}
					break;
				case EActiveNodeShortcutShow.PhoneMessage:
				{
					BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					ITrackCustomBoard trackCustomBoard = (behaviorTree != null) ? behaviorTree.GetCurrentNodeCustomTrackBoard() : null;
					if (trackCustomBoard != null)
					{
						Singleton<QuestUtil>.Instance.HandleTrackCustomBoard(trackCustomBoard, true);
					}
					this.IsRequesting = false;
					return;
				}
				case EActiveNodeShortcutShow.FastReturn:
				{
					BaseBehaviorTree behaviorTree2 = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					FastReturnResolved fastReturnResolved = FastReturnUtil.Resolve(behaviorTree2);
					if (behaviorTree2 != null && fastReturnResolved != null)
					{
						FastReturnUtil.Trigger(behaviorTree2, fastReturnResolved, false, delegate
						{
							this.IsRequesting = false;
						});
						return;
					}
					this.IsRequesting = false;
					return;
				}
				case EActiveNodeShortcutShow.QuestMultiLineView:
				{
					BaseBehaviorTree behaviorTree3 = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					ITrackCustomBoard trackCustomBoard2 = (behaviorTree3 != null) ? behaviorTree3.GetCurrentNodeCustomTrackBoard() : null;
					if (trackCustomBoard2 != null)
					{
						Singleton<QuestUtil>.Instance.HandleTrackCustomBoard(trackCustomBoard2, true);
					}
					this.IsRequesting = false;
					return;
				}
				case EActiveNodeShortcutShow.SheriffAnomalyProgress:
				{
					BaseBehaviorTree behaviorTree4 = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					ITrackCustomBoard trackCustomBoard3 = (behaviorTree4 != null) ? behaviorTree4.GetCurrentNodeCustomTrackBoard() : null;
					if (trackCustomBoard3 != null)
					{
						Singleton<QuestUtil>.Instance.HandleTrackCustomBoard(trackCustomBoard3, true);
					}
					this.IsRequesting = false;
					return;
				}
				case EActiveNodeShortcutShow.SheriffReasoningBoard:
				{
					BaseBehaviorTree behaviorTree5 = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					ITrackCustomBoard trackCustomBoard4 = (behaviorTree5 != null) ? behaviorTree5.GetCurrentNodeCustomTrackBoard() : null;
					if (trackCustomBoard4 != null)
					{
						Singleton<QuestUtil>.Instance.HandleTrackCustomBoard(trackCustomBoard4, true);
					}
					this.IsRequesting = false;
					return;
				}
				case EActiveNodeShortcutShow.SheriffMainBoard:
					ControllerBase<SheriffController>.Instance.OpenSheriffMap(new SheriffMapPanelParam
					{
						OnPanelOpened = delegate
						{
							this.IsRequesting = false;
						}
					});
					return;
				case EActiveNodeShortcutShow.SheriffClueDetail:
				{
					BaseBehaviorTree behaviorTree6 = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(this.ShowData.Id), false);
					ITrackCustomBoard trackCustomBoard5 = (behaviorTree6 != null) ? behaviorTree6.GetCurrentNodeCustomTrackBoard() : null;
					if (trackCustomBoard5 != null)
					{
						Singleton<QuestUtil>.Instance.HandleTrackCustomBoard(trackCustomBoard5, true);
					}
					this.IsRequesting = false;
					break;
				}
				default:
					return;
				}
			}

			// Token: 0x0403B7BF RID: 243647
			private EMissionItemView ViewType;

			// Token: 0x0403B7C0 RID: 243648
			public UUIItem ShortcutKeyRoot;

			// Token: 0x0403B7C1 RID: 243649
			public UUISprite ShortcutKeySprite;

			// Token: 0x0403B7C2 RID: 243650
			public UUIText ShortcutTextComp;

			// Token: 0x0403B7C3 RID: 243651
			private EActiveNodeShortcutShow CurShortcutType;

			// Token: 0x0403B7C4 RID: 243652
			private QueryNearestTeleporterResult QueryResult;

			// Token: 0x0403B7C5 RID: 243653
			private bool IsRequesting;
		}
	}
}
