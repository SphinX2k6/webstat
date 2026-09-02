using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.QuickHack;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F9F RID: 24479
	[NullableContext(2)]
	[Nullable(0)]
	public class CenterPanel : BattleChildViewPanel
	{
		// Token: 0x0603D787 RID: 251783 RVA: 0x00FA47E0 File Offset: 0x00FA29E0
		protected unsafe override void OnRegisterComponent()
		{
			EOperationType operationType = base.GetOperationType();
			if (operationType == EOperationType.Desktop)
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				return;
			}
			if (operationType == EOperationType.Pad)
			{
				int num2 = 5;
				List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
				int num = 0;
				*span[num] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(1, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(3, typeof(UUIItem));
				num++;
				*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
				this.ComponentRegisterInfos = list2;
			}
		}

		// Token: 0x0603D788 RID: 251784 RVA: 0x00FA493C File Offset: 0x00FA2B3C
		public override void InitializeTemp()
		{
			this.OnBattleHudVisibleChanged();
			this.CurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		}

		// Token: 0x0603D789 RID: 251785 RVA: 0x00FA4954 File Offset: 0x00FA2B54
		public override UniTask InitializeAsync()
		{
			CenterPanel.<InitializeAsync>d__30 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<CenterPanel.<InitializeAsync>d__30>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D78A RID: 251786 RVA: 0x00FA4998 File Offset: 0x00FA2B98
		protected override void OnShowBattleChildViewPanel(bool isFirst)
		{
			Joystick joystick = this.Joystick;
			if (joystick != null)
			{
				joystick.ShowBattleVisibleChildView();
			}
			this.RefreshJoystickEnable();
			TrackedMarksView trackedMarksView = this.TrackedMarksView;
			if (trackedMarksView != null)
			{
				trackedMarksView.OnShowBattleChildViewPanel();
			}
			AutoPilotTrackedMarksView autoPilotTrackedMarksView = this.AutoPilotTrackedMarksView;
			if (autoPilotTrackedMarksView != null)
			{
				autoPilotTrackedMarksView.OnShowBattleChildViewPanel();
			}
			MotorcycleControlTopPanel motorcycleControlTopPanel = this.MotorcycleControlTopPanel;
			if (motorcycleControlTopPanel != null)
			{
				motorcycleControlTopPanel.OnShowBattleChildViewPanel();
			}
			QuickHackMarksView quickHackMarksView = this.QuickHackMarksView;
			if (quickHackMarksView == null)
			{
				return;
			}
			quickHackMarksView.OnShowBattleChildViewPanel();
		}

		// Token: 0x0603D78B RID: 251787 RVA: 0x00FA4A00 File Offset: 0x00FA2C00
		protected override void OnHideBattleChildViewPanel()
		{
			Joystick joystick = this.Joystick;
			if (joystick != null)
			{
				joystick.HideBattleVisibleChildView();
			}
			TrackedMarksView trackedMarksView = this.TrackedMarksView;
			if (trackedMarksView != null)
			{
				trackedMarksView.OnHideBattleChildViewPanel();
			}
			AutoPilotTrackedMarksView autoPilotTrackedMarksView = this.AutoPilotTrackedMarksView;
			if (autoPilotTrackedMarksView != null)
			{
				autoPilotTrackedMarksView.OnHideBattleChildViewPanel();
			}
			MotorcycleControlTopPanel motorcycleControlTopPanel = this.MotorcycleControlTopPanel;
			if (motorcycleControlTopPanel == null)
			{
				return;
			}
			motorcycleControlTopPanel.OnHideBattleChildViewPanel();
		}

		// Token: 0x0603D78C RID: 251788 RVA: 0x00FA4A50 File Offset: 0x00FA2C50
		public void SetEventVisible(bool value)
		{
		}

		// Token: 0x0603D78D RID: 251789 RVA: 0x00FA4A54 File Offset: 0x00FA2C54
		public override void Reset()
		{
			this.TrackedMarksView = null;
			this.AutoPilotTrackedMarksView = null;
			this.AlterMarksView = null;
			this.Joystick = null;
			GrapplingHookPoint hookPointMakerPanel = this.HookPointMakerPanel;
			if (hookPointMakerPanel != null)
			{
				hookPointMakerPanel.Destroy(null);
			}
			this.HookPointMakerPanel = null;
			ExecutionPanel executionPanel = this.ExecutionPanel;
			if (executionPanel != null)
			{
				executionPanel.Destroy(null);
			}
			this.ExecutionPanel = null;
			BreakWeaknessPanel breakWeaknessPanel = this.BreakWeaknessPanel;
			if (breakWeaknessPanel != null)
			{
				breakWeaknessPanel.Destroy(null);
			}
			this.BreakWeaknessPanel = null;
			if (this.MotorcycleControlPanel != null)
			{
				this.MotorcycleControlPanel.Destroy(null);
				this.MotorcycleControlPanel = null;
			}
			if (this.MotorcycleControlTopPanel != null)
			{
				this.MotorcycleControlTopPanel.Destroy(null);
				this.MotorcycleControlTopPanel = null;
			}
			if (this.MotorcycleControlHudPanel != null)
			{
				this.MotorcycleControlHudPanel.Destroy(null);
				this.MotorcycleControlHudPanel = null;
			}
			if (this.SlideControlComponent != null)
			{
				this.SlideControlComponent.Destroy(null);
				this.SlideControlComponent = null;
				ModelBase<BattleUiModel>.Instance.SlideControlData.ForceStop();
			}
			this.EntityList.Clear();
			base.Reset();
		}

		// Token: 0x0603D78E RID: 251790 RVA: 0x00FA4B54 File Offset: 0x00FA2D54
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.Add(EEventName.ExploreComponentTargetChanged, new Action(this.OnExploreComponentTargetChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
			Singleton<EventSystem>.Instance.Add<bool, int, ECustomOptionType?>(EEventName.OnEnterOrExitExecutionRange, new Action<bool, int, ECustomOptionType?>(this.OnEnterOrExitExecutionRange));
			Singleton<EventSystem>.Instance.Add(EEventName.GmOnlyShowJoyStick, new Action<bool>(this.OnGmOnlyShowJoyStick));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.EnableGrapplingHookMark, new Action<bool>(this.OnEnableGrapplingHookMark));
			Singleton<EventSystem>.Instance.Add(EEventName.OnSetBattleUiChildCacheState, new Action<EBattleUiChildCacheType, bool>(this.OnSetBattleUiChildCacheState));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiSlideControlVisibleChanged, new Action<bool>(this.OnSlideControlVisibleChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnMotorcycleRoundJoystickChanged, new Action<bool>(this.OnMotorcycleRoundJoystickChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnAutoPilotTrackMarkVisibleChanged, new Action<bool>(this.OnAutoPilotTrackMarkVisibleChanged));
			this.ChildViewData.AddCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleHudVisibleChanged));
		}

		// Token: 0x0603D78F RID: 251791 RVA: 0x00FA4CB0 File Offset: 0x00FA2EB0
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRoleCompleted));
			Singleton<EventSystem>.Instance.Remove(EEventName.ExploreComponentTargetChanged, new Action(this.OnExploreComponentTargetChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOrExitExecutionRange, new Action<bool, int, ECustomOptionType?>(this.OnEnterOrExitExecutionRange));
			Singleton<EventSystem>.Instance.Remove(EEventName.GmOnlyShowJoyStick, new Action<bool>(this.OnGmOnlyShowJoyStick));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.EnableGrapplingHookMark, new Action<bool>(this.OnEnableGrapplingHookMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSetBattleUiChildCacheState, new Action<EBattleUiChildCacheType, bool>(this.OnSetBattleUiChildCacheState));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiSlideControlVisibleChanged, new Action<bool>(this.OnSlideControlVisibleChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorcycleRoundJoystickChanged, new Action<bool>(this.OnMotorcycleRoundJoystickChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAutoPilotTrackMarkVisibleChanged, new Action<bool>(this.OnAutoPilotTrackMarkVisibleChanged));
			this.ChildViewData.RemoveCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleHudVisibleChanged));
		}

		// Token: 0x0603D790 RID: 251792 RVA: 0x00FA4E0C File Offset: 0x00FA300C
		public override void OnTickBattleChildViewPanel(float delta)
		{
			Joystick joystick = this.Joystick;
			if (joystick != null)
			{
				joystick.Tick(delta);
			}
			IBattleUiCenterPanelOtherMovePanel otherMovePanel = this.OtherMovePanel;
			if (otherMovePanel != null)
			{
				otherMovePanel.Tick(delta);
			}
			MotorcycleControlPanelBase motorcycleControlPanel = this.MotorcycleControlPanel;
			if (motorcycleControlPanel != null)
			{
				motorcycleControlPanel.Tick(delta);
			}
			MotorcycleControlTopPanel motorcycleControlTopPanel = this.MotorcycleControlTopPanel;
			if (motorcycleControlTopPanel != null)
			{
				motorcycleControlTopPanel.Tick(delta);
			}
			MotorcycleControlHudPanel motorcycleControlHudPanel = this.MotorcycleControlHudPanel;
			if (motorcycleControlHudPanel != null)
			{
				motorcycleControlHudPanel.Tick(delta);
			}
			BattleSkillSlideControlItem slideControlComponent = this.SlideControlComponent;
			if (slideControlComponent != null)
			{
				slideControlComponent.Tick(delta);
			}
			this.AlterMarksView.Update(delta);
			this.UpdateHookPointPosition();
			BreakWeaknessPanel breakWeaknessPanel = this.BreakWeaknessPanel;
			if (breakWeaknessPanel == null)
			{
				return;
			}
			breakWeaknessPanel.Tick(delta);
		}

		// Token: 0x0603D791 RID: 251793 RVA: 0x00FA4EA8 File Offset: 0x00FA30A8
		public override void OnAfterTickBattleChildViewPanel(float delta)
		{
			TrackedMarksView trackedMarksView = this.TrackedMarksView;
			if (trackedMarksView != null)
			{
				trackedMarksView.Update(delta);
			}
			this.ScanTrackedMarksView.Update();
			this.GrapplingHookPointAfterTick();
			AutoPilotTrackedMarksView autoPilotTrackedMarksView = this.AutoPilotTrackedMarksView;
			if (autoPilotTrackedMarksView != null)
			{
				autoPilotTrackedMarksView.Update(delta);
			}
			QuickHackMarksView quickHackMarksView = this.QuickHackMarksView;
			if (quickHackMarksView == null)
			{
				return;
			}
			quickHackMarksView.Update();
		}

		// Token: 0x0603D792 RID: 251794 RVA: 0x00FA4EFA File Offset: 0x00FA30FA
		private void OnExploreComponentTargetChanged()
		{
			this.UpdateHookPointMarker();
		}

		// Token: 0x0603D793 RID: 251795 RVA: 0x00FA4F04 File Offset: 0x00FA3104
		private void OnBattleHudVisibleChanged()
		{
			bool childVisible = this.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
			base.GetItem(0).SetUIActive(childVisible);
			AlterMarksView alterMarksView = this.AlterMarksView;
			if (alterMarksView == null)
			{
				return;
			}
			alterMarksView.OnBattleHudVisibleChanged(childVisible);
		}

		// Token: 0x0603D794 RID: 251796 RVA: 0x00FA4F3D File Offset: 0x00FA313D
		private void OnEnableGrapplingHookMark(bool isEnable)
		{
			this.ForceHideHookPointMaker = !isEnable;
		}

		// Token: 0x0603D795 RID: 251797 RVA: 0x00FA4F4C File Offset: 0x00FA314C
		private void OnRouletteViewVisibleChanged(bool bVisible)
		{
			UUIItem item = base.GetItem(2);
			item.SetUIActive(bVisible);
			item.SetRaycastTarget(bVisible);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BattleUiSet;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "轮盘界面显隐，设置CenterPanel遮罩";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bVisible", bVisible);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603D796 RID: 251798 RVA: 0x00FA4F9C File Offset: 0x00FA319C
		private void OnEnterOrExitExecutionRange(bool isEnter, int entityId, ECustomOptionType? optionType)
		{
			if (isEnter)
			{
				if (optionType.GetValueOrDefault() == ECustomOptionType.Execution)
				{
					if (this.ExecutionPanel == null)
					{
						this.ExecutionPanel = new ExecutionPanel();
						this.ExecutionPanel.Init(this.RootItem);
					}
					this.ExecutionPanel.ShowByEntity(entityId, optionType);
					return;
				}
				if (optionType.GetValueOrDefault() == ECustomOptionType.BreakWeakness)
				{
					if (this.BreakWeaknessPanel == null)
					{
						this.BreakWeaknessPanel = new BreakWeaknessPanel();
						if (Singleton<Info>.Instance.IsInTouch())
						{
							this.BreakWeaknessPanel.Init(this.RootItem, base.GetItem(4));
						}
						else
						{
							this.BreakWeaknessPanel.Init(Singleton<UiLayer>.Instance.GetBattleViewUnit(1), null);
						}
					}
					this.BreakWeaknessPanel.ShowByEntity(entityId, optionType);
				}
				return;
			}
			else
			{
				ExecutionPanel executionPanel = this.ExecutionPanel;
				if (executionPanel != null)
				{
					executionPanel.HideByEntity(entityId);
				}
				BreakWeaknessPanel breakWeaknessPanel = this.BreakWeaknessPanel;
				if (breakWeaknessPanel == null)
				{
					return;
				}
				breakWeaknessPanel.HideByEntity(entityId);
				return;
			}
		}

		// Token: 0x0603D797 RID: 251799 RVA: 0x00FA5076 File Offset: 0x00FA3276
		private void OnGmOnlyShowJoyStick(bool isVisible)
		{
			base.GetItem(0).SetUIActive(isVisible);
			base.GetItem(1).SetUIActive(isVisible);
			base.GetItem(2).SetUIActive(isVisible);
		}

		// Token: 0x0603D798 RID: 251800 RVA: 0x00FA50A0 File Offset: 0x00FA32A0
		[NullableContext(1)]
		private void CreateHookPointMaker(Vector targetLocation)
		{
			if (this.HookPointMakerPanel != null)
			{
				GrapplingHookPoint hookPointMakerPanel = this.HookPointMakerPanel;
				FVectorDouble fvectorDouble = targetLocation.ToUeVector(false);
				hookPointMakerPanel.UpdateHookPointLocation(fvectorDouble);
				return;
			}
			UUIItem battleViewUnit = Singleton<UiLayer>.Instance.GetBattleViewUnit(1);
			this.HookPointMakerPanel = new GrapplingHookPoint(targetLocation, battleViewUnit);
		}

		// Token: 0x0603D799 RID: 251801 RVA: 0x00FA50E4 File Offset: 0x00FA32E4
		private void RemoveHookPointMaker()
		{
			if (this.HookPointMakerPanel == null)
			{
				return;
			}
			this.HookPointMakerPanel.Destroy(null);
			this.HookPointMakerPanel = null;
		}

		// Token: 0x0603D79A RID: 251802 RVA: 0x00FA5104 File Offset: 0x00FA3304
		private void UpdateHookPointPosition()
		{
			if (this.HookPointMakerPanel == null)
			{
				return;
			}
			BaseExploreComponent activeExploreComponent = ModelBase<CharacterExploreModel>.Instance.GetActiveExploreComponent();
			if (activeExploreComponent == null || !activeExploreComponent.Valid)
			{
				return;
			}
			GrapplingHookPointComponent focusTarget = activeExploreComponent.FocusTarget;
			if (activeExploreComponent.FocusTargetLegal && focusTarget != null && focusTarget.IsMovable())
			{
				GrapplingHookPoint hookPointMakerPanel = this.HookPointMakerPanel;
				FVectorDouble fvectorDouble = focusTarget.HookLocation.ToUeVector(false);
				hookPointMakerPanel.UpdateHookPointLocation(fvectorDouble);
			}
		}

		// Token: 0x0603D79B RID: 251803 RVA: 0x00FA516C File Offset: 0x00FA336C
		private void UpdateHookPointMarker()
		{
			BaseExploreComponent activeExploreComponent = ModelBase<CharacterExploreModel>.Instance.GetActiveExploreComponent();
			if (activeExploreComponent == null || !activeExploreComponent.Valid)
			{
				this.RemoveHookPointMaker();
				return;
			}
			GrapplingHookPointComponent focusTarget = activeExploreComponent.FocusTarget;
			bool focusTargetLegal = activeExploreComponent.FocusTargetLegal;
			if (focusTarget == null || this.ForceHideHookPointMaker)
			{
				this.RemoveHookPointMaker();
				return;
			}
			this.CreateHookPointMaker(focusTarget.HookLocation);
			if (focusTargetLegal)
			{
				GrapplingHookPoint hookPointMakerPanel = this.HookPointMakerPanel;
				if (hookPointMakerPanel == null)
				{
					return;
				}
				hookPointMakerPanel.EnableMarker();
				return;
			}
			else
			{
				GrapplingHookPoint hookPointMakerPanel2 = this.HookPointMakerPanel;
				if (hookPointMakerPanel2 == null)
				{
					return;
				}
				hookPointMakerPanel2.DisableMarker();
				return;
			}
		}

		// Token: 0x0603D79C RID: 251804 RVA: 0x00FA51EC File Offset: 0x00FA33EC
		public UUIItem GetExecutionItem()
		{
			ExecutionPanel executionPanel = this.ExecutionPanel;
			if (executionPanel == null)
			{
				return null;
			}
			return executionPanel.GetExecutionItem();
		}

		// Token: 0x0603D79D RID: 251805 RVA: 0x00FA5200 File Offset: 0x00FA3400
		private void GrapplingHookPointAfterTick()
		{
			if (this.HookPointMakerPanel == null)
			{
				return;
			}
			BaseExploreComponent activeExploreComponent = ModelBase<CharacterExploreModel>.Instance.GetActiveExploreComponent();
			if (activeExploreComponent == null || !activeExploreComponent.Valid || activeExploreComponent.FocusTarget == null)
			{
				this.RemoveHookPointMaker();
				return;
			}
			if (activeExploreComponent.FocusTargetLegal)
			{
				this.HookPointMakerPanel.EnableMarker();
				this.HookPointMakerPanel.AfterTick();
				return;
			}
			this.HookPointMakerPanel.DisableMarker();
		}

		// Token: 0x0603D79E RID: 251806 RVA: 0x00FA526C File Offset: 0x00FA346C
		private UniTask NewTrackedMarksView()
		{
			CenterPanel.<NewTrackedMarksView>d__51 <NewTrackedMarksView>d__;
			<NewTrackedMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewTrackedMarksView>d__.<>4__this = this;
			<NewTrackedMarksView>d__.<>1__state = -1;
			<NewTrackedMarksView>d__.<>t__builder.Start<CenterPanel.<NewTrackedMarksView>d__51>(ref <NewTrackedMarksView>d__);
			return <NewTrackedMarksView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D79F RID: 251807 RVA: 0x00FA52B0 File Offset: 0x00FA34B0
		private UniTask NewScanTrackedMarksView()
		{
			CenterPanel.<NewScanTrackedMarksView>d__52 <NewScanTrackedMarksView>d__;
			<NewScanTrackedMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewScanTrackedMarksView>d__.<>4__this = this;
			<NewScanTrackedMarksView>d__.<>1__state = -1;
			<NewScanTrackedMarksView>d__.<>t__builder.Start<CenterPanel.<NewScanTrackedMarksView>d__52>(ref <NewScanTrackedMarksView>d__);
			return <NewScanTrackedMarksView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7A0 RID: 251808 RVA: 0x00FA52F4 File Offset: 0x00FA34F4
		private UniTask NewAlterMarksView()
		{
			CenterPanel.<NewAlterMarksView>d__53 <NewAlterMarksView>d__;
			<NewAlterMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAlterMarksView>d__.<>4__this = this;
			<NewAlterMarksView>d__.<>1__state = -1;
			<NewAlterMarksView>d__.<>t__builder.Start<CenterPanel.<NewAlterMarksView>d__53>(ref <NewAlterMarksView>d__);
			return <NewAlterMarksView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7A1 RID: 251809 RVA: 0x00FA5338 File Offset: 0x00FA3538
		private UniTask NewAutoPilotTrackedMarksView()
		{
			CenterPanel.<NewAutoPilotTrackedMarksView>d__54 <NewAutoPilotTrackedMarksView>d__;
			<NewAutoPilotTrackedMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAutoPilotTrackedMarksView>d__.<>4__this = this;
			<NewAutoPilotTrackedMarksView>d__.<>1__state = -1;
			<NewAutoPilotTrackedMarksView>d__.<>t__builder.Start<CenterPanel.<NewAutoPilotTrackedMarksView>d__54>(ref <NewAutoPilotTrackedMarksView>d__);
			return <NewAutoPilotTrackedMarksView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7A2 RID: 251810 RVA: 0x00FA537C File Offset: 0x00FA357C
		private UniTask NewQuickHackMarksView()
		{
			CenterPanel.<NewQuickHackMarksView>d__55 <NewQuickHackMarksView>d__;
			<NewQuickHackMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewQuickHackMarksView>d__.<>4__this = this;
			<NewQuickHackMarksView>d__.<>1__state = -1;
			<NewQuickHackMarksView>d__.<>t__builder.Start<CenterPanel.<NewQuickHackMarksView>d__55>(ref <NewQuickHackMarksView>d__);
			return <NewQuickHackMarksView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7A3 RID: 251811 RVA: 0x00FA53C0 File Offset: 0x00FA35C0
		private UniTask NewJoysticks()
		{
			CenterPanel.<NewJoysticks>d__56 <NewJoysticks>d__;
			<NewJoysticks>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewJoysticks>d__.<>4__this = this;
			<NewJoysticks>d__.<>1__state = -1;
			<NewJoysticks>d__.<>t__builder.Start<CenterPanel.<NewJoysticks>d__56>(ref <NewJoysticks>d__);
			return <NewJoysticks>d__.<>t__builder.Task;
		}

		// Token: 0x0603D7A4 RID: 251812 RVA: 0x00FA5404 File Offset: 0x00FA3604
		private void RefreshJoystick()
		{
			EntityHandle currentEntity = this.CurrentEntity;
			if (currentEntity == null || !currentEntity.Valid)
			{
				return;
			}
			if (this.Joystick != null)
			{
				base.ClearAllTagSignificantChangedCallback();
				base.ListenForTagSignificantChanged(this.CurrentEntity, CenterPanel.ForbidMoveTagId, delegate(int _, bool tagExists)
				{
					this.Joystick.SetForbidMove(tagExists);
				});
				this.Joystick.SetForbidMove(base.ContainsTag(this.CurrentEntity, CenterPanel.ForbidMoveTagId));
			}
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			int num = 0;
			if (curRoleData != null && curRoleData.RoleBattleViewInfo != null)
			{
				num = curRoleData.RoleBattleViewInfo.Value.JoystickType;
			}
			if (this.JoystickType == num)
			{
				return;
			}
			this.JoystickType = num;
			Joystick joystick2 = this.Joystick;
			if (joystick2 != null)
			{
				joystick2.SetVisible(EBattleUiVisibleReason.RoleConfig, num == 0);
			}
			this.RefreshJoystickEnable();
			if (this.OtherMovePanel != null)
			{
				this.OtherMovePanel.Destroy(null);
				this.OtherMovePanel = null;
			}
			if (num == 1)
			{
				MoveSkillPanel moveSkillPanel = new MoveSkillPanel();
				moveSkillPanel.CreateDynamic(base.GetRootItem());
				this.OtherMovePanel = moveSkillPanel;
			}
			if (num == 3)
			{
				if (base.GetOperationType() == EOperationType.Pad)
				{
					base.NewDynamicChildViewByResourceIdWithCallback<JoystickStatic>(this.RootItem, "PnlLevelJoystick", true, delegate(JoystickStatic joystick)
					{
						this.OtherMovePanel = joystick;
						joystick.SetVisible(EBattleUiVisibleReason.RoleConfig, true);
						joystick.SetEnable(true);
						joystick.ShowBattleVisibleChildView();
					}, this.RootItem);
					return;
				}
				MoveCursorPanel moveCursorPanel = new MoveCursorPanel();
				moveCursorPanel.CreateDynamic(base.GetRootItem());
				this.OtherMovePanel = moveCursorPanel;
			}
		}

		// Token: 0x0603D7A5 RID: 251813 RVA: 0x00FA5558 File Offset: 0x00FA3758
		private void RefreshJoystickEnable()
		{
			BattleUiMotorcycleData motorcycleData = ModelBase<BattleUiModel>.Instance.MotorcycleData;
			if (motorcycleData.IsDriving && !motorcycleData.GetIsRoundJoystick())
			{
				Joystick joystick = this.Joystick;
				if (joystick == null)
				{
					return;
				}
				joystick.SetEnable(false);
				return;
			}
			else
			{
				Joystick joystick2 = this.Joystick;
				if (joystick2 == null)
				{
					return;
				}
				joystick2.SetEnable(this.JoystickType == 0);
				return;
			}
		}

		// Token: 0x0603D7A6 RID: 251814 RVA: 0x00FA55AC File Offset: 0x00FA37AC
		private void OnChangeRoleCompleted(int i, int i1)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			this.CurrentEntity = curRoleData.EntityHandle;
			this.RefreshJoystick();
			BreakWeaknessPanel breakWeaknessPanel = this.BreakWeaknessPanel;
			if (breakWeaknessPanel == null)
			{
				return;
			}
			breakWeaknessPanel.ChangeRole();
		}

		// Token: 0x0603D7A7 RID: 251815 RVA: 0x00FA55E6 File Offset: 0x00FA37E6
		private void OnMotorcycleStateChanged(bool b)
		{
			this.RefreshMotorcycleControl();
			this.RefreshJoystickEnable();
		}

		// Token: 0x0603D7A8 RID: 251816 RVA: 0x00FA55F4 File Offset: 0x00FA37F4
		private void RefreshMotorcycleControl()
		{
			this.RefreshMotorcycleControlWithCache();
		}

		// Token: 0x0603D7A9 RID: 251817 RVA: 0x00FA55FC File Offset: 0x00FA37FC
		private void RefreshMotorcycleControlWithCache()
		{
			bool isDriving = ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving;
			bool isNeedCacheUi = ModelBase<BattleUiModel>.Instance.MotorcycleData.IsNeedCacheUi;
			bool flag = false;
			if (isNeedCacheUi)
			{
				if (this.MotorcycleControlPanel == null)
				{
					if (Singleton<Info>.Instance.IsInTouch())
					{
						this.MotorcycleControlPanel = new MotorcycleControlMobilePanel();
						this.MotorcycleControlPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControl").Forget();
					}
					else
					{
						this.MotorcycleControlPanel = new MotorcycleControlPanel();
						this.MotorcycleControlPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControl").Forget();
					}
					flag = true;
				}
				if (this.MotorcycleControlTopPanel == null)
				{
					this.MotorcycleControlTopPanel = new MotorcycleControlTopPanel();
					this.MotorcycleControlTopPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControlTop").Forget();
				}
				if (this.MotorcycleControlHudPanel == null)
				{
					this.MotorcycleControlHudPanel = new MotorcycleControlHudPanel();
					UUIItem battleViewUnit = Singleton<UiLayer>.Instance.GetBattleViewUnit(1);
					this.MotorcycleControlHudPanel.Init(battleViewUnit, "UiItem_MotoParkourHUD_T").Forget();
				}
				if (flag)
				{
					return;
				}
			}
			else if (isDriving)
			{
				if (this.MotorcycleControlPanel == null)
				{
					if (Singleton<Info>.Instance.IsInTouch())
					{
						this.MotorcycleControlPanel = new MotorcycleControlMobilePanel();
						this.MotorcycleControlPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControl").Forget();
					}
					else
					{
						this.MotorcycleControlPanel = new MotorcycleControlPanel();
						this.MotorcycleControlPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControl").Forget();
					}
				}
				if (this.MotorcycleControlTopPanel == null)
				{
					this.MotorcycleControlTopPanel = new MotorcycleControlTopPanel();
					this.MotorcycleControlTopPanel.Init(base.GetRootItem(), "UiItem_MotorcycleControlTop").Forget();
				}
				if (this.MotorcycleControlHudPanel == null)
				{
					this.MotorcycleControlHudPanel = new MotorcycleControlHudPanel();
					UUIItem battleViewUnit2 = Singleton<UiLayer>.Instance.GetBattleViewUnit(1);
					this.MotorcycleControlHudPanel.Init(battleViewUnit2, "UiItem_MotoParkourHUD_T").Forget();
				}
				return;
			}
			if (isDriving)
			{
				if (this.MotorcycleControlPanel != null && !this.MotorcycleControlPanel.IsCreateOrCreating)
				{
					this.MotorcycleControlPanel.ShowBattleVisibleChildView(false);
				}
				if (this.MotorcycleControlTopPanel != null && !this.MotorcycleControlTopPanel.IsCreateOrCreating)
				{
					this.MotorcycleControlTopPanel.ShowBattleVisibleChildView(false);
				}
				if (this.MotorcycleControlHudPanel != null && !this.MotorcycleControlHudPanel.IsCreateOrCreating)
				{
					this.MotorcycleControlHudPanel.ShowBattleVisibleChildView(false);
					return;
				}
			}
			else
			{
				if (this.MotorcycleControlPanel != null)
				{
					if (!isNeedCacheUi)
					{
						this.MotorcycleControlPanel.Destroy(null);
						this.MotorcycleControlPanel = null;
					}
					else
					{
						this.MotorcycleControlPanel.HideBattleVisibleChildView();
					}
				}
				if (this.MotorcycleControlTopPanel != null)
				{
					if (!isNeedCacheUi)
					{
						this.MotorcycleControlTopPanel.Destroy(null);
						this.MotorcycleControlTopPanel = null;
					}
					else
					{
						this.MotorcycleControlTopPanel.HideBattleVisibleChildView();
					}
				}
				if (this.MotorcycleControlHudPanel != null)
				{
					if (!isNeedCacheUi)
					{
						this.MotorcycleControlHudPanel.Destroy(null);
						this.MotorcycleControlHudPanel = null;
						return;
					}
					this.MotorcycleControlHudPanel.HideBattleVisibleChildView();
				}
			}
		}

		// Token: 0x0603D7AA RID: 251818 RVA: 0x00FA58BA File Offset: 0x00FA3ABA
		private void OnSetBattleUiChildCacheState(EBattleUiChildCacheType cacheType, bool needCache)
		{
			if (cacheType == EBattleUiChildCacheType.Motorcycle)
			{
				this.RefreshMotorcycleControl();
			}
		}

		// Token: 0x0603D7AB RID: 251819 RVA: 0x00FA58C8 File Offset: 0x00FA3AC8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams[0] == "MotorMobile")
			{
				UUIItem[] result;
				if ((result = this.GetGuideItemFromPanel(this.MotorcycleControlPanel, configParams)) == null)
				{
					result = (this.GetGuideItemFromPanel(this.MotorcycleControlTopPanel, configParams) ?? this.GetGuideItemFromPanel(ControllerBase<AutoPilotController>.Instance.AutoPilotViewInstance, configParams));
				}
				return result;
			}
			return null;
		}

		// Token: 0x0603D7AC RID: 251820 RVA: 0x00FA591C File Offset: 0x00FA3B1C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] GetGuideItemFromPanel([Nullable(2)] UiPanelBase panel, string[] configParams)
		{
			if (panel == null)
			{
				return null;
			}
			string text = (configParams.Length > 1) ? configParams[1] : null;
			string text2 = (configParams.Length > 2) ? configParams[2] : null;
			UUIItem uuiitem = (!string.IsNullOrEmpty(text)) ? panel.GetGuideUiItem(text) : null;
			UUIItem uuiitem2 = (!string.IsNullOrEmpty(text2)) ? panel.GetGuideUiItem(text2) : null;
			if (uuiitem != null && uuiitem2 != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem2
				};
			}
			if (uuiitem != null)
			{
				return new UUIItem[]
				{
					uuiitem,
					uuiitem
				};
			}
			return null;
		}

		// Token: 0x0603D7AD RID: 251821 RVA: 0x00FA5996 File Offset: 0x00FA3B96
		private void OnSlideControlVisibleChanged(bool visible)
		{
			this.RefreshSlideControlItem();
		}

		// Token: 0x0603D7AE RID: 251822 RVA: 0x00FA59A0 File Offset: 0x00FA3BA0
		private void RefreshSlideControlItem()
		{
			if (ModelBase<BattleUiModel>.Instance.SlideControlData.GetVisible())
			{
				if (this.SlideControlComponent == null)
				{
					this.SlideControlComponent = new BattleSkillSlideControlItem();
					this.SlideControlComponent.CreateByResourceIdAsync("UiItem_AimisiFlyControl", this.RootItem, false).AsTask();
				}
				this.SlideControlComponent.SetComponentActive(true);
				return;
			}
			if (this.SlideControlComponent != null)
			{
				this.SlideControlComponent.SetComponentActive(false);
			}
		}

		// Token: 0x0603D7AF RID: 251823 RVA: 0x00FA5A0F File Offset: 0x00FA3C0F
		private void OnMotorcycleRoundJoystickChanged(bool b)
		{
			this.RefreshJoystickEnable();
		}

		// Token: 0x0603D7B0 RID: 251824 RVA: 0x00FA5A17 File Offset: 0x00FA3C17
		private void OnAutoPilotTrackMarkVisibleChanged(bool visible)
		{
			base.GetItem(0).SetUIActive(visible);
		}

		// Token: 0x0402289F RID: 141471
		[StaticVariableRuleIgnore]
		private static int ForbidMoveTagId = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"];

		// Token: 0x040228A0 RID: 141472
		private TrackedMarksView TrackedMarksView;

		// Token: 0x040228A1 RID: 141473
		private ScanTrackedMarksView ScanTrackedMarksView;

		// Token: 0x040228A2 RID: 141474
		private AlterMarksView AlterMarksView;

		// Token: 0x040228A3 RID: 141475
		private AutoPilotTrackedMarksView AutoPilotTrackedMarksView;

		// Token: 0x040228A4 RID: 141476
		private QuickHackMarksView QuickHackMarksView;

		// Token: 0x040228A5 RID: 141477
		private Joystick Joystick;

		// Token: 0x040228A6 RID: 141478
		private GrapplingHookPoint HookPointMakerPanel;

		// Token: 0x040228A7 RID: 141479
		private ExecutionPanel ExecutionPanel;

		// Token: 0x040228A8 RID: 141480
		private BreakWeaknessPanel BreakWeaknessPanel;

		// Token: 0x040228A9 RID: 141481
		private MotorcycleControlPanelBase MotorcycleControlPanel;

		// Token: 0x040228AA RID: 141482
		private MotorcycleControlTopPanel MotorcycleControlTopPanel;

		// Token: 0x040228AB RID: 141483
		private MotorcycleControlHudPanel MotorcycleControlHudPanel;

		// Token: 0x040228AC RID: 141484
		private BattleSkillSlideControlItem SlideControlComponent;

		// Token: 0x040228AD RID: 141485
		private IBattleUiCenterPanelOtherMovePanel OtherMovePanel;

		// Token: 0x040228AE RID: 141486
		private EntityHandle CurrentEntity;

		// Token: 0x040228AF RID: 141487
		[Nullable(1)]
		private readonly List<Entity> EntityList = new List<Entity>();

		// Token: 0x040228B0 RID: 141488
		private int JoystickType;

		// Token: 0x040228B1 RID: 141489
		private bool ForceHideHookPointMaker;

		// Token: 0x040228B2 RID: 141490
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject1 = Stat.Create("[BattleView]CenterPanelTick1", "", "");

		// Token: 0x040228B3 RID: 141491
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject2 = Stat.Create("[BattleView]CenterPanelTick2", "", "");

		// Token: 0x040228B4 RID: 141492
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject5 = Stat.Create("[BattleView]CenterPanelTick5", "", "");

		// Token: 0x040228B5 RID: 141493
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject6 = Stat.Create("[BattleView]CenterPanelTick6", "", "");

		// Token: 0x040228B6 RID: 141494
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject7 = Stat.Create("[BattleView]CenterPanelTick7", "", "");

		// Token: 0x040228B7 RID: 141495
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject8 = Stat.Create("[BattleView]CenterPanelTick8", "", "");

		// Token: 0x040228B8 RID: 141496
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject9 = Stat.Create("[BattleView]CenterPanelTick9", "", "");

		// Token: 0x0200BF98 RID: 49048
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AF8F RID: 241551
			TrackItem,
			// Token: 0x0403AF90 RID: 241552
			AlterCursorItem,
			// Token: 0x0403AF91 RID: 241553
			PanelMask,
			// Token: 0x0403AF92 RID: 241554
			JoystickItem,
			// Token: 0x0403AF93 RID: 241555
			BreakWeaknessItem
		}

		// Token: 0x0200BF99 RID: 49049
		[NullableContext(0)]
		private enum EJoystickType
		{
			// Token: 0x0403AF95 RID: 241557
			NormalJoyStick,
			// Token: 0x0403AF96 RID: 241558
			UpDownButton,
			// Token: 0x0403AF97 RID: 241559
			None,
			// Token: 0x0403AF98 RID: 241560
			StaticJoystick
		}
	}
}
