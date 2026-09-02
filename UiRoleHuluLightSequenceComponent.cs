using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CAC RID: 11436
[NullableContext(2)]
[Nullable(0)]
public class UiRoleHuluLightSequenceComponent : UiModelComponentBase, IUiModelVisible
{
	// Token: 0x06016F24 RID: 93988 RVA: 0x0065C29C File Offset: 0x0065A49C
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016F25 RID: 93989 RVA: 0x0065C2B0 File Offset: 0x0065A4B0
	private void CreateLevelSequencePlayer()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("LevelSequence_HuluLight");
		this.HandleId = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(resourcePath, delegate([Nullable(2)] ULevelSequence levelSequenceObject, string _)
		{
			if (ObjectUtils.IsValid(levelSequenceObject))
			{
				FMovieSceneSequencePlaybackSettings fmovieSceneSequencePlaybackSettings = new FMovieSceneSequencePlaybackSettings();
				fmovieSceneSequencePlaybackSettings.bRestoreState = true;
				fmovieSceneSequencePlaybackSettings.bPauseAtEnd = true;
				this.SequenceActor = (Singleton<ActorSystem>.Instance.Spawn(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null) as ALevelSequenceActor);
				this.SequenceActor.PlaybackSettings = fmovieSceneSequencePlaybackSettings;
				this.SequenceActor.SetSequence(levelSequenceObject);
				this.LevelSequencePlayer = this.SequenceActor.SequencePlayer;
				if (this.LevelSequencePlayer != null)
				{
					this.PlayLightSequence();
				}
			}
		}, 100, "Ui.UiSceneModel");
	}

	// Token: 0x06016F26 RID: 93990 RVA: 0x0065C2F4 File Offset: 0x0065A4F4
	public void PlayLightSequence()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.SequenceActor.bOverrideInstanceData = true;
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.SequenceActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			Vector location = Transform.Create(this.ActorComponent.MainMeshComponent.D_GetSocketTransform(Singleton<CharacterNameDefines>.Instance.GLIDEING_SOCKETNAME, ERelativeTransformSpace.RTS_World)).GetLocation();
			Transform transform = Transform.Create();
			transform.SetLocation(location);
			udefaultLevelSequenceInstanceData.TransformOrigin = transform.ToUeTransformOld();
			this.LevelSequencePlayer.Play();
			return;
		}
		if (this.HandleId == -1)
		{
			this.CreateLevelSequencePlayer();
		}
	}

	// Token: 0x06016F27 RID: 93991 RVA: 0x0065C383 File Offset: 0x0065A583
	public void StopLightSequence()
	{
		if (this.LevelSequencePlayer != null)
		{
			this.LevelSequencePlayer.Stop();
			return;
		}
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleId = -1;
		}
	}

	// Token: 0x06016F28 RID: 93992 RVA: 0x0065C3BC File Offset: 0x0065A5BC
	protected override void OnEnd()
	{
		this.StopLightSequence();
		ALevelSequenceActor tmp = this.SequenceActor;
		TimerSystem.Instance.Next(delegate(float delta)
		{
			Singleton<ActorSystem>.Instance.Put("UiRoleHuluLightSequenceComponent.OnEnd", tmp, null);
		}, null, null);
		this.LevelSequencePlayer = null;
		this.SequenceActor = null;
	}

	// Token: 0x06016F29 RID: 93993 RVA: 0x0065C408 File Offset: 0x0065A608
	public void OnModelVisibleChange(bool visible)
	{
		if (!visible)
		{
			this.StopLightSequence();
		}
	}

	// Token: 0x0400B0FA RID: 45306
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B0FB RID: 45307
	private ULevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400B0FC RID: 45308
	private ALevelSequenceActor SequenceActor;

	// Token: 0x0400B0FD RID: 45309
	private int HandleId = -1;
}
