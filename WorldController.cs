using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using CSharpScript.Core.Common;
using CSharpScript.Core.GameBudgetAllocator;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Perception;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Controller;
using CSharpScript.Launcher.Platform;
using CSharpScript.Typing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003482 RID: 13442
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class WorldController : ControllerBase<WorldController>
{
	// Token: 0x0601C593 RID: 116115 RVA: 0x0087E19C File Offset: 0x0087C39C
	protected override bool OnInit()
	{
		ModelBase<WorldModel>.Instance.CurrentSchedulerDelta = 0.0;
		if (GameBudgetInterfaceController.IsOpen)
		{
			int frameRate = Singleton<GameSettingsDeviceRender>.Instance.FrameRate;
			Singleton<GameBudgetInterfaceController>.Instance.SetMaximumFrameRate(frameRate);
		}
		Singleton<PerformanceController>.Instance.IsOpenCatchWorldEntity = !Singleton<Info>.Instance.IsBuildShipping;
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SettingFrameRateChanged, new Action<int>(this.OnSettingFrameRateChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangePerformanceLimitMode, new Action<bool, bool>(this.OnPerformanceLimitModeChanged));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<Net>.Instance.Register<FuncOpenConfirmNotify>(ENotifyMessageId.FuncOpenConfirmNotify, new Action<FuncOpenConfirmNotify, Net.CallbackStatus>(this.OnFuncOpenConfirmNotify));
		this.DoTickHandle = Singleton<TickSystem>.Instance.Add(new Action<float>(this.DoTick), "WorldController", ETickingGroup.TG_DuringPhysics, false, 0, false);
		this.DoTickFrameEndHandle = Singleton<TickSystem>.Instance.Add(new Action<float>(this.DoTickFrameEnd), "WorldController", ETickingGroup.TG_PostUpdateWork, true, 0, false);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wo.ParallelOffset 1", null);
		this.MemoryGcCheckTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnMemoryGcCheck), 1800000f, 1f, null, "WorldController.OnInit.MemoryGcCheck", false);
		this.VoxelCheckTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnPlayerVoxelEnvCheck), 5000f, 1f, null, null, true);
		return true;
	}

	// Token: 0x0601C594 RID: 116116 RVA: 0x0087E3A0 File Offset: 0x0087C5A0
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SettingFrameRateChanged, new Action<int>(this.OnSettingFrameRateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.OnLeaveOnlineWorld));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangePerformanceLimitMode, new Action<bool, bool>(this.OnPerformanceLimitModeChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FuncOpenConfirmNotify);
		ModelBase<WorldModel>.Instance.ControlPlayerLastLocation = null;
		if (this.VoxelCheckTimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.VoxelCheckTimerId);
			this.VoxelCheckTimerId = null;
		}
		if (this.DoTickHandle != null)
		{
			Singleton<TickSystem>.Instance.Remove(this.DoTickHandle.Id);
			this.DoTickHandle = null;
		}
		if (this.DoTickFrameEndHandle != null)
		{
			Singleton<TickSystem>.Instance.Remove(this.DoTickFrameEndHandle.Id);
			this.DoTickFrameEndHandle = null;
		}
		return true;
	}

	// Token: 0x0601C595 RID: 116117 RVA: 0x0087E51C File Offset: 0x0087C71C
	[NullableContext(2)]
	private unsafe void OnFuncOpenConfirmNotify(FuncOpenConfirmNotify message, Net.CallbackStatus status)
	{
		fixed (byte* pinnableReference = message.FuncInfo.Span.GetPinnableReference())
		{
			byte* data = pinnableReference;
			UFuncOpenBlueprintFunctionLibrary.TryOpen(new FArrayBuffer
			{
				Data = (void*)data,
				Length = (ulong)((long)message.FuncInfo.Length)
			});
		}
	}

	// Token: 0x0601C596 RID: 116118 RVA: 0x0087E56C File Offset: 0x0087C76C
	private void OnMemoryGcCheck(float delta)
	{
		if (this.GlobalIsInFight)
		{
			TimerSystem.GameplayTimeInstance.Pause(this.MemoryGcCheckTimerId, null);
			this.ShouldGcWhenBattleFinished = true;
			return;
		}
		this.ManuallyGarbageCollection(EGarbageCollectionReason.OnTimerFinish);
		this.ShouldGcWhenBattleFinished = false;
	}

	// Token: 0x0601C597 RID: 116119 RVA: 0x0087E59E File Offset: 0x0087C79E
	private void OnTeleportStart(bool b)
	{
		if (this.IsPerformanceLimitMode)
		{
			this.OnPerformanceLimitModeChanged(true, true);
		}
	}

	// Token: 0x0601C598 RID: 116120 RVA: 0x0087E5B0 File Offset: 0x0087C7B0
	[NullableContext(2)]
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		if (this.IsPerformanceLimitMode)
		{
			this.OnPerformanceLimitModeChanged(true, false);
		}
	}

	// Token: 0x0601C599 RID: 116121 RVA: 0x0087E5C2 File Offset: 0x0087C7C2
	private void OnWorldDone()
	{
		ModelBase<WorldModel>.Instance.CurEnvironmentInfo.ServerCaveMode = EActorCavernMode.ActorCavernMode_None;
	}

	// Token: 0x0601C59A RID: 116122 RVA: 0x0087E5D4 File Offset: 0x0087C7D4
	private void OnPerformanceLimitModeChanged(bool isPerformanceLimitMode, bool forceDisable)
	{
		this.IsPerformanceLimitMode = isPerformanceLimitMode;
		Singleton<GameBudgetInterfaceController>.Instance.SetPerformanceLimitMode(isPerformanceLimitMode && !forceDisable);
		BP_GlobalGI_C bp_GlobalGI_C = UKuroGISystem.GetKuroGISystem(GlobalData.World.GetWorld()).GetKuroGlobalGIActor() as BP_GlobalGI_C;
		if (isPerformanceLimitMode && !forceDisable)
		{
			bp_GlobalGI_C.EnableImposterUpdate = false;
			return;
		}
		bp_GlobalGI_C.EnableImposterUpdate = true;
	}

	// Token: 0x0601C59B RID: 116123 RVA: 0x0087E62C File Offset: 0x0087C82C
	private void OnBattleStateChanged(bool bStart)
	{
		this.GlobalIsInFight = bStart;
		if (bStart)
		{
			Singleton<GameSettingsDeviceRender>.Instance.TryReduceCsmUpdateFrequency("Battle");
		}
		else
		{
			Singleton<GameSettingsDeviceRender>.Instance.TryRestoreCsmUpdateFrequency("Battle");
		}
		this.UpdateWPLoadingStreamingCells();
		if (!bStart && this.ShouldGcWhenBattleFinished)
		{
			this.ManuallyGarbageCollection(EGarbageCollectionReason.OnTimerFinishAndWaitForBattle);
			this.ShouldGcWhenBattleFinished = false;
			TimerSystem.GameplayTimeInstance.Resume(this.MemoryGcCheckTimerId);
		}
		UKuroStaticLibrary.SetGameThreadAffinity(bStart);
	}

	// Token: 0x0601C59C RID: 116124 RVA: 0x0087E69C File Offset: 0x0087C89C
	private void OnPlayerVoxelEnvCheck(float delta)
	{
		WorldModel instance = ModelBase<WorldModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.CurEnvironmentInfo.RequestUpdateVoxelEnv();
	}

	// Token: 0x0601C59D RID: 116125 RVA: 0x0087E6BE File Offset: 0x0087C8BE
	private void UpdateWPLoadingStreamingCells()
	{
		if (!Singleton<LoadModeManager>.Instance.IsLoadModeInGameOrForceInGame())
		{
			return;
		}
		if (this.GlobalIsInFight)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.MaxLoadingStreamingCells 1", null);
			return;
		}
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.MaxLoadingStreamingCells 4", null);
	}

	// Token: 0x0601C59E RID: 116126 RVA: 0x0087E6F8 File Offset: 0x0087C8F8
	public void ForceGarbageCollection(bool bFullPurge)
	{
		double milliseconds = KuroTime.GetMilliseconds64();
		UKuroStaticLibrary.ForceGarbageCollection(bFullPurge);
		double num = KuroTime.GetMilliseconds64() - milliseconds;
		if (Singleton<PerfSight>.Instance.IsEnable)
		{
			FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "ForceGarbageCollection", (float)num);
		}
	}

	// Token: 0x0601C59F RID: 116127 RVA: 0x0087E738 File Offset: 0x0087C938
	public void ManuallyGarbageCollection(EGarbageCollectionReason reason)
	{
		if (this.DeviceShouldGc == EShouldGc.NotDecided)
		{
			this.DeviceShouldGc = EShouldGc.ShouldGc;
			if (Singleton<Platform>.Instance.IsAndroidPlatform())
			{
				string deviceCPU = UKuroStaticLibrary.GetDeviceCPU();
				if (deviceCPU.Contains("SDM660"))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.World;
					ELogAuthor author = ELogAuthor.MZJ;
					string message = "Disable ManuallyGarbageCollection";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cpu", deviceCPU);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.DeviceShouldGc = EShouldGc.ShouldNotGc;
				}
			}
		}
		if (this.DeviceShouldGc != EShouldGc.ShouldGc)
		{
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.World;
		ELogAuthor author2 = ELogAuthor.WY;
		string message2 = "ManuallyGarbageCollection";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason: ", reason);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		Singleton<EventSystem>.Instance.Emit(EEventName.TestManuallyGarbageCollection);
		double milliseconds = KuroTime.GetMilliseconds64();
		double num = KuroTime.GetMilliseconds64() - milliseconds;
		if (Singleton<PerfSight>.Instance.IsEnable)
		{
			FKuroPerfSightHelper.PostValueFloat1("CustomPerformance", "ManuallyGarbageCollection", (float)num);
		}
	}

	// Token: 0x0601C5A0 RID: 116128 RVA: 0x0087E818 File Offset: 0x0087CA18
	public void ManuallyClearStreamingPool()
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "ManuallyClearStreamingPool In IOS", default(ReadOnlySpan<ValueTuple<string, object>>));
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSize ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(90);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSizeForMeshes ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(90);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnManuallyClearStreamingPool);
	}

	// Token: 0x0601C5A1 RID: 116129 RVA: 0x0087E8C0 File Offset: 0x0087CAC0
	public void ManuallyResetStreamingPool()
	{
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.WLJ, "ManuallyResetStreamingPool In IOS", default(ReadOnlySpan<ValueTuple<string, object>>));
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSize ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(250);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.Streaming.PoolSizeForMeshes ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(250);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnManuallyResetStreamingPool);
	}

	// Token: 0x0601C5A2 RID: 116130 RVA: 0x0087E974 File Offset: 0x0087CB74
	private void OnSettingFrameRateChanged(int frameRate)
	{
		if (GameBudgetInterfaceController.IsOpen)
		{
			Singleton<GameBudgetInterfaceController>.Instance.SetMaximumFrameRate(frameRate);
			return;
		}
		WorldModel instance = ModelBase<WorldModel>.Instance;
		if (((instance != null) ? instance.TickIntervalSchedulers : null) != null)
		{
			foreach (TickIntervalSchedulerBase tickIntervalSchedulerBase in ModelBase<WorldModel>.Instance.TickIntervalSchedulers)
			{
				tickIntervalSchedulerBase.ChangeTickFramePeriodByFrameRate((double)frameRate);
			}
		}
	}

	// Token: 0x0601C5A3 RID: 116131 RVA: 0x0087E9F0 File Offset: 0x0087CBF0
	private void DoTick(float deltaTime)
	{
		if (!GameBudgetInterfaceController.IsOpen)
		{
			WorldModel instance = ModelBase<WorldModel>.Instance;
			if (Singleton<Time>.Instance.DeltaTime <= 25f && Singleton<Time>.Instance.DeltaTime >= 20f)
			{
				instance.ChangeSchedulerLastType = 0L;
			}
			else if (Singleton<Time>.Instance.DeltaTime > 25f && instance.CurrentSchedulerDelta > 0.0)
			{
				if (instance.ChangeSchedulerLastType != 1L)
				{
					instance.ChangeSchedulerLastType = 1L;
					instance.ChangeSchedulerDeltaFrameCount = 0L;
				}
				else
				{
					WorldModel worldModel = instance;
					long num = worldModel.ChangeSchedulerDeltaFrameCount + 1L;
					worldModel.ChangeSchedulerDeltaFrameCount = num;
					if (num >= 5L)
					{
						instance.CurrentSchedulerDelta -= 1.0;
						instance.ChangeSchedulerDeltaFrameCount = 0L;
						foreach (TickIntervalSchedulerBase tickIntervalSchedulerBase in ModelBase<WorldModel>.Instance.TickIntervalSchedulers)
						{
							tickIntervalSchedulerBase.SetCountDelta(instance.CurrentSchedulerDelta);
						}
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.World;
						ELogAuthor author = ELogAuthor.LCZ;
						string message = "Decrease max tick count";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Delta", instance.CurrentSchedulerDelta);
						instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
			}
			else if (Singleton<Time>.Instance.DeltaTime < 20f && instance.CurrentSchedulerDelta < 0.0)
			{
				if (instance.ChangeSchedulerLastType != 2L)
				{
					instance.ChangeSchedulerLastType = 2L;
					instance.ChangeSchedulerDeltaFrameCount = 0L;
				}
				else
				{
					WorldModel worldModel2 = instance;
					long num = worldModel2.ChangeSchedulerDeltaFrameCount + 1L;
					worldModel2.ChangeSchedulerDeltaFrameCount = num;
					if (num >= 10L)
					{
						instance.CurrentSchedulerDelta += 1.0;
						instance.ChangeSchedulerDeltaFrameCount = 0L;
						foreach (TickIntervalSchedulerBase tickIntervalSchedulerBase2 in ModelBase<WorldModel>.Instance.TickIntervalSchedulers)
						{
							tickIntervalSchedulerBase2.SetCountDelta(instance.CurrentSchedulerDelta);
						}
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.World;
						ELogAuthor author2 = ELogAuthor.LCZ;
						string message2 = "Increase max tick count";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Delta", instance.CurrentSchedulerDelta);
						instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
				}
			}
			foreach (TickIntervalSchedulerBase tickIntervalSchedulerBase3 in ModelBase<WorldModel>.Instance.TickIntervalSchedulers)
			{
				tickIntervalSchedulerBase3.Schedule();
			}
		}
		if (this.UpdateRemoveInterval())
		{
			this.CurrentFrameInterval = 0;
			this.UpdateDestroyPendingNum();
			int destroyPendingNum = this.DestroyPendingNum;
			while (destroyPendingNum-- > 0)
			{
				this.CheckDestroyEntity();
				this.CheckDestroyActor();
			}
		}
	}

	// Token: 0x0601C5A4 RID: 116132 RVA: 0x0087ECB0 File Offset: 0x0087CEB0
	private void UpdateDestroyPendingNum()
	{
		int num = Singleton<Info>.Instance.IsLowMemoryDevice ? 50 : 100;
		if (ModelBase<CreatureModel>.Instance.PendingRemoveEntitySize() > num)
		{
			this.DestroyPendingNum++;
		}
		else
		{
			this.DestroyPendingNum--;
		}
		if (this.DestroyPendingNum < 1)
		{
			this.DestroyPendingNum = 1;
		}
	}

	// Token: 0x0601C5A5 RID: 116133 RVA: 0x0087ED0C File Offset: 0x0087CF0C
	private bool UpdateRemoveInterval()
	{
		this.CurrentFrameInterval++;
		if (!Singleton<Info>.Instance.IsLowMemoryDevice && ModelBase<CreatureModel>.Instance.PendingRemoveEntitySize() < 100 && (ControllerBase<PlayerVelocityController>.Instance.IsHighSpeedMode() || ControllerBase<PlayerSoarMonitorController>.Instance.IsPlayerSoar))
		{
			this.RemoveInterval = 10;
		}
		else
		{
			this.RemoveInterval = 0;
		}
		return this.CurrentFrameInterval >= this.RemoveInterval;
	}

	// Token: 0x0601C5A6 RID: 116134 RVA: 0x0087ED7C File Offset: 0x0087CF7C
	private void DoTickFrameEnd(float deltaTime)
	{
		if (!this.EnableWorldOriginTickCheck)
		{
			return;
		}
		if (Global.BaseCharacter != null)
		{
			FVectorDouble fvectorDouble = Global.BaseCharacter.D_K2_GetActorLocation();
			this.FixWorldOriginTickCheck(fvectorDouble);
		}
	}

	// Token: 0x0601C5A7 RID: 116135 RVA: 0x0087EDAC File Offset: 0x0087CFAC
	private void CheckDestroyEntity()
	{
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		if (instance.PendingRemoveEntitySize() == 0)
		{
			return;
		}
		if (!instance.PeekPendingRemoveEntity().AllowDestroy)
		{
			return;
		}
		this.DestroyEntity(instance.PopPendingRemoveEntity());
	}

	// Token: 0x0601C5A8 RID: 116136 RVA: 0x0087EDE4 File Offset: 0x0087CFE4
	[NullableContext(2)]
	private unsafe void DestroyEntity(EntityHandle handle)
	{
		if (handle == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "[WorldController.DestroyEntity] handle参数无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!handle.Valid)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[WorldController.DestroyEntity] 重复删除Entity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", handle.CreatureDataId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		bool flag = ControllerBase<AttachToActorController>.Instance.DetachActorsBeforeDestroyEntity(handle);
		BaseActorComponent component = handle.Entity.GetComponent<BaseActorComponent>();
		AActor actor = (component != null) ? component.Owner : null;
		long creatureDataId = handle.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		bool flag2 = Singleton<WorldEntityHelper>.Instance.Destroy(handle);
		bool flag3 = ControllerBase<AttachToActorController>.Instance.DetachActorsAfterDestroyEntity(handle.Id);
		if (flag2)
		{
			ModelBase<WorldModel>.Instance.AddDestroyActor(creatureDataId, handle.Id, actor);
		}
		else
		{
			this.DestroyEntityActor(creatureDataId, handle.Id, actor, false);
		}
		if (ControllerBase<CreatureController>.Instance.CheckEnableEntityLog(new OneOf<EEntityType, EntityHandle>?(handle)))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[实体生命周期:删除实体] DestroyEntity结束";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", handle.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntitySystem.DestroyEntity结果", flag2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BeforDetachActors", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AfterDetachActors", flag3);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
		}
	}

	// Token: 0x0601C5A9 RID: 116137 RVA: 0x0087EF98 File Offset: 0x0087D198
	private void CheckDestroyActor()
	{
		WorldModel instance = ModelBase<WorldModel>.Instance;
		if (instance.DestroyActorQueue.Size == 0)
		{
			return;
		}
		ValueTuple<long, int, AActor>? valueTuple = instance.PopDestroyActor();
		UWorld world = GlobalData.World;
		if (world == null || !world.IsValid())
		{
			return;
		}
		ModelBase<WorldModel>.Instance.RemoveIgnore(valueTuple.Value.Item3);
		this.DestroyEntityActor(valueTuple.Value.Item1, valueTuple.Value.Item2, valueTuple.Value.Item3, true);
	}

	// Token: 0x0601C5AA RID: 116138 RVA: 0x0087F01C File Offset: 0x0087D21C
	public void DoLeaveLevel()
	{
		UWorld world = GlobalData.World;
		if (world == null || !world.IsValid())
		{
			return;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		while (instance.PendingRemoveEntitySize() > 0)
		{
			this.DestroyEntity(instance.PopPendingRemoveEntity());
		}
		WorldModel instance2 = ModelBase<WorldModel>.Instance;
		while (instance2.DestroyActorQueue.Size != 0)
		{
			ValueTuple<long, int, AActor>? valueTuple = instance2.PopDestroyActor();
			this.DestroyEntityActor(valueTuple.Value.Item1, valueTuple.Value.Item2, valueTuple.Value.Item3, true);
		}
		instance2.ClearIgnore();
	}

	// Token: 0x0601C5AB RID: 116139 RVA: 0x0087F0AB File Offset: 0x0087D2AB
	public void SetActorDataByCreature(CreatureDataComponent creatureData, [Nullable(2)] AActor actor)
	{
		this.SetEntityRole(creatureData);
		this.SetActorGravityDirection(creatureData, actor);
		this.SetActorLocationAndRotation(creatureData, actor);
		this.SetActorTags(creatureData, actor);
	}

	// Token: 0x0601C5AC RID: 116140 RVA: 0x0087F0CC File Offset: 0x0087D2CC
	private void SetEntityRole(CreatureDataComponent creatureData)
	{
		Entity entity = creatureData.Entity;
		EEntityType entityType = creatureData.GetEntityType();
		if ((entityType == EEntityType.Monster || entityType == EEntityType.Vehicle) && entity.GetComponent<FollowShooterComponent>() == null)
		{
			return;
		}
		bool flag = creatureData.GetPlayerId() == ModelBase<CreatureModel>.Instance.GetPlayerId() || entityType == EEntityType.Npc;
		SceneItemMovementSyncComponent component = entity.GetComponent<SceneItemMovementSyncComponent>();
		bool value = (component != null) ? component.HasMoveAuthority() : flag;
		entity.GetComponent<BaseActorComponent>().SetAutonomous(flag, new bool?(value));
	}

	// Token: 0x0601C5AD RID: 116141 RVA: 0x0087F13C File Offset: 0x0087D33C
	public void SetActorGravityDirection(CreatureDataComponent creatureData, [Nullable(2)] AActor actor)
	{
		if (actor == null)
		{
			return;
		}
		Aki.Protocol.Vector initGravityDirection = creatureData.GetInitGravityDirection();
		if (initGravityDirection != null)
		{
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
			WorldEntity worldEntity = (entityByActor != null) ? entityByActor.Entity : null;
			VehicleGravityComponent vehicleGravityComponent = (worldEntity != null) ? worldEntity.GetComponent<VehicleGravityComponent>() : null;
			if (vehicleGravityComponent != null)
			{
				vehicleGravityComponent.SetGravityDirectForVehicle(0, initGravityDirection, false, -1f, false);
				return;
			}
			BaseGravityComponent baseGravityComponent = (worldEntity != null) ? worldEntity.GetComponent<BaseGravityComponent>() : null;
			if (baseGravityComponent == null)
			{
				return;
			}
			baseGravityComponent.SetGravityByPriority(0, initGravityDirection, true, -1f, false);
		}
	}

	// Token: 0x0601C5AE RID: 116142 RVA: 0x0087F1AC File Offset: 0x0087D3AC
	public void SetActorLocationAndRotation(CreatureDataComponent creatureData, [Nullable(2)] AActor actor)
	{
		if (actor == null)
		{
			return;
		}
		FVectorDouble location = creatureData.GetLocation();
		FRotator rotation = creatureData.GetRotation();
		actor.D_K2_SetActorLocationAndRotation(location, rotation, false, ref WorldGlobal.SweepHitResult, true);
		FVector fvector = UKismetMathLibrary.Conv_VectorDoubleToVector(location);
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(actor, true);
		bool flag;
		if (entityByActor == null)
		{
			flag = (null != null);
		}
		else
		{
			WorldEntity entity = entityByActor.Entity;
			if (entity == null)
			{
				flag = (null != null);
			}
			else
			{
				CharacterMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
				flag = (((component != null) ? component.CharacterMovement : null) != null);
			}
		}
		if (flag)
		{
			FVector zeroVector = global::Vector.ZeroVector;
			FVector zeroVector2 = global::Vector.ZeroVector;
			ActorUtils.GetEntityByActor(actor, true).Entity.GetComponent<CharacterMoveComponent>().CharacterMovement.AddReplayData(ref fvector, ref rotation, ref zeroVector, ref zeroVector2, 0, 0f);
		}
	}

	// Token: 0x0601C5AF RID: 116143 RVA: 0x0087F248 File Offset: 0x0087D448
	private void SetActorTags(CreatureDataComponent creatureData, [Nullable(2)] AActor actor)
	{
		if (actor == null)
		{
			return;
		}
		List<string> publicTags = creatureData.GetPublicTags();
		if (publicTags != null)
		{
			foreach (string key in publicTags)
			{
				FName? dynamicFName = FNameUtil.GetDynamicFName(key);
				actor.Tags.Add(dynamicFName.Value);
			}
		}
	}

	// Token: 0x0601C5B0 RID: 116144 RVA: 0x0087F2B4 File Offset: 0x0087D4B4
	[NullableContext(2)]
	public unsafe bool DestroyEntityActor(long creatureDataId, int entityId, AActor actor, bool useActorSystem = true)
	{
		bool flag = this.DestroyActor(actor, creatureDataId, entityId, useActorSystem);
		if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
		{
			bool flag2 = ControllerBase<AttachToActorController>.Instance.CheckAttachError(entityId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[实体生命周期:删除实体] 删除实体Actor";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Result", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("AttachSuccess", flag2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return flag;
	}

	// Token: 0x0601C5B1 RID: 116145 RVA: 0x0087F380 File Offset: 0x0087D580
	[NullableContext(2)]
	public bool DestroyActor(AActor actor, long creatureDataId, int entityId, bool useActorSystem = true)
	{
		AActor actor2 = actor;
		if (actor2 == null || !actor2.IsValid())
		{
			return false;
		}
		UWorld world = actor.GetWorld();
		if (world == null || !world.IsValid())
		{
			return false;
		}
		AController acontroller = null;
		APawn apawn = actor as APawn;
		if (apawn != null)
		{
			acontroller = apawn.Controller;
		}
		this.DestroyActorList.Clear();
		this.GetAttachedActors(actor, this.DestroyActorList, true);
		for (;;)
		{
			AActor destroyActor;
			if (!this.DestroyActorList.TryPop(out destroyActor))
			{
				break;
			}
			AActor destroyActor2 = destroyActor;
			if (destroyActor2 != null && destroyActor2.IsValid())
			{
				UWorld world2 = destroyActor.GetWorld();
				if (world2 != null && world2.IsValid() && destroyActor != acontroller)
				{
					ModelBase<AttachToActorModel>.Instance.GetEntityIdByActor(destroyActor);
				}
			}
		}
		if (useActorSystem)
		{
			ActorSystem instance = Singleton<ActorSystem>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
			defaultInterpolatedStringHandler.AppendLiteral("WorldController.DestroyActor ");
			defaultInterpolatedStringHandler.AppendFormatted<long>(creatureDataId);
			instance.Put(defaultInterpolatedStringHandler.ToStringAndClear(), actor, null);
		}
		else
		{
			actor.K2_DestroyActor();
		}
		return true;
	}

	// Token: 0x0601C5B2 RID: 116146 RVA: 0x0087F4D4 File Offset: 0x0087D6D4
	private void GetAttachedActors([Nullable(2)] AActor actor, List<AActor> outActors, bool ignore)
	{
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		if (!ignore)
		{
			outActors.Add(actor);
		}
		TArray<AActor> tarray = new TArray<AActor>();
		actor.GetAttachedActors(ref tarray, true);
		for (int i = 0; i < tarray.Num(); i++)
		{
			this.GetAttachedActors(tarray.Get(i), outActors, false);
		}
	}

	// Token: 0x0601C5B3 RID: 116147 RVA: 0x0087F52C File Offset: 0x0087D72C
	public FName? EnvironmentInfoUpdate(FVectorDouble location, bool isRole, bool isTeleport = false)
	{
		if (!ModelBase<WorldModel>.Instance.IsEnableEnvironmentDetecting || !isRole)
		{
			return null;
		}
		if (!ModelBase<GameModeModel>.Instance.UseWorldPartition)
		{
			return null;
		}
		UWorld world = GlobalData.World;
		if (world == null || !world.IsValid())
		{
			return null;
		}
		FKuroVoxelInfo fkuroVoxelInfo = new FKuroVoxelInfo();
		int num = 0;
		VoxelUtils.TryGetVoxelInfo(world, location, ref fkuroVoxelInfo, ref num, -1f);
		FKuroVoxelInfo info = fkuroVoxelInfo;
		bool flag = ModelBase<WorldModel>.Instance.HandleEnvironmentUpdate(info);
		if (isTeleport || flag)
		{
			return this.ApplyEnvironmentInfo(world, location, isTeleport);
		}
		return null;
	}

	// Token: 0x0601C5B4 RID: 116148 RVA: 0x0087F5D0 File Offset: 0x0087D7D0
	public void ChangeCaveOrRoomDatalayer(UObject world, FName? dataLayer, FName? subDataLayer, bool isEnter)
	{
		if (isEnter)
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState(world, dataLayer ?? FName.NAME_None, true);
			UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState(world, subDataLayer ?? FName.NAME_None, false);
			return;
		}
		UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState(world, dataLayer ?? FName.NAME_None, false);
		UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState(world, subDataLayer ?? FName.NAME_None, true);
	}

	// Token: 0x0601C5B5 RID: 116149 RVA: 0x0087F664 File Offset: 0x0087D864
	private unsafe FName? ApplyEnvironmentInfo(UObject world, FVectorDouble location, bool isTeleport)
	{
		EStreamingHandleType estreamingHandleType = ModelBase<WorldModel>.Instance.ApplyEnvironmentUpdate();
		if (estreamingHandleType == EStreamingHandleType.DoNothing)
		{
			return null;
		}
		FName value = FNameUtil.GetDynamicFName(ModelBase<WorldModel>.Instance.CurEnvironmentInfo.DataLayerType.ToEnumString()).Value;
		FName value2 = FNameUtil.GetDynamicFName(ModelBase<WorldModel>.Instance.CurEnvironmentInfo.SubDataLayerType.ToEnumString()).Value;
		Singleton<EventSystem>.Instance.Emit<EStreamingHandleType>(EEventName.OnEncloseSpaceTypeChange, estreamingHandleType);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.LevelEvent;
		ELogAuthor author = ELogAuthor.XY;
		string message = "[WorldController]Streaming:体素参数";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DataLayer", value);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SubDatalayer", value2);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		switch (estreamingHandleType)
		{
		case EStreamingHandleType.EnterEncloseSpace:
			this.ChangeCaveOrRoomDatalayer(world, new FName?(value), new FName?(value2), true);
			Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:进入封闭空间", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_IntermediateZone);
			return new FName?(value);
		case EStreamingHandleType.ExitEncloseSpace:
			UKuroRenderingRuntimeBPPluginBPLibrary.SetIsUsingInCaveOrIndoorShadow(world, false, 20000f, 8000f);
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_IntermediateZone);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnOverlapEncloseSpace, false);
			Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:退出封闭空间", default(ReadOnlySpan<ValueTuple<string, object>>));
			break;
		case EStreamingHandleType.FinishEnterEncloseSpace:
			UKuroRenderingRuntimeBPPluginBPLibrary.SetIsUsingInCaveOrIndoorShadow(world, true, 20000f, 8000f);
			Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:完成进入封闭空间", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_Inside);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnOverlapEncloseSpace, true);
			break;
		case EStreamingHandleType.FinishExitEncloseSpace:
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_Outside);
			this.ChangeCaveOrRoomDatalayer(world, new FName?(value), new FName?(value2), false);
			Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:完成退出封闭空间", default(ReadOnlySpan<ValueTuple<string, object>>));
			break;
		case EStreamingHandleType.ImmediateEnter:
			this.ChangeCaveOrRoomDatalayer(world, new FName?(value), new FName?(value2), true);
			UKuroRenderingRuntimeBPPluginBPLibrary.SetIsUsingInCaveOrIndoorShadow(world, true, 20000f, 8000f);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnOverlapEncloseSpace, true);
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_Inside);
			if (!isTeleport)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.YZH;
				string message2 = "[WorldController]Streaming:非传送下,无过渡区域进入封闭空间";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Location", location);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.RequestToNearestTeleport();
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:进入封闭空间[传送]", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return new FName?(value);
		case EStreamingHandleType.ImmediateExit:
			this.ChangeCaveOrRoomDatalayer(world, new FName?(value), new FName?(value2), false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnOverlapEncloseSpace, false);
			UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_Outside);
			if (!isTeleport)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelEvent;
				ELogAuthor author3 = ELogAuthor.YZH;
				string message3 = "[WorldController]Streaming:非传送下,无过渡区域退出封闭空间";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Location", location);
				instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.RequestToNearestTeleport();
			}
			else
			{
				Singleton<Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, "[WorldController]Streaming:退出封闭空间[传送]", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			UKuroRenderingRuntimeBPPluginBPLibrary.SetIsUsingInCaveOrIndoorShadow(world, false, 20000f, 8000f);
			break;
		}
		return null;
	}

	// Token: 0x0601C5B6 RID: 116150 RVA: 0x0087F994 File Offset: 0x0087DB94
	public bool IsEncloseSpace(int pbDataId, FVectorDouble location, EEntityType entityType, EntityConfigType entityConfigType, bool isSummonsAndCtrlByMe = false)
	{
		if (!ModelBase<GameModeModel>.Instance.UseWorldPartition || pbDataId == 0)
		{
			return false;
		}
		UWorld world = GlobalData.World;
		if (world == null || !world.IsValid())
		{
			return false;
		}
		if (entityType == EEntityType.Player || entityType == EEntityType.Vision || isSummonsAndCtrlByMe)
		{
			return false;
		}
		EntityVoxelInfo? entityVoxelInfo = null;
		if (entityConfigType == EntityConfigType.Level)
		{
			entityVoxelInfo = ConfigEntityVoxelInfoByMapIdAndEntityId.GetConfig(ModelBase<GameModeModel>.Instance.MapId, pbDataId, true);
		}
		if (entityVoxelInfo == null)
		{
			int num = 0;
			byte envType = VoxelUtils.GetVoxelInfo(world, location, ref num, -1f).EnvType;
			return envType <= 1 || (envType != byte.MaxValue && false);
		}
		int envType2 = entityVoxelInfo.Value.EnvType;
		return envType2 <= 1 || (envType2 != 255 && false);
	}

	// Token: 0x0601C5B7 RID: 116151 RVA: 0x0087FA55 File Offset: 0x0087DC55
	public void RequestToNearestTeleport()
	{
		Singleton<Net>.Instance.Call<UnOpenedAreaPullbackResponse>(ERequestMessageId.UnOpenedAreaPullbackRequest, UnOpenedAreaPullbackRequest.Create(), delegate(UnOpenedAreaPullbackResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21402, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0601C5B8 RID: 116152 RVA: 0x0087FA8B File Offset: 0x0087DC8B
	private void OnLeaveOnlineWorld()
	{
		UKuroGameBudgetAllocatorCSharpInterface.ClearAssistantActors();
	}

	// Token: 0x0601C5B9 RID: 116153 RVA: 0x0087FA94 File Offset: 0x0087DC94
	private void OnFormationChange()
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return;
		}
		UKuroGameBudgetAllocatorCSharpInterface.ClearAssistantActors();
		foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItems(false))
		{
			if (!sceneTeamItem.IsMyRole())
			{
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				TsBaseCharacter tsBaseCharacter;
				if (entityHandle == null)
				{
					tsBaseCharacter = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity == null)
					{
						tsBaseCharacter = null;
					}
					else
					{
						CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
						tsBaseCharacter = ((component != null) ? component.Actor : null);
					}
				}
				TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
				if (tsBaseCharacter2 != null)
				{
					UKuroGameBudgetAllocatorCSharpInterface.AddAssistantActor(tsBaseCharacter2);
				}
			}
		}
	}

	// Token: 0x0601C5BA RID: 116154 RVA: 0x0087FB34 File Offset: 0x0087DD34
	public unsafe void GetEntitiesInRangeWithLocation(FVectorDouble location, float distance, EEntityTypeQuery entityType, ICollection<EntityHandle> result, bool bResetArray)
	{
		if (bResetArray)
		{
			result.Clear();
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		for (int i = 0; i < 9; i++)
		{
			if ((entityType & (EEntityTypeQuery)(1 << i)) != (EEntityTypeQuery)0)
			{
				IntPtr[] array = Array.Empty<IntPtr>();
				FKuroGameBudgetAllocatorCSharpInterface.GetEntitiesInRangeWithLocation(location, distance, EntityHelperConstants.GlobalEntityTypeQueryName[i], ref array);
				Span<IntPtr> span = array.AsSpan<IntPtr>();
				for (int j = 0; j < span.Length; j++)
				{
					IntPtr intPtr = *span[j];
					if (intPtr != IntPtr.Zero)
					{
						Entity entity = GCHandle.FromIntPtr(intPtr).Target as Entity;
						if (entity != null)
						{
							EntityHandle handleByEntity = instance.GetHandleByEntity(entity);
							if (handleByEntity != null)
							{
								result.Add(handleByEntity);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601C5BB RID: 116155 RVA: 0x0087FBF0 File Offset: 0x0087DDF0
	public void GetEntitiesInRange(float distance, EEntityTypeQuery entityType, ICollection<EntityHandle> result, bool bResetArray, bool bContainPlayer)
	{
		if (bResetArray)
		{
			result.Clear();
		}
		List<Entity> list = new List<Entity>();
		uint num = 0U;
		EPerceptionEntityType[] globalEntityTypePerceptionType = CreatureModel.globalEntityTypePerceptionType;
		for (int i = 0; i < 9; i++)
		{
			if ((entityType & (EEntityTypeQuery)(1 << i)) != (EEntityTypeQuery)0 && i < globalEntityTypePerceptionType.Length)
			{
				EPerceptionEntityType eperceptionEntityType = globalEntityTypePerceptionType[i];
				if (eperceptionEntityType != EPerceptionEntityType.Player)
				{
					num |= (uint)eperceptionEntityType;
				}
			}
		}
		if ((entityType & EEntityTypeQuery.Team) > (EEntityTypeQuery)0 && bContainPlayer)
		{
			List<Entity> list2 = new List<Entity>();
			IntPtr[] array = Array.Empty<IntPtr>();
			FKuroGameBudgetAllocatorCSharpInterface.GetAllPlayerEntities(ref array);
			foreach (IntPtr intPtr in array)
			{
				if (intPtr != IntPtr.Zero)
				{
					Entity entity = GCHandle.FromIntPtr(intPtr).Target as Entity;
					if (entity != null)
					{
						list2.Add(entity);
					}
				}
			}
			foreach (Entity entity2 in list2)
			{
				EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity2);
				if (handleByEntity != null)
				{
					result.Add(handleByEntity);
				}
			}
		}
		IntPtr[] array2 = Array.Empty<IntPtr>();
		FKuroPerceptionCSharpInterface.GetEntitiesInPlayerPerceptionRange(distance, num, ref array2);
		foreach (IntPtr intPtr2 in array2)
		{
			if (intPtr2 != IntPtr.Zero)
			{
				Entity entity3 = GCHandle.FromIntPtr(intPtr2).Target as Entity;
				if (entity3 != null)
				{
					list.Add(entity3);
				}
			}
		}
		foreach (Entity entity4 in list)
		{
			EntityHandle handleByEntity2 = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity4);
			if (handleByEntity2 != null)
			{
				result.Add(handleByEntity2);
			}
		}
	}

	// Token: 0x0601C5BC RID: 116156 RVA: 0x0087FDB0 File Offset: 0x0087DFB0
	public int GetCustomEntityId(int ownerEntityId, int pos)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(ownerEntityId);
		if (entity != null)
		{
			EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(entity, ESummonType.ConcomitantCustom, pos);
			if (summonedEntity != null)
			{
				return summonedEntity.Id;
			}
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "无法找到伴生物拥有者实体";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ownerEntityId", ownerEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return 0;
	}

	// Token: 0x0601C5BD RID: 116157 RVA: 0x0087FE0C File Offset: 0x0087E00C
	public UniTask StartWorldOriginInUiMode()
	{
		WorldController.<StartWorldOriginInUiMode>d__83 <StartWorldOriginInUiMode>d__;
		<StartWorldOriginInUiMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartWorldOriginInUiMode>d__.<>4__this = this;
		<StartWorldOriginInUiMode>d__.<>1__state = -1;
		<StartWorldOriginInUiMode>d__.<>t__builder.Start<WorldController.<StartWorldOriginInUiMode>d__83>(ref <StartWorldOriginInUiMode>d__);
		return <StartWorldOriginInUiMode>d__.<>t__builder.Task;
	}

	// Token: 0x0601C5BE RID: 116158 RVA: 0x0087FE50 File Offset: 0x0087E050
	public UniTask EndWorldOriginInUiMode()
	{
		WorldController.<EndWorldOriginInUiMode>d__84 <EndWorldOriginInUiMode>d__;
		<EndWorldOriginInUiMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EndWorldOriginInUiMode>d__.<>4__this = this;
		<EndWorldOriginInUiMode>d__.<>1__state = -1;
		<EndWorldOriginInUiMode>d__.<>t__builder.Start<WorldController.<EndWorldOriginInUiMode>d__84>(ref <EndWorldOriginInUiMode>d__);
		return <EndWorldOriginInUiMode>d__.<>t__builder.Task;
	}

	// Token: 0x0601C5BF RID: 116159 RVA: 0x0087FE93 File Offset: 0x0087E093
	public bool GetIsWorldOriginInUiMode()
	{
		return this.IsWorldOriginInUiMode;
	}

	// Token: 0x0601C5C0 RID: 116160 RVA: 0x0087FE9C File Offset: 0x0087E09C
	public void StartWorldOriginInLoadingMode(string reason)
	{
		if (!this.IsWorldOriginInLoadingMode)
		{
			this.IsWorldOriginInLoadingMode = true;
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "IsWorldOriginInLoadingMode 开关不成对", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601C5C1 RID: 116161 RVA: 0x0087FED8 File Offset: 0x0087E0D8
	public void EndWorldOriginInLoadingMode(string reason, in FVectorDouble origin)
	{
		if (this.IsWorldOriginInLoadingMode)
		{
			if (this.IsWorldOriginInUiMode)
			{
				this.CacheWorldOrigin.DeepCopy(origin);
			}
			else
			{
				this.FixWorldOrigin(reason, origin);
			}
			this.IsWorldOriginInLoadingMode = false;
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.ZWY, "IsWorldOriginInLoadingMode 开关不成对", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0601C5C2 RID: 116162 RVA: 0x0087FF30 File Offset: 0x0087E130
	public void SetEnableWorldOriginTickCheck(string reason, bool enableCheck)
	{
		if (this.EnableWorldOriginTickCheck == enableCheck)
		{
			Singleton<Log>.Instance.Warn(ELogModule.World, ELogAuthor.ZWY, "SetEnableWorldOriginTickCheck 调用不成对", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.EnableWorldOriginTickCheck = enableCheck;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "SetEnableWorldOriginTickCheck";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601C5C3 RID: 116163 RVA: 0x0087FF94 File Offset: 0x0087E194
	public void SetEnableWorldOrigin(bool enableWorldOrigin)
	{
		this.EnableWorldOrigin = enableWorldOrigin;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "EnableWorldOrigin";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EnableWorldOrigin", enableWorldOrigin);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0601C5C4 RID: 116164 RVA: 0x0087FFD4 File Offset: 0x0087E1D4
	public void FixWorldOriginTickCheck(in FVectorDouble origin)
	{
		if (this.IsAllWorldOriginConditionEnable() && this.IsCheckFixWorldOriginPass(origin))
		{
			this.FixWorldOrigin("Tick", origin);
		}
	}

	// Token: 0x0601C5C5 RID: 116165 RVA: 0x0087FFF3 File Offset: 0x0087E1F3
	public bool FixWorldOriginGm(in FVectorDouble origin)
	{
		if (this.IsAllWorldOriginConditionEnable())
		{
			this.FixWorldOrigin("GM", origin);
			return true;
		}
		return false;
	}

	// Token: 0x0601C5C6 RID: 116166 RVA: 0x0088000C File Offset: 0x0087E20C
	private bool IsWorldOriginFinish()
	{
		if (GlobalData.World == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZWY, "IsWorldOriginFinish false No World", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (UKuroRenderingRuntimeBPPluginBPLibrary.IsWorldOriginFinish(GlobalData.World))
		{
			return true;
		}
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZWY, "IsWorldOriginFinish false", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x0601C5C7 RID: 116167 RVA: 0x00880069 File Offset: 0x0087E269
	private bool IsAllWorldOriginConditionEnable()
	{
		return !this.IsWorldOriginInUiMode && !this.IsWorldOriginInLoadingMode;
	}

	// Token: 0x0601C5C8 RID: 116168 RVA: 0x00880080 File Offset: 0x0087E280
	private bool IsCheckFixWorldOriginPass(in FVectorDouble origin)
	{
		this.CheckRateInternal++;
		if (this.CheckRateInternal < this.CheckRateMax)
		{
			return false;
		}
		this.CheckRateInternal = 0;
		if (Math.Abs(origin.X - this.WorldOriginValue.X) < (double)this.OriginNeedChangeMax && Math.Abs(origin.Y - this.WorldOriginValue.Y) < (double)this.OriginNeedChangeMax && Math.Abs(origin.Z - this.WorldOriginValue.Z) < (double)this.OriginNeedChangeMax)
		{
			return false;
		}
		if (this.LastSetWorldOriginFrame == Singleton<Time>.Instance.Frame)
		{
			return false;
		}
		if (ModelBase<PlotModel>.Instance.IsInPlot)
		{
			return false;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleView))
		{
			return false;
		}
		if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			return false;
		}
		int entityIdNoBlueprint = Global.BaseCharacter.GetEntityIdNoBlueprint();
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdNoBlueprint);
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		return baseTagComponent != null && !baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]) && !baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.控物中"]) && !baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"]);
	}

	// Token: 0x0601C5C9 RID: 116169 RVA: 0x008801CC File Offset: 0x0087E3CC
	public unsafe void SetEnableZAxisOffset(bool enable, string reason)
	{
		if (this.EnableZAxisOffset == enable)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null)
		{
			this.EnableZAxisOffset = enable;
			FVectorDouble fvectorDouble = baseCharacter.D_K2_GetActorLocation();
			this.FixWorldOrigin(reason, fvectorDouble);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LC;
			string message = "SetEnableZAxisOffset";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("enable", enable);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0601C5CA RID: 116170 RVA: 0x0088025C File Offset: 0x0087E45C
	private unsafe void FixWorldOrigin(string reason, in FVectorDouble origin)
	{
		if (this.LastSetWorldOriginFrame != Singleton<Time>.Instance.Frame)
		{
			this.LastWorldOriginValue.DeepCopy(this.WorldOriginValue);
			this.LastSetWorldOriginFrame = Singleton<Time>.Instance.Frame;
		}
		FVectorDouble fvectorDouble = new FVectorDouble();
		fvectorDouble.X = Math.Truncate(origin.X);
		fvectorDouble.Y = Math.Truncate(origin.Y);
		fvectorDouble.Z = (this.EnableZAxisOffset ? Math.Truncate(origin.Z) : 0.0);
		this.WorldOriginValue.X = fvectorDouble.X;
		this.WorldOriginValue.Y = fvectorDouble.Y;
		this.WorldOriginValue.Z = fvectorDouble.Z;
		if (!this.EnableWorldOrigin)
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZWY, "SetWorldOriginIgnore", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldOrigin(GlobalData.World, fvectorDouble);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "SetWorldOrigin";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Origin", fvectorDouble);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		TimerSystem.GameplayTimeInstance.Next(delegate(float _)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Shadow.ForceUpdateCSMOnce 1", null);
		}, null, null);
	}

	// Token: 0x0601C5CB RID: 116171 RVA: 0x008803D4 File Offset: 0x0087E5D4
	public void ToWorldRelativeLocation(IVector location, IVector outRelative)
	{
		if (!this.EnableWorldOrigin)
		{
			outRelative.X = location.X;
			outRelative.Y = location.Y;
			outRelative.Z = location.Z;
			return;
		}
		outRelative.X = location.X - this.WorldOriginValue.X;
		outRelative.Y = location.Y - this.WorldOriginValue.Y;
		outRelative.Z = location.Z - this.WorldOriginValue.Z;
	}

	// Token: 0x0400E411 RID: 58385
	private const int DELTA_TIME_LIMIT_LOW = 20;

	// Token: 0x0400E412 RID: 58386
	private const int DELTA_TIME_LIMIT_HIGH = 25;

	// Token: 0x0400E413 RID: 58387
	private const int MIN_DELTA = 0;

	// Token: 0x0400E414 RID: 58388
	private const int MAX_DELTA = 0;

	// Token: 0x0400E415 RID: 58389
	private const int SCHEDULER_MINUS_FRAME_COUNT = 5;

	// Token: 0x0400E416 RID: 58390
	private const int DEFAULT_ENVIRONMENTTYPE = 255;

	// Token: 0x0400E417 RID: 58391
	private const int IOS_STREAMING_POOL_SIZE = 250;

	// Token: 0x0400E418 RID: 58392
	private const int IOS_STREAMING_POOL_SIZE_FOR_MESHES = 250;

	// Token: 0x0400E419 RID: 58393
	private const int IOS_STREAMING_POOL_SIZE_IN_LOADING = 90;

	// Token: 0x0400E41A RID: 58394
	private const int IOS_STREAMING_POOL_SIZE_FOR_MESHES_IN_LOADING = 90;

	// Token: 0x0400E41B RID: 58395
	private const int HIGH_SPEED_REMOVE_INTERVAL = 10;

	// Token: 0x0400E41C RID: 58396
	private const int MAX_PENDING_REMOVE_COUNT = 100;

	// Token: 0x0400E41D RID: 58397
	private const int LOW_MEMORY_PENDING_REMOVE_COUNT = 50;

	// Token: 0x0400E41E RID: 58398
	private bool GlobalIsInFight;

	// Token: 0x0400E41F RID: 58399
	[Nullable(2)]
	private TimerHandle MemoryGcCheckTimerId;

	// Token: 0x0400E420 RID: 58400
	[Nullable(2)]
	private TimerHandle VoxelCheckTimerId;

	// Token: 0x0400E421 RID: 58401
	private bool ShouldGcWhenBattleFinished;

	// Token: 0x0400E422 RID: 58402
	private EShouldGc DeviceShouldGc;

	// Token: 0x0400E423 RID: 58403
	private bool IsPerformanceLimitMode;

	// Token: 0x0400E424 RID: 58404
	private int RemoveInterval;

	// Token: 0x0400E425 RID: 58405
	private int CurrentFrameInterval;

	// Token: 0x0400E426 RID: 58406
	private int DestroyPendingNum = 1;

	// Token: 0x0400E427 RID: 58407
	[Nullable(2)]
	private Ticker DoTickHandle;

	// Token: 0x0400E428 RID: 58408
	[Nullable(2)]
	private Ticker DoTickFrameEndHandle;

	// Token: 0x0400E429 RID: 58409
	private bool EnableZAxisOffset = true;

	// Token: 0x0400E42A RID: 58410
	private readonly List<AActor> DestroyActorList = new List<AActor>();

	// Token: 0x0400E42B RID: 58411
	private readonly global::Vector WorldOriginValue = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400E42C RID: 58412
	private readonly global::Vector LastWorldOriginValue = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400E42D RID: 58413
	private int LastSetWorldOriginFrame;

	// Token: 0x0400E42E RID: 58414
	public bool EnableWorldOrigin = true;

	// Token: 0x0400E42F RID: 58415
	public bool EnableWorldOriginLoadingCheck = true;

	// Token: 0x0400E430 RID: 58416
	public bool EnableWorldOriginTickCheck = true;

	// Token: 0x0400E431 RID: 58417
	public int OriginNeedChangeMax = 250000;

	// Token: 0x0400E432 RID: 58418
	public int CheckRateMax = 30;

	// Token: 0x0400E433 RID: 58419
	private int CheckRateInternal;

	// Token: 0x0400E434 RID: 58420
	private bool IsWorldOriginInUiMode;

	// Token: 0x0400E435 RID: 58421
	private bool IsWorldOriginInLoadingMode;

	// Token: 0x0400E436 RID: 58422
	private readonly global::Vector CacheWorldOrigin = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400E437 RID: 58423
	[Nullable(2)]
	private TimerHandle CheckWorldOriginFinishTimer;

	// Token: 0x0400E438 RID: 58424
	private int CheckWorldOriginFinishTimerNum;

	// Token: 0x0400E439 RID: 58425
	private readonly int CheckWorldOriginFinishTimerNumMax = 10;
}
