using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.PathDrivenActorSpawner
{
	// Token: 0x02004834 RID: 18484
	[NullableContext(2)]
	[Nullable(0)]
	public class PathDrivenActorSpawnerComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x17008247 RID: 33351
		// (get) Token: 0x0603019B RID: 197019 RVA: 0x00BAB13D File Offset: 0x00BA933D
		[Nullable(1)]
		public static Type[] Dependencies
		{
			[NullableContext(1)]
			get
			{
				return new Type[]
				{
					typeof(CreatureDataComponent),
					typeof(SceneItemStateComponent)
				};
			}
		}

		// Token: 0x0603019C RID: 197020 RVA: 0x00BAB160 File Offset: 0x00BA9360
		protected override bool OnInitData(IEntityArgs args = null)
		{
			object param = args.GetP1<CreateEntityData>().GetParam<PathDrivenActorSpawnerComponent>();
			this.Config = (param as PathDrivenActorSpawnerComponent);
			PathDrivenActorSpawnerComponent config = this.Config;
			this.SpawnRule = ((config != null) ? config.SpawnRule : null);
			return this.Config != null && this.SpawnRule != null;
		}

		// Token: 0x0603019D RID: 197021 RVA: 0x00BAB1B0 File Offset: 0x00BA93B0
		protected unsafe override bool OnStart()
		{
			this.StateComp = base.Entity.GetComponent<SceneItemStateComponent>();
			IIntervalSplineSpawn spawnRule = this.SpawnRule;
			if (spawnRule == null || spawnRule.Type > EPathDrivenActorSpawnType.IntervalSplineSpawn)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[PathDrivenActorSpawnerComponent] 不支持的生成规则类型";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.GetOwnerPbDataId());
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "SpawnType";
				IIntervalSplineSpawn spawnRule2 = this.SpawnRule;
				ptr = new ValueTuple<string, object>(item, (spawnRule2 != null) ? new EPathDrivenActorSpawnType?(spawnRule2.Type) : null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			IPathDrivenActorSplineMove moveMode = this.SpawnRule.MoveMode;
			if (this.SpawnRule.MoveMode.Type != EPathDrivenActorMoveType.Spline || moveMode == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PathDrivenActor;
				ELogAuthor author2 = ELogAuthor.WRY;
				string message2 = "[PathDrivenActorSpawnerComponent] 当前仅支持样条运动模式";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.GetOwnerPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("MoveType", this.SpawnRule.MoveMode.Type);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			this.ActorClassPath = this.NormalizeActorClassPath(this.SpawnRule.ActorBlueprintPath);
			return !string.IsNullOrEmpty(this.ActorClassPath);
		}

		// Token: 0x0603019E RID: 197022 RVA: 0x00BAB32C File Offset: 0x00BA952C
		protected override void OnActivate()
		{
			Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<int, bool>(this, base.Entity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.OnStateChange));
			SceneItemStateComponent stateComp = this.StateComp;
			if (stateComp == null || !stateComp.IsInState(SceneItemStateComponent.ESceneItemState.Born))
			{
				this.OnStateChange(0, false);
			}
		}

		// Token: 0x0603019F RID: 197023 RVA: 0x00BAB37C File Offset: 0x00BA957C
		protected override void OnTick(float delta)
		{
			if (this.State != EPathDrivenActorSpawnerState.Running)
			{
				return;
			}
			float num = Math.Max(delta, 0f) * 0.001f;
			if (num <= 0f)
			{
				return;
			}
			PathDrivenActorRuntimeController runtimeController = this.RuntimeController;
			if (runtimeController == null)
			{
				return;
			}
			runtimeController.Tick(num);
		}

		// Token: 0x060301A0 RID: 197024 RVA: 0x00BAB3BF File Offset: 0x00BA95BF
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			this.StopAndClear("[PathDrivenActorSpawnerComponent] OnEnd");
			this.CancelActorClassLoad();
			return true;
		}

		// Token: 0x060301A1 RID: 197025 RVA: 0x00BAB3DF File Offset: 0x00BA95DF
		protected override bool OnClear()
		{
			this.StopAndClear("[PathDrivenActorSpawnerComponent] OnClear");
			this.CancelActorClassLoad();
			this.Config = null;
			this.SpawnRule = null;
			this.ActorClassPath = null;
			this.ActorClass = null;
			this.StateComp = null;
			return true;
		}

		// Token: 0x060301A2 RID: 197026 RVA: 0x00BAB416 File Offset: 0x00BA9616
		private void OnStateChange(int _1 = 0, bool _2 = false)
		{
			SceneItemStateComponent stateComp = this.StateComp;
			if (stateComp != null && stateComp.IsInState(SceneItemStateComponent.ESceneItemState.Active))
			{
				this.RequestStart();
				return;
			}
			this.RequestStop("[PathDrivenActorSpawnerComponent] StateInactive");
		}

		// Token: 0x060301A3 RID: 197027 RVA: 0x00BAB43F File Offset: 0x00BA963F
		private void RequestStart()
		{
			this.DesiredRunning = true;
			if (this.State == EPathDrivenActorSpawnerState.Running)
			{
				this.TryRegisterOwnerAssistantActor();
				return;
			}
			this.TryStartRunning();
		}

		// Token: 0x060301A4 RID: 197028 RVA: 0x00BAB460 File Offset: 0x00BA9660
		private void TryStartRunning()
		{
			if (this.DesiredRunning)
			{
				SceneItemStateComponent stateComp = this.StateComp;
				if (stateComp != null && stateComp.IsInState(SceneItemStateComponent.ESceneItemState.Active))
				{
					UClass actorClass = this.ActorClass;
					if (actorClass == null || !actorClass.IsValid())
					{
						this.EnterState(EPathDrivenActorSpawnerState.LoadingActorClass);
						this.TryLoadActorClassAsync();
						return;
					}
					if (this.TrackRuntimeSet == null || this.TrackRuntimeSet.TrackList.Count <= 0)
					{
						this.StartPrepareTracks();
						return;
					}
					this.TryCreateRuntimeController();
					if (this.RuntimeController == null)
					{
						this.DesiredRunning = false;
						this.EnterState(EPathDrivenActorSpawnerState.Idle);
						return;
					}
					this.EnterState(EPathDrivenActorSpawnerState.Running);
					return;
				}
			}
		}

		// Token: 0x060301A5 RID: 197029 RVA: 0x00BAB4FC File Offset: 0x00BA96FC
		private void StartPrepareTracks()
		{
			if (this.State == EPathDrivenActorSpawnerState.PreparingTracks || this.SpawnRule == null)
			{
				return;
			}
			IPathDrivenActorSplineMove moveMode = this.SpawnRule.MoveMode;
			if (moveMode == null)
			{
				return;
			}
			this.ReleaseTrackSet();
			this.EnterState(EPathDrivenActorSpawnerState.PreparingTracks);
			int? ownerPbDataId = this.GetOwnerPbDataId();
			IReadOnlyList<int> splineEntityIds = moveMode.SplineEntityIds;
			this.PrepareTracksAsync(ownerPbDataId, splineEntityIds);
		}

		// Token: 0x060301A6 RID: 197030 RVA: 0x00BAB550 File Offset: 0x00BA9750
		[NullableContext(1)]
		private UniTask PrepareTracksAsync(int? ownerPbDataId, IReadOnlyList<int> splineEntityIds)
		{
			PathDrivenActorSpawnerComponent.<PrepareTracksAsync>d__25 <PrepareTracksAsync>d__;
			<PrepareTracksAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PrepareTracksAsync>d__.<>4__this = this;
			<PrepareTracksAsync>d__.ownerPbDataId = ownerPbDataId;
			<PrepareTracksAsync>d__.splineEntityIds = splineEntityIds;
			<PrepareTracksAsync>d__.<>1__state = -1;
			<PrepareTracksAsync>d__.<>t__builder.Start<PathDrivenActorSpawnerComponent.<PrepareTracksAsync>d__25>(ref <PrepareTracksAsync>d__);
			return <PrepareTracksAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060301A7 RID: 197031 RVA: 0x00BAB5A3 File Offset: 0x00BA97A3
		[NullableContext(1)]
		private void RequestStop(string reason)
		{
			if (!this.DesiredRunning && this.State == EPathDrivenActorSpawnerState.Idle && this.TrackRuntimeSet == null && this.RuntimeController == null)
			{
				return;
			}
			this.StopAndClear(reason);
		}

		// Token: 0x060301A8 RID: 197032 RVA: 0x00BAB5CD File Offset: 0x00BA97CD
		[NullableContext(1)]
		private void StopAndClear(string reason)
		{
			this.DesiredRunning = false;
			this.EnterState(EPathDrivenActorSpawnerState.Idle);
			PathDrivenActorRuntimeController runtimeController = this.RuntimeController;
			if (runtimeController != null)
			{
				runtimeController.ClearAllActors(reason);
			}
			this.RuntimeController = null;
			this.TrackRuntimeBuilder.CancelBuild();
			this.ReleaseTrackSet();
		}

		// Token: 0x060301A9 RID: 197033 RVA: 0x00BAB607 File Offset: 0x00BA9807
		private void EnterState(EPathDrivenActorSpawnerState state)
		{
			this.State = state;
			if (state == EPathDrivenActorSpawnerState.Running)
			{
				this.TryRegisterOwnerAssistantActor();
				return;
			}
			this.TryUnregisterOwnerAssistantActor();
		}

		// Token: 0x060301AA RID: 197034 RVA: 0x00BAB621 File Offset: 0x00BA9821
		private void ReleaseTrackSet()
		{
			PathDrivenTrackRuntimeSet trackRuntimeSet = this.TrackRuntimeSet;
			if (trackRuntimeSet != null)
			{
				trackRuntimeSet.Release();
			}
			this.TrackRuntimeSet = null;
		}

		// Token: 0x060301AB RID: 197035 RVA: 0x00BAB63C File Offset: 0x00BA983C
		private void TryCreateRuntimeController()
		{
			if (this.RuntimeController == null)
			{
				UClass actorClass = this.ActorClass;
				if (actorClass != null && actorClass.IsValid() && this.SpawnRule != null && this.TrackRuntimeSet != null && this.TrackRuntimeSet.TrackList.Count > 0)
				{
					this.RuntimeController = new PathDrivenActorRuntimeController(base.Entity, this.GetOwnerPbDataId(), this.ActorClass, this.SpawnRule, this.TrackRuntimeSet.TrackList);
					return;
				}
			}
		}

		// Token: 0x060301AC RID: 197036 RVA: 0x00BAB6BC File Offset: 0x00BA98BC
		private void TryRegisterOwnerAssistantActor()
		{
			if (this.IsOwnerAssistantActorRegistered)
			{
				return;
			}
			AActor actorByEntity = ControllerBase<CharacterController>.Instance.GetActorByEntity(base.Entity);
			if (actorByEntity == null || !actorByEntity.IsValid())
			{
				return;
			}
			UKuroGameBudgetAllocatorCSharpInterface.AddAssistantActor(actorByEntity);
			this.IsOwnerAssistantActorRegistered = true;
		}

		// Token: 0x060301AD RID: 197037 RVA: 0x00BAB704 File Offset: 0x00BA9904
		private void TryUnregisterOwnerAssistantActor()
		{
			if (!this.IsOwnerAssistantActorRegistered)
			{
				return;
			}
			AActor actorByEntity = ControllerBase<CharacterController>.Instance.GetActorByEntity(base.Entity);
			if (actorByEntity != null && actorByEntity.IsValid())
			{
				UKuroGameBudgetAllocatorCSharpInterface.RemoveAssistantActor(actorByEntity);
			}
			this.IsOwnerAssistantActorRegistered = false;
		}

		// Token: 0x060301AE RID: 197038 RVA: 0x00BAB744 File Offset: 0x00BA9944
		private string NormalizeActorClassPath(string actorBlueprintPath)
		{
			if (string.IsNullOrEmpty(actorBlueprintPath))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[PathDrivenActorSpawnerComponent] ActorBlueprintPath为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.GetOwnerPbDataId());
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			string text = actorBlueprintPath;
			if (!text.EndsWith("_C"))
			{
				text += "_C";
			}
			return text;
		}

		// Token: 0x060301AF RID: 197039 RVA: 0x00BAB7AC File Offset: 0x00BA99AC
		private unsafe void TryLoadActorClassAsync()
		{
			PathDrivenActorSpawnerComponent.<>c__DisplayClass34_0 CS$<>8__locals1 = new PathDrivenActorSpawnerComponent.<>c__DisplayClass34_0();
			CS$<>8__locals1.<>4__this = this;
			UClass actorClass = this.ActorClass;
			if ((actorClass != null && actorClass.IsValid()) || string.IsNullOrEmpty(this.ActorClassPath) || this.ActorClassLoadHandle != -1)
			{
				return;
			}
			PathDrivenActorSpawnerComponent.<>c__DisplayClass34_0 CS$<>8__locals2 = CS$<>8__locals1;
			int num = this.ActorClassLoadToken + 1;
			this.ActorClassLoadToken = num;
			CS$<>8__locals2.loadToken = num;
			int num2 = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(this.ActorClassPath, delegate([Nullable(2)] UClass result, string _)
			{
				if (CS$<>8__locals1.loadToken != CS$<>8__locals1.<>4__this.ActorClassLoadToken)
				{
					return;
				}
				CS$<>8__locals1.<>4__this.ActorClassLoadHandle = -1;
				Entity entity = CS$<>8__locals1.<>4__this.Entity;
				if (entity == null || !entity.Valid)
				{
					return;
				}
				if (result == null || !result.IsValid())
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.PathDrivenActor;
					ELogAuthor author2 = ELogAuthor.WRY;
					string message2 = "[PathDrivenActorSpawnerComponent] Actor类异步加载失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", CS$<>8__locals1.<>4__this.GetOwnerPbDataId());
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item2 = "ActorBlueprintPath";
					IIntervalSplineSpawn spawnRule2 = CS$<>8__locals1.<>4__this.SpawnRule;
					ptr2 = new ValueTuple<string, object>(item2, (spawnRule2 != null) ? spawnRule2.ActorBlueprintPath : null);
					instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					CS$<>8__locals1.<>4__this.DesiredRunning = false;
					CS$<>8__locals1.<>4__this.EnterState(EPathDrivenActorSpawnerState.Idle);
					return;
				}
				if (!(UKuroStaticLibrary.GetDefaultObject(result.ClassStackOnlyPtr) is AActor))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.PathDrivenActor;
					ELogAuthor author3 = ELogAuthor.WRY;
					string message3 = "[PathDrivenActorSpawnerComponent] 异步加载结果不是Actor类";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("PbDataId", CS$<>8__locals1.<>4__this.GetOwnerPbDataId());
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
					string item3 = "ActorBlueprintPath";
					IIntervalSplineSpawn spawnRule3 = CS$<>8__locals1.<>4__this.SpawnRule;
					ptr3 = new ValueTuple<string, object>(item3, (spawnRule3 != null) ? spawnRule3.ActorBlueprintPath : null);
					instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
					CS$<>8__locals1.<>4__this.DesiredRunning = false;
					CS$<>8__locals1.<>4__this.EnterState(EPathDrivenActorSpawnerState.Idle);
					return;
				}
				CS$<>8__locals1.<>4__this.ActorClass = result;
				if (CS$<>8__locals1.<>4__this.DesiredRunning)
				{
					SceneItemStateComponent stateComp = CS$<>8__locals1.<>4__this.StateComp;
					if (stateComp != null && stateComp.IsInState(SceneItemStateComponent.ESceneItemState.Active))
					{
						CS$<>8__locals1.<>4__this.TryStartRunning();
					}
				}
			}, 100, "js_undefined");
			if (num2 == -1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PathDrivenActor;
				ELogAuthor author = ELogAuthor.WRY;
				string message = "[PathDrivenActorSpawnerComponent] Actor类异步加载请求失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.GetOwnerPbDataId());
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "ActorBlueprintPath";
				IIntervalSplineSpawn spawnRule = this.SpawnRule;
				ptr = new ValueTuple<string, object>(item, (spawnRule != null) ? spawnRule.ActorBlueprintPath : null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.DesiredRunning = false;
				this.EnterState(EPathDrivenActorSpawnerState.Idle);
				return;
			}
			this.ActorClassLoadHandle = num2;
		}

		// Token: 0x060301B0 RID: 197040 RVA: 0x00BAB8BA File Offset: 0x00BA9ABA
		private void CancelActorClassLoad()
		{
			if (this.ActorClassLoadHandle != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.ActorClassLoadHandle);
				this.ActorClassLoadHandle = -1;
			}
			this.ActorClassLoadToken++;
			this.DesiredRunning = false;
		}

		// Token: 0x060301B1 RID: 197041 RVA: 0x00BAB8F4 File Offset: 0x00BA9AF4
		private int? GetOwnerPbDataId()
		{
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				return null;
			}
			return new int?(component.GetPbDataId());
		}

		// Token: 0x060301B2 RID: 197042 RVA: 0x00BAB924 File Offset: 0x00BA9B24
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			PathDrivenActorSpawnerComponent pathDrivenActorSpawnerComponent = (PathDrivenActorSpawnerComponent)componentTemplate;
			if (base.CanResetComponentProperty("StateComp"))
			{
				if (pathDrivenActorSpawnerComponent.StateComp == null)
				{
					this.StateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemStateComponent>(this.StateComp), "StateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("Config"))
			{
				if (pathDrivenActorSpawnerComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PathDrivenActorSpawnerComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SpawnRule"))
			{
				if (pathDrivenActorSpawnerComponent.SpawnRule == null)
				{
					this.SpawnRule = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IIntervalSplineSpawn>(this.SpawnRule), "SpawnRule"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorClassPath"))
			{
				this.ActorClassPath = pathDrivenActorSpawnerComponent.ActorClassPath;
			}
			if (base.CanResetComponentProperty("ActorClass"))
			{
				if (pathDrivenActorSpawnerComponent.ActorClass == null)
				{
					this.ActorClass = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UClass>(this.ActorClass), "ActorClass"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorClassLoadHandle"))
			{
				this.ActorClassLoadHandle = pathDrivenActorSpawnerComponent.ActorClassLoadHandle;
			}
			if (base.CanResetComponentProperty("ActorClassLoadToken"))
			{
				this.ActorClassLoadToken = pathDrivenActorSpawnerComponent.ActorClassLoadToken;
			}
			if (base.CanResetComponentProperty("DesiredRunning"))
			{
				this.DesiredRunning = pathDrivenActorSpawnerComponent.DesiredRunning;
			}
			if (base.CanResetComponentProperty("State"))
			{
				this.State = pathDrivenActorSpawnerComponent.State;
			}
			if (base.CanResetComponentProperty("IsOwnerAssistantActorRegistered"))
			{
				this.IsOwnerAssistantActorRegistered = pathDrivenActorSpawnerComponent.IsOwnerAssistantActorRegistered;
			}
			if (base.CanResetComponentProperty("TrackRuntimeSet"))
			{
				if (pathDrivenActorSpawnerComponent.TrackRuntimeSet == null)
				{
					this.TrackRuntimeSet = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PathDrivenTrackRuntimeSet>(this.TrackRuntimeSet), "TrackRuntimeSet"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TrackRuntimeBuilder") && pathDrivenActorSpawnerComponent.TrackRuntimeBuilder != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PathDrivenTrackRuntimeBuilder>(this.TrackRuntimeBuilder), "TrackRuntimeBuilder"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RuntimeController"))
			{
				if (pathDrivenActorSpawnerComponent.RuntimeController == null)
				{
					this.RuntimeController = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PathDrivenActorRuntimeController>(this.RuntimeController), "RuntimeController"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B9E6 RID: 113126
		private SceneItemStateComponent StateComp;

		// Token: 0x0401B9E7 RID: 113127
		private PathDrivenActorSpawnerComponent Config;

		// Token: 0x0401B9E8 RID: 113128
		private IIntervalSplineSpawn SpawnRule;

		// Token: 0x0401B9E9 RID: 113129
		private string ActorClassPath;

		// Token: 0x0401B9EA RID: 113130
		private UClass ActorClass;

		// Token: 0x0401B9EB RID: 113131
		private int ActorClassLoadHandle = -1;

		// Token: 0x0401B9EC RID: 113132
		private int ActorClassLoadToken;

		// Token: 0x0401B9ED RID: 113133
		private bool DesiredRunning;

		// Token: 0x0401B9EE RID: 113134
		private EPathDrivenActorSpawnerState State;

		// Token: 0x0401B9EF RID: 113135
		private bool IsOwnerAssistantActorRegistered;

		// Token: 0x0401B9F0 RID: 113136
		private PathDrivenTrackRuntimeSet TrackRuntimeSet;

		// Token: 0x0401B9F1 RID: 113137
		[Nullable(1)]
		private readonly PathDrivenTrackRuntimeBuilder TrackRuntimeBuilder = new PathDrivenTrackRuntimeBuilder();

		// Token: 0x0401B9F2 RID: 113138
		private PathDrivenActorRuntimeController RuntimeController;
	}
}
