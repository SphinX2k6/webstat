using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Transport;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006140 RID: 24896
	[NullableContext(1)]
	[Nullable(0)]
	public class AutoPilotCirclePathResult
	{
		// Token: 0x0603EE0E RID: 257550 RVA: 0x0101CE94 File Offset: 0x0101B094
		public AutoPilotCirclePathResult(int circleId, bool isInCircle)
		{
			this.CircleId = circleId;
			this.IsInCircle = isInCircle;
			AutoPilotCircles? config = ConfigAutoPilotCirclesById.GetConfig(circleId, true);
			this.MapId = ((config != null) ? config.GetValueOrDefault().MapId : 0);
			this.CircleRoadWaysIds = ((config != null) ? config.GetValueOrDefault().GetWaySplinesArray() : null);
		}

		// Token: 0x0603EE0F RID: 257551 RVA: 0x0101CF2C File Offset: 0x0101B12C
		public void RefreshPathToCircleDataInAutoPilot(float? _ = null)
		{
			CharacterActorComponent actorComp = ModelBase<AutoPilotModel>.Instance.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			MotorcycleSplineMoveComponent splineMoveComp = ModelBase<AutoPilotModel>.Instance.SplineMoveComp;
			int? num;
			if (splineMoveComp == null)
			{
				num = null;
			}
			else
			{
				SplineMoveParams currentSplineMoveParams = splineMoveComp.CurrentSplineMoveParams;
				num = ((currentSplineMoveParams != null) ? new int?(currentSplineMoveParams.CurrentRouteIndex) : null);
			}
			int? num2 = num;
			if (num2 == null)
			{
				return;
			}
			int? num3 = num2;
			int num4 = this.PathToCircleRoadWays.Count - 1;
			if ((num3.GetValueOrDefault() == num4 & num3 != null) && AutoPilotUtil.CheckReachEnd(this.PathToCircleRoadWays[num2.Value].RoadSpline, actorComp.ActorLocationProxy, this.EnterCirclePoint, 1000))
			{
				this.RefreshIsInCircle(true);
				return;
			}
			AutoPilotUtil.ProcessSplinePointsForAutoPilotRoute(this.PathToCircleRoadWays[num2.Value], this.PathToCircleSplinePoints, actorComp.ActorLocationProxy, this.RoadWaySplinePointsMap);
		}

		// Token: 0x0603EE10 RID: 257552 RVA: 0x0101D010 File Offset: 0x0101B210
		public void RefreshPathToCircleData()
		{
			if (this.IsInCircle)
			{
				return;
			}
			int enterCircleRoadId = ModelBase<AutoPilotModel>.Instance.EnterCircleRoadId;
			if (enterCircleRoadId == 0)
			{
				return;
			}
			UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(enterCircleRoadId);
			FVectorDouble? fvectorDouble;
			if (roadWay == null)
			{
				fvectorDouble = null;
			}
			else
			{
				USplineComponent roadSpline = roadWay.RoadSpline;
				fvectorDouble = ((roadSpline != null) ? new FVectorDouble?(roadSpline.D_GetLocationAtSplinePoint(1, ESplineCoordinateSpace.World)) : null);
			}
			FVectorDouble? fvectorDouble2 = fvectorDouble;
			if (fvectorDouble2 == null)
			{
				return;
			}
			global::Vector enterCirclePoint = this.EnterCirclePoint;
			FVectorDouble value = fvectorDouble2.Value;
			enterCirclePoint.FromUeVector(value);
			CharacterActorComponent actorComp = ModelBase<AutoPilotModel>.Instance.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			ITransportFindPathResult transportFindPathResult = ControllerBase<TransportNetworkController>.Instance.FindPath(actorComp.ActorLocationProxy, this.EnterCirclePoint, true, false, ModelBase<AutoPilotModel>.Instance.IsDebugMode);
			if (transportFindPathResult == null)
			{
				return;
			}
			this.PathToCircleRoadWays.Clear();
			int num = transportFindPathResult.Roadways.Num();
			for (int i = 0; i < num; i++)
			{
				UKuroRoadway ukuroRoadway = transportFindPathResult.Roadways.Get(i);
				this.PathToCircleRoadWays.Add(ukuroRoadway);
				this.RoadWaySplinePointsMap[ukuroRoadway.Id] = new List<double>();
			}
			AutoPilotUtil.GenerateAllSplinePoints(this.PathToCircleRoadWays.ToArray(), this.PathToCircleSplinePoints, actorComp.ActorLocationProxy, this.EnterCirclePoint, this.RoadWaySplinePointsMap);
			ControllerBase<AutoPilotController>.Instance.AddTick(new Action<float?>(this.RefreshPathToCircleDataInAutoPilot));
		}

		// Token: 0x0603EE11 RID: 257553 RVA: 0x0101D168 File Offset: 0x0101B368
		[NullableContext(2)]
		public UAutopilotRoute GenerateAutopilotRoute()
		{
			if (!this.IsInCircle)
			{
				List<int> list = new List<int>();
				foreach (UKuroRoadway ukuroRoadway in this.PathToCircleRoadWays)
				{
					list.Add(ukuroRoadway.Id);
				}
				return ControllerBase<TransportNetworkController>.Instance.GetAssembleAutopilotRoute(list, false, ModelBase<AutoPilotModel>.Instance.IsDebugMode);
			}
			if (this.CircleRoadWaysIds == null)
			{
				return null;
			}
			return ControllerBase<TransportNetworkController>.Instance.GetAssembleAutopilotRoute(this.CircleRoadWaysIds, true, ModelBase<AutoPilotModel>.Instance.IsDebugMode);
		}

		// Token: 0x0603EE12 RID: 257554 RVA: 0x0101D20C File Offset: 0x0101B40C
		public void RefreshIsInCircle(bool isInCircle)
		{
			if (this.IsInCircle == isInCircle)
			{
				return;
			}
			this.IsInCircle = isInCircle;
			if (isInCircle)
			{
				ControllerBase<AutoPilotController>.Instance.RemoveTick(new Action<float?>(this.RefreshPathToCircleDataInAutoPilot));
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCircleStateChange, isInCircle);
		}

		// Token: 0x0603EE13 RID: 257555 RVA: 0x0101D249 File Offset: 0x0101B449
		public bool GetIsInCircle()
		{
			return this.IsInCircle;
		}

		// Token: 0x0402347C RID: 144508
		public int MapId;

		// Token: 0x0402347D RID: 144509
		public int CircleId;

		// Token: 0x0402347E RID: 144510
		[Nullable(2)]
		public int[] CircleRoadWaysIds;

		// Token: 0x0402347F RID: 144511
		public readonly TArray<FVector2D> PathToCircleSplinePoints = new TArray<FVector2D>();

		// Token: 0x04023480 RID: 144512
		private readonly List<UKuroRoadway> PathToCircleRoadWays = new List<UKuroRoadway>();

		// Token: 0x04023481 RID: 144513
		private bool IsInCircle;

		// Token: 0x04023482 RID: 144514
		public readonly global::Vector EnterCirclePoint = global::Vector.Create();

		// Token: 0x04023483 RID: 144515
		private readonly Dictionary<int, List<double>> RoadWaySplinePointsMap = new Dictionary<int, List<double>>();
	}
}
