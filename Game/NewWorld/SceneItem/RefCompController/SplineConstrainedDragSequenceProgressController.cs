using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.RefCompController
{
	// Token: 0x0200482D RID: 18477
	public class SplineConstrainedDragSequenceProgressController : ISequenceProgressController
	{
		// Token: 0x0603014D RID: 196941 RVA: 0x00BA8804 File Offset: 0x00BA6A04
		[NullableContext(1)]
		public void OnSequenceLoaded([Nullable(2)] ULevelSequence data, string path)
		{
			if (data == null || !data.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragSequenceProgressController] Sequence 加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.SimpleSequenceActor == null)
			{
				this.SimpleSequenceActor = new SimpleLevelSequenceActor(data);
			}
			else
			{
				this.SimpleSequenceActor.SetSequenceData(data);
			}
			this.SimpleSequenceActor.UpdateSettings(new bool?(true));
			this.SimpleSequenceActor.SetOriginTransform();
			UMovieSceneSequencePlayer player = this.SimpleSequenceActor.GetPlayer();
			if (player == null || !player.IsValid())
			{
				return;
			}
			FQualifiedFrameTime startTime = player.GetStartTime();
			FQualifiedFrameTime endTime = player.GetEndTime();
			this.CachedStartSeconds = ((float)startTime.Time.FrameNumber.Value + startTime.Time.SubFrame) * (float)startTime.Rate.Denominator / (float)startTime.Rate.Numerator;
			float num = ((float)endTime.Time.FrameNumber.Value + endTime.Time.SubFrame) * (float)endTime.Rate.Denominator / (float)endTime.Rate.Numerator;
			this.CachedTotalSeconds = num - this.CachedStartSeconds;
			if (!this.HasAcquiredForbidEvalDisable)
			{
				ModelBase<SplineConstrainedDragModel>.Instance.AcquireForbidEvalDisable();
				this.HasAcquiredForbidEvalDisable = true;
			}
			player.Play();
			player.SetPlayRate(0f);
		}

		// Token: 0x0603014E RID: 196942 RVA: 0x00BA8964 File Offset: 0x00BA6B64
		public void SetSequenceProgress(float progress)
		{
			if (this.SimpleSequenceActor == null)
			{
				return;
			}
			UMovieSceneSequencePlayer player = this.SimpleSequenceActor.GetPlayer();
			if (player == null || !player.IsValid())
			{
				return;
			}
			if (this.CachedTotalSeconds <= 0f)
			{
				return;
			}
			float num = Math.Max(0f, Math.Min(1f, progress));
			float time = this.CachedStartSeconds + num * this.CachedTotalSeconds;
			FMovieSceneSequencePlaybackParams playbackPosition = new FMovieSceneSequencePlaybackParams(new FFrameTime(), time, "", EMovieScenePositionType.Time, EUpdatePositionMethod.Jump);
			player.SetPlaybackPosition(playbackPosition);
		}

		// Token: 0x0603014F RID: 196943 RVA: 0x00BA89E6 File Offset: 0x00BA6BE6
		public void Destroy()
		{
			if (this.SimpleSequenceActor != null)
			{
				this.SimpleSequenceActor.Clear();
			}
			this.SimpleSequenceActor = null;
			if (this.HasAcquiredForbidEvalDisable)
			{
				ModelBase<SplineConstrainedDragModel>.Instance.ReleaseForbidEvalDisable();
				this.HasAcquiredForbidEvalDisable = false;
			}
		}

		// Token: 0x0401B9C2 RID: 113090
		[Nullable(2)]
		private SimpleLevelSequenceActor SimpleSequenceActor;

		// Token: 0x0401B9C3 RID: 113091
		private float CachedTotalSeconds;

		// Token: 0x0401B9C4 RID: 113092
		private float CachedStartSeconds;

		// Token: 0x0401B9C5 RID: 113093
		private bool HasAcquiredForbidEvalDisable;
	}
}
