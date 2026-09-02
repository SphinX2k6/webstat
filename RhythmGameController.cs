using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;
using AkiClient.Game.Aki.Data.Level.PlaneYinyou.BP;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001141 RID: 4417
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RhythmGameController : UiControllerBase<RhythmGameController>
{
	// Token: 0x0600741E RID: 29726 RVA: 0x001E5036 File Offset: 0x001E3236
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x0600741F RID: 29727 RVA: 0x001E5054 File Offset: 0x001E3254
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x06007420 RID: 29728 RVA: 0x001E5074 File Offset: 0x001E3274
	private void OnWorldDone()
	{
		this.FeverTimes = 0;
		InstanceDungeon? instanceDungeon;
		if (((ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().InstSubType) : null).GetValueOrDefault() != 53)
		{
			this.IsEnterRhythmGame = false;
			this.ClearCache();
			return;
		}
		this.IsEnterRhythmGame = true;
		this.ClearCache();
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		ControllerBase<GameModeController>.Instance.AddWorldDoneBlocker(delegate
		{
			RhythmGameController.<<OnWorldDone>b__32_0>d <<OnWorldDone>b__32_0>d;
			<<OnWorldDone>b__32_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnWorldDone>b__32_0>d.<>4__this = this;
			<<OnWorldDone>b__32_0>d.<>1__state = -1;
			<<OnWorldDone>b__32_0>d.<>t__builder.Start<RhythmGameController.<<OnWorldDone>b__32_0>d>(ref <<OnWorldDone>b__32_0>d);
			return <<OnWorldDone>b__32_0>d.<>t__builder.Task;
		}, 60000);
	}

	// Token: 0x06007421 RID: 29729 RVA: 0x001E5130 File Offset: 0x001E3330
	protected override bool OnLeaveLevel()
	{
		if (!this.IsEnterRhythmGame)
		{
			return base.OnLeaveLevel();
		}
		if (this.MusicEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.MusicEventHandle = 0;
		}
		if (this.HoldNoteEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.HoldNoteEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.HoldNoteEventHandle = 0;
		}
		if (this.FeverLoopEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.FeverLoopEventHandle = 0;
		}
		if (Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView)))
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		}
		if (Singleton<EventSystem>.Instance.Has<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView)))
		{
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}
		this.IsEnterRhythmGame = false;
		return base.OnLeaveLevel();
	}

	// Token: 0x06007422 RID: 29730 RVA: 0x001E5270 File Offset: 0x001E3470
	private UniTask StartRhythmGame()
	{
		RhythmGameController.<StartRhythmGame>d__34 <StartRhythmGame>d__;
		<StartRhythmGame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartRhythmGame>d__.<>4__this = this;
		<StartRhythmGame>d__.<>1__state = -1;
		<StartRhythmGame>d__.<>t__builder.Start<RhythmGameController.<StartRhythmGame>d__34>(ref <StartRhythmGame>d__);
		return <StartRhythmGame>d__.<>t__builder.Task;
	}

	// Token: 0x06007423 RID: 29731 RVA: 0x001E52B4 File Offset: 0x001E34B4
	private UniTask LoadRhythmGameItemAsync()
	{
		RhythmGameController.<LoadRhythmGameItemAsync>d__35 <LoadRhythmGameItemAsync>d__;
		<LoadRhythmGameItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadRhythmGameItemAsync>d__.<>4__this = this;
		<LoadRhythmGameItemAsync>d__.<>1__state = -1;
		<LoadRhythmGameItemAsync>d__.<>t__builder.Start<RhythmGameController.<LoadRhythmGameItemAsync>d__35>(ref <LoadRhythmGameItemAsync>d__);
		return <LoadRhythmGameItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007424 RID: 29732 RVA: 0x001E52F8 File Offset: 0x001E34F8
	[NullableContext(0)]
	private UniTask<bool> LoadShipActorAsync()
	{
		RhythmGameController.<LoadShipActorAsync>d__36 <LoadShipActorAsync>d__;
		<LoadShipActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadShipActorAsync>d__.<>4__this = this;
		<LoadShipActorAsync>d__.<>1__state = -1;
		<LoadShipActorAsync>d__.<>t__builder.Start<RhythmGameController.<LoadShipActorAsync>d__36>(ref <LoadShipActorAsync>d__);
		return <LoadShipActorAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007425 RID: 29733 RVA: 0x001E533C File Offset: 0x001E353C
	[NullableContext(0)]
	private UniTask<bool> LoadRhythmGameConfigAsync()
	{
		RhythmGameController.<LoadRhythmGameConfigAsync>d__37 <LoadRhythmGameConfigAsync>d__;
		<LoadRhythmGameConfigAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadRhythmGameConfigAsync>d__.<>1__state = -1;
		<LoadRhythmGameConfigAsync>d__.<>t__builder.Start<RhythmGameController.<LoadRhythmGameConfigAsync>d__37>(ref <LoadRhythmGameConfigAsync>d__);
		return <LoadRhythmGameConfigAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007426 RID: 29734 RVA: 0x001E5378 File Offset: 0x001E3578
	private void StartRhythmGameInternal(int roleId)
	{
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----[StartRhythmGameInternal]----", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----InitTimerSystem----", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.InitTimerSystem();
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----InitializeRhythmGameShipController----", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.ShipActor != null)
		{
			ControllerBase<RhythmGameShipController>.Instance.Initialize(this.ShipActor);
		}
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----FindSplineEntity----", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.SplineActor = (Singleton<ActorSystem>.Instance.Get(TsGameSplineActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as TsGameSplineActor);
		this.SplineComp = GameSplineUtils.InitGameSplineBySplineEntity(229800000, this.SplineActor);
		ModelBase<RhythmGameModel>.Instance.CurSplineComponent = this.SplineComp;
		global::Vector splineLocation = ModelBase<RhythmGameModel>.Instance.SplineLocation;
		FVectorDouble fvectorDouble = this.SplineActor.D_K2_GetActorLocation();
		splineLocation.FromUeVector(fvectorDouble);
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----FindRhythmGameManagerActor----", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.RhythmGameManager = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroRhythmGameManager.StaticClass()) as UKuroRhythmGameManager);
		ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.Config.GlobalTimeOffset += (float)(ModelBase<RhythmShipModel>.Instance.LocalCalibrationValue / 1000);
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----StartRhythmGame----", default(ReadOnlySpan<ValueTuple<string, object>>));
		TArray<FKuroRhythmSkillEffectParam> rhythmGameSkillEffectParam = RhythmGameUtil.GetRhythmGameSkillEffectParam(roleId);
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager != null)
		{
			FKuroRhythmGameConfig config = ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.Config;
			rhythmGameManager.InitializeGame(config, ref rhythmGameSkillEffectParam, this.ShipActor, this.SplineComp);
		}
		ModelBase<RhythmGameModel>.Instance.ForceTargetActor = this.ShipActor;
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.EnterSpecialGameplayCamera(2);
		this.ChangedCamera = true;
		UKuroRhythmGameManager rhythmGameManager2 = this.RhythmGameManager;
		if (rhythmGameManager2 != null)
		{
			rhythmGameManager2.SetShipMovementSpeed(ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig().Speed);
		}
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----LoadMusicGameConfig----", default(ReadOnlySpan<ValueTuple<string, object>>));
		RhythmSubLevel? config2 = ConfigRhythmSubLevelById.GetConfig(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId, true);
		MusicGameData? config3 = ConfigMusicGameDataById.GetConfig((config2 != null) ? config2.GetValueOrDefault().JsonId : 10, true);
		this.GuideIds = (((config2 != null) ? config2.GetValueOrDefault().Guide() : null) ?? Array.Empty<int>());
		RhythmGamePerformanceCameraConfig startCameraConfig = ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.StartCameraConfig;
		Singleton<EventSystem>.Instance.Emit<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameStartPhase, startCameraConfig);
		this.TotalOffset = -((config3 != null) ? config3.GetValueOrDefault().BgmOffset : 0f) + startCameraConfig.Time;
		this.RhythmGameManager.NoteEventTimeOffset = startCameraConfig.Time;
		FKuroRhythmChartData rhythmGameData = new FKuroRhythmChartData();
		UKuroRhythmGameManager rhythmGameManager3 = this.RhythmGameManager;
		if (rhythmGameManager3 != null)
		{
			rhythmGameManager3.ParseChartDataFromJson(((config3 != null) ? config3.GetValueOrDefault().Data : null) ?? "", ref rhythmGameData);
		}
		this.RhythmGameData = rhythmGameData;
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----StartRhythmGame End----", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "----AddGameEvent----", default(ReadOnlySpan<ValueTuple<string, object>>));
		UKuroRhythmGameManager rhythmGameManager4 = this.RhythmGameManager;
		if (rhythmGameManager4 != null)
		{
			rhythmGameManager4.OnNoteResult.Add(new Action<int, EKuroRhythmGameNoteType, EKuroRhythmGameRating, FVectorDouble, FQuat>(this.OnNoteResult));
		}
		UKuroRhythmGameManager rhythmGameManager5 = this.RhythmGameManager;
		if (rhythmGameManager5 != null)
		{
			rhythmGameManager5.OnAllNotesFinished.Add(new Action(this.AllNotesFinished));
		}
		UKuroRhythmGameManager rhythmGameManager6 = this.RhythmGameManager;
		if (rhythmGameManager6 != null)
		{
			rhythmGameManager6.OnFeverStateChanged.Add(new Action<bool>(this.OnFeverStateChanged));
		}
		UKuroRhythmGameManager rhythmGameManager7 = this.RhythmGameManager;
		if (rhythmGameManager7 != null)
		{
			rhythmGameManager7.OnHiddenScoreLevelChanged.Add(new Action<int, int>(this.OnHiddenScoreLevelChanged));
		}
		UKuroRhythmGameManager rhythmGameManager8 = this.RhythmGameManager;
		if (rhythmGameManager8 != null)
		{
			rhythmGameManager8.OnFeverScoreChanged.Add(new Action<int, int>(this.OnFeverScoreChanged));
		}
		UKuroRhythmGameManager rhythmGameManager9 = this.RhythmGameManager;
		if (rhythmGameManager9 != null)
		{
			rhythmGameManager9.OnJumpEvent.Add(new Action<float>(this.OnJumpEvent));
		}
		UKuroRhythmGameManager rhythmGameManager10 = this.RhythmGameManager;
		if (rhythmGameManager10 != null)
		{
			rhythmGameManager10.OnTrackSwitched.Add(new Action<int, int>(this.OnTrackSwitched));
		}
		UKuroRhythmGameManager rhythmGameManager11 = this.RhythmGameManager;
		if (rhythmGameManager11 != null)
		{
			rhythmGameManager11.OnHoldScoreUpdated.Add(new Action<int, int>(this.OnHoldScoreUpdated));
		}
		UKuroRhythmGameManager rhythmGameManager12 = this.RhythmGameManager;
		if (rhythmGameManager12 != null)
		{
			rhythmGameManager12.OnGameEvent.Add(new Action<EKuroRhythmChartEventType>(this.OnGameEvent));
		}
		UKuroRhythmGameManager rhythmGameManager13 = this.RhythmGameManager;
		if (rhythmGameManager13 != null)
		{
			UKuroRhythmGameJudgement judgementSystem = rhythmGameManager13.JudgementSystem;
			if (judgementSystem != null)
			{
				judgementSystem.OnTunnelFlickSwitch.Add(new Action<bool>(this.OnTunnelFlickSwitch));
			}
		}
		UKuroRhythmGameManager rhythmGameManager14 = this.RhythmGameManager;
		if (rhythmGameManager14 != null)
		{
			UKuroRhythmGameJudgement judgementSystem2 = rhythmGameManager14.JudgementSystem;
			if (judgementSystem2 != null)
			{
				judgementSystem2.OnLineHitTrigger.Add(new Action(this.OnLineHitTrigger));
			}
		}
		UKuroRhythmGameManager rhythmGameManager15 = this.RhythmGameManager;
		if (rhythmGameManager15 != null)
		{
			UKuroRhythmGameJudgement judgementSystem3 = rhythmGameManager15.JudgementSystem;
			if (judgementSystem3 != null)
			{
				judgementSystem3.OnAutoJudgeCountChange.Add(new Action<int>(this.OnAutoJudgeCountChange));
			}
		}
		UKuroRhythmGameManager rhythmGameManager16 = this.RhythmGameManager;
		if (rhythmGameManager16 != null)
		{
			UKuroRhythmGameJudgement judgementSystem4 = rhythmGameManager16.JudgementSystem;
			if (judgementSystem4 != null)
			{
				judgementSystem4.OnHoldNoteInputReleased.Add(new Action(this.OnHoldNoteStop));
			}
		}
		UKuroRhythmGameManager rhythmGameManager17 = this.RhythmGameManager;
		if (rhythmGameManager17 != null)
		{
			UKuroRhythmGameJudgement judgementSystem5 = rhythmGameManager17.JudgementSystem;
			if (judgementSystem5 != null)
			{
				judgementSystem5.OnHoldNoteTimeout.Add(new Action(this.OnHoldNoteStop));
			}
		}
		UKuroRhythmGameManager rhythmGameManager18 = this.RhythmGameManager;
		if (rhythmGameManager18 != null)
		{
			UKuroRhythmGameJudgement judgementSystem6 = rhythmGameManager18.JudgementSystem;
			if (judgementSystem6 != null)
			{
				judgementSystem6.OnHoldNoteTimeout.Add(new Action(this.OnHoldNoteTimeout));
			}
		}
		UKuroRhythmGameManager rhythmGameManager19 = this.RhythmGameManager;
		bool? flag;
		if (rhythmGameManager19 == null)
		{
			flag = null;
		}
		else
		{
			UKuroRhythmGameJudgement judgementSystem7 = rhythmGameManager19.JudgementSystem;
			flag = ((judgementSystem7 != null) ? new bool?(judgementSystem7.IsDisableRecordUpLoad()) : null);
		}
		bool? flag2 = flag;
		this.IsDisableRecordUpLoad = flag2.GetValueOrDefault();
		this.SpawnStartEffect();
		this.RhythmGameManagerTickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.RhythmGameManagerTick), "RhythmGameManager", ETickingGroup.TG_PrePhysics, true, 0, false).Id;
		int remainUpgradeRatingCount = this.RhythmGameManager.JudgementSystem.GetRemainUpgradeRatingCount();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipGameView, new RhythmShipGameViewOpenParam
		{
			RoleId = roleId,
			AutoJudgeCount = remainUpgradeRatingCount
		}, null);
		this.LoadMusicAndPause();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gameship_start");
		this.PlayStartingCameraAnim();
	}

	// Token: 0x06007427 RID: 29735 RVA: 0x001E5A12 File Offset: 0x001E3C12
	private void InitTimerSystem()
	{
		if (this.RhythmGameTimerSystem != null)
		{
			this.RhythmGameTimerSystem.Clear();
		}
		this.RhythmGameTimerSystem = new TimerSystemInstance();
	}

	// Token: 0x06007428 RID: 29736 RVA: 0x001E5A32 File Offset: 0x001E3C32
	private void ClearTimerSystem()
	{
		if (this.RhythmGameTimerSystem != null)
		{
			this.RhythmGameTimerSystem.Clear();
			this.RhythmGameTimerSystem = null;
		}
	}

	// Token: 0x06007429 RID: 29737 RVA: 0x001E5A50 File Offset: 0x001E3C50
	public unsafe void GetOffsetFromMusic()
	{
		if (!this.IsBeginPlayMusic || this.MusicEventHandle == 0 || this.IsPause)
		{
			return;
		}
		float num = this.CurrentPlayedTime() * 1000f;
		int? sourcePlayPositionWithExtrapolation = Singleton<AudioSystem>.Instance.GetSourcePlayPositionWithExtrapolation(this.MusicEventHandle, true);
		if (sourcePlayPositionWithExtrapolation == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.RhythmGame, ELogAuthor.CH, "audioTime is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float num2 = (float)sourcePlayPositionWithExtrapolation.Value - num;
		if (Math.Abs(num2) > 500f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RhythmGame;
			ELogAuthor author = ELogAuthor.CH;
			string message = "GetOffsetFromMusic Offset too large";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Offset", num2);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CachedTimeOffset = 0f;
			this.IsAccumulatingTimeOffset = false;
			this.RhythmGameManager.GameplayTimeOffset += num2 / 1000f;
		}
		else
		{
			this.ApplyAudioTimeOffset(num2);
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.RhythmGame;
		ELogAuthor author2 = ELogAuthor.CH;
		string message2 = "MusicSyncBeat";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GameMusicTime", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AudioTime", sourcePlayPositionWithExtrapolation.Value);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Offset", num2);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0600742A RID: 29738 RVA: 0x001E5BBD File Offset: 0x001E3DBD
	public UKuroRhythmGameShipController GetRhythmGameShipController()
	{
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager == null)
		{
			return null;
		}
		return rhythmGameManager.ShipController;
	}

	// Token: 0x0600742B RID: 29739 RVA: 0x001E5BD0 File Offset: 0x001E3DD0
	public void OnPlayerInputDown(EKuroRhythmGameInputType type)
	{
		if (type == EKuroRhythmGameInputType.Line)
		{
			this.LineHoldKeyPressed = true;
		}
		if (!this.PlayerCanInput)
		{
			return;
		}
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager == null)
		{
			return;
		}
		rhythmGameManager.OnPlayerInputDown(type);
	}

	// Token: 0x0600742C RID: 29740 RVA: 0x001E5BF7 File Offset: 0x001E3DF7
	public void OnPlayerInputUp(EKuroRhythmGameInputType type)
	{
		if (type == EKuroRhythmGameInputType.Line)
		{
			this.LineHoldKeyPressed = false;
		}
		if (!this.PlayerCanInput)
		{
			return;
		}
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager == null)
		{
			return;
		}
		rhythmGameManager.OnPlayerInputUp(type);
	}

	// Token: 0x0600742D RID: 29741 RVA: 0x001E5C20 File Offset: 0x001E3E20
	private unsafe void OnGameEvent(EKuroRhythmChartEventType eventType)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnGameEvent";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("event", eventType);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		switch (eventType)
		{
		case EKuroRhythmChartEventType.Road:
		case EKuroRhythmChartEventType.Tunnel:
			ControllerBase<RhythmGameShipController>.Instance.SpawnLockIcon();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRhythmGameFreePhase, false);
			ModelBase<RhythmGameModel>.Instance.OnRoadMode = (eventType == EKuroRhythmChartEventType.Road);
			break;
		case EKuroRhythmChartEventType.Jump:
			break;
		case EKuroRhythmChartEventType.Guide:
		{
			if (this.CurrentGuideId < this.GuideIds.Length)
			{
				GuideController instance2 = ControllerBase<GuideController>.Instance;
				int[] guideIds = this.GuideIds;
				int currentGuideId = this.CurrentGuideId;
				this.CurrentGuideId = currentGuideId + 1;
				instance2.TryStartGuide(guideIds[currentGuideId]);
				return;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RhythmGame;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "OnGameEvent out of range";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GuideId length", this.GuideIds.Length);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentGuideId", this.CurrentGuideId);
			instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		case EKuroRhythmChartEventType.KuroFreefly:
			ControllerBase<RhythmGameShipController>.Instance.StopLockIconEffect();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRhythmGameFreePhase, true);
			ModelBase<RhythmGameModel>.Instance.OnRoadMode = false;
			return;
		default:
			return;
		}
	}

	// Token: 0x0600742E RID: 29742 RVA: 0x001E5D6C File Offset: 0x001E3F6C
	private void SpawnStartEffect()
	{
		RhythmGamePerformanceCameraConfig startCameraConfig = ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.StartCameraConfig;
		float distance = startCameraConfig.Time * ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig().Speed;
		FVectorDouble fvectorDouble = this.SplineComp.D_GetLocationAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World);
		FTransformDouble value = new FTransformDouble();
		value.SetLocation(fvectorDouble);
		FQuat fquat = this.SplineComp.GetRotationAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World).Quaternion();
		value.SetRotation(fquat);
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(value);
		this.StartEffectHandle = instance.SpawnEffect(world, ftransformDouble, "/Game/Aki/Effect/EffectGroup/Scenes/3_2/3_2YinYou/DA_Fx_Group_Start.DA_Fx_Group_Start", "[RhythmGameController] Spawn Start Effect", null, EEffectType.Scene, null, null, null, false, false);
		this.RhythmGameTimerSystem.Delay(delegate(float _)
		{
			ControllerBase<RhythmGameShipController>.Instance.SpawnStartTrailEffect();
			this.PlayerCanInput = true;
		}, startCameraConfig.Time * 1000f, null, null, true, 1f);
		this.RhythmGameTimerSystem.Delay(delegate(float _)
		{
			if (this.StartEffectHandle != -1)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.StartEffectHandle, "[RhythmGameController] Stop Start Effect", false, null);
				this.StartEffectHandle = -1;
			}
		}, (startCameraConfig.Time + 2f) * 1000f, null, null, true, 1f);
	}

	// Token: 0x0600742F RID: 29743 RVA: 0x001E5E70 File Offset: 0x001E4070
	private void LoadMusicAndPause()
	{
		if (this.MusicEvent != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RhythmGame;
			ELogAuthor author = ELogAuthor.CH;
			string message = "PlayMusic";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("curLevelConfig.Music", this.MusicEvent);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.MusicEventHandle = Singleton<AudioSystem>.Instance.PostEvent(this.MusicEvent, null, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.MusicPlayStarted),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo _)
				{
					if (callbackType == EAkCallbackType.MusicPlayStarted && !this.IsBeginPlayMusic)
					{
						Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
						{
							TransitionDuration = new int?(0)
						}));
						Singleton<AudioSystem>.Instance.SeekOnEvent(this.MusicEvent, 0, new SeekOnEventArgs?(new SeekOnEventArgs
						{
							Handle = new int?(this.MusicEventHandle)
						}));
					}
				}
			}));
		}
	}

	// Token: 0x06007430 RID: 29744 RVA: 0x001E5EFD File Offset: 0x001E40FD
	private void PlayStartingCameraAnim()
	{
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager != null)
		{
			rhythmGameManager.StartGame();
		}
		this.RhythmGameTimerSystem.Delay(delegate(float _)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.IsBeginPlayMusic = true;
		}, this.TotalOffset * 1000f, null, null, true, 1f);
	}

	// Token: 0x06007431 RID: 29745 RVA: 0x001E5F3C File Offset: 0x001E413C
	private void ClearCache()
	{
		if (this.SplineActor != null && this.SplineActor.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("RhythmGameController.ClearCacheSpline", this.SplineActor, null);
			this.SplineActor = null;
		}
		if (this.ShipActor != null && this.ShipActor.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("RhythmGameController.ClearCacheShip", this.ShipActor, null);
			this.ShipActor = null;
		}
		if (this.SplineComp != null && this.SplineComp.IsValid())
		{
			this.SplineComp = null;
		}
		if (this.RhythmGameManager != null && this.RhythmGameManager.IsValid())
		{
			this.RhythmGameManager.OnNoteResult.Remove(new Action<int, EKuroRhythmGameNoteType, EKuroRhythmGameRating, FVectorDouble, FQuat>(this.OnNoteResult));
			this.RhythmGameManager.OnAllNotesFinished.Remove(new Action(this.AllNotesFinished));
			this.RhythmGameManager.OnFeverStateChanged.Remove(new Action<bool>(this.OnFeverStateChanged));
			this.RhythmGameManager.OnHiddenScoreLevelChanged.Remove(new Action<int, int>(this.OnHiddenScoreLevelChanged));
			this.RhythmGameManager.OnFeverScoreChanged.Remove(new Action<int, int>(this.OnFeverScoreChanged));
			this.RhythmGameManager.OnJumpEvent.Remove(new Action<float>(this.OnJumpEvent));
			this.RhythmGameManager.OnTrackSwitched.Remove(new Action<int, int>(this.OnTrackSwitched));
			this.RhythmGameManager.OnHoldScoreUpdated.Remove(new Action<int, int>(this.OnHoldScoreUpdated));
			this.RhythmGameManager.OnGameEvent.Remove(new Action<EKuroRhythmChartEventType>(this.OnGameEvent));
			UKuroRhythmGameJudgement judgementSystem = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem != null)
			{
				judgementSystem.OnTunnelFlickSwitch.Remove(new Action<bool>(this.OnTunnelFlickSwitch));
			}
			UKuroRhythmGameJudgement judgementSystem2 = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem2 != null)
			{
				judgementSystem2.OnLineHitTrigger.Remove(new Action(this.OnLineHitTrigger));
			}
			UKuroRhythmGameJudgement judgementSystem3 = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem3 != null)
			{
				judgementSystem3.OnAutoJudgeCountChange.Remove(new Action<int>(this.OnAutoJudgeCountChange));
			}
			UKuroRhythmGameJudgement judgementSystem4 = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem4 != null)
			{
				judgementSystem4.OnHoldNoteInputReleased.Remove(new Action(this.OnHoldNoteStop));
			}
			UKuroRhythmGameJudgement judgementSystem5 = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem5 != null)
			{
				judgementSystem5.OnHoldNoteTimeout.Remove(new Action(this.OnHoldNoteStop));
			}
			UKuroRhythmGameJudgement judgementSystem6 = this.RhythmGameManager.JudgementSystem;
			if (judgementSystem6 != null)
			{
				judgementSystem6.OnHoldNoteTimeout.Remove(new Action(this.OnHoldNoteTimeout));
			}
			this.RhythmGameManager.Cleanup();
			this.RhythmGameManager = null;
		}
		if (this.ChangedCamera)
		{
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitSpecialGameplayCamera();
			this.ChangedCamera = false;
		}
		if (this.StartEffectHandle != -1)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.StartEffectHandle, "[RhythmGameController] Stop Start Effect", false, null);
			this.StartEffectHandle = -1;
		}
		if (this.RhythmGameManagerTickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.RhythmGameManagerTickId);
			this.RhythmGameManagerTickId = -1;
		}
		ControllerBase<RhythmGameShipController>.Instance.Release();
		this.IsBeginPlayMusic = false;
		ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex = 0;
		this.ClearTimerSystem();
		this.StopRoleFeverAudio();
		this.IsPause = false;
		this.GuideIds = Array.Empty<int>();
		this.CurrentGuideId = 0;
		this.IsAccumulatingTimeOffset = false;
		this.CachedTimeOffset = 0f;
	}

	// Token: 0x06007432 RID: 29746 RVA: 0x001E62AC File Offset: 0x001E44AC
	private void RhythmGameManagerTick(float deltaTime)
	{
		if (this.IsPause)
		{
			return;
		}
		this.GetOffsetFromMusic();
		if (this.IsAccumulatingTimeOffset && this.CachedTimeOffset != 0f)
		{
			UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
			if (rhythmGameManager != null && rhythmGameManager.IsValid())
			{
				float num = Math.Min(Math.Abs(this.CachedTimeOffset), this.TimeOffsetApplySpeed * deltaTime / 1000f) * (float)Math.Sign(this.CachedTimeOffset);
				this.RhythmGameManager.GameplayTimeOffset += num;
				this.CachedTimeOffset -= num;
				if (Math.Abs(this.CachedTimeOffset) < 0.0001f)
				{
					this.CachedTimeOffset = 0f;
					this.IsAccumulatingTimeOffset = false;
				}
			}
		}
		UKuroRhythmGameManager rhythmGameManager2 = this.RhythmGameManager;
		if (rhythmGameManager2 != null && rhythmGameManager2.IsValid())
		{
			this.RhythmGameManager.Tick(deltaTime);
		}
		if (this.RhythmGameTimerSystem != null)
		{
			this.RhythmGameTimerSystem.Tick(deltaTime);
		}
	}

	// Token: 0x06007433 RID: 29747 RVA: 0x001E639C File Offset: 0x001E459C
	private unsafe void OnNoteResult(int noteIndex, EKuroRhythmGameNoteType noteType, EKuroRhythmGameRating result, FVectorDouble worldPosition, FQuat rotation)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnNoteResult: ";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("noteIndex", noteIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("noteType", noteType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("result", result);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnRhythmGameNoteResultUpdate;
		EKuroRhythmGameRating? p = new EKuroRhythmGameRating?(result);
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		instance2.Emit<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(name, p, (rhythmGameManager != null) ? rhythmGameManager.Statistics : null);
		if (result != EKuroRhythmGameRating.Miss)
		{
			this.PlayHitResultEffect(noteType, new FVectorDouble?(worldPosition), new FQuat?(rotation));
			if (noteType == EKuroRhythmGameNoteType.KuroTapLeft || noteType == EKuroRhythmGameNoteType.KuroTapRight)
			{
				ControllerBase<RhythmGameShipController>.Instance.TriggerTunnelTranslationAnim(noteType == EKuroRhythmGameNoteType.KuroTapLeft);
			}
			ControllerBase<RhythmGameShipController>.Instance.TriggerHitLockEffect();
			this.PlayHitAudioEvent(noteType);
		}
	}

	// Token: 0x06007434 RID: 29748 RVA: 0x001E6490 File Offset: 0x001E4690
	private void PlayHitAudioEvent(EKuroRhythmGameNoteType noteType)
	{
		double hitTime = Singleton<Time>.Instance.Now;
		Action<EAkCallbackType, UAkCallbackInfo> <>9__1;
		Func<string, int> func = delegate(string eventName)
		{
			AudioSystem instance = Singleton<AudioSystem>.Instance;
			AActor target = null;
			PostEventArgs value = default(PostEventArgs);
			value.CallbackMask = new ECallbackMask?(ECallbackMask.Duration);
			Action<EAkCallbackType, UAkCallbackInfo> callbackHandler;
			if ((callbackHandler = <>9__1) == null)
			{
				callbackHandler = (<>9__1 = delegate(EAkCallbackType callbackType, UAkCallbackInfo _)
				{
					if (callbackType == EAkCallbackType.Duration)
					{
						double now = Singleton<Time>.Instance.Now;
						double hitTime = hitTime;
					}
				});
			}
			value.CallbackHandler = callbackHandler;
			return instance.PostEvent(eventName, target, new PostEventArgs?(value));
		};
		switch (noteType)
		{
		case EKuroRhythmGameNoteType.Kuro3DFlickLeft:
		case EKuroRhythmGameNoteType.Kuro3DFlickRight:
			func("play_ui_rhythmship_gamenote_spin");
			return;
		case EKuroRhythmGameNoteType.KuroLine:
			func("play_ui_rhythmship_gamenote_line");
			return;
		case EKuroRhythmGameNoteType.KuroLineHold:
			if (this.HoldNoteEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.HoldNoteEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			this.HoldNoteEventHandle = func("play_ui_rhythmship_gamenote_line_loop");
			return;
		case EKuroRhythmGameNoteType.KuroLineHit:
			func("play_ui_rhythmship_gamenote_air");
			return;
		default:
			func("play_ui_rhythmship_gamenote_normal");
			return;
		}
	}

	// Token: 0x06007435 RID: 29749 RVA: 0x001E6558 File Offset: 0x001E4758
	private void OnHoldNoteStop()
	{
		if (this.HoldNoteEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.HoldNoteEventHandle, EAudioActionType.Stop, null);
			this.HoldNoteEventHandle = 0;
		}
	}

	// Token: 0x06007436 RID: 29750 RVA: 0x001E658E File Offset: 0x001E478E
	private void OnHoldNoteTimeout()
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamenote_line");
	}

	// Token: 0x06007437 RID: 29751 RVA: 0x001E65A0 File Offset: 0x001E47A0
	private void OnFeverStateChanged(bool bFeverActive)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnFeverStateChanged";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bFeverActive", bFeverActive);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRhythmGameFeverModeChanged, bFeverActive);
		if (bFeverActive)
		{
			if (this.FeverLoopEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			this.FeverLoopEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamefever_start_loop");
			this.FeverTimes++;
			return;
		}
		if (this.FeverLoopEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Stop, null);
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamefever_end");
	}

	// Token: 0x06007438 RID: 29752 RVA: 0x001E667C File Offset: 0x001E487C
	private unsafe void OnHiddenScoreLevelChanged(int newLevel, int oldLevel)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnHiddenScoreLevelChanged: ";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newLevel", newLevel - 1);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldLevel", oldLevel - 1);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex = newLevel - 1;
		if (newLevel > oldLevel)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamespeedlevel_up");
			return;
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_rhythmship_gamespeedlevel_down");
	}

	// Token: 0x06007439 RID: 29753 RVA: 0x001E6720 File Offset: 0x001E4920
	private unsafe void OnFeverScoreChanged(int newScore, int oldScore)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnFeverScoreChanged: ";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newScore", newScore);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldScore", oldScore);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnRhythmGameFeverScoreChanged, newScore, oldScore);
	}

	// Token: 0x0600743A RID: 29754 RVA: 0x001E67A0 File Offset: 0x001E49A0
	private void AllNotesFinished()
	{
		RhythmGamePerformanceCameraConfig endCameraConfig = ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.EndCameraConfig;
		Singleton<EventSystem>.Instance.Emit<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameEndPhase, endCameraConfig);
		this.IsBeginPlayMusic = false;
		this.RhythmGameTimerSystem.Delay(delegate(float _)
		{
			this.PlayerCanInput = false;
		}, 300f, null, null, true, 1f);
		if (endCameraConfig.Time > 0.02f)
		{
			this.RhythmGameTimerSystem.Delay(delegate(float _)
			{
				this.OnStopRhythmGame(false);
			}, endCameraConfig.Time * 1000f, null, null, true, 1f);
			return;
		}
		this.OnStopRhythmGame(false);
	}

	// Token: 0x0600743B RID: 29755 RVA: 0x001E683C File Offset: 0x001E4A3C
	public void OnStopRhythmGame(bool isQuit = false)
	{
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "OnAllNotesFinished", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.FeverLoopEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Stop, null);
		}
		RhythmResultPayload payload = RhythmResultPayload.Create();
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		FKuroRhythmGameStatistics fkuroRhythmGameStatistics = (rhythmGameManager != null) ? rhythmGameManager.Statistics : null;
		payload.Score = ((fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.TotalScore : 0);
		int num = (fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.PerfectCount : 0;
		int num2 = (fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.GreatCount : 0;
		int num3 = (fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.GoodCount : 0;
		int num4 = (fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.BadCount : 0;
		int num5 = (fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.MissCount : 0;
		foreach (int item in new int[]
		{
			num,
			num2,
			num3,
			num4,
			num5
		})
		{
			payload.JudgementCount.Add(item);
		}
		payload.MaxCombo = ((fkuroRhythmGameStatistics != null) ? fkuroRhythmGameStatistics.MaxCombo : 0);
		payload.CostSecond = (int)this.CurrentPlayedTime();
		payload.FeverCount = this.FeverTimes;
		RhythmSubLevel? config = ConfigRhythmSubLevelById.GetConfig(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId, true);
		string text = (config != null) ? config.GetValueOrDefault().RatingJud1 : null;
		if (StringUtils.IsBlank(text))
		{
			payload.Rank = RhythmShipRank.Sss;
		}
		else
		{
			int[] array2 = Json.Parse<int[]>(text, null);
			int j = 0;
			bool flag = false;
			while (j < array2.Length)
			{
				if (payload.Score >= array2[j])
				{
					flag = true;
					break;
				}
				j++;
			}
			if (flag)
			{
				payload.Rank = j + RhythmShipRank.Sss;
			}
			else
			{
				payload.Rank = RhythmShipRank.B;
			}
		}
		int num6 = num + num2 + num3 + num4;
		FKuroRhythmChartData rhythmGameData = this.RhythmGameData;
		int? num7;
		if (rhythmGameData == null)
		{
			num7 = null;
		}
		else
		{
			TArray<FKuroRhythmGameNote> notes = rhythmGameData.Notes;
			num7 = ((notes != null) ? new int?(notes.Count) : null);
		}
		int? num8 = num7;
		int valueOrDefault = num8.GetValueOrDefault(1);
		int num9 = (int)Math.Round((double)((float)num6 / (float)valueOrDefault * 10000f));
		payload.Accuracy = (int)Math.Round((double)((float)num6 / (float)valueOrDefault * 10000f));
		payload.Completion = num9;
		Dictionary<ERhythmShipSettlementType, int> settlementItemMap = new Dictionary<ERhythmShipSettlementType, int>
		{
			{
				ERhythmShipSettlementType.Miss,
				num5
			},
			{
				ERhythmShipSettlementType.OK,
				num4
			},
			{
				ERhythmShipSettlementType.Good,
				num3
			},
			{
				ERhythmShipSettlementType.Great,
				num2
			},
			{
				ERhythmShipSettlementType.Perfect,
				num
			}
		};
		bool isFp = num == valueOrDefault;
		bool isFc = payload.MaxCombo == valueOrDefault;
		if (isQuit)
		{
			ControllerBase<RhythmShipController>.Instance.RhythmSettleRequest(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId, RhythmSettleReasonPb.Quit, payload, settlementItemMap, this.IsDisableRecordUpLoad, isQuit);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipGameEndTipView, new RhythmShipGameEndTipViewOpenParam
		{
			Level = (int)payload.Rank,
			IsFp = isFp,
			IsFc = isFc,
			Accuracy = (float)num9 / 100f,
			Callback = delegate()
			{
				ControllerBase<RhythmShipController>.Instance.RhythmSettleRequest(ModelBase<RhythmShipModel>.Instance.RhythmShipSubLevelId, RhythmSettleReasonPb.Complete, payload, settlementItemMap, this.IsDisableRecordUpLoad, false);
			}
		}, null);
	}

	// Token: 0x0600743C RID: 29756 RVA: 0x001E6B98 File Offset: 0x001E4D98
	private void OnTunnelFlickSwitch(bool bToLeft)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnTunnelFlickSwitch";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bToLeft", bToLeft);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<RhythmGameShipController>.Instance.TriggerRollAnim(bToLeft);
	}

	// Token: 0x0600743D RID: 29757 RVA: 0x001E6BE0 File Offset: 0x001E4DE0
	private void OnLineHitTrigger()
	{
		Singleton<Log>.Instance.Info(ELogModule.RhythmGame, ELogAuthor.CH, "OnLineHitTrigger", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<RhythmGameShipController>.Instance.TriggerLineHit();
	}

	// Token: 0x0600743E RID: 29758 RVA: 0x001E6C18 File Offset: 0x001E4E18
	private void OnJumpEvent(float beatDurationMs)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnJumpEvent";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("beatDurationMs", beatDurationMs);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<RhythmGameShipController>.Instance.TriggerJumpAnim();
	}

	// Token: 0x0600743F RID: 29759 RVA: 0x001E6C60 File Offset: 0x001E4E60
	private unsafe void OnTrackSwitched(int newTrackIndex, int oldTrackIndex)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnTrackSwitched";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newTrackIndex", newTrackIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldTrackIndex", oldTrackIndex);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ControllerBase<RhythmGameShipController>.Instance.TriggerTranslationAnim(newTrackIndex < oldTrackIndex);
	}

	// Token: 0x06007440 RID: 29760 RVA: 0x001E6CDC File Offset: 0x001E4EDC
	private unsafe void OnHoldScoreUpdated(int newHoldScore, int oldHoldScore)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "OnHoldScoreUpdated";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("newHoldScore", newHoldScore);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("oldHoldScore", oldHoldScore);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.OnRhythmGameNoteResultUpdate;
		EKuroRhythmGameRating? p = null;
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		instance2.Emit<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(name, p, (rhythmGameManager != null) ? rhythmGameManager.Statistics : null);
	}

	// Token: 0x06007441 RID: 29761 RVA: 0x001E6D74 File Offset: 0x001E4F74
	private unsafe void PlayHitResultEffect(EKuroRhythmGameNoteType noteType, FVectorDouble? worldPosition, FQuat? rotation)
	{
		IReadOnlyList<string> readOnlyList2;
		if (!RhythmGameModelDefine.RhythmGameHitResultEffect.ContainsKey(noteType))
		{
			IReadOnlyList<string> readOnlyList = new string[0];
			readOnlyList2 = readOnlyList;
		}
		else
		{
			readOnlyList2 = RhythmGameModelDefine.RhythmGameHitResultEffect[noteType];
		}
		IReadOnlyList<string> readOnlyList3 = readOnlyList2;
		if (!ModelBase<RhythmGameModel>.Instance.OnRoadMode && noteType == EKuroRhythmGameNoteType.KuroLine)
		{
			readOnlyList3 = new string[]
			{
				"/Game/Aki/Effect/DataAsset/Niagara/Scene/3_2/3_2YinYou/DA_FX_Yinyou_Rectangle_Sparks_02.DA_FX_Yinyou_Rectangle_Sparks_02"
			};
		}
		string text = RhythmGameModelDefine.RhythmGameHitResultExternalEffect.ContainsKey(noteType) ? RhythmGameModelDefine.RhythmGameHitResultExternalEffect[noteType] : "";
		if (readOnlyList3.Count == 0 && StringUtils.IsBlank(text))
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.CH;
		string message = "PlayHitResultEffect";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("worldPosition", worldPosition);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("rotation", rotation);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("effectPath", readOnlyList3);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		FTransformDouble value = new FTransformDouble();
		FVectorDouble fvectorDouble = worldPosition ?? new FVectorDouble();
		value.SetLocation(fvectorDouble);
		FQuat fquat = rotation ?? new FQuat();
		value.SetRotation(fquat);
		foreach (string text2 in readOnlyList3)
		{
			if (!StringUtils.IsBlank(text2))
			{
				EffectSystem instance2 = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(value);
				instance2.SpawnEffect(world, ftransformDouble, text2, "PlayHitResultEffect", null, EEffectType.Scene, null, null, null, false, false);
			}
		}
		if (!StringUtils.IsBlank(text))
		{
			EffectSystem instance3 = Singleton<EffectSystem>.Instance;
			UObject world2 = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			int id = instance3.SpawnEffect(world2, ftransformDouble, text, "PlayHitResultEffect", null, EEffectType.Scene, null, null, null, false, false);
			Singleton<EffectSystem>.Instance.GetEffectActor(id).K2_AttachToComponent(this.ShipActor.SkeletalMesh, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
		}
	}

	// Token: 0x06007442 RID: 29762 RVA: 0x001E6F88 File Offset: 0x001E5188
	private void OnAutoJudgeCountChange(int autoJudgeCount)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RhythmGame;
		ELogAuthor author = ELogAuthor.BB;
		string message = "OnAutoJudgeCountChange";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("autoJudgeCount", autoJudgeCount);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRhythmGameAutoJudgeCountChanged, autoJudgeCount);
	}

	// Token: 0x06007443 RID: 29763 RVA: 0x001E6FD5 File Offset: 0x001E51D5
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.RhythmShipPauseView || viewName == EUiViewName.GuideTutorialView || viewName == EUiViewName.GuideTutorialPopView)
		{
			this.PauseGame();
		}
	}

	// Token: 0x06007444 RID: 29764 RVA: 0x001E7004 File Offset: 0x001E5204
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.RhythmShipPauseView || viewName == EUiViewName.GuideTutorialView || viewName == EUiViewName.GuideTutorialPopView)
		{
			this.ResumeGame();
		}
	}

	// Token: 0x06007445 RID: 29765 RVA: 0x001E7033 File Offset: 0x001E5233
	public int GetCurrentBeatDurationMs()
	{
		return (int)Math.Round((double)(60f / this.RhythmGameManager.CurrentBPM * 1000f));
	}

	// Token: 0x06007446 RID: 29766 RVA: 0x001E7054 File Offset: 0x001E5254
	public void StopRhythmGame()
	{
		this.OnStopRhythmGame(false);
		if (this.MusicEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.MusicEventHandle = 0;
		}
	}

	// Token: 0x06007447 RID: 29767 RVA: 0x001E70A3 File Offset: 0x001E52A3
	public void SetShipSpeed(float speed)
	{
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager == null)
		{
			return;
		}
		rhythmGameManager.SetShipMovementSpeed(speed);
	}

	// Token: 0x06007448 RID: 29768 RVA: 0x001E70B8 File Offset: 0x001E52B8
	public void PauseGame()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRhythmGameEndCoolDown);
		this.IsPause = true;
		this.PlayerCanInput = false;
		this.LineHoldKeyPressed = false;
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		if (rhythmGameManager != null)
		{
			rhythmGameManager.PauseGame();
		}
		this.PauseRoleFeverAudio();
		if (this.MusicEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
		}
		if (this.HoldNoteEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.HoldNoteEventHandle, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
		}
		if (this.FeverLoopEventHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
		}
	}

	// Token: 0x06007449 RID: 29769 RVA: 0x001E719D File Offset: 0x001E539D
	public void ResumeGame()
	{
		Singleton<EventSystem>.Instance.Emit<TTimerAction>(EEventName.OnRhythmGameStartCoolDown, delegate(float _)
		{
			this.IsPause = false;
			this.PlayerCanInput = true;
			UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
			if (rhythmGameManager != null)
			{
				rhythmGameManager.ResumeGame();
			}
			this.ResumeRoleFeverAudio();
			if (this.MusicEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.SeekOnEvent(this.MusicEvent, (int)(this.CurrentPlayedTime() * 1000f), new SeekOnEventArgs?(new SeekOnEventArgs
				{
					Handle = new int?(this.MusicEventHandle)
				}));
				Singleton<AudioSystem>.Instance.ExecuteAction(this.MusicEventHandle, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			if (this.HoldNoteEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.HoldNoteEventHandle, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			if (this.FeverLoopEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.FeverLoopEventHandle, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(0)
				}));
			}
			if (!this.LineHoldKeyPressed)
			{
				UKuroRhythmGameManager rhythmGameManager2 = this.RhythmGameManager;
				if (rhythmGameManager2 != null && rhythmGameManager2.bLineKeyPressed)
				{
					UKuroRhythmGameManager rhythmGameManager3 = this.RhythmGameManager;
					if (rhythmGameManager3 == null)
					{
						return;
					}
					rhythmGameManager3.OnPlayerInputUp(EKuroRhythmGameInputType.Line);
				}
			}
		});
	}

	// Token: 0x0600744A RID: 29770 RVA: 0x001E71BC File Offset: 0x001E53BC
	public float CurrentPlayedTime()
	{
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		float num = (rhythmGameManager != null) ? rhythmGameManager.GetGameplayTime() : 0f;
		if (num < this.TotalOffset)
		{
			return 0f;
		}
		return num - this.TotalOffset;
	}

	// Token: 0x0600744B RID: 29771 RVA: 0x001E71F7 File Offset: 0x001E53F7
	public void ApplyAudioTimeOffset(float offset)
	{
		this.CachedTimeOffset = offset / 1000f;
		this.IsAccumulatingTimeOffset = true;
	}

	// Token: 0x0600744C RID: 29772 RVA: 0x001E720D File Offset: 0x001E540D
	public TsGameSplineActor GetSplineActor()
	{
		return this.SplineActor;
	}

	// Token: 0x0600744D RID: 29773 RVA: 0x001E7218 File Offset: 0x001E5418
	public void SetRhythmGameStatistics(int score, int accuracy, int perfectCount, int greatCount, int goodCount, int badCount, int missCount, int maxCombo)
	{
		UKuroRhythmGameManager rhythmGameManager = this.RhythmGameManager;
		FKuroRhythmGameStatistics fkuroRhythmGameStatistics = (rhythmGameManager != null) ? rhythmGameManager.Statistics : null;
		if (fkuroRhythmGameStatistics != null)
		{
			fkuroRhythmGameStatistics.TotalScore = score;
			fkuroRhythmGameStatistics.Accuracy = (float)accuracy;
			fkuroRhythmGameStatistics.PerfectCount = perfectCount;
			fkuroRhythmGameStatistics.GreatCount = greatCount;
			fkuroRhythmGameStatistics.GoodCount = goodCount;
			fkuroRhythmGameStatistics.BadCount = badCount;
			fkuroRhythmGameStatistics.MissCount = missCount;
			fkuroRhythmGameStatistics.MaxCombo = maxCombo;
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnRhythmGameNoteResultUpdate;
			EKuroRhythmGameRating? p = null;
			UKuroRhythmGameManager rhythmGameManager2 = this.RhythmGameManager;
			instance.Emit<EKuroRhythmGameRating?, FKuroRhythmGameStatistics>(name, p, (rhythmGameManager2 != null) ? rhythmGameManager2.Statistics : null);
		}
	}

	// Token: 0x0600744E RID: 29774 RVA: 0x001E72AC File Offset: 0x001E54AC
	[NullableContext(1)]
	public void PlayRoleFeverAudio(string musicEvent)
	{
		this.StopRoleFeverAudio();
		int handleId = -1;
		handleId = Singleton<AudioSystem>.Instance.PostEvent(musicEvent, null, new PostEventArgs?(new PostEventArgs
		{
			CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
			CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo _)
			{
				if (callbackType == EAkCallbackType.EndOfEvent && this.RoleFeverAudioHandle == handleId)
				{
					this.StopRoleFeverAudio();
				}
			}
		}));
		this.RoleFeverAudioHandle = handleId;
	}

	// Token: 0x0600744F RID: 29775 RVA: 0x001E7320 File Offset: 0x001E5520
	private void StopRoleFeverAudio()
	{
		if (this.RoleFeverAudioHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.RoleFeverAudioHandle, EAudioActionType.Stop, null);
			this.RoleFeverAudioHandle = 0;
		}
	}

	// Token: 0x06007450 RID: 29776 RVA: 0x001E7358 File Offset: 0x001E5558
	private void PauseRoleFeverAudio()
	{
		if (this.RoleFeverAudioHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.RoleFeverAudioHandle, EAudioActionType.Pause, null);
		}
	}

	// Token: 0x06007451 RID: 29777 RVA: 0x001E7388 File Offset: 0x001E5588
	private void ResumeRoleFeverAudio()
	{
		if (this.RoleFeverAudioHandle != 0)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.RoleFeverAudioHandle, EAudioActionType.Resume, null);
		}
	}

	// Token: 0x06007452 RID: 29778 RVA: 0x001E73B7 File Offset: 0x001E55B7
	public bool GetIsPause()
	{
		return this.IsPause;
	}

	// Token: 0x040037EB RID: 14315
	private const int SplineEntityId = 229800000;

	// Token: 0x040037EC RID: 14316
	[Nullable(1)]
	private const string RhythmGameConfigPath = "/Game/Aki/Data/Gameplay/RhythmGame/DefaultRhythmGameConfig.DefaultRhythmGameConfig";

	// Token: 0x040037ED RID: 14317
	private const int LockInputAfterFinishTime = 300;

	// Token: 0x040037EE RID: 14318
	private BP_Plane_C ShipActor;

	// Token: 0x040037EF RID: 14319
	private TsGameSplineActor SplineActor;

	// Token: 0x040037F0 RID: 14320
	private USplineComponent SplineComp;

	// Token: 0x040037F1 RID: 14321
	private UKuroRhythmGameManager RhythmGameManager;

	// Token: 0x040037F2 RID: 14322
	private bool ChangedCamera;

	// Token: 0x040037F3 RID: 14323
	private int RhythmGameManagerTickId = -1;

	// Token: 0x040037F4 RID: 14324
	private FKuroRhythmChartData RhythmGameData;

	// Token: 0x040037F5 RID: 14325
	private string MusicEvent;

	// Token: 0x040037F6 RID: 14326
	private int StartEffectHandle = -1;

	// Token: 0x040037F7 RID: 14327
	private float TotalOffset;

	// Token: 0x040037F8 RID: 14328
	private bool IsPause;

	// Token: 0x040037F9 RID: 14329
	private bool IsDisableRecordUpLoad;

	// Token: 0x040037FA RID: 14330
	private bool IsBeginPlayMusic;

	// Token: 0x040037FB RID: 14331
	[Nullable(1)]
	private int[] GuideIds = Array.Empty<int>();

	// Token: 0x040037FC RID: 14332
	public bool PlayerCanInput;

	// Token: 0x040037FD RID: 14333
	private bool LineHoldKeyPressed;

	// Token: 0x040037FE RID: 14334
	private int MusicEventHandle;

	// Token: 0x040037FF RID: 14335
	private int CurrentGuideId;

	// Token: 0x04003800 RID: 14336
	private int HoldNoteEventHandle;

	// Token: 0x04003801 RID: 14337
	private int FeverLoopEventHandle;

	// Token: 0x04003802 RID: 14338
	private float CachedTimeOffset;

	// Token: 0x04003803 RID: 14339
	private bool IsAccumulatingTimeOffset;

	// Token: 0x04003804 RID: 14340
	private readonly float TimeOffsetApplySpeed = 0.3f;

	// Token: 0x04003805 RID: 14341
	private int FeverTimes;

	// Token: 0x04003806 RID: 14342
	public TimerSystemInstance RhythmGameTimerSystem;

	// Token: 0x04003807 RID: 14343
	private int RoleFeverAudioHandle;

	// Token: 0x04003808 RID: 14344
	private bool IsEnterRhythmGame;
}
