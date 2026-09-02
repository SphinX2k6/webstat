using System;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB4 RID: 28596
	public class LevelFlowWaitLoadingDone : LevelFlowActionBase
	{
		// Token: 0x06045252 RID: 283218 RVA: 0x0120B1B4 File Offset: 0x012093B4
		protected override void OnExecute()
		{
			if (!ModelBase<LoadingModel>.Instance.IsLoading)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x06045253 RID: 283219 RVA: 0x0120B1C9 File Offset: 0x012093C9
		protected override void OnTick(float delta)
		{
			if (!ModelBase<LoadingModel>.Instance.IsLoading)
			{
				base.FinishExecute(true);
			}
		}
	}
}
