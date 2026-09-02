using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.GameMainView.TrapDefense.ChildPanel;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001DAF RID: 7599
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseMainViewProxy : GameMainViewProxy
{
	// Token: 0x17001185 RID: 4485
	// (get) Token: 0x0600E035 RID: 57397 RVA: 0x003C4B78 File Offset: 0x003C2D78
	protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
	{
		get
		{
			return new EBattleUiCommonChildVisibleReason?(EBattleUiCommonChildVisibleReason.TrapDefense);
		}
	}

	// Token: 0x0600E036 RID: 57398 RVA: 0x003C4B80 File Offset: 0x003C2D80
	public TrapDefenseMainViewProxy()
	{
		this.InterfaceLogic = new TrapDefenseInterfaceLogic(this);
		this.TouchUiEditGroup = new ECommonTouchUiEditGroup?(ECommonTouchUiEditGroup.TrapDefenseMain);
	}

	// Token: 0x0600E037 RID: 57399 RVA: 0x003C4BA0 File Offset: 0x003C2DA0
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseMainViewProxy.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E038 RID: 57400 RVA: 0x003C4BE3 File Offset: 0x003C2DE3
	protected override void OnStart()
	{
		this.WarningDistance = (float)ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseWarningDistance();
	}

	// Token: 0x0600E039 RID: 57401 RVA: 0x003C4BF8 File Offset: 0x003C2DF8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseEventStepUpdate, new Action<ETowerDefenseEventProcessStatus>(this.OnStepUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseEventNotifyType, new Action<ETrapDefenseBuildTipsType>(this.OnNotifyType));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.TowerDefenseRecycleRaycastNotify, new Action<int?>(this.OnOrganChange));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseComboNumChange, new Action<int>(this.OnComboNumChange));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseActivityDataUpdate, new Action(this.OnTrapDefenseActivityDataUpdate));
		Singleton<EventSystem>.Instance.Add<int, float>(EEventName.TrapFollowerSkillCd, new Action<int, float>(this.OnTrapFollowerSkillCd));
		Singleton<EventSystem>.Instance.Add(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnSlotUpdate, new Action(this.OnSlotInfoUpdate));
	}

	// Token: 0x0600E03A RID: 57402 RVA: 0x003C4CE8 File Offset: 0x003C2EE8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseEventStepUpdate, new Action<ETowerDefenseEventProcessStatus>(this.OnStepUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseEventNotifyType, new Action<ETrapDefenseBuildTipsType>(this.OnNotifyType));
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseRecycleRaycastNotify, new Action<int?>(this.OnOrganChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseComboNumChange, new Action<int>(this.OnComboNumChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseActivityDataUpdate, new Action(this.OnTrapDefenseActivityDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapFollowerSkillCd, new Action<int, float>(this.OnTrapFollowerSkillCd));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotViewChange, new Action<EUiViewName, bool>(this.OnPlotViewChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnSlotUpdate, new Action(this.OnSlotInfoUpdate));
	}

	// Token: 0x0600E03B RID: 57403 RVA: 0x003C4DD8 File Offset: 0x003C2FD8
	protected override void OnBeforeShow(bool isFirstShow)
	{
		if (isFirstShow)
		{
			ETowerDefenseEventProcessStatus processStatus = ControllerBase<TowerDefenseEventController>.Instance.ProcessStatus;
			this.OnStepUpdate(processStatus);
			TrapDefenseDesktopSkillPanel desktopSkillPanel = this.DesktopSkillPanel;
			if (desktopSkillPanel != null)
			{
				desktopSkillPanel.RefreshButtonByIsInBuild(false);
			}
			ETrapDefenseBuildTipsType buildTipsType = ControllerBase<TowerDefenseEventController>.Instance.BuildTipsType;
			TrapDefenseMobileSkillPanel mobileSkillPanel = this.MobileSkillPanel;
			if (mobileSkillPanel == null)
			{
				return;
			}
			mobileSkillPanel.RefreshButtonByTipsType(buildTipsType);
		}
	}

	// Token: 0x0600E03C RID: 57404 RVA: 0x003C4E28 File Offset: 0x003C3028
	protected override void OnTick(float delta)
	{
		FKSC_MiniMapContext[] entityPositions = ControllerBase<KuroSimpleCombatController>.Instance.GetEntityPositions();
		this.UpdateHpPanelWarning(entityPositions);
	}

	// Token: 0x0600E03D RID: 57405 RVA: 0x003C4E48 File Offset: 0x003C3048
	private void UpdateHpPanelWarning([Nullable(new byte[]
	{
		2,
		1
	})] FKSC_MiniMapContext[] positions)
	{
		bool warningItemActive = false;
		if (positions != null && positions.Length != 0)
		{
			for (int i = 0; i < positions.Length; i++)
			{
				if (positions[i].Distance <= this.WarningDistance)
				{
					warningItemActive = true;
					break;
				}
			}
		}
		this.CampsiteHpPanel.SetWarningItemActive(warningItemActive);
	}

	// Token: 0x0600E03E RID: 57406 RVA: 0x003C4E90 File Offset: 0x003C3090
	protected override void OnRouletteViewVisibleChangedInner(bool visible)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			if (!visible)
			{
				this.BuildTipsPanel.ShowBattleChildViewPanel();
				this.MissionPanel.ShowBattleChildViewPanel();
			}
			else
			{
				this.BuildTipsPanel.HideBattleChildViewPanel();
				this.MissionPanel.HideBattleChildViewPanel();
			}
			this.MachineTipsPanel.RefreshMachineStateByRoulette(visible);
		}
	}

	// Token: 0x0600E03F RID: 57407 RVA: 0x003C4EE8 File Offset: 0x003C30E8
	private UniTask CreateMiniMap()
	{
		TrapDefenseMainViewProxy.<CreateMiniMap>d__24 <CreateMiniMap>d__;
		<CreateMiniMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMiniMap>d__.<>4__this = this;
		<CreateMiniMap>d__.<>1__state = -1;
		<CreateMiniMap>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMiniMap>d__24>(ref <CreateMiniMap>d__);
		return <CreateMiniMap>d__.<>t__builder.Task;
	}

	// Token: 0x0600E040 RID: 57408 RVA: 0x003C4F2C File Offset: 0x003C312C
	private UniTask CreateMissionPanel()
	{
		TrapDefenseMainViewProxy.<CreateMissionPanel>d__25 <CreateMissionPanel>d__;
		<CreateMissionPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMissionPanel>d__.<>4__this = this;
		<CreateMissionPanel>d__.<>1__state = -1;
		<CreateMissionPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMissionPanel>d__25>(ref <CreateMissionPanel>d__);
		return <CreateMissionPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E041 RID: 57409 RVA: 0x003C4F70 File Offset: 0x003C3170
	private UniTask CreateMachineSelectPanel()
	{
		TrapDefenseMainViewProxy.<CreateMachineSelectPanel>d__26 <CreateMachineSelectPanel>d__;
		<CreateMachineSelectPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMachineSelectPanel>d__.<>4__this = this;
		<CreateMachineSelectPanel>d__.<>1__state = -1;
		<CreateMachineSelectPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMachineSelectPanel>d__26>(ref <CreateMachineSelectPanel>d__);
		return <CreateMachineSelectPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E042 RID: 57410 RVA: 0x003C4FB4 File Offset: 0x003C31B4
	private UniTask CreatePreparationPanel()
	{
		TrapDefenseMainViewProxy.<CreatePreparationPanel>d__27 <CreatePreparationPanel>d__;
		<CreatePreparationPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePreparationPanel>d__.<>4__this = this;
		<CreatePreparationPanel>d__.<>1__state = -1;
		<CreatePreparationPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreatePreparationPanel>d__27>(ref <CreatePreparationPanel>d__);
		return <CreatePreparationPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E043 RID: 57411 RVA: 0x003C4FF8 File Offset: 0x003C31F8
	private UniTask CreateFunctionalPanel()
	{
		TrapDefenseMainViewProxy.<CreateFunctionalPanel>d__28 <CreateFunctionalPanel>d__;
		<CreateFunctionalPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateFunctionalPanel>d__.<>4__this = this;
		<CreateFunctionalPanel>d__.<>1__state = -1;
		<CreateFunctionalPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateFunctionalPanel>d__28>(ref <CreateFunctionalPanel>d__);
		return <CreateFunctionalPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E044 RID: 57412 RVA: 0x003C503C File Offset: 0x003C323C
	private UniTask CreateCampsiteHpPanel()
	{
		TrapDefenseMainViewProxy.<CreateCampsiteHpPanel>d__29 <CreateCampsiteHpPanel>d__;
		<CreateCampsiteHpPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCampsiteHpPanel>d__.<>4__this = this;
		<CreateCampsiteHpPanel>d__.<>1__state = -1;
		<CreateCampsiteHpPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateCampsiteHpPanel>d__29>(ref <CreateCampsiteHpPanel>d__);
		return <CreateCampsiteHpPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E045 RID: 57413 RVA: 0x003C5080 File Offset: 0x003C3280
	private UniTask CreateBuildTipsPanel()
	{
		TrapDefenseMainViewProxy.<CreateBuildTipsPanel>d__30 <CreateBuildTipsPanel>d__;
		<CreateBuildTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBuildTipsPanel>d__.<>4__this = this;
		<CreateBuildTipsPanel>d__.<>1__state = -1;
		<CreateBuildTipsPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateBuildTipsPanel>d__30>(ref <CreateBuildTipsPanel>d__);
		return <CreateBuildTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E046 RID: 57414 RVA: 0x003C50C4 File Offset: 0x003C32C4
	private UniTask CreateComboPanel()
	{
		TrapDefenseMainViewProxy.<CreateComboPanel>d__31 <CreateComboPanel>d__;
		<CreateComboPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateComboPanel>d__.<>4__this = this;
		<CreateComboPanel>d__.<>1__state = -1;
		<CreateComboPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateComboPanel>d__31>(ref <CreateComboPanel>d__);
		return <CreateComboPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E047 RID: 57415 RVA: 0x003C5108 File Offset: 0x003C3308
	private UniTask CreateMobileSkillPanel()
	{
		TrapDefenseMainViewProxy.<CreateMobileSkillPanel>d__32 <CreateMobileSkillPanel>d__;
		<CreateMobileSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanel>d__.<>4__this = this;
		<CreateMobileSkillPanel>d__.<>1__state = -1;
		<CreateMobileSkillPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMobileSkillPanel>d__32>(ref <CreateMobileSkillPanel>d__);
		return <CreateMobileSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E048 RID: 57416 RVA: 0x003C514C File Offset: 0x003C334C
	private UniTask CreateDesktopSkillPanel()
	{
		TrapDefenseMainViewProxy.<CreateDesktopSkillPanel>d__33 <CreateDesktopSkillPanel>d__;
		<CreateDesktopSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanel>d__.<>4__this = this;
		<CreateDesktopSkillPanel>d__.<>1__state = -1;
		<CreateDesktopSkillPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateDesktopSkillPanel>d__33>(ref <CreateDesktopSkillPanel>d__);
		return <CreateDesktopSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E049 RID: 57417 RVA: 0x003C5190 File Offset: 0x003C3390
	private UniTask CreateMobileSkillPanelInner()
	{
		TrapDefenseMainViewProxy.<CreateMobileSkillPanelInner>d__34 <CreateMobileSkillPanelInner>d__;
		<CreateMobileSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanelInner>d__.<>4__this = this;
		<CreateMobileSkillPanelInner>d__.<>1__state = -1;
		<CreateMobileSkillPanelInner>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMobileSkillPanelInner>d__34>(ref <CreateMobileSkillPanelInner>d__);
		return <CreateMobileSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600E04A RID: 57418 RVA: 0x003C51D4 File Offset: 0x003C33D4
	private UniTask CreateDesktopSkillPanelInner()
	{
		TrapDefenseMainViewProxy.<CreateDesktopSkillPanelInner>d__35 <CreateDesktopSkillPanelInner>d__;
		<CreateDesktopSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanelInner>d__.<>4__this = this;
		<CreateDesktopSkillPanelInner>d__.<>1__state = -1;
		<CreateDesktopSkillPanelInner>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateDesktopSkillPanelInner>d__35>(ref <CreateDesktopSkillPanelInner>d__);
		return <CreateDesktopSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600E04B RID: 57419 RVA: 0x003C5218 File Offset: 0x003C3418
	private UniTask CreateMachineTipsPanel()
	{
		TrapDefenseMainViewProxy.<CreateMachineTipsPanel>d__36 <CreateMachineTipsPanel>d__;
		<CreateMachineTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMachineTipsPanel>d__.<>4__this = this;
		<CreateMachineTipsPanel>d__.<>1__state = -1;
		<CreateMachineTipsPanel>d__.<>t__builder.Start<TrapDefenseMainViewProxy.<CreateMachineTipsPanel>d__36>(ref <CreateMachineTipsPanel>d__);
		return <CreateMachineTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600E04C RID: 57420 RVA: 0x003C525B File Offset: 0x003C345B
	private void ShowShopOpenTips()
	{
		if (ModelBase<TrapDefenseModel>.Instance.BattleData.IsShopOpen)
		{
			ControllerBase<TrapDefenseController>.Instance.OpenTrapDefenseShopOpenTips(delegate
			{
				this.PreparationPanel.ShowBattleChildViewPanel();
			});
			return;
		}
		this.PreparationPanel.ShowBattleChildViewPanel();
	}

	// Token: 0x0600E04D RID: 57421 RVA: 0x003C5290 File Offset: 0x003C3490
	private void ShowMonsterEnhancedTips()
	{
		TrapDefenseWave? currentBatchData = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData();
		if (currentBatchData != null && !StringUtils.IsBlank(currentBatchData.Value.ReadStageEnhanceTips))
		{
			this.FunctionalPanel.SetTips(currentBatchData.Value.ReadStageEnhanceTips);
		}
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		object obj = (instance != null) ? instance.GetCurInstToLevelData() : null;
		int batch = ModelBase<TrapDefenseModel>.Instance.BattleData.GetBatch();
		object obj2 = obj;
		if (obj2 != null && obj2.IsBossWave(batch))
		{
			ControllerBase<TrapDefenseController>.Instance.OpenTrapDefenseBossComingTips(null);
		}
	}

	// Token: 0x0600E04E RID: 57422 RVA: 0x003C5320 File Offset: 0x003C3520
	private void HideMonsterEnhancedTips()
	{
		TrapDefenseWave? currentBatchData = ModelBase<TrapDefenseModel>.Instance.GetCurrentBatchData();
		if (currentBatchData != null && !StringUtils.IsBlank(currentBatchData.Value.ReadStageEnhanceTips))
		{
			this.FunctionalPanel.HideTips();
		}
	}

	// Token: 0x0600E04F RID: 57423 RVA: 0x003C5364 File Offset: 0x003C3564
	private void OnStepUpdate(ETowerDefenseEventProcessStatus status)
	{
		if (status == ETowerDefenseEventProcessStatus.Ready)
		{
			this.ShowShopOpenTips();
			this.ShowMonsterEnhancedTips();
		}
		else if (status == ETowerDefenseEventProcessStatus.Fighting)
		{
			this.PreparationPanel.HideBattleChildViewPanel();
			this.HideMonsterEnhancedTips();
			ControllerBase<TrapDefenseController>.Instance.StartChallengeRoundTips();
		}
		if (status != ETowerDefenseEventProcessStatus.Fighting)
		{
			this.ComboPanel.HideComboPanel();
		}
		this.MiniMap.OnTowerDefenseStepUpdate(status);
		this.MachineSelectPanel.OnTowerDefenseStepUpdate(status);
	}

	// Token: 0x0600E050 RID: 57424 RVA: 0x003C53CA File Offset: 0x003C35CA
	private void OnNotifyType(ETrapDefenseBuildTipsType type)
	{
		this.BuildTipsPanel.SetTipsType(type);
		TrapDefenseMobileSkillPanel mobileSkillPanel = this.MobileSkillPanel;
		if (mobileSkillPanel == null)
		{
			return;
		}
		mobileSkillPanel.RefreshButtonByTipsType(type);
	}

	// Token: 0x0600E051 RID: 57425 RVA: 0x003C53E9 File Offset: 0x003C35E9
	private void OnOrganChange(int? recyclePrice)
	{
		if (recyclePrice != null)
		{
			this.BuildTipsPanel.SetRecyclePrice(recyclePrice.Value);
			TrapDefenseMobileSkillPanel mobileSkillPanel = this.MobileSkillPanel;
			if (mobileSkillPanel == null)
			{
				return;
			}
			mobileSkillPanel.SetRecyclePrice(recyclePrice.Value);
		}
	}

	// Token: 0x0600E052 RID: 57426 RVA: 0x003C541D File Offset: 0x003C361D
	private void OnComboNumChange(int num)
	{
		this.ComboPanel.RefreshComboNum(num);
	}

	// Token: 0x0600E053 RID: 57427 RVA: 0x003C542B File Offset: 0x003C362B
	private void OnTrapDefenseActivityDataUpdate()
	{
		this.FunctionalPanel.UpdateBdSumState();
	}

	// Token: 0x0600E054 RID: 57428 RVA: 0x003C5438 File Offset: 0x003C3638
	private void OnTrapFollowerSkillCd(int proxyId, float _)
	{
		TrapDefenseMachineSelectPanel machineSelectPanel = this.MachineSelectPanel;
		if (machineSelectPanel != null)
		{
			machineSelectPanel.RefreshMachineCdState(proxyId);
		}
		TrapDefenseMobileSkillPanel mobileSkillPanel = this.MobileSkillPanel;
		if (mobileSkillPanel == null)
		{
			return;
		}
		mobileSkillPanel.RefreshMachineCdState();
	}

	// Token: 0x0600E055 RID: 57429 RVA: 0x003C545C File Offset: 0x003C365C
	private void OnPlotViewChange(EUiViewName viewName, bool isShow)
	{
		if (viewName == EUiViewName.PlotViewHUD)
		{
			this.MachineSelectPanel.SetMachineSelectCollapse(isShow);
		}
	}

	// Token: 0x0600E056 RID: 57430 RVA: 0x003C5477 File Offset: 0x003C3677
	private void OnSlotInfoUpdate()
	{
		this.MachineSelectPanel.RefreshSlotState();
	}

	// Token: 0x0600E057 RID: 57431 RVA: 0x003C5484 File Offset: 0x003C3684
	public void RefreshSelectPanel()
	{
		this.MachineSelectPanel.RefreshMachineState();
	}

	// Token: 0x04006B9C RID: 27548
	private readonly TrapDefenseInterfaceLogic InterfaceLogic;

	// Token: 0x04006B9D RID: 27549
	public TrapDefenseMiniMapPanel MiniMap;

	// Token: 0x04006B9E RID: 27550
	public TrapDefenseMissionPanel MissionPanel;

	// Token: 0x04006B9F RID: 27551
	public TrapDefenseMachineSelectPanel MachineSelectPanel;

	// Token: 0x04006BA0 RID: 27552
	public TrapDefensePreparationPanel PreparationPanel;

	// Token: 0x04006BA1 RID: 27553
	public TrapDefenseFunctionalPanel FunctionalPanel;

	// Token: 0x04006BA2 RID: 27554
	public TrapDefenseCampsiteHpPanel CampsiteHpPanel;

	// Token: 0x04006BA3 RID: 27555
	public TrapDefenseBuildTipsPanel BuildTipsPanel;

	// Token: 0x04006BA4 RID: 27556
	public TrapDefenseComboPanel ComboPanel;

	// Token: 0x04006BA5 RID: 27557
	[Nullable(2)]
	public TrapDefenseMobileSkillPanel MobileSkillPanel;

	// Token: 0x04006BA6 RID: 27558
	[Nullable(2)]
	public TrapDefenseDesktopSkillPanel DesktopSkillPanel;

	// Token: 0x04006BA7 RID: 27559
	public TrapDefenseMachineTipsPanel MachineTipsPanel;

	// Token: 0x04006BA8 RID: 27560
	private float WarningDistance;
}
