using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C49 RID: 11337
[NullableContext(1)]
[Nullable(0)]
public class UiCameraSequenceComponent : UiCameraComponent
{
	// Token: 0x06016B64 RID: 93028 RVA: 0x0064E48E File Offset: 0x0064C68E
	public UiCameraSequenceComponent()
	{
		this.OnUiCameraSequenceFinishedCallbackList = new List<Action>();
	}

	// Token: 0x06016B65 RID: 93029 RVA: 0x0064E4A1 File Offset: 0x0064C6A1
	protected override void OnDestroy()
	{
		this.DestroyUiCameraSequence(true, ERestoreStateType.NotSet);
	}

	// Token: 0x06016B66 RID: 93030 RVA: 0x0064E4AC File Offset: 0x0064C6AC
	public void PlayUiCameraSequence(ULevelSequence levelSequence, float playRate = 1f, bool bReverse = false, bool bAutoDestroyBlackScreen = true, [Nullable(2)] AActor originActor = null)
	{
		this.SequenceActor = this.CreateLevelSequenceActor(levelSequence);
		if (this.SequenceActor == null)
		{
			return;
		}
		this.SequenceActor.bOverrideInstanceData = false;
		this.LevelSequenceInstanceData = (this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData);
		this.SequenceActor.SetTickableWhenPaused(true);
		this.SetTransformOriginActor(originActor);
		this.TryAddBindUiCameraSequence(this.SequenceActor);
		this.IsAutoDestroyBlackScreen = bAutoDestroyBlackScreen;
		ULevelSequencePlayer sequencePlayer = this.SequenceActor.SequencePlayer;
		sequencePlayer.SetPlayRate(playRate);
		sequencePlayer.OnFinished.Add(new Action(this.OnUiCameraSequenceFinished));
		sequencePlayer.OnStop.Add(new Action(this.OnUiCameraSequenceStop));
		sequencePlayer.OnPlay.Add(new Action(this.OnUiCameraSequencePlay));
		sequencePlayer.OnPlayReverse.Add(new Action(this.OnUiCameraSequenceOnPlayReverse));
		if (bReverse)
		{
			sequencePlayer.PlayReverse();
			return;
		}
		sequencePlayer.Play();
	}

	// Token: 0x06016B67 RID: 93031 RVA: 0x0064E598 File Offset: 0x0064C798
	public UniTask LoadAndPlayUiCameraSequence(TSoftObjectPtr<ULevelSequence> sequenceSoftObjectPtr, float playRate, bool bReverse, [Nullable(2)] AActor originActor = null)
	{
		UiCameraSequenceComponent.<LoadAndPlayUiCameraSequence>d__12 <LoadAndPlayUiCameraSequence>d__;
		<LoadAndPlayUiCameraSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadAndPlayUiCameraSequence>d__.<>4__this = this;
		<LoadAndPlayUiCameraSequence>d__.sequenceSoftObjectPtr = sequenceSoftObjectPtr;
		<LoadAndPlayUiCameraSequence>d__.playRate = playRate;
		<LoadAndPlayUiCameraSequence>d__.bReverse = bReverse;
		<LoadAndPlayUiCameraSequence>d__.originActor = originActor;
		<LoadAndPlayUiCameraSequence>d__.<>1__state = -1;
		<LoadAndPlayUiCameraSequence>d__.<>t__builder.Start<UiCameraSequenceComponent.<LoadAndPlayUiCameraSequence>d__12>(ref <LoadAndPlayUiCameraSequence>d__);
		return <LoadAndPlayUiCameraSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06016B68 RID: 93032 RVA: 0x0064E5FC File Offset: 0x0064C7FC
	public void Pause()
	{
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor == null || !sequenceActor.IsValid())
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = this.SequenceActor.SequencePlayer;
		if (sequencePlayer == null || !sequencePlayer.IsValid())
		{
			return;
		}
		sequencePlayer.Pause();
	}

	// Token: 0x06016B69 RID: 93033 RVA: 0x0064E648 File Offset: 0x0064C848
	public void Continue()
	{
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor == null || !sequenceActor.IsValid())
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = this.SequenceActor.SequencePlayer;
		if (sequencePlayer == null || !sequencePlayer.IsValid())
		{
			return;
		}
		if (sequencePlayer.IsPaused())
		{
			sequencePlayer.Play();
		}
	}

	// Token: 0x06016B6A RID: 93034 RVA: 0x0064E699 File Offset: 0x0064C899
	public void DestroyUiCameraSequence(bool bDestroyBlackScreen = true, ERestoreStateType restoreStateType = ERestoreStateType.NotSet)
	{
		this.StopUiCameraSequence(bDestroyBlackScreen, restoreStateType);
		this.DestroySequenceActor();
	}

	// Token: 0x06016B6B RID: 93035 RVA: 0x0064E6AC File Offset: 0x0064C8AC
	private void FinishUiCameraSequence()
	{
		for (int i = 0; i < this.OnUiCameraSequenceFinishedCallbackList.Count; i++)
		{
			this.OnUiCameraSequenceFinishedCallbackList[i]();
		}
		this.DestroyUiCameraSequence(this.IsAutoDestroyBlackScreen, ERestoreStateType.NotSet);
	}

	// Token: 0x06016B6C RID: 93036 RVA: 0x0064E6F0 File Offset: 0x0064C8F0
	private void StopUiCameraSequence(bool bDestroyBlackScreen = true, ERestoreStateType restoreStateType = ERestoreStateType.NotSet)
	{
		if (this.SequenceActor != null)
		{
			ULevelSequencePlayer sequencePlayer = this.SequenceActor.SequencePlayer;
			if (restoreStateType != ERestoreStateType.NotSet)
			{
				sequencePlayer.PlaybackSettings.bRestoreState = (restoreStateType == ERestoreStateType.Restore);
			}
			sequencePlayer.Stop();
		}
		if (bDestroyBlackScreen)
		{
			this.DestroyBlackScreenView();
		}
		if (this.LoadSequenceHandleId != 0)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadSequenceHandleId);
			this.LoadSequenceHandleId = 0;
		}
	}

	// Token: 0x06016B6D RID: 93037 RVA: 0x0064E751 File Offset: 0x0064C951
	private void DestroySequenceActor()
	{
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor != null)
		{
			sequenceActor.SetShouldLatentDestroy(true);
		}
		this.SequenceActor = null;
		this.OnUiCameraSequenceFinishedCallbackList.Clear();
		this.OnCallUiCameraSequenceEvent = null;
		this.UiCameraSequenceEventName = null;
	}

	// Token: 0x06016B6E RID: 93038 RVA: 0x0064E785 File Offset: 0x0064C985
	public void ExecuteUiCameraSequenceEvent(string eventName)
	{
		if (this.OnCallUiCameraSequenceEvent == null)
		{
			return;
		}
		if (this.UiCameraSequenceEventName != eventName)
		{
			return;
		}
		this.OnCallUiCameraSequenceEvent();
	}

	// Token: 0x06016B6F RID: 93039 RVA: 0x0064E7AC File Offset: 0x0064C9AC
	public void SetTransformOrigin(FTransformDouble transform)
	{
		if (this.LevelSequenceInstanceData == null)
		{
			return;
		}
		this.SequenceActor.bOverrideInstanceData = true;
		FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(transform);
		this.LevelSequenceInstanceData.TransformOrigin = transformOrigin;
	}

	// Token: 0x06016B70 RID: 93040 RVA: 0x0064E7E1 File Offset: 0x0064C9E1
	[NullableContext(2)]
	public void SetTransformOriginActor(AActor actor)
	{
		if (this.LevelSequenceInstanceData == null)
		{
			return;
		}
		this.SequenceActor.bOverrideInstanceData = true;
		this.LevelSequenceInstanceData.TransformOriginActor = actor;
	}

	// Token: 0x06016B71 RID: 93041 RVA: 0x0064E804 File Offset: 0x0064CA04
	public void AddUiCameraSequenceEvent(string eventName, Action callback)
	{
		this.UiCameraSequenceEventName = eventName;
		this.OnCallUiCameraSequenceEvent = callback;
	}

	// Token: 0x06016B72 RID: 93042 RVA: 0x0064E814 File Offset: 0x0064CA14
	public void AddUiCameraSequenceFinishedCallback(Action onUiCameraSequenceFinishedCallback)
	{
		if (onUiCameraSequenceFinishedCallback == null)
		{
			return;
		}
		this.OnUiCameraSequenceFinishedCallbackList.Add(onUiCameraSequenceFinishedCallback);
	}

	// Token: 0x06016B73 RID: 93043 RVA: 0x0064E826 File Offset: 0x0064CA26
	private void OnUiCameraSequencePlay()
	{
		this.WaitPlayPromise.SetResult();
	}

	// Token: 0x06016B74 RID: 93044 RVA: 0x0064E833 File Offset: 0x0064CA33
	private void OnUiCameraSequenceOnPlayReverse()
	{
		this.WaitPlayPromise.SetResult();
	}

	// Token: 0x06016B75 RID: 93045 RVA: 0x0064E840 File Offset: 0x0064CA40
	private void OnUiCameraSequenceFinished()
	{
		this.FinishUiCameraSequence();
	}

	// Token: 0x06016B76 RID: 93046 RVA: 0x0064E848 File Offset: 0x0064CA48
	private void OnUiCameraSequenceStop()
	{
		if (this.IsAutoDestroyBlackScreen)
		{
			this.DestroyBlackScreenView();
		}
	}

	// Token: 0x06016B77 RID: 93047 RVA: 0x0064E858 File Offset: 0x0064CA58
	private ALevelSequenceActor CreateLevelSequenceActor(ULevelSequence levelSequence)
	{
		ALevelSequenceActor alevelSequenceActor = null;
		ULevelSequencePlayer.CreateLevelSequencePlayer(GlobalData.World, levelSequence, new FMovieSceneSequencePlaybackSettings(), ref alevelSequenceActor);
		alevelSequenceActor.SetSequence(levelSequence);
		return alevelSequenceActor;
	}

	// Token: 0x06016B78 RID: 93048 RVA: 0x0064E884 File Offset: 0x0064CA84
	private void TryAddBindUiCameraSequence(ALevelSequenceActor sequenceActor)
	{
		sequenceActor.ResetBindings();
		ULevelSequence sequence = sequenceActor.GetSequence();
		if (sequence.HasBindingTag(UiCameraSequenceDefine.BLACK_TEXTURE_TAG, true))
		{
			this.NewBlackScreenView().ContinueWith(delegate(BlackScreenView blackScreenView)
			{
				AActor blackScreenTextureActor = blackScreenView.GetBlackScreenTextureActor();
				sequenceActor.AddBindingByTag(UiCameraSequenceDefine.BLACK_TEXTURE_TAG, blackScreenTextureActor, false, false);
			});
		}
		if (sequence.HasBindingTag(UiCameraSequenceDefine.UI_CAMERA, true))
		{
			sequenceActor.AddBindingByTag(UiCameraSequenceDefine.UI_CAMERA, this.CameraActor, false, false);
		}
		if (sequence.HasBindingTag(UiCameraSequenceDefine.FIGHT_CAMERA, true))
		{
			ACameraActor cameraActor = ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraDisplayComponent>().CameraActor;
			sequenceActor.AddBindingByTag(UiCameraSequenceDefine.FIGHT_CAMERA, cameraActor, false, false);
		}
	}

	// Token: 0x06016B79 RID: 93049 RVA: 0x0064E93C File Offset: 0x0064CB3C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<BlackScreenView> NewBlackScreenView()
	{
		UiCameraSequenceComponent.<NewBlackScreenView>d__30 <NewBlackScreenView>d__;
		<NewBlackScreenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<BlackScreenView>.Create();
		<NewBlackScreenView>d__.<>4__this = this;
		<NewBlackScreenView>d__.<>1__state = -1;
		<NewBlackScreenView>d__.<>t__builder.Start<UiCameraSequenceComponent.<NewBlackScreenView>d__30>(ref <NewBlackScreenView>d__);
		return <NewBlackScreenView>d__.<>t__builder.Task;
	}

	// Token: 0x06016B7A RID: 93050 RVA: 0x0064E97F File Offset: 0x0064CB7F
	public void DestroyBlackScreenView()
	{
		if (this.BlackScreenViewInternal == null)
		{
			return;
		}
		this.BlackScreenViewInternal.Destroy(null);
		this.BlackScreenViewInternal = null;
	}

	// Token: 0x0400AF30 RID: 44848
	[Nullable(2)]
	private ALevelSequenceActor SequenceActor;

	// Token: 0x0400AF31 RID: 44849
	[Nullable(2)]
	private UDefaultLevelSequenceInstanceData LevelSequenceInstanceData;

	// Token: 0x0400AF32 RID: 44850
	[Nullable(2)]
	private BlackScreenView BlackScreenViewInternal;

	// Token: 0x0400AF33 RID: 44851
	private readonly List<Action> OnUiCameraSequenceFinishedCallbackList;

	// Token: 0x0400AF34 RID: 44852
	private bool IsAutoDestroyBlackScreen;

	// Token: 0x0400AF35 RID: 44853
	[Nullable(2)]
	private Action OnCallUiCameraSequenceEvent;

	// Token: 0x0400AF36 RID: 44854
	[Nullable(2)]
	private string UiCameraSequenceEventName;

	// Token: 0x0400AF37 RID: 44855
	private int LoadSequenceHandleId;

	// Token: 0x0400AF38 RID: 44856
	[Nullable(2)]
	private CustomPromise WaitPlayPromise;
}
