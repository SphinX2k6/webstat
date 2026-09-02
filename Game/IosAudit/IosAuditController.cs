using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.RenderData;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DataLayerSwitch;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Render;
using CSharpScript.Game.World.Controller;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.IosAudit
{
	// Token: 0x02006FC8 RID: 28616
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class IosAuditController : ControllerBase<IosAuditController>
	{
		// Token: 0x06045396 RID: 283542 RVA: 0x01213488 File Offset: 0x01211688
		[NullableContext(0)]
		private UniTask RunAfter(UniTask<bool> promise, [Nullable(2)] Action<bool> after)
		{
			IosAuditController.<RunAfter>d__12 <RunAfter>d__;
			<RunAfter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunAfter>d__.promise = promise;
			<RunAfter>d__.after = after;
			<RunAfter>d__.<>1__state = -1;
			<RunAfter>d__.<>t__builder.Start<IosAuditController.<RunAfter>d__12>(ref <RunAfter>d__);
			return <RunAfter>d__.<>t__builder.Task;
		}

		// Token: 0x06045397 RID: 283543 RVA: 0x012134D4 File Offset: 0x012116D4
		[NullableContext(0)]
		private UniTask<bool> RunLoadGroupAsync([TupleElementNames(new string[]
		{
			"Name",
			"Before",
			"Handle",
			"After"
		})] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2,
			1,
			0,
			2
		})] List<ValueTuple<string, Func<bool>, Func<UniTask<bool>>, Action<bool>>> handles)
		{
			IosAuditController.<RunLoadGroupAsync>d__13 <RunLoadGroupAsync>d__;
			<RunLoadGroupAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RunLoadGroupAsync>d__.<>4__this = this;
			<RunLoadGroupAsync>d__.handles = handles;
			<RunLoadGroupAsync>d__.<>1__state = -1;
			<RunLoadGroupAsync>d__.<>t__builder.Start<IosAuditController.<RunLoadGroupAsync>d__13>(ref <RunLoadGroupAsync>d__);
			return <RunLoadGroupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045398 RID: 283544 RVA: 0x01213520 File Offset: 0x01211720
		[return: Nullable(0)]
		private UniTask<bool> WatchOneControllerPreload(string name, CustomPromise<bool> promise)
		{
			IosAuditController.<WatchOneControllerPreload>d__14 <WatchOneControllerPreload>d__;
			<WatchOneControllerPreload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WatchOneControllerPreload>d__.name = name;
			<WatchOneControllerPreload>d__.promise = promise;
			<WatchOneControllerPreload>d__.<>1__state = -1;
			<WatchOneControllerPreload>d__.<>t__builder.Start<IosAuditController.<WatchOneControllerPreload>d__14>(ref <WatchOneControllerPreload>d__);
			return <WatchOneControllerPreload>d__.<>t__builder.Task;
		}

		// Token: 0x06045399 RID: 283545 RVA: 0x0121356B File Offset: 0x0121176B
		public void Start(SceneInformation sceneInformation)
		{
			this.StartAsync(sceneInformation).Forget();
		}

		// Token: 0x0604539A RID: 283546 RVA: 0x0121357C File Offset: 0x0121177C
		public UniTask StartAsync(SceneInformation sceneInformation)
		{
			IosAuditController.<StartAsync>d__16 <StartAsync>d__;
			<StartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartAsync>d__.<>4__this = this;
			<StartAsync>d__.sceneInformation = sceneInformation;
			<StartAsync>d__.<>1__state = -1;
			<StartAsync>d__.<>t__builder.Start<IosAuditController.<StartAsync>d__16>(ref <StartAsync>d__);
			return <StartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604539B RID: 283547 RVA: 0x012135C8 File Offset: 0x012117C8
		private UniTask ExecuteWorldDoneBlockers()
		{
			IosAuditController.<ExecuteWorldDoneBlockers>d__17 <ExecuteWorldDoneBlockers>d__;
			<ExecuteWorldDoneBlockers>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteWorldDoneBlockers>d__.<>4__this = this;
			<ExecuteWorldDoneBlockers>d__.<>1__state = -1;
			<ExecuteWorldDoneBlockers>d__.<>t__builder.Start<IosAuditController.<ExecuteWorldDoneBlockers>d__17>(ref <ExecuteWorldDoneBlockers>d__);
			return <ExecuteWorldDoneBlockers>d__.<>t__builder.Task;
		}

		// Token: 0x0604539C RID: 283548 RVA: 0x0121360C File Offset: 0x0121180C
		private UniTask RunWorldDoneBlockerAsync([TupleElementNames(new string[]
		{
			"Blocker",
			"Timeout"
		})] [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<Func<UniTask>, int> info, int index)
		{
			IosAuditController.<RunWorldDoneBlockerAsync>d__18 <RunWorldDoneBlockerAsync>d__;
			<RunWorldDoneBlockerAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunWorldDoneBlockerAsync>d__.<>4__this = this;
			<RunWorldDoneBlockerAsync>d__.info = info;
			<RunWorldDoneBlockerAsync>d__.index = index;
			<RunWorldDoneBlockerAsync>d__.<>1__state = -1;
			<RunWorldDoneBlockerAsync>d__.<>t__builder.Start<IosAuditController.<RunWorldDoneBlockerAsync>d__18>(ref <RunWorldDoneBlockerAsync>d__);
			return <RunWorldDoneBlockerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604539D RID: 283549 RVA: 0x01213660 File Offset: 0x01211860
		private UniTask RunBlockerWithCatch(Func<UniTask> blocker, int index)
		{
			IosAuditController.<RunBlockerWithCatch>d__19 <RunBlockerWithCatch>d__;
			<RunBlockerWithCatch>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunBlockerWithCatch>d__.blocker = blocker;
			<RunBlockerWithCatch>d__.index = index;
			<RunBlockerWithCatch>d__.<>1__state = -1;
			<RunBlockerWithCatch>d__.<>t__builder.Start<IosAuditController.<RunBlockerWithCatch>d__19>(ref <RunBlockerWithCatch>d__);
			return <RunBlockerWithCatch>d__.<>t__builder.Task;
		}

		// Token: 0x0604539E RID: 283550 RVA: 0x012136AB File Offset: 0x012118AB
		protected override bool OnLeaveLevel()
		{
			UHoldPreloadObject holdPreloadObject = this.HoldPreloadObject;
			if (holdPreloadObject != null)
			{
				holdPreloadObject.Clear();
			}
			this.HoldPreloadObject = null;
			return true;
		}

		// Token: 0x0604539F RID: 283551 RVA: 0x012136C8 File Offset: 0x012118C8
		private void ForceLowMemDeviceStreamingLowIfSanWangFengInstance(bool isSet)
		{
			if (!UKuroStaticLibrary.IsLowMemoryDevice())
			{
				return;
			}
			if (isSet)
			{
				this.HasOverrideQuality = true;
				this.LastGameQualityLevel = UKismetSystemLibrary.GetConsoleVariableIntValue("sg.KuroRenderQuality");
				if (this.LastGameQualityLevel > 1)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "sg.KuroRenderQuality 1", null);
				}
				if (!Singleton<GameSettingsDeviceRender>.Instance.IsTargetBaseProfile("IPad", false))
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.RuntimeLODBiasDeviceMappingIndices 274432", null);
				}
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.DepthOfFieldQuality 0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.ScreenSizeCullRatioFactor 85.0", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.StaticMeshLODDistanceScale 2.5", null);
				return;
			}
			if (this.HasOverrideQuality)
			{
				this.HasOverrideQuality = false;
				UObject world = GlobalData.World;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("sg.KuroRenderQuality ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastGameQualityLevel);
				UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.RuntimeLODBiasDeviceMappingIndices 274960", null);
			}
		}

		// Token: 0x060453A0 RID: 283552 RVA: 0x012137BC File Offset: 0x012119BC
		[NullableContext(0)]
		public UniTask<bool> PreloadIosAudit()
		{
			IosAuditController.<PreloadIosAudit>d__22 <PreloadIosAudit>d__;
			<PreloadIosAudit>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PreloadIosAudit>d__.<>4__this = this;
			<PreloadIosAudit>d__.<>1__state = -1;
			<PreloadIosAudit>d__.<>t__builder.Start<IosAuditController.<PreloadIosAudit>d__22>(ref <PreloadIosAudit>d__);
			return <PreloadIosAudit>d__.<>t__builder.Task;
		}

		// Token: 0x060453A1 RID: 283553 RVA: 0x01213800 File Offset: 0x01211A00
		public UniTask Load(SceneInformation sceneInformation)
		{
			IosAuditController.<Load>d__23 <Load>d__;
			<Load>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Load>d__.<>4__this = this;
			<Load>d__.sceneInformation = sceneInformation;
			<Load>d__.<>1__state = -1;
			<Load>d__.<>t__builder.Start<IosAuditController.<Load>d__23>(ref <Load>d__);
			return <Load>d__.<>t__builder.Task;
		}

		// Token: 0x060453A2 RID: 283554 RVA: 0x0121384B File Offset: 0x01211A4B
		private void CreateStat(string name)
		{
			Stat.CreateNoFlameGraph(name, "", "");
		}

		// Token: 0x060453A3 RID: 283555 RVA: 0x01213860 File Offset: 0x01211A60
		public void RegisterDataLayerChange()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance != null && instance.UseWorldPartition)
			{
				UDataLayerSubsystem udataLayerSubsystem = (UDataLayerSubsystem)UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UDataLayerSubsystem.StaticClass());
				if (udataLayerSubsystem != null)
				{
					if (!ModelBase<GameModeModel>.Instance.HasDataLayer(WorldDefine.SpecificVolumeDatalayer1.ToString()))
					{
						ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(WorldDefine.SpecificVolumeDatalayer1.ToString(), false, false);
					}
					if (!ModelBase<GameModeModel>.Instance.HasDataLayer(WorldDefine.SpecificVolumeDatalayer2.ToString()))
					{
						ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(WorldDefine.SpecificVolumeDatalayer2.ToString(), false, false);
					}
					udataLayerSubsystem.OnGlobalDataLayerActivationStateChanged.Add(new Action<FName, bool>(this.OnDatalayerChange));
					Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.HWK, "注册DataLayer变化监听", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.IosAudit;
				ELogAuthor author = ELogAuthor.HWK;
				string message = "注册DataLayer变化监听失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DatalayerSubSystem", udataLayerSubsystem);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x060453A4 RID: 283556 RVA: 0x01213974 File Offset: 0x01211B74
		private void OnDatalayerChange(FName datalayerLabel, bool bIsActive)
		{
			if (bIsActive && datalayerLabel != null && (datalayerLabel == WorldDefine.SpecificVolumeDatalayer1 || datalayerLabel == WorldDefine.SpecificVolumeDatalayer2) && !ModelBase<GameModeModel>.Instance.HasDataLayer(datalayerLabel.ToString()))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.IosAudit;
				ELogAuthor author = ELogAuthor.HWK;
				string message = "DataLayer在业务端未激活";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Datalayer", datalayerLabel);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(datalayerLabel.ToString(), false, false);
			}
		}

		// Token: 0x060453A5 RID: 283557 RVA: 0x01213A10 File Offset: 0x01211C10
		public void PreventEntityFalling()
		{
			ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.IosAudit, true);
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null && getCurrentEntity.Valid)
			{
				CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
				if (component != null && component.Valid)
				{
					TsBaseCharacter actor = component.Actor;
					if (actor != null && actor.IsValid())
					{
						UCharacterMovementComponent characterMovement = component.Actor.CharacterMovement;
						if (characterMovement != null && characterMovement.IsValid())
						{
							component.Actor.KuroSetMovementMode(new SetMovementModeInfo
							{
								Mode = EMovementMode.MOVE_None,
								Context = "[IosAuditController.PreventEntityFalling]"
							});
						}
					}
				}
			}
		}

		// Token: 0x060453A6 RID: 283558 RVA: 0x01213AA8 File Offset: 0x01211CA8
		public void EnableEntityFalling()
		{
			ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.IosAudit, false);
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null && getCurrentEntity.Valid)
			{
				CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
				if (component != null && component.Valid)
				{
					TsBaseCharacter actor = component.Actor;
					if (actor != null && actor.IsValid())
					{
						UCharacterMovementComponent characterMovement = component.Actor.CharacterMovement;
						if (characterMovement != null && characterMovement.IsValid())
						{
							component.Actor.KuroSetMovementMode(new SetMovementModeInfo
							{
								Mode = component.Actor.CharacterMovement.DefaultLandMovementMode,
								Context = "[IosAuditController.EnableEntityFalling]"
							});
						}
					}
				}
			}
		}

		// Token: 0x060453A7 RID: 283559 RVA: 0x01213B54 File Offset: 0x01211D54
		public void PrintWorldPartitionDebugInfo(UWorldPartitionStreamingSourceComponent streamingSourceComponent, [Nullable(2)] TArray<FName> inDataLayerLabels, bool bUseGridLoadingRange, float radius, bool bRequirePhysics)
		{
			if (streamingSourceComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.IosAudit, ELogAuthor.HWK, "WorldPartitionStreamingSourceComponent不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if ((UWorldPartitionSubsystem)UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.IosAudit, ELogAuthor.HWK, "WorldPartitionSubsystem不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			streamingSourceComponent.LogStreamingStuckInfo2(inDataLayerLabels, bUseGridLoadingRange, radius, bRequirePhysics);
		}

		// Token: 0x060453A8 RID: 283560 RVA: 0x01213BCA File Offset: 0x01211DCA
		[NullableContext(2)]
		public void SwitchDataLayer([Nullable(1)] string[] unloadDataLayers, [Nullable(1)] string[] activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
		{
			this.AwaitSwitchDataLayer(unloadDataLayers, activateDataLayers, callback, sequencePath, sequenceMarkBeforeModifyMaterial, materialDataForLoadedLayers, materialDataForUnloadLayers).Forget();
		}

		// Token: 0x060453A9 RID: 283561 RVA: 0x01213BE4 File Offset: 0x01211DE4
		private static void OnInterruptDataLayerSwitchTask()
		{
			Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "IosAudit:Task被打断,触发OnInterrupt收尾", default(ReadOnlySpan<ValueTuple<string, object>>));
			IosAuditController.InterruptDataLayerSwitch();
		}

		// Token: 0x060453AA RID: 283562 RVA: 0x01213C18 File Offset: 0x01211E18
		public static void InterruptDataLayerSwitch()
		{
			Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "IosAudit:打断DataLayer切换(InterruptDataLayerSwitch)", default(ReadOnlySpan<ValueTuple<string, object>>));
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SwitchDataLayerContext.AbortDataLayerSwitch();
		}

		// Token: 0x060453AB RID: 283563 RVA: 0x01213C58 File Offset: 0x01211E58
		[NullableContext(2)]
		public UniTask AwaitSwitchDataLayer([Nullable(1)] string[] unloadDataLayers, [Nullable(1)] string[] activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
		{
			IosAuditController.<AwaitSwitchDataLayer>d__33 <AwaitSwitchDataLayer>d__;
			<AwaitSwitchDataLayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AwaitSwitchDataLayer>d__.<>4__this = this;
			<AwaitSwitchDataLayer>d__.unloadDataLayers = unloadDataLayers;
			<AwaitSwitchDataLayer>d__.activateDataLayers = activateDataLayers;
			<AwaitSwitchDataLayer>d__.callback = callback;
			<AwaitSwitchDataLayer>d__.sequencePath = sequencePath;
			<AwaitSwitchDataLayer>d__.sequenceMarkBeforeModifyMaterial = sequenceMarkBeforeModifyMaterial;
			<AwaitSwitchDataLayer>d__.materialDataForLoadedLayers = materialDataForLoadedLayers;
			<AwaitSwitchDataLayer>d__.materialDataForUnloadLayers = materialDataForUnloadLayers;
			<AwaitSwitchDataLayer>d__.<>1__state = -1;
			<AwaitSwitchDataLayer>d__.<>t__builder.Start<IosAuditController.<AwaitSwitchDataLayer>d__33>(ref <AwaitSwitchDataLayer>d__);
			return <AwaitSwitchDataLayer>d__.<>t__builder.Task;
		}

		// Token: 0x060453AC RID: 283564 RVA: 0x01213CD8 File Offset: 0x01211ED8
		[NullableContext(2)]
		[return: Nullable(1)]
		private AsyncTask CreateSwitchDataLayerTask([Nullable(1)] string[] unloadDataLayers, [Nullable(1)] string[] activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
		{
			IosAuditController.<>c__DisplayClass34_0 CS$<>8__locals1 = new IosAuditController.<>c__DisplayClass34_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.unloadDataLayers = unloadDataLayers;
			CS$<>8__locals1.activateDataLayers = activateDataLayers;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.sequencePath = sequencePath;
			CS$<>8__locals1.sequenceMarkBeforeModifyMaterial = sequenceMarkBeforeModifyMaterial;
			CS$<>8__locals1.materialDataForLoadedLayers = materialDataForLoadedLayers;
			CS$<>8__locals1.materialDataForUnloadLayers = materialDataForUnloadLayers;
			if (!StringUtils.IsBlank(CS$<>8__locals1.materialDataForLoadedLayers) || !StringUtils.IsBlank(CS$<>8__locals1.materialDataForUnloadLayers))
			{
				Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "IosAudit:选择材质过渡切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
				CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunMaterialSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.callback, CS$<>8__locals1.sequencePath, CS$<>8__locals1.sequenceMarkBeforeModifyMaterial, CS$<>8__locals1.materialDataForLoadedLayers, CS$<>8__locals1.materialDataForUnloadLayers));
			}
			else if (!StringUtils.IsBlank(CS$<>8__locals1.sequencePath))
			{
				Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "IosAudit:选择序列切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
				CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunLevelSeqSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.sequencePath, CS$<>8__locals1.callback));
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "IosAudit:选择普通切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
				CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunNormalSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.callback));
			}
			string name = "SwitchDataLayer";
			Func<UniTask<bool>> runHandle = delegate()
			{
				IosAuditController.<>c__DisplayClass34_0.<<CreateSwitchDataLayerTask>b__3>d <<CreateSwitchDataLayerTask>b__3>d;
				<<CreateSwitchDataLayerTask>b__3>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<CreateSwitchDataLayerTask>b__3>d.<>4__this = CS$<>8__locals1;
				<<CreateSwitchDataLayerTask>b__3>d.<>1__state = -1;
				<<CreateSwitchDataLayerTask>b__3>d.<>t__builder.Start<IosAuditController.<>c__DisplayClass34_0.<<CreateSwitchDataLayerTask>b__3>d>(ref <<CreateSwitchDataLayerTask>b__3>d);
				return <<CreateSwitchDataLayerTask>b__3>d.<>t__builder.Task;
			};
			Func<bool> initHandle = null;
			Action<bool> finishedCallback = null;
			ETaskPriority priority = ETaskPriority.Normal;
			bool interruptible = true;
			Action onInterrupt;
			if ((onInterrupt = IosAuditController.<>O.<0>__OnInterruptDataLayerSwitchTask) == null)
			{
				onInterrupt = (IosAuditController.<>O.<0>__OnInterruptDataLayerSwitchTask = new Action(IosAuditController.OnInterruptDataLayerSwitchTask));
			}
			return new AsyncTask(name, runHandle, initHandle, finishedCallback, new TaskInterruptOptions(priority, interruptible, onInterrupt));
		}

		// Token: 0x060453AD RID: 283565 RVA: 0x01213E20 File Offset: 0x01212020
		private void PrepareSwitchDataLayer()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.IosAudit;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "IosAudit:准备切换DataLayer";
			string item = "InstId";
			InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().Id : 0);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			bool flag = (((instanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().Id) : null) ?? 0) == 0;
			if (flag)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.IosAudit;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "切换DataLayer:InstId为0或空";
				string item2 = "InstId";
				instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (instanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().Id) : null);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			DataLayerSwitchContext switchDataLayerContext = ModelBase<GameModeModel>.Instance.SwitchDataLayerContext;
			switchDataLayerContext.ResetDataLayerSwitchAbort();
			instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			switchDataLayerContext.BeginDataLayerSwitch((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().Id : 0);
		}

		// Token: 0x060453AE RID: 283566 RVA: 0x01213F72 File Offset: 0x01212172
		private bool CheckAndTryFakeSwitchDataLayer(string[] unloadDataLayers, string[] activateDataLayers, [Nullable(2)] Action<bool> callback = null)
		{
			AutoRunModel instance = ModelBase<AutoRunModel>.Instance;
			if (instance != null && instance.IsInLogicTreeGmMode())
			{
				this.FakeSwitchDataLayerInternal(unloadDataLayers, activateDataLayers, ModelBase<GameModeModel>.Instance.SwitchDataLayerContext.CurrentSwitchInstId, callback);
				return true;
			}
			return false;
		}

		// Token: 0x060453AF RID: 283567 RVA: 0x01213FA4 File Offset: 0x012121A4
		private UniTask RunNormalSwitchTask(string[] unloadDataLayers, string[] activateDataLayers, [Nullable(2)] Action<bool> callback = null)
		{
			IosAuditController.<RunNormalSwitchTask>d__37 <RunNormalSwitchTask>d__;
			<RunNormalSwitchTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunNormalSwitchTask>d__.<>4__this = this;
			<RunNormalSwitchTask>d__.unloadDataLayers = unloadDataLayers;
			<RunNormalSwitchTask>d__.activateDataLayers = activateDataLayers;
			<RunNormalSwitchTask>d__.callback = callback;
			<RunNormalSwitchTask>d__.<>1__state = -1;
			<RunNormalSwitchTask>d__.<>t__builder.Start<IosAuditController.<RunNormalSwitchTask>d__37>(ref <RunNormalSwitchTask>d__);
			return <RunNormalSwitchTask>d__.<>t__builder.Task;
		}

		// Token: 0x060453B0 RID: 283568 RVA: 0x01214000 File Offset: 0x01212200
		private UniTask RunLevelSeqSwitchTask(string[] unloadDataLayers, string[] activateDataLayers, string sequencePath, [Nullable(2)] Action<bool> callback = null)
		{
			IosAuditController.<RunLevelSeqSwitchTask>d__38 <RunLevelSeqSwitchTask>d__;
			<RunLevelSeqSwitchTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunLevelSeqSwitchTask>d__.<>4__this = this;
			<RunLevelSeqSwitchTask>d__.unloadDataLayers = unloadDataLayers;
			<RunLevelSeqSwitchTask>d__.activateDataLayers = activateDataLayers;
			<RunLevelSeqSwitchTask>d__.sequencePath = sequencePath;
			<RunLevelSeqSwitchTask>d__.callback = callback;
			<RunLevelSeqSwitchTask>d__.<>1__state = -1;
			<RunLevelSeqSwitchTask>d__.<>t__builder.Start<IosAuditController.<RunLevelSeqSwitchTask>d__38>(ref <RunLevelSeqSwitchTask>d__);
			return <RunLevelSeqSwitchTask>d__.<>t__builder.Task;
		}

		// Token: 0x060453B1 RID: 283569 RVA: 0x01214064 File Offset: 0x01212264
		[NullableContext(2)]
		private UniTask RunMaterialSwitchTask([Nullable(1)] string[] unloadDataLayers, [Nullable(1)] string[] activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
		{
			IosAuditController.<RunMaterialSwitchTask>d__39 <RunMaterialSwitchTask>d__;
			<RunMaterialSwitchTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunMaterialSwitchTask>d__.<>4__this = this;
			<RunMaterialSwitchTask>d__.unloadDataLayers = unloadDataLayers;
			<RunMaterialSwitchTask>d__.activateDataLayers = activateDataLayers;
			<RunMaterialSwitchTask>d__.callback = callback;
			<RunMaterialSwitchTask>d__.sequencePath = sequencePath;
			<RunMaterialSwitchTask>d__.sequenceMarkBeforeModifyMaterial = sequenceMarkBeforeModifyMaterial;
			<RunMaterialSwitchTask>d__.materialDataForLoadedLayers = materialDataForLoadedLayers;
			<RunMaterialSwitchTask>d__.materialDataForUnloadLayers = materialDataForUnloadLayers;
			<RunMaterialSwitchTask>d__.<>1__state = -1;
			<RunMaterialSwitchTask>d__.<>t__builder.Start<IosAuditController.<RunMaterialSwitchTask>d__39>(ref <RunMaterialSwitchTask>d__);
			return <RunMaterialSwitchTask>d__.<>t__builder.Task;
		}

		// Token: 0x060453B2 RID: 283570 RVA: 0x012140E4 File Offset: 0x012122E4
		private UniTask NormalSwitchDataLayerInternal(string[] unloadDataLayers, string[] activateDataLayers, bool bEnterLoadingMode = true, bool bWaitingRenderAssetDone = true)
		{
			IosAuditController.<NormalSwitchDataLayerInternal>d__40 <NormalSwitchDataLayerInternal>d__;
			<NormalSwitchDataLayerInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NormalSwitchDataLayerInternal>d__.<>4__this = this;
			<NormalSwitchDataLayerInternal>d__.unloadDataLayers = unloadDataLayers;
			<NormalSwitchDataLayerInternal>d__.activateDataLayers = activateDataLayers;
			<NormalSwitchDataLayerInternal>d__.bEnterLoadingMode = bEnterLoadingMode;
			<NormalSwitchDataLayerInternal>d__.bWaitingRenderAssetDone = bWaitingRenderAssetDone;
			<NormalSwitchDataLayerInternal>d__.<>1__state = -1;
			<NormalSwitchDataLayerInternal>d__.<>t__builder.Start<IosAuditController.<NormalSwitchDataLayerInternal>d__40>(ref <NormalSwitchDataLayerInternal>d__);
			return <NormalSwitchDataLayerInternal>d__.<>t__builder.Task;
		}

		// Token: 0x060453B3 RID: 283571 RVA: 0x01214148 File Offset: 0x01212348
		private unsafe void FakeSwitchDataLayerInternal(string[] unloadDataLayers, string[] activateDataLayers, int instId, [Nullable(2)] Action<bool> callback = null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.IosAudit;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "伪切换DataLayer:(开始)";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("卸载的DataLayer", string.Join(",", unloadDataLayers ?? Array.Empty<string>()));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("加载的DataLayer", string.Join(",", activateDataLayers ?? Array.Empty<string>()));
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "伪切换DataLayer:更新缓存的DataLayer变更信息", default(ReadOnlySpan<ValueTuple<string, object>>));
			AutoRunModel instance2 = ModelBase<AutoRunModel>.Instance;
			if (instance2 != null)
			{
				instance2.UpdateCachedDataLayerInfo(activateDataLayers, unloadDataLayers, null);
			}
			Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.ZYL, "伪切换DataLayer:通知服务器切换完成", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ChangeDataLayerFinishRequest(instId);
			Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.CJH, "伪切换DataLayer:(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
			GameModeModel instance3 = ModelBase<GameModeModel>.Instance;
			if (instance3 != null)
			{
				instance3.SwitchDataLayerContext.FinishDataLayerSwitch();
			}
			if (callback != null)
			{
				callback(true);
			}
		}

		// Token: 0x060453B4 RID: 283572 RVA: 0x01214271 File Offset: 0x01212471
		public bool IsInInstance()
		{
			return ModelBase<GameModeModel>.Instance.InstanceType >= InstanceType.NormalInstance;
		}

		// Token: 0x060453B5 RID: 283573 RVA: 0x01214284 File Offset: 0x01212484
		public bool CanLoadEntity()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			return instance.WorldDone && !instance.IsTeleport && !instance.ChangeModeState;
		}

		// Token: 0x060453B6 RID: 283574 RVA: 0x012142B4 File Offset: 0x012124B4
		public void InitAllPlayerStarts()
		{
			TArray<AActor> tarray = new TArray<AActor>();
			UGameplayStatics.GetAllActorsOfClass(GlobalData.World, APlayerStart.StaticClass(), ref tarray);
			ModelBase<GameModeModel>.Instance.ClearPlayerStart();
			if (tarray.Num() > 0)
			{
				for (int i = 0; i < tarray.Num(); i++)
				{
					ModelBase<GameModeModel>.Instance.AddPlayerStart((APlayerStart)tarray.Get(i));
				}
			}
		}

		// Token: 0x060453B7 RID: 283575 RVA: 0x01214318 File Offset: 0x01212518
		public unsafe void PrintLoadDetail(FVectorDouble bornLocation)
		{
			LogProfiler loadWorldProfiler = ModelBase<GameModeModel>.Instance.LoadWorldProfiler;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "加载详情";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MapPath", ModelBase<GameModeModel>.Instance.MapPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("耗时", loadWorldProfiler.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			List<ValueTuple<string, int>> resourcesLoadTime = ModelBase<PreloadModelNew>.Instance.ResourcesLoadTime;
			resourcesLoadTime.Sort(([Nullable(new byte[]
			{
				0,
				1
			})] ValueTuple<string, int> a, [Nullable(new byte[]
			{
				0,
				1
			})] ValueTuple<string, int> b) => b.Item2 - a.Item2);
			if (UKuroStaticLibrary.IsWithEditor())
			{
				float piestartTimeInSeconds = UKuroStaticLibrary.GetPIEStartTimeInSeconds();
				float platformTimeInSeconds = UKuroStaticLibrary.GetPlatformTimeInSeconds();
				string commandLine = UKismetSystemLibrary.GetCommandLine();
				string value = IosAuditController.<PrintLoadDetail>g__GetCmdValue|45_1(commandLine, "-KuroPipelineTag=");
				string[] array = IosAuditController.<PrintLoadDetail>g__GetCmdValue|45_1(commandLine, "-KuroTsSilentLoginTestFile=").Replace("/", "\\").Split("\\", StringSplitOptions.None);
				string value2 = array[array.Length - 1];
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["Version"] = Singleton<BaseConfigController>.Instance.GetVersionString();
				dictionary["LoadingTime"] = (platformTimeInSeconds - piestartTimeInSeconds).ToString();
				dictionary["MapPath"] = ModelBase<GameModeModel>.Instance.MapPath;
				dictionary["BornLocation"] = bornLocation.ToString();
				dictionary["TestName"] = value2;
				dictionary["PipelineTag"] = value;
				string text = Json.Stringify<Dictionary<string, string>>(dictionary, null);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.IosAudit;
				ELogAuthor author2 = ELogAuthor.HMH;
				string message2 = "UE_TraceProfile_Event";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", text);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (FThinkingAnalyticsForCSharp.Track("UE_TraceProfile_Event", text, 21))
				{
					TimerSystem.Instance.Next(delegate(float _)
					{
						FThinkingAnalyticsForCSharp.Flush(21);
					}, null, null);
				}
				else
				{
					Singleton<Log>.Instance.Warn(ELogModule.IosAudit, ELogAuthor.HMH, "TraceProfile report fail", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			if (!ModelBase<PreloadModelNew>.Instance.LoadAssetOneByOneState)
			{
				return;
			}
			int num = 0;
			while (num < 20 && num < resourcesLoadTime.Count)
			{
				ValueTuple<string, int> valueTuple2 = resourcesLoadTime[num];
				int item = valueTuple2.Item2;
				string text2;
				if (item >= 1000)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
					defaultInterpolatedStringHandler.AppendFormatted<float>((float)item / 1000f);
					defaultInterpolatedStringHandler.AppendLiteral(" s");
					text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(item);
					defaultInterpolatedStringHandler.AppendLiteral(" ms");
					text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				string item2 = text2;
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.World;
				ELogAuthor author3 = ELogAuthor.LFJW;
				string message3 = "资源耗时Top20";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("耗时", item2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("资源路径", valueTuple2.Item1);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				num++;
			}
			ModelBase<PreloadModelNew>.Instance.ClearResourcesLoadTime();
		}

		// Token: 0x060453B8 RID: 283576 RVA: 0x01214628 File Offset: 0x01212828
		public unsafe void SetTimeDilation(float timeDilation, ETimeDilationType timeDilationType = ETimeDilationType.Default)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.IosAudit;
			ELogAuthor author = ELogAuthor.XWX;
			string message = "时停:调用假时停";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timeDilation", timeDilation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timeDilationType", timeDilationType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Dictionary<ETimeDilationType, float> timeDilationMap = ModelBase<GameModeModel>.Instance.TimeDilationMap;
			if (timeDilation == 1f)
			{
				timeDilationMap.Remove(timeDilationType);
			}
			else
			{
				timeDilationMap[timeDilationType] = timeDilation;
			}
			if (ModelBase<GameModeModel>.Instance.ForceDisableGamePaused)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.IosAudit;
				ELogAuthor author2 = ELogAuthor.JYS;
				string message2 = "时停:由于在传送过程中，不执行假时停，只保存";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("timeDilation", timeDilation);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("timeDilationType", timeDilationType);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			float num = 1f;
			float num2 = 1f;
			foreach (KeyValuePair<ETimeDilationType, float> keyValuePair in timeDilationMap)
			{
				bool key = keyValuePair.Key != ETimeDilationType.Default;
				float value = keyValuePair.Value;
				num *= value;
				if (((key ? 1 : 0) & 3) == 0)
				{
					num2 *= value;
				}
			}
			if ((double)num < 1E-08)
			{
				num = 0f;
			}
			if ((double)num2 < 1E-08)
			{
				num2 = 0f;
			}
			if ((timeDilationType & ETimeDilationType.PhantomBattleArena) == ETimeDilationType.Default)
			{
				Singleton<Time>.Instance.OriginTimeDilation = num2;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.IosAudit;
			ELogAuthor author3 = ELogAuthor.XWX;
			string message3 = "时停:假时停计算后的值";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("finalDilation", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("finalDilationWithoutPause", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("Time.OriginTimeDilation", Singleton<Time>.Instance.OriginTimeDilation);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			if (Singleton<TickSystem>.Instance.IsSetPaused && !Singleton<TickSystem>.Instance.IsPaused)
			{
				ModelBase<GameModeModel>.Instance.SetCacheTimeDilationValue(num);
				return;
			}
			this.BroadcastTimeDilation(num);
		}

		// Token: 0x060453B9 RID: 283577 RVA: 0x01214874 File Offset: 0x01212A74
		private void BroadcastTimeDilation(float finalDilation)
		{
			ModelBase<GameModeModel>.Instance.ClearCacheTimeDilationValue();
			Singleton<Time>.Instance.SetTimeDilation(finalDilation);
			ControllerBase<TimeOfDayController>.Instance.ChangeTimeScale(finalDilation);
			ControllerBase<CharacterController>.Instance.SetTimeDilation(finalDilation);
			ControllerBase<FormationDataController>.Instance.SetTimeDilation(finalDilation);
			ControllerBase<BulletController>.Instance.SetTimeDilation(finalDilation);
			ControllerBase<CameraController>.Instance.SetTimeDilation(finalDilation, "MainCamera");
			ControllerBase<ComponentForceTickController>.Instance.SetTimeDilation(finalDilation);
			Singleton<EffectEnvironment>.Instance.GlobalTimeScale = finalDilation;
			TimeStopPush timeStopPush = TimeStopPush.Create();
			timeStopPush.TimeDilation = finalDilation;
			Singleton<Net>.Instance.Send(EPushMessageId.TimeStopPush, timeStopPush);
			if (finalDilation == 0f)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PauseGame, 1);
			}
			if (finalDilation == 1f)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PauseGame, 0);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.TriggerUiTimeDilation);
		}

		// Token: 0x060453BA RID: 283578 RVA: 0x01214944 File Offset: 0x01212B44
		[NullableContext(2)]
		public void FixBornLocation(global::Vector target = null)
		{
			if (Global.BaseCharacter == null)
			{
				return;
			}
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			RoleDriveVehicleComponent roleDriveVehicleComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<RoleDriveVehicleComponent>() : null;
			if (roleDriveVehicleComponent != null && roleDriveVehicleComponent.IsOnVehicle)
			{
				return;
			}
			if (target != null)
			{
				Global.BaseCharacter.CharacterActorComponent.TeleportAndFindStandLocation(target, true);
			}
			else
			{
				Global.BaseCharacter.CharacterActorComponent.FixBornLocation("主控玩家.修正地面", true, null, false, false, true);
			}
			Global.BaseCharacter.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Walking,
				Context = "[IosAuditController.FixBornLocation]"
			});
			Entity entity = Global.BaseCharacter.CharacterActorComponent.Entity;
			CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
			if (component != null)
			{
				UAnimInstance mainAnimInstance = component.MainAnimInstance;
				if (mainAnimInstance != null)
				{
					mainAnimInstance.SyncAnimStates(null);
				}
			}
			CharacterMoveComponent component2 = entity.GetComponent<CharacterMoveComponent>();
			if (component2 != null)
			{
				component2.StopAllAddMove();
			}
			CharacterUnifiedStateComponent component3 = entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component3 == null)
			{
				return;
			}
			component3.ResetCharState();
		}

		// Token: 0x060453BB RID: 283579 RVA: 0x01214A20 File Offset: 0x01212C20
		public unsafe void LoadDataLayers(SceneInformation sceneInformation)
		{
			bool flag = UKuroStaticLibrary.IsLowMemoryDevice();
			if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
			{
				int physicalGBRam = Singleton<GameSettingsDeviceRender>.Instance.PhysicalGBRam;
				bool flag2 = physicalGBRam <= 6;
				flag = (flag || flag2);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.IosAudit;
				ELogAuthor author = ELogAuthor.RY;
				string message = "判断Android低内存";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PhysicalMemory", flag2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("totalMemoryGB", physicalGBRam);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState("DatalayerRuntime_HideInLowMemDevice", !flag, false);
			if (((sceneInformation != null) ? sceneInformation.DataLayers : null) == null)
			{
				return;
			}
			List<string> list = new List<string>(ModelBase<GameModeModel>.Instance.GetAllDataLayers());
			foreach (int num in sceneInformation.DataLayers)
			{
				DataLayerConfig? config = ConfigDataLayerConfigById.GetConfig(num, true);
				if (config == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.IosAudit;
					ELogAuthor author2 = ELogAuthor.LFJW;
					string message2 = "加载场景:加载DataLayer失败,不存在的配置Id";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DataLayerId:", num);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					string dataLayer = config.Value.DataLayer;
					if (ModelBase<GameModeModel>.Instance.HasDataLayer(dataLayer))
					{
						int num2 = list.IndexOf(dataLayer);
						if (num2 >= 0)
						{
							list.RemoveAt(num2);
						}
					}
					else
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.IosAudit;
						ELogAuthor author3 = ELogAuthor.LFJW;
						string message3 = "加载场景:加载DataLayer";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DataLayer", dataLayer);
						instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						this.ActivateDataLayer(dataLayer);
					}
				}
			}
			foreach (string dataLayerPath in list)
			{
				this.UnloadDataLayer(dataLayerPath);
			}
		}

		// Token: 0x060453BC RID: 283580 RVA: 0x01214C24 File Offset: 0x01212E24
		private void ActivateDataLayer(string dataLayerPath)
		{
			ModelBase<GameModeModel>.Instance.AddDataLayer(dataLayerPath);
			ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(dataLayerPath, true, false);
		}

		// Token: 0x060453BD RID: 283581 RVA: 0x01214C3F File Offset: 0x01212E3F
		private void UnloadDataLayer(string dataLayerPath)
		{
			ModelBase<GameModeModel>.Instance.RemoveDataLayer(dataLayerPath);
			ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(dataLayerPath, false, false);
		}

		// Token: 0x060453BE RID: 283582 RVA: 0x01214C5C File Offset: 0x01212E5C
		private void ChangeDataLayerFinishRequest(int instId)
		{
			ChangeDataLayerFinishRequest changeDataLayerFinishRequest = Aki.Protocol.ChangeDataLayerFinishRequest.Create();
			changeDataLayerFinishRequest.InstId = instId;
			Singleton<Net>.Instance.Call<ChangeDataLayerFinishResponse>(ERequestMessageId.ChangeDataLayerFinishRequest, changeDataLayerFinishRequest, delegate(ChangeDataLayerFinishResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.ChangeDataLayerFinishResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060453BF RID: 283583 RVA: 0x01214CA8 File Offset: 0x01212EA8
		public unsafe void ApplyMaterialParameterCollection(IDictionary<int, int> protoAreaMpc)
		{
			ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap.Clear();
			foreach (KeyValuePair<int, int> keyValuePair in protoAreaMpc)
			{
				int key = keyValuePair.Key;
				string mpcData = ConfigAreaMpcById.GetConfig(keyValuePair.Value, true).Value.MpcData;
				if (StringUtils.IsBlank(mpcData) || mpcData == "None" || mpcData == "Empty")
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.IosAudit;
					ELogAuthor author = ELogAuthor.CJH;
					string message = "加载场景: 未配置对应区域的MPCData";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AreaId", key);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MpcData", mpcData);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap[mpcData] = false;
				}
			}
			if (ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap.Count == 0)
			{
				ModelBase<GameModeModel>.Instance.ApplyMaterialParameterCollectionPromise.SetResult(true);
				return;
			}
			using (Dictionary<string, bool>.KeyCollection.Enumerator enumerator2 = ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap.Keys.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					string inPath = enumerator2.Current;
					Singleton<ResourceSystem>.Instance.LoadAsync<ItemMaterialControllerMPCData_C>(inPath, delegate([Nullable(2)] ItemMaterialControllerMPCData_C data, string _)
					{
						if (data == null || !data.IsValid())
						{
							Singleton<Log>.Instance.Error(ELogModule.IosAudit, ELogAuthor.CJH, "加载场景: MPCData无效", default(ReadOnlySpan<ValueTuple<string, object>>));
							ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap[inPath] = true;
							this.CheckMaterialParameterCollectionLoaded();
							return;
						}
						ModelBase<RenderModuleModel>.Instance.UpdateItemMaterialParameterCollection(data);
						ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap[inPath] = true;
						this.CheckMaterialParameterCollectionLoaded();
					}, 100, "js_undefined");
				}
			}
		}

		// Token: 0x060453C0 RID: 283584 RVA: 0x01214E60 File Offset: 0x01213060
		private void CheckMaterialParameterCollectionLoaded()
		{
			bool flag = true;
			foreach (bool flag2 in ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap.Values)
			{
				flag = (flag2 && flag);
			}
			if (flag)
			{
				ModelBase<GameModeModel>.Instance.ApplyMaterialParameterCollectionPromise.SetResult(true);
			}
		}

		// Token: 0x060453C1 RID: 283585 RVA: 0x01214ECC File Offset: 0x012130CC
		public UniTask SwitchStreamingSource(AActor actor, bool waitForStreaming, bool bLockMovementDuringStreaming, EMovementLockMode? movementLockModeAfterStreaming)
		{
			IosAuditController.<SwitchStreamingSource>d__55 <SwitchStreamingSource>d__;
			<SwitchStreamingSource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SwitchStreamingSource>d__.<>4__this = this;
			<SwitchStreamingSource>d__.actor = actor;
			<SwitchStreamingSource>d__.waitForStreaming = waitForStreaming;
			<SwitchStreamingSource>d__.bLockMovementDuringStreaming = bLockMovementDuringStreaming;
			<SwitchStreamingSource>d__.movementLockModeAfterStreaming = movementLockModeAfterStreaming;
			<SwitchStreamingSource>d__.<>1__state = -1;
			<SwitchStreamingSource>d__.<>t__builder.Start<IosAuditController.<SwitchStreamingSource>d__55>(ref <SwitchStreamingSource>d__);
			return <SwitchStreamingSource>d__.<>t__builder.Task;
		}

		// Token: 0x060453C2 RID: 283586 RVA: 0x01214F30 File Offset: 0x01213130
		private UniTask CheckWorldPartitionStreamingCompleted(CustomPromise<bool> voxelPromise, CustomPromise<bool> streamingPromise, [Nullable(2)] Func<bool> abortCheckCondition = null)
		{
			IosAuditController.<CheckWorldPartitionStreamingCompleted>d__56 <CheckWorldPartitionStreamingCompleted>d__;
			<CheckWorldPartitionStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckWorldPartitionStreamingCompleted>d__.<>4__this = this;
			<CheckWorldPartitionStreamingCompleted>d__.voxelPromise = voxelPromise;
			<CheckWorldPartitionStreamingCompleted>d__.streamingPromise = streamingPromise;
			<CheckWorldPartitionStreamingCompleted>d__.abortCheckCondition = abortCheckCondition;
			<CheckWorldPartitionStreamingCompleted>d__.<>1__state = -1;
			<CheckWorldPartitionStreamingCompleted>d__.<>t__builder.Start<IosAuditController.<CheckWorldPartitionStreamingCompleted>d__56>(ref <CheckWorldPartitionStreamingCompleted>d__);
			return <CheckWorldPartitionStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x060453C3 RID: 283587 RVA: 0x01214F8C File Offset: 0x0121318C
		[NullableContext(2)]
		[return: Nullable(1)]
		private unsafe TimerHandle CheckTargetStreamingCompleted([Nullable(1)] UWorldPartitionStreamingSourceComponent streamingSourceComponent, [Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<CustomPromise<bool>, GameModePromise> completedPromise, TArray<FName> dataLayerLabels = null, Action<float> progressUpdated = null, bool checkPhysics = false, Func<bool> abortCheckCondition = null)
		{
			TArray<FName> targetGrids = streamingSourceComponent.TargetGrids;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.XY;
			string message = "[CheckTargetStreamingCompleted] 检测参数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dataLayers", (dataLayerLabels != null && dataLayerLabels.Num() > 0) ? dataLayerLabels.Get(0).ToString() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetGrids", (targetGrids != null && targetGrids.Num() > 0) ? targetGrids.Get(0).ToString() : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			bool isCheckingPhysics = false;
			int streamingStuckLogInternal = 0;
			TimerHandle timerId = null;
			timerId = TimerSystem.Instance.Forever(delegate(float _)
			{
				Func<bool> abortCheckCondition2 = abortCheckCondition;
				if (abortCheckCondition2 != null && abortCheckCondition2())
				{
					Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.CK, "检查加载场景提前结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					if (!isCheckingPhysics)
					{
						bool flag = streamingSourceComponent.IsStreamingCompletedForLayers2(dataLayerLabels, false, 7000f, true, ref this.cellProgress, false);
						if (progressUpdated != null)
						{
							progressUpdated(this.cellProgress);
						}
						if (!flag)
						{
							base.<CheckTargetStreamingCompleted>g__TimerStreamingStuckLog|1(isCheckingPhysics);
							return;
						}
						isCheckingPhysics = checkPhysics;
						if (isCheckingPhysics)
						{
							Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.XY, "加载场景:检测场景物理体(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
						}
					}
					if (isCheckingPhysics)
					{
						if (!streamingSourceComponent.IsStreamingCompletedForLayers2(dataLayerLabels, false, 7000f, false, ref this.cellProgress, true))
						{
							base.<CheckTargetStreamingCompleted>g__TimerStreamingStuckLog|1(isCheckingPhysics);
							return;
						}
						Singleton<Log>.Instance.Info(ELogModule.IosAudit, ELogAuthor.XY, "加载场景:检测场景物理体(结束)", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				if (timerId != null)
				{
					TimerSystem.Instance.Remove(timerId);
				}
				if (completedPromise.IsT1)
				{
					completedPromise.AsT1.SetResult(true);
					return;
				}
				if (completedPromise.IsT2)
				{
					completedPromise.AsT2.SetResult(true);
				}
			}, 100f, 1f, null, null, true);
			return timerId;
		}

		// Token: 0x060453C4 RID: 283588 RVA: 0x012150CC File Offset: 0x012132CC
		public void InitStreamingSources()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (!GlobalData.World.GetWorld().K2_GetWorldSettings().bEnableWorldPartition || instance.BornLocation == null)
			{
				return;
			}
			instance.InitStreamingSources();
		}

		// Token: 0x060453C5 RID: 283589 RVA: 0x0121510C File Offset: 0x0121330C
		public UniTask CheckVoxelStreamingCompleted(float relativeProgress, int maxProgress)
		{
			IosAuditController.<CheckVoxelStreamingCompleted>d__59 <CheckVoxelStreamingCompleted>d__;
			<CheckVoxelStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckVoxelStreamingCompleted>d__.<>4__this = this;
			<CheckVoxelStreamingCompleted>d__.relativeProgress = relativeProgress;
			<CheckVoxelStreamingCompleted>d__.maxProgress = maxProgress;
			<CheckVoxelStreamingCompleted>d__.<>1__state = -1;
			<CheckVoxelStreamingCompleted>d__.<>t__builder.Start<IosAuditController.<CheckVoxelStreamingCompleted>d__59>(ref <CheckVoxelStreamingCompleted>d__);
			return <CheckVoxelStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x060453C6 RID: 283590 RVA: 0x01215160 File Offset: 0x01213360
		public void AppendAllBaseDatalayers(TArray<FName> dataLayerLabels)
		{
			foreach (FName value in WorldDefine.allBaseDataLayers)
			{
				dataLayerLabels.Add(value);
			}
		}

		// Token: 0x060453C7 RID: 283591 RVA: 0x01215190 File Offset: 0x01213390
		public UniTask CheckStreamingCompleted(float relativeProgress, int maxProgress)
		{
			IosAuditController.<CheckStreamingCompleted>d__61 <CheckStreamingCompleted>d__;
			<CheckStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckStreamingCompleted>d__.<>4__this = this;
			<CheckStreamingCompleted>d__.relativeProgress = relativeProgress;
			<CheckStreamingCompleted>d__.maxProgress = maxProgress;
			<CheckStreamingCompleted>d__.<>1__state = -1;
			<CheckStreamingCompleted>d__.<>t__builder.Start<IosAuditController.<CheckStreamingCompleted>d__61>(ref <CheckStreamingCompleted>d__);
			return <CheckStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x060453C8 RID: 283592 RVA: 0x012151E4 File Offset: 0x012133E4
		public void AddOrRemoveRenderAssetsQueryViewInfo(FVectorDouble viewOrigin, float duration)
		{
			if (!GlobalData.World.GetWorld().K2_GetWorldSettings().bEnableWorldPartition)
			{
				return;
			}
			UWorldPartitionSubsystem uworldPartitionSubsystem = (UWorldPartitionSubsystem)UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass());
			if (uworldPartitionSubsystem == null || !uworldPartitionSubsystem.IsValid())
			{
				return;
			}
			uworldPartitionSubsystem.D_AddOrRemoveRenderAssetsQueryViewInfo(viewOrigin, duration, 1.2f);
		}

		// Token: 0x060453C9 RID: 283593 RVA: 0x01215244 File Offset: 0x01213444
		[NullableContext(2)]
		private void ResetRenderAssetsQuery(UWorldPartitionSubsystem worldPartitionSubsystem = null, FWorldPartitionStreamingQuerySource querySource = null, bool? raiseError = null)
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			TimerHandle checkRenderAssetsStreamingCompletedTimerId = instance.CheckRenderAssetsStreamingCompletedTimerId;
			if (checkRenderAssetsStreamingCompletedTimerId != null && checkRenderAssetsStreamingCompletedTimerId.Valid())
			{
				TimerSystem.Instance.Remove(instance.CheckRenderAssetsStreamingCompletedTimerId);
				instance.CheckRenderAssetsStreamingCompletedTimerId = null;
				if (worldPartitionSubsystem == null)
				{
					worldPartitionSubsystem = (UWorldPartitionSubsystem)UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass());
				}
				if (querySource == null)
				{
					querySource = new FWorldPartitionStreamingQuerySource();
				}
				worldPartitionSubsystem.IsRenderAssetsStreamingCompleted(querySource, false, false, true);
				if (raiseError.GetValueOrDefault())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.World;
					ELogAuthor author = ELogAuthor.XY;
					string message = "检查渲染资源(异常结束)";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("是否超时:", false);
					instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x060453CA RID: 283594 RVA: 0x012152F8 File Offset: 0x012134F8
		[NullableContext(0)]
		public UniTask<bool> CheckRenderAssetsStreamingCompleted(FVectorDouble viewOrigin, [Nullable(1)] string reason, [Nullable(2)] Func<bool> abortCheckCondition = null)
		{
			IosAuditController.<CheckRenderAssetsStreamingCompleted>d__64 <CheckRenderAssetsStreamingCompleted>d__;
			<CheckRenderAssetsStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CheckRenderAssetsStreamingCompleted>d__.<>4__this = this;
			<CheckRenderAssetsStreamingCompleted>d__.viewOrigin = viewOrigin;
			<CheckRenderAssetsStreamingCompleted>d__.reason = reason;
			<CheckRenderAssetsStreamingCompleted>d__.abortCheckCondition = abortCheckCondition;
			<CheckRenderAssetsStreamingCompleted>d__.<>1__state = -1;
			<CheckRenderAssetsStreamingCompleted>d__.<>t__builder.Start<IosAuditController.<CheckRenderAssetsStreamingCompleted>d__64>(ref <CheckRenderAssetsStreamingCompleted>d__);
			return <CheckRenderAssetsStreamingCompleted>d__.<>t__builder.Task;
		}

		// Token: 0x060453CB RID: 283595 RVA: 0x01215354 File Offset: 0x01213554
		public void CheckPreload(Action<bool> commonCallback, [Nullable(2)] Action<bool> callback = null)
		{
			ControllerBase<PreloadControllerNew>.Instance.DoPreload(delegate(bool commonResult)
			{
				Action<bool> commonCallback2 = commonCallback;
				if (commonCallback2 == null)
				{
					return;
				}
				commonCallback2(commonResult);
			}).ContinueWith(delegate(bool result)
			{
				ModelBase<GameModeModel>.Instance.PreloadPromise.SetResult(result);
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(result);
			});
		}

		// Token: 0x060453CC RID: 283596 RVA: 0x012153A0 File Offset: 0x012135A0
		[NullableContext(0)]
		public UniTask<bool> OpenLoading()
		{
			IosAuditController.<OpenLoading>d__66 <OpenLoading>d__;
			<OpenLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenLoading>d__.<>1__state = -1;
			<OpenLoading>d__.<>t__builder.Start<IosAuditController.<OpenLoading>d__66>(ref <OpenLoading>d__);
			return <OpenLoading>d__.<>t__builder.Task;
		}

		// Token: 0x060453CD RID: 283597 RVA: 0x012153DB File Offset: 0x012135DB
		[NullableContext(2)]
		public void SetTravelMp4(bool play, string path = null)
		{
			if (play && path == null)
			{
				return;
			}
			ModelBase<GameModeModel>.Instance.PlayTravelMp4 = play;
			ModelBase<GameModeModel>.Instance.TravelMp4Path = path;
		}

		// Token: 0x060453CE RID: 283598 RVA: 0x012153FC File Offset: 0x012135FC
		public unsafe void UpdateStreamingQualityLevel()
		{
			AWorldSettings aworldSettings = GlobalData.World.GetWorld().K2_GetWorldSettings();
			DeviceRenderFeature? currentDeviceRenderFeature;
			if (aworldSettings == null || !aworldSettings.bEnableWorldPartition)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "UpdateStreamingQualityLevel";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bEnableWorldPartition", false);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "streamLevel";
				currentDeviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetCurrentDeviceRenderFeature();
				ptr = new ValueTuple<string, object>(item, (currentDeviceRenderFeature != null) ? new int?(currentDeviceRenderFeature.GetValueOrDefault().StreamLevel) : null);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			currentDeviceRenderFeature = Singleton<GameSettingsDeviceRender>.Instance.GetCurrentDeviceRenderFeature();
			int num = (currentDeviceRenderFeature != null) ? currentDeviceRenderFeature.GetValueOrDefault().StreamLevel : 0;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 1);
			defaultInterpolatedStringHandler.AppendLiteral("wp.Runtime.ModifyQualityLevelStreamingValue ");
			defaultInterpolatedStringHandler.AppendFormatted<float>((num == 0) ? 0.8f : 1f);
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
			defaultInterpolatedStringHandler.AppendLiteral("wp.Runtime.CurStreamingQualityLevel ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, text, null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, text2, null);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "UpdateStreamingQualityLevel";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("bEnableWorldPartition", true);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("modifyQualityLevelStreamingValue", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("curStreamingQualityLevel", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("streamLevel", num);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
		}

		// Token: 0x060453CF RID: 283599 RVA: 0x012155E8 File Offset: 0x012137E8
		private void LoadAssetAsyncInternal(string path, ResourceSystem.EResourceLoadPriority priority, [Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<bool, string, UObject> loadCallback)
		{
			if (!string.IsNullOrEmpty(path))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(path, delegate([Nullable(2)] UObject assetObject, string assetPath)
				{
					if (assetObject == null || !assetObject.IsValid())
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Preload;
						ELogAuthor author = ELogAuthor.YZ;
						string message = "[IosAudit][预加载] 预加载资源失败";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", assetPath);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						Action<bool, string, UObject> loadCallback3 = loadCallback;
						if (loadCallback3 != null)
						{
							loadCallback3(false, path, null);
						}
						if (!Singleton<Info>.Instance.IsBuildShipping)
						{
							ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PreloadFailConfirm);
							confirmBoxDataNew.SetTitle("[IosAudit][预加载] 预加载资源失败");
							confirmBoxDataNew.TextArgs = new string[]
							{
								assetPath ?? ""
							};
							ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
						}
						return;
					}
					this.HoldPreloadObject.AddCommonAsset(assetObject);
					Action<bool, string, UObject> loadCallback4 = loadCallback;
					if (loadCallback4 == null)
					{
						return;
					}
					loadCallback4(true, path, assetObject);
				}, priority, "js_undefined");
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.Preload, ELogAuthor.YZ, "[预加载] path路径为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			Action<bool, string, UObject> loadCallback2 = loadCallback;
			if (loadCallback2 == null)
			{
				return;
			}
			loadCallback2(false, path, null);
		}

		// Token: 0x060453D1 RID: 283601 RVA: 0x0121569C File Offset: 0x0121389C
		[CompilerGenerated]
		internal static string <PrintLoadDetail>g__GetCmdValue|45_1(string cmd, string startStr)
		{
			int num = cmd.IndexOf(startStr, StringComparison.Ordinal);
			if (num != -1)
			{
				int num2 = cmd.IndexOf(' ', num + startStr.Length);
				return cmd.Substring(num + startStr.Length, (num2 == -1) ? (cmd.Length - (num + startStr.Length)) : (num2 - (num + startStr.Length)));
			}
			return "";
		}

		// Token: 0x040269F8 RID: 158200
		private const int ONE_SECOND = 1000;

		// Token: 0x040269F9 RID: 158201
		private const int GAME_MODE_CTRL_THINKING_INDEX = 21;

		// Token: 0x040269FA RID: 158202
		private const int SANWANGFENG_INSTANCEID = 1550;

		// Token: 0x040269FB RID: 158203
		private const int RENDER_ASSET_ABORT_CHECK_DISTANCE_SQUARE = 10000;

		// Token: 0x040269FC RID: 158204
		public const int LOG_STREAMING_STUCK_INTERVAL = 60000;

		// Token: 0x040269FD RID: 158205
		private float cellProgress;

		// Token: 0x040269FE RID: 158206
		[TupleElementNames(new string[]
		{
			"Blocker",
			"Timeout"
		})]
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private readonly List<ValueTuple<Func<UniTask>, int>> WorldDoneBlockers = new List<ValueTuple<Func<UniTask>, int>>();

		// Token: 0x040269FF RID: 158207
		protected bool IsWorldDoneBlockersExecuted;

		// Token: 0x04026A00 RID: 158208
		[Nullable(2)]
		private UHoldPreloadObject HoldPreloadObject;

		// Token: 0x04026A01 RID: 158209
		private bool HasOverrideQuality;

		// Token: 0x04026A02 RID: 158210
		private int LastGameQualityLevel = -1;

		// Token: 0x04026A03 RID: 158211
		private readonly global::Vector TmpLocation = global::Vector.Create();

		// Token: 0x0200CC46 RID: 52294
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403E9D0 RID: 256464
			[Nullable(0)]
			public static Action <0>__OnInterruptDataLayerSwitchTask;
		}
	}
}
