using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056E1 RID: 22241
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class MovieModeController : UiControllerBase<MovieModeController>
	{
		// Token: 0x170090D5 RID: 37077
		// (get) Token: 0x0603899B RID: 231835 RVA: 0x00E57069 File Offset: 0x00E55269
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0603899C RID: 231836 RVA: 0x00E5706C File Offset: 0x00E5526C
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603899D RID: 231837 RVA: 0x00E57070 File Offset: 0x00E55270
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PlotSequenceStarted, new Action(this.PlotSequenceStarted));
			Singleton<EventSystem>.Instance.Add(EEventName.PlotSequenceEnd, new Action(this.PlotSequenceEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
		}

		// Token: 0x0603899E RID: 231838 RVA: 0x00E570D0 File Offset: 0x00E552D0
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceStarted, new Action(this.PlotSequenceStarted));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceEnd, new Action(this.PlotSequenceEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.UIViewPortSizeChanged, new Action(this.OnUiViewPortSizeChanged));
		}

		// Token: 0x0603899F RID: 231839 RVA: 0x00E5712E File Offset: 0x00E5532E
		private void OnUiViewPortSizeChanged()
		{
			MovieModeAspectView movieModeAspectView = this.MovieModeAspectView;
			if (movieModeAspectView == null)
			{
				return;
			}
			movieModeAspectView.UpdateTransform();
		}

		// Token: 0x060389A0 RID: 231840 RVA: 0x00E57140 File Offset: 0x00E55340
		public int AddTick(Action<float> handle)
		{
			this.TickHandleId++;
			this.TickGroup[this.TickHandleId] = handle;
			return this.TickHandleId;
		}

		// Token: 0x060389A1 RID: 231841 RVA: 0x00E57168 File Offset: 0x00E55368
		public void RemoveTick(int id)
		{
			this.TickGroup.Remove(id);
		}

		// Token: 0x060389A2 RID: 231842 RVA: 0x00E57178 File Offset: 0x00E55378
		protected override void OnTick(float delta)
		{
			if (this.TickGroup.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, Action<float>> keyValuePair in this.TickGroup)
			{
				keyValuePair.Value(delta);
			}
		}

		// Token: 0x060389A3 RID: 231843 RVA: 0x00E571E0 File Offset: 0x00E553E0
		public UniTask EnterMovieMode(IEnterMovieModeParams param, [Nullable(2)] Action<bool> callBack = null)
		{
			MovieModeController.<EnterMovieMode>d__15 <EnterMovieMode>d__;
			<EnterMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnterMovieMode>d__.<>4__this = this;
			<EnterMovieMode>d__.param = param;
			<EnterMovieMode>d__.callBack = callBack;
			<EnterMovieMode>d__.<>1__state = -1;
			<EnterMovieMode>d__.<>t__builder.Start<MovieModeController.<EnterMovieMode>d__15>(ref <EnterMovieMode>d__);
			return <EnterMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x060389A4 RID: 231844 RVA: 0x00E57234 File Offset: 0x00E55434
		private UniTask ExecuteEnter(IEnterMovieModeParams param)
		{
			MovieModeController.<ExecuteEnter>d__16 <ExecuteEnter>d__;
			<ExecuteEnter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteEnter>d__.<>4__this = this;
			<ExecuteEnter>d__.param = param;
			<ExecuteEnter>d__.<>1__state = -1;
			<ExecuteEnter>d__.<>t__builder.Start<MovieModeController.<ExecuteEnter>d__16>(ref <ExecuteEnter>d__);
			return <ExecuteEnter>d__.<>t__builder.Task;
		}

		// Token: 0x060389A5 RID: 231845 RVA: 0x00E57280 File Offset: 0x00E55480
		public UniTask ExitMovieMode(IExitMovieModeParams param, [Nullable(2)] Action<bool> callBack = null)
		{
			MovieModeController.<ExitMovieMode>d__17 <ExitMovieMode>d__;
			<ExitMovieMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExitMovieMode>d__.<>4__this = this;
			<ExitMovieMode>d__.param = param;
			<ExitMovieMode>d__.callBack = callBack;
			<ExitMovieMode>d__.<>1__state = -1;
			<ExitMovieMode>d__.<>t__builder.Start<MovieModeController.<ExitMovieMode>d__17>(ref <ExitMovieMode>d__);
			return <ExitMovieMode>d__.<>t__builder.Task;
		}

		// Token: 0x060389A6 RID: 231846 RVA: 0x00E572D4 File Offset: 0x00E554D4
		private UniTask ExecuteExit(IExitMovieModeParams param)
		{
			MovieModeController.<ExecuteExit>d__18 <ExecuteExit>d__;
			<ExecuteExit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteExit>d__.<>4__this = this;
			<ExecuteExit>d__.param = param;
			<ExecuteExit>d__.<>1__state = -1;
			<ExecuteExit>d__.<>t__builder.Start<MovieModeController.<ExecuteExit>d__18>(ref <ExecuteExit>d__);
			return <ExecuteExit>d__.<>t__builder.Task;
		}

		// Token: 0x060389A7 RID: 231847 RVA: 0x00E57320 File Offset: 0x00E55520
		public UniTask CreateAspectView(IEnterMovieModeParams param)
		{
			MovieModeController.<CreateAspectView>d__19 <CreateAspectView>d__;
			<CreateAspectView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAspectView>d__.<>4__this = this;
			<CreateAspectView>d__.param = param;
			<CreateAspectView>d__.<>1__state = -1;
			<CreateAspectView>d__.<>t__builder.Start<MovieModeController.<CreateAspectView>d__19>(ref <CreateAspectView>d__);
			return <CreateAspectView>d__.<>t__builder.Task;
		}

		// Token: 0x060389A8 RID: 231848 RVA: 0x00E5736C File Offset: 0x00E5556C
		public UniTask RemoveAspectView(IExitMovieModeParams param)
		{
			MovieModeController.<RemoveAspectView>d__20 <RemoveAspectView>d__;
			<RemoveAspectView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RemoveAspectView>d__.<>4__this = this;
			<RemoveAspectView>d__.param = param;
			<RemoveAspectView>d__.<>1__state = -1;
			<RemoveAspectView>d__.<>t__builder.Start<MovieModeController.<RemoveAspectView>d__20>(ref <RemoveAspectView>d__);
			return <RemoveAspectView>d__.<>t__builder.Task;
		}

		// Token: 0x060389A9 RID: 231849 RVA: 0x00E573B8 File Offset: 0x00E555B8
		public UniTask CreateUiView(IEnterMovieModeParams param)
		{
			MovieModeController.<CreateUiView>d__21 <CreateUiView>d__;
			<CreateUiView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateUiView>d__.<>4__this = this;
			<CreateUiView>d__.param = param;
			<CreateUiView>d__.<>1__state = -1;
			<CreateUiView>d__.<>t__builder.Start<MovieModeController.<CreateUiView>d__21>(ref <CreateUiView>d__);
			return <CreateUiView>d__.<>t__builder.Task;
		}

		// Token: 0x060389AA RID: 231850 RVA: 0x00E57403 File Offset: 0x00E55603
		public void RemoveUiView()
		{
			MovieModeUiView movieModeUiView = this.MovieModeUiView;
			if (movieModeUiView != null)
			{
				movieModeUiView.Destroy(null);
			}
			this.MovieModeUiView = null;
		}

		// Token: 0x060389AB RID: 231851 RVA: 0x00E5741E File Offset: 0x00E5561E
		[NullableContext(2)]
		public IMovieModeAspectOffset GetAspectOffset()
		{
			MovieModeAspectView movieModeAspectView = this.MovieModeAspectView;
			if (movieModeAspectView == null)
			{
				return null;
			}
			return movieModeAspectView.GetAspectOffset();
		}

		// Token: 0x060389AC RID: 231852 RVA: 0x00E57434 File Offset: 0x00E55634
		private void CancelEnterMovieMode()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "取消进入电影模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			MovieModeAspectView movieModeAspectView = this.MovieModeAspectView;
			if (movieModeAspectView != null)
			{
				movieModeAspectView.FadeReverse();
			}
			this.CurrentState = EMovieModeState.CancelEnter;
		}

		// Token: 0x060389AD RID: 231853 RVA: 0x00E57478 File Offset: 0x00E55678
		private void ReEnterMovieMode()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "重新进入电影模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			MovieModeAspectView movieModeAspectView = this.MovieModeAspectView;
			if (movieModeAspectView != null)
			{
				movieModeAspectView.FadeReverse();
			}
			this.CurrentState = EMovieModeState.Entering;
		}

		// Token: 0x060389AE RID: 231854 RVA: 0x00E574BC File Offset: 0x00E556BC
		private unsafe void PlayMovieCamera(IEnterMovieModeParams param)
		{
			if (param.MovieCameraConfig == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "进入电影模式没有配置对应电影镜头", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IEnterMovieCameraType movieCameraType = param.MovieCameraConfig.MovieCameraType;
			if (movieCameraType.Type == EMovieCameraType.Common)
			{
				IEnterCommonMovieCamera enterCommonMovieCamera = movieCameraType as IEnterCommonMovieCamera;
				string rowName = enterCommonMovieCamera.RowName;
				int initialIndex = enterCommonMovieCamera.SpecElementIndex.GetValueOrDefault(-1);
				ModelBase<CameraModel>.Instance.MainModel.PlayMovieCamera(rowName, initialIndex, delegate(bool success)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.MovieMode;
					ELogAuthor author = ELogAuthor.CB;
					string message = "[电影镜头]通过MovieModeController进入常规电影镜头结果";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", success);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", rowName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("InitialIndex", initialIndex);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				});
				return;
			}
			if (movieCameraType.Type == EMovieCameraType.Spec)
			{
				IEnterSpecMovieCamera enterSpecMovieCamera = movieCameraType as IEnterSpecMovieCamera;
				string rowName = enterSpecMovieCamera.RowName;
				ModelBase<CameraModel>.Instance.MainModel.PlaySpecialMovieCamera(rowName, delegate(bool success)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.MovieMode;
					ELogAuthor author = ELogAuthor.CB;
					string message = "[电影镜头]通过MovieModeController进入特殊电影镜头结果";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", success);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", rowName);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				});
			}
		}

		// Token: 0x060389AF RID: 231855 RVA: 0x00E575A8 File Offset: 0x00E557A8
		private UniTask StopMovieCamera()
		{
			MovieModeController.<StopMovieCamera>d__27 <StopMovieCamera>d__;
			<StopMovieCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StopMovieCamera>d__.<>1__state = -1;
			<StopMovieCamera>d__.<>t__builder.Start<MovieModeController.<StopMovieCamera>d__27>(ref <StopMovieCamera>d__);
			return <StopMovieCamera>d__.<>t__builder.Task;
		}

		// Token: 0x060389B0 RID: 231856 RVA: 0x00E575E4 File Offset: 0x00E557E4
		public void ResumeMovieCamera()
		{
			ModelBase<CameraModel>.Instance.MainModel.ResumeMovieCamera();
			Singleton<global::Log>.Instance.Info(ELogModule.MovieMode, ELogAuthor.CB, "[电影镜头]通过MovieModeController恢复电影镜头播放", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060389B1 RID: 231857 RVA: 0x00E57620 File Offset: 0x00E55820
		public UniTask PlaySpecialMovieCamera(string specialRowName)
		{
			MovieModeController.<PlaySpecialMovieCamera>d__29 <PlaySpecialMovieCamera>d__;
			<PlaySpecialMovieCamera>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySpecialMovieCamera>d__.specialRowName = specialRowName;
			<PlaySpecialMovieCamera>d__.<>1__state = -1;
			<PlaySpecialMovieCamera>d__.<>t__builder.Start<MovieModeController.<PlaySpecialMovieCamera>d__29>(ref <PlaySpecialMovieCamera>d__);
			return <PlaySpecialMovieCamera>d__.<>t__builder.Task;
		}

		// Token: 0x060389B2 RID: 231858 RVA: 0x00E57663 File Offset: 0x00E55863
		public bool IsPlayingSpecialMovieCamera(string specialRowName)
		{
			return ModelBase<CameraModel>.Instance.MainModel.IsPlayingSpecialMovieCamera(specialRowName);
		}

		// Token: 0x060389B3 RID: 231859 RVA: 0x00E57675 File Offset: 0x00E55875
		public void ResetMovieModeHideUi(bool isHide)
		{
			if (ModelBase<MovieModeModel>.Instance.IsFreezingUi)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.MovieModeHideUiChange, isHide);
			MovieModeUiView movieModeUiView = this.MovieModeUiView;
			if (movieModeUiView == null)
			{
				return;
			}
			movieModeUiView.ActivateTimer();
		}

		// Token: 0x060389B4 RID: 231860 RVA: 0x00E576A8 File Offset: 0x00E558A8
		private void PlotSequenceStarted()
		{
			MovieModeUiView movieModeUiView = this.MovieModeUiView;
			if (movieModeUiView != null)
			{
				movieModeUiView.SetUiActive(false);
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MovieMode;
			ELogAuthor author = ELogAuthor.CB;
			string message = "电影模式UI显示状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isActive", false);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.IsAutoExitInFlowSequence)
			{
				this.ExitMovieMode(new ExitMovieModeParams
				{
					BlendTime = 0f
				}, null).Forget();
				this.IsAutoExitInFlowSequence = false;
			}
		}

		// Token: 0x060389B5 RID: 231861 RVA: 0x00E57724 File Offset: 0x00E55924
		private void PlotSequenceEnd()
		{
			MovieModeUiView movieModeUiView = this.MovieModeUiView;
			if (movieModeUiView != null)
			{
				movieModeUiView.SetUiActive(true);
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MovieMode;
			ELogAuthor author = ELogAuthor.CB;
			string message = "电影模式UI显示状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("isActive", true);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060389B6 RID: 231862 RVA: 0x00E57772 File Offset: 0x00E55972
		public void ClearViews()
		{
			if (this.MovieModeAspectView != null)
			{
				this.MovieModeAspectView.Destroy(null);
				this.MovieModeAspectView = null;
			}
			if (this.MovieModeUiView != null)
			{
				this.MovieModeUiView.Destroy(null);
				this.MovieModeUiView = null;
			}
			this.CurrentState = EMovieModeState.Idle;
		}

		// Token: 0x060389B7 RID: 231863 RVA: 0x00E577B1 File Offset: 0x00E559B1
		public bool IsInMovieMode()
		{
			return this.CurrentState > EMovieModeState.Idle;
		}

		// Token: 0x060389B8 RID: 231864 RVA: 0x00E577BC File Offset: 0x00E559BC
		protected override bool OnClear()
		{
			this.ClearViews();
			this.TickGroup.Clear();
			return true;
		}

		// Token: 0x040204AC RID: 132268
		[Nullable(2)]
		private MovieModeAspectView MovieModeAspectView;

		// Token: 0x040204AD RID: 132269
		[Nullable(2)]
		private MovieModeUiView MovieModeUiView;

		// Token: 0x040204AE RID: 132270
		private int TickHandleId;

		// Token: 0x040204AF RID: 132271
		private readonly Dictionary<int, Action<float>> TickGroup = new Dictionary<int, Action<float>>();

		// Token: 0x040204B0 RID: 132272
		private EMovieModeState CurrentState;

		// Token: 0x040204B1 RID: 132273
		private bool IsAutoExitInFlowSequence;
	}
}
