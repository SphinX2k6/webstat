using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle
{
	// Token: 0x020047A5 RID: 18341
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleAudioComponent : VehicleAudioComponent, IStaticVariableResetter
	{
		// Token: 0x0602F958 RID: 194904 RVA: 0x00B57963 File Offset: 0x00B55B63
		static MotorcycleAudioComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MotorcycleAudioComponent.CreateStaticDefaultValue), new Action(MotorcycleAudioComponent.ResetStaticDefaultValue));
		}

		// Token: 0x0602F959 RID: 194905 RVA: 0x00B57982 File Offset: 0x00B55B82
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602F95A RID: 194906 RVA: 0x00B57984 File Offset: 0x00B55B84
		public static void ResetStaticDefaultValue()
		{
			MotorcycleAudioComponent.StackStatInternal = null;
		}

		// Token: 0x170081AD RID: 33197
		// (get) Token: 0x0602F95B RID: 194907 RVA: 0x00B5798C File Offset: 0x00B55B8C
		// (set) Token: 0x0602F95C RID: 194908 RVA: 0x00B579AD File Offset: 0x00B55BAD
		private FHitResult CacheHitResult
		{
			get
			{
				if (this.CacheHitResultInternal == null)
				{
					this.CacheHitResultInternal = new FHitResult();
				}
				return this.CacheHitResultInternal;
			}
			set
			{
				this.CacheHitResultInternal = value;
			}
		}

		// Token: 0x170081AE RID: 33198
		// (get) Token: 0x0602F95D RID: 194909 RVA: 0x00B579B6 File Offset: 0x00B55BB6
		private static Stat StackStat
		{
			get
			{
				if (MotorcycleAudioComponent.StackStatInternal == null)
				{
					MotorcycleAudioComponent.StackStatInternal = Stat.Create("MotorcycleAudioComponent.DetectFloorHandle", "", "");
				}
				return MotorcycleAudioComponent.StackStatInternal;
			}
		}

		// Token: 0x0602F95E RID: 194910 RVA: 0x00B579E0 File Offset: 0x00B55BE0
		protected override bool OnStart()
		{
			this.MoveComp = base.Entity.GetComponent<MotorcycleMoveComponent>();
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.WaterComp = base.Entity.GetComponent<MotorcycleWaterComponent>();
			MotorcycleMoveComponent moveComp = this.MoveComp;
			float? num;
			if (moveComp == null)
			{
				num = null;
			}
			else
			{
				UKuroVehicleMovementComponent vehicleMovement = moveComp.VehicleMovement;
				num = ((vehicleMovement != null) ? new float?(vehicleMovement.MotorFrontWheelHang.GPerCm) : null);
			}
			float? num2 = num;
			this.FrontWheelHangG = num2.GetValueOrDefault(0.07f);
			MotorcycleMoveComponent moveComp2 = this.MoveComp;
			float? num3;
			if (moveComp2 == null)
			{
				num3 = null;
			}
			else
			{
				UKuroVehicleMovementComponent vehicleMovement2 = moveComp2.VehicleMovement;
				num3 = ((vehicleMovement2 != null) ? new float?(vehicleMovement2.MotorBackWheelHang.GPerCm) : null);
			}
			num2 = num3;
			this.RearWheelHangG = num2.GetValueOrDefault(0.07f);
			return true;
		}

		// Token: 0x0602F95F RID: 194911 RVA: 0x00B57AB8 File Offset: 0x00B55CB8
		protected override void OnTick(float delta)
		{
			if (this.MoveComp == null || !this.IsPlayerDriving)
			{
				return;
			}
			int num = (base.ActorComp.ActorVelocityProxy.DotProduct(base.ActorComp.ActorForwardProxy) < 0.0) ? -1 : 1;
			float speed = this.MoveComp.Speed * (float)num;
			this.UpdateMotorHangsAudio((double)delta);
			this.UpdateMotorWheelTexture();
			this.SetMotorAcceleration(delta, speed);
			this.SetMotorSpeed(delta, speed);
			this.SetMotorInAirDurationRtpc(delta);
		}

		// Token: 0x0602F960 RID: 194912 RVA: 0x00B57B35 File Offset: 0x00B55D35
		protected override bool OnEnd()
		{
			this.ChangeEventListener(true);
			this.LeaveMotorClearAudio();
			this.IsPlayerDriving = false;
			return base.OnEnd();
		}

		// Token: 0x0602F961 RID: 194913 RVA: 0x00B57B54 File Offset: 0x00B55D54
		protected override void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (info.IsNpcPassenger())
			{
				GameAudioModel instance = ModelBase<GameAudioModel>.Instance;
				if (instance != null && instance.CheckMotorState())
				{
					GameAudioModel instance2 = ModelBase<GameAudioModel>.Instance;
					if (instance2 != null)
					{
						instance2.PlayMotorPlotAudio(EGondolaVoiceTriggeredType.InviteRole);
					}
				}
			}
			if (!info.IsRolePassenger(true))
			{
				return;
			}
			this.IsPlayerDriving = true;
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.MotorEngine, false);
			this.ChangeEventListener(false);
			this.MotorStrength = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.MotorcycleStrength);
			this.MaxMotorStrength = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.MotorcycleStrength);
			this.SetMotorStrengthRtpc(this.MotorStrength, this.MaxMotorStrength);
		}

		// Token: 0x0602F962 RID: 194914 RVA: 0x00B57BE8 File Offset: 0x00B55DE8
		protected override void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
		{
			if (!info.IsRolePassenger(true))
			{
				return;
			}
			this.IsPlayerDriving = false;
			this.ChangeEventListener(true);
			this.LeaveMotorClearAudio();
		}

		// Token: 0x0602F963 RID: 194915 RVA: 0x00B57C08 File Offset: 0x00B55E08
		private void ChangeEventListener(bool remove = false)
		{
			if (!remove && !this.HasEventListener)
			{
				this.HasEventListener = true;
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.漂移"], new BaseTagComponent.TTagSwitchedCallback(this.MotorDriftingStateChange), null);
				}
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.MotorNitroStateChange), null);
				}
				BaseTagComponent tagComp3 = this.TagComp;
				if (tagComp3 != null)
				{
					tagComp3.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.MotorGlideStateChange), null);
				}
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.MotorOnHit, new Action<EMotorPart, FHitResult>(this.MotorOnHit));
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateModeChange));
				ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged), null);
				ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthMaxChanged), null);
				return;
			}
			if (remove && this.HasEventListener)
			{
				this.HasEventListener = false;
				BaseTagComponent tagComp4 = this.TagComp;
				if (tagComp4 != null)
				{
					tagComp4.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.漂移"], new BaseTagComponent.TTagSwitchedCallback(this.MotorDriftingStateChange));
				}
				BaseTagComponent tagComp5 = this.TagComp;
				if (tagComp5 != null)
				{
					tagComp5.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.MotorNitroStateChange));
				}
				BaseTagComponent tagComp6 = this.TagComp;
				if (tagComp6 != null)
				{
					tagComp6.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.移动.翱翔冲刺"], new BaseTagComponent.TTagSwitchedCallback(this.MotorGlideStateChange));
				}
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.MotorOnHit, new Action<EMotorPart, FHitResult>(this.MotorOnHit));
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateModeChange));
				ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthChanged));
				ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.MotorcycleStrength, new TValueListener(this.OnStrengthMaxChanged));
			}
		}

		// Token: 0x0602F964 RID: 194916 RVA: 0x00B57E3C File Offset: 0x00B5603C
		private void LeaveMotorClearAudio()
		{
			if (base.ActorComp == null)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_speed", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_nos_energe", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_nos_energe_percent", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_engine_speed", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_crash_strength", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_air_land_time_seconds", 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?(200)
			}));
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.NitroAcceleration, true);
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.MotorEngine, true);
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.WheelRoll, true);
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.BrakingTurn, true);
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.DriftingState, true);
		}

		// Token: 0x0602F965 RID: 194917 RVA: 0x00B5802C File Offset: 0x00B5622C
		private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			if ((double)Math.Abs(newValue - this.MotorStrength) < 5.0 && newValue != 0f)
			{
				return;
			}
			if ((double)newValue < 5.0)
			{
				this.MotorStrength = 0f;
			}
			else
			{
				this.MotorStrength = newValue;
			}
			this.SetMotorStrengthRtpc(this.MotorStrength, this.MaxMotorStrength);
		}

		// Token: 0x0602F966 RID: 194918 RVA: 0x00B5808E File Offset: 0x00B5628E
		private void OnStrengthMaxChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			this.MaxMotorStrength = newValue;
		}

		// Token: 0x0602F967 RID: 194919 RVA: 0x00B58098 File Offset: 0x00B56298
		private void SetMotorStrengthRtpc(float value, float maxValue)
		{
			if (base.ActorComp == null || value > maxValue)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_nos_energe", value, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner
			}));
			float value2 = value / maxValue;
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_nos_energe_percent", value2, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner
			}));
		}

		// Token: 0x0602F968 RID: 194920 RVA: 0x00B58118 File Offset: 0x00B56318
		private void MotorOnHit(EMotorPart part, FHitResult hitResult)
		{
			if (base.ActorComp == null || (double)Math.Abs(this.LastMotorOnHitSpeed - this.LastMotorSpeed) < 20.0)
			{
				return;
			}
			this.LastMotorOnHitSpeed = this.LastMotorSpeed;
			this.TempVector.DeepCopy(hitResult.Normal);
			this.LastMotorOnHitStrength = (float)Math.Abs(this.MotorSpeedDirection.DotProduct(this.TempVector));
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_crash_strength", this.LastMotorOnHitStrength, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner
			}));
			Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_crash", base.ActorComp.Owner, null);
		}

		// Token: 0x0602F969 RID: 194921 RVA: 0x00B581E4 File Offset: 0x00B563E4
		private void MotorDriftingStateChange(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.DriftingState, false);
				return;
			}
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.DriftingState, true);
		}

		// Token: 0x0602F96A RID: 194922 RVA: 0x00B58204 File Offset: 0x00B56404
		private void MotorGlideStateChange(int tagId, bool tagExist)
		{
			if (!base.ActorComp)
			{
				return;
			}
			if (tagExist)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_gliding_nos_start", base.ActorComp.Owner, null);
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_gliding_nos_end", base.ActorComp.Owner, null);
		}

		// Token: 0x0602F96B RID: 194923 RVA: 0x00B5826B File Offset: 0x00B5646B
		private void MotorNitroStateChange(int tagId, bool tagExist)
		{
			this.MotorNitroAcceleration(tagExist);
		}

		// Token: 0x0602F96C RID: 194924 RVA: 0x00B58274 File Offset: 0x00B56474
		private void MotorSubStateModeChange(EMotorSubState newValue, EMotorSubState oldValue)
		{
			if (base.ActorComp == null)
			{
				return;
			}
			bool flag = this.CheckMotorAirState(oldValue);
			bool flag2 = this.CheckMotorAirState(newValue);
			if (!flag && flag2)
			{
				this.InAirDuration = 0f;
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_takeoff", base.ActorComp.Owner, null);
			}
			if (flag && !flag2)
			{
				this.InAirDuration = 0f;
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_touchdown", base.ActorComp.Owner, null);
			}
			if (newValue == EMotorSubState.BrakingTurn)
			{
				this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.BrakingTurn, false);
			}
			if (oldValue == EMotorSubState.BrakingTurn)
			{
				this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.BrakingTurn, true);
			}
			this.LastMotorSubState = newValue;
		}

		// Token: 0x0602F96D RID: 194925 RVA: 0x00B5832C File Offset: 0x00B5652C
		private void SetMotorInAirDurationRtpc(float delta)
		{
			if (base.ActorComp == null)
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp(this.InAirDuration + delta * (float)(this.CheckMotorAirState(this.LastMotorSubState) ? 1 : -1) * 0.001f, -10f, 10f);
			if (this.InAirDuration == num)
			{
				return;
			}
			this.InAirDuration = num;
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_air_land_time_seconds", this.InAirDuration, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?((int)delta)
			}));
		}

		// Token: 0x0602F96E RID: 194926 RVA: 0x00B583D0 File Offset: 0x00B565D0
		private void SetMotorSpeed(float delta, float speed)
		{
			VehicleActorComponent actorComp = base.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) == null || (speed == 0f && this.LastMotorSpeed == 0f) || ((double)Math.Abs(this.LastMotorSpeed - speed) < 20.0 && this.LastMotorSpeed != 0f))
			{
				return;
			}
			this.LastMotorSpeed = speed;
			this.MotorSpeedDirection.DeepCopy(base.ActorComp.ActorVelocityProxy);
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_speed", speed, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?((int)delta)
			}));
			if ((double)Math.Abs(speed) < 20.0 || this.CheckMotorAirState(this.LastMotorSubState))
			{
				this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.WheelRoll, true);
				return;
			}
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.WheelRoll, false);
		}

		// Token: 0x0602F96F RID: 194927 RVA: 0x00B584C4 File Offset: 0x00B566C4
		private void SetMotorAcceleration(float delta, float speed)
		{
			MotorcycleMoveComponent moveComp = this.MoveComp;
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (moveComp != null) ? moveComp.VehicleMovement : null;
			VehicleActorComponent actorComp = base.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) == null || ukuroVehicleMovementComponent == null)
			{
				return;
			}
			float currentMotorPower = ukuroVehicleMovementComponent.GetCurrentMotorPower();
			float toMax = ukuroVehicleMovementComponent.MotorAccelConfig.PowerAccel.ToMax;
			float toMax2 = ukuroVehicleMovementComponent.MotorAccelConfig.PowerAccel.ToMax;
			float num = this.CheckMotorAirState(this.LastMotorSubState) ? 1.6f : 1f;
			float num2 = Singleton<MathUtils>.Instance.Clamp(Math.Abs(speed) / toMax2, 0f, 1f);
			float num3 = Singleton<MathUtils>.Instance.Clamp(-2500f * num2 * (num2 - 2f) + 3000f * (currentMotorPower / toMax) * num, 0f, 6000f);
			if ((num3 == 0f && this.LastEngineSpeed == 0f) || ((double)Math.Abs(this.LastEngineSpeed - num3) < 10.0 && this.LastEngineSpeed != 0f))
			{
				return;
			}
			this.LastEngineSpeed = num3;
			Singleton<AudioSystem>.Instance.SetRtpcValue("motor_engine_speed", num3, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = base.ActorComp.Owner,
				TransitionDuration = new int?((int)delta)
			}));
		}

		// Token: 0x0602F970 RID: 194928 RVA: 0x00B5861C File Offset: 0x00B5681C
		private void MotorNitroAcceleration(bool change)
		{
			VehicleActorComponent actorComp = base.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) == null)
			{
				return;
			}
			if (change)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_nos_start", base.ActorComp.Owner, null);
				this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.NitroAcceleration, false);
				return;
			}
			this.ChangeMoveAudioEvent(EMotorMoveAudioEvent.NitroAcceleration, true);
			if (!this.MoveComp.BackBraking)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_nos_end", base.ActorComp.Owner, null);
			}
		}

		// Token: 0x0602F971 RID: 194929 RVA: 0x00B586B0 File Offset: 0x00B568B0
		public void MotorNitroAccelerationFailure(bool banned, bool sprint, bool input)
		{
			VehicleActorComponent actorComp = base.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) == null)
			{
				return;
			}
			if (banned && (this.LastNitroSprint != sprint || (!this.LastNitroInput && input)))
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_nos_failed", base.ActorComp.Owner, null);
			}
			this.LastNitroInput = input;
			this.LastNitroSprint = sprint;
		}

		// Token: 0x0602F972 RID: 194930 RVA: 0x00B58720 File Offset: 0x00B56920
		private void UpdateMotorHangsAudio(double delta)
		{
			if (base.ActorComp != null)
			{
				MotorcycleMoveComponent moveComp = this.MoveComp;
				if (((moveComp != null) ? moveComp.VehicleMovement : null) != null)
				{
					Vector tempVector = this.TempVector;
					FVector fvector = this.MoveComp.VehicleMovement.GetCurrentMotorFrontPulling();
					tempVector.FromUeVector(fvector);
					double num = this.FrontWheelPulling.SubtractionEqual(this.TempVector).Size() * (double)this.FrontWheelHangG / (delta * 0.0010000000474974513);
					this.FrontWheelPulling.DeepCopy(this.TempVector);
					Vector tempVector2 = this.TempVector;
					fvector = this.MoveComp.VehicleMovement.GetCurrentMotorRearPulling();
					tempVector2.FromUeVector(fvector);
					double num2 = this.RearWheelPulling.SubtractionEqual(this.TempVector).Size() * (double)this.RearWheelHangG / (delta * 0.0010000000474974513);
					this.RearWheelPulling.DeepCopy(this.TempVector);
					if ((num > 25.0 || num2 > 25.0) && Singleton<Time>.Instance.Now - this.HangsAudioLastTime > 100.0)
					{
						this.HangsAudioLastTime = Singleton<Time>.Instance.Now;
						Singleton<AudioSystem>.Instance.PostEvent("play_sfx_motor_suspension", base.ActorComp.Owner, null);
					}
					return;
				}
			}
		}

		// Token: 0x0602F973 RID: 194931 RVA: 0x00B58864 File Offset: 0x00B56A64
		private void ChangeMoveAudioEvent(EMotorMoveAudioEvent eventType, bool stop = false)
		{
			if (base.ActorComp == null)
			{
				return;
			}
			bool flag = this.AudioEventHandleMap.ContainsKey(eventType);
			if (!stop && !flag)
			{
				string text;
				string @event = this.AudioEventOverrideMap.TryGetValue(eventType, out text) ? text : eventType.Value;
				int value = Singleton<AudioSystem>.Instance.PostEvent(@event, base.ActorComp.Owner, null);
				this.AudioEventHandleMap[eventType] = value;
				return;
			}
			if (stop && flag)
			{
				int handle = this.AudioEventHandleMap[eventType];
				Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, null);
				this.AudioEventHandleMap.Remove(eventType);
			}
		}

		// Token: 0x0602F974 RID: 194932 RVA: 0x00B58910 File Offset: 0x00B56B10
		private string GetMoveAudioEventName(EMotorMoveAudioEvent eventType)
		{
			if (eventType == EMotorMoveAudioEvent.WheelRoll)
			{
				return "轮胎音效";
			}
			if (eventType == EMotorMoveAudioEvent.BrakingTurn)
			{
				return "烧胎音效";
			}
			if (eventType == EMotorMoveAudioEvent.DriftingState)
			{
				return "漂移音效";
			}
			if (eventType == EMotorMoveAudioEvent.MotorEngine)
			{
				return "引擎音效";
			}
			if (eventType == EMotorMoveAudioEvent.NitroAcceleration)
			{
				return "氮气音效";
			}
			return "未知音效";
		}

		// Token: 0x0602F975 RID: 194933 RVA: 0x00B58984 File Offset: 0x00B56B84
		private void UpdateMotorWheelTexture()
		{
			VehicleActorComponent actorComp = base.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) == null)
			{
				return;
			}
			CharacterFootEffectComponent.EFootstepTexture motorWheelTexture = this.GetMotorWheelTexture();
			if (this.LastTexture != motorWheelTexture)
			{
				this.LastTexture = motorWheelTexture;
				Singleton<AudioSystem>.Instance.SetSwitch("motor_wheel_texture", motorWheelTexture.ToEnumString(), base.ActorComp.Owner);
			}
		}

		// Token: 0x0602F976 RID: 194934 RVA: 0x00B589E0 File Offset: 0x00B56BE0
		private CharacterFootEffectComponent.EFootstepTexture GetMotorWheelTexture()
		{
			VehicleActorComponent actorComp = base.ActorComp;
			TsBaseVehicle tsBaseVehicle = (actorComp != null) ? actorComp.Actor : null;
			MotorcycleMoveComponent moveComp = this.MoveComp;
			if (((moveComp != null) ? moveComp.VehicleMovement : null) == null || tsBaseVehicle == null)
			{
				return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
			}
			if (this.CheckMotorAirState(this.LastMotorSubState))
			{
				return this.LastTexture;
			}
			MotorcycleWaterComponent waterComp = this.WaterComp;
			if (waterComp != null && waterComp.InSwimArea)
			{
				return this.CheckWaterSurfaceType();
			}
			if (!this.GetHitResult())
			{
				return this.LastTexture;
			}
			this.TempVector.DeepCopy(this.CacheHitResult.Location);
			FoliageAudioInfo foliageAudioInfo = Singleton<AudioUtils>.Instance.QueryFoliageAudioPhysicalMaterial(this.TempVector.ToUeVector(false), base.Entity);
			if (foliageAudioInfo.IsHitFoliage && foliageAudioInfo.PhysicalMaterial != null)
			{
				return this.GetMaterialTexture(foliageAudioInfo.PhysicalMaterial);
			}
			TWeakObjectPtr<UPhysicalMaterial> physMaterial = this.CacheHitResult.PhysMaterial;
			return this.GetMaterialTexture(physMaterial);
		}

		// Token: 0x0602F977 RID: 194935 RVA: 0x00B58AC8 File Offset: 0x00B56CC8
		private void CacheMotorHitResult(bool forward)
		{
			FHitResult cacheHitResult = this.CacheHitResult;
			if (forward)
			{
				MotorcycleMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					UKuroVehicleMovementComponent vehicleMovement = moveComp.VehicleMovement;
					if (vehicleMovement != null)
					{
						vehicleMovement.GetFrontMotorHitResult(ref cacheHitResult);
					}
				}
			}
			else
			{
				MotorcycleMoveComponent moveComp2 = this.MoveComp;
				if (moveComp2 != null)
				{
					UKuroVehicleMovementComponent vehicleMovement2 = moveComp2.VehicleMovement;
					if (vehicleMovement2 != null)
					{
						vehicleMovement2.GetBackMotorHitResult(ref cacheHitResult);
					}
				}
			}
			this.CacheHitResult = cacheHitResult;
		}

		// Token: 0x0602F978 RID: 194936 RVA: 0x00B58B28 File Offset: 0x00B56D28
		private bool GetHitResult()
		{
			bool flag = base.ActorComp.ActorVelocityProxy.DotProduct(base.ActorComp.ActorForwardProxy) > 0.0;
			this.CacheMotorHitResult(flag);
			if (!this.CacheHitResult.bBlockingHit)
			{
				this.CacheMotorHitResult(!flag);
			}
			return this.CacheHitResult.bBlockingHit;
		}

		// Token: 0x0602F979 RID: 194937 RVA: 0x00B58B88 File Offset: 0x00B56D88
		[NullableContext(2)]
		private CharacterFootEffectComponent.EFootstepTexture GetMaterialTexture(UPhysicalMaterial material)
		{
			if (material != null && material.IsValid())
			{
				if (material.SurfaceType == EPhysicalSurface.SurfaceType6 || material.SurfaceType == EPhysicalSurface.SurfaceType14)
				{
					return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
				}
				string text = UKuroAudioMaterialSettings.GetFootstepTextureName(material.SurfaceType).ToString();
				CharacterFootEffectComponent.EFootstepTexture result;
				if (text.Length > 0 && Enum.TryParse<CharacterFootEffectComponent.EFootstepTexture>(text, out result))
				{
					return result;
				}
			}
			return CharacterFootEffectComponent.EFootstepTexture.DirtSurface;
		}

		// Token: 0x0602F97A RID: 194938 RVA: 0x00B58C00 File Offset: 0x00B56E00
		private CharacterFootEffectComponent.EFootstepTexture CheckWaterSurfaceType()
		{
			if (base.ActorComp == null)
			{
				return CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
			}
			AActor owner = base.ActorComp.Owner;
			TWeakObjectPtr<UKuroEnviInteractionComponent> key = new TWeakObjectPtr<UKuroEnviInteractionComponent>(((owner != null) ? owner.GetComponentByClass(UKuroEnviInteractionComponent.StaticClass()) : null) as UKuroEnviInteractionComponent);
			if (base.ActorComp.Owner != null)
			{
				UKuroInteractionEffectSystem kuroInteractionEffectSystem = UKuroInteractionEffectSystem.GetKuroInteractionEffectSystem(base.ActorComp.Owner.GetWorld());
				if (kuroInteractionEffectSystem != null)
				{
					FKuroEnviInteractionData fkuroEnviInteractionData = kuroInteractionEffectSystem.EnviInteractionCollections.Get(key);
					if (fkuroEnviInteractionData != null && fkuroEnviInteractionData.WaterType == 1)
					{
						return CharacterFootEffectComponent.EFootstepTexture.VoicelessSurface;
					}
				}
			}
			return CharacterFootEffectComponent.EFootstepTexture.WaterSurface;
		}

		// Token: 0x0602F97B RID: 194939 RVA: 0x00B58C8C File Offset: 0x00B56E8C
		private bool CheckMotorAirState(EMotorSubState state)
		{
			return state == EMotorSubState.AirMoving || state == EMotorSubState.Soaring;
		}

		// Token: 0x0602F97C RID: 194940 RVA: 0x00B58C98 File Offset: 0x00B56E98
		[NullableContext(2)]
		public void SetAudioEventOverride(EMotorMoveAudioEvent eventType, string eventName = null)
		{
			if (!string.IsNullOrEmpty(eventName))
			{
				this.AudioEventOverrideMap[eventType] = eventName;
			}
			else
			{
				this.AudioEventOverrideMap.Remove(eventType);
			}
			int handle;
			if (!this.AudioEventHandleMap.TryGetValue(eventType, out handle) || base.ActorComp == null)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(handle, EAudioActionType.Stop, null);
			this.AudioEventHandleMap.Remove(eventType);
			string text;
			string @event = this.AudioEventOverrideMap.TryGetValue(eventType, out text) ? text : eventType.Value;
			int value = Singleton<AudioSystem>.Instance.PostEvent(@event, base.ActorComp.Owner, null);
			this.AudioEventHandleMap[eventType] = value;
		}

		// Token: 0x0602F97D RID: 194941 RVA: 0x00B58D4D File Offset: 0x00B56F4D
		public void ClearAudioEventOverrides()
		{
			this.AudioEventOverrideMap.Clear();
		}

		// Token: 0x0602F97E RID: 194942 RVA: 0x00B58D5C File Offset: 0x00B56F5C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			MotorcycleAudioComponent motorcycleAudioComponent = (MotorcycleAudioComponent)componentTemplate;
			if (base.CanResetComponentProperty("TempVector") && motorcycleAudioComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MotorSpeedDirection") && motorcycleAudioComponent.MotorSpeedDirection != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.MotorSpeedDirection), "MotorSpeedDirection"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("FrontWheelHangG"))
			{
				this.FrontWheelHangG = motorcycleAudioComponent.FrontWheelHangG;
			}
			if (base.CanResetComponentProperty("FrontWheelPulling") && motorcycleAudioComponent.FrontWheelPulling != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.FrontWheelPulling), "FrontWheelPulling"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RearWheelHangG"))
			{
				this.RearWheelHangG = motorcycleAudioComponent.RearWheelHangG;
			}
			if (base.CanResetComponentProperty("RearWheelPulling") && motorcycleAudioComponent.RearWheelPulling != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.RearWheelPulling), "RearWheelPulling"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (motorcycleAudioComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (motorcycleAudioComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("WaterComp"))
			{
				if (motorcycleAudioComponent.WaterComp == null)
				{
					this.WaterComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MotorcycleWaterComponent>(this.WaterComp), "WaterComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AudioEventHandleMap") && motorcycleAudioComponent.AudioEventHandleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMotorMoveAudioEvent, int>>(this.AudioEventHandleMap), "AudioEventHandleMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CacheHitResultInternal"))
			{
				if (motorcycleAudioComponent.CacheHitResultInternal == null)
				{
					this.CacheHitResultInternal = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FHitResult>(this.CacheHitResultInternal), "CacheHitResultInternal"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastTexture"))
			{
				this.LastTexture = motorcycleAudioComponent.LastTexture;
			}
			if (base.CanResetComponentProperty("AudioEventOverrideMap") && motorcycleAudioComponent.AudioEventOverrideMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EMotorMoveAudioEvent, string>>(this.AudioEventOverrideMap), "AudioEventOverrideMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("IsPlayerDriving"))
			{
				this.IsPlayerDriving = motorcycleAudioComponent.IsPlayerDriving;
			}
			if (base.CanResetComponentProperty("HasEventListener"))
			{
				this.HasEventListener = motorcycleAudioComponent.HasEventListener;
			}
			if (base.CanResetComponentProperty("MotorStrength"))
			{
				this.MotorStrength = motorcycleAudioComponent.MotorStrength;
			}
			if (base.CanResetComponentProperty("MaxMotorStrength"))
			{
				this.MaxMotorStrength = motorcycleAudioComponent.MaxMotorStrength;
			}
			if (base.CanResetComponentProperty("LastMotorOnHitSpeed"))
			{
				this.LastMotorOnHitSpeed = motorcycleAudioComponent.LastMotorOnHitSpeed;
			}
			if (base.CanResetComponentProperty("LastMotorOnHitStrength"))
			{
				this.LastMotorOnHitStrength = motorcycleAudioComponent.LastMotorOnHitStrength;
			}
			if (base.CanResetComponentProperty("InAirDuration"))
			{
				this.InAirDuration = motorcycleAudioComponent.InAirDuration;
			}
			if (base.CanResetComponentProperty("LastMotorSubState"))
			{
				this.LastMotorSubState = motorcycleAudioComponent.LastMotorSubState;
			}
			if (base.CanResetComponentProperty("LastMotorSpeed"))
			{
				this.LastMotorSpeed = motorcycleAudioComponent.LastMotorSpeed;
			}
			if (base.CanResetComponentProperty("LastEngineSpeed"))
			{
				this.LastEngineSpeed = motorcycleAudioComponent.LastEngineSpeed;
			}
			if (base.CanResetComponentProperty("LastNitroInput"))
			{
				this.LastNitroInput = motorcycleAudioComponent.LastNitroInput;
			}
			if (base.CanResetComponentProperty("LastNitroSprint"))
			{
				this.LastNitroSprint = motorcycleAudioComponent.LastNitroSprint;
			}
			if (base.CanResetComponentProperty("HangsAudioLastTime"))
			{
				this.HangsAudioLastTime = motorcycleAudioComponent.HangsAudioLastTime;
			}
			return true;
		}

		// Token: 0x0401B374 RID: 111476
		private const int MATERIAL_ID_WAT = 6;

		// Token: 0x0401B375 RID: 111477
		private const int MATERIAL_ID_SHR = 14;

		// Token: 0x0401B376 RID: 111478
		private const double SPEED_TOLERANCE = 20.0;

		// Token: 0x0401B377 RID: 111479
		private const double ACC_CHANGE_TOLERANCE = 10.0;

		// Token: 0x0401B378 RID: 111480
		private const double STRENGTH_TOLERANCE = 5.0;

		// Token: 0x0401B379 RID: 111481
		private const float MS_TO_SECOND = 0.001f;

		// Token: 0x0401B37A RID: 111482
		private const float IN_AIR_MAX_DURATION = 10f;

		// Token: 0x0401B37B RID: 111483
		private const int LEAVE_MOTOR_TIME = 200;

		// Token: 0x0401B37C RID: 111484
		private const double HANG_CHANGE_SPEED_TOLERANCE = 25.0;

		// Token: 0x0401B37D RID: 111485
		private const int HANG_AUDIO_INTERVAL_TIME = 100;

		// Token: 0x0401B37E RID: 111486
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0401B37F RID: 111487
		private readonly Vector MotorSpeedDirection = Vector.Create();

		// Token: 0x0401B380 RID: 111488
		private float FrontWheelHangG;

		// Token: 0x0401B381 RID: 111489
		private readonly Vector FrontWheelPulling = Vector.Create();

		// Token: 0x0401B382 RID: 111490
		private float RearWheelHangG;

		// Token: 0x0401B383 RID: 111491
		private readonly Vector RearWheelPulling = Vector.Create();

		// Token: 0x0401B384 RID: 111492
		[Nullable(2)]
		private MotorcycleMoveComponent MoveComp;

		// Token: 0x0401B385 RID: 111493
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401B386 RID: 111494
		[Nullable(2)]
		private MotorcycleWaterComponent WaterComp;

		// Token: 0x0401B387 RID: 111495
		private readonly Dictionary<EMotorMoveAudioEvent, int> AudioEventHandleMap = new Dictionary<EMotorMoveAudioEvent, int>();

		// Token: 0x0401B388 RID: 111496
		[Nullable(2)]
		private FHitResult CacheHitResultInternal;

		// Token: 0x0401B389 RID: 111497
		private CharacterFootEffectComponent.EFootstepTexture LastTexture;

		// Token: 0x0401B38A RID: 111498
		private readonly Dictionary<EMotorMoveAudioEvent, string> AudioEventOverrideMap = new Dictionary<EMotorMoveAudioEvent, string>();

		// Token: 0x0401B38B RID: 111499
		[Nullable(2)]
		private static Stat StackStatInternal;

		// Token: 0x0401B38C RID: 111500
		private bool IsPlayerDriving;

		// Token: 0x0401B38D RID: 111501
		private bool HasEventListener;

		// Token: 0x0401B38E RID: 111502
		private float MotorStrength;

		// Token: 0x0401B38F RID: 111503
		private float MaxMotorStrength;

		// Token: 0x0401B390 RID: 111504
		private float LastMotorOnHitSpeed;

		// Token: 0x0401B391 RID: 111505
		private float LastMotorOnHitStrength;

		// Token: 0x0401B392 RID: 111506
		private float InAirDuration;

		// Token: 0x0401B393 RID: 111507
		private EMotorSubState LastMotorSubState = EMotorSubState.EMotorSubState_MAX;

		// Token: 0x0401B394 RID: 111508
		private float LastMotorSpeed;

		// Token: 0x0401B395 RID: 111509
		private float LastEngineSpeed;

		// Token: 0x0401B396 RID: 111510
		private bool LastNitroInput;

		// Token: 0x0401B397 RID: 111511
		private bool LastNitroSprint;

		// Token: 0x0401B398 RID: 111512
		private double HangsAudioLastTime;
	}
}
