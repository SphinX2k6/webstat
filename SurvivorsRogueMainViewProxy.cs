using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D8D RID: 7565
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueMainViewProxy : GameMainViewProxy
{
	// Token: 0x1700117C RID: 4476
	// (get) Token: 0x0600DEDB RID: 57051 RVA: 0x003BF395 File Offset: 0x003BD595
	protected override EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason
	{
		get
		{
			return new EBattleUiCommonChildVisibleReason?(EBattleUiCommonChildVisibleReason.SurvivorsRogue);
		}
	}

	// Token: 0x0600DEDC RID: 57052 RVA: 0x003BF3A0 File Offset: 0x003BD5A0
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueMainViewProxy.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEDD RID: 57053 RVA: 0x003BF3E3 File Offset: 0x003BD5E3
	protected override void OnBeforeDestroy()
	{
		this.RemoveScreenEffectFightRoot();
		this.CleanAllBossTrackedMarker();
	}

	// Token: 0x0600DEDE RID: 57054 RVA: 0x003BF3F4 File Offset: 0x003BD5F4
	protected override void OnAfterShow()
	{
		foreach (UiPanelBase uiPanelBase in this.SurvivorsRogueChildPanelMap.Values)
		{
			uiPanelBase.Show(null);
		}
		foreach (SurvivorsRogueBossTrackedMarker survivorsRogueBossTrackedMarker in this.BossTrackedMarkerMap.Values)
		{
			survivorsRogueBossTrackedMarker.Show(null);
		}
		if (this.CurTipsState != (int)ModelBase<SurvivorsRogueModel>.Instance.WaveTipsState)
		{
			this.UpdateWaveTipsByState((int)ModelBase<SurvivorsRogueModel>.Instance.WaveTipsState);
		}
	}

	// Token: 0x0600DEDF RID: 57055 RVA: 0x003BF4B4 File Offset: 0x003BD6B4
	protected override void OnAfterHide()
	{
		foreach (UiPanelBase uiPanelBase in this.SurvivorsRogueChildPanelMap.Values)
		{
			uiPanelBase.Hide(null);
		}
		foreach (SurvivorsRogueBossTrackedMarker survivorsRogueBossTrackedMarker in this.BossTrackedMarkerMap.Values)
		{
			survivorsRogueBossTrackedMarker.Hide(null);
		}
	}

	// Token: 0x0600DEE0 RID: 57056 RVA: 0x003BF550 File Offset: 0x003BD750
	protected override void OnTick(float delta)
	{
		float num = delta * Singleton<Time>.Instance.TimeDilation;
		base.OnTick(num);
		if (this.CurTipsState == 2)
		{
			this.CountDownTips.OnTick(num);
		}
		else if (this.CurTipsState == 1)
		{
			this.PopUpWaveTips.OnTick(num);
		}
		this.FightInfoPanel.OnTick(num);
		this.PlayerTrackedMarker.OnTick(num);
		this.RoleStatePanel.OnTick(num);
		foreach (KeyValuePair<int, SurvivorsRogueBossTrackedMarker> keyValuePair in this.BossTrackedMarkerMap)
		{
			keyValuePair.Value.OnTick(num);
		}
	}

	// Token: 0x0600DEE1 RID: 57057 RVA: 0x003BF610 File Offset: 0x003BD810
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRogueSwitchWaveTipsState, new Action<int>(this.SwitchWaveTipsState));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRogueShowBonusWaveTips, new Action(this.ShowBonusWaveTips));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRogueShowEndlessWaveTips, new Action(this.ShowEndlessWaveTips));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRogueBossTrackedMarkerUpdate, new Action<int, bool>(this.OnBossTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.ConsecutiveKillCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsComboUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.TreasureBoxCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsChestUpdate));
		behaviorDelegate.AddTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.GoldGainEfficiency.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsPositiveUpdate));
	}

	// Token: 0x0600DEE2 RID: 57058 RVA: 0x003BF718 File Offset: 0x003BD918
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueSwitchWaveTipsState, new Action<int>(this.SwitchWaveTipsState));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueShowBonusWaveTips, new Action(this.ShowBonusWaveTips));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueShowEndlessWaveTips, new Action(this.ShowEndlessWaveTips));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRogueBossTrackedMarkerUpdate, new Action<int, bool>(this.OnBossTrackedMarkerUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		BehaviorTreeUpdateDelegateProxy behaviorDelegate = ModelBase<SurvivorsRogueModel>.Instance.BattleData.BehaviorDelegate;
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.Gold.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsCurrencyUpdate));
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.ConsecutiveKillCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsComboUpdate));
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.TreasureBoxCount.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsChestUpdate));
		behaviorDelegate.RemoveTreeVarUpdateDelegate(ESurvivorsRougeSystemVarType.GoldGainEfficiency.ToEnumString(), new TTreeVarUpdateDelegate(this.OnSurvivorsPositiveUpdate));
	}

	// Token: 0x0600DEE3 RID: 57059 RVA: 0x003BF820 File Offset: 0x003BDA20
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected UniTask<T> CreateSurvivorsRogueChildPanel<[Nullable(0)] T>(string resourceId, UUIItem parentItem, bool bShow = true) where T : UiPanelBase, new()
	{
		SurvivorsRogueMainViewProxy.<CreateSurvivorsRogueChildPanel>d__24<T> <CreateSurvivorsRogueChildPanel>d__;
		<CreateSurvivorsRogueChildPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<CreateSurvivorsRogueChildPanel>d__.<>4__this = this;
		<CreateSurvivorsRogueChildPanel>d__.resourceId = resourceId;
		<CreateSurvivorsRogueChildPanel>d__.parentItem = parentItem;
		<CreateSurvivorsRogueChildPanel>d__.bShow = bShow;
		<CreateSurvivorsRogueChildPanel>d__.<>1__state = -1;
		<CreateSurvivorsRogueChildPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateSurvivorsRogueChildPanel>d__24<T>>(ref <CreateSurvivorsRogueChildPanel>d__);
		return <CreateSurvivorsRogueChildPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEE4 RID: 57060 RVA: 0x003BF87C File Offset: 0x003BDA7C
	private void OnSurvivorsCurrencyUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int currencyNum = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.FightInfoPanel.RefreshCurrencyNum(currencyNum, true);
	}

	// Token: 0x0600DEE5 RID: 57061 RVA: 0x003BF8A8 File Offset: 0x003BDAA8
	private void OnSurvivorsComboUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int comboNum = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.FightInfoPanel.RefreshComboNum(comboNum);
	}

	// Token: 0x0600DEE6 RID: 57062 RVA: 0x003BF8D4 File Offset: 0x003BDAD4
	private void OnSurvivorsChestUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int chestNum = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.FightInfoPanel.RefreshChestNum(chestNum, true);
	}

	// Token: 0x0600DEE7 RID: 57063 RVA: 0x003BF900 File Offset: 0x003BDB00
	private void OnSurvivorsPositiveUpdate([Nullable(2)] VarDefinePb lastVarDefine, VarDefinePb newVarDefine)
	{
		int value = (int)Singleton<MathUtils>.Instance.LongToNumber(newVarDefine.Int);
		this.FightInfoPanel.RefreshPositiveArea(value);
	}

	// Token: 0x0600DEE8 RID: 57064 RVA: 0x003BF92C File Offset: 0x003BDB2C
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

	// Token: 0x0600DEE9 RID: 57065 RVA: 0x003BF994 File Offset: 0x003BDB94
	private void RemoveScreenEffectFightRoot()
	{
		AUIContainerActor screenEffectFightRoot = this.ScreenEffectFightRoot;
		if (screenEffectFightRoot != null && screenEffectFightRoot.IsValid())
		{
			this.ScreenEffectFightRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
		}
		this.ScreenEffectFightRoot = null;
		ScreenEffectModel instance = ModelBase<ScreenEffectModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetFightRootInited(false);
	}

	// Token: 0x0600DEEA RID: 57066 RVA: 0x003BF9D0 File Offset: 0x003BDBD0
	private UniTask CreateResidentWaveTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateResidentWaveTipsPanel>d__31 <CreateResidentWaveTipsPanel>d__;
		<CreateResidentWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateResidentWaveTipsPanel>d__.<>4__this = this;
		<CreateResidentWaveTipsPanel>d__.<>1__state = -1;
		<CreateResidentWaveTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateResidentWaveTipsPanel>d__31>(ref <CreateResidentWaveTipsPanel>d__);
		return <CreateResidentWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEEB RID: 57067 RVA: 0x003BFA14 File Offset: 0x003BDC14
	private UniTask CreateCountDownTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateCountDownTipsPanel>d__32 <CreateCountDownTipsPanel>d__;
		<CreateCountDownTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateCountDownTipsPanel>d__.<>4__this = this;
		<CreateCountDownTipsPanel>d__.<>1__state = -1;
		<CreateCountDownTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateCountDownTipsPanel>d__32>(ref <CreateCountDownTipsPanel>d__);
		return <CreateCountDownTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEEC RID: 57068 RVA: 0x003BFA58 File Offset: 0x003BDC58
	private UniTask CreateBonusWaveTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateBonusWaveTipsPanel>d__33 <CreateBonusWaveTipsPanel>d__;
		<CreateBonusWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBonusWaveTipsPanel>d__.<>4__this = this;
		<CreateBonusWaveTipsPanel>d__.<>1__state = -1;
		<CreateBonusWaveTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateBonusWaveTipsPanel>d__33>(ref <CreateBonusWaveTipsPanel>d__);
		return <CreateBonusWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEED RID: 57069 RVA: 0x003BFA9C File Offset: 0x003BDC9C
	private UniTask CreateEndlessWaveTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateEndlessWaveTipsPanel>d__34 <CreateEndlessWaveTipsPanel>d__;
		<CreateEndlessWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateEndlessWaveTipsPanel>d__.<>4__this = this;
		<CreateEndlessWaveTipsPanel>d__.<>1__state = -1;
		<CreateEndlessWaveTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateEndlessWaveTipsPanel>d__34>(ref <CreateEndlessWaveTipsPanel>d__);
		return <CreateEndlessWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEEE RID: 57070 RVA: 0x003BFAE0 File Offset: 0x003BDCE0
	private UniTask CreatePopUpWaveTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreatePopUpWaveTipsPanel>d__35 <CreatePopUpWaveTipsPanel>d__;
		<CreatePopUpWaveTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePopUpWaveTipsPanel>d__.<>4__this = this;
		<CreatePopUpWaveTipsPanel>d__.<>1__state = -1;
		<CreatePopUpWaveTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreatePopUpWaveTipsPanel>d__35>(ref <CreatePopUpWaveTipsPanel>d__);
		return <CreatePopUpWaveTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEEF RID: 57071 RVA: 0x003BFB24 File Offset: 0x003BDD24
	private UniTask CreateWaveCompleteTipsPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateWaveCompleteTipsPanel>d__36 <CreateWaveCompleteTipsPanel>d__;
		<CreateWaveCompleteTipsPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateWaveCompleteTipsPanel>d__.<>4__this = this;
		<CreateWaveCompleteTipsPanel>d__.<>1__state = -1;
		<CreateWaveCompleteTipsPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateWaveCompleteTipsPanel>d__36>(ref <CreateWaveCompleteTipsPanel>d__);
		return <CreateWaveCompleteTipsPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF0 RID: 57072 RVA: 0x003BFB68 File Offset: 0x003BDD68
	private UniTask CreatePlayerTrackedMarkerPanel()
	{
		SurvivorsRogueMainViewProxy.<CreatePlayerTrackedMarkerPanel>d__37 <CreatePlayerTrackedMarkerPanel>d__;
		<CreatePlayerTrackedMarkerPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePlayerTrackedMarkerPanel>d__.<>4__this = this;
		<CreatePlayerTrackedMarkerPanel>d__.<>1__state = -1;
		<CreatePlayerTrackedMarkerPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreatePlayerTrackedMarkerPanel>d__37>(ref <CreatePlayerTrackedMarkerPanel>d__);
		return <CreatePlayerTrackedMarkerPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF1 RID: 57073 RVA: 0x003BFBAC File Offset: 0x003BDDAC
	private UniTask CreateRoleStatePanel()
	{
		SurvivorsRogueMainViewProxy.<CreateRoleStatePanel>d__38 <CreateRoleStatePanel>d__;
		<CreateRoleStatePanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRoleStatePanel>d__.<>4__this = this;
		<CreateRoleStatePanel>d__.<>1__state = -1;
		<CreateRoleStatePanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateRoleStatePanel>d__38>(ref <CreateRoleStatePanel>d__);
		return <CreateRoleStatePanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF2 RID: 57074 RVA: 0x003BFBF0 File Offset: 0x003BDDF0
	private UniTask CreateFightInfoPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateFightInfoPanel>d__39 <CreateFightInfoPanel>d__;
		<CreateFightInfoPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateFightInfoPanel>d__.<>4__this = this;
		<CreateFightInfoPanel>d__.<>1__state = -1;
		<CreateFightInfoPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateFightInfoPanel>d__39>(ref <CreateFightInfoPanel>d__);
		return <CreateFightInfoPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF3 RID: 57075 RVA: 0x003BFC34 File Offset: 0x003BDE34
	private UniTask CreateMobileSkillPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateMobileSkillPanel>d__40 <CreateMobileSkillPanel>d__;
		<CreateMobileSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanel>d__.<>4__this = this;
		<CreateMobileSkillPanel>d__.<>1__state = -1;
		<CreateMobileSkillPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateMobileSkillPanel>d__40>(ref <CreateMobileSkillPanel>d__);
		return <CreateMobileSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF4 RID: 57076 RVA: 0x003BFC78 File Offset: 0x003BDE78
	private UniTask CreateDesktopSkillPanel()
	{
		SurvivorsRogueMainViewProxy.<CreateDesktopSkillPanel>d__41 <CreateDesktopSkillPanel>d__;
		<CreateDesktopSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanel>d__.<>4__this = this;
		<CreateDesktopSkillPanel>d__.<>1__state = -1;
		<CreateDesktopSkillPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateDesktopSkillPanel>d__41>(ref <CreateDesktopSkillPanel>d__);
		return <CreateDesktopSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF5 RID: 57077 RVA: 0x003BFCBC File Offset: 0x003BDEBC
	private UniTask CreateMobileSkillPanelInner()
	{
		SurvivorsRogueMainViewProxy.<CreateMobileSkillPanelInner>d__42 <CreateMobileSkillPanelInner>d__;
		<CreateMobileSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanelInner>d__.<>4__this = this;
		<CreateMobileSkillPanelInner>d__.<>1__state = -1;
		<CreateMobileSkillPanelInner>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateMobileSkillPanelInner>d__42>(ref <CreateMobileSkillPanelInner>d__);
		return <CreateMobileSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF6 RID: 57078 RVA: 0x003BFD00 File Offset: 0x003BDF00
	private UniTask CreateDesktopSkillPanelInner()
	{
		SurvivorsRogueMainViewProxy.<CreateDesktopSkillPanelInner>d__43 <CreateDesktopSkillPanelInner>d__;
		<CreateDesktopSkillPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanelInner>d__.<>4__this = this;
		<CreateDesktopSkillPanelInner>d__.<>1__state = -1;
		<CreateDesktopSkillPanelInner>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateDesktopSkillPanelInner>d__43>(ref <CreateDesktopSkillPanelInner>d__);
		return <CreateDesktopSkillPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF7 RID: 57079 RVA: 0x003BFD44 File Offset: 0x003BDF44
	private UniTask CreateBossTrackedMarkerPanel(int entityId)
	{
		SurvivorsRogueMainViewProxy.<CreateBossTrackedMarkerPanel>d__44 <CreateBossTrackedMarkerPanel>d__;
		<CreateBossTrackedMarkerPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateBossTrackedMarkerPanel>d__.<>4__this = this;
		<CreateBossTrackedMarkerPanel>d__.entityId = entityId;
		<CreateBossTrackedMarkerPanel>d__.<>1__state = -1;
		<CreateBossTrackedMarkerPanel>d__.<>t__builder.Start<SurvivorsRogueMainViewProxy.<CreateBossTrackedMarkerPanel>d__44>(ref <CreateBossTrackedMarkerPanel>d__);
		return <CreateBossTrackedMarkerPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEF8 RID: 57080 RVA: 0x003BFD8F File Offset: 0x003BDF8F
	private void SwitchWaveTipsState(int state)
	{
		this.UpdateWaveTipsByState(state);
	}

	// Token: 0x0600DEF9 RID: 57081 RVA: 0x003BFD98 File Offset: 0x003BDF98
	private void ShowBonusWaveTips()
	{
		this.BonusWaveTips.ShowTips();
	}

	// Token: 0x0600DEFA RID: 57082 RVA: 0x003BFDA5 File Offset: 0x003BDFA5
	private void ShowEndlessWaveTips()
	{
		this.EndlessWaveTips.ShowTips();
	}

	// Token: 0x0600DEFB RID: 57083 RVA: 0x003BFDB4 File Offset: 0x003BDFB4
	private void OnBossTrackedMarkerUpdate(int entityId, bool isAdd)
	{
		if (isAdd)
		{
			this.CreateBossTrackedMarkerPanel(entityId).Forget();
			return;
		}
		SurvivorsRogueBossTrackedMarker survivorsRogueBossTrackedMarker;
		if (this.BossTrackedMarkerMap.TryGetValue(entityId, out survivorsRogueBossTrackedMarker))
		{
			this.BossTrackedMarkerMap.Remove(entityId);
			survivorsRogueBossTrackedMarker.DelayRecycle();
		}
	}

	// Token: 0x0600DEFC RID: 57084 RVA: 0x003BFDF4 File Offset: 0x003BDFF4
	private void OnPlayerEntityCreated()
	{
		this.PlayerTrackedMarker.ShowTips();
	}

	// Token: 0x0600DEFD RID: 57085 RVA: 0x003BFE04 File Offset: 0x003BE004
	public void UpdateWaveTipsByState(int state)
	{
		this.CurTipsState = state;
		switch (state)
		{
		case 0:
			this.PopUpWaveTips.Hide(null);
			this.ResidentWaveTips.HideTips();
			this.CountDownTips.HideTips();
			this.WaveCompleteTips.HideTips();
			this.BonusWaveTips.HideTips();
			this.EndlessWaveTips.HideTips();
			return;
		case 1:
			if (ConfigSurvivorsWaveByLevel.GetConfigList(ModelBase<SurvivorsRogueModel>.Instance.CurLevelId, true) != null)
			{
				this.PopUpWaveTips.ShowWaveTips();
				this.FightInfoPanel.SetChestActive(ModelBase<SurvivorsRogueModel>.Instance.IsBonusWave);
				this.ResidentWaveTips.HideTips();
				this.CountDownTips.HideTips();
				this.WaveCompleteTips.HideTips();
				this.BonusWaveTips.HideTips();
				this.EndlessWaveTips.HideTips();
				return;
			}
			break;
		case 2:
			this.CountDownTips.InitCountDown((float)ConfigBase<SurvivorsRogueConfig>.Instance.GetWaveDuration(ModelBase<SurvivorsRogueModel>.Instance.CurLevelId, ModelBase<SurvivorsRogueModel>.Instance.CurWaveNum), ModelBase<SurvivorsRogueModel>.Instance.IsEndlessWave);
			this.PopUpWaveTips.Hide(null);
			this.ResidentWaveTips.ShowTips();
			this.CountDownTips.ShowTips();
			this.WaveCompleteTips.HideTips();
			this.BonusWaveTips.HideTips();
			this.EndlessWaveTips.HideTips();
			return;
		case 3:
			this.CleanAllBossTrackedMarker();
			this.PopUpWaveTips.Hide(null);
			this.ResidentWaveTips.HideTips();
			this.CountDownTips.HideTips();
			this.WaveCompleteTips.ShowTips();
			this.BonusWaveTips.HideTips();
			this.EndlessWaveTips.HideTips();
			this.FightInfoPanel.ResetFightInfo();
			break;
		default:
			return;
		}
	}

	// Token: 0x0600DEFE RID: 57086 RVA: 0x003BFFAC File Offset: 0x003BE1AC
	private void CleanAllBossTrackedMarker()
	{
		if (this.BossTrackedMarkerMap.Count == 0)
		{
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.SurvivorsRogue, ELogAuthor.CK, "结束战斗阶段时有BOSS追踪图标残留, 强制清除", default(ReadOnlySpan<ValueTuple<string, object>>));
		foreach (SurvivorsRogueBossTrackedMarker survivorsRogueBossTrackedMarker in this.BossTrackedMarkerMap.Values)
		{
			survivorsRogueBossTrackedMarker.Recycle();
		}
		this.BossTrackedMarkerMap.Clear();
	}

	// Token: 0x04006B2C RID: 27436
	protected Dictionary<Type, UiPanelBase> SurvivorsRogueChildPanelMap = new Dictionary<Type, UiPanelBase>();

	// Token: 0x04006B2D RID: 27437
	public SurvivorsRogueRoleStatePanel RoleStatePanel;

	// Token: 0x04006B2E RID: 27438
	public SurvivorsRogueFightInfoPanel FightInfoPanel;

	// Token: 0x04006B2F RID: 27439
	public SurvivorsRogueTipsPanelBase BonusWaveTips;

	// Token: 0x04006B30 RID: 27440
	public SurvivorsRoguePopUpWaveTipsPanel PopUpWaveTips;

	// Token: 0x04006B31 RID: 27441
	[Nullable(2)]
	public SurvivorsRogueSkillPanel MobileSkillPanel;

	// Token: 0x04006B32 RID: 27442
	[Nullable(2)]
	public SurvivorsRogueSkillPanel DesktopSkillPanel;

	// Token: 0x04006B33 RID: 27443
	public SurvivorsRogueResidentWaveTipsPanel ResidentWaveTips;

	// Token: 0x04006B34 RID: 27444
	public SurvivorsRogueTipsPanelBase EndlessWaveTips;

	// Token: 0x04006B35 RID: 27445
	public SurvivorsRogueCountDownTipsPanel CountDownTips;

	// Token: 0x04006B36 RID: 27446
	public SurvivorsRogueTipsPanelBase WaveCompleteTips;

	// Token: 0x04006B37 RID: 27447
	private readonly Dictionary<int, SurvivorsRogueBossTrackedMarker> BossTrackedMarkerMap = new Dictionary<int, SurvivorsRogueBossTrackedMarker>();

	// Token: 0x04006B38 RID: 27448
	private SurvivorsRoguePlayerTrackerMarker PlayerTrackedMarker;

	// Token: 0x04006B39 RID: 27449
	[Nullable(2)]
	private AUIContainerActor ScreenEffectFightRoot;

	// Token: 0x04006B3A RID: 27450
	private int CurTipsState;
}
