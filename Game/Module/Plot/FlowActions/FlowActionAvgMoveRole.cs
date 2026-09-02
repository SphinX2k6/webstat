using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Avg;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200540B RID: 21515
	public class FlowActionAvgMoveRole : FlowActionBase
	{
		// Token: 0x06036EF9 RID: 225017 RVA: 0x00DF1B20 File Offset: 0x00DEFD20
		protected override void OnExecute()
		{
			AvgMoveRole avgMoveRole = this.ActionInfo.Params as AvgMoveRole;
			AvgTalkerMoveActionContext context = new AvgTalkerMoveActionContext
			{
				CharacterId = avgMoveRole.RoleId,
				AnimationType = avgMoveRole.AnimationType,
				TargetPosition = avgMoveRole.TargetPosition,
				EaseCurve = avgMoveRole.EaseCurve
			};
			if (this.ActionInfo.Async.GetValueOrDefault())
			{
				ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterMoveAsync(context).Forget();
				base.FinishExecute(true, true);
				return;
			}
			ModelBase<PlotModel>.Instance.PlotAvg.AvgCharacterMoveAsync(context).ContinueWith(delegate()
			{
				base.FinishExecute(true, true);
			}).Forget();
		}
	}
}
