using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

// Token: 0x02003220 RID: 12832
[NullableContext(1)]
[Nullable(0)]
public class BaseSplineMoveComponent : EntityComponent
{
	// Token: 0x17002430 RID: 9264
	// (get) Token: 0x0601AAEF RID: 109295 RVA: 0x007F0FE3 File Offset: 0x007EF1E3
	public ESplineMovePattern CurrentSplineMoveType
	{
		get
		{
			if (this.CurrentSplineMoveParamsInternal == null)
			{
				return ESplineMovePattern.PathLine;
			}
			return this.CurrentSplineMoveParamsInternal.Type;
		}
	}

	// Token: 0x17002431 RID: 9265
	// (get) Token: 0x0601AAF0 RID: 109296 RVA: 0x007F0FFA File Offset: 0x007EF1FA
	[Nullable(2)]
	public SplineMoveParams CurrentSplineMoveParams
	{
		[NullableContext(2)]
		get
		{
			return this.CurrentSplineMoveParamsInternal;
		}
	}

	// Token: 0x17002432 RID: 9266
	// (get) Token: 0x0601AAF1 RID: 109297 RVA: 0x007F1002 File Offset: 0x007EF202
	// (set) Token: 0x0601AAF2 RID: 109298 RVA: 0x007F100A File Offset: 0x007EF20A
	public bool IsPositiveMoving
	{
		get
		{
			return this.IsPositiveMovingInternal;
		}
		protected set
		{
			if (this.IsPositiveMovingInternal == value)
			{
				return;
			}
			this.IsPositiveMovingInternal = value;
			this.OnPositiveMovingChanged();
		}
	}

	// Token: 0x0601AAF3 RID: 109299 RVA: 0x007F1023 File Offset: 0x007EF223
	protected virtual void OnPositiveMovingChanged()
	{
	}

	// Token: 0x0601AAF4 RID: 109300 RVA: 0x007F1028 File Offset: 0x007EF228
	protected override bool OnStart()
	{
		this.DisableKey = new int?(base.Disable("[SplineMoveComponent.OnStart] 默认Disable"));
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.TeleportChangeLocation, new Action(this.OnTeleportWrapper));
		return true;
	}

	// Token: 0x0601AAF5 RID: 109301 RVA: 0x007F1090 File Offset: 0x007EF290
	protected override void OnTick(float delta)
	{
		SplineMoveParams currentSplineMoveParams = this.CurrentSplineMoveParams;
		if (currentSplineMoveParams == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.Movement, ELogAuthor.LCZ, "Tick in No SplineMove!", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.DisableKey = new int?(base.Disable("[SplineMoveComponent.OnTick] this.CurrentSplineMoveParams为false"));
			return;
		}
		if (!this.SplineMoveParamsMap.ContainsKey(currentSplineMoveParams.Id) && currentSplineMoveParams.EarliestLeaveTime <= Singleton<Time>.Instance.NowSeconds)
		{
			if (currentSplineMoveParams.IsDelayClear)
			{
				currentSplineMoveParams.EnableParams(false);
			}
			if (!this.SelectNextSplineMove())
			{
				return;
			}
		}
		this.UpdateSplineLocationAndDirection();
		this.UpdateLastSplineLocationAndDirection();
		float deltaSeconds = delta * 0.001f;
		this.PositionAdjust(this.SplineTimeKey, deltaSeconds);
		this.InputAdjust();
		this.CheckAutoExitCurrentSpline();
		this.LastLocation.DeepCopy(this.TargetLocation);
		this.LastTimeKey = this.SplineTimeKey;
		this.UpdateSplineGravity(ESplineGravityUpdateType.Update);
	}

	// Token: 0x0601AAF6 RID: 109302 RVA: 0x007F1167 File Offset: 0x007EF367
	protected override bool OnEnd()
	{
		this.ClearSplineMoveParams();
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.TeleportChangeLocation, new Action(this.OnTeleportWrapper));
		return true;
	}

	// Token: 0x0601AAF7 RID: 109303 RVA: 0x007F1194 File Offset: 0x007EF394
	protected virtual void PositionAdjust(float timeKey, float deltaSeconds)
	{
		ESplineMovePattern currentSplineMoveType = this.CurrentSplineMoveType;
		if (currentSplineMoveType <= ESplineMovePattern.SlideTrack)
		{
			this.PositionAdjustCommon(timeKey, deltaSeconds);
		}
	}

	// Token: 0x0601AAF8 RID: 109304 RVA: 0x007F11B4 File Offset: 0x007EF3B4
	protected virtual void PositionAdjustCommon(float timeKey, float deltaSeconds)
	{
		this.TargetLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.CheckAndLimitOnlyForwardMove();
		this.LimitMaxMove();
		this.MoveToTargetLocation(deltaSeconds);
	}

	// Token: 0x0601AAF9 RID: 109305 RVA: 0x007F11E0 File Offset: 0x007EF3E0
	protected void LimitMaxMove()
	{
		SplineMoveParams currentSplineMoveParamsInternal = this.CurrentSplineMoveParamsInternal;
		this.SplineLocation.Subtraction(this.TargetLocation, this.OffsetVector);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.OffsetVector);
		this.SplineQuat.UnRotateVector(this.OffsetVector, this.OffsetVector);
		this.OffsetVector.X = 0.0;
		float currentMaxOffset = this.CurrentSplineMoveParamsInternal.CurrentMaxOffset;
		if (currentMaxOffset < 0f)
		{
			return;
		}
		double num;
		if (this.Using3d)
		{
			num = this.OffsetVector.Size();
			if (num > (double)currentMaxOffset)
			{
				this.OffsetVector.Multiply((num - (double)currentMaxOffset) / num, this.TmpVector);
				this.SplineQuat.RotateVector(this.TmpVector, this.TmpVector);
				this.TargetLocation.AdditionEqual(this.TmpVector);
			}
		}
		else
		{
			num = Math.Abs(this.OffsetVector.Y);
			if (num > (double)currentMaxOffset)
			{
				this.TmpVector.Set(0.0, (double)Math.Sign(this.OffsetVector.Y) * (num - (double)currentMaxOffset), 0.0);
				this.SplineQuat.RotateVector(this.TmpVector, this.TmpVector);
				this.TargetLocation.AdditionEqual(this.TmpVector);
			}
		}
		currentSplineMoveParamsInternal.CurrentMaxOffset = (float)Math.Max((double)currentSplineMoveParamsInternal.MaxOffsetDist, Math.Min((double)currentSplineMoveParamsInternal.CurrentMaxOffset, num));
	}

	// Token: 0x0601AAFA RID: 109306 RVA: 0x007F1360 File Offset: 0x007EF560
	protected virtual void MoveToTargetLocation(float deltaSeconds)
	{
		if (Vector.DistSquared(this.ActorComp.ActorLocationProxy, this.TargetLocation) <= 1E-08)
		{
			return;
		}
		this.ActorComp.SetActorLocation(this.TargetLocation.ToUeVector(false), "样条移动", false);
	}

	// Token: 0x0601AAFB RID: 109307 RVA: 0x007F13B0 File Offset: 0x007EF5B0
	protected bool CheckAndLimitOnlyForwardMove()
	{
		this.ActorComp.ActorLocationProxy.Subtraction(this.LastLocation, this.TmpVector);
		bool flag = this.TmpVector.DotProduct(this.SplineDirection) > 0.0;
		if (!this.CurrentSplineMoveParamsInternal.OnlyForward || flag)
		{
			return false;
		}
		this.LastLocation.Subtraction(this.TargetLocation, this.OffsetVector);
		double inB = this.SplineDirection.DotProduct(this.OffsetVector);
		this.SplineDirection.Multiply(inB, this.TmpVector);
		this.TargetLocation.AdditionEqual(this.TmpVector);
		return true;
	}

	// Token: 0x0601AAFC RID: 109308 RVA: 0x007F145B File Offset: 0x007EF65B
	protected virtual void InputAdjust()
	{
	}

	// Token: 0x0601AAFD RID: 109309 RVA: 0x007F1460 File Offset: 0x007EF660
	public void StartSplineMove(int id, ISplineMovePattern config, bool allowInherit = false)
	{
		if (!this.StartMoveConditionCheck(id, config))
		{
			return;
		}
		SplineMoveParams splineMoveParams = new SplineMoveParams();
		splineMoveParams.InitBase(id, config, base.Entity);
		splineMoveParams.AllowInherit = allowInherit;
		this.StartSplineMoveInternal(splineMoveParams);
	}

	// Token: 0x0601AAFE RID: 109310 RVA: 0x007F149C File Offset: 0x007EF69C
	public void InheritStartSplineMove(SplineMoveParams splineMoveParams)
	{
		if (!this.StartMoveConditionCheck(splineMoveParams.Id, splineMoveParams.Config))
		{
			return;
		}
		SplineMoveParams splineMoveParams2 = new SplineMoveParams();
		if (splineMoveParams.Id == -1 && splineMoveParams.Type == ESplineMovePattern.MotorcycleTrack)
		{
			splineMoveParams2.InitByAutoPilotRoute(splineMoveParams.AutopilotRoute, base.Entity);
		}
		else
		{
			splineMoveParams2.InitBase(splineMoveParams.Id, splineMoveParams.Config, base.Entity);
		}
		splineMoveParams.MarkInherited = true;
		splineMoveParams2.AllowInherit = true;
		this.StartSplineMoveInternal(splineMoveParams2);
	}

	// Token: 0x0601AAFF RID: 109311 RVA: 0x007F151C File Offset: 0x007EF71C
	public void StartSplineMoveWithAutoPilotRoute(UAutopilotRoute autoPilotRoute)
	{
		SplineMoveParams splineMoveParams = new SplineMoveParams();
		splineMoveParams.InitByAutoPilotRoute(autoPilotRoute, base.Entity);
		this.StartSplineMoveInternal(splineMoveParams);
	}

	// Token: 0x0601AB00 RID: 109312 RVA: 0x007F1544 File Offset: 0x007EF744
	public unsafe virtual void StartSplineMoveInternal(SplineMoveParams config)
	{
		int id = config.Id;
		if (this.DisableKey != null)
		{
			base.Enable(new int?(this.DisableKey.Value), "SplineMoveComponent.StartSplineMoveInternal");
			this.DisableKey = null;
			this.OnSplineMoveEnable(id, config);
		}
		this.AddSplineMoveParams(id, config);
		this.SelectNextSplineMove();
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "StartSplineMove";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Spline Id", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorComp.Owner);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StackCount", this.SplineStack.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601AB01 RID: 109313 RVA: 0x007F162C File Offset: 0x007EF82C
	public unsafe void EndSplineMove(int id)
	{
		if (!this.EndMoveConditionCheck(id))
		{
			return;
		}
		bool flag = this.CurrentSplineMoveParamsInternal.EarliestLeaveTime > Singleton<Time>.Instance.NowSeconds;
		this.RemoveSplineMoveParams(id, flag);
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "EndSplineMove";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Spline Id", id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorComp.Owner);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StackCount", this.SplineStack.Count);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (flag)
		{
			return;
		}
		this.SelectNextSplineMove();
	}

	// Token: 0x0601AB02 RID: 109314 RVA: 0x007F16F6 File Offset: 0x007EF8F6
	public void EndSplineMoveForAutoPilot()
	{
		this.EndSplineMove(-1);
	}

	// Token: 0x0601AB03 RID: 109315 RVA: 0x007F16FF File Offset: 0x007EF8FF
	public void ForceStopSplineMove()
	{
		if (this.DisableKey == null)
		{
			this.DisableKey = new int?(base.Disable("SplineMoveComponent.ForceStopSplineMove"));
			this.OnSplineMoveDisable();
		}
		this.CurrentSplineMoveParamsInternal = null;
		this.ClearSplineMoveParams();
	}

	// Token: 0x0601AB04 RID: 109316 RVA: 0x007F1737 File Offset: 0x007EF937
	public virtual bool IsPlannerMove()
	{
		return true;
	}

	// Token: 0x0601AB05 RID: 109317 RVA: 0x007F173A File Offset: 0x007EF93A
	protected virtual bool StartMoveConditionCheck(int id, ISplineMovePattern config)
	{
		return this.SplineStack.Count <= 0 || this.SplineStack[this.SplineStack.Count - 1] != id;
	}

	// Token: 0x0601AB06 RID: 109318 RVA: 0x007F1768 File Offset: 0x007EF968
	protected virtual bool EndMoveConditionCheck(int id)
	{
		return this.SplineMoveParamsMap.ContainsKey(id);
	}

	// Token: 0x0601AB07 RID: 109319 RVA: 0x007F177C File Offset: 0x007EF97C
	protected bool SelectNextSplineMove()
	{
		this.OnSelectNextSplineMoveBegin();
		if (this.SplineStack.Count > 0)
		{
			SplineMoveParams currentSplineMoveParamsInternal = this.SplineMoveParamsMap[this.SplineStack[this.SplineStack.Count - 1]];
			this.CurrentSplineMoveParamsInternal = currentSplineMoveParamsInternal;
			this.UpdateSplineLocationAndDirection();
		}
		else
		{
			if (this.DisableKey == null)
			{
				this.DisableKey = new int?(base.Disable("[SplineMoveComponent.EndSplineMove] 没有下一个SplineMove"));
				this.OnSplineMoveDisable();
			}
			this.CurrentSplineMoveParamsInternal = null;
		}
		this.OnSelectNextSplineMoveEnd();
		return this.CurrentSplineMoveParams != null;
	}

	// Token: 0x0601AB08 RID: 109320 RVA: 0x007F180F File Offset: 0x007EFA0F
	protected void AddSplineMoveParams(int id, SplineMoveParams config)
	{
		if (!this.SplineMoveParamsMap.ContainsKey(id))
		{
			config.EnableParams(true);
			this.SplineMoveParamsMap[id] = config;
		}
		this.SplineStack.Add(id);
	}

	// Token: 0x0601AB09 RID: 109321 RVA: 0x007F1840 File Offset: 0x007EFA40
	protected void RemoveSplineMoveParams(int id, bool bDelayClear)
	{
		SplineMoveParams splineMoveParams;
		if (this.SplineMoveParamsMap.TryGetValue(id, out splineMoveParams))
		{
			if (!bDelayClear)
			{
				splineMoveParams.EnableParams(false);
			}
			splineMoveParams.IsDelayClear = bDelayClear;
		}
		this.SplineMoveParamsMap.Remove(id);
		while (this.SplineStack.Count > 0 && !this.SplineMoveParamsMap.ContainsKey(this.SplineStack[this.SplineStack.Count - 1]))
		{
			this.SplineStack.RemoveAt(this.SplineStack.Count - 1);
		}
	}

	// Token: 0x0601AB0A RID: 109322 RVA: 0x007F18C8 File Offset: 0x007EFAC8
	protected void ClearSplineMoveParams()
	{
		foreach (int splineId in this.SplineMoveParamsMap.Keys)
		{
			ModelBase<GameSplineModel>.Instance.ReleaseSpline(splineId, (long)base.Entity.Id, EIdType.EntityId);
		}
		this.SplineMoveParamsMap.Clear();
		this.SplineStack.Clear();
	}

	// Token: 0x0601AB0B RID: 109323 RVA: 0x007F1948 File Offset: 0x007EFB48
	protected virtual void OnSplineMoveEnable(int id, SplineMoveParams config)
	{
	}

	// Token: 0x0601AB0C RID: 109324 RVA: 0x007F194A File Offset: 0x007EFB4A
	protected virtual void OnSplineMoveDisable()
	{
	}

	// Token: 0x0601AB0D RID: 109325 RVA: 0x007F194C File Offset: 0x007EFB4C
	protected virtual void OnSelectNextSplineMoveBegin()
	{
		SplineMoveParams currentSplineMoveParams = this.CurrentSplineMoveParams;
		this.CacheNeedUpdateSplineGravityLeave = (currentSplineMoveParams != null && currentSplineMoveParams.UseSplineGravity);
	}

	// Token: 0x0601AB0E RID: 109326 RVA: 0x007F1968 File Offset: 0x007EFB68
	protected virtual void OnSelectNextSplineMoveEnd()
	{
		this.LastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.LastSplineDirection.DeepCopy(this.SplineDirection);
		this.LastSplineLocation.DeepCopy(this.SplineLocation);
		this.LastTimeKey = -1f;
		SplineMoveParams currentSplineMoveParams = this.CurrentSplineMoveParams;
		if (currentSplineMoveParams != null && currentSplineMoveParams.UseSplineGravity)
		{
			this.UpdateSplineGravity(ESplineGravityUpdateType.Enter);
			return;
		}
		if (this.CacheNeedUpdateSplineGravityLeave)
		{
			this.UpdateSplineGravity(ESplineGravityUpdateType.Leave);
		}
	}

	// Token: 0x0601AB0F RID: 109327 RVA: 0x007F19E4 File Offset: 0x007EFBE4
	protected virtual void UpdateSplineLocationAndDirection()
	{
		USplineComponent spline = this.CurrentSplineMoveParams.Spline;
		FVectorDouble fvectorDouble;
		float num;
		if (this.CurrentSplineMoveParams.UseSplineGravity || this.Using3d)
		{
			USplineComponent usplineComponent = spline;
			fvectorDouble = this.ActorComp.ActorLocationProxy.ToUeVector(false);
			num = usplineComponent.D_FindInputKeyClosestToWorldLocation(fvectorDouble);
		}
		else
		{
			USplineComponent usplineComponent2 = spline;
			fvectorDouble = this.ActorComp.ActorLocationProxy.ToUeVector(false);
			num = usplineComponent2.D_FindInputKeyClosestToWorldLocationInGravity(fvectorDouble, this.ActorComp.ActorGravityDirectProxy.ToUeVectorOld(), this.CurrentSplineMoveParams.LayerVerticalLimit);
		}
		this.SplineTimeKey = num;
		Vector splineLocation = this.SplineLocation;
		fvectorDouble = spline.D_GetLocationAtSplineInputKey(num, ESplineCoordinateSpace.World);
		splineLocation.FromUeVector(fvectorDouble);
		Vector splineDirection = this.SplineDirection;
		FVector directionAtSplineInputKey = spline.GetDirectionAtSplineInputKey(num, ESplineCoordinateSpace.World);
		fvectorDouble = directionAtSplineInputKey;
		splineDirection.DeepCopy(fvectorDouble);
		if (this.CurrentSplineMoveParams.OnlyForward || this.CurrentSplineMoveParams.OnlyPositiveMove)
		{
			this.IsPositiveMoving = true;
		}
		else
		{
			Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
			double num2 = this.SplineDirection.DotProduct(actorForwardProxy);
			this.IsPositiveMoving = (num2 >= 0.0);
		}
		if (this.IsPlannerMove())
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.SplineDirection);
		}
		this.SplineDirection.Normalize(9.99999993922529E-09);
		this.ActorComp.ActorGravityDirectProxy.UnaryNegation(this.TmpVector);
		if (this.IsPositiveMoving)
		{
			this.TmpVector1.DeepCopy(this.SplineDirection);
		}
		else
		{
			this.SplineDirection.UnaryNegation(this.TmpVector1);
		}
		if (this.Using3d)
		{
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TmpVector1, this.TmpVector, this.SplineQuat);
			return;
		}
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TmpVector1, this.TmpVector, this.SplineQuat);
	}

	// Token: 0x0601AB10 RID: 109328 RVA: 0x007F1BB4 File Offset: 0x007EFDB4
	protected void UpdateLastSplineLocationAndDirection()
	{
		if (this.LastTimeKey == -1f)
		{
			return;
		}
		USplineComponent spline = this.CurrentSplineMoveParamsInternal.Spline;
		Vector lastSplineLocation = this.LastSplineLocation;
		FVectorDouble fvectorDouble = spline.D_GetLocationAtSplineInputKey(this.LastTimeKey, ESplineCoordinateSpace.World);
		lastSplineLocation.FromUeVector(fvectorDouble);
		Vector lastSplineDirection = this.LastSplineDirection;
		FVector directionAtSplineInputKey = spline.GetDirectionAtSplineInputKey(this.LastTimeKey, ESplineCoordinateSpace.World);
		lastSplineDirection.FromUeVector(directionAtSplineInputKey);
		if (this.IsPlannerMove())
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.LastSplineDirection);
		}
		this.LastSplineDirection.Normalize(9.99999993922529E-09);
	}

	// Token: 0x0601AB11 RID: 109329 RVA: 0x007F1C45 File Offset: 0x007EFE45
	protected void OnTeleportWrapper()
	{
		if (this.SplineMoveParamsMap.Count == 0 && this.SplineStack.Count == 0)
		{
			return;
		}
		this.OnTeleportChangeLocation();
	}

	// Token: 0x0601AB12 RID: 109330 RVA: 0x007F1C68 File Offset: 0x007EFE68
	protected void OnTeleportChangeLocation()
	{
		this.LastLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.LastSplineDirection.DeepCopy(this.SplineDirection);
		this.LastSplineLocation.DeepCopy(this.SplineLocation);
		this.LastTimeKey = -1f;
	}

	// Token: 0x0601AB13 RID: 109331 RVA: 0x007F1CB8 File Offset: 0x007EFEB8
	protected unsafe virtual void UpdateSplineGravity(ESplineGravityUpdateType type)
	{
		BaseGravityComponent component = base.Entity.GetComponent<BaseGravityComponent>();
		FVector upVectorAtSplineInputKey;
		FVectorDouble fvectorDouble;
		switch (type)
		{
		case ESplineGravityUpdateType.Enter:
		{
			SplineMoveParams currentSplineMoveParams = this.CurrentSplineMoveParams;
			if (currentSplineMoveParams == null || !currentSplineMoveParams.UseSplineGravity)
			{
				return;
			}
			Vector tmpVector = this.TmpVector;
			upVectorAtSplineInputKey = this.CurrentSplineMoveParams.Spline.GetUpVectorAtSplineInputKey(this.SplineTimeKey, ESplineCoordinateSpace.World);
			fvectorDouble = upVectorAtSplineInputKey;
			tmpVector.DeepCopy(fvectorDouble);
			this.TmpVector.UnaryNegation(this.TmpVector);
			if (component != null)
			{
				component.SetGravityByPriority(1, this.TmpVector, true, this.CalcGravitySwitchSmoothTime(component.GetActiveGravityDirect(), this.TmpVector), false);
				return;
			}
			return;
		}
		case ESplineGravityUpdateType.Leave:
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "ResetSpline MoveGravity";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Spline Id";
			SplineMoveParams currentSplineMoveParams2 = this.CurrentSplineMoveParams;
			ptr = new ValueTuple<string, object>(item, (currentSplineMoveParams2 != null) ? new int?(currentSplineMoveParams2.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.ActorComp.Owner);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (component != null)
			{
				component.StopGravityByPriority(1, true, this.CalcGravitySwitchSmoothTime(component.GetActiveGravityDirect(), component.GetDefaultGravityDirect()), false);
				return;
			}
			return;
		}
		}
		SplineMoveParams currentSplineMoveParams3 = this.CurrentSplineMoveParams;
		if (currentSplineMoveParams3 == null || !currentSplineMoveParams3.UseSplineGravity)
		{
			return;
		}
		Vector tmpVector2 = this.TmpVector;
		upVectorAtSplineInputKey = this.CurrentSplineMoveParams.Spline.GetUpVectorAtSplineInputKey(this.SplineTimeKey, ESplineCoordinateSpace.World);
		fvectorDouble = upVectorAtSplineInputKey;
		tmpVector2.DeepCopy(fvectorDouble);
		this.TmpVector.UnaryNegation(this.TmpVector);
		if (component != null)
		{
			component.SetGravityByPriority(1, this.TmpVector, true, -1f, false);
		}
	}

	// Token: 0x0601AB14 RID: 109332 RVA: 0x007F1E78 File Offset: 0x007F0078
	protected float CalcGravitySwitchSmoothTime(Vector from, Vector to)
	{
		SplineMoveParams currentSplineMoveParams = this.CurrentSplineMoveParams;
		float? num;
		if (currentSplineMoveParams == null)
		{
			num = null;
		}
		else
		{
			ISplineMovePattern config = currentSplineMoveParams.Config;
			num = ((config != null) ? config.GravitySwitchAngularVelocity : null);
		}
		float? num2 = num;
		if (num2 != null)
		{
			float? num3 = num2;
			float num4 = 0f;
			if (!(num3.GetValueOrDefault() <= num4 & num3 != null))
			{
				double num5 = Math.Acos(Singleton<MathUtils>.Instance.Clamp(from.DotProduct(to), -1.0, 1.0)) * 57.295780181884766;
				num3 = num2;
				return (float)(num5 / ((num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null) * (double)1000).Value;
			}
		}
		return -1f;
	}

	// Token: 0x0601AB15 RID: 109333 RVA: 0x007F1F98 File Offset: 0x007F0198
	protected void CheckAutoExitCurrentSpline()
	{
		if (this.CurrentSplineMoveParams.AutoExitSplineDist <= 0f)
		{
			return;
		}
		USplineComponent spline = this.CurrentSplineMoveParams.Spline;
		float distanceAlongSplineAtSplineInputKey = spline.GetDistanceAlongSplineAtSplineInputKey(this.SplineTimeKey);
		if (this.IsPositiveMoving)
		{
			float distanceAlongSplineAtSplineInputKey2 = spline.GetDistanceAlongSplineAtSplineInputKey((float)spline.GetNumberOfSplinePoints());
			if (distanceAlongSplineAtSplineInputKey > distanceAlongSplineAtSplineInputKey2 - this.CurrentSplineMoveParams.AutoExitSplineDist)
			{
				this.EndSplineMove(this.CurrentSplineMoveParams.Id);
				return;
			}
		}
		else if (distanceAlongSplineAtSplineInputKey < this.CurrentSplineMoveParams.AutoExitSplineDist)
		{
			this.EndSplineMove(this.CurrentSplineMoveParams.Id);
		}
	}

	// Token: 0x0601AB16 RID: 109334 RVA: 0x007F2028 File Offset: 0x007F0228
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseSplineMoveComponent baseSplineMoveComponent = (BaseSplineMoveComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (baseSplineMoveComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (baseSplineMoveComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableKey"))
		{
			this.DisableKey = baseSplineMoveComponent.DisableKey;
		}
		if (base.CanResetComponentProperty("SplineMoveParamsMap") && baseSplineMoveComponent.SplineMoveParamsMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, SplineMoveParams>>(this.SplineMoveParamsMap), "SplineMoveParamsMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SplineStack") && baseSplineMoveComponent.SplineStack != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.SplineStack), "SplineStack"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CurrentSplineMoveParamsInternal"))
		{
			if (baseSplineMoveComponent.CurrentSplineMoveParamsInternal == null)
			{
				this.CurrentSplineMoveParamsInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SplineMoveParams>(this.CurrentSplineMoveParamsInternal), "CurrentSplineMoveParamsInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsPositiveMovingInternal"))
		{
			this.IsPositiveMovingInternal = baseSplineMoveComponent.IsPositiveMovingInternal;
		}
		if (base.CanResetComponentProperty("SplineTimeKey"))
		{
			this.SplineTimeKey = baseSplineMoveComponent.SplineTimeKey;
		}
		if (base.CanResetComponentProperty("SplineDirection"))
		{
			if (baseSplineMoveComponent.SplineDirection == null)
			{
				this.SplineDirection = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SplineDirection), "SplineDirection"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SplineLocation"))
		{
			if (baseSplineMoveComponent.SplineLocation == null)
			{
				this.SplineLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.SplineLocation), "SplineLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SplineQuat"))
		{
			if (baseSplineMoveComponent.SplineQuat == null)
			{
				this.SplineQuat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.SplineQuat), "SplineQuat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastTimeKey"))
		{
			this.LastTimeKey = baseSplineMoveComponent.LastTimeKey;
		}
		if (base.CanResetComponentProperty("LastSplineLocation"))
		{
			if (baseSplineMoveComponent.LastSplineLocation == null)
			{
				this.LastSplineLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastSplineLocation), "LastSplineLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastSplineDirection"))
		{
			if (baseSplineMoveComponent.LastSplineDirection == null)
			{
				this.LastSplineDirection = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastSplineDirection), "LastSplineDirection"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Using3d"))
		{
			this.Using3d = baseSplineMoveComponent.Using3d;
		}
		if (base.CanResetComponentProperty("AllowInherit"))
		{
			this.AllowInherit = baseSplineMoveComponent.AllowInherit;
		}
		if (base.CanResetComponentProperty("InheritThisFrame"))
		{
			this.InheritThisFrame = baseSplineMoveComponent.InheritThisFrame;
		}
		if (base.CanResetComponentProperty("LastLocation"))
		{
			if (baseSplineMoveComponent.LastLocation == null)
			{
				this.LastLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastLocation), "LastLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TargetLocation"))
		{
			if (baseSplineMoveComponent.TargetLocation == null)
			{
				this.TargetLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TargetLocation), "TargetLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OffsetVector"))
		{
			if (baseSplineMoveComponent.OffsetVector == null)
			{
				this.OffsetVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.OffsetVector), "OffsetVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpVector"))
		{
			if (baseSplineMoveComponent.TmpVector == null)
			{
				this.TmpVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpVector1"))
		{
			if (baseSplineMoveComponent.TmpVector1 == null)
			{
				this.TmpVector1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector1), "TmpVector1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpVector2"))
		{
			if (baseSplineMoveComponent.TmpVector2 == null)
			{
				this.TmpVector2 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector2), "TmpVector2"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpQuat"))
		{
			if (baseSplineMoveComponent.TmpQuat == null)
			{
				this.TmpQuat = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat), "TmpQuat"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpQuat1"))
		{
			if (baseSplineMoveComponent.TmpQuat1 == null)
			{
				this.TmpQuat1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat1), "TmpQuat1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TmpRotator"))
		{
			if (baseSplineMoveComponent.TmpRotator == null)
			{
				this.TmpRotator = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator), "TmpRotator"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheNeedUpdateSplineGravityLeave"))
		{
			this.CacheNeedUpdateSplineGravityLeave = baseSplineMoveComponent.CacheNeedUpdateSplineGravityLeave;
		}
		return true;
	}

	// Token: 0x0400D848 RID: 55368
	public const int INVALID_TIME_KEY = -1;

	// Token: 0x0400D849 RID: 55369
	public const int AUTO_PILOT_ROUTE_ID = -1;

	// Token: 0x0400D84A RID: 55370
	[Nullable(2)]
	protected BaseActorComponent ActorComp;

	// Token: 0x0400D84B RID: 55371
	[Nullable(2)]
	protected BaseTagComponent TagComp;

	// Token: 0x0400D84C RID: 55372
	protected int? DisableKey;

	// Token: 0x0400D84D RID: 55373
	protected readonly Dictionary<int, SplineMoveParams> SplineMoveParamsMap = new Dictionary<int, SplineMoveParams>();

	// Token: 0x0400D84E RID: 55374
	protected readonly List<int> SplineStack = new List<int>();

	// Token: 0x0400D84F RID: 55375
	[Nullable(2)]
	protected SplineMoveParams CurrentSplineMoveParamsInternal;

	// Token: 0x0400D850 RID: 55376
	private bool IsPositiveMovingInternal = true;

	// Token: 0x0400D851 RID: 55377
	public float SplineTimeKey;

	// Token: 0x0400D852 RID: 55378
	public Vector SplineDirection = Vector.Create();

	// Token: 0x0400D853 RID: 55379
	public Vector SplineLocation = Vector.Create();

	// Token: 0x0400D854 RID: 55380
	protected Quat SplineQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D855 RID: 55381
	protected float LastTimeKey = -1f;

	// Token: 0x0400D856 RID: 55382
	protected Vector LastSplineLocation = Vector.Create();

	// Token: 0x0400D857 RID: 55383
	protected Vector LastSplineDirection = Vector.Create();

	// Token: 0x0400D858 RID: 55384
	protected bool Using3d;

	// Token: 0x0400D859 RID: 55385
	protected bool AllowInherit;

	// Token: 0x0400D85A RID: 55386
	protected bool InheritThisFrame;

	// Token: 0x0400D85B RID: 55387
	protected Vector LastLocation = Vector.Create();

	// Token: 0x0400D85C RID: 55388
	protected Vector TargetLocation = Vector.Create();

	// Token: 0x0400D85D RID: 55389
	protected Vector OffsetVector = Vector.Create();

	// Token: 0x0400D85E RID: 55390
	protected Vector TmpVector = Vector.Create();

	// Token: 0x0400D85F RID: 55391
	protected Vector TmpVector1 = Vector.Create();

	// Token: 0x0400D860 RID: 55392
	protected Vector TmpVector2 = Vector.Create();

	// Token: 0x0400D861 RID: 55393
	protected Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D862 RID: 55394
	protected Quat TmpQuat1 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400D863 RID: 55395
	protected Rotator TmpRotator = Rotator.Create();

	// Token: 0x0400D864 RID: 55396
	private bool CacheNeedUpdateSplineGravityLeave;
}
