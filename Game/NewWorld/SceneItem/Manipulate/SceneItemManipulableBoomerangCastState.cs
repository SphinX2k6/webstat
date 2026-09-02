using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484D RID: 18509
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulableBoomerangCastState : SceneItemManipulableCastState
	{
		// Token: 0x06030271 RID: 197233 RVA: 0x00BADA38 File Offset: 0x00BABC38
		public SceneItemManipulableBoomerangCastState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, new TSubclassOf<UCameraShakeBase>?(cameraShake), gamepadShake)
		{
			this.BoomerangConfig = (this.SceneItem.Config.ThrowCfg.MotionConfig as ICircumnutation);
			this.Velocity = this.BoomerangConfig.Velocity;
			this.RotateSpeed = this.BoomerangConfig.AngularVelocity;
			if (!StringUtils.IsEmpty(this.BoomerangConfig.AngularVelocityCurve))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(this.BoomerangConfig.AngularVelocityCurve, delegate([Nullable(2)] UCurveFloat result, string _)
				{
					this.AngularVelocityCurve = result;
				}, 100, "js_undefined");
			}
			if (!StringUtils.IsEmpty(this.BoomerangConfig.VelocityCurve))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(this.BoomerangConfig.VelocityCurve, delegate([Nullable(2)] UCurveFloat result, string _)
				{
					this.VelocityCurve = result;
				}, 100, "js_undefined");
			}
			this.VelocityDirection = Vector.Create();
			IRenderTrajectoryConfig renderTrajectoryConfig = (this.SceneItem.Config.ThrowCfg.MotionConfig as ICircumnutation).RenderTrajectoryConfig;
			this.LifeTime = ((renderTrajectoryConfig != null) ? new float?(renderTrajectoryConfig.Time) : null).GetValueOrDefault();
		}

		// Token: 0x06030272 RID: 197234 RVA: 0x00BADB94 File Offset: 0x00BABD94
		protected override void OnEnter()
		{
			base.OnEnter();
			this.SimulationTimer = 0f;
			this.PrevLoc.DeepCopy(this.LastLoc);
			if (this.HitCallback != null)
			{
				this.SceneItem.ActorComp.Owner.OnActorHit.Add(this.HitCallback);
			}
			this.SceneItem.ForceMoving = true;
		}

		// Token: 0x06030273 RID: 197235 RVA: 0x00BADBF7 File Offset: 0x00BABDF7
		public void SetVelocityDirection(Vector dire)
		{
			this.VelocityDirection.DeepCopy(dire);
		}

		// Token: 0x06030274 RID: 197236 RVA: 0x00BADC08 File Offset: 0x00BABE08
		protected override void OnTick(float delta)
		{
			this.TempDelta += delta;
			while (this.TempDelta > this.TimeStepLimit)
			{
				this.UpdateLocation(this.TimeStepLimit);
				this.TempDelta -= this.TimeStepLimit;
			}
			this.UpdateRotationAccordingToVelocity();
		}

		// Token: 0x06030275 RID: 197237 RVA: 0x00BADC58 File Offset: 0x00BABE58
		protected override void UpdateLocation(float delta)
		{
			this.SimulationTimer += delta;
			Vector slalomLocation = this.GetSlalomLocation(this.PrevLoc, this.VelocityDirection, this.UpVector, delta);
			this.SceneItem.ActorComp.SetActorLocation(slalomLocation.ToUeVector(false), "[ManipulableCastState.UpdateSlalomLocation]", true);
			this.PrevLoc = slalomLocation;
		}

		// Token: 0x06030276 RID: 197238 RVA: 0x00BADCB4 File Offset: 0x00BABEB4
		private Vector GetSlalomLocation(Vector startLoc, Vector velocityDirection, Vector upVector, float timeStep)
		{
			float num = this.RotateSpeed * timeStep;
			UCurveFloat angularVelocityCurve = this.AngularVelocityCurve;
			if (angularVelocityCurve != null && angularVelocityCurve.IsValid())
			{
				num *= this.AngularVelocityCurve.GetFloatValue(this.SimulationTimer);
			}
			num *= (float)((this.BoomerangConfig.Direction == EDirection.Right) ? 1 : -1);
			num = (float)Math.Floor((double)(num * 100f)) / 100f;
			velocityDirection.RotateAngleAxis((double)num, upVector, velocityDirection);
			Vector vector = Vector.Create();
			velocityDirection.Multiply((double)(this.Velocity * timeStep), vector);
			UCurveFloat velocityCurve = this.VelocityCurve;
			if (velocityCurve != null && velocityCurve.IsValid())
			{
				vector.MultiplyEqual((double)this.VelocityCurve.GetFloatValue(this.SimulationTimer));
			}
			vector.Set(Math.Floor(vector.X * 100.0) / 100.0, Math.Floor(vector.Y * 100.0) / 100.0, Math.Floor(vector.Z * 100.0) / 100.0);
			startLoc.Addition(vector, vector);
			return vector;
		}

		// Token: 0x06030277 RID: 197239 RVA: 0x00BADDDC File Offset: 0x00BABFDC
		public List<Vector> GetCastPath(Vector targetDirection, float? time = null)
		{
			List<Vector> list = new List<Vector>();
			this.VelocityDirection.DeepCopy(targetDirection);
			this.LastLoc = Vector.Create(this.SceneItem.ActorComp.ActorLocationProxy);
			Vector vector = Vector.Create(this.LastLoc);
			Vector vector2 = Vector.Create(Vector.UpVectorProxy);
			vector2.CrossProduct(this.VelocityDirection, vector2);
			vector2.Normalize(9.99999993922529E-09);
			this.UpVector.DeepCopy(vector2);
			this.VelocityDirection.CrossProduct(this.UpVector, this.UpVector);
			this.UpVector.Normalize(9.99999993922529E-09);
			this.SimulationTimer = 0f;
			list.Add(vector);
			float num = time ?? this.LifeTime;
			for (float num2 = 0f; num2 < num; num2 += this.TimeStepLimit)
			{
				this.SimulationTimer += this.TimeStepLimit;
				Vector slalomLocation = this.GetSlalomLocation(vector, targetDirection, this.UpVector, this.TimeStepLimit);
				vector = slalomLocation;
				list.Add(slalomLocation);
			}
			return list;
		}

		// Token: 0x06030278 RID: 197240 RVA: 0x00BADEFE File Offset: 0x00BAC0FE
		public override bool IsNoLockCasting()
		{
			return true;
		}

		// Token: 0x0401BA40 RID: 113216
		private readonly float Velocity;

		// Token: 0x0401BA41 RID: 113217
		[Nullable(2)]
		private readonly Vector VelocityDirection;

		// Token: 0x0401BA42 RID: 113218
		private readonly float RotateSpeed = 180f;

		// Token: 0x0401BA43 RID: 113219
		private readonly Vector UpVector = Vector.Create();

		// Token: 0x0401BA44 RID: 113220
		[Nullable(2)]
		private readonly ICircumnutation BoomerangConfig;

		// Token: 0x0401BA45 RID: 113221
		[Nullable(2)]
		private UCurveFloat AngularVelocityCurve;

		// Token: 0x0401BA46 RID: 113222
		[Nullable(2)]
		private UCurveFloat VelocityCurve;

		// Token: 0x0401BA47 RID: 113223
		private float SimulationTimer;

		// Token: 0x0401BA48 RID: 113224
		private readonly float LifeTime;

		// Token: 0x0401BA49 RID: 113225
		private readonly float TimeStepLimit = 0.033f;

		// Token: 0x0401BA4A RID: 113226
		private Vector PrevLoc = Vector.Create();

		// Token: 0x0401BA4B RID: 113227
		private Vector LastLoc = Vector.Create();

		// Token: 0x0401BA4C RID: 113228
		private float TempDelta;
	}
}
