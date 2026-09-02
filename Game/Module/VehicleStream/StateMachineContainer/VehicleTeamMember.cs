using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.Transport;
using CSharpScript.Game.Module.VehicleStream.StateMachine;
using CSharpScript.Game.Module.VehicleStream.StateMachine.States;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream.StateMachineContainer
{
	// Token: 0x02004C5A RID: 19546
	[NullableContext(1)]
	[Nullable(0)]
	public class VehicleTeamMember : StateMachineContainer
	{
		// Token: 0x17008778 RID: 34680
		// (get) Token: 0x06032ECA RID: 208586 RVA: 0x00CC1FB2 File Offset: 0x00CC01B2
		public override EStateContainerType Type
		{
			get
			{
				return EStateContainerType.Vehicle;
			}
		}

		// Token: 0x17008779 RID: 34681
		// (get) Token: 0x06032ECB RID: 208587 RVA: 0x00CC1FB5 File Offset: 0x00CC01B5
		public override int Id
		{
			get
			{
				return this.BlackBoard.PbDataId;
			}
		}

		// Token: 0x1700877A RID: 34682
		// (get) Token: 0x06032ECC RID: 208588 RVA: 0x00CC1FC2 File Offset: 0x00CC01C2
		public int TeamId
		{
			get
			{
				return this.BlackBoard.TeamId;
			}
		}

		// Token: 0x06032ECD RID: 208589 RVA: 0x00CC1FD0 File Offset: 0x00CC01D0
		public VehicleTeamMember(int teamId, int memberId, long creatureDataId, int pbDataId, global::Vector startActorLocation, global::Rotator startActorRotator, global::Vector destinationLocation, int destRoadId, int destIndex, ITrafficNavigationConfig baseConfig, ITransportFindPathResult result)
		{
			UKuroTransportNetworkSubsystem transportSystem = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem();
			VehicleStreamModel instance = ModelBase<VehicleStreamModel>.Instance;
			List<UKuroRoadway> list = new List<UKuroRoadway>();
			for (int i = 0; i < result.Roadways.Num(); i++)
			{
				UKuroRoadway ukuroRoadway = result.Roadways.Get(i);
				list.Add(ukuroRoadway);
				TArray<int> tarray = new TArray<int>();
				int intersectionId = transportSystem.GetIntersectionId(ukuroRoadway.Id);
				transportSystem.GetRoadwaysAtSameIntersection(intersectionId, ref tarray);
				instance.AddIntersection(intersectionId, tarray);
				transportSystem.GetCrossingRoads(ukuroRoadway.Id, ref tarray);
				TArray<int> inCrossingRoadways = tarray;
				instance.RecordCrossingRoadways(ukuroRoadway.Id, inCrossingRoadways);
			}
			global::Vector vector = global::Vector.Create();
			global::Vector vector2 = vector;
			FVectorDouble fvectorDouble = result.RoadStartPoint;
			vector2.DeepCopy(fvectorDouble);
			global::Vector vector3 = global::Vector.Create();
			global::Vector vector4 = vector3;
			fvectorDouble = result.RoadEndPoint;
			vector4.DeepCopy(fvectorDouble);
			CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent component = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId).Entity.GetComponent<CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent>();
			this.BlackBoard = new VehicleSmBlackBoard(teamId, memberId, creatureDataId, pbDataId, startActorLocation, startActorRotator, destinationLocation, list, vector, vector3, destRoadId, destIndex, component, baseConfig, new VehicleSmBlackBoard.SwitchStateHandleType(this.SwitchState));
		}

		// Token: 0x06032ECE RID: 208590 RVA: 0x00CC2100 File Offset: 0x00CC0300
		private void AddState<[Nullable(0)] T>(EVehicleStateType stateType, Func<VehicleSmBlackBoard, T> ctor) where T : VehicleStateBase
		{
			T t = ctor(this.BlackBoard);
			t.Create();
			this.StateMachine.AddState(stateType, t);
		}

		// Token: 0x06032ECF RID: 208591 RVA: 0x00CC2138 File Offset: 0x00CC0338
		public void Init()
		{
			this.AddState<BornState>(EVehicleStateType.Born, (VehicleSmBlackBoard board) => new BornState(board));
			this.AddState<RunningState>(EVehicleStateType.Running, (VehicleSmBlackBoard board) => new RunningState(board));
			this.AddState<BrakingState>(EVehicleStateType.Braking, (VehicleSmBlackBoard board) => new BrakingState(board));
			this.AddState<DestroyState>(EVehicleStateType.Destroy, (VehicleSmBlackBoard board) => new DestroyState(board));
			this.StateMachine.Start(EVehicleStateType.Born);
		}

		// Token: 0x06032ED0 RID: 208592 RVA: 0x00CC21EC File Offset: 0x00CC03EC
		public void Launch(USkeletalMeshComponent skeletalMeshComponent)
		{
			this.BlackBoard.SkeletalMeshComponent = skeletalMeshComponent;
			this.BlackBoard.SkeletalMeshRelativeLocation.Reset();
			global::Vector skeletalMeshRelativeLocation = this.BlackBoard.SkeletalMeshRelativeLocation;
			FVector relativeLocation = skeletalMeshComponent.RelativeLocation;
			FVectorDouble fvectorDouble = relativeLocation;
			skeletalMeshRelativeLocation.DeepCopy(fvectorDouble);
			float num = (float)this.BlackBoard.ModelCenterOffsetX();
			this.BlackBoard.MeshCenterToHead = (float)this.BlackBoard.VehicleSize.X / 2f + num;
			this.BlackBoard.MeshCenterToTail = (float)this.BlackBoard.VehicleSize.X / 2f - num;
			this.BlackBoard.RootCenterToHead = this.BlackBoard.MeshCenterToHead + (float)this.BlackBoard.SkeletalMeshRelativeLocation.X;
			this.BlackBoard.RootCenterToTail = this.BlackBoard.MeshCenterToTail - (float)this.BlackBoard.SkeletalMeshRelativeLocation.X;
			this.BlackBoard.InitTrace();
			this.BlackBoard.IsLaunch = true;
		}

		// Token: 0x06032ED1 RID: 208593 RVA: 0x00CC22F4 File Offset: 0x00CC04F4
		public void Destroy()
		{
			this.StateMachine.Destroy();
			UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
			if (currentRoadway != null)
			{
				ModelBase<VehicleStreamModel>.Instance.ExitRoadway(currentRoadway.Id, this.BlackBoard.CreatureDataId);
			}
		}

		// Token: 0x06032ED2 RID: 208594 RVA: 0x00CC2338 File Offset: 0x00CC0538
		public void OnForceTick(float delta)
		{
			this.BlackBoard.TickNum++;
			this.BlackBoard.TimeSinceLastTick += delta;
			this.BlackBoard.UpdateSkeletalMeshDistance();
			this.BlackBoard.UpdateRtpc(delta);
			if (!ModelBase<VehicleStreamModel>.Instance.EnableDebug)
			{
				return;
			}
			CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent roadNetworkNavigationComponent = this.BlackBoard.RoadNetworkNavigationComponent;
			FVectorDouble location = roadNetworkNavigationComponent.GetActorComponent().ActorTransform.GetLocation();
			FVectorDouble fvectorDouble = location;
			location.Z += this.BlackBoard.VehicleSize.Z;
			if (this.BlackBoard.SkeletalMeshComponent != null)
			{
				fvectorDouble = this.BlackBoard.SkeletalMeshComponent.D_K2_GetComponentToWorld().GetLocation();
				fvectorDouble.Z += this.BlackBoard.VehicleSize.Z;
			}
			FLinearColor flinearColor = new FLinearColor(1f, 0f, 0f, 1f);
			UKismetSystemLibrary.D_DrawDebugArrow(GlobalData.World, fvectorDouble, location, 2000f, flinearColor, 0.05f, 10f);
			EVehicleStateType currentState = this.StateMachine.GetCurrentState();
			string value = roadNetworkNavigationComponent.GetModelBufferTime().ToString("F2");
			UObject world = GlobalData.World;
			FVectorDouble textLocation = fvectorDouble;
			string str = currentState.ToString();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			VehicleSmBlackBoard blackBoard = this.BlackBoard;
			defaultInterpolatedStringHandler.AppendFormatted<bool?>((blackBoard != null) ? new bool?(blackBoard.WaitingModelBuffer) : null);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(this.BlackBoard.RoadNetworkNavigationComponent.IsModelBufferCompTickEnabled());
			UKismetSystemLibrary.D_DrawDebugString(world, textLocation, str + defaultInterpolatedStringHandler.ToStringAndClear(), null, new FLinearColor?(flinearColor), 0f);
		}

		// Token: 0x06032ED3 RID: 208595 RVA: 0x00CC2510 File Offset: 0x00CC0710
		public void OnTick(ETickType tickType, float delta, int tickInterval)
		{
			if (this.BlackBoard.LastTickNum == this.BlackBoard.TickNum)
			{
				return;
			}
			this.BlackBoard.TimeSinceLastTick = 0f;
			this.BlackBoard.UpdateMoved = false;
			this.CheckWaitModelBuffer();
			this.StateMachine.Update(delta);
			if (this.BlackBoard.UpdateMoved)
			{
				this.UpdateActorLocationAndRotation(tickType, delta, tickInterval);
			}
			this.BlackBoard.LastTickNum = this.BlackBoard.TickNum;
		}

		// Token: 0x06032ED4 RID: 208596 RVA: 0x00CC2591 File Offset: 0x00CC0791
		public void OnEnterPlayerRange()
		{
			this.BlackBoard.IsInPlayerRange = true;
			this.StateMachine.OnEnterPlayerRange();
		}

		// Token: 0x06032ED5 RID: 208597 RVA: 0x00CC25AC File Offset: 0x00CC07AC
		public void OnLeavePlayerRange()
		{
			this.BlackBoard.IsInPlayerRange = false;
			this.StateMachine.OnLeavePlayerRange();
			foreach (int eventHandle in this.BlackBoard.AudioHandleSet)
			{
				this.BlackBoard.StopAudio(eventHandle, false);
			}
			this.BlackBoard.AudioHandleSet.Clear();
		}

		// Token: 0x06032ED6 RID: 208598 RVA: 0x00CC2634 File Offset: 0x00CC0834
		private bool CheckWaitModelBuffer()
		{
			CSharpScript.Game.NewWorld.Common.Component.RoadNetworkNavigationComponent roadNetworkNavigationComponent = this.BlackBoard.RoadNetworkNavigationComponent;
			if (this.BlackBoard.WaitingModelBuffer && roadNetworkNavigationComponent.HasModelBuffer())
			{
				return true;
			}
			this.BlackBoard.WaitingModelBuffer = false;
			bool flag = roadNetworkNavigationComponent.WasRecentlyRenderedOnScreen();
			if (flag && !this.BlackBoard.LastRenderOnScreen && roadNetworkNavigationComponent.HasModelBuffer())
			{
				this.BlackBoard.WaitingModelBuffer = true;
			}
			this.BlackBoard.LastRenderOnScreen = flag;
			return this.BlackBoard.WaitingModelBuffer;
		}

		// Token: 0x06032ED7 RID: 208599 RVA: 0x00CC26B2 File Offset: 0x00CC08B2
		private void UpdateActorLocationAndRotation(ETickType tickType, float delta, int tickInterval)
		{
			this.BlackBoard.RoadNetworkNavigationComponent.SetLocationAndRotation(this.BlackBoard.DesireLocation.ToUeVector(false), this.BlackBoard.DesireRotator.ToUeRotator(), tickType, delta, tickInterval);
		}

		// Token: 0x06032ED8 RID: 208600 RVA: 0x00CC26E8 File Offset: 0x00CC08E8
		[NullableContext(2)]
		private bool SwitchState(EVehicleStateType state, string reason = null)
		{
			return this.StateMachine.Switch(state, reason);
		}

		// Token: 0x06032ED9 RID: 208601 RVA: 0x00CC26F7 File Offset: 0x00CC08F7
		public float GetCurrentRootDistance()
		{
			return this.BlackBoard.CurrentRootDistance;
		}

		// Token: 0x06032EDA RID: 208602 RVA: 0x00CC2704 File Offset: 0x00CC0904
		public float GetCurrentMeshCenterDistance()
		{
			return this.BlackBoard.CurrentMeshCenterDistance;
		}

		// Token: 0x06032EDB RID: 208603 RVA: 0x00CC2711 File Offset: 0x00CC0911
		public float GetCurrentMeshHeadDistance()
		{
			return this.BlackBoard.CurrentMeshHeadDistance;
		}

		// Token: 0x06032EDC RID: 208604 RVA: 0x00CC271E File Offset: 0x00CC091E
		public float GetCurrentMeshTailDistance()
		{
			return this.BlackBoard.CurrentMeshTailDistance;
		}

		// Token: 0x06032EDD RID: 208605 RVA: 0x00CC272B File Offset: 0x00CC092B
		public global::Vector GetRelativeLocation()
		{
			return this.BlackBoard.RelativeLocationToStart;
		}

		// Token: 0x06032EDE RID: 208606 RVA: 0x00CC2738 File Offset: 0x00CC0938
		public global::Vector GetDesireLocation()
		{
			return this.BlackBoard.DesireLocation;
		}

		// Token: 0x06032EDF RID: 208607 RVA: 0x00CC2745 File Offset: 0x00CC0945
		public global::Rotator GetDesireRotator()
		{
			return this.BlackBoard.DesireRotator;
		}

		// Token: 0x06032EE0 RID: 208608 RVA: 0x00CC2752 File Offset: 0x00CC0952
		public global::Vector GetVehicleSize()
		{
			return this.BlackBoard.VehicleSize;
		}

		// Token: 0x06032EE1 RID: 208609 RVA: 0x00CC275F File Offset: 0x00CC095F
		public float GetMeshCenterToTail()
		{
			return this.BlackBoard.MeshCenterToTail;
		}

		// Token: 0x06032EE2 RID: 208610 RVA: 0x00CC276C File Offset: 0x00CC096C
		public float GetSpeed()
		{
			return this.BlackBoard.CurrentSpeed;
		}

		// Token: 0x06032EE3 RID: 208611 RVA: 0x00CC2779 File Offset: 0x00CC0979
		public EEntityType? GetBlockTarget()
		{
			return this.BlackBoard.BlockTarget;
		}

		// Token: 0x06032EE4 RID: 208612 RVA: 0x00CC2786 File Offset: 0x00CC0986
		public bool IsInBrakeState()
		{
			return this.StateMachine.GetCurrentState() == EVehicleStateType.Braking;
		}

		// Token: 0x0401DA58 RID: 121432
		private readonly VehicleStateMachine StateMachine = new VehicleStateMachine();

		// Token: 0x0401DA59 RID: 121433
		[Nullable(2)]
		private readonly VehicleSmBlackBoard BlackBoard;
	}
}
