using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000013 RID: 19
[NullableContext(1)]
[Nullable(0)]
public static class ActorPoolGuard
{
	// Token: 0x06000025 RID: 37 RVA: 0x00002050 File Offset: 0x00000250
	public static bool CleanActorBeforeEnPool(AActor actor, [Nullable(2)] TClearFunction clearFunc = null)
	{
		if (clearFunc != null)
		{
			clearFunc(actor);
		}
		else
		{
			ALevelSequenceActor alevelSequenceActor = actor as ALevelSequenceActor;
			if (alevelSequenceActor != null)
			{
				ActorPoolGuard.ClearSequenceActor(alevelSequenceActor);
			}
			else
			{
				FTransformDouble ftransformDouble = new FTransformDouble();
				actor.D_K2_SetActorTransform(ftransformDouble, false, null, true);
				UKuroActorManager.ClearAcquiredComponents(actor);
				UKuroActorManager.ResetDelegates(actor);
				actor.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
				actor.SetActorHiddenInGame(true);
				TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UActorComponent.StaticClass());
				for (int i = 0; i < tarray.Num(); i++)
				{
					UKuroActorManager.UnregisterComponent(tarray.Get(i));
				}
				actor.SetActorTickEnabled(false);
				actor.SetActorEnableCollision(false);
			}
		}
		return true;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000020E7 File Offset: 0x000002E7
	public static bool PrepareActorBeforeDePool(AActor actor)
	{
		if (!UKuroActorManager.ResetActorToDefault(actor))
		{
			return false;
		}
		actor.SetActorEnableCollision(true);
		UKuroActorManager.ResetUberGraph(actor);
		return true;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002104 File Offset: 0x00000304
	public static void ClearSequenceActor(ALevelSequenceActor actor)
	{
		actor.PlaybackSettings = new FMovieSceneSequencePlaybackSettings();
		actor.ResetBindings();
		actor.SequencePlayer.OnFinished.Clear();
		actor.SequencePlayer.OnPlay.Clear();
		actor.SequencePlayer.OnStop.Clear();
		actor.SequencePlayer.OnPause.Clear();
		actor.SequencePlayer.OnPlayReverse.Clear();
		actor.SequencePlayer.OnCameraCut.Clear();
		actor.bOverrideInstanceData = false;
		UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = actor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
		if (udefaultLevelSequenceInstanceData != null)
		{
			udefaultLevelSequenceInstanceData.TransformOrigin = new FTransform();
			udefaultLevelSequenceInstanceData.TransformOriginActor = null;
		}
		actor.SetSequence(UKuroActorManager.GetDummySequence());
	}
}
