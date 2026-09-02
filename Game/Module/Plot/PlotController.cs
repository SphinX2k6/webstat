using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.GravityFlip;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Ui;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005355 RID: 21333
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class PlotController : UiControllerBase<PlotController>
	{
		// Token: 0x06036695 RID: 222869 RVA: 0x00DB886C File Offset: 0x00DB6A6C
		protected override bool OnInit()
		{
			this.IsInPlotProtect = false;
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(ModelBase<PlotModel>.Instance.PlotGlobalConfig.PlotGoBattleMaterialPath, delegate([Nullable(2)] PD_CharacterControllerData_C effect, string _)
			{
				if (effect == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "剧情切人效果资产加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", ModelBase<PlotModel>.Instance.PlotGlobalConfig.PlotGoBattleMaterialPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				ModelBase<PlotModel>.Instance.GoBattleMaterial = effect;
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x06036696 RID: 222870 RVA: 0x00DB88C1 File Offset: 0x00DB6AC1
		protected override void OnTick(float delta)
		{
			this.TickAll(delta);
			ModelBase<PlotModel>.Instance.PlotWeather.OnTick(delta);
			ModelBase<PlotModel>.Instance.PlotTemplate.OnTick(delta);
			ModelBase<PlotModel>.Instance.PlotCleanRange.OnTick((double)delta);
		}

		// Token: 0x06036697 RID: 222871 RVA: 0x00DB88FC File Offset: 0x00DB6AFC
		public unsafe void TickPriority2(float delta)
		{
			if (this.TickGroupPriority2.Count <= 0)
			{
				return;
			}
			this.TickGroupPriority2IdBuffer.Clear();
			this.TickGroupPriority2IdBuffer.AddRange(this.NextPriority2IdList);
			for (int i = 0; i < this.TickGroupPriority2IdBuffer.Count; i++)
			{
				int num = this.TickGroupPriority2IdBuffer[i];
				try
				{
					this.TickGroupPriority2[num](delta);
				}
				catch (Exception item)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "PlotController TickPriority2 异常";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", num);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", item);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			if (this.TickGroupPriority2IdBuffer.Count > 0)
			{
				foreach (int num2 in this.TickGroupPriority2IdBuffer)
				{
					this.TickGroupPriority2.Remove(num2);
					this.NextPriority2IdList.Remove(num2);
				}
			}
		}

		// Token: 0x06036698 RID: 222872 RVA: 0x00DB8A44 File Offset: 0x00DB6C44
		public int AddTickPriority2(Action<float> handle)
		{
			this.TickPriority2HandleId++;
			this.TickGroupPriority2[this.TickPriority2HandleId] = handle;
			return this.TickPriority2HandleId;
		}

		// Token: 0x06036699 RID: 222873 RVA: 0x00DB8A6C File Offset: 0x00DB6C6C
		public void RemoveTickPriority2(int id)
		{
			this.NextPriority2IdList.Remove(id);
			this.TickGroupPriority2.Remove(id);
		}

		// Token: 0x0603669A RID: 222874 RVA: 0x00DB8A88 File Offset: 0x00DB6C88
		public int NextPriority2(Action<float> handle)
		{
			int num = this.AddTickPriority2(handle);
			this.NextPriority2IdList.Add(num);
			return num;
		}

		// Token: 0x0603669B RID: 222875 RVA: 0x00DB8AAC File Offset: 0x00DB6CAC
		public new void AfterTick(float delta)
		{
			if (this.TickGroupAfterTick.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, Action<float>> keyValuePair in this.TickGroupAfterTick)
			{
				keyValuePair.Value(delta);
			}
			if (this.NextAfterTickIdList.Count > 0)
			{
				foreach (int key in this.NextAfterTickIdList)
				{
					this.TickGroupAfterTick.Remove(key);
				}
				this.NextAfterTickIdList.Clear();
			}
		}

		// Token: 0x0603669C RID: 222876 RVA: 0x00DB8B78 File Offset: 0x00DB6D78
		public int AddAfterTick(Action<float> handle)
		{
			this.AfterTickHandleId++;
			this.TickGroupAfterTick[this.AfterTickHandleId] = handle;
			return this.AfterTickHandleId;
		}

		// Token: 0x0603669D RID: 222877 RVA: 0x00DB8BA0 File Offset: 0x00DB6DA0
		public void RemoveAfterTick(int id)
		{
			this.NextAfterTickIdList.Remove(id);
			this.TickGroupAfterTick.Remove(id);
		}

		// Token: 0x0603669E RID: 222878 RVA: 0x00DB8BBC File Offset: 0x00DB6DBC
		public int NextAfterTick(Action<float> handle)
		{
			int num = this.AddAfterTick(handle);
			this.NextAfterTickIdList.Add(num);
			return num;
		}

		// Token: 0x0603669F RID: 222879 RVA: 0x00DB8BE0 File Offset: 0x00DB6DE0
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.GeneralLogicTreePrepareRollback, new Action<int>(this.ObBtBack));
			Singleton<Net>.Instance.Register<RemovePreloadFlowsNotify>(ENotifyMessageId.RemovePreloadFlowsNotify, new Action<RemovePreloadFlowsNotify, Net.CallbackStatus>(this.OnServerNotifyRemovePreloadFlows));
			this.PlotViewManager.RegisterEvent();
		}

		// Token: 0x060366A0 RID: 222880 RVA: 0x00DB8CF4 File Offset: 0x00DB6EF4
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStartLoadingState, new Action(this.OnOpenLoading));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.GeneralLogicTreePrepareRollback, new Action<int>(this.ObBtBack));
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RemovePreloadFlowsNotify);
			this.PlotViewManager.UnRegisterEvent();
		}

		// Token: 0x060366A1 RID: 222881 RVA: 0x00DB8DFC File Offset: 0x00DB6FFC
		protected override bool OnClear()
		{
			this.ClearAnsPreloadGuaranteeCache();
			return true;
		}

		// Token: 0x060366A2 RID: 222882 RVA: 0x00DB8E08 File Offset: 0x00DB7008
		public void TogglePlotStreamingSource(bool enable)
		{
			AActor cineCamera = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera;
			if (this.PlotStreamingSource == null || !this.PlotStreamingSource.IsValid())
			{
				GameModeModel instance = ModelBase<GameModeModel>.Instance;
				this.PlotStreamingSource = ((instance != null) ? instance.CreateShapedStreamingSource(100, 1f) : null);
				if (this.PlotStreamingSource != null)
				{
					this.PlotStreamingSource.K2_AttachToActor(cineCamera, null, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
				}
			}
			AActor plotStreamingSource = this.PlotStreamingSource;
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = ((plotStreamingSource != null) ? plotStreamingSource.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) : null) as UWorldPartitionStreamingSourceComponent;
			if (enable)
			{
				if (uworldPartitionStreamingSourceComponent != null)
				{
					uworldPartitionStreamingSourceComponent.EnableStreamingSource();
				}
				return;
			}
			if (uworldPartitionStreamingSourceComponent != null)
			{
				uworldPartitionStreamingSourceComponent.DisableStreamingSource();
			}
		}

		// Token: 0x060366A3 RID: 222883 RVA: 0x00DB8EBC File Offset: 0x00DB70BC
		[NullableContext(2)]
		public void TogglePlotIndependentStreaming(bool enable, global::Vector position = null)
		{
			if (this.PlotIndependentStreamingSource == null || !this.PlotIndependentStreamingSource.IsValid())
			{
				GameModeModel instance = ModelBase<GameModeModel>.Instance;
				this.PlotIndependentStreamingSource = ((instance != null) ? instance.CreateShapedStreamingSource(360, 1f) : null);
			}
			AActor plotIndependentStreamingSource = this.PlotIndependentStreamingSource;
			UWorldPartitionStreamingSourceComponent uworldPartitionStreamingSourceComponent = ((plotIndependentStreamingSource != null) ? plotIndependentStreamingSource.GetComponentByClass(UWorldPartitionStreamingSourceComponent.StaticClass()) : null) as UWorldPartitionStreamingSourceComponent;
			if (enable && position != null)
			{
				FHitResult fhitResult = new FHitResult();
				AActor plotIndependentStreamingSource2 = this.PlotIndependentStreamingSource;
				if (plotIndependentStreamingSource2 != null)
				{
					plotIndependentStreamingSource2.D_K2_SetActorLocation(position.ToUeVector(false), false, ref fhitResult, false);
				}
				if (uworldPartitionStreamingSourceComponent != null)
				{
					uworldPartitionStreamingSourceComponent.EnableStreamingSource();
				}
				return;
			}
			if (uworldPartitionStreamingSourceComponent != null)
			{
				uworldPartitionStreamingSourceComponent.DisableStreamingSource();
			}
		}

		// Token: 0x060366A4 RID: 222884 RVA: 0x00DB8F5D File Offset: 0x00DB715D
		private void OnBeforeLoadMap()
		{
			if (!ModelBase<PlotModel>.Instance.IsInPlot)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotResult.ResultCode = EPlotResultCode.Interrupt;
			ControllerBase<FlowController>.Instance.BackgroundFlow("加载地图前跳过当前剧情", false, false, false);
		}

		// Token: 0x060366A5 RID: 222885 RVA: 0x00DB8F8E File Offset: 0x00DB718E
		private void OnWorldDone()
		{
			if (ModelBase<PlotModel>.Instance.IsInPlot)
			{
				return;
			}
			SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
			Entity entity;
			if (instance == null)
			{
				entity = null;
			}
			else
			{
				EntityHandle getCurrentEntity = instance.GetCurrentEntity;
				entity = ((getCurrentEntity != null) ? getCurrentEntity.Entity : null);
			}
			this.RemoveProtect(entity, false);
		}

		// Token: 0x060366A6 RID: 222886 RVA: 0x00DB8FC1 File Offset: 0x00DB71C1
		private void OnOpenLoading()
		{
			this.EndInteraction(false, false);
		}

		// Token: 0x060366A7 RID: 222887 RVA: 0x00DB8FCC File Offset: 0x00DB71CC
		private void OnLeaveOnlineWorld()
		{
			if (ModelBase<PlotModel>.Instance.IsInPlot)
			{
				ControllerBase<FlowController>.Instance.FinishFlow("退出联机时退出剧情", null, false);
				ControllerBase<FlowController>.Instance.ClearOnLeaveOnlineWorld();
			}
		}

		// Token: 0x060366A8 RID: 222888 RVA: 0x00DB9008 File Offset: 0x00DB7208
		private void OnBattleStateChanged(bool bStart)
		{
			if (bStart && ControllerBase<FlowController>.Instance.IsInShowTalk() && ModelBase<PlotModel>.Instance.PlotConfig.SkipTalkWhenFighting)
			{
				ControllerBase<FlowController>.Instance.FinishFlow("战斗状态改变结束剧情", null, false);
			}
		}

		// Token: 0x060366A9 RID: 222889 RVA: 0x00DB904E File Offset: 0x00DB724E
		public void OnChangeRole(EntityHandle newEntityHandle, EntityHandle oldEntityHandle)
		{
			if (ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
			{
				this.ProtectCurrentRole();
				return;
			}
			this.RemoveProtect(newEntityHandle.Entity, false);
		}

		// Token: 0x060366AA RID: 222890 RVA: 0x00DB9070 File Offset: 0x00DB7270
		private void OnUpdateSceneTeam()
		{
			if (ModelBase<SceneTeamModel>.Instance.CurrentGroupType.GetValueOrDefault() == ETeamGroupType.Plot)
			{
				this.ProtectCurrentRole();
			}
		}

		// Token: 0x060366AB RID: 222891 RVA: 0x00DB908C File Offset: 0x00DB728C
		private void ObBtBack(int treeId)
		{
			if (!ModelBase<PlotModel>.Instance.IsInPlot)
			{
				return;
			}
			GeneralContext curContext = ModelBase<PlotModel>.Instance.CurContext;
			if (curContext != null && curContext.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree && ((GeneralLogicTreeContext)ModelBase<PlotModel>.Instance.CurContext).TreeConfigId == treeId)
			{
				ControllerBase<FlowController>.Instance.FinishFlow("任务树回退打断剧情", null, false);
			}
		}

		// Token: 0x060366AC RID: 222892 RVA: 0x00DB90F6 File Offset: 0x00DB72F6
		public void ChangeFormation()
		{
			this.PlotFormation.ChangeFormation();
		}

		// Token: 0x060366AD RID: 222893 RVA: 0x00DB9104 File Offset: 0x00DB7304
		public UniTask CheckFormation()
		{
			PlotController.<CheckFormation>d__45 <CheckFormation>d__;
			<CheckFormation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckFormation>d__.<>4__this = this;
			<CheckFormation>d__.<>1__state = -1;
			<CheckFormation>d__.<>t__builder.Start<PlotController.<CheckFormation>d__45>(ref <CheckFormation>d__);
			return <CheckFormation>d__.<>t__builder.Task;
		}

		// Token: 0x060366AE RID: 222894 RVA: 0x00DB9148 File Offset: 0x00DB7348
		public UniTask CheckSwitchSubLevel()
		{
			PlotController.<CheckSwitchSubLevel>d__46 <CheckSwitchSubLevel>d__;
			<CheckSwitchSubLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckSwitchSubLevel>d__.<>4__this = this;
			<CheckSwitchSubLevel>d__.<>1__state = -1;
			<CheckSwitchSubLevel>d__.<>t__builder.Start<PlotController.<CheckSwitchSubLevel>d__46>(ref <CheckSwitchSubLevel>d__);
			return <CheckSwitchSubLevel>d__.<>t__builder.Task;
		}

		// Token: 0x060366AF RID: 222895 RVA: 0x00DB918C File Offset: 0x00DB738C
		public void OnStartPlotNetwork(PlotInfo plotInfo)
		{
			if (PerfSightController.IsEnable)
			{
				FKuroPerfSightHelper.BeginExtTag("Plot");
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Plot_");
				defaultInterpolatedStringHandler.AppendFormatted(plotInfo.FlowListName);
				defaultInterpolatedStringHandler.AppendLiteral("_");
				defaultInterpolatedStringHandler.AppendFormatted<int>(plotInfo.FlowId);
				this.CachePerfSightName = defaultInterpolatedStringHandler.ToStringAndClear();
				FKuroPerfSightHelper.BeginExtTag(this.CachePerfSightName);
			}
			ModelBase<PlotModel>.Instance.IsInPlot = true;
			ModelBase<PlotModel>.Instance.PlotStartFrame = Singleton<Time>.Instance.Frame;
			ModelBase<PlotModel>.Instance.FlowListName = plotInfo.FlowListName;
			ModelBase<PlotModel>.Instance.CurContext = plotInfo.Context;
			ModelBase<PlotModel>.Instance.IsServerNotify = new bool?(plotInfo.IsServerNotify);
			ModelBase<PlotModel>.Instance.IsAsync = new bool?(plotInfo.IsAsync);
			ModelBase<PlotModel>.Instance.KeepBgAudio = plotInfo.KeepMusic;
			ModelBase<PlotModel>.Instance.PlotResult.Reset();
			ModelBase<PlotModel>.Instance.PlotResult.FlowListName = plotInfo.FlowListName;
			ModelBase<PlotModel>.Instance.PlotResult.FlowId = new int?(plotInfo.FlowId);
			ModelBase<PlotModel>.Instance.PlotResult.StateId = plotInfo.StateId;
			ModelBase<PlotModel>.Instance.PlotResult.FlowIncId = new long?(plotInfo.FlowIncId);
			if (!plotInfo.IsBackground && (plotInfo.PlotLevel == EPlotLevel.LevelA || plotInfo.PlotLevel == EPlotLevel.LevelB))
			{
				ModelBase<PlotModel>.Instance.SetInPlotGameBudget(true);
			}
			Singleton<EventSystem>.Instance.Emit<PlotInfo>(EEventName.PlotNetworkStart, plotInfo);
			this.PlotFormationMemory.Enter(plotInfo);
		}

		// Token: 0x060366B0 RID: 222896 RVA: 0x00DB9324 File Offset: 0x00DB7524
		public void EnsureFormationMemoryMaskBeforePlotEnd()
		{
			this.PlotFormationMemory.EnsureMaskBeforePlotEnd();
		}

		// Token: 0x060366B1 RID: 222897 RVA: 0x00DB9334 File Offset: 0x00DB7534
		public void OnEndPlotNetwork()
		{
			Singleton<PlotSequenceInertiaKeeper>.Instance.Stop("PlotController.OnEndPlotNetwork");
			if (PerfSightController.IsEnable)
			{
				FKuroPerfSightHelper.EndExtTag("Plot");
				FKuroPerfSightHelper.EndExtTag(this.CachePerfSightName);
				this.CachePerfSightName = "";
			}
			ModelBase<PlotModel>.Instance.KeepBgAudio = false;
			ModelBase<PlotModel>.Instance.ResetAudioState();
			ModelBase<PlotModel>.Instance.IsInPlot = false;
			this.PlotFormationMemory.Restore();
			ModelBase<PlotModel>.Instance.FinishMontage();
			ControllerBase<SequenceController>.Instance.ManualFinish();
			ModelBase<PlotModel>.Instance.SetRender(false);
			ModelBase<PlotModel>.Instance.SetInPlotGameBudget(false);
			ModelBase<PlotModel>.Instance.FinishTemplate();
			ModelBase<PlotModel>.Instance.PlotWeather.OnPlotEnd();
			ModelBase<PlotModel>.Instance.PlotTimeOfDay.OnPlotEnd();
			ModelBase<PlotModel>.Instance.PlotCleanRange.Close();
			ModelBase<PlotModel>.Instance.PlotAvg.OnPlotEnd();
			ModelBase<PlotModel>.Instance.ClearOptionReadState();
			ModelBase<PlotModel>.Instance.PlotConfig.DisableInput = false;
			ModelBase<PlotModel>.Instance.IsTipsViewShowed = false;
			ModelBase<PlotModel>.Instance.CurTalkItem = null;
			ModelBase<PlotModel>.Instance.CurShowTalk = null;
			ModelBase<PlotModel>.Instance.TimeLimitedOptionTag = false;
			ModelBase<PlotModel>.Instance.IsTeleportTransitionSeq = false;
			Global.CharacterCameraManager.FadeAmount = 0f;
			ControllerBase<CameraController>.Instance.ExitDialogMode("MainCamera");
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.TogglePlotProtect(false);
			this.EnableViewControl(false);
			if (ModelBase<PlotModel>.Instance.HasEnterMovieMode)
			{
				ModelBase<PlotModel>.Instance.HasEnterMovieMode = false;
				ControllerBase<MovieModeController>.Instance.ExitMovieMode(new ExitMovieModeParams
				{
					BlendTime = 0f
				}, null);
			}
			PlotResultInfo plotResult = ModelBase<PlotModel>.Instance.PlotResult;
			Singleton<EventSystem>.Instance.Emit<PlotResultInfo>(EEventName.PlotNetworkEnd, plotResult);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MusicSubtitleView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MusicSubtitleView, null);
			}
			ControllerBase<PreloadControllerNew>.Instance.RemovePlot(plotResult.FlowListName ?? string.Empty, plotResult.FlowId.GetValueOrDefault(), plotResult.StateId.GetValueOrDefault());
			ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.RemovePlotUiAsset(plotResult.FormatId);
			ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.CancelHangingTask(plotResult.FormatId);
			plotResult.Reset();
			ModelBase<PlotModel>.Instance.ClearContext();
			ModelBase<PlotModel>.Instance.PlotTextReplacer.Clear();
			if (ModelBase<PlotModel>.Instance.PlotPendingList.Count > 0)
			{
				ModelBase<PlotModel>.Instance.IsBackInteractionAfterFlow = false;
				this.EndInteraction(true, false);
				return;
			}
			if (ModelBase<PlotModel>.Instance.IsBackInteractionAfterFlow)
			{
				ModelBase<PlotModel>.Instance.IsBackInteractionAfterFlow = false;
				this.TriggerInteraction(true);
			}
			ModelBase<SequenceModel>.Instance.SkipUiWaiting = false;
			ModelBase<PlotModel>.Instance.SeamlessLockState = false;
		}

		// Token: 0x060366B2 RID: 222898 RVA: 0x00DB95DC File Offset: 0x00DB77DC
		public void CloseAllUi(long? ownerId = null)
		{
			this.PlotViewManager.ClosePlotView(ownerId);
			this.PlotViewManager.CloseTipsView();
		}

		// Token: 0x060366B3 RID: 222899 RVA: 0x00DB95F5 File Offset: 0x00DB77F5
		public void ClearUi(long? ownerId = null)
		{
			this.PlotViewManager.ClearPlotSubtitle(ownerId);
		}

		// Token: 0x060366B4 RID: 222900 RVA: 0x00DB9603 File Offset: 0x00DB7803
		public void HideUi(bool isHidden, long? ownerId = null)
		{
			this.PlotViewManager.HidePlotUi(isHidden, ownerId);
		}

		// Token: 0x060366B5 RID: 222901 RVA: 0x00DB9612 File Offset: 0x00DB7812
		public EUiViewName? GetCurrentViewName()
		{
			return this.PlotViewManager.GetCurrentViewName();
		}

		// Token: 0x060366B6 RID: 222902 RVA: 0x00DB961F File Offset: 0x00DB781F
		[NullableContext(2)]
		public void OpenPlotView(EUiViewName viewName, TCallback callback = null, UiParam param = null, long? ownerId = null)
		{
			this.PlotViewManager.OpenPlotView(viewName, callback, param, ownerId);
		}

		// Token: 0x060366B7 RID: 222903 RVA: 0x00DB9634 File Offset: 0x00DB7834
		[NullableContext(2)]
		public void OpenCurrentPlotView(TCallback callback = null, UiParam param = null, long? ownerId = null)
		{
			EUiViewName? plotViewName = ModelBase<PlotModel>.Instance.PlotConfig.PlotViewName;
			if (plotViewName != null)
			{
				this.PlotViewManager.OpenPlotView(plotViewName.Value, callback, param, ownerId);
				return;
			}
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x060366B8 RID: 222904 RVA: 0x00DB967A File Offset: 0x00DB787A
		public void WaitViewCallback(TCallback callback)
		{
			this.PlotViewManager.WaitOpenCallback(callback);
		}

		// Token: 0x060366B9 RID: 222905 RVA: 0x00DB9688 File Offset: 0x00DB7888
		public void RemoveViewCallback(TCallback callback)
		{
			this.PlotViewManager.RemoveCallback(callback);
		}

		// Token: 0x060366BA RID: 222906 RVA: 0x00DB9698 File Offset: 0x00DB7898
		public void HandleShowCenterText(bool isPopView)
		{
			EUiViewName euiViewName = isPopView ? EUiViewName.PlotTransitionViewPop : EUiViewName.PlotTransitionView;
			if (Singleton<UiManager>.Instance.IsViewShow(euiViewName))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdatePlotCenterText);
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(euiViewName))
			{
				return;
			}
			if (isPopView)
			{
				Singleton<UiManager>.Instance.OpenView(euiViewName, null, delegate(bool _1, int _2)
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.UpdatePlotCenterText);
				});
				return;
			}
			Singleton<UiManager>.Instance.OpenViewByPlot(euiViewName, null, delegate(bool _1, int _2)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdatePlotCenterText);
			});
		}

		// Token: 0x060366BB RID: 222907 RVA: 0x00DB973B File Offset: 0x00DB793B
		public bool ShowTipsView(ITalkItem talkItem, EPromptStyle style, UiParam uiParam)
		{
			ModelBase<PlotModel>.Instance.CurTalkItem = talkItem;
			if (this.PlotViewManager.UpdateTipsSubtitle(talkItem))
			{
				return true;
			}
			ModelBase<PlotModel>.Instance.IsTipsViewShowed = true;
			this.PlotViewManager.OpenTipsView(style, uiParam).Forget();
			return true;
		}

		// Token: 0x060366BC RID: 222908 RVA: 0x00DB9778 File Offset: 0x00DB7978
		public void ShowSystemOption(ITalkItem talkItem, Action<int, List<ActionInfo>> callback)
		{
			ITalkItemSystemOption config = talkItem as ITalkItemSystemOption;
			ITalkItemSystemOption config2 = config;
			if (config2 != null && config2.OptionConfig.Type == ESystemOptionType.RogueRandomEvent)
			{
				IRogueRandomEventOption rogueRandomEventOption = config.OptionConfig as IRogueRandomEventOption;
				IRoguelikeRandomEventOpenParam param = new RoguelikeRandomEventOpenParam
				{
					BindId = rogueRandomEventOption.EventId,
					SelectCallback = delegate(int index)
					{
						callback(config.Options.FindIndex(delegate(ITalkOption option)
						{
							int? optionId = (option.TypeParams as ITalkOptionRogueRandomEvent).OptionId;
							int index = index;
							return optionId.GetValueOrDefault() == index & optionId != null;
						}), config.Options.Find(delegate(ITalkOption option)
						{
							int? optionId = (option.TypeParams as ITalkOptionRogueRandomEvent).OptionId;
							int index = index;
							return optionId.GetValueOrDefault() == index & optionId != null;
						}).Actions);
					}
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeRandomEventView, param, null);
				return;
			}
			if (config.OptionConfig.Type != ESystemOptionType.GravityControl)
			{
				if (config.OptionConfig.Type == ESystemOptionType.PermanentRogueRandomEvent)
				{
					IPermanentRogueRandomEvent permanentRogueRandomEvent = config.OptionConfig as IPermanentRogueRandomEvent;
					if (permanentRogueRandomEvent != null)
					{
						IRoguelikeRandomEventOpenParam param2 = new RoguelikeRandomEventOpenParam
						{
							BindId = permanentRogueRandomEvent.EventId,
							SelectCallback = delegate(int index)
							{
								callback(config.Options.FindIndex(delegate(ITalkOption option)
								{
									int? optionId = (option.TypeParams as ITalkOptionRogueRandomEvent).OptionId;
									int index = index;
									return optionId.GetValueOrDefault() == index & optionId != null;
								}), config.Options.Find(delegate(ITalkOption option)
								{
									int? optionId = (option.TypeParams as ITalkOptionRogueRandomEvent).OptionId;
									int index = index;
									return optionId.GetValueOrDefault() == index & optionId != null;
								}).Actions);
							}
						};
						Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeRandomEventView, param2, null);
					}
				}
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GravityFlipView))
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnGravityFlipAnimFinish);
				return;
			}
			IGravityFlipViewOpenParam param3 = new GravityFlipViewOpenParam
			{
				SelectCallback = delegate(int index)
				{
					callback(index, new List<ActionInfo>());
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GravityFlipView, param3, null);
		}

		// Token: 0x060366BD RID: 222909 RVA: 0x00DB98C4 File Offset: 0x00DB7AC4
		public void HandleSeqPlayerInput(bool inDisableInput, bool inDisableLookupInput)
		{
			if (GlobalData.GameInstance != null)
			{
				bool baseCharacter = Global.BaseCharacter != null;
				APlayerController characterController = Global.CharacterController;
				if (!baseCharacter || characterController == null)
				{
					return;
				}
				if (!inDisableInput)
				{
					ModelBase<InputDistributeModel>.Instance.SetInputDistributeTag("FightInputRoot");
				}
				ModelBase<InteractionModel>.Instance.SetInteractionHintDisable(inDisableInput);
				characterController.SetIgnoreLookInput(inDisableLookupInput);
			}
		}

		// Token: 0x060366BE RID: 222910 RVA: 0x00DB990D File Offset: 0x00DB7B0D
		public void TogglePlotProtect(bool inEnable)
		{
			if (this.IsInPlotProtect != inEnable)
			{
				this.IsInPlotProtect = inEnable;
				if (inEnable)
				{
					ModelBase<PlotModel>.Instance.SaveCharacterLockOn();
				}
				else
				{
					ModelBase<PlotModel>.Instance.RevertCharacterLockOn();
				}
			}
			if (inEnable)
			{
				this.ProtectCurrentRole();
				return;
			}
			this.RemoveAllProtect();
		}

		// Token: 0x060366BF RID: 222911 RVA: 0x00DB9948 File Offset: 0x00DB7B48
		public void ProtectCurrentRole()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !this.PlotProtectEntityIds.Add(getCurrentEntity.Id))
			{
				return;
			}
			CharacterBuffComponent characterBuffComponent;
			if (getCurrentEntity == null)
			{
				characterBuffComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				characterBuffComponent = ((entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null);
			}
			CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
			BaseTagComponent baseTagComponent;
			if (getCurrentEntity == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity2 = getCurrentEntity.Entity;
				baseTagComponent = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 != null)
			{
				if (!baseTagComponent2.HasTag(this.PlotProtectTag))
				{
					baseTagComponent2.AddTag(new int?(this.PlotProtectTag));
				}
				if (!baseTagComponent2.HasTag(this.PlotTag))
				{
					baseTagComponent2.AddTag(new int?(this.PlotTag));
				}
			}
			if (characterBuffComponent2 != null)
			{
				characterBuffComponent2.AddBuff(3037L, new AddBuffParam
				{
					InstigatorId = characterBuffComponent2.CreatureDataId,
					Reason = "PlotController.ProtectCurrentRole"
				});
			}
		}

		// Token: 0x060366C0 RID: 222912 RVA: 0x00DB9A18 File Offset: 0x00DB7C18
		private void RemoveAllProtect()
		{
			foreach (int id in this.PlotProtectEntityIds)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(id);
				this.RemoveProtect(entity, true);
			}
			this.PlotProtectEntityIds.Clear();
		}

		// Token: 0x060366C1 RID: 222913 RVA: 0x00DB9A84 File Offset: 0x00DB7C84
		[NullableContext(2)]
		private void RemoveProtect(Entity entity, bool removeTag)
		{
			object obj = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (removeTag)
			{
				if (baseTagComponent != null)
				{
					baseTagComponent.RemoveTag(new int?(this.PlotProtectTag));
				}
				if (baseTagComponent != null)
				{
					baseTagComponent.RemoveTag(new int?(this.PlotTag));
				}
			}
			object obj2 = obj;
			if (obj2 == null)
			{
				return;
			}
			obj2.RemoveBuff(3037L, -1, "PlotController.RemoveProtect", null, null, null);
		}

		// Token: 0x060366C2 RID: 222914 RVA: 0x00DB9B08 File Offset: 0x00DB7D08
		public bool IsEnableInteract()
		{
			return !ModelBase<PlotModel>.Instance.IsInPlot || ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelD || ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelE;
		}

		// Token: 0x060366C3 RID: 222915 RVA: 0x00DB9B46 File Offset: 0x00DB7D46
		public bool NeedInputRefresh()
		{
			return ModelBase<PlotModel>.Instance.IsInPlot || ModelBase<PlotModel>.Instance.PlotPendingList.Count > 0;
		}

		// Token: 0x060366C4 RID: 222916 RVA: 0x00DB9B68 File Offset: 0x00DB7D68
		public bool TriggerInteraction(bool showOption = true)
		{
			if (!ModelBase<PlotModel>.Instance.IsInPlot)
			{
				ModelBase<PlotModel>.Instance.IsInInteraction = true;
				ModelBase<PlotModel>.Instance.PlotConfig.SetMode(new SetPlotMode
				{
					Mode = EPlotMode.LevelC.ToEnumString(),
					IsSwitchMainRole = new bool?(false),
					UseFlowCamera = new bool?(true)
				}, true);
				ModelBase<PlotModel>.Instance.ApplyPlotConfig(false);
				int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
				if (currentInteractEntityId != null)
				{
					EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(currentInteractEntityId.Value);
					if (entityById == null)
					{
						this.EndInteraction(false, false);
						return false;
					}
					WorldEntity entity = entityById.Entity;
					PawnInteractNewComponent pawnInteractNewComponent = (entity != null) ? entity.GetComponent<PawnInteractNewComponent>() : null;
					if (pawnInteractNewComponent == null)
					{
						this.EndInteraction(false, false);
						return false;
					}
					if (!pawnInteractNewComponent.IsPawnInteractive())
					{
						this.EndInteraction(false, false);
						return false;
					}
					ModelBase<PlotModel>.Instance.CurrentInteractEntity = entityById;
					Singleton<EventSystem>.Instance.EmitWithTarget(entityById.Entity, EEventName.OnInteractPlotStart);
					PawnInteractController pawnInteractController = pawnInteractNewComponent.GetInteractController();
					ModelBase<PlotModel>.Instance.InteractController = pawnInteractController;
					this.OpenPlotView(EUiViewName.PlotView, delegate(bool result)
					{
						if (showOption && result && ModelBase<PlotModel>.Instance.IsInInteraction)
						{
							Singleton<EventSystem>.Instance.Emit<PawnInteractController>(EEventName.TriggerPlotInteraction, pawnInteractController);
						}
						if (result)
						{
							Singleton<EventSystem>.Instance.Emit(EEventName.PlotInteractViewOpen);
							return;
						}
						this.EndInteraction(false, false);
					}, null, null);
				}
				else
				{
					this.EndInteraction(false, false);
					Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.CFT, "交互目标为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				return true;
			}
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelD || ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() == EPlotLevel.LevelE)
			{
				ModelBase<PlotModel>.Instance.IsInInteraction = true;
				this.SetBackInteractionAfterFlow();
				ControllerBase<FlowController>.Instance.FinishFlow("触发交互结束剧情", null, false);
				return true;
			}
			return false;
		}

		// Token: 0x060366C5 RID: 222917 RVA: 0x00DB9D32 File Offset: 0x00DB7F32
		public void EndInteractionByInteractController(PawnInteractController interactController)
		{
			if (ModelBase<PlotModel>.Instance.InteractController != interactController)
			{
				return;
			}
			this.EndInteraction(false, false);
		}

		// Token: 0x060366C6 RID: 222918 RVA: 0x00DB9D4C File Offset: 0x00DB7F4C
		public void EndInteraction(bool isPlayFlow = false, bool isForce = false)
		{
			if (!ModelBase<PlotModel>.Instance.IsInInteraction && !isForce)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.IsInInteraction = false;
			ModelBase<PlotModel>.Instance.InteractController = null;
			if (!isPlayFlow)
			{
				ModelBase<PlotModel>.Instance.ResetAudioState();
				ControllerBase<CameraController>.Instance.ExitDialogMode("MainCamera");
				this.CloseAllUi(null);
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				this.TogglePlotProtect(false);
			}
			else
			{
				this.ClearUi(null);
			}
			if (ModelBase<PlotModel>.Instance.CurrentInteractEntity == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Interaction, ELogAuthor.WLJ, "当前交互目标为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Singleton<EventSystem>.Instance.EmitWithTarget(ModelBase<PlotModel>.Instance.CurrentInteractEntity.Entity, EEventName.OnInteractPlotEnd);
			ModelBase<PlotModel>.Instance.CurrentInteractEntity = null;
		}

		// Token: 0x060366C7 RID: 222919 RVA: 0x00DB9E22 File Offset: 0x00DB8022
		public void SetBackInteractionAfterFlow()
		{
			ModelBase<PlotModel>.Instance.IsBackInteractionAfterFlow = true;
		}

		// Token: 0x060366C8 RID: 222920 RVA: 0x00DB9E30 File Offset: 0x00DB8030
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public unsafe List<ITalkItem> GetTalkItemsOfFlow(PlayFlow flow)
		{
			if (flow == null)
			{
				return null;
			}
			IReadOnlyList<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flow.FlowListName, flow.FlowId, flow.StateId);
			if (flowStateActions == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotController.StartPlotNetwork] 无法找到对应剧情的状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", flow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", flow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", flow.StateId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return null;
			}
			ActionInfo actionInfo = null;
			foreach (ActionInfo actionInfo2 in flowStateActions)
			{
				if (actionInfo2.Name == EAction.ShowTalk)
				{
					actionInfo = actionInfo2;
					break;
				}
			}
			if (actionInfo == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[PlotController.StartPlotNetwork] 无法找到对应剧情的ShowTalk行为";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("FlowListName", flow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowId", flow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("StateId", flow.StateId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return null;
			}
			ShowTalk showTalk = actionInfo.Params as ShowTalk;
			if (showTalk == null)
			{
				return null;
			}
			return showTalk.TalkItems;
		}

		// Token: 0x060366C9 RID: 222921 RVA: 0x00DB9FD8 File Offset: 0x00DB81D8
		[NullableContext(2)]
		public unsafe string GetTalkItemsOfCenterText(PlayFlow flow)
		{
			if (flow == null)
			{
				return null;
			}
			IReadOnlyList<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(flow.FlowListName, flow.FlowId, flow.StateId);
			if (flowStateActions == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "[PlotController.StartPlotNetwork] 无法找到对应剧情的状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", flow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", flow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", flow.StateId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return null;
			}
			ActionInfo actionInfo = null;
			foreach (ActionInfo actionInfo2 in flowStateActions)
			{
				if (actionInfo2.Name == EAction.ShowCenterText)
				{
					actionInfo = actionInfo2;
					break;
				}
			}
			if (actionInfo == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.JYS;
				string message2 = "[PlotController.StartPlotNetwork] 无法找到对应剧情的ShowCenterText行为";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("FlowListName", flow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowId", flow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("StateId", flow.StateId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return null;
			}
			ShowCenterText showCenterText = actionInfo.Params as ShowCenterText;
			if (showCenterText == null)
			{
				return null;
			}
			return showCenterText.TidCenterText;
		}

		// Token: 0x060366CA RID: 222922 RVA: 0x00DBA184 File Offset: 0x00DB8384
		[NullableContext(2)]
		public unsafe ShowCenterText GetTalkItemsOfCenterTextForTeleport()
		{
			PlotFlow playFlow = ModelBase<PlotModel>.Instance.PlayFlow;
			if (playFlow == null)
			{
				return null;
			}
			IReadOnlyList<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(playFlow.FlowListName ?? string.Empty, playFlow.FlowId.GetValueOrDefault(), playFlow.StateId.GetValueOrDefault());
			if (flowStateActions == null || flowStateActions.Count <= 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.JYS;
				string message = "[PlotController.StartPlotNetwork] 无法找到对应剧情的状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", playFlow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowId", playFlow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", playFlow.StateId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return null;
			}
			ActionInfo actionInfo = flowStateActions[0];
			if (actionInfo == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.JYS;
				string message2 = "[PlotController.StartPlotNetwork] 无法找到对应剧情的ShowCenterText行为";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("FlowListName", playFlow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowId", playFlow.FlowId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("StateId", playFlow.StateId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return null;
			}
			if (actionInfo.Name == EAction.ShowCenterText)
			{
				return actionInfo.Params as ShowCenterText;
			}
			if (actionInfo.Name == EAction.ShowTalk)
			{
				ShowTalk showTalk = actionInfo.Params as ShowTalk;
				if (showTalk != null && showTalk.TalkItems.Count > 0 && showTalk.TalkItems[0].Type.GetValueOrDefault() == ETalkItemType.CenterText)
				{
					ITalkItemCenterText talkItemCenterText = showTalk.TalkItems[0] as ITalkItemCenterText;
					ShowCenterText showCenterText = new ShowCenterText();
					float? totalTime;
					if (talkItemCenterText == null)
					{
						totalTime = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig = talkItemCenterText.CenterTextConfig;
						totalTime = ((centerTextConfig != null) ? centerTextConfig.TotalTime : null);
					}
					showCenterText.TotalTime = totalTime;
					ITextStyle textStyle;
					if (talkItemCenterText == null)
					{
						textStyle = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig2 = talkItemCenterText.CenterTextConfig;
						textStyle = ((centerTextConfig2 != null) ? centerTextConfig2.TextStyle : null);
					}
					showCenterText.TextStyle = textStyle;
					string bgImageId;
					if (talkItemCenterText == null)
					{
						bgImageId = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig3 = talkItemCenterText.CenterTextConfig;
						bgImageId = ((centerTextConfig3 != null) ? centerTextConfig3.BgImageId : null);
					}
					showCenterText.BgImageId = bgImageId;
					bool? isMulLine;
					if (talkItemCenterText == null)
					{
						isMulLine = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig4 = talkItemCenterText.CenterTextConfig;
						isMulLine = ((centerTextConfig4 != null) ? centerTextConfig4.IsMulLine : null);
					}
					showCenterText.IsMulLine = isMulLine;
					bool? isManualNext;
					if (talkItemCenterText == null)
					{
						isManualNext = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig5 = talkItemCenterText.CenterTextConfig;
						isManualNext = ((centerTextConfig5 != null) ? centerTextConfig5.IsManualNext : null);
					}
					showCenterText.IsManualNext = isManualNext;
					bool? isCancelAutoLine;
					if (talkItemCenterText == null)
					{
						isCancelAutoLine = null;
					}
					else
					{
						IShowCenterTextParams centerTextConfig6 = talkItemCenterText.CenterTextConfig;
						isCancelAutoLine = ((centerTextConfig6 != null) ? centerTextConfig6.IsCancelAutoLine : null);
					}
					showCenterText.IsCancelAutoLine = isCancelAutoLine;
					showCenterText.TextId = showTalk.TalkItems[0].TextId.GetValueOrDefault(1);
					showCenterText.TidCenterText = showTalk.TalkItems[0].TidTalk;
					return showCenterText;
				}
			}
			return null;
		}

		// Token: 0x060366CB RID: 222923 RVA: 0x00DBA4C1 File Offset: 0x00DB86C1
		public void TriggerBlackSequence()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.TriggerBlackSequence);
		}

		// Token: 0x060366CC RID: 222924 RVA: 0x00DBA4D3 File Offset: 0x00DB86D3
		public void ChangeWeather(int weatherId, bool isInherit, float tweenTime)
		{
			if (!ModelBase<PlotModel>.Instance.IsInPlot && !GlobalData.IsPlayInEditor)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotWeather.ChangeWeather(weatherId, isInherit, tweenTime, 100);
		}

		// Token: 0x060366CD RID: 222925 RVA: 0x00DBA4FD File Offset: 0x00DB86FD
		public void ChangePlotTimeOfDay(bool isInherit, int startSecond, int endSecond = 0, int tweenSecond = 0)
		{
			if (!ModelBase<PlotModel>.Instance.IsInPlot && !GlobalData.IsPlayInEditor)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotTimeOfDay.SetTimeDuration(isInherit, startSecond, endSecond, tweenSecond);
		}

		// Token: 0x060366CE RID: 222926 RVA: 0x00DBA527 File Offset: 0x00DB8727
		public void EnableViewControl(bool bEnable)
		{
			ModelBase<PlotModel>.Instance.CanControlView = bEnable;
			ModelBase<PlotModel>.Instance.UpdateLastViewControl();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.PlotEnableControlView, bEnable);
		}

		// Token: 0x060366CF RID: 222927 RVA: 0x00DBA54F File Offset: 0x00DB874F
		private bool GetLastViewControl()
		{
			return ModelBase<PlotModel>.Instance.GetLastViewControl();
		}

		// Token: 0x060366D0 RID: 222928 RVA: 0x00DBA55C File Offset: 0x00DB875C
		public void UpdateViewControl(bool bEnable)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "[ViewControl]UpdateViewControl";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", bEnable);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<PlotModel>.Instance.CanControlView = bEnable;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.PlotEnableControlView, bEnable);
		}

		// Token: 0x060366D1 RID: 222929 RVA: 0x00DBA5B4 File Offset: 0x00DB87B4
		public void ResetViewControl()
		{
			bool lastViewControl = this.GetLastViewControl();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "[ViewControl]ResetViewControl";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", lastViewControl);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.EnableViewControl(lastViewControl);
		}

		// Token: 0x060366D2 RID: 222930 RVA: 0x00DBA5FC File Offset: 0x00DB87FC
		public void HideSummonedEntity()
		{
			foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
			{
				if (entityHandle != null && entityHandle.Valid)
				{
					WorldEntity entity = entityHandle.Entity;
					foreach (long num in ((entity != null) ? entity.GetComponent<CreatureDataComponent>() : null).CustomServerEntityIds)
					{
						int num2 = (int)num;
						EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity((long)num2);
						if (entity2 != null && entity2.Valid)
						{
							ControllerBase<CreatureController>.Instance.SetEntityEnable(entity2.Entity, false, "剧情隐藏伴生物", false);
						}
					}
				}
			}
		}

		// Token: 0x060366D3 RID: 222931 RVA: 0x00DBA6D8 File Offset: 0x00DB88D8
		public void TestOpenTick(Action handle)
		{
			this.TestId = this.AddTick(delegate(float delta)
			{
				handle();
			});
		}

		// Token: 0x060366D4 RID: 222932 RVA: 0x00DBA70A File Offset: 0x00DB890A
		public void TestCloseTick()
		{
			this.RemoveTick(this.TestId);
		}

		// Token: 0x060366D5 RID: 222933 RVA: 0x00DBA718 File Offset: 0x00DB8918
		public int AddTick(Action<float> handle)
		{
			this.TickHandleId++;
			this.TickCount++;
			this.TickGroup[this.TickHandleId] = handle;
			return this.TickHandleId;
		}

		// Token: 0x060366D6 RID: 222934 RVA: 0x00DBA74E File Offset: 0x00DB894E
		public void RemoveTick(int id)
		{
			if (this.TickGroup.Remove(id))
			{
				this.TickCount--;
			}
		}

		// Token: 0x060366D7 RID: 222935 RVA: 0x00DBA76C File Offset: 0x00DB896C
		public unsafe void TickAll(float delta)
		{
			if (this.TickCount <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, Action<float>> keyValuePair in this.TickGroup)
			{
				try
				{
					keyValuePair.Value(delta);
				}
				catch (Exception item)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "PlotModel Tick 异常";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("name", keyValuePair.Key);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", item);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x060366D8 RID: 222936 RVA: 0x00DBA844 File Offset: 0x00DB8A44
		[NullableContext(2)]
		public SceneTeamItem FindMainRoleTeamItem()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId);
				if (baseRoleId != 0 && ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId))
				{
					PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
					bool flag;
					if (instance == null)
					{
						flag = true;
					}
					else
					{
						instance.GetPlayerGender();
						flag = false;
					}
					if (!flag)
					{
						MainRoleConfig? mainRoleById = ConfigBase<RoleConfig>.Instance.GetMainRoleById(baseRoleId);
						int? num = (mainRoleById != null) ? new int?(mainRoleById.GetValueOrDefault().Gender) : null;
						int playerGender = (int)ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
						if ((num.GetValueOrDefault() == playerGender & num != null) && !sceneTeamItem.IsDead())
						{
							RoleDataBase roleDataBase = ConfigBase<RoleConfig>.Instance.IsTrialRole(sceneTeamItem.GetConfigId) ? ModelBase<RoleModel>.Instance.GetRoleRobotData(sceneTeamItem.GetConfigId) : ModelBase<RoleModel>.Instance.GetRoleInstanceById(sceneTeamItem.GetConfigId);
							if (roleDataBase != null)
							{
								int roleSkinId = roleDataBase.GetRoleSkinId();
								if (ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId).GetRoleSkinConfig().GroupId != ModelBase<PlotModel>.Instance.PlotConfig.PlayerSkinId)
								{
									continue;
								}
							}
							return sceneTeamItem;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060366D9 RID: 222937 RVA: 0x00DBA9C0 File Offset: 0x00DB8BC0
		[NullableContext(2)]
		public SceneTeamItem FindMainRoleTeamItemForFormationMemory()
		{
			foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(true))
			{
				int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(sceneTeamItem.GetConfigId);
				if (baseRoleId != 0 && ModelBase<RoleModel>.Instance.IsMainRole(baseRoleId))
				{
					return sceneTeamItem;
				}
			}
			return null;
		}

		// Token: 0x060366DA RID: 222938 RVA: 0x00DBAA3C File Offset: 0x00DB8C3C
		public void RequestChangeRole()
		{
			SceneTeamItem sceneTeamItem = this.FindMainRoleTeamItem();
			if (sceneTeamItem == null)
			{
				return;
			}
			ControllerBase<SceneTeamController>.Instance.RequestChangeRole(sceneTeamItem.GetCreatureDataId(), new RequestChangeRoleParams
			{
				GoBattleInvincible = new bool?(true),
				CanUseGoBattleSkill = new bool?(false)
			});
		}

		// Token: 0x060366DB RID: 222939 RVA: 0x00DBAA84 File Offset: 0x00DB8C84
		public void RestoreChangeRole()
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(playerId);
			SceneTeamRole sceneTeamRole;
			if (teamPlayerData == null)
			{
				sceneTeamRole = null;
			}
			else
			{
				SceneTeamGroup group = teamPlayerData.GetGroup(ETeamGroupType.Battle);
				sceneTeamRole = ((group != null) ? group.GetCurrentRole() : null);
			}
			SceneTeamRole sceneTeamRole2 = sceneTeamRole;
			if (sceneTeamRole2 == null)
			{
				return;
			}
			ControllerBase<SceneTeamController>.Instance.RequestChangeRole(sceneTeamRole2.CreatureDataId, new RequestChangeRoleParams
			{
				GoBattleInvincible = new bool?(true),
				CanUseGoBattleSkill = new bool?(false)
			});
		}

		// Token: 0x060366DC RID: 222940 RVA: 0x00DBAAF4 File Offset: 0x00DB8CF4
		public void ManualAdaptAspectRatio(float time)
		{
			UCineCameraComponent cineCameraComponent = ModelBase<CameraModel>.Instance.MainModel.SequenceCamera.DisplayComponent.CineCamera.GetCineCameraComponent();
			int num = 0;
			int num2 = 0;
			Global.CharacterController.GetViewportSize(ref num, ref num2);
			float num3 = (float)num;
			float num4 = (float)num2;
			float num5 = num3 / num4;
			PlotAspectTransformView plotAspectTransformView = ModelBase<PlotModel>.Instance.PlotAspectTransformView;
			if (plotAspectTransformView != null)
			{
				plotAspectTransformView.EnableAutoBlendOut(time);
			}
			cineCameraComponent.bConstrainAspectRatio = false;
			if (cineCameraComponent.Filmback.SensorWidth / cineCameraComponent.Filmback.SensorHeight < num5)
			{
				cineCameraComponent.Filmback.SensorWidth = cineCameraComponent.Filmback.SensorHeight * num5;
				return;
			}
			cineCameraComponent.Filmback.SensorHeight = cineCameraComponent.Filmback.SensorWidth / num5;
		}

		// Token: 0x060366DD RID: 222941 RVA: 0x00DBABA8 File Offset: 0x00DB8DA8
		public UniTask CreateAspectTransformView()
		{
			PlotController.<CreateAspectTransformView>d__94 <CreateAspectTransformView>d__;
			<CreateAspectTransformView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAspectTransformView>d__.<>1__state = -1;
			<CreateAspectTransformView>d__.<>t__builder.Start<PlotController.<CreateAspectTransformView>d__94>(ref <CreateAspectTransformView>d__);
			return <CreateAspectTransformView>d__.<>t__builder.Task;
		}

		// Token: 0x060366DE RID: 222942 RVA: 0x00DBABE3 File Offset: 0x00DB8DE3
		public void RemoveAspectTransformView()
		{
			if (ModelBase<PlotModel>.Instance.PlotAspectTransformView == null)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotAspectTransformView.CloseMeAsync().Forget<bool>();
			ModelBase<PlotModel>.Instance.PlotAspectTransformView = null;
		}

		// Token: 0x060366DF RID: 222943 RVA: 0x00DBAC11 File Offset: 0x00DB8E11
		public void ClearAnsPreloadGuaranteeCache()
		{
			this.PreloadPlotName = null;
			this.PreloadPlotId = null;
			this.PreloadStateId = null;
			this.TriggerMontage = null;
			this.TriggerAnimIns = null;
		}

		// Token: 0x060366E0 RID: 222944 RVA: 0x00DBAC40 File Offset: 0x00DB8E40
		public void RegisterOnMontageEnd(string plotName, int plotId, int plotStateId, [Nullable(2)] UAnimInstance animIns)
		{
			if (animIns == null)
			{
				return;
			}
			this.TriggerMontage = animIns.GetCurrentActiveMontage();
			this.TriggerAnimIns = animIns;
			this.RemovePreloadOnMontageEndImp();
			animIns.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.RemovePreloadOnMontageEnd));
			animIns.OnMontageEnded.Add(new Action<UAnimMontage, bool>(this.RemovePreloadOnMontageEnd));
			this.PreloadPlotName = plotName;
			this.PreloadPlotId = new int?(plotId);
			this.PreloadStateId = new int?(plotStateId);
		}

		// Token: 0x060366E1 RID: 222945 RVA: 0x00DBACBC File Offset: 0x00DB8EBC
		[NullableContext(2)]
		private void RemovePreloadOnMontageEnd(UAnimMontage montage, bool isInterrupted)
		{
			if (montage == null || montage != this.TriggerMontage)
			{
				return;
			}
			UAnimInstance triggerAnimIns = this.TriggerAnimIns;
			if (triggerAnimIns != null)
			{
				triggerAnimIns.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.RemovePreloadOnMontageEnd));
			}
			this.RemovePreloadOnMontageEndImp();
		}

		// Token: 0x060366E2 RID: 222946 RVA: 0x00DBACF4 File Offset: 0x00DB8EF4
		private void RemovePreloadOnMontageEndImp()
		{
			if (!ModelBase<PlotModel>.Instance.AnsPreloadMark)
			{
				this.PreloadPlotName = null;
				this.PreloadPlotId = null;
				this.PreloadStateId = null;
				return;
			}
			if (this.PreloadPlotName == null || this.PreloadPlotId == null || this.PreloadStateId == null)
			{
				return;
			}
			ControllerBase<PreloadControllerNew>.Instance.RemovePlot(this.PreloadPlotName, this.PreloadPlotId.Value, this.PreloadStateId.Value);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.PreloadPlotName);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.PreloadPlotId.Value);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.PreloadStateId.Value);
			string plotId = defaultInterpolatedStringHandler.ToStringAndClear();
			ModelBase<PreloadModelNew>.Instance.PlotUiAssetManager.RemovePlotUiAsset(plotId);
			this.CloseAllUi(null);
			ModelBase<SequenceModel>.Instance.SkipUiWaiting = false;
			ModelBase<PlotModel>.Instance.SeamlessLockState = false;
			ModelBase<PlotModel>.Instance.AnsPreloadMark = false;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "TsAnimNotifyStatePreloadPlot ANS结束时演出未触发, 卸载预加载的资源";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotName", this.PreloadPlotName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.PreloadPlotName = null;
			this.PreloadPlotId = null;
			this.PreloadStateId = null;
		}

		// Token: 0x060366E3 RID: 222947 RVA: 0x00DBAE5C File Offset: 0x00DB905C
		private void OnServerNotifyRemovePreloadFlows(RemovePreloadFlowsNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ControllerBase<PreloadControllerNew>.Instance.RemovePlot(notify.FlowListName, notify.FlowId, notify.StateId);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "收到服务器通知移除预加载的剧情";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Plot", notify.FlowGuid);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0401F49C RID: 128156
		public PlotViewManager PlotViewManager = new PlotViewManager();

		// Token: 0x0401F49D RID: 128157
		private PlotFormation PlotFormation = new PlotFormation();

		// Token: 0x0401F49E RID: 128158
		private PlotFormationMemory PlotFormationMemory = new PlotFormationMemory();

		// Token: 0x0401F49F RID: 128159
		private PlotSwitchSubLevel PlotSwitchSubLevel = new PlotSwitchSubLevel();

		// Token: 0x0401F4A0 RID: 128160
		private int PlotProtectTag = GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.隐身"];

		// Token: 0x0401F4A1 RID: 128161
		private int PlotTag = GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.剧情中"];

		// Token: 0x0401F4A2 RID: 128162
		private bool IsInPlotProtect;

		// Token: 0x0401F4A3 RID: 128163
		private HashSet<int> PlotProtectEntityIds = new HashSet<int>();

		// Token: 0x0401F4A4 RID: 128164
		private int TickHandleId;

		// Token: 0x0401F4A5 RID: 128165
		private Dictionary<int, Action<float>> TickGroup = new Dictionary<int, Action<float>>();

		// Token: 0x0401F4A6 RID: 128166
		private int TickCount;

		// Token: 0x0401F4A7 RID: 128167
		private string CachePerfSightName = "";

		// Token: 0x0401F4A8 RID: 128168
		private Dictionary<int, Action<float>> TickGroupPriority2 = new Dictionary<int, Action<float>>();

		// Token: 0x0401F4A9 RID: 128169
		private List<int> TickGroupPriority2IdBuffer = new List<int>();

		// Token: 0x0401F4AA RID: 128170
		private HashSet<int> NextPriority2IdList = new HashSet<int>();

		// Token: 0x0401F4AB RID: 128171
		private int TickPriority2HandleId;

		// Token: 0x0401F4AC RID: 128172
		private readonly Dictionary<int, Action<float>> TickGroupAfterTick = new Dictionary<int, Action<float>>();

		// Token: 0x0401F4AD RID: 128173
		private readonly HashSet<int> NextAfterTickIdList = new HashSet<int>();

		// Token: 0x0401F4AE RID: 128174
		private int AfterTickHandleId;

		// Token: 0x0401F4AF RID: 128175
		[Nullable(2)]
		private AActor PlotStreamingSource;

		// Token: 0x0401F4B0 RID: 128176
		[Nullable(2)]
		private AActor PlotIndependentStreamingSource;

		// Token: 0x0401F4B1 RID: 128177
		public int TestId;

		// Token: 0x0401F4B2 RID: 128178
		[Nullable(2)]
		private string PreloadPlotName;

		// Token: 0x0401F4B3 RID: 128179
		private int? PreloadPlotId;

		// Token: 0x0401F4B4 RID: 128180
		private int? PreloadStateId;

		// Token: 0x0401F4B5 RID: 128181
		[Nullable(2)]
		private UAnimMontage TriggerMontage;

		// Token: 0x0401F4B6 RID: 128182
		[Nullable(2)]
		private UAnimInstance TriggerAnimIns;
	}
}
