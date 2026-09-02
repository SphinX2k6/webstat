using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D7B RID: 7547
[NullableContext(2)]
[Nullable(0)]
public class SpringManorMainHudPanel : BattleChildViewPanel
{
	// Token: 0x0600DDE6 RID: 56806 RVA: 0x003BA8B0 File Offset: 0x003B8AB0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIArtText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickExit)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickSetting)),
			new ValueTuple<int, Delegate>(19, new Action(this.OnClickAtmosphere)),
			new ValueTuple<int, Delegate>(24, new Action(this.OnClickOpenPhotograph)),
			new ValueTuple<int, Delegate>(25, new Action(this.OnClickRoleSwitch))
		};
	}

	// Token: 0x0600DDE7 RID: 56807 RVA: 0x003BABF8 File Offset: 0x003B8DF8
	protected override UniTask OnBeforeStartAsync()
	{
		SpringManorMainHudPanel.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpringManorMainHudPanel.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDE8 RID: 56808 RVA: 0x003BAC3C File Offset: 0x003B8E3C
	protected override void OnStart()
	{
		this.InitializeBattleViewPanel();
		this.InitializeFunctionButtonMap();
		this.TimeTipsItem = base.GetItem(15);
		this.TimeTipsText = base.GetText(16);
		this.AtmosphereProgressBar = base.GetSlider(8);
		this.AtmosphereSeqPlayer = new LevelSequencePlayer(base.GetItem(20));
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600DDE9 RID: 56809 RVA: 0x003BACA2 File Offset: 0x003B8EA2
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer atmosphereSeqPlayer = this.AtmosphereSeqPlayer;
		if (atmosphereSeqPlayer == null)
		{
			return;
		}
		atmosphereSeqPlayer.Clear();
	}

	// Token: 0x0600DDEA RID: 56810 RVA: 0x003BACB4 File Offset: 0x003B8EB4
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorFunctionOpenNotify, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorAtmosphereUpdate, new Action(this.OnAtmosphereUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorTaskUpdateNotify, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add<TQuest>(EEventName.OnAddNewQuest, new Action<TQuest>(this.AddNewQuest));
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FurnitureEntranceRedDot, base.GetItem(22), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.SpringManorGameEntrance, base.GetItem(21), null, 0);
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData != null)
		{
			childViewData.AddCallback(EBattleUiChild.SpringManorHud, new Action(this.OnBattleViewChildVisibleChanged));
		}
		BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData2 == null)
		{
			return;
		}
		childViewData2.AddCallback(EBattleUiChild.Mission, new Action(this.RefreshMissionRootPanelVisible));
	}

	// Token: 0x0600DDEB RID: 56811 RVA: 0x003BADA8 File Offset: 0x003B8FA8
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorFunctionOpenNotify, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorAtmosphereUpdate, new Action(this.OnAtmosphereUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorTaskUpdateNotify, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddNewQuest, new Action<TQuest>(this.AddNewQuest));
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.FurnitureEntranceRedDot);
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.SpringManorGameEntrance);
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData != null)
		{
			childViewData.RemoveCallback(EBattleUiChild.SpringManorHud, new Action(this.OnBattleViewChildVisibleChanged));
		}
		BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData2 == null)
		{
			return;
		}
		childViewData2.RemoveCallback(EBattleUiChild.Mission, new Action(this.RefreshMissionRootPanelVisible));
	}

	// Token: 0x0600DDEC RID: 56812 RVA: 0x003BAE88 File Offset: 0x003B9088
	private void OnBattleViewChildVisibleChanged()
	{
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		bool? flag = (childViewData != null) ? new bool?(childViewData.GetChildVisible(EBattleUiChild.SpringManorHud)) : null;
		UUIItem item = base.GetItem(27);
		if (item != null)
		{
			item.SetUIActive(flag.GetValueOrDefault());
		}
		UUIItem item2 = base.GetItem(28);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(flag.GetValueOrDefault());
	}

	// Token: 0x0600DDED RID: 56813 RVA: 0x003BAEF0 File Offset: 0x003B90F0
	private void RefreshMissionRootPanelVisible()
	{
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		bool? flag = (childViewData != null) ? new bool?(childViewData.GetChildVisible(EBattleUiChild.Mission)) : null;
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(flag.GetValueOrDefault());
	}

	// Token: 0x0600DDEE RID: 56814 RVA: 0x003BAF3B File Offset: 0x003B913B
	private void OnAtmosphereUpdate()
	{
		this.RefreshAtmosphere();
		this.RefreshRedDot();
	}

	// Token: 0x0600DDEF RID: 56815 RVA: 0x003BAF49 File Offset: 0x003B9149
	[NullableContext(1)]
	private void AddNewQuest(TQuest quest)
	{
		this.OnActivityUpdate();
	}

	// Token: 0x0600DDF0 RID: 56816 RVA: 0x003BAF51 File Offset: 0x003B9151
	private void OnActivityUpdate()
	{
		this.RefreshAtmosphere();
		this.RefreshFunctionButtonVisible();
		this.RefreshRedDot();
	}

	// Token: 0x0600DDF1 RID: 56817 RVA: 0x003BAF68 File Offset: 0x003B9168
	private void RefreshRedDot()
	{
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		bool? flag;
		if (instance == null)
		{
			flag = null;
		}
		else
		{
			SpringManorData activityData = instance.ActivityData;
			flag = ((activityData != null) ? new bool?(activityData.HasAtmosphereRedDot()) : null);
		}
		bool? flag2 = flag;
		bool valueOrDefault = flag2.GetValueOrDefault();
		UUIItem item = base.GetItem(26);
		if (item != null)
		{
			item.SetUIActive(valueOrDefault);
		}
		SpringManorModel instance2 = ModelBase<SpringManorModel>.Instance;
		bool? flag3;
		if (instance2 == null)
		{
			flag3 = null;
		}
		else
		{
			SpringManorData activityData2 = instance2.ActivityData;
			flag3 = ((activityData2 != null) ? new bool?(activityData2.HasRewardRedDot()) : null);
		}
		flag2 = flag3;
		bool valueOrDefault2 = flag2.GetValueOrDefault();
		UUIItem item2 = base.GetItem(23);
		if (item2 != null)
		{
			item2.SetUIActive(valueOrDefault2);
		}
		SpringManorQuestButton questButton = this.QuestButton;
		if (questButton == null)
		{
			return;
		}
		questButton.RefreshRedDot();
	}

	// Token: 0x0600DDF2 RID: 56818 RVA: 0x003BB023 File Offset: 0x003B9223
	private void InitializeBattleViewPanel()
	{
		this.Visible = true;
		base.ShowBattleChildViewPanel();
	}

	// Token: 0x0600DDF3 RID: 56819 RVA: 0x003BB034 File Offset: 0x003B9234
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		TrackedMarksView trackPanel = this.TrackPanel;
		if (trackPanel != null)
		{
			trackPanel.OnShowBattleChildViewPanel();
		}
		MissionPanel missionPanel = this.MissionPanel;
		if (missionPanel != null)
		{
			missionPanel.ShowBattleChildViewPanel();
		}
		this.RefreshMissionRootPanelVisible();
		this.SetBattleChildViewPanelVisible(true);
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		if (((instance != null) ? instance.ActivityData : null) != null)
		{
			this.OnActivityUpdate();
		}
		else
		{
			Singleton<EventSystem>.Instance.Once(EEventName.OnActivityUpdate, new Action(this.OnActivityUpdate));
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 != null)
		{
			seqPlayer2.PlaySequencePurely(isFirst ? "Start" : "ShowView", false, false, null, null, false);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFurnitureEntranceRedDot);
		this.AddEventListener();
	}

	// Token: 0x0600DDF4 RID: 56820 RVA: 0x003BB100 File Offset: 0x003B9300
	protected override void OnHideBattleChildViewPanel()
	{
		TrackedMarksView trackPanel = this.TrackPanel;
		if (trackPanel != null)
		{
			trackPanel.OnHideBattleChildViewPanel();
		}
		MissionPanel missionPanel = this.MissionPanel;
		if (missionPanel != null)
		{
			missionPanel.HideBattleChildViewPanel();
		}
		this.SetBattleChildViewPanelVisible(false);
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 != null)
		{
			seqPlayer2.PlaySequencePurely("Close", false, false, null, null, false);
		}
		this.ClearTweener();
		this.RemoveEventListener();
	}

	// Token: 0x0600DDF5 RID: 56821 RVA: 0x003BB178 File Offset: 0x003B9378
	public override void OnTickBattleChildViewPanel(float delta)
	{
		this.CheckMissionTrack();
		MissionPanel missionPanel = this.MissionPanel;
		if (missionPanel != null)
		{
			missionPanel.OnTickBattleChildViewPanel(delta);
		}
		this.RefreshTimeText();
	}

	// Token: 0x0600DDF6 RID: 56822 RVA: 0x003BB198 File Offset: 0x003B9398
	public override void Reset()
	{
		MissionPanel missionPanel = this.MissionPanel;
		if (missionPanel == null)
		{
			return;
		}
		missionPanel.Reset();
	}

	// Token: 0x0600DDF7 RID: 56823 RVA: 0x003BB1AA File Offset: 0x003B93AA
	public override void OnAfterTickBattleChildViewPanel(float delta)
	{
		TrackedMarksView trackPanel = this.TrackPanel;
		if (trackPanel == null)
		{
			return;
		}
		trackPanel.Update(delta);
	}

	// Token: 0x0600DDF8 RID: 56824 RVA: 0x003BB1C0 File Offset: 0x003B93C0
	private void SetBattleChildViewPanelVisible(bool visible)
	{
		foreach (EBattleUiChild childType in SpringManorMainHudPanel.controlBattleChildUiChildList)
		{
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.SetChildVisible(EBattleUiVisibleReason.Default, childType, visible, true, 0);
			}
		}
	}

	// Token: 0x0600DDF9 RID: 56825 RVA: 0x003BB200 File Offset: 0x003B9400
	private UniTask NewFullScreenPanel()
	{
		SpringManorMainHudPanel.<NewFullScreenPanel>d__32 <NewFullScreenPanel>d__;
		<NewFullScreenPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewFullScreenPanel>d__.<>4__this = this;
		<NewFullScreenPanel>d__.<>1__state = -1;
		<NewFullScreenPanel>d__.<>t__builder.Start<SpringManorMainHudPanel.<NewFullScreenPanel>d__32>(ref <NewFullScreenPanel>d__);
		return <NewFullScreenPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDFA RID: 56826 RVA: 0x003BB244 File Offset: 0x003B9444
	private UniTask NewTrackedMarksView()
	{
		SpringManorMainHudPanel.<NewTrackedMarksView>d__33 <NewTrackedMarksView>d__;
		<NewTrackedMarksView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewTrackedMarksView>d__.<>4__this = this;
		<NewTrackedMarksView>d__.<>1__state = -1;
		<NewTrackedMarksView>d__.<>t__builder.Start<SpringManorMainHudPanel.<NewTrackedMarksView>d__33>(ref <NewTrackedMarksView>d__);
		return <NewTrackedMarksView>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDFB RID: 56827 RVA: 0x003BB288 File Offset: 0x003B9488
	private UniTask NewMissionPanel()
	{
		SpringManorMainHudPanel.<NewMissionPanel>d__34 <NewMissionPanel>d__;
		<NewMissionPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewMissionPanel>d__.<>4__this = this;
		<NewMissionPanel>d__.<>1__state = -1;
		<NewMissionPanel>d__.<>t__builder.Start<SpringManorMainHudPanel.<NewMissionPanel>d__34>(ref <NewMissionPanel>d__);
		return <NewMissionPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DDFC RID: 56828 RVA: 0x003BB2CB File Offset: 0x003B94CB
	public void SetTipsVisible(bool visible)
	{
		UUIItem timeTipsItem = this.TimeTipsItem;
		if (timeTipsItem == null)
		{
			return;
		}
		timeTipsItem.SetUIActive(visible);
	}

	// Token: 0x0600DDFD RID: 56829 RVA: 0x003BB2E0 File Offset: 0x003B94E0
	[NullableContext(1)]
	public void SetTipsText(string str)
	{
		string newText = StringUtils.Format(this.TimeLimitString, new string[]
		{
			str
		});
		UUIText timeTipsText = this.TimeTipsText;
		if (timeTipsText == null)
		{
			return;
		}
		timeTipsText.SetText(newText, true);
	}

	// Token: 0x0600DDFE RID: 56830 RVA: 0x003BB318 File Offset: 0x003B9518
	private void RefreshTimeText()
	{
		if (this.CurrentTraceMainQuestId != 0 || ModelBase<SpringManorModel>.Instance.CheckMainQuestIsFinished())
		{
			this.SetTipsVisible(false);
			return;
		}
		int needTraceMainQuestId = this.GetNeedTraceMainQuestId();
		string mainQuestRemainTimeText = ModelBase<SpringManorModel>.Instance.GetMainQuestRemainTimeText(needTraceMainQuestId, null);
		this.SetTipsVisible(mainQuestRemainTimeText != null);
		if (mainQuestRemainTimeText != null)
		{
			this.SetTipsText(mainQuestRemainTimeText);
		}
	}

	// Token: 0x0600DDFF RID: 56831 RVA: 0x003BB36C File Offset: 0x003B956C
	private int GetNeedTraceMainQuestId()
	{
		return ModelBase<SpringManorModel>.Instance.GetMainQuestId().GetValueOrDefault();
	}

	// Token: 0x0600DE00 RID: 56832 RVA: 0x003BB38C File Offset: 0x003B958C
	public void CheckMissionTrack()
	{
		int needTraceMainQuestId = this.GetNeedTraceMainQuestId();
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		int num = needTraceMainQuestId;
		int? num2 = (curTrackedQuest != null) ? new int?(curTrackedQuest.Id) : null;
		if (num == num2.GetValueOrDefault() & num2 != null)
		{
			this.CurrentTraceMainQuestId = needTraceMainQuestId;
			return;
		}
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(needTraceMainQuestId);
		if (quest == null || quest.IsSuspend())
		{
			if (curTrackedQuest != null)
			{
				ControllerBase<QuestNewController>.Instance.RequestTrackQuest(curTrackedQuest.Id, false, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
			}
			this.CurrentTraceMainQuestId = 0;
			return;
		}
		this.CurrentTraceMainQuestId = needTraceMainQuestId;
		ControllerBase<QuestNewController>.Instance.RequestTrackQuest(needTraceMainQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
		Singleton<EventSystem>.Instance.Emit<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, quest.Tree.BtType, new long?(quest.Tree.TreeIncId));
	}

	// Token: 0x0600DE01 RID: 56833 RVA: 0x003BB45C File Offset: 0x003B965C
	private void PlayAtmosphereStageUpAnimation()
	{
		if (this.AtmosphereStageUpParam == null)
		{
			return;
		}
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		int atmosphere = instance.ActivityData.GetAtmosphere();
		int nextLevel = instance.GetNextLevel();
		int levelNeedExp = instance.GetLevelNeedExp(nextLevel);
		this.RefreshAtmosphereProgressText(this.AtmosphereStageUpParam.OldLevel, atmosphere, levelNeedExp);
		int oldLevel = this.AtmosphereStageUpParam.OldLevel;
		AtmosphereLevel? levelConfigById = ConfigBase<SpringManorConfig>.Instance.GetLevelConfigById(oldLevel);
		if (levelConfigById == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SpringManor;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取不到等级配置！");
			defaultInterpolatedStringHandler.AppendFormatted<int>(oldLevel);
			instance2.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float startValue = Singleton<MathUtils>.Instance.Clamp((float)((this.AtmosphereStageUpParam.OldAtmosphere - levelConfigById.Value.AtmosphereNeed) / levelConfigById.Value.AtmosphereNext), 0f, 1f);
		this.AtmosphereTweener = ULTweenBPLibrary.FloatTo(this.RootActor, global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.OnAtmosphereStageUpAnimationChange)), startValue, 1f, 1f, 0f, LTweenEase.OutCubic);
		this.AtmosphereTweener.OnCompleteCallBack.Bind(new Action(this.OnAtmosphereStageUpAnimationCompleted));
	}

	// Token: 0x0600DE02 RID: 56834 RVA: 0x003BB59B File Offset: 0x003B979B
	private void OnAtmosphereStageUpAnimationChange(float value)
	{
		UUISliderComponent atmosphereProgressBar = this.AtmosphereProgressBar;
		if (atmosphereProgressBar == null)
		{
			return;
		}
		atmosphereProgressBar.SetValue(value, true);
	}

	// Token: 0x0600DE03 RID: 56835 RVA: 0x003BB5B0 File Offset: 0x003B97B0
	private void OnAtmosphereStageUpAnimationCompleted()
	{
		this.ClearTweener();
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		int atmosphereLevel = instance.GetAtmosphereLevel();
		UUIArtText artText = base.GetArtText(6);
		if (artText != null)
		{
			artText.SetText(atmosphereLevel.ToString());
		}
		this.PlayAtmosphereStageUpBgAnimation(this.AtmosphereStageUpParam.Stage);
		int atmosphere = instance.ActivityData.GetAtmosphere();
		SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
		AtmosphereLevel? atmosphereLevel2 = (instance2 != null) ? instance2.GetLevelConfigById(atmosphereLevel) : null;
		if (atmosphereLevel2 == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SpringManor;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取不到等级配置！");
			defaultInterpolatedStringHandler.AppendFormatted<int>(atmosphereLevel);
			instance3.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float endValue = Singleton<MathUtils>.Instance.Clamp((float)((atmosphere - atmosphereLevel2.Value.AtmosphereNeed) / atmosphereLevel2.Value.AtmosphereNext), 0f, 1f);
		this.AtmosphereTweener = ULTweenBPLibrary.FloatTo(this.RootActor, global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.OnAtmosphereStageUpAnimationChange)), 0f, endValue, 1f, 0f, LTweenEase.OutCubic);
		this.AtmosphereTweener.OnCompleteCallBack.Bind(new Action(this.ClearTweener));
	}

	// Token: 0x0600DE04 RID: 56836 RVA: 0x003BB6F4 File Offset: 0x003B98F4
	private void PlayAtmosphereStageUpBgAnimation(int stage)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(stage == 1 || stage == 2);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(stage == 2 || stage == 3);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 != null)
		{
			item3.SetUIActive(stage == 3);
		}
		if (stage > 1)
		{
			string sequenceName = SpringManorDefine.atmosphereLevelUpSeqName[stage - 2];
			LevelSequencePlayer atmosphereSeqPlayer = this.AtmosphereSeqPlayer;
			if (atmosphereSeqPlayer != null)
			{
				atmosphereSeqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer atmosphereSeqPlayer2 = this.AtmosphereSeqPlayer;
			if (atmosphereSeqPlayer2 != null)
			{
				atmosphereSeqPlayer2.PlaySequencePurely(sequenceName, false, false, null, null, false);
			}
		}
		LevelSequencePlayer atmosphereSeqPlayer3 = this.AtmosphereSeqPlayer;
		if (atmosphereSeqPlayer3 == null)
		{
			return;
		}
		atmosphereSeqPlayer3.PlaySequencePurely("NumChange", false, false, null, null, false);
	}

	// Token: 0x0600DE05 RID: 56837 RVA: 0x003BB7B7 File Offset: 0x003B99B7
	private void ClearTweener()
	{
		if (this.AtmosphereTweener != null)
		{
			this.AtmosphereTweener.Kill(false);
			this.AtmosphereTweener = null;
		}
	}

	// Token: 0x0600DE06 RID: 56838 RVA: 0x003BB7D4 File Offset: 0x003B99D4
	public void RefreshAtmosphere()
	{
		if (this.AtmosphereTweener != null)
		{
			this.ClearTweener();
		}
		AtmosphereStageUpParam atmosphereStageUpParam = ModelBase<SpringManorModel>.Instance.GetAtmosphereStageUpParam();
		if (atmosphereStageUpParam != null)
		{
			this.AtmosphereStageUpParam = atmosphereStageUpParam;
			this.PlayAtmosphereStageUpAnimation();
			return;
		}
		SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
		int atmosphereLevel = instance.GetAtmosphereLevel();
		int atmosphere = instance.ActivityData.GetAtmosphere();
		int nextLevel = instance.GetNextLevel();
		int levelNeedExp = instance.GetLevelNeedExp(nextLevel);
		int atmosphereLevelStage = instance.GetAtmosphereLevelStage(atmosphereLevel);
		this.RefreshPassBg(atmosphereLevelStage);
		this.RefreshAtmosphereProgressText(atmosphereLevel, atmosphere, levelNeedExp);
		SpringManorConfig instance2 = ConfigBase<SpringManorConfig>.Instance;
		AtmosphereLevel? atmosphereLevel2 = (instance2 != null) ? instance2.GetLevelConfigById(atmosphereLevel) : null;
		if (atmosphereLevel2 == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SpringManor;
			ELogAuthor author = ELogAuthor.LJ;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取不到等级配置！");
			defaultInterpolatedStringHandler.AppendFormatted<int>(atmosphereLevel);
			instance3.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float inValue = Singleton<MathUtils>.Instance.Clamp((float)((atmosphere - atmosphereLevel2.Value.AtmosphereNeed) / atmosphereLevel2.Value.AtmosphereNext), 0f, 1f);
		UUISliderComponent atmosphereProgressBar = this.AtmosphereProgressBar;
		if (atmosphereProgressBar == null)
		{
			return;
		}
		atmosphereProgressBar.SetValue(inValue, true);
	}

	// Token: 0x0600DE07 RID: 56839 RVA: 0x003BB904 File Offset: 0x003B9B04
	public void RefreshPassBg(int stage)
	{
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(stage == 1);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(stage == 2);
		}
		UUIItem item3 = base.GetItem(5);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(stage == 3);
	}

	// Token: 0x0600DE08 RID: 56840 RVA: 0x003BB954 File Offset: 0x003B9B54
	public void RefreshAtmosphereProgressText(int curLevel, int curProgress, int targetProgress)
	{
		UUIArtText artText = base.GetArtText(6);
		if (artText != null)
		{
			artText.SetText(curLevel.ToString());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Spring26_MainHud_PassProgress", new <>z__ReadOnlyArray<object>(new object[]
		{
			curProgress,
			targetProgress
		}));
	}

	// Token: 0x0600DE09 RID: 56841 RVA: 0x003BB9AE File Offset: 0x003B9BAE
	private void OnClickAtmosphere()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelView, null, null);
	}

	// Token: 0x0600DE0A RID: 56842 RVA: 0x003BB9C4 File Offset: 0x003B9BC4
	private UniTask InitializeFunctionButton()
	{
		SpringManorMainHudPanel.<InitializeFunctionButton>d__52 <InitializeFunctionButton>d__;
		<InitializeFunctionButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeFunctionButton>d__.<>4__this = this;
		<InitializeFunctionButton>d__.<>1__state = -1;
		<InitializeFunctionButton>d__.<>t__builder.Start<SpringManorMainHudPanel.<InitializeFunctionButton>d__52>(ref <InitializeFunctionButton>d__);
		return <InitializeFunctionButton>d__.<>t__builder.Task;
	}

	// Token: 0x0600DE0B RID: 56843 RVA: 0x003BBA07 File Offset: 0x003B9C07
	private void InitializeFunctionButtonMap()
	{
		this.FunctionButtonMap[ESpringFunctionType.Gameplay] = base.GetItem(12);
		this.FunctionButtonMap[ESpringFunctionType.DIY] = base.GetItem(14);
	}

	// Token: 0x0600DE0C RID: 56844 RVA: 0x003BBA34 File Offset: 0x003B9C34
	private void RefreshFunctionButtonVisible()
	{
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		foreach (KeyValuePair<ESpringFunctionType, UUIItem> keyValuePair in this.FunctionButtonMap)
		{
			bool uiactive = activityData.IsFunctionUnlocked(keyValuePair.Key);
			keyValuePair.Value.SetUIActive(uiactive);
		}
	}

	// Token: 0x0600DE0D RID: 56845 RVA: 0x003BBAA8 File Offset: 0x003B9CA8
	private void OnClickExit()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattleViewLeaveInstance);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<SpringManorController>.Instance.LeaveInstanceDungeonRequest();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600DE0E RID: 56846 RVA: 0x003BBAF3 File Offset: 0x003B9CF3
	private void OnClickSetting()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MenuView, null, null);
	}

	// Token: 0x0600DE0F RID: 56847 RVA: 0x003BBB06 File Offset: 0x003B9D06
	private void OnClickQuest()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorQuestView, null, null);
	}

	// Token: 0x0600DE10 RID: 56848 RVA: 0x003BBB19 File Offset: 0x003B9D19
	private void OnClickGameplay()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorGameplayEntryView, null, null);
	}

	// Token: 0x0600DE11 RID: 56849 RVA: 0x003BBB2C File Offset: 0x003B9D2C
	private void OnClickDiy()
	{
		ControllerBase<FurnitureController>.Instance.OpenFurnitureAreaSelectView();
	}

	// Token: 0x0600DE12 RID: 56850 RVA: 0x003BBB38 File Offset: 0x003B9D38
	private void OnClickReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorRewardView, null, null);
	}

	// Token: 0x0600DE13 RID: 56851 RVA: 0x003BBB4B File Offset: 0x003B9D4B
	private void OnClickOpenPhotograph()
	{
		ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.Photograph);
	}

	// Token: 0x0600DE14 RID: 56852 RVA: 0x003BBB5C File Offset: 0x003B9D5C
	private void OnClickRoleSwitch()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorRoleSwitchView, null, null);
	}

	// Token: 0x04006A97 RID: 27287
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly EBattleUiChild[] controlBattleChildUiChildList = new EBattleUiChild[]
	{
		EBattleUiChild.BattleFloat,
		EBattleUiChild.InteractionHint,
		EBattleUiChild.SpringManorHud,
		EBattleUiChild.ScreenEffect
	};

	// Token: 0x04006A98 RID: 27288
	private MissionPanel MissionPanel;

	// Token: 0x04006A99 RID: 27289
	[Nullable(1)]
	private readonly Dictionary<ESpringFunctionType, UUIItem> FunctionButtonMap = new Dictionary<ESpringFunctionType, UUIItem>();

	// Token: 0x04006A9A RID: 27290
	private TrackedMarksView TrackPanel;

	// Token: 0x04006A9B RID: 27291
	private FullScreenPanel FullScreenPanel;

	// Token: 0x04006A9C RID: 27292
	private UUIItem TimeTipsItem;

	// Token: 0x04006A9D RID: 27293
	private UUIText TimeTipsText;

	// Token: 0x04006A9E RID: 27294
	[Nullable(1)]
	private readonly string TimeLimitString = ConfigMultiTextLang.GetLocalTextNew("Spring26_MainHud_MissionRemain", null) ?? "";

	// Token: 0x04006A9F RID: 27295
	private LevelSequencePlayer AtmosphereSeqPlayer;

	// Token: 0x04006AA0 RID: 27296
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04006AA1 RID: 27297
	private UUISliderComponent AtmosphereProgressBar;

	// Token: 0x04006AA2 RID: 27298
	private SpringManorQuestButton QuestButton;

	// Token: 0x04006AA3 RID: 27299
	private int CurrentTraceMainQuestId;

	// Token: 0x04006AA4 RID: 27300
	private ULTweener AtmosphereTweener;

	// Token: 0x04006AA5 RID: 27301
	private AtmosphereStageUpParam AtmosphereStageUpParam;

	// Token: 0x020080F5 RID: 33013
	[NullableContext(0)]
	private static class EComp
	{
		// Token: 0x0402BD85 RID: 179589
		public const int BtnExit = 0;

		// Token: 0x0402BD86 RID: 179590
		public const int BtnSetting = 1;

		// Token: 0x0402BD87 RID: 179591
		public const int CostRoot = 2;

		// Token: 0x0402BD88 RID: 179592
		public const int PassBg1 = 3;

		// Token: 0x0402BD89 RID: 179593
		public const int PassBg2 = 4;

		// Token: 0x0402BD8A RID: 179594
		public const int PassBg3 = 5;

		// Token: 0x0402BD8B RID: 179595
		public const int PassLevel = 6;

		// Token: 0x0402BD8C RID: 179596
		public const int PassName = 7;

		// Token: 0x0402BD8D RID: 179597
		public const int PassSliderBar = 8;

		// Token: 0x0402BD8E RID: 179598
		public const int PassProgress = 9;

		// Token: 0x0402BD8F RID: 179599
		public const int BtnQuest = 10;

		// Token: 0x0402BD90 RID: 179600
		public const int QuestContentLayout = 11;

		// Token: 0x0402BD91 RID: 179601
		public const int BtnGameplay = 12;

		// Token: 0x0402BD92 RID: 179602
		public const int BtnReward = 13;

		// Token: 0x0402BD93 RID: 179603
		public const int BtnDIY = 14;

		// Token: 0x0402BD94 RID: 179604
		public const int TimeTips = 15;

		// Token: 0x0402BD95 RID: 179605
		public const int TimeTipsText = 16;

		// Token: 0x0402BD96 RID: 179606
		public const int BtnTimeTips = 17;

		// Token: 0x0402BD97 RID: 179607
		public const int TrackItem = 18;

		// Token: 0x0402BD98 RID: 179608
		public const int BtnAtmosphere = 19;

		// Token: 0x0402BD99 RID: 179609
		public const int AtmospherePanel = 20;

		// Token: 0x0402BD9A RID: 179610
		public const int BtnGameplayRedDotItem = 21;

		// Token: 0x0402BD9B RID: 179611
		public const int BtnDIYRedDotItem = 22;

		// Token: 0x0402BD9C RID: 179612
		public const int BtnRewardRedDotItem = 23;

		// Token: 0x0402BD9D RID: 179613
		public const int BtnCamera = 24;

		// Token: 0x0402BD9E RID: 179614
		public const int BtnSwitch = 25;

		// Token: 0x0402BD9F RID: 179615
		public const int BtnAtmosphereRedDotItem = 26;

		// Token: 0x0402BDA0 RID: 179616
		public const int HideLeft = 27;

		// Token: 0x0402BDA1 RID: 179617
		public const int HideRight = 28;

		// Token: 0x0402BDA2 RID: 179618
		public const int FullScreenPanel = 29;
	}
}
