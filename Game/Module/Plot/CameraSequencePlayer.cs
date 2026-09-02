using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Plot.Sequence;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005349 RID: 21321
	[NullableContext(1)]
	[Nullable(0)]
	public class CameraSequencePlayer
	{
		// Token: 0x06036645 RID: 222789 RVA: 0x00DB6440 File Offset: 0x00DB4640
		public void Play(string path, bool isRelativeCamera)
		{
			if (this.IsPlaying)
			{
				this.Stop();
			}
			this.IsPlaying = true;
			this.IsRelative = isRelativeCamera;
			this.LoadId = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(path, new Action<ULevelSequence, string>(this.OnLoad), 100, "js_undefined");
		}

		// Token: 0x06036646 RID: 222790 RVA: 0x00DB6490 File Offset: 0x00DB4690
		public void Stop()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.IsPlaying = false;
			if (this.LoadId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadId);
				this.LoadId = -1;
			}
			if (this.CurLevelSeqActor != null)
			{
				this.CurLevelSeqActor.SequencePlayer.OnStop.Clear();
				this.CurLevelSeqActor.SequencePlayer.Stop();
				this.CurLevelSeqActor.ResetBindings();
				Singleton<ActorSystem>.Instance.Put("CameraSequencePlayer.Stop", this.CurLevelSeqActor, null);
			}
			this.CurLevelSeqActor = null;
		}

		// Token: 0x06036647 RID: 222791 RVA: 0x00DB6524 File Offset: 0x00DB4724
		private void OnLoad([Nullable(2)] ULevelSequence sequence, string _)
		{
			this.LoadId = -1;
			if (sequence == null || !ObjectUtils.IsValid(sequence))
			{
				return;
			}
			ALevelSequenceActor alevelSequenceActor = Singleton<ActorSystem>.Instance.Spawn<ALevelSequenceActor>(ALevelSequenceActor.StaticClass(), new FTransformDouble(), null);
			this.CurLevelSeqActor = alevelSequenceActor;
			this.CurLevelSeqActor.SetSequence(sequence);
			if (this.IsRelative)
			{
				FTransformDouble inT = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.D_GetTransform();
				this.CurLevelSeqActor.bOverrideInstanceData = true;
				UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.CurLevelSeqActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
				FTransform transformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(inT);
				udefaultLevelSequenceInstanceData.TransformOrigin = transformOrigin;
			}
			TArray<AActor> tarray = new TArray<AActor>();
			BP_CineCamera_C cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			tarray.Add(cineCamera);
			cineCamera.ResetSeqCineCamSetting();
			this.CurLevelSeqActor.SetBindingByTag(SequenceDefine.CAMERA_TAG, tarray, false, true);
			alevelSequenceActor.SequencePlayer.OnStop.Add(new Action(this.OnStop));
			alevelSequenceActor.SequencePlayer.Play();
		}

		// Token: 0x06036648 RID: 222792 RVA: 0x00DB6627 File Offset: 0x00DB4827
		private void OnStop()
		{
			this.Stop();
		}

		// Token: 0x0401F46E RID: 128110
		[Nullable(2)]
		private ALevelSequenceActor CurLevelSeqActor;

		// Token: 0x0401F46F RID: 128111
		private int LoadId = -1;

		// Token: 0x0401F470 RID: 128112
		private bool IsPlaying;

		// Token: 0x0401F471 RID: 128113
		private bool IsRelative;
	}
}
