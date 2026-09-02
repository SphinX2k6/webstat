using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.AlertArea;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.PhoneMessage.View;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB4 RID: 24500
	[NullableContext(2)]
	[Nullable(0)]
	public class TopPanel : BattleChildViewPanel
	{
		// Token: 0x0603D933 RID: 252211 RVA: 0x00FAF488 File Offset: 0x00FAD688
		protected unsafe override void OnRegisterComponent()
		{
			int num = 37;
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
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(40, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(41, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(42, typeof(UUIItem)));
			}
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(18, new Action<EToggleState>(this.OnClickIosVoiceToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D934 RID: 252212 RVA: 0x00FAFA30 File Offset: 0x00FADC30
		public override UniTask InitializeAsync()
		{
			TopPanel.<InitializeAsync>d__45 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<TopPanel.<InitializeAsync>d__45>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D935 RID: 252213 RVA: 0x00FAFA73 File Offset: 0x00FADC73
		public override void OnSeamlessTravelFinish()
		{
			this.MiniMapView.RefreshMiniMap();
			this.RefreshAllButtonVisible();
		}

		// Token: 0x0603D936 RID: 252214 RVA: 0x00FAFA88 File Offset: 0x00FADC88
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Default, TopPanel.BattleUiChildren, true, true, 0);
			this.MiniMapView.ShowBattleVisibleChildView(false);
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.ShowBattleVisibleChildView(false);
			}
			this.SilentAreaView.ShowBattleVisibleChildView(false);
			this.TowerGuideButton.ShowBattleVisibleChildView(false);
			this.ShipTowerBuffView.ShowBattleVisibleChildView(false);
			this.MoraleBuffView.ShowBattleVisibleChildView(false);
			this.MowingRiskView.ShowBattleVisibleChildView(false);
			this.BabelTowerBattleTopPanel.ShowBattleVisibleChildView(false);
			this.ResDownLoadItemTopPanel.ShowBattleVisibleChildView(false);
			this.AlertAreaInfoView.ShowBattleVisibleChildView(false);
			this.WavePlateTip.ShowBattleVisibleChildView(false);
			this.FishingView.ShowBattleVisibleChildView(false);
			this.MoraleExpView.ShowBattleVisibleChildView(false);
			FlagChallengeExpView flagChallengeExpView = this.FlagChallengeExpView;
			if (flagChallengeExpView != null)
			{
				flagChallengeExpView.ShowBattleVisibleChildView(false);
			}
			BattleHonamiStoryMapLevelView honamiStoryMapLevelView = this.HonamiStoryMapLevelView;
			if (honamiStoryMapLevelView != null)
			{
				honamiStoryMapLevelView.ShowBattleVisibleChildView(false);
			}
			BattleHonamiStoryPlayerStateView honamiStoryPlayerStateView = this.HonamiStoryPlayerStateView;
			if (honamiStoryPlayerStateView != null)
			{
				honamiStoryPlayerStateView.ShowBattleVisibleChildView(false);
			}
			BossPilingTopItem bossPilingTopItem = this.BossPilingTopItem;
			if (bossPilingTopItem != null)
			{
				bossPilingTopItem.ShowBattleVisibleChildView(false);
			}
			if (this.IsGamepad && !this.OnlineButton.GetActive())
			{
				this.OnlineButton.RefreshButtonState();
			}
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter == null)
			{
				return;
			}
			uiHookCenter.OnShow(this);
		}

		// Token: 0x0603D937 RID: 252215 RVA: 0x00FAFBFC File Offset: 0x00FADDFC
		protected override void OnHideBattleChildViewPanel()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Default, TopPanel.BattleUiChildren, false, true, 0);
			this.MiniMapView.HideBattleVisibleChildView();
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.HideBattleVisibleChildView();
			}
			this.SilentAreaView.HideBattleVisibleChildView();
			this.ShipTowerBuffView.HideBattleVisibleChildView();
			this.MoraleBuffView.HideBattleVisibleChildView();
			this.MowingRiskView.HideBattleVisibleChildView();
			this.BabelTowerBattleTopPanel.HideBattleVisibleChildView();
			this.ResDownLoadItemTopPanel.HideBattleVisibleChildView();
			this.WavePlateTip.HideBattleVisibleChildView();
			this.AlertAreaInfoView.HideBattleVisibleChildView();
			this.FishingView.HideBattleVisibleChildView();
			this.MoraleExpView.HideBattleVisibleChildView();
			FlagChallengeExpView flagChallengeExpView = this.FlagChallengeExpView;
			if (flagChallengeExpView != null)
			{
				flagChallengeExpView.HideBattleVisibleChildView();
			}
			BattleHonamiStoryMapLevelView honamiStoryMapLevelView = this.HonamiStoryMapLevelView;
			if (honamiStoryMapLevelView != null)
			{
				honamiStoryMapLevelView.HideBattleVisibleChildView();
			}
			BattleHonamiStoryPlayerStateView honamiStoryPlayerStateView = this.HonamiStoryPlayerStateView;
			if (honamiStoryPlayerStateView != null)
			{
				honamiStoryPlayerStateView.HideBattleVisibleChildView();
			}
			BossPilingTopItem bossPilingTopItem = this.BossPilingTopItem;
			if (bossPilingTopItem != null)
			{
				bossPilingTopItem.HideBattleVisibleChildView();
			}
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter == null)
			{
				return;
			}
			uiHookCenter.OnHide(this);
		}

		// Token: 0x0603D938 RID: 252216 RVA: 0x00FAFD34 File Offset: 0x00FADF34
		private void RefreshAllButtonVisible()
		{
			this.IsGamepad = Singleton<Info>.Instance.IsInGamepad();
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.SetGamepadHide(this.IsGamepad);
			}
			this.RefreshExitButtonVisibleState();
			this.RefreshActivityVisibleState();
			this.RefreshDirectTrainProState();
			this.RefreshTowerGuideVisibleState();
			this.RefreshShipTowerBuffVisibleState();
			this.RefreshMoraleBuffVisibleState();
			this.RefreshBabelTowerTopPanelState();
			this.RefreshShipTowerTopPanelState();
			this.RefreshResDownLoadTopPanelState();
			this.RefreshMowingRiskVisibleState();
			this.RefreshBattleLinkVisibleState();
			this.DungeonChange();
			this.RefreshSilentAreaViewVisibleState();
			this.RefreshAreaAlertUiVisibleState(0, false);
			this.RefreshMoraleUiVisibleState();
			this.RefreshFlagChallengeUiVisibleState();
			this.RefreshActivityDungeonState();
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter != null)
			{
				uiHookCenter.OnRefresh(this);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "IOS 审核音乐Toggle";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BaseConfigController.GetIosAuditFirstDownloadTip()", Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS && Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip())
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(18);
				if (extendToggle != null)
				{
					extendToggle.RootUIComp.Get().SetUIActive(true);
				}
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(18);
				if (extendToggle2 != null)
				{
					extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				}
				Singleton<Log>.Instance.Info(ELogModule.BattleUiSet, ELogAuthor.YZY, "初始化IOS 背景播放按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (this.IsGamepad)
			{
				base.GetItem(40).SetUIActive(false);
				this.RefreshGamepad();
				return;
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				base.GetItem(40).SetUIActive(true);
			}
		}

		// Token: 0x0603D939 RID: 252217 RVA: 0x00FAFEF4 File Offset: 0x00FAE0F4
		public override void Reset()
		{
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter != null)
			{
				uiHookCenter.OnReset(this);
			}
			this.MiniMapView.Reset();
			this.MiniMapView = null;
			this.ButtonList = null;
			base.Reset();
		}

		// Token: 0x0603D93A RID: 252218 RVA: 0x00FAFF28 File Offset: 0x00FAE128
		public override void OnTickBattleChildViewPanel(float delta)
		{
			this.MiniMapView.RefreshShow();
			AlertAreaInfoView alertAreaInfoView = this.AlertAreaInfoView;
			if (alertAreaInfoView != null)
			{
				alertAreaInfoView.Tick(delta);
			}
			MoraleExpView moraleExpView = this.MoraleExpView;
			if (moraleExpView != null)
			{
				moraleExpView.Tick(delta);
			}
			FlagChallengeExpView flagChallengeExpView = this.FlagChallengeExpView;
			if (flagChallengeExpView == null)
			{
				return;
			}
			flagChallengeExpView.Tick(delta);
		}

		// Token: 0x0603D93B RID: 252219 RVA: 0x00FAFF78 File Offset: 0x00FAE178
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityUpdate, new Action(this.OnActivityUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.DungeonGuideChange, new Action(this.DungeonChange));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.GmOnlyShowMiniMap, new Action<bool>(this.OnGmOnlyShowMiniMap));
			Singleton<EventSystem>.Instance.Add<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, new Action<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(this.OnBehaviorTreeStartShow));
			Singleton<EventSystem>.Instance.Add<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, new Action<long, ETreeTextExpressReason, bool>(this.OnBehaviorTreeEndShow));
			Singleton<EventSystem>.Instance.Add(EEventName.OnShowTowerGuideButton, new Action(this.OnShowTowerGuideButton));
			Singleton<EventSystem>.Instance.Add(EEventName.MowingRiskInBattleViewSetActive, new Action<bool>(this.MowingRiskInBattleView));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.OnUpdateAreaAlertUiVisible, new Action<int, bool>(this.RefreshAreaAlertUiVisibleState));
			Singleton<EventSystem>.Instance.Add(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleActiveChanged, new Action<bool>(this.OnMoraleActiveChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.OnCharOnBuffAddShowMoraleBuffTips));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityDirectTrainProSetActive, new Action<bool>(this.OnActivityDirectTrainProSetActive));
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter == null)
			{
				return;
			}
			uiHookCenter.OnAddEventListener(this);
		}

		// Token: 0x0603D93C RID: 252220 RVA: 0x00FB0190 File Offset: 0x00FAE390
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityUpdate, new Action(this.OnActivityUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.DungeonGuideChange, new Action(this.DungeonChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.GmOnlyShowMiniMap, new Action<bool>(this.OnGmOnlyShowMiniMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeStartShowTrackText, new Action<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(this.OnBehaviorTreeStartShow));
			Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeEndShowTrackText, new Action<long, ETreeTextExpressReason, bool>(this.OnBehaviorTreeEndShow));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnShowTowerGuideButton, new Action(this.OnShowTowerGuideButton));
			Singleton<EventSystem>.Instance.Remove(EEventName.MowingRiskInBattleViewSetActive, new Action<bool>(this.MowingRiskInBattleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateAreaAlertUiVisible, new <>f__AnonymousDelegate4<int, bool>(this.RefreshAreaAlertUiVisibleState));
			Singleton<EventSystem>.Instance.Remove(EEventName.DriveFishingShipStateChanged, new Action<bool>(this.OnDriveFishingShipStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackDownLoadState, new Action(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSubPackageDownLoadByPriority, new Action(this.ResDownLoadStateRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleActiveChanged, new Action<bool>(this.OnMoraleActiveChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CharOnBuffAddShowMoraleBuffTips, new Action<int, GameplayCue, bool, int>(this.OnCharOnBuffAddShowMoraleBuffTips));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityDirectTrainProSetActive, new Action<bool>(this.OnActivityDirectTrainProSetActive));
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter == null)
			{
				return;
			}
			uiHookCenter.OnRemoveEventListener(this);
		}

		// Token: 0x0603D93D RID: 252221 RVA: 0x00FB03A8 File Offset: 0x00FAE5A8
		[NullableContext(1)]
		private void OnBehaviorTreeStartShow(BehaviorTreeViewShowData showBridge, ETreeTextExpressReason eTreeTextExpressReason, bool arg3)
		{
			BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(showBridge.Id), false);
			if (behaviorTree == null)
			{
				return;
			}
			if (behaviorTree.GetSilentAreaShowInfo() == null)
			{
				return;
			}
			this.SilentAreaView.StartShow(showBridge.Id, behaviorTree);
		}

		// Token: 0x0603D93E RID: 252222 RVA: 0x00FB03EB File Offset: 0x00FAE5EB
		private void OnBehaviorTreeEndShow(long treeIncId, ETreeTextExpressReason _1, bool _2)
		{
			SilentAreaView silentAreaView = this.SilentAreaView;
			if (silentAreaView == null || silentAreaView.Id != treeIncId)
			{
				return;
			}
			this.SilentAreaView.EndShow();
		}

		// Token: 0x0603D93F RID: 252223 RVA: 0x00FB0414 File Offset: 0x00FAE614
		private void RefreshSilentAreaViewVisibleState()
		{
			BaseBehaviorTree treeHandle = ModelBase<BattleUiModel>.Instance.TreeHandle;
			long? treeIncIdHandle = ModelBase<BattleUiModel>.Instance.TreeIncIdHandle;
			if (treeHandle == null || treeIncIdHandle == null)
			{
				this.SilentAreaView.EndShow();
				return;
			}
			this.SilentAreaView.StartShow(treeIncIdHandle.Value, treeHandle);
		}

		// Token: 0x0603D940 RID: 252224 RVA: 0x00FB0462 File Offset: 0x00FAE662
		private void OnShowTowerGuideButton()
		{
			BattleTowerButton towerGuideButton = this.TowerGuideButton;
			if (towerGuideButton != null)
			{
				towerGuideButton.SetOtherHide(false);
			}
			this.SilentAreaView.EndShow();
		}

		// Token: 0x0603D941 RID: 252225 RVA: 0x00FB0484 File Offset: 0x00FAE684
		private void MowingRiskInBattleView(bool active)
		{
			MowingRiskInBattleView mowingRiskView = this.MowingRiskView;
			if (mowingRiskView != null)
			{
				mowingRiskView.CustomSetActive(active);
			}
			if (active)
			{
				IMowingRiskInBattleRootData data = ModelBase<MowingRiskModel>.Instance.BuildInBattleRootData();
				MowingRiskInBattleView mowingRiskView2 = this.MowingRiskView;
				if (mowingRiskView2 == null)
				{
					return;
				}
				mowingRiskView2.RefreshByCustomData(data);
			}
		}

		// Token: 0x0603D942 RID: 252226 RVA: 0x00FB04C4 File Offset: 0x00FAE6C4
		private void OnGmOnlyShowMiniMap(bool bVisible)
		{
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.SetGmHide(!bVisible);
			}
			this.ExitButton.SetGmHide(!bVisible);
			this.ActivityButton.SetGmHide(!bVisible);
		}

		// Token: 0x0603D943 RID: 252227 RVA: 0x00FB0538 File Offset: 0x00FAE738
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.IsGamepad = Singleton<Info>.Instance.IsInGamepad();
			if (this.MiniMapView != null)
			{
				this.MiniMapView.RefreshOnPlatformChanged();
			}
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.SetGamepadHide(this.IsGamepad);
			}
			this.OnlineButton.RefreshButtonState();
			if (this.IsGamepad)
			{
				base.GetItem(40).SetUIActive(false);
				this.RefreshGamepad();
				return;
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				base.GetItem(40).SetUIActive(true);
			}
		}

		// Token: 0x0603D944 RID: 252228 RVA: 0x00FB05F4 File Offset: 0x00FAE7F4
		private void RefreshGamepad()
		{
			this.EnsureGamepadPanelCreatedAsync().ContinueWith(delegate()
			{
				if (base.IsDestroyOrDestroying)
				{
					return;
				}
				GamepadTopPanel gamepadTopPanel = this.GamepadTopPanel;
				if (gamepadTopPanel != null)
				{
					gamepadTopPanel.ShowBattleVisibleChildView(false);
				}
				TopPanelWavePlateTip wavePlateTipGamePad = this.WavePlateTipGamePad;
				if (wavePlateTipGamePad == null)
				{
					return;
				}
				wavePlateTipGamePad.ShowBattleVisibleChildView(false);
			}).Forget();
		}

		// Token: 0x0603D945 RID: 252229 RVA: 0x00FB0614 File Offset: 0x00FAE814
		private UniTask CreateGamepadPanel()
		{
			TopPanel.<CreateGamepadPanel>d__62 <CreateGamepadPanel>d__;
			<CreateGamepadPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGamepadPanel>d__.<>4__this = this;
			<CreateGamepadPanel>d__.<>1__state = -1;
			<CreateGamepadPanel>d__.<>t__builder.Start<TopPanel.<CreateGamepadPanel>d__62>(ref <CreateGamepadPanel>d__);
			return <CreateGamepadPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603D946 RID: 252230 RVA: 0x00FB0658 File Offset: 0x00FAE858
		private UniTask CreateGamepadPanelInner()
		{
			TopPanel.<CreateGamepadPanelInner>d__63 <CreateGamepadPanelInner>d__;
			<CreateGamepadPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateGamepadPanelInner>d__.<>4__this = this;
			<CreateGamepadPanelInner>d__.<>1__state = -1;
			<CreateGamepadPanelInner>d__.<>t__builder.Start<TopPanel.<CreateGamepadPanelInner>d__63>(ref <CreateGamepadPanelInner>d__);
			return <CreateGamepadPanelInner>d__.<>t__builder.Task;
		}

		// Token: 0x0603D947 RID: 252231 RVA: 0x00FB069C File Offset: 0x00FAE89C
		private UniTask EnsureGamepadPanelCreatedAsync()
		{
			TopPanel.<EnsureGamepadPanelCreatedAsync>d__64 <EnsureGamepadPanelCreatedAsync>d__;
			<EnsureGamepadPanelCreatedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureGamepadPanelCreatedAsync>d__.<>4__this = this;
			<EnsureGamepadPanelCreatedAsync>d__.<>1__state = -1;
			<EnsureGamepadPanelCreatedAsync>d__.<>t__builder.Start<TopPanel.<EnsureGamepadPanelCreatedAsync>d__64>(ref <EnsureGamepadPanelCreatedAsync>d__);
			return <EnsureGamepadPanelCreatedAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D948 RID: 252232 RVA: 0x00FB06E0 File Offset: 0x00FAE8E0
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UUIItem> GetEntitySequenceButtonRootAsync()
		{
			TopPanel.<GetEntitySequenceButtonRootAsync>d__65 <GetEntitySequenceButtonRootAsync>d__;
			<GetEntitySequenceButtonRootAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UUIItem>.Create();
			<GetEntitySequenceButtonRootAsync>d__.<>4__this = this;
			<GetEntitySequenceButtonRootAsync>d__.<>1__state = -1;
			<GetEntitySequenceButtonRootAsync>d__.<>t__builder.Start<TopPanel.<GetEntitySequenceButtonRootAsync>d__65>(ref <GetEntitySequenceButtonRootAsync>d__);
			return <GetEntitySequenceButtonRootAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D949 RID: 252233 RVA: 0x00FB0723 File Offset: 0x00FAE923
		private void OnActivityUpdate()
		{
			this.RefreshActivityVisibleState();
			this.RefreshActivityDungeonState();
		}

		// Token: 0x0603D94A RID: 252234 RVA: 0x00FB0731 File Offset: 0x00FAE931
		private bool CheckIsInRogue()
		{
			return ModelBase<RoguelikeModel>.Instance.CheckInRoguelike() || ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue() || ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance();
		}

		// Token: 0x0603D94B RID: 252235 RVA: 0x00FB0758 File Offset: 0x00FAE958
		private bool CheckIsBossPiling()
		{
			InstanceDungeon? instanceDungeon;
			return ((ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? instanceDungeon.GetValueOrDefault().InstSubType : -1) == 55;
		}

		// Token: 0x0603D94C RID: 252236 RVA: 0x00FB0790 File Offset: 0x00FAE990
		private void DungeonChange()
		{
			bool haveGuide = ModelBase<InstanceDungeonGuideModel>.Instance.GetHaveGuide();
			if (haveGuide)
			{
				this.QuestButton.SetOtherHide(true);
				this.DungeonGuideButton.SetOtherHide(false);
			}
			else
			{
				this.QuestButton.SetOtherHide(false);
				this.DungeonGuideButton.SetOtherHide(true);
			}
			bool flag = this.CheckIsInRogue();
			if (flag)
			{
				this.QuestButton.SetOtherHide(true);
				this.DungeonGuideButton.SetOtherHide(true);
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				this.QuestButton.SetOtherHide(true);
			}
			if (ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower())
			{
				this.QuestButton.SetOtherHide(true);
			}
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				this.QuestButton.SetOtherHide(true);
			}
			if (this.CheckIsBossPiling())
			{
				this.QuestButton.SetOtherHide(true);
				this.DungeonGuideButton.SetOtherHide(true);
			}
			ModelBase<BattleUiModel>.Instance.EnvironmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.DungeonGuide, haveGuide && !flag);
		}

		// Token: 0x0603D94D RID: 252237 RVA: 0x00FB0881 File Offset: 0x00FAEA81
		private void OnChangeRole(int i, int i1)
		{
			this.OnlineButton.RefreshButtonState();
		}

		// Token: 0x0603D94E RID: 252238 RVA: 0x00FB0890 File Offset: 0x00FAEA90
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.SetFunctionOpen(functionType, isOpen);
			}
		}

		// Token: 0x0603D94F RID: 252239 RVA: 0x00FB08E4 File Offset: 0x00FAEAE4
		private void RefreshExitButtonVisibleState()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				this.ExitButton.SetOtherHide(true);
				return;
			}
			this.ExitButton.SetOtherHide(false);
		}

		// Token: 0x0603D950 RID: 252240 RVA: 0x00FB090C File Offset: 0x00FAEB0C
		private void RefreshActivityVisibleState()
		{
			if (this.CheckIsInRogue())
			{
				this.ActivityButton.SetOtherHide(true);
				return;
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				this.ActivityButton.SetOtherHide(true);
				return;
			}
			this.ActivityButton.SetOtherHide(!ModelBase<ActivityModel>.Instance.GetIfShowActivity());
		}

		// Token: 0x0603D951 RID: 252241 RVA: 0x00FB095F File Offset: 0x00FAEB5F
		private void RefreshDirectTrainProState()
		{
			BattleEntranceButton directTrainProButton = this.DirectTrainProButton;
			if (directTrainProButton == null)
			{
				return;
			}
			directTrainProButton.SetOtherHide(!ActivityDirectTrainHelper.IsProOpen || !ActivityDirectTrainHelper.IsInValidInstance);
		}

		// Token: 0x0603D952 RID: 252242 RVA: 0x00FB0983 File Offset: 0x00FAEB83
		private void RefreshTowerGuideVisibleState()
		{
			this.TowerGuideButton.SetOtherHide(!ModelBase<TowerModel>.Instance.CheckInTower());
		}

		// Token: 0x0603D953 RID: 252243 RVA: 0x00FB09A0 File Offset: 0x00FAEBA0
		private void RefreshShipTowerBuffVisibleState()
		{
			bool flag = ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower();
			bool flag2 = ModelBase<ShipTowerModel>.Instance.CheckIsScoreBattle();
			if (flag && !flag2)
			{
				ShipTowerBuffBattleView shipTowerBuffView = this.ShipTowerBuffView;
				if (shipTowerBuffView == null)
				{
					return;
				}
				shipTowerBuffView.StartShow();
				return;
			}
			else
			{
				ShipTowerBuffBattleView shipTowerBuffView2 = this.ShipTowerBuffView;
				if (shipTowerBuffView2 == null)
				{
					return;
				}
				shipTowerBuffView2.EndShow();
				return;
			}
		}

		// Token: 0x0603D954 RID: 252244 RVA: 0x00FB09E8 File Offset: 0x00FAEBE8
		private void RefreshMoraleBuffVisibleState()
		{
			if (ModelBase<MoraleModel>.Instance.GetBattleIsShowBuff())
			{
				MoraleBuffBattleView moraleBuffView = this.MoraleBuffView;
				if (moraleBuffView == null)
				{
					return;
				}
				moraleBuffView.StartShow();
				return;
			}
			else
			{
				MoraleBuffBattleView moraleBuffView2 = this.MoraleBuffView;
				if (moraleBuffView2 == null)
				{
					return;
				}
				moraleBuffView2.EndShow();
				return;
			}
		}

		// Token: 0x0603D955 RID: 252245 RVA: 0x00FB0A17 File Offset: 0x00FAEC17
		private void RefreshBabelTowerTopPanelState()
		{
			if (ModelBase<BabelTowerModel>.Instance.CheckInBattleBabelTower())
			{
				BabelTowerBattleTopPanel babelTowerBattleTopPanel = this.BabelTowerBattleTopPanel;
				if (babelTowerBattleTopPanel == null)
				{
					return;
				}
				babelTowerBattleTopPanel.StartShow();
				return;
			}
			else
			{
				BabelTowerBattleTopPanel babelTowerBattleTopPanel2 = this.BabelTowerBattleTopPanel;
				if (babelTowerBattleTopPanel2 == null)
				{
					return;
				}
				babelTowerBattleTopPanel2.EndShow();
				return;
			}
		}

		// Token: 0x0603D956 RID: 252246 RVA: 0x00FB0A48 File Offset: 0x00FAEC48
		private void RefreshShipTowerTopPanelState()
		{
			bool flag = ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower();
			bool flag2 = ModelBase<ShipTowerModel>.Instance.CheckIsScoreBattle();
			bool shipTowerVisible = !flag || !flag2;
			this.MiniMapView.SetShipTowerVisible(shipTowerVisible);
		}

		// Token: 0x0603D957 RID: 252247 RVA: 0x00FB0A80 File Offset: 0x00FAEC80
		private void RefreshResDownLoadTopPanelState()
		{
			if (ModelBase<SubPackageDownLoadModel>.Instance.NeedShowBattleViewButton())
			{
				ResDownLoadTopPanel resDownLoadItemTopPanel = this.ResDownLoadItemTopPanel;
				if (resDownLoadItemTopPanel == null)
				{
					return;
				}
				resDownLoadItemTopPanel.StartShow();
				return;
			}
			else
			{
				ResDownLoadTopPanel resDownLoadItemTopPanel2 = this.ResDownLoadItemTopPanel;
				if (resDownLoadItemTopPanel2 == null)
				{
					return;
				}
				resDownLoadItemTopPanel2.EndShow();
				return;
			}
		}

		// Token: 0x0603D958 RID: 252248 RVA: 0x00FB0AB0 File Offset: 0x00FAECB0
		private void RefreshMowingRiskVisibleState()
		{
			bool active = ControllerBase<ActivityMowingRiskController>.Instance.CheckInInstanceDungeon();
			this.MowingRiskInBattleView(active);
		}

		// Token: 0x0603D959 RID: 252249 RVA: 0x00FB0AD0 File Offset: 0x00FAECD0
		private void RefreshBattleLinkVisibleState()
		{
			bool flag = ModelBase<BattleLinkModel>.Instance.CheckInDreamLink();
			if (flag)
			{
				this.ButtonList.ForEach(delegate(BattleEntranceButton button)
				{
					button.SetOtherHide(true);
				});
				this.ExitButton.SetOtherHide(false);
			}
			this.MiniMapView.SetBattleLinkVisible(!flag);
		}

		// Token: 0x0603D95A RID: 252250 RVA: 0x00FB0B30 File Offset: 0x00FAED30
		private void RefreshActivityDungeonState()
		{
			bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
			bool isInFlagChallengeDungeon = ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon;
			if (flag)
			{
				this.RefreshHonamiStoryButtonVisibleState();
			}
			else if (isInFlagChallengeDungeon)
			{
				this.RefreshFlagChallengeButtonVisibleState();
			}
			else if (this.CheckIsBossPiling())
			{
				this.RefreshBossPilingTopState();
			}
			else
			{
				this.RefreshRogueInfoButtonVisibleState();
			}
			BattleTopPanelHookCenter uiHookCenter = this.UiHookCenter;
			if (uiHookCenter == null)
			{
				return;
			}
			uiHookCenter.OnRefresh(this);
		}

		// Token: 0x0603D95B RID: 252251 RVA: 0x00FB0B8C File Offset: 0x00FAED8C
		private void RefreshHonamiStoryButtonVisibleState()
		{
			this.ButtonList.ForEach(delegate(BattleEntranceButton button)
			{
				button.SetOtherHide(true);
			});
			CommonTopButtonPanel honamiStoryBagButton = this.HonamiStoryBagButton;
			if (honamiStoryBagButton != null)
			{
				honamiStoryBagButton.SetOtherHide(false);
			}
			this.SettingButton.SetOtherHide(false);
			this.QuestButton.SetOtherHide(false);
			if (HonamiStoryUtil.CheckInHonamiStoryMainDungeon())
			{
				this.ExitButton.SetOtherHide(false);
				return;
			}
			BattleHonamiStoryLeaveButton honamiStoryLeaveButton = this.HonamiStoryLeaveButton;
			if (honamiStoryLeaveButton != null)
			{
				honamiStoryLeaveButton.SetOtherHide(false);
			}
			ResDownLoadTopPanel resDownLoadItemTopPanel = this.ResDownLoadItemTopPanel;
			if (resDownLoadItemTopPanel != null)
			{
				resDownLoadItemTopPanel.EndShow();
			}
			ResDownLoadTopPanel resDownLoadItemTopPanel2 = this.ResDownLoadItemTopPanel;
			if (resDownLoadItemTopPanel2 == null)
			{
				return;
			}
			resDownLoadItemTopPanel2.SetOtherHide(true);
		}

		// Token: 0x0603D95C RID: 252252 RVA: 0x00FB0C38 File Offset: 0x00FAEE38
		private void RefreshFlagChallengeButtonVisibleState()
		{
			foreach (BattleEntranceButton battleEntranceButton in this.ButtonList)
			{
				battleEntranceButton.SetOtherHide(true);
			}
			this.QuestButton.SetOtherHide(true);
			CommonTopButtonPanel flagChallengeLevelButton = this.FlagChallengeLevelButton;
			if (flagChallengeLevelButton != null)
			{
				flagChallengeLevelButton.SetOtherHide(false);
			}
			CommonTopButtonPanel flagChallengeBuffButton = this.FlagChallengeBuffButton;
			if (flagChallengeBuffButton != null)
			{
				flagChallengeBuffButton.SetOtherHide(false);
			}
			CommonTopButtonPanel flagChallengePauseButton = this.FlagChallengePauseButton;
			if (flagChallengePauseButton == null)
			{
				return;
			}
			flagChallengePauseButton.SetOtherHide(false);
		}

		// Token: 0x0603D95D RID: 252253 RVA: 0x00FB0CCC File Offset: 0x00FAEECC
		private void RefreshRogueInfoButtonVisibleState()
		{
			bool flag = this.CheckIsInRogue();
			bool flag2 = flag || ModelBase<BabelTowerModel>.Instance.CheckInBattleBabelTower();
			if (flag2)
			{
				this.ButtonList.ForEach(delegate(BattleEntranceButton button)
				{
					button.SetOtherHide(true);
				});
				this.ExitButton.SetOtherHide(false);
			}
			this.MiniMapView.SetRoguelikeVisible(!flag2);
			this.RogueInfoButton.SetOtherHide(!flag);
			this.SettingButton.SetOtherHide(!flag);
		}

		// Token: 0x0603D95E RID: 252254 RVA: 0x00FB0D58 File Offset: 0x00FAEF58
		private void RefreshAreaAlertUiVisibleState(int _1 = 0, bool _2 = false)
		{
			int? alertUiVisibleAreaId = ModelBase<AlertAreaModel>.Instance.GetAlertUiVisibleAreaId();
			if (alertUiVisibleAreaId == null)
			{
				AlertAreaInfoView alertAreaInfoView = this.AlertAreaInfoView;
				if (alertAreaInfoView == null)
				{
					return;
				}
				alertAreaInfoView.EndShow(null);
				return;
			}
			else
			{
				AlertAreaInfoView alertAreaInfoView2 = this.AlertAreaInfoView;
				if (alertAreaInfoView2 == null)
				{
					return;
				}
				alertAreaInfoView2.StartShow(alertUiVisibleAreaId.Value);
				return;
			}
		}

		// Token: 0x0603D95F RID: 252255 RVA: 0x00FB0DAA File Offset: 0x00FAEFAA
		private void RefreshMoraleUiVisibleState()
		{
			if (ModelBase<MoraleBattleModel>.Instance.IsMoraleActive())
			{
				MoraleExpView moraleExpView = this.MoraleExpView;
				if (moraleExpView == null)
				{
					return;
				}
				moraleExpView.StartShow();
				return;
			}
			else
			{
				MoraleExpView moraleExpView2 = this.MoraleExpView;
				if (moraleExpView2 == null)
				{
					return;
				}
				moraleExpView2.EndShow();
				return;
			}
		}

		// Token: 0x0603D960 RID: 252256 RVA: 0x00FB0DD9 File Offset: 0x00FAEFD9
		private void OnMoraleActiveChanged(bool active)
		{
			this.RefreshMoraleUiVisibleState();
			this.RefreshMoraleBuffVisibleState();
			BattleEntranceButton moraleBuffSumButton = this.MoraleBuffSumButton;
			if (moraleBuffSumButton != null)
			{
				moraleBuffSumButton.SetOtherHide(!active);
			}
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.MoraleAreaSum, active);
		}

		// Token: 0x0603D961 RID: 252257 RVA: 0x00FB0E14 File Offset: 0x00FAF014
		private void OnCharOnBuffAddShowMoraleBuffTips(int entityId, GameplayCue cue, bool isAdd, int handleId)
		{
			if (cue.Parameters(0) == "1")
			{
				int num = int.Parse(cue.Parameters(1));
				if (ModelBase<MoraleModel>.Instance.GamePlayFinishTeamBuffId == num)
				{
					this.RefreshMoraleBuffVisibleState();
				}
			}
		}

		// Token: 0x0603D962 RID: 252258 RVA: 0x00FB0E58 File Offset: 0x00FAF058
		private UniTask NewHomeButton()
		{
			TopPanel.<NewHomeButton>d__91 <NewHomeButton>d__;
			<NewHomeButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewHomeButton>d__.<>4__this = this;
			<NewHomeButton>d__.<>1__state = -1;
			<NewHomeButton>d__.<>t__builder.Start<TopPanel.<NewHomeButton>d__91>(ref <NewHomeButton>d__);
			return <NewHomeButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D963 RID: 252259 RVA: 0x00FB0E9B File Offset: 0x00FAF09B
		private void OnClickedHomeButton()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FunctionView, null, null);
		}

		// Token: 0x0603D964 RID: 252260 RVA: 0x00FB0EB0 File Offset: 0x00FAF0B0
		private UniTask NewGachaButton()
		{
			TopPanel.<NewGachaButton>d__93 <NewGachaButton>d__;
			<NewGachaButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewGachaButton>d__.<>4__this = this;
			<NewGachaButton>d__.<>1__state = -1;
			<NewGachaButton>d__.<>t__builder.Start<TopPanel.<NewGachaButton>d__93>(ref <NewGachaButton>d__);
			return <NewGachaButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D965 RID: 252261 RVA: 0x00FB0EF3 File Offset: 0x00FAF0F3
		private void OnClickedGachaButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Gacha);
		}

		// Token: 0x0603D966 RID: 252262 RVA: 0x00FB0F04 File Offset: 0x00FAF104
		private UniTask NewExitButton()
		{
			TopPanel.<NewExitButton>d__95 <NewExitButton>d__;
			<NewExitButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewExitButton>d__.<>4__this = this;
			<NewExitButton>d__.<>1__state = -1;
			<NewExitButton>d__.<>t__builder.Start<TopPanel.<NewExitButton>d__95>(ref <NewExitButton>d__);
			return <NewExitButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D967 RID: 252263 RVA: 0x00FB0F48 File Offset: 0x00FAF148
		private UniTask NewActivityButton()
		{
			TopPanel.<NewActivityButton>d__96 <NewActivityButton>d__;
			<NewActivityButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewActivityButton>d__.<>4__this = this;
			<NewActivityButton>d__.<>1__state = -1;
			<NewActivityButton>d__.<>t__builder.Start<TopPanel.<NewActivityButton>d__96>(ref <NewActivityButton>d__);
			return <NewActivityButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D968 RID: 252264 RVA: 0x00FB0F8B File Offset: 0x00FAF18B
		private bool GetActivityOtherHide()
		{
			return !ModelBase<ActivityModel>.Instance.GetIfShowActivity();
		}

		// Token: 0x0603D969 RID: 252265 RVA: 0x00FB0F9A File Offset: 0x00FAF19A
		private void OnClickedExitButton()
		{
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, true);
		}

		// Token: 0x0603D96A RID: 252266 RVA: 0x00FB0FAC File Offset: 0x00FAF1AC
		private UniTask NewOnlineButton()
		{
			TopPanel.<NewOnlineButton>d__99 <NewOnlineButton>d__;
			<NewOnlineButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewOnlineButton>d__.<>4__this = this;
			<NewOnlineButton>d__.<>1__state = -1;
			<NewOnlineButton>d__.<>t__builder.Start<TopPanel.<NewOnlineButton>d__99>(ref <NewOnlineButton>d__);
			return <NewOnlineButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D96B RID: 252267 RVA: 0x00FB0FF0 File Offset: 0x00FAF1F0
		private static void OnClickedOnlineButton()
		{
			int isMulti = ModelBase<GameModeModel>.Instance.IsMulti ? 1 : 0;
			bool flag = ModelBase<OnlineModel>.Instance.IsOnlineDisabled();
			if (isMulti == 0 && flag)
			{
				ControllerBase<OnlineController>.Instance.ShowTipsWhenOnlineDisabled(null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineWorldHallView, null, null);
		}

		// Token: 0x0603D96C RID: 252268 RVA: 0x00FB1038 File Offset: 0x00FAF238
		private UniTask NewInventoryButton()
		{
			TopPanel.<NewInventoryButton>d__101 <NewInventoryButton>d__;
			<NewInventoryButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewInventoryButton>d__.<>4__this = this;
			<NewInventoryButton>d__.<>1__state = -1;
			<NewInventoryButton>d__.<>t__builder.Start<TopPanel.<NewInventoryButton>d__101>(ref <NewInventoryButton>d__);
			return <NewInventoryButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D96D RID: 252269 RVA: 0x00FB107B File Offset: 0x00FAF27B
		private void OnClickedInventoryButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Bag);
		}

		// Token: 0x0603D96E RID: 252270 RVA: 0x00FB108C File Offset: 0x00FAF28C
		private UniTask NewPhoneMagButton()
		{
			TopPanel.<NewPhoneMagButton>d__103 <NewPhoneMagButton>d__;
			<NewPhoneMagButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewPhoneMagButton>d__.<>4__this = this;
			<NewPhoneMagButton>d__.<>1__state = -1;
			<NewPhoneMagButton>d__.<>t__builder.Start<TopPanel.<NewPhoneMagButton>d__103>(ref <NewPhoneMagButton>d__);
			return <NewPhoneMagButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D96F RID: 252271 RVA: 0x00FB10CF File Offset: 0x00FAF2CF
		private static void OnClickedPhoneMsgButton()
		{
			ControllerBase<PhoneMsgController>.Instance.OpenAndJumpShowTipShortMessage(EPhoneMsgOpenWay.HUD, EPhoneMsgViewType.Big);
		}

		// Token: 0x0603D970 RID: 252272 RVA: 0x00FB10E0 File Offset: 0x00FAF2E0
		private UniTask NewShopButton()
		{
			TopPanel.<NewShopButton>d__105 <NewShopButton>d__;
			<NewShopButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewShopButton>d__.<>4__this = this;
			<NewShopButton>d__.<>1__state = -1;
			<NewShopButton>d__.<>t__builder.Start<TopPanel.<NewShopButton>d__105>(ref <NewShopButton>d__);
			return <NewShopButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D971 RID: 252273 RVA: 0x00FB1123 File Offset: 0x00FAF323
		private void OnClickedShopButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Shop);
		}

		// Token: 0x0603D972 RID: 252274 RVA: 0x00FB1134 File Offset: 0x00FAF334
		private UniTask NewPassCheckButton()
		{
			TopPanel.<NewPassCheckButton>d__107 <NewPassCheckButton>d__;
			<NewPassCheckButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewPassCheckButton>d__.<>4__this = this;
			<NewPassCheckButton>d__.<>1__state = -1;
			<NewPassCheckButton>d__.<>t__builder.Start<TopPanel.<NewPassCheckButton>d__107>(ref <NewPassCheckButton>d__);
			return <NewPassCheckButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D973 RID: 252275 RVA: 0x00FB1177 File Offset: 0x00FAF377
		private void OnClickedPassCheckButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.BattlePass);
		}

		// Token: 0x0603D974 RID: 252276 RVA: 0x00FB1188 File Offset: 0x00FAF388
		private void OnClickedActivityButton()
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(0, EActivityViewOpenType.BattleView, null, null);
		}

		// Token: 0x0603D975 RID: 252277 RVA: 0x00FB119C File Offset: 0x00FAF39C
		private UniTask NewResonanceButton()
		{
			TopPanel.<NewResonanceButton>d__110 <NewResonanceButton>d__;
			<NewResonanceButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewResonanceButton>d__.<>4__this = this;
			<NewResonanceButton>d__.<>1__state = -1;
			<NewResonanceButton>d__.<>t__builder.Start<TopPanel.<NewResonanceButton>d__110>(ref <NewResonanceButton>d__);
			return <NewResonanceButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D976 RID: 252278 RVA: 0x00FB11DF File Offset: 0x00FAF3DF
		private void OnClickedRoleButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Role);
		}

		// Token: 0x0603D977 RID: 252279 RVA: 0x00FB11F0 File Offset: 0x00FAF3F0
		private UniTask NewHelpButton()
		{
			TopPanel.<NewHelpButton>d__112 <NewHelpButton>d__;
			<NewHelpButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewHelpButton>d__.<>4__this = this;
			<NewHelpButton>d__.<>1__state = -1;
			<NewHelpButton>d__.<>t__builder.Start<TopPanel.<NewHelpButton>d__112>(ref <NewHelpButton>d__);
			return <NewHelpButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D978 RID: 252280 RVA: 0x00FB1233 File Offset: 0x00FAF433
		private void OnClickedHelpButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.AdventureGuide);
		}

		// Token: 0x0603D979 RID: 252281 RVA: 0x00FB1244 File Offset: 0x00FAF444
		private UniTask NewMiniMapView()
		{
			TopPanel.<NewMiniMapView>d__114 <NewMiniMapView>d__;
			<NewMiniMapView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMiniMapView>d__.<>4__this = this;
			<NewMiniMapView>d__.<>1__state = -1;
			<NewMiniMapView>d__.<>t__builder.Start<TopPanel.<NewMiniMapView>d__114>(ref <NewMiniMapView>d__);
			return <NewMiniMapView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97A RID: 252282 RVA: 0x00FB1288 File Offset: 0x00FAF488
		private UniTask NewSilentAreaInfo()
		{
			TopPanel.<NewSilentAreaInfo>d__115 <NewSilentAreaInfo>d__;
			<NewSilentAreaInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewSilentAreaInfo>d__.<>4__this = this;
			<NewSilentAreaInfo>d__.<>1__state = -1;
			<NewSilentAreaInfo>d__.<>t__builder.Start<TopPanel.<NewSilentAreaInfo>d__115>(ref <NewSilentAreaInfo>d__);
			return <NewSilentAreaInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97B RID: 252283 RVA: 0x00FB12CC File Offset: 0x00FAF4CC
		private UniTask NewShipTowerBuffInfo()
		{
			TopPanel.<NewShipTowerBuffInfo>d__116 <NewShipTowerBuffInfo>d__;
			<NewShipTowerBuffInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewShipTowerBuffInfo>d__.<>4__this = this;
			<NewShipTowerBuffInfo>d__.<>1__state = -1;
			<NewShipTowerBuffInfo>d__.<>t__builder.Start<TopPanel.<NewShipTowerBuffInfo>d__116>(ref <NewShipTowerBuffInfo>d__);
			return <NewShipTowerBuffInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97C RID: 252284 RVA: 0x00FB1310 File Offset: 0x00FAF510
		private UniTask NewMoraleBuffInfo()
		{
			TopPanel.<NewMoraleBuffInfo>d__117 <NewMoraleBuffInfo>d__;
			<NewMoraleBuffInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMoraleBuffInfo>d__.<>4__this = this;
			<NewMoraleBuffInfo>d__.<>1__state = -1;
			<NewMoraleBuffInfo>d__.<>t__builder.Start<TopPanel.<NewMoraleBuffInfo>d__117>(ref <NewMoraleBuffInfo>d__);
			return <NewMoraleBuffInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97D RID: 252285 RVA: 0x00FB1354 File Offset: 0x00FAF554
		private UniTask NewBabelTowerBattleTopPanel()
		{
			TopPanel.<NewBabelTowerBattleTopPanel>d__118 <NewBabelTowerBattleTopPanel>d__;
			<NewBabelTowerBattleTopPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewBabelTowerBattleTopPanel>d__.<>4__this = this;
			<NewBabelTowerBattleTopPanel>d__.<>1__state = -1;
			<NewBabelTowerBattleTopPanel>d__.<>t__builder.Start<TopPanel.<NewBabelTowerBattleTopPanel>d__118>(ref <NewBabelTowerBattleTopPanel>d__);
			return <NewBabelTowerBattleTopPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97E RID: 252286 RVA: 0x00FB1398 File Offset: 0x00FAF598
		private UniTask NewResDownLoadItemTopPanel()
		{
			TopPanel.<NewResDownLoadItemTopPanel>d__119 <NewResDownLoadItemTopPanel>d__;
			<NewResDownLoadItemTopPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewResDownLoadItemTopPanel>d__.<>4__this = this;
			<NewResDownLoadItemTopPanel>d__.<>1__state = -1;
			<NewResDownLoadItemTopPanel>d__.<>t__builder.Start<TopPanel.<NewResDownLoadItemTopPanel>d__119>(ref <NewResDownLoadItemTopPanel>d__);
			return <NewResDownLoadItemTopPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603D97F RID: 252287 RVA: 0x00FB13DC File Offset: 0x00FAF5DC
		private UniTask NewMowingRiskInfo()
		{
			TopPanel.<NewMowingRiskInfo>d__120 <NewMowingRiskInfo>d__;
			<NewMowingRiskInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMowingRiskInfo>d__.<>4__this = this;
			<NewMowingRiskInfo>d__.<>1__state = -1;
			<NewMowingRiskInfo>d__.<>t__builder.Start<TopPanel.<NewMowingRiskInfo>d__120>(ref <NewMowingRiskInfo>d__);
			return <NewMowingRiskInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D980 RID: 252288 RVA: 0x00FB1420 File Offset: 0x00FAF620
		private UniTask NewTowerGuideButton()
		{
			TopPanel.<NewTowerGuideButton>d__121 <NewTowerGuideButton>d__;
			<NewTowerGuideButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewTowerGuideButton>d__.<>4__this = this;
			<NewTowerGuideButton>d__.<>1__state = -1;
			<NewTowerGuideButton>d__.<>t__builder.Start<TopPanel.<NewTowerGuideButton>d__121>(ref <NewTowerGuideButton>d__);
			return <NewTowerGuideButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D981 RID: 252289 RVA: 0x00FB1464 File Offset: 0x00FAF664
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BattleEntranceRoleButton> NewEntranceRoleButton(UUIItem uiItem, ERedDotName? redDotName = null, EFunctionType? functionType = null, bool hideInGamepad = false, bool hideByRoleConfig = true, EBattleUiChild childType = EBattleUiChild.TopButton)
		{
			TopPanel.<NewEntranceRoleButton>d__122 <NewEntranceRoleButton>d__;
			<NewEntranceRoleButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<BattleEntranceRoleButton>.Create();
			<NewEntranceRoleButton>d__.<>4__this = this;
			<NewEntranceRoleButton>d__.uiItem = uiItem;
			<NewEntranceRoleButton>d__.redDotName = redDotName;
			<NewEntranceRoleButton>d__.functionType = functionType;
			<NewEntranceRoleButton>d__.hideInGamepad = hideInGamepad;
			<NewEntranceRoleButton>d__.hideByRoleConfig = hideByRoleConfig;
			<NewEntranceRoleButton>d__.childType = childType;
			<NewEntranceRoleButton>d__.<>1__state = -1;
			<NewEntranceRoleButton>d__.<>t__builder.Start<TopPanel.<NewEntranceRoleButton>d__122>(ref <NewEntranceRoleButton>d__);
			return <NewEntranceRoleButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D982 RID: 252290 RVA: 0x00FB14DC File Offset: 0x00FAF6DC
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<BattleEntranceButton> NewBattleEntranceButton(UUIItem uiItem, ERedDotName? redDotName = null, EFunctionType? functionType = null, bool hideInGamepad = false, bool hideByRoleConfig = true, EBattleUiChild childType = EBattleUiChild.TopButton)
		{
			TopPanel.<NewBattleEntranceButton>d__123 <NewBattleEntranceButton>d__;
			<NewBattleEntranceButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<BattleEntranceButton>.Create();
			<NewBattleEntranceButton>d__.<>4__this = this;
			<NewBattleEntranceButton>d__.uiItem = uiItem;
			<NewBattleEntranceButton>d__.redDotName = redDotName;
			<NewBattleEntranceButton>d__.functionType = functionType;
			<NewBattleEntranceButton>d__.hideInGamepad = hideInGamepad;
			<NewBattleEntranceButton>d__.hideByRoleConfig = hideByRoleConfig;
			<NewBattleEntranceButton>d__.childType = childType;
			<NewBattleEntranceButton>d__.<>1__state = -1;
			<NewBattleEntranceButton>d__.<>t__builder.Start<TopPanel.<NewBattleEntranceButton>d__123>(ref <NewBattleEntranceButton>d__);
			return <NewBattleEntranceButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D983 RID: 252291 RVA: 0x00FB1554 File Offset: 0x00FAF754
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<CommonTopButtonPanel> NewCommonTopButton(UUIItem parent, [Nullable(2)] string iconPath = null, ERedDotName? redDotName = null, EFunctionType? functionType = null, bool hideInGamepad = false, bool hideByRoleConfig = true, EBattleUiChild childType = EBattleUiChild.TopButton)
		{
			TopPanel.<NewCommonTopButton>d__124 <NewCommonTopButton>d__;
			<NewCommonTopButton>d__.<>t__builder = AsyncUniTaskMethodBuilder<CommonTopButtonPanel>.Create();
			<NewCommonTopButton>d__.<>4__this = this;
			<NewCommonTopButton>d__.parent = parent;
			<NewCommonTopButton>d__.iconPath = iconPath;
			<NewCommonTopButton>d__.redDotName = redDotName;
			<NewCommonTopButton>d__.functionType = functionType;
			<NewCommonTopButton>d__.hideInGamepad = hideInGamepad;
			<NewCommonTopButton>d__.hideByRoleConfig = hideByRoleConfig;
			<NewCommonTopButton>d__.childType = childType;
			<NewCommonTopButton>d__.<>1__state = -1;
			<NewCommonTopButton>d__.<>t__builder.Start<TopPanel.<NewCommonTopButton>d__124>(ref <NewCommonTopButton>d__);
			return <NewCommonTopButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D984 RID: 252292 RVA: 0x00FB15D4 File Offset: 0x00FAF7D4
		private UniTask NewQuestButton()
		{
			TopPanel.<NewQuestButton>d__125 <NewQuestButton>d__;
			<NewQuestButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewQuestButton>d__.<>4__this = this;
			<NewQuestButton>d__.<>1__state = -1;
			<NewQuestButton>d__.<>t__builder.Start<TopPanel.<NewQuestButton>d__125>(ref <NewQuestButton>d__);
			return <NewQuestButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D985 RID: 252293 RVA: 0x00FB1617 File Offset: 0x00FAF817
		private void OnClickedQuestButton()
		{
			if (HonamiStoryUtil.CheckInHonamiStoryAreaDungeon())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryQuestView, null, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, null, null);
		}

		// Token: 0x0603D986 RID: 252294 RVA: 0x00FB1644 File Offset: 0x00FAF844
		private UniTask NewDungeonGuideButton()
		{
			TopPanel.<NewDungeonGuideButton>d__127 <NewDungeonGuideButton>d__;
			<NewDungeonGuideButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDungeonGuideButton>d__.<>4__this = this;
			<NewDungeonGuideButton>d__.<>1__state = -1;
			<NewDungeonGuideButton>d__.<>t__builder.Start<TopPanel.<NewDungeonGuideButton>d__127>(ref <NewDungeonGuideButton>d__);
			return <NewDungeonGuideButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D987 RID: 252295 RVA: 0x00FB1687 File Offset: 0x00FAF887
		private static void OnClickedDungeonGuideButton()
		{
			InstanceDungeonGuideController.StartReplayGuide();
		}

		// Token: 0x0603D988 RID: 252296 RVA: 0x00FB168E File Offset: 0x00FAF88E
		private static void OnClickedTowerGuideButton()
		{
			ControllerBase<TowerController>.Instance.OpenTowerGuide();
		}

		// Token: 0x0603D989 RID: 252297 RVA: 0x00FB169C File Offset: 0x00FAF89C
		private UniTask NewRogueInfoButton()
		{
			TopPanel.<NewRogueInfoButton>d__130 <NewRogueInfoButton>d__;
			<NewRogueInfoButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRogueInfoButton>d__.<>4__this = this;
			<NewRogueInfoButton>d__.<>1__state = -1;
			<NewRogueInfoButton>d__.<>t__builder.Start<TopPanel.<NewRogueInfoButton>d__130>(ref <NewRogueInfoButton>d__);
			return <NewRogueInfoButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D98A RID: 252298 RVA: 0x00FB16E0 File Offset: 0x00FAF8E0
		private void OnClickedRogueInfoButton()
		{
			if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueInfo, null, null);
				return;
			}
			if (ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSummary, null, null);
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(null, true, true, ERogueInfoViewPage.Overview);
		}

		// Token: 0x0603D98B RID: 252299 RVA: 0x00FB1737 File Offset: 0x00FAF937
		private bool RogueInfoButtonVisible()
		{
			return ModelBase<RoguelikeModel>.Instance.CheckInRoguelike() || ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue();
		}

		// Token: 0x0603D98C RID: 252300 RVA: 0x00FB1754 File Offset: 0x00FAF954
		private UniTask NewSettingButton()
		{
			TopPanel.<NewSettingButton>d__133 <NewSettingButton>d__;
			<NewSettingButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewSettingButton>d__.<>4__this = this;
			<NewSettingButton>d__.<>1__state = -1;
			<NewSettingButton>d__.<>t__builder.Start<TopPanel.<NewSettingButton>d__133>(ref <NewSettingButton>d__);
			return <NewSettingButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D98D RID: 252301 RVA: 0x00FB1797 File Offset: 0x00FAF997
		private void OnClickSettingButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Menu);
		}

		// Token: 0x0603D98E RID: 252302 RVA: 0x00FB17A8 File Offset: 0x00FAF9A8
		private UniTask NewIosSettingButton()
		{
			TopPanel.<NewIosSettingButton>d__135 <NewIosSettingButton>d__;
			<NewIosSettingButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewIosSettingButton>d__.<>4__this = this;
			<NewIosSettingButton>d__.<>1__state = -1;
			<NewIosSettingButton>d__.<>t__builder.Start<TopPanel.<NewIosSettingButton>d__135>(ref <NewIosSettingButton>d__);
			return <NewIosSettingButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D98F RID: 252303 RVA: 0x00FB17EB File Offset: 0x00FAF9EB
		private bool SettingButtonVisible()
		{
			return ModelBase<RoguelikeModel>.Instance.CheckInRoguelike() && !ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue();
		}

		// Token: 0x0603D990 RID: 252304 RVA: 0x00FB1808 File Offset: 0x00FAFA08
		private UniTask NewFightTeamButton()
		{
			TopPanel.<NewFightTeamButton>d__137 <NewFightTeamButton>d__;
			<NewFightTeamButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFightTeamButton>d__.<>4__this = this;
			<NewFightTeamButton>d__.<>1__state = -1;
			<NewFightTeamButton>d__.<>t__builder.Start<TopPanel.<NewFightTeamButton>d__137>(ref <NewFightTeamButton>d__);
			return <NewFightTeamButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D991 RID: 252305 RVA: 0x00FB184B File Offset: 0x00FAFA4B
		private void OnClickedFightTeamButton()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.FormatTeam);
		}

		// Token: 0x0603D992 RID: 252306 RVA: 0x00FB185C File Offset: 0x00FAFA5C
		private void OnClickIosVoiceToggle(EToggleState _)
		{
			EToggleState toggleState = base.GetExtendToggle(18).ToggleState;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "当前背景播放音乐按钮 ToggleState";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("currentToggleState", toggleState);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (toggleState == EToggleState.ETT_UnChecked)
			{
				Singleton<Log>.Instance.Info(ELogModule.BattleUiSet, ELogAuthor.YZY, "停止背景音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKuroBgPlayerStatic.Stop();
				return;
			}
			if (toggleState == EToggleState.ETT_Checked)
			{
				Singleton<Log>.Instance.Info(ELogModule.BattleUiSet, ELogAuthor.YZY, "背景播放音乐", default(ReadOnlySpan<ValueTuple<string, object>>));
				UKuroBgPlayerStatic.Play();
			}
		}

		// Token: 0x0603D993 RID: 252307 RVA: 0x00FB18F8 File Offset: 0x00FAFAF8
		private UniTask NewDirectTrainProButton()
		{
			TopPanel.<NewDirectTrainProButton>d__140 <NewDirectTrainProButton>d__;
			<NewDirectTrainProButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDirectTrainProButton>d__.<>4__this = this;
			<NewDirectTrainProButton>d__.<>1__state = -1;
			<NewDirectTrainProButton>d__.<>t__builder.Start<TopPanel.<NewDirectTrainProButton>d__140>(ref <NewDirectTrainProButton>d__);
			return <NewDirectTrainProButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D994 RID: 252308 RVA: 0x00FB193B File Offset: 0x00FAFB3B
		private void OnClickedDirectTrainProButton()
		{
			ActivityDirectTrainHelper.TryOpenPro(false).Forget();
		}

		// Token: 0x0603D995 RID: 252309 RVA: 0x00FB1948 File Offset: 0x00FAFB48
		private bool DirectTrainProButtonHide()
		{
			return !ActivityDirectTrainHelper.IsProOpen || !ActivityDirectTrainHelper.IsInValidInstance;
		}

		// Token: 0x0603D996 RID: 252310 RVA: 0x00FB195B File Offset: 0x00FAFB5B
		private void OnActivityDirectTrainProSetActive(bool active)
		{
			BattleEntranceButton directTrainProButton = this.DirectTrainProButton;
			if (directTrainProButton == null)
			{
				return;
			}
			directTrainProButton.SetOtherHide(!active);
		}

		// Token: 0x0603D997 RID: 252311 RVA: 0x00FB1974 File Offset: 0x00FAFB74
		private UniTask NewMoraleSumButton()
		{
			TopPanel.<NewMoraleSumButton>d__144 <NewMoraleSumButton>d__;
			<NewMoraleSumButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMoraleSumButton>d__.<>4__this = this;
			<NewMoraleSumButton>d__.<>1__state = -1;
			<NewMoraleSumButton>d__.<>t__builder.Start<TopPanel.<NewMoraleSumButton>d__144>(ref <NewMoraleSumButton>d__);
			return <NewMoraleSumButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D998 RID: 252312 RVA: 0x00FB19B7 File Offset: 0x00FAFBB7
		private void OnClickedMoraleSumButton()
		{
			if (ModelBase<MoraleModel>.Instance.IsInitData)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleAreaSumView, null, null);
			}
		}

		// Token: 0x0603D999 RID: 252313 RVA: 0x00FB19D6 File Offset: 0x00FAFBD6
		private bool MoraleSumButtonHide()
		{
			return !ModelBase<MoraleBattleModel>.Instance.IsMoraleActive();
		}

		// Token: 0x0603D99A RID: 252314 RVA: 0x00FB19E8 File Offset: 0x00FAFBE8
		private UniTask NewWavePlateTip()
		{
			TopPanel.<NewWavePlateTip>d__147 <NewWavePlateTip>d__;
			<NewWavePlateTip>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewWavePlateTip>d__.<>4__this = this;
			<NewWavePlateTip>d__.<>1__state = -1;
			<NewWavePlateTip>d__.<>t__builder.Start<TopPanel.<NewWavePlateTip>d__147>(ref <NewWavePlateTip>d__);
			return <NewWavePlateTip>d__.<>t__builder.Task;
		}

		// Token: 0x0603D99B RID: 252315 RVA: 0x00FB1A2C File Offset: 0x00FAFC2C
		private UniTask NewWavePlateTipGamepad()
		{
			TopPanel.<NewWavePlateTipGamepad>d__148 <NewWavePlateTipGamepad>d__;
			<NewWavePlateTipGamepad>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewWavePlateTipGamepad>d__.<>4__this = this;
			<NewWavePlateTipGamepad>d__.<>1__state = -1;
			<NewWavePlateTipGamepad>d__.<>t__builder.Start<TopPanel.<NewWavePlateTipGamepad>d__148>(ref <NewWavePlateTipGamepad>d__);
			return <NewWavePlateTipGamepad>d__.<>t__builder.Task;
		}

		// Token: 0x0603D99C RID: 252316 RVA: 0x00FB1A70 File Offset: 0x00FAFC70
		private UniTask NewAlertAreaInfo()
		{
			TopPanel.<NewAlertAreaInfo>d__149 <NewAlertAreaInfo>d__;
			<NewAlertAreaInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAlertAreaInfo>d__.<>4__this = this;
			<NewAlertAreaInfo>d__.<>1__state = -1;
			<NewAlertAreaInfo>d__.<>t__builder.Start<TopPanel.<NewAlertAreaInfo>d__149>(ref <NewAlertAreaInfo>d__);
			return <NewAlertAreaInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603D99D RID: 252317 RVA: 0x00FB1AB4 File Offset: 0x00FAFCB4
		private UniTask NewGamepadTopPanel()
		{
			TopPanel.<NewGamepadTopPanel>d__150 <NewGamepadTopPanel>d__;
			<NewGamepadTopPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewGamepadTopPanel>d__.<>4__this = this;
			<NewGamepadTopPanel>d__.<>1__state = -1;
			<NewGamepadTopPanel>d__.<>t__builder.Start<TopPanel.<NewGamepadTopPanel>d__150>(ref <NewGamepadTopPanel>d__);
			return <NewGamepadTopPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603D99E RID: 252318 RVA: 0x00FB1AF8 File Offset: 0x00FAFCF8
		private UniTask NewFishingView()
		{
			TopPanel.<NewFishingView>d__151 <NewFishingView>d__;
			<NewFishingView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFishingView>d__.<>4__this = this;
			<NewFishingView>d__.<>1__state = -1;
			<NewFishingView>d__.<>t__builder.Start<TopPanel.<NewFishingView>d__151>(ref <NewFishingView>d__);
			return <NewFishingView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D99F RID: 252319 RVA: 0x00FB1B3C File Offset: 0x00FAFD3C
		private UniTask NewMoraleExpView()
		{
			TopPanel.<NewMoraleExpView>d__152 <NewMoraleExpView>d__;
			<NewMoraleExpView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewMoraleExpView>d__.<>4__this = this;
			<NewMoraleExpView>d__.<>1__state = -1;
			<NewMoraleExpView>d__.<>t__builder.Start<TopPanel.<NewMoraleExpView>d__152>(ref <NewMoraleExpView>d__);
			return <NewMoraleExpView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9A0 RID: 252320 RVA: 0x00FB1B80 File Offset: 0x00FAFD80
		private void OnDriveFishingShipStateChanged(bool isDriving)
		{
			BattleFishingView fishingView = this.FishingView;
			if (fishingView != null)
			{
				fishingView.SetDriveFishingShipVisible(isDriving);
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.Formation, !isDriving, true, 0);
			}
			BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData2 == null)
			{
				return;
			}
			childViewData2.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.GamepadFormation, !isDriving, true, 0);
		}

		// Token: 0x0603D9A1 RID: 252321 RVA: 0x00FB1BDA File Offset: 0x00FAFDDA
		private void ResDownLoadStateRefresh()
		{
			this.RefreshResDownLoadTopPanelState();
		}

		// Token: 0x0603D9A2 RID: 252322 RVA: 0x00FB1BE4 File Offset: 0x00FAFDE4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "MoraleExp")
			{
				MoraleExpView moraleExpView = this.MoraleExpView;
				UUIItem uuiitem = (moraleExpView != null) ? moraleExpView.GetGuideUiItem("0") : null;
				if (uuiitem == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			else if (a == "HonamiStoryPlayerLevel")
			{
				BattleHonamiStoryPlayerStateView honamiStoryPlayerStateView = this.HonamiStoryPlayerStateView;
				UUIItem uuiitem2 = (honamiStoryPlayerStateView != null) ? honamiStoryPlayerStateView.GetGuideUiItem("0") : null;
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
			else if (a == "HonamiStoryMapLevel")
			{
				BattleHonamiStoryMapLevelView honamiStoryMapLevelView = this.HonamiStoryMapLevelView;
				UUIItem uuiitem3 = (honamiStoryMapLevelView != null) ? honamiStoryMapLevelView.GetGuideUiItem("0") : null;
				UUIItem rootItem = this.HonamiStoryMapLevelView.GetRootItem();
				if (uuiitem3 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					rootItem,
					uuiitem3
				};
			}
			else if (a == "HonamiStoryLeaveBtn")
			{
				BattleHonamiStoryLeaveButton honamiStoryLeaveButton = this.HonamiStoryLeaveButton;
				UUIItem uuiitem4 = (honamiStoryLeaveButton != null) ? honamiStoryLeaveButton.GetGuideUiItem("0") : null;
				if (uuiitem4 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem4,
					uuiitem4
				};
			}
			else if (a == "FlagChallengeBuff")
			{
				CommonTopButtonPanel flagChallengeBuffButton = this.FlagChallengeBuffButton;
				UUIItem uuiitem5 = (flagChallengeBuffButton != null) ? flagChallengeBuffButton.GetRootItem() : null;
				if (uuiitem5 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem5,
					uuiitem5
				};
			}
			else if (a == "FlagChallengePause")
			{
				CommonTopButtonPanel flagChallengeLevelButton = this.FlagChallengeLevelButton;
				UUIItem uuiitem6 = (flagChallengeLevelButton != null) ? flagChallengeLevelButton.GetRootItem() : null;
				if (uuiitem6 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem6,
					uuiitem6
				};
			}
			else if (a == "FlagChallengeMapBar")
			{
				FlagChallengeExpView flagChallengeExpView = this.FlagChallengeExpView;
				UUIItem uuiitem7 = (flagChallengeExpView != null) ? flagChallengeExpView.GetLevelBgTextureItem() : null;
				if (uuiitem7 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem7,
					uuiitem7
				};
			}
			else if (a == "ResDownLoadBtn")
			{
				ResDownLoadTopPanel resDownLoadItemTopPanel = this.ResDownLoadItemTopPanel;
				UUIItem uuiitem8 = (resDownLoadItemTopPanel != null) ? resDownLoadItemTopPanel.GetRootItem() : null;
				if (uuiitem8 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem8,
					uuiitem8
				};
			}
			else
			{
				BattleFishingView fishingView = this.FishingView;
				if (fishingView == null)
				{
					return null;
				}
				return fishingView.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x0603D9A3 RID: 252323 RVA: 0x00FB1DE8 File Offset: 0x00FAFFE8
		private UniTask NewHonamiStoryItems()
		{
			TopPanel.<NewHonamiStoryItems>d__156 <NewHonamiStoryItems>d__;
			<NewHonamiStoryItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewHonamiStoryItems>d__.<>4__this = this;
			<NewHonamiStoryItems>d__.<>1__state = -1;
			<NewHonamiStoryItems>d__.<>t__builder.Start<TopPanel.<NewHonamiStoryItems>d__156>(ref <NewHonamiStoryItems>d__);
			return <NewHonamiStoryItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9A4 RID: 252324 RVA: 0x00FB1E2B File Offset: 0x00FB002B
		private void OnClickHonamiStoryBag()
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.HonamiStoryBackpack);
		}

		// Token: 0x0603D9A5 RID: 252325 RVA: 0x00FB1E3C File Offset: 0x00FB003C
		private bool HonamiStoryBagHide()
		{
			return !HonamiStoryUtil.CheckInHonamiStoryDungeon();
		}

		// Token: 0x0603D9A6 RID: 252326 RVA: 0x00FB1E48 File Offset: 0x00FB0048
		private UniTask NewFlagChallengeItems()
		{
			TopPanel.<NewFlagChallengeItems>d__159 <NewFlagChallengeItems>d__;
			<NewFlagChallengeItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFlagChallengeItems>d__.<>4__this = this;
			<NewFlagChallengeItems>d__.<>1__state = -1;
			<NewFlagChallengeItems>d__.<>t__builder.Start<TopPanel.<NewFlagChallengeItems>d__159>(ref <NewFlagChallengeItems>d__);
			return <NewFlagChallengeItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9A7 RID: 252327 RVA: 0x00FB1E8C File Offset: 0x00FB008C
		private UniTask NewFlagChallengePauseButton()
		{
			TopPanel.<NewFlagChallengePauseButton>d__160 <NewFlagChallengePauseButton>d__;
			<NewFlagChallengePauseButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFlagChallengePauseButton>d__.<>4__this = this;
			<NewFlagChallengePauseButton>d__.<>1__state = -1;
			<NewFlagChallengePauseButton>d__.<>t__builder.Start<TopPanel.<NewFlagChallengePauseButton>d__160>(ref <NewFlagChallengePauseButton>d__);
			return <NewFlagChallengePauseButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9A8 RID: 252328 RVA: 0x00FB1ED0 File Offset: 0x00FB00D0
		private void OnClickedFlagChallengeLevelButton()
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			int levelId = ModelBase<FlagChallengeBattleModel>.Instance.LevelId;
			int areaId = ModelBase<FlagChallengeBattleModel>.Instance.AreaId;
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId);
			int levelRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetLevelRecommendStrongholdId(activityId, levelId, new int[]
			{
				areaId
			});
			FlagChallengeStrongholdData strongholdData = flagChallengeData.GetStrongholdData(levelRecommendStrongholdId);
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeAreaDetailView(activityId, levelId, strongholdData.StrongholdConfig.AreaId, new int?(levelRecommendStrongholdId));
		}

		// Token: 0x0603D9A9 RID: 252329 RVA: 0x00FB1F4C File Offset: 0x00FB014C
		private void OnClickedFlagChallengeBuffButton()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeBuffView(ModelBase<FlagChallengeBattleModel>.Instance.ActivityId, null);
		}

		// Token: 0x0603D9AA RID: 252330 RVA: 0x00FB1F76 File Offset: 0x00FB0176
		private void OnClickedFlagChallengePauseButton()
		{
			ControllerBase<FlagChallengeBattleController>.Instance.OpenPauseView();
		}

		// Token: 0x0603D9AB RID: 252331 RVA: 0x00FB1F82 File Offset: 0x00FB0182
		private bool FlagChallengeButtonHide()
		{
			return !ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon;
		}

		// Token: 0x0603D9AC RID: 252332 RVA: 0x00FB1F91 File Offset: 0x00FB0191
		private void RefreshFlagChallengeUiVisibleState()
		{
			if (ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				FlagChallengeExpView flagChallengeExpView = this.FlagChallengeExpView;
				if (flagChallengeExpView == null)
				{
					return;
				}
				flagChallengeExpView.StartShow();
				return;
			}
			else
			{
				FlagChallengeExpView flagChallengeExpView2 = this.FlagChallengeExpView;
				if (flagChallengeExpView2 == null)
				{
					return;
				}
				flagChallengeExpView2.EndShow();
				return;
			}
		}

		// Token: 0x0603D9AD RID: 252333 RVA: 0x00FB1FC0 File Offset: 0x00FB01C0
		private UniTask NewBossPilingTopPanel()
		{
			TopPanel.<NewBossPilingTopPanel>d__166 <NewBossPilingTopPanel>d__;
			<NewBossPilingTopPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewBossPilingTopPanel>d__.<>4__this = this;
			<NewBossPilingTopPanel>d__.<>1__state = -1;
			<NewBossPilingTopPanel>d__.<>t__builder.Start<TopPanel.<NewBossPilingTopPanel>d__166>(ref <NewBossPilingTopPanel>d__);
			return <NewBossPilingTopPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9AE RID: 252334 RVA: 0x00FB2004 File Offset: 0x00FB0204
		private void RefreshBossPilingTopState()
		{
			if (this.BossPilingTopItem == null)
			{
				return;
			}
			bool flag = this.CheckIsBossPiling();
			this.MiniMapView.SetRoguelikeVisible(!flag);
			if (flag)
			{
				this.ButtonList.ForEach(delegate(BattleEntranceButton button)
				{
					button.SetOtherHide(true);
				});
				this.ExitButton.SetOtherHide(false);
				BossPilingTopItem bossPilingTopItem = this.BossPilingTopItem;
				if (bossPilingTopItem == null)
				{
					return;
				}
				bossPilingTopItem.StartShow();
				return;
			}
			else
			{
				BossPilingTopItem bossPilingTopItem2 = this.BossPilingTopItem;
				if (bossPilingTopItem2 == null)
				{
					return;
				}
				bossPilingTopItem2.EndShow();
				return;
			}
		}

		// Token: 0x0603D9AF RID: 252335 RVA: 0x00FB208C File Offset: 0x00FB028C
		[NullableContext(1)]
		[return: Nullable(2)]
		public UUIItem GetPanelItem(string item)
		{
			if (!(item == "PhoneMsgButton"))
			{
				if (!(item == "EntitySequenceButtonRoot"))
				{
					return null;
				}
				if (!Singleton<Info>.Instance.IsInGamepad())
				{
					return base.GetItem(39);
				}
				GamepadTopPanel gamepadTopPanel = this.GamepadTopPanel;
				if (gamepadTopPanel == null)
				{
					return null;
				}
				return gamepadTopPanel.GetPanelItem(item);
			}
			else
			{
				if (!Singleton<Info>.Instance.IsInGamepad())
				{
					return base.GetItem(38);
				}
				GamepadTopPanel gamepadTopPanel2 = this.GamepadTopPanel;
				if (gamepadTopPanel2 == null)
				{
					return null;
				}
				return gamepadTopPanel2.GetPanelItem(item);
			}
		}

		// Token: 0x0603D9B0 RID: 252336 RVA: 0x00FB2106 File Offset: 0x00FB0306
		public IPhoneMessageButtonImplement GetPhoneMsgButton()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return this.GamepadTopPanel.GetPhoneMsgButton();
			}
			return this.PhoneMsgButton;
		}

		// Token: 0x04022935 RID: 141621
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]TopPanelTick", "", "");

		// Token: 0x04022936 RID: 141622
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly EBattleUiChild[] BattleUiChildren = new EBattleUiChild[]
		{
			EBattleUiChild.MiniMap,
			EBattleUiChild.TopButton,
			EBattleUiChild.HomeButton,
			EBattleUiChild.ExitButton
		};

		// Token: 0x04022937 RID: 141623
		private MiniMapView MiniMapView;

		// Token: 0x04022938 RID: 141624
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<BattleEntranceButton> ButtonList;

		// Token: 0x04022939 RID: 141625
		private BattleEntranceButton ExitButton;

		// Token: 0x0402293A RID: 141626
		private BattleEntranceButton HomeButton;

		// Token: 0x0402293B RID: 141627
		private BattleEntranceButton ActivityButton;

		// Token: 0x0402293C RID: 141628
		private BattleEntranceButton DirectTrainProButton;

		// Token: 0x0402293D RID: 141629
		private BattleEntranceButton MoraleBuffSumButton;

		// Token: 0x0402293E RID: 141630
		private BattleOnlineButton OnlineButton;

		// Token: 0x0402293F RID: 141631
		private BattlePhoneMessageButton PhoneMsgButton;

		// Token: 0x04022940 RID: 141632
		private BattleQuestButton QuestButton;

		// Token: 0x04022941 RID: 141633
		private BattleDungeonGuideButton DungeonGuideButton;

		// Token: 0x04022942 RID: 141634
		private BattleEntranceButton RogueInfoButton;

		// Token: 0x04022943 RID: 141635
		private BattleFormationButton FightTeamButton;

		// Token: 0x04022944 RID: 141636
		private SilentAreaView SilentAreaView;

		// Token: 0x04022945 RID: 141637
		private ShipTowerBuffBattleView ShipTowerBuffView;

		// Token: 0x04022946 RID: 141638
		private MoraleBuffBattleView MoraleBuffView;

		// Token: 0x04022947 RID: 141639
		private MowingRiskInBattleView MowingRiskView;

		// Token: 0x04022948 RID: 141640
		private BabelTowerBattleTopPanel BabelTowerBattleTopPanel;

		// Token: 0x04022949 RID: 141641
		private ResDownLoadTopPanel ResDownLoadItemTopPanel;

		// Token: 0x0402294A RID: 141642
		private BattleTowerButton TowerGuideButton;

		// Token: 0x0402294B RID: 141643
		private BattleEntranceButton SettingButton;

		// Token: 0x0402294C RID: 141644
		private TopPanelWavePlateTip WavePlateTip;

		// Token: 0x0402294D RID: 141645
		private TopPanelWavePlateTip WavePlateTipGamePad;

		// Token: 0x0402294E RID: 141646
		private AlertAreaInfoView AlertAreaInfoView;

		// Token: 0x0402294F RID: 141647
		private GamepadTopPanel GamepadTopPanel;

		// Token: 0x04022950 RID: 141648
		private CommonTopButtonPanel HonamiStoryBagButton;

		// Token: 0x04022951 RID: 141649
		private BattleHonamiStoryLeaveButton HonamiStoryLeaveButton;

		// Token: 0x04022952 RID: 141650
		private BattleHonamiStoryMapLevelView HonamiStoryMapLevelView;

		// Token: 0x04022953 RID: 141651
		private BattleHonamiStoryPlayerStateView HonamiStoryPlayerStateView;

		// Token: 0x04022954 RID: 141652
		private BattleFishingView FishingView;

		// Token: 0x04022955 RID: 141653
		private MoraleExpView MoraleExpView;

		// Token: 0x04022956 RID: 141654
		private FlagChallengeExpView FlagChallengeExpView;

		// Token: 0x04022957 RID: 141655
		private CommonTopButtonPanel FlagChallengeLevelButton;

		// Token: 0x04022958 RID: 141656
		private CommonTopButtonPanel FlagChallengeBuffButton;

		// Token: 0x04022959 RID: 141657
		private CommonTopButtonPanel FlagChallengePauseButton;

		// Token: 0x0402295A RID: 141658
		private BossPilingTopItem BossPilingTopItem;

		// Token: 0x0402295B RID: 141659
		private BattleTopPanelHookCenter UiHookCenter;

		// Token: 0x0402295C RID: 141660
		private bool IsGamepad;

		// Token: 0x0402295D RID: 141661
		private bool IsGamepadPanelCreated;

		// Token: 0x0402295E RID: 141662
		private UniTaskCompletionSource GamepadPanelCreatePromise;

		// Token: 0x0200BFE5 RID: 49125
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B124 RID: 241956
			MiniMapItem,
			// Token: 0x0403B125 RID: 241957
			HomeButtonItem,
			// Token: 0x0403B126 RID: 241958
			ExitButtonItem,
			// Token: 0x0403B127 RID: 241959
			GachaButtonItem,
			// Token: 0x0403B128 RID: 241960
			OnlineButtonItem,
			// Token: 0x0403B129 RID: 241961
			ShopButtonItem,
			// Token: 0x0403B12A RID: 241962
			InventoryButtonItem,
			// Token: 0x0403B12B RID: 241963
			PassCheckButtonItem,
			// Token: 0x0403B12C RID: 241964
			RoleButtonItem,
			// Token: 0x0403B12D RID: 241965
			HelpButtonItem,
			// Token: 0x0403B12E RID: 241966
			ActivityItem,
			// Token: 0x0403B12F RID: 241967
			QuestButton,
			// Token: 0x0403B130 RID: 241968
			DungeonGuideButton,
			// Token: 0x0403B131 RID: 241969
			RogueInfoButton,
			// Token: 0x0403B132 RID: 241970
			SilentInfoItem = 15,
			// Token: 0x0403B133 RID: 241971
			TowerGuideButton,
			// Token: 0x0403B134 RID: 241972
			FightTeamButton,
			// Token: 0x0403B135 RID: 241973
			VoiceToggle,
			// Token: 0x0403B136 RID: 241974
			SettingButton,
			// Token: 0x0403B137 RID: 241975
			TowerDefenseItem,
			// Token: 0x0403B138 RID: 241976
			MowingRiskItem,
			// Token: 0x0403B139 RID: 241977
			DungeonTutorialButton,
			// Token: 0x0403B13A RID: 241978
			WavePlateTipItem,
			// Token: 0x0403B13B RID: 241979
			AlertAreaInfoItem,
			// Token: 0x0403B13C RID: 241980
			FishingView,
			// Token: 0x0403B13D RID: 241981
			ShipTowerBuffItem = 27,
			// Token: 0x0403B13E RID: 241982
			BabelTowerStarItem,
			// Token: 0x0403B13F RID: 241983
			IosSettingItem,
			// Token: 0x0403B140 RID: 241984
			PanelLeftTop,
			// Token: 0x0403B141 RID: 241985
			DirectTrainProButtonItem,
			// Token: 0x0403B142 RID: 241986
			MapBarItem,
			// Token: 0x0403B143 RID: 241987
			MoraleBuffItem,
			// Token: 0x0403B144 RID: 241988
			MoraleSumButtonItem,
			// Token: 0x0403B145 RID: 241989
			HonamiStoryLeaveItem,
			// Token: 0x0403B146 RID: 241990
			PlayerLevelItem,
			// Token: 0x0403B147 RID: 241991
			PhoneMsgButtonItem = 38,
			// Token: 0x0403B148 RID: 241992
			EntitySequenceButtonRoot,
			// Token: 0x0403B149 RID: 241993
			MAX
		}

		// Token: 0x0200BFE6 RID: 49126
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B14B RID: 241995
			KeyBoardPane = 40,
			// Token: 0x0403B14C RID: 241996
			GamepadPanel,
			// Token: 0x0403B14D RID: 241997
			WavePlateTipGamepadItem
		}

		// Token: 0x0200BFE7 RID: 49127
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403B14E RID: 241998
			[Nullable(0)]
			public static Action <0>__OnClickedOnlineButton;

			// Token: 0x0403B14F RID: 241999
			[Nullable(0)]
			public static Action <1>__OnClickedPhoneMsgButton;

			// Token: 0x0403B150 RID: 242000
			[Nullable(0)]
			public static Action <2>__OnClickedTowerGuideButton;

			// Token: 0x0403B151 RID: 242001
			[Nullable(0)]
			public static Action <3>__OnClickedDungeonGuideButton;
		}
	}
}
