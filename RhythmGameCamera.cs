using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.RhythmGame;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Camera.FightCameraController.SpecialGameplay;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200113F RID: 4415
[NullableContext(1)]
[Nullable(0)]
public class RhythmGameCamera : ISpecialGameplayCamera
{
	// Token: 0x06007405 RID: 29701 RVA: 0x001E3250 File Offset: 0x001E1450
	public void OnInit(ACameraActor camera, CameraModelInstance cameraModel)
	{
		this.CameraActor = camera;
		this.ShipController = ControllerBase<RhythmGameController>.Instance.GetRhythmGameShipController();
		this.InitializeInterpolationState();
		UKuroGameBudgetAllocatorCSharpInterface.AddAssistantActor(this.CameraActor);
		Singleton<EventSystem>.Instance.Add<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameStartPhase, new Action<RhythmGamePerformanceCameraConfig>(this.OnRhythmGameStartPhase));
		Singleton<EventSystem>.Instance.Add<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameEndPhase, new Action<RhythmGamePerformanceCameraConfig>(this.OnRhythmGameEndPhase));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnRhythmGameFreePhase, new Action<bool>(this.OnRhythmGameFreePhase));
	}

	// Token: 0x06007406 RID: 29702 RVA: 0x001E32DC File Offset: 0x001E14DC
	private void InitializeInterpolationState()
	{
		CameraInterpolationState interpolationState = new CameraInterpolationState
		{
			StartPos = Vector.Create(0.0, 0.0, 0.0),
			StartRot = Rotator.Create(0f, 0f, 0f),
			StartFov = 90f,
			TargetPos = Vector.Create(0.0, 0.0, 0.0),
			TargetRot = Rotator.Create(0f, 0f, 0f),
			TargetFov = 90f,
			CurrentPos = Vector.Create(0.0, 0.0, 0.0),
			CurrentRot = Rotator.Create(0f, 0f, 0f),
			CurrentFov = 90f,
			IsInterpolating = false,
			InterpolationDuration = 0.5f,
			ElapsedTime = 0f,
			PrevConfig = null
		};
		this.InterpolationState = interpolationState;
		CameraPhaseState phaseState = new CameraPhaseState
		{
			PhaseType = ECameraPhaseType.Normal,
			StartPos = Vector.Create(0.0, 0.0, 0.0),
			StartRot = Rotator.Create(0f, 0f, 0f),
			StartFov = 90f,
			TargetPos = Vector.Create(0.0, 0.0, 0.0),
			TargetRot = Rotator.Create(0f, 0f, 0f),
			TargetFov = 90f,
			Duration = 0f,
			ElapsedTime = 0f,
			PerformancePos = new FVectorDouble(),
			PerformanceRot = new FRotator(),
			PerformanceFov = 90f
		};
		this.PhaseState = phaseState;
	}

	// Token: 0x06007407 RID: 29703 RVA: 0x001E34DC File Offset: 0x001E16DC
	private float LerpFloat(float start, float end, float alpha)
	{
		return start + (end - start) * alpha;
	}

	// Token: 0x06007408 RID: 29704 RVA: 0x001E34E8 File Offset: 0x001E16E8
	private void UpdateInterpolation(float deltaTime)
	{
		if (this.InterpolationState == null || !this.InterpolationState.IsInterpolating)
		{
			return;
		}
		this.InterpolationState.ElapsedTime += deltaTime;
		float num = Math.Min(this.InterpolationState.ElapsedTime / this.InterpolationState.InterpolationDuration, 1f);
		Vector.Lerp(this.InterpolationState.StartPos, this.InterpolationState.TargetPos, (double)num, this.InterpolationState.CurrentPos);
		Quat quat = this.InterpolationState.StartRot.Quaternion(null);
		Quat quat2 = this.InterpolationState.TargetRot.Quaternion(null);
		Quat quat3 = Quat.Create(0f, 0f, 0f, 1f);
		Quat.Slerp(quat, quat2, num, quat3);
		quat3.Rotator(this.InterpolationState.CurrentRot);
		this.InterpolationState.CurrentFov = this.LerpFloat(this.InterpolationState.StartFov, this.InterpolationState.TargetFov, num);
		if (num >= 1f)
		{
			this.InterpolationState.CurrentPos.DeepCopy(this.InterpolationState.TargetPos);
			this.InterpolationState.CurrentRot.DeepCopy(this.InterpolationState.TargetRot);
			this.InterpolationState.CurrentFov = this.InterpolationState.TargetFov;
			this.InterpolationState.IsInterpolating = false;
			IFreeCameraState freeState = this.FreeState;
			if (freeState != null && freeState.IsExiting.GetValueOrDefault())
			{
				int curSpeedLevelConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
				this.LastConfigIndex = curSpeedLevelConfigIndex;
				RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
				if (currentSpeedLevelConfig != null)
				{
					ControllerBase<RhythmGameController>.Instance.SetShipSpeed(currentSpeedLevelConfig.Speed);
				}
				this.PhaseState.PhaseType = ECameraPhaseType.Normal;
				this.FreeState = null;
				this.InterpolationState.PrevConfig = null;
			}
		}
	}

	// Token: 0x06007409 RID: 29705 RVA: 0x001E36C0 File Offset: 0x001E18C0
	private void UpdateTargetValues(Vector targetPos, Rotator targetRot, float targetFov)
	{
		if (this.InterpolationState == null)
		{
			return;
		}
		this.InterpolationState.TargetPos.DeepCopy(targetPos);
		this.InterpolationState.TargetRot.DeepCopy(targetRot);
		this.InterpolationState.TargetFov = targetFov;
	}

	// Token: 0x0600740A RID: 29706 RVA: 0x001E36FC File Offset: 0x001E18FC
	private void StartInterpolation(Vector targetPos, Rotator targetRot, float targetFov, RhythmGameSpeedLevelConfig prevConfig, float duration = 0.5f)
	{
		if (this.InterpolationState == null)
		{
			return;
		}
		Vector startPos = this.InterpolationState.StartPos;
		FVector fvector = this.CameraActor.K2_GetActorLocation();
		startPos.FromUeVector(fvector);
		Rotator startRot = this.InterpolationState.StartRot;
		FRotator frotator = this.CameraActor.K2_GetActorRotation();
		startRot.FromUeRotator(frotator);
		this.InterpolationState.StartFov = this.CameraActor.CameraComponent.FieldOfView;
		this.InterpolationState.CurrentPos.DeepCopy(this.InterpolationState.StartPos);
		this.InterpolationState.CurrentRot.DeepCopy(this.InterpolationState.StartRot);
		this.InterpolationState.CurrentFov = this.InterpolationState.StartFov;
		this.InterpolationState.PrevConfig = prevConfig;
		this.UpdateTargetValues(targetPos, targetRot, targetFov);
		this.InterpolationState.InterpolationDuration = duration;
		this.InterpolationState.ElapsedTime = 0f;
		this.InterpolationState.IsInterpolating = true;
	}

	// Token: 0x0600740B RID: 29707 RVA: 0x001E37F4 File Offset: 0x001E19F4
	private void EnterStartPhase(FVectorDouble targetPos, FRotator targetRot, float targetFov, float duration)
	{
		if (this.PhaseState == null || this.InterpolationState == null)
		{
			return;
		}
		this.PhaseState.PerformancePos = targetPos;
		this.PhaseState.PerformanceRot = targetRot;
		this.PhaseState.PerformanceFov = targetFov;
		Rotator shipRotation = Rotator.Create(this.ShipController.GetShipRotation());
		Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
		Vector vector = Vector.Create();
		Rotator rotator = Rotator.Create();
		this.CalculateCameraTransform(shipLocation, shipRotation, new RhythmGameSpeedLevelConfig
		{
			Pos = targetPos,
			Rot = targetRot,
			Fov = targetFov
		}, vector, rotator);
		FHitResult fhitResult = new FHitResult();
		AActor cameraActor = this.CameraActor;
		FVectorDouble fvectorDouble = vector.ToUeVector(false);
		cameraActor.K2_SetActorLocationAndRotation(fvectorDouble, rotator.ToUeRotator(), false, ref fhitResult, false);
		this.CameraActor.CameraComponent.SetFieldOfView(targetFov);
		this.InterpolationState.CurrentPos.DeepCopy(vector);
		this.InterpolationState.CurrentRot.DeepCopy(rotator);
		this.InterpolationState.CurrentFov = targetFov;
		Vector vector2 = Vector.Create();
		Rotator rotator2 = Rotator.Create();
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		if (currentSpeedLevelConfig == null)
		{
			return;
		}
		this.LastConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
		float targetFov2 = this.CalculateCameraTransform(shipLocation, shipRotation, currentSpeedLevelConfig, vector2, rotator2);
		this.PhaseState.StartPos.DeepCopy(vector);
		this.PhaseState.StartRot.DeepCopy(rotator);
		this.PhaseState.StartFov = targetFov;
		this.PhaseState.TargetPos.DeepCopy(vector2);
		this.PhaseState.TargetRot.DeepCopy(rotator2);
		this.PhaseState.TargetFov = targetFov2;
		this.PhaseState.PhaseType = ECameraPhaseType.StartPhase;
		this.PhaseState.Duration = duration;
		this.PhaseState.ElapsedTime = 0f;
		if (this.InterpolationState != null)
		{
			this.InterpolationState.IsInterpolating = false;
		}
	}

	// Token: 0x0600740C RID: 29708 RVA: 0x001E39E8 File Offset: 0x001E1BE8
	private void EnterEndPhase(FVectorDouble targetPos, FRotator targetRot, float targetFov, float duration)
	{
		if (this.PhaseState == null || this.InterpolationState == null)
		{
			return;
		}
		this.PhaseState.PerformancePos = targetPos;
		this.PhaseState.PerformanceRot = targetRot;
		this.PhaseState.PerformanceFov = targetFov;
		Rotator shipRotation = Rotator.Create(this.ShipController.GetShipRotation());
		Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
		Vector vector = Vector.Create();
		Rotator rotator = Rotator.Create();
		this.CalculateCameraTransform(shipLocation, shipRotation, new RhythmGameSpeedLevelConfig
		{
			Pos = targetPos,
			Rot = targetRot,
			Fov = targetFov
		}, vector, rotator);
		this.PhaseState.StartPos.DeepCopy(this.InterpolationState.CurrentPos);
		this.PhaseState.StartRot.DeepCopy(this.InterpolationState.CurrentRot);
		this.PhaseState.StartFov = this.InterpolationState.CurrentFov;
		this.PhaseState.TargetPos.DeepCopy(vector);
		this.PhaseState.TargetRot.DeepCopy(rotator);
		this.PhaseState.TargetFov = targetFov;
		this.PhaseState.PhaseType = ECameraPhaseType.EndPhase;
		this.PhaseState.Duration = duration;
		this.PhaseState.ElapsedTime = 0f;
		if (this.InterpolationState != null)
		{
			this.InterpolationState.IsInterpolating = false;
		}
	}

	// Token: 0x0600740D RID: 29709 RVA: 0x001E3B48 File Offset: 0x001E1D48
	private void ExitPhase()
	{
		if (this.PhaseState == null)
		{
			return;
		}
		this.PhaseState.PhaseType = ECameraPhaseType.Normal;
		this.PhaseState.ElapsedTime = 0f;
		this.LastConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRhythmGameStartNormalPhase);
	}

	// Token: 0x0600740E RID: 29710 RVA: 0x001E3B9C File Offset: 0x001E1D9C
	private void UpdatePhase(float deltaTime)
	{
		if (this.PhaseState == null)
		{
			return;
		}
		ECameraPhaseType phaseType = this.PhaseState.PhaseType;
		if (phaseType - ECameraPhaseType.StartPhase > 1)
		{
			if (phaseType == ECameraPhaseType.Free)
			{
				this.UpdateFreePhase(deltaTime);
				return;
			}
		}
		else
		{
			this.UpdatePerformancePhase(deltaTime);
		}
	}

	// Token: 0x0600740F RID: 29711 RVA: 0x001E3BD8 File Offset: 0x001E1DD8
	private void UpdatePerformancePhase(float deltaTime)
	{
		if (this.PhaseState == null)
		{
			return;
		}
		Rotator shipRotation = Rotator.Create(this.ShipController.GetShipRotation());
		Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
		Vector vector = Vector.Create();
		Rotator rotator = Rotator.Create();
		this.CalculateCameraTransform(shipLocation, shipRotation, new RhythmGameSpeedLevelConfig
		{
			Pos = this.PhaseState.PerformancePos,
			Rot = this.PhaseState.PerformanceRot,
			Fov = this.PhaseState.PerformanceFov
		}, vector, rotator);
		Vector vector2 = Vector.Create();
		Rotator rotator2 = Rotator.Create();
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		if (currentSpeedLevelConfig == null)
		{
			return;
		}
		float num = this.CalculateCameraTransform(shipLocation, shipRotation, currentSpeedLevelConfig, vector2, rotator2);
		if (this.PhaseState.PhaseType == ECameraPhaseType.StartPhase)
		{
			this.PhaseState.StartPos.DeepCopy(vector);
			this.PhaseState.StartRot.DeepCopy(rotator);
			this.PhaseState.StartFov = this.PhaseState.PerformanceFov;
			this.PhaseState.TargetPos.DeepCopy(vector2);
			this.PhaseState.TargetRot.DeepCopy(rotator2);
			this.PhaseState.TargetFov = num;
		}
		else if (this.PhaseState.PhaseType == ECameraPhaseType.EndPhase)
		{
			this.PhaseState.StartPos.DeepCopy(vector2);
			this.PhaseState.StartRot.DeepCopy(rotator2);
			this.PhaseState.StartFov = num;
			this.PhaseState.TargetPos.DeepCopy(vector);
			this.PhaseState.TargetRot.DeepCopy(rotator);
			this.PhaseState.TargetFov = this.PhaseState.PerformanceFov;
		}
		this.PhaseState.ElapsedTime += deltaTime;
		float num2 = Math.Min(this.PhaseState.ElapsedTime / this.PhaseState.Duration, 1f);
		Vector.Lerp(this.PhaseState.StartPos, this.PhaseState.TargetPos, (double)num2, this.InterpolationState.CurrentPos);
		Quat quat = this.PhaseState.StartRot.Quaternion(null);
		Quat quat2 = this.PhaseState.TargetRot.Quaternion(null);
		Quat quat3 = Quat.Create(0f, 0f, 0f, 1f);
		Quat.Slerp(quat, quat2, num2, quat3);
		quat3.Rotator(this.InterpolationState.CurrentRot);
		this.InterpolationState.CurrentFov = this.LerpFloat(this.PhaseState.StartFov, this.PhaseState.TargetFov, num2);
		if (num2 >= 1f)
		{
			if (this.PhaseState.PhaseType == ECameraPhaseType.StartPhase)
			{
				this.ExitPhase();
				return;
			}
			if (this.PhaseState.PhaseType == ECameraPhaseType.EndPhase)
			{
				this.PhaseState.ElapsedTime = this.PhaseState.Duration;
			}
		}
	}

	// Token: 0x06007410 RID: 29712 RVA: 0x001E3EBC File Offset: 0x001E20BC
	private void EnterFreePhase(IFreeCameraConfig config, float? interpDuration = null)
	{
		if (this.PhaseState == null || this.InterpolationState == null)
		{
			return;
		}
		this.PhaseState.PhaseType = ECameraPhaseType.Free;
		this.FreeState = new FreeCameraState
		{
			Config = config,
			Timer = 0f,
			LastDirection = 1,
			IsInterpolating = false,
			InterpolationElapsedTime = 0f,
			StartDirection = 1,
			TargetDirection = 1
		};
		Rotator rotator = Rotator.Create(this.ShipController.GetShipRotation());
		Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
		RhythmGameSpeedLevelConfig rhythmGameSpeedLevelConfig = new RhythmGameSpeedLevelConfig();
		rhythmGameSpeedLevelConfig.Pos = config.Pos;
		rhythmGameSpeedLevelConfig.Rot = config.Rot;
		rhythmGameSpeedLevelConfig.Fov = config.Fov;
		Vector vector = Vector.Create();
		Rotator rotator2 = Rotator.Create();
		this.CalculateCameraTransform(shipLocation, rotator, rhythmGameSpeedLevelConfig, vector, rotator2);
		Quat quat = rotator.Quaternion(null);
		Vector vector2 = Vector.Create(0.0, 1.0, 0.0);
		quat.RotateVector(vector2, vector2);
		Vector vector3 = Vector.Create(vector);
		Vector vector4 = Vector.Create(vector2);
		vector4.MultiplyEqual((double)config.Radius);
		vector3.AdditionEqual(vector4);
		Rotator rotator3 = Rotator.Create(rotator2);
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		if (currentSpeedLevelConfig != null)
		{
			this.StartInterpolation(vector3, rotator3, config.Fov, currentSpeedLevelConfig, interpDuration.GetValueOrDefault(0.5f));
		}
		this.PhaseState.StartPos.DeepCopy(vector3);
		this.PhaseState.StartRot.DeepCopy(rotator3);
		this.PhaseState.StartFov = config.Fov;
		this.PhaseState.TargetPos.DeepCopy(vector3);
		this.PhaseState.TargetRot.DeepCopy(rotator3);
		this.PhaseState.TargetFov = config.Fov;
		this.PhaseState.Duration = 0f;
		this.PhaseState.ElapsedTime = 0f;
	}

	// Token: 0x06007411 RID: 29713 RVA: 0x001E40C0 File Offset: 0x001E22C0
	private void ExitFreePhase(float interpDuration = 0.5f)
	{
		ICameraPhaseState phaseState = this.PhaseState;
		if (phaseState == null || phaseState.PhaseType != ECameraPhaseType.Free)
		{
			return;
		}
		if (this.PhaseState == null || this.InterpolationState == null)
		{
			return;
		}
		this.FreeState.IsExiting = new bool?(true);
		Vector vector = Vector.Create();
		Vector vector2 = vector;
		FVector fvector = this.CameraActor.K2_GetActorLocation();
		vector2.FromUeVector(fvector);
		Vector inB = Vector.Create(this.ShipController.GetShipPosition());
		Quat quat = Rotator.Create(this.ShipController.GetShipRotation()).Quaternion(null);
		Vector vector3 = Vector.Create();
		vector.Subtraction(inB, vector3);
		this.FreeState.ExitRelativePos = Vector.Create();
		quat.UnRotateVector(vector3, this.FreeState.ExitRelativePos);
		Quat inQ = Rotator.Create(this.CameraActor.K2_GetActorRotation()).Quaternion(null);
		Quat quat2 = Quat.Create(0f, 0f, 0f, 1f);
		quat.Inverse(quat2);
		Quat quat3 = Quat.Create(0f, 0f, 0f, 1f);
		quat2.Multiply(inQ, quat3);
		this.FreeState.ExitRelativeRot = Rotator.Create();
		quat3.Rotator(this.FreeState.ExitRelativeRot);
		int curSpeedLevelConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		this.FreeState.ExitFollowConfigIndex = new int?(curSpeedLevelConfigIndex);
		if (currentSpeedLevelConfig != null)
		{
			Rotator shipRotation = Rotator.Create(this.ShipController.GetShipRotation());
			Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
			Vector vector4 = Vector.Create();
			Rotator rotator = Rotator.Create();
			float targetFov = this.CalculateCameraTransform(shipLocation, shipRotation, currentSpeedLevelConfig, vector4, rotator);
			this.StartInterpolation(vector4, rotator, targetFov, currentSpeedLevelConfig, interpDuration);
			ControllerBase<RhythmGameController>.Instance.SetShipSpeed(currentSpeedLevelConfig.Speed);
		}
		this.LastConfigIndex = curSpeedLevelConfigIndex;
	}

	// Token: 0x06007412 RID: 29714 RVA: 0x001E42B8 File Offset: 0x001E24B8
	private void UpdateFreePhase(float deltaTime)
	{
		if (this.FreeState == null || this.InterpolationState == null)
		{
			return;
		}
		Rotator rotator = Rotator.Create(this.ShipController.GetShipRotation());
		Vector vector = Vector.Create(this.ShipController.GetShipPosition());
		if (this.InterpolationState.IsInterpolating)
		{
			if (this.FreeState.IsExiting.GetValueOrDefault())
			{
				int curSpeedLevelConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
				if (this.FreeState.ExitRelativePos != null && this.FreeState.ExitRelativeRot != null)
				{
					Vector vector2 = Vector.Create();
					Quat quat = rotator.Quaternion(null);
					quat.RotateVector(this.FreeState.ExitRelativePos, vector2);
					Vector vector3 = Vector.Create(vector);
					vector3.AdditionEqual(vector2);
					this.InterpolationState.StartPos.DeepCopy(vector3);
					Quat inQ = this.FreeState.ExitRelativeRot.Quaternion(null);
					Quat quat2 = Quat.Create(0f, 0f, 0f, 1f);
					quat.Multiply(inQ, quat2);
					quat2.Rotator(this.InterpolationState.StartRot);
				}
				RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
				if (currentSpeedLevelConfig != null)
				{
					int? exitFollowConfigIndex = this.FreeState.ExitFollowConfigIndex;
					int num = curSpeedLevelConfigIndex;
					if (!(exitFollowConfigIndex.GetValueOrDefault() == num & exitFollowConfigIndex != null))
					{
						this.FreeState.ExitFollowConfigIndex = new int?(curSpeedLevelConfigIndex);
						ControllerBase<RhythmGameController>.Instance.SetShipSpeed(currentSpeedLevelConfig.Speed);
						float interpolationDuration = Math.Max(0.01f, this.InterpolationState.InterpolationDuration - this.InterpolationState.ElapsedTime);
						this.InterpolationState.StartPos.DeepCopy(this.InterpolationState.CurrentPos);
						this.InterpolationState.StartRot.DeepCopy(this.InterpolationState.CurrentRot);
						this.InterpolationState.StartFov = this.InterpolationState.CurrentFov;
						this.InterpolationState.ElapsedTime = 0f;
						this.InterpolationState.InterpolationDuration = interpolationDuration;
						Vector vector4 = Vector.Create();
						FVector fvector = this.CameraActor.K2_GetActorLocation();
						vector4.FromUeVector(fvector);
						Vector vector5 = Vector.Create();
						vector4.Subtraction(vector, vector5);
						Quat quat3 = rotator.Quaternion(null);
						this.FreeState.ExitRelativePos = Vector.Create();
						quat3.UnRotateVector(vector5, this.FreeState.ExitRelativePos);
						Quat inQ2 = Rotator.Create(this.CameraActor.K2_GetActorRotation()).Quaternion(null);
						Quat quat4 = Quat.Create(0f, 0f, 0f, 1f);
						quat3.Inverse(quat4);
						Quat quat5 = Quat.Create(0f, 0f, 0f, 1f);
						quat4.Multiply(inQ2, quat5);
						this.FreeState.ExitRelativeRot = Rotator.Create();
						quat5.Rotator(this.FreeState.ExitRelativeRot);
					}
					Vector vector6 = Vector.Create();
					Rotator rotator2 = Rotator.Create();
					float targetFov = this.CalculateCameraTransform(vector, rotator, currentSpeedLevelConfig, vector6, rotator2);
					this.UpdateTargetValues(vector6, rotator2, targetFov);
					return;
				}
			}
			else
			{
				RhythmGameSpeedLevelConfig currentSpeedLevelConfig2 = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
				if (currentSpeedLevelConfig2 != null)
				{
					Vector vector7 = Vector.Create();
					Rotator rotator3 = Rotator.Create();
					this.CalculateCameraTransform(vector, rotator, currentSpeedLevelConfig2, vector7, rotator3);
					this.InterpolationState.StartPos.DeepCopy(vector7);
					this.InterpolationState.StartRot.DeepCopy(rotator3);
				}
				RhythmGameSpeedLevelConfig rhythmGameSpeedLevelConfig = new RhythmGameSpeedLevelConfig();
				rhythmGameSpeedLevelConfig.Pos = this.FreeState.Config.Pos;
				rhythmGameSpeedLevelConfig.Rot = this.FreeState.Config.Rot;
				rhythmGameSpeedLevelConfig.Fov = this.FreeState.Config.Fov;
				Vector vector8 = Vector.Create();
				Rotator rotator4 = Rotator.Create();
				this.CalculateCameraTransform(vector, rotator, rhythmGameSpeedLevelConfig, vector8, rotator4);
				Quat quat6 = rotator.Quaternion(null);
				Vector vector9 = Vector.Create(0.0, 1.0, 0.0);
				quat6.RotateVector(vector9, vector9);
				Vector vector10 = Vector.Create(vector8);
				Vector vector11 = Vector.Create(vector9);
				vector11.MultiplyEqual((double)this.FreeState.Config.Radius);
				vector10.AdditionEqual(vector11);
				Rotator targetRot = Rotator.Create(rotator4);
				this.UpdateTargetValues(vector10, targetRot, this.FreeState.Config.Fov);
			}
			return;
		}
		if (!this.FreeState.IsInterpolating)
		{
			this.FreeState.Timer += deltaTime;
			if (this.FreeState.Timer >= this.FreeState.Config.Interval)
			{
				this.FreeState.Timer = 0f;
				int num2 = -this.FreeState.LastDirection;
				this.FreeState.StartDirection = this.FreeState.LastDirection;
				this.FreeState.TargetDirection = num2;
				this.FreeState.LastDirection = num2;
				this.FreeState.IsInterpolating = true;
				this.FreeState.InterpolationElapsedTime = 0f;
			}
		}
		RhythmGameSpeedLevelConfig rhythmGameSpeedLevelConfig2 = new RhythmGameSpeedLevelConfig();
		rhythmGameSpeedLevelConfig2.Pos = this.FreeState.Config.Pos;
		rhythmGameSpeedLevelConfig2.Rot = this.FreeState.Config.Rot;
		rhythmGameSpeedLevelConfig2.Fov = this.FreeState.Config.Fov;
		Vector vector12 = Vector.Create();
		Rotator rotator5 = Rotator.Create();
		this.CalculateCameraTransform(vector, rotator, rhythmGameSpeedLevelConfig2, vector12, rotator5);
		Quat quat7 = rotator.Quaternion(null);
		Vector vector13 = Vector.Create(0.0, 1.0, 0.0);
		quat7.RotateVector(vector13, vector13);
		Vector vector14 = Vector.Create(vector12);
		Vector vector15 = Vector.Create(vector13);
		vector15.MultiplyEqual((double)((float)this.FreeState.StartDirection * this.FreeState.Config.Radius));
		vector14.AdditionEqual(vector15);
		Rotator rotator6 = Rotator.Create(rotator5);
		Vector vector16 = Vector.Create(vector12);
		Vector vector17 = Vector.Create(vector13);
		vector17.MultiplyEqual((double)((float)this.FreeState.TargetDirection * this.FreeState.Config.Radius));
		vector16.AdditionEqual(vector17);
		Rotator rotator7 = Rotator.Create(rotator5);
		if (this.FreeState.IsInterpolating)
		{
			this.FreeState.InterpolationElapsedTime += deltaTime;
			float num3 = Math.Min(this.FreeState.InterpolationElapsedTime / this.FreeState.Config.InterpDuration, 1f);
			Vector.Lerp(vector14, vector16, (double)num3, this.InterpolationState.CurrentPos);
			Quat quat8 = rotator6.Quaternion(null);
			Quat quat9 = rotator7.Quaternion(null);
			Quat quat10 = Quat.Create(0f, 0f, 0f, 1f);
			Quat.Slerp(quat8, quat9, num3, quat10);
			quat10.Rotator(this.InterpolationState.CurrentRot);
			this.InterpolationState.CurrentFov = this.LerpFloat(this.FreeState.Config.Fov, this.FreeState.Config.Fov, num3);
			if (num3 >= 1f)
			{
				this.FreeState.IsInterpolating = false;
				this.FreeState.InterpolationElapsedTime = 0f;
				this.FreeState.StartDirection = this.FreeState.TargetDirection;
				return;
			}
		}
		else
		{
			this.FreeState.StartDirection = this.FreeState.LastDirection;
			this.InterpolationState.CurrentPos.DeepCopy(vector16);
			this.InterpolationState.CurrentRot.DeepCopy(rotator7);
			this.InterpolationState.CurrentFov = this.FreeState.Config.Fov;
		}
	}

	// Token: 0x06007413 RID: 29715 RVA: 0x001E4A70 File Offset: 0x001E2C70
	private float CalculateCameraTransform(Vector shipLocation, Rotator shipRotation, RhythmGameSpeedLevelConfig config, Vector outPos, Rotator outRot)
	{
		Quat quat = shipRotation.Quaternion(null);
		Vector vector = Vector.Create(config.Pos);
		quat.RotateVector(vector, vector);
		shipLocation.Addition(vector, outPos);
		Quat inQ = Rotator.Create(config.Rot).Quaternion(null);
		Quat quat2 = Quat.Create(0f, 0f, 0f, 1f);
		quat.Multiply(inQ, quat2);
		quat2.Rotator(outRot);
		return config.Fov;
	}

	// Token: 0x06007414 RID: 29716 RVA: 0x001E4AF0 File Offset: 0x001E2CF0
	public void Update(float deltaTime)
	{
		if (ControllerBase<RhythmGameController>.Instance.GetIsPause())
		{
			return;
		}
		Rotator shipRotation = Rotator.Create(this.ShipController.GetShipRotation());
		Vector shipLocation = Vector.Create(this.ShipController.GetShipPosition());
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		if (currentSpeedLevelConfig == null)
		{
			return;
		}
		if (this.InterpolationState == null || this.PhaseState == null)
		{
			return;
		}
		ECameraPhaseType phaseType = this.PhaseState.PhaseType;
		if (this.PhaseState.PhaseType != ECameraPhaseType.Normal)
		{
			this.UpdatePhase(deltaTime);
			this.UpdateInterpolation(deltaTime);
		}
		if (this.PhaseState.PhaseType == ECameraPhaseType.Normal && phaseType == ECameraPhaseType.Normal)
		{
			Vector vector = Vector.Create();
			Rotator rotator = Rotator.Create();
			float num = this.CalculateCameraTransform(shipLocation, shipRotation, currentSpeedLevelConfig, vector, rotator);
			int curSpeedLevelConfigIndex = ModelBase<RhythmGameModel>.Instance.CurSpeedLevelConfigIndex;
			if (curSpeedLevelConfigIndex != this.LastConfigIndex)
			{
				RhythmGameSpeedLevelConfig speedLevelConfigByIndex = ModelBase<RhythmGameModel>.Instance.GetSpeedLevelConfigByIndex(this.LastConfigIndex);
				this.LastConfigIndex = curSpeedLevelConfigIndex;
				if (speedLevelConfigByIndex != null)
				{
					this.StartInterpolation(vector, rotator, num, speedLevelConfigByIndex, 1f);
				}
				ControllerBase<RhythmGameController>.Instance.SetShipSpeed(currentSpeedLevelConfig.Speed);
			}
			if (this.InterpolationState.IsInterpolating && this.InterpolationState.PrevConfig != null)
			{
				Vector vector2 = Vector.Create();
				Rotator rotator2 = Rotator.Create();
				this.CalculateCameraTransform(shipLocation, shipRotation, this.InterpolationState.PrevConfig, vector2, rotator2);
				this.InterpolationState.StartPos.DeepCopy(vector2);
				this.InterpolationState.StartRot.DeepCopy(rotator2);
				this.UpdateTargetValues(vector, rotator, num);
				this.UpdateInterpolation(deltaTime);
			}
			else if (!this.InterpolationState.IsInterpolating)
			{
				this.InterpolationState.CurrentPos.DeepCopy(vector);
				this.InterpolationState.CurrentRot.DeepCopy(rotator);
				this.InterpolationState.CurrentFov = num;
			}
		}
		FHitResult fhitResult = new FHitResult();
		AActor cameraActor = this.CameraActor;
		FVectorDouble fvectorDouble = this.InterpolationState.CurrentPos.ToUeVector(false);
		cameraActor.K2_SetActorLocationAndRotation(fvectorDouble, this.InterpolationState.CurrentRot.ToUeRotator(), false, ref fhitResult, false);
		this.CameraActor.CameraComponent.SetFieldOfView(this.InterpolationState.CurrentFov);
	}

	// Token: 0x06007415 RID: 29717 RVA: 0x001E4D2C File Offset: 0x001E2F2C
	private void OnRhythmGameStartPhase(RhythmGamePerformanceCameraConfig config)
	{
		if (config.Time > 0.02f)
		{
			this.EnterStartPhase(config.TargetLoc, config.TargetRot, config.Fov, config.Time);
		}
	}

	// Token: 0x06007416 RID: 29718 RVA: 0x001E4D59 File Offset: 0x001E2F59
	private void OnRhythmGameEndPhase(RhythmGamePerformanceCameraConfig config)
	{
		if (config.Time > 0.02f)
		{
			this.EnterEndPhase(config.TargetLoc, config.TargetRot, config.Fov, config.Time);
		}
	}

	// Token: 0x06007417 RID: 29719 RVA: 0x001E4D88 File Offset: 0x001E2F88
	private void OnRhythmGameFreePhase(bool isEnter)
	{
		RhythmGameFreeFlyCameraConfig freeFlyCameraConfig = ModelBase<RhythmGameModel>.Instance.RhythmGameConfig.FreeFlyCameraConfig;
		RhythmGameSpeedLevelConfig currentSpeedLevelConfig = ModelBase<RhythmGameModel>.Instance.GetCurrentSpeedLevelConfig();
		if (freeFlyCameraConfig == null || currentSpeedLevelConfig == null)
		{
			return;
		}
		FreeCameraConfig config = new FreeCameraConfig
		{
			Pos = freeFlyCameraConfig.TargetLoc,
			Rot = freeFlyCameraConfig.TargetRot,
			Fov = currentSpeedLevelConfig.Fov,
			Radius = freeFlyCameraConfig.Radius,
			Interval = freeFlyCameraConfig.ChangeInterval,
			InterpDuration = freeFlyCameraConfig.InterpDuration
		};
		if (isEnter)
		{
			this.EnterFreePhase(config, new float?(freeFlyCameraConfig.EnterTime));
			return;
		}
		this.ExitFreePhase(freeFlyCameraConfig.ExitTime);
	}

	// Token: 0x06007418 RID: 29720 RVA: 0x001E4E34 File Offset: 0x001E3034
	public void OnDestroy()
	{
		if (this.CameraActor != null && this.CameraActor.IsValid())
		{
			UKuroGameBudgetAllocatorCSharpInterface.RemoveAssistantActor(this.CameraActor);
		}
		this.CameraActor = null;
		this.InterpolationState = null;
		this.FreeState = null;
		Singleton<EventSystem>.Instance.Remove<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameStartPhase, new Action<RhythmGamePerformanceCameraConfig>(this.OnRhythmGameStartPhase));
		Singleton<EventSystem>.Instance.Remove<RhythmGamePerformanceCameraConfig>(EEventName.OnRhythmGameEndPhase, new Action<RhythmGamePerformanceCameraConfig>(this.OnRhythmGameEndPhase));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnRhythmGameFreePhase, new Action<bool>(this.OnRhythmGameFreePhase));
	}

	// Token: 0x040037E1 RID: 14305
	private const float CameraInterpolationDuration = 1f;

	// Token: 0x040037E2 RID: 14306
	[Nullable(2)]
	private ACameraActor CameraActor;

	// Token: 0x040037E3 RID: 14307
	[Nullable(2)]
	private ICameraInterpolationState InterpolationState;

	// Token: 0x040037E4 RID: 14308
	[Nullable(2)]
	private ICameraPhaseState PhaseState;

	// Token: 0x040037E5 RID: 14309
	[Nullable(2)]
	private IFreeCameraState FreeState;

	// Token: 0x040037E6 RID: 14310
	private int LastConfigIndex = -1;

	// Token: 0x040037E7 RID: 14311
	[Nullable(2)]
	private UKuroRhythmGameShipController ShipController;
}
