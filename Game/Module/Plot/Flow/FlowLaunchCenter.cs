using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Sequence.Manager;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.GameSettings;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005402 RID: 21506
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowLaunchCenter : ControllerAssistantBase, IStaticVariableResetter
	{
		// Token: 0x06036E94 RID: 224916 RVA: 0x00DECE53 File Offset: 0x00DEB053
		protected override void OnDestroy()
		{
		}

		// Token: 0x06036E95 RID: 224917 RVA: 0x00DECE55 File Offset: 0x00DEB055
		static FlowLaunchCenter()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FlowLaunchCenter.CreateStaticDefaultValue), new Action(FlowLaunchCenter.ResetStaticDefaultValue));
		}

		// Token: 0x06036E96 RID: 224918 RVA: 0x00DECE74 File Offset: 0x00DEB074
		public static void CreateStaticDefaultValue()
		{
			FlowLaunchCenter.LocalFlowIncId = -1;
		}

		// Token: 0x06036E97 RID: 224919 RVA: 0x00DECE7C File Offset: 0x00DEB07C
		public static void ResetStaticDefaultValue()
		{
			FlowLaunchCenter.LocalFlowIncId = -1;
		}

		// Token: 0x06036E98 RID: 224920 RVA: 0x00DECE84 File Offset: 0x00DEB084
		protected override void OnInit()
		{
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.LoadingDone, "场景未加载完", this.OnCheckLoading));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.UiReady, "界面检查不通过", new Func<float, PlotInfo, bool>(this.OnCheckUi)));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.TeleportDone, "传送未完成", this.OnCheckTeleport));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.AllPlayerAlive, "死亡或者队伍没人", this.OnCheckAllPlayerAlive));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.CurPlayerAlive, "当前角色死亡", this.OnCheckCurPlayerAlive));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.FormationReady, "编队未准备好", new Func<float, PlotInfo, bool>(this.OnCheckFormation)));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.CharAnimReady, "人物动作还没回正", new Func<float, PlotInfo, bool>(this.OnCheckCharAnim)));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.PreloadReady, "预加载未完成", this.OnCheckPreload));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.PlotCaption, "处于报幕中", this.OnCheckPlotCaption));
			this.CheckList.Add(new ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>(FlowLaunchCenter.ECheckType.TransitionFlowWaitWorldDoneEnd, "个别传送过渡Seq要在WorldDoneEnd后", new Func<float, PlotInfo, bool>(this.OnCheckTransitionFlowWaitWorldDoneEnd)));
			for (int i = 0; i < this.CheckList.Count; i++)
			{
				if (this.CheckList[i].Item1 != (FlowLaunchCenter.ECheckType)i)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "剧情开始检查队列顺序错误";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", i);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x06036E99 RID: 224921 RVA: 0x00DED018 File Offset: 0x00DEB218
		[NullableContext(2)]
		public unsafe long StartFlow([Nullable(1)] string flowListName, int flowId, int stateId, GeneralContext context = null, long flowIncId = -1L, bool isServerNotify = false, bool isAsync = false, UiParam uiParam = null, bool canBeAbandoned = false, bool isSkip = false, Vector pos = null, Action callback = null, bool isTeleportTransition = false)
		{
			List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flowListName, flowId, stateId);
			if (flowStateActions == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[StartFlow] 无法找到对应剧情的状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", flowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", flowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", stateId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return 0L;
			}
			long num = isServerNotify ? flowIncId : ((long)FlowLaunchCenter.LocalFlowIncId--);
			GeneralContext context2 = (context != null) ? GeneralContext.Copy(context) : null;
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "StartFlow";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("FLowIncId", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowListName", flowListName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("FlowId", flowId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("StateId", stateId);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			Singleton<EventSystem>.Instance.Emit<long>(EEventName.OnStartFlow, num);
			bool? flowStateKeepMusic = ConfigBase<FlowConfig>.Instance.GetFlowStateKeepMusic(flowListName, flowId, stateId);
			IStateProgramSpecialProcessChangeTeamOptimization flowProgramSpecialProcess = ConfigBase<FlowConfig>.Instance.GetFlowProgramSpecialProcess(flowListName, flowId, stateId);
			bool? flowNeedLoad = ConfigBase<FlowConfig>.Instance.GetFlowNeedLoad(flowListName, flowId, stateId);
			bool flag = ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode() || ModelBase<PlotModel>.Instance.IsMuteAllPlot || isSkip;
			if (flowNeedLoad.GetValueOrDefault() && !flag)
			{
				ControllerBase<PreloadControllerNew>.Instance.PreloadPlot(flowListName, flowId, stateId, 999);
				ControllerBase<PreloadControllerNew>.Instance.PreloadPlotUi(flowListName, flowId, stateId);
			}
			PlotInfo plotInfo = PlotInfo.Create();
			plotInfo.Init(isServerNotify, num, flowListName, flowId, stateId, flowStateActions, flowStateKeepMusic.GetValueOrDefault(), context2, isAsync, uiParam, canBeAbandoned, isSkip, pos, flowNeedLoad.GetValueOrDefault(), callback, isTeleportTransition, flowProgramSpecialProcess);
			ModelBase<PlotModel>.Instance.IsTeleportTransitionSeq = isTeleportTransition;
			if (this.CheckStateCanPlay(plotInfo, 0f))
			{
				this.StartFlowByPlotInfo(plotInfo);
			}
			else
			{
				ModelBase<PlotModel>.Instance.PendingPlot(plotInfo);
				this.NeedPlay = true;
				ControllerBase<FlowController>.Instance.CheckDisableInput(new EPlotLevel?(plotInfo.PlotLevel));
			}
			ModelBase<PlotModel>.Instance.AnsPreloadMark = false;
			ControllerBase<PlotController>.Instance.ClearAnsPreloadGuaranteeCache();
			return num;
		}

		// Token: 0x06036E9A RID: 224922 RVA: 0x00DED288 File Offset: 0x00DEB488
		public unsafe void StartPlotNetworkPending()
		{
			if (ModelBase<PlotModel>.Instance.IsInPlot)
			{
				return;
			}
			if (ModelBase<PlotModel>.Instance.PlotPendingList.Count == 0)
			{
				return;
			}
			PlotInfo plotInfo = ModelBase<PlotModel>.Instance.PlotPendingList[0];
			if (!this.CheckStateCanPlay(plotInfo, 0f))
			{
				this.NeedPlay = true;
				return;
			}
			ModelBase<PlotModel>.Instance.PlotPendingList.RemoveAt(0);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "开始缓存的剧情";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowIncId", plotInfo.FlowIncId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowListName", plotInfo.FlowListName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", plotInfo.FlowId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("StateID", plotInfo.StateId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			this.StartFlowByPlotInfo(plotInfo);
		}

		// Token: 0x06036E9B RID: 224923 RVA: 0x00DED398 File Offset: 0x00DEB598
		public unsafe void Tick(float delta)
		{
			if (!this.NeedPlay)
			{
				return;
			}
			PlotInfo plotInfo = (ModelBase<PlotModel>.Instance.PlotPendingList.Count > 0) ? ModelBase<PlotModel>.Instance.PlotPendingList[0] : null;
			if (plotInfo == null)
			{
				this.NeedPlay = false;
				return;
			}
			if (this.CheckStateCanPlay(plotInfo, delta))
			{
				ModelBase<PlotModel>.Instance.PlotPendingList.RemoveAt(0);
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "开始缓存的剧情";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowIncId", plotInfo.FlowIncId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowListName", plotInfo.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", plotInfo.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("StateID", plotInfo.StateId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				this.NeedPlay = false;
				this.StartFlowByPlotInfo(plotInfo);
			}
		}

		// Token: 0x06036E9C RID: 224924 RVA: 0x00DED4B0 File Offset: 0x00DEB6B0
		private unsafe bool CheckStateCanPlay(PlotInfo plotInfo, float deltaTime = 0f)
		{
			if (plotInfo.IsBreakdown)
			{
				this.CurCheckType = FlowLaunchCenter.ECheckType.None;
				return true;
			}
			if (this.CurCheckType != FlowLaunchCenter.ECheckType.None && !this.CheckList[(int)this.CurCheckType].Item3(deltaTime, plotInfo))
			{
				return false;
			}
			foreach (ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>> valueTuple in this.CheckList)
			{
				if (valueTuple.Item1 != this.CurCheckType && !valueTuple.Item3(deltaTime, plotInfo))
				{
					this.CurCheckType = valueTuple.Item1;
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "剧情开始检查不通过";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", valueTuple.Item2);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IncId", plotInfo.FlowIncId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
			}
			this.CurCheckType = FlowLaunchCenter.ECheckType.None;
			return true;
		}

		// Token: 0x06036E9D RID: 224925 RVA: 0x00DED5DC File Offset: 0x00DEB7DC
		private unsafe bool OnCheckUi(float delta, PlotInfo plotInfo)
		{
			if (ControllerBase<BlackScreenFadeController>.Instance.GetIsFadeIn() && ControllerBase<BlackScreenFadeController>.Instance.CheckIfInCommon())
			{
				this.UiCheckTime = 0f;
				return true;
			}
			if (plotInfo.Seamless)
			{
				return true;
			}
			UiParam uiParam = plotInfo.UiParam;
			if (uiParam != null && uiParam.ViewName != null)
			{
				EUiViewName? euiViewName = (plotInfo.UiParam.ViewName == EUiViewName.BattleView) ? new EUiViewName?(Singleton<UiModel>.Instance.MainViewName) : plotInfo.UiParam.ViewName;
				if (Singleton<UiManager>.Instance.IsViewShow(euiViewName.Value))
				{
					this.UiCheckTime = 0f;
					return true;
				}
				this.UiCheckTime += delta;
				if (plotInfo.CanBeAbandoned || this.UiCheckTime >= 20000f)
				{
					plotInfo.IsBreakdown = true;
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "剧情检查条件不通过，且允许被舍弃，丢了";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("incId", plotInfo.FlowIncId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("flowListName", plotInfo.FlowListName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("flowId", plotInfo.FlowId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("stateId", plotInfo.StateId);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					this.UiCheckTime = 0f;
					return true;
				}
				return false;
			}
			else
			{
				UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Plot);
				EUiViewName? euiViewName2;
				if (topView == null)
				{
					euiViewName2 = null;
				}
				else
				{
					UiViewInfo viewInfo = topView.ViewInfo;
					euiViewName2 = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
				}
				EUiViewName? euiViewName3 = euiViewName2;
				EUiViewName? euiViewName4;
				if (euiViewName3 == null)
				{
					UiViewBase topView2 = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
					if (topView2 == null)
					{
						euiViewName4 = null;
					}
					else
					{
						UiViewInfo viewInfo2 = topView2.ViewInfo;
						euiViewName4 = ((viewInfo2 != null) ? new EUiViewName?(viewInfo2.Name) : null);
					}
				}
				else
				{
					euiViewName4 = euiViewName3;
				}
				EUiViewName? euiViewName5 = euiViewName4;
				if (euiViewName5 == null)
				{
					return false;
				}
				if (this.EnableView.Contains(euiViewName5.Value))
				{
					return Singleton<UiManager>.Instance.IsViewShow(euiViewName5.Value);
				}
				return Singleton<UiManager>.Instance.CheckIfCanShowPlotView() || ModelBase<ScreenEffectModel>.Instance.GetIsGeneralScreenEffectActive();
			}
		}

		// Token: 0x06036E9E RID: 224926 RVA: 0x00DED85A File Offset: 0x00DEBA5A
		private bool OnCheckFormation(float delta, PlotInfo plotInfo)
		{
			return ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode() || this.TempSkipFormationCheck.Contains(plotInfo.FormatId) || ModelBase<SceneTeamModel>.Instance.IsTeamReady;
		}

		// Token: 0x06036E9F RID: 224927 RVA: 0x00DED88C File Offset: 0x00DEBA8C
		private bool OnCheckCharAnim(float delta, PlotInfo plotInfo)
		{
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				return true;
			}
			if (plotInfo.PlotLevel != EPlotLevel.LevelC && !plotInfo.IsWaitAnim)
			{
				return true;
			}
			if (this.DeltaForCalm > ModelBase<PlotModel>.Instance.PlotGlobalConfig.WaitCalmTime)
			{
				this.DeltaForCalm = 0f;
				return true;
			}
			BaseTagComponent baseTagComponent = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.CheckGetComponent<BaseTagComponent>();
			if (baseTagComponent == null || !baseTagComponent.Valid)
			{
				this.DeltaForCalm = 0f;
				return true;
			}
			if (!baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
			{
				this.DeltaForCalm = 0f;
				return true;
			}
			this.DeltaForCalm += delta;
			return false;
		}

		// Token: 0x06036EA0 RID: 224928 RVA: 0x00DED944 File Offset: 0x00DEBB44
		private bool OnCheckTransitionFlowWaitWorldDoneEnd(float delta, PlotInfo plotInfo)
		{
			if (!this.TransitionFlowNeedWaitForWorldDoneEnd.Contains(plotInfo.FormatId))
			{
				return true;
			}
			ELoadingPhase loadingPhase = ModelBase<GameModeModel>.Instance.LoadingPhase;
			return loadingPhase <= ELoadingPhase.Finished || loadingPhase >= ELoadingPhase.WorldDoneEnd;
		}

		// Token: 0x06036EA1 RID: 224929 RVA: 0x00DED97F File Offset: 0x00DEBB7F
		public static void ApplyTemporaryLowQuality()
		{
			GameSettingsUtils.ApplyImageQualityOnly(0);
			GameSettingsUtils.ApplyVegetationDensity(0);
			GameSettingsUtils.ApplySkinDamageMode(0);
			GameSettingsUtils.ApplyBloomEnable(0);
			GameSettingsUtils.ApplyImageDetail(0);
			GameSettingsUtils.ApplyNiagaraQuality(0);
			GameSettingsUtils.ApplyMobileResolution(0);
		}

		// Token: 0x06036EA2 RID: 224930 RVA: 0x00DED9B4 File Offset: 0x00DEBBB4
		public static void ReApplyTemporaryLowQuality()
		{
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.IMAGEQUALITY, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.VegetationDensity, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.SkinDamageMode, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.BLOOM, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.IMAGEDETAIL, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.SHADOWQUALITY, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.NIAGARAQUALITY, EGameSettingsApplyReason.AnyTime, true);
			Singleton<GameSettingsManager>.Instance.ReApply(EFunction.MOBILERESOLUTION, EGameSettingsApplyReason.AnyTime, true);
		}

		// Token: 0x06036EA3 RID: 224931 RVA: 0x00DEDA44 File Offset: 0x00DEBC44
		private unsafe void StartFlowByPlotInfo(PlotInfo plotInfo)
		{
			if (ModelBase<PlotModel>.Instance.IsInInteraction)
			{
				ControllerBase<PlotController>.Instance.EndInteraction(true, false);
			}
			if (!ModelBase<PlotModel>.Instance.CheckCanPlayNow(plotInfo))
			{
				return;
			}
			ControllerBase<PlotController>.Instance.OnStartPlotNetwork(plotInfo);
			bool flag = ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode() || ModelBase<PlotModel>.Instance.IsMuteAllPlot || plotInfo.IsBackground;
			if (flag)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "剧情开始时被跳过";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsInLogicTreeGmMode", ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsMuteAllPlot", ModelBase<PlotModel>.Instance.IsMuteAllPlot);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsBackground", plotInfo.IsBackground);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			FlowContext flowContext = FlowContext.Create();
			flowContext.Init(plotInfo, flag);
			if (this.TempEnablePlotStreamingSource.Contains(flowContext.FormatId))
			{
				ControllerBase<PlotController>.Instance.TogglePlotStreamingSource(true);
			}
			Vector vector;
			if (this.IndependentStreamingSource.TryGetValue(flowContext.FormatId, out vector))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.HWK;
				string message2 = "使用独立流源Start";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("id", flowContext.FormatId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("pos", vector);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				ControllerBase<PlotController>.Instance.TogglePlotIndependentStreaming(true, vector);
			}
			if (FlowLaunchResCheckHardCodingList.TempDisableWorldOffsetZ.Contains(flowContext.FormatId))
			{
				ControllerBase<WorldController>.Instance.SetEnableZAxisOffset(false, "剧情流程开始");
			}
			if (Singleton<Info>.Instance.IsLowMemoryDevice && this.LowQualityPlot.Contains(flowContext.FormatId))
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Plot;
				ELogAuthor author3 = ELogAuthor.FZX;
				string message3 = "LowQualityPlot";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", flowContext.FormatId);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				FlowLaunchCenter.ApplyTemporaryLowQuality();
			}
			if (this.DebugProtectedPlot.Contains(flowContext.FormatId))
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.Plot;
				ELogAuthor author4 = ELogAuthor.FZX;
				string message4 = "DebugProtectedPlot";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("id", flowContext.FormatId);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.DebugProtectedPlotTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					ControllerBase<PlotController>.Instance.CloseAllUi(null);
					ControllerBase<FlowController>.Instance.BackgroundFlow("DebugProtectedPlot", true, false, false);
				}, 30000f, null, null, true, 1f);
			}
			BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
			if (bpEventManager != null)
			{
				bpEventManager.演出状态改变时.Broadcast(flowContext.FormatId, EPlotState.Start);
			}
			ControllerBase<FlowController>.Instance.ExecuteActions(plotInfo.StateActions, flowContext, delegate
			{
				if (this.TempEnablePlotStreamingSource.Contains(flowContext.FormatId))
				{
					ControllerBase<PlotController>.Instance.TogglePlotStreamingSource(false);
				}
				if (this.IndependentStreamingSource.ContainsKey(flowContext.FormatId))
				{
					ControllerBase<PlotController>.Instance.TogglePlotIndependentStreaming(false, null);
					global::Log instance5 = Singleton<global::Log>.Instance;
					ELogModule module5 = ELogModule.Plot;
					ELogAuthor author5 = ELogAuthor.HWK;
					string message5 = "使用独立流源End";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("id", flowContext.FormatId);
					instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
				if (FlowLaunchResCheckHardCodingList.TempDisableWorldOffsetZ.Contains(flowContext.FormatId))
				{
					ControllerBase<WorldController>.Instance.SetEnableZAxisOffset(true, "剧情流程结束");
				}
				if (Singleton<Info>.Instance.IsLowMemoryDevice && this.LowQualityPlot.Contains(flowContext.FormatId))
				{
					global::Log instance6 = Singleton<global::Log>.Instance;
					ELogModule module6 = ELogModule.Plot;
					ELogAuthor author6 = ELogAuthor.FZX;
					string message6 = "LowQualityPlot恢复";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("id", flowContext.FormatId);
					instance6.Info(module6, author6, message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					FlowLaunchCenter.ReApplyTemporaryLowQuality();
				}
				TimerHandle debugProtectedPlotTimer = this.DebugProtectedPlotTimer;
				if (debugProtectedPlotTimer != null)
				{
					debugProtectedPlotTimer.Remove();
				}
				this.DebugProtectedPlotTimer = null;
				ControllerBase<PlotController>.Instance.OnEndPlotNetwork();
				BP_EventManager_C bpEventManager2 = GlobalData.BpEventManager;
				if (bpEventManager2 != null)
				{
					bpEventManager2.演出状态改变时.Broadcast(flowContext.FormatId, EPlotState.End);
				}
				if (flowContext.Callback != null)
				{
					flowContext.Callback();
					flowContext.Callback = null;
					global::Log instance7 = Singleton<global::Log>.Instance;
					ELogModule module7 = ELogModule.Plot;
					ELogAuthor author7 = ELogAuthor.JYS;
					string message7 = "执行了flowContext的Callback";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("incId", flowContext.FlowIncId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("id", flowContext.FormatId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("IsSkip", flowContext.IsBackground);
					instance7.Info(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				}
				global::Log instance8 = Singleton<global::Log>.Instance;
				ELogModule module8 = ELogModule.Plot;
				ELogAuthor author8 = ELogAuthor.FZX;
				string message8 = "EndFlow";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("incId", flowContext.FlowIncId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("id", flowContext.FormatId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("IsSkip", flowContext.IsBackground);
				instance8.Info(module8, author8, message8, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
				flowContext.Recycle();
				this.StartPlotNetworkPending();
			});
			plotInfo.Recycle();
		}

		// Token: 0x0401F9B7 RID: 129463
		private static int LocalFlowIncId;

		// Token: 0x0401F9B8 RID: 129464
		private bool NeedPlay;

		// Token: 0x0401F9B9 RID: 129465
		private float DeltaForCalm;

		// Token: 0x0401F9BA RID: 129466
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			1
		})]
		private readonly List<ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>> CheckList = new List<ValueTuple<FlowLaunchCenter.ECheckType, string, Func<float, PlotInfo, bool>>>();

		// Token: 0x0401F9BB RID: 129467
		private FlowLaunchCenter.ECheckType CurCheckType = FlowLaunchCenter.ECheckType.None;

		// Token: 0x0401F9BC RID: 129468
		private readonly Func<float, PlotInfo, bool> OnCheckLoading = delegate(float delta, PlotInfo plotInfo)
		{
			if (plotInfo.IsTeleportTransition)
			{
				return true;
			}
			if (ModelBase<LoadingModel>.Instance.IsLoading || !ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
			{
				if (plotInfo.FadeBegin != null)
				{
					Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "Loading期间准备播剧情，提前打开黑幕", default(ReadOnlySpan<ValueTuple<string, object>>));
					ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "Flow_CheckLoading", null, new object[]
					{
						0,
						plotInfo.FadeBegin,
						false,
						false
					});
					plotInfo.FadeBegin = null;
				}
				return false;
			}
			return true;
		};

		// Token: 0x0401F9BD RID: 129469
		private readonly HashSet<EUiViewName> EnableView = new HashSet<EUiViewName>
		{
			EUiViewName.PlotView,
			EUiViewName.PlotSubtitleView
		};

		// Token: 0x0401F9BE RID: 129470
		private float UiCheckTime;

		// Token: 0x0401F9BF RID: 129471
		private readonly Func<float, PlotInfo, bool> OnCheckTeleport = (float delta, PlotInfo plotInfo) => plotInfo.IsTeleportTransition || !ModelBase<TeleportModel>.Instance.IsTeleport;

		// Token: 0x0401F9C0 RID: 129472
		private readonly Func<float, PlotInfo, bool> OnCheckAllPlayerAlive = (float delta, PlotInfo plotInfo) => ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode() || !ModelBase<SceneTeamModel>.Instance.IsAllDid();

		// Token: 0x0401F9C1 RID: 129473
		private readonly Func<float, PlotInfo, bool> OnCheckCurPlayerAlive = delegate(float delta, PlotInfo plotInfo)
		{
			if (ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode())
			{
				return true;
			}
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			return getCurrentTeamItem != null && !getCurrentTeamItem.IsDead();
		};

		// Token: 0x0401F9C2 RID: 129474
		private readonly Func<float, PlotInfo, bool> OnCheckPreload = delegate(float delta, PlotInfo plotInfo)
		{
			ELoadResultType eloadResultType;
			return !plotInfo.CheckPreload || ((!ModelBase<PreloadModelNew>.Instance.PlotAssetManager.LoadStateMap.TryGetValue(plotInfo.FormatId, out eloadResultType) || eloadResultType != ELoadResultType.Loading) && !ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.IsLoading(plotInfo.FormatId) && !ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.IsHanging(plotInfo.FormatId));
		};

		// Token: 0x0401F9C3 RID: 129475
		private readonly Func<float, PlotInfo, bool> OnCheckPlotCaption = (float delta, PlotInfo plotInfo) => !ControllerBase<PlotCaptionImageController>.Instance.IsInPlotCaption;

		// Token: 0x0401F9C4 RID: 129476
		private readonly HashSet<string> TempEnablePlotStreamingSource = new HashSet<string>
		{
			"剧情_2_6_狄斯台地主线_上半_1,25,1",
			"剧情_2_0_黎那汐塔主线_第一幕,1,1"
		};

		// Token: 0x0401F9C5 RID: 129477
		private readonly Dictionary<string, Vector> IndependentStreamingSource = new Dictionary<string, Vector>
		{
			{
				"剧情_2_5_隐海试验场_声骸培养场,1,23",
				Vector.Create(194400.0, 155500.0, -165850.0)
			},
			{
				"剧情_2_5_隐海试验场_声骸培养场,1,9",
				Vector.Create(161705.0, 133164.0, -166068.0)
			},
			{
				"剧情_2_5_隐海试验场_声骸培养场,6,1",
				Vector.Create(345600.0, -6581.0, -165980.0)
			}
		};

		// Token: 0x0401F9C6 RID: 129478
		private readonly HashSet<string> LowQualityPlot = new HashSet<string>
		{
			"剧情_3_0_主线_拉海洛主线_上半_1,35,1"
		};

		// Token: 0x0401F9C7 RID: 129479
		private readonly HashSet<string> TransitionFlowNeedWaitForWorldDoneEnd = new HashSet<string>
		{
			"剧情_3_4_拉海洛主线,13,1",
			"剧情_3_4_拉海洛主线,6,2"
		};

		// Token: 0x0401F9C8 RID: 129480
		private readonly HashSet<string> TempSkipFormationCheck = new HashSet<string>
		{
			"剧情_3_5_穗穗线_玩法副本_1,2,18",
			"剧情_3_5_穗穗线_玩法副本_1,1,9"
		};

		// Token: 0x0401F9C9 RID: 129481
		private readonly HashSet<string> DebugProtectedPlot = new HashSet<string>
		{
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,1",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,2",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,3",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,4",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,5",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,6",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,7",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,8",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,9",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,11",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,12",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,13",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,14",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,15",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,16",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,17",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,18",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,22",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,23",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,24",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,25",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,26",
			"剧情_2_7_狄斯台地主线_上半_巡游天国,33,27",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,1,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,1,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,1,3",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,1,4",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,2,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,2,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,3,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,3,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,4,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,4,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,5,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,5,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,6,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,6,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,6,3",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,6,4",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,7,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,7,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,8,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,8,2",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,9,1",
			"剧情_2.8_穗波怪异物语（战中语音对话文本）,9,2"
		};

		// Token: 0x0401F9CA RID: 129482
		[Nullable(2)]
		private TimerHandle DebugProtectedPlotTimer;

		// Token: 0x0200B392 RID: 45970
		[NullableContext(0)]
		private enum ECheckType
		{
			// Token: 0x040379FE RID: 227838
			LoadingDone,
			// Token: 0x040379FF RID: 227839
			UiReady,
			// Token: 0x04037A00 RID: 227840
			TeleportDone,
			// Token: 0x04037A01 RID: 227841
			AllPlayerAlive,
			// Token: 0x04037A02 RID: 227842
			CurPlayerAlive,
			// Token: 0x04037A03 RID: 227843
			FormationReady,
			// Token: 0x04037A04 RID: 227844
			CharAnimReady,
			// Token: 0x04037A05 RID: 227845
			PreloadReady,
			// Token: 0x04037A06 RID: 227846
			PlotCaption,
			// Token: 0x04037A07 RID: 227847
			TransitionFlowWaitWorldDoneEnd,
			// Token: 0x04037A08 RID: 227848
			None
		}
	}
}
