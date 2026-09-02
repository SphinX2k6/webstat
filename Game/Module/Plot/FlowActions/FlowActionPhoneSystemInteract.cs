using System;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542B RID: 21547
	public class FlowActionPhoneSystemInteract : FlowActionLevelAsyncAction
	{
		// Token: 0x06036F6C RID: 225132 RVA: 0x00DF39E0 File Offset: 0x00DF1BE0
		protected override void OnExecute()
		{
			EPlotLevel? plotLevel = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			EPlotLevel? eplotLevel = plotLevel;
			EPlotLevel eplotLevel2 = EPlotLevel.LevelA;
			if (!(eplotLevel.GetValueOrDefault() == eplotLevel2 & eplotLevel != null) && plotLevel.GetValueOrDefault() != EPlotLevel.LevelB && plotLevel.GetValueOrDefault() != EPlotLevel.LevelC)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "PhoneSystemInteract只允许在剧情A/B/C级别中执行";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotLevel", plotLevel);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, true);
				return;
			}
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ControllerBase<FlowController>.Instance.EnableSkip(false);
			}
			base.OnExecute();
		}

		// Token: 0x06036F6D RID: 225133 RVA: 0x00DF3A7B File Offset: 0x00DF1C7B
		protected override void OnBackgroundExecute()
		{
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F6E RID: 225134 RVA: 0x00DF3A85 File Offset: 0x00DF1C85
		protected override void OnActionFinish(bool result)
		{
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ControllerBase<FlowController>.Instance.EnableSkip(true);
			}
			base.FinishExecute(true, true);
		}
	}
}
