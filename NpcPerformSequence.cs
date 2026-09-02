using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x020031DA RID: 12762
[NullableContext(2)]
[Nullable(0)]
public class NpcPerformSequence
{
	// Token: 0x0601A73C RID: 108348 RVA: 0x007CE594 File Offset: 0x007CC794
	public void Destroy()
	{
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null && levelSequencePlayer.IsValid() && this.LevelSequencePlayer.IsPlaying())
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.WLJ, "[CollectionItemDisplay]开始销毁Npc表现Sequence时，Sequence仍在播放，等播放完成后销毁", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.LevelSequencePlayer.OnFinished.Clear();
			this.LevelSequencePlayer.OnFinished.Add(new Action(this.OnDestroyedWhenFinished));
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.WLJ, "[CollectionItemDisplay]开始销毁Npc表现Sequence", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.DestroyInternal();
	}

	// Token: 0x0601A73D RID: 108349 RVA: 0x007CE634 File Offset: 0x007CC834
	private void DestroyInternal()
	{
		if (this.LoadSequenceHandleId != null)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadSequenceHandleId.Value);
			this.LoadSequenceHandleId = null;
		}
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null && levelSequencePlayer.IsValid())
		{
			this.LevelSequencePlayer.Stop();
			this.LevelSequencePlayer.OnFinished.Clear();
			this.LevelSequencePlayer = null;
		}
		ALevelSequenceActor levelSequenceActor = this.LevelSequenceActor;
		if (levelSequenceActor != null && levelSequenceActor.IsValid())
		{
			ALevelSequenceActor tmp = this.LevelSequenceActor;
			TimerSystem.Instance.Next(delegate(float _)
			{
				Singleton<ActorSystem>.Instance.Put("NpcPerformSequence.DestroyInternal", tmp, null);
			}, null, null);
			this.LevelSequenceActor = null;
		}
		this.LevelSequenceInstanceData = null;
		this.OnFinishedCallback = null;
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
	}

	// Token: 0x0601A73E RID: 108350 RVA: 0x007CE717 File Offset: 0x007CC917
	private void OnDestroyedWhenFinished()
	{
		this.Finish();
		this.DestroyInternal();
	}

	// Token: 0x0601A73F RID: 108351 RVA: 0x007CE728 File Offset: 0x007CC928
	[NullableContext(1)]
	public void SetTransformOriginEntity(Entity entity)
	{
		AActor owner = entity.GetComponent<BaseActorComponent>().Owner;
		this.SetTransformOriginActor(owner);
	}

	// Token: 0x0601A740 RID: 108352 RVA: 0x007CE748 File Offset: 0x007CC948
	[NullableContext(1)]
	public void SetTransformOriginActor(AActor actor)
	{
		if (this.LevelSequenceInstanceData == null)
		{
			return;
		}
		this.LevelSequenceActor.bOverrideInstanceData = true;
		this.LevelSequenceInstanceData.TransformOriginActor = actor;
	}

	// Token: 0x0601A741 RID: 108353 RVA: 0x007CE76C File Offset: 0x007CC96C
	[NullableContext(1)]
	public void Load(string sequencePath, [Nullable(2)] Action onLoaded = null)
	{
		if (this.SequencePath == sequencePath && this.IsValid())
		{
			if (onLoaded != null)
			{
				onLoaded();
			}
			return;
		}
		this.SequencePath = sequencePath;
		this.LoadSequenceHandleId = new int?(Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(this.SequencePath, delegate([Nullable(2)] ULevelSequence levelSequence, string _)
		{
			this.CreateLevelSequence(levelSequence);
			if (onLoaded != null)
			{
				onLoaded();
			}
		}, 100, "js_undefined"));
	}

	// Token: 0x0601A742 RID: 108354 RVA: 0x007CE7EC File Offset: 0x007CC9EC
	public void Play(Action onFinished = null)
	{
		if (!this.IsValid())
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.WLJ, "[CollectionItemDisplay]尝试播放Npc表现Sequence时，LevelSequencePlayer为空或不可用", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.IsPlaying())
		{
			Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.WLJ, "[CollectionItemDisplay]尝试播放Npc表现Sequence时，Sequence正在播放中,停止后重新播放", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.StopInternal();
		}
		BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
		cineCamera.ResetSeqCineCamSetting();
		this.AddBindingByTag(this.sequenceCameraTag, cineCamera);
		ControllerBase<CameraController>.Instance.EnterCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, false, "MainCamera", null);
		this.PlayInternal(onFinished);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayNpcPerformSequence);
	}

	// Token: 0x0601A743 RID: 108355 RVA: 0x007CE8B1 File Offset: 0x007CCAB1
	public void AddBindingByTag(FName tag, AActor actor)
	{
		this.LevelSequenceActor.AddBindingByTag(tag, actor, false, true);
	}

	// Token: 0x0601A744 RID: 108356 RVA: 0x007CE8C4 File Offset: 0x007CCAC4
	private void CreateLevelSequence(ULevelSequence levelSequence)
	{
		this.LevelSequenceActor = Singleton<ActorSystem>.Instance.Get<ALevelSequenceActor>(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null, false);
		this.LevelSequenceActor.SetSequence(levelSequence);
		this.LevelSequencePlayer = this.LevelSequenceActor.SequencePlayer;
		this.LevelSequenceInstanceData = (this.LevelSequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData);
		this.LevelSequenceActor.bOverrideInstanceData = true;
		FVector fvector = new FVector(0f);
		if (levelSequence.GetCenterOffset(ref fvector))
		{
			this.LevelSequenceInstanceData.TransformOrigin = new FTransform(ref fvector);
			return;
		}
		this.LevelSequenceInstanceData.TransformOrigin = new FTransform();
	}

	// Token: 0x0601A745 RID: 108357 RVA: 0x007CE968 File Offset: 0x007CCB68
	private void PlayInternal(Action onFinished = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[CollectionItemDisplay]开始播放Npc表现Sequence";
		string item = "SequenceName";
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (levelSequencePlayer != null) ? levelSequencePlayer.Sequence : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnFinishedCallback = onFinished;
		this.LevelSequencePlayer.OnFinished.Add(new Action(this.OnFinished));
		this.LevelSequencePlayer.Play();
	}

	// Token: 0x0601A746 RID: 108358 RVA: 0x007CE9E0 File Offset: 0x007CCBE0
	public void Stop()
	{
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.WLJ, "[CollectionItemDisplay]Npc表现Sequence被停止", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.StopInternal();
	}

	// Token: 0x0601A747 RID: 108359 RVA: 0x007CEA14 File Offset: 0x007CCC14
	private void StopInternal()
	{
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null || !levelSequencePlayer.IsValid())
		{
			return;
		}
		this.LevelSequencePlayer.Stop();
	}

	// Token: 0x0601A748 RID: 108360 RVA: 0x007CEA62 File Offset: 0x007CCC62
	public void Pause()
	{
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null || !levelSequencePlayer.IsValid())
		{
			return;
		}
		this.LevelSequencePlayer.Pause();
	}

	// Token: 0x0601A749 RID: 108361 RVA: 0x007CEA87 File Offset: 0x007CCC87
	public void Continue()
	{
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null || !levelSequencePlayer.IsValid())
		{
			return;
		}
		this.LevelSequencePlayer.Play();
	}

	// Token: 0x0601A74A RID: 108362 RVA: 0x007CEAAC File Offset: 0x007CCCAC
	public bool IsPlaying()
	{
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		return levelSequencePlayer != null && levelSequencePlayer.IsValid() && this.LevelSequencePlayer.IsPlaying();
	}

	// Token: 0x0601A74B RID: 108363 RVA: 0x007CEAD2 File Offset: 0x007CCCD2
	public bool IsValid()
	{
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		return levelSequencePlayer != null && levelSequencePlayer.IsValid();
	}

	// Token: 0x0601A74C RID: 108364 RVA: 0x007CEAE8 File Offset: 0x007CCCE8
	private void OnFinished()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[CollectionItemDisplay]Npc表现Sequence播放完成";
		string item = "SequenceName";
		ULevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (levelSequencePlayer != null) ? levelSequencePlayer.Sequence : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.Finish();
	}

	// Token: 0x0601A74D RID: 108365 RVA: 0x007CEB38 File Offset: 0x007CCD38
	private void Finish()
	{
		ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
		if (this.OnFinishedCallback != null)
		{
			this.OnFinishedCallback();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnNpcPerformSequenceFinished);
	}

	// Token: 0x0400D5BA RID: 54714
	private readonly FName sequenceCameraTag = new FName("SequenceCamera");

	// Token: 0x0400D5BB RID: 54715
	[Nullable(1)]
	private string SequencePath = "";

	// Token: 0x0400D5BC RID: 54716
	private int? LoadSequenceHandleId;

	// Token: 0x0400D5BD RID: 54717
	private ULevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400D5BE RID: 54718
	private ALevelSequenceActor LevelSequenceActor;

	// Token: 0x0400D5BF RID: 54719
	private UDefaultLevelSequenceInstanceData LevelSequenceInstanceData;

	// Token: 0x0400D5C0 RID: 54720
	private Action OnFinishedCallback;
}
