using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.VehicleStream.StateMachineContainer;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream.StateMachine.States
{
	// Token: 0x02004C53 RID: 19539
	[NullableContext(1)]
	[Nullable(0)]
	public class BornState : VehicleStateBase
	{
		// Token: 0x06032E7A RID: 208506 RVA: 0x00CBFF1F File Offset: 0x00CBE11F
		public BornState(VehicleSmBlackBoard blackBoard) : base(EVehicleStateType.Born, blackBoard)
		{
		}

		// Token: 0x06032E7B RID: 208507 RVA: 0x00CBFF2C File Offset: 0x00CBE12C
		[NullableContext(2)]
		protected unsafe override void OnEnter(EVehicleStateType lastState, string reason = null)
		{
			base.EnterNextRoadway();
			this.CalculateStartPointInfo();
			this.CalculateEndPointInfo();
			List<long> list = this.CheckSameRoadwayVehicleOverlap(this.BlackBoard.CurrentRootDistance);
			if (list != null && list.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.VehicleStream;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "载具出生时与其他载具重叠";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("selfCreatureDataId", this.BlackBoard.CreatureDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("重叠载具", list);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06032E7C RID: 208508 RVA: 0x00CBFFD0 File Offset: 0x00CBE1D0
		protected unsafe override void OnUpdate(float delta)
		{
			EVehicleStateType evehicleStateType = this.CheckGetNextState();
			if (evehicleStateType != EVehicleStateType.None)
			{
				List<long> list = this.CheckSameRoadwayVehicleOverlap(this.BlackBoard.CurrentRootDistance);
				if (list != null && list.Count > 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.VehicleStream;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "载具启动时与其他载具重叠";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("selfCreatureDataId", this.BlackBoard.CreatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("重叠载具", list);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				this.BlackBoard.SwitchState(evehicleStateType, null);
			}
		}

		// Token: 0x06032E7D RID: 208509 RVA: 0x00CC007B File Offset: 0x00CBE27B
		protected override void OnExit(EVehicleStateType nextState)
		{
			this.InitAudio();
		}

		// Token: 0x06032E7E RID: 208510 RVA: 0x00CC0083 File Offset: 0x00CBE283
		protected override EVehicleStateType CheckGetNextState()
		{
			if (!this.BlackBoard.IsLaunch)
			{
				return EVehicleStateType.None;
			}
			return EVehicleStateType.Running;
		}

		// Token: 0x06032E7F RID: 208511 RVA: 0x00CC0098 File Offset: 0x00CBE298
		[NullableContext(2)]
		private List<long> CheckSameRoadwayVehicleOverlap(float currentFrameRootDistance)
		{
			UKuroRoadway currentRoadway = this.BlackBoard.CurrentRoadway;
			if (currentRoadway == null)
			{
				return null;
			}
			VehicleStreamModel instance = ModelBase<VehicleStreamModel>.Instance;
			HashSet<long> allVehicleInRoadway = instance.GetAllVehicleInRoadway(currentRoadway.Id);
			if (allVehicleInRoadway == null)
			{
				return null;
			}
			List<long> list = new List<long>();
			foreach (long num in allVehicleInRoadway)
			{
				if (num != this.BlackBoard.CreatureDataId)
				{
					VehicleTeamMember vehicleTeamMember = instance.GetVehicleTeamMember(num);
					if (vehicleTeamMember != null && Math.Abs(vehicleTeamMember.GetRelativeLocation().Y - this.BlackBoard.RelativeLocationToStart.Y) <= (vehicleTeamMember.GetVehicleSize().Y + this.BlackBoard.VehicleSize.Y) * 0.5)
					{
						EPositionRelationship epositionRelationship = base.CheckPositionalRelationshipToTarget(currentFrameRootDistance, vehicleTeamMember.GetCurrentMeshHeadDistance(), vehicleTeamMember.GetCurrentMeshTailDistance());
						if (epositionRelationship == EPositionRelationship.OverlapBehind || epositionRelationship == EPositionRelationship.OverlapForward)
						{
							list.Add(num);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06032E80 RID: 208512 RVA: 0x00CC01AC File Offset: 0x00CBE3AC
		private void CalculateStartPointInfo()
		{
			UKuroRoadway startRoadway = this.BlackBoard.StartRoadway;
			if (((startRoadway != null) ? startRoadway.RoadSpline : null) == null)
			{
				return;
			}
			USplineComponent roadSpline = startRoadway.RoadSpline;
			FVectorDouble fvectorDouble = this.BlackBoard.StartActorLocation.ToUeVector(false);
			float inKey = roadSpline.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
			FTransformDouble ftransformDouble = startRoadway.RoadSpline.D_GetTransformAtSplineInputKey(inKey, ESplineCoordinateSpace.Local, false);
			fvectorDouble = this.BlackBoard.StartActorLocation.ToUeVector(false);
			FVectorDouble fvectorDouble2 = ftransformDouble.InverseTransformPosition(fvectorDouble);
			this.BlackBoard.RelativeLocationToStart.DeepCopy(fvectorDouble2);
			this.CheckAndSetZero(this.BlackBoard.RelativeLocationToStart);
			this.BlackBoard.RelativeLocationToStartWithoutX.DeepCopy(this.BlackBoard.RelativeLocationToStart);
			this.BlackBoard.RelativeLocationToStartWithoutX.X = 0.0;
			this.BlackBoard.CurrentSplineLength = startRoadway.RoadSpline.GetSplineLength();
			this.BlackBoard.CurrentRootDistance = startRoadway.RoadSpline.GetDistanceAlongSplineAtSplineInputKey(inKey);
		}

		// Token: 0x06032E81 RID: 208513 RVA: 0x00CC02A8 File Offset: 0x00CBE4A8
		private void CalculateEndPointInfo()
		{
			UKuroRoadway endRoadway = this.BlackBoard.EndRoadway;
			if (((endRoadway != null) ? endRoadway.RoadSpline : null) == null)
			{
				return;
			}
			USplineComponent roadSpline = endRoadway.RoadSpline;
			FVectorDouble fvectorDouble = this.BlackBoard.EndLocationInRoad.ToUeVector(false);
			float inKey = roadSpline.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
			this.BlackBoard.EndPointInSplineDistance = endRoadway.RoadSpline.GetDistanceAlongSplineAtSplineInputKey(inKey);
		}

		// Token: 0x06032E82 RID: 208514 RVA: 0x00CC0308 File Offset: 0x00CBE508
		private void InitAudio()
		{
			Entity entity = this.BlackBoard.RoadNetworkNavigationComponent.Entity;
			if (entity == null || !entity.Valid)
			{
				return;
			}
			CustomAudioControlComponent component = entity.GetComponent<CustomAudioControlComponent>();
			if (component == null)
			{
				return;
			}
			IAudioControlType audioControlConfig = component.GetAudioControlConfig();
			if (audioControlConfig == null)
			{
				return;
			}
			ITrafficAudioControl trafficAudioControl = audioControlConfig as ITrafficAudioControl;
			if (trafficAudioControl != null && audioControlConfig.Type == EAudioControlType.Traffic)
			{
				this.BlackBoard.HornAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(trafficAudioControl.HornAudio);
				this.BlackBoard.BrakingAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(trafficAudioControl.BrakingAudio);
				this.BlackBoard.BrakingShortAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(trafficAudioControl.BrakingShortAudio);
				this.BlackBoard.EngineAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(trafficAudioControl.EngineAudio);
			}
		}

		// Token: 0x06032E83 RID: 208515 RVA: 0x00CC03C8 File Offset: 0x00CBE5C8
		private void CheckAndSetZero(Vector relativeLocation)
		{
			if (Math.Abs(relativeLocation.X) < 9.999999747378752E-05)
			{
				relativeLocation.X = 0.0;
			}
			if (Math.Abs(relativeLocation.Y) < 9.999999747378752E-05)
			{
				relativeLocation.Y = 0.0;
			}
			if (Math.Abs(relativeLocation.Z) < 9.999999747378752E-05)
			{
				relativeLocation.Z = 0.0;
			}
		}
	}
}
