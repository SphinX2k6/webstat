using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F94 RID: 28564
	public class LevelFlowFadeInScreen : LevelFlowActionBase
	{
		// Token: 0x060451BA RID: 283066 RVA: 0x01206E59 File Offset: 0x01205059
		[NullableContext(1)]
		public LevelFlowFadeInScreen Init(FadeInScreen inParams)
		{
			this.InParams = inParams;
			return this;
		}

		// Token: 0x060451BB RID: 283067 RVA: 0x01206E64 File Offset: 0x01205064
		protected override void OnExecute()
		{
			if (this.InParams == null)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.IsFadeIn = true;
			CameraModel instance = ModelBase<CameraModel>.Instance;
			if (instance != null)
			{
				FightCamera fightCamera = instance.MainModel.FightCamera;
				if (fightCamera != null)
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					if (logicComponent != null)
					{
						logicComponent.ExitCameraHook(false);
					}
				}
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && this.InParams.TypeOverride != null)
			{
				ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Plot);
			}
			else
			{
				ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Ui);
			}
			EBlackScreenType? blackScreenType = ModelBase<PlotModel>.Instance.BlackScreenType;
			EBlackScreenType eblackScreenType = EBlackScreenType.Ui;
			if (blackScreenType.GetValueOrDefault() == eblackScreenType & blackScreenType != null)
			{
				EFadeInScreenShowType? screenType = this.InParams.ScreenType;
				if (screenType != null)
				{
					EFadeInScreenShowType valueOrDefault = screenType.GetValueOrDefault();
					if (valueOrDefault != EFadeInScreenShowType.White)
					{
						if (valueOrDefault == EFadeInScreenShowType.Black)
						{
							ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectBlack);
						}
					}
					else
					{
						ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectWhite);
					}
				}
				LevelLoadingController instance2 = ControllerBase<LevelLoadingController>.Instance;
				ELoadingReason reason = ELoadingReason.Common;
				ELoadingPerform perform = ELoadingPerform.CameraFade;
				string context = "LevelFlowFadeInScreen";
				Action callback = delegate()
				{
					base.FinishExecute(true);
				};
				object[] array = new object[4];
				int num = 0;
				IEaseData ease = this.InParams.Ease;
				array[num] = ((ease != null) ? new float?(ease.Duration) : null);
				array[1] = this.InParams.ScreenType;
				array[2] = true;
				array[3] = true;
				instance2.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, true, new Action(this.OnFadeComplete));
		}

		// Token: 0x060451BC RID: 283068 RVA: 0x01207001 File Offset: 0x01205201
		private void OnFadeComplete()
		{
			base.FinishExecute(true);
		}

		// Token: 0x040268F6 RID: 157942
		[Nullable(2)]
		private FadeInScreen InParams;
	}
}
