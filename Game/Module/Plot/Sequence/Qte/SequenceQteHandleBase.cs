using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005395 RID: 21397
	[NullableContext(2)]
	[Nullable(0)]
	public class SequenceQteHandleBase<[Nullable(0)] T> : ISequenceCommonQteHandle where T : CommonQteContextBase
	{
		// Token: 0x060368FE RID: 223486 RVA: 0x00DCAAC4 File Offset: 0x00DC8CC4
		[NullableContext(1)]
		public SequenceQteHandleBase(SequenceQteManager qteManager, T context)
		{
			this.QteManager = qteManager;
			this.Context = context;
			this.Context.SuccessCallback = new TCommonQteCallback(this.OnQteSucceed);
			this.Context.FailCallback = new TCommonQteCallback(this.OnQteFailed);
		}

		// Token: 0x17008DA0 RID: 36256
		// (get) Token: 0x060368FF RID: 223487 RVA: 0x00DCAB57 File Offset: 0x00DC8D57
		// (set) Token: 0x06036900 RID: 223488 RVA: 0x00DCAB5F File Offset: 0x00DC8D5F
		public int SubtitleId { get; set; } = -1;

		// Token: 0x17008DA1 RID: 36257
		// (get) Token: 0x06036901 RID: 223489 RVA: 0x00DCAB68 File Offset: 0x00DC8D68
		// (set) Token: 0x06036902 RID: 223490 RVA: 0x00DCAB70 File Offset: 0x00DC8D70
		public int OptionIndex { get; set; } = -1;

		// Token: 0x17008DA2 RID: 36258
		// (get) Token: 0x06036903 RID: 223491 RVA: 0x00DCAB79 File Offset: 0x00DC8D79
		// (set) Token: 0x06036904 RID: 223492 RVA: 0x00DCAB81 File Offset: 0x00DC8D81
		public bool IsProgressQte { get; set; }

		// Token: 0x17008DA3 RID: 36259
		// (get) Token: 0x06036905 RID: 223493 RVA: 0x00DCAB8A File Offset: 0x00DC8D8A
		// (set) Token: 0x06036906 RID: 223494 RVA: 0x00DCAB92 File Offset: 0x00DC8D92
		public FFrameTime SequenceQteStartRange { get; set; }

		// Token: 0x17008DA4 RID: 36260
		// (get) Token: 0x06036907 RID: 223495 RVA: 0x00DCAB9B File Offset: 0x00DC8D9B
		// (set) Token: 0x06036908 RID: 223496 RVA: 0x00DCABA3 File Offset: 0x00DC8DA3
		public FFrameTime SequenceQteEndRange { get; set; }

		// Token: 0x17008DA5 RID: 36261
		// (get) Token: 0x06036909 RID: 223497 RVA: 0x00DCABAC File Offset: 0x00DC8DAC
		// (set) Token: 0x0603690A RID: 223498 RVA: 0x00DCABB4 File Offset: 0x00DC8DB4
		public bool IsUpdateWithProgress { get; set; }

		// Token: 0x17008DA6 RID: 36262
		// (get) Token: 0x0603690B RID: 223499 RVA: 0x00DCABBD File Offset: 0x00DC8DBD
		// (set) Token: 0x0603690C RID: 223500 RVA: 0x00DCABC5 File Offset: 0x00DC8DC5
		public QteSpineInfoProxy SpineInfo { get; set; }

		// Token: 0x0603690D RID: 223501 RVA: 0x00DCABCE File Offset: 0x00DC8DCE
		public void OnSequenceAnimFinished()
		{
			this.MarkSequenceQtePending = false;
			this.CheckFinish();
		}

		// Token: 0x0603690E RID: 223502 RVA: 0x00DCABDD File Offset: 0x00DC8DDD
		protected void OnQteSucceed(CommonQteContextBase context)
		{
			Singleton<AudioSystem>.Instance.PostEvent("plot_seq_qte_success");
			this.OptionIndex = 0;
			this.OnCommonQteFinished();
		}

		// Token: 0x0603690F RID: 223503 RVA: 0x00DCABFC File Offset: 0x00DC8DFC
		protected void OnQteFailed(CommonQteContextBase context)
		{
			this.OptionIndex = 1;
			Singleton<AudioSystem>.Instance.PostEvent("plot_seq_qte_timeout");
			this.OnCommonQteFinished();
		}

		// Token: 0x06036910 RID: 223504 RVA: 0x00DCAC1C File Offset: 0x00DC8E1C
		public virtual void OnBegin()
		{
			if (!this.IsProgressQte)
			{
				SCommonQte config = this.Context.Config;
				float playRate = (config != null) ? config.BaseConfig.TimeDilation : 1f;
				this.QteManager.SetPlayRate(playRate);
			}
			this.NeedTick = true;
			if (this.SpineInfo != null)
			{
				ControllerBase<PlotController>.Instance.PlotViewManager.RunWithPlotSubtitleView("RegisterQteSpineCallback", delegate(PlotSubtitleView view)
				{
					if (this.SpineInfo == null || !this.NeedTick)
					{
						return UniTask.FromResult<object>(false);
					}
					this.View = view;
					this.View.RegisterCallback(new Action<string>(this.OnSpineFinishedCallback));
					return UniTask.FromResult<object>(true);
				}, null);
			}
			this.ProgressLerpSpeed = -1f;
			if (this.IsProgressQte)
			{
				this.SectionLength = this.SequenceQteEndRange.FrameNumber.Value - this.SequenceQteStartRange.FrameNumber.Value;
			}
		}

		// Token: 0x06036911 RID: 223505 RVA: 0x00DCACCE File Offset: 0x00DC8ECE
		public virtual void OnFinish()
		{
			this.ResultSpineCheckList.Clear();
			this.QteManager.ResetPlayRate();
			if (this.SpineInfo != null)
			{
				PlotSubtitleView view = this.View;
				if (view != null)
				{
					view.RegisterCallback(null);
				}
				this.View = null;
			}
		}

		// Token: 0x06036912 RID: 223506 RVA: 0x00DCAD08 File Offset: 0x00DC8F08
		public void ForceStopSequenceQte()
		{
			if (this.Context.IsActive())
			{
				this.Context.SuccessCallback = null;
				this.Context.FailCallback = null;
				ControllerBase<CommonQteController>.Instance.StopQte(this.Context.HandleId);
			}
			this.IsForceStop = true;
			this.NeedTick = false;
			this.QteManager.FinishSequenceAnim(this.Context.QteId);
			Singleton<AudioSystem>.Instance.SetRtpcValue("plot_seq_qte_time_scale", 1f, null);
			this.CloseAllSpine();
			this.OnFinish();
		}

		// Token: 0x06036913 RID: 223507 RVA: 0x00DCADB5 File Offset: 0x00DC8FB5
		protected virtual void OnReceiveTick(float delta)
		{
			this.Progress = Singleton<MathUtils>.Instance.Clamp(this.Context.GetProgress(), 0f, 1f);
		}

		// Token: 0x06036914 RID: 223508 RVA: 0x00DCADE4 File Offset: 0x00DC8FE4
		public void OnTick(float inDelta)
		{
			if (!this.NeedTick)
			{
				return;
			}
			float num = inDelta;
			if (this.TickInterval > 0f)
			{
				this.TickCheckTime += inDelta;
				if (this.TickCheckTime < this.TickInterval)
				{
					return;
				}
				num = this.TickCheckTime;
				this.TickCheckTime = 0f;
			}
			this.LastProgress = this.CacheProgress;
			this.OnReceiveTick(num);
			if (this.ProgressLerpSpeed > 0f)
			{
				this.CacheProgress = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheProgress, this.Progress, num, this.ProgressLerpSpeed);
			}
			else
			{
				this.CacheProgress = this.Progress;
			}
			this.UpdateSequenceQte(num);
			this.UpdateSpine();
			if (this.HasCommonQteFinished && this.CheckProgressFinish())
			{
				this.NeedTick = false;
				this.PlayResultSpine(!this.Context.IsFail(), null);
				this.CheckFinish();
			}
		}

		// Token: 0x06036915 RID: 223509 RVA: 0x00DCAED0 File Offset: 0x00DC90D0
		protected virtual void UpdateSequenceQte(float delta)
		{
			if (this.CacheProgress > this.LastProgress)
			{
				this.QteManager.ForwardSequenceAnim(this.Context.QteId, this.CacheProgress, this.SequenceQteEndRange);
			}
			else if (this.CacheProgress < this.LastProgress)
			{
				this.MarkSequenceQtePending = true;
				this.QteManager.BackwardSequenceAnim(this.Context.QteId, this.CacheProgress, this.SequenceQteStartRange);
			}
			if (this.IsUpdateWithProgress && this.IsProgressQte)
			{
				if (delta <= 0f)
				{
					return;
				}
				float? num = Math.Abs(this.CacheProgress - this.LastProgress) * (float)this.SectionLength / ModelBase<SequenceModel>.Instance.CurFrameRate * (float)1000 / delta;
				this.QteManager.SetPlayRate(num.GetValueOrDefault());
			}
		}

		// Token: 0x06036916 RID: 223510 RVA: 0x00DCB020 File Offset: 0x00DC9220
		[NullableContext(1)]
		protected void OnSpineFinishedCallback(string spineName)
		{
			if (this.ResultSpineCheckList.Remove(spineName) && this.ResultSpineCheckList.Count == 0)
			{
				this.CheckFinish();
			}
		}

		// Token: 0x06036917 RID: 223511 RVA: 0x00DCB044 File Offset: 0x00DC9244
		protected virtual void OnCommonQteFinished()
		{
			this.HasCommonQteFinished = true;
			Singleton<AudioSystem>.Instance.SetRtpcValue("plot_seq_qte_time_scale", 1f, null);
			this.QteManager.ResetPlayRate();
			this.CheckFinish();
		}

		// Token: 0x06036918 RID: 223512 RVA: 0x00DCB088 File Offset: 0x00DC9288
		protected void UpdateSpine()
		{
			if (this.SpineInfo == null)
			{
				return;
			}
			HashSet<string> activeProgressSpineNames = this.GetActiveProgressSpineNames();
			if (activeProgressSpineNames.Count == 0)
			{
				this.PlayStartSpines();
				if (this.CacheProgress > 0f)
				{
					PlotSubtitleView view = this.View;
					if (view == null)
					{
						return;
					}
					view.ManualUpdateNiagara(this.SpineInfo.NiagaraParamNames, this.CacheProgress);
				}
				return;
			}
			this.CloseStartSpines();
			this.UpdateProgressSpineSegments(activeProgressSpineNames);
			PlotSubtitleView view2 = this.View;
			if (view2 == null)
			{
				return;
			}
			view2.ManualUpdateNiagara(this.SpineInfo.NiagaraParamNames, this.CacheProgress);
		}

		// Token: 0x06036919 RID: 223513 RVA: 0x00DCB110 File Offset: 0x00DC9310
		[NullableContext(1)]
		private HashSet<string> GetActiveProgressSpineNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			QteSpineInfoProxy spineInfo = this.SpineInfo;
			if (((spineInfo != null) ? spineInfo.ProgressSpineSegments : null) != null)
			{
				foreach (QteProgressSpineSegmentProxy qteProgressSpineSegmentProxy in this.SpineInfo.ProgressSpineSegments)
				{
					if (qteProgressSpineSegmentProxy.IsActive(this.CacheProgress))
					{
						foreach (SpineDataProxy spineDataProxy in qteProgressSpineSegmentProxy.Spines)
						{
							if (!string.IsNullOrEmpty(spineDataProxy.Name))
							{
								hashSet.Add(spineDataProxy.Name);
							}
						}
					}
				}
			}
			return hashSet;
		}

		// Token: 0x0603691A RID: 223514 RVA: 0x00DCB1E8 File Offset: 0x00DC93E8
		[NullableContext(1)]
		private void UpdateProgressSpineSegments(HashSet<string> activeSpineNames)
		{
			this.CloseInactiveProgressSpines(activeSpineNames);
			QteSpineInfoProxy spineInfo = this.SpineInfo;
			if (((spineInfo != null) ? spineInfo.ProgressSpineSegments : null) != null)
			{
				foreach (QteProgressSpineSegmentProxy qteProgressSpineSegmentProxy in this.SpineInfo.ProgressSpineSegments)
				{
					if (qteProgressSpineSegmentProxy.IsActive(this.CacheProgress))
					{
						foreach (SpineDataProxy spineDataProxy in qteProgressSpineSegmentProxy.Spines)
						{
							if (!string.IsNullOrEmpty(spineDataProxy.Name))
							{
								if (!this.ActiveProgressSpineNames.Contains(spineDataProxy.Name))
								{
									PlotSubtitleView view = this.View;
									if (view != null)
									{
										view.PlaySonUiSpine(spineDataProxy.Name, spineDataProxy.NeedLoop.GetValueOrDefault(), true, qteProgressSpineSegmentProxy.BlendInTime);
									}
									this.ActiveProgressSpineNames.Add(spineDataProxy.Name);
								}
								this.ActiveProgressSpineSegments[spineDataProxy.Name] = qteProgressSpineSegmentProxy;
								PlotSubtitleView view2 = this.View;
								if (view2 != null)
								{
									view2.UpdateSpineForQteByName(spineDataProxy.Name, qteProgressSpineSegmentProxy.GetSpineProgress(this.CacheProgress));
								}
							}
						}
					}
				}
			}
			this.HasPlayProgressSpine = (this.ActiveProgressSpineNames.Count > 0);
		}

		// Token: 0x0603691B RID: 223515 RVA: 0x00DCB358 File Offset: 0x00DC9558
		private void PlayStartSpines()
		{
			if (this.HasPlayProgressSpine)
			{
				this.CloseInactiveProgressSpines(new HashSet<string>());
				this.HasPlayProgressSpine = false;
			}
			if (!this.HasPlayStartSpine)
			{
				QteSpineInfoProxy spineInfo = this.SpineInfo;
				foreach (SpineDataProxy spineDataProxy in (((spineInfo != null) ? spineInfo.StartLoopSpines : null) ?? new List<SpineDataProxy>()))
				{
					PlotSubtitleView view = this.View;
					if (view != null)
					{
						view.PlaySonUiSpine(spineDataProxy.Name, spineDataProxy.NeedLoop.GetValueOrDefault(), false, 0f);
					}
				}
				this.HasPlayStartSpine = true;
			}
		}

		// Token: 0x0603691C RID: 223516 RVA: 0x00DCB40C File Offset: 0x00DC960C
		private void CloseStartSpines()
		{
			if (this.HasPlayStartSpine)
			{
				QteSpineInfoProxy spineInfo = this.SpineInfo;
				this.CloseSpine((spineInfo != null) ? spineInfo.StartLoopSpines : null, 0.5f);
				this.HasPlayStartSpine = false;
			}
		}

		// Token: 0x0603691D RID: 223517 RVA: 0x00DCB43C File Offset: 0x00DC963C
		[NullableContext(1)]
		private void CloseInactiveProgressSpines(HashSet<string> activeSpineNames)
		{
			foreach (string text in this.ActiveProgressSpineNames.ToList<string>())
			{
				if (!activeSpineNames.Contains(text))
				{
					QteProgressSpineSegmentProxy qteProgressSpineSegmentProxy;
					this.ActiveProgressSpineSegments.TryGetValue(text, out qteProgressSpineSegmentProxy);
					PlotSubtitleView view = this.View;
					if (view != null)
					{
						view.CloseSpineAnimation(text, (qteProgressSpineSegmentProxy != null) ? qteProgressSpineSegmentProxy.BlendOutTime : 0f);
					}
					this.ActiveProgressSpineNames.Remove(text);
					this.ActiveProgressSpineSegments.Remove(text);
				}
			}
		}

		// Token: 0x0603691E RID: 223518 RVA: 0x00DCB4E4 File Offset: 0x00DC96E4
		protected void CloseSpine([Nullable(new byte[]
		{
			2,
			1
		})] List<SpineDataProxy> spines, float blendOutTime = 0f)
		{
			if (spines == null)
			{
				return;
			}
			foreach (SpineDataProxy spineDataProxy in spines)
			{
				PlotSubtitleView view = this.View;
				if (view != null)
				{
					view.CloseSpineAnimation(spineDataProxy.Name, blendOutTime);
				}
			}
		}

		// Token: 0x0603691F RID: 223519 RVA: 0x00DCB548 File Offset: 0x00DC9748
		protected void CloseAllSpine()
		{
			if (this.SpineInfo == null)
			{
				return;
			}
			this.CloseSpine(this.SpineInfo.GetProgressSpines(), 0f);
			this.CloseSpine(this.SpineInfo.StartLoopSpines, 0f);
			this.CloseSpine(this.SpineInfo.EndSpine, 0f);
			this.CloseSpine(this.SpineInfo.SuccessSpine, 0f);
			this.CloseSpine(this.SpineInfo.FailSpine, 0f);
			this.ActiveProgressSpineNames.Clear();
			this.ActiveProgressSpineSegments.Clear();
			this.HasPlayProgressSpine = false;
			this.HasPlayStartSpine = false;
		}

		// Token: 0x06036920 RID: 223520 RVA: 0x00DCB5F0 File Offset: 0x00DC97F0
		protected void CloseProgressSpine()
		{
			if (this.SpineInfo == null)
			{
				return;
			}
			if (this.HasPlayProgressSpine)
			{
				this.CloseSpine(this.SpineInfo.GetProgressSpines(), 0f);
				this.ActiveProgressSpineNames.Clear();
				this.ActiveProgressSpineSegments.Clear();
				this.HasPlayProgressSpine = false;
			}
			if (this.HasPlayStartSpine)
			{
				this.CloseSpine(this.SpineInfo.StartLoopSpines, 0f);
				this.HasPlayStartSpine = false;
			}
		}

		// Token: 0x06036921 RID: 223521 RVA: 0x00DCB668 File Offset: 0x00DC9868
		protected void PlayResultSpine(bool isSuccess, QteSpineInfoProxy spineInfo = null)
		{
			if (spineInfo == null)
			{
				spineInfo = this.SpineInfo;
			}
			if (spineInfo == null)
			{
				return;
			}
			if (spineInfo == this.SpineInfo)
			{
				this.CloseProgressSpine();
			}
			List<SpineDataProxy> list = isSuccess ? spineInfo.GetSuccessResultSpine() : spineInfo.GetFailResultSpine();
			if (list != null)
			{
				foreach (SpineDataProxy spineDataProxy in list)
				{
					if (!string.IsNullOrEmpty(spineDataProxy.Name))
					{
						if (this.View != null && spineInfo.WaitEndSpineFinish && !spineDataProxy.NeedLoop.GetValueOrDefault())
						{
							this.ResultSpineCheckList.Add(spineDataProxy.Name);
						}
						PlotSubtitleView view = this.View;
						if (view != null)
						{
							view.PlaySonUiSpine(spineDataProxy.Name, spineDataProxy.NeedLoop.GetValueOrDefault(), false, 0f);
						}
					}
				}
			}
			int count = this.ResultSpineCheckList.Count;
		}

		// Token: 0x06036922 RID: 223522 RVA: 0x00DCB758 File Offset: 0x00DC9958
		protected void CheckFinish()
		{
			if (this.HasFinished)
			{
				return;
			}
			if (!this.IsSequenceQteFinished())
			{
				return;
			}
			this.HasFinished = true;
			this.QteManager.OnSequenceQteFinished(this.Context.QteId);
		}

		// Token: 0x06036923 RID: 223523 RVA: 0x00DCB790 File Offset: 0x00DC9990
		protected bool IsSequenceQteFinished()
		{
			return this.IsForceStop || (this.ResultSpineCheckList.Count == 0 && this.CheckProgressFinish() && !this.MarkSequenceQtePending && !this.Context.IsPending());
		}

		// Token: 0x06036924 RID: 223524 RVA: 0x00DCB7E0 File Offset: 0x00DC99E0
		protected bool CheckProgressFinish()
		{
			return Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.CacheProgress, (double)this.Progress, null);
		}

		// Token: 0x0401F6E9 RID: 128745
		[Nullable(1)]
		private const string EVENT_SUCCESS = "plot_seq_qte_success";

		// Token: 0x0401F6EA RID: 128746
		[Nullable(1)]
		private const string EVENT_FAIL = "plot_seq_qte_timeout";

		// Token: 0x0401F6EB RID: 128747
		public const float PERCENT = 0.01f;

		// Token: 0x0401F6EC RID: 128748
		private const float BLEND_OUT_TIME = 0.5f;

		// Token: 0x0401F6ED RID: 128749
		[Nullable(1)]
		protected readonly SequenceQteManager QteManager;

		// Token: 0x0401F6EE RID: 128750
		[Nullable(1)]
		protected readonly T Context;

		// Token: 0x0401F6F5 RID: 128757
		protected bool MarkSequenceQtePending;

		// Token: 0x0401F6F6 RID: 128758
		protected bool IsForceStop;

		// Token: 0x0401F6F7 RID: 128759
		protected float UpdateInterval;

		// Token: 0x0401F6F8 RID: 128760
		protected float Progress;

		// Token: 0x0401F6F9 RID: 128761
		protected float CacheProgress;

		// Token: 0x0401F6FA RID: 128762
		protected float LastProgress;

		// Token: 0x0401F6FB RID: 128763
		protected float ProgressLerpSpeed = -1f;

		// Token: 0x0401F6FC RID: 128764
		protected float TickInterval;

		// Token: 0x0401F6FD RID: 128765
		protected float TickCheckTime;

		// Token: 0x0401F6FE RID: 128766
		protected bool HasFinished;

		// Token: 0x0401F6FF RID: 128767
		protected bool HasCommonQteFinished;

		// Token: 0x0401F700 RID: 128768
		protected bool NeedTick;

		// Token: 0x0401F701 RID: 128769
		protected int SectionLength;

		// Token: 0x0401F703 RID: 128771
		protected float CacheSpineProgress;

		// Token: 0x0401F704 RID: 128772
		protected PlotSubtitleView View;

		// Token: 0x0401F705 RID: 128773
		protected bool HasPlayProgressSpine;

		// Token: 0x0401F706 RID: 128774
		protected bool HasPlayStartSpine;

		// Token: 0x0401F707 RID: 128775
		[Nullable(1)]
		private readonly HashSet<string> ActiveProgressSpineNames = new HashSet<string>();

		// Token: 0x0401F708 RID: 128776
		[Nullable(1)]
		private readonly Dictionary<string, QteProgressSpineSegmentProxy> ActiveProgressSpineSegments = new Dictionary<string, QteProgressSpineSegmentProxy>();

		// Token: 0x0401F709 RID: 128777
		[Nullable(1)]
		protected readonly HashSet<string> ResultSpineCheckList = new HashSet<string>();
	}
}
