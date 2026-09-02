using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x02004814 RID: 18452
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemTrackGuideComponent : EntityComponent
	{
		// Token: 0x06030040 RID: 196672 RVA: 0x00BA0700 File Offset: 0x00B9E900
		protected override bool OnInitData(IEntityArgs args = null)
		{
			FollowTrackComponent followTrackComponent = args.GetP1<CreateEntityData>().GetParam<SceneItemTrackGuideComponent>() as FollowTrackComponent;
			if (followTrackComponent.SplineEntityId != 0)
			{
				this.SplineEntityId = followTrackComponent.SplineEntityId;
			}
			this.IsInRange = false;
			this.UpdateState = SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineStart;
			this.HasFinished = false;
			SModelConfig modelConfig = base.Entity.GetComponent<CreatureDataComponent>().GetModelConfig();
			FGameplayTag value = GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["物体.表现.常驻特效"]).Value;
			this.UseCommonEffect = (((modelConfig != null) ? modelConfig.常驻特效列表.GetValueOrDefault(value) : null) != null);
			switch (followTrackComponent.EndType.Type)
			{
			case EFollowTrackEndType.ToStart:
				this.FoundationId = null;
				this.ReachedEndOfSplineType = new EFollowTrackEndType?(EFollowTrackEndType.ToStart);
				break;
			case EFollowTrackEndType.ToFoundation:
			{
				IFollowTrackToFoundation followTrackToFoundation = (IFollowTrackToFoundation)followTrackComponent.EndType;
				this.FoundationId = new int?(followTrackToFoundation.FoundationId);
				this.ReachedEndOfSplineType = new EFollowTrackEndType?(EFollowTrackEndType.ToFoundation);
				if (followTrackToFoundation.FinalOffset != null)
				{
					this.FoundationOffset = global::Vector.Create((double)followTrackToFoundation.FinalOffset.X.Value, (double)followTrackToFoundation.FinalOffset.Y.Value, (double)followTrackToFoundation.FinalOffset.Z.Value);
				}
				else
				{
					this.FoundationOffset = global::Vector.Create();
				}
				break;
			}
			case EFollowTrackEndType.ToSplineDestination:
				this.ReachedEndOfSplineType = new EFollowTrackEndType?(EFollowTrackEndType.ToSplineDestination);
				break;
			}
			this.DistanceAlongSpline = 0f;
			this.TargetPointIndex = 0;
			this.NeedCheckWait = true;
			this.FoundationLocation = global::Vector.Create();
			this.SplineStartLocation = global::Vector.Create();
			this.SplineEndLocation = global::Vector.Create();
			this.DirectionCache = global::Vector.Create();
			this.DistanceBetweenLastTwoPointsInverse = 0f;
			this.PawnSensoryInfo = base.Entity.GetComponent<PawnSensoryInfoComponent>();
			this.PawnSensoryInfo.SetLogicRange(followTrackComponent.Range);
			this.AddEvents();
			return true;
		}

		// Token: 0x06030041 RID: 196673 RVA: 0x00BA08EC File Offset: 0x00B9EAEC
		private void AddEvents()
		{
			if (this.UseCommonEffect)
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnAddCommonEffect, new Action(this.OnAddCommonEffect));
			}
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.EnterLogicRange, new Action(this.OnEnterLogicRange));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.LeaveLogicRange, new Action(this.OnLeaveLogicRange));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
		}

		// Token: 0x06030042 RID: 196674 RVA: 0x00BA0984 File Offset: 0x00B9EB84
		private void RemoveEvents()
		{
			if (this.UseCommonEffect)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnAddCommonEffect, new Action(this.OnAddCommonEffect));
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.EnterLogicRange, new Action(this.OnEnterLogicRange));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.LeaveLogicRange, new Action(this.OnLeaveLogicRange));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
		}

		// Token: 0x06030043 RID: 196675 RVA: 0x00BA0A1C File Offset: 0x00B9EC1C
		protected unsafe override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<SceneItemActorComponent>();
			if (this.ActorComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneGameplay, ELogAuthor.CJH, "[SceneItemTrackGuideComponent] SceneItemPatrolComponent初始化失败 Actor Component Undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			CreatureDataComponent creatureData = this.ActorComp.CreatureData;
			BaseInfoComponent baseInfo = creatureData.GetBaseInfo();
			if (baseInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "[PawnAdsorbComponent.OnStart] SceneItemPatrolComponent初始化失败 Config Invalid";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureGenID:", creatureData.GetOwnerId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId:", creatureData.GetPbDataId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			this.OnlineInteractType = new EOnlineInteractType?(baseInfo.OnlineInteractType);
			if (this.OnlineInteractType.GetValueOrDefault() == EOnlineInteractType.EveryOne)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.SceneGameplay;
				ELogAuthor author2 = ELogAuthor.CJH;
				string message2 = "[PawnAdsorbComponent.OnStart] 不支持的联机类型配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureGenID:", creatureData.GetOwnerId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId:", creatureData.GetPbDataId());
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				this.OnlineInteractType = new EOnlineInteractType?(EOnlineInteractType.HostOnly);
			}
			this.PerformanceComp = base.Entity.GetComponent<PerformanceComponent>();
			this.PropertyComp = base.Entity.GetComponent<SceneItemPropertyComponent>();
			this.SyncComp = base.Entity.GetComponent<SceneItemMovementSyncComponent>();
			this.MoveComp = base.Entity.GetComponent<SceneItemMoveComponent>();
			if (ModelBase<GameModeModel>.Instance.IsMulti && !ControllerBase<LevelGamePlayController>.Instance.MultiplayerLimitTypeCheck(this.OnlineInteractType.Value, false))
			{
				this.DisableHandle = new int?(base.Disable("[SceneItemTrackGuideComponent.OnStart] 联机停止交互"));
				return true;
			}
			this.InitSpline();
			return true;
		}

		// Token: 0x06030044 RID: 196676 RVA: 0x00BA0BF9 File Offset: 0x00B9EDF9
		protected override void OnActivate()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti && !ControllerBase<LevelGamePlayController>.Instance.MultiplayerLimitTypeCheck(this.OnlineInteractType.Value, false))
			{
				SceneItemMovementSyncComponent syncComp = this.SyncComp;
				if (syncComp == null)
				{
					return;
				}
				syncComp.SetEnableMovementSync(true, "SceneItemTrackGuideComponent OnActivate");
			}
		}

		// Token: 0x06030045 RID: 196677 RVA: 0x00BA0C38 File Offset: 0x00B9EE38
		private void InitSpline()
		{
			USplineComponent usplineComponent = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(this.SplineEntityId, this.ActorComp.CreatureData.GetPbDataId(), EIdType.PbDataId);
			if (usplineComponent == null)
			{
				return;
			}
			this.PathLine = usplineComponent;
			TsGameSplineActor splineActorBySplineId = ModelBase<GameSplineModel>.Instance.GetSplineActorBySplineId(this.SplineEntityId);
			global::Vector splineStartLocation = this.SplineStartLocation;
			FVectorDouble fvectorDouble = usplineComponent.D_GetLocationAtDistanceAlongSpline(0f, ESplineCoordinateSpace.World);
			splineStartLocation.FromUeVector(fvectorDouble);
			this.NumSplinePoints = usplineComponent.GetNumberOfSplinePoints();
			ISplineType splineData = splineActorBySplineId.SplineData;
			this.WaitConfig = new List<bool>(this.NumSplinePoints);
			this.SpeedConfig = new List<float>(this.NumSplinePoints);
			List<float> list = new List<float>(this.NumSplinePoints);
			for (int i = 0; i < this.NumSplinePoints; i++)
			{
				this.WaitConfig.Add(!SceneItemTrackGuideComponent.IsSplinePointIgnored(splineData, i));
				list.Add(0f);
			}
			for (int j = 0; j < this.NumSplinePoints; j++)
			{
				this.LastSpeed = Singleton<MathUtils>.Instance.Clamp(SceneItemTrackGuideComponent.GetSplinePointMoveSpeed(splineData, j), 50f, 800f);
				this.SpeedConfig.Add(this.LastSpeed);
			}
			this.SplineMoveParam = new SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam(usplineComponent);
			SceneItemSplineMoveTaskUtils.ParseOldConfigToSplineMoveParam(usplineComponent, this.SpeedConfig, list, false, false, true, 0f, this.SplineMoveParam);
			this.SplineLength = usplineComponent.GetSplineLength();
			global::Vector splineEndLocation = this.SplineEndLocation;
			fvectorDouble = usplineComponent.D_GetLocationAtSplinePoint(this.NumSplinePoints - 1, ESplineCoordinateSpace.World);
			splineEndLocation.FromUeVector(fvectorDouble);
			if (this.FoundationLocation != null)
			{
				this.SplineEndLocation.Subtraction(this.FoundationLocation, this.DirectionCache);
				if (this.DirectionCache.SizeSquared() < 10000.0)
				{
					this.WaitConfig[this.NumSplinePoints - 1] = false;
					this.SpeedConfig[this.NumSplinePoints - 1] = 150f;
					this.LastSpeed = 150f;
				}
			}
			if (this.NumSplinePoints >= 2)
			{
				this.DistanceBetweenLastTwoPointsInverse = this.SplineLength - usplineComponent.GetDistanceAlongSplineAtSplinePoint(this.NumSplinePoints - 2);
				if ((double)this.DistanceBetweenLastTwoPointsInverse <= 1.0)
				{
					this.DistanceBetweenLastTwoPointsInverse = 0f;
					return;
				}
				this.DistanceBetweenLastTwoPointsInverse = 1f / this.DistanceBetweenLastTwoPointsInverse;
			}
		}

		// Token: 0x06030046 RID: 196678 RVA: 0x00BA0E6C File Offset: 0x00B9F06C
		private static bool IsSplinePointIgnored(ISplineType splineData, int index)
		{
			IButterflySpline butterflySpline = splineData as IButterflySpline;
			bool result;
			if (butterflySpline == null)
			{
				IPatrolSpline patrolSpline = splineData as IPatrolSpline;
				result = (patrolSpline != null && patrolSpline.Points[index].IgnorePoint.GetValueOrDefault());
			}
			else
			{
				result = butterflySpline.Points[index].IgnorePoint;
			}
			return result;
		}

		// Token: 0x06030047 RID: 196679 RVA: 0x00BA0EC4 File Offset: 0x00B9F0C4
		private static float GetSplinePointMoveSpeed(ISplineType splineData, int index)
		{
			IButterflySpline butterflySpline = splineData as IButterflySpline;
			int num;
			if (butterflySpline == null)
			{
				IPatrolSpline patrolSpline = splineData as IPatrolSpline;
				if (patrolSpline == null)
				{
					num = 800;
				}
				else
				{
					num = patrolSpline.Points[index].MoveSpeed;
				}
			}
			else
			{
				num = butterflySpline.Points[index].MoveSpeed;
			}
			return (float)num;
		}

		// Token: 0x06030048 RID: 196680 RVA: 0x00BA0F17 File Offset: 0x00B9F117
		protected override void OnTick(float delta)
		{
			if (this.HasFinished || (this.UseCommonEffect && !this.CommonEffectInit))
			{
				return;
			}
			if (this.UpdateState != SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineEnd)
			{
				this.UpdateNoSplineMovement(delta);
				return;
			}
			this.UpdateSplineMovement(delta);
		}

		// Token: 0x06030049 RID: 196681 RVA: 0x00BA0F4C File Offset: 0x00B9F14C
		private void UpdateSplineMovement(float delta)
		{
			USplineComponent pathLine = this.PathLine;
			if (pathLine != null && pathLine.IsValid() && this.SplineMoveParam != null)
			{
				SceneItemActorComponent actorComp = this.ActorComp;
				if (actorComp == null || !actorComp.CreatureData.GetRemoveState())
				{
					if (this.NeedCheckWait && this.CheckAndUpdateIfNeedWaiting())
					{
						if (this.ShouldBeMoving)
						{
							this.ShouldBeMoving = false;
							SceneItemMovementSyncComponent syncComp = this.SyncComp;
							if (syncComp != null)
							{
								syncComp.SetEnableMovementSync(false, "SceneItemTrackGuideComponent UpdateSplineMovement MoveStop");
							}
							this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 0f);
							SceneItemMoveComponent moveComp = this.MoveComp;
							if (moveComp == null)
							{
								return;
							}
							moveComp.StopMove(true, true);
						}
						return;
					}
					USplineComponent pathLine2 = this.PathLine;
					int targetPointIndex = this.TargetPointIndex;
					float distanceAlongSplineAtSplinePoint = pathLine2.GetDistanceAlongSplineAtSplinePoint(targetPointIndex);
					SceneItemMoveComponent moveComp2 = this.MoveComp;
					if (moveComp2 != null && moveComp2.IsMoving)
					{
						this.DistanceAlongSpline = this.MoveComp.GetDistanceAloneSpline();
					}
					if (!this.ShouldBeMoving)
					{
						this.ShouldBeMoving = true;
						this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 1f);
						if (!this.HasTriggered)
						{
							this.HasTriggered = true;
							this.ReportTrigger();
						}
					}
					base.Entity.ChangeTickInterval(0);
					SceneItemMoveComponent moveComp3 = this.MoveComp;
					if (moveComp3 == null || !moveComp3.IsMoving)
					{
						this.SplineMoveParam.StartDis = this.DistanceAlongSpline;
						this.SplineMoveParam.EndDis = distanceAlongSplineAtSplinePoint;
						SceneItemMoveComponent moveComp4 = this.MoveComp;
						if (moveComp4 != null)
						{
							moveComp4.StartSplineMoveAtConstantTimeImplement(this.SplineMoveParam, new Action(this.SplineMoveStopCallback), true);
						}
					}
					if (this.ReachedEndOfSplineType.GetValueOrDefault() == EFollowTrackEndType.ToFoundation && this.PerformanceComp != null && this.TargetPointIndex == this.NumSplinePoints - 1)
					{
						float alpha = (this.SplineLength - this.DistanceAlongSpline) * this.DistanceBetweenLastTwoPointsInverse;
						float value = Singleton<MathUtils>.Instance.Lerp(0f, 50f, alpha);
						this.PerformanceComp.ApplyNiagaraParameters("Radius", value);
						this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 1f);
					}
					return;
				}
			}
		}

		// Token: 0x0603004A RID: 196682 RVA: 0x00BA1144 File Offset: 0x00B9F344
		private void SplineMoveStopCallback()
		{
			this.ShouldBeMoving = false;
			this.NeedCheckWait = true;
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.CollectSampleAndSend(false);
			}
			SceneItemMovementSyncComponent syncComp2 = this.SyncComp;
			if (syncComp2 != null)
			{
				syncComp2.SetEnableMovementSync(false, "SceneItemTrackGuideComponent SplineMoveStopCallback");
			}
			USplineComponent pathLine = this.PathLine;
			if (pathLine != null && pathLine.IsValid())
			{
				SceneItemActorComponent actorComp = this.ActorComp;
				if (actorComp == null || !actorComp.CreatureData.GetRemoveState())
				{
					USplineComponent pathLine2 = this.PathLine;
					this.DistanceAlongSpline = pathLine2.GetDistanceAlongSplineAtSplinePoint(this.TargetPointIndex);
					this.TargetPointIndex++;
					if (this.TargetPointIndex > this.NumSplinePoints - 1)
					{
						this.TargetPointIndex = this.NumSplinePoints - 1;
						this.DistanceAlongSpline = this.SplineLength;
						EFollowTrackEndType? reachedEndOfSplineType = this.ReachedEndOfSplineType;
						if (reachedEndOfSplineType != null)
						{
							switch (reachedEndOfSplineType.GetValueOrDefault())
							{
							case EFollowTrackEndType.ToStart:
								this.UpdateState = SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineStart;
								break;
							case EFollowTrackEndType.ToFoundation:
								this.UpdateState = SceneItemTrackGuideComponent.EUpdateState.UpdateToFoundation;
								break;
							case EFollowTrackEndType.ToSplineDestination:
								this.UpdateState = SceneItemTrackGuideComponent.EUpdateState.UpdateToStopAtEnd;
								break;
							}
						}
					}
					if (this.ReachedEndOfSplineType.GetValueOrDefault() == EFollowTrackEndType.ToFoundation && this.PerformanceComp != null && this.TargetPointIndex == this.NumSplinePoints - 1)
					{
						float alpha = (this.SplineLength - this.DistanceAlongSpline) * this.DistanceBetweenLastTwoPointsInverse;
						float value = Singleton<MathUtils>.Instance.Lerp(0f, 50f, alpha);
						this.PerformanceComp.ApplyNiagaraParameters("Radius", value);
						this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 1f);
					}
					return;
				}
			}
		}

		// Token: 0x0603004B RID: 196683 RVA: 0x00BA12CC File Offset: 0x00B9F4CC
		private void UpdateNoSplineMovement(float delta)
		{
			if (this.NeedCheckWait && this.CheckAndUpdateIfNeedWaiting())
			{
				if (this.ShouldBeMoving)
				{
					this.ShouldBeMoving = false;
					SceneItemMovementSyncComponent syncComp = this.SyncComp;
					if (syncComp != null)
					{
						syncComp.CollectSampleAndSend(false);
					}
					SceneItemMovementSyncComponent syncComp2 = this.SyncComp;
					if (syncComp2 != null)
					{
						syncComp2.SetEnableMovementSync(false, "SceneItemTrackGuideComponent UpdateNoSplineMovement MoveStop");
					}
					this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 0f);
				}
				return;
			}
			if (!this.ShouldBeMoving)
			{
				this.ShouldBeMoving = true;
				this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 1f);
				if (!this.HasTriggered)
				{
					this.HasTriggered = true;
					this.ReportTrigger();
				}
			}
			base.Entity.ChangeTickInterval(0);
			switch (this.UpdateState)
			{
			case SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineStart:
				this.UpdateToSplineStart(delta);
				if (this.CheckIfReach(this.SplineStartLocation))
				{
					this.OnTrackGuideReset();
					return;
				}
				break;
			case SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineEnd:
				break;
			case SceneItemTrackGuideComponent.EUpdateState.UpdateToFoundation:
				this.UpdateToFoundation(delta);
				if (this.CheckIfReach(this.FoundationLocation))
				{
					this.ActorComp.SetActorLocation(this.FoundationLocation.ToUeVector(false), "unknown", true);
					this.OnTrackGuideFinish();
					return;
				}
				break;
			case SceneItemTrackGuideComponent.EUpdateState.UpdateToStopAtEnd:
				this.UpdateToStopAtEnd(delta);
				if (this.CheckIfReach(this.SplineEndLocation))
				{
					this.OnTrackGuideFinish();
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0603004C RID: 196684 RVA: 0x00BA1410 File Offset: 0x00B9F610
		private void UpdateToSplineStart(float delta)
		{
			USplineComponent pathLine = this.PathLine;
			if (pathLine == null || !pathLine.IsValid())
			{
				return;
			}
			SceneItemMoveComponent moveComp = this.MoveComp;
			if (moveComp != null && moveComp.IsMoving)
			{
				return;
			}
			double num = global::Vector.Dist(this.ActorComp.ActorLocationProxy, this.SplineStartLocation) / 600.0;
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.SetEnableMovementSync(true, "UpdateNoSplineMovement UpdateToSplineStart");
			}
			SceneItemMoveComponent moveComp2 = this.MoveComp;
			if (moveComp2 != null)
			{
				moveComp2.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(global::Vector.Create(this.SplineStartLocation), (float)num, 0f, -1f, -1f));
			}
			this.HasMoveStart = true;
		}

		// Token: 0x0603004D RID: 196685 RVA: 0x00BA14BC File Offset: 0x00B9F6BC
		private void UpdateToFoundation(float delta)
		{
			bool flag = (this.FoundationId ?? 0) == 0;
			if (flag)
			{
				return;
			}
			SceneItemMoveComponent moveComp = this.MoveComp;
			if (moveComp != null && moveComp.IsMoving)
			{
				return;
			}
			if (this.FoundationEntity == null)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.FoundationId.Value);
				if (entityByPbDataId == null)
				{
					return;
				}
				BaseActorComponent component = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
				if (component == null || component.Owner == null)
				{
					return;
				}
				this.FoundationEntity = entityByPbDataId;
				this.FoundationLocation.DeepCopy(component.ActorLocationProxy);
				this.FoundationLocation.AdditionEqual(this.FoundationOffset);
			}
			double num = global::Vector.Dist(this.ActorComp.ActorLocationProxy, this.FoundationLocation) / (double)this.LastSpeed;
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.SetEnableMovementSync(true, "UpdateNoSplineMovement UpdateToFoundation");
			}
			SceneItemMoveComponent moveComp2 = this.MoveComp;
			if (moveComp2 == null)
			{
				return;
			}
			moveComp2.AddMoveTarget(new SceneItemMoveComponent.MoveTarget(global::Vector.Create(this.FoundationLocation), (float)num, 0f, -1f, -1f));
		}

		// Token: 0x0603004E RID: 196686 RVA: 0x00BA15D0 File Offset: 0x00B9F7D0
		private void UpdateToStopAtEnd(float delta)
		{
			this.ActorComp.SetActorLocation(this.SplineEndLocation.ToUeVector(false), "unknown", true);
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp == null)
			{
				return;
			}
			syncComp.SetEnableMovementSync(true, "UpdateNoSplineMovement UpdateToStopAtEnd");
		}

		// Token: 0x0603004F RID: 196687 RVA: 0x00BA1608 File Offset: 0x00B9F808
		private void OnTrackGuideFinish()
		{
			SceneItemMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.StopMove(true, true);
			}
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.CollectSampleAndSend(false);
			}
			SceneItemMovementSyncComponent syncComp2 = this.SyncComp;
			if (syncComp2 != null)
			{
				syncComp2.SetEnableMovementSync(false, "UpdateNoSplineMovement OnTrackGuideFinish");
			}
			this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 0f);
			this.PerformanceComp.ApplyNiagaraParameters("IsDying", 1f);
			this.HasFinished = true;
			ControllerBase<LevelGamePlayController>.Instance.EntityFollowTrackRequest(this.ActorComp.CreatureData.GetCreatureDataId(), delegate(FollowTrackResponse response, Net.CallbackStatus _)
			{
			});
		}

		// Token: 0x06030050 RID: 196688 RVA: 0x00BA16C0 File Offset: 0x00B9F8C0
		private void OnTrackGuideReset()
		{
			this.ActorComp.SetActorLocation(this.SplineStartLocation.ToUeVector(false), "unknown", true);
			this.UpdateState = SceneItemTrackGuideComponent.EUpdateState.UpdateToSplineEnd;
			this.DistanceAlongSpline = 0f;
			this.TargetPointIndex = 0;
			this.NeedCheckWait = true;
			this.ShouldBeMoving = false;
			SceneItemMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.StopMove(true, true);
			}
			SceneItemMovementSyncComponent syncComp = this.SyncComp;
			if (syncComp != null)
			{
				syncComp.CollectSampleAndSend(false);
			}
			SceneItemMovementSyncComponent syncComp2 = this.SyncComp;
			if (syncComp2 != null)
			{
				syncComp2.SetEnableMovementSync(false, "UpdateNoSplineMovement OnTrackGuideReset");
			}
			this.HasMoveStart = true;
			this.PerformanceComp.ApplyNiagaraParameters("IsMoving", 0f);
		}

		// Token: 0x06030051 RID: 196689 RVA: 0x00BA176C File Offset: 0x00B9F96C
		private bool CheckAndUpdateIfNeedWaiting()
		{
			USplineComponent pathLine = this.PathLine;
			if (pathLine == null || !pathLine.IsValid())
			{
				this.NeedCheckWait = true;
				return true;
			}
			SceneItemPropertyComponent propertyComp = this.PropertyComp;
			if (propertyComp != null && propertyComp.IsLocked)
			{
				this.NeedCheckWait = true;
				return true;
			}
			if (this.IsInRange && !ModelBase<SceneTeamModel>.Instance.IsPhantomTeam)
			{
				this.NeedCheckWait = false;
				return false;
			}
			if (!this.HasMoveStart)
			{
				this.NeedCheckWait = true;
				return true;
			}
			int index = (this.TargetPointIndex == 0) ? 0 : (this.TargetPointIndex - 1);
			this.NeedCheckWait = this.WaitConfig[index];
			return this.NeedCheckWait;
		}

		// Token: 0x06030052 RID: 196690 RVA: 0x00BA1810 File Offset: 0x00B9FA10
		[NullableContext(1)]
		private bool CheckIfReach(global::Vector location)
		{
			return this.ActorComp != null && global::Vector.DistSquared(this.ActorComp.ActorLocationProxy, location) <= 2500.0;
		}

		// Token: 0x06030053 RID: 196691 RVA: 0x00BA183B File Offset: 0x00B9FA3B
		private void OnAddCommonEffect()
		{
			this.CommonEffectInit = true;
		}

		// Token: 0x06030054 RID: 196692 RVA: 0x00BA1844 File Offset: 0x00B9FA44
		private void OnEnterLogicRange()
		{
			this.IsInRange = true;
		}

		// Token: 0x06030055 RID: 196693 RVA: 0x00BA184D File Offset: 0x00B9FA4D
		private void OnLeaveLogicRange()
		{
			this.IsInRange = false;
		}

		// Token: 0x06030056 RID: 196694 RVA: 0x00BA1858 File Offset: 0x00B9FA58
		private void OnChangeModeFinish()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int? disableHandle = this.DisableHandle;
				if (disableHandle != null && disableHandle.GetValueOrDefault() != 0)
				{
					base.Enable(new int?(this.DisableHandle.Value), "[SceneItemTrackGuideComponent.OnChangeModeFinish] 单机启用交互");
					this.DisableHandle = null;
					return;
				}
			}
			else
			{
				if (!ControllerBase<LevelGamePlayController>.Instance.MultiplayerLimitTypeCheck(this.OnlineInteractType.Value, false))
				{
					this.DisableHandle = new int?(base.Disable("[SceneItemTrackGuideComponent.OnChangeModeFinish] 联机停止交互"));
					this.Reset();
					return;
				}
				int? disableHandle = this.DisableHandle;
				if (disableHandle != null && disableHandle.GetValueOrDefault() != 0)
				{
					base.Enable(new int?(this.DisableHandle.Value), "[SceneItemTrackGuideComponent.OnChangeModeFinish] 联机启用交互");
					this.DisableHandle = null;
				}
			}
		}

		// Token: 0x06030057 RID: 196695 RVA: 0x00BA192F File Offset: 0x00B9FB2F
		private void Reset()
		{
			if (this.HasFinished)
			{
				return;
			}
			this.OnTrackGuideReset();
		}

		// Token: 0x06030058 RID: 196696 RVA: 0x00BA1940 File Offset: 0x00B9FB40
		protected override bool OnEnd()
		{
			this.RemoveEvents();
			if (this.PathLine != null)
			{
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(this.SplineEntityId, (long)this.ActorComp.CreatureData.GetPbDataId(), EIdType.PbDataId);
			}
			return true;
		}

		// Token: 0x06030059 RID: 196697 RVA: 0x00BA1974 File Offset: 0x00B9FB74
		private void ReportTrigger()
		{
			if (this.HasReportTriggered)
			{
				return;
			}
			SceneItemTrackGuideComponent.ButterflyTriggerData butterflyTriggerData = new SceneItemTrackGuideComponent.ButterflyTriggerData();
			butterflyTriggerData.event_id = "10";
			butterflyTriggerData.i_inst_id = ModelBase<CreatureModel>.Instance.GetInstanceId();
			butterflyTriggerData.i_config_id = this.ActorComp.CreatureData.GetPbDataId().ToString();
			butterflyTriggerData.f_player_pos_x = this.ActorComp.ActorLocationProxy.X.ToString();
			butterflyTriggerData.f_player_pos_y = this.ActorComp.ActorLocationProxy.Y.ToString();
			butterflyTriggerData.f_player_pos_z = this.ActorComp.ActorLocationProxy.Z.ToString();
			butterflyTriggerData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId.ToString();
			butterflyTriggerData.s_tag = this.ActorComp.CreatureData.GetPlayerId().ToString() + "|" + this.ActorComp.CreatureData.GetCreatureDataId().ToString();
			ControllerBase<LogReportController>.Instance.LogReport(butterflyTriggerData);
			this.HasReportTriggered = true;
		}

		// Token: 0x0603005A RID: 196698 RVA: 0x00BA1A98 File Offset: 0x00B9FC98
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemTrackGuideComponent sceneItemTrackGuideComponent = (SceneItemTrackGuideComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (sceneItemTrackGuideComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PerformanceComp"))
			{
				if (sceneItemTrackGuideComponent.PerformanceComp == null)
				{
					this.PerformanceComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PerformanceComponent>(this.PerformanceComp), "PerformanceComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (sceneItemTrackGuideComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PropertyComp"))
			{
				if (sceneItemTrackGuideComponent.PropertyComp == null)
				{
					this.PropertyComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemPropertyComponent>(this.PropertyComp), "PropertyComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ReachedEndOfSplineType"))
			{
				this.ReachedEndOfSplineType = sceneItemTrackGuideComponent.ReachedEndOfSplineType;
			}
			if (base.CanResetComponentProperty("SyncComp"))
			{
				if (sceneItemTrackGuideComponent.SyncComp == null)
				{
					this.SyncComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMovementSyncComponent>(this.SyncComp), "SyncComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FoundationId"))
			{
				this.FoundationId = sceneItemTrackGuideComponent.FoundationId;
			}
			if (base.CanResetComponentProperty("FoundationOffset"))
			{
				if (sceneItemTrackGuideComponent.FoundationOffset == null)
				{
					this.FoundationOffset = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.FoundationOffset), "FoundationOffset"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FoundationEntity"))
			{
				if (sceneItemTrackGuideComponent.FoundationEntity == null)
				{
					this.FoundationEntity = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.FoundationEntity), "FoundationEntity"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FoundationLocation"))
			{
				if (sceneItemTrackGuideComponent.FoundationLocation == null)
				{
					this.FoundationLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.FoundationLocation), "FoundationLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PathLine"))
			{
				if (sceneItemTrackGuideComponent.PathLine == null)
				{
					this.PathLine = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<USplineComponent>(this.PathLine), "PathLine"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SplineStartLocation"))
			{
				if (sceneItemTrackGuideComponent.SplineStartLocation == null)
				{
					this.SplineStartLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SplineStartLocation), "SplineStartLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SplineEndLocation"))
			{
				if (sceneItemTrackGuideComponent.SplineEndLocation == null)
				{
					this.SplineEndLocation = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.SplineEndLocation), "SplineEndLocation"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("DistanceAlongSpline"))
			{
				this.DistanceAlongSpline = sceneItemTrackGuideComponent.DistanceAlongSpline;
			}
			if (base.CanResetComponentProperty("TargetPointIndex"))
			{
				this.TargetPointIndex = sceneItemTrackGuideComponent.TargetPointIndex;
			}
			if (base.CanResetComponentProperty("NumSplinePoints"))
			{
				this.NumSplinePoints = sceneItemTrackGuideComponent.NumSplinePoints;
			}
			if (base.CanResetComponentProperty("SplineLength"))
			{
				this.SplineLength = sceneItemTrackGuideComponent.SplineLength;
			}
			if (base.CanResetComponentProperty("DistanceBetweenLastTwoPointsInverse"))
			{
				this.DistanceBetweenLastTwoPointsInverse = sceneItemTrackGuideComponent.DistanceBetweenLastTwoPointsInverse;
			}
			if (base.CanResetComponentProperty("WaitConfig"))
			{
				if (sceneItemTrackGuideComponent.WaitConfig == null)
				{
					this.WaitConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<bool>>(this.WaitConfig), "WaitConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SpeedConfig"))
			{
				if (sceneItemTrackGuideComponent.SpeedConfig == null)
				{
					this.SpeedConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<float>>(this.SpeedConfig), "SpeedConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SplineMoveParam"))
			{
				if (sceneItemTrackGuideComponent.SplineMoveParam == null)
				{
					this.SplineMoveParam = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam>(this.SplineMoveParam), "SplineMoveParam"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("NeedCheckWait"))
			{
				this.NeedCheckWait = sceneItemTrackGuideComponent.NeedCheckWait;
			}
			if (base.CanResetComponentProperty("IsInRange"))
			{
				this.IsInRange = sceneItemTrackGuideComponent.IsInRange;
			}
			if (base.CanResetComponentProperty("UpdateState"))
			{
				this.UpdateState = sceneItemTrackGuideComponent.UpdateState;
			}
			if (base.CanResetComponentProperty("HasFinished"))
			{
				this.HasFinished = sceneItemTrackGuideComponent.HasFinished;
			}
			if (base.CanResetComponentProperty("DirectionCache"))
			{
				if (sceneItemTrackGuideComponent.DirectionCache == null)
				{
					this.DirectionCache = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.DirectionCache), "DirectionCache"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PawnSensoryInfo"))
			{
				if (sceneItemTrackGuideComponent.PawnSensoryInfo == null)
				{
					this.PawnSensoryInfo = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnSensoryInfoComponent>(this.PawnSensoryInfo), "PawnSensoryInfo"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UseCommonEffect"))
			{
				this.UseCommonEffect = sceneItemTrackGuideComponent.UseCommonEffect;
			}
			if (base.CanResetComponentProperty("CommonEffectInit"))
			{
				this.CommonEffectInit = sceneItemTrackGuideComponent.CommonEffectInit;
			}
			if (base.CanResetComponentProperty("HasMoveStart"))
			{
				this.HasMoveStart = sceneItemTrackGuideComponent.HasMoveStart;
			}
			if (base.CanResetComponentProperty("ShouldBeMoving"))
			{
				this.ShouldBeMoving = sceneItemTrackGuideComponent.ShouldBeMoving;
			}
			if (base.CanResetComponentProperty("LastSpeed"))
			{
				this.LastSpeed = sceneItemTrackGuideComponent.LastSpeed;
			}
			if (base.CanResetComponentProperty("OnlineInteractType"))
			{
				this.OnlineInteractType = sceneItemTrackGuideComponent.OnlineInteractType;
			}
			if (base.CanResetComponentProperty("DisableHandle"))
			{
				this.DisableHandle = sceneItemTrackGuideComponent.DisableHandle;
			}
			if (base.CanResetComponentProperty("HasTriggered"))
			{
				this.HasTriggered = sceneItemTrackGuideComponent.HasTriggered;
			}
			if (base.CanResetComponentProperty("HasReportTriggered"))
			{
				this.HasReportTriggered = sceneItemTrackGuideComponent.HasReportTriggered;
			}
			if (base.CanResetComponentProperty("SplineEntityId"))
			{
				this.SplineEntityId = sceneItemTrackGuideComponent.SplineEntityId;
			}
			return true;
		}

		// Token: 0x0401B8F8 RID: 112888
		private const int DISTANCE_SPLINE_FOUNDATION_THRESHOLD = 10000;

		// Token: 0x0401B8F9 RID: 112889
		private const int SPLINE_FOUNDATION_SPEED = 150;

		// Token: 0x0401B8FA RID: 112890
		private const int DISTANCE_SQUARE_THRESHOLD = 2500;

		// Token: 0x0401B8FB RID: 112891
		private const int MOVEMENT_SPEED = 600;

		// Token: 0x0401B8FC RID: 112892
		private const int CONFIG_DEFAULT_MOVEMENT_SPEED = 50;

		// Token: 0x0401B8FD RID: 112893
		private const int MAX_MOVEMENT_SPEED = 800;

		// Token: 0x0401B8FE RID: 112894
		private const int NORMAL_RADIUS = 50;

		// Token: 0x0401B8FF RID: 112895
		private const int COMPRESS_RADIUS = 0;

		// Token: 0x0401B900 RID: 112896
		private SceneItemActorComponent ActorComp;

		// Token: 0x0401B901 RID: 112897
		private PerformanceComponent PerformanceComp;

		// Token: 0x0401B902 RID: 112898
		private SceneItemMoveComponent MoveComp;

		// Token: 0x0401B903 RID: 112899
		private SceneItemPropertyComponent PropertyComp;

		// Token: 0x0401B904 RID: 112900
		private EFollowTrackEndType? ReachedEndOfSplineType;

		// Token: 0x0401B905 RID: 112901
		private SceneItemMovementSyncComponent SyncComp;

		// Token: 0x0401B906 RID: 112902
		private int? FoundationId;

		// Token: 0x0401B907 RID: 112903
		private global::Vector FoundationOffset;

		// Token: 0x0401B908 RID: 112904
		private EntityHandle FoundationEntity;

		// Token: 0x0401B909 RID: 112905
		private global::Vector FoundationLocation;

		// Token: 0x0401B90A RID: 112906
		private USplineComponent PathLine;

		// Token: 0x0401B90B RID: 112907
		private global::Vector SplineStartLocation;

		// Token: 0x0401B90C RID: 112908
		private global::Vector SplineEndLocation;

		// Token: 0x0401B90D RID: 112909
		private float DistanceAlongSpline;

		// Token: 0x0401B90E RID: 112910
		private int TargetPointIndex;

		// Token: 0x0401B90F RID: 112911
		private int NumSplinePoints;

		// Token: 0x0401B910 RID: 112912
		private float SplineLength;

		// Token: 0x0401B911 RID: 112913
		private float DistanceBetweenLastTwoPointsInverse;

		// Token: 0x0401B912 RID: 112914
		private List<bool> WaitConfig;

		// Token: 0x0401B913 RID: 112915
		private List<float> SpeedConfig;

		// Token: 0x0401B914 RID: 112916
		private SceneItemMoveComponent.SceneItemSplineMoveAtConstantTimeParam SplineMoveParam;

		// Token: 0x0401B915 RID: 112917
		private bool NeedCheckWait = true;

		// Token: 0x0401B916 RID: 112918
		private bool IsInRange;

		// Token: 0x0401B917 RID: 112919
		private SceneItemTrackGuideComponent.EUpdateState UpdateState;

		// Token: 0x0401B918 RID: 112920
		private bool HasFinished;

		// Token: 0x0401B919 RID: 112921
		private global::Vector DirectionCache;

		// Token: 0x0401B91A RID: 112922
		private PawnSensoryInfoComponent PawnSensoryInfo;

		// Token: 0x0401B91B RID: 112923
		private bool UseCommonEffect;

		// Token: 0x0401B91C RID: 112924
		private bool CommonEffectInit;

		// Token: 0x0401B91D RID: 112925
		private bool HasMoveStart;

		// Token: 0x0401B91E RID: 112926
		private bool ShouldBeMoving;

		// Token: 0x0401B91F RID: 112927
		private float LastSpeed;

		// Token: 0x0401B920 RID: 112928
		private EOnlineInteractType? OnlineInteractType;

		// Token: 0x0401B921 RID: 112929
		private int? DisableHandle;

		// Token: 0x0401B922 RID: 112930
		private bool HasTriggered;

		// Token: 0x0401B923 RID: 112931
		private bool HasReportTriggered;

		// Token: 0x0401B924 RID: 112932
		private int SplineEntityId;

		// Token: 0x0200A8EF RID: 43247
		[NullableContext(0)]
		private enum EUpdateState
		{
			// Token: 0x04034630 RID: 214576
			UpdateToSplineStart,
			// Token: 0x04034631 RID: 214577
			UpdateToSplineEnd,
			// Token: 0x04034632 RID: 214578
			UpdateToFoundation,
			// Token: 0x04034633 RID: 214579
			UpdateToStopAtEnd
		}

		// Token: 0x0200A8F0 RID: 43248
		[NullableContext(1)]
		[Nullable(0)]
		private class ButterflyTriggerData : PlayerCommonLogData
		{
			// Token: 0x04034634 RID: 214580
			public int i_inst_id;

			// Token: 0x04034635 RID: 214581
			public string i_config_id = "";

			// Token: 0x04034636 RID: 214582
			public string f_player_pos_x = "";

			// Token: 0x04034637 RID: 214583
			public string f_player_pos_y = "";

			// Token: 0x04034638 RID: 214584
			public string f_player_pos_z = "";

			// Token: 0x04034639 RID: 214585
			public string i_area_id = "";

			// Token: 0x0403463A RID: 214586
			public string s_tag = "";
		}
	}
}
