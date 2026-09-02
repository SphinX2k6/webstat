using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

// Token: 0x0200321E RID: 12830
[NullableContext(2)]
[Nullable(0)]
public class SplineMoveParams
{
	// Token: 0x1700242D RID: 9261
	// (get) Token: 0x0601AAE4 RID: 109284 RVA: 0x007F07CA File Offset: 0x007EE9CA
	// (set) Token: 0x0601AAE5 RID: 109285 RVA: 0x007F07D2 File Offset: 0x007EE9D2
	public float CurrentMaxOffset
	{
		get
		{
			return this.CurrentMaxOffsetInternal;
		}
		set
		{
			this.CurrentMaxOffsetInternal = value;
			this.CurrentMaxOffsetSquaredInternal = value * value;
		}
	}

	// Token: 0x1700242E RID: 9262
	// (get) Token: 0x0601AAE6 RID: 109286 RVA: 0x007F07E4 File Offset: 0x007EE9E4
	public float CurrentMaxOffsetSquared
	{
		get
		{
			return this.CurrentMaxOffsetSquaredInternal;
		}
	}

	// Token: 0x1700242F RID: 9263
	// (get) Token: 0x0601AAE7 RID: 109287 RVA: 0x007F07EC File Offset: 0x007EE9EC
	public bool OnlyPositiveMove
	{
		get
		{
			return this.OnlyForward || this.PositiveMoveInternal;
		}
	}

	// Token: 0x0601AAE8 RID: 109288 RVA: 0x007F0800 File Offset: 0x007EEA00
	[NullableContext(1)]
	public void InitBase(int id, ISplineMovePattern config, Entity entity)
	{
		this.Id = id;
		this.Config = config;
		this.Entity = entity;
		this.Type = config.Type;
		this.MaxOffsetDist = config.MaxOffsetDistance.GetValueOrDefault();
		this.OnlyForward = config.IsOneWay.GetValueOrDefault();
		this.AutoExitSplineDist = (float)config.AutoExitDistance.GetValueOrDefault();
		this.UseSplineGravity = config.DynamicGravity.GetValueOrDefault();
		this.LayerVerticalLimit = config.LayerVerticalLimit.GetValueOrDefault(100000f);
		switch (config.Type)
		{
		case ESplineMovePattern.PathLine:
		{
			IPathLineFacingType facingConfig = (config as IPathLineMove).FacingConfig;
			this.AdjustFacingType = ((facingConfig != null) ? new EPathLineFacingType?(facingConfig.Type) : null);
			if ((config as IPathLineMove).FacingConfig != null)
			{
				EPathLineFacingType type = (config as IPathLineMove).FacingConfig.Type;
				if (type != EPathLineFacingType.Current)
				{
					if (type == EPathLineFacingType.Custom)
					{
						this.AdjustFacingLimit = ((config as IPathLineMove).FacingConfig as IPathLineFacingCustomDirection).Yaw;
					}
				}
				else
				{
					this.AdjustFacingLimit = ((config as IPathLineMove).FacingConfig as IPathLineFacingCurrentDirection).YawOffset.GetValueOrDefault();
				}
			}
			this.ConfigDaPath = (config as IPathLineMove).SplineMoveConfigDaPath;
			this.IsAdaptiveClimbInput = (config as IPathLineMove).IsAdaptiveClimbInput.GetValueOrDefault();
			this.IsDisableStopAnim = (config as IPathLineMove).IsDisableStopAnim.GetValueOrDefault();
			this.IsAllowEarlyExitClimb = (config as IPathLineMove).IsAllowEarlyExitClimb.GetValueOrDefault();
			break;
		}
		case ESplineMovePattern.RacingTrack:
			this.InputLimitAngle = (config as IRacingTrackMove).DirectionAngleLimit;
			this.InputLimitCos = (float)Math.Cos((double)(this.InputLimitAngle * 0.017453292f));
			this.InputLimitSin = (float)Math.Sin((double)(this.InputLimitAngle * 0.017453292f));
			break;
		case ESplineMovePattern.SlideTrack:
			this.InputLimitAngle = (config as ISlideTrackMove).DirectionAngleLimit;
			this.EdgeLimitCurve = new PowerCurve3(new float[]
			{
				(config as ISlideTrackMove).EdgeLimitCurveFactor
			});
			break;
		case ESplineMovePattern.AirPassage:
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(id);
			SceneItemWindPipelineComponent sceneItemWindPipelineComponent;
			if (entityByPbDataId == null)
			{
				sceneItemWindPipelineComponent = null;
			}
			else
			{
				WorldEntity entity2 = entityByPbDataId.Entity;
				sceneItemWindPipelineComponent = ((entity2 != null) ? entity2.GetComponent<SceneItemWindPipelineComponent>() : null);
			}
			SceneItemWindPipelineComponent sceneItemWindPipelineComponent2 = sceneItemWindPipelineComponent;
			if (((sceneItemWindPipelineComponent2 != null) ? sceneItemWindPipelineComponent2.SplineData : null) != null)
			{
				this.MaxSoarSplineSpeed = sceneItemWindPipelineComponent2.SplineData.SpeedLimit;
				this.MaxOffsetDist = sceneItemWindPipelineComponent2.SplineData.MovableRadius;
				this.SoarFriction = sceneItemWindPipelineComponent2.SplineData.Resistance;
				this.SoarSprintLimit = sceneItemWindPipelineComponent2.SplineData.SprintSpeedLimit;
			}
			else
			{
				this.MaxSoarSplineSpeed = 3000f;
				this.SoarFriction = 0.5f;
				this.SoarSprintLimit = 0f;
			}
			this.NeedLimitSoarTransform = ((config as IAirPassageMove).Limit != null);
			if ((config as IAirPassageMove).Limit != null)
			{
				this.InputLimitAngle = (config as IAirPassageMove).Limit.DirectionAngleLimit;
				this.EdgeLimitCurve = new PowerCurve3(new float[]
				{
					(config as IAirPassageMove).Limit.EdgeLimitCurveFactor
				});
			}
			break;
		}
		case ESplineMovePattern.MotorcycleTrack:
		{
			if (this.MaxOffsetDist <= 0f)
			{
				this.MaxOffsetDist = 1f;
			}
			this.AdjustFacingLimit = (((config as IMotorcycleTrack).ForwardAngleLimit >= 0f) ? (config as IMotorcycleTrack).ForwardAngleLimit : 180f);
			if ((config as IMotorcycleTrack).LongitudinalAngleLimit != null)
			{
				this.AdjustFacingLimitPitchSin = (float)Math.Sin((double)(0.017453292f * (config as IMotorcycleTrack).LongitudinalAngleLimit.Value));
			}
			if ((config as IMotorcycleTrack).CorrectionPredictionDistance != null)
			{
				this.PredictDist = (config as IMotorcycleTrack).CorrectionPredictionDistance.Value;
			}
			else
			{
				this.PredictDist = 2000f;
			}
			this.InputCorrectionBaseAngle = (config as IMotorcycleTrack).InputCorrectionBaseAngle.GetValueOrDefault(30f);
			if ((config as IMotorcycleTrack).ForwardAngleLimitCurve != null)
			{
				this.AdjustFacingLimitCurve = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>((config as IMotorcycleTrack).ForwardAngleLimitCurve, "js_undefined");
			}
			this.InputCorrectionCurve = Singleton<ResourceSystem>.Instance.Load<UCurveFloat>((config as IMotorcycleTrack).InputCorrectionCurve, "js_undefined");
			IAutomaticDrive automaticDrive = (config as IMotorcycleTrack).AutomaticDrive;
			bool flag;
			if (automaticDrive == null)
			{
				flag = false;
			}
			else
			{
				float standbyTime = automaticDrive.StandbyTime;
				flag = true;
			}
			this.AutoDriveStandbyTime = (flag ? (config as IMotorcycleTrack).AutomaticDrive.StandbyTime : -1f);
			this.DisableAutoForward = (config as IMotorcycleTrack).DisableAutoForward.GetValueOrDefault();
			break;
		}
		}
		this.CurrentMaxOffset = this.MaxOffsetDist + 100000f;
		if (this.Type == ESplineMovePattern.AirPassage)
		{
			this.EarliestLeaveTime = Singleton<Time>.Instance.NowSeconds + 1.0;
			return;
		}
		if (this.Type == ESplineMovePattern.MotorcycleTrack && this.UseSplineGravity)
		{
			this.EarliestLeaveTime = Singleton<Time>.Instance.NowSeconds + 0.5;
			return;
		}
		this.EarliestLeaveTime = Singleton<Time>.Instance.NowSeconds;
	}

	// Token: 0x0601AAE9 RID: 109289 RVA: 0x007F0D18 File Offset: 0x007EEF18
	[NullableContext(1)]
	public void InitByAutoPilotRoute(UAutopilotRoute route, Entity entity)
	{
		this.Id = -1;
		this.Entity = entity;
		this.AutopilotRoute = route;
		this.Spline = route.RoadSpline;
		this.Type = ESplineMovePattern.MotorcycleTrack;
		this.CurrentMaxOffset = 0f;
		this.UpdateRouteParamsByIndex(0);
		this.CurrentMaxOffset += 100000f;
		this.OnlyForward = false;
		this.PositiveMoveInternal = true;
		this.LayerVerticalLimit = 100000f;
		this.AdjustFacingLimit = 180f;
		this.AdjustFacingLimitPitchSin = (float)Math.Sin(1.0471975803375244);
		this.PredictDist = 2000f;
		this.AdjustFacingLimitCurve = null;
		this.InputCorrectionCurve = null;
		this.EarliestLeaveTime = Singleton<Time>.Instance.NowSeconds;
		int num = route.RoadSegmentInfos.Num();
		for (int i = 0; i < num; i++)
		{
			FRoadSegmentInfo froadSegmentInfo = route.RoadSegmentInfos.Get(i);
			this.KeyOfAutopilotRoute.Add(froadSegmentInfo.StartKey);
		}
	}

	// Token: 0x0601AAEA RID: 109290 RVA: 0x007F0E0C File Offset: 0x007EF00C
	public void UpdateParamsByTimeKey(float timeKey)
	{
		if (this.AutopilotRoute == null)
		{
			return;
		}
		int num = 0;
		int num2 = this.KeyOfAutopilotRoute.Count;
		while (num2 - num > 1)
		{
			int num3 = num + num2 >> 1;
			if (this.KeyOfAutopilotRoute[num3] <= timeKey)
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		this.UpdateRouteParamsByIndex(num);
	}

	// Token: 0x0601AAEB RID: 109291 RVA: 0x007F0E5C File Offset: 0x007EF05C
	protected void UpdateRouteParamsByIndex(int index)
	{
		this.CurrentRouteIndex = index;
		UKuroRoadway roadInfo = this.AutopilotRoute.RoadSegmentInfos.Get(index).RoadInfo;
		this.MaxOffsetDist = (float)(roadInfo.Width / 2);
		this.AutoSprint = Singleton<MathUtils>.Instance.IsNearlyEqual((double)roadInfo.PavedRoadConfig, 2.0, null);
		if (this.MaxOffsetDist <= 0f)
		{
			this.MaxOffsetDist = 1f;
		}
		this.CurrentMaxOffset = Math.Max(this.CurrentMaxOffset, this.MaxOffsetDist);
	}

	// Token: 0x0601AAEC RID: 109292 RVA: 0x007F0EF0 File Offset: 0x007EF0F0
	public void EnableParams(bool enable)
	{
		if (this.Spline == null && enable)
		{
			this.Spline = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(this.Id, this.Entity.Id, EIdType.EntityId);
		}
		else if (this.Spline != null && !enable)
		{
			ModelBase<GameSplineModel>.Instance.ReleaseSpline(this.Id, (long)this.Entity.Id, EIdType.EntityId);
			this.Spline = null;
		}
		if (!enable)
		{
			this.Clear();
		}
	}

	// Token: 0x0601AAED RID: 109293 RVA: 0x007F0F66 File Offset: 0x007EF166
	public void Clear()
	{
		if (this.AutopilotRoute != null && !this.MarkInherited)
		{
			this.AutopilotRoute.Clear();
		}
	}

	// Token: 0x0400D818 RID: 55320
	private const float MAX_OFFSET_INCREASE = 100000f;

	// Token: 0x0400D819 RID: 55321
	private const float HEIGHT_LIMIT = 100000f;

	// Token: 0x0400D81A RID: 55322
	public int Id;

	// Token: 0x0400D81B RID: 55323
	public ISplineMovePattern Config;

	// Token: 0x0400D81C RID: 55324
	public Entity Entity;

	// Token: 0x0400D81D RID: 55325
	public bool AllowInherit;

	// Token: 0x0400D81E RID: 55326
	public bool MarkInherited;

	// Token: 0x0400D81F RID: 55327
	public USplineComponent Spline;

	// Token: 0x0400D820 RID: 55328
	private float CurrentMaxOffsetInternal;

	// Token: 0x0400D821 RID: 55329
	private float CurrentMaxOffsetSquaredInternal;

	// Token: 0x0400D822 RID: 55330
	public ESplineMovePattern Type;

	// Token: 0x0400D823 RID: 55331
	public float MaxOffsetDist;

	// Token: 0x0400D824 RID: 55332
	public bool OnlyForward;

	// Token: 0x0400D825 RID: 55333
	private bool PositiveMoveInternal;

	// Token: 0x0400D826 RID: 55334
	public float InputLimitAngle;

	// Token: 0x0400D827 RID: 55335
	public float InputLimitCos;

	// Token: 0x0400D828 RID: 55336
	public float InputLimitSin;

	// Token: 0x0400D829 RID: 55337
	public float LayerVerticalLimit = 100000f;

	// Token: 0x0400D82A RID: 55338
	public float AutoExitSplineDist;

	// Token: 0x0400D82B RID: 55339
	public bool UseSplineGravity;

	// Token: 0x0400D82C RID: 55340
	public EPathLineFacingType? AdjustFacingType;

	// Token: 0x0400D82D RID: 55341
	public string ConfigDaPath;

	// Token: 0x0400D82E RID: 55342
	public bool IsAdaptiveClimbInput;

	// Token: 0x0400D82F RID: 55343
	public bool IsDisableStopAnim;

	// Token: 0x0400D830 RID: 55344
	public bool IsAllowEarlyExitClimb;

	// Token: 0x0400D831 RID: 55345
	public float AdjustFacingLimit;

	// Token: 0x0400D832 RID: 55346
	public UCurveFloat AdjustFacingLimitCurve;

	// Token: 0x0400D833 RID: 55347
	public float AdjustFacingLimitPitchSin = (float)Math.Sin(1.0471975803375244);

	// Token: 0x0400D834 RID: 55348
	[Nullable(1)]
	public CurveBase EdgeLimitCurve = CurveUtils.DefaultLinear;

	// Token: 0x0400D835 RID: 55349
	public bool IsDelayClear;

	// Token: 0x0400D836 RID: 55350
	public double EarliestLeaveTime;

	// Token: 0x0400D837 RID: 55351
	public bool NeedLimitSoarTransform;

	// Token: 0x0400D838 RID: 55352
	public float MaxSoarSplineSpeed;

	// Token: 0x0400D839 RID: 55353
	public float SoarFriction;

	// Token: 0x0400D83A RID: 55354
	public float SoarSprintLimit;

	// Token: 0x0400D83B RID: 55355
	public float PredictDist = 2000f;

	// Token: 0x0400D83C RID: 55356
	public float InputCorrectionBaseAngle = 30f;

	// Token: 0x0400D83D RID: 55357
	public UCurveFloat InputCorrectionCurve;

	// Token: 0x0400D83E RID: 55358
	public float AutoDriveStandbyTime;

	// Token: 0x0400D83F RID: 55359
	public bool AutoSprint;

	// Token: 0x0400D840 RID: 55360
	public bool DisableAutoForward;

	// Token: 0x0400D841 RID: 55361
	public UAutopilotRoute AutopilotRoute;

	// Token: 0x0400D842 RID: 55362
	public int CurrentRouteIndex;

	// Token: 0x0400D843 RID: 55363
	[Nullable(1)]
	protected readonly List<float> KeyOfAutopilotRoute = new List<float>();
}
