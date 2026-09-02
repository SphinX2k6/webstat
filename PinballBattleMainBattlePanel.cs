using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D54 RID: 7508
[NullableContext(1)]
[Nullable(0)]
public class PinballBattleMainBattlePanel : BattleChildViewPanel, IStaticVariableResetter
{
	// Token: 0x0600DD2B RID: 56619 RVA: 0x003B6EE5 File Offset: 0x003B50E5
	static PinballBattleMainBattlePanel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballBattleMainBattlePanel.CreateStaticDefaultValue), new Action(PinballBattleMainBattlePanel.ResetStaticDefaultValue));
	}

	// Token: 0x0600DD2C RID: 56620 RVA: 0x003B6F04 File Offset: 0x003B5104
	public static void CreateStaticDefaultValue()
	{
		PinballBattleMainBattlePanel.DashBarRange = new float[]
		{
			0f,
			0.75f
		};
		PinballBattleMainBattlePanel.ComboSeqNames = new string[]
		{
			"Combo_In",
			"Combo_Out",
			"Combo_Up"
		};
	}

	// Token: 0x0600DD2D RID: 56621 RVA: 0x003B6F3C File Offset: 0x003B513C
	public static void ResetStaticDefaultValue()
	{
		PinballBattleMainBattlePanel.DashBarRange = null;
		PinballBattleMainBattlePanel.ComboSeqNames = null;
	}

	// Token: 0x0600DD2E RID: 56622 RVA: 0x003B6F4C File Offset: 0x003B514C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD2F RID: 56623 RVA: 0x003B7214 File Offset: 0x003B5414
	protected override UniTask OnBeforeStartAsync()
	{
		PinballBattleMainBattlePanel.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PinballBattleMainBattlePanel.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DD30 RID: 56624 RVA: 0x003B7258 File Offset: 0x003B5458
	protected override void OnStart()
	{
		this.InitCacheComponent();
		this.InitCountdown();
		this.InitCaption();
		this.InitStarLayout();
		this.InitLevelInfo();
		this.InitLevelSequencePlayer();
		this.BindButtonEvent();
		this.TryBindTeamEntity();
		PinballModel instance = ModelBase<PinballModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SetBattleCenterRootItem(base.GetItem(17));
	}

	// Token: 0x0600DD31 RID: 56625 RVA: 0x003B72AC File Offset: 0x003B54AC
	protected override void OnBeforeDestroy()
	{
		this.UnBindDashAttrDelegate();
		PinballModel instance = ModelBase<PinballModel>.Instance;
		if (instance != null)
		{
			instance.ClearBattleCenterRootItem();
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600DD32 RID: 56626 RVA: 0x003B72D4 File Offset: 0x003B54D4
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		this.RefreshRoleSkillItemList();
		this.RefreshLevelInfo();
		this.RefreshDashButton();
		this.PlaySwitchIn();
	}

	// Token: 0x0600DD33 RID: 56627 RVA: 0x003B72EE File Offset: 0x003B54EE
	public override void OnTickBattleChildViewPanel(float delta)
	{
		this.TickCountdown(delta * Singleton<Time>.Instance.TimeDilation);
		this.RefreshSkillBtnState();
	}

	// Token: 0x0600DD34 RID: 56628 RVA: 0x003B7308 File Offset: 0x003B5508
	private void InitLevelSequencePlayer()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceFinished), false);
	}

	// Token: 0x0600DD35 RID: 56629 RVA: 0x003B7334 File Offset: 0x003B5534
	private void InitCacheComponent()
	{
		this.TimeText = base.GetText(8);
		this.ScoreText = base.GetArtText(9);
		this.ComboNum = base.GetArtText(15);
		this.ScoreProgressBar = base.GetTexture(11);
		this.ComboPanel = base.GetItem(14);
		this.SkillBtn = base.GetButton(6);
	}

	// Token: 0x0600DD36 RID: 56630 RVA: 0x003B7394 File Offset: 0x003B5594
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add<FKSC_HeadHpContext>(EEventName.OnPinballEntityHpChanged, new Action<FKSC_HeadHpContext>(this.OnEntityHpChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPinballScoreChanged, new Action<int>(this.OnScoreChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPinballComboChanged, new Action<int>(this.OnComboChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPinballEntityCreated, new Action<int>(this.OnEntityCreated));
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerCreate, new Action(this.OnPlayerCreate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPinballBattleViewSwitchIn, new Action(this.OnPinballBattleViewSwitchIn));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPinballFirstLaunch, new Action(this.OnFirstLaunch));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPinballFeverChange, new Action<bool>(this.OnFeverChange));
	}

	// Token: 0x0600DD37 RID: 56631 RVA: 0x003B7484 File Offset: 0x003B5684
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballEntityHpChanged, new Action<FKSC_HeadHpContext>(this.OnEntityHpChange));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPinballScoreChanged, new Action<int>(this.OnScoreChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballComboChanged, new Action<int>(this.OnComboChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballEntityCreated, new Action<int>(this.OnEntityCreated));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerCreate, new Action(this.OnPlayerCreate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballBattleViewSwitchIn, new Action(this.OnPinballBattleViewSwitchIn));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballFirstLaunch, new Action(this.OnFirstLaunch));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballFeverChange, new Action<bool>(this.OnFeverChange));
	}

	// Token: 0x0600DD38 RID: 56632 RVA: 0x003B7574 File Offset: 0x003B5774
	private void BindButtonEvent()
	{
		UUIButtonComponent button = base.GetButton(5);
		if (button != null)
		{
			button.OnPointDownCallBack.Bind(new Action(this.OnBtnShootClick));
		}
		UUIButtonComponent button2 = base.GetButton(6);
		if (button2 != null)
		{
			button2.OnPointDownCallBack.Bind(new Action(this.OnBtnDashClick));
		}
		UUIButtonComponent button3 = base.GetButton(18);
		if (button3 != null)
		{
			button3.OnPointDownCallBack.Bind(new Action(this.OnCenterBtnShootClick));
		}
		UUIButtonComponent button4 = base.GetButton(1);
		if (button4 == null)
		{
			return;
		}
		button4.OnPointDownCallBack.Bind(new Action(this.OnBtnResetClick));
	}

	// Token: 0x0600DD39 RID: 56633 RVA: 0x003B760D File Offset: 0x003B580D
	private void OnSequenceFinished(string sequenceName)
	{
		if (sequenceName == "Combo_Out")
		{
			UUIItem comboPanel = this.ComboPanel;
			if (comboPanel == null)
			{
				return;
			}
			comboPanel.SetUIActive(false);
		}
	}

	// Token: 0x0600DD3A RID: 56634 RVA: 0x003B7630 File Offset: 0x003B5830
	private void OnFeverChange(bool isIn)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.PlayOrReplaySequenceByName(isIn ? "Fever_In" : "Fever_Out", false, null);
	}

	// Token: 0x0600DD3B RID: 56635 RVA: 0x003B7666 File Offset: 0x003B5866
	private void OnFirstLaunch()
	{
		this.StartCountdown();
	}

	// Token: 0x0600DD3C RID: 56636 RVA: 0x003B766E File Offset: 0x003B586E
	private void OnPlayerCreate()
	{
		this.RefreshRoleSkillItemList();
	}

	// Token: 0x0600DD3D RID: 56637 RVA: 0x003B7676 File Offset: 0x003B5876
	private void OnEntityCreated(int entityId)
	{
		if (entityId == 10001)
		{
			this.TryBindTeamEntity();
		}
	}

	// Token: 0x0600DD3E RID: 56638 RVA: 0x003B7686 File Offset: 0x003B5886
	private void OnClickRoleSkill(int roleId)
	{
		PinballController instance = ControllerBase<PinballController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.ShowRoleSkillTips(roleId, new Action(this.OnRoleSkillReleaseTipsClose));
	}

	// Token: 0x0600DD3F RID: 56639 RVA: 0x003B76A4 File Offset: 0x003B58A4
	private void OnRoleSkillReleaseTipsClose()
	{
		foreach (PinballBattleRoleSkillItem pinballBattleRoleSkillItem in this.RoleSkillItemList)
		{
			pinballBattleRoleSkillItem.StartClickCooldown();
		}
	}

	// Token: 0x0600DD40 RID: 56640 RVA: 0x003B76F4 File Offset: 0x003B58F4
	private void OnPinballBattleViewSwitchIn()
	{
		this.PlaySwitchIn();
	}

	// Token: 0x0600DD41 RID: 56641 RVA: 0x003B76FC File Offset: 0x003B58FC
	private void PlaySwitchIn()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopSequenceByKey("Switch_Out", false, true);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayOrReplaySequenceByName("Switch_In", false, null);
	}

	// Token: 0x0600DD42 RID: 56642 RVA: 0x003B7740 File Offset: 0x003B5940
	private void OnEntityHpChange(FKSC_HeadHpContext hpContext)
	{
		if (hpContext.HeadUiType == EKSC_HeadUiType.TopBoss)
		{
			PinballBattleBossHpBar bossHpBar = this.BossHpBar;
			if (bossHpBar == null)
			{
				return;
			}
			bossHpBar.Refresh(hpContext);
		}
	}

	// Token: 0x0600DD43 RID: 56643 RVA: 0x003B775C File Offset: 0x003B595C
	private void OnScoreChange(int score)
	{
		PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
		UUIArtText scoreText = this.ScoreText;
		if (scoreText != null)
		{
			scoreText.SetText(score.ToString());
		}
		this.RefreshProgress(((pinballBattleSubModel != null) ? pinballBattleSubModel.LevelScoreTargetList : null) ?? new List<float>(), (float)score);
	}

	// Token: 0x0600DD44 RID: 56644 RVA: 0x003B77B0 File Offset: 0x003B59B0
	private void PlayComboSequence(string name)
	{
		foreach (string text in PinballBattleMainBattlePanel.ComboSeqNames)
		{
			if (text != name)
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer != null)
				{
					seqPlayer.StopSequenceByKey(text, false, true);
				}
			}
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlayOrReplaySequenceByName(name, false, null);
	}

	// Token: 0x0600DD45 RID: 56645 RVA: 0x003B7810 File Offset: 0x003B5A10
	private void OnComboChange(int newValue)
	{
		if (this.LastCombo == 0 && newValue > 0)
		{
			this.PlayComboSequence("Combo_In");
		}
		else if (this.LastCombo > 0 && newValue == 0)
		{
			this.PlayComboSequence("Combo_Out");
		}
		else
		{
			this.PlayComboSequence("Combo_Up");
		}
		this.LastCombo = newValue;
		if (newValue != 0)
		{
			UUIItem comboPanel = this.ComboPanel;
			if (comboPanel != null)
			{
				comboPanel.SetUIActive(true);
			}
			UUIArtText comboNum = this.ComboNum;
			if (comboNum == null)
			{
				return;
			}
			comboNum.SetText(newValue.ToString());
		}
	}

	// Token: 0x0600DD46 RID: 56646 RVA: 0x003B7890 File Offset: 0x003B5A90
	private void OnGameplayCdChanged(float remainTime)
	{
		int num = (int)Math.Floor((double)(remainTime / 1000f));
		int value = (int)Math.Floor((double)num % Singleton<TimeUtil>.Instance.Hour / (double)((float)Singleton<TimeUtil>.Instance.Minute));
		double num2 = (double)num % Singleton<TimeUtil>.Instance.Minute;
		string str = this.FormatTimeUnit(value);
		string str2 = this.FormatTimeUnit((int)num2);
		UUIText timeText = this.TimeText;
		if (timeText == null)
		{
			return;
		}
		timeText.SetText(str + ":" + str2, true);
	}

	// Token: 0x0600DD47 RID: 56647 RVA: 0x003B7908 File Offset: 0x003B5B08
	private string FormatTimeUnit(int value)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
		defaultInterpolatedStringHandler.AppendFormatted((value < 10) ? "0" : "");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600DD48 RID: 56648 RVA: 0x003B7948 File Offset: 0x003B5B48
	private void InitCaption()
	{
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.SetCloseCallBack(delegate
			{
				PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
				if (pinballBattleSubModel == null || pinballBattleSubModel.GameState != 1)
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballBattlePauseView, new PinballBattlePauseViewParam
				{
					LevelId = pinballBattleSubModel.LevelId
				}, null);
			});
		}
		int curLevelConfigId = ModelBase<PinballModel>.Instance.CurLevelConfigId;
		PinballConfig instance = ConfigBase<PinballConfig>.Instance;
		PinballLevelConfig? pinballLevelConfig = (instance != null) ? instance.GetPinballLevelConfigById(curLevelConfigId) : null;
		PopupCaptionItem caption2 = this.Caption;
		if (caption2 == null)
		{
			return;
		}
		caption2.SetTitleLocalText(((pinballLevelConfig != null) ? pinballLevelConfig.GetValueOrDefault().Name : null) ?? "");
	}

	// Token: 0x0600DD49 RID: 56649 RVA: 0x003B79E0 File Offset: 0x003B5BE0
	private void InitLevelInfo()
	{
		int curLevelId = ModelBase<PinballModel>.Instance.CurLevelId;
		PinballConfig instance = ConfigBase<PinballConfig>.Instance;
		PinballLevelConfig? pinballLevelConfig = (instance != null) ? instance.GetPinballLevelConfigById(curLevelId) : null;
		this.IsCowLevel = (pinballLevelConfig != null && pinballLevelConfig.GetValueOrDefault().Type == 2);
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.IsCowLevel);
	}

	// Token: 0x0600DD4A RID: 56650 RVA: 0x003B7A50 File Offset: 0x003B5C50
	private void RefreshProgress(List<float> scoreTargetList, float curScore)
	{
		if (!this.IsCowLevel)
		{
			return;
		}
		int count = scoreTargetList.Count;
		if (count == 0)
		{
			UUITexture scoreProgressBar = this.ScoreProgressBar;
			if (scoreProgressBar == null)
			{
				return;
			}
			scoreProgressBar.SetFillAmount(0f);
			return;
		}
		else
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < count; i++)
			{
				float num3 = (i == 0) ? 0f : scoreTargetList[i - 1];
				float num4 = scoreTargetList[i];
				if (curScore >= num4)
				{
					num += 1f / (float)count;
				}
				else if (curScore > num3)
				{
					float num5 = 428f / (float)count - 50f;
					float num6 = (curScore - num3) / ((num4 - num3 != 0f) ? (num4 - num3) : 1f);
					num2 = num5 * num6 / 428f;
					break;
				}
			}
			UUITexture scoreProgressBar2 = this.ScoreProgressBar;
			if (scoreProgressBar2 != null)
			{
				scoreProgressBar2.SetFillAmount(num + num2);
			}
			List<bool> list = new List<bool>();
			for (int j = 0; j < count; j++)
			{
				list.Add(curScore >= scoreTargetList[j]);
			}
			GenericLayout<PinballBattleStarItem, bool> starLayout = this.StarLayout;
			if (starLayout == null)
			{
				return;
			}
			starLayout.RefreshByData(list, null, false);
			return;
		}
	}

	// Token: 0x0600DD4B RID: 56651 RVA: 0x003B7B64 File Offset: 0x003B5D64
	private void RefreshDashButton()
	{
		this.RefreshSkillBtnState();
		this.UpdateDashSkillBar();
	}

	// Token: 0x0600DD4C RID: 56652 RVA: 0x003B7B74 File Offset: 0x003B5D74
	private void RefreshLevelInfo()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		this.OnGameplayCdChanged(this.LevelCountdownTimer);
		PinballBattleSubModel pinballBattleSubModel = (pinballBattleSubController != null) ? pinballBattleSubController.GetModel() : null;
		float curScore = (pinballBattleSubModel != null) ? pinballBattleSubModel.Score : 0f;
		UUIArtText scoreText = this.ScoreText;
		if (scoreText != null)
		{
			scoreText.SetText(curScore.ToString());
		}
		this.RefreshProgress(((pinballBattleSubModel != null) ? pinballBattleSubModel.LevelScoreTargetList : null) ?? new List<float>(), curScore);
	}

	// Token: 0x0600DD4D RID: 56653 RVA: 0x003B7BEE File Offset: 0x003B5DEE
	private void InitStarLayout()
	{
		this.StarLayout = new GenericLayout<PinballBattleStarItem, bool>(base.GetLayoutBase(12), new Func<PinballBattleStarItem>(this.CreateStarItem), base.GetItem(13).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600DD4E RID: 56654 RVA: 0x003B7C23 File Offset: 0x003B5E23
	private PinballBattleStarItem CreateStarItem()
	{
		return new PinballBattleStarItem();
	}

	// Token: 0x0600DD4F RID: 56655 RVA: 0x003B7C2C File Offset: 0x003B5E2C
	public void RefreshRoleSkillItemList()
	{
		PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
		List<PinballFormationRolePb> list = (pinballBattleSubModel != null) ? pinballBattleSubModel.PreloadFormationData : null;
		List<int> list2 = new List<int>();
		if (list != null)
		{
			foreach (PinballFormationRolePb pinballFormationRolePb in list)
			{
				list2.Add(pinballFormationRolePb.RoleId);
			}
		}
		for (int i = 0; i < this.RoleSkillItemList.Count; i++)
		{
			PinballBattleRoleSkillItem pinballBattleRoleSkillItem = this.RoleSkillItemList[i];
			if (i < list2.Count)
			{
				pinballBattleRoleSkillItem.Refresh(list2[i]);
			}
			else
			{
				pinballBattleRoleSkillItem.Refresh(-1);
			}
		}
	}

	// Token: 0x0600DD50 RID: 56656 RVA: 0x003B7CF0 File Offset: 0x003B5EF0
	private void OnCenterBtnShootClick()
	{
		if (Singleton<Info>.Instance.IsInKeyBoard() && (Singleton<InputSettings>.Instance.IsInputKeyDown("RightMouseButton") || !Singleton<InputSettings>.Instance.IsInputKeyDown("LeftMouseButton")))
		{
			return;
		}
		this.OnBtnShootClick();
	}

	// Token: 0x0600DD51 RID: 56657 RVA: 0x003B7D28 File Offset: 0x003B5F28
	private void OnBtnShootClick()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		if (pinballBattleSubController == null)
		{
			return;
		}
		pinballBattleSubController.OnInputTriggerBar();
	}

	// Token: 0x0600DD52 RID: 56658 RVA: 0x003B7D4F File Offset: 0x003B5F4F
	private bool CanUseDashSkill(PinballBattleSubController subController)
	{
		if (this.CanEnableDashSkill(subController) && Singleton<Time>.Instance.TimeDilation != 0f)
		{
			PinballBattleLaunchPhaseController launchPhaseController = subController.LaunchPhaseController;
			return launchPhaseController == null || !launchPhaseController.IsActive();
		}
		return false;
	}

	// Token: 0x0600DD53 RID: 56659 RVA: 0x003B7D84 File Offset: 0x003B5F84
	private bool CanEnableDashSkill(PinballBattleSubController subController)
	{
		if (this.OwnerAttrSet == null || subController == null)
		{
			return false;
		}
		float? dashNeedCost = subController.GetDashNeedCost();
		return dashNeedCost != null && (float)this.OwnerAttrSet.Attrs_.GetValueOrNull(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashAttrType).GetValueOrDefault() >= dashNeedCost.Value && !subController.IsInDashCd();
	}

	// Token: 0x0600DD54 RID: 56660 RVA: 0x003B7DE4 File Offset: 0x003B5FE4
	private void OnBtnDashClick()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		if (!this.CanUseDashSkill(pinballBattleSubController))
		{
			return;
		}
		pinballBattleSubController.OnInputUseTeamSkill(1);
	}

	// Token: 0x0600DD55 RID: 56661 RVA: 0x003B7E14 File Offset: 0x003B6014
	private void OnBtnResetClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PinballBattleResetLaunchConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
			if (pinballBattleSubController == null)
			{
				return;
			}
			pinballBattleSubController.ReadyLaunch();
		};
		ControllerBase<PinballController>.Instance.OpenPinballSmallConfirmBoxView(confirmBoxDataNew);
	}

	// Token: 0x0600DD56 RID: 56662 RVA: 0x003B7E64 File Offset: 0x003B6064
	private void TryBindTeamEntity()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		AKSC_Shape2D_Entity_TeamPlayer aksc_Shape2D_Entity_TeamPlayer = (pinballBattleSubController != null) ? pinballBattleSubController.KscTeamPlayer : null;
		if (aksc_Shape2D_Entity_TeamPlayer != null)
		{
			this.BindTeamEntity(aksc_Shape2D_Entity_TeamPlayer);
		}
	}

	// Token: 0x0600DD57 RID: 56663 RVA: 0x003B7E98 File Offset: 0x003B6098
	private void BindTeamEntity(AKSC_Entity entity)
	{
		UKSC_SkillComp skillComp_ = entity.SkillComp_;
		UKSC_AttrSet uksc_AttrSet = (skillComp_ != null) ? skillComp_.AttrSet_ : null;
		if (uksc_AttrSet == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PinballBattle;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("实体没有属性组件！EntityId：");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entity.EntityId_);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.BindDashAttrDelegate(uksc_AttrSet);
		this.UpdateDashSkillBar();
	}

	// Token: 0x0600DD58 RID: 56664 RVA: 0x003B7F10 File Offset: 0x003B6110
	private void UpdateDashSkillBar()
	{
		UKSC_AttrSet ownerAttrSet = this.OwnerAttrSet;
		int? num;
		if (ownerAttrSet == null)
		{
			num = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_ = ownerAttrSet.Attrs_;
			num = ((attrs_ != null) ? attrs_.GetValueOrNull(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashAttrType) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		UKSC_AttrSet ownerAttrSet2 = this.OwnerAttrSet;
		int? num3;
		if (ownerAttrSet2 == null)
		{
			num3 = null;
		}
		else
		{
			TMap<EKSC_AttrType, int> attrs_2 = ownerAttrSet2.Attrs_;
			num3 = ((attrs_2 != null) ? attrs_2.GetValueOrNull(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashMaxAttrType) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault(1);
		UUISprite sprite = base.GetSprite(7);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(Singleton<MathUtils>.Instance.Lerp(PinballBattleMainBattlePanel.DashBarRange[0], PinballBattleMainBattlePanel.DashBarRange[1], (float)valueOrDefault / (float)valueOrDefault2));
	}

	// Token: 0x0600DD59 RID: 56665 RVA: 0x003B7FC4 File Offset: 0x003B61C4
	public void BindDashAttrDelegate(UKSC_AttrSet attrSet)
	{
		this.UnBindDashAttrDelegate();
		this.DelegateDashChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnDashChange));
		attrSet.AssignAttrListen(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashAttrType, this.DelegateDashChange);
		attrSet.AssignAttrListen(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashMaxAttrType, this.DelegateDashChange);
		this.OwnerAttrSet = attrSet;
	}

	// Token: 0x0600DD5A RID: 56666 RVA: 0x003B8018 File Offset: 0x003B6218
	public void UnBindDashAttrDelegate()
	{
		if (this.OwnerAttrSet != null)
		{
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashAttrType, this.DelegateDashChange);
			this.OwnerAttrSet.RemoveAttrListen(<PinballBattleMainBattlePanel>F772434047A5E50B2FEB074B57BC5725D5E34FDAF48B4430A6DFD676C7BF630E6__MainBattleConst.DashMaxAttrType, this.DelegateDashChange);
			this.OwnerAttrSet = null;
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnDashChange));
			this.DelegateDashChange = null;
		}
	}

	// Token: 0x0600DD5B RID: 56667 RVA: 0x003B8078 File Offset: 0x003B6278
	private void OnDashChange(EKSC_AttrType attrType, int value)
	{
		this.UpdateDashSkillBar();
	}

	// Token: 0x0600DD5C RID: 56668 RVA: 0x003B8080 File Offset: 0x003B6280
	private void RefreshSkillBtnState()
	{
		PinballBattleSubController pinballBattleSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController as PinballBattleSubController;
		bool flag = pinballBattleSubController != null && this.CanEnableDashSkill(pinballBattleSubController);
		if (flag != this.LastCanUseDash)
		{
			this.LastCanUseDash = flag;
			UUIButtonComponent skillBtn = this.SkillBtn;
			if (skillBtn == null)
			{
				return;
			}
			skillBtn.SetSelfInteractive(flag);
		}
	}

	// Token: 0x0600DD5D RID: 56669 RVA: 0x003B80CC File Offset: 0x003B62CC
	private void InitCountdown()
	{
		int curLevelId = ModelBase<PinballModel>.Instance.CurLevelId;
		PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(curLevelId);
		if (pinballLevelConfigById == null)
		{
			return;
		}
		this.LevelCountdownTimer = (float)(pinballLevelConfigById.Value.LevelTime * 1000);
	}

	// Token: 0x0600DD5E RID: 56670 RVA: 0x003B8116 File Offset: 0x003B6316
	private void StartCountdown()
	{
		this.IsCountdownStart = true;
		this.OnGameplayCdChanged(this.LevelCountdownTimer);
	}

	// Token: 0x0600DD5F RID: 56671 RVA: 0x003B812C File Offset: 0x003B632C
	private void TickCountdown(float delta)
	{
		if (delta == 0f || !this.IsCountdownStart)
		{
			return;
		}
		this.LevelCountdownTimer -= delta;
		this.TickTimer += delta;
		if (this.TickTimer < 1000f)
		{
			return;
		}
		this.TickTimer = 0f;
		if (this.LevelCountdownTimer <= 0f)
		{
			this.IsCountdownStart = false;
			this.OnGameplayCdChanged(0f);
			return;
		}
		this.OnGameplayCdChanged(this.LevelCountdownTimer);
	}

	// Token: 0x0600DD60 RID: 56672 RVA: 0x003B81AC File Offset: 0x003B63AC
	public void PlaySequence(string name)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.PlayOrReplaySequenceByName(name, false, null);
	}

	// Token: 0x04006A12 RID: 27154
	[Nullable(2)]
	private static float[] DashBarRange;

	// Token: 0x04006A13 RID: 27155
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static string[] ComboSeqNames;

	// Token: 0x04006A14 RID: 27156
	[Nullable(2)]
	private PopupCaptionItem Caption;

	// Token: 0x04006A15 RID: 27157
	private readonly List<PinballBattleRoleSkillItem> RoleSkillItemList = new List<PinballBattleRoleSkillItem>();

	// Token: 0x04006A16 RID: 27158
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PinballBattleStarItem, bool> StarLayout;

	// Token: 0x04006A17 RID: 27159
	[Nullable(2)]
	private PinballBattleBossHpBar BossHpBar;

	// Token: 0x04006A18 RID: 27160
	[Nullable(2)]
	private UUIText TimeText;

	// Token: 0x04006A19 RID: 27161
	[Nullable(2)]
	private UUIArtText ScoreText;

	// Token: 0x04006A1A RID: 27162
	[Nullable(2)]
	private UUIArtText ComboNum;

	// Token: 0x04006A1B RID: 27163
	[Nullable(2)]
	private UUIItem ComboPanel;

	// Token: 0x04006A1C RID: 27164
	[Nullable(2)]
	private UUITexture ScoreProgressBar;

	// Token: 0x04006A1D RID: 27165
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04006A1E RID: 27166
	[Nullable(2)]
	private UKSC_AttrSet OwnerAttrSet;

	// Token: 0x04006A1F RID: 27167
	[Nullable(2)]
	private FOnKSCAttrChange DelegateDashChange;

	// Token: 0x04006A20 RID: 27168
	private bool LastCanUseDash = true;

	// Token: 0x04006A21 RID: 27169
	private bool IsCowLevel;

	// Token: 0x04006A22 RID: 27170
	private int LastCombo;

	// Token: 0x04006A23 RID: 27171
	[Nullable(2)]
	private UUIButtonComponent SkillBtn;

	// Token: 0x04006A24 RID: 27172
	private float LevelCountdownTimer;

	// Token: 0x04006A25 RID: 27173
	private bool IsCountdownStart;

	// Token: 0x04006A26 RID: 27174
	private float TickTimer;
}
