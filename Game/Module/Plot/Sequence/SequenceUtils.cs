using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseSeqCharacter;
using AkiClient.Game.Aki.Sequence.Seq_BP;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x0200538C RID: 21388
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceUtils : IStaticVariableResetter
	{
		// Token: 0x060368C6 RID: 223430 RVA: 0x00DC9F52 File Offset: 0x00DC8152
		static SequenceUtils()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SequenceUtils.CreateStaticDefaultValue), new Action(SequenceUtils.ResetStaticDefaultValue));
		}

		// Token: 0x060368C7 RID: 223431 RVA: 0x00DC9F71 File Offset: 0x00DC8171
		[NullableContext(2)]
		public static ULevelSequence GetSelectedSequenceInEditor()
		{
			return null;
		}

		// Token: 0x060368C8 RID: 223432 RVA: 0x00DC9F74 File Offset: 0x00DC8174
		public static bool CheckIfUseAudioSeq(AActor actor)
		{
			BP_BaseRole_Seq_V2_C bp_BaseRole_Seq_V2_C = actor as BP_BaseRole_Seq_V2_C;
			bool result;
			if (bp_BaseRole_Seq_V2_C != null)
			{
				SeqAudio_Seq_V2_C seqAudio_Seq_V = bp_BaseRole_Seq_V2_C.SeqAudio_Seq_V2;
				result = (seqAudio_Seq_V != null && seqAudio_Seq_V.UseAudioSeq);
			}
			else
			{
				BP_SeqNPC_C bp_SeqNPC_C = actor as BP_SeqNPC_C;
				if (bp_SeqNPC_C != null)
				{
					SeqAudio_Seq_V2_C seqAudio_Seq_V2 = bp_SeqNPC_C.SeqAudio_Seq_V2;
					result = (seqAudio_Seq_V2 != null && seqAudio_Seq_V2.UseAudioSeq);
				}
				else
				{
					BP_SeqSkeletal_C bp_SeqSkeletal_C = actor as BP_SeqSkeletal_C;
					if (bp_SeqSkeletal_C == null)
					{
						return false;
					}
					SeqAudio_Seq_V2_C seqAudio_Seq_V3 = bp_SeqSkeletal_C.SeqAudio_Seq_V2;
					result = (seqAudio_Seq_V3 != null && seqAudio_Seq_V3.UseAudioSeq);
				}
			}
			return result;
		}

		// Token: 0x060368C9 RID: 223433 RVA: 0x00DC9FE8 File Offset: 0x00DC81E8
		public static void AsFrameTime(FFrameRate frameRate, float timeInSeconds, ref FFrameTime outFrameTime)
		{
			float num = timeInSeconds * (float)frameRate.Numerator / (float)frameRate.Denominator;
			int num2 = (int)Math.Floor((double)num);
			float num3 = num - (float)num2;
			if (num3 > 0f)
			{
				num3 = Math.Min(num3, 0.1f);
			}
			outFrameTime.FrameNumber.Value = num2;
			outFrameTime.SubFrame = num3;
		}

		// Token: 0x060368CA RID: 223434 RVA: 0x00DCA03C File Offset: 0x00DC823C
		[return: Nullable(2)]
		public static UMovieSceneTrack GetLevelSequenceTransformTrack(ULevelSequence sequence, FName tag)
		{
			if (!sequence.IsValid())
			{
				return null;
			}
			TArray<FMovieSceneObjectBindingID> tarray = sequence.FindBindingsByTag(tag);
			FSequencerBindingRuntimeProxy fsequencerBindingRuntimeProxy = null;
			for (int i = 0; i < tarray.Num(); i++)
			{
				FMovieSceneObjectBindingID fmovieSceneObjectBindingID = tarray.Get(i);
				fsequencerBindingRuntimeProxy = UKuroSequenceRuntimeFunctionLibrary.FindBindingById(sequence, fmovieSceneObjectBindingID.Guid);
				if (fsequencerBindingRuntimeProxy.BindingID.IsValid())
				{
					break;
				}
				fsequencerBindingRuntimeProxy = null;
			}
			if (fsequencerBindingRuntimeProxy == null)
			{
				return null;
			}
			TArray<UMovieSceneTrack> tarray2 = UKuroSequenceRuntimeFunctionLibrary.FindTracksByType(fsequencerBindingRuntimeProxy, UMovieScene3DTransformTrack.StaticClass());
			if (tarray2.Num() <= 0)
			{
				return null;
			}
			return tarray2.Get(0);
		}

		// Token: 0x060368CB RID: 223435 RVA: 0x00DCA0C7 File Offset: 0x00DC82C7
		public static FTransformDouble GetLevelSequenceTransform(ULevelSequence sequence, UMovieSceneTrack track, float time)
		{
			if (SequenceUtils._frameTime == null)
			{
				SequenceUtils._frameTime = new FFrameTime();
			}
			SequenceUtils.AsFrameTime(sequence.MovieScene.TickResolution, time, ref SequenceUtils._frameTime);
			return UKismetMathLibrary.Conv_TransformToTransformDouble(UKuroSequenceRuntimeFunctionLibrary.GetFrameTransform(track, SequenceUtils._frameTime));
		}

		// Token: 0x060368CC RID: 223436 RVA: 0x00DCA106 File Offset: 0x00DC8306
		public static void CreateStaticDefaultValue()
		{
			SequenceUtils._frameTime = null;
		}

		// Token: 0x060368CD RID: 223437 RVA: 0x00DCA10E File Offset: 0x00DC830E
		public static void ResetStaticDefaultValue()
		{
			SequenceUtils._frameTime = null;
		}

		// Token: 0x0401F6CE RID: 128718
		private const float MINI_SUB_FRAME_TIME = 0.1f;

		// Token: 0x0401F6CF RID: 128719
		[Nullable(2)]
		private static FFrameTime _frameTime;
	}
}
