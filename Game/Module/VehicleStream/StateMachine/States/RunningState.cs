using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.VehicleStream.StateMachineContainer;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream.StateMachine.States
{
	// Token: 0x02004C56 RID: 19542
	[NullableContext(1)]
	[Nullable(0)]
	public class RunningState : VehicleStateBase
	{
		// Token: 0x06032E8A RID: 208522 RVA: 0x00CC05B8 File Offset: 0x00CBE7B8
		public RunningState(VehicleSmBlackBoard blackBoard) : base(EVehicleStateType.Running, blackBoard)
		{
		}

		// Token: 0x06032E8B RID: 208523 RVA: 0x00CC0637 File Offset: 0x00CBE837
		protected override void OnCreate()
		{
		}

		// Token: 0x06032E8C RID: 208524 RVA: 0x00CC063C File Offset: 0x00CBE83C
		[NullableContext(2)]
		protected override void OnEnter(EVehicleStateType lastState, string reason = null)
		{
			this.BlackBoard.CurrentAcceleratedSpeed = this.BlackBoard.AcceleratedSpeedConfig;
			this.SubState = ERunningSubState.Normal;
			if (this.BlackBoard.EngineAudio != null && this.EngineAudioHandle == 0)
			{
				this.EngineAudioHandle = this.BlackBoard.OpenAudio(this.BlackBoard.EngineAudio, true);
			}
		}

		// Token: 0x06032E8D RID: 208525 RVA: 0x00CC0698 File Offset: 0x00CBE898
		protected override void OnExit(EVehicleStateType nextState)
		{
			this.SubState = ERunningSubState.None;
			this.BlackBoard.StopAudio(this.BrakingAudioHandle, true);
			this.BrakingAudioHandle = 0;
		}

		// Token: 0x06032E8E RID: 208526 RVA: 0x00CC06BA File Offset: 0x00CBE8BA
		protected override void OnDestroy()
		{
			this.BlackBoard.StopAudio(this.EngineAudioHandle, true);
			this.EngineAudioHandle = 0;
		}

		// Token: 0x06032E8F RID: 208527 RVA: 0x00CC06D5 File Offset: 0x00CBE8D5
		public new void OnEnterPlayerRange()
		{
			if (this.BlackBoard.EngineAudio != null && this.EngineAudioHandle == 0)
			{
				this.EngineAudioHandle = this.BlackBoard.OpenAudio(this.BlackBoard.EngineAudio, true);
			}
		}

		// Token: 0x06032E90 RID: 208528 RVA: 0x00CC0709 File Offset: 0x00CBE909
		public new void OnLeavePlayerRange()
		{
			this.BlackBoard.StopAudio(this.EngineAudioHandle, true);
			this.EngineAudioHandle = 0;
		}

		// Token: 0x06032E91 RID: 208529 RVA: 0x00CC0724 File Offset: 0x00CBE924
		protected override void OnUpdate(float delta)
		{
			if (this.UpdateMove(delta))
			{
				this.UpdateDesireLocationAndRotation();
			}
			this.SyncKeyPointToServer();
			EVehicleStateType evehicleStateType = this.CheckGetNextState();
			if (evehicleStateType != EVehicleStateType.None)
			{
				this.BlackBoard.SwitchState(evehicleStateType, this.MoveInfo.BeforeMoveCheckResult.ToEnumString());
			}
		}

		// Token: 0x06032E92 RID: 208530 RVA: 0x00CC076D File Offset: 0x00CBE96D
		protected override EVehicleStateType CheckGetNextState()
		{
			if (this.BlackBoard.CheckArrivedDestination())
			{
				return EVehicleStateType.Destroy;
			}
			if (this.BlackBoard.CurrentSpeed <= 0f)
			{
				return EVehicleStateType.Braking;
			}
			return EVehicleStateType.None;
		}

		// Token: 0x06032E93 RID: 208531 RVA: 0x00CC0794 File Offset: 0x00CBE994
		private bool UpdateMove(float delta)
		{
			this.CheckUpdateRoadway();
			this.OnBeforeMove();
			if (this.BlackBoard.WaitingModelBuffer)
			{
				this.SubState = ERunningSubState.WaitingModelBuffer;
				return false;
			}
			if (this.SubState == ERunningSubState.None)
			{
				return false;
			}
			this.UpdateSpeed(delta);
			if (this.BlackBoard.CurrentSpeed == 0f)
			{
				return false;
			}
			bool result = this.UpdateMoveImp(delta);
			this.PredictedVariableSpeed();
			bool enableDebug = ModelBase<VehicleStreamModel>.Instance.EnableDebug;
			return result;
		}

		// Token: 0x06032E94 RID: 208532 RVA: 0x00CC0804 File Offset: 0x00CBEA04
		private bool CheckUpdateRoadway()
		{
			float num = this.BlackBoard.CurrentSplineLength - this.BlackBoard.CurrentRootDistance;
			int num2 = 10;
			if (num > (float)num2)
			{
				return false;
			}
			base.EnterNextRoadway();
			return true;
		}

		// Token: 0x06032E95 RID: 208533 RVA: 0x00CC0838 File Offset: 0x00CBEA38
		private void OnBeforeMove()
		{
			EMoveCheckResult beforeMoveCheckResult = this.MoveInfo.BeforeMoveCheckResult;
			this.MoveInfo.Reset();
			EMoveCheckResult moveCheckResult = this.BeforeMoveCheck(this.BlackBoard.CurrentRootDistance);
			this.DoByBeforeMoveCheckResult(beforeMoveCheckResult, moveCheckResult);
		}

		// Token: 0x06032E96 RID: 208534 RVA: 0x00CC0878 File Offset: 0x00CBEA78
		private void UpdateSpeed(float delta)
		{
			float currentSpeed = (float)MathCommon.Clamp((double)this.BlackBoard.CurrentSpeed + (double)(this.BlackBoard.CurrentAcceleratedSpeed * delta) * Singleton<TimeUtil>.Instance.Millisecond, 0.0, (double)this.BlackBoard.NormalSpeed);
			this.BlackBoard.CurrentSpeed = currentSpeed;
		}

		// Token: 0x06032E97 RID: 208535 RVA: 0x00CC08D4 File Offset: 0x00CBEAD4
		private bool UpdateMoveImp(float delta)
		{
			float currentRootDistance = this.BlackBoard.CurrentRootDistance;
			double num = (double)delta * Singleton<TimeUtil>.Instance.Millisecond * (double)this.BlackBoard.CurrentSpeed * 100.0;
			float num2 = (float)Math.Min((double)currentRootDistance + num, (double)this.BlackBoard.CurrentSplineLength);
			this.MoveInfo.AfterMoveCheckResult = this.AfterMoveCheck(currentRootDistance, num2);
			float val = num2;
			if (this.MoveInfo.AfterMoveCheckResult != EMoveCheckResult.None)
			{
				val = this.MoveInfo.AfterMoveCheckInfo.AfterAdjustDistance;
			}
			this.BlackBoard.CurrentRootDistance = Math.Min(val, this.BlackBoard.CurrentSplineLength);
			return currentRootDistance != this.BlackBoard.CurrentRootDistance;
		}

		// Token: 0x06032E98 RID: 208536 RVA: 0x00CC098C File Offset: 0x00CBEB8C
		private EMoveCheckResult BeforeMoveCheck(float curRootDistance)
		{
			string text = base.CheckObstruction(curRootDistance, "VehicleStream.Running");
			if (text != EObstructionCheckResult.None.ToEnumString())
			{
				return (EMoveCheckResult)Enum.Parse(typeof(EMoveCheckResult), text);
			}
			if (this.CheckWillArriveIntersection())
			{
				return EMoveCheckResult.Intersection;
			}
			return EMoveCheckResult.None;
		}

		// Token: 0x06032E99 RID: 208537 RVA: 0x00CC09D8 File Offset: 0x00CBEBD8
		private bool CheckWillArriveIntersection()
		{
			UKuroRoadway nextRoadway = this.BlackBoard.NextRoadway;
			return nextRoadway != null && nextRoadway is UKuroRoadwayIntersection && ModelBase<VehicleStreamModel>.Instance.CheckIntersectionRoadwayOccupied(nextRoadway.Id) && (this.BlackBoard.CurrentSplineLength - this.BlackBoard.CurrentRootHeadDistance) * 0.01f <= 5f;
		}

		// Token: 0x06032E9A RID: 208538 RVA: 0x00CC0A38 File Offset: 0x00CBEC38
		private void DoByBeforeMoveCheckResult(EMoveCheckResult lastMoveCheckResult, EMoveCheckResult moveCheckResult)
		{
			this.MoveInfo.BeforeMoveCheckResult = moveCheckResult;
			switch (moveCheckResult)
			{
			case EMoveCheckResult.None:
				this.SubState = ERunningSubState.Normal;
				this.BlackBoard.CurrentAcceleratedSpeed = this.BlackBoard.AcceleratedSpeedConfig;
				if (this.BrakingAudioHandle != 0 && this.IsBrakingLoop)
				{
					this.BlackBoard.StopAudio(this.BrakingAudioHandle, true);
				}
				this.BrakingAudioHandle = 0;
				this.BlackBoard.BlockTarget = null;
				break;
			case EMoveCheckResult.TraceBlock:
			case EMoveCheckResult.CheckPlayerBlock:
			case EMoveCheckResult.SameRoadwayVehicleBlock:
			case EMoveCheckResult.NextRoadwayVehicleBlock:
			{
				this.BlackBoard.BlockTarget = this.ObstructionCheckInfo.HitEntityType;
				this.SubState = ERunningSubState.BrakingByObstruction;
				this.MoveInfo.BrakingDistance = Math.Max(this.ObstructionCheckInfo.HitDistance - this.ObstructionCheckInfo.DistanceToKeep, 0.1f);
				float num = this.CalculateAcceleratedSpeedByBrakingDistance(this.MoveInfo.BrakingDistance);
				num = Math.Min(num, -1f);
				if (num < this.BlackBoard.CurrentAcceleratedSpeed)
				{
					this.BlackBoard.CurrentAcceleratedSpeed = num;
				}
				break;
			}
			case EMoveCheckResult.Intersection:
				this.BlackBoard.BlockTarget = null;
				if (this.SubState != ERunningSubState.BrakingByIntersection)
				{
					this.SubState = ERunningSubState.BrakingByIntersection;
					float val = (this.BlackBoard.CurrentSplineLength - this.BlackBoard.CurrentRootHeadDistance) * 0.01f;
					this.MoveInfo.BrakingDistance = Math.Max(val, 0.1f);
					this.BlackBoard.CurrentAcceleratedSpeed = this.CalculateAcceleratedSpeedByBrakingDistance(this.MoveInfo.BrakingDistance);
				}
				break;
			}
			if (moveCheckResult != EMoveCheckResult.None)
			{
				this.PlayBrakingAudio(this.MoveInfo.BrakingDistance);
			}
			bool enableDebug = ModelBase<VehicleStreamModel>.Instance.EnableDebug;
			bool flag = lastMoveCheckResult == EMoveCheckResult.TraceBlock && moveCheckResult != EMoveCheckResult.TraceBlock;
			bool flag2 = lastMoveCheckResult != EMoveCheckResult.TraceBlock && moveCheckResult == EMoveCheckResult.TraceBlock;
			if (flag2 || flag)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget<bool>(this.BlackBoard.RoadNetworkNavigationComponent, EEventName.VehicleMemberBlockByTraceTarget, flag2);
			}
		}

		// Token: 0x06032E9B RID: 208539 RVA: 0x00CC0C1F File Offset: 0x00CBEE1F
		private EMoveCheckResult AfterMoveCheck(float beforeMoveRootDistance, float afterMoveRootDistance)
		{
			this.CheckCrossPlayer(beforeMoveRootDistance, afterMoveRootDistance);
			this.CheckCrossSameRoadwayVehicle(beforeMoveRootDistance, afterMoveRootDistance);
			this.CheckCrossNextRoadwayVehicle(beforeMoveRootDistance, afterMoveRootDistance);
			this.CheckVehicleHeadOverRoadOnWaitIntersection(afterMoveRootDistance);
			return this.MoveInfo.AfterMoveCheckInfo.Result;
		}

		// Token: 0x06032E9C RID: 208540 RVA: 0x00CC0C50 File Offset: 0x00CBEE50
		private void CheckCrossPlayer(float beforeMoveRootDistance, float afterMoveRootDistance)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (!this.BlackBoard.IsInPlayerRange || this.BlackBoard.RoadNetworkNavigationComponent.WasRecentlyRenderedOnScreen() || characterActorComponent == null)
			{
				return;
			}
			EEntityType? blockTarget = this.BlackBoard.BlockTarget;
			EEntityType eentityType = EEntityType.Player;
			if (blockTarget.GetValueOrDefault() == eentityType & blockTarget != null)
			{
				return;
			}
			UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
			USplineComponent usplineComponent = (currentRoadway != null) ? currentRoadway.RoadSpline : null;
			if (usplineComponent == null)
			{
				return;
			}
			FVectorDouble actorLocation = characterActorComponent.ActorLocation;
			float num;
			if (this.ObstructionCheckInfo.PlayerHitDistance == 0f)
			{
				num = (float)(usplineComponent.D_GetTransformAtDistanceAlongSpline(afterMoveRootDistance, ESplineCoordinateSpace.World, false).InverseTransformPosition(actorLocation).X - (double)this.BlackBoard.RootCenterToHead) * 0.01f;
			}
			else
			{
				num = this.ObstructionCheckInfo.PlayerHitDistance;
			}
			if (num <= 0f)
			{
				return;
			}
			if ((float)(usplineComponent.D_GetTransformAtDistanceAlongSpline(afterMoveRootDistance, ESplineCoordinateSpace.World, false).InverseTransformPosition(actorLocation).X - (double)this.BlackBoard.RootCenterToHead) * 0.01f >= 0f)
			{
				return;
			}
			float inKey = usplineComponent.D_FindInputKeyClosestToWorldLocation(actorLocation);
			float distanceAlongSplineAtSplineInputKey = usplineComponent.GetDistanceAlongSplineAtSplineInputKey(inKey);
			float num2 = 500f + this.BlackBoard.RootCenterToHead;
			float afterAdjustDistance = Math.Max(distanceAlongSplineAtSplineInputKey - num2, beforeMoveRootDistance);
			this.MoveInfo.TryUpdateAdjustDistance(EMoveCheckResult.CrossPlayer, afterAdjustDistance);
		}

		// Token: 0x06032E9D RID: 208541 RVA: 0x00CC0DAC File Offset: 0x00CBEFAC
		private unsafe void CheckCrossSameRoadwayVehicle(float beforeMoveRootDistance, float afterMoveRootDistance)
		{
			UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
			if (currentRoadway == null)
			{
				return;
			}
			VehicleStreamModel instance = ModelBase<VehicleStreamModel>.Instance;
			HashSet<long> allVehicleInRoadway = instance.GetAllVehicleInRoadway(currentRoadway.Id);
			if (allVehicleInRoadway == null)
			{
				return;
			}
			bool flag = false;
			float num = afterMoveRootDistance;
			foreach (long num2 in allVehicleInRoadway)
			{
				if (num2 != this.BlackBoard.CreatureDataId)
				{
					VehicleTeamMember vehicleTeamMember = instance.GetVehicleTeamMember(num2);
					if (vehicleTeamMember != null && Math.Abs(vehicleTeamMember.GetRelativeLocation().Y - this.BlackBoard.RelativeLocationToStart.Y) <= (vehicleTeamMember.GetVehicleSize().Y + this.BlackBoard.VehicleSize.Y) * 0.5)
					{
						EPositionRelationship epositionRelationship = base.CheckPositionalRelationshipToTarget(beforeMoveRootDistance, vehicleTeamMember.GetCurrentMeshHeadDistance(), vehicleTeamMember.GetCurrentMeshTailDistance());
						bool flag2 = true;
						if (epositionRelationship != EPositionRelationship.OverlapBehind)
						{
							if (epositionRelationship - EPositionRelationship.CompleteOverlap <= 2)
							{
								flag2 = false;
							}
						}
						else
						{
							flag = true;
							if (beforeMoveRootDistance < num)
							{
								num = beforeMoveRootDistance;
							}
							flag2 = false;
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module = ELogModule.VehicleStream;
							ELogAuthor author = ELogAuthor.YSQ;
							string message = "发现载具重叠";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SelfCreatureDataId", this.BlackBoard.CreatureDataId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetCreatureDataId", this.BlackBoard.CreatureDataId);
							instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						if (flag2)
						{
							switch (base.CheckPositionalRelationshipToTarget(afterMoveRootDistance, vehicleTeamMember.GetCurrentMeshHeadDistance(), vehicleTeamMember.GetCurrentMeshTailDistance()))
							{
							case EPositionRelationship.OverlapBehind:
							case EPositionRelationship.OverlapForward:
							case EPositionRelationship.Forward:
							{
								flag = true;
								float currentMeshCenterDistance = vehicleTeamMember.GetCurrentMeshCenterDistance();
								float num3 = this.BlackBoard.RootCenterToHead + vehicleTeamMember.GetMeshCenterToTail();
								float num4 = 300f + num3;
								if (currentMeshCenterDistance - beforeMoveRootDistance > num4)
								{
									int num5 = 100;
									float num6 = currentMeshCenterDistance - num4 + (float)num5;
									if (num6 < num)
									{
										num = num6;
									}
								}
								break;
							}
							}
						}
					}
				}
			}
			if (flag)
			{
				this.MoveInfo.TryUpdateAdjustDistance(EMoveCheckResult.CrossSameRoadwayVehicle, num);
			}
		}

		// Token: 0x06032E9E RID: 208542 RVA: 0x00CC0FF4 File Offset: 0x00CBF1F4
		private void CheckCrossNextRoadwayVehicle(float beforeMoveRootDistance, float afterMoveRootDistance)
		{
			UKuroRoadway nextRoadway = this.BlackBoard.NextRoadway;
			if (nextRoadway == null)
			{
				return;
			}
			VehicleStreamModel instance = ModelBase<VehicleStreamModel>.Instance;
			HashSet<long> allVehicleInRoadway = instance.GetAllVehicleInRoadway(nextRoadway.Id);
			if (allVehicleInRoadway == null)
			{
				return;
			}
			bool flag = false;
			float num = afterMoveRootDistance;
			foreach (long num2 in allVehicleInRoadway)
			{
				if (num2 != this.BlackBoard.CreatureDataId)
				{
					VehicleTeamMember vehicleTeamMember = instance.GetVehicleTeamMember(num2);
					if (vehicleTeamMember != null && Math.Abs(vehicleTeamMember.GetRelativeLocation().Y - this.BlackBoard.RelativeLocationToStart.Y) <= (vehicleTeamMember.GetVehicleSize().Y + this.BlackBoard.VehicleSize.Y) * 0.5)
					{
						float currentSplineLength = this.BlackBoard.CurrentSplineLength;
						switch (base.CheckPositionalRelationshipToTarget(afterMoveRootDistance, currentSplineLength + vehicleTeamMember.GetCurrentMeshHeadDistance(), currentSplineLength + vehicleTeamMember.GetCurrentMeshTailDistance()))
						{
						case EPositionRelationship.OverlapBehind:
						case EPositionRelationship.OverlapForward:
						case EPositionRelationship.Forward:
						{
							flag = true;
							float currentMeshCenterDistance = vehicleTeamMember.GetCurrentMeshCenterDistance();
							float num3 = currentSplineLength - beforeMoveRootDistance;
							float num4 = this.BlackBoard.RootCenterToHead + vehicleTeamMember.GetMeshCenterToTail();
							float num5 = 600f + num4;
							if (currentMeshCenterDistance + num3 > num5)
							{
								float num6 = currentMeshCenterDistance - num5;
								if (num6 < 0f)
								{
									num6 += currentSplineLength;
								}
								if (num6 < num)
								{
									num = num6;
								}
							}
							break;
						}
						}
					}
				}
			}
			if (flag)
			{
				this.MoveInfo.TryUpdateAdjustDistance(EMoveCheckResult.CrossNextRoadwayVehicle, num);
			}
		}

		// Token: 0x06032E9F RID: 208543 RVA: 0x00CC11A0 File Offset: 0x00CBF3A0
		private void CheckVehicleHeadOverRoadOnWaitIntersection(float afterMoveRootDistance)
		{
			UKuroRoadway nextRoadway = this.BlackBoard.NextRoadway;
			if (nextRoadway == null || !(nextRoadway is UKuroRoadwayIntersection))
			{
				return;
			}
			if (!ModelBase<VehicleStreamModel>.Instance.CheckIntersectionRoadwayOccupied(nextRoadway.Id))
			{
				return;
			}
			float rootCenterToHead = this.BlackBoard.RootCenterToHead;
			if (afterMoveRootDistance + rootCenterToHead >= this.BlackBoard.CurrentSplineLength && this.SubState != ERunningSubState.BrakingByIntersection)
			{
				float afterAdjustDistance = this.BlackBoard.CurrentSplineLength - rootCenterToHead;
				this.MoveInfo.TryUpdateAdjustDistance(EMoveCheckResult.HeadOverRoadOnWaitIntersection, afterAdjustDistance);
			}
		}

		// Token: 0x06032EA0 RID: 208544 RVA: 0x00CC1219 File Offset: 0x00CBF419
		private void PredictedVariableSpeed()
		{
			if (this.SubState == ERunningSubState.BrakingByIntersection || this.SubState == ERunningSubState.BrakingByObstruction)
			{
				return;
			}
			this.CheckSlowDownByTurn();
			this.CheckSlowDownByUpSlope();
			this.CheckSpeedUpByDownSlope();
		}

		// Token: 0x06032EA1 RID: 208545 RVA: 0x00CC1240 File Offset: 0x00CBF440
		private void CheckSlowDownByTurn()
		{
		}

		// Token: 0x06032EA2 RID: 208546 RVA: 0x00CC1242 File Offset: 0x00CBF442
		private void CheckSlowDownByUpSlope()
		{
		}

		// Token: 0x06032EA3 RID: 208547 RVA: 0x00CC1244 File Offset: 0x00CBF444
		private void CheckSpeedUpByDownSlope()
		{
		}

		// Token: 0x06032EA4 RID: 208548 RVA: 0x00CC1248 File Offset: 0x00CBF448
		private void UpdateDesireLocationAndRotation()
		{
			UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
			if (currentRoadway == null)
			{
				return;
			}
			UKuroRoadway lastRoadway = this.BlackBoard.LastRoadway;
			bool flag = ((lastRoadway != null) ? lastRoadway.RoadSpline : null) != null || this.BlackBoard.CurrentRootTailDistance >= 0f;
			if (ModelBase<VehicleStreamModel>.Instance.EnableRotationOptimize && flag)
			{
				this.BlackBoard.GetHeadDistanceAndRoadway(this.BlackBoard.CurrentRootDistance, this.TmpDistanceAndRoadway);
				if (!this.GetLocationWithRelativePosition(this.TmpDistanceAndRoadway.Roadway, this.TmpDistanceAndRoadway.Distance, this.CurrentHeadLocation))
				{
					return;
				}
				this.BlackBoard.GetTailDistanceAndRoadway(this.BlackBoard.CurrentRootDistance, this.TmpDistanceAndRoadway);
				if (!this.GetLocationWithRelativePosition(this.TmpDistanceAndRoadway.Roadway, this.TmpDistanceAndRoadway.Distance, this.CurrentTailLocation))
				{
					return;
				}
				this.CurrentHeadLocation.Subtraction(this.CurrentTailLocation, this.CurrentDirection);
				this.CurrentDirection.Normalize(9.99999993922529E-09);
				this.CurrentDirection.Rotation(this.CurrentRotator);
				this.BlackBoard.DesireRotator.DeepCopy(this.CurrentRotator);
				this.CurrentDirection.Multiply((double)this.BlackBoard.RootCenterToTail, this.CurrentTail2Center);
				this.CurrentTailLocation.Addition(this.CurrentTail2Center, this.CurrentLocation);
				this.BlackBoard.DesireLocation.DeepCopy(this.CurrentLocation);
				this.BlackBoard.UpdateMoved = true;
				return;
			}
			else
			{
				USplineComponent roadSpline = currentRoadway.RoadSpline;
				FTransformDouble? ftransformDouble = (roadSpline != null) ? new FTransformDouble?(roadSpline.D_GetTransformAtDistanceAlongSpline(this.BlackBoard.CurrentRootDistance, ESplineCoordinateSpace.World, false)) : null;
				if (ftransformDouble == null)
				{
					return;
				}
				FTransformDouble value = ftransformDouble.Value;
				FVectorDouble fvectorDouble = this.BlackBoard.RelativeLocationToStartWithoutX.ToUeVector(false);
				FVectorDouble fvectorDouble2 = value.TransformPositionNoScale(fvectorDouble);
				this.BlackBoard.DesireLocation.DeepCopy(fvectorDouble2);
				global::Rotator desireRotator = this.BlackBoard.DesireRotator;
				FRotator frotator = ftransformDouble.Value.GetRotation().Rotator();
				desireRotator.DeepCopy(frotator);
				this.BlackBoard.UpdateMoved = true;
				return;
			}
		}

		// Token: 0x06032EA5 RID: 208549 RVA: 0x00CC1484 File Offset: 0x00CBF684
		private void SyncKeyPointToServer()
		{
			int num = -1;
			for (int i = 0; i < this.BlackBoard.KeyPointDistances.Count; i++)
			{
				float num2 = this.BlackBoard.KeyPointDistances[i];
				if (!this.BlackBoard.KeyPointDistanceSyncRecord.GetValueOrDefault(i, false) && this.BlackBoard.CurrentMeshHeadDistance >= num2)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				this.BlackBoard.KeyPointDistanceSyncRecord[num] = true;
				VehicleStreamController instance = ControllerBase<VehicleStreamController>.Instance;
				long creatureDataId = this.BlackBoard.CreatureDataId;
				UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
				instance.RequestNetworkEntityUpdateCurRoadPush(creatureDataId, (currentRoadway != null) ? currentRoadway.Id : 0, num);
			}
		}

		// Token: 0x06032EA6 RID: 208550 RVA: 0x00CC152C File Offset: 0x00CBF72C
		private bool GetLocationWithRelativePosition([Nullable(2)] UKuroRoadway roadway, float distance, global::Vector outVector)
		{
			if (roadway == null)
			{
				return false;
			}
			USplineComponent roadSpline = roadway.RoadSpline;
			FTransformDouble? ftransformDouble = (roadSpline != null) ? new FTransformDouble?(roadSpline.D_GetTransformAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World, false)) : null;
			if (ftransformDouble == null)
			{
				return false;
			}
			FTransformDouble value = ftransformDouble.Value;
			FVectorDouble fvectorDouble = this.BlackBoard.RelativeLocationToStartWithoutX.ToUeVector(false);
			FVectorDouble fvectorDouble2 = value.TransformPositionNoScale(fvectorDouble);
			outVector.DeepCopy(fvectorDouble2);
			return true;
		}

		// Token: 0x06032EA7 RID: 208551 RVA: 0x00CC159A File Offset: 0x00CBF79A
		private float CalculateAcceleratedSpeedByBrakingDistance(float brakingDistance)
		{
			return -(this.BlackBoard.CurrentSpeed * this.BlackBoard.CurrentSpeed) / (2f * brakingDistance);
		}

		// Token: 0x06032EA8 RID: 208552 RVA: 0x00CC15BC File Offset: 0x00CBF7BC
		private void PlayBrakingAudio(float brakingDistance)
		{
			this.IsBrakingLoop = (brakingDistance > 0.1f);
			string text = this.IsBrakingLoop ? this.BlackBoard.BrakingAudio : this.BlackBoard.BrakingShortAudio;
			if (text == null || this.BrakingAudioHandle != 0)
			{
				return;
			}
			this.BrakingAudioHandle = this.BlackBoard.OpenAudio(text, this.IsBrakingLoop);
		}

		// Token: 0x0401DA40 RID: 121408
		private ERunningSubState SubState;

		// Token: 0x0401DA41 RID: 121409
		private readonly MoveCheckInfo MoveInfo = new MoveCheckInfo();

		// Token: 0x0401DA42 RID: 121410
		private readonly global::Vector CurrentHeadLocation = global::Vector.Create();

		// Token: 0x0401DA43 RID: 121411
		private readonly global::Vector CurrentTailLocation = global::Vector.Create();

		// Token: 0x0401DA44 RID: 121412
		private readonly global::Vector CurrentDirection = global::Vector.Create();

		// Token: 0x0401DA45 RID: 121413
		private readonly global::Rotator CurrentRotator = global::Rotator.Create();

		// Token: 0x0401DA46 RID: 121414
		private readonly global::Vector CurrentTail2Center = global::Vector.Create();

		// Token: 0x0401DA47 RID: 121415
		private readonly global::Vector CurrentLocation = global::Vector.Create();

		// Token: 0x0401DA48 RID: 121416
		private readonly IDistanceAndRoadway TmpDistanceAndRoadway = new DistanceAndRoadway
		{
			Distance = 0f,
			Roadway = null
		};

		// Token: 0x0401DA49 RID: 121417
		private int EngineAudioHandle;

		// Token: 0x0401DA4A RID: 121418
		private int BrakingAudioHandle;

		// Token: 0x0401DA4B RID: 121419
		private bool IsBrakingLoop;
	}
}
