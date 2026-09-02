using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005397 RID: 21399
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceQteManager
	{
		// Token: 0x06036929 RID: 223529 RVA: 0x00DCB8AC File Offset: 0x00DC9AAC
		public void Init()
		{
			this.AfterTickHandleId = ControllerBase<PlotController>.Instance.AddAfterTick(new Action<float>(this.OnTick));
			UMovieSceneDialogueSubsystem umovieSceneDialogueSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UMovieSceneDialogueSubsystem.StaticClass()) as UMovieSceneDialogueSubsystem;
			this.QteManager = ((umovieSceneDialogueSubsystem != null) ? umovieSceneDialogueSubsystem.GetQteManager() : null);
			if (!ObjectUtils.IsValid(this.QteManager))
			{
				ControllerBase<FlowController>.Instance.LogError("QteManager异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.QteManager = null;
			}
		}

		// Token: 0x0603692A RID: 223530 RVA: 0x00DCB930 File Offset: 0x00DC9B30
		public void Clear()
		{
			ControllerBase<PlotController>.Instance.RemoveAfterTick(this.AfterTickHandleId);
			if (this.CurrentSequenceQte.Count > 0)
			{
				foreach (KeyValuePair<int, ISequenceCommonQteHandle> keyValuePair in this.CurrentSequenceQte)
				{
					int key = keyValuePair.Key;
					keyValuePair.Value.ForceStopSequenceQte();
				}
			}
			this.CurrentSequenceQte.Clear();
			this.CollectPendingStartQteIds();
			this.ReleasePendingQtes();
			this.PendingOptionResult.Clear();
			this.PendingQteEventQueue.Clear();
			this.PendingFinishQteQueue.Clear();
			this.QteManager = null;
		}

		// Token: 0x0603692B RID: 223531 RVA: 0x00DCB9F0 File Offset: 0x00DC9BF0
		public void EnqueueQteStart(FMovieSceneQteEventParam param)
		{
			this.PendingQteEventQueue.Push(new SequenceQteManager.PendingQteStartEvent
			{
				Type = SequenceQteManager.EQtePendingEventType.Start,
				Data = this.CreateQteStartData(param)
			});
		}

		// Token: 0x0603692C RID: 223532 RVA: 0x00DCBA16 File Offset: 0x00DC9C16
		public void EnqueueQteAnimEnd(int qteId)
		{
			this.PendingQteEventQueue.Push(new SequenceQteManager.PendingQteAnimEndEvent
			{
				Type = SequenceQteManager.EQtePendingEventType.AnimEnd,
				QteId = qteId
			});
		}

		// Token: 0x0603692D RID: 223533 RVA: 0x00DCBA36 File Offset: 0x00DC9C36
		public void EnqueueQteRelease(int qteId)
		{
			this.PendingReleaseQteIds.Add(qteId);
		}

		// Token: 0x0603692E RID: 223534 RVA: 0x00DCBA48 File Offset: 0x00DC9C48
		private SequenceQteManager.ISequenceQteStartData CreateQteStartData(FMovieSceneQteEventParam param)
		{
			bool flag = !param.IsTriggerType;
			FFrameTime startFrame = null;
			FFrameTime fframeTime = null;
			if (flag)
			{
				startFrame = new FFrameTime(param.StartFrame.FrameNumber, param.StartFrame.SubFrame);
				fframeTime = new FFrameTime(param.EndFrame.FrameNumber, param.EndFrame.SubFrame);
				fframeTime.FrameNumber.Value--;
			}
			return new SequenceQteManager.SequenceQteStartData
			{
				QteId = param.QteId,
				SubtitleId = param.SubtitleId,
				IsProgress = flag,
				IsGroupQte = param.IsGroupQte,
				StartFrame = startFrame,
				EndFrame = fframeTime,
				AttachActor = param.AttachActor,
				SpineInfo = QteSpineInfoProxy.CreateQteSpineInfo(param.SpineInfo),
				IsUpdateWithProgress = param.IsUpdateWithProgress,
				SubQteParams = this.CreateSubQteParams(param.SubQteParams)
			};
		}

		// Token: 0x0603692F RID: 223535 RVA: 0x00DCBB2C File Offset: 0x00DC9D2C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<MovieSceneSubQteParamsProxy> CreateSubQteParams([Nullable(new byte[]
		{
			2,
			1
		})] TArray<FMovieSceneSubQteParams> @params)
		{
			if (@params == null || @params.Num() <= 0)
			{
				return null;
			}
			List<MovieSceneSubQteParamsProxy> list = new List<MovieSceneSubQteParamsProxy>();
			for (int i = 0; i < @params.Num(); i++)
			{
				FMovieSceneSubQteParams fmovieSceneSubQteParams = @params.Get(i);
				list.Add(new MovieSceneSubQteParamsProxy(fmovieSceneSubQteParams.SubQteId, QteSpineInfoProxy.CreateQteSpineInfo(fmovieSceneSubQteParams.SpineInfo)));
			}
			return list;
		}

		// Token: 0x06036930 RID: 223536 RVA: 0x00DCBB84 File Offset: 0x00DC9D84
		private void StartSequenceQte(SequenceQteManager.ISequenceQteStartData data)
		{
			if (this.CurrentSequenceQte.Count > 0)
			{
				foreach (KeyValuePair<int, ISequenceCommonQteHandle> keyValuePair in this.CurrentSequenceQte)
				{
					keyValuePair.Value.ForceStopSequenceQte();
				}
				this.CurrentSequenceQte.Clear();
			}
			ISequenceCommonQteHandle sequenceCommonQteHandle = this.CreateQte(data.QteId, data.SubtitleId, data.IsProgress, data.IsGroupQte, data.StartFrame, data.EndFrame, data.AttachActor, data.SpineInfo, data.SubQteParams, new bool?(data.IsUpdateWithProgress));
			if (sequenceCommonQteHandle == null)
			{
				UMovieSceneQteManager qteManager = this.QteManager;
				if (qteManager != null)
				{
					qteManager.FinishQte(data.QteId);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[FlowSequence][PlotQte] Sequence Qte 失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", data.QteId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.CurrentSequenceQte[data.QteId] = sequenceCommonQteHandle;
			sequenceCommonQteHandle.OnBegin();
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				if (sequenceCommonQteHandle.IsProgressQte)
				{
					ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
					if (curLevelSeqActor != null)
					{
						ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
						if (sequencePlayer != null)
						{
							sequencePlayer.PauseOnNextFrame();
						}
					}
				}
				else
				{
					ControllerBase<SequenceController>.Instance.PauseSequence("QTE");
				}
			}
			this.PlayDirection = SequenceQteManager.EDirection.Pause;
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			ControllerBase<PlotController>.Instance.PlotViewManager.EnableInteractPlot(false, new bool?(true), "SequenceQte", null);
		}

		// Token: 0x06036931 RID: 223537 RVA: 0x00DCBD14 File Offset: 0x00DC9F14
		private void OnSequenceAnimFinished(int qteId)
		{
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (!this.CurrentSequenceQte.TryGetValue(qteId, out sequenceCommonQteHandle))
			{
				return;
			}
			sequenceCommonQteHandle.OnSequenceAnimFinished();
		}

		// Token: 0x06036932 RID: 223538 RVA: 0x00DCBD38 File Offset: 0x00DC9F38
		public void OnSequenceQteFinished(int qteId)
		{
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (!this.CurrentSequenceQte.TryGetValue(qteId, out sequenceCommonQteHandle))
			{
				return;
			}
			if (sequenceCommonQteHandle.SubtitleId != -1)
			{
				this.PendingOptionResult[sequenceCommonQteHandle.SubtitleId] = sequenceCommonQteHandle.OptionIndex;
			}
			this.PendingFinishQteQueue.Push(qteId);
		}

		// Token: 0x06036933 RID: 223539 RVA: 0x00DCBD84 File Offset: 0x00DC9F84
		private void HandleFinishSequenceQte(int qteId)
		{
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (!this.CurrentSequenceQte.TryGetValue(qteId, out sequenceCommonQteHandle))
			{
				return;
			}
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				if (sequenceCommonQteHandle.IsProgressQte)
				{
					ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
					ULevelSequencePlayer ulevelSequencePlayer = (curLevelSeqActor != null) ? curLevelSeqActor.SequencePlayer : null;
					if (ulevelSequencePlayer != null)
					{
						ulevelSequencePlayer.CleanPauseOnFrame();
					}
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 0", null);
					if (ulevelSequencePlayer != null)
					{
						ulevelSequencePlayer.Play();
					}
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
				}
				else
				{
					this.FinishSequenceAnim(qteId);
					ControllerBase<SequenceController>.Instance.ResumeSequence("QTE", null);
				}
			}
			sequenceCommonQteHandle.OnFinish();
			ControllerBase<FlowController>.Instance.EnableSkip(true);
			ControllerBase<PlotController>.Instance.PlotViewManager.EnableInteractPlot(true, new bool?(true), "SequenceQte", null);
			this.CurrentSequenceQte.Remove(qteId);
		}

		// Token: 0x06036934 RID: 223540 RVA: 0x00DCBE60 File Offset: 0x00DCA060
		private void OnTick(float delta)
		{
			this.ReleasePendingQtes();
			this.HandlePendingQteEvents();
			if (this.CurrentSequenceQte.Count <= 0)
			{
				goto IL_69;
			}
			using (Dictionary<int, ISequenceCommonQteHandle>.Enumerator enumerator = this.CurrentSequenceQte.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, ISequenceCommonQteHandle> keyValuePair = enumerator.Current;
					keyValuePair.Value.OnTick(delta);
				}
				goto IL_69;
			}
			IL_56:
			int qteId = this.PendingFinishQteQueue.Pop();
			this.HandleFinishSequenceQte(qteId);
			IL_69:
			if (this.PendingFinishQteQueue.Size <= 0)
			{
				return;
			}
			goto IL_56;
		}

		// Token: 0x06036935 RID: 223541 RVA: 0x00DCBEF4 File Offset: 0x00DCA0F4
		private void CollectPendingStartQteIds()
		{
			while (this.PendingQteEventQueue.Size > 0)
			{
				SequenceQteManager.TPendingQteEvent tpendingQteEvent = this.PendingQteEventQueue.Pop();
				if (tpendingQteEvent != null && tpendingQteEvent.Type == SequenceQteManager.EQtePendingEventType.Start)
				{
					this.PendingReleaseQteIds.Add(((SequenceQteManager.IPendingQteStartEvent)tpendingQteEvent).Data.QteId);
				}
			}
		}

		// Token: 0x06036936 RID: 223542 RVA: 0x00DCBF44 File Offset: 0x00DCA144
		private void ReleasePendingQtes()
		{
			UMovieSceneQteManager qteManager = this.QteManager;
			if (!ObjectUtils.IsValid(qteManager))
			{
				this.PendingReleaseQteIds.Clear();
				return;
			}
			foreach (int num in this.PendingReleaseQteIds)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[FlowSequence][PlotQte] 尝试释放未接管的原生Qte";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", num);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				qteManager.FinishQte(num);
			}
			this.PendingReleaseQteIds.Clear();
		}

		// Token: 0x06036937 RID: 223543 RVA: 0x00DCBFE8 File Offset: 0x00DCA1E8
		private void HandlePendingQteEvents()
		{
			int i = this.PendingQteEventQueue.Size;
			while (i > 0)
			{
				i--;
				SequenceQteManager.TPendingQteEvent tpendingQteEvent = this.PendingQteEventQueue.Pop();
				if (tpendingQteEvent != null)
				{
					if (tpendingQteEvent.Type == SequenceQteManager.EQtePendingEventType.Start)
					{
						this.StartSequenceQte(((SequenceQteManager.IPendingQteStartEvent)tpendingQteEvent).Data);
					}
					else
					{
						this.OnSequenceAnimFinished(((SequenceQteManager.IPendingQteAnimEndEvent)tpendingQteEvent).QteId);
					}
				}
			}
		}

		// Token: 0x06036938 RID: 223544 RVA: 0x00DCC048 File Offset: 0x00DCA248
		[NullableContext(2)]
		public void ForwardSequenceAnim(int id, float progress, FFrameTime toFrame)
		{
			UMovieSceneQteManager qteManager = this.QteManager;
			if (qteManager != null)
			{
				qteManager.UpdateQte(id, true, progress);
			}
			if (this.PlayDirection != SequenceQteManager.EDirection.Forward)
			{
				this.PlayDirection = SequenceQteManager.EDirection.Forward;
				if (toFrame != null && ModelBase<SequenceModel>.Instance.IsPlaying)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 0", null);
					ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
					if (curLevelSeqActor != null)
					{
						curLevelSeqActor.SequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(toFrame, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play));
					}
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
				}
			}
		}

		// Token: 0x06036939 RID: 223545 RVA: 0x00DCC0DC File Offset: 0x00DCA2DC
		[NullableContext(2)]
		public void BackwardSequenceAnim(int id, float progress, FFrameTime toFrame)
		{
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (!this.CurrentSequenceQte.TryGetValue(id, out sequenceCommonQteHandle))
			{
				return;
			}
			UMovieSceneQteManager qteManager = this.QteManager;
			if (qteManager != null)
			{
				qteManager.UpdateQte(id, false, progress);
			}
			if (this.PlayDirection != SequenceQteManager.EDirection.Backward)
			{
				this.PlayDirection = SequenceQteManager.EDirection.Backward;
				if (toFrame != null && ModelBase<SequenceModel>.Instance.IsPlaying)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 0", null);
					ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
					if (curLevelSeqActor != null)
					{
						ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
						if (sequencePlayer != null)
						{
							sequencePlayer.PlayTo(new FMovieSceneSequencePlaybackParams(toFrame, 0f, "", EMovieScenePositionType.Frame, EUpdatePositionMethod.Play));
						}
					}
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Animation.ForbiddenEvaluateTwice 1", null);
				}
			}
		}

		// Token: 0x0603693A RID: 223546 RVA: 0x00DCC188 File Offset: 0x00DCA388
		public void FinishSequenceAnim(int id)
		{
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (!this.CurrentSequenceQte.TryGetValue(id, out sequenceCommonQteHandle))
			{
				return;
			}
			UMovieSceneQteManager qteManager = this.QteManager;
			if (qteManager == null)
			{
				return;
			}
			qteManager.FinishQte(id);
		}

		// Token: 0x0603693B RID: 223547 RVA: 0x00DCC1B7 File Offset: 0x00DCA3B7
		public void SetPlayRate(float playRate)
		{
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
				if (curLevelSeqActor == null)
				{
					return;
				}
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.SetPlayRate(playRate);
			}
		}

		// Token: 0x0603693C RID: 223548 RVA: 0x00DCC1E4 File Offset: 0x00DCA3E4
		public void ResetPlayRate()
		{
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
				if (curLevelSeqActor == null)
				{
					return;
				}
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.SetPlayRate(1f);
			}
		}

		// Token: 0x0603693D RID: 223549 RVA: 0x00DCC218 File Offset: 0x00DCA418
		[NullableContext(2)]
		public ISequenceCommonQteHandle CreateQte(int qteId, int subtitleId, bool isProgress, bool isGroup, FFrameTime startFrame, FFrameTime endFrame, AActor attachActor, QteSpineInfoProxy spineInfo, [Nullable(new byte[]
		{
			2,
			1
		})] List<MovieSceneSubQteParamsProxy> subQteParams, bool? isUpdateWithProgress)
		{
			CommonQteContextBase commonQteContextBase;
			if (isGroup)
			{
				commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQteGroup(qteId, null, null, EQteSource.Plot, new QteExtraParams
				{
					AttachTarget = attachActor
				});
			}
			else
			{
				commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQte(qteId, null, null, EQteSource.Plot, new QteExtraParams
				{
					AttachTarget = attachActor
				});
			}
			if (commonQteContextBase == null)
			{
				return null;
			}
			ISequenceCommonQteHandle sequenceCommonQteHandle;
			if (commonQteContextBase.Type.GetValueOrDefault() == ECommonQteContextType.SingleButtonLongPress)
			{
				sequenceCommonQteHandle = new SequenceQteLongPress(this, (CommonQteLongPressContext)commonQteContextBase);
			}
			else if (commonQteContextBase.Type.GetValueOrDefault() == ECommonQteContextType.SingleButtonContinuousClick)
			{
				sequenceCommonQteHandle = new SequenceQteContinuousClick(this, (CommonQteContinuousClickContext)commonQteContextBase);
			}
			else if (commonQteContextBase.Type.GetValueOrDefault() == ECommonQteContextType.SelectOption)
			{
				sequenceCommonQteHandle = new SequenceQteSelectOption(this, (CommonQteSelectOptionContext)commonQteContextBase);
			}
			else if (commonQteContextBase.Type.GetValueOrDefault() == ECommonQteContextType.QteGroup)
			{
				sequenceCommonQteHandle = new SequenceQteGroup(this, (CommonQteGroupContext)commonQteContextBase);
				((SequenceQteGroup)sequenceCommonQteHandle).SetSubQteParams(subQteParams);
			}
			else if (commonQteContextBase.Type.GetValueOrDefault() == ECommonQteContextType.SingleButtonDrag)
			{
				sequenceCommonQteHandle = new SequenceQteDrag(this, (CommonQteDragContext)commonQteContextBase);
			}
			else
			{
				sequenceCommonQteHandle = new SequenceQteHandleBase<CommonQteContextBase>(this, commonQteContextBase);
			}
			sequenceCommonQteHandle.SubtitleId = subtitleId;
			sequenceCommonQteHandle.IsProgressQte = isProgress;
			sequenceCommonQteHandle.SequenceQteStartRange = startFrame;
			sequenceCommonQteHandle.SequenceQteEndRange = endFrame;
			sequenceCommonQteHandle.SpineInfo = spineInfo;
			sequenceCommonQteHandle.IsUpdateWithProgress = isUpdateWithProgress.GetValueOrDefault();
			return sequenceCommonQteHandle;
		}

		// Token: 0x0401F70A RID: 128778
		private const string QTE_REASON = "QTE";

		// Token: 0x0401F70B RID: 128779
		private const string EnableInteractReason = "SequenceQte";

		// Token: 0x0401F70C RID: 128780
		private readonly Dictionary<int, ISequenceCommonQteHandle> CurrentSequenceQte = new Dictionary<int, ISequenceCommonQteHandle>();

		// Token: 0x0401F70D RID: 128781
		private SequenceQteManager.EDirection PlayDirection = SequenceQteManager.EDirection.Pause;

		// Token: 0x0401F70E RID: 128782
		[Nullable(2)]
		public UMovieSceneQteManager QteManager;

		// Token: 0x0401F70F RID: 128783
		public Dictionary<int, int> PendingOptionResult = new Dictionary<int, int>();

		// Token: 0x0401F710 RID: 128784
		private int AfterTickHandleId;

		// Token: 0x0401F711 RID: 128785
		private readonly Queue<int> PendingFinishQteQueue = new Queue<int>(4);

		// Token: 0x0401F712 RID: 128786
		private readonly Queue<SequenceQteManager.TPendingQteEvent> PendingQteEventQueue = new Queue<SequenceQteManager.TPendingQteEvent>(4);

		// Token: 0x0401F713 RID: 128787
		private readonly HashSet<int> PendingReleaseQteIds = new HashSet<int>();

		// Token: 0x0200B2E2 RID: 45794
		[NullableContext(0)]
		private enum EDirection
		{
			// Token: 0x04037710 RID: 227088
			Forward,
			// Token: 0x04037711 RID: 227089
			Backward,
			// Token: 0x04037712 RID: 227090
			Pause
		}

		// Token: 0x0200B2E3 RID: 45795
		[NullableContext(0)]
		private enum EQtePendingEventType
		{
			// Token: 0x04037714 RID: 227092
			Start,
			// Token: 0x04037715 RID: 227093
			AnimEnd
		}

		// Token: 0x0200B2E4 RID: 45796
		[NullableContext(2)]
		private interface ISequenceQteStartData
		{
			// Token: 0x1700A96B RID: 43371
			// (get) Token: 0x0604C8FE RID: 313598
			// (set) Token: 0x0604C8FF RID: 313599
			int QteId { get; set; }

			// Token: 0x1700A96C RID: 43372
			// (get) Token: 0x0604C900 RID: 313600
			// (set) Token: 0x0604C901 RID: 313601
			int SubtitleId { get; set; }

			// Token: 0x1700A96D RID: 43373
			// (get) Token: 0x0604C902 RID: 313602
			// (set) Token: 0x0604C903 RID: 313603
			bool IsProgress { get; set; }

			// Token: 0x1700A96E RID: 43374
			// (get) Token: 0x0604C904 RID: 313604
			// (set) Token: 0x0604C905 RID: 313605
			bool IsGroupQte { get; set; }

			// Token: 0x1700A96F RID: 43375
			// (get) Token: 0x0604C906 RID: 313606
			// (set) Token: 0x0604C907 RID: 313607
			FFrameTime StartFrame { get; set; }

			// Token: 0x1700A970 RID: 43376
			// (get) Token: 0x0604C908 RID: 313608
			// (set) Token: 0x0604C909 RID: 313609
			FFrameTime EndFrame { get; set; }

			// Token: 0x1700A971 RID: 43377
			// (get) Token: 0x0604C90A RID: 313610
			// (set) Token: 0x0604C90B RID: 313611
			AActor AttachActor { get; set; }

			// Token: 0x1700A972 RID: 43378
			// (get) Token: 0x0604C90C RID: 313612
			// (set) Token: 0x0604C90D RID: 313613
			QteSpineInfoProxy SpineInfo { get; set; }

			// Token: 0x1700A973 RID: 43379
			// (get) Token: 0x0604C90E RID: 313614
			// (set) Token: 0x0604C90F RID: 313615
			bool IsUpdateWithProgress { get; set; }

			// Token: 0x1700A974 RID: 43380
			// (get) Token: 0x0604C910 RID: 313616
			// (set) Token: 0x0604C911 RID: 313617
			[Nullable(new byte[]
			{
				2,
				1
			})]
			List<MovieSceneSubQteParamsProxy> SubQteParams { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }
		}

		// Token: 0x0200B2E5 RID: 45797
		[NullableContext(2)]
		[Nullable(0)]
		[RequiredMember]
		private class SequenceQteStartData : SequenceQteManager.ISequenceQteStartData
		{
			// Token: 0x1700A975 RID: 43381
			// (get) Token: 0x0604C912 RID: 313618 RVA: 0x014FD65A File Offset: 0x014FB85A
			// (set) Token: 0x0604C913 RID: 313619 RVA: 0x014FD662 File Offset: 0x014FB862
			[RequiredMember]
			public int QteId { get; set; }

			// Token: 0x1700A976 RID: 43382
			// (get) Token: 0x0604C914 RID: 313620 RVA: 0x014FD66B File Offset: 0x014FB86B
			// (set) Token: 0x0604C915 RID: 313621 RVA: 0x014FD673 File Offset: 0x014FB873
			[RequiredMember]
			public int SubtitleId { get; set; }

			// Token: 0x1700A977 RID: 43383
			// (get) Token: 0x0604C916 RID: 313622 RVA: 0x014FD67C File Offset: 0x014FB87C
			// (set) Token: 0x0604C917 RID: 313623 RVA: 0x014FD684 File Offset: 0x014FB884
			[RequiredMember]
			public bool IsProgress { get; set; }

			// Token: 0x1700A978 RID: 43384
			// (get) Token: 0x0604C918 RID: 313624 RVA: 0x014FD68D File Offset: 0x014FB88D
			// (set) Token: 0x0604C919 RID: 313625 RVA: 0x014FD695 File Offset: 0x014FB895
			[RequiredMember]
			public bool IsGroupQte { get; set; }

			// Token: 0x1700A979 RID: 43385
			// (get) Token: 0x0604C91A RID: 313626 RVA: 0x014FD69E File Offset: 0x014FB89E
			// (set) Token: 0x0604C91B RID: 313627 RVA: 0x014FD6A6 File Offset: 0x014FB8A6
			public FFrameTime StartFrame { get; set; }

			// Token: 0x1700A97A RID: 43386
			// (get) Token: 0x0604C91C RID: 313628 RVA: 0x014FD6AF File Offset: 0x014FB8AF
			// (set) Token: 0x0604C91D RID: 313629 RVA: 0x014FD6B7 File Offset: 0x014FB8B7
			public FFrameTime EndFrame { get; set; }

			// Token: 0x1700A97B RID: 43387
			// (get) Token: 0x0604C91E RID: 313630 RVA: 0x014FD6C0 File Offset: 0x014FB8C0
			// (set) Token: 0x0604C91F RID: 313631 RVA: 0x014FD6C8 File Offset: 0x014FB8C8
			public AActor AttachActor { get; set; }

			// Token: 0x1700A97C RID: 43388
			// (get) Token: 0x0604C920 RID: 313632 RVA: 0x014FD6D1 File Offset: 0x014FB8D1
			// (set) Token: 0x0604C921 RID: 313633 RVA: 0x014FD6D9 File Offset: 0x014FB8D9
			public QteSpineInfoProxy SpineInfo { get; set; }

			// Token: 0x1700A97D RID: 43389
			// (get) Token: 0x0604C922 RID: 313634 RVA: 0x014FD6E2 File Offset: 0x014FB8E2
			// (set) Token: 0x0604C923 RID: 313635 RVA: 0x014FD6EA File Offset: 0x014FB8EA
			[RequiredMember]
			public bool IsUpdateWithProgress { get; set; }

			// Token: 0x1700A97E RID: 43390
			// (get) Token: 0x0604C924 RID: 313636 RVA: 0x014FD6F3 File Offset: 0x014FB8F3
			// (set) Token: 0x0604C925 RID: 313637 RVA: 0x014FD6FB File Offset: 0x014FB8FB
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public List<MovieSceneSubQteParamsProxy> SubQteParams { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }

			// Token: 0x0604C926 RID: 313638 RVA: 0x014FD704 File Offset: 0x014FB904
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public SequenceQteStartData()
			{
			}
		}

		// Token: 0x0200B2E6 RID: 45798
		private interface IPendingQteStartEvent : SequenceQteManager.TPendingQteEvent
		{
			// Token: 0x1700A97F RID: 43391
			// (get) Token: 0x0604C927 RID: 313639
			// (set) Token: 0x0604C928 RID: 313640
			SequenceQteManager.ISequenceQteStartData Data { get; set; }
		}

		// Token: 0x0200B2E7 RID: 45799
		[Nullable(0)]
		[RequiredMember]
		private class PendingQteStartEvent : SequenceQteManager.IPendingQteStartEvent, SequenceQteManager.TPendingQteEvent
		{
			// Token: 0x1700A980 RID: 43392
			// (get) Token: 0x0604C929 RID: 313641 RVA: 0x014FD70C File Offset: 0x014FB90C
			// (set) Token: 0x0604C92A RID: 313642 RVA: 0x014FD714 File Offset: 0x014FB914
			[RequiredMember]
			public SequenceQteManager.EQtePendingEventType Type { get; set; }

			// Token: 0x1700A981 RID: 43393
			// (get) Token: 0x0604C92B RID: 313643 RVA: 0x014FD71D File Offset: 0x014FB91D
			// (set) Token: 0x0604C92C RID: 313644 RVA: 0x014FD725 File Offset: 0x014FB925
			[RequiredMember]
			public SequenceQteManager.ISequenceQteStartData Data { get; set; }

			// Token: 0x0604C92D RID: 313645 RVA: 0x014FD72E File Offset: 0x014FB92E
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public PendingQteStartEvent()
			{
			}
		}

		// Token: 0x0200B2E8 RID: 45800
		[NullableContext(0)]
		private interface IPendingQteAnimEndEvent : SequenceQteManager.TPendingQteEvent
		{
			// Token: 0x1700A982 RID: 43394
			// (get) Token: 0x0604C92E RID: 313646
			// (set) Token: 0x0604C92F RID: 313647
			int QteId { get; set; }
		}

		// Token: 0x0200B2E9 RID: 45801
		[NullableContext(0)]
		[RequiredMember]
		private class PendingQteAnimEndEvent : SequenceQteManager.IPendingQteAnimEndEvent, SequenceQteManager.TPendingQteEvent
		{
			// Token: 0x1700A983 RID: 43395
			// (get) Token: 0x0604C930 RID: 313648 RVA: 0x014FD736 File Offset: 0x014FB936
			// (set) Token: 0x0604C931 RID: 313649 RVA: 0x014FD73E File Offset: 0x014FB93E
			[RequiredMember]
			public SequenceQteManager.EQtePendingEventType Type { get; set; }

			// Token: 0x1700A984 RID: 43396
			// (get) Token: 0x0604C932 RID: 313650 RVA: 0x014FD747 File Offset: 0x014FB947
			// (set) Token: 0x0604C933 RID: 313651 RVA: 0x014FD74F File Offset: 0x014FB94F
			[RequiredMember]
			public int QteId { get; set; }

			// Token: 0x0604C934 RID: 313652 RVA: 0x014FD758 File Offset: 0x014FB958
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public PendingQteAnimEndEvent()
			{
			}
		}

		// Token: 0x0200B2EA RID: 45802
		private interface TPendingQteEvent
		{
			// Token: 0x1700A985 RID: 43397
			// (get) Token: 0x0604C935 RID: 313653
			// (set) Token: 0x0604C936 RID: 313654
			SequenceQteManager.EQtePendingEventType Type { get; set; }
		}
	}
}
