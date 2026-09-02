using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F95 RID: 28565
	public class LevelFlowFadeOutScreen : LevelFlowActionBase
	{
		// Token: 0x060451BF RID: 283071 RVA: 0x0120701B File Offset: 0x0120521B
		[NullableContext(1)]
		public LevelFlowFadeOutScreen Init(FadeOutScreen inParams)
		{
			this.InParams = inParams;
			return this;
		}

		// Token: 0x060451C0 RID: 283072 RVA: 0x01207028 File Offset: 0x01205228
		protected override void OnExecute()
		{
			if (this.InParams == null)
			{
				base.FinishExecute(false);
				return;
			}
			FadeOutScreen inParams = this.InParams;
			ModelBase<PlotModel>.Instance.IsFadeIn = false;
			if (ModelBase<PlotModel>.Instance.BlackScreenType.GetValueOrDefault() == EBlackScreenType.Plot && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, false, new Action(this.OnFadeComplete));
				return;
			}
			Global.CharacterCameraManager.FadeAmount = 0f;
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.Common;
			string context = "LevelFlowFadeOutScreen";
			Action callback = delegate()
			{
				base.FinishExecute(true);
				ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
				ModelBase<PlotModel>.Instance.LastPlotAspect = -1f;
				ModelBase<PlotModel>.Instance.LastPlotColor = -1;
			};
			IEaseData ease = inParams.Ease;
			instance.CloseLoading(reason, context, callback, (ease != null) ? new float?(ease.Duration) : null);
		}

		// Token: 0x060451C1 RID: 283073 RVA: 0x012070E8 File Offset: 0x012052E8
		private void OnFadeComplete()
		{
			base.FinishExecute(true);
		}

		// Token: 0x040268F7 RID: 157943
		[Nullable(2)]
		private FadeOutScreen InParams;
	}
}
