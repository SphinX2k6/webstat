using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A19 RID: 10777
[NullableContext(1)]
[Nullable(0)]
public class SignalDecodeViewV2 : UiTickViewBase
{
	// Token: 0x060157FE RID: 88062 RVA: 0x005F5C58 File Offset: 0x005F3E58
	public SignalDecodeViewV2(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060157FF RID: 88063 RVA: 0x005F5CC4 File Offset: 0x005F3EC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUINiagara)),
			new ValueTuple<int, Type>(12, typeof(UUINiagara)),
			new ValueTuple<int, Type>(13, typeof(UUINiagara)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUINiagara)),
			new ValueTuple<int, Type>(17, typeof(UUINiagara))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnPauseBtnClick)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnHelpBtnClick))
		};
	}

	// Token: 0x06015800 RID: 88064 RVA: 0x005F5EAC File Offset: 0x005F40AC
	protected override UniTask OnBeforeStartAsync()
	{
		SignalDecodeViewV2.<OnBeforeStartAsync>d__39 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SignalDecodeViewV2.<OnBeforeStartAsync>d__39>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015801 RID: 88065 RVA: 0x005F5EF0 File Offset: 0x005F40F0
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private UniTask<UNiagaraSystem> WaitLoadNiagaraSystem(string pathKey)
	{
		SignalDecodeViewV2.<WaitLoadNiagaraSystem>d__40 <WaitLoadNiagaraSystem>d__;
		<WaitLoadNiagaraSystem>d__.<>t__builder = AsyncUniTaskMethodBuilder<UNiagaraSystem>.Create();
		<WaitLoadNiagaraSystem>d__.<>4__this = this;
		<WaitLoadNiagaraSystem>d__.pathKey = pathKey;
		<WaitLoadNiagaraSystem>d__.<>1__state = -1;
		<WaitLoadNiagaraSystem>d__.<>t__builder.Start<SignalDecodeViewV2.<WaitLoadNiagaraSystem>d__40>(ref <WaitLoadNiagaraSystem>d__);
		return <WaitLoadNiagaraSystem>d__.<>t__builder.Task;
	}

	// Token: 0x06015802 RID: 88066 RVA: 0x005F5F3B File Offset: 0x005F413B
	protected override void OnBeforeShow()
	{
		UUIButtonComponent button = base.GetButton(6);
		button.OnPointDownCallBack.Bind(new Action(this.OnCatchBtnDown));
		button.OnPointUpCallBack.Bind(new Action(this.OnCatchBtnUp));
	}

	// Token: 0x06015803 RID: 88067 RVA: 0x005F5F71 File Offset: 0x005F4171
	protected override void OnAfterShow()
	{
		this.UpdateByStep(SignalDecodeViewV2.EGameplayStep.CountDown, false);
	}

	// Token: 0x06015804 RID: 88068 RVA: 0x005F5F7B File Offset: 0x005F417B
	protected override void OnBeforeDestroy()
	{
		this.StopAllAudio();
		this.SuccessLoopNiagara = null;
		this.SuccessBurstNiagara = null;
		this.FailLoopNiagara = null;
		this.FailBurstNiagara = null;
	}

	// Token: 0x06015805 RID: 88069 RVA: 0x005F5FA0 File Offset: 0x005F41A0
	private void StopAllAudio()
	{
		Singleton<AudioController>.Instance.StopEvent(this.CountDownPlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.CountDownEndPlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.BgNoisePlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.BgStopNoisePlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.CatchDownPlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.CatchSuccessPlayResult, true, null);
		Singleton<AudioController>.Instance.StopEvent(this.CatchFailedPlayResult, true, null);
	}

	// Token: 0x06015806 RID: 88070 RVA: 0x005F6063 File Offset: 0x005F4263
	private void DisableAllNiagara()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(13);
		if (uiNiagara != null)
		{
			uiNiagara.SetNiagaraUIActive(false, false);
		}
		UUINiagara uiNiagara2 = base.GetUiNiagara(12);
		if (uiNiagara2 != null)
		{
			uiNiagara2.SetNiagaraUIActive(false, false);
		}
		UUINiagara uiNiagara3 = base.GetUiNiagara(11);
		if (uiNiagara3 == null)
		{
			return;
		}
		uiNiagara3.SetNiagaraUIActive(false, false);
	}

	// Token: 0x06015807 RID: 88071 RVA: 0x005F60A4 File Offset: 0x005F42A4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignalCatchStart, new Action(this.OnSignalCatchStart));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignalCatchSuccess, new Action(this.OnSignalCatchSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignalCatchFailed, new Action(this.OnSignalCatchFailed));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignalCatchContinue, new Action(this.OnSignalCatchContinue));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignalCatchStartAgain, new Action(this.OnSignalCatchStartAgain));
	}

	// Token: 0x06015808 RID: 88072 RVA: 0x005F6140 File Offset: 0x005F4340
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalCatchStart, new Action(this.OnSignalCatchStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalCatchSuccess, new Action(this.OnSignalCatchSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalCatchFailed, new Action(this.OnSignalCatchFailed));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalCatchContinue, new Action(this.OnSignalCatchContinue));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignalCatchStartAgain, new Action(this.OnSignalCatchStartAgain));
	}

	// Token: 0x06015809 RID: 88073 RVA: 0x005F61D9 File Offset: 0x005F43D9
	private void OnSignalCatchStart()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(12);
		uiNiagara.SetNiagaraSystem(this.SuccessLoopNiagara);
		uiNiagara.SetNiagaraUIActive(true, false);
		uiNiagara.ActivateSystem(true);
	}

	// Token: 0x0601580A RID: 88074 RVA: 0x005F6200 File Offset: 0x005F4400
	private void OnSignalCatchSuccess()
	{
		this.DecisionSpriteToNormal();
		UUINiagara uiNiagara = base.GetUiNiagara(12);
		uiNiagara.SetNiagaraSystem(this.SuccessLoopNiagara);
		uiNiagara.SetNiagaraUIActive(false, false);
		uiNiagara.DeactivateSystem();
		UUINiagara uiNiagara2 = base.GetUiNiagara(11);
		uiNiagara2.SetNiagaraSystem(this.SuccessBurstNiagara);
		uiNiagara2.SetNiagaraUIActive(true, false);
		uiNiagara2.ActivateSystem(true);
		this.PlayAudio("SignalDecodeGame_release_correct", this.CatchSuccessPlayResult);
	}

	// Token: 0x0601580B RID: 88075 RVA: 0x005F6268 File Offset: 0x005F4468
	private void OnSignalCatchFailed()
	{
		this.DecisionSpriteToRed();
		this.LockChange = true;
		UUINiagara uiNiagara = base.GetUiNiagara(12);
		uiNiagara.SetNiagaraSystem(this.FailLoopNiagara);
		uiNiagara.SetNiagaraUIActive(false, false);
		uiNiagara.DeactivateSystem();
		UUINiagara uiNiagara2 = base.GetUiNiagara(11);
		uiNiagara2.SetNiagaraSystem(this.FailBurstNiagara);
		uiNiagara2.SetNiagaraUIActive(true, false);
		uiNiagara2.ActivateSystem(true);
		TimerSystem.Instance.Delay(delegate(float _)
		{
			this.LockChange = false;
			this.DecisionSpriteToNormal();
		}, 1000f, null, null, true, 1f);
		string name = "SignalDecodeGame_release_error";
		if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
		{
			name = "SignalDecodeGame_music_play_presserror";
		}
		this.PlayAudio(name, this.CatchFailedPlayResult);
	}

	// Token: 0x0601580C RID: 88076 RVA: 0x005F630F File Offset: 0x005F450F
	private void OnSignalCatchContinue()
	{
		this.PausePanel.Hide(null);
		this.UpdateByStep(SignalDecodeViewV2.EGameplayStep.Gameplay, false);
	}

	// Token: 0x0601580D RID: 88077 RVA: 0x005F6325 File Offset: 0x005F4525
	private void OnSignalCatchStartAgain()
	{
		this.PausePanel.Hide(null);
		this.MovePanel.StartAgain();
		this.UpdateByStep(SignalDecodeViewV2.EGameplayStep.Gameplay, true);
	}

	// Token: 0x0601580E RID: 88078 RVA: 0x005F6346 File Offset: 0x005F4546
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Counter")
		{
			this.UpdateByStep(SignalDecodeViewV2.EGameplayStep.Gameplay, true);
		}
	}

	// Token: 0x0601580F RID: 88079 RVA: 0x005F6360 File Offset: 0x005F4560
	private void SequenceEvent(string sequenceName, string eventName)
	{
		if (sequenceName != "Counter")
		{
			return;
		}
		UUIText text = base.GetText(2);
		if (eventName == "开始")
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("Start");
			text.SetText(textById, true);
			this.PlayAudio("SignalDecodeGame_count_down_End", this.CountDownEndPlayResult);
			return;
		}
		text.SetText(eventName, true);
		this.PlayAudio("SignalDecodeGame_count_down", this.CountDownPlayResult);
	}

	// Token: 0x06015810 RID: 88080 RVA: 0x005F63D3 File Offset: 0x005F45D3
	protected override void OnTick(float delta)
	{
		if (this.CurrentStep == SignalDecodeViewV2.EGameplayStep.Gameplay)
		{
			this.UpdateGameplay(delta);
		}
	}

	// Token: 0x06015811 RID: 88081 RVA: 0x005F63E5 File Offset: 0x005F45E5
	private void UpdateGameplay(float delta)
	{
		this.MovePanel.UpdateMove(delta);
		this.UpdateProgress();
	}

	// Token: 0x06015812 RID: 88082 RVA: 0x005F63FC File Offset: 0x005F45FC
	private void UpdateProgress()
	{
		float num = this.MovePanel.GetCompleteness();
		num = (float)Math.Floor((double)(num * 100f));
		UUIText text = base.GetText(8);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)num);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		float progress = this.MovePanel.GetProgress();
		base.GetSprite(10).SetFillAmount(progress);
		if (progress >= 1f)
		{
			this.GameOver((int)num);
		}
	}

	// Token: 0x06015813 RID: 88083 RVA: 0x005F6480 File Offset: 0x005F4680
	private void GameOver(int completeness)
	{
		if (this.BlockFlag)
		{
			return;
		}
		this.BlockFlag = true;
		TimerSystem.Instance.Delay(delegate(float _)
		{
			SignalDecodeViewV2.EGameplayStep step = (completeness >= ModelBase<SignalDecodeModel>.Instance.TargetCompletion) ? SignalDecodeViewV2.EGameplayStep.SuccessFinish : SignalDecodeViewV2.EGameplayStep.FailedFinish;
			this.UpdateByStep(step, false);
			this.BlockFlag = false;
		}, 1000f, null, null, true, 1f);
	}

	// Token: 0x06015814 RID: 88084 RVA: 0x005F64D8 File Offset: 0x005F46D8
	private void UpdateByStep(SignalDecodeViewV2.EGameplayStep step, bool reStart = false)
	{
		if (this.CurrentStep == step)
		{
			return;
		}
		switch (step)
		{
		case SignalDecodeViewV2.EGameplayStep.CountDown:
		{
			base.GetItem(1).SetUIActive(false);
			base.GetItem(0).SetUIActive(true);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetText("3", true);
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Counter", false, null, false);
			}
			break;
		}
		case SignalDecodeViewV2.EGameplayStep.Gameplay:
		{
			this.DisableAllNiagara();
			base.GetItem(0).SetUIActive(false);
			base.GetItem(1).SetUIActive(true);
			if (reStart)
			{
				this.InitMoveNode();
			}
			string text2 = "SignalDecodeGame_play_base_noise";
			if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
			{
				text2 = (reStart ? "SignalDecodeGame_music_play_BGM" : "SignalDecodeGame_music_resume_BGM");
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "BGM事件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("eventName", text2);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.PlayAudio(text2, this.BgNoisePlayResult);
			break;
		}
		case SignalDecodeViewV2.EGameplayStep.Pause:
		{
			this.StopAllAudio();
			base.GetItem(1).SetUIActive(false);
			this.PausePanel.Show(null);
			string text2 = "SignalDecodeGame_stop_base_noise";
			if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
			{
				text2 = "SignalDecodeGame_music_pause_BGM";
			}
			this.PlayAudio(text2, this.BgStopNoisePlayResult);
			break;
		}
		case SignalDecodeViewV2.EGameplayStep.SuccessFinish:
		{
			this.StopAllAudio();
			base.GetItem(1).SetUIActive(false);
			this.SuccessFinishPanel.Open();
			string text2 = "SignalDecodeGame_stop_base_noise";
			if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
			{
				text2 = "SignalDecodeGame_music_stop_BGM";
			}
			this.PlayAudio(text2, this.BgStopNoisePlayResult);
			break;
		}
		case SignalDecodeViewV2.EGameplayStep.FailedFinish:
		{
			this.StopAllAudio();
			base.GetItem(1).SetUIActive(false);
			this.FailedFinishPanel.Open();
			string text2 = "SignalDecodeGame_stop_base_noise";
			if (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.DrawSword)
			{
				text2 = "SignalDecodeGame_music_stop_BGM";
			}
			this.PlayAudio(text2, this.BgStopNoisePlayResult);
			break;
		}
		}
		this.CurrentStep = step;
	}

	// Token: 0x06015815 RID: 88085 RVA: 0x005F66CB File Offset: 0x005F48CB
	private void InitMoveNode()
	{
		this.MovePanel.InitMoveNode();
	}

	// Token: 0x06015816 RID: 88086 RVA: 0x005F66D8 File Offset: 0x005F48D8
	private void PlayAudio(string name, PlayResult result)
	{
		Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath(name);
		if (audioPath == null || string.IsNullOrEmpty(audioPath.Value.Path))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "获取Audio配表信息错误！请检查Audio的配置是否存在！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<AudioController>.Instance.PostEventByUi(audioPath.Value.Path, result, null, null);
	}

	// Token: 0x06015817 RID: 88087 RVA: 0x005F675C File Offset: 0x005F495C
	private void OnCatchBtnDown()
	{
		this.MovePanel.OnCatchBtnDown();
		UUINiagara uiNiagara = base.GetUiNiagara(13);
		if (uiNiagara != null)
		{
			uiNiagara.SetNiagaraUIActive(true, false);
		}
		if (uiNiagara != null)
		{
			uiNiagara.ActivateSystem(true);
		}
		this.DecisionSpriteOnPress();
		Singleton<AudioController>.Instance.PostEventByUi("SignalDecodeGame_play_press_loop", this.CatchDownPlayResult, null, null);
	}

	// Token: 0x06015818 RID: 88088 RVA: 0x005F67BC File Offset: 0x005F49BC
	private void OnCatchBtnUp()
	{
		this.MovePanel.OnCatchBtnUp();
		this.DecisionSpriteToNormal();
		Singleton<AudioController>.Instance.PostEventByUi("SignalDecodeGame_stop_press_loop", this.CatchUpPlayResult, null, null);
	}

	// Token: 0x06015819 RID: 88089 RVA: 0x005F67F9 File Offset: 0x005F49F9
	private void OnPauseBtnClick()
	{
		this.UpdateByStep(SignalDecodeViewV2.EGameplayStep.Pause, false);
	}

	// Token: 0x0601581A RID: 88090 RVA: 0x005F6803 File Offset: 0x005F4A03
	private void OnHelpBtnClick()
	{
	}

	// Token: 0x0601581B RID: 88091 RVA: 0x005F6808 File Offset: 0x005F4A08
	private void DecisionSpriteOnPress()
	{
		string key = (ModelBase<SignalDecodeModel>.Instance.CurrentGameplayType == ESignalGameplayType.Send) ? "SP_SignalPointerGreen" : "SP_SignalPointerYellow";
		this.DecisionSpriteChange(key);
	}

	// Token: 0x0601581C RID: 88092 RVA: 0x005F6838 File Offset: 0x005F4A38
	private void DecisionSpriteToNormal()
	{
		this.DecisionSpriteChange("SP_SignalPointerNor");
	}

	// Token: 0x0601581D RID: 88093 RVA: 0x005F6845 File Offset: 0x005F4A45
	private void DecisionSpriteToRed()
	{
		this.DecisionSpriteChange("SP_SignalPointerRed");
	}

	// Token: 0x0601581E RID: 88094 RVA: 0x005F6854 File Offset: 0x005F4A54
	private void DecisionSpriteChange(string key)
	{
		if (this.LockChange)
		{
			return;
		}
		UUISprite sprite = base.GetSprite(7);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(key);
		this.SetSpriteByPath(resourcePath, sprite, false, null, null);
	}

	// Token: 0x0400A574 RID: 42356
	private const string COUNTDOWN_SEQUENCENAME = "Counter";

	// Token: 0x0400A575 RID: 42357
	private const string NIAGARA_ORANGE_COLOR = "FF400FFF";

	// Token: 0x0400A576 RID: 42358
	private const string COUNTDOWN_AUDIO_EVENTNAME = "SignalDecodeGame_count_down";

	// Token: 0x0400A577 RID: 42359
	private const string COUNTDOWNEND_AUDIO_EVENTNAME = "SignalDecodeGame_count_down_End";

	// Token: 0x0400A578 RID: 42360
	private const string BG_NOISE_AUDIO_EVENTNAME = "SignalDecodeGame_play_base_noise";

	// Token: 0x0400A579 RID: 42361
	private const string BG_NOISE_STOP_AUDIO_EVENTNAME = "SignalDecodeGame_stop_base_noise";

	// Token: 0x0400A57A RID: 42362
	private const string BG_BGM_AUDIO_EVENTNAME = "SignalDecodeGame_music_play_BGM";

	// Token: 0x0400A57B RID: 42363
	private const string BG_BGM_AUDIO_PAUSE_EVENTNAME = "SignalDecodeGame_music_pause_BGM";

	// Token: 0x0400A57C RID: 42364
	private const string BG_BGM_AUDIO_RESUME_EVENTNAME = "SignalDecodeGame_music_resume_BGM";

	// Token: 0x0400A57D RID: 42365
	private const string BG_BGM_STOP_AUDIO_EVENTNAME = "SignalDecodeGame_music_stop_BGM";

	// Token: 0x0400A57E RID: 42366
	private const string PLAYER_CATCHDOWN_AUDIO_EVENTNAME = "SignalDecodeGame_play_press_loop";

	// Token: 0x0400A57F RID: 42367
	private const string PLAYER_CATCHUP_AUDIO_EVENTNAME = "SignalDecodeGame_stop_press_loop";

	// Token: 0x0400A580 RID: 42368
	private const string PLAYER_CATCHSUCCESS_AUDIO_EVENTNAME = "SignalDecodeGame_release_correct";

	// Token: 0x0400A581 RID: 42369
	private const string PLAYER_CATCHFAILED_AUDIO_EVENTNAME = "SignalDecodeGame_release_error";

	// Token: 0x0400A582 RID: 42370
	private const string PLAYER_CATCHFAILED2_AUDIO_EVENTNAME = "SignalDecodeGame_music_play_presserror";

	// Token: 0x0400A583 RID: 42371
	[Nullable(2)]
	private SignalMovePanel MovePanel;

	// Token: 0x0400A584 RID: 42372
	[Nullable(2)]
	private PausePanel PausePanel;

	// Token: 0x0400A585 RID: 42373
	[Nullable(2)]
	private SuccessFinishPanel SuccessFinishPanel;

	// Token: 0x0400A586 RID: 42374
	[Nullable(2)]
	private FailedFinishPanel FailedFinishPanel;

	// Token: 0x0400A587 RID: 42375
	[Nullable(2)]
	private UNiagaraSystem SuccessBurstNiagara;

	// Token: 0x0400A588 RID: 42376
	[Nullable(2)]
	private UNiagaraSystem SuccessLoopNiagara;

	// Token: 0x0400A589 RID: 42377
	[Nullable(2)]
	private UNiagaraSystem FailBurstNiagara;

	// Token: 0x0400A58A RID: 42378
	[Nullable(2)]
	private UNiagaraSystem FailLoopNiagara;

	// Token: 0x0400A58B RID: 42379
	private readonly PlayResult CountDownPlayResult = new PlayResult();

	// Token: 0x0400A58C RID: 42380
	private readonly PlayResult CountDownEndPlayResult = new PlayResult();

	// Token: 0x0400A58D RID: 42381
	private readonly PlayResult BgNoisePlayResult = new PlayResult();

	// Token: 0x0400A58E RID: 42382
	private readonly PlayResult BgStopNoisePlayResult = new PlayResult();

	// Token: 0x0400A58F RID: 42383
	private readonly PlayResult CatchDownPlayResult = new PlayResult();

	// Token: 0x0400A590 RID: 42384
	private readonly PlayResult CatchUpPlayResult = new PlayResult();

	// Token: 0x0400A591 RID: 42385
	private readonly PlayResult CatchSuccessPlayResult = new PlayResult();

	// Token: 0x0400A592 RID: 42386
	private readonly PlayResult CatchFailedPlayResult = new PlayResult();

	// Token: 0x0400A593 RID: 42387
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400A594 RID: 42388
	private SignalDecodeViewV2.EGameplayStep CurrentStep;

	// Token: 0x0400A595 RID: 42389
	private bool LockChange;

	// Token: 0x0400A596 RID: 42390
	private bool BlockFlag;

	// Token: 0x02008D98 RID: 36248
	[NullableContext(0)]
	private enum EGameplayStep
	{
		// Token: 0x0402F9C4 RID: 195012
		None,
		// Token: 0x0402F9C5 RID: 195013
		CountDown,
		// Token: 0x0402F9C6 RID: 195014
		Gameplay,
		// Token: 0x0402F9C7 RID: 195015
		Pause,
		// Token: 0x0402F9C8 RID: 195016
		SuccessFinish,
		// Token: 0x0402F9C9 RID: 195017
		FailedFinish
	}

	// Token: 0x02008D99 RID: 36249
	[NullableContext(0)]
	public static class EChildComponent
	{
		// Token: 0x0402F9CA RID: 195018
		public const int CountDownNode = 0;

		// Token: 0x0402F9CB RID: 195019
		public const int GamePlayRoot = 1;

		// Token: 0x0402F9CC RID: 195020
		public const int CountDownText = 2;

		// Token: 0x0402F9CD RID: 195021
		public const int PauseBtn = 3;

		// Token: 0x0402F9CE RID: 195022
		public const int HelpBtn = 4;

		// Token: 0x0402F9CF RID: 195023
		public const int SignalMoveNode = 5;

		// Token: 0x0402F9D0 RID: 195024
		public const int CatchButton = 6;

		// Token: 0x0402F9D1 RID: 195025
		public const int DecisionSprite = 7;

		// Token: 0x0402F9D2 RID: 195026
		public const int ProgressText = 8;

		// Token: 0x0402F9D3 RID: 195027
		public const int BottomBg = 9;

		// Token: 0x0402F9D4 RID: 195028
		public const int GameplayProgressSprite = 10;

		// Token: 0x0402F9D5 RID: 195029
		public const int BurstNiagara = 11;

		// Token: 0x0402F9D6 RID: 195030
		public const int PressNiagara = 12;

		// Token: 0x0402F9D7 RID: 195031
		public const int BtnClickNiagara = 13;

		// Token: 0x0402F9D8 RID: 195032
		public const int MatchText = 14;

		// Token: 0x0402F9D9 RID: 195033
		public const int DescribeText = 15;

		// Token: 0x0402F9DA RID: 195034
		public const int BottomBgNiagaraL = 16;

		// Token: 0x0402F9DB RID: 195035
		public const int BottomBgNiagaraR = 17;
	}
}
