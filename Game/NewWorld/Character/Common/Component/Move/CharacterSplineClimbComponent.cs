using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.SplineClimb;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200493B RID: 18747
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterSplineClimbComponent : EntityComponent
	{
		// Token: 0x170083A6 RID: 33702
		// (get) Token: 0x06031044 RID: 200772 RVA: 0x00C2D775 File Offset: 0x00C2B975
		private SplineClimbParams Params
		{
			get
			{
				if (CharacterSplineClimbComponent.CommonParams == null)
				{
					CharacterSplineClimbComponent.CommonParams = CharacterSplineClimbComponent.LoadCommonParams();
				}
				return CharacterSplineClimbComponent.CommonParams;
			}
		}

		// Token: 0x06031045 RID: 200773 RVA: 0x00C2D790 File Offset: 0x00C2B990
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
			this.AnimComp = base.Entity.CheckGetComponent<CharacterAnimationComponent>();
			this.TagComp = base.Entity.CheckGetComponent<BaseTagComponent>();
			this.MoveComp = base.Entity.CheckGetComponent<CharacterMoveComponent>();
			this.ClimbComp = base.Entity.GetComponent<CharacterClimbComponent>();
			CharacterAnimationComponent animComp = this.AnimComp;
			this.AnimInstance = (((animComp != null) ? animComp.MainAnimInstance : null) as UKuroAnimInstanceRole);
			return true;
		}

		// Token: 0x06031046 RID: 200774 RVA: 0x00C2D810 File Offset: 0x00C2BA10
		protected override bool OnEnd()
		{
			this.RemoveEvents();
			return true;
		}

		// Token: 0x06031047 RID: 200775 RVA: 0x00C2D819 File Offset: 0x00C2BA19
		protected override void OnTick(float delta)
		{
			if (this.StateChangeExit)
			{
				this.ExitSplineClimb("位置状态改变", true, false);
				this.StateChangeExit = false;
			}
		}

		// Token: 0x06031048 RID: 200776 RVA: 0x00C2D838 File Offset: 0x00C2BA38
		public unsafe void EnterSplineClimb(USplineComponent splineAsset, Vector traceDirection, Action<bool> callback)
		{
			if (this.InSplineClimb)
			{
				this.ExitSplineClimb("重复进入", false, true);
			}
			this.TraceDirection.DeepCopy(traceDirection);
			this.InitSplineRuntime(splineAsset);
			this.SetInitialLocation();
			this.FastClimbMix = 0f;
			this.SmoothedSpeed = 500f;
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Custom,
					CustomMode = 13,
					Context = "[CharacterSplineClimbComponent.EnterSplineClimb]"
				});
			}
			foreach (int value in this.Params.Tags)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTag(new int?(value));
				}
			}
			this.AddEvents();
			Entity entity = base.Entity;
			BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
			if (baseSkillComponent != null)
			{
				baseSkillComponent.StopAllSkills("开始样条跑墙");
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, "[CharacterSplineClimbComponent] 开始样条跑墙");
			this.EndCallback = callback;
			this.InSplineClimb = true;
			if (GlobalData.IsPlayInEditor)
			{
				CharacterSplineClimbComponent.LoadCommonParams();
			}
			if (this.IsFirstPerson())
			{
				CharacterMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					moveComp.SetLockedRotation(false);
				}
			}
			if (this.ClimbComp != null)
			{
				this.DisableClimbHandle = this.ClimbComp.Disable("样条跑墙开始");
			}
			this.TargetLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			SplineRuntime splineRuntime = this.SplineRuntime;
			float splineLength = splineRuntime.SourceSpline.GetSplineLength();
			if (!this.BuildWallSpline(splineRuntime.SourceSpline, splineRuntime.WallSpline, (double)splineRuntime.DistanceInSource, (double)splineLength, this.TraceDirection, this.ActorComp.ActorLocationProxy))
			{
				this.ExitSplineClimb("无法投影", true, true);
				return;
			}
			splineRuntime.DistanceInSource = splineLength;
			splineRuntime.DistanceInWallSpline = 0f;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LJF;
			string message = "开始样条跑墙";
			<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SourceLength", splineLength);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DistanceInSource", splineRuntime.DistanceInSource);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "SourceLengthUe";
			USplineComponent sourceSplineUe = splineRuntime.SourceSplineUe;
			ptr = new ValueTuple<string, object>(item, (sourceSplineUe != null) ? new float?(sourceSplineUe.GetSplineLength()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("WallSplineLength", splineRuntime.WallSpline.GetSplineLength());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("SplineLocation", splineRuntime.SourceSpline.SplineTransform.GetLocation());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("ActorLocation", this.ActorComp.ActorLocationProxy);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
		}

		// Token: 0x06031049 RID: 200777 RVA: 0x00C2DB30 File Offset: 0x00C2BD30
		public unsafe void ExitSplineClimb(string reason, bool tryChangeState = true, bool jumpExit = true)
		{
			this.RemoveEvents();
			if (this.ClimbComp != null)
			{
				this.ClimbComp.Enable(new int?(this.DisableClimbHandle), "样条跑墙结束");
				this.DisableClimbHandle = 0;
			}
			ECharPositionState positionState = base.Entity.GetComponent<CharacterUnifiedStateComponent>().PositionState;
			bool flag = !jumpExit || this.IsFirstPerson() || this.ClimbComp == null;
			bool flag2 = tryChangeState && flag && (positionState == ECharPositionState.Air || positionState == ECharPositionState.Climb);
			bool flag3 = tryChangeState && positionState == ECharPositionState.Climb;
			if (flag2)
			{
				this.FixCharacterExitRotation();
			}
			if (flag3)
			{
				this.OnExitSplineClimbState(flag || this.ClimbComp == null);
			}
			foreach (int value in this.Params.Tags)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.RemoveTag(new int?(value));
				}
			}
			this.InSplineClimb = false;
			this.StateChangeExit = false;
			if (this.IsFirstPerson())
			{
				CharacterMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					moveComp.SetLockedRotation(true);
				}
			}
			Action<bool> endCallback = this.EndCallback;
			if (endCallback != null)
			{
				endCallback(true);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LJF;
			string message = "退出样条跑墙";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "DistanceInSource";
			SplineRuntime splineRuntime = this.SplineRuntime;
			ptr = new ValueTuple<string, object>(item, (splineRuntime != null) ? new float?(splineRuntime.DistanceInSource) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item2 = "WallSplineLength";
			SplineRuntime splineRuntime2 = this.SplineRuntime;
			float? num;
			if (splineRuntime2 == null)
			{
				num = null;
			}
			else
			{
				SplineCurve wallSpline = splineRuntime2.WallSpline;
				num = ((wallSpline != null) ? new float?(wallSpline.GetSplineLength()) : null);
			}
			ptr2 = new ValueTuple<string, object>(item2, num);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
			string item3 = "DistanceOnWall";
			SplineRuntime splineRuntime3 = this.SplineRuntime;
			ptr3 = new ValueTuple<string, object>(item3, (splineRuntime3 != null) ? new float?(splineRuntime3.DistanceInWallSpline) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("bChangeState", flag3);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("bToFall", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("hasClimbComp", this.ClimbComp != null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x0603104A RID: 200778 RVA: 0x00C2DDD0 File Offset: 0x00C2BFD0
		private void OnExitSplineClimbState(bool falling)
		{
			if (falling)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp == null)
				{
					return;
				}
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Falling,
					Context = "[CharacterSplineClimbComponent.OnExitClimb] Falling"
				});
				return;
			}
			else
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Custom,
						CustomMode = 0,
						Context = "[CharacterSplineClimbComponent.ExitSplineClimb]"
					});
				}
				CharacterClimbComponent climbComp = this.ClimbComp;
				if (climbComp == null)
				{
					return;
				}
				climbComp.KickWallExit();
				return;
			}
		}

		// Token: 0x0603104B RID: 200779 RVA: 0x00C2DE54 File Offset: 0x00C2C054
		private void FixCharacterExitRotation()
		{
			if (Singleton<GravityUtils>.Instance.GetZnInGravityForActor(this.ActorComp, this.ActorComp.ActorVelocityProxy) > 0.0)
			{
				this.TempVector.DeepCopy(this.ActorComp.ActorVelocityProxy);
				Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.TempVector);
				this.MoveComp.SetForceSpeed(this.TempVector);
			}
			Vector tempVector = this.TempVector;
			tempVector.DeepCopy(this.MoveOffset);
			SplineRuntime splineRuntime = this.SplineRuntime;
			SplineCurve splineCurve = (splineRuntime != null) ? splineRuntime.WallSpline : null;
			if (splineCurve != null)
			{
				float splineLength = splineCurve.GetSplineLength();
				splineCurve.GetDirectionAtDistanceAlongSpline(splineLength - 1f, ESplineCoordinateSpace.World, tempVector);
			}
			double inB = Vector.DotProduct(tempVector, this.MoveComp.GravityUp);
			Vector tempVector2 = this.TempVector2;
			this.MoveComp.GravityUp.Multiply(inB, tempVector2);
			tempVector.SubtractionEqual(tempVector2);
			if (!tempVector.IsNearlyZero(9.999999747378752E-05))
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(tempVector, this.MoveComp.GravityUp, this.TempQuat);
				FTransformDouble actorTransform = this.ActorComp.ActorTransform;
				FQuat fquat = this.TempQuat.ToUeQuat();
				actorTransform.SetRotation(fquat);
				if (this.ClimbComp != null)
				{
					this.ClimbComp.SetCharacterTransformAndBuffer(actorTransform, 300f, null, true);
					return;
				}
				this.SetCharacterTransformWithBuffer(actorTransform, 300f, true);
			}
		}

		// Token: 0x0603104C RID: 200780 RVA: 0x00C2DFB8 File Offset: 0x00C2C1B8
		private void SetCharacterTransformWithBuffer(FTransformDouble newTransform, float smoothTime, bool sweep = true)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null && animComp.Valid)
			{
				this.AnimComp.SetTransformWithModelBuffer(newTransform, smoothTime, null, sweep);
				return;
			}
			this.ActorComp.SetActorTransform(newTransform, "[SplineClimb] SetCharacterTransformWithBuffer", sweep, null);
		}

		// Token: 0x0603104D RID: 200781 RVA: 0x00C2E010 File Offset: 0x00C2C210
		private void InitSplineRuntime(USplineComponent splineAsset)
		{
			this.SplineRuntime = new SplineRuntime();
			this.SplineRuntime.SourceSplineUe = splineAsset;
			SplineCurve sourceSpline = this.SplineRuntime.SourceSpline;
			sourceSpline.Init(splineAsset.SplineCurves.Position, splineAsset.SplineCurves.ReparamTable.Points, splineAsset.SplineCurves.Rotation, splineAsset.SplineCurves.Scale);
			sourceSpline.SetSplineTransform(Transform.Create(splineAsset.D_K2_GetComponentToWorld()), false);
		}

		// Token: 0x0603104E RID: 200782 RVA: 0x00C2E08C File Offset: 0x00C2C28C
		private void SetInitialLocation()
		{
			USplineComponent sourceSplineUe = this.SplineRuntime.SourceSplineUe;
			FVectorDouble actorLocation = this.ActorComp.ActorLocation;
			float inKey = sourceSplineUe.D_FindInputKeyClosestToWorldLocationInGravity(actorLocation, this.ActorComp.ActorGravityDirectProxy.ToUeVectorOld(), 800f);
			float distanceAlongSplineAtSplineInputKey = this.SplineRuntime.SourceSplineUe.GetDistanceAlongSplineAtSplineInputKey(inKey);
			this.SplineRuntime.DistanceInSource = distanceAlongSplineAtSplineInputKey;
		}

		// Token: 0x0603104F RID: 200783 RVA: 0x00C2E0EC File Offset: 0x00C2C2EC
		private void AddEvents()
		{
			if (this.EventAdded)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CustomMoveSplineClimb, new Action<float>(this.ReceiveSplineClimbEvent));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChange));
			this.EventAdded = true;
		}

		// Token: 0x06031050 RID: 200784 RVA: 0x00C2E1A4 File Offset: 0x00C2C3A4
		private void RemoveEvents()
		{
			if (!this.EventAdded)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CustomMoveSplineClimb, new Action<float>(this.ReceiveSplineClimbEvent));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChange));
			this.EventAdded = false;
		}

		// Token: 0x06031051 RID: 200785 RVA: 0x00C2E259 File Offset: 0x00C2C459
		private void ReceiveSplineClimbEvent(float deltaTime)
		{
			this.MoveToTarget(deltaTime);
		}

		// Token: 0x06031052 RID: 200786 RVA: 0x00C2E262 File Offset: 0x00C2C462
		private void OnTeleportStart(bool _)
		{
			this.ExitSplineClimb("OnTeleportStart", true, false);
		}

		// Token: 0x06031053 RID: 200787 RVA: 0x00C2E271 File Offset: 0x00C2C471
		private void OnRoleDead()
		{
			this.ExitSplineClimb("OnRoleDead", true, false);
		}

		// Token: 0x06031054 RID: 200788 RVA: 0x00C2E280 File Offset: 0x00C2C480
		private void OnUseSkill(int charId, int skillId, bool isAutonomousProxy)
		{
			SplineClimbParams @params = this.Params;
			bool flag = @params != null && @params.InterruptSkills.Contains((long)skillId);
			if (charId != base.Entity.Id || !flag)
			{
				return;
			}
			this.ExitSplineClimb("使用技能" + skillId.ToString(), true, false);
		}

		// Token: 0x06031055 RID: 200789 RVA: 0x00C2E2D4 File Offset: 0x00C2C4D4
		private void OnPositionStateChange(ECharPositionState oldPositionState, ECharPositionState newPositionState)
		{
			this.StateChangeExit = true;
		}

		// Token: 0x06031056 RID: 200790 RVA: 0x00C2E2E0 File Offset: 0x00C2C4E0
		private void MoveToTarget(float deltaSeconds)
		{
			SplineRuntime splineRuntime = this.SplineRuntime;
			if (!this.InSplineClimb || splineRuntime == null)
			{
				return;
			}
			float splineLength = splineRuntime.WallSpline.GetSplineLength();
			if ((double)splineRuntime.DistanceInWallSpline >= (double)splineLength - 0.1)
			{
				this.ExitSplineClimb("样条结束", true, true);
				return;
			}
			splineRuntime.WallSpline.GetTransformAtDistanceAlongSpline(splineRuntime.DistanceInWallSpline, ESplineCoordinateSpace.World, this.TargetTransform);
			float num = this.MoveComp.CharacterMovement.AnimRootMotionVelocity.Size();
			UKuroAnimInstanceRole animInstance = this.AnimInstance;
			float num2 = (animInstance != null && animInstance.HasKuroRootMotionAnim()) ? num : 500f;
			float num3 = (deltaSeconds > 0f) ? (1f - (float)Math.Exp((double)(-(double)deltaSeconds / 0.2f))) : 1f;
			this.SmoothedSpeed += (num2 - this.SmoothedSpeed) * num3;
			float smoothedSpeed = this.SmoothedSpeed;
			splineRuntime.DistanceInWallSpline = Math.Min(splineRuntime.DistanceInWallSpline + smoothedSpeed * deltaSeconds, splineLength - 0.1f);
			this.TargetLocation.DeepCopy(this.TargetTransform.GetLocation());
			this.TargetLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.MoveOffset);
			this.ActorComp.AddActorWorldOffset(this.MoveOffset.ToUeVector(false), "[CharacterSplineClimbComponent] 沿样条跑墙", true);
			this.GetTargetRotator(this.TargetTransform, this.TargetRotator);
			this.MoveComp.SmoothCharacterRotation(this.TargetRotator, 800f, deltaSeconds, false, "[SplineClimb] 沿样条跑墙", true);
			this.UpdateAnimParams(this.TargetTransform, deltaSeconds);
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp != null)
			{
				animComp.ConsumeRootMotion();
			}
			CharacterClimbComponent climbComp = this.ClimbComp;
			if (climbComp == null)
			{
				return;
			}
			climbComp.SetLastSafeLocation(this.ActorComp.ActorLocationProxy);
		}

		// Token: 0x06031057 RID: 200791 RVA: 0x00C2E49C File Offset: 0x00C2C69C
		private void GetTargetRotator(Transform targetTransform, Rotator outRotator)
		{
			this.TempVector3.DeepCopy(this.ActorComp.ActorGravityDirectProxy);
			this.TempVector3.UnaryNegation(this.TempVector3);
			targetTransform.GetRotation().GetUpVector(this.TempVector2);
			this.TempVector2.UnaryNegation(this.TempVector2);
			if (this.IsFirstPerson())
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.TempVector2, this.TempVector3, outRotator);
				return;
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, this.TempVector3, outRotator);
		}

		// Token: 0x06031058 RID: 200792 RVA: 0x00C2E52C File Offset: 0x00C2C72C
		private unsafe bool BuildWallSpline(SplineCurve sourceSpline, SplineCurve wallSpline, double startDistance, double endDistance, Vector direction, [Nullable(2)] Vector prependLocation = null)
		{
			List<InterpCurvePointVector> list = new List<InterpCurvePointVector>();
			List<InterpCurvePointQuat> list2 = new List<InterpCurvePointQuat>();
			if (prependLocation != null)
			{
				InterpCurvePointVector interpCurvePointVector = new InterpCurvePointVector(global::EInterpCurveMode.Linear);
				interpCurvePointVector.OutVal.DeepCopy(prependLocation);
				Vector tempVector = this.TempVector;
				sourceSpline.GetDirectionAtDistanceAlongSpline((float)Math.Min(startDistance, (double)sourceSpline.GetSplineLength() - 0.1), ESplineCoordinateSpace.World, tempVector);
				Vector tempVector2 = this.TempVector2;
				tempVector2.DeepCopy(this.ActorComp.ActorGravityDirectProxy);
				tempVector2.UnaryNegation(tempVector2);
				InterpCurvePointQuat interpCurvePointQuat = new InterpCurvePointQuat(global::EInterpCurveMode.Linear);
				Singleton<MathUtils>.Instance.LookRotationUpFirst(tempVector, tempVector2, interpCurvePointQuat.OutVal);
				interpCurvePointQuat.LeaveTangent.DeepCopy(interpCurvePointQuat.OutVal);
				interpCurvePointQuat.ArriveTangent.DeepCopy(interpCurvePointQuat.OutVal);
				list.Add(interpCurvePointVector);
				list2.Add(interpCurvePointQuat);
			}
			double num = (double)sourceSpline.GetSplineLength();
			double num2 = endDistance - startDistance;
			if (num2 < 10.0)
			{
				wallSpline.InitPoints(list, null);
			}
			double sampleInterval = this.Params.SampleInterval;
			int num3 = (int)(num2 / sampleInterval);
			CharacterClimbComponent climbComp = this.ClimbComp;
			float num4 = (climbComp != null) ? climbComp.GetClimbRadius() : 35f;
			double traceStartOffset = this.Params.TraceStartOffset;
			double traceLength = this.Params.TraceLength;
			double extraWallRadius = this.Params.ExtraWallRadius;
			for (int i = 0; i <= num3; i++)
			{
				double num5 = startDistance + (double)i * sampleInterval;
				float distance = (float)Math.Min(num5, num - 0.1);
				Transform tempTransform = this.TempTransform;
				sourceSpline.GetTransformAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World, tempTransform);
				if (this.TraceElement == null)
				{
					this.TraceElement = this.CreateTraceElement();
				}
				this.TraceElement.Radius = num4;
				Vector tempVector3 = this.TempVector;
				direction.GetSafeNormal(tempVector3, 9.99999993922529E-09);
				tempVector3.MultiplyEqual(traceStartOffset);
				tempVector3.AdditionEqual(tempTransform.GetLocation());
				Vector tempVector4 = this.TempVector2;
				direction.GetSafeNormal(tempVector4, 9.99999993922529E-09);
				tempVector4.MultiplyEqual(traceLength);
				tempVector4.AdditionEqual(tempTransform.GetLocation());
				Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, tempVector3);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, tempVector4);
				if (Singleton<TraceElementCommon>.Instance.SphereTrace(this.TraceElement, "CharacterSplineClimbComponent.BuildWallSpline") && this.TraceElement.HitResult != null)
				{
					Vector tempVector5 = this.TempVector;
					Singleton<TraceElementCommon>.Instance.GetImpactPoint(this.TraceElement.HitResult, 0, tempVector5);
					Vector tempVector6 = this.TempVector2;
					Singleton<TraceElementCommon>.Instance.GetImpactNormal(this.TraceElement.HitResult, 0, tempVector6);
					InterpCurvePointVector interpCurvePointVector2 = new InterpCurvePointVector(global::EInterpCurveMode.CurveAutoClamped);
					interpCurvePointVector2.InVal = (float)i;
					tempVector6.MultiplyEqual((double)num4 + extraWallRadius);
					tempVector5.AdditionEqual(tempVector6);
					tempVector6.Normalize(9.99999993922529E-09);
					interpCurvePointVector2.OutVal.DeepCopy(tempVector5);
					Vector tempVector7 = this.TempVector;
					sourceSpline.GetDirectionAtDistanceAlongSpline(distance, ESplineCoordinateSpace.World, tempVector7);
					InterpCurvePointQuat interpCurvePointQuat2 = new InterpCurvePointQuat(global::EInterpCurveMode.Linear);
					interpCurvePointQuat2.InVal = (float)i;
					Singleton<MathUtils>.Instance.LookRotationUpFirst(tempVector7, tempVector6, interpCurvePointQuat2.OutVal);
					interpCurvePointQuat2.LeaveTangent.DeepCopy(interpCurvePointQuat2.OutVal);
					interpCurvePointQuat2.ArriveTangent.DeepCopy(interpCurvePointQuat2.OutVal);
					double inB = Vector.DotProduct(tempVector7, tempVector6);
					tempVector6.MultiplyEqual(inB);
					tempVector7.SubtractionEqual(tempVector6);
					tempVector7.Normalize(9.99999993922529E-09);
					interpCurvePointVector2.ArriveTangent.DeepCopy(tempVector7);
					interpCurvePointVector2.LeaveTangent.DeepCopy(tempVector7);
					list.Add(interpCurvePointVector2);
					list2.Add(interpCurvePointQuat2);
					if (GlobalData.IsPlayInEditor && this.Params.DebugDraw)
					{
						FVectorDouble fvectorDouble = interpCurvePointVector2.OutVal.ToUeVector(false);
						UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, fvectorDouble, 5f, 12, new FLinearColor?(ColorUtils.LinearYellow), 5f, 0f);
						FVectorDouble fvectorDouble2 = interpCurvePointVector2.ArriveTangent.ToUeVector(false);
						UObject world = GlobalData.World;
						FVectorDouble lineStart = fvectorDouble;
						FVectorDouble fvectorDouble3 = fvectorDouble2 * 20.0;
						UKismetSystemLibrary.D_DrawDebugLine(world, lineStart, fvectorDouble + fvectorDouble3, ColorUtils.LinearRed, 5f, 0f);
						UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, tempTransform.GetLocation().ToUeVector(false), 2f, 12, new FLinearColor?(ColorUtils.LinearBlue), 5f, 0f);
					}
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.LJF;
					string message = "[CharacterSplineClimbComponent] 未检测到墙壁";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("distance", num5);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("maxDistance", num);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				if (num5 >= num)
				{
					break;
				}
			}
			wallSpline.InitPoints(list, list2);
			return list.Count >= 1;
		}

		// Token: 0x06031059 RID: 200793 RVA: 0x00C2EA14 File Offset: 0x00C2CC14
		private UTraceSphereElement CreateTraceElement()
		{
			UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
			utraceSphereElement.bIsSingle = true;
			utraceSphereElement.bIgnoreSelf = true;
			utraceSphereElement.WorldContextObject = this.ActorComp.Owner;
			utraceSphereElement.Radius = 2f;
			utraceSphereElement.bTraceComplex = false;
			utraceSphereElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			utraceSphereElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
			return utraceSphereElement;
		}

		// Token: 0x0603105A RID: 200794 RVA: 0x00C2EA70 File Offset: 0x00C2CC70
		private void UpdateAnimParams(Transform targetTransform, float deltaSeconds)
		{
			Quat rotation = targetTransform.GetRotation();
			Vector tempVector = this.TempVector;
			rotation.GetForwardVector(tempVector);
			double blendSpaceAxis = this.GetBlendSpaceAxis(tempVector);
			this.FastClimbMix = (float)Singleton<MathUtils>.Instance.InterpTo((double)this.FastClimbMix, blendSpaceAxis, (double)deltaSeconds, 4.0);
			this.AnimInstance.FastClimbMix = this.FastClimbMix;
		}

		// Token: 0x0603105B RID: 200795 RVA: 0x00C2EAD0 File Offset: 0x00C2CCD0
		private double GetBlendSpaceAxis(Vector moveDirection)
		{
			Vector actorRightProxy = this.ActorComp.ActorRightProxy;
			double num = Vector.DotProduct(moveDirection, actorRightProxy);
			if (-Vector.DotProduct(moveDirection, this.ActorComp.ActorGravityDirectProxy) < 0.0)
			{
				num = (double)((num < 0.0) ? -1 : 1);
			}
			return num;
		}

		// Token: 0x0603105C RID: 200796 RVA: 0x00C2EB24 File Offset: 0x00C2CD24
		private static SplineClimbParams LoadCommonParams()
		{
			string text = "/Game/Aki/Data/Level/SplineClimb/DA_SplineClimb_Common.DA_SplineClimb_Common";
			BP_SplineClimbConfig_C bp_SplineClimbConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_SplineClimbConfig_C>(text, "js_undefined");
			if (bp_SplineClimbConfig_C == null || !bp_SplineClimbConfig_C.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LJF;
				string message = "[CharacterSplineClimbComponent] 获取样条跑墙DA参数失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DaPath", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new SplineClimbParams(null);
			}
			return CharacterSplineClimbComponent.CommonParams = new SplineClimbParams(bp_SplineClimbConfig_C);
		}

		// Token: 0x0603105D RID: 200797 RVA: 0x00C2EB8D File Offset: 0x00C2CD8D
		private bool IsFirstPerson()
		{
			return this.TagComp != null && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.通用镜头.第一人称镜头"]);
		}

		// Token: 0x0603105E RID: 200798 RVA: 0x00C2EBB4 File Offset: 0x00C2CDB4
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterSplineClimbComponent characterSplineClimbComponent = (CharacterSplineClimbComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterSplineClimbComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimComp"))
			{
				if (characterSplineClimbComponent.AnimComp == null)
				{
					this.AnimComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ClimbComp"))
			{
				if (characterSplineClimbComponent.ClimbComp == null)
				{
					this.ClimbComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterClimbComponent>(this.ClimbComp), "ClimbComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (characterSplineClimbComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterSplineClimbComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("EndCallback"))
			{
				if (characterSplineClimbComponent.EndCallback == null)
				{
					this.EndCallback = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Action<bool>>(this.EndCallback), "EndCallback"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SplineRuntime"))
			{
				if (characterSplineClimbComponent.SplineRuntime == null)
				{
					this.SplineRuntime = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SplineRuntime>(this.SplineRuntime), "SplineRuntime"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TraceDirection") && characterSplineClimbComponent.TraceDirection != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TraceDirection), "TraceDirection"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("AnimInstance"))
			{
				if (characterSplineClimbComponent.AnimInstance == null)
				{
					this.AnimInstance = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroAnimInstanceRole>(this.AnimInstance), "AnimInstance"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("FastClimbMix"))
			{
				this.FastClimbMix = characterSplineClimbComponent.FastClimbMix;
			}
			if (base.CanResetComponentProperty("SmoothedSpeed"))
			{
				this.SmoothedSpeed = characterSplineClimbComponent.SmoothedSpeed;
			}
			if (base.CanResetComponentProperty("TraceElement"))
			{
				if (characterSplineClimbComponent.TraceElement == null)
				{
					this.TraceElement = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceSphereElement>(this.TraceElement), "TraceElement"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InSplineClimb"))
			{
				this.InSplineClimb = characterSplineClimbComponent.InSplineClimb;
			}
			if (base.CanResetComponentProperty("DisableClimbHandle"))
			{
				this.DisableClimbHandle = characterSplineClimbComponent.DisableClimbHandle;
			}
			if (base.CanResetComponentProperty("StateChangeExit"))
			{
				this.StateChangeExit = characterSplineClimbComponent.StateChangeExit;
			}
			if (base.CanResetComponentProperty("EventAdded"))
			{
				this.EventAdded = characterSplineClimbComponent.EventAdded;
			}
			return (!base.CanResetComponentProperty("TargetTransform") || characterSplineClimbComponent.TargetTransform == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.TargetTransform), "TargetTransform")) && (!base.CanResetComponentProperty("MoveOffset") || characterSplineClimbComponent.MoveOffset == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MoveOffset), "MoveOffset")) && (!base.CanResetComponentProperty("TargetLocation") || characterSplineClimbComponent.TargetLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TargetLocation), "TargetLocation")) && (!base.CanResetComponentProperty("TargetRotator") || characterSplineClimbComponent.TargetRotator == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TargetRotator), "TargetRotator")) && (!base.CanResetComponentProperty("TempTransform") || characterSplineClimbComponent.TempTransform == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Transform>(this.TempTransform), "TempTransform")) && (!base.CanResetComponentProperty("TempVector") || characterSplineClimbComponent.TempVector == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector")) && (!base.CanResetComponentProperty("TempVector2") || characterSplineClimbComponent.TempVector2 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector2), "TempVector2")) && (!base.CanResetComponentProperty("TempVector3") || characterSplineClimbComponent.TempVector3 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector3), "TempVector3")) && (!base.CanResetComponentProperty("TempQuat") || characterSplineClimbComponent.TempQuat == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TempQuat), "TempQuat"));
		}

		// Token: 0x0401C36D RID: 115565
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C36E RID: 115566
		[Nullable(2)]
		private CharacterAnimationComponent AnimComp;

		// Token: 0x0401C36F RID: 115567
		[Nullable(2)]
		private CharacterClimbComponent ClimbComp;

		// Token: 0x0401C370 RID: 115568
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401C371 RID: 115569
		[Nullable(2)]
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C372 RID: 115570
		[Nullable(2)]
		private Action<bool> EndCallback;

		// Token: 0x0401C373 RID: 115571
		[Nullable(2)]
		private SplineRuntime SplineRuntime;

		// Token: 0x0401C374 RID: 115572
		private readonly Vector TraceDirection = Vector.Create();

		// Token: 0x0401C375 RID: 115573
		[Nullable(2)]
		private UKuroAnimInstanceRole AnimInstance;

		// Token: 0x0401C376 RID: 115574
		private float FastClimbMix;

		// Token: 0x0401C377 RID: 115575
		private float SmoothedSpeed;

		// Token: 0x0401C378 RID: 115576
		[Nullable(2)]
		private UTraceSphereElement TraceElement;

		// Token: 0x0401C379 RID: 115577
		private bool InSplineClimb;

		// Token: 0x0401C37A RID: 115578
		private int DisableClimbHandle;

		// Token: 0x0401C37B RID: 115579
		private bool StateChangeExit;

		// Token: 0x0401C37C RID: 115580
		private bool EventAdded;

		// Token: 0x0401C37D RID: 115581
		[Nullable(2)]
		[StaticVariableRuleIgnore]
		private static SplineClimbParams CommonParams;

		// Token: 0x0401C37E RID: 115582
		private readonly Transform TargetTransform = Transform.Create();

		// Token: 0x0401C37F RID: 115583
		private readonly Vector MoveOffset = Vector.Create();

		// Token: 0x0401C380 RID: 115584
		private readonly Vector TargetLocation = Vector.Create();

		// Token: 0x0401C381 RID: 115585
		private readonly Rotator TargetRotator = Rotator.Create();

		// Token: 0x0401C382 RID: 115586
		private readonly Transform TempTransform = Transform.Create();

		// Token: 0x0401C383 RID: 115587
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0401C384 RID: 115588
		private readonly Vector TempVector2 = Vector.Create();

		// Token: 0x0401C385 RID: 115589
		private readonly Vector TempVector3 = Vector.Create();

		// Token: 0x0401C386 RID: 115590
		private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);
	}
}
