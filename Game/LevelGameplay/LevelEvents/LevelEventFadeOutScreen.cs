using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA1 RID: 27553
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventFadeOutScreen : LevelEventBase
	{
		// Token: 0x06043FB2 RID: 278450 RVA: 0x0119DA2C File Offset: 0x0119BC2C
		public LevelEventFadeOutScreen(int id) : base(id)
		{
		}

		// Token: 0x06043FB3 RID: 278451 RVA: 0x0119DA38 File Offset: 0x0119BC38
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			FadeOutScreen fadeOutScreen = inParams as FadeOutScreen;
			ModelBase<PlotModel>.Instance.IsFadeIn = false;
			if (ModelBase<PlotModel>.Instance.BlackScreenType.GetValueOrDefault() == EBlackScreenType.Plot && ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, false, new Action(this.OnFadeComplete));
				return;
			}
			Global.CharacterCameraManager.FadeAmount = 0f;
			LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
			ELoadingReason reason = ELoadingReason.Common;
			string context2 = null;
			Action callback = delegate()
			{
				base.FinishExecute(true, false, true);
				ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
				ModelBase<PlotModel>.Instance.LastPlotAspect = -1f;
				ModelBase<PlotModel>.Instance.LastPlotColor = -1;
			};
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
			instance.CloseLoading(reason, context2, callback, duration);
		}

		// Token: 0x06043FB4 RID: 278452 RVA: 0x0119DAF6 File Offset: 0x0119BCF6
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, null, delegate
			{
				base.FinishExecute(true, false, true);
				ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
			}, new float?(0f));
		}

		// Token: 0x06043FB5 RID: 278453 RVA: 0x0119DB1A File Offset: 0x0119BD1A
		private void OnFadeComplete()
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FB6 RID: 278454 RVA: 0x0119DB28 File Offset: 0x0119BD28
		protected override void OnUpdateGuarantee()
		{
			GuaranteeActionInfo p = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.ActionBlackScreenFadeOut
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p, null);
		}
	}
}
