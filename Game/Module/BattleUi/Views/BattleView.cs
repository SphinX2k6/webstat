using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI;
using CSharpScript.Game.Module.BattleUiSet;
using CSharpScript.Game.Module.PhoneMessage.View;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDE RID: 24542
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleView : UiTickViewBase
	{
		// Token: 0x0603DC14 RID: 252948 RVA: 0x00FBB828 File Offset: 0x00FB9A28
		public BattleView(UiViewInfo viewInfo) : base(viewInfo)
		{
			this.GuideUiItemBuilders.Add("Execution", new TGuideItemBuilder(this.BuilderForExecution));
			this.GuideUiItemBuilders.Add("Skill", new TGuideItemBuilder(this.BuilderForSkill));
			this.GuideUiItemBuilders.Add("Default", new TGuideItemBuilder(this.BuilderForDefault));
			this.GuideUiItemBuilders.Add("Teammate", new TGuideItemBuilder(this.BuilderForTeammate));
			this.GuideUiItemBuilders.Add("FishingViewBtn", new TGuideItemBuilder(this.BuilderForFishingView));
			this.GuideUiItemBuilders.Add("DangoViewBtn", new TGuideItemBuilder(this.BuilderForDangoView));
			this.GuideUiItemBuilders.Add("LinkBtn", new TGuideItemBuilder(this.BuilderForLinkBtn));
			this.GuideUiItemBuilders.Add("DangoMissionButton", new TGuideItemBuilder(this.BuilderForMissionDangoPanel));
			this.GuideUiItemBuilders.Add("MoraleTempExp", new TGuideItemBuilder(this.BuilderForMoraleTempExp));
			this.GuideUiItemBuilders.Add("MoraleExp", new TGuideItemBuilder(this.BuilderForMoraleExp));
			this.GuideUiItemBuilders.Add("ScorePanel", new TGuideItemBuilder(this.BuilderForScorePanel));
			this.GuideUiItemBuilders.Add("WeeklyRogueBtn", new TGuideItemBuilder(this.BuilderForWeeklyRogueBtn));
			this.GuideUiItemBuilders.Add("TimeDilationBtn", new TGuideItemBuilder(this.BuilderForTimeDilationBtn));
			this.GuideUiItemBuilders.Add("HonamiStoryPlayerLevel", new TGuideItemBuilder(this.BuilderForHonamiStoryPlayerLevel));
			this.GuideUiItemBuilders.Add("HonamiStoryMapLevel", new TGuideItemBuilder(this.BuilderForHonamiStoryMapLevel));
			this.GuideUiItemBuilders.Add("HonamiStoryLeaveBtn", new TGuideItemBuilder(this.BuilderForHonamiStoryLeaveBtn));
			this.GuideUiItemBuilders.Add("MotorMobile", new TGuideItemBuilder(this.BuilderForMotorMobile));
			this.GuideUiItemBuilders.Add("FlagChallengeBuff", new TGuideItemBuilder(this.BuilderForTopPanel));
			this.GuideUiItemBuilders.Add("FlagChallengePause", new TGuideItemBuilder(this.BuilderForTopPanel));
			this.GuideUiItemBuilders.Add("FlagChallengeMapBar", new TGuideItemBuilder(this.BuilderForTopPanel));
			this.GuideUiItemBuilders.Add("SkillSprite", new TGuideItemBuilder(this.BuilderForSkillSprite));
			this.GuideUiItemBuilders.Add("SkillTexture", new TGuideItemBuilder(this.BuilderForSkillTexture));
			this.GuideUiItemBuilders.Add("ResDownLoadBtn", new TGuideItemBuilder(this.BuilderForTopPanel));
		}

		// Token: 0x0603DC15 RID: 252949 RVA: 0x00FBBAF8 File Offset: 0x00FB9CF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(12, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(13, typeof(UUIItem)));
			}
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnPureModeClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603DC16 RID: 252950 RVA: 0x00FBBD98 File Offset: 0x00FB9F98
		protected override UniTask OnBeforeStartAsync()
		{
			BattleView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC17 RID: 252951 RVA: 0x00FBBDDC File Offset: 0x00FB9FDC
		private UniTask NewDangoAbyssInfo()
		{
			BattleView.<NewDangoAbyssInfo>d__26 <NewDangoAbyssInfo>d__;
			<NewDangoAbyssInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDangoAbyssInfo>d__.<>4__this = this;
			<NewDangoAbyssInfo>d__.<>1__state = -1;
			<NewDangoAbyssInfo>d__.<>t__builder.Start<BattleView.<NewDangoAbyssInfo>d__26>(ref <NewDangoAbyssInfo>d__);
			return <NewDangoAbyssInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC18 RID: 252952 RVA: 0x00FBBE20 File Offset: 0x00FBA020
		private void RefreshSpecialViewElement()
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (((config != null) ? new int?(config.GetValueOrDefault().WorldDungeonSubType) : null).Value != 1)
			{
				return;
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Mission, false, true, 0);
			}
			BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData2 != null)
			{
				childViewData2.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Formation, false, true, 0);
			}
			BattleUiChildViewData childViewData3 = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData3 == null)
			{
				return;
			}
			childViewData3.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.GamepadFormation, false, true, 0);
		}

		// Token: 0x0603DC19 RID: 252953 RVA: 0x00FBBEE0 File Offset: 0x00FBA0E0
		private UniTask CreateKeyBoardPanel()
		{
			BattleView.<CreateKeyBoardPanel>d__28 <CreateKeyBoardPanel>d__;
			<CreateKeyBoardPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateKeyBoardPanel>d__.<>4__this = this;
			<CreateKeyBoardPanel>d__.<>1__state = -1;
			<CreateKeyBoardPanel>d__.<>t__builder.Start<BattleView.<CreateKeyBoardPanel>d__28>(ref <CreateKeyBoardPanel>d__);
			return <CreateKeyBoardPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC1A RID: 252954 RVA: 0x00FBBF24 File Offset: 0x00FBA124
		private UniTask CreateKeyBoardPanelInner()
		{
			BattleView.<CreateKeyBoardPanelInner>d__29 <CreateKeyBoardPanelInner>d__;
			<CreateKeyBoardPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateKeyBoardPanelInner>d__.<>4__this = this;
			<CreateKeyBoardPanelInner>d__.<>1__state = -1;
			<CreateKeyBoardPanelInner>d__.<>t__builder.Start<BattleView.<CreateKeyBoardPanelInner>d__29>(ref <CreateKeyBoardPanelInner>d__);
			return <CreateKeyBoardPanelInner>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC1B RID: 252955 RVA: 0x00FBBF68 File Offset: 0x00FBA168
		private UniTask CreateGamepadPanel()
		{
			BattleView.<CreateGamepadPanel>d__30 <CreateGamepadPanel>d__;
			<CreateGamepadPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGamepadPanel>d__.<>4__this = this;
			<CreateGamepadPanel>d__.<>1__state = -1;
			<CreateGamepadPanel>d__.<>t__builder.Start<BattleView.<CreateGamepadPanel>d__30>(ref <CreateGamepadPanel>d__);
			return <CreateGamepadPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC1C RID: 252956 RVA: 0x00FBBFAC File Offset: 0x00FBA1AC
		private UniTask CreateGamepadPanelInner()
		{
			BattleView.<CreateGamepadPanelInner>d__31 <CreateGamepadPanelInner>d__;
			<CreateGamepadPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGamepadPanelInner>d__.<>4__this = this;
			<CreateGamepadPanelInner>d__.<>1__state = -1;
			<CreateGamepadPanelInner>d__.<>t__builder.Start<BattleView.<CreateGamepadPanelInner>d__31>(ref <CreateGamepadPanelInner>d__);
			return <CreateGamepadPanelInner>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC1D RID: 252957 RVA: 0x00FBBFF0 File Offset: 0x00FBA1F0
		protected override void OnTick(float delta)
		{
			foreach (BattleChildViewPanel battleChildViewPanel in this.TickPanelList)
			{
				if (battleChildViewPanel.GetVisible())
				{
					battleChildViewPanel.OnTickBattleChildViewPanel(delta);
				}
			}
			this.Proxy.HeadStatePanel.Tick(delta);
			this.PartStatePanel.Tick(delta);
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle == null)
			{
				return;
			}
			formationUnitNodeHandle.Tick(delta);
		}

		// Token: 0x0603DC1E RID: 252958 RVA: 0x00FBC07C File Offset: 0x00FBA27C
		protected override void OnAfterTick(float delta)
		{
			foreach (BattleChildViewPanel battleChildViewPanel in this.TickPanelList)
			{
				if (battleChildViewPanel.GetVisible())
				{
					battleChildViewPanel.OnAfterTickBattleChildViewPanel(delta);
				}
			}
		}

		// Token: 0x0603DC1F RID: 252959 RVA: 0x00FBC0D8 File Offset: 0x00FBA2D8
		protected override void OnBeforeShow()
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.RefreshPureModeBeforeShow();
			this.RefreshMobileUiSet();
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				if (this.GetChildPanelOverrideSwitch(battleChildViewPanel))
				{
					battleChildViewPanel.ShowBattleChildViewPanel();
				}
				else
				{
					battleChildViewPanel.HideBattleChildViewPanel();
				}
			}
			this.RefreshSpecialViewElement();
		}

		// Token: 0x0603DC20 RID: 252960 RVA: 0x00FBC15C File Offset: 0x00FBA35C
		protected override void OnAfterShow()
		{
			if (base.IsDestroyOrDestroying)
			{
				return;
			}
			this.RefreshPureModeAfterShow();
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.BattleView);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			instance.TryBroadcastCacheRoleLevelUpData();
			instance.TryBroadcastCacheRevive();
			Singleton<EventSystem>.Instance.Emit(EEventName.BattleViewActiveSequenceFinish);
			Singleton<EventSystem>.Instance.Emit(EEventName.ActiveBattleView);
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotStart);
		}

		// Token: 0x0603DC21 RID: 252961 RVA: 0x00FBC1C8 File Offset: 0x00FBA3C8
		protected override void OnBeforeHide()
		{
			this.RefreshPureModeBeforeHide();
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.BattleView);
			Singleton<EventSystem>.Instance.Emit(EEventName.DisActiveBattleView);
		}

		// Token: 0x0603DC22 RID: 252962 RVA: 0x00FBC1F0 File Offset: 0x00FBA3F0
		protected override void OnAfterHide()
		{
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				battleChildViewPanel.HideBattleChildViewPanel();
			}
		}

		// Token: 0x0603DC23 RID: 252963 RVA: 0x00FBC248 File Offset: 0x00FBA448
		[NullableContext(2)]
		public UUIItem GetDynamicUIRootItem(EBattleViewChildType childType)
		{
			BattleView.EChildType name;
			if (!BattleView.BattleViewChildMap.TryGetValue(childType, out name))
			{
				return null;
			}
			return base.GetItem((int)name);
		}

		// Token: 0x0603DC24 RID: 252964 RVA: 0x00FBC270 File Offset: 0x00FBA470
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
			this.ResetAllChildViewPanels();
			this.ResetSceneItemDurabilityPanel();
			this.ResetBattleHeadStatePanel();
			this.ResetPartStatePanel();
			this.ResetFormationCooldownExternal();
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle != null)
			{
				formationUnitNodeHandle.Destroy();
			}
			this.FormationUnitNodeHandle = null;
			ControllerBase<BattleViewDynamicUIController>.Instance.UnregisterBattleView(this);
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				this.CheckDestroyTimer = TimerSystem.Instance.Forever(delegate(float _)
				{
					if (ModelBase<GameModeModel>.Instance.WorldDone)
					{
						TimerSystem.Instance.Remove(this.CheckDestroyTimer);
						this.CheckDestroyTimer = null;
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "[battleView]主界面销毁超时，请将本次日志提交给测试", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}, 5000f, 1f, null, null, true);
			}
		}

		// Token: 0x0603DC25 RID: 252965 RVA: 0x00FBC2F9 File Offset: 0x00FBA4F9
		protected override void OnAfterDestroy()
		{
			if (this.CheckDestroyTimer != null)
			{
				TimerSystem.Instance.Remove(this.CheckDestroyTimer);
				this.CheckDestroyTimer = null;
			}
		}

		// Token: 0x0603DC26 RID: 252966 RVA: 0x00FBC31C File Offset: 0x00FBA51C
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnRefreshFormationCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnAllRoleDataChanged));
			Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnCreateEntity));
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Add(EEventName.GmOnlyShowMiniMap, new Action<bool>(this.OnGmOnlyShowMiniMap));
			Singleton<EventSystem>.Instance.Add(EEventName.GmOnlyShowJoyStick, new Action<bool>(this.OnGmOnlyShowJoyStick));
			Singleton<EventSystem>.Instance.Add(EEventName.GmHideMissionAndBossName, new Action<bool>(this.OnGmHideMission));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
			Singleton<EventSystem>.Instance.Add<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, new Action<int, int, float?, float?>(this.OnRefreshFormationCooldownExternal));
			Singleton<EventSystem>.Instance.Add(EEventName.SeamlessTravelFinishBeforeShowUI, new Action(this.OnSeamlessTravelFinish));
			Singleton<EventSystem>.Instance.Add<string>(EEventName.BattleUiPlayAudio, new Action<string>(this.OnBattleUiPlayAudio));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.BattleUiAlphaChanged, new Action<float>(this.OnBattleUiAlphaChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiPureModeChanged, new Action<bool>(this.OnBattleUiPureModeChanged));
			Singleton<EventSystem>.Instance.Add<int, bool, int?, int?, string>(EEventName.OnEnableSceneItemDurabilityUI, new Action<int, bool, int?, int?, string>(this.OnEnableSceneItemDurabilityUI));
			ControllerBase<InputDistributeController>.Instance.BindAction("退出精简模式", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputClosePureModeAction));
			ControllerBase<InputDistributeController>.Instance.BindAction("退出精简模式PC触摸板", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputClosePureModeAction));
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			}
		}

		// Token: 0x0603DC27 RID: 252967 RVA: 0x00FBC52C File Offset: 0x00FBA72C
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnRefreshFormationCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiAllRoleDataChanged, new Action(this.OnAllRoleDataChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnCreateEntity));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Remove(EEventName.GmOnlyShowMiniMap, new Action<bool>(this.OnGmOnlyShowMiniMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.GmOnlyShowJoyStick, new Action<bool>(this.OnGmOnlyShowJoyStick));
			Singleton<EventSystem>.Instance.Remove(EEventName.GmHideMissionAndBossName, new Action<bool>(this.OnGmHideMission));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshFormationCooldownExternalInBattleView, new <>f__AnonymousDelegate5<int, int, float?, float?>(this.OnRefreshFormationCooldownExternal));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeamlessTravelFinishBeforeShowUI, new Action(this.OnSeamlessTravelFinish));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPlayAudio, new Action<string>(this.OnBattleUiPlayAudio));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiAlphaChanged, new Action<float>(this.OnBattleUiAlphaChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiPureModeChanged, new Action<bool>(this.OnBattleUiPureModeChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnableSceneItemDurabilityUI, new Action<int, bool, int?, int?, string>(this.OnEnableSceneItemDurabilityUI));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("退出精简模式", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputClosePureModeAction));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("退出精简模式PC触摸板", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputClosePureModeAction));
			if (Singleton<EventSystem>.Instance.Has(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			}
		}

		// Token: 0x0603DC28 RID: 252968 RVA: 0x00FBC74C File Offset: 0x00FBA94C
		private void OnRefreshFormationCallback()
		{
			this.Proxy.HeadStatePanel.RefreshCurrentRole();
		}

		// Token: 0x0603DC29 RID: 252969 RVA: 0x00FBC760 File Offset: 0x00FBA960
		private void OnAllRoleDataChanged()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null && curRoleData.RoleConfig != null)
			{
				this.PlayFormationSwitchAnim(curRoleData.RoleConfig.Value.RoleType == 2);
			}
		}

		// Token: 0x0603DC2A RID: 252970 RVA: 0x00FBC7A4 File Offset: 0x00FBA9A4
		private void PlayFormationSwitchAnim(bool isPhantom)
		{
			if (this.IsPhantom == isPhantom)
			{
				return;
			}
			this.IsPhantom = isPhantom;
			if (base.IsShow && !this.IsPureModeOpen)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence == null)
				{
					return;
				}
				uiViewSequence.PlaySequencePurely("Switch", false, false);
			}
		}

		// Token: 0x0603DC2B RID: 252971 RVA: 0x00FBC7DE File Offset: 0x00FBA9DE
		private void OnPureModeClicked()
		{
			ControllerBase<BattleUiControl>.Instance.TryClosePureMode();
		}

		// Token: 0x0603DC2C RID: 252972 RVA: 0x00FBC7EB File Offset: 0x00FBA9EB
		private void OnChangeRoleCompleted(EntityHandle newHandle, [Nullable(2)] EntityHandle oldHandle)
		{
			this.Proxy.HeadStatePanel.RefreshCurrentRole();
		}

		// Token: 0x0603DC2D RID: 252973 RVA: 0x00FBC7FD File Offset: 0x00FBA9FD
		[NullableContext(2)]
		private void OnStartSequenceStart(string _ = null)
		{
			if (base.IsShow)
			{
				this.SetActive(true);
			}
		}

		// Token: 0x0603DC2E RID: 252974 RVA: 0x00FBC810 File Offset: 0x00FBAA10
		private void OnCreateEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
		{
			if (!handle.Valid)
			{
				return;
			}
			this.Proxy.HeadStatePanel.OnCreateEntity(handle.Entity);
			this.PartStatePanel.OnCreateEntity(handle.Entity);
			BossStatePanel bossStatePanel = this.BossStatePanel;
			if (bossStatePanel == null)
			{
				return;
			}
			bossStatePanel.OnCreateEntity(handle);
		}

		// Token: 0x0603DC2F RID: 252975 RVA: 0x00FBC85E File Offset: 0x00FBAA5E
		private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			if (!handle.Valid)
			{
				return;
			}
			this.Proxy.HeadStatePanel.OnRemoveEntity(handle.Entity);
			this.PartStatePanel.DestroyPartStateFromRole(handle.Entity);
		}

		// Token: 0x0603DC30 RID: 252976 RVA: 0x00FBC890 File Offset: 0x00FBAA90
		private UniTask PreloadBattleHeadStatePanel()
		{
			BattleView.<PreloadBattleHeadStatePanel>d__52 <PreloadBattleHeadStatePanel>d__;
			<PreloadBattleHeadStatePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadBattleHeadStatePanel>d__.<>4__this = this;
			<PreloadBattleHeadStatePanel>d__.<>1__state = -1;
			<PreloadBattleHeadStatePanel>d__.<>t__builder.Start<BattleView.<PreloadBattleHeadStatePanel>d__52>(ref <PreloadBattleHeadStatePanel>d__);
			return <PreloadBattleHeadStatePanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC31 RID: 252977 RVA: 0x00FBC8D3 File Offset: 0x00FBAAD3
		private void InitializeBattleHeadStatePanel()
		{
			BattleHeadStatePanel headStatePanel = this.Proxy.HeadStatePanel;
			if (headStatePanel == null)
			{
				return;
			}
			headStatePanel.Init();
		}

		// Token: 0x0603DC32 RID: 252978 RVA: 0x00FBC8EA File Offset: 0x00FBAAEA
		private void ResetBattleHeadStatePanel()
		{
			if (this.Proxy.HeadStatePanel == null)
			{
				return;
			}
			this.Proxy.HeadStatePanel.ResetAllHeadStates();
			this.Proxy.HeadStatePanel = null;
		}

		// Token: 0x0603DC33 RID: 252979 RVA: 0x00FBC916 File Offset: 0x00FBAB16
		private void InitializePartStatePanel()
		{
			this.PartStatePanel = new PartStatePanel();
			this.PartStatePanel.InitializePartStatePanel();
		}

		// Token: 0x0603DC34 RID: 252980 RVA: 0x00FBC92E File Offset: 0x00FBAB2E
		private void ResetPartStatePanel()
		{
			if (this.PartStatePanel == null)
			{
				return;
			}
			this.PartStatePanel.ResetPartStatePanel();
			this.PartStatePanel = null;
		}

		// Token: 0x0603DC35 RID: 252981 RVA: 0x00FBC94B File Offset: 0x00FBAB4B
		private void ResetSceneItemDurabilityPanel()
		{
			if (this.SceneItemDurabilityPanel == null)
			{
				return;
			}
			this.SceneItemDurabilityPanel.Reset();
			this.SceneItemDurabilityPanel = null;
		}

		// Token: 0x0603DC36 RID: 252982 RVA: 0x00FBC968 File Offset: 0x00FBAB68
		public void ShowLinkButton(bool isShow)
		{
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle == null)
			{
				return;
			}
			formationUnitNodeHandle.ShowLinkButton(isShow);
		}

		// Token: 0x0603DC37 RID: 252983 RVA: 0x00FBC97B File Offset: 0x00FBAB7B
		public void UpdateTimeDilationButton()
		{
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle == null)
			{
				return;
			}
			formationUnitNodeHandle.UpdateTimeDilationButton();
		}

		// Token: 0x0603DC38 RID: 252984 RVA: 0x00FBC990 File Offset: 0x00FBAB90
		public void OffsetMissionAnchor(float y)
		{
			UUIItem item = base.GetItem(1);
			if (this.MissionOriginalY == -1f)
			{
				this.MissionOriginalY = item.GetAnchorOffsetY();
			}
			item.SetAnchorOffsetY((y == -1f) ? this.MissionOriginalY : (this.MissionOriginalY + y));
		}

		// Token: 0x0603DC39 RID: 252985 RVA: 0x00FBC9DC File Offset: 0x00FBABDC
		[NullableContext(0)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<T> NewBattleChildViewPanel<T>(int rootItemIndex, bool bTick = false, EBattleUiChild childType = EBattleUiChild.Common) where T : BattleChildViewPanel, new()
		{
			BattleView.<NewBattleChildViewPanel>d__62<T> <NewBattleChildViewPanel>d__;
			<NewBattleChildViewPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<NewBattleChildViewPanel>d__.<>4__this = this;
			<NewBattleChildViewPanel>d__.rootItemIndex = rootItemIndex;
			<NewBattleChildViewPanel>d__.bTick = bTick;
			<NewBattleChildViewPanel>d__.childType = childType;
			<NewBattleChildViewPanel>d__.<>1__state = -1;
			<NewBattleChildViewPanel>d__.<>t__builder.Start<BattleView.<NewBattleChildViewPanel>d__62<T>>(ref <NewBattleChildViewPanel>d__);
			return <NewBattleChildViewPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC3A RID: 252986 RVA: 0x00FBCA37 File Offset: 0x00FBAC37
		[NullableContext(2)]
		private BattleChildViewPanel GetPanel(int index)
		{
			return this.PanelMap.GetValueOrDefault(index);
		}

		// Token: 0x0603DC3B RID: 252987 RVA: 0x00FBCA48 File Offset: 0x00FBAC48
		private void OnRouletteViewVisibleChanged(bool bVisible)
		{
			UUIItem rootItem = this.GetPanel(6).GetRootItem();
			UUIItem rootItem2 = (Singleton<Info>.Instance.IsInTouch() ? this.GetPanel(5) : this.GetPanel(7)).GetRootItem();
			int hierarchyIndex = rootItem.GetHierarchyIndex();
			int hierarchyIndex2 = rootItem2.GetHierarchyIndex();
			if (bVisible && hierarchyIndex2 >= hierarchyIndex)
			{
				this.CenterPanelUiIndex = new int?(hierarchyIndex);
				rootItem.SetHierarchyIndex(hierarchyIndex2);
			}
			else if (this.CenterPanelUiIndex != null)
			{
				rootItem.SetHierarchyIndex(this.CenterPanelUiIndex.Value);
				this.CenterPanelUiIndex = null;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "轮盘界面显隐，调整摇杆面板层级";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bVisible", bVisible);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603DC3C RID: 252988 RVA: 0x00FBCB08 File Offset: 0x00FBAD08
		private void OnSeamlessTravelFinish()
		{
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				battleChildViewPanel.OnSeamlessTravelFinish();
			}
		}

		// Token: 0x0603DC3D RID: 252989 RVA: 0x00FBCB60 File Offset: 0x00FBAD60
		private void OnBattleUiPlayAudio(string audioId)
		{
			Singleton<AudioSystem>.Instance.PostEvent(audioId);
		}

		// Token: 0x0603DC3E RID: 252990 RVA: 0x00FBCB6E File Offset: 0x00FBAD6E
		private void OnBattleUiAlphaChanged(float alpha)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAlpha(alpha);
		}

		// Token: 0x0603DC3F RID: 252991 RVA: 0x00FBCB81 File Offset: 0x00FBAD81
		private void OnBattleUiPureModeChanged(bool _)
		{
			this.RefreshPureMode();
		}

		// Token: 0x0603DC40 RID: 252992 RVA: 0x00FBCB8C File Offset: 0x00FBAD8C
		[NullableContext(2)]
		private void OnEnableSceneItemDurabilityUI(int entityId, bool enable, int? durability, int? maxDurability, string tidName)
		{
			if (this.SceneItemDurabilityPanel != null)
			{
				this.SceneItemDurabilityPanel.OnEnableSceneItemDurabilityUI(entityId, enable, durability, maxDurability, tidName);
				return;
			}
			if (!enable || this.IsLoadingDurabilityPanel)
			{
				return;
			}
			this.IsLoadingDurabilityPanel = true;
			UUIItem item = base.GetItem(0);
			this.SceneItemDurabilityPanel = new SceneItemDurabilityStatePanel();
			this.SceneItemDurabilityPanel.OpenParam = EBattleUiChild.SceneItemDurabilityState;
			this.SceneItemDurabilityPanel.CreateThenShowByResourceIdAsync("UiItem_LevelHpState_Prefab", item, false).ContinueWith(delegate()
			{
				this.IsLoadingDurabilityPanel = false;
				if (this.IsDestroyOrDestroying)
				{
					return;
				}
				this.TickPanelList.Add(this.SceneItemDurabilityPanel);
				this.SceneItemDurabilityPanel.OnEnableSceneItemDurabilityUI(entityId, enable, durability, maxDurability, tidName);
			});
		}

		// Token: 0x0603DC41 RID: 252993 RVA: 0x00FBCC5E File Offset: 0x00FBAE5E
		private void OnInputClosePureModeAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (this.IsPureModeOpen)
			{
				ControllerBase<BattleUiControl>.Instance.TryClosePureMode();
				return;
			}
			ControllerBase<BattleUiControl>.Instance.TryOpenPureMode();
		}

		// Token: 0x0603DC42 RID: 252994 RVA: 0x00FBCC84 File Offset: 0x00FBAE84
		private void RefreshPureMode()
		{
			BattleUiPureModeData pureModeData = ModelBase<BattleUiModel>.Instance.PureModeData;
			this.IsPureModeOpen = (pureModeData != null && pureModeData.IsOpen);
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(this.IsPureModeOpen);
			}
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				battleChildViewPanel.RefreshPureMode(this.IsPureModeOpen);
			}
			if (!this.IsPureModeOpen)
			{
				UUIItem item2 = base.GetItem(14);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
			}
		}

		// Token: 0x0603DC43 RID: 252995 RVA: 0x00FBCD30 File Offset: 0x00FBAF30
		private void RefreshPureModeBeforeShow()
		{
			if (!this.IsPureModeOpen)
			{
				return;
			}
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603DC44 RID: 252996 RVA: 0x00FBCD50 File Offset: 0x00FBAF50
		private void RefreshPureModeAfterShow()
		{
			if (!this.IsPureModeOpen)
			{
				return;
			}
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				battleChildViewPanel.RefreshPureMode(this.IsPureModeOpen);
			}
		}

		// Token: 0x0603DC45 RID: 252997 RVA: 0x00FBCDC8 File Offset: 0x00FBAFC8
		private void RefreshPureModeBeforeHide()
		{
			if (!this.IsPureModeOpen)
			{
				return;
			}
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603DC46 RID: 252998 RVA: 0x00FBCDE8 File Offset: 0x00FBAFE8
		private void ResetAllChildViewPanels()
		{
			foreach (BattleChildViewPanel battleChildViewPanel in this.PanelMap.Values)
			{
				battleChildViewPanel.Reset();
			}
			this.PanelMap.Clear();
			this.TickPanelList.Clear();
		}

		// Token: 0x0603DC47 RID: 252999 RVA: 0x00FBCE54 File Offset: 0x00FBB054
		private unsafe void RefreshMobileUiSet()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			foreach (KeyValuePair<int, BattleUiSetPanelData> keyValuePair in ModelBase<BattleUiSetModel>.Instance.GetPanelDataMap())
			{
				int num;
				BattleUiSetPanelData battleUiSetPanelData;
				keyValuePair.Deconstruct(out num, out battleUiSetPanelData);
				int num2 = num;
				BattleUiSetPanelData battleUiSetPanelData2 = battleUiSetPanelData;
				BattleChildViewPanel panel = this.GetPanel(num2);
				if (panel != null)
				{
					foreach (KeyValuePair<int, BattleUiSetPanelItemData> keyValuePair2 in battleUiSetPanelData2.GetPanelItemDataMap())
					{
						BattleUiSetPanelItemData battleUiSetPanelItemData;
						keyValuePair2.Deconstruct(out num, out battleUiSetPanelItemData);
						int num3 = num;
						BattleUiSetPanelItemData battleUiSetPanelItemData2 = battleUiSetPanelItemData;
						if (battleUiSetPanelItemData2.IsInitialized())
						{
							UUIItem uuiitem = panel.GetItem(num3);
							if (num3 == -1)
							{
								uuiitem = panel.GetRootItem();
							}
							if (uuiitem == null)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.BattleUiSet;
								ELogAuthor author = ELogAuthor.CFT;
								string message = "刷新移动端主界面设置时，找不到对应按钮";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("panelIndex", num2);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("panelItemIndex", num3);
								instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
							}
							else
							{
								float size = battleUiSetPanelItemData2.Size;
								float alpha = battleUiSetPanelItemData2.Alpha;
								float offsetX = battleUiSetPanelItemData2.OffsetX;
								float offsetY = battleUiSetPanelItemData2.OffsetY;
								int hierarchyIndex = battleUiSetPanelItemData2.HierarchyIndex;
								uuiitem.SetUIItemScale(new FVector(size));
								uuiitem.SetAnchorOffsetX(offsetX);
								uuiitem.SetAnchorOffsetY(offsetY);
								uuiitem.SetUIItemAlpha(alpha);
								uuiitem.SetHierarchyIndex(hierarchyIndex);
							}
						}
					}
				}
			}
		}

		// Token: 0x0603DC48 RID: 253000 RVA: 0x00FBD02C File Offset: 0x00FBB22C
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				if (Singleton<Info>.Instance.IsInKeyBoard())
				{
					if (!this.IsKeyboardPanelCreated)
					{
						this.<InputControllerChange>g__Invoke|77_1().Forget();
						return;
					}
					FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
					if (formationUnitNodeHandle == null)
					{
						return;
					}
					formationUnitNodeHandle.OnInputControllerChange(this.FormationPanel, this.GamepadFormationPanel);
				}
				return;
			}
			if (!this.IsGamepadPanelCreated)
			{
				this.<InputControllerChange>g__Invoke|77_0().Forget();
				return;
			}
			FormationUnitNodeHandle formationUnitNodeHandle2 = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle2 == null)
			{
				return;
			}
			formationUnitNodeHandle2.OnInputControllerChange(this.FormationPanel, this.GamepadFormationPanel);
		}

		// Token: 0x0603DC49 RID: 253001 RVA: 0x00FBD0B4 File Offset: 0x00FBB2B4
		private void OnGmOnlyShowMiniMap(bool bVisible)
		{
			foreach (KeyValuePair<int, BattleChildViewPanel> keyValuePair in this.PanelMap)
			{
				int num;
				BattleChildViewPanel battleChildViewPanel;
				keyValuePair.Deconstruct(out num, out battleChildViewPanel);
				int num2 = num;
				BattleChildViewPanel battleChildViewPanel2 = battleChildViewPanel;
				if (num2 != 5)
				{
					if (bVisible)
					{
						if (battleChildViewPanel2.GetVisible())
						{
							battleChildViewPanel2.GetRootItem().SetUIActive(true);
						}
					}
					else
					{
						battleChildViewPanel2.GetRootItem().SetUIActive(false);
					}
				}
			}
		}

		// Token: 0x0603DC4A RID: 253002 RVA: 0x00FBD138 File Offset: 0x00FBB338
		private void OnGmOnlyShowJoyStick(bool bVisible)
		{
			foreach (KeyValuePair<int, BattleChildViewPanel> keyValuePair in this.PanelMap)
			{
				int num;
				BattleChildViewPanel battleChildViewPanel;
				keyValuePair.Deconstruct(out num, out battleChildViewPanel);
				int num2 = num;
				BattleChildViewPanel battleChildViewPanel2 = battleChildViewPanel;
				if (num2 != 6)
				{
					if (bVisible)
					{
						if (battleChildViewPanel2.GetVisible())
						{
							battleChildViewPanel2.GetRootItem().SetUIActive(true);
						}
					}
					else
					{
						battleChildViewPanel2.GetRootItem().SetUIActive(false);
					}
				}
			}
		}

		// Token: 0x0603DC4B RID: 253003 RVA: 0x00FBD1BC File Offset: 0x00FBB3BC
		private void OnGmHideMission(bool bVisible)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(bVisible);
			}
			ModelBase<BattleUiModel>.Instance.IsMissionPanelVisible = bVisible;
		}

		// Token: 0x0603DC4C RID: 253004 RVA: 0x00FBD1DC File Offset: 0x00FBB3DC
		private bool GetChildPanelOverrideSwitch(BattleChildViewPanel panel)
		{
			return !panel.IsChildType(EBattleUiChild.Mission) || ModelBase<BattleUiModel>.Instance.IsMissionPanelVisible;
		}

		// Token: 0x0603DC4D RID: 253005 RVA: 0x00FBD1F8 File Offset: 0x00FBB3F8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForExecution(string[] configParams)
		{
			CenterPanel centerPanel = this.PanelMap.GetValueOrDefault(6) as CenterPanel;
			if (centerPanel == null)
			{
				return null;
			}
			UUIItem executionItem = centerPanel.GetExecutionItem();
			if (executionItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				executionItem,
				executionItem
			};
		}

		// Token: 0x0603DC4E RID: 253006 RVA: 0x00FBD236 File Offset: 0x00FBB436
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForSkill(string[] configParams)
		{
			BattleSkillItem activeSkillItemForGuide = this.GetActiveSkillItemForGuide(configParams);
			if (activeSkillItemForGuide == null)
			{
				return null;
			}
			return activeSkillItemForGuide.GetGuideItem();
		}

		// Token: 0x0603DC4F RID: 253007 RVA: 0x00FBD24C File Offset: 0x00FBB44C
		[return: Nullable(2)]
		private BattleSkillItem GetActiveSkillItemForGuide(string[] configParams)
		{
			int buttonType = int.Parse(configParams[1]);
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				GamepadSkillButtonPanel gamepadSkillButtonPanel = this.PanelMap.GetValueOrDefault(13) as GamepadSkillButtonPanel;
				if (gamepadSkillButtonPanel == null)
				{
					return null;
				}
				return gamepadSkillButtonPanel.GetBattleSkillItemByButtonType(buttonType);
			}
			else
			{
				SkillButtonPanel skillButtonPanel = this.PanelMap.GetValueOrDefault(3) as SkillButtonPanel;
				if (skillButtonPanel == null)
				{
					return null;
				}
				return skillButtonPanel.GetBattleSkillItemByButtonType((ESkillButtonType)buttonType);
			}
		}

		// Token: 0x0603DC50 RID: 253008 RVA: 0x00FBD2AA File Offset: 0x00FBB4AA
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForSkillSprite(string[] configParams)
		{
			BattleSkillItem activeSkillItemForGuide = this.GetActiveSkillItemForGuide(configParams);
			if (activeSkillItemForGuide == null)
			{
				return null;
			}
			return activeSkillItemForGuide.GetSpriteGuideItem();
		}

		// Token: 0x0603DC51 RID: 253009 RVA: 0x00FBD2BE File Offset: 0x00FBB4BE
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForSkillTexture(string[] configParams)
		{
			BattleSkillItem activeSkillItemForGuide = this.GetActiveSkillItemForGuide(configParams);
			if (activeSkillItemForGuide == null)
			{
				return null;
			}
			return activeSkillItemForGuide.GetTextureGuideItem();
		}

		// Token: 0x0603DC52 RID: 253010 RVA: 0x00FBD2D4 File Offset: 0x00FBB4D4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForDefault(string[] configParams)
		{
			BattleChildViewPanel valueOrDefault = this.PanelMap.GetValueOrDefault(int.Parse(configParams[0]));
			object obj;
			if (valueOrDefault == null)
			{
				obj = null;
			}
			else
			{
				AActor uiActorForGuide = valueOrDefault.GetUiActorForGuide();
				obj = ((uiActorForGuide != null) ? uiActorForGuide.GetComponentByClass(UGuideHookRegistry.StaticClass()) : null);
			}
			UGuideHookRegistry uguideHookRegistry = obj as UGuideHookRegistry;
			if (uguideHookRegistry == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "战斗界面挂接组件(GuideHookRegistry)缺失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤参数", configParams);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			string text = configParams[2];
			TWeakObjectPtr<AActor> tweakObjectPtr;
			if (uguideHookRegistry.GuideHookComponents.TryGetValue(text, out tweakObjectPtr))
			{
				AUIBaseActor auibaseActor = tweakObjectPtr.Get() as AUIBaseActor;
				if (auibaseActor != null)
				{
					UUIItem uiitem = auibaseActor.GetUIItem();
					string text2 = configParams[1];
					if (string.IsNullOrEmpty(text2))
					{
						text2 = text;
					}
					TWeakObjectPtr<AActor> tweakObjectPtr2;
					if (uguideHookRegistry.GuideHookComponents.TryGetValue(text2, out tweakObjectPtr2))
					{
						AUIBaseActor auibaseActor2 = tweakObjectPtr2.Get() as AUIBaseActor;
						if (auibaseActor2 != null)
						{
							UUIItem uiitem2 = auibaseActor2.GetUIItem();
							return new UUIItem[]
							{
								uiitem,
								uiitem2
							};
						}
					}
					Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "战斗界面挂接组件(GuideHookRegistry)不存在该挂接点（展示用）名称，请检查聚焦引导配置或挂接组件", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
			}
			Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "战斗界面挂接组件(GuideHookRegistry)不存在该挂接点名称，请检查聚焦引导配置或挂接组件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x0603DC53 RID: 253011 RVA: 0x00FBD400 File Offset: 0x00FBB600
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForTeammate(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(2);
			if (panel == null)
			{
				return null;
			}
			foreach (FormationItem formationItem in (panel as FormationPanel).GetFormationItemList())
			{
				if (!formationItem.IsMyRole)
				{
					UUIItem rootItem = formationItem.GetRootItem();
					if (rootItem == null)
					{
						return null;
					}
					return new UUIItem[]
					{
						rootItem,
						rootItem
					};
				}
			}
			return null;
		}

		// Token: 0x0603DC54 RID: 253012 RVA: 0x00FBD48C File Offset: 0x00FBB68C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForFishingView(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC55 RID: 253013 RVA: 0x00FBD4A1 File Offset: 0x00FBB6A1
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForDangoView(string[] configParams)
		{
			DangoWorldMainPanel dangoWorldMainPanel = this.DangoWorldMainPanel;
			if (dangoWorldMainPanel == null)
			{
				return null;
			}
			return dangoWorldMainPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC56 RID: 253014 RVA: 0x00FBD4B8 File Offset: 0x00FBB6B8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForLinkBtn(string[] configParams)
		{
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			UUIItem uuiitem;
			if (formationUnitNodeHandle == null)
			{
				uuiitem = null;
			}
			else
			{
				BattleLinkEnergyButton linkEnergyButton = formationUnitNodeHandle.GetLinkEnergyButton();
				uuiitem = ((linkEnergyButton != null) ? linkEnergyButton.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x0603DC57 RID: 253015 RVA: 0x00FBD4F7 File Offset: 0x00FBB6F7
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForMissionDangoPanel(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(1);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC58 RID: 253016 RVA: 0x00FBD50C File Offset: 0x00FBB70C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForMoraleTempExp(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(4);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC59 RID: 253017 RVA: 0x00FBD521 File Offset: 0x00FBB721
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForMoraleExp(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC5A RID: 253018 RVA: 0x00FBD536 File Offset: 0x00FBB736
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForScorePanel(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(11);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC5B RID: 253019 RVA: 0x00FBD54C File Offset: 0x00FBB74C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForWeeklyRogueBtn(string[] configParams)
		{
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			if (formationUnitNodeHandle == null)
			{
				return null;
			}
			BattleWeeklyRogueButton weeklyRogueButton = formationUnitNodeHandle.GetWeeklyRogueButton();
			if (weeklyRogueButton == null)
			{
				return null;
			}
			return weeklyRogueButton.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC5C RID: 253020 RVA: 0x00FBD56C File Offset: 0x00FBB76C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForTimeDilationBtn(string[] configParams)
		{
			FormationUnitNodeHandle formationUnitNodeHandle = this.FormationUnitNodeHandle;
			UUIItem uuiitem;
			if (formationUnitNodeHandle == null)
			{
				uuiitem = null;
			}
			else
			{
				BattleTimeDilationButton battleTimeDilationButton = formationUnitNodeHandle.GetBattleTimeDilationButton();
				uuiitem = ((battleTimeDilationButton != null) ? battleTimeDilationButton.GetRootItem() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x0603DC5D RID: 253021 RVA: 0x00FBD5AB File Offset: 0x00FBB7AB
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForHonamiStoryPlayerLevel(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC5E RID: 253022 RVA: 0x00FBD5C0 File Offset: 0x00FBB7C0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForHonamiStoryMapLevel(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC5F RID: 253023 RVA: 0x00FBD5D5 File Offset: 0x00FBB7D5
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForHonamiStoryLeaveBtn(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC60 RID: 253024 RVA: 0x00FBD5EA File Offset: 0x00FBB7EA
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForMotorMobile(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(6);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC61 RID: 253025 RVA: 0x00FBD5FF File Offset: 0x00FBB7FF
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] BuilderForTopPanel(string[] configParams)
		{
			BattleChildViewPanel panel = this.GetPanel(5);
			if (panel == null)
			{
				return null;
			}
			return panel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603DC62 RID: 253026 RVA: 0x00FBD614 File Offset: 0x00FBB814
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.WZ, "BattleView相关的引导Extra参数设置错误，不能为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			TGuideItemBuilder tguideItemBuilder;
			if (this.GuideUiItemBuilders.TryGetValue(configParams[0], out tguideItemBuilder))
			{
				return tguideItemBuilder(configParams);
			}
			return this.GuideUiItemBuilders["Default"](configParams);
		}

		// Token: 0x0603DC63 RID: 253027 RVA: 0x00FBD673 File Offset: 0x00FBB873
		private void OnRefreshFormationCooldownExternal(int playerId, int roleId, float? remainCd = null, float? totalCd = null)
		{
			FormationPanel gamepadFormationPanel = this.GamepadFormationPanel;
			if (gamepadFormationPanel != null)
			{
				gamepadFormationPanel.RefreshFormationCooldownExternal(playerId, roleId, remainCd, totalCd);
			}
			FormationPanel formationPanel = this.FormationPanel;
			if (formationPanel == null)
			{
				return;
			}
			formationPanel.RefreshFormationCooldownExternal(playerId, roleId, remainCd, totalCd);
		}

		// Token: 0x0603DC64 RID: 253028 RVA: 0x00FBD6A0 File Offset: 0x00FBB8A0
		public void ResetFormationCooldownExternal()
		{
			FormationPanel gamepadFormationPanel = this.GamepadFormationPanel;
			if (gamepadFormationPanel != null)
			{
				gamepadFormationPanel.ResetFormationCooldownExternal();
			}
			FormationPanel formationPanel = this.FormationPanel;
			if (formationPanel == null)
			{
				return;
			}
			formationPanel.ResetFormationCooldownExternal();
		}

		// Token: 0x0603DC65 RID: 253029 RVA: 0x00FBD6C4 File Offset: 0x00FBB8C4
		private UniTask NewFormationUnitNode()
		{
			BattleView.<NewFormationUnitNode>d__107 <NewFormationUnitNode>d__;
			<NewFormationUnitNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFormationUnitNode>d__.<>4__this = this;
			<NewFormationUnitNode>d__.<>1__state = -1;
			<NewFormationUnitNode>d__.<>t__builder.Start<BattleView.<NewFormationUnitNode>d__107>(ref <NewFormationUnitNode>d__);
			return <NewFormationUnitNode>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC66 RID: 253030 RVA: 0x00FBD707 File Offset: 0x00FBB907
		[NullableContext(2)]
		public UUIItem GetTopPanelPhoneMsgButtonItem()
		{
			TopPanel topPanel = this.GetPanel(5) as TopPanel;
			if (topPanel == null)
			{
				return null;
			}
			return topPanel.GetPanelItem("PhoneMsgButton");
		}

		// Token: 0x0603DC67 RID: 253031 RVA: 0x00FBD725 File Offset: 0x00FBB925
		[NullableContext(2)]
		public IPhoneMessageButtonImplement GetTopPanelPhoneMsgButton()
		{
			TopPanel topPanel = this.GetPanel(5) as TopPanel;
			if (topPanel == null)
			{
				return null;
			}
			return topPanel.GetPhoneMsgButton();
		}

		// Token: 0x0603DC68 RID: 253032 RVA: 0x00FBD740 File Offset: 0x00FBB940
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UUIItem> GetTopPanelEntitySequenceButtonRootAsync()
		{
			BattleView.<GetTopPanelEntitySequenceButtonRootAsync>d__110 <GetTopPanelEntitySequenceButtonRootAsync>d__;
			<GetTopPanelEntitySequenceButtonRootAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UUIItem>.Create();
			<GetTopPanelEntitySequenceButtonRootAsync>d__.<>4__this = this;
			<GetTopPanelEntitySequenceButtonRootAsync>d__.<>1__state = -1;
			<GetTopPanelEntitySequenceButtonRootAsync>d__.<>t__builder.Start<BattleView.<GetTopPanelEntitySequenceButtonRootAsync>d__110>(ref <GetTopPanelEntitySequenceButtonRootAsync>d__);
			return <GetTopPanelEntitySequenceButtonRootAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC69 RID: 253033 RVA: 0x00FBD783 File Offset: 0x00FBB983
		[NullableContext(2)]
		public PositionPanel GetPositionPanel()
		{
			return this.GetPanel(9) as PositionPanel;
		}

		// Token: 0x0603DC6C RID: 253036 RVA: 0x00FBD87C File Offset: 0x00FBBA7C
		[CompilerGenerated]
		private UniTask <InputControllerChange>g__Invoke|77_0()
		{
			BattleView.<<InputControllerChange>g__Invoke|77_0>d <<InputControllerChange>g__Invoke|77_0>d;
			<<InputControllerChange>g__Invoke|77_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<InputControllerChange>g__Invoke|77_0>d.<>4__this = this;
			<<InputControllerChange>g__Invoke|77_0>d.<>1__state = -1;
			<<InputControllerChange>g__Invoke|77_0>d.<>t__builder.Start<BattleView.<<InputControllerChange>g__Invoke|77_0>d>(ref <<InputControllerChange>g__Invoke|77_0>d);
			return <<InputControllerChange>g__Invoke|77_0>d.<>t__builder.Task;
		}

		// Token: 0x0603DC6D RID: 253037 RVA: 0x00FBD8C0 File Offset: 0x00FBBAC0
		[CompilerGenerated]
		private UniTask <InputControllerChange>g__Invoke|77_1()
		{
			BattleView.<<InputControllerChange>g__Invoke|77_1>d <<InputControllerChange>g__Invoke|77_1>d;
			<<InputControllerChange>g__Invoke|77_1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<InputControllerChange>g__Invoke|77_1>d.<>4__this = this;
			<<InputControllerChange>g__Invoke|77_1>d.<>1__state = -1;
			<<InputControllerChange>g__Invoke|77_1>d.<>t__builder.Start<BattleView.<<InputControllerChange>g__Invoke|77_1>d>(ref <<InputControllerChange>g__Invoke|77_1>d);
			return <<InputControllerChange>g__Invoke|77_1>d.<>t__builder.Task;
		}

		// Token: 0x04022A4F RID: 141903
		private const int CHECK_DESTROY_TIME = 5000;

		// Token: 0x04022A50 RID: 141904
		private static readonly IReadOnlyDictionary<EBattleViewChildType, BattleView.EChildType> BattleViewChildMap = new Dictionary<EBattleViewChildType, BattleView.EChildType>
		{
			{
				EBattleViewChildType.BossStatePanel,
				BattleView.EChildType.BossStatePanel
			},
			{
				EBattleViewChildType.MissionPanel,
				BattleView.EChildType.MissionPanel
			},
			{
				EBattleViewChildType.FormationPanel,
				BattleView.EChildType.FormationPanel
			},
			{
				EBattleViewChildType.SkillButtonPanel,
				BattleView.EChildType.SkillButtonPanel
			},
			{
				EBattleViewChildType.BottomPanel,
				BattleView.EChildType.BottomPanel
			},
			{
				EBattleViewChildType.TopPanel,
				BattleView.EChildType.TopPanel
			},
			{
				EBattleViewChildType.CenterPanel,
				BattleView.EChildType.CenterPanel
			},
			{
				EBattleViewChildType.ChatPanel,
				BattleView.EChildType.ChatPanel
			},
			{
				EBattleViewChildType.FullScreenPanel,
				BattleView.EChildType.FullScreenPanel
			},
			{
				EBattleViewChildType.PositionPanel,
				BattleView.EChildType.PositionPanel
			},
			{
				EBattleViewChildType.OnlineInstanceDungeonDeathPanel,
				BattleView.EChildType.OnlineInstanceDungeonDeathPanel
			},
			{
				EBattleViewChildType.ScorePanel,
				BattleView.EChildType.ScorePanel
			}
		};

		// Token: 0x04022A51 RID: 141905
		[Nullable(2)]
		private PartStatePanel PartStatePanel;

		// Token: 0x04022A52 RID: 141906
		[Nullable(2)]
		private BossStatePanel BossStatePanel;

		// Token: 0x04022A53 RID: 141907
		[Nullable(2)]
		private FormationPanel FormationPanel;

		// Token: 0x04022A54 RID: 141908
		[Nullable(2)]
		private SkillButtonPanel SkillButtonPanel;

		// Token: 0x04022A55 RID: 141909
		[Nullable(2)]
		private FormationPanel GamepadFormationPanel;

		// Token: 0x04022A56 RID: 141910
		[Nullable(2)]
		private GamepadSkillButtonPanel GamepadSkillButtonPanel;

		// Token: 0x04022A57 RID: 141911
		[Nullable(2)]
		private DangoWorldMainPanel DangoWorldMainPanel;

		// Token: 0x04022A58 RID: 141912
		[Nullable(2)]
		private SceneItemDurabilityStatePanel SceneItemDurabilityPanel;

		// Token: 0x04022A59 RID: 141913
		private bool IsLoadingDurabilityPanel;

		// Token: 0x04022A5A RID: 141914
		private bool IsKeyboardPanelCreated;

		// Token: 0x04022A5B RID: 141915
		private bool IsGamepadPanelCreated;

		// Token: 0x04022A5C RID: 141916
		private readonly Dictionary<int, BattleChildViewPanel> PanelMap = new Dictionary<int, BattleChildViewPanel>();

		// Token: 0x04022A5D RID: 141917
		private readonly List<BattleChildViewPanel> TickPanelList = new List<BattleChildViewPanel>();

		// Token: 0x04022A5E RID: 141918
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]BattleViewTick", "", "");

		// Token: 0x04022A5F RID: 141919
		private int? CenterPanelUiIndex;

		// Token: 0x04022A60 RID: 141920
		private bool IsPhantom;

		// Token: 0x04022A61 RID: 141921
		private bool IsPureModeOpen;

		// Token: 0x04022A62 RID: 141922
		[Nullable(2)]
		private FormationUnitNodeHandle FormationUnitNodeHandle;

		// Token: 0x04022A63 RID: 141923
		public BattleViewProxy Proxy = new BattleViewProxy();

		// Token: 0x04022A64 RID: 141924
		[Nullable(2)]
		private TimerHandle CheckDestroyTimer;

		// Token: 0x04022A65 RID: 141925
		private float MissionOriginalY = -1f;

		// Token: 0x04022A66 RID: 141926
		private readonly Dictionary<string, TGuideItemBuilder> GuideUiItemBuilders = new Dictionary<string, TGuideItemBuilder>();

		// Token: 0x0200C05B RID: 49243
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B32F RID: 242479
			BossStatePanel,
			// Token: 0x0403B330 RID: 242480
			MissionPanel,
			// Token: 0x0403B331 RID: 242481
			FormationPanel,
			// Token: 0x0403B332 RID: 242482
			SkillButtonPanel,
			// Token: 0x0403B333 RID: 242483
			BottomPanel,
			// Token: 0x0403B334 RID: 242484
			TopPanel,
			// Token: 0x0403B335 RID: 242485
			CenterPanel,
			// Token: 0x0403B336 RID: 242486
			ChatPanel,
			// Token: 0x0403B337 RID: 242487
			FullScreenPanel,
			// Token: 0x0403B338 RID: 242488
			PositionPanel,
			// Token: 0x0403B339 RID: 242489
			OnlineInstanceDungeonDeathPanel,
			// Token: 0x0403B33A RID: 242490
			ScorePanel,
			// Token: 0x0403B33B RID: 242491
			PureModeRootItem = 14,
			// Token: 0x0403B33C RID: 242492
			PureModeItem,
			// Token: 0x0403B33D RID: 242493
			PureModeButton
		}

		// Token: 0x0200C05C RID: 49244
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B33F RID: 242495
			GamepadFormationPanel = 12,
			// Token: 0x0403B340 RID: 242496
			GamepadSkillButtonPanel
		}
	}
}
