using System;
using System.Collections.Generic;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200543D RID: 21565
	public class FlowActionShowTalk : FlowActionBase
	{
		// Token: 0x06036FC4 RID: 225220 RVA: 0x00DF5438 File Offset: 0x00DF3638
		protected override void OnExecute()
		{
			this.Context.CurShowTalk = (this.ActionInfo.Params as ShowTalk);
			this.Context.CurShowTalkActionId = this.ActionInfo.ActionId.GetValueOrDefault();
			this.Context.OptionsHistory[this.Context.CurShowTalkActionId] = new Dictionary<int, int>();
			this.Context.OptionsCollection.Add(new ValueTuple<int, List<ValueTuple<int, int>>>(this.Context.CurShowTalkActionId, new List<ValueTuple<int, int>>
			{
				Capacity = 0
			}));
			switch (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault())
			{
			case EPlotLevel.LevelA:
			case EPlotLevel.LevelB:
			case EPlotLevel.ControlEntity:
				this.OnExecuteSequenceTalk();
				return;
			case EPlotLevel.LevelC:
				this.OnExecuteNormalTalk();
				return;
			case EPlotLevel.LevelD:
			case EPlotLevel.LevelE:
				if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight && ModelBase<PlotModel>.Instance.PlotConfig.SkipTalkWhenFighting)
				{
					base.FinishExecute(true, true);
					return;
				}
				this.OnExecuteNormalTalk();
				break;
			case EPlotLevel.Prompt:
				break;
			default:
				return;
			}
		}

		// Token: 0x06036FC5 RID: 225221 RVA: 0x00DF553C File Offset: 0x00DF373C
		private void OnExecuteNormalTalk()
		{
			ShowTalk inShowTalk = this.ActionInfo.Params as ShowTalk;
			FlowContext context = this.Context;
			FlowActionRunner runner = this.Runner;
			base.FinishExecute(true, false);
			runner.FlowShowTalk.Start(inShowTalk, context);
		}

		// Token: 0x06036FC6 RID: 225222 RVA: 0x00DF557C File Offset: 0x00DF377C
		private void OnExecuteSequenceTalk()
		{
			ShowTalk showTalk = this.ActionInfo.Params as ShowTalk;
			if (showTalk == null || showTalk.SequenceDataAsset == null)
			{
				base.FinishExecute(true, true);
				return;
			}
			FlowActionRunner runner = this.Runner;
			FlowContext context = this.Context;
			bool seamlessPlot = this.Context.SeamlessPlot;
			base.FinishExecute(true, false);
			runner.FlowSequence.Init(showTalk, context);
			runner.FlowSequence.Start(seamlessPlot);
		}

		// Token: 0x06036FC7 RID: 225223 RVA: 0x00DF55E7 File Offset: 0x00DF37E7
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
