using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200541E RID: 21534
	public class FlowActionFadeOutScreen : FlowActionBase
	{
		// Token: 0x06036F40 RID: 225088 RVA: 0x00DF3188 File Offset: 0x00DF1388
		protected override void OnExecute()
		{
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			FadeOutScreen fadeOutScreen = this.ActionInfo.Params as FadeOutScreen;
			ModelBase<PlotModel>.Instance.IsFadeIn = false;
			ModelBase<PlotModel>.Instance.LastPlotAspect = -1f;
			if (ModelBase<PlotModel>.Instance.BlackScreenType.GetValueOrDefault() == EBlackScreenType.Plot && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				ControllerBase<PlotController>.Instance.PlotViewManager.PlotViewBgFadeBlackScreen(false, new Action(this.OnFadeComplete));
				return;
			}
			Global.CharacterCameraManager.FadeAmount = 0f;
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.Common;
			string context = "FlowActionFadeOutScreen";
			Action callback = new Action(this.OnFadeComplete);
			float? duration;
			if (fadeOutScreen == null)
			{
				duration = null;
			}
			else
			{
				IEaseData ease = fadeOutScreen.Ease;
				duration = ((ease != null) ? new float?(ease.Duration) : null);
			}
			instance.CloseLoading(reason, context, callback, duration);
		}

		// Token: 0x06036F41 RID: 225089 RVA: 0x00DF3269 File Offset: 0x00DF1469
		protected override void OnBackgroundExecute()
		{
			ModelBase<PlotModel>.Instance.IsFadeIn = false;
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F42 RID: 225090 RVA: 0x00DF327E File Offset: 0x00DF147E
		private void OnFadeComplete()
		{
			base.FinishExecute(true, true);
		}
	}
}
