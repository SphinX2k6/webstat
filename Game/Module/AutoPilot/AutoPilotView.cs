using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x0200614F RID: 24911
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class AutoPilotView : UiPanelBase, IExtraShowCursor
	{
		// Token: 0x17009AE4 RID: 39652
		// (get) Token: 0x0603EEF9 RID: 257785 RVA: 0x01021F2B File Offset: 0x0102012B
		// (set) Token: 0x0603EEF8 RID: 257784 RVA: 0x01021EFB File Offset: 0x010200FB
		private bool IsCanShowMovieBtn
		{
			get
			{
				return this.IsCanShowMovieBtnInner;
			}
			set
			{
				if (this.IsCanShowMovieBtnInner != value)
				{
					this.IsCanShowMovieBtnInner = value;
					this.RefreshMovieBtnVisible();
					if (value)
					{
						Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "ShowAutoPilotMovieBtn");
					}
				}
			}
		}

		// Token: 0x17009AE5 RID: 39653
		// (get) Token: 0x0603EEFB RID: 257787 RVA: 0x01021F4B File Offset: 0x0102014B
		// (set) Token: 0x0603EEFA RID: 257786 RVA: 0x01021F33 File Offset: 0x01020133
		private bool IsCanShowSkipBtn
		{
			get
			{
				return this.IsCanShowSkipBtnInner;
			}
			set
			{
				if (this.IsCanShowSkipBtnInner != value)
				{
					this.IsCanShowSkipBtnInner = value;
					this.RefreshSkipBtnVisible();
				}
			}
		}

		// Token: 0x0603EEFC RID: 257788 RVA: 0x01021F54 File Offset: 0x01020154
		protected override UniTask OnBeforeStartAsync()
		{
			AutoPilotView.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AutoPilotView.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EEFD RID: 257789 RVA: 0x01021F97 File Offset: 0x01020197
		protected override void OnStart()
		{
			this.AddTick();
			this.InitUi();
			this.RefreshUiVisible();
			this.AddEvents();
		}

		// Token: 0x0603EEFE RID: 257790 RVA: 0x01021FB1 File Offset: 0x010201B1
		protected virtual void InitUi()
		{
			this.InitSkipBtn();
			this.InitExitBtn();
			this.InitMovieBtn();
			this.InitRideShareBtn();
			this.InitPhotoBtn();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnAutoPilotTrackMarkVisibleChanged, true);
		}

		// Token: 0x0603EEFF RID: 257791 RVA: 0x01021FE4 File Offset: 0x010201E4
		private void AddEvents()
		{
			Singleton<InputManager>.Instance.RegisterLockShortcutKeyReason("AutoPilotView", new TLockShortcutKeyDelegate(this.LockShortCutKeyDelegate));
			if (ModelBase<AutoPilotModel>.Instance.IsAllowExitByMove)
			{
				ControllerBase<InputDistributeController>.Instance.BindAxis("MotorMoveForward", new TInputHandle<float>(this.ExitAutoPilotByInput));
				ControllerBase<InputDistributeController>.Instance.BindAxis("MotorMoveRight", new TInputHandle<float>(this.ExitAutoPilotByInput));
			}
			Singleton<EventSystem>.Instance.Add<IMovieModeAspectOffset>(EEventName.MovieModeAspectOffsetUpdate, new Action<IMovieModeAspectOffset>(this.OnAspectOffsetUpdate));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.MovieModeHideUiChange, new Action<bool>(this.OnMovieModeHideUiChange));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<InputExtraShowCursorCenter>.Instance.RegisterExtraRefreshData("AutoPilotView", this);
		}

		// Token: 0x0603EF00 RID: 257792 RVA: 0x010220B0 File Offset: 0x010202B0
		private void RemoveEvents()
		{
			Singleton<InputManager>.Instance.RemoveLockShortcutKeyReason("AutoPilotView");
			if (ModelBase<AutoPilotModel>.Instance.IsAllowExitByMove)
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("MotorMoveForward", new TInputHandle<float>(this.ExitAutoPilotByInput));
				ControllerBase<InputDistributeController>.Instance.UnBindAxis("MotorMoveRight", new TInputHandle<float>(this.ExitAutoPilotByInput));
			}
			Singleton<EventSystem>.Instance.Remove<IMovieModeAspectOffset>(EEventName.MovieModeAspectOffsetUpdate, new Action<IMovieModeAspectOffset>(this.OnAspectOffsetUpdate));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.MovieModeHideUiChange, new Action<bool>(this.OnMovieModeHideUiChange));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData("AutoPilotView");
		}

		// Token: 0x0603EF01 RID: 257793
		protected abstract int GetSkipBtnCompId();

		// Token: 0x0603EF02 RID: 257794 RVA: 0x01022170 File Offset: 0x01020370
		private void InitSkipBtn()
		{
			this.SkipBtn = base.GetButton(this.GetSkipBtnCompId());
			if (this.SkipBtn == null)
			{
				return;
			}
			if (ModelBase<AutoPilotModel>.Instance.GetIsCanShowSkipBtn())
			{
				this.SkipBtn.OnClickCallBack.Bind(new Action(this.OnClickSkipBtn));
				return;
			}
			this.SkipBtn.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x0603EF03 RID: 257795
		protected abstract int GetRideShareBtnCompId();

		// Token: 0x0603EF04 RID: 257796 RVA: 0x010221DC File Offset: 0x010203DC
		private void InitRideShareBtn()
		{
			this.RideShareBtn = base.GetButton(this.GetRideShareBtnCompId());
			UUIButtonComponent rideShareBtn = this.RideShareBtn;
			if (rideShareBtn != null)
			{
				rideShareBtn.OnPointDownCallBack.Bind(new Action(this.OnPointDownRideShareBtn));
			}
			UUIButtonComponent rideShareBtn2 = this.RideShareBtn;
			if (rideShareBtn2 != null)
			{
				rideShareBtn2.OnPointUpCallBack.Bind(new Action(this.OnPointUpRideShareBtn));
			}
			UUIButtonComponent rideShareBtn3 = this.RideShareBtn;
			if (rideShareBtn3 != null)
			{
				rideShareBtn3.OnPointExitCallBack.Bind(new Action(this.OnPointUpRideShareBtn));
			}
			this.RideSharePressConfigTime = (float)ConfigCommonParamById.GetIntConfig("AutoPilotMovieModeRideShareLongPressTime").GetValueOrDefault(1);
			this.RideSharePressConfigTime *= 1000f;
		}

		// Token: 0x0603EF05 RID: 257797
		protected abstract int GetExitBtnCompId();

		// Token: 0x0603EF06 RID: 257798 RVA: 0x0102228D File Offset: 0x0102048D
		private void InitExitBtn()
		{
			this.ExitBtn = base.GetButton(this.GetExitBtnCompId());
			if (this.ExitBtn == null)
			{
				return;
			}
			this.ExitBtn.OnClickCallBack.Bind(new Action(this.OnClickExitBtn));
		}

		// Token: 0x0603EF07 RID: 257799
		protected abstract int GetMovieBtnCompId();

		// Token: 0x0603EF08 RID: 257800
		protected abstract int GetMovieBtnProgressCompId();

		// Token: 0x0603EF09 RID: 257801 RVA: 0x010222C8 File Offset: 0x010204C8
		private void InitMovieBtn()
		{
			this.MovieBtn = base.GetButton(this.GetMovieBtnCompId());
			UUIButtonComponent movieBtn = this.MovieBtn;
			if (movieBtn != null)
			{
				movieBtn.OnPointDownCallBack.Bind(new Action(this.OnPointDownMovieBtn));
			}
			UUIButtonComponent movieBtn2 = this.MovieBtn;
			if (movieBtn2 != null)
			{
				movieBtn2.OnPointUpCallBack.Bind(new Action(this.OnPointUpMovieBtn));
			}
			UUIButtonComponent movieBtn3 = this.MovieBtn;
			if (movieBtn3 != null)
			{
				movieBtn3.OnPointExitCallBack.Bind(new Action(this.OnPointUpMovieBtn));
			}
			this.MovieBtnProgress = base.GetTexture(this.GetMovieBtnProgressCompId());
			this.UpdateMovieBtnProgress(0f);
			this.EnterMovieModeConfigTime = (float)ConfigCommonParamById.GetIntConfig("EnterMovieModeTimeThreshold").GetValueOrDefault(1);
			this.ExitMovieModeConfigTime = (float)ConfigCommonParamById.GetIntConfig("ExitMovieModeTimeThreshold").GetValueOrDefault(1);
		}

		// Token: 0x0603EF0A RID: 257802
		protected abstract int GetPhotoBtnCompId();

		// Token: 0x0603EF0B RID: 257803 RVA: 0x0102239E File Offset: 0x0102059E
		private void InitPhotoBtn()
		{
			this.PhotoBtn = base.GetButton(this.GetPhotoBtnCompId());
			UUIButtonComponent photoBtn = this.PhotoBtn;
			if (photoBtn == null)
			{
				return;
			}
			photoBtn.OnClickCallBack.Bind(new Action(this.OnClickPhotoBtn));
		}

		// Token: 0x0603EF0C RID: 257804 RVA: 0x010223D3 File Offset: 0x010205D3
		private void AddTick()
		{
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "AutoPilotView", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x0603EF0D RID: 257805 RVA: 0x010223FF File Offset: 0x010205FF
		protected override void OnBeforeShow()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.TickId);
			}
			this.UpdateRideShareProgress(0f);
		}

		// Token: 0x0603EF0E RID: 257806 RVA: 0x01022426 File Offset: 0x01020626
		protected override void OnAfterHide()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.TickId);
			}
		}

		// Token: 0x0603EF0F RID: 257807 RVA: 0x01022442 File Offset: 0x01020642
		private void OnTick(float deltaTime)
		{
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			if (instance != null && instance.GetIsCanShowSkipBtn())
			{
				this.OnTickIsCanShowSkipBtn();
			}
			this.OnTickIsCanShowMovieBtn();
			this.OnTickRideShareProgress(deltaTime);
		}

		// Token: 0x0603EF10 RID: 257808 RVA: 0x0102246A File Offset: 0x0102066A
		private void OnClickSkipBtn()
		{
			this.HandleClickSkipBtn();
		}

		// Token: 0x0603EF11 RID: 257809
		protected abstract void HandleClickSkipBtn();

		// Token: 0x0603EF12 RID: 257810 RVA: 0x01022472 File Offset: 0x01020672
		private void OnClickExitBtn()
		{
			this.HandleClickExitBtn().Forget();
		}

		// Token: 0x0603EF13 RID: 257811 RVA: 0x01022480 File Offset: 0x01020680
		private UniTask HandleClickExitBtn()
		{
			AutoPilotView.<HandleClickExitBtn>d__45 <HandleClickExitBtn>d__;
			<HandleClickExitBtn>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleClickExitBtn>d__.<>4__this = this;
			<HandleClickExitBtn>d__.<>1__state = -1;
			<HandleClickExitBtn>d__.<>t__builder.Start<AutoPilotView.<HandleClickExitBtn>d__45>(ref <HandleClickExitBtn>d__);
			return <HandleClickExitBtn>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF14 RID: 257812 RVA: 0x010224C3 File Offset: 0x010206C3
		private void OnPointDownMovieBtn()
		{
			this.EnterMovieMode();
		}

		// Token: 0x0603EF15 RID: 257813 RVA: 0x010224CC File Offset: 0x010206CC
		private void OnPointUpMovieBtn()
		{
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			if (instance != null && instance.GetIsInMovieMode())
			{
				return;
			}
			this.ExitMovieMode(null).Forget();
		}

		// Token: 0x0603EF16 RID: 257814 RVA: 0x01022501 File Offset: 0x01020701
		private void OnPointDownRideShareBtn()
		{
			this.IsRideSharePressed = true;
		}

		// Token: 0x0603EF17 RID: 257815 RVA: 0x0102250A File Offset: 0x0102070A
		private void OnPointUpRideShareBtn()
		{
			this.IsRideSharePressed = false;
		}

		// Token: 0x0603EF18 RID: 257816 RVA: 0x01022514 File Offset: 0x01020714
		private void EnterRideShareMode()
		{
			ControllerBase<MovieModeController>.Instance.ResetMovieModeHideUi(true);
			MovieModeModel instance = ModelBase<MovieModeModel>.Instance;
			if (instance != null)
			{
				instance.FreezeUi("EnterRideShareMode");
			}
			if (!ModelBase<ShipTogetherModel>.Instance.IsInMovieRideSharingMode)
			{
				this.OpenRideShareViewWithRequest().Forget();
				return;
			}
			this.OpenRideShareView().Forget();
		}

		// Token: 0x0603EF19 RID: 257817 RVA: 0x01022564 File Offset: 0x01020764
		private UniTask OpenRideShareViewWithRequest()
		{
			AutoPilotView.<OpenRideShareViewWithRequest>d__51 <OpenRideShareViewWithRequest>d__;
			<OpenRideShareViewWithRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenRideShareViewWithRequest>d__.<>4__this = this;
			<OpenRideShareViewWithRequest>d__.<>1__state = -1;
			<OpenRideShareViewWithRequest>d__.<>t__builder.Start<AutoPilotView.<OpenRideShareViewWithRequest>d__51>(ref <OpenRideShareViewWithRequest>d__);
			return <OpenRideShareViewWithRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF1A RID: 257818 RVA: 0x010225A8 File Offset: 0x010207A8
		private UniTask OpenRideShareView()
		{
			AutoPilotView.<OpenRideShareView>d__52 <OpenRideShareView>d__;
			<OpenRideShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenRideShareView>d__.<>4__this = this;
			<OpenRideShareView>d__.<>1__state = -1;
			<OpenRideShareView>d__.<>t__builder.Start<AutoPilotView.<OpenRideShareView>d__52>(ref <OpenRideShareView>d__);
			return <OpenRideShareView>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF1B RID: 257819 RVA: 0x010225EB File Offset: 0x010207EB
		private void OpenMotorcycleTogetherView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleTogetherView, null, delegate(bool success, int _)
			{
				if (!success)
				{
					MovieModeModel instance = ModelBase<MovieModeModel>.Instance;
					if (instance != null)
					{
						instance.UnFreezeUi("EnterRideShareMode");
					}
					this.UpdateRideShareProgress(0f);
				}
			});
		}

		// Token: 0x0603EF1C RID: 257820 RVA: 0x0102260C File Offset: 0x0102080C
		private UniTask AwaitRideShareCamera()
		{
			AutoPilotView.<AwaitRideShareCamera>d__54 <AwaitRideShareCamera>d__;
			<AwaitRideShareCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AwaitRideShareCamera>d__.<>1__state = -1;
			<AwaitRideShareCamera>d__.<>t__builder.Start<AutoPilotView.<AwaitRideShareCamera>d__54>(ref <AwaitRideShareCamera>d__);
			return <AwaitRideShareCamera>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF1D RID: 257821 RVA: 0x01022648 File Offset: 0x01020848
		private UniTask AwaitEnterRideShare()
		{
			AutoPilotView.<AwaitEnterRideShare>d__55 <AwaitEnterRideShare>d__;
			<AwaitEnterRideShare>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AwaitEnterRideShare>d__.<>1__state = -1;
			<AwaitEnterRideShare>d__.<>t__builder.Start<AutoPilotView.<AwaitEnterRideShare>d__55>(ref <AwaitEnterRideShare>d__);
			return <AwaitEnterRideShare>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF1E RID: 257822 RVA: 0x01022684 File Offset: 0x01020884
		private UniTask AwaitExitRideShare()
		{
			AutoPilotView.<AwaitExitRideShare>d__56 <AwaitExitRideShare>d__;
			<AwaitExitRideShare>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AwaitExitRideShare>d__.<>1__state = -1;
			<AwaitExitRideShare>d__.<>t__builder.Start<AutoPilotView.<AwaitExitRideShare>d__56>(ref <AwaitExitRideShare>d__);
			return <AwaitExitRideShare>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF1F RID: 257823 RVA: 0x010226C0 File Offset: 0x010208C0
		protected void OnClickPhotoBtn()
		{
			ControllerBase<PhotographController>.Instance.ScreenShot(new PhotoSaveViewParam
			{
				ScreenShot = true,
				PrepareFullScreenShot = false,
				IsHiddenBattleView = true,
				HandBookPhotoData = null,
				GachaData = null,
				FragmentMemory = null,
				RoleSkinData = null,
				ShareId = 1
			});
		}

		// Token: 0x0603EF20 RID: 257824 RVA: 0x01022714 File Offset: 0x01020914
		public void EnterMovieMode()
		{
			string randomItem = Singleton<MathUtils>.Instance.GetRandomItem<string>(ModelBase<AutoPilotModel>.Instance.MovieModeCameraRowNameArray);
			if (randomItem == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.AutoPilot, ELogAuthor.CB, "EnterMovieMode: rowName is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IEnterCommonMovieCamera movieCameraType = new IEnterCommonMovieCamera
			{
				Type = EMovieCameraType.Common,
				RowName = randomItem
			};
			IMovieCameraConfig movieCameraConfig = new IMovieCameraConfig
			{
				MovieCameraType = movieCameraType
			};
			EnterMovieModeParams param = new EnterMovieModeParams
			{
				BlendTime = this.EnterMovieModeConfigTime,
				MovieCameraConfig = movieCameraConfig,
				Parent = this,
				UiLayer = new ELayerType?(ELayerType.Pop),
				AdaptUiLayers = new ELayerType[]
				{
					ELayerType.Normal
				},
				IsIgnoreUiLayerVisible = new bool?(true),
				IsNeedMovieModeUi = new bool?(true)
			};
			ControllerBase<MovieModeController>.Instance.EnterMovieMode(param, delegate(bool success)
			{
				if (success)
				{
					BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
					if (instance != null)
					{
						instance.SetBattleUiAlpha(1f);
					}
					BattleUiModel instance2 = ModelBase<BattleUiModel>.Instance;
					if (instance2 != null)
					{
						BattleUiChildViewData childViewData = instance2.ChildViewData;
						if (childViewData != null)
						{
							childViewData.SetChildrenVisible(EBattleUiVisibleReason.AutoPilot, new List<EBattleUiChild>
							{
								EBattleUiChild.MiniMap,
								EBattleUiChild.MotorcycleControlHud
							}, false, true, 0);
						}
					}
					Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnAutoPilotTrackMarkVisibleChanged, false);
					AutoPilotModel instance3 = ModelBase<AutoPilotModel>.Instance;
					if (instance3 != null)
					{
						instance3.SetIsInMovieMode(true);
					}
					this.RefreshUiByIsInMovieMode();
					Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
				}
			}).Forget();
		}

		// Token: 0x0603EF21 RID: 257825 RVA: 0x010227F8 File Offset: 0x010209F8
		public UniTask ExitMovieMode(float? blendTime = null)
		{
			AutoPilotView.<ExitMovieMode>d__59 <ExitMovieMode>d__;
			<ExitMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExitMovieMode>d__.<>4__this = this;
			<ExitMovieMode>d__.blendTime = blendTime;
			<ExitMovieMode>d__.<>1__state = -1;
			<ExitMovieMode>d__.<>t__builder.Start<AutoPilotView.<ExitMovieMode>d__59>(ref <ExitMovieMode>d__);
			return <ExitMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF22 RID: 257826 RVA: 0x01022844 File Offset: 0x01020A44
		private void OnTickIsCanShowMovieBtn()
		{
			double autoPilotTime = ModelBase<AutoPilotModel>.Instance.GetAutoPilotTime();
			int enterMovieModeTimeThreshold = ModelBase<AutoPilotModel>.Instance.GetEnterMovieModeTimeThreshold();
			if (autoPilotTime < (double)enterMovieModeTimeThreshold)
			{
				this.IsCanShowMovieBtn = false;
				return;
			}
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			AutoPilotFindPathResult autoPilotFindPathResult = (instance != null) ? instance.GetFindPathResult() : null;
			if (autoPilotFindPathResult != null)
			{
				double enterMovieModeDistanceThreshold = ModelBase<AutoPilotModel>.Instance.GetEnterMovieModeDistanceThreshold();
				if (autoPilotFindPathResult.GetDistSquaredPlayerToEndPoint() < enterMovieModeDistanceThreshold)
				{
					this.IsCanShowMovieBtn = false;
					return;
				}
			}
			this.IsCanShowMovieBtn = true;
		}

		// Token: 0x0603EF23 RID: 257827 RVA: 0x010228AC File Offset: 0x01020AAC
		private void OnTickIsCanShowSkipBtn()
		{
			double autoPilotTime = ModelBase<AutoPilotModel>.Instance.GetAutoPilotTime();
			int canSkipTimeThreshold = ModelBase<AutoPilotModel>.Instance.GetCanSkipTimeThreshold();
			if (autoPilotTime < (double)canSkipTimeThreshold)
			{
				this.IsCanShowSkipBtn = false;
			}
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			AutoPilotFindPathResult autoPilotFindPathResult = (instance != null) ? instance.GetFindPathResult() : null;
			if (autoPilotFindPathResult != null)
			{
				double canSkipDistanceThreshold = ModelBase<AutoPilotModel>.Instance.GetCanSkipDistanceThreshold();
				if (autoPilotFindPathResult.GetDistSquaredPlayerToEndPoint() < canSkipDistanceThreshold)
				{
					this.IsCanShowSkipBtn = false;
				}
			}
			this.IsCanShowSkipBtn = true;
		}

		// Token: 0x0603EF24 RID: 257828 RVA: 0x01022910 File Offset: 0x01020B10
		private void RefreshMovieBtnVisible()
		{
			bool isInMovieMode = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode();
			UUIButtonComponent movieBtn = this.MovieBtn;
			if (movieBtn == null)
			{
				return;
			}
			UUIItem uuiitem = movieBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(this.IsCanShowMovieBtn && !isInMovieMode);
		}

		// Token: 0x0603EF25 RID: 257829 RVA: 0x0102295C File Offset: 0x01020B5C
		private void RefreshSkipBtnVisible()
		{
			UUIButtonComponent skipBtn = this.SkipBtn;
			if (skipBtn == null)
			{
				return;
			}
			UUIItem uuiitem = skipBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(!this.IsMovieModeHideUi && this.IsCanShowSkipBtn);
		}

		// Token: 0x0603EF26 RID: 257830 RVA: 0x0102299C File Offset: 0x01020B9C
		private void RefreshExitBtnVisible()
		{
			UUIButtonComponent exitBtn = this.ExitBtn;
			if (exitBtn == null)
			{
				return;
			}
			UUIItem uuiitem = exitBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(!this.IsMovieModeHideUi);
		}

		// Token: 0x0603EF27 RID: 257831 RVA: 0x010229D4 File Offset: 0x01020BD4
		protected virtual void RefreshPhotoBtnVisible()
		{
			UUIButtonComponent photoBtn = this.PhotoBtn;
			if (photoBtn == null)
			{
				return;
			}
			UUIItem uuiitem = photoBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(!this.IsMovieModeHideUi);
		}

		// Token: 0x0603EF28 RID: 257832 RVA: 0x01022A0C File Offset: 0x01020C0C
		private void RefreshRideShareBtnVisible()
		{
			bool uiactive = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode() && !this.IsMovieModeHideUi;
			UUIButtonComponent rideShareBtn = this.RideShareBtn;
			if (rideShareBtn == null)
			{
				return;
			}
			UUIItem uuiitem = rideShareBtn.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(uiactive);
		}

		// Token: 0x0603EF29 RID: 257833 RVA: 0x01022A58 File Offset: 0x01020C58
		private void RefreshAutoPilotStateViewVisible()
		{
			bool isInMovieMode = ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode();
			AutoPilotStateView autoPilotStateView = this.AutoPilotStateView;
			if (autoPilotStateView == null)
			{
				return;
			}
			autoPilotStateView.SetUiActive(!isInMovieMode);
		}

		// Token: 0x0603EF2A RID: 257834 RVA: 0x01022A84 File Offset: 0x01020C84
		protected virtual void RefreshUiVisible()
		{
			this.RefreshRideShareBtnVisible();
			this.RefreshMovieBtnVisible();
			this.RefreshSkipBtnVisible();
			this.RefreshExitBtnVisible();
			this.RefreshPhotoBtnVisible();
		}

		// Token: 0x0603EF2B RID: 257835 RVA: 0x01022AA4 File Offset: 0x01020CA4
		protected virtual void RefreshUiByIsMovieModeHideUi()
		{
			this.RefreshSkipBtnVisible();
			this.RefreshExitBtnVisible();
			this.RefreshPhotoBtnVisible();
			this.RefreshRideShareBtnVisible();
		}

		// Token: 0x0603EF2C RID: 257836 RVA: 0x01022ABE File Offset: 0x01020CBE
		protected virtual void RefreshUiByIsInMovieMode()
		{
			this.RefreshMovieBtnVisible();
			this.RefreshRideShareBtnVisible();
			this.RefreshAutoPilotStateViewVisible();
		}

		// Token: 0x0603EF2D RID: 257837 RVA: 0x01022AD2 File Offset: 0x01020CD2
		[NullableContext(1)]
		private bool LockShortCutKeyDelegate(string actionName, InputDistributeDefine.EActionType actionType)
		{
			return ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode() || actionName != "地图";
		}

		// Token: 0x0603EF2E RID: 257838 RVA: 0x01022AED File Offset: 0x01020CED
		[NullableContext(1)]
		private void ExitAutoPilotByInput(string axisName, float value, InputIdentification inputIdentification)
		{
			if (value == 0f)
			{
				return;
			}
			ControllerBase<AutoPilotController>.Instance.ExitAutoPilot("ExitAutoPilotByInput", false).Forget();
		}

		// Token: 0x0603EF2F RID: 257839 RVA: 0x01022B10 File Offset: 0x01020D10
		[NullableContext(1)]
		private void OnAspectOffsetUpdate(IMovieModeAspectOffset aspectOffset)
		{
			if (ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode())
			{
				return;
			}
			this.UpdateMovieBtnProgress(aspectOffset.Progress);
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAlpha(1f - aspectOffset.Progress);
			}
			ModelBase<BattleUiModel>.Instance.SetBattleUiAlpha(1f - aspectOffset.Progress);
		}

		// Token: 0x0603EF30 RID: 257840 RVA: 0x01022B69 File Offset: 0x01020D69
		private void OnMovieModeHideUiChange(bool isHide)
		{
			this.HandleMovieModeHideUiChange(isHide).Forget();
		}

		// Token: 0x0603EF31 RID: 257841 RVA: 0x01022B78 File Offset: 0x01020D78
		private UniTask HandleMovieModeHideUiChange(bool isHide)
		{
			AutoPilotView.<HandleMovieModeHideUiChange>d__75 <HandleMovieModeHideUiChange>d__;
			<HandleMovieModeHideUiChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleMovieModeHideUiChange>d__.<>4__this = this;
			<HandleMovieModeHideUiChange>d__.isHide = isHide;
			<HandleMovieModeHideUiChange>d__.<>1__state = -1;
			<HandleMovieModeHideUiChange>d__.<>t__builder.Start<AutoPilotView.<HandleMovieModeHideUiChange>d__75>(ref <HandleMovieModeHideUiChange>d__);
			return <HandleMovieModeHideUiChange>d__.<>t__builder.Task;
		}

		// Token: 0x0603EF32 RID: 257842 RVA: 0x01022BC4 File Offset: 0x01020DC4
		private void OnTickRideShareProgress(float deltaTime)
		{
			if (!ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode() || this.IsMovieModeHideUi)
			{
				return;
			}
			if (this.RideSharePressedTime >= this.RideSharePressConfigTime)
			{
				if (ModelBase<ShipTogetherModel>.Instance.CanEnterMotorcycleMovieRideSharingMode(true))
				{
					this.EnterRideShareMode();
				}
				this.RideSharePressedTime = 0f;
				this.IsRideSharePressed = false;
				this.UpdateRideShareProgress(0f);
				return;
			}
			if (this.IsRideSharePressed)
			{
				this.RideSharePressedTime = Math.Min(this.RideSharePressedTime + deltaTime, this.RideSharePressConfigTime);
			}
			else
			{
				if (this.RideSharePressedTime <= 0f)
				{
					return;
				}
				this.RideSharePressedTime = Math.Max(this.RideSharePressedTime - deltaTime, 0f);
			}
			float progress = this.RideSharePressedTime / this.RideSharePressConfigTime;
			this.UpdateRideShareProgress(progress);
		}

		// Token: 0x0603EF33 RID: 257843 RVA: 0x01022C8B File Offset: 0x01020E8B
		protected virtual void UpdateRideShareProgress(float progress)
		{
			ModelBase<AutoPilotModel>.Instance.RideShareBtnProgress = progress;
		}

		// Token: 0x0603EF34 RID: 257844 RVA: 0x01022C98 File Offset: 0x01020E98
		private void UpdateMovieBtnProgress(float progress)
		{
			UUITexture movieBtnProgress = this.MovieBtnProgress;
			if (movieBtnProgress == null)
			{
				return;
			}
			movieBtnProgress.SetFillAmount(progress);
		}

		// Token: 0x0603EF35 RID: 257845 RVA: 0x01022CAB File Offset: 0x01020EAB
		public bool IsShowCursor()
		{
			return ModelBase<InputDistributeModel>.Instance.GetNotAllowFightInputViewNameSet().Count > 0 || (ModelBase<AutoPilotModel>.Instance.GetIsInMovieMode() && !this.IsMovieModeHideUi);
		}

		// Token: 0x0603EF36 RID: 257846 RVA: 0x01022CD8 File Offset: 0x01020ED8
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.MotorcycleTogetherView)
			{
				return;
			}
			MovieModeModel instance = ModelBase<MovieModeModel>.Instance;
			if (instance != null)
			{
				instance.UnFreezeUi("EnterRideShareMode");
			}
			this.UpdateRideShareProgress(0f);
		}

		// Token: 0x0603EF37 RID: 257847 RVA: 0x01022D08 File Offset: 0x01020F08
		private void RemoveTick()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
				this.TickId = -1;
			}
		}

		// Token: 0x0603EF38 RID: 257848 RVA: 0x01022D2B File Offset: 0x01020F2B
		protected override void OnBeforeDestroy()
		{
			ModelBase<BattleUiModel>.Instance.SetBattleUiAlpha(1f);
			MovieModeModel instance = ModelBase<MovieModeModel>.Instance;
			if (instance != null)
			{
				instance.UnFreezeUi("EnterRideShareMode");
			}
			this.RemoveTick();
			this.RemoveEvents();
		}

		// Token: 0x0402350E RID: 144654
		private AutoPilotStateView AutoPilotStateView;

		// Token: 0x0402350F RID: 144655
		private int TickId = -1;

		// Token: 0x04023510 RID: 144656
		private UUITexture MovieBtnProgress;

		// Token: 0x04023511 RID: 144657
		private UUIButtonComponent SkipBtn;

		// Token: 0x04023512 RID: 144658
		private UUIButtonComponent MovieBtn;

		// Token: 0x04023513 RID: 144659
		private UUIButtonComponent RideShareBtn;

		// Token: 0x04023514 RID: 144660
		private UUIButtonComponent ExitBtn;

		// Token: 0x04023515 RID: 144661
		protected UUIButtonComponent PhotoBtn;

		// Token: 0x04023516 RID: 144662
		protected bool IsMovieModeHideUi;

		// Token: 0x04023517 RID: 144663
		private bool IsRideSharePressed;

		// Token: 0x04023518 RID: 144664
		private float RideSharePressedTime;

		// Token: 0x04023519 RID: 144665
		private float RideSharePressConfigTime;

		// Token: 0x0402351A RID: 144666
		private float EnterMovieModeConfigTime;

		// Token: 0x0402351B RID: 144667
		private float ExitMovieModeConfigTime;

		// Token: 0x0402351C RID: 144668
		private bool IsCanShowMovieBtnInner;

		// Token: 0x0402351D RID: 144669
		private bool IsCanShowSkipBtnInner;
	}
}
