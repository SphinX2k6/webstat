using System;
using System.Collections.Generic;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Sequence.Manager;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542D RID: 21549
	public class FlowActionPlaySequenceData : FlowActionBase
	{
		// Token: 0x06036F74 RID: 225140 RVA: 0x00DF3BC4 File Offset: 0x00DF1DC4
		protected override void OnExecute()
		{
			PlaySequenceData playSequenceData = this.ActionInfo.Params as PlaySequenceData;
			if (playSequenceData == null || StringUtils.IsEmpty(playSequenceData.Path))
			{
				ControllerBase<FlowController>.Instance.LogError("SequenceData路径为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, true);
				return;
			}
			EPlotLevel? plotLevel = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			EPlotLevel? eplotLevel = plotLevel;
			EPlotLevel eplotLevel2 = EPlotLevel.LevelA;
			if ((eplotLevel.GetValueOrDefault() == eplotLevel2 & eplotLevel != null) || plotLevel.GetValueOrDefault() == EPlotLevel.ControlEntity)
			{
				ModelBase<SequenceModel>.Instance.Type = new EPlotSequenceType?(EPlotSequenceType.过场);
			}
			else if (plotLevel.GetValueOrDefault() == EPlotLevel.LevelB)
			{
				ModelBase<SequenceModel>.Instance.Type = new EPlotSequenceType?(EPlotSequenceType.站桩);
			}
			if (!this.Context.IsBackground)
			{
				Singleton<EventSystem>.Instance.Once<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
				ControllerBase<SequenceController>.Instance.Play(playSequenceData, new List<string>(), new Action<bool>(this.OnSequenceFinish), plotLevel.GetValueOrDefault() != EPlotLevel.ControlEntity, true, this.Context.IsWaitRenderData, 1f, false, plotLevel.GetValueOrDefault() == EPlotLevel.ControlEntity);
				return;
			}
			ControllerBase<SequenceController>.Instance.LoadData(playSequenceData, delegate
			{
				this.SkipPromise().ContinueWith(delegate()
				{
					base.FinishExecute(true, true);
				}).Forget();
			});
		}

		// Token: 0x06036F75 RID: 225141 RVA: 0x00DF3CF9 File Offset: 0x00DF1EF9
		private void OnSequenceStart(float _)
		{
			ControllerBase<FlowController>.Instance.EnableSkip(true);
		}

		// Token: 0x06036F76 RID: 225142 RVA: 0x00DF3D08 File Offset: 0x00DF1F08
		private void OnSequenceFinish(bool state)
		{
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			if (Singleton<EventSystem>.Instance.Has<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart)))
			{
				Singleton<EventSystem>.Instance.Remove<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
			}
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F77 RID: 225143 RVA: 0x00DF3D64 File Offset: 0x00DF1F64
		protected override void OnInterruptExecute()
		{
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			if (Singleton<EventSystem>.Instance.Has<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart)))
			{
				Singleton<EventSystem>.Instance.Remove<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnSequenceStart));
			}
			this.SkipPromise().ContinueWith(delegate()
			{
				base.FinishExecute(true, true);
			}).Forget();
		}

		// Token: 0x06036F78 RID: 225144 RVA: 0x00DF3DD1 File Offset: 0x00DF1FD1
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}

		// Token: 0x06036F79 RID: 225145 RVA: 0x00DF3DDC File Offset: 0x00DF1FDC
		private UniTask SkipPromise()
		{
			FlowActionPlaySequenceData.<SkipPromise>d__5 <SkipPromise>d__;
			<SkipPromise>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SkipPromise>d__.<>4__this = this;
			<SkipPromise>d__.<>1__state = -1;
			<SkipPromise>d__.<>t__builder.Start<FlowActionPlaySequenceData.<SkipPromise>d__5>(ref <SkipPromise>d__);
			return <SkipPromise>d__.<>t__builder.Task;
		}
	}
}
