using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot.Flow;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200541D RID: 21533
	public class FlowActionFadeInScreen : FlowActionBase
	{
		// Token: 0x06036F3B RID: 225083 RVA: 0x00DF2F74 File Offset: 0x00DF1174
		protected override void OnExecute()
		{
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			FadeInScreen fadeInScreen = this.ActionInfo.Params as FadeInScreen;
			ModelBase<PlotModel>.Instance.IsFadeIn = true;
			ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Plot);
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && fadeInScreen != null && fadeInScreen.TypeOverride != null)
			{
				ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Plot);
			}
			else
			{
				ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Ui);
			}
			if (fadeInScreen != null && fadeInScreen.FadeBackground != null)
			{
				SpecialTransitionController instance = ControllerBase<SpecialTransitionController>.Instance;
				IFadeBackgroundType fadeBackground = fadeInScreen.FadeBackground;
				IEaseData ease = fadeInScreen.Ease;
				instance.OpenSpecialTransitionLoadingByFadeScreen(fadeBackground, (ease != null) ? new float?(ease.Duration) : null, new Action(this.OnFadeComplete)).Forget();
			}
			else
			{
				EBlackScreenType? blackScreenType = ModelBase<PlotModel>.Instance.BlackScreenType;
				EBlackScreenType eblackScreenType = EBlackScreenType.Ui;
				if (blackScreenType.GetValueOrDefault() == eblackScreenType & blackScreenType != null)
				{
					LevelLoadingController instance2 = ControllerBase<LevelLoadingController>.Instance;
					ELoadingReason reason = ELoadingReason.Common;
					ELoadingPerform perform = ELoadingPerform.CameraFade;
					string context = "FlowActionFadeInScreen";
					Action callback = new Action(this.OnFadeComplete);
					object[] array = new object[2];
					int num = 0;
					float? num2;
					if (fadeInScreen == null)
					{
						num2 = null;
					}
					else
					{
						IEaseData ease2 = fadeInScreen.Ease;
						num2 = ((ease2 != null) ? new float?(ease2.Duration) : null);
					}
					array[num] = num2;
					array[1] = (((fadeInScreen != null) ? fadeInScreen.ScreenType : null) ?? ControllerBase<LevelLoadingController>.Instance.CameraFade.ColorSearch());
					instance2.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
				}
				else
				{
					ControllerBase<PlotController>.Instance.PlotViewManager.PlotViewBgFadeBlackScreen(true, new Action(this.OnFadeComplete));
				}
			}
			base.RecordAction(null);
		}

		// Token: 0x06036F3C RID: 225084 RVA: 0x00DF3137 File Offset: 0x00DF1337
		protected override void OnBackgroundExecute()
		{
			ModelBase<PlotModel>.Instance.IsFadeIn = true;
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F3D RID: 225085 RVA: 0x00DF314C File Offset: 0x00DF134C
		private void OnFadeComplete()
		{
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F3E RID: 225086 RVA: 0x00DF3158 File Offset: 0x00DF1358
		[NullableContext(1)]
		protected override void OnRollback(ActionRecord actionInfo, FlowContext context)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "FlowActionFadeInScreen_Rollback", null, null);
		}
	}
}
