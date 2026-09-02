using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Assistant
{
	// Token: 0x020053A9 RID: 21417
	[NullableContext(1)]
	[Nullable(0)]
	public class QteManger
	{
		// Token: 0x060369FA RID: 223738 RVA: 0x00DD559C File Offset: 0x00DD379C
		public void HandlePlotQte(ITalkItem subtitle)
		{
			if (this.CurrentQte.Count > 0)
			{
				foreach (int qteHandle in this.CurrentQte.Keys)
				{
					ControllerBase<CommonQteController>.Instance.StopQte(qteHandle);
				}
				this.CurrentQte.Clear();
			}
			int num = ControllerBase<FlowController>.Instance.FlowSequence.OnQteStart(subtitle.Id);
			if (ModelBase<SequenceModel>.Instance.IsMuteAllQte || ModelBase<SequenceModel>.Instance.MuteQteList.Contains(num))
			{
				ControllerBase<FlowController>.Instance.FlowSequence.OnQteExecute(subtitle.Id, true);
				return;
			}
			CommonQteContextBase commonQteContextBase = ControllerBase<CommonQteController>.Instance.StartQte(num, new TCommonQteCallback(this.OnQteSuccess), new TCommonQteCallback(this.OnQteFail), EQteSource.Plot, null);
			if (commonQteContextBase == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[FlowSequence][PlotQte] Sequence Qte 失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QteId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			SCommonQte config = commonQteContextBase.Config;
			float playRate = (config != null) ? config.BaseConfig.TimeDilation : 1f;
			ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
			if (curLevelSeqActor != null)
			{
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.SetPlayRate(playRate);
				}
			}
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			ControllerBase<PlotController>.Instance.PlotViewManager.EnableInteractPlot(false, new bool?(true), "PlotQte", null);
			this.CurrentQte[commonQteContextBase.HandleId] = subtitle.Id;
		}

		// Token: 0x060369FB RID: 223739 RVA: 0x00DD5730 File Offset: 0x00DD3930
		public void HandlePlotQteEnd(int talkId)
		{
			ControllerBase<FlowController>.Instance.FlowSequence.OnQteEnd(talkId);
		}

		// Token: 0x060369FC RID: 223740 RVA: 0x00DD5744 File Offset: 0x00DD3944
		public void StopQte()
		{
			foreach (int qteHandle in this.CurrentQte.Keys)
			{
				ControllerBase<CommonQteController>.Instance.StopQte(qteHandle);
			}
			this.CurrentQte.Clear();
		}

		// Token: 0x060369FD RID: 223741 RVA: 0x00DD57AC File Offset: 0x00DD39AC
		[NullableContext(2)]
		private void OnQteSuccess(CommonQteContextBase context)
		{
			ControllerBase<FlowController>.Instance.FlowSequence.OnQteExecute(this.CurrentQte[context.HandleId], true);
			Singleton<AudioSystem>.Instance.PostEvent("plot_seq_qte_success");
			this.OnQteFinish(context);
		}

		// Token: 0x060369FE RID: 223742 RVA: 0x00DD57E6 File Offset: 0x00DD39E6
		[NullableContext(2)]
		private void OnQteFail(CommonQteContextBase context)
		{
			ControllerBase<FlowController>.Instance.FlowSequence.OnQteExecute(this.CurrentQte.GetValueOrDefault(context.HandleId, 0), false);
			Singleton<AudioSystem>.Instance.PostEvent("plot_seq_qte_timeout");
			this.OnQteFinish(context);
		}

		// Token: 0x060369FF RID: 223743 RVA: 0x00DD5824 File Offset: 0x00DD3A24
		private void OnQteFinish(CommonQteContextBase context)
		{
			ALevelSequenceActor curLevelSeqActor = ModelBase<SequenceModel>.Instance.CurLevelSeqActor;
			if (curLevelSeqActor != null)
			{
				ULevelSequencePlayer sequencePlayer = curLevelSeqActor.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.SetPlayRate(1f);
				}
			}
			Singleton<AudioSystem>.Instance.SetRtpcValue("plot_seq_qte_time_scale", 1f, null);
			ControllerBase<FlowController>.Instance.EnableSkip(true);
			ControllerBase<PlotController>.Instance.PlotViewManager.EnableInteractPlot(true, new bool?(true), "PlotQte", null);
			this.CurrentQte.Remove(context.HandleId);
		}

		// Token: 0x0401F757 RID: 128855
		private const string EnableInteractReason = "PlotQte";

		// Token: 0x0401F758 RID: 128856
		private const string EVENT_SUCCESS = "plot_seq_qte_success";

		// Token: 0x0401F759 RID: 128857
		private const string EVENT_FAIL = "plot_seq_qte_timeout";

		// Token: 0x0401F75A RID: 128858
		private readonly Dictionary<int, int> CurrentQte = new Dictionary<int, int>();
	}
}
