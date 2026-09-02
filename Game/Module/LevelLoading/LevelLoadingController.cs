using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A16 RID: 23062
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class LevelLoadingController : ControllerBase<LevelLoadingController>
	{
		// Token: 0x170094CA RID: 38090
		// (get) Token: 0x0603A637 RID: 239159 RVA: 0x00ECDEF1 File Offset: 0x00ECC0F1
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0603A638 RID: 239160 RVA: 0x00ECDEF4 File Offset: 0x00ECC0F4
		protected override bool OnInit()
		{
			this.CameraFade = new CameraFadeLoading();
			this.ProcessList = new List<object>();
			Singleton<Net>.Instance.Register<ActionOperationScreenNotify>(ENotifyMessageId.ActionOperationScreenNotify, new Action<ActionOperationScreenNotify, Net.CallbackStatus>(this.OnOperationScreenNotify));
			return true;
		}

		// Token: 0x0603A639 RID: 239161 RVA: 0x00ECDF29 File Offset: 0x00ECC129
		protected override bool OnClear()
		{
			this.CameraFade = null;
			this.ProcessList = null;
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActionOperationScreenNotify);
			return true;
		}

		// Token: 0x0603A63A RID: 239162 RVA: 0x00ECDF4C File Offset: 0x00ECC14C
		protected override void OnTick(float delta)
		{
			if (this.ProcessList == null || this.ProcessList.Count == 0)
			{
				return;
			}
			if (this.CurProcess != null)
			{
				return;
			}
			this.CurProcess = this.ProcessList[0];
			object curProcess = this.CurProcess;
			OpenLoadingProcess<ELoadingPerform> openProcess = curProcess as OpenLoadingProcess<ELoadingPerform>;
			if (openProcess != null)
			{
				this.OpenLoadingImp(openProcess.Reason, openProcess.Perform, openProcess.Context, openProcess.Params).ContinueWith(delegate(bool _)
				{
					Action callback = openProcess.Callback;
					if (callback == null)
					{
						return;
					}
					callback();
				});
				return;
			}
			curProcess = this.CurProcess;
			CloseLoadingProcess closeProcess = curProcess as CloseLoadingProcess;
			if (closeProcess != null)
			{
				this.CloseLoadingImp(closeProcess.Reason, closeProcess.Duration, closeProcess.Context).ContinueWith(delegate()
				{
					Action callback = closeProcess.Callback;
					if (callback == null)
					{
						return;
					}
					callback();
				});
			}
		}

		// Token: 0x0603A63B RID: 239163 RVA: 0x00ECE04A File Offset: 0x00ECC24A
		private void FinishCallback()
		{
			this.ProcessList.RemoveAt(0);
			this.CurProcess = null;
		}

		// Token: 0x0603A63C RID: 239164 RVA: 0x00ECE060 File Offset: 0x00ECC260
		[NullableContext(1)]
		private unsafe void OnOperationScreenNotify(ActionOperationScreenNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			LevelLoadingController.<>c__DisplayClass10_0 CS$<>8__locals1 = new LevelLoadingController.<>c__DisplayClass10_0();
			CS$<>8__locals1.playerId = message.PlayerId;
			CS$<>8__locals1.incId = message.IncId;
			CS$<>8__locals1.type = message.Type;
			string @params = message.Params;
			GeneralContext generalContext = LevelGeneralContextUtil.CreateByServerContext(message.GameCtx);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.JYS;
			string message2 = "[黑幕]ActionOperationScreenNotify 服务端下发黑幕操作";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("playerId:", CS$<>8__locals1.playerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("incId:", CS$<>8__locals1.incId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("type:", CS$<>8__locals1.type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("inParam:", @params);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0();
				return;
			}
			ActionScreenOperationType type = CS$<>8__locals1.type;
			if (type != ActionScreenOperationType.Close)
			{
				if (type != ActionScreenOperationType.Open)
				{
					return;
				}
				FadeInScreen fadeInScreen = Json.Parse<FadeInScreen>(@params, null);
				ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectBlack);
				ModelBase<PlotModel>.Instance.IsFadeIn = true;
				if (fadeInScreen == null)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.BlackScreen, ELogAuthor.JYS, "[黑幕]Params 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, null, new Action(CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0), new object[]
					{
						1f,
						EFadeInScreenShowType.Black,
						true,
						true
					});
					return;
				}
				int? num = null;
				bool flag = !(fadeInScreen.KeepFadeAfterTreeEnd ?? false);
				if (flag)
				{
					GeneralLogicTreeContext generalLogicTreeContext = generalContext as GeneralLogicTreeContext;
					if (generalLogicTreeContext != null && generalLogicTreeContext.BtType == BtType.LevelPlay)
					{
						num = new int?(generalLogicTreeContext.TreeConfigId);
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.BlackScreen;
						ELogAuthor author2 = ELogAuthor.JYS;
						string message3 = "玩法内开启黑幕：";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("treeId", generalLogicTreeContext.TreeConfigId);
						instance2.Info(module2, author2, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
				CameraModel instance3 = ModelBase<CameraModel>.Instance;
				if (instance3 != null)
				{
					FightCamera fightCamera = instance3.MainModel.FightCamera;
					if (fightCamera != null)
					{
						FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
						if (logicComponent != null)
						{
							logicComponent.ExitCameraHook(false);
						}
					}
				}
				if (fadeInScreen.TypeOverride != null)
				{
					EFadeUiOverride? typeOverride = fadeInScreen.TypeOverride;
					EFadeUiOverride efadeUiOverride = EFadeUiOverride.ShowTalkDialog;
					if (!(typeOverride.GetValueOrDefault() == efadeUiOverride & typeOverride != null))
					{
						ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Plot);
						Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, true, new Action(CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0));
						goto IL_4C3;
					}
				}
				ModelBase<PlotModel>.Instance.BlackScreenType = new EBlackScreenType?(EBlackScreenType.Ui);
				EFadeInScreenShowType? screenType = fadeInScreen.ScreenType;
				if (screenType != null)
				{
					EFadeInScreenShowType valueOrDefault = screenType.GetValueOrDefault();
					if (valueOrDefault == EFadeInScreenShowType.White)
					{
						ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectWhite);
						goto IL_3E2;
					}
					if (valueOrDefault != EFadeInScreenShowType.Black)
					{
					}
				}
				ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectBlack);
				IL_3E2:
				if (fadeInScreen.FadeBackground != null)
				{
					SpecialTransitionController instance4 = ControllerBase<SpecialTransitionController>.Instance;
					IFadeBackgroundType fadeBackground = fadeInScreen.FadeBackground;
					IEaseData ease = fadeInScreen.Ease;
					instance4.OpenSpecialTransitionLoadingByFadeScreen(fadeBackground, (ease != null) ? new float?(ease.Duration) : null, new Action(CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0));
				}
				else
				{
					ELoadingReason reason = ELoadingReason.Common;
					ELoadingPerform perform = ELoadingPerform.CameraFade;
					string context = null;
					Action callback = new Action(CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0);
					object[] array = new object[5];
					int num2 = 0;
					IEaseData ease2 = fadeInScreen.Ease;
					array[num2] = ((ease2 != null) ? ease2.Duration : 0f);
					array[1] = fadeInScreen.ScreenType;
					array[2] = true;
					array[3] = true;
					array[4] = num;
					this.OpenLoading<ELoadingPerform>(reason, perform, context, callback, array);
				}
				IL_4C3:
				GuaranteeActionInfo p = new GuaranteeActionInfo
				{
					Name = EGuaranteeAction.ActionBlackScreenFadeOut,
					Params = new GuaranteeFadeInParams
					{
						KeepFadeAfterTreeRollBack = fadeInScreen.KeepFadeAfterTreeRollBack
					}
				};
				flag = !(fadeInScreen.KeepFadeAfterTreeEnd ?? false);
				if (flag || (generalContext != null && generalContext.Type.GetValueOrDefault() == EGeneralContextType.DynamicInteract))
				{
					Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, "LevelEventFadeInScreen", generalContext, p, null);
					return;
				}
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, "LevelEventFadeInScreen", generalContext, p, null);
				return;
			}
			else
			{
				FadeOutScreen fadeOutScreen = Json.Parse<FadeOutScreen>(@params, null);
				ModelBase<PlotModel>.Instance.IsFadeIn = false;
				if (fadeOutScreen == null)
				{
					Singleton<global::Log>.Instance.Error(ELogModule.BlackScreen, ELogAuthor.JYS, "[黑幕]Params 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					Global.CharacterCameraManager.FadeAmount = 0f;
					this.CloseLoading(ELoadingReason.Common, null, delegate
					{
						base.<OnOperationScreenNotify>g__RequestFunc|0();
						ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
						ModelBase<PlotModel>.Instance.LastPlotAspect = -1f;
						ModelBase<PlotModel>.Instance.LastPlotColor = -1;
					}, new float?(1f));
					return;
				}
				if (ModelBase<PlotModel>.Instance.BlackScreenType.GetValueOrDefault() == EBlackScreenType.Plot)
				{
					Singleton<EventSystem>.Instance.Emit<bool, Action>(EEventName.PlotViewBgFadeBlackScreen, false, new Action(CS$<>8__locals1.<OnOperationScreenNotify>g__RequestFunc|0));
					return;
				}
				Global.CharacterCameraManager.FadeAmount = 0f;
				ELoadingReason reason2 = ELoadingReason.Common;
				string context2 = null;
				Action callback2 = delegate()
				{
					base.<OnOperationScreenNotify>g__RequestFunc|0();
					ModelBase<LoadingModel>.Instance.ScreenEffect = new EScreenEffectType?(EScreenEffectType.ScreenEffectNone);
					ModelBase<PlotModel>.Instance.LastPlotAspect = -1f;
					ModelBase<PlotModel>.Instance.LastPlotColor = -1;
				};
				IEaseData ease3 = fadeOutScreen.Ease;
				this.CloseLoading(reason2, context2, callback2, (ease3 != null) ? new float?(ease3.Duration) : null);
				GuaranteeActionInfo p2 = new GuaranteeActionInfo
				{
					Name = EGuaranteeAction.ActionBlackScreenFadeOut
				};
				Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, "LevelEventFadeInScreen", generalContext, p2, null);
				return;
			}
		}

		// Token: 0x0603A63D RID: 239165 RVA: 0x00ECE5D4 File Offset: 0x00ECC7D4
		public void OpenLoading<T>(ELoadingReason reason, [Nullable(1)] T perform, string context = null, Action callback = null, [Nullable(1)] params object[] parameters)
		{
			LevelLoadingController.<>c__DisplayClass11_0<T> CS$<>8__locals1 = new LevelLoadingController.<>c__DisplayClass11_0<T>();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			this.ProcessList.Add(new OpenLoadingProcess<T>(reason, perform, new Action(CS$<>8__locals1.<OpenLoading>g__TempCallback|0), context, parameters));
		}

		// Token: 0x0603A63E RID: 239166 RVA: 0x00ECE618 File Offset: 0x00ECC818
		public void CloseLoading(ELoadingReason reason, string context = null, Action callback = null, float? duration = null)
		{
			LevelLoadingController.<>c__DisplayClass12_0 CS$<>8__locals1 = new LevelLoadingController.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			this.ProcessList.Add(new CloseLoadingProcess(reason, new Action(CS$<>8__locals1.<CloseLoading>g__TempCallback|0), duration, context));
		}

		// Token: 0x0603A63F RID: 239167 RVA: 0x00ECE65C File Offset: 0x00ECC85C
		[NullableContext(1)]
		public UniTask WaitOpenLoading<[Nullable(2)] T>(ELoadingReason reason, T perform, [Nullable(2)] string context = null, params object[] parameters)
		{
			LevelLoadingController.<WaitOpenLoading>d__13<T> <WaitOpenLoading>d__;
			<WaitOpenLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitOpenLoading>d__.<>4__this = this;
			<WaitOpenLoading>d__.reason = reason;
			<WaitOpenLoading>d__.perform = perform;
			<WaitOpenLoading>d__.context = context;
			<WaitOpenLoading>d__.parameters = parameters;
			<WaitOpenLoading>d__.<>1__state = -1;
			<WaitOpenLoading>d__.<>t__builder.Start<LevelLoadingController.<WaitOpenLoading>d__13<T>>(ref <WaitOpenLoading>d__);
			return <WaitOpenLoading>d__.<>t__builder.Task;
		}

		// Token: 0x0603A640 RID: 239168 RVA: 0x00ECE6C0 File Offset: 0x00ECC8C0
		public UniTask WaitCloseLoading(ELoadingReason reason, string context = null, float? duration = null)
		{
			LevelLoadingController.<WaitCloseLoading>d__14 <WaitCloseLoading>d__;
			<WaitCloseLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitCloseLoading>d__.<>4__this = this;
			<WaitCloseLoading>d__.reason = reason;
			<WaitCloseLoading>d__.context = context;
			<WaitCloseLoading>d__.duration = duration;
			<WaitCloseLoading>d__.<>1__state = -1;
			<WaitCloseLoading>d__.<>t__builder.Start<LevelLoadingController.<WaitCloseLoading>d__14>(ref <WaitCloseLoading>d__);
			return <WaitCloseLoading>d__.<>t__builder.Task;
		}

		// Token: 0x0603A641 RID: 239169 RVA: 0x00ECE71C File Offset: 0x00ECC91C
		[NullableContext(0)]
		private UniTask<bool> OpenLoadingImp(ELoadingReason reason, ELoadingPerform perform, [Nullable(2)] string context, [Nullable(1)] params object[] parameters)
		{
			LevelLoadingController.<OpenLoadingImp>d__15 <OpenLoadingImp>d__;
			<OpenLoadingImp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenLoadingImp>d__.<>4__this = this;
			<OpenLoadingImp>d__.reason = reason;
			<OpenLoadingImp>d__.perform = perform;
			<OpenLoadingImp>d__.context = context;
			<OpenLoadingImp>d__.parameters = parameters;
			<OpenLoadingImp>d__.<>1__state = -1;
			<OpenLoadingImp>d__.<>t__builder.Start<LevelLoadingController.<OpenLoadingImp>d__15>(ref <OpenLoadingImp>d__);
			return <OpenLoadingImp>d__.<>t__builder.Task;
		}

		// Token: 0x0603A642 RID: 239170 RVA: 0x00ECE780 File Offset: 0x00ECC980
		private UniTask PrePerformLoadingMode()
		{
			LevelLoadingController.<PrePerformLoadingMode>d__16 <PrePerformLoadingMode>d__;
			<PrePerformLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformLoadingMode>d__.<>1__state = -1;
			<PrePerformLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformLoadingMode>d__16>(ref <PrePerformLoadingMode>d__);
			return <PrePerformLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A643 RID: 239171 RVA: 0x00ECE7BC File Offset: 0x00ECC9BC
		private UniTask PrePerformFadeLoadingMode()
		{
			LevelLoadingController.<PrePerformFadeLoadingMode>d__17 <PrePerformFadeLoadingMode>d__;
			<PrePerformFadeLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformFadeLoadingMode>d__.<>1__state = -1;
			<PrePerformFadeLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformFadeLoadingMode>d__17>(ref <PrePerformFadeLoadingMode>d__);
			return <PrePerformFadeLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A644 RID: 239172 RVA: 0x00ECE7F8 File Offset: 0x00ECC9F8
		private UniTask PrePerformCameraFadeMode(float duration, EFadeInScreenShowType screenType, bool needBackToFight, bool needCheckOpenView, int? treeId, bool stillNeedChangeColor)
		{
			LevelLoadingController.<PrePerformCameraFadeMode>d__18 <PrePerformCameraFadeMode>d__;
			<PrePerformCameraFadeMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformCameraFadeMode>d__.<>4__this = this;
			<PrePerformCameraFadeMode>d__.duration = duration;
			<PrePerformCameraFadeMode>d__.screenType = screenType;
			<PrePerformCameraFadeMode>d__.needBackToFight = needBackToFight;
			<PrePerformCameraFadeMode>d__.needCheckOpenView = needCheckOpenView;
			<PrePerformCameraFadeMode>d__.treeId = treeId;
			<PrePerformCameraFadeMode>d__.<>1__state = -1;
			<PrePerformCameraFadeMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformCameraFadeMode>d__18>(ref <PrePerformCameraFadeMode>d__);
			return <PrePerformCameraFadeMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A645 RID: 239173 RVA: 0x00ECE868 File Offset: 0x00ECCA68
		private UniTask PrePerformVideoCenterLoadingMode(string textKey)
		{
			LevelLoadingController.<PrePerformVideoCenterLoadingMode>d__19 <PrePerformVideoCenterLoadingMode>d__;
			<PrePerformVideoCenterLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformVideoCenterLoadingMode>d__.textKey = textKey;
			<PrePerformVideoCenterLoadingMode>d__.<>1__state = -1;
			<PrePerformVideoCenterLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformVideoCenterLoadingMode>d__19>(ref <PrePerformVideoCenterLoadingMode>d__);
			return <PrePerformVideoCenterLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A646 RID: 239174 RVA: 0x00ECE8AC File Offset: 0x00ECCAAC
		[NullableContext(1)]
		private UniTask PrePerformCgMode(string movieName, Action callback, bool inPlot = false)
		{
			LevelLoadingController.<PrePerformCgMode>d__20 <PrePerformCgMode>d__;
			<PrePerformCgMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformCgMode>d__.movieName = movieName;
			<PrePerformCgMode>d__.callback = callback;
			<PrePerformCgMode>d__.inPlot = inPlot;
			<PrePerformCgMode>d__.<>1__state = -1;
			<PrePerformCgMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformCgMode>d__20>(ref <PrePerformCgMode>d__);
			return <PrePerformCgMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A647 RID: 239175 RVA: 0x00ECE900 File Offset: 0x00ECCB00
		[NullableContext(1)]
		private UniTask PrePerformSpecialTransitionMode(ISpecialTransitionParams parameters)
		{
			LevelLoadingController.<PrePerformSpecialTransitionMode>d__21 <PrePerformSpecialTransitionMode>d__;
			<PrePerformSpecialTransitionMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrePerformSpecialTransitionMode>d__.parameters = parameters;
			<PrePerformSpecialTransitionMode>d__.<>1__state = -1;
			<PrePerformSpecialTransitionMode>d__.<>t__builder.Start<LevelLoadingController.<PrePerformSpecialTransitionMode>d__21>(ref <PrePerformSpecialTransitionMode>d__);
			return <PrePerformSpecialTransitionMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A648 RID: 239176 RVA: 0x00ECE944 File Offset: 0x00ECCB44
		public bool CheckIsOpen(ELoadingPerform? perform)
		{
			bool result = false;
			if (perform != null)
			{
				switch (perform.GetValueOrDefault())
				{
				case ELoadingPerform.VideoCenter:
					result = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PlotTransitionView);
					break;
				case ELoadingPerform.Loading:
					result = ModelBase<LoadingModel>.Instance.IsLoadingView;
					break;
				case ELoadingPerform.FadeLoading:
					result = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FadeLoadingView);
					break;
				case ELoadingPerform.CameraFade:
					result = this.CameraFade.IsInFade();
					break;
				case ELoadingPerform.CG:
					result = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VideoView);
					break;
				case ELoadingPerform.SpecialTransition:
					result = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SpecialTransitionView);
					break;
				}
			}
			return result;
		}

		// Token: 0x0603A649 RID: 239177 RVA: 0x00ECE9F0 File Offset: 0x00ECCBF0
		private UniTask CloseLoadingImp(ELoadingReason reason, float duration, string context = null)
		{
			LevelLoadingController.<CloseLoadingImp>d__23 <CloseLoadingImp>d__;
			<CloseLoadingImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseLoadingImp>d__.<>4__this = this;
			<CloseLoadingImp>d__.reason = reason;
			<CloseLoadingImp>d__.duration = duration;
			<CloseLoadingImp>d__.context = context;
			<CloseLoadingImp>d__.<>1__state = -1;
			<CloseLoadingImp>d__.<>t__builder.Start<LevelLoadingController.<CloseLoadingImp>d__23>(ref <CloseLoadingImp>d__);
			return <CloseLoadingImp>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64A RID: 239178 RVA: 0x00ECEA4C File Offset: 0x00ECCC4C
		private UniTask CloseViewInternal(ELoadingPerform? perform, float duration, string context = null)
		{
			LevelLoadingController.<CloseViewInternal>d__24 <CloseViewInternal>d__;
			<CloseViewInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseViewInternal>d__.<>4__this = this;
			<CloseViewInternal>d__.perform = perform;
			<CloseViewInternal>d__.duration = duration;
			<CloseViewInternal>d__.context = context;
			<CloseViewInternal>d__.<>1__state = -1;
			<CloseViewInternal>d__.<>t__builder.Start<LevelLoadingController.<CloseViewInternal>d__24>(ref <CloseViewInternal>d__);
			return <CloseViewInternal>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64B RID: 239179 RVA: 0x00ECEAA8 File Offset: 0x00ECCCA8
		private UniTask PostPerformLoadingMode()
		{
			LevelLoadingController.<PostPerformLoadingMode>d__25 <PostPerformLoadingMode>d__;
			<PostPerformLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PostPerformLoadingMode>d__.<>1__state = -1;
			<PostPerformLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PostPerformLoadingMode>d__25>(ref <PostPerformLoadingMode>d__);
			return <PostPerformLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64C RID: 239180 RVA: 0x00ECEAE4 File Offset: 0x00ECCCE4
		private UniTask PostPerformFadeLoadingMode()
		{
			LevelLoadingController.<PostPerformFadeLoadingMode>d__26 <PostPerformFadeLoadingMode>d__;
			<PostPerformFadeLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PostPerformFadeLoadingMode>d__.<>1__state = -1;
			<PostPerformFadeLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PostPerformFadeLoadingMode>d__26>(ref <PostPerformFadeLoadingMode>d__);
			return <PostPerformFadeLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64D RID: 239181 RVA: 0x00ECEB20 File Offset: 0x00ECCD20
		private UniTask PostPerformCameraFadeMode(float duration)
		{
			LevelLoadingController.<PostPerformCameraFadeMode>d__27 <PostPerformCameraFadeMode>d__;
			<PostPerformCameraFadeMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PostPerformCameraFadeMode>d__.<>4__this = this;
			<PostPerformCameraFadeMode>d__.duration = duration;
			<PostPerformCameraFadeMode>d__.<>1__state = -1;
			<PostPerformCameraFadeMode>d__.<>t__builder.Start<LevelLoadingController.<PostPerformCameraFadeMode>d__27>(ref <PostPerformCameraFadeMode>d__);
			return <PostPerformCameraFadeMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64E RID: 239182 RVA: 0x00ECEB6C File Offset: 0x00ECCD6C
		private UniTask PostPerformVideoCenterLoadingMode()
		{
			LevelLoadingController.<PostPerformVideoCenterLoadingMode>d__28 <PostPerformVideoCenterLoadingMode>d__;
			<PostPerformVideoCenterLoadingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PostPerformVideoCenterLoadingMode>d__.<>1__state = -1;
			<PostPerformVideoCenterLoadingMode>d__.<>t__builder.Start<LevelLoadingController.<PostPerformVideoCenterLoadingMode>d__28>(ref <PostPerformVideoCenterLoadingMode>d__);
			return <PostPerformVideoCenterLoadingMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A64F RID: 239183 RVA: 0x00ECEBA8 File Offset: 0x00ECCDA8
		private UniTask PostPerformSpecialTransitionMode()
		{
			LevelLoadingController.<PostPerformSpecialTransitionMode>d__29 <PostPerformSpecialTransitionMode>d__;
			<PostPerformSpecialTransitionMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PostPerformSpecialTransitionMode>d__.<>1__state = -1;
			<PostPerformSpecialTransitionMode>d__.<>t__builder.Start<LevelLoadingController.<PostPerformSpecialTransitionMode>d__29>(ref <PostPerformSpecialTransitionMode>d__);
			return <PostPerformSpecialTransitionMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603A650 RID: 239184 RVA: 0x00ECEBE4 File Offset: 0x00ECCDE4
		public void CloseAllBlackScreenLoading()
		{
			this.CloseLoading(ELoadingReason.Common, null, null, null);
			this.CloseLoading(ELoadingReason.BehaviorTreeRollback, null, null, null);
			this.CloseLoading(ELoadingReason.SimpleLevelSequence, null, null, null);
			ModelBase<LevelLoadingModel>.Instance.FinishCameraShowPromise();
		}

		// Token: 0x0603A651 RID: 239185 RVA: 0x00ECEC34 File Offset: 0x00ECCE34
		private unsafe void PushBlackScreenStateAndReasonToServer(bool isOpen, string reason)
		{
			if (string.IsNullOrEmpty(reason))
			{
				return;
			}
			BlackScreenStatePush blackScreenStatePush = BlackScreenStatePush.Create();
			blackScreenStatePush.IsOpen = isOpen;
			blackScreenStatePush.Source = BlackScreenSourceType.ClientAuto;
			blackScreenStatePush.BlackScreenReason = reason;
			Singleton<Net>.Instance.Send(EPushMessageId.BlackScreenStatePush, blackScreenStatePush);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.BlackScreen;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "推送客户端黑幕状态";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isOpen", isOpen);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0402110F RID: 135439
		public CameraFadeLoading CameraFade;

		// Token: 0x04021110 RID: 135440
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<object> ProcessList;

		// Token: 0x04021111 RID: 135441
		private object CurProcess;

		// Token: 0x04021112 RID: 135442
		private bool IsLockUiTimeDilation;
	}
}
