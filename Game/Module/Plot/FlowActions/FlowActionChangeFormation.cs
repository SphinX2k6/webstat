using System;
using CSharpScript.Game.Module.Plot.Sequence;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005416 RID: 21526
	public class FlowActionChangeFormation : FlowActionServerAction
	{
		// Token: 0x06036F26 RID: 225062 RVA: 0x00DF28EC File Offset: 0x00DF0AEC
		protected override void OnExecute()
		{
			if (!ModelBase<PlotModel>.Instance.IsInSequencePlot() || !ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.FZX, "禁止在非Seq剧情中使用切编队", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, true);
				return;
			}
			ControllerBase<PlotController>.Instance.ChangeFormation();
			base.RequestServerAction(false, null);
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F27 RID: 225063 RVA: 0x00DF2950 File Offset: 0x00DF0B50
		protected override void OnBackgroundExecute()
		{
			base.FinishExecute(true, true);
		}
	}
}
