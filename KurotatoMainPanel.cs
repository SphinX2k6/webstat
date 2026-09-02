using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D22 RID: 7458
[NullableContext(1)]
[Nullable(0)]
public class KurotatoMainPanel : UiPanelBase
{
	// Token: 0x17001165 RID: 4453
	// (get) Token: 0x0600DB3B RID: 56123 RVA: 0x003AE374 File Offset: 0x003AC574
	private float CurHp
	{
		get
		{
			if (this.AttrMap == null)
			{
				return 0f;
			}
			int valueOrDefault = this.AttrMap.GetValueOrDefault(EKSC_AttrType.Life, 0);
			if (valueOrDefault > 0)
			{
				return (float)valueOrDefault;
			}
			return 0f;
		}
	}

	// Token: 0x17001166 RID: 4454
	// (get) Token: 0x0600DB3C RID: 56124 RVA: 0x003AE3AC File Offset: 0x003AC5AC
	private float MaxHp
	{
		get
		{
			if (this.AttrMap == null)
			{
				return this.LastValidMaxHp;
			}
			int valueOrDefault = this.AttrMap.GetValueOrDefault(EKSC_AttrType.LifeMax, 0);
			if (valueOrDefault > 0)
			{
				this.LastValidMaxHp = (float)valueOrDefault;
				return (float)valueOrDefault;
			}
			return this.LastValidMaxHp;
		}
	}

	// Token: 0x0600DB3D RID: 56125 RVA: 0x003AE3EC File Offset: 0x003AC5EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUITexture)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUISprite)),
			new ValueTuple<int, Type>(16, typeof(UUISprite)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUISprite)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUITexture)),
			new ValueTuple<int, Type>(27, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnBtnQuitClicked)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnBtnMonsterClicked)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnInfoClicked))
		};
	}

	// Token: 0x0600DB3E RID: 56126 RVA: 0x003AE6D4 File Offset: 0x003AC8D4
	protected override UniTask OnBeforeStartAsync()
	{
		KurotatoMainPanel.<OnBeforeStartAsync>d__35 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoMainPanel.<OnBeforeStartAsync>d__35>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB3F RID: 56127 RVA: 0x003AE718 File Offset: 0x003AC918
	protected override void OnStart()
	{
		this.SpriteExpBar = base.GetSprite(13);
		this.SpriteLowHpBar = base.GetSprite(22);
		this.SpriteHpBar = base.GetSprite(16);
		this.HpBufferSprite = base.GetSprite(15);
		this.TextHpNum = base.GetText(17);
		this.TextHpNum2 = base.GetText(19);
		this.ComboNumText = base.GetText(7);
		this.PanelKillNum = base.GetItem(23);
		this.PanelKillNum.SetUIActive(false);
		this.HpTextMask = (base.GetItem(18).GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
		this.HpTextWidth = this.TextHpNum.GetWidth();
		this.HpBufferAnimDuration = (float)ConfigCommonParamById.GetIntConfig("PlayerHPAttenuateBufferSpeed").GetValueOrDefault();
		this.ChestCountPanel.SetUiActive(false);
		this.LevelUpCountPanel.SetUiActive(false);
		base.GetItem(5).SetUIActive(false);
		base.GetItem(10).SetUIActive(false);
		base.GetItem(24).SetUIActive(false);
		base.GetItem(25).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		this.InitActivityConfig();
		this.InitHpBar();
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
	}

	// Token: 0x0600DB40 RID: 56128 RVA: 0x003AE884 File Offset: 0x003ACA84
	protected override void OnBeforeShow()
	{
		this.OnAddEventListener();
		this.RefreshAll();
		this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
		if (ModelBase<KurotatoModel>.Instance.ConsumeNeedShowSaveTip())
		{
			base.GetItem(10).SetUIActive(true);
			this.SeqPlayer.PlayOrReplaySequenceByName("Save", false, null);
		}
		KurotatoSkillPanel activeSkillPanel = this.GetActiveSkillPanel();
		if (activeSkillPanel == null)
		{
			return;
		}
		activeSkillPanel.ShowBattleChildViewPanel();
	}

	// Token: 0x0600DB41 RID: 56129 RVA: 0x003AE8FC File Offset: 0x003ACAFC
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
		this.SeqPlayer.StopPlayingSequence(false, false);
		this.KillHoldTimeRemainMs = -1f;
		UUIItem panelKillNum = this.PanelKillNum;
		if (panelKillNum != null)
		{
			panelKillNum.SetUIActive(false);
		}
		base.GetItem(10).SetUIActive(false);
		KurotatoSkillPanel activeSkillPanel = this.GetActiveSkillPanel();
		if (activeSkillPanel == null)
		{
			return;
		}
		activeSkillPanel.HideBattleChildViewPanel();
	}

	// Token: 0x0600DB42 RID: 56130 RVA: 0x003AE957 File Offset: 0x003ACB57
	protected override void OnBeforeDestroy()
	{
		KurotatoSkillPanel activeSkillPanel = this.GetActiveSkillPanel();
		if (activeSkillPanel == null)
		{
			return;
		}
		activeSkillPanel.Reset();
	}

	// Token: 0x0600DB43 RID: 56131 RVA: 0x003AE96C File Offset: 0x003ACB6C
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		Singleton<EventSystem>.Instance.Add(EEventName.KurotatoOnSystemInfoUpdate, new Action(this.OnSystemInfoUpdate));
	}

	// Token: 0x0600DB44 RID: 56132 RVA: 0x003AE9EC File Offset: 0x003ACBEC
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerHpChanged, new Action(this.OnKscPlayerHpChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.SurvivorsRoguePlayerEntityCreated, new Action(this.OnPlayerEntityCreated));
		Singleton<EventSystem>.Instance.Remove(EEventName.KurotatoOnSystemInfoUpdate, new Action(this.OnSystemInfoUpdate));
	}

	// Token: 0x0600DB45 RID: 56133 RVA: 0x003AEA6C File Offset: 0x003ACC6C
	public void OnTick(float delta)
	{
		this.LerpBarPercent(delta);
		this.TickKillHold(delta);
		KurotatoSkillPanel activeSkillPanel = this.GetActiveSkillPanel();
		if (activeSkillPanel != null && activeSkillPanel.GetVisible())
		{
			activeSkillPanel.OnTickBattleChildViewPanel(delta);
		}
	}

	// Token: 0x0600DB46 RID: 56134 RVA: 0x003AEAA0 File Offset: 0x003ACCA0
	private void TickKillHold(float delta)
	{
		if (this.KillHoldTimeRemainMs < 0f)
		{
			return;
		}
		this.KillHoldTimeRemainMs -= delta;
		if (this.KillHoldTimeRemainMs <= 0f)
		{
			this.KillHoldTimeRemainMs = -1f;
			this.SeqPlayer.PlayOrReplaySequenceByName("KillClose", false, null);
		}
	}

	// Token: 0x0600DB47 RID: 56135 RVA: 0x003AEAFC File Offset: 0x003ACCFC
	private UniTask CreateMobileSkillPanel()
	{
		KurotatoMainPanel.<CreateMobileSkillPanel>d__44 <CreateMobileSkillPanel>d__;
		<CreateMobileSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateMobileSkillPanel>d__.<>4__this = this;
		<CreateMobileSkillPanel>d__.<>1__state = -1;
		<CreateMobileSkillPanel>d__.<>t__builder.Start<KurotatoMainPanel.<CreateMobileSkillPanel>d__44>(ref <CreateMobileSkillPanel>d__);
		return <CreateMobileSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB48 RID: 56136 RVA: 0x003AEB40 File Offset: 0x003ACD40
	private UniTask CreateDesktopSkillPanel()
	{
		KurotatoMainPanel.<CreateDesktopSkillPanel>d__45 <CreateDesktopSkillPanel>d__;
		<CreateDesktopSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateDesktopSkillPanel>d__.<>4__this = this;
		<CreateDesktopSkillPanel>d__.<>1__state = -1;
		<CreateDesktopSkillPanel>d__.<>t__builder.Start<KurotatoMainPanel.<CreateDesktopSkillPanel>d__45>(ref <CreateDesktopSkillPanel>d__);
		return <CreateDesktopSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB49 RID: 56137 RVA: 0x003AEB84 File Offset: 0x003ACD84
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<KurotatoSkillPanel> CreateSkillPanel(string resourceId, EBattleUiChild childType)
	{
		KurotatoMainPanel.<CreateSkillPanel>d__46 <CreateSkillPanel>d__;
		<CreateSkillPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder<KurotatoSkillPanel>.Create();
		<CreateSkillPanel>d__.<>4__this = this;
		<CreateSkillPanel>d__.resourceId = resourceId;
		<CreateSkillPanel>d__.childType = childType;
		<CreateSkillPanel>d__.<>1__state = -1;
		<CreateSkillPanel>d__.<>t__builder.Start<KurotatoMainPanel.<CreateSkillPanel>d__46>(ref <CreateSkillPanel>d__);
		return <CreateSkillPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DB4A RID: 56138 RVA: 0x003AEBD7 File Offset: 0x003ACDD7
	[NullableContext(2)]
	private KurotatoSkillPanel GetActiveSkillPanel()
	{
		return this.MobileSkillPanel ?? this.DesktopSkillPanel;
	}

	// Token: 0x0600DB4B RID: 56139 RVA: 0x003AEBE9 File Offset: 0x003ACDE9
	private void OnBtnQuitClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPauseView, null, null);
	}

	// Token: 0x0600DB4C RID: 56140 RVA: 0x003AEBFC File Offset: 0x003ACDFC
	private void OnBtnMonsterClicked()
	{
		KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
		if (instance.GetIsSpecialWave())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Flying_Tip", Array.Empty<object>());
			return;
		}
		KurotatoEnemyDetailBookMainViewOpenParam param = new KurotatoEnemyDetailBookMainViewOpenParam
		{
			TargetLevel = instance.GetCurLevelId(),
			TargetWave = instance.CurWaveNum
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoEnemyDetailBookMainView, param, null);
	}

	// Token: 0x0600DB4D RID: 56141 RVA: 0x003AEC5B File Offset: 0x003ACE5B
	private void OnBtnInfoClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoTabMainView, null, null);
	}

	// Token: 0x0600DB4E RID: 56142 RVA: 0x003AEC6E File Offset: 0x003ACE6E
	private void OnRefreshText(string oldLang, string newLang)
	{
		this.RefreshHpAndShield(false);
	}

	// Token: 0x0600DB4F RID: 56143 RVA: 0x003AEC77 File Offset: 0x003ACE77
	private void OnKscPlayerHpChanged()
	{
		this.RefreshHpAndShield(true);
	}

	// Token: 0x0600DB50 RID: 56144 RVA: 0x003AEC80 File Offset: 0x003ACE80
	private void OnPlayerEntityCreated()
	{
		this.InitPlayerData();
	}

	// Token: 0x0600DB51 RID: 56145 RVA: 0x003AEC88 File Offset: 0x003ACE88
	private void OnSystemInfoUpdate()
	{
		this.RefreshAll();
	}

	// Token: 0x0600DB52 RID: 56146 RVA: 0x003AEC90 File Offset: 0x003ACE90
	public void RefreshAll()
	{
		this.InitPlayerData();
		this.RefreshRoleHead();
		this.RefreshExp();
		this.RefreshChestCount(ModelBase<KurotatoModel>.Instance.BattleData.GetChestCount(), false);
		this.RefreshLevelUpCount(ModelBase<KurotatoModel>.Instance.BattleData.GetUpgradeCount(), false);
		this.RefreshCurrencyNum(ModelBase<KurotatoModel>.Instance.BattleData.GetCurrencyCount(), 0);
		this.RefreshSpareGold(ModelBase<KurotatoModel>.Instance.BattleData.GetSpareGold(), 0);
	}

	// Token: 0x0600DB53 RID: 56147 RVA: 0x003AED08 File Offset: 0x003ACF08
	public void RefreshRoleHead()
	{
		int roleId = ModelBase<KurotatoModel>.Instance.GetRoleId();
		RoleDataBase roleDataByKurotatoRoleId = ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(roleId);
		base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleDataByKurotatoRoleId.GetRoleSkinId()).Value.RoleHeadIconCircle, base.GetTexture(12), null, null);
	}

	// Token: 0x0600DB54 RID: 56148 RVA: 0x003AED68 File Offset: 0x003ACF68
	public void RefreshExp()
	{
		KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
		KurotatoConfig instance2 = ConfigBase<KurotatoConfig>.Instance;
		int curLevelId = instance.GetCurLevelId();
		if (curLevelId == 0)
		{
			this.SetExpBarFill(0f);
			return;
		}
		int roleLevel = instance.BattleData.GetRoleLevel();
		int roleExp = instance.BattleData.GetRoleExp();
		KurotatoLevel value = instance2.GetLevelConfig(curLevelId).Value;
		int maxLevel = instance2.GetMaxLevel(value.ActivityId);
		if (roleLevel <= 0)
		{
			this.SetExpBarFill(0f);
		}
		else if (roleLevel >= maxLevel)
		{
			this.SetExpBarFill(1f);
		}
		else
		{
			int expByLevel = instance2.GetExpByLevel(roleLevel, value.ActivityId);
			int expByLevel2 = instance2.GetExpByLevel(roleLevel + 1, value.ActivityId);
			float expBarFill = (float)(roleExp - expByLevel) / (float)(expByLevel2 - expByLevel);
			this.SetExpBarFill(expBarFill);
		}
		base.GetText(14).SetText(roleLevel.ToString(), true);
	}

	// Token: 0x0600DB55 RID: 56149 RVA: 0x003AEE44 File Offset: 0x003AD044
	private void SetExpBarFill(float percent)
	{
		float fillAmount = Singleton<MathUtils>.Instance.Lerp(0.1f, 0.68f, percent);
		this.SpriteExpBar.SetFillAmount(fillAmount);
		base.GetTexture(26).SetFillAmount(fillAmount);
	}

	// Token: 0x0600DB56 RID: 56150 RVA: 0x003AEE84 File Offset: 0x003AD084
	public void PlayLvUpAnim()
	{
		this.SeqPlayer.PlayOrReplaySequenceByName("LvUp", false, null);
	}

	// Token: 0x0600DB57 RID: 56151 RVA: 0x003AEEAC File Offset: 0x003AD0AC
	public void RefreshCurrencyNum(int currencyNum, int increment = 0)
	{
		base.GetText(2).SetText(currencyNum.ToString(), true);
		if (increment > 0)
		{
			this.SeqPlayer.PlayOrReplaySequenceByName("Coin", false, null);
			this.SeqPlayer.PlayOrReplaySequenceByName("Coin02", false, null);
		}
	}

	// Token: 0x0600DB58 RID: 56152 RVA: 0x003AEF08 File Offset: 0x003AD108
	public void RefreshSpareGold(int spareGold, int increment = 0)
	{
		base.GetText(4).SetText(spareGold.ToString(), true);
		base.GetItem(24).SetUIActive(spareGold > 0);
		if (increment > 0)
		{
			UUIText text = base.GetText(6);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("+");
			defaultInterpolatedStringHandler.AppendFormatted<int>(increment);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.SeqPlayer.PlayOrReplaySequenceByName("Coin02", false, null);
		}
		base.GetItem(3).SetUIActive(increment < 0);
		if (increment < 0)
		{
			this.SeqPlayer.PlayOrReplaySequenceByName("CoinX2", false, null);
		}
	}

	// Token: 0x0600DB59 RID: 56153 RVA: 0x003AEFB8 File Offset: 0x003AD1B8
	public void RefreshComboNum(int comboNum)
	{
		if (!this.ConsecutiveKillStartShowNumArray.Contains(comboNum))
		{
			return;
		}
		this.ComboNumText.SetText(comboNum.ToString(), true);
		if (this.SeqPlayer.IsPlayingSequence("KillStart") || this.SeqPlayer.IsPlayingSequence("KillMore") || this.SeqPlayer.IsPlayingSequence("KillClose") || this.KillHoldTimeRemainMs >= 0f)
		{
			this.KillHoldTimeRemainMs = -1f;
			this.SeqPlayer.PlayOrReplaySequenceByName("KillMore", false, null);
			return;
		}
		this.PanelKillNum.SetUIActive(true);
		this.SeqPlayer.PlayOrReplaySequenceByName("KillStart", false, null);
	}

	// Token: 0x0600DB5A RID: 56154 RVA: 0x003AF07E File Offset: 0x003AD27E
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "KillStart" || sequenceName == "KillMore")
		{
			this.KillHoldTimeRemainMs = this.ConsecutiveKillHoldDuration;
		}
	}

	// Token: 0x0600DB5B RID: 56155 RVA: 0x003AF0A6 File Offset: 0x003AD2A6
	public void RefreshChestCount(int count, bool bPlayAcquireAnim = false)
	{
		this.ChestCountPanel.SetUiActive(count > 0);
		this.ChestCountPanel.Refresh(count);
		if (bPlayAcquireAnim)
		{
			this.ChestCountPanel.PlayAcquireAnim();
		}
	}

	// Token: 0x0600DB5C RID: 56156 RVA: 0x003AF0D1 File Offset: 0x003AD2D1
	public void RefreshLevelUpCount(int count, bool bPlayAcquireAnim = false)
	{
		this.LevelUpCountPanel.SetUiActive(count > 0);
		this.LevelUpCountPanel.Refresh(count);
		if (bPlayAcquireAnim)
		{
			this.LevelUpCountPanel.PlayAcquireAnim();
		}
	}

	// Token: 0x0600DB5D RID: 56157 RVA: 0x003AF0FC File Offset: 0x003AD2FC
	public void InitPlayerData()
	{
		KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		AKSC_Entity aksc_Entity = (curSubModel != null) ? curSubModel.KscPlayerEntity : null;
		if (aksc_Entity == null)
		{
			return;
		}
		UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
		TMap<EKSC_AttrType, int> tmap;
		if (skillComp == null)
		{
			tmap = null;
		}
		else
		{
			UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
			tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
		}
		TMap<EKSC_AttrType, int> tmap2 = tmap;
		if (tmap2 == null)
		{
			return;
		}
		this.AttrMap = tmap2;
		this.RefreshHpAndShield(false);
		base.GetItem(25).SetUIActive(true);
	}

	// Token: 0x0600DB5E RID: 56158 RVA: 0x003AF164 File Offset: 0x003AD364
	private void InitActivityConfig()
	{
		KurotatoActivityConfig? activityConfig = ModelBase<KurotatoModel>.Instance.GetActivityConfig();
		if (activityConfig == null)
		{
			return;
		}
		this.ConsecutiveKillStartShowNumArray = (from showNum in activityConfig.Value.GetConsecutiveKillStartShowNumArrayArray()
		where showNum > 0
		select showNum into num
		orderby num
		select num).ToList<int>();
		this.ConsecutiveKillHoldDuration = (float)activityConfig.Value.ConsecutiveKillHoldDuration;
	}

	// Token: 0x0600DB5F RID: 56159 RVA: 0x003AF1FE File Offset: 0x003AD3FE
	private void InitHpBar()
	{
		this.SpriteLowHpBar.SetUIActive(false);
		this.SpriteHpBar.SetUIActive(true);
	}

	// Token: 0x0600DB60 RID: 56160 RVA: 0x003AF218 File Offset: 0x003AD418
	private void RefreshHpAndShield(bool bPlayBarAnimation = false)
	{
		if (this.AttrMap == null)
		{
			return;
		}
		float num = this.CurHp / this.MaxHp;
		this.UeMargin.Right = -(1f - num) * this.HpTextWidth;
		this.HpTextMask.SetRectClipOffset(this.UeMargin);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)this.CurHp));
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)Math.Ceiling((double)this.MaxHp));
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		this.TextHpNum.SetText(newText, true);
		this.TextHpNum2.SetText(newText, true);
		this.SetHpBarPercent(num);
		if (bPlayBarAnimation)
		{
			this.PlayBarAnimation();
		}
		else
		{
			this.StopBarLerpAnimation();
		}
		this.CurrentBarPercent = num;
	}

	// Token: 0x0600DB61 RID: 56161 RVA: 0x003AF2E8 File Offset: 0x003AD4E8
	private void SetHpBarPercent(float percent)
	{
		if (percent <= 0.2f)
		{
			this.SpriteLowHpBar.SetUIActive(true);
			this.SpriteHpBar.SetUIActive(false);
			this.SpriteLowHpBar.SetFillAmount(percent);
			return;
		}
		this.SpriteLowHpBar.SetUIActive(false);
		this.SpriteHpBar.SetUIActive(true);
		this.SpriteHpBar.SetFillAmount(percent);
	}

	// Token: 0x0600DB62 RID: 56162 RVA: 0x003AF348 File Offset: 0x003AD548
	private void PlayBarAnimation()
	{
		if (this.AttrMap == null)
		{
			return;
		}
		float num = this.CurHp / this.MaxHp;
		float currentBarPercent = this.CurrentBarPercent;
		if (num >= currentBarPercent)
		{
			return;
		}
		this.TargetBarPercent = num;
		this.SourceBarPercent = currentBarPercent;
		this.HpBufferAnimTime = 0f;
	}

	// Token: 0x0600DB63 RID: 56163 RVA: 0x003AF391 File Offset: 0x003AD591
	private void StopBarLerpAnimation()
	{
		this.TargetBarPercent = 0f;
		this.SourceBarPercent = 0f;
		this.HpBufferAnimTime = -1f;
		this.HpBufferSprite.SetUIActive(false);
	}

	// Token: 0x0600DB64 RID: 56164 RVA: 0x003AF3C0 File Offset: 0x003AD5C0
	private void LerpBarPercent(float delta)
	{
		if (this.HpBufferAnimTime == -1f)
		{
			return;
		}
		if (this.HpBufferAnimTime >= this.HpBufferAnimDuration)
		{
			this.StopBarLerpAnimation();
			return;
		}
		if (this.TargetBarPercent >= this.SourceBarPercent)
		{
			return;
		}
		float alpha = this.HpBufferAnimTime / this.HpBufferAnimDuration;
		float fillAmount = Singleton<MathUtils>.Instance.Lerp(this.SourceBarPercent, this.TargetBarPercent, alpha);
		this.HpBufferSprite.SetFillAmount(fillAmount);
		this.HpBufferSprite.SetUIActive(true);
		this.HpBufferAnimTime += delta;
	}

	// Token: 0x040068BC RID: 26812
	private const float LOW_HP_PERCENT = 0.2f;

	// Token: 0x040068BD RID: 26813
	private const float EXP_BAR_FILL_MIN = 0.1f;

	// Token: 0x040068BE RID: 26814
	private const float EXP_BAR_FILL_MAX = 0.68f;

	// Token: 0x040068BF RID: 26815
	private UUISprite SpriteExpBar;

	// Token: 0x040068C0 RID: 26816
	private UUISprite SpriteLowHpBar;

	// Token: 0x040068C1 RID: 26817
	private UUISprite SpriteHpBar;

	// Token: 0x040068C2 RID: 26818
	private UUISprite HpBufferSprite;

	// Token: 0x040068C3 RID: 26819
	private UUIText TextHpNum;

	// Token: 0x040068C4 RID: 26820
	private UUIText TextHpNum2;

	// Token: 0x040068C5 RID: 26821
	private ULGUICanvas HpTextMask;

	// Token: 0x040068C6 RID: 26822
	private UUIText ComboNumText;

	// Token: 0x040068C7 RID: 26823
	private UUIItem PanelKillNum;

	// Token: 0x040068C8 RID: 26824
	private float HpTextWidth;

	// Token: 0x040068C9 RID: 26825
	private FMargin UeMargin;

	// Token: 0x040068CA RID: 26826
	private List<int> ConsecutiveKillStartShowNumArray = new List<int>();

	// Token: 0x040068CB RID: 26827
	private float ConsecutiveKillHoldDuration;

	// Token: 0x040068CC RID: 26828
	private float KillHoldTimeRemainMs = -1f;

	// Token: 0x040068CD RID: 26829
	private readonly KurotatoCountItemPanel ChestCountPanel = new KurotatoCountItemPanel();

	// Token: 0x040068CE RID: 26830
	private readonly KurotatoCountItemPanel LevelUpCountPanel = new KurotatoCountItemPanel();

	// Token: 0x040068CF RID: 26831
	[Nullable(2)]
	private KurotatoSkillPanel MobileSkillPanel;

	// Token: 0x040068D0 RID: 26832
	[Nullable(2)]
	private KurotatoSkillPanel DesktopSkillPanel;

	// Token: 0x040068D1 RID: 26833
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040068D2 RID: 26834
	[Nullable(2)]
	private TMap<EKSC_AttrType, int> AttrMap;

	// Token: 0x040068D3 RID: 26835
	private float CurrentBarPercent = -1f;

	// Token: 0x040068D4 RID: 26836
	private float TargetBarPercent;

	// Token: 0x040068D5 RID: 26837
	private float SourceBarPercent;

	// Token: 0x040068D6 RID: 26838
	private float HpBufferAnimTime = -1f;

	// Token: 0x040068D7 RID: 26839
	private float HpBufferAnimDuration;

	// Token: 0x040068D8 RID: 26840
	private float LastValidMaxHp = -1f;

	// Token: 0x0200809B RID: 32923
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BBCE RID: 179150
		public const int PanelLowHpEffect = 0;

		// Token: 0x0402BBCF RID: 179151
		public const int BtnQuit = 1;

		// Token: 0x0402BBD0 RID: 179152
		public const int TextCurrencyNum = 2;

		// Token: 0x0402BBD1 RID: 179153
		public const int PanelCurrencyExtra = 3;

		// Token: 0x0402BBD2 RID: 179154
		public const int TextSpareGoldNum = 4;

		// Token: 0x0402BBD3 RID: 179155
		public const int PanelSpareGoldAdd = 5;

		// Token: 0x0402BBD4 RID: 179156
		public const int TextSpareGoldAdd = 6;

		// Token: 0x0402BBD5 RID: 179157
		public const int TextComboNum = 7;

		// Token: 0x0402BBD6 RID: 179158
		public const int BtnMonster = 8;

		// Token: 0x0402BBD7 RID: 179159
		public const int BtnInfo = 9;

		// Token: 0x0402BBD8 RID: 179160
		public const int PanelSaveTip = 10;

		// Token: 0x0402BBD9 RID: 179161
		public const int TextSaveTip = 11;

		// Token: 0x0402BBDA RID: 179162
		public const int TextureRoleHead = 12;

		// Token: 0x0402BBDB RID: 179163
		public const int SpriteExpBar = 13;

		// Token: 0x0402BBDC RID: 179164
		public const int TextLevel = 14;

		// Token: 0x0402BBDD RID: 179165
		public const int SpriteHpBuffer = 15;

		// Token: 0x0402BBDE RID: 179166
		public const int SpriteHpBar = 16;

		// Token: 0x0402BBDF RID: 179167
		public const int TextHpNum = 17;

		// Token: 0x0402BBE0 RID: 179168
		public const int PanelHpMask = 18;

		// Token: 0x0402BBE1 RID: 179169
		public const int TextHpNum2 = 19;

		// Token: 0x0402BBE2 RID: 179170
		public const int ItemLevelUpCount = 20;

		// Token: 0x0402BBE3 RID: 179171
		public const int ItemChestCount = 21;

		// Token: 0x0402BBE4 RID: 179172
		public const int SpriteLowHpBar = 22;

		// Token: 0x0402BBE5 RID: 179173
		public const int PanelKillNum = 23;

		// Token: 0x0402BBE6 RID: 179174
		public const int PanelGoldAdd = 24;

		// Token: 0x0402BBE7 RID: 179175
		public const int PanelRoleInfo = 25;

		// Token: 0x0402BBE8 RID: 179176
		public const int TextureFxGlow = 26;

		// Token: 0x0402BBE9 RID: 179177
		public const int Content = 27;
	}
}
