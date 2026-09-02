using System;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542A RID: 21546
	public class FlowActionOpenSystemBoard : FlowActionLevelAsyncAction
	{
		// Token: 0x06036F68 RID: 225128 RVA: 0x00DF398D File Offset: 0x00DF1B8D
		protected override void OnExecute()
		{
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				ControllerBase<FlowController>.Instance.EnableSkip(false);
			}
			base.OnExecute();
		}

		// Token: 0x06036F69 RID: 225129 RVA: 0x00DF39AC File Offset: 0x00DF1BAC
		protected override void OnBackgroundExecute()
		{
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F6A RID: 225130 RVA: 0x00DF39B6 File Offset: 0x00DF1BB6
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
