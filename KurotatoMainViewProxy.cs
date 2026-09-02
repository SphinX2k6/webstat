using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D29 RID: 7465
[NullableContext(1)]
[Nullable(0)]
public class KurotatoMainViewProxy : GameMainViewProxy
{
	// Token: 0x17001167 RID: 4455
	// (get) Token: 0x0600DBAD RID: 56237 RVA: 0x003B04FA File Offset: 0x003AE6FA
	protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
	{
		get
		{
			return new EBattleUiCommonChildVisibleReason?(EBattleUiCommonChildVisibleReason.Kurotato);
		}
	}

	// Token: 0x0600DBAE RID: 56238 RVA: 0x003B0504 File Offset: 0x003AE704
	protected override UniTask OnBeforeStartAsync()
	{
		KurotatoMainViewProxy.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoMainViewProxy.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBAF RID: 56239 RVA: 0x003B0548 File Offset: 0x003AE748
	protected override void OnBeforeDestroy()
	{
		this.ClearStepAdvanceTimer();
		this.KurotatoCleanAllBossTrackedMarker();
		this.KurotatoCleanAllTreasureBoxTrackedMarker();
		foreach (UiPanelBase uiPanelBase in this.KurotatoChildPanelMap.Values)
		{
			uiPanelBase.Destroy(null);
		}
		this.KurotatoChildPanelMap.Clear();
	}

	// Token: 0x0600DBB0 RID: 56240 RVA: 0x003B05BC File Offset: 0x003AE7BC
	protected override void OnStart()
	{
		this.AttrChangePanel.SetUiActive(false);
	}

	// Token: 0x0600DBB1 RID: 56241 RVA: 0x003B05CC File Offset: 0x003AE7CC
	protected override void OnAfterShow()
	{
		foreach (UiPanelBase uiPanelBase in this.KurotatoChildPanelMap.Values)
		{
			uiPanelBase.Show(null);
		}
		foreach (KurotatoBossTrackedMarker kurotatoBossTrackedMarker in this.KurotatoBossTrackedMarkerMap.Values)
		{
			kurotatoBossTrackedMarker.Show(null);
		}
		foreach (KurotatoTreasureBoxTrackedMarker kurotatoTreasureBoxTrackedMarker in this.KurotatoTreasureBoxTrackedMarkerMap.Values)
		{
			kurotatoTreasureBoxTrackedMarker.Show(null);
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.Kurotato);
		if (this.CurStep != ModelBase<KurotatoModel>.Instance.GetStep())
		{
			this.UpdateTipsByState(ModelBase<KurotatoModel>.Instance.GetStep());
		}
	}

	// Token: 0x0600DBB2 RID: 56242 RVA: 0x003B06E0 File Offset: 0x003AE8E0
	protected override void OnAfterHide()
	{
		foreach (UiPanelBase uiPanelBase in this.KurotatoChildPanelMap.Values)
		{
			uiPanelBase.Hide(null);
		}
		foreach (KurotatoBossTrackedMarker kurotatoBossTrackedMarker in this.KurotatoBossTrackedMarkerMap.Values)
		{
			kurotatoBossTrackedMarker.Hide(null);
		}
		foreach (KurotatoTreasureBoxTrackedMarker kurotatoTreasureBoxTrackedMarker in this.KurotatoTreasureBoxTrackedMarkerMap.Values)
		{
			kurotatoTreasureBoxTrackedMarker.Hide(null);
		}
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.Kurotato);
	}

	// Token: 0x0600DBB3 RID: 56243 RVA: 0x003B07D0 File Offset: 0x003AE9D0
	protected override void OnTick(float delta)
	{
		if (this.CurStep == EKurotatoStep.Combat)
		{
			this.CountDownTips.OnTick(delta);
		}
		this.ResidentWaveTips.OnTick(delta);
		this.PlayerTrackedMarker.OnTick(delta);
		this.MainPanel.OnTick(delta);
		foreach (KeyValuePair<int, KurotatoBossTrackedMarker> keyValuePair in this.KurotatoBossTrackedMarkerMap)
		{
			keyValuePair.Value.OnTick(delta);
		}
		foreach (KeyValuePair<int, KurotatoTreasureBoxTrackedMarker> keyValuePair2 in this.KurotatoTreasureBoxTrackedMarkerMap)
		{
			keyValuePair2.Value.OnTick(delta);
		}
		this.AttrChangePanel.OnTick(delta);
	}

	// Token: 0x0600DBB4 RID: 56244 RVA: 0x003B08B8 File Offset: 0x003AEAB8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EKurotatoStep>(EEventName.KurotatoOnStepChanged, new Action<EKurotatoStep>(this.OnStepChanged));
		Singleton<EventSystem>.Instance.Add<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnPropertyUpdate));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.KurotatoBossTrackedMarkerUpdate, new Action<int, bool>(this.OnKurotatoBossTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.KurotatoTreasureBoxTrackedMarkerUpdate, new Action<int, bool>(this.OnKurotatoTreasureBoxTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnPlayerDie, new Action(this.OnPlayerDie));
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<KurotatoModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnCurrencyUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.SpareGold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSpareGoldUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.TreasureBoxCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnChestUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.UpgradeCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnUpgradeCountUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.TotalRoleExp.ToEnumString(), new TTreeVarUpdateDelegate(this.OnExpUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.ConsecutiveKillCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnComboUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(EKurotatoSystemVarType.RoleLevel.ToEnumString(), new TTreeVarUpdateDelegate(this.OnRoleLevelUpdate));
	}

	// Token: 0x0600DBB5 RID: 56245 RVA: 0x003B0A0C File Offset: 0x003AEC0C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<EKurotatoStep>(EEventName.KurotatoOnStepChanged, new Action<EKurotatoStep>(this.OnStepChanged));
		Singleton<EventSystem>.Instance.Remove<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnPropertyUpdate));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.KurotatoBossTrackedMarkerUpdate, new Action<int, bool>(this.OnKurotatoBossTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.KurotatoTreasureBoxTrackedMarkerUpdate, new Action<int, bool>(this.OnKurotatoTreasureBoxTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnPlayerDie, new Action(this.OnPlayerDie));
	}

	// Token: 0x0600DBB6 RID: 56246 RVA: 0x003B0AA8 File Offset: 0x003AECA8
	private void AddScreenEffectFightRoot()
	{
		BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
		if (instance == null || !instance.IsValid())
		{
			return;
		}
		AUIContainerActor screenEffectFightRoot = null;
		instance.GetScreenEffectFightRoot(ref screenEffectFightRoot);
		this.ScreenEffectFightRoot = screenEffectFightRoot;
		AUIContainerActor screenEffectFightRoot2 = this.ScreenEffectFightRoot;
		if (screenEffectFightRoot2 != null)
		{
			screenEffectFightRoot2.K2_AttachRootComponentTo(this.View.GetContentPanel(), default(FName), EAttachLocation.KeepRelativeOffset, true);
		}
		ModelBase<ScreenEffectModel>.Instance.SetFightRootInited(true);
	}

	// Token: 0x0600DBB7 RID: 56247 RVA: 0x003B0B10 File Offset: 0x003AED10
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected UniTask<T> CreateKurotatoChildPanel<[Nullable(0)] T>(string resourceId, UUIItem parentItem, bool bShow = true) where T : UiPanelBase, new()
	{
		KurotatoMainViewProxy.<CreateKurotatoChildPanel>d__26<T> <CreateKurotatoChildPanel>d__;
		<CreateKurotatoChildPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<CreateKurotatoChildPanel>d__.<>4__this = this;
		<CreateKurotatoChildPanel>d__.resourceId = resourceId;
		<CreateKurotatoChildPanel>d__.parentItem = parentItem;
		<CreateKurotatoChildPanel>d__.bShow = bShow;
		<CreateKurotatoChildPanel>d__.<>1__state = -1;
		<CreateKurotatoChildPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateKurotatoChildPanel>d__26<T>>(ref <CreateKurotatoChildPanel>d__);
		return <CreateKurotatoChildPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBB8 RID: 56248 RVA: 0x003B0B6C File Offset: 0x003AED6C
	private UniTask CreateResidentWaveTipsPanel()
	{
		KurotatoMainViewProxy.<CreateResidentWaveTipsPanel>d__27 <CreateResidentWaveTipsPanel>d__;
		<CreateResidentWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateResidentWaveTipsPanel>d__.<>4__this = this;
		<CreateResidentWaveTipsPanel>d__.<>1__state = -1;
		<CreateResidentWaveTipsPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateResidentWaveTipsPanel>d__27>(ref <CreateResidentWaveTipsPanel>d__);
		return <CreateResidentWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBB9 RID: 56249 RVA: 0x003B0BB0 File Offset: 0x003AEDB0
	private UniTask CreateCountDownTipsPanel()
	{
		KurotatoMainViewProxy.<CreateCountDownTipsPanel>d__28 <CreateCountDownTipsPanel>d__;
		<CreateCountDownTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCountDownTipsPanel>d__.<>4__this = this;
		<CreateCountDownTipsPanel>d__.<>1__state = -1;
		<CreateCountDownTipsPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateCountDownTipsPanel>d__28>(ref <CreateCountDownTipsPanel>d__);
		return <CreateCountDownTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBA RID: 56250 RVA: 0x003B0BF4 File Offset: 0x003AEDF4
	private UniTask CreatePlayerTrackedMarkerPanel()
	{
		KurotatoMainViewProxy.<CreatePlayerTrackedMarkerPanel>d__29 <CreatePlayerTrackedMarkerPanel>d__;
		<CreatePlayerTrackedMarkerPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePlayerTrackedMarkerPanel>d__.<>4__this = this;
		<CreatePlayerTrackedMarkerPanel>d__.<>1__state = -1;
		<CreatePlayerTrackedMarkerPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreatePlayerTrackedMarkerPanel>d__29>(ref <CreatePlayerTrackedMarkerPanel>d__);
		return <CreatePlayerTrackedMarkerPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBB RID: 56251 RVA: 0x003B0C38 File Offset: 0x003AEE38
	private UniTask CreateMainPanel()
	{
		KurotatoMainViewProxy.<CreateMainPanel>d__30 <CreateMainPanel>d__;
		<CreateMainPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMainPanel>d__.<>4__this = this;
		<CreateMainPanel>d__.<>1__state = -1;
		<CreateMainPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateMainPanel>d__30>(ref <CreateMainPanel>d__);
		return <CreateMainPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBC RID: 56252 RVA: 0x003B0C7C File Offset: 0x003AEE7C
	private UniTask CreateAttrChangePanel()
	{
		KurotatoMainViewProxy.<CreateAttrChangePanel>d__31 <CreateAttrChangePanel>d__;
		<CreateAttrChangePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateAttrChangePanel>d__.<>4__this = this;
		<CreateAttrChangePanel>d__.<>1__state = -1;
		<CreateAttrChangePanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateAttrChangePanel>d__31>(ref <CreateAttrChangePanel>d__);
		return <CreateAttrChangePanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBD RID: 56253 RVA: 0x003B0CC0 File Offset: 0x003AEEC0
	private UniTask CreateWaveTipsPanel()
	{
		KurotatoMainViewProxy.<CreateWaveTipsPanel>d__32 <CreateWaveTipsPanel>d__;
		<CreateWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateWaveTipsPanel>d__.<>4__this = this;
		<CreateWaveTipsPanel>d__.<>1__state = -1;
		<CreateWaveTipsPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateWaveTipsPanel>d__32>(ref <CreateWaveTipsPanel>d__);
		return <CreateWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBE RID: 56254 RVA: 0x003B0D04 File Offset: 0x003AEF04
	private UniTask CreateBossSpawnTipsPanel()
	{
		KurotatoMainViewProxy.<CreateBossSpawnTipsPanel>d__33 <CreateBossSpawnTipsPanel>d__;
		<CreateBossSpawnTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBossSpawnTipsPanel>d__.<>4__this = this;
		<CreateBossSpawnTipsPanel>d__.<>1__state = -1;
		<CreateBossSpawnTipsPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateBossSpawnTipsPanel>d__33>(ref <CreateBossSpawnTipsPanel>d__);
		return <CreateBossSpawnTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBBF RID: 56255 RVA: 0x003B0D48 File Offset: 0x003AEF48
	private UniTask CreateEliteWaveTipsPanel()
	{
		KurotatoMainViewProxy.<CreateEliteWaveTipsPanel>d__34 <CreateEliteWaveTipsPanel>d__;
		<CreateEliteWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateEliteWaveTipsPanel>d__.<>4__this = this;
		<CreateEliteWaveTipsPanel>d__.<>1__state = -1;
		<CreateEliteWaveTipsPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateEliteWaveTipsPanel>d__34>(ref <CreateEliteWaveTipsPanel>d__);
		return <CreateEliteWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBC0 RID: 56256 RVA: 0x003B0D8C File Offset: 0x003AEF8C
	public void UpdateTipsByState(EKurotatoStep state)
	{
		this.CurStep = state;
		KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
		switch (state)
		{
		case EKurotatoStep.Combat:
			if (instance.GetIsStepStart())
			{
				this.CountDownTips.InitCountDown((float)instance.GetWaveDuration());
				this.ResidentWaveTips.ShowTips();
				this.CountDownTips.ShowTips();
				this.MainPanel.RefreshExp();
				if (instance.GetIsCurWaveBoss())
				{
					this.BossSpawnTipsPanel.PlayBossSpawn();
					return;
				}
				if (instance.GetIsCurWaveElite())
				{
					this.EliteWaveTipsPanel.PlayEliteWave();
					return;
				}
			}
			break;
		case EKurotatoStep.ChestReward:
		case EKurotatoStep.Shop:
		case EKurotatoStep.WaveUpdate:
		case EKurotatoStep.UpgradeReward:
		case EKurotatoStep.Prepare:
			break;
		case EKurotatoStep.End:
			if (instance.GetIsStepStart())
			{
				this.CountDownTips.HideTips();
				this.WaveTipsPanel.PlaySuccess("Kurotato_LevelSucceed");
				this.StartStepAdvanceWatch();
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0600DBC1 RID: 56257 RVA: 0x003B0E58 File Offset: 0x003AF058
	private void OnStepChanged(EKurotatoStep step)
	{
		this.UpdateTipsByState(step);
	}

	// Token: 0x0600DBC2 RID: 56258 RVA: 0x003B0E61 File Offset: 0x003AF061
	private void OnPropertyUpdate(IDictionary<int, int> propertyValues)
	{
		this.AttrChangePanel.ShowAttrChange(propertyValues);
	}

	// Token: 0x0600DBC3 RID: 56259 RVA: 0x003B0E70 File Offset: 0x003AF070
	private void OnCurrencyUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		int increment = (lastVarDefine != null) ? (num - (int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int)) : 0;
		this.MainPanel.RefreshCurrencyNum(num, increment);
	}

	// Token: 0x0600DBC4 RID: 56260 RVA: 0x003B0EB8 File Offset: 0x003AF0B8
	private void OnSpareGoldUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		int increment = (lastVarDefine != null) ? (num - (int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int)) : 0;
		this.MainPanel.RefreshSpareGold(num, increment);
	}

	// Token: 0x0600DBC5 RID: 56261 RVA: 0x003B0F00 File Offset: 0x003AF100
	private void OnChestUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		bool bPlayAcquireAnim = lastVarDefine != null && num > (int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int);
		this.MainPanel.RefreshChestCount(num, bPlayAcquireAnim);
	}

	// Token: 0x0600DBC6 RID: 56262 RVA: 0x003B0F48 File Offset: 0x003AF148
	private void OnUpgradeCountUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		bool bPlayAcquireAnim = lastVarDefine != null && num > (int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int);
		this.MainPanel.RefreshLevelUpCount(num, bPlayAcquireAnim);
	}

	// Token: 0x0600DBC7 RID: 56263 RVA: 0x003B0F8F File Offset: 0x003AF18F
	private void OnExpUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		this.MainPanel.RefreshExp();
	}

	// Token: 0x0600DBC8 RID: 56264 RVA: 0x003B0F9C File Offset: 0x003AF19C
	private void OnComboUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int comboNum = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.MainPanel.RefreshComboNum(comboNum);
	}

	// Token: 0x0600DBC9 RID: 56265 RVA: 0x003B0FC8 File Offset: 0x003AF1C8
	private void OnRoleLevelUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int num = (lastVarDefine != null) ? ((int)Singleton<MathUtils>.Instance.LongToNumber(lastVarDefine.Int)) : 0;
		int num2 = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		if (num <= 0 || num2 <= num)
		{
			return;
		}
		this.AttrChangePanel.ShowLevelUp();
		this.MainPanel.PlayLvUpAnim();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "KurotatoRoleLevelUp");
	}

	// Token: 0x0600DBCA RID: 56266 RVA: 0x003B1038 File Offset: 0x003AF238
	private void OnPlayerDie()
	{
		this.WaveTipsPanel.PlayFail("Kurotato_LevelFail");
		foreach (KurotatoBossTrackedMarker kurotatoBossTrackedMarker in this.KurotatoBossTrackedMarkerMap.Values)
		{
			kurotatoBossTrackedMarker.DelayRecycle();
		}
		this.KurotatoBossTrackedMarkerMap.Clear();
		foreach (KurotatoTreasureBoxTrackedMarker kurotatoTreasureBoxTrackedMarker in this.KurotatoTreasureBoxTrackedMarkerMap.Values)
		{
			kurotatoTreasureBoxTrackedMarker.DelayRecycle();
		}
		this.KurotatoTreasureBoxTrackedMarkerMap.Clear();
	}

	// Token: 0x0600DBCB RID: 56267 RVA: 0x003B10F8 File Offset: 0x003AF2F8
	private void StartStepAdvanceWatch()
	{
		this.ClearStepAdvanceTimer();
		this.StepAdvanceTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.TriggerStepAdvance();
		}, 3000f, null, null, true, 1f);
	}

	// Token: 0x0600DBCC RID: 56268 RVA: 0x003B1129 File Offset: 0x003AF329
	private void OnWaveTipsFinish()
	{
		this.TriggerStepAdvance();
	}

	// Token: 0x0600DBCD RID: 56269 RVA: 0x003B1134 File Offset: 0x003AF334
	private void TriggerStepAdvance()
	{
		TimerHandle stepAdvanceTimer = this.StepAdvanceTimer;
		if (stepAdvanceTimer != null && stepAdvanceTimer.Valid())
		{
			this.StepAdvanceTimer.Remove();
		}
		this.StepAdvanceTimer = null;
		if (ModelBase<KurotatoModel>.Instance.GetStep() != EKurotatoStep.End)
		{
			return;
		}
		ControllerBase<KurotatoController>.Instance.RequestKurotatoStepAdvance().Forget<bool>();
	}

	// Token: 0x0600DBCE RID: 56270 RVA: 0x003B1185 File Offset: 0x003AF385
	private void ClearStepAdvanceTimer()
	{
		if (this.StepAdvanceTimer != null)
		{
			this.StepAdvanceTimer.Remove();
			this.StepAdvanceTimer = null;
		}
	}

	// Token: 0x0600DBCF RID: 56271 RVA: 0x003B11A4 File Offset: 0x003AF3A4
	private UniTask CreateKurotatoBossTrackedMarkerPanel(int entityId)
	{
		KurotatoMainViewProxy.<CreateKurotatoBossTrackedMarkerPanel>d__50 <CreateKurotatoBossTrackedMarkerPanel>d__;
		<CreateKurotatoBossTrackedMarkerPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateKurotatoBossTrackedMarkerPanel>d__.<>4__this = this;
		<CreateKurotatoBossTrackedMarkerPanel>d__.entityId = entityId;
		<CreateKurotatoBossTrackedMarkerPanel>d__.<>1__state = -1;
		<CreateKurotatoBossTrackedMarkerPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateKurotatoBossTrackedMarkerPanel>d__50>(ref <CreateKurotatoBossTrackedMarkerPanel>d__);
		return <CreateKurotatoBossTrackedMarkerPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBD0 RID: 56272 RVA: 0x003B11F0 File Offset: 0x003AF3F0
	public void OnKurotatoBossTrackedMarkerUpdate(int entityId, bool isAdd)
	{
		if (isAdd)
		{
			this.CreateKurotatoBossTrackedMarkerPanel(entityId).Forget();
			return;
		}
		KurotatoBossTrackedMarker kurotatoBossTrackedMarker;
		if (this.KurotatoBossTrackedMarkerMap.TryGetValue(entityId, out kurotatoBossTrackedMarker))
		{
			this.KurotatoBossTrackedMarkerMap.Remove(entityId);
			kurotatoBossTrackedMarker.DelayRecycle();
		}
	}

	// Token: 0x0600DBD1 RID: 56273 RVA: 0x003B1230 File Offset: 0x003AF430
	private void KurotatoCleanAllBossTrackedMarker()
	{
		if (this.KurotatoBossTrackedMarkerMap.Count == 0)
		{
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.Kurotato, ELogAuthor.LYX, "结束战斗阶段时有BOSS追踪图标残留, 强制清除", default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (KurotatoBossTrackedMarker kurotatoBossTrackedMarker in this.KurotatoBossTrackedMarkerMap.Values)
		{
			kurotatoBossTrackedMarker.Recycle();
		}
		this.KurotatoBossTrackedMarkerMap.Clear();
	}

	// Token: 0x0600DBD2 RID: 56274 RVA: 0x003B12C0 File Offset: 0x003AF4C0
	private UniTask CreateKurotatoTreasureBoxTrackedMarkerPanel(int entityId)
	{
		KurotatoMainViewProxy.<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__53 <CreateKurotatoTreasureBoxTrackedMarkerPanel>d__;
		<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.<>4__this = this;
		<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.entityId = entityId;
		<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.<>1__state = -1;
		<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.<>t__builder.Start<KurotatoMainViewProxy.<CreateKurotatoTreasureBoxTrackedMarkerPanel>d__53>(ref <CreateKurotatoTreasureBoxTrackedMarkerPanel>d__);
		return <CreateKurotatoTreasureBoxTrackedMarkerPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DBD3 RID: 56275 RVA: 0x003B130C File Offset: 0x003AF50C
	public void OnKurotatoTreasureBoxTrackedMarkerUpdate(int entityId, bool isAdd)
	{
		if (isAdd)
		{
			this.CreateKurotatoTreasureBoxTrackedMarkerPanel(entityId).Forget();
			return;
		}
		KurotatoTreasureBoxTrackedMarker kurotatoTreasureBoxTrackedMarker;
		if (this.KurotatoTreasureBoxTrackedMarkerMap.TryGetValue(entityId, out kurotatoTreasureBoxTrackedMarker))
		{
			this.KurotatoTreasureBoxTrackedMarkerMap.Remove(entityId);
			kurotatoTreasureBoxTrackedMarker.DelayRecycle();
		}
	}

	// Token: 0x0600DBD4 RID: 56276 RVA: 0x003B134C File Offset: 0x003AF54C
	private void KurotatoCleanAllTreasureBoxTrackedMarker()
	{
		if (this.KurotatoTreasureBoxTrackedMarkerMap.Count == 0)
		{
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.Kurotato, ELogAuthor.LYX, "结束战斗阶段时有宝箱追踪图标残留, 强制清除", default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (KurotatoTreasureBoxTrackedMarker kurotatoTreasureBoxTrackedMarker in this.KurotatoTreasureBoxTrackedMarkerMap.Values)
		{
			kurotatoTreasureBoxTrackedMarker.Recycle();
		}
		this.KurotatoTreasureBoxTrackedMarkerMap.Clear();
	}

	// Token: 0x04006904 RID: 26884
	private const float STEP_ADVANCE_FALLBACK_MS = 3000f;

	// Token: 0x04006905 RID: 26885
	protected Dictionary<Type, UiPanelBase> KurotatoChildPanelMap = new Dictionary<Type, UiPanelBase>();

	// Token: 0x04006906 RID: 26886
	public KurotatoResidentWaveTipsPanel ResidentWaveTips;

	// Token: 0x04006907 RID: 26887
	public KurotatoCountDownTipsPanel CountDownTips;

	// Token: 0x04006908 RID: 26888
	private SurvivorsRoguePlayerTrackerMarker PlayerTrackedMarker;

	// Token: 0x04006909 RID: 26889
	public KurotatoMainPanel MainPanel;

	// Token: 0x0400690A RID: 26890
	public KurotatoAttrChangePanel AttrChangePanel;

	// Token: 0x0400690B RID: 26891
	public KurotatoWaveTipsPanel WaveTipsPanel;

	// Token: 0x0400690C RID: 26892
	public KurotatoBossSpawnTipsPanel BossSpawnTipsPanel;

	// Token: 0x0400690D RID: 26893
	public KurotatoEliteWaveTipsPanel EliteWaveTipsPanel;

	// Token: 0x0400690E RID: 26894
	[Nullable(2)]
	private AUIContainerActor ScreenEffectFightRoot;

	// Token: 0x0400690F RID: 26895
	private readonly Dictionary<int, KurotatoBossTrackedMarker> KurotatoBossTrackedMarkerMap = new Dictionary<int, KurotatoBossTrackedMarker>();

	// Token: 0x04006910 RID: 26896
	private readonly Dictionary<int, KurotatoTreasureBoxTrackedMarker> KurotatoTreasureBoxTrackedMarkerMap = new Dictionary<int, KurotatoTreasureBoxTrackedMarker>();

	// Token: 0x04006911 RID: 26897
	private EKurotatoStep CurStep = EKurotatoStep.None;

	// Token: 0x04006912 RID: 26898
	[Nullable(2)]
	private TimerHandle StepAdvanceTimer;
}
