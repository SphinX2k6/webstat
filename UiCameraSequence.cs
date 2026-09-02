using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C35 RID: 11317
[NullableContext(1)]
[Nullable(0)]
public class UiCameraSequence
{
	// Token: 0x06016AD0 RID: 92880 RVA: 0x0064C3FC File Offset: 0x0064A5FC
	public void InitializeUiCameraSequence(ULevelSequence levelSequence)
	{
		this.SequenceActor = this.CreateLevelSequenceActor(levelSequence);
		this.SequenceActor.bOverrideInstanceData = false;
		this.LevelSequenceInstanceData = (this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData);
		this.TryAddBindUiCameraSequence(this.SequenceActor);
	}

	// Token: 0x06016AD1 RID: 92881 RVA: 0x0064C43C File Offset: 0x0064A63C
	public void PlayUiCameraSequence(float playRate, bool bReverse = false, bool bAutoDestroyBlackScreen = true)
	{
		if (this.SequenceActor == null)
		{
			return;
		}
		this.IsAutoDestroyBlackScreen = bAutoDestroyBlackScreen;
		ULevelSequencePlayer sequencePlayer = this.SequenceActor.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.SetPlayRate(playRate);
		sequencePlayer.OnFinished.Add(new Action(this.OnUiCameraSequenceFinished));
		if (bReverse)
		{
			sequencePlayer.PlayReverse();
			return;
		}
		sequencePlayer.Play();
	}

	// Token: 0x06016AD2 RID: 92882 RVA: 0x0064C498 File Offset: 0x0064A698
	public void Pause()
	{
		if (this.SequenceActor == null || !this.SequenceActor.IsValid())
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

	// Token: 0x06016AD3 RID: 92883 RVA: 0x0064C4DC File Offset: 0x0064A6DC
	public void Continue()
	{
		if (this.SequenceActor == null || !this.SequenceActor.IsValid())
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

	// Token: 0x06016AD4 RID: 92884 RVA: 0x0064C525 File Offset: 0x0064A725
	public void DestroyUiCameraSequence(bool bDestroyBlackScreen = true)
	{
		this.StopUiCameraSequence();
		this.DestroySequenceActor();
		if (bDestroyBlackScreen)
		{
			this.DestroyBlackScreenView();
		}
		this.OnUiCameraSequenceFinishedCallbackList.Clear();
		this.OnCallUiCameraSequenceEvent = null;
		this.UiCameraSequenceEventName = null;
	}

	// Token: 0x06016AD5 RID: 92885 RVA: 0x0064C558 File Offset: 0x0064A758
	private void FinishUiCameraSequence()
	{
		foreach (Action<UiCameraSequence> action in this.OnUiCameraSequenceFinishedCallbackList)
		{
			action(this);
		}
		this.DestroyUiCameraSequence(this.IsAutoDestroyBlackScreen);
	}

	// Token: 0x06016AD6 RID: 92886 RVA: 0x0064C5B8 File Offset: 0x0064A7B8
	private void StopUiCameraSequence()
	{
		ALevelSequenceActor sequenceActor = this.SequenceActor;
		if (sequenceActor == null)
		{
			return;
		}
		ULevelSequencePlayer sequencePlayer = sequenceActor.SequencePlayer;
		if (sequencePlayer == null)
		{
			return;
		}
		sequencePlayer.Stop();
	}

	// Token: 0x06016AD7 RID: 92887 RVA: 0x0064C5D4 File Offset: 0x0064A7D4
	private void DestroySequenceActor()
	{
		if (this.SequenceActor == null)
		{
			return;
		}
		this.SequenceActor.SetShouldLatentDestroy(true);
		this.SequenceActor = null;
	}

	// Token: 0x06016AD8 RID: 92888 RVA: 0x0064C5F2 File Offset: 0x0064A7F2
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

	// Token: 0x06016AD9 RID: 92889 RVA: 0x0064C618 File Offset: 0x0064A818
	public void SetTransformOrigin(FTransformDouble transform)
	{
		if (this.LevelSequenceInstanceData == null || this.SequenceActor == null)
		{
			return;
		}
		this.SequenceActor.bOverrideInstanceData = true;
		FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(transform);
		this.LevelSequenceInstanceData.TransformOrigin = transformOrigin;
	}

	// Token: 0x06016ADA RID: 92890 RVA: 0x0064C655 File Offset: 0x0064A855
	public void SetTransformOriginActor(AActor actor)
	{
		if (this.LevelSequenceInstanceData == null || this.SequenceActor == null)
		{
			return;
		}
		this.SequenceActor.bOverrideInstanceData = true;
		this.LevelSequenceInstanceData.TransformOriginActor = actor;
	}

	// Token: 0x06016ADB RID: 92891 RVA: 0x0064C680 File Offset: 0x0064A880
	public void AddUiCameraSequenceEvent(string eventName, Action callback)
	{
		this.UiCameraSequenceEventName = eventName;
		this.OnCallUiCameraSequenceEvent = callback;
	}

	// Token: 0x06016ADC RID: 92892 RVA: 0x0064C690 File Offset: 0x0064A890
	public void AddUiCameraSequenceFinishedCallback([Nullable(new byte[]
	{
		2,
		1
	})] Action<UiCameraSequence> callback)
	{
		if (callback == null)
		{
			return;
		}
		this.OnUiCameraSequenceFinishedCallbackList.Add(callback);
	}

	// Token: 0x06016ADD RID: 92893 RVA: 0x0064C6A2 File Offset: 0x0064A8A2
	private void OnUiCameraSequenceFinished()
	{
		this.FinishUiCameraSequence();
	}

	// Token: 0x06016ADE RID: 92894 RVA: 0x0064C6AC File Offset: 0x0064A8AC
	[return: Nullable(2)]
	private ALevelSequenceActor CreateLevelSequenceActor(ULevelSequence levelSequence)
	{
		ALevelSequenceActor result = new ALevelSequenceActor();
		ULevelSequencePlayer.CreateLevelSequencePlayer(GlobalData.World, levelSequence, new FMovieSceneSequencePlaybackSettings(), ref result);
		return result;
	}

	// Token: 0x06016ADF RID: 92895 RVA: 0x0064C6D4 File Offset: 0x0064A8D4
	private UniTask TryAddBindUiCameraSequence(ALevelSequenceActor sequenceActor)
	{
		UiCameraSequence.<TryAddBindUiCameraSequence>d__25 <TryAddBindUiCameraSequence>d__;
		<TryAddBindUiCameraSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryAddBindUiCameraSequence>d__.<>4__this = this;
		<TryAddBindUiCameraSequence>d__.sequenceActor = sequenceActor;
		<TryAddBindUiCameraSequence>d__.<>1__state = -1;
		<TryAddBindUiCameraSequence>d__.<>t__builder.Start<UiCameraSequence.<TryAddBindUiCameraSequence>d__25>(ref <TryAddBindUiCameraSequence>d__);
		return <TryAddBindUiCameraSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06016AE0 RID: 92896 RVA: 0x0064C720 File Offset: 0x0064A920
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	private UniTask<BlackScreenView> NewBlackScreenView()
	{
		UiCameraSequence.<NewBlackScreenView>d__26 <NewBlackScreenView>d__;
		<NewBlackScreenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<BlackScreenView>.Create();
		<NewBlackScreenView>d__.<>4__this = this;
		<NewBlackScreenView>d__.<>1__state = -1;
		<NewBlackScreenView>d__.<>t__builder.Start<UiCameraSequence.<NewBlackScreenView>d__26>(ref <NewBlackScreenView>d__);
		return <NewBlackScreenView>d__.<>t__builder.Task;
	}

	// Token: 0x06016AE1 RID: 92897 RVA: 0x0064C763 File Offset: 0x0064A963
	public void DestroyBlackScreenView()
	{
		if (this.BlackScreenViewInternal == null)
		{
			return;
		}
		this.BlackScreenViewInternal.Destroy(null);
		this.BlackScreenViewInternal = null;
	}

	// Token: 0x0400AEEF RID: 44783
	private static readonly FName BLACK_TEXTURE_TAG = new FName("BlackTexture");

	// Token: 0x0400AEF0 RID: 44784
	private static readonly FName UI_CAMERA = new FName("UiCamera");

	// Token: 0x0400AEF1 RID: 44785
	private static readonly FName FIGHT_CAMERA = new FName("FightCamera");

	// Token: 0x0400AEF2 RID: 44786
	[Nullable(2)]
	private ALevelSequenceActor SequenceActor;

	// Token: 0x0400AEF3 RID: 44787
	[Nullable(2)]
	private UDefaultLevelSequenceInstanceData LevelSequenceInstanceData;

	// Token: 0x0400AEF4 RID: 44788
	[Nullable(2)]
	private BlackScreenView BlackScreenViewInternal;

	// Token: 0x0400AEF5 RID: 44789
	[Nullable(new byte[]
	{
		1,
		2,
		1
	})]
	private readonly List<Action<UiCameraSequence>> OnUiCameraSequenceFinishedCallbackList = new List<Action<UiCameraSequence>>();

	// Token: 0x0400AEF6 RID: 44790
	private bool IsAutoDestroyBlackScreen;

	// Token: 0x0400AEF7 RID: 44791
	[Nullable(2)]
	private Action OnCallUiCameraSequenceEvent;

	// Token: 0x0400AEF8 RID: 44792
	[Nullable(2)]
	private string UiCameraSequenceEventName;
}
