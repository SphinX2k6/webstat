using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA0 RID: 27552
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventFadeInScreen : LevelEventBase
	{
		// Token: 0x06043FAB RID: 278443 RVA: 0x0119D738 File Offset: 0x0119B938
		public LevelEventFadeInScreen(int id) : base(id)
		{
		}

		// Token: 0x06043FAC RID: 278444 RVA: 0x0119D744 File Offset: 0x0119B944
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			int? num = null;
			FadeInScreen fadeInScreen = inParams as FadeInScreen;
			if (fadeInScreen.KeepFadeAfterTreeEnd.GetValueOrDefault())
			{
				this.KeepFadeAfterTreeEnd = fadeInScreen.KeepFadeAfterTreeEnd.Value;
			}
			if (!this.KeepFadeAfterTreeEnd && context != null && context.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext != null && generalLogicTreeContext.BtType == BtType.LevelPlay)
				{
					num = new int?(generalLogicTreeContext.TreeConfigId);
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.BlackScreen;
					ELogAuthor author = ELogAuthor.JYS;
					string message = "玩法内开启黑幕：";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", generalLogicTreeContext.TreeConfigId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			ModelBase<PlotModel>.Instance.IsFadeIn = true;
			CameraModel instance2 = ModelBase<CameraModel>.Instance;
			if (instance2 != null)
			{
				FightCamera fightCamera = instance2.MainModel.FightCamera;
				if (fightCamera != null)
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					if (logicComponent != null)
					{
						logicComponent.ExitCameraHook(false);
					}
				}
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelC && fadeInScreen.TypeOverride != null)
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
				EFadeInScreenShowType? screenType = fadeInScreen.ScreenType;
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
				LevelLoadingController instance3 = ControllerBase<LevelLoadingController>.Instance;
				ELoadingReason reason = ELoadingReason.Common;
				ELoadingPerform perform = ELoadingPerform.CameraFade;
				string context2 = null;
				Action callback = delegate()
				{
					base.FinishExecute(true, false, true);
				};
				object[] array = new object[5];
				int num2 = 0;
				float? num3;
				if (fadeInScreen == null)
				{
					num3 = null;
				}
				else
				{
					IEaseData ease = fadeInScreen.Ease;
					num3 = ((ease != null) ? new float?(ease.Duration) : null);
				}
				array[num2] = num3;
				array[1] = fadeInScreen.ScreenType;
				array[2] = true;
				array[3] = true;
				array[4] = num;
				instance3.OpenLoading<ELoadingPerform>(reason, perform, context2, callback, array);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, true, new Action(this.OnFadeComplete));
		}

		// Token: 0x06043FAD RID: 278445 RVA: 0x0119D986 File Offset: 0x0119BB86
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FAE RID: 278446 RVA: 0x0119D991 File Offset: 0x0119BB91
		private void OnFadeComplete()
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043FAF RID: 278447 RVA: 0x0119D99C File Offset: 0x0119BB9C
		protected override void OnUpdateGuarantee()
		{
			if (!this.KeepFadeAfterTreeEnd)
			{
				GuaranteeActionInfo p = new GuaranteeActionInfo
				{
					Name = EGuaranteeAction.ActionBlackScreenFadeOut
				};
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, this.Type, this.BaseContext, p, null);
				return;
			}
			GuaranteeActionInfo p2 = new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.ActionBlackScreenFadeOut
			};
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, this.Type, this.BaseContext, p2, null);
		}

		// Token: 0x06043FB0 RID: 278448 RVA: 0x0119DA18 File Offset: 0x0119BC18
		protected override void OnReset()
		{
			this.KeepFadeAfterTreeEnd = false;
		}

		// Token: 0x0402601E RID: 155678
		private bool KeepFadeAfterTreeEnd;
	}
}
