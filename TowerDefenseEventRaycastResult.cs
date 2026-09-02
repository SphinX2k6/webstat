using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using UnrealEngine;

// Token: 0x02002BD5 RID: 11221
[NullableContext(1)]
[Nullable(0)]
public class TowerDefenseEventRaycastResult
{
	// Token: 0x06016651 RID: 91729 RVA: 0x00637954 File Offset: 0x00635B54
	[NullableContext(2)]
	public bool Raycast(TsTowerDefenseEventActor target, ETowerDefenseEventTrapPlacementType placementType, float degree, bool canRecycle)
	{
		this.Start.DeepCopy(ModelBase<CameraModel>.Instance.MainModel.CameraLocation);
		ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Vector(this.End);
		this.End.MultiplyEqual(10000.0);
		this.End.AdditionEqual(this.Start);
		this.PlacementType = placementType;
		this.BuildingGridRaycastResult.Target = new TWeakObjectPtr<UObject>(target);
		this.BuildingGridRaycastResult.DegreeAlongNormal = degree;
		this.BuildingGridRaycastResult.RaycastTarget = new TWeakObjectPtr<UObject>(null);
		UObject world = GlobalData.World;
		FVectorDouble fvectorDouble = this.Start.ToUeVector(false);
		FVectorDouble fvectorDouble2 = this.End.ToUeVector(false);
		bool flag = UKuroBuildingGridSubsystem.K2_RaycastGrid(world, fvectorDouble, fvectorDouble2, ref this.BuildingGridRaycastResult);
		if (flag)
		{
			this.Target = (this.BuildingGridRaycastResult.Target.Get() as TsTowerDefenseEventActor);
			this.RaycastTarget = (this.BuildingGridRaycastResult.RaycastTarget.Get() as TsTowerDefenseEventActor);
			this.Grid = this.BuildingGridRaycastResult.Grid;
			Vector location = this.Location;
			fvectorDouble = this.BuildingGridRaycastResult.Location;
			location.DeepCopy(fvectorDouble);
			Rotator rotation = this.Rotation;
			FRotator frotator = this.BuildingGridRaycastResult.Rotation.Rotator();
			rotation.DeepCopy(frotator);
			this.Coords.Set((double)this.BuildingGridRaycastResult.Coords.X, (double)this.BuildingGridRaycastResult.Coords.Y);
			this.Degree = this.BuildingGridRaycastResult.DegreeAlongNormal;
			Vector normal = this.Normal;
			FVector normal2 = this.BuildingGridRaycastResult.Normal;
			fvectorDouble = normal2;
			normal.DeepCopy(fvectorDouble);
			this.IsStateDirty = this.UpdateRaycastState(target, canRecycle);
			return flag;
		}
		this.Reset();
		return flag;
	}

	// Token: 0x06016652 RID: 91730 RVA: 0x00637B28 File Offset: 0x00635D28
	public void Reset()
	{
		this.BuildingGridRaycastResult.Target = new TWeakObjectPtr<UObject>(null);
		this.BuildingGridRaycastResult.RaycastTarget = new TWeakObjectPtr<UObject>(null);
		this.Target = null;
		this.RaycastTarget = null;
		this.Grid = null;
		this.Location.Set(0.0, 0.0, 0.0);
		this.Rotation.Set(0f, 0f, 0f);
		this.Coords.Set(0.0, 0.0);
		this.Degree = 0f;
		this.Normal.Set(0.0, 0.0, 0.0);
		this.IsStateDirty = this.UpdateRaycastState(this.Target, false);
	}

	// Token: 0x06016653 RID: 91731 RVA: 0x00637C10 File Offset: 0x00635E10
	[NullableContext(2)]
	private bool UpdateRaycastState(TsTowerDefenseEventActor target, bool canRecycle)
	{
		bool flag = this.UpdateBuildState(target);
		bool flag2 = this.UpdateRecycleState(canRecycle);
		return flag || flag2;
	}

	// Token: 0x06016654 RID: 91732 RVA: 0x00637C30 File Offset: 0x00635E30
	[NullableContext(2)]
	private bool UpdateBuildState(TsTowerDefenseEventActor target)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		this.PollutedNum = 0;
		if (target != null && target == this.Target)
		{
			if (TowerDefenseEventUtility.ValidatePlacementWithGridNormal(this.PlacementType, this.Normal, 0.7f))
			{
				flag2 = true;
				OutPollutedNum outPollutedNum = new OutPollutedNum();
				ETowerDefenseEventBuildState etowerDefenseEventBuildState = target.UpdateBuildState(this.Grid, this.Coords, this.Degree, this.Location, this.Rotation, outPollutedNum);
				this.PollutedNum = outPollutedNum.PollutedNum;
				flag3 = ((etowerDefenseEventBuildState & ETowerDefenseEventBuildState.Valid) == ETowerDefenseEventBuildState.Valid);
				flag4 = ((etowerDefenseEventBuildState & ETowerDefenseEventBuildState.Polluted) == ETowerDefenseEventBuildState.Polluted);
			}
			else
			{
				flag = true;
			}
		}
		bool result = this.IsInvalidPlacement != flag || this.IsCanPlace != flag2 || this.IsCanBuild != flag3 || this.IsPolluted != flag4;
		this.IsInvalidPlacement = flag;
		this.IsCanPlace = flag2;
		this.IsCanBuild = flag3;
		this.IsPolluted = flag4;
		return result;
	}

	// Token: 0x06016655 RID: 91733 RVA: 0x00637D04 File Offset: 0x00635F04
	private bool UpdateRecycleState(bool canRecycle)
	{
		bool flag = canRecycle && this.RaycastTarget != null;
		bool result = this.IsCanRecycle != flag;
		this.IsCanRecycle = flag;
		return result;
	}

	// Token: 0x0400AD44 RID: 44356
	private FKuroBuildingGridRaycastResult BuildingGridRaycastResult = new FKuroBuildingGridRaycastResult();

	// Token: 0x0400AD45 RID: 44357
	public Vector Start = Vector.Create();

	// Token: 0x0400AD46 RID: 44358
	public Vector End = Vector.Create();

	// Token: 0x0400AD47 RID: 44359
	[Nullable(2)]
	public TsTowerDefenseEventActor Target;

	// Token: 0x0400AD48 RID: 44360
	[Nullable(2)]
	public TsTowerDefenseEventActor RaycastTarget;

	// Token: 0x0400AD49 RID: 44361
	[Nullable(2)]
	public AKuroBuildingGrid Grid;

	// Token: 0x0400AD4A RID: 44362
	public Vector Location = Vector.Create();

	// Token: 0x0400AD4B RID: 44363
	public Rotator Rotation = Rotator.Create();

	// Token: 0x0400AD4C RID: 44364
	public Vector2D Coords = Vector2D.Create(0.0, 0.0);

	// Token: 0x0400AD4D RID: 44365
	public float Degree;

	// Token: 0x0400AD4E RID: 44366
	public Vector Normal = Vector.Create();

	// Token: 0x0400AD4F RID: 44367
	public ETowerDefenseEventTrapPlacementType PlacementType = ETowerDefenseEventTrapPlacementType.Ground;

	// Token: 0x0400AD50 RID: 44368
	public bool IsStateDirty;

	// Token: 0x0400AD51 RID: 44369
	public bool IsInvalidPlacement;

	// Token: 0x0400AD52 RID: 44370
	public bool IsCanPlace;

	// Token: 0x0400AD53 RID: 44371
	public bool IsCanBuild;

	// Token: 0x0400AD54 RID: 44372
	public bool IsPolluted;

	// Token: 0x0400AD55 RID: 44373
	public int PollutedNum;

	// Token: 0x0400AD56 RID: 44374
	public bool IsCanRecycle;
}
