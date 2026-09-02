using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using CSharpScript.Game.Module.Movement.Model;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004888 RID: 18568
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemMoveComponent : EntityComponent
	{
		// Token: 0x1700828C RID: 33420
		// (get) Token: 0x0603050E RID: 197902 RVA: 0x00BC7DF3 File Offset: 0x00BC5FF3
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public new static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(SceneItemActorComponent),
					typeof(CreatureDataComponent)
				};
			}
		}

		// Token: 0x1700828D RID: 33421
		// (get) Token: 0x0603050F RID: 197903 RVA: 0x00BC7E15 File Offset: 0x00BC6015
		public bool IsMovingPrepareCompleted
		{
			get
			{
				return this.IsMovingPrepareCompletedInternal;
			}
		}

		// Token: 0x1700828E RID: 33422
		// (get) Token: 0x06030510 RID: 197904 RVA: 0x00BC7E20 File Offset: 0x00BC6020
		public bool IsMoving
		{
			get
			{
				if (Singleton<Info>.Instance.EnableForceTick)
				{
					return this.MoveTargetList.Count > 0 || this.CurState == SceneItemMoveComponent.ERunningState.RUN;
				}
				if (!this.IsMovingPrepareCompleted)
				{
					return this.MoveTargetList.Count > 0;
				}
				return this.MoveComponent.IsMoving(false);
			}
		}

		// Token: 0x1700828F RID: 33423
		// (get) Token: 0x06030511 RID: 197905 RVA: 0x00BC7E76 File Offset: 0x00BC6076
		// (set) Token: 0x06030512 RID: 197906 RVA: 0x00BC7E7E File Offset: 0x00BC607E
		public bool ForceSyncing
		{
			get
			{
				return this.ForceSyncingInternal;
			}
			set
			{
				this.ForceSyncingInternal = value;
				if (this.ForceSyncingInternal)
				{
					SceneItemMovementSyncComponent syncComp = this.SyncComp;
					if (syncComp == null)
					{
						return;
					}
					syncComp.SetEnableMovementSync(true, "SceneItemMoveComponent ForceSyncing");
				}
			}
		}

		// Token: 0x06030513 RID: 197907 RVA: 0x00BC7EA5 File Offset: 0x00BC60A5
		public bool IsSplineMoving()
		{
			if (!this.IsMovingPrepareCompleted)
			{
				return false;
			}
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			return moveComponent != null && moveComponent.IsValid() && this.MoveComponent.GetSplineRunState() > ESplineRunState.None;
		}

		// Token: 0x06030514 RID: 197908 RVA: 0x00BC7ED5 File Offset: 0x00BC60D5
		public float GetDistanceAloneSpline()
		{
			if (!this.IsMovingPrepareCompleted)
			{
				return 0f;
			}
			return this.MoveComponent.GetDistanceAlongSpline();
		}

		// Token: 0x06030515 RID: 197909 RVA: 0x00BC7EF0 File Offset: 0x00BC60F0
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			return true;
		}

		// Token: 0x06030516 RID: 197910 RVA: 0x00BC7F04 File Offset: 0x00BC6104
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			this.SyncComp = base.Entity.GetComponent<SceneItemMovementSyncComponent>();
			this.PropertyComp = base.Entity.GetComponent<SceneItemPropertyComponent>();
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.UeTickComponent = base.Entity.GetComponent<UeSceneItemMoveTickManagerComponent>();
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.SetEnableMovementSync(false, "SceneItemMoveComponent OnStart");
			}
			if (this.CreatureDataComp == null)
			{
				return true;
			}
			if (this.CreatureDataComp.GetPbEntityInitData() == null)
			{
				return true;
			}
			if (base.Entity.GameBudgetConfig.GroupName == FNameUtil.GetDynamicFName("MoveSceneItemEntity"))
			{
				this.NeedTickOutside = true;
			}
			if (!Singleton<Info>.Instance.EnableForceTick)
			{
				this.MoveComponent = (this.ActorComp.Owner.GetComponentByClass(UKuroSceneItemMoveComponent.StaticClass()) as UKuroSceneItemMoveComponent);
				UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
				if (moveComponent == null || !moveComponent.IsValid())
				{
					AActor owner = this.ActorComp.Owner;
					TSubclassOf<UActorComponent> @class = UKuroSceneItemMoveComponent.StaticClass();
					bool bManualAttachment = false;
					FTransform ftransform = new FTransform();
					this.MoveComponent = (owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroSceneItemMoveComponent);
				}
				this.MoveComponent.Kuro_SetGravityDirect(this.ActorComp.ActorGravityDirectProxy.ToUeVectorOld());
				this.MoveComponent.SetTickingMoveEnable(false);
				this.AddUeArrivePointCallback(new Action<int>(this.OnUeArrivePointCallback));
				this.AddUeMoveStopCallback(new Action(this.OnUeMoveStopCallback));
				if (this.NeedTickOutside)
				{
					this.MoveComponent.SetKuroOnlyTickOutside(true);
				}
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(base.Entity.Id);
				if (entityById != null && !Singleton<EventSystem>.Instance.HasWithTarget(entityById, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveSelfEntity)))
				{
					Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey<ERemoveEntityType, EntityHandle>(this, entityById, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveSelfEntity));
				}
				if (ModelBase<AvoidanceModel>.Instance.UseRVOAvoidance)
				{
					UKuroSceneItemMoveComponent moveComponent2 = this.MoveComponent;
					FNavAvoidanceMask fnavAvoidanceMask = ModelBase<AvoidanceModel>.Instance.SceneItemAvoidanceGroupMask;
					moveComponent2.SetAvoidanceGroupMask(fnavAvoidanceMask);
					UKuroSceneItemMoveComponent moveComponent3 = this.MoveComponent;
					fnavAvoidanceMask = ModelBase<AvoidanceModel>.Instance.SceneItemGroupsToAvoidMask;
					moveComponent3.SetGroupsToAvoidMask(fnavAvoidanceMask);
					this.MoveComponent.AvoidanceRadius = ModelBase<AvoidanceModel>.Instance.SceneItemAvoidanceRadius;
					this.MoveComponent.SetAvoidanceEnabled(true);
				}
			}
			return true;
		}

		// Token: 0x06030517 RID: 197911 RVA: 0x00BC816C File Offset: 0x00BC636C
		protected override bool OnEnd()
		{
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent != null && moveComponent.IsValid())
			{
				this.RemoveUeArrivePointCallback(new Action<int>(this.OnUeArrivePointCallback));
				this.RemoveUeMoveStopCallback(new Action(this.OnUeMoveStopCallback));
			}
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			return true;
		}

		// Token: 0x06030518 RID: 197912 RVA: 0x00BC81C0 File Offset: 0x00BC63C0
		protected override void OnActivate()
		{
			if (!Singleton<Info>.Instance.EnableForceTick && this.MoveTargetList.Count > 0)
			{
				foreach (SceneItemMoveComponent.MoveTarget moveTarget in this.MoveTargetList)
				{
					this.MoveComponent.AddMoveTarget(new FVectorDouble(moveTarget.TargetPosData.X, moveTarget.TargetPosData.Y, moveTarget.TargetPosData.Z), moveTarget.MoveTime, moveTarget.StayTime, -1f, -1f);
				}
				this.MoveMode = SceneItemMoveComponent.EMoveMode.Simple;
				this.MoveTargetList.Clear();
				this.MoveComponent.SetTickingMoveEnable(true);
				this.PropertyComp.IsMoving = true;
			}
			this.IsMovingPrepareCompletedInternal = true;
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			int? num = (creatureDataComp != null) ? new int?(creatureDataComp.PbMoveSplineId) : null;
			if (num != null && num.GetValueOrDefault() != 0)
			{
				this.OnRecvSyncSplineMoving(this.CreatureDataComp.PbMoveSplineId, this.CreatureDataComp.PbMoveSplineConfig, this.CreatureDataComp.PbMoveSplineSceneItemRuntimeData);
			}
		}

		// Token: 0x06030519 RID: 197913 RVA: 0x00BC8300 File Offset: 0x00BC6500
		private bool CheckReachTarget()
		{
			return global::Vector.DistSquared(this.StartLocation, this.CurLocation) >= (double)this.MaxDist;
		}

		// Token: 0x0603051A RID: 197914 RVA: 0x00BC8320 File Offset: 0x00BC6520
		protected override void OnTick(float delta)
		{
			if (this.NeedTickOutside)
			{
				UeSceneItemMoveTickManagerComponent ueTickComponent = this.UeTickComponent;
				if (ueTickComponent != null)
				{
					ueTickComponent.TickMovement(delta, false);
				}
			}
			if (this.PropertyComp.IsMoving)
			{
				if (!this.IsMoving)
				{
					this.PropertyComp.IsMoving = false;
				}
				else if (this.MoveComponent.GetSimpleRunState() == ESimpleRunState.Wait)
				{
					this.PropertyComp.IsMoving = false;
				}
			}
			else if (this.IsMoving && this.MoveComponent.GetSimpleRunState() == ESimpleRunState.Run)
			{
				this.PropertyComp.IsMoving = true;
			}
			if (this.IsSyncing && !this.IsMoving && !this.ForceSyncing)
			{
				this.IsSyncing = false;
				SceneItemMovementSyncComponent syncComp = this.SyncComp;
				if (syncComp != null && syncComp.GetEnableMovementSync())
				{
					SceneItemMovementSyncComponent syncComp2 = this.SyncComp;
					if (syncComp2 == null)
					{
						return;
					}
					syncComp2.SetEnableMovementSync(false, "SceneItemMoveComponent MoveStop");
				}
			}
		}

		// Token: 0x0603051B RID: 197915 RVA: 0x00BC83F4 File Offset: 0x00BC65F4
		protected override void OnForceTick(float delta)
		{
			base.OnTick(delta);
			if (this.CurState == SceneItemMoveComponent.ERunningState.RUN)
			{
				this.Velocity.Addition(this.ActorComp.ActorLocationProxy, this.CurLocation);
				if (this.CheckReachTarget())
				{
					this.ActorComp.SetActorLocation(this.TargetLocation.ToUeVector(false), "unknown", true);
					this.CurState = SceneItemMoveComponent.ERunningState.STOP;
					return;
				}
				this.ActorComp.SetActorLocation(this.CurLocation.ToUeVector(false), "unknown", true);
				return;
			}
			else
			{
				if (this.MoveTargetList == null || this.MoveTargetList.Count == 0)
				{
					return;
				}
				SceneItemMoveComponent.MoveTarget moveTarget = this.MoveTargetList[0];
				this.MoveTargetList.RemoveAt(0);
				this.TargetLocation = global::Vector.Create(moveTarget.TargetPosData.X, moveTarget.TargetPosData.Y, moveTarget.TargetPosData.Z);
				if ((double)moveTarget.MoveTime <= 0.0001)
				{
					this.ActorComp.SetActorLocation(this.TargetLocation.ToUeVector(false), "unknown", true);
					return;
				}
				this.StartLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
				this.MaxDist = (float)global::Vector.DistSquared(this.StartLocation, this.TargetLocation);
				global::Vector vector = global::Vector.Create();
				this.TargetLocation.Subtraction(this.StartLocation, vector);
				vector.Division((double)(moveTarget.MoveTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond / delta), vector);
				this.Velocity = vector;
				this.CurState = SceneItemMoveComponent.ERunningState.RUN;
				return;
			}
		}

		// Token: 0x0603051C RID: 197916 RVA: 0x00BC8578 File Offset: 0x00BC6778
		private unsafe void OnRemoveSelfEntity(ERemoveEntityType removeType, EntityHandle handle)
		{
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent != null && moveComponent.IsValid() && this.MoveComponent.IsMoving(true))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "当前SceneItem移动时被删除，保底停止移动";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.StopMove(true, true);
			}
		}

		// Token: 0x0603051D RID: 197917 RVA: 0x00BC863C File Offset: 0x00BC683C
		public void AddSimpleRotation(AActor actor, global::Rotator beginRotator, global::Rotator endRotator, float time)
		{
			this.MoveComponent.InitRotationData(actor, false);
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			FRotator frotator = beginRotator.ToUeRotator();
			FRotator frotator2 = endRotator.ToUeRotator();
			moveComponent.AddRotationStep(frotator, frotator2, time, 0f, null);
			this.MoveComponent.StartRotate();
		}

		// Token: 0x0603051E RID: 197918 RVA: 0x00BC868C File Offset: 0x00BC688C
		private unsafe void AddMoveTargetInternal(SceneItemMoveComponent.MoveTarget target)
		{
			if (Singleton<Info>.Instance.EnableForceTick)
			{
				this.MoveTargetList.Add(target);
			}
			else if (!this.IsMovingPrepareCompleted)
			{
				this.MoveTargetList.Add(target);
			}
			else
			{
				global::Vector vector = global::Vector.Create(target.TargetPosData.X, target.TargetPosData.Y, target.TargetPosData.Z);
				this.MoveComponent.AddMoveTarget(vector.ToUeVector(false), target.MoveTime, target.StayTime, target.MaxSpeed, target.Acceleration);
				this.MoveMode = SceneItemMoveComponent.EMoveMode.Simple;
				this.MoveComponent.SetTickingMoveEnable(true);
				double num = global::Vector.Dist(vector, this.ActorComp.ActorLocationProxy);
				if (this.MoveComponent.GetSimpleRunState() == ESimpleRunState.Stop && num > 100.0)
				{
					this.PropertyComp.IsMoving = true;
				}
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CH;
			string message = "添加路径点";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("moveTargetX", target.TargetPosData.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("moveTargetY", target.TargetPosData.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("moveTargetZ", target.TargetPosData.Z);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Time", target.MoveTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x0603051F RID: 197919 RVA: 0x00BC8824 File Offset: 0x00BC6A24
		public void AddMoveTarget(object targetData)
		{
			if (this.InPotral)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CH;
				string message = "当前SceneItem正在巡逻中,不可再添加目标点";
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			SceneItemMoveComponent.MoveTarget moveTarget = targetData as SceneItemMoveComponent.MoveTarget;
			SceneItemMoveComponent.MoveTarget target;
			if (moveTarget != null)
			{
				target = moveTarget;
			}
			else
			{
				IMoveToPoint moveToPoint = targetData as IMoveToPoint;
				ISceneItemMoveMotionType moveMotion = moveToPoint.MoveMotion;
				float num;
				if (moveMotion == null || moveMotion.Type != EMoveMotion.VariableMotion)
				{
					IUniformMotion uniformMotion = moveToPoint.MoveMotion as IUniformMotion;
					num = ((uniformMotion != null) ? uniformMotion.Time : 0f);
				}
				else
				{
					num = -1f;
				}
				float moveTime = num;
				target = new SceneItemMoveComponent.MoveTarget(moveToPoint.Point, moveTime, 0f, -1f, -1f);
			}
			this.AddMoveTargetInternal(target);
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.RequestMoveToTarget(target);
			}
		}

		// Token: 0x06030520 RID: 197920 RVA: 0x00BC8914 File Offset: 0x00BC6B14
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"HasTarget",
			"Target",
			"Velocity"
		})]
		public unsafe ValueTuple<bool, FVectorDouble, FVectorDouble> GetNextTarget()
		{
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent == null || !moveComponent.IsValid())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.CH;
				string message = "SceneItemMoveComponent不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsEntityInit", base.Entity.IsInit);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return new ValueTuple<bool, FVectorDouble, FVectorDouble>(false, new FVectorDouble(), new FVectorDouble());
			}
			FVectorDouble item2 = new FVectorDouble();
			FVectorDouble item3 = new FVectorDouble();
			return new ValueTuple<bool, FVectorDouble, FVectorDouble>(this.MoveComponent.GetNextMoveTarget(ref item2, ref item3), item2, item3);
		}

		// Token: 0x06030521 RID: 197921 RVA: 0x00BC89F8 File Offset: 0x00BC6BF8
		public void RequestMoveToTarget(SceneItemMoveComponent.MoveTarget target)
		{
			SceneItemMoveTargetRequest sceneItemMoveTargetRequest = SceneItemMoveTargetRequest.Create();
			sceneItemMoveTargetRequest.MoveInfo = SceneItemMoveTargetInfo.Create();
			sceneItemMoveTargetRequest.MoveInfo.EntityId = this.ActorComp.CreatureData.GetCreatureDataId();
			sceneItemMoveTargetRequest.MoveInfo.Location = new Aki.Protocol.Vector
			{
				X = (float)target.TargetPosData.X,
				Y = (float)target.TargetPosData.Y,
				Z = (float)target.TargetPosData.Z
			};
			sceneItemMoveTargetRequest.MoveInfo.MoveTime = target.MoveTime;
			sceneItemMoveTargetRequest.MoveInfo.StayTime = target.StayTime;
			sceneItemMoveTargetRequest.MoveInfo.MaxSpeed = target.MaxSpeed;
			sceneItemMoveTargetRequest.MoveInfo.Acceleration = target.Acceleration;
			Singleton<Net>.Instance.Call<SceneItemMoveTargetResponse>(ERequestMessageId.SceneItemMoveTargetRequest, sceneItemMoveTargetRequest, null, 0);
		}

		// Token: 0x06030522 RID: 197922 RVA: 0x00BC8AD0 File Offset: 0x00BC6CD0
		public void HandleMoveToTarget(SceneItemMoveTargetNotify notify)
		{
			SceneItemMoveComponent.MoveTarget target = new SceneItemMoveComponent.MoveTarget(new global::Vector
			{
				X = (double)notify.MoveInfo.Location.X,
				Y = (double)notify.MoveInfo.Location.Y,
				Z = (double)notify.MoveInfo.Location.Z
			}, notify.MoveInfo.MoveTime, notify.MoveInfo.StayTime, notify.MoveInfo.MaxSpeed, notify.MoveInfo.Acceleration);
			this.AddMoveTargetInternal(target);
		}

		// Token: 0x06030523 RID: 197923 RVA: 0x00BC8B60 File Offset: 0x00BC6D60
		public void StartSplineMoveTask(ISceneItemSplineMoveTaskParam param)
		{
			if (this.GetCurSplineMoveTask() != null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "SceneItemMoveComponent 样条移动任务未结束时开始新任务，清除旧任务";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ControllerBase<SplineMoveTaskController>.Instance.EndEntityTasks((long)base.Entity.Id);
			}
			SceneItemSplineMoveTask.Create(ModelBase<CreatureModel>.Instance.GetEntityById(base.Entity.Id), param).StartTask();
		}

		// Token: 0x06030524 RID: 197924 RVA: 0x00BC8BE4 File Offset: 0x00BC6DE4
		public void SwitchSplineMoveTask(ISceneItemSplineMoveTaskParam newParam)
		{
			SceneItemSplineMoveTask curSplineMoveTask = this.GetCurSplineMoveTask();
			bool flag = curSplineMoveTask != null && curSplineMoveTask.IsEnableSplineMoveSync;
			bool flag2 = newParam != null && newParam.EnableSplineMoveSync;
			if (flag && flag2)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemMoveComponent.SwitchSplineMoveTask] 切换样条移动,新旧task都需要走样条协议同步，将使用Switch协议切换样条移动";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				curSplineMoveTask.MarkSuppressSplineMoveSyncOnEnd();
				curSplineMoveTask.EndTask(false);
				this.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
				{
					SplineId = newParam.SplineId,
					SplineMoveConfig = newParam.SplineMoveConfig,
					EnableSplineMoveSync = newParam.EnableSplineMoveSync,
					EnableMovementSync = newParam.EnableMovementSync,
					NeedMoveToStartPoint = newParam.NeedMoveToStartPoint,
					SplineMoveRuntimeData = newParam.SplineMoveRuntimeData,
					Callback = newParam.Callback,
					Context = newParam.Context,
					UseSplineMoveSyncSwitchOnStart = new bool?(true)
				});
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.SceneItem;
			ELogAuthor author2 = ELogAuthor.ZYL;
			string message2 = "[SceneItemMoveComponent.SwitchSplineMoveTask] 切换样条移动,新旧task至少有一个不走样条协议同步，将使用Stop+Start的方式切换样条移动";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			if (curSplineMoveTask != null)
			{
				curSplineMoveTask.EndTask(false);
			}
			this.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
			{
				SplineId = newParam.SplineId,
				SplineMoveConfig = newParam.SplineMoveConfig,
				EnableSplineMoveSync = newParam.EnableSplineMoveSync,
				EnableMovementSync = newParam.EnableMovementSync,
				NeedMoveToStartPoint = newParam.NeedMoveToStartPoint,
				SplineMoveRuntimeData = newParam.SplineMoveRuntimeData,
				Callback = newParam.Callback,
				Context = newParam.Context,
				UseSplineMoveSyncSwitchOnStart = new bool?(false)
			});
		}

		// Token: 0x06030525 RID: 197925 RVA: 0x00BC8D8C File Offset: 0x00BC6F8C
		[NullableContext(2)]
		public SceneItemSplineMoveTask GetCurSplineMoveTask()
		{
			SplineMoveTaskBase entityCurSplineMoveTask = ControllerBase<SplineMoveTaskController>.Instance.GetEntityCurSplineMoveTask((long)base.Entity.Id);
			if (entityCurSplineMoveTask == null)
			{
				return null;
			}
			return entityCurSplineMoveTask as SceneItemSplineMoveTask;
		}

		// Token: 0x06030526 RID: 197926 RVA: 0x00BC8DBC File Offset: 0x00BC6FBC
		public unsafe bool StartSplineMoveAtConstantTimeImplement(SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam param, [Nullable(2)] Action potralEndCallback = null, bool enableMovementSync = true)
		{
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			if (creatureDataComp != null && creatureDataComp.GetRemoveState())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "SceneItemMoveComponent 样条移动(ConstantTime)开始失败，Entity已删除";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataComp.GetPbDataId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (!this.MoveComponent.StartMoveWithSplineAtConstantTime(param.Spline, param.IsRepeat, param.IsCycle, param.IsKeepLookAt, param.TimeSec, param.TimeDisCurve, param.StartTimeOffset, param.StartDis, param.EndDis))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "SceneItemMoveComponent 样条移动(ConstantTime)开始失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			this.InPotral = true;
			this.IsSyncing = enableMovementSync;
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.SetEnableMovementSync(enableMovementSync, "SceneItemMoveComponent StartPatrolAtConstantTime");
			}
			this.MoveMode = SceneItemMoveComponent.EMoveMode.Spline;
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.移动机关.样条移动.移动中"]));
			}
			if (potralEndCallback != null)
			{
				Action callback = null;
				callback = delegate()
				{
					this.RemoveStopMoveCallback(callback);
					potralEndCallback();
				};
				this.AddStopMoveCallback(callback);
			}
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.SceneItem;
			ELogAuthor author3 = ELogAuthor.ZYL;
			string message3 = "SceneItemMoveComponent 样条移动(ConstantTime)开始";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
			ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveStarted, base.Entity);
			return true;
		}

		// Token: 0x06030527 RID: 197927 RVA: 0x00BC9054 File Offset: 0x00BC7254
		public unsafe bool StartSplineMoveAtDynamicSpeedImplement(SceneItemMoveComponent.SceneItemSplineMoveAtDynamicSpeedParam param, [Nullable(2)] Action potralEndCallback = null, bool enableMovementSync = true)
		{
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			if (creatureDataComp != null && creatureDataComp.GetRemoveState())
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "SceneItemMoveComponent 样条移动(DynamicSpeed)开始失败，Entity已删除";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.CreatureDataComp.GetPbDataId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (!this.MoveComponent.StartMoveWithSplineAtDynamicSpeed(param.Spline, param.MaxMoveTimes, param.IsCycle, param.IsKeepLookAt, param.InitSpeed, param.Acceleration, param.TargetSpeed, param.StartDis, param.EndDis))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "SceneItemMoveComponent 样条移动(DynamicSpeed)开始失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			this.InPotral = true;
			this.IsSyncing = enableMovementSync;
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.SetEnableMovementSync(enableMovementSync, "SceneItemMoveComponent StartPatrolAtDynamicSpeed");
			}
			this.MoveMode = SceneItemMoveComponent.EMoveMode.Spline;
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.移动机关.样条移动.移动中"]));
			}
			if (potralEndCallback != null)
			{
				Action callback = null;
				callback = delegate()
				{
					this.RemoveStopMoveCallback(callback);
					potralEndCallback();
				};
				this.AddStopMoveCallback(callback);
			}
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.SceneItem;
			ELogAuthor author3 = ELogAuthor.ZYL;
			string message3 = "SceneItemMoveComponent 样条移动(DynamicSpeed)开始";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
			string item2 = "PbDataId";
			CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
			ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveStarted, base.Entity);
			return true;
		}

		// Token: 0x06030528 RID: 197928 RVA: 0x00BC92EC File Offset: 0x00BC74EC
		public unsafe bool UpdatePatrolAtDynamicSpeedEditableParam(SceneItemMoveComponent.SceneItemSplineMoveAtDynamicSpeedEditableParam param)
		{
			if (!this.IsSplineMoving() || this.MoveComponent == null)
			{
				return false;
			}
			FSplineMoveDynamicSpeedData dynamicSpeedData = this.MoveComponent.SplineMoveData.DynamicSpeedData;
			float currentSpeed = param.CurrentSpeed ?? dynamicSpeedData.CurrentSpeed;
			float acceleration = param.Acceleration ?? dynamicSpeedData.Acceleration;
			float targetSpeed = param.TargetSpeed ?? dynamicSpeedData.TargetSpeed;
			bool flag = this.MoveComponent.UpdateDynamicSpeedSplineMoveParams(currentSpeed, acceleration, targetSpeed);
			if (!flag)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "SceneItemMoveComponent 更新样条移动动态参数失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SCENEITEM_MOVE_DEBUG");
			return flag;
		}

		// Token: 0x06030529 RID: 197929 RVA: 0x00BC9430 File Offset: 0x00BC7630
		public bool UpdateSplineMoveDistance(float newDisAlongPath)
		{
			return this.IsSplineMoving() && this.MoveComponent != null && this.MoveComponent.UpdateSplineMoveDistance(newDisAlongPath);
		}

		// Token: 0x0603052A RID: 197930 RVA: 0x00BC9450 File Offset: 0x00BC7650
		public bool UpdateSplineMoveDistanceByPos(global::Vector newPos)
		{
			return this.IsSplineMoving() && this.MoveComponent != null && this.MoveComponent.UpdateSplineMoveDistanceByPosition(newPos.ToUeVector(false));
		}

		// Token: 0x0603052B RID: 197931 RVA: 0x00BC9478 File Offset: 0x00BC7678
		public unsafe bool UpdateSplineMoveDistanceByRuntimeData(SceneItemSplineMoveRuntimeData splineMoveRuntimeData, float tolerance = 100f)
		{
			if (!this.IsSplineMoving() || this.MoveComponent == null)
			{
				return false;
			}
			if (splineMoveRuntimeData.DistanceAloneSpline != null)
			{
				float? distanceAloneSpline = splineMoveRuntimeData.DistanceAloneSpline;
				float num = 0f;
				if (distanceAloneSpline.GetValueOrDefault() >= num & distanceAloneSpline != null)
				{
					if (!SceneItemSplineMoveTaskUtils.CheckSplineMoveDistanceNearlyEqual((double)splineMoveRuntimeData.DistanceAloneSpline.Value, (double)this.MoveComponent.GetDistanceAlongSpline(), (double)tolerance))
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.SceneItem;
						ELogAuthor author = ELogAuthor.ZYL;
						string message = "[SceneItemMoveComponent.UpdateSplineMoveDistanceByRuntimeData] 更新样条移动进度";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
						string item = "PbDataId";
						CreatureDataComponent creatureDataComp = this.CreatureDataComp;
						ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("OldDistanceAlongSpline", this.MoveComponent.GetDistanceAlongSpline());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NewDistanceAlongSpline", splineMoveRuntimeData.DistanceAloneSpline);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
						this.UpdateSplineMoveDistance(splineMoveRuntimeData.DistanceAloneSpline.Value);
						return true;
					}
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[SceneItemMoveComponent.UpdateSplineMoveDistanceByRuntimeData] 样条移动进度相差过小，不更新";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item2 = "PbDataId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("OldDistanceAlongSpline", this.MoveComponent.GetDistanceAlongSpline());
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("NewDistanceAlongSpline", splineMoveRuntimeData.DistanceAloneSpline);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
					return false;
				}
			}
			if (splineMoveRuntimeData.CurPos != null)
			{
				if (!SceneItemSplineMoveTaskUtils.CheckSplineMoveLocationNearlyEqual(this.ActorComp.ActorLocationProxy, splineMoveRuntimeData.CurPos, (double)tolerance))
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.SceneItem;
					ELogAuthor author3 = ELogAuthor.ZYL;
					string message3 = "[SceneItemMoveComponent.UpdateSplineMoveDistanceByRuntimeData] 更新样条移动进度";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
					string item3 = "PbDataId";
					CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
					ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("OldPos", this.ActorComp.ActorLocationProxy);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("NewPos", splineMoveRuntimeData.CurPos);
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
					this.UpdateSplineMoveDistanceByPos(splineMoveRuntimeData.CurPos);
					return true;
				}
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SceneItemMoveComponent.UpdateSplineMoveDistanceByRuntimeData] 样条移动进度相差过小，不更新";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1);
				string item4 = "PbDataId";
				CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
				ptr4 = new ValueTuple<string, object>(item4, (creatureDataComp4 != null) ? new int?(creatureDataComp4.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("OldPos", this.ActorComp.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("NewPos", splineMoveRuntimeData.CurPos);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 4));
			}
			return false;
		}

		// Token: 0x0603052C RID: 197932 RVA: 0x00BC9878 File Offset: 0x00BC7A78
		public unsafe bool UpdateSplineMoveRotationByRuntimeData(SceneItemSplineMoveRuntimeData splineMoveRuntimeData, float tolerance = 0.017453292f)
		{
			if (!this.IsSplineMoving() || this.MoveComponent == null)
			{
				return false;
			}
			if (splineMoveRuntimeData.CurRot != null)
			{
				Singleton<MathUtils>.Instance.CommonTempRotator.DeepCopy(splineMoveRuntimeData.CurRot);
				if (!SceneItemSplineMoveTaskUtils.CheckSplineMoveRotatorNearlyEqual(Singleton<MathUtils>.Instance.CommonTempRotator, this.ActorComp.ActorRotationProxy, (double)tolerance))
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SceneItemMoveComponent.UpdateSplineMoveRotationByRuntimeData] 更新样条移动旋转";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "PbDataId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("OldRot", this.ActorComp.ActorRotationProxy);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("NewRot", splineMoveRuntimeData.CurRot);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					AActor owner = this.MoveComponent.GetOwner();
					if (owner != null)
					{
						owner.K2_SetActorRotation(Singleton<MathUtils>.Instance.CommonTempRotator.ToUeRotator(), false);
					}
					return true;
				}
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemMoveComponent.UpdateSplineMoveRotationByRuntimeData] 样条移动旋转相差过小，不更新";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("OldRot", this.ActorComp.ActorRotationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("NewRot", splineMoveRuntimeData.CurRot);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			}
			return false;
		}

		// Token: 0x0603052D RID: 197933 RVA: 0x00BC9A8C File Offset: 0x00BC7C8C
		public FSplineMoveDynamicSpeedData? GetSplineMoveDynamicSpeedData()
		{
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent == null || !moveComponent.IsMoving(false))
			{
				return null;
			}
			return new FSplineMoveDynamicSpeedData?(this.MoveComponent.SplineMoveData.DynamicSpeedData);
		}

		// Token: 0x0603052E RID: 197934 RVA: 0x00BC9AD0 File Offset: 0x00BC7CD0
		[NullableContext(2)]
		public unsafe void OnRecvSyncSplineMoving(int protoSplineId, MoveSplineConfig protoMoveSplineConfig = null, SceneItemSplineRuntimeData protoRuntimeData = null)
		{
			ISceneItemSplineMoveConfig sceneItemSplineMoveConfig = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralConfig();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveConfigToGeneralConfig(protoSplineId, protoMoveSplineConfig, sceneItemSplineMoveConfig))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneItem;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SceneItemMoveComponent.OnRecvSyncSplineMoving] 解析样条移动协议中的样条移动配置失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			SceneItemSplineMoveRuntimeData sceneItemSplineMoveRuntimeData = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralRuntimeData();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveRuntimeDataToGeneralRuntimeData(protoRuntimeData, sceneItemSplineMoveRuntimeData))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemMoveComponent.OnRecvSyncSplineMoving] 解析样条移动协议中的样条移动运行时数据失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			SceneItemSplineMoveTask curSplineMoveTask = this.GetCurSplineMoveTask();
			if (curSplineMoveTask == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[SceneItemMoveComponent.OnRecvSyncSplineMoving] 当前没有样条移动task，直接开始新的样条移动task";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
				string item3 = "PbDataId";
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
				this.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
				{
					SplineId = protoSplineId,
					SplineMoveConfig = sceneItemSplineMoveConfig,
					EnableSplineMoveSync = true,
					EnableMovementSync = false,
					NeedMoveToStartPoint = false,
					SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData
				});
				return;
			}
			if (!curSplineMoveTask.CheckSplineMoveConfigEqual(sceneItemSplineMoveConfig))
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SceneItemMoveComponent.OnRecvSyncSplineMoving] 当前样条移动task参数与同步信息不同，中断并开始新的样条移动task";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1);
				string item4 = "PbDataId";
				CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
				ptr4 = new ValueTuple<string, object>(item4, (creatureDataComp4 != null) ? new int?(creatureDataComp4.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 5));
				curSplineMoveTask.EndTask(false);
				this.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
				{
					SplineId = protoSplineId,
					SplineMoveConfig = sceneItemSplineMoveConfig,
					EnableSplineMoveSync = true,
					EnableMovementSync = false,
					NeedMoveToStartPoint = false,
					SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData
				});
				return;
			}
			if (!this.IsSplineMoving())
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[SceneItemMoveComponent.OnRecvSyncSplineMoving] 当前样条移动task未在进行样条移动，中断并开始新的样条移动task";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 4));
				curSplineMoveTask.EndTask(false);
				this.StartSplineMoveTask(new SceneItemSplineMoveTaskParam
				{
					SplineId = protoSplineId,
					SplineMoveConfig = sceneItemSplineMoveConfig,
					EnableSplineMoveSync = true,
					EnableMovementSync = false,
					NeedMoveToStartPoint = false,
					SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData
				});
				return;
			}
			bool flag = false;
			flag = (this.UpdateSplineMoveDistanceByRuntimeData(sceneItemSplineMoveRuntimeData, 100f) || flag);
			flag = (this.UpdateSplineMoveRotationByRuntimeData(sceneItemSplineMoveRuntimeData, 0.017453292f) || flag);
			if (flag)
			{
				UeSceneItemMoveTickManagerComponent ueTickComponent = this.UeTickComponent;
				if (ueTickComponent == null)
				{
					return;
				}
				ueTickComponent.TickMovement(0f, true);
			}
		}

		// Token: 0x0603052F RID: 197935 RVA: 0x00BC9F94 File Offset: 0x00BC8194
		[NullableContext(2)]
		public unsafe void OnRecvSyncSplineStop(int protoSplineId, MoveSplineConfig protoMoveSplineConfig = null, SceneItemSplineRuntimeData protoRuntimeData = null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SceneItemMoveComponent.OnRecvSyncSplineStop] 停止样条移动task";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "PbDataId";
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			ISceneItemSplineMoveConfig sceneItemSplineMoveConfig = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralConfig();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveConfigToGeneralConfig(protoSplineId, protoMoveSplineConfig, sceneItemSplineMoveConfig))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemMoveComponent.OnRecvSyncSplineStop] 解析样条移动协议中的样条移动配置失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			SceneItemSplineMoveRuntimeData sceneItemSplineMoveRuntimeData = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralRuntimeData();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveRuntimeDataToGeneralRuntimeData(protoRuntimeData, sceneItemSplineMoveRuntimeData))
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[SceneItemMoveComponent.OnRecvSyncSplineStop] 解析样条移动协议中的样条移动运行时数据失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
				string item3 = "PbDataId";
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				return;
			}
			SceneItemSplineMoveTask curSplineMoveTask = this.GetCurSplineMoveTask();
			if (curSplineMoveTask == null)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SceneItemMoveComponent.OnRecvSyncSplineStop] 当前没有样条移动task，不需要处理停止";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1);
				string item4 = "PbDataId";
				CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
				ptr4 = new ValueTuple<string, object>(item4, (creatureDataComp4 != null) ? new int?(creatureDataComp4.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 5));
				return;
			}
			if (!curSplineMoveTask.CheckSplineMoveConfigEqual(sceneItemSplineMoveConfig))
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[SceneItemMoveComponent.OnRecvSyncSplineStop] 当前样条移动task参数与同步信息不同，不处理停止";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr5 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1);
				string item5 = "PbDataId";
				CreatureDataComponent creatureDataComp5 = this.CreatureDataComp;
				ptr5 = new ValueTuple<string, object>(item5, (creatureDataComp5 != null) ? new int?(creatureDataComp5.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 5));
				return;
			}
			if (this.MoveComponent != null && this.IsSplineMoving())
			{
				bool flag = false;
				flag = (this.UpdateSplineMoveDistanceByRuntimeData(sceneItemSplineMoveRuntimeData, 0f) || flag);
				flag = (this.UpdateSplineMoveRotationByRuntimeData(sceneItemSplineMoveRuntimeData, 0f) || flag);
				if (flag)
				{
					UeSceneItemMoveTickManagerComponent ueTickComponent = this.UeTickComponent;
					if (ueTickComponent != null)
					{
						ueTickComponent.TickMovement(0f, true);
					}
				}
			}
			curSplineMoveTask.EndTask(true);
		}

		// Token: 0x06030530 RID: 197936 RVA: 0x00BCA3CC File Offset: 0x00BC85CC
		[NullableContext(2)]
		public unsafe void OnRecvSyncSplineInterrupt(int protoSplineId, MoveSplineConfig protoMoveSplineConfig = null, SceneItemSplineRuntimeData protoRuntimeData = null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SceneItemMoveComponent.OnRecvSyncSplineInterrupt] 中断样条移动task";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "PbDataId";
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			ISceneItemSplineMoveConfig sceneItemSplineMoveConfig = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralConfig();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveConfigToGeneralConfig(protoSplineId, protoMoveSplineConfig, sceneItemSplineMoveConfig))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemMoveComponent.OnRecvSyncSplineInterrupt] 解析样条移动协议中的样条移动配置失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			SceneItemSplineMoveRuntimeData sceneItemSplineMoveRuntimeData = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralRuntimeData();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveRuntimeDataToGeneralRuntimeData(protoRuntimeData, sceneItemSplineMoveRuntimeData))
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[SceneItemMoveComponent.OnRecvSyncSplineInterrupt] 解析样条移动协议中的样条移动运行时数据失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
				string item3 = "PbDataId";
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				return;
			}
			SceneItemSplineMoveTask curSplineMoveTask = this.GetCurSplineMoveTask();
			if (curSplineMoveTask == null)
			{
				global::Log instance4 = Singleton<global::Log>.Instance;
				ELogModule module4 = ELogModule.SceneItem;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[SceneItemMoveComponent.OnRecvSyncSplineInterrupt] 当前没有样条移动task，不需要处理中断";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1);
				string item4 = "PbDataId";
				CreatureDataComponent creatureDataComp4 = this.CreatureDataComp;
				ptr4 = new ValueTuple<string, object>(item4, (creatureDataComp4 != null) ? new int?(creatureDataComp4.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 5));
				return;
			}
			if (!curSplineMoveTask.CheckSplineMoveConfigEqual(sceneItemSplineMoveConfig))
			{
				global::Log instance5 = Singleton<global::Log>.Instance;
				ELogModule module5 = ELogModule.SceneItem;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[SceneItemMoveComponent.OnRecvSyncSplineInterrupt] 当前样条移动task参数与同步信息不同，不处理中断";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr5 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1);
				string item5 = "PbDataId";
				CreatureDataComponent creatureDataComp5 = this.CreatureDataComp;
				ptr5 = new ValueTuple<string, object>(item5, (creatureDataComp5 != null) ? new int?(creatureDataComp5.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("SplineEntityId", protoSplineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("SplineMoveRuntimeData", sceneItemSplineMoveRuntimeData);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 4) = new ValueTuple<string, object>("SplineMoveConfig", sceneItemSplineMoveConfig);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 5));
				return;
			}
			if (this.MoveComponent != null && this.IsSplineMoving())
			{
				bool flag = false;
				flag = (this.UpdateSplineMoveDistanceByRuntimeData(sceneItemSplineMoveRuntimeData, 0f) || flag);
				flag = (this.UpdateSplineMoveRotationByRuntimeData(sceneItemSplineMoveRuntimeData, 0f) || flag);
				if (flag)
				{
					UeSceneItemMoveTickManagerComponent ueTickComponent = this.UeTickComponent;
					if (ueTickComponent != null)
					{
						ueTickComponent.TickMovement(0f, true);
					}
				}
			}
			if (curSplineMoveTask != null)
			{
				curSplineMoveTask.EndTask(false);
			}
		}

		// Token: 0x06030531 RID: 197937 RVA: 0x00BCA804 File Offset: 0x00BC8A04
		[NullableContext(2)]
		public unsafe void OnRecvSyncSplineSwitch(int protoSplineId, MoveSplineConfig protoMoveSplineConfig = null, SceneItemSplineRuntimeData protoRuntimeData = null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[SceneItemMoveComponent.OnRecvSyncSplineSwitch] 接收切换样条移动";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "PbDataId";
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NewSplineEntityId", protoSplineId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			ISceneItemSplineMoveConfig sceneItemSplineMoveConfig = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralConfig();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveConfigToGeneralConfig(protoSplineId, protoMoveSplineConfig, sceneItemSplineMoveConfig))
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.SceneItem;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SceneItemMoveComponent.OnRecvSyncSplineSwitch] 解析样条移动协议中的新样条配置失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item2 = "PbDataId";
				CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
				ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("NewSplineEntityId", protoSplineId);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			SceneItemSplineMoveRuntimeData sceneItemSplineMoveRuntimeData = SceneItemSplineMoveTaskUtils.CreateDefaultGeneralRuntimeData();
			if (!SceneItemSplineMoveTaskUtils.ParseProtoSplineMoveRuntimeDataToGeneralRuntimeData(protoRuntimeData, sceneItemSplineMoveRuntimeData))
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.SceneItem;
				ELogAuthor author3 = ELogAuthor.ZYL;
				string message3 = "[SceneItemMoveComponent.OnRecvSyncSplineSwitch] 解析样条移动协议中的运行时数据失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
				string item3 = "PbDataId";
				CreatureDataComponent creatureDataComp3 = this.CreatureDataComp;
				ptr3 = new ValueTuple<string, object>(item3, (creatureDataComp3 != null) ? new int?(creatureDataComp3.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("NewSplineEntityId", protoSplineId);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
				return;
			}
			this.SwitchSplineMoveTask(new SceneItemSplineMoveTaskParam
			{
				SplineId = protoSplineId,
				SplineMoveConfig = sceneItemSplineMoveConfig,
				EnableSplineMoveSync = true,
				EnableMovementSync = false,
				NeedMoveToStartPoint = false,
				SplineMoveRuntimeData = sceneItemSplineMoveRuntimeData
			});
		}

		// Token: 0x06030532 RID: 197938 RVA: 0x00BCAA58 File Offset: 0x00BC8C58
		public unsafe void StopMove(bool broadcastStopCallback = true, bool boardcastIndexCallback = true)
		{
			if (Singleton<Info>.Instance.EnableForceTick)
			{
				this.MoveTargetList.Clear();
				this.CurState = SceneItemMoveComponent.ERunningState.STOP;
				return;
			}
			if (!this.IsMovingPrepareCompleted)
			{
				this.MoveTargetList.Clear();
				return;
			}
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			bool flag = moveComponent != null && moveComponent.IsMoving(true);
			bool flag2;
			if (!flag)
			{
				flag2 = false;
			}
			else
			{
				UKuroSceneItemMoveComponent moveComponent2 = this.MoveComponent;
				flag2 = (moveComponent2 == null || moveComponent2.GetSimpleRunState() > ESimpleRunState.Stop);
			}
			bool flag3 = flag2;
			if (flag)
			{
				if (flag3)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "SceneItemMoveComponent 简单移动中断";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
					string item = "PbDataId";
					CreatureDataComponent creatureDataComp = this.CreatureDataComp;
					ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemMoveBroken, base.Entity);
				}
				else
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.SceneItem;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "SceneItemMoveComponent 样条移动中断";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
					string item2 = "PbDataId";
					CreatureDataComponent creatureDataComp2 = this.CreatureDataComp;
					ptr2 = new ValueTuple<string, object>(item2, (creatureDataComp2 != null) ? new int?(creatureDataComp2.GetPbDataId()) : null);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemMoveBroken, base.Entity);
					Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveBroken, base.Entity);
				}
			}
			this.MoveComponent.StopAllMove(broadcastStopCallback, boardcastIndexCallback);
		}

		// Token: 0x06030533 RID: 197939 RVA: 0x00BCAC42 File Offset: 0x00BC8E42
		private void AddUeArrivePointCallback(Action<int> callback)
		{
			this.MoveComponent.OnArrivePointCallback.Add(callback);
		}

		// Token: 0x06030534 RID: 197940 RVA: 0x00BCAC55 File Offset: 0x00BC8E55
		private void RemoveUeArrivePointCallback(Action<int> callback)
		{
			this.MoveComponent.OnArrivePointCallback.Remove(callback);
		}

		// Token: 0x06030535 RID: 197941 RVA: 0x00BCAC68 File Offset: 0x00BC8E68
		private void OnUeArrivePointCallback(int index)
		{
			this.CallOnArrivePointCallbacks(index);
		}

		// Token: 0x06030536 RID: 197942 RVA: 0x00BCAC71 File Offset: 0x00BC8E71
		public void AddOnArrivePointCallback(Action<int> callback)
		{
			if (!this.OnArrivePointCallbacks.Contains(callback))
			{
				this.OnArrivePointCallbacks.Add(callback);
			}
		}

		// Token: 0x06030537 RID: 197943 RVA: 0x00BCAC90 File Offset: 0x00BC8E90
		public void RemoveOnArrivePointCallback(Action<int> callback)
		{
			int num = this.OnArrivePointCallbacks.IndexOf(callback);
			if (num != -1)
			{
				this.OnArrivePointCallbacks.RemoveAt(num);
			}
		}

		// Token: 0x06030538 RID: 197944 RVA: 0x00BCACBA File Offset: 0x00BC8EBA
		public void ClearOnArrivePointCallbacks()
		{
			this.OnArrivePointCallbacks.Clear();
		}

		// Token: 0x06030539 RID: 197945 RVA: 0x00BCACC8 File Offset: 0x00BC8EC8
		private void CallOnArrivePointCallbacks(int index)
		{
			foreach (Action<int> action in new List<Action<int>>(this.OnArrivePointCallbacks))
			{
				action(index);
			}
		}

		// Token: 0x0603053A RID: 197946 RVA: 0x00BCAD20 File Offset: 0x00BC8F20
		private void AddUeMoveStopCallback(Action callback)
		{
			this.MoveComponent.OnMoveStopCallback.Add(callback);
		}

		// Token: 0x0603053B RID: 197947 RVA: 0x00BCAD33 File Offset: 0x00BC8F33
		private void RemoveUeMoveStopCallback(Action callback)
		{
			this.MoveComponent.OnMoveStopCallback.Remove(callback);
		}

		// Token: 0x0603053C RID: 197948 RVA: 0x00BCAD48 File Offset: 0x00BC8F48
		private void OnUeMoveStopCallback()
		{
			SceneItemMoveComponent.EMoveMode moveMode = this.MoveMode;
			this.MoveMode = SceneItemMoveComponent.EMoveMode.None;
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.移动机关.样条移动.移动中"]));
			}
			if (moveMode == SceneItemMoveComponent.EMoveMode.Simple)
			{
				this.OnUeMoveStopCallbackForSimpleMove();
				return;
			}
			if (moveMode == SceneItemMoveComponent.EMoveMode.Spline)
			{
				this.OnUeMoveStopCallbackForSplineMove();
			}
		}

		// Token: 0x0603053D RID: 197949 RVA: 0x00BCAD9E File Offset: 0x00BC8F9E
		private void OnUeMoveStopCallbackForSimpleMove()
		{
			SceneItemActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ResetAllCachedTime();
			}
			this.CallOnMoveStopCallbacksWithEntity();
			this.CallOnMoveStopCallbacks();
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemMoveStopped, base.Entity);
		}

		// Token: 0x0603053E RID: 197950 RVA: 0x00BCADDC File Offset: 0x00BC8FDC
		private void OnUeMoveStopCallbackForSplineMove()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.SceneItem;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "SceneItemMoveComponent 样条移动停止";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			SceneItemActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ResetAllCachedTime();
			}
			this.InPotral = false;
			this.CallOnMoveStopCallbacksWithEntity();
			this.CallOnMoveStopCallbacks();
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemMoveStopped, base.Entity);
			Singleton<EventSystem>.Instance.EmitWithTarget<Entity>(base.Entity, EEventName.OnSceneItemSplineMoveStopped, base.Entity);
		}

		// Token: 0x0603053F RID: 197951 RVA: 0x00BCAE7B File Offset: 0x00BC907B
		public void AddStopMoveCallback(Action callback)
		{
			if (!this.MoveStopCallbacks.Contains(callback))
			{
				this.MoveStopCallbacks.Add(callback);
			}
		}

		// Token: 0x06030540 RID: 197952 RVA: 0x00BCAE98 File Offset: 0x00BC9098
		public void RemoveStopMoveCallback(Action callback)
		{
			int num = this.MoveStopCallbacks.IndexOf(callback);
			if (num != -1)
			{
				this.MoveStopCallbacks.RemoveAt(num);
			}
		}

		// Token: 0x06030541 RID: 197953 RVA: 0x00BCAEC2 File Offset: 0x00BC90C2
		public void ClearStopMoveCallback()
		{
			this.MoveStopCallbacks.Clear();
		}

		// Token: 0x06030542 RID: 197954 RVA: 0x00BCAED0 File Offset: 0x00BC90D0
		private void CallOnMoveStopCallbacks()
		{
			foreach (Action action in new List<Action>(this.MoveStopCallbacks))
			{
				action();
			}
		}

		// Token: 0x06030543 RID: 197955 RVA: 0x00BCAF28 File Offset: 0x00BC9128
		public void AddStopMoveCallbackWithEntity(Action<Entity> callback)
		{
			if (!this.MoveStopCallbacksWithEntity.Contains(callback))
			{
				this.MoveStopCallbacksWithEntity.Add(callback);
			}
		}

		// Token: 0x06030544 RID: 197956 RVA: 0x00BCAF44 File Offset: 0x00BC9144
		public void RemoveStopMoveCallbackWithEntity(Action<Entity> callback)
		{
			int num = this.MoveStopCallbacksWithEntity.IndexOf(callback);
			if (num != -1)
			{
				this.MoveStopCallbacksWithEntity.RemoveAt(num);
			}
		}

		// Token: 0x06030545 RID: 197957 RVA: 0x00BCAF6E File Offset: 0x00BC916E
		public void ClearStopMoveCallbacksWithEntity()
		{
			this.MoveStopCallbacksWithEntity.Clear();
		}

		// Token: 0x06030546 RID: 197958 RVA: 0x00BCAF7C File Offset: 0x00BC917C
		private void CallOnMoveStopCallbacksWithEntity()
		{
			foreach (Action<Entity> action in new List<Action<Entity>>(this.MoveStopCallbacksWithEntity))
			{
				action(base.Entity);
			}
		}

		// Token: 0x06030547 RID: 197959 RVA: 0x00BCAFD8 File Offset: 0x00BC91D8
		public string GetDebugString()
		{
			string text = "";
			UKuroSceneItemMoveComponent moveComponent = this.MoveComponent;
			if (moveComponent == null || !moveComponent.IsValid())
			{
				return text;
			}
			bool flag = this.MoveComponent.IsMoving(true);
			string str = text;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("移动中: ");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(flag);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			if (!flag)
			{
				return text;
			}
			ESimpleRunState simpleRunState = this.MoveComponent.GetSimpleRunState();
			string str2 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("简单移动状态: ");
			defaultInterpolatedStringHandler.AppendFormatted<ESimpleRunState>(simpleRunState);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			ESplineRunState splineRunState = this.MoveComponent.GetSplineRunState();
			string str3 = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("样条移动状态: ");
			defaultInterpolatedStringHandler.AppendFormatted<ESplineRunState>(splineRunState);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str3 + defaultInterpolatedStringHandler.ToStringAndClear();
			if (splineRunState != ESplineRunState.None)
			{
				FSplineMoveDynamicSpeedData dynamicSpeedData = this.MoveComponent.SplineMoveData.DynamicSpeedData;
				text += "动态速度参数:\n";
				string str4 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\tCurrentSpeed: ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(dynamicSpeedData.CurrentSpeed, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str4 + defaultInterpolatedStringHandler.ToStringAndClear();
				string str5 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\tTargetSpeed: ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(dynamicSpeedData.TargetSpeed, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str5 + defaultInterpolatedStringHandler.ToStringAndClear();
				string str6 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\tAcceleration: ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(dynamicSpeedData.Acceleration, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str6 + defaultInterpolatedStringHandler.ToStringAndClear();
				string str7 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\tEndDis: ");
				defaultInterpolatedStringHandler.AppendFormatted<float>(dynamicSpeedData.EndDis, "F2");
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str7 + defaultInterpolatedStringHandler.ToStringAndClear();
				FSplineMoveStaticTimeDisData staticTimeDisData = this.MoveComponent.SplineMoveData.StaticTimeDisData;
				text += "固定时间参数:\n";
				string str8 = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("\tTimeDisCurveValid: ");
				UCurveFloat timeDisCurve = staticTimeDisData.TimeDisCurve;
				defaultInterpolatedStringHandler.AppendFormatted<bool>(timeDisCurve != null && timeDisCurve.IsValid());
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				text = str8 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return text;
		}

		// Token: 0x06030548 RID: 197960 RVA: 0x00BCB270 File Offset: 0x00BC9470
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemMoveComponent sceneItemMoveComponent = (SceneItemMoveComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemMoveComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComponent"))
			{
				if (sceneItemMoveComponent.MoveComponent == null)
				{
					this.MoveComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroSceneItemMoveComponent>(this.MoveComponent), "MoveComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SyncComp"))
			{
				if (sceneItemMoveComponent.SyncComp == null)
				{
					this.SyncComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMovementSyncComponent>(this.SyncComp), "SyncComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PropertyComp"))
			{
				if (sceneItemMoveComponent.PropertyComp == null)
				{
					this.PropertyComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemPropertyComponent>(this.PropertyComp), "PropertyComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (sceneItemMoveComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (sceneItemMoveComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UeTickComponent"))
			{
				if (sceneItemMoveComponent.UeTickComponent == null)
				{
					this.UeTickComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UeSceneItemMoveTickManagerComponent>(this.UeTickComponent), "UeTickComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveMode"))
			{
				this.MoveMode = sceneItemMoveComponent.MoveMode;
			}
			if (base.CanResetComponentProperty("IsSyncing"))
			{
				this.IsSyncing = sceneItemMoveComponent.IsSyncing;
			}
			if (base.CanResetComponentProperty("ForceSyncingInternal"))
			{
				this.ForceSyncingInternal = sceneItemMoveComponent.ForceSyncingInternal;
			}
			if (base.CanResetComponentProperty("Velocity"))
			{
				if (sceneItemMoveComponent.Velocity == null)
				{
					this.Velocity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.Velocity), "Velocity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveTargetList"))
			{
				if (sceneItemMoveComponent.MoveTargetList == null)
				{
					this.MoveTargetList = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<SceneItemMoveComponent.MoveTarget>>(this.MoveTargetList), "MoveTargetList"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurState"))
			{
				this.CurState = sceneItemMoveComponent.CurState;
			}
			if (base.CanResetComponentProperty("StartLocation") && sceneItemMoveComponent.StartLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.StartLocation), "StartLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TargetLocation"))
			{
				if (sceneItemMoveComponent.TargetLocation == null)
				{
					this.TargetLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TargetLocation), "TargetLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurLocation") && sceneItemMoveComponent.CurLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CurLocation), "CurLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MaxDist"))
			{
				this.MaxDist = sceneItemMoveComponent.MaxDist;
			}
			if (base.CanResetComponentProperty("InPotral"))
			{
				this.InPotral = sceneItemMoveComponent.InPotral;
			}
			if (base.CanResetComponentProperty("IsMovingPrepareCompletedInternal"))
			{
				this.IsMovingPrepareCompletedInternal = sceneItemMoveComponent.IsMovingPrepareCompletedInternal;
			}
			if (base.CanResetComponentProperty("NeedTickOutside"))
			{
				this.NeedTickOutside = sceneItemMoveComponent.NeedTickOutside;
			}
			return (!base.CanResetComponentProperty("OnArrivePointCallbacks") || sceneItemMoveComponent.OnArrivePointCallbacks == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<Action<int>>>(this.OnArrivePointCallbacks), "OnArrivePointCallbacks")) && (!base.CanResetComponentProperty("MoveStopCallbacks") || sceneItemMoveComponent.MoveStopCallbacks == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<Action>>(this.MoveStopCallbacks), "MoveStopCallbacks")) && (!base.CanResetComponentProperty("MoveStopCallbacksWithEntity") || sceneItemMoveComponent.MoveStopCallbacksWithEntity == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<Action<Entity>>>(this.MoveStopCallbacksWithEntity), "MoveStopCallbacksWithEntity"));
		}

		// Token: 0x0401BC01 RID: 113665
		private const string SCENEITEM_MOVE_DEBUG_KEY = "SCENEITEM_MOVE_DEBUG";

		// Token: 0x0401BC02 RID: 113666
		private const float OFFSET = 100f;

		// Token: 0x0401BC03 RID: 113667
		[Nullable(2)]
		public SceneItemActorComponent ActorComp;

		// Token: 0x0401BC04 RID: 113668
		[Nullable(2)]
		private UKuroSceneItemMoveComponent MoveComponent;

		// Token: 0x0401BC05 RID: 113669
		[Nullable(2)]
		private SceneItemMovementSyncComponent SyncComp;

		// Token: 0x0401BC06 RID: 113670
		[Nullable(2)]
		private SceneItemPropertyComponent PropertyComp;

		// Token: 0x0401BC07 RID: 113671
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BC08 RID: 113672
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401BC09 RID: 113673
		[Nullable(2)]
		private UeSceneItemMoveTickManagerComponent UeTickComponent;

		// Token: 0x0401BC0A RID: 113674
		private SceneItemMoveComponent.EMoveMode MoveMode;

		// Token: 0x0401BC0B RID: 113675
		private bool IsSyncing;

		// Token: 0x0401BC0C RID: 113676
		private bool ForceSyncingInternal;

		// Token: 0x0401BC0D RID: 113677
		private global::Vector Velocity = global::Vector.Create();

		// Token: 0x0401BC0E RID: 113678
		private List<SceneItemMoveComponent.MoveTarget> MoveTargetList = new List<SceneItemMoveComponent.MoveTarget>();

		// Token: 0x0401BC0F RID: 113679
		private SceneItemMoveComponent.ERunningState CurState = SceneItemMoveComponent.ERunningState.STOP;

		// Token: 0x0401BC10 RID: 113680
		private readonly global::Vector StartLocation = global::Vector.Create();

		// Token: 0x0401BC11 RID: 113681
		private global::Vector TargetLocation = global::Vector.Create();

		// Token: 0x0401BC12 RID: 113682
		private readonly global::Vector CurLocation = global::Vector.Create();

		// Token: 0x0401BC13 RID: 113683
		private float MaxDist;

		// Token: 0x0401BC14 RID: 113684
		private bool InPotral;

		// Token: 0x0401BC15 RID: 113685
		private bool IsMovingPrepareCompletedInternal;

		// Token: 0x0401BC16 RID: 113686
		private bool NeedTickOutside;

		// Token: 0x0401BC17 RID: 113687
		private readonly List<Action<int>> OnArrivePointCallbacks = new List<Action<int>>();

		// Token: 0x0401BC18 RID: 113688
		private readonly List<Action> MoveStopCallbacks = new List<Action>();

		// Token: 0x0401BC19 RID: 113689
		private readonly List<Action<Entity>> MoveStopCallbacksWithEntity = new List<Action<Entity>>();

		// Token: 0x0200A959 RID: 43353
		[NullableContext(0)]
		private enum ERunningState
		{
			// Token: 0x0403476C RID: 214892
			RUN,
			// Token: 0x0403476D RID: 214893
			STOP
		}

		// Token: 0x0200A95A RID: 43354
		[NullableContext(0)]
		private enum EMoveMode
		{
			// Token: 0x0403476F RID: 214895
			None,
			// Token: 0x04034770 RID: 214896
			Simple,
			// Token: 0x04034771 RID: 214897
			Spline
		}

		// Token: 0x0200A95B RID: 43355
		[Nullable(0)]
		public class MoveTarget
		{
			// Token: 0x0604B162 RID: 307554 RVA: 0x01470C81 File Offset: 0x0146EE81
			public MoveTarget(IVector targetPosData, float moveTime, float stayTime = 0f, float maxSpeed = -1f, float acceleration = -1f)
			{
				this.TargetPosData.DeepCopy(targetPosData);
				this.MoveTime = moveTime;
				this.StayTime = stayTime;
				this.MaxSpeed = maxSpeed;
				this.Acceleration = acceleration;
			}

			// Token: 0x04034772 RID: 214898
			public global::Vector TargetPosData = global::Vector.Create();

			// Token: 0x04034773 RID: 214899
			public float MoveTime;

			// Token: 0x04034774 RID: 214900
			public float StayTime;

			// Token: 0x04034775 RID: 214901
			public float MaxSpeed;

			// Token: 0x04034776 RID: 214902
			public float Acceleration;
		}

		// Token: 0x0200A95C RID: 43356
		[Nullable(0)]
		public abstract class SceneItemSplineMoveBaseParam
		{
			// Token: 0x0604B163 RID: 307555 RVA: 0x01470CBE File Offset: 0x0146EEBE
			protected SceneItemSplineMoveBaseParam(USplineComponent spline)
			{
			}

			// Token: 0x04034777 RID: 214903
			public bool IsCycle;

			// Token: 0x04034778 RID: 214904
			public bool IsKeepLookAt;

			// Token: 0x04034779 RID: 214905
			public float StartDis = -1f;

			// Token: 0x0403477A RID: 214906
			public float EndDis = -1f;

			// Token: 0x0403477B RID: 214907
			public USplineComponent Spline = spline;
		}

		// Token: 0x0200A95D RID: 43357
		[NullableContext(0)]
		public class SceneItemSplineMoveAtConstantTimeParam : SceneItemMoveComponent.SceneItemSplineMoveBaseParam
		{
			// Token: 0x0604B164 RID: 307556 RVA: 0x01470CE3 File Offset: 0x0146EEE3
			[NullableContext(1)]
			public SceneItemSplineMoveAtConstantTimeParam(USplineComponent spline) : base(spline)
			{
			}

			// Token: 0x0403477C RID: 214908
			public bool IsRepeat;

			// Token: 0x0403477D RID: 214909
			public float TimeSec;

			// Token: 0x0403477E RID: 214910
			[Nullable(2)]
			public UCurveFloat TimeDisCurve;

			// Token: 0x0403477F RID: 214911
			public float StartTimeOffset;
		}

		// Token: 0x0200A95E RID: 43358
		[NullableContext(0)]
		public class SceneItemSplineMoveAtDynamicSpeedParam : SceneItemMoveComponent.SceneItemSplineMoveBaseParam
		{
			// Token: 0x0604B165 RID: 307557 RVA: 0x01470CEC File Offset: 0x0146EEEC
			[NullableContext(1)]
			public SceneItemSplineMoveAtDynamicSpeedParam(USplineComponent spline) : base(spline)
			{
			}

			// Token: 0x04034780 RID: 214912
			public int MaxMoveTimes = -1;

			// Token: 0x04034781 RID: 214913
			public float InitSpeed;

			// Token: 0x04034782 RID: 214914
			public float TargetSpeed;

			// Token: 0x04034783 RID: 214915
			public float Acceleration;
		}

		// Token: 0x0200A95F RID: 43359
		[NullableContext(0)]
		public class SceneItemSplineMoveAtDynamicSpeedEditableParam
		{
			// Token: 0x0604B166 RID: 307558 RVA: 0x01470CFC File Offset: 0x0146EEFC
			public void Clear()
			{
				this.CurrentSpeed = null;
				this.TargetSpeed = null;
				this.Acceleration = null;
			}

			// Token: 0x0604B167 RID: 307559 RVA: 0x01470D24 File Offset: 0x0146EF24
			[NullableContext(2)]
			public bool Equals(SceneItemMoveComponent.SceneItemSplineMoveAtDynamicSpeedEditableParam other)
			{
				if (other != null)
				{
					float? num = this.CurrentSpeed;
					float? num2 = other.CurrentSpeed;
					if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
					{
						num2 = this.TargetSpeed;
						num = other.TargetSpeed;
						if (num2.GetValueOrDefault() == num.GetValueOrDefault() & num2 != null == (num != null))
						{
							num = this.Acceleration;
							num2 = other.Acceleration;
							return num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null);
						}
					}
				}
				return false;
			}

			// Token: 0x04034784 RID: 214916
			public float? CurrentSpeed;

			// Token: 0x04034785 RID: 214917
			public float? TargetSpeed;

			// Token: 0x04034786 RID: 214918
			public float? Acceleration;
		}
	}
}
