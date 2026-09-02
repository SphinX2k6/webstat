using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EE8 RID: 20200
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class TeleportController : ControllerBase<TeleportController>
	{
		// Token: 0x060342B1 RID: 213681 RVA: 0x00D0B6D4 File Offset: 0x00D098D4
		public UniTask<bool> TeleportPlayer([Nullable(1)] ITeleportContext param)
		{
			TeleportController.<TeleportPlayer>d__3 <TeleportPlayer>d__;
			<TeleportPlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TeleportPlayer>d__.<>4__this = this;
			<TeleportPlayer>d__.param = param;
			<TeleportPlayer>d__.<>1__state = -1;
			<TeleportPlayer>d__.<>t__builder.Start<TeleportController.<TeleportPlayer>d__3>(ref <TeleportPlayer>d__);
			return <TeleportPlayer>d__.<>t__builder.Task;
		}

		// Token: 0x060342B2 RID: 213682 RVA: 0x00D0B720 File Offset: 0x00D09920
		public UniTask<bool> TeleportPlayerInVehicle([Nullable(1)] ITeleportContext param)
		{
			TeleportController.<TeleportPlayerInVehicle>d__4 <TeleportPlayerInVehicle>d__;
			<TeleportPlayerInVehicle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TeleportPlayerInVehicle>d__.<>4__this = this;
			<TeleportPlayerInVehicle>d__.param = param;
			<TeleportPlayerInVehicle>d__.<>1__state = -1;
			<TeleportPlayerInVehicle>d__.<>t__builder.Start<TeleportController.<TeleportPlayerInVehicle>d__4>(ref <TeleportPlayerInVehicle>d__);
			return <TeleportPlayerInVehicle>d__.<>t__builder.Task;
		}

		// Token: 0x060342B3 RID: 213683 RVA: 0x00D0B76C File Offset: 0x00D0996C
		private UniTask<bool> TeleportPlayerInternal([Nullable(1)] TeleportContext teleportContext, bool isInVehicle)
		{
			TeleportController.<TeleportPlayerInternal>d__5 <TeleportPlayerInternal>d__;
			<TeleportPlayerInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TeleportPlayerInternal>d__.<>4__this = this;
			<TeleportPlayerInternal>d__.teleportContext = teleportContext;
			<TeleportPlayerInternal>d__.isInVehicle = isInVehicle;
			<TeleportPlayerInternal>d__.<>1__state = -1;
			<TeleportPlayerInternal>d__.<>t__builder.Start<TeleportController.<TeleportPlayerInternal>d__5>(ref <TeleportPlayerInternal>d__);
			return <TeleportPlayerInternal>d__.<>t__builder.Task;
		}

		// Token: 0x060342B4 RID: 213684 RVA: 0x00D0B7C0 File Offset: 0x00D099C0
		public UniTask<bool> TeleportElevatorAndPlayerSeparately([Nullable(1)] ITeleportContext param)
		{
			TeleportController.<TeleportElevatorAndPlayerSeparately>d__6 <TeleportElevatorAndPlayerSeparately>d__;
			<TeleportElevatorAndPlayerSeparately>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TeleportElevatorAndPlayerSeparately>d__.param = param;
			<TeleportElevatorAndPlayerSeparately>d__.<>1__state = -1;
			<TeleportElevatorAndPlayerSeparately>d__.<>t__builder.Start<TeleportController.<TeleportElevatorAndPlayerSeparately>d__6>(ref <TeleportElevatorAndPlayerSeparately>d__);
			return <TeleportElevatorAndPlayerSeparately>d__.<>t__builder.Task;
		}

		// Token: 0x060342B5 RID: 213685 RVA: 0x00D0B804 File Offset: 0x00D09A04
		public bool QueryCanTeleportNoLoading(FVectorDouble targetPosition)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				Singleton<Log>.Instance.Warn(ELogModule.Teleport, ELogAuthor.CK, "查询是否可以无加载传送: 失败, 找不到当前玩家", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (!ModelBase<GameModeModel>.Instance.UseWorldPartition)
			{
				return true;
			}
			UWorldPartitionSubsystem uworldPartitionSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UWorldPartitionSubsystem.StaticClass()) as UWorldPartitionSubsystem;
			FWorldPartitionStreamingQuerySource fworldPartitionStreamingQuerySource = new FWorldPartitionStreamingQuerySource();
			fworldPartitionStreamingQuerySource.Location = targetPosition.ToVector();
			fworldPartitionStreamingQuerySource.bUseGridLoadingRange = false;
			fworldPartitionStreamingQuerySource.Radius = 3000f;
			TArray<FWorldPartitionStreamingQuerySource> tarray = new TArray<FWorldPartitionStreamingQuerySource>();
			tarray.Add(fworldPartitionStreamingQuerySource);
			int num = 0;
			int num2 = 0;
			return uworldPartitionSubsystem.IsStreamingCompleted(EWorldPartitionRuntimeCellState.Activated, tarray, false, ref num, ref num2, true, false);
		}

		// Token: 0x060342B6 RID: 213686 RVA: 0x00D0B8B8 File Offset: 0x00D09AB8
		private bool CheckNeedFakeTeleport(TeleportReason? serverReason)
		{
			return ((serverReason.GetValueOrDefault() == TeleportReason.Action || serverReason.GetValueOrDefault() == TeleportReason.FlowAction || serverReason.GetValueOrDefault() == TeleportReason.Fall) && ModelBase<AutoRunModel>.Instance.IsInLogicTreeGmMode()) || (serverReason.GetValueOrDefault() == TeleportReason.Gm && ModelBase<PlotModel>.Instance.IsInHighLevelPlot());
		}

		// Token: 0x060342B7 RID: 213687 RVA: 0x00D0B90C File Offset: 0x00D09B0C
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<TeleportNotify>(ENotifyMessageId.TeleportNotify, new Action<TeleportNotify, Net.CallbackStatus>(this.OnTeleportNotify));
			Singleton<Net>.Instance.Register<TeleportVehicleNotify>(ENotifyMessageId.TeleportVehicleNotify, new Action<TeleportVehicleNotify, Net.CallbackStatus>(this.OnTeleportVehicleNotify));
			Singleton<Net>.Instance.Register<TeleportFlowNotify>(ENotifyMessageId.TeleportFlowNotify, new Action<TeleportFlowNotify, Net.CallbackStatus>(this.OnTeleportFlowNotify));
			return true;
		}

		// Token: 0x060342B8 RID: 213688 RVA: 0x00D0B96E File Offset: 0x00D09B6E
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportVehicleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TeleportFlowNotify);
			return true;
		}

		// Token: 0x060342B9 RID: 213689 RVA: 0x00D0B9A4 File Offset: 0x00D09BA4
		protected override void OnTick(float delta)
		{
			TeleportContext teleportContext = ModelBase<TeleportModel>.Instance.TeleportContext;
			if (teleportContext != null && teleportContext.Seamless.GetValueOrDefault())
			{
				SeamlessTravelTreadmill treadmill = teleportContext.Treadmill;
				if (treadmill != null)
				{
					treadmill.Tick(delta);
				}
				SeamlessTravelPostProcess postProcess = teleportContext.PostProcess;
				if (postProcess != null)
				{
					postProcess.Tick(delta);
				}
				SeamlessTravelKeepMovementMode keepMovementMode = teleportContext.KeepMovementMode;
				if (keepMovementMode != null)
				{
					keepMovementMode.Tick(delta);
				}
			}
			if (!ModelBase<TeleportModel>.Instance.IsTeleport)
			{
				this.HandleCacheServerTeleportNotify();
			}
		}

		// Token: 0x060342BA RID: 213690 RVA: 0x00D0BA14 File Offset: 0x00D09C14
		private void HandleCacheServerTeleportNotify()
		{
			if (this.TeleportPlayerNotifyCache != null)
			{
				this.OnTeleportNotify(this.TeleportPlayerNotifyCache, null);
				return;
			}
			if (this.TeleportVehicleNotifyCache != null)
			{
				this.OnTeleportVehicleNotify(this.TeleportVehicleNotifyCache, null);
			}
		}

		// Token: 0x060342BB RID: 213691 RVA: 0x00D0BA44 File Offset: 0x00D09C44
		public UniTask<bool> TeleportToPositionNoLoading(FVectorDouble targetPosition, FRotator? targetRotation, [Nullable(1)] string reason, bool bNeedRestoreCamera = true)
		{
			TeleportController.<TeleportToPositionNoLoading>d__13 <TeleportToPositionNoLoading>d__;
			<TeleportToPositionNoLoading>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TeleportToPositionNoLoading>d__.<>4__this = this;
			<TeleportToPositionNoLoading>d__.targetPosition = targetPosition;
			<TeleportToPositionNoLoading>d__.targetRotation = targetRotation;
			<TeleportToPositionNoLoading>d__.reason = reason;
			<TeleportToPositionNoLoading>d__.bNeedRestoreCamera = bNeedRestoreCamera;
			<TeleportToPositionNoLoading>d__.<>1__state = -1;
			<TeleportToPositionNoLoading>d__.<>t__builder.Start<TeleportController.<TeleportToPositionNoLoading>d__13>(ref <TeleportToPositionNoLoading>d__);
			return <TeleportToPositionNoLoading>d__.<>t__builder.Task;
		}

		// Token: 0x060342BC RID: 213692 RVA: 0x00D0BAA8 File Offset: 0x00D09CA8
		[NullableContext(1)]
		private unsafe void OnTeleportNotify(TeleportNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			FVectorDouble targetPosition = (message.Position != null) ? global::Vector.Create(message.Position).ToUeVector(false) : global::Vector.ZeroVectorDouble;
			FRotator frotator = (message.Rotation != null) ? global::Rotator.Create(message.Rotation.Y, message.Rotation.Z, message.Rotation.X).ToUeRotator() : global::Rotator.ZeroRotator;
			global::Vector targetGravityDirect = (message.GravityDirection != null) ? global::Vector.Create(message.GravityDirection) : global::Vector.DownVectorProxy;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Teleport;
			ELogAuthor author = ELogAuthor.CK;
			string message2 = "传送: 收到传送协议";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Context", JsonSerializer.Serialize<GameCtxPb>(message.GameCtx, null));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Pos", message.Position);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Rot", message.Rotation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Gravity", message.GravityDirection);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Reason", message.Reason);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			if (ModelBase<TeleportModel>.Instance.IsTeleport)
			{
				this.TeleportPlayerNotifyCache = message;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Teleport;
				ELogAuthor author2 = ELogAuthor.CK;
				string message3 = "传送: 传送中再次收到传送协议, 缓存";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SeverTeleportReason", message.Reason);
				instance2.Info(module2, author2, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.TeleportPlayerNotifyCache = null;
			ITeleportContextParam teleportContextParam = new ITeleportContextParam();
			teleportContextParam.ClientReason = "OnTeleportNotify";
			teleportContextParam.TargetPosition = targetPosition;
			teleportContextParam.TargetRotation = frotator;
			teleportContextParam.TargetGravityDirect = targetGravityDirect;
			teleportContextParam.TeleportMode = new ETeleportMode?(ETeleportMode.Loading);
			teleportContextParam.ServerReason = new TeleportReason?(message.Reason);
			teleportContextParam.TransitionConfigId = new int?(message.TransferEffectId);
			teleportContextParam.Option = message.TransitionOption;
			teleportContextParam.DisableAutoFade = new bool?(message.DisableAutoFadeInScreen);
			GameCtxPb gameCtx = message.GameCtx;
			int? teleportCfgId;
			if (gameCtx == null)
			{
				teleportCfgId = null;
			}
			else
			{
				TransferCtxPb transferCtxPb = gameCtx.TransferCtxPb;
				teleportCfgId = ((transferCtxPb != null) ? new int?(transferCtxPb.TeleportId) : null);
			}
			teleportContextParam.TeleportCfgId = teleportCfgId;
			teleportContextParam.GameCtx = message.GameCtx;
			this.TeleportPlayer(teleportContextParam);
		}

		// Token: 0x060342BD RID: 213693 RVA: 0x00D0BD00 File Offset: 0x00D09F00
		[NullableContext(1)]
		private void OnTeleportFlowNotify(TeleportFlowNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Teleport;
			ELogAuthor author = ELogAuthor.JYS;
			string message2 = "收到上线播放CG请求";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", message.FlowName);
			instance.Info(module, author, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.LoadingTeleport, ELoadingPerform.FadeLoading, null, null, Array.Empty<object>());
			ModelBase<GameModeModel>.Instance.PlayTravelMp4 = true;
			ControllerBase<LevelLoadingController>.Instance.WaitOpenLoading<ELoadingPerform>(ELoadingReason.CG, ELoadingPerform.CG, null, new object[]
			{
				message.FlowName,
				new Action(delegate()
				{
					TeleportFlowEndRequest teleportFlowEndRequest = TeleportFlowEndRequest.Create();
					teleportFlowEndRequest.FlowName = message.FlowName;
					if (string.IsNullOrEmpty(message.FlowName))
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Teleport;
						ELogAuthor author2 = ELogAuthor.JYS;
						string message3 = "收到的CG名称不存在";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Name", message.FlowName);
						instance2.Error(module2, author2, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					Singleton<Net>.Instance.Call<TeleportFlowEndResponse>(ERequestMessageId.TeleportFlowEndRequest, teleportFlowEndRequest, delegate(TeleportFlowEndResponse finishResponse, Net.CallbackStatus callbackStatus)
					{
						if (finishResponse == null || finishResponse.Code != ErrorCode.Success)
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.Teleport;
							ELogAuthor author3 = ELogAuthor.JYS;
							string message4 = "播放CG完成请求失败";
							ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("ErrorCode", finishResponse.Code);
							instance3.Info(module3, author3, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						}
						TeleportContext teleportContext = ModelBase<TeleportModel>.Instance.TeleportContext;
						if (teleportContext != null)
						{
							GameModePromise cgTeleportCompleted = teleportContext.CgTeleportCompleted;
							if (cgTeleportCompleted != null)
							{
								cgTeleportCompleted.SetResult(true);
							}
						}
						GameModePromise videoStartPromise = ModelBase<GameModeModel>.Instance.VideoStartPromise;
						if (videoStartPromise != null)
						{
							videoStartPromise.SetResult(true);
						}
						ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.CG, null, null, null);
						ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.LoadingTeleport, null, null, null);
					}, 0);
				}),
				false
			});
		}

		// Token: 0x060342BE RID: 213694 RVA: 0x00D0BDA8 File Offset: 0x00D09FA8
		[NullableContext(1)]
		private unsafe void OnTeleportVehicleNotify(TeleportVehicleNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			if (message.Location == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Teleport, ELogAuthor.YSQ, "传送载具：目标位置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			long creatureDataId = Singleton<MathUtils>.Instance.LongToNumber(message.Vehicle);
			bool flag = message.PsgPlayerIds.Count > 0;
			FVectorDouble fvectorDouble = new FVectorDouble((double)message.Location.X, (double)message.Location.Y, (double)message.Location.Z);
			Aki.Protocol.Rotator rotation = message.Rotation;
			float pitch = (rotation != null) ? rotation.Pitch : 0f;
			Aki.Protocol.Rotator rotation2 = message.Rotation;
			float yaw = (rotation2 != null) ? rotation2.Yaw : 0f;
			Aki.Protocol.Rotator rotation3 = message.Rotation;
			global::Rotator rotator = global::Rotator.Create(pitch, yaw, (rotation3 != null) ? rotation3.Roll : 0f);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Teleport;
			ELogAuthor author = ELogAuthor.CK;
			string message2 = "OnTeleportVehicleNotify";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Position", fvectorDouble);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Rotation", rotator);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Reason", message.Reason);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (!flag)
			{
				this.SetEntityLocation(creatureDataId, fvectorDouble, rotator, global::Vector.DownVectorProxy);
				return;
			}
			if (ModelBase<TeleportModel>.Instance.IsTeleport)
			{
				this.TeleportVehicleNotifyCache = message;
				return;
			}
			if (!this.IsPlayerInVehicle())
			{
				this.TeleportVehicleNotifyCache = message;
				return;
			}
			this.TeleportVehicleNotifyCache = null;
			ControllerBase<TeleportController>.Instance.TeleportPlayerInVehicle(new ITeleportContextParam
			{
				ClientReason = "OnTeleportVehicleNotify",
				TargetPosition = fvectorDouble,
				TargetRotation = rotator.ToUeRotator(),
				TeleportMode = new ETeleportMode?(message.NoLoading ? ETeleportMode.Auto : ETeleportMode.Loading),
				ServerReason = new TeleportReason?(message.Reason),
				Option = message.TransitionOption
			});
		}

		// Token: 0x060342BF RID: 213695 RVA: 0x00D0BF98 File Offset: 0x00D0A198
		private bool IsPlayerInVehicle()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			BaseActorComponent baseActorComponent;
			if (getCurrentEntity == null)
			{
				baseActorComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				baseActorComponent = ((entity != null) ? entity.GetComponent<BaseActorComponent>() : null);
			}
			BaseActorComponent baseActorComponent2 = baseActorComponent;
			return baseActorComponent2 != null && baseActorComponent2.Entity.CheckGetComponent<CharacterDriveVehicleComponent>().VehicleEntity != null;
		}

		// Token: 0x060342C0 RID: 213696 RVA: 0x00D0BFE4 File Offset: 0x00D0A1E4
		[NullableContext(1)]
		private unsafe void SetEntityLocation(long creatureDataId, IVector targetPosition, global::Rotator targetRotation, IVector targetGravityDirection)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
			if (entity == null || !entity.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "传送载具：实体已无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			BaseActorComponent actorComponent = ControllerBase<CharacterController>.Instance.GetActorComponent(entity);
			actorComponent.SetActorRotation(targetRotation.ToUeRotator(), "ResetLocationForZRangeNotify", true);
			BaseGravityComponent component = entity.Entity.GetComponent<BaseGravityComponent>();
			if (component != null)
			{
				component.SetGravityByPriority(0, targetGravityDirection, true, -1f, true);
			}
			global::Vector vector = global::Vector.Create(targetPosition);
			CharacterActorComponent component2 = entity.Entity.GetComponent<CharacterActorComponent>();
			if (component2 != null)
			{
				component2.FixBornLocation("ResetLocationForZRangeNotify", true, vector, false, true, true);
			}
			else
			{
				actorComponent.SetActorLocation(vector.ToUeVector(false), "ResetLocationForZRangeNotify", false);
			}
			BaseMoveComponent moveComp = actorComponent.MoveComp;
			if (moveComp != null)
			{
				moveComp.SetForceSpeed(global::Vector.ZeroVectorProxy);
			}
			BaseMovementSyncComponent component3 = entity.Entity.GetComponent<BaseMovementSyncComponent>();
			if (component3 != null)
			{
				component3.ClearReplaySamples();
			}
			Singleton<EventSystem>.Instance.EmitWithTarget(entity.Entity, EEventName.TeleportChangeLocation);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Teleport;
			ELogAuthor author2 = ELogAuthor.CK;
			string message2 = "传送载具：设置载具实体位置";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", entity.CreatureDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", entity.PbDataId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", entity.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Location", vector.ToString());
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x060342C1 RID: 213697 RVA: 0x00D0C1AC File Offset: 0x00D0A3AC
		protected override bool OnLeaveLevel()
		{
			TeleportContext teleportContext = ModelBase<TeleportModel>.Instance.TeleportContext;
			if (teleportContext == null)
			{
				return true;
			}
			if (teleportContext.CheckStreamingCompletedTimerId != null)
			{
				if (TimerSystem.GameplayTimeInstance.Has(teleportContext.CheckStreamingCompletedTimerId))
				{
					TimerSystem.GameplayTimeInstance.Remove(teleportContext.CheckStreamingCompletedTimerId);
				}
				teleportContext.CheckStreamingCompletedTimerId = null;
			}
			GameModePromise voxelStreamingCompleted = teleportContext.VoxelStreamingCompleted;
			if (voxelStreamingCompleted != null)
			{
				voxelStreamingCompleted.SetResult(true);
			}
			GameModePromise streamingCompleted = teleportContext.StreamingCompleted;
			if (streamingCompleted != null)
			{
				streamingCompleted.SetResult(true);
			}
			return true;
		}

		// Token: 0x0401E1D8 RID: 123352
		private const int STREAMING_SOURCE_RADIUS_TELEPORT_NO_LOADING = 3000;

		// Token: 0x0401E1D9 RID: 123353
		[Nullable(2)]
		private TeleportNotify TeleportPlayerNotifyCache;

		// Token: 0x0401E1DA RID: 123354
		[Nullable(2)]
		private TeleportVehicleNotify TeleportVehicleNotifyCache;
	}
}
