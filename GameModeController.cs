using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.RenderData;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Manager;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.DataLayerSwitch;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Render;
using CSharpScript.Game.World.Controller;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003470 RID: 13424
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class GameModeController : ControllerBase<GameModeController>
{
	// Token: 0x0601C496 RID: 115862 RVA: 0x00875284 File Offset: 0x00873484
	public void AddWorldDoneBlocker(Func<UniTask> blocker, int timeout = 60000)
	{
		if (this.IsWorldDoneBlockersExecuted)
		{
			Singleton<Log>.Instance.Warn(ELogModule.GameMode, ELogAuthor.CH, "'WorldDoneBlockers 已经执行完毕，新注册的 Blocker 将不会被执行！请检查调用时机", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.WorldDoneBlockers.Add(new ValueTuple<Func<UniTask>, int>(blocker, timeout));
	}

	// Token: 0x0601C497 RID: 115863 RVA: 0x008752C8 File Offset: 0x008734C8
	private UniTask ExecuteWorldDoneBlockers()
	{
		GameModeController.<ExecuteWorldDoneBlockers>d__14 <ExecuteWorldDoneBlockers>d__;
		<ExecuteWorldDoneBlockers>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteWorldDoneBlockers>d__.<>4__this = this;
		<ExecuteWorldDoneBlockers>d__.<>1__state = -1;
		<ExecuteWorldDoneBlockers>d__.<>t__builder.Start<GameModeController.<ExecuteWorldDoneBlockers>d__14>(ref <ExecuteWorldDoneBlockers>d__);
		return <ExecuteWorldDoneBlockers>d__.<>t__builder.Task;
	}

	// Token: 0x0601C498 RID: 115864 RVA: 0x0087530C File Offset: 0x0087350C
	private UniTask ExecuteBlockerWithTimeout(Func<UniTask> blocker, int timeout, int index)
	{
		GameModeController.<ExecuteBlockerWithTimeout>d__15 <ExecuteBlockerWithTimeout>d__;
		<ExecuteBlockerWithTimeout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteBlockerWithTimeout>d__.<>4__this = this;
		<ExecuteBlockerWithTimeout>d__.blocker = blocker;
		<ExecuteBlockerWithTimeout>d__.timeout = timeout;
		<ExecuteBlockerWithTimeout>d__.index = index;
		<ExecuteBlockerWithTimeout>d__.<>1__state = -1;
		<ExecuteBlockerWithTimeout>d__.<>t__builder.Start<GameModeController.<ExecuteBlockerWithTimeout>d__15>(ref <ExecuteBlockerWithTimeout>d__);
		return <ExecuteBlockerWithTimeout>d__.<>t__builder.Task;
	}

	// Token: 0x0601C499 RID: 115865 RVA: 0x00875368 File Offset: 0x00873568
	private UniTask ExecuteBlockerWithErrorHandler(Func<UniTask> blocker, int index)
	{
		GameModeController.<ExecuteBlockerWithErrorHandler>d__16 <ExecuteBlockerWithErrorHandler>d__;
		<ExecuteBlockerWithErrorHandler>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteBlockerWithErrorHandler>d__.blocker = blocker;
		<ExecuteBlockerWithErrorHandler>d__.index = index;
		<ExecuteBlockerWithErrorHandler>d__.<>1__state = -1;
		<ExecuteBlockerWithErrorHandler>d__.<>t__builder.Start<GameModeController.<ExecuteBlockerWithErrorHandler>d__16>(ref <ExecuteBlockerWithErrorHandler>d__);
		return <ExecuteBlockerWithErrorHandler>d__.<>t__builder.Task;
	}

	// Token: 0x0601C49A RID: 115866 RVA: 0x008753B4 File Offset: 0x008735B4
	protected override bool OnInit()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform() || Singleton<Info>.Instance.IsGamepadPlatform())
		{
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.ApplicationHasDeactivated));
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
		}
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "Disable UseSeparatedBody In Editor", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Collision.UseSeparatedBody 0", null);
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "Disable FastGeo In Editor", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Wp.Runtime.UseNoTransformerPackages 1", null);
		}
		Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Add(EEventName.SlowStreamingBySoar, new Action<bool>(this.OnSlowStreamingBySoar));
		if (UKuroStaticLibrary.IsWithEditor())
		{
			this.InitDataReport();
		}
		return true;
	}

	// Token: 0x0601C49B RID: 115867 RVA: 0x008754B1 File Offset: 0x008736B1
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x0601C49C RID: 115868 RVA: 0x008754B4 File Offset: 0x008736B4
	private void ApplicationHasDeactivated()
	{
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return;
		}
		TimeStopPush timeStopPush = TimeStopPush.Create();
		timeStopPush.TimeDilation = 0f;
		Singleton<Net>.Instance.Send(EPushMessageId.TimeStopPush, timeStopPush);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "ApplicationHasDeactivated 发生时停协议";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", Singleton<Time>.Instance.TimeDilation);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601C49D RID: 115869 RVA: 0x00875524 File Offset: 0x00873724
	private void ApplicationHasReactivated()
	{
		if (!Singleton<Net>.Instance.IsServerConnected())
		{
			return;
		}
		TimeStopPush timeStopPush = TimeStopPush.Create();
		timeStopPush.TimeDilation = Singleton<Time>.Instance.TimeDilation;
		Singleton<Net>.Instance.Send(EPushMessageId.TimeStopPush, timeStopPush);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "ApplicationHasReactivated 发生时停协议";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TimeDilation", Singleton<Time>.Instance.TimeDilation);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601C49E RID: 115870 RVA: 0x0087559C File Offset: 0x0087379C
	protected override bool OnClear()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform() || Singleton<Info>.Instance.IsGamepadPlatform())
		{
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.ApplicationHasDeactivated));
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.ApplicationHasReactivated));
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.SlowStreamingBySoar, new Action<bool>(this.OnSlowStreamingBySoar));
		this.ResetRenderAssetsQuery(null, null, false);
		return true;
	}

	// Token: 0x0601C49F RID: 115871 RVA: 0x00875631 File Offset: 0x00873831
	private void OnClearWorld()
	{
		ModelBase<GameModeModel>.Instance.RenderAssetDone = false;
	}

	// Token: 0x0601C4A0 RID: 115872 RVA: 0x00875640 File Offset: 0x00873840
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
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("sg.KuroRenderQuality $");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.LastGameQualityLevel);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Streaming.RuntimeLODBiasDeviceMappingIndices 274960", null);
		}
	}

	// Token: 0x0601C4A1 RID: 115873 RVA: 0x00875734 File Offset: 0x00873934
	public bool SetGameModeData(int id, SceneMode sceneMode)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		InstanceDungeon? config = ConfigInstanceDungeonById.GetConfig(id, true);
		if (config == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[GameModeController.InitGameModeData] 不存在副本表id:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		AkiMapSource? akiMapSourceConfig = ConfigBase<WorldMapConfig>.Instance.GetAkiMapSourceConfig(config.Value.MapConfigId);
		if (akiMapSourceConfig == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[WorldGlobal.LoadMapFromInstanceDungeon] 不存在Id";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MapConfigId", config.Value.MapConfigId);
			instance3.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		instance.HasGameModeData = true;
		instance.MapPath = akiMapSourceConfig.Value.MapPath.ToString();
		instance.IsMulti = (sceneMode == SceneMode.Multi);
		instance.Mode = new SceneMode?(sceneMode);
		instance.InstanceType = (InstanceType)config.Value.InstType;
		instance.MapConfig = akiMapSourceConfig.Value;
		instance.MapId = config.Value.MapConfigId;
		instance.LoadMapMode = (ELoadMapMode)akiMapSourceConfig.Value.LoadMapMode;
		instance.SetInstanceDungeon(id);
		if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			ModelBase<CreatureModel>.Instance.EnableEntityLog = (instance.InstanceType != InstanceType.BigWorldInstance);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSetGameModeDataDone);
		return true;
	}

	// Token: 0x0601C4A2 RID: 115874 RVA: 0x008758A8 File Offset: 0x00873AA8
	public bool CheckIsSameMapTravel(int targetDungeonId)
	{
		InstanceDungeon? config = ConfigInstanceDungeonById.GetConfig(targetDungeonId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "[GameModeController.CheckIsSameMapTravel] 不存在副本表id:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", targetDungeonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		AkiMapSource? akiMapSourceConfig = ConfigBase<WorldMapConfig>.Instance.GetAkiMapSourceConfig(config.Value.MapConfigId);
		if (akiMapSourceConfig == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[GameModeController.CheckIsSameMapTravel] 不存在Id";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MapConfigId", config.Value.MapConfigId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return ModelBase<GameModeModel>.Instance.MapPath == akiMapSourceConfig.Value.MapPath;
	}

	// Token: 0x0601C4A3 RID: 115875 RVA: 0x00875974 File Offset: 0x00873B74
	public UniTask Load(SceneInformation sceneInformation)
	{
		GameModeController.<Load>d__26 <Load>d__;
		<Load>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Load>d__.<>4__this = this;
		<Load>d__.sceneInformation = sceneInformation;
		<Load>d__.<>1__state = -1;
		<Load>d__.<>t__builder.Start<GameModeController.<Load>d__26>(ref <Load>d__);
		return <Load>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4A4 RID: 115876 RVA: 0x008759C0 File Offset: 0x00873BC0
	private void CreateStat(string name)
	{
		Stat.CreateNoFlameGraph(name, "", "");
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			float platformTimeInSeconds = UKuroStaticLibrary.GetPlatformTimeInSeconds();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.BLZ;
			string message = "[LoadPhase] " + name;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("time", platformTimeInSeconds);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601C4A5 RID: 115877 RVA: 0x00875A24 File Offset: 0x00873C24
	public UniTask Change(ChangeSceneModeNotify data)
	{
		GameModeController.<Change>d__28 <Change>d__;
		<Change>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Change>d__.<>4__this = this;
		<Change>d__.data = data;
		<Change>d__.<>1__state = -1;
		<Change>d__.<>t__builder.Start<GameModeController.<Change>d__28>(ref <Change>d__);
		return <Change>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4A6 RID: 115878 RVA: 0x00875A70 File Offset: 0x00873C70
	private void RegisterDataLayerChange()
	{
		if (ModelBase<GameModeModel>.Instance.UseWorldPartition)
		{
			UDataLayerSubsystem udataLayerSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UDataLayerSubsystem.StaticClass()) as UDataLayerSubsystem;
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
				Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.HWK, "注册DataLayer变化监听", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.HWK;
			string message = "注册DataLayer变化监听失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DatalayerSubSystem", udataLayerSubsystem);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0601C4A7 RID: 115879 RVA: 0x00875B78 File Offset: 0x00873D78
	private void OnDatalayerChange(FName datalayerLabel, bool bIsActive)
	{
		if (bIsActive && datalayerLabel != FName.NAME_None && (datalayerLabel == WorldDefine.SpecificVolumeDatalayer1 || datalayerLabel == WorldDefine.SpecificVolumeDatalayer2) && !ModelBase<GameModeModel>.Instance.HasDataLayer(datalayerLabel.ToString()))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.HWK;
			string message = "DataLayer在业务端未激活";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Datalayer", datalayerLabel);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(datalayerLabel.ToString(), false, false);
		}
	}

	// Token: 0x0601C4A8 RID: 115880 RVA: 0x00875C10 File Offset: 0x00873E10
	public void PreventEntityFalling()
	{
		ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.GameMode, true);
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
							Context = "[GameModeController.PreventEntityFalling]"
						});
					}
				}
			}
		}
	}

	// Token: 0x0601C4A9 RID: 115881 RVA: 0x00875CA8 File Offset: 0x00873EA8
	public void EnableEntityFalling()
	{
		ModelBase<DeadReviveModel>.Instance.SetSkipFallInjure(ESkipFallInjureReason.GameMode, false);
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
							Context = "[GameModeController.EnableEntityFalling]"
						});
					}
				}
			}
		}
	}

	// Token: 0x0601C4AA RID: 115882 RVA: 0x00875D54 File Offset: 0x00873F54
	public void PrintWorldPartitionDebugInfo(UWorldPartitionStreamingSourceComponent streamingSourceComponent, [Nullable(2)] TArray<FName> inDataLayerLabels, bool bUseGridLoadingRange, float radius, bool bRequirePhysics)
	{
		if (streamingSourceComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.GameMode, ELogAuthor.HWK, "WorldPartitionStreamingSourceComponent不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!(UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) is UWorldPartitionSubsystem))
		{
			Singleton<Log>.Instance.Error(ELogModule.GameMode, ELogAuthor.HWK, "WorldPartitionSubsystem不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		streamingSourceComponent.LogStreamingStuckInfo2(inDataLayerLabels ?? new TArray<FName>(), bUseGridLoadingRange, radius, bRequirePhysics);
	}

	// Token: 0x0601C4AB RID: 115883 RVA: 0x00875DCD File Offset: 0x00873FCD
	[NullableContext(2)]
	public void SwitchDataLayer([Nullable(1)] IList<string> unloadDataLayers, [Nullable(1)] IList<string> activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
	{
		this.AwaitSwitchDataLayer(unloadDataLayers, activateDataLayers, callback, sequencePath, sequenceMarkBeforeModifyMaterial, materialDataForLoadedLayers, materialDataForUnloadLayers);
	}

	// Token: 0x0601C4AC RID: 115884 RVA: 0x00875DE4 File Offset: 0x00873FE4
	private void OnInterruptDataLayerSwitchTask()
	{
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "GameMode:Task被打断,触发OnInterrupt收尾", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.InterruptDataLayerSwitch();
	}

	// Token: 0x0601C4AD RID: 115885 RVA: 0x00875E14 File Offset: 0x00874014
	public void InterruptDataLayerSwitch()
	{
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "GameMode:打断DataLayer切换(InterruptDataLayerSwitch)", default(ReadOnlySpan<ValueTuple<string, object>>));
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.SwitchDataLayerContext.AbortDataLayerSwitch();
	}

	// Token: 0x0601C4AE RID: 115886 RVA: 0x00875E54 File Offset: 0x00874054
	[NullableContext(2)]
	public UniTask AwaitSwitchDataLayer([Nullable(1)] IList<string> unloadDataLayers, [Nullable(1)] IList<string> activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
	{
		GameModeController.<AwaitSwitchDataLayer>d__37 <AwaitSwitchDataLayer>d__;
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
		<AwaitSwitchDataLayer>d__.<>t__builder.Start<GameModeController.<AwaitSwitchDataLayer>d__37>(ref <AwaitSwitchDataLayer>d__);
		return <AwaitSwitchDataLayer>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4AF RID: 115887 RVA: 0x00875ED4 File Offset: 0x008740D4
	[NullableContext(2)]
	[return: Nullable(1)]
	private AsyncTask CreateSwitchDataLayerTask([Nullable(1)] IList<string> unloadDataLayers, [Nullable(1)] IList<string> activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
	{
		GameModeController.<>c__DisplayClass38_0 CS$<>8__locals1 = new GameModeController.<>c__DisplayClass38_0();
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
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "GameMode:选择材质过渡切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunMaterialSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.callback, CS$<>8__locals1.sequencePath, CS$<>8__locals1.sequenceMarkBeforeModifyMaterial, CS$<>8__locals1.materialDataForLoadedLayers, CS$<>8__locals1.materialDataForUnloadLayers));
		}
		else if (!StringUtils.IsBlank(CS$<>8__locals1.sequencePath))
		{
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "GameMode:选择序列切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunLevelSeqSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.sequencePath, CS$<>8__locals1.callback));
		}
		else
		{
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "GameMode:选择普通切换模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			CS$<>8__locals1.runner = (() => CS$<>8__locals1.<>4__this.RunNormalSwitchTask(CS$<>8__locals1.unloadDataLayers, CS$<>8__locals1.activateDataLayers, CS$<>8__locals1.callback));
		}
		return new AsyncTask("SwitchDataLayer", delegate()
		{
			GameModeController.<>c__DisplayClass38_0.<<CreateSwitchDataLayerTask>b__3>d <<CreateSwitchDataLayerTask>b__3>d;
			<<CreateSwitchDataLayerTask>b__3>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<<CreateSwitchDataLayerTask>b__3>d.<>4__this = CS$<>8__locals1;
			<<CreateSwitchDataLayerTask>b__3>d.<>1__state = -1;
			<<CreateSwitchDataLayerTask>b__3>d.<>t__builder.Start<GameModeController.<>c__DisplayClass38_0.<<CreateSwitchDataLayerTask>b__3>d>(ref <<CreateSwitchDataLayerTask>b__3>d);
			return <<CreateSwitchDataLayerTask>b__3>d.<>t__builder.Task;
		}, null, null, new TaskInterruptOptions(ETaskPriority.Normal, true, new Action(this.OnInterruptDataLayerSwitchTask)));
	}

	// Token: 0x0601C4B0 RID: 115888 RVA: 0x00876004 File Offset: 0x00874204
	private void PrepareSwitchDataLayer()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "GameMode:准备切换DataLayer";
		string item = "InstId";
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().Id : 0);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		bool flag = (((instanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().Id) : null) ?? 0) == 0;
		if (flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameMode;
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

	// Token: 0x0601C4B1 RID: 115889 RVA: 0x00876150 File Offset: 0x00874350
	private bool CheckAndTryFakeSwitchDataLayer(IList<string> unloadDataLayers, IList<string> activateDataLayers, [Nullable(2)] Action<bool> callback = null)
	{
		AutoRunModel instance = ModelBase<AutoRunModel>.Instance;
		if (instance != null && instance.IsInLogicTreeGmMode())
		{
			this.FakeSwitchDataLayerInternal(unloadDataLayers, activateDataLayers, ModelBase<GameModeModel>.Instance.SwitchDataLayerContext.CurrentSwitchInstId, callback);
			return true;
		}
		return false;
	}

	// Token: 0x0601C4B2 RID: 115890 RVA: 0x00876180 File Offset: 0x00874380
	private UniTask RunNormalSwitchTask(IList<string> unloadDataLayers, IList<string> activateDataLayers, [Nullable(2)] Action<bool> callback = null)
	{
		GameModeController.<RunNormalSwitchTask>d__41 <RunNormalSwitchTask>d__;
		<RunNormalSwitchTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RunNormalSwitchTask>d__.<>4__this = this;
		<RunNormalSwitchTask>d__.unloadDataLayers = unloadDataLayers;
		<RunNormalSwitchTask>d__.activateDataLayers = activateDataLayers;
		<RunNormalSwitchTask>d__.callback = callback;
		<RunNormalSwitchTask>d__.<>1__state = -1;
		<RunNormalSwitchTask>d__.<>t__builder.Start<GameModeController.<RunNormalSwitchTask>d__41>(ref <RunNormalSwitchTask>d__);
		return <RunNormalSwitchTask>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4B3 RID: 115891 RVA: 0x008761DC File Offset: 0x008743DC
	private UniTask RunLevelSeqSwitchTask(IList<string> unloadDataLayers, IList<string> activateDataLayers, string sequencePath, [Nullable(2)] Action<bool> callback = null)
	{
		GameModeController.<RunLevelSeqSwitchTask>d__42 <RunLevelSeqSwitchTask>d__;
		<RunLevelSeqSwitchTask>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RunLevelSeqSwitchTask>d__.<>4__this = this;
		<RunLevelSeqSwitchTask>d__.unloadDataLayers = unloadDataLayers;
		<RunLevelSeqSwitchTask>d__.activateDataLayers = activateDataLayers;
		<RunLevelSeqSwitchTask>d__.sequencePath = sequencePath;
		<RunLevelSeqSwitchTask>d__.callback = callback;
		<RunLevelSeqSwitchTask>d__.<>1__state = -1;
		<RunLevelSeqSwitchTask>d__.<>t__builder.Start<GameModeController.<RunLevelSeqSwitchTask>d__42>(ref <RunLevelSeqSwitchTask>d__);
		return <RunLevelSeqSwitchTask>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4B4 RID: 115892 RVA: 0x00876240 File Offset: 0x00874440
	[NullableContext(2)]
	private UniTask RunMaterialSwitchTask([Nullable(1)] IList<string> unloadDataLayers, [Nullable(1)] IList<string> activateDataLayers, Action<bool> callback = null, string sequencePath = null, string sequenceMarkBeforeModifyMaterial = null, string materialDataForLoadedLayers = null, string materialDataForUnloadLayers = null)
	{
		GameModeController.<RunMaterialSwitchTask>d__43 <RunMaterialSwitchTask>d__;
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
		<RunMaterialSwitchTask>d__.<>t__builder.Start<GameModeController.<RunMaterialSwitchTask>d__43>(ref <RunMaterialSwitchTask>d__);
		return <RunMaterialSwitchTask>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4B5 RID: 115893 RVA: 0x008762C0 File Offset: 0x008744C0
	private UniTask NormalSwitchDataLayerInternal(IList<string> unloadDataLayers, IList<string> activateDataLayers, bool bEnterLoadingMode = true, bool bWaitingRenderAssetDone = true)
	{
		GameModeController.<NormalSwitchDataLayerInternal>d__44 <NormalSwitchDataLayerInternal>d__;
		<NormalSwitchDataLayerInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NormalSwitchDataLayerInternal>d__.<>4__this = this;
		<NormalSwitchDataLayerInternal>d__.unloadDataLayers = unloadDataLayers;
		<NormalSwitchDataLayerInternal>d__.activateDataLayers = activateDataLayers;
		<NormalSwitchDataLayerInternal>d__.bEnterLoadingMode = bEnterLoadingMode;
		<NormalSwitchDataLayerInternal>d__.bWaitingRenderAssetDone = bWaitingRenderAssetDone;
		<NormalSwitchDataLayerInternal>d__.<>1__state = -1;
		<NormalSwitchDataLayerInternal>d__.<>t__builder.Start<GameModeController.<NormalSwitchDataLayerInternal>d__44>(ref <NormalSwitchDataLayerInternal>d__);
		return <NormalSwitchDataLayerInternal>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4B6 RID: 115894 RVA: 0x00876324 File Offset: 0x00874524
	private unsafe void FakeSwitchDataLayerInternal(IList<string> unloadDataLayers, IList<string> activateDataLayers, int instId, [Nullable(2)] Action<bool> callback = null)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.CJH;
		string message = "伪切换DataLayer:(开始)";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("卸载的DataLayer", (unloadDataLayers != null && unloadDataLayers.Count > 0) ? string.Join(",", unloadDataLayers) : "");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("加载的DataLayer", (activateDataLayers != null && activateDataLayers.Count > 0) ? string.Join(",", activateDataLayers) : "");
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "伪切换DataLayer:更新缓存的DataLayer变更信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<AutoRunModel>.Instance.UpdateCachedDataLayerInfo(activateDataLayers, unloadDataLayers, null);
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.ZYL, "伪切换DataLayer:通知服务器切换完成", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.ChangeDataLayerFinishRequest(instId);
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.CJH, "伪切换DataLayer:(完成)", default(ReadOnlySpan<ValueTuple<string, object>>));
		GameModeModel instance2 = ModelBase<GameModeModel>.Instance;
		if (instance2 != null)
		{
			instance2.SwitchDataLayerContext.FinishDataLayerSwitch();
		}
		if (callback != null)
		{
			callback(true);
		}
	}

	// Token: 0x0601C4B7 RID: 115895 RVA: 0x0087644F File Offset: 0x0087464F
	public bool IsInInstance()
	{
		return ModelBase<GameModeModel>.Instance.InstanceType >= InstanceType.NormalInstance;
	}

	// Token: 0x0601C4B8 RID: 115896 RVA: 0x00876464 File Offset: 0x00874664
	public bool CanLoadEntity()
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		return instance.WorldDone && !instance.IsTeleport && !instance.ChangeModeState;
	}

	// Token: 0x0601C4B9 RID: 115897 RVA: 0x00876492 File Offset: 0x00874692
	public void BeforeLoadMap()
	{
		ModelBase<GameModeModel>.Instance.BeginLoadMapPromise.SetResult(true);
	}

	// Token: 0x0601C4BA RID: 115898 RVA: 0x008764A4 File Offset: 0x008746A4
	public void InitAllPlayerStarts()
	{
		TArray<AActor> tarray = new TArray<AActor>();
		UGameplayStatics.GetAllActorsOfClass(GlobalData.World, APlayerStart.StaticClass(), ref tarray);
		ModelBase<GameModeModel>.Instance.ClearPlayerStart();
		if (tarray.Num() > 0)
		{
			for (int i = 0; i < tarray.Num(); i++)
			{
				ModelBase<GameModeModel>.Instance.AddPlayerStart(tarray.Get(i) as APlayerStart);
			}
		}
	}

	// Token: 0x0601C4BB RID: 115899 RVA: 0x00876507 File Offset: 0x00874707
	public void AfterLoadMap()
	{
		this.InitAllPlayerStarts();
		ModelBase<GameModeModel>.Instance.OpenLevelPromise.SetResult(true);
	}

	// Token: 0x0601C4BC RID: 115900 RVA: 0x00876520 File Offset: 0x00874720
	protected override void OnTick(float delta)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti || ModelBase<CombatMessageModel>.Instance.AnyEntityInFight)
		{
			Singleton<Heartbeat>.Instance.SetHeartBeatMode(HeartbeatDefine.EHeartBeatType.BattleHeartBeat);
		}
		else
		{
			Singleton<Heartbeat>.Instance.SetHeartBeatMode(HeartbeatDefine.EHeartBeatType.NormalHeartBeat);
		}
		if (!ModelBase<GameModeModel>.Instance.UseWorldPartition)
		{
			return;
		}
		if (!ModelBase<GameModeModel>.Instance.WorldDone)
		{
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsTeleport)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null || !baseCharacter.IsValid())
		{
			return;
		}
		FTransformDouble ftransformDouble = Global.BaseCharacter.D_GetTransform();
		ModelBase<GameModeModel>.Instance.UpdateBornLocation(ftransformDouble.GetLocation());
	}

	// Token: 0x0601C4BD RID: 115901 RVA: 0x008765B8 File Offset: 0x008747B8
	public new void AfterTick(float delta)
	{
		ITimeDilationData cacheTimeDilationValue = ModelBase<GameModeModel>.Instance.GetCacheTimeDilationValue();
		if (cacheTimeDilationValue != null)
		{
			this.BroadcastTimeDilation(cacheTimeDilationValue.TimeDilation);
		}
	}

	// Token: 0x0601C4BE RID: 115902 RVA: 0x008765DF File Offset: 0x008747DF
	private void OnSlowStreamingBySoar(bool bSlow)
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, bSlow ? "wp.Runtime.EnableGridBlackList true" : "wp.Runtime.EnableGridBlackList false", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, bSlow ? "r.CLV.Freeze 1" : "r.CLV.Freeze 0", null);
	}

	// Token: 0x0601C4BF RID: 115903 RVA: 0x00876618 File Offset: 0x00874818
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
		})] ValueTuple<string, int> b) => b.Item2.CompareTo(a.Item2));
		if (UKuroStaticLibrary.IsWithEditor())
		{
			float piestartTimeInSeconds = UKuroStaticLibrary.GetPIEStartTimeInSeconds();
			float platformTimeInSeconds = UKuroStaticLibrary.GetPlatformTimeInSeconds();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.GameMode;
			ELogAuthor author2 = ELogAuthor.BLZ;
			string message2 = "[LoadPhase] LoadingTime Start";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("time", piestartTimeInSeconds);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.GameMode;
			ELogAuthor author3 = ELogAuthor.BLZ;
			string message3 = "[LoadPhase] LoadingTime End";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("time", platformTimeInSeconds);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			string commandLine = UKismetSystemLibrary.GetCommandLine();
			string value = GameModeController.<PrintLoadDetail>g__GetCmdValue|54_1(commandLine, "-KuroPipelineTag=");
			string[] array = GameModeController.<PrintLoadDetail>g__GetCmdValue|54_1(commandLine, "-KuroTsSilentLoginTestFile=").Replace('/', '\\').Split('\\', StringSplitOptions.None);
			string value2 = array[array.Length - 1];
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["Version"] = Singleton<BaseConfigController>.Instance.GetVersionString();
			dictionary["LoadingTime"] = platformTimeInSeconds - piestartTimeInSeconds;
			dictionary["MapPath"] = ModelBase<GameModeModel>.Instance.MapPath;
			dictionary["BornLocation"] = bornLocation.ToString();
			dictionary["TestName"] = value2;
			dictionary["PipelineTag"] = value;
			string text = Json.Stringify<Dictionary<string, object>>(dictionary, null);
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.GameMode;
			ELogAuthor author4 = ELogAuthor.HMH;
			string message4 = "UE_TraceProfile_Event";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("value", text);
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			if (FThinkingAnalyticsForCSharp.Track("UE_TraceProfile_Event", text, 21))
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					FThinkingAnalyticsForCSharp.Flush(21);
				}, null, null);
			}
			else
			{
				Singleton<Log>.Instance.Warn(ELogModule.GameMode, ELogAuthor.HMH, "TraceProfile report fail", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}
		if (!ModelBase<PreloadModelNew>.Instance.LoadAssetOneByOneState)
		{
			return;
		}
		int num = 0;
		while (num < 20 && num < resourcesLoadTime.Count)
		{
			ValueTuple<string, int> valueTuple4 = resourcesLoadTime[num];
			int item = valueTuple4.Item2;
			string item2;
			if (item < 1000)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item);
				defaultInterpolatedStringHandler.AppendLiteral(" ms");
				item2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item / 1000);
				defaultInterpolatedStringHandler.AppendLiteral(" s");
				item2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.World;
			ELogAuthor author5 = ELogAuthor.LFJW;
			string message5 = "资源耗时Top20";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("耗时", item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("资源路径", valueTuple4.Item1);
			instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			num++;
		}
		ModelBase<PreloadModelNew>.Instance.ClearResourcesLoadTime();
	}

	// Token: 0x0601C4C0 RID: 115904 RVA: 0x00876970 File Offset: 0x00874B70
	private void InitDataReport()
	{
		EntryJson entryJson = Singleton<BaseConfigModel>.Instance.EntryJson;
		ITDConfig itdconfig = (entryJson != null) ? entryJson.TDCfg : null;
		string serverUrl = ((itdconfig != null) ? itdconfig.URL : null) ?? "https://cn-datareceiver.aki-game.com";
		string appId = ((itdconfig != null) ? itdconfig.AppID : null) ?? "0d45e80772374d95a961daf5316265e3";
		if (itdconfig == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.GameMode, ELogAuthor.HMH, "Thinking Analytics init fail, TDCfg is empty", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		int maxNumInBatch = 1000;
		if (UThinkingAnalytics.HasInstanceInitialized(21))
		{
			return;
		}
		FCreateInstanceParam fcreateInstanceParam = new FCreateInstanceParam(21, serverUrl, appId, UThinkingAnalytics.GetMachineID(), "", "GameController", "", maxNumInBatch, TAMode.NORMAL, UnrealEngine.ESaveMode.None_Save, 0f, true, false, false, true, 1f, 1000, 10000f, true, 10f, true, true);
		if (!UThinkingAnalytics.CreateSimpleInstance(fcreateInstanceParam))
		{
			Singleton<Log>.Instance.Warn(ELogModule.GameMode, ELogAuthor.HMH, "Thinking Analytics instance create fail", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601C4C1 RID: 115905 RVA: 0x00876A58 File Offset: 0x00874C58
	public unsafe bool SetGamePaused(bool bPaused, string reason, float unPausedTimeDilation = 1f)
	{
		Singleton<Time>.Instance.OriginTimeDilation = unPausedTimeDilation;
		HashSet<string> gamePausedReasons = ModelBase<GameModeModel>.Instance.GamePausedReasons;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
		ELogAuthor author = ELogAuthor.XWX;
		string message = "时停:调用真时停";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("bPaused", bPaused);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("unPausedTimeDilation", unPausedTimeDilation);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (ModelBase<GameModeModel>.Instance.ForceDisableGamePaused)
		{
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:缓存真时停:由于强制设置时停", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!bPaused)
			{
				if (gamePausedReasons.Contains(reason))
				{
					gamePausedReasons.Remove(reason);
				}
				return false;
			}
			if (!gamePausedReasons.Contains(reason))
			{
				gamePausedReasons.Add(reason);
			}
		}
		UKuroGameBudgetSubSystem ukuroGameBudgetSubSystem = USubsystemBlueprintLibrary.GetWorldSubsystem(GlobalData.World, UKuroGameBudgetSubSystem.StaticClass()) as UKuroGameBudgetSubSystem;
		if (bPaused)
		{
			if (gamePausedReasons.Contains(reason))
			{
				Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:已存在该时停", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			gamePausedReasons.Add(reason);
			Singleton<TickSystem>.Instance.IsPaused = true;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TsSyncTickPauseState, Singleton<TickSystem>.Instance.IsSetPaused);
			UKuroGameBudgetAllocatorCSharpInterface.SetPauseFrame((ulong)UKismetSystemLibrary.GetFrameCount());
			this.SetTimeDilation(0f, ETimeDilationType.Pause);
			Singleton<Time>.Instance.LastPauseTimeFrame = Singleton<Time>.Instance.Frame;
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:执行真时停", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSetGamePaused, true);
			if (ukuroGameBudgetSubSystem != null)
			{
				ukuroGameBudgetSubSystem.SetGamePaused(bPaused);
			}
			return UGameplayStatics.SetGamePaused(GlobalData.World, true);
		}
		else
		{
			if (gamePausedReasons.Contains(reason))
			{
				gamePausedReasons.Remove(reason);
			}
			if (gamePausedReasons.Count == 0)
			{
				Singleton<TickSystem>.Instance.IsPaused = false;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TsSyncTickPauseState, Singleton<TickSystem>.Instance.IsSetPaused);
				this.SetTimeDilation(unPausedTimeDilation, ETimeDilationType.Pause);
				Singleton<Time>.Instance.LastResumeTimeFrame = Singleton<Time>.Instance.Frame;
				Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:解除真时停", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSetGamePaused, false);
				if (ukuroGameBudgetSubSystem != null)
				{
					ukuroGameBudgetSubSystem.SetGamePaused(bPaused);
				}
				return UGameplayStatics.SetGamePaused(GlobalData.World, false);
			}
			return true;
		}
	}

	// Token: 0x0601C4C2 RID: 115906 RVA: 0x00876CC4 File Offset: 0x00874EC4
	public void CheckAndUpdateGamePaused()
	{
		HashSet<string> gamePausedReasons = ModelBase<GameModeModel>.Instance.GamePausedReasons;
		Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.JYS, "时停:调用真时停检查", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (gamePausedReasons.Count == 0)
		{
			Singleton<TickSystem>.Instance.IsPaused = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TsSyncTickPauseState, Singleton<TickSystem>.Instance.IsSetPaused);
			this.SetTimeDilation(1f, ETimeDilationType.Pause);
			Singleton<Time>.Instance.LastResumeTimeFrame = Singleton<Time>.Instance.Frame;
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:gamePausedReasons = 0,解除真时停", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSetGamePaused, false);
			UGameplayStatics.SetGamePaused(GlobalData.World, false);
		}
	}

	// Token: 0x0601C4C3 RID: 115907 RVA: 0x00876D7C File Offset: 0x00874F7C
	public void ForceDisableGamePaused(bool value)
	{
		if (value)
		{
			ModelBase<GameModeModel>.Instance.ForceDisableGamePaused = true;
			Singleton<TickSystem>.Instance.IsPaused = false;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TsSyncTickPauseState, Singleton<TickSystem>.Instance.IsSetPaused);
			this.SetTimeDilation(1f, ETimeDilationType.Teleport);
			Singleton<Time>.Instance.LastResumeTimeFrame = Singleton<Time>.Instance.Frame;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameMode;
			ELogAuthor author = ELogAuthor.XWX;
			string message = "时停:强制解除真时停";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("timeDilation", Singleton<Time>.Instance.OriginTimeDilation);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSetGamePaused, false);
			UGameplayStatics.SetGamePaused(GlobalData.World, false);
			return;
		}
		ModelBase<GameModeModel>.Instance.ForceDisableGamePaused = false;
		if (ModelBase<GameModeModel>.Instance.GamePausedReasons.Count > 0)
		{
			Singleton<TickSystem>.Instance.IsPaused = true;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TsSyncTickPauseState, Singleton<TickSystem>.Instance.IsSetPaused);
			UKuroGameBudgetAllocatorCSharpInterface.SetPauseFrame((ulong)UKismetSystemLibrary.GetFrameCount());
			this.SetTimeDilation(1f, ETimeDilationType.Teleport);
			Singleton<Time>.Instance.LastPauseTimeFrame = Singleton<Time>.Instance.Frame;
			Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XWX, "时停:恢复强制解除, Set中存在reason, 执行真时停", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnSetGamePaused, true);
			UGameplayStatics.SetGamePaused(GlobalData.World, true);
			return;
		}
		this.SetTimeDilation(1f, ETimeDilationType.Teleport);
		ControllerBase<GameModeController>.Instance.CheckAndUpdateGamePaused();
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.GameMode;
		ELogAuthor author2 = ELogAuthor.XWX;
		string message2 = "时停:恢复强制解除, Set中不存在reason, 不执行真时停";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("timeDilation", Singleton<Time>.Instance.OriginTimeDilation);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x0601C4C4 RID: 115908 RVA: 0x00876F28 File Offset: 0x00875128
	public unsafe void SetTimeDilation(float timeDilation, ETimeDilationType timeDilationType = ETimeDilationType.Default)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GameMode;
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
			ELogModule module2 = ELogModule.GameMode;
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
			num *= keyValuePair.Value;
			if ((keyValuePair.Key & ETimeDilationType.PhantomBattleArena) == ETimeDilationType.Default)
			{
				num2 *= keyValuePair.Value;
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
		ELogModule module3 = ELogModule.GameMode;
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

	// Token: 0x0601C4C5 RID: 115909 RVA: 0x0087716C File Offset: 0x0087536C
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

	// Token: 0x0601C4C6 RID: 115910 RVA: 0x0087723C File Offset: 0x0087543C
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
			Context = "[GameModeController.FixBornLocation]"
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

	// Token: 0x0601C4C7 RID: 115911 RVA: 0x00877318 File Offset: 0x00875518
	public void LoadDataLayers(SceneInformation sceneInformation)
	{
		ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState("DatalayerRuntime_HideInLowMemDevice", !UKuroStaticLibrary.IsLowMemoryDevice(), false);
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
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameMode;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "加载场景:加载DataLayer失败,不存在的配置Id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DataLayerId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				string dataLayer = config.Value.DataLayer;
				if (ModelBase<GameModeModel>.Instance.HasDataLayer(dataLayer))
				{
					list.Remove(dataLayer);
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.GameMode;
					ELogAuthor author2 = ELogAuthor.LFJW;
					string message2 = "加载场景:加载DataLayer";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DataLayer", dataLayer);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					ControllerBase<GameModeController>.Instance.ActivateDataLayer(dataLayer);
				}
			}
		}
		foreach (string dataLayerPath in list)
		{
			ControllerBase<GameModeController>.Instance.UnloadDataLayer(dataLayerPath);
		}
	}

	// Token: 0x0601C4C8 RID: 115912 RVA: 0x00877480 File Offset: 0x00875680
	private void ActivateDataLayer(string dataLayerPath)
	{
		ModelBase<GameModeModel>.Instance.AddDataLayer(dataLayerPath);
		ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(dataLayerPath, true, false);
	}

	// Token: 0x0601C4C9 RID: 115913 RVA: 0x0087749B File Offset: 0x0087569B
	private void UnloadDataLayer(string dataLayerPath)
	{
		ModelBase<GameModeModel>.Instance.RemoveDataLayer(dataLayerPath);
		ControllerBase<RenderModuleController>.Instance.SetWorldPartitionDataLayerState(dataLayerPath, false, false);
	}

	// Token: 0x0601C4CA RID: 115914 RVA: 0x008774B8 File Offset: 0x008756B8
	private void ChangeDataLayerFinishRequest(int instId)
	{
		ChangeDataLayerFinishRequest changeDataLayerFinishRequest = Aki.Protocol.ChangeDataLayerFinishRequest.Create();
		changeDataLayerFinishRequest.InstId = instId;
		Singleton<Net>.Instance.Call<ChangeDataLayerFinishResponse>(ERequestMessageId.ChangeDataLayerFinishRequest, changeDataLayerFinishRequest, delegate(ChangeDataLayerFinishResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21444, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601C4CB RID: 115915 RVA: 0x00877504 File Offset: 0x00875704
	public unsafe void ApplyMaterialParameterCollection(IDictionary<int, int> protoAreaMpc)
	{
		ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap.Clear();
		foreach (KeyValuePair<int, int> keyValuePair in protoAreaMpc)
		{
			int key = keyValuePair.Key;
			string mpcData = ConfigAreaMpcById.GetConfig(keyValuePair.Value, true).Value.MpcData;
			if (string.IsNullOrEmpty(mpcData) || mpcData == "None" || mpcData == "Empty")
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.GameMode;
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
						Singleton<Log>.Instance.Error(ELogModule.GameMode, ELogAuthor.CJH, "加载场景: MPCData无效", default(ReadOnlySpan<ValueTuple<string, object>>));
						ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap[inPath] = true;
						ControllerBase<GameModeController>.Instance.CheckMaterialParameterCollectionLoaded();
						return;
					}
					ModelBase<RenderModuleModel>.Instance.UpdateItemMaterialParameterCollection(data);
					ModelBase<GameModeModel>.Instance.MaterialParameterCollectionMap[inPath] = true;
					ControllerBase<GameModeController>.Instance.CheckMaterialParameterCollectionLoaded();
				}, 100, "js_undefined");
			}
		}
	}

	// Token: 0x0601C4CC RID: 115916 RVA: 0x008776B0 File Offset: 0x008758B0
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

	// Token: 0x0601C4CD RID: 115917 RVA: 0x0087771C File Offset: 0x0087591C
	public UniTask SwitchStreamingSource(AActor actor, bool waitForStreaming, bool bLockMovementDuringStreaming, EMovementLockMode? movementLockModeAfterStreaming)
	{
		GameModeController.<SwitchStreamingSource>d__68 <SwitchStreamingSource>d__;
		<SwitchStreamingSource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SwitchStreamingSource>d__.<>4__this = this;
		<SwitchStreamingSource>d__.actor = actor;
		<SwitchStreamingSource>d__.waitForStreaming = waitForStreaming;
		<SwitchStreamingSource>d__.bLockMovementDuringStreaming = bLockMovementDuringStreaming;
		<SwitchStreamingSource>d__.movementLockModeAfterStreaming = movementLockModeAfterStreaming;
		<SwitchStreamingSource>d__.<>1__state = -1;
		<SwitchStreamingSource>d__.<>t__builder.Start<GameModeController.<SwitchStreamingSource>d__68>(ref <SwitchStreamingSource>d__);
		return <SwitchStreamingSource>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4CE RID: 115918 RVA: 0x00877780 File Offset: 0x00875980
	public UniTask ResetStreamingSourceAttachment()
	{
		GameModeController.<ResetStreamingSourceAttachment>d__69 <ResetStreamingSourceAttachment>d__;
		<ResetStreamingSourceAttachment>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ResetStreamingSourceAttachment>d__.<>4__this = this;
		<ResetStreamingSourceAttachment>d__.<>1__state = -1;
		<ResetStreamingSourceAttachment>d__.<>t__builder.Start<GameModeController.<ResetStreamingSourceAttachment>d__69>(ref <ResetStreamingSourceAttachment>d__);
		return <ResetStreamingSourceAttachment>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4CF RID: 115919 RVA: 0x008777C4 File Offset: 0x008759C4
	private UniTask CheckWorldPartitionStreamingCompleted(CustomPromise<bool> voxelPromise, CustomPromise<bool> streamingPromise, [Nullable(2)] Func<bool> abortCheckCondition = null)
	{
		GameModeController.<CheckWorldPartitionStreamingCompleted>d__70 <CheckWorldPartitionStreamingCompleted>d__;
		<CheckWorldPartitionStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckWorldPartitionStreamingCompleted>d__.<>4__this = this;
		<CheckWorldPartitionStreamingCompleted>d__.voxelPromise = voxelPromise;
		<CheckWorldPartitionStreamingCompleted>d__.streamingPromise = streamingPromise;
		<CheckWorldPartitionStreamingCompleted>d__.abortCheckCondition = abortCheckCondition;
		<CheckWorldPartitionStreamingCompleted>d__.<>1__state = -1;
		<CheckWorldPartitionStreamingCompleted>d__.<>t__builder.Start<GameModeController.<CheckWorldPartitionStreamingCompleted>d__70>(ref <CheckWorldPartitionStreamingCompleted>d__);
		return <CheckWorldPartitionStreamingCompleted>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4D0 RID: 115920 RVA: 0x00877820 File Offset: 0x00875A20
	[NullableContext(2)]
	[return: Nullable(1)]
	private unsafe TimerHandle CheckTargetStreamingCompleted([Nullable(1)] UWorldPartitionStreamingSourceComponent streamingSourceComponent, [Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<CustomPromise<bool>, GameModePromise> completedPromise, TArray<FName> dataLayerLabels = null, Action<double> progressUpdated = null, bool checkPhysics = false, Func<bool> abortCheckCondition = null)
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
					bool flag = streamingSourceComponent.IsStreamingCompletedForLayers2(dataLayerLabels ?? new TArray<FName>(), false, 7000f, true, ref this.cellProgress, false);
					Action<double> progressUpdated2 = progressUpdated;
					if (progressUpdated2 != null)
					{
						progressUpdated2((double)this.cellProgress);
					}
					if (!flag)
					{
						base.<CheckTargetStreamingCompleted>g__TimerStreamingStuckLog|1(isCheckingPhysics);
						return;
					}
					isCheckingPhysics = checkPhysics;
					if (isCheckingPhysics)
					{
						Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XY, "加载场景:检测场景物理体(开始)", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				if (isCheckingPhysics)
				{
					if (!streamingSourceComponent.IsStreamingCompletedForLayers2(dataLayerLabels ?? new TArray<FName>(), false, 7000f, false, ref this.cellProgress, true))
					{
						base.<CheckTargetStreamingCompleted>g__TimerStreamingStuckLog|1(isCheckingPhysics);
						return;
					}
					Singleton<Log>.Instance.Info(ELogModule.GameMode, ELogAuthor.XY, "加载场景:检测场景物理体(结束)", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			TimerSystem.Instance.Remove(timerId);
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

	// Token: 0x0601C4D1 RID: 115921 RVA: 0x00877960 File Offset: 0x00875B60
	public void InitStreamingSources()
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (!GlobalData.World.GetWorld().K2_GetWorldSettings().bEnableWorldPartition || instance.BornLocation == null)
		{
			return;
		}
		instance.InitStreamingSources();
	}

	// Token: 0x0601C4D2 RID: 115922 RVA: 0x008779A0 File Offset: 0x00875BA0
	public UniTask CheckVoxelStreamingCompleted(float relativeProgress, int maxProgress)
	{
		GameModeController.<CheckVoxelStreamingCompleted>d__73 <CheckVoxelStreamingCompleted>d__;
		<CheckVoxelStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckVoxelStreamingCompleted>d__.<>4__this = this;
		<CheckVoxelStreamingCompleted>d__.relativeProgress = relativeProgress;
		<CheckVoxelStreamingCompleted>d__.maxProgress = maxProgress;
		<CheckVoxelStreamingCompleted>d__.<>1__state = -1;
		<CheckVoxelStreamingCompleted>d__.<>t__builder.Start<GameModeController.<CheckVoxelStreamingCompleted>d__73>(ref <CheckVoxelStreamingCompleted>d__);
		return <CheckVoxelStreamingCompleted>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4D3 RID: 115923 RVA: 0x008779F4 File Offset: 0x00875BF4
	public void AppendAllBaseDatalayers(TArray<FName> dataLayerLabels)
	{
		foreach (FName value in WorldDefine.allBaseDataLayers)
		{
			dataLayerLabels.Add(value);
		}
	}

	// Token: 0x0601C4D4 RID: 115924 RVA: 0x00877A24 File Offset: 0x00875C24
	public UniTask CheckStreamingCompleted(float relativeProgress, int maxProgress)
	{
		GameModeController.<CheckStreamingCompleted>d__75 <CheckStreamingCompleted>d__;
		<CheckStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckStreamingCompleted>d__.<>4__this = this;
		<CheckStreamingCompleted>d__.relativeProgress = relativeProgress;
		<CheckStreamingCompleted>d__.maxProgress = maxProgress;
		<CheckStreamingCompleted>d__.<>1__state = -1;
		<CheckStreamingCompleted>d__.<>t__builder.Start<GameModeController.<CheckStreamingCompleted>d__75>(ref <CheckStreamingCompleted>d__);
		return <CheckStreamingCompleted>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4D5 RID: 115925 RVA: 0x00877A78 File Offset: 0x00875C78
	public void AddOrRemoveRenderAssetsQueryViewInfo(FVectorDouble viewOrigin, float duration)
	{
		if (!GlobalData.World.GetWorld().K2_GetWorldSettings().bEnableWorldPartition)
		{
			return;
		}
		UWorldPartitionSubsystem uworldPartitionSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem;
		if (uworldPartitionSubsystem == null || !uworldPartitionSubsystem.IsValid())
		{
			return;
		}
		uworldPartitionSubsystem.D_AddOrRemoveRenderAssetsQueryViewInfo(viewOrigin, duration, 1.2f);
	}

	// Token: 0x0601C4D6 RID: 115926 RVA: 0x00877AD8 File Offset: 0x00875CD8
	[NullableContext(2)]
	private void ResetRenderAssetsQuery(UWorldPartitionSubsystem worldPartitionSubsystem = null, FWorldPartitionStreamingQuerySource querySource = null, bool raiseError = false)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		TimerHandle checkRenderAssetsStreamingCompletedTimerId = instance.CheckRenderAssetsStreamingCompletedTimerId;
		if (checkRenderAssetsStreamingCompletedTimerId != null && checkRenderAssetsStreamingCompletedTimerId.Valid())
		{
			TimerSystem.Instance.Remove(instance.CheckRenderAssetsStreamingCompletedTimerId);
			instance.CheckRenderAssetsStreamingCompletedTimerId = null;
			if (worldPartitionSubsystem == null)
			{
				worldPartitionSubsystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem);
			}
			if (querySource == null)
			{
				querySource = new FWorldPartitionStreamingQuerySource();
			}
			worldPartitionSubsystem.IsRenderAssetsStreamingCompleted(querySource, false, false, true);
			if (raiseError)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.XY;
				string message = "检查渲染资源(异常结束)";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("是否超时", false);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0601C4D7 RID: 115927 RVA: 0x00877B84 File Offset: 0x00875D84
	[return: Nullable(0)]
	public UniTask<bool> CheckRenderAssetsStreamingCompleted(FVectorDouble viewOrigin, string reason, Func<bool> abortCheckCondition = null)
	{
		GameModeController.<CheckRenderAssetsStreamingCompleted>d__78 <CheckRenderAssetsStreamingCompleted>d__;
		<CheckRenderAssetsStreamingCompleted>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CheckRenderAssetsStreamingCompleted>d__.<>4__this = this;
		<CheckRenderAssetsStreamingCompleted>d__.viewOrigin = viewOrigin;
		<CheckRenderAssetsStreamingCompleted>d__.reason = reason;
		<CheckRenderAssetsStreamingCompleted>d__.abortCheckCondition = abortCheckCondition;
		<CheckRenderAssetsStreamingCompleted>d__.<>1__state = -1;
		<CheckRenderAssetsStreamingCompleted>d__.<>t__builder.Start<GameModeController.<CheckRenderAssetsStreamingCompleted>d__78>(ref <CheckRenderAssetsStreamingCompleted>d__);
		return <CheckRenderAssetsStreamingCompleted>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4D8 RID: 115928 RVA: 0x00877BE0 File Offset: 0x00875DE0
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

	// Token: 0x0601C4D9 RID: 115929 RVA: 0x00877C2C File Offset: 0x00875E2C
	[NullableContext(0)]
	public UniTask<bool> OpenLoading()
	{
		GameModeController.<OpenLoading>d__80 <OpenLoading>d__;
		<OpenLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenLoading>d__.<>1__state = -1;
		<OpenLoading>d__.<>t__builder.Start<GameModeController.<OpenLoading>d__80>(ref <OpenLoading>d__);
		return <OpenLoading>d__.<>t__builder.Task;
	}

	// Token: 0x0601C4DA RID: 115930 RVA: 0x00877C67 File Offset: 0x00875E67
	[NullableContext(2)]
	public void SetTravelMp4(bool play, string path = null)
	{
		if (play && string.IsNullOrEmpty(path))
		{
			return;
		}
		ModelBase<GameModeModel>.Instance.PlayTravelMp4 = play;
		ModelBase<GameModeModel>.Instance.TravelMp4Path = path;
	}

	// Token: 0x0601C4DB RID: 115931 RVA: 0x00877C8C File Offset: 0x00875E8C
	public void ChangeGameMode()
	{
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.LFJW, "[Game.ChangeMode] ChangeMode", default(ReadOnlySpan<ValueTuple<string, object>>));
		try
		{
			this.Manager.ChangeMode();
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[Game.ChangeMode] 调用ControllerManager.ChangeMode异常。";
			Exception error = ex;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		try
		{
			ModelManagerBase<ModelManager>.Instance.ChangeMode();
		}
		catch (Exception ex2)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Game;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[Game.ChangeMode] 调用ModelManager.ChangeMode异常。";
			Exception error2 = ex2;
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex2.Message);
			instance2.ErrorWithStack(module2, author2, message2, error2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
	}

	// Token: 0x0601C4DC RID: 115932 RVA: 0x00877D4C File Offset: 0x00875F4C
	public void UpdateFoliageDataLayer()
	{
		AWorldSettings aworldSettings = GlobalData.World.GetWorld().K2_GetWorldSettings();
		if (aworldSettings == null || !aworldSettings.bEnableWorldPartition)
		{
			return;
		}
		EGameQualitySettingLevel gameQualitySettingLevel = Singleton<GameSettingsDeviceRender>.Instance.GameQualitySettingLevel;
		UKuroRenderingRuntimeBPPluginBPLibrary.UpdateFoliageDataLayer(GlobalData.World, (int)((gameQualitySettingLevel < EGameQualitySettingLevel.VeryLow) ? EGameQualitySettingLevel.Low : gameQualitySettingLevel));
	}

	// Token: 0x0601C4DD RID: 115933 RVA: 0x00877D98 File Offset: 0x00875F98
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
		defaultInterpolatedStringHandler.AppendFormatted<double>((num == 0) ? 0.8 : 1.0);
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

	// Token: 0x0601C4DF RID: 115935 RVA: 0x00877FB0 File Offset: 0x008761B0
	[CompilerGenerated]
	internal static string <PrintLoadDetail>g__GetCmdValue|54_1(string commandLine, string startStr)
	{
		int num = commandLine.IndexOf(startStr);
		if (num != -1)
		{
			int num2 = commandLine.IndexOf(' ', num + startStr.Length);
			return commandLine.Substring(num + startStr.Length, (num2 == -1) ? (commandLine.Length - num - startStr.Length) : (num2 - num - startStr.Length));
		}
		return "";
	}

	// Token: 0x0400E395 RID: 58261
	public const int TOP_CONSUMING_COUNT = 20;

	// Token: 0x0400E396 RID: 58262
	private const int ONE_SECOND = 1000;

	// Token: 0x0400E397 RID: 58263
	private const int GAME_MODE_CTRL_THINKING_INDEX = 21;

	// Token: 0x0400E398 RID: 58264
	private const int SANWANGFENG_INSTANCEID = 1550;

	// Token: 0x0400E399 RID: 58265
	public const int LOG_STREAMING_STUCK_INTERVAL = 60000;

	// Token: 0x0400E39A RID: 58266
	private const int RENDER_ASSET_ABORT_CHECK_DISTANCE_SQUARE = 10000;

	// Token: 0x0400E39B RID: 58267
	private float cellProgress;

	// Token: 0x0400E39C RID: 58268
	private bool HasOverrideQuality;

	// Token: 0x0400E39D RID: 58269
	private int LastGameQualityLevel = -1;

	// Token: 0x0400E39E RID: 58270
	private readonly global::Vector TmpLocation = global::Vector.Create();

	// Token: 0x0400E39F RID: 58271
	private const int DEFAULT_BLOCKER_TIMEOUT = 60000;

	// Token: 0x0400E3A0 RID: 58272
	[TupleElementNames(new string[]
	{
		"blocker",
		"timeout"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly List<ValueTuple<Func<UniTask>, int>> WorldDoneBlockers = new List<ValueTuple<Func<UniTask>, int>>();

	// Token: 0x0400E3A1 RID: 58273
	private bool IsWorldDoneBlockersExecuted;
}
