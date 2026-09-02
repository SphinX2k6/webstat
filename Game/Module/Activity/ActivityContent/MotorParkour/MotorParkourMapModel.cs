using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.Map;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066B4 RID: 26292
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MotorParkourMapModel : ModelBase<MotorParkourMapModel>
	{
		// Token: 0x06041A84 RID: 268932 RVA: 0x010D5B44 File Offset: 0x010D3D44
		public void InitSplinePoints(int splineId, float scale, Vector2D centerOffset, int startIndex, int endIndex)
		{
			this.Scale = scale;
			this.CenterOffset = centerOffset;
			if (Global.BaseCharacter == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorParkour, ELogAuthor.CXJ, "当前角色实体不存在，样条线组件无法绑定角色实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.SplineComponent = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(splineId, Global.BaseCharacter.EntityId, EIdType.EntityId);
			if (this.SplineComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorParkour;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托车跑酷spline获取失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SplineId", splineId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.StartDist = this.SplineComponent.GetDistanceAlongSplineAtSplinePoint(0);
			this.StartDist = this.SplineComponent.GetDistanceAlongSplineAtSplinePoint(startIndex);
			float distanceAlongSplineAtSplinePoint = this.SplineComponent.GetDistanceAlongSplineAtSplinePoint(endIndex);
			this.GetSplinePoints(distanceAlongSplineAtSplinePoint, this.SplinePoints, this.StartDist == distanceAlongSplineAtSplinePoint);
			FVector2D fvector2D = this.SplinePoints.Get(this.SplinePoints.Num() - 1);
			this.EndPointOffset.Set((double)fvector2D.X, (double)fvector2D.Y);
			FVectorDouble fvectorDouble = this.SplineComponent.D_GetArriveTangentAtSplinePoint(endIndex, ESplineCoordinateSpace.World);
			this.EndPointRotator.Yaw = -(float)(Math.Atan2(fvectorDouble.Y, fvectorDouble.X) * 57.295780181884766 + 90.0);
		}

		// Token: 0x06041A85 RID: 268933 RVA: 0x010D5C98 File Offset: 0x010D3E98
		public TArray<FVector2D> GetPathTakenSplinePoints()
		{
			if (this.SplineComponent == null)
			{
				return this.PathTakenSplinePoints;
			}
			Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
			if (playerLocation == null)
			{
				return this.PathTakenSplinePoints;
			}
			USplineComponent splineComponent = this.SplineComponent;
			FVectorDouble fvectorDouble = playerLocation.ToUeVector(false);
			float inKey = splineComponent.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
			float distanceAlongSplineAtSplineInputKey = this.SplineComponent.GetDistanceAlongSplineAtSplineInputKey(inKey);
			this.GetSplinePoints(distanceAlongSplineAtSplineInputKey, this.PathTakenSplinePoints, false);
			return this.PathTakenSplinePoints;
		}

		// Token: 0x06041A86 RID: 268934 RVA: 0x010D5D00 File Offset: 0x010D3F00
		public void GetSplinePoints(float endDistance, TArray<FVector2D> array, bool forcePassSplineStartPoint = false)
		{
			if (this.SplineComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorParkour, ELogAuthor.CXJ, "样条线组件不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			array.Empty(true);
			float splineLength = this.SplineComponent.GetSplineLength();
			bool flag = endDistance < this.StartDist;
			if (forcePassSplineStartPoint || flag)
			{
				this.AddPoints(this.StartDist, splineLength, array);
				this.AddPoints(0f, endDistance, array);
				return;
			}
			this.AddPoints(this.StartDist, endDistance, array);
		}

		// Token: 0x06041A87 RID: 268935 RVA: 0x010D5D84 File Offset: 0x010D3F84
		public void AddPoints(float startDist, float endDist, TArray<FVector2D> array)
		{
			if (this.SplineComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MotorParkour, ELogAuthor.CXJ, "样条线组件不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			for (float num = startDist; num != endDist; num = Math.Min(num + 1000f, endDist))
			{
				FVectorDouble fvectorDouble = this.SplineComponent.D_GetLocationAtDistanceAlongSpline(num, ESplineCoordinateSpace.World);
				this.TmpVector2D.Set(fvectorDouble.X, fvectorDouble.Y);
				MapUtil.WorldPosition2UiPosition2D(this.TmpVector2D, null).Multiply((double)this.Scale, this.SplinePoint2D).Subtraction(this.CenterOffset, this.SplinePoint2D);
				array.Add(this.SplinePoint2D.ToUeVector2D(false));
			}
		}

		// Token: 0x04024A63 RID: 150115
		[Nullable(2)]
		private USplineComponent SplineComponent;

		// Token: 0x04024A64 RID: 150116
		private float Scale = 1f;

		// Token: 0x04024A65 RID: 150117
		private Vector2D CenterOffset = Vector2D.Create();

		// Token: 0x04024A66 RID: 150118
		private float StartDist;

		// Token: 0x04024A67 RID: 150119
		private readonly Vector2D SplinePoint2D = Vector2D.Create();

		// Token: 0x04024A68 RID: 150120
		private readonly Vector2D TmpVector2D = Vector2D.Create();

		// Token: 0x04024A69 RID: 150121
		public readonly Vector2D EndPointOffset = Vector2D.Create();

		// Token: 0x04024A6A RID: 150122
		public FRotator EndPointRotator = new FRotator();

		// Token: 0x04024A6B RID: 150123
		public readonly TArray<FVector2D> SplinePoints = new TArray<FVector2D>();

		// Token: 0x04024A6C RID: 150124
		public readonly TArray<FVector2D> PathTakenSplinePoints = new TArray<FVector2D>();
	}
}
