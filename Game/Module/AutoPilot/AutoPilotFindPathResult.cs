using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Transport;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006143 RID: 24899
	[NullableContext(1)]
	[Nullable(0)]
	public class AutoPilotFindPathResult
	{
		// Token: 0x0603EE42 RID: 257602 RVA: 0x0101E244 File Offset: 0x0101C444
		public AutoPilotFindPathResult()
		{
			this.CheckFindPathAutoPilotConditions = delegate(float? _)
			{
				AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
				if (!((instance != null) ? new bool?(instance.CheckCommonConditions()) : null).GetValueOrDefault())
				{
					return;
				}
				if (this.GetIsShowPlayerToTargetLine())
				{
					AutoPilotModel instance2 = ModelBase<AutoPilotModel>.Instance;
					if (instance2 == null)
					{
						return;
					}
					instance2.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NoHighLightLine));
					return;
				}
				else
				{
					this.RefreshHasArriveStartPoint();
					if (this.GetHasArriveStartPoint())
					{
						AutoPilotModel instance3 = ModelBase<AutoPilotModel>.Instance;
						if (instance3 == null)
						{
							return;
						}
						instance3.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Dest, null);
						return;
					}
					else
					{
						AutoPilotModel instance4 = ModelBase<AutoPilotModel>.Instance;
						if (instance4 == null)
						{
							return;
						}
						instance4.SetEnableAutoPilot(AutoPilotDefine.EEnableAutoPilot.Disable, new AutoPilotDefine.EDisableAutoPilotReason?(AutoPilotDefine.EDisableAutoPilotReason.NotNearRoad));
						return;
					}
				}
			};
			ControllerBase<AutoPilotController>.Instance.AddTick(this.CheckFindPathAutoPilotConditions);
		}

		// Token: 0x17009ADA RID: 39642
		// (get) Token: 0x0603EE43 RID: 257603 RVA: 0x0101E2D1 File Offset: 0x0101C4D1
		public Vector PlayerPoint
		{
			get
			{
				AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
				Vector vector;
				if (instance == null)
				{
					vector = null;
				}
				else
				{
					CharacterActorComponent actorComp = instance.ActorComp;
					vector = ((actorComp != null) ? actorComp.ActorLocationProxy : null);
				}
				return vector ?? Vector.ZeroVectorProxy;
			}
		}

		// Token: 0x0603EE44 RID: 257604 RVA: 0x0101E2F9 File Offset: 0x0101C4F9
		public bool GetIsShowStartPoint()
		{
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			return (instance == null || !instance.GetIsInAutoPilot()) && !this.HasArriveStartPoint && !this.GetIsShowPlayerToTargetLine();
		}

		// Token: 0x0603EE45 RID: 257605 RVA: 0x0101E321 File Offset: 0x0101C521
		public bool GetIsShowEndPoint()
		{
			return !this.GetIsShowPlayerToTargetLine();
		}

		// Token: 0x0603EE46 RID: 257606 RVA: 0x0101E32E File Offset: 0x0101C52E
		public bool GetIsShowHighLightLine()
		{
			return !this.GetIsShowPlayerToTargetLine();
		}

		// Token: 0x0603EE47 RID: 257607 RVA: 0x0101E33B File Offset: 0x0101C53B
		public bool GetIsShowPlayerToStartLine()
		{
			return this.GetIsShowStartPoint() && !this.GetIsShowPlayerToTargetLine();
		}

		// Token: 0x0603EE48 RID: 257608 RVA: 0x0101E350 File Offset: 0x0101C550
		public bool GetIsShowEndToTargetLine()
		{
			return this.GetIsShowEndPoint() && !this.GetIsShowPlayerToTargetLine();
		}

		// Token: 0x0603EE49 RID: 257609 RVA: 0x0101E365 File Offset: 0x0101C565
		public bool GetIsShowPlayerToTargetLine()
		{
			return this.IsShowPlayerToTargetLine;
		}

		// Token: 0x0603EE4A RID: 257610 RVA: 0x0101E36D File Offset: 0x0101C56D
		[NullableContext(2)]
		public Vector GetTrackingPoint()
		{
			if (this.GetIsShowStartPoint())
			{
				return this.StartPoint;
			}
			if (this.GetIsShowEndPoint())
			{
				return this.EndPoint;
			}
			return null;
		}

		// Token: 0x0603EE4B RID: 257611 RVA: 0x0101E390 File Offset: 0x0101C590
		public void RefreshSplinePoints()
		{
			this.ClearRoadWaySplinePointsMap();
			if (this.Roadways.Length == 0)
			{
				return;
			}
			this.RefreshRoadWaySplinePointsMap();
			this.SplineDistance = AutoPilotUtil.GenerateAllSplinePoints(this.Roadways, this.SplinePoints, this.StartPoint, this.EndPoint, this.RoadWaySplinePointsMap);
		}

		// Token: 0x0603EE4C RID: 257612 RVA: 0x0101E3DC File Offset: 0x0101C5DC
		private void ClearRoadWaySplinePointsMap()
		{
			foreach (List<double> list in this.RoadWaySplinePointsMap.Values)
			{
				list.Clear();
				this.RoadWaySplinePointsPool.Push(list);
			}
			this.RoadWaySplinePointsMap.Clear();
		}

		// Token: 0x0603EE4D RID: 257613 RVA: 0x0101E44C File Offset: 0x0101C64C
		private void RefreshRoadWaySplinePointsMap()
		{
			foreach (UKuroRoadway ukuroRoadway in this.Roadways)
			{
				this.RoadWaySplinePointsMap[ukuroRoadway.Id] = (this.RoadWaySplinePointsPool.Pop() ?? new List<double>());
			}
		}

		// Token: 0x0603EE4E RID: 257614 RVA: 0x0101E497 File Offset: 0x0101C697
		public double GetDistSquaredPlayerToEndPoint()
		{
			return this.DistSquaredPlayerToEndPointInner;
		}

		// Token: 0x0603EE4F RID: 257615 RVA: 0x0101E4A0 File Offset: 0x0101C6A0
		public void RefreshHasArriveStartPoint()
		{
			if (this.Roadways.Length == 0)
			{
				this.HasArriveStartPoint = false;
				return;
			}
			UKuroRoadway ukuroRoadway = this.Roadways[0];
			if (AutoPilotUtil.IsNearRoadWay(ukuroRoadway, this.PlayerPoint))
			{
				this.HasArriveStartPoint = true;
				return;
			}
			UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(ukuroRoadway.OpposingId);
			if (roadWay != null && AutoPilotUtil.IsNearRoadWay(roadWay, this.PlayerPoint))
			{
				this.HasArriveStartPoint = true;
				return;
			}
			this.HasArriveStartPoint = false;
		}

		// Token: 0x0603EE50 RID: 257616 RVA: 0x0101E513 File Offset: 0x0101C713
		public bool GetHasArriveStartPoint()
		{
			return this.HasArriveStartPoint;
		}

		// Token: 0x0603EE51 RID: 257617 RVA: 0x0101E51C File Offset: 0x0101C71C
		[NullableContext(2)]
		public void SetIsShowPlayerToTargetLine(bool value, string reason = null)
		{
			if (this.IsShowPlayerToTargetLine != value)
			{
				if (value)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.AutoPilot;
					ELogAuthor author = ELogAuthor.CB;
					string message = "直接连接玩家和目标点";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.IsShowPlayerToTargetLine = value;
			}
		}

		// Token: 0x0603EE52 RID: 257618 RVA: 0x0101E568 File Offset: 0x0101C768
		public void RefreshData(int mapId, Vector source, Vector desc, ITransportFindPathResult findPathResult)
		{
			this.MapId = mapId;
			this.LastFindPathPoint.FromUeVector(source);
			this.TargetPoint.FromUeVector(desc);
			Vector startPoint = this.StartPoint;
			FVectorDouble fvectorDouble = findPathResult.RoadStartPoint;
			startPoint.FromUeVector(fvectorDouble);
			this.Roadways = new UKuroRoadway[findPathResult.Roadways.Num()];
			for (int i = 0; i < findPathResult.Roadways.Num(); i++)
			{
				this.Roadways[i] = findPathResult.Roadways.Get(i);
			}
			Vector endPoint = this.EndPoint;
			fvectorDouble = findPathResult.RoadEndPoint;
			endPoint.FromUeVector(fvectorDouble);
			this.RefreshSplinePoints();
			if (this.SplineDistance < ModelBase<AutoPilotModel>.Instance.GetSplineDistanceThreshold())
			{
				this.SetIsShowPlayerToTargetLine(true, "样条线距离过短");
				return;
			}
			double num = Vector.DistSquared2D(this.StartPoint, this.PlayerPoint);
			double num2 = Vector.DistSquared2D(this.EndPoint, this.TargetPoint);
			if (Vector.DistSquared2D(this.PlayerPoint, this.TargetPoint) < num + num2)
			{
				this.SetIsShowPlayerToTargetLine(true, "玩家到目标点距离<起点到切入点+切出点到目标点");
				return;
			}
			this.SetIsShowPlayerToTargetLine(false, null);
			this.DistSquaredPlayerToEndPointInner = Vector.DistSquared(this.PlayerPoint, this.EndPoint);
		}

		// Token: 0x0603EE53 RID: 257619 RVA: 0x0101E68C File Offset: 0x0101C88C
		public void RefreshDataInAutoPilot()
		{
			this.IsNeedForceRefresh = true;
			this.StartPoint.FromUeVector(this.PlayerPoint);
			this.DistSquaredPlayerToEndPointInner = Vector.DistSquared(this.PlayerPoint, this.EndPoint);
			AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				MotorcycleSplineMoveComponent splineMoveComp = instance.SplineMoveComp;
				if (splineMoveComp == null)
				{
					num = null;
				}
				else
				{
					SplineMoveParams currentSplineMoveParams = splineMoveComp.CurrentSplineMoveParams;
					num = ((currentSplineMoveParams != null) ? new int?(currentSplineMoveParams.CurrentRouteIndex) : null);
				}
			}
			int? num2 = num;
			if (num2 == null)
			{
				return;
			}
			int? num3 = num2;
			int num4 = this.Roadways.Length - 1;
			if ((num3.GetValueOrDefault() == num4 & num3 != null) && AutoPilotUtil.CheckReachEnd(this.Roadways[num2.Value].RoadSpline, this.StartPoint, this.EndPoint, 1000))
			{
				ControllerBase<AutoPilotController>.Instance.ExitAutoPilot("OnReachEndPoint", true).Forget();
				return;
			}
			AutoPilotUtil.ProcessSplinePointsForAutoPilotRoute(this.Roadways[num2.Value], this.SplinePoints, this.StartPoint, this.RoadWaySplinePointsMap);
		}

		// Token: 0x0603EE54 RID: 257620 RVA: 0x0101E7A0 File Offset: 0x0101C9A0
		[NullableContext(2)]
		public UKuroRoadway GetLastRoadWay()
		{
			if (this.Roadways.Length == 0)
			{
				return null;
			}
			return this.Roadways[this.Roadways.Length - 1];
		}

		// Token: 0x0603EE55 RID: 257621 RVA: 0x0101E7C0 File Offset: 0x0101C9C0
		[NullableContext(2)]
		public UAutopilotRoute GenerateAutopilotRoute()
		{
			if (this.Roadways == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (UKuroRoadway ukuroRoadway in this.Roadways)
			{
				list.Add(ukuroRoadway.Id);
			}
			TransportNetworkController instance = ControllerBase<TransportNetworkController>.Instance;
			IEnumerable<int> idList = list;
			bool isLoop = false;
			AutoPilotModel instance2 = ModelBase<AutoPilotModel>.Instance;
			return instance.GetAssembleAutopilotRoute(idList, isLoop, instance2 != null && instance2.IsDebugMode);
		}

		// Token: 0x0603EE56 RID: 257622 RVA: 0x0101E820 File Offset: 0x0101CA20
		public bool IsNeedRefreshByFindPath(Vector location)
		{
			if (this.IsNeedForceRefresh)
			{
				this.IsNeedForceRefresh = false;
				return true;
			}
			if (this.Roadways.Length == 0)
			{
				return false;
			}
			double num = Vector.DistSquared(location, this.LastFindPathPoint);
			double num2 = ModelBase<AutoPilotModel>.Instance.AutoPilotRoadWayWidthOffset;
			double num3 = (double)this.Roadways[0].Width / 2.0 + num2;
			double num4 = num3 * num3;
			return num > num4;
		}

		// Token: 0x0603EE57 RID: 257623 RVA: 0x0101E884 File Offset: 0x0101CA84
		public FRotator? GetStartRotator()
		{
			if (this.Roadways.Length == 0)
			{
				return null;
			}
			double distanceAlongSplineAtWorldLocation = AutoPilotUtil.GetDistanceAlongSplineAtWorldLocation(this.Roadways[0].RoadSpline, this.StartPoint);
			USplineComponent roadSpline = this.Roadways[0].RoadSpline;
			if (roadSpline == null)
			{
				return null;
			}
			return new FRotator?(roadSpline.GetRotationAtDistanceAlongSpline((float)distanceAlongSplineAtWorldLocation, ESplineCoordinateSpace.World));
		}

		// Token: 0x0603EE58 RID: 257624 RVA: 0x0101E8E5 File Offset: 0x0101CAE5
		public void Clear()
		{
			ControllerBase<AutoPilotController>.Instance.RemoveTick(this.CheckFindPathAutoPilotConditions);
		}

		// Token: 0x0402349F RID: 144543
		public int MapId;

		// Token: 0x040234A0 RID: 144544
		public Vector TargetPoint = Vector.Create();

		// Token: 0x040234A1 RID: 144545
		public Vector StartPoint = Vector.Create();

		// Token: 0x040234A2 RID: 144546
		public Vector EndPoint = Vector.Create();

		// Token: 0x040234A3 RID: 144547
		private readonly Vector LastFindPathPoint = Vector.Create();

		// Token: 0x040234A4 RID: 144548
		public UKuroRoadway[] Roadways = Array.Empty<UKuroRoadway>();

		// Token: 0x040234A5 RID: 144549
		public readonly TArray<FVector2D> SplinePoints = new TArray<FVector2D>();

		// Token: 0x040234A6 RID: 144550
		private double SplineDistance;

		// Token: 0x040234A7 RID: 144551
		private bool IsShowPlayerToTargetLine;

		// Token: 0x040234A8 RID: 144552
		private readonly Dictionary<int, List<double>> RoadWaySplinePointsMap = new Dictionary<int, List<double>>();

		// Token: 0x040234A9 RID: 144553
		private readonly global::Stack<List<double>> RoadWaySplinePointsPool = new global::Stack<List<double>>();

		// Token: 0x040234AA RID: 144554
		private bool IsNeedForceRefresh;

		// Token: 0x040234AB RID: 144555
		private bool HasArriveStartPoint;

		// Token: 0x040234AC RID: 144556
		private double DistSquaredPlayerToEndPointInner;

		// Token: 0x040234AD RID: 144557
		public readonly Action<float?> CheckFindPathAutoPilotConditions;
	}
}
