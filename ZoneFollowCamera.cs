using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.ZoneFollowCamera;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Camera.FightCameraController.SpecialGameplay;
using UnrealEngine;

// Token: 0x02000E34 RID: 3636
[NullableContext(1)]
[Nullable(0)]
public class ZoneFollowCamera : ISpecialGameplayCamera
{
	// Token: 0x06005637 RID: 22071 RVA: 0x000EC639 File Offset: 0x000EA839
	public void OnInit(ACameraActor camera, CameraModelInstance cameraModel)
	{
		this.CameraActor = camera;
		FightCamera fightCamera = cameraModel.FightCamera;
		this.FightCameraLogicComp = ((fightCamera != null) ? fightCamera.LogicComponent : null);
	}

	// Token: 0x06005638 RID: 22072 RVA: 0x000EC65C File Offset: 0x000EA85C
	public void Update(float deltaTime)
	{
		ACameraActor cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid() || !this.IsSettingsValid)
		{
			return;
		}
		Vector currentPlayerPosition = this.GetCurrentPlayerPosition();
		if (this.HasLastPlayerPosition && Vector.Distance(currentPlayerPosition, this.LastPlayerPosition) < 0.0001)
		{
			this.LerpCameraToTarget(deltaTime);
			return;
		}
		this.LastPlayerPosition.DeepCopy(currentPlayerPosition);
		this.HasLastPlayerPosition = true;
		this.UpdateTargetCameraPositionAndRotation(currentPlayerPosition);
		this.LerpCameraToTarget(deltaTime);
	}

	// Token: 0x06005639 RID: 22073 RVA: 0x000EC6D8 File Offset: 0x000EA8D8
	public void OnDestroy()
	{
		this.IsSettingsValid = false;
		this.HasLastPlayerPosition = false;
		this.UseExternalPlayerPosition = false;
		this.ExternalPlayerPosition.Set(0.0, 0.0, 0.0);
		this.ZoneIndexListCache.Clear();
		this.DistanceListCache.Clear();
		this.CachedZoneConfigs.Clear();
		this.CameraActor = null;
		this.FightCameraLogicComp = null;
		this.TargetFov = null;
		this.CurrentFov = null;
	}

	// Token: 0x0600563A RID: 22074 RVA: 0x000EC768 File Offset: 0x000EA968
	public void SetCameraSettings(SZoneFollowCameraSettings settings)
	{
		this.LerpSpeed = settings.LerpSpeed;
		Vector defaultCameraOffset = this.DefaultCameraOffset;
		FVector fvector = settings.DefaultCameraOffset;
		defaultCameraOffset.FromUeVector(fvector);
		Rotator defaultCameraRotation = this.DefaultCameraRotation;
		FRotator frotator = settings.DefaultCameraRotation;
		defaultCameraRotation.FromUeRotator(frotator);
		if (this.TargetFov == null)
		{
			this.CurrentFov = new float?(settings.CameraFov);
		}
		this.TargetFov = new float?(settings.CameraFov);
		int num = settings.ZoneConfigs.Num();
		while (this.CachedZoneConfigs.Count < num)
		{
			this.CachedZoneConfigs.Add(new ZoneSnapshot());
		}
		if (this.CachedZoneConfigs.Count > num)
		{
			this.CachedZoneConfigs.RemoveRange(num, this.CachedZoneConfigs.Count - num);
		}
		for (int i = 0; i < num; i++)
		{
			SZoneFollowCameraZoneSetting szoneFollowCameraZoneSetting = settings.ZoneConfigs.Get(i);
			ZoneSnapshot zoneSnapshot = this.CachedZoneConfigs[i];
			Vector centerPosition = zoneSnapshot.CenterPosition;
			fvector = szoneFollowCameraZoneSetting.CenterPosition;
			centerPosition.FromUeVector(fvector);
			Vector cameraOffset = zoneSnapshot.CameraOffset;
			fvector = szoneFollowCameraZoneSetting.CameraOffset;
			cameraOffset.FromUeVector(fvector);
			Vector cameraOffsetAlpha = zoneSnapshot.CameraOffsetAlpha;
			fvector = szoneFollowCameraZoneSetting.CameraOffsetAlpha;
			cameraOffsetAlpha.FromUeVector(fvector);
			Rotator cameraRotation = zoneSnapshot.CameraRotation;
			frotator = szoneFollowCameraZoneSetting.CameraRotation;
			cameraRotation.FromUeRotator(frotator);
			zoneSnapshot.HasBox = true;
			Transform boxTransform = zoneSnapshot.BoxTransform;
			FTransform boxTransform2 = szoneFollowCameraZoneSetting.BoxTransform;
			boxTransform.FromUeTransform(boxTransform2);
			Vector boxExtend = zoneSnapshot.BoxExtend;
			fvector = szoneFollowCameraZoneSetting.BoxExtend;
			boxExtend.FromUeVector(fvector);
		}
		this.IsSettingsValid = true;
		this.HasLastPlayerPosition = false;
	}

	// Token: 0x0600563B RID: 22075 RVA: 0x000EC8F4 File Offset: 0x000EAAF4
	public void ApplyInitialTransform()
	{
		ACameraActor cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		Vector currentPlayerPosition = this.GetCurrentPlayerPosition();
		if (this.IsSettingsValid)
		{
			this.UpdateTargetCameraPositionAndRotation(currentPlayerPosition);
		}
		else
		{
			currentPlayerPosition.Addition(this.DefaultCameraOffset, this.TargetCameraPosition);
			this.TargetCameraRotation.DeepCopy(this.DefaultCameraRotation);
		}
		this.LastPlayerPosition.DeepCopy(currentPlayerPosition);
		this.HasLastPlayerPosition = true;
		this.CameraActor.D_K2_SetActorLocationAndRotation(this.TargetCameraPosition.ToUeVector(false), this.TargetCameraRotation.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, false);
		this.CameraActor.CameraComponent.SetFieldOfView(this.TargetFov.GetValueOrDefault(90f));
		this.CurrentFov = new float?(this.TargetFov.GetValueOrDefault(90f));
		if (this.TargetFov == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Camera;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "ApplyInitialTransform";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(" TargetFov is undefined, using default FOV", 90);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x0600563C RID: 22076 RVA: 0x000ECA07 File Offset: 0x000EAC07
	public void UpdateExternalPlayerPosition(Vector position)
	{
		this.ExternalPlayerPosition.DeepCopy(position);
	}

	// Token: 0x0600563D RID: 22077 RVA: 0x000ECA15 File Offset: 0x000EAC15
	public void EnableExternalPlayerPosition(bool isUseExternal)
	{
		if (this.UseExternalPlayerPosition == isUseExternal)
		{
			return;
		}
		this.HasLastPlayerPosition = false;
		if (isUseExternal && this.FightCameraLogicComp != null)
		{
			this.ExternalPlayerPosition.DeepCopy(this.FightCameraLogicComp.PlayerLocation);
		}
		this.UseExternalPlayerPosition = isUseExternal;
	}

	// Token: 0x0600563E RID: 22078 RVA: 0x000ECA50 File Offset: 0x000EAC50
	private Vector GetCurrentPlayerPosition()
	{
		if (this.UseExternalPlayerPosition)
		{
			return this.ExternalPlayerPosition;
		}
		return this.FightCameraLogicComp.PlayerLocation;
	}

	// Token: 0x0600563F RID: 22079 RVA: 0x000ECA6C File Offset: 0x000EAC6C
	private void LerpCameraToTarget(float deltaTime)
	{
		ACameraActor cameraActor = this.CameraActor;
		if (cameraActor == null || !cameraActor.IsValid())
		{
			return;
		}
		Vector curPositionCache = this.CurPositionCache;
		FVectorDouble fvectorDouble = this.CameraActor.D_K2_GetActorLocation();
		curPositionCache.FromUeVector(fvectorDouble);
		Rotator curRotationCache = this.CurRotationCache;
		FRotator frotator = this.CameraActor.K2_GetActorRotation();
		curRotationCache.FromUeRotator(frotator);
		Singleton<MathUtils>.Instance.VectorInterpTo(this.CurPositionCache, this.TargetCameraPosition, (double)deltaTime, (double)this.LerpSpeed, this.TempVec1);
		Singleton<MathUtils>.Instance.RotatorInterpTo(this.CurRotationCache, this.TargetCameraRotation, (double)deltaTime, (double)this.LerpSpeed, this.TempRot0);
		this.CameraActor.D_K2_SetActorLocation(this.TempVec1.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
		this.CameraActor.K2_SetActorRotation(this.TempRot0.ToUeRotator(), false);
		if (this.TargetFov != null && this.CurrentFov != null)
		{
			this.CurrentFov = new float?((float)Singleton<MathUtils>.Instance.InterpTo((double)this.CurrentFov.Value, (double)this.TargetFov.Value, (double)deltaTime, (double)this.LerpSpeed));
			this.CameraActor.CameraComponent.SetFieldOfView(this.CurrentFov.Value);
		}
	}

	// Token: 0x06005640 RID: 22080 RVA: 0x000ECBB0 File Offset: 0x000EADB0
	private void FindActorInZone(Vector curPosition)
	{
		this.ZoneIndexListCache.Clear();
		for (int i = 0; i < this.CachedZoneConfigs.Count; i++)
		{
			ZoneSnapshot zoneSnapshot = this.CachedZoneConfigs[i];
			if (zoneSnapshot.HasBox && this.IsPointInBoxWithTransform(curPosition, zoneSnapshot.BoxTransform, zoneSnapshot.BoxExtend))
			{
				this.ZoneIndexListCache.Add(i);
			}
		}
	}

	// Token: 0x06005641 RID: 22081 RVA: 0x000ECC14 File Offset: 0x000EAE14
	private bool IsPointInBoxWithTransform(Vector point, Transform boxWorldTransform, Vector boxExtent)
	{
		boxWorldTransform.InverseTransformPosition(point, this.TempVec2);
		return Math.Abs(this.TempVec2.X) <= Math.Abs(boxExtent.X) && Math.Abs(this.TempVec2.Y) <= Math.Abs(boxExtent.Y) && Math.Abs(this.TempVec2.Z) <= Math.Abs(boxExtent.Z);
	}

	// Token: 0x06005642 RID: 22082 RVA: 0x000ECC8C File Offset: 0x000EAE8C
	private void UpdateTargetCameraPositionAndRotation(Vector curPosition)
	{
		this.FindActorInZone(curPosition);
		int count = this.ZoneIndexListCache.Count;
		if (count == 0)
		{
			this.UpdateTargetPositionFromPlayerPosition(curPosition);
			return;
		}
		this.DistanceListCache.Clear();
		float num = 0f;
		for (int i = 0; i < count; i++)
		{
			ZoneSnapshot zoneSnapshot = this.CachedZoneConfigs[this.ZoneIndexListCache[i]];
			float num2 = (float)(1.0 / (Vector.Distance(curPosition, zoneSnapshot.CenterPosition) + 1E-08));
			num += num2;
			this.DistanceListCache.Add(num2);
		}
		this.TargetCameraPosition.Set(0.0, 0.0, 0.0);
		float num3 = 0f;
		for (int j = 0; j < count; j++)
		{
			float num4 = this.DistanceListCache[j] / num;
			ZoneSnapshot zoneSnapshot2 = this.CachedZoneConfigs[this.ZoneIndexListCache[j]];
			curPosition.Subtraction(zoneSnapshot2.CenterPosition, this.TempVec1);
			this.TempVec1.Multiply(zoneSnapshot2.CameraOffsetAlpha, this.TempVec1);
			zoneSnapshot2.CenterPosition.Addition(zoneSnapshot2.CameraOffset, this.TempVec3);
			this.TempVec3.Addition(this.TempVec1, this.TempVec1);
			this.TempVec1.Multiply((double)num4, this.TempVec0);
			this.TargetCameraPosition.AdditionEqual(this.TempVec0);
			num3 += num4;
			if (j == 0)
			{
				this.TargetCameraRotation.DeepCopy(zoneSnapshot2.CameraRotation);
			}
			else
			{
				Rotator.Lerp(this.TargetCameraRotation, zoneSnapshot2.CameraRotation, num4 / num3, this.TempRot0);
				this.TargetCameraRotation.DeepCopy(this.TempRot0);
			}
		}
	}

	// Token: 0x06005643 RID: 22083 RVA: 0x000ECE60 File Offset: 0x000EB060
	private void UpdateTargetPositionFromPlayerPosition(Vector playerPosition)
	{
		playerPosition.Addition(this.DefaultCameraOffset, this.TargetCameraPosition);
		this.TargetCameraRotation.DeepCopy(this.DefaultCameraRotation);
	}

	// Token: 0x04001BF3 RID: 7155
	[Nullable(2)]
	private ACameraActor CameraActor;

	// Token: 0x04001BF4 RID: 7156
	[Nullable(2)]
	private FightCameraLogicComponent FightCameraLogicComp;

	// Token: 0x04001BF5 RID: 7157
	private bool IsSettingsValid;

	// Token: 0x04001BF6 RID: 7158
	private float LerpSpeed;

	// Token: 0x04001BF7 RID: 7159
	private readonly Vector DefaultCameraOffset = Vector.Create();

	// Token: 0x04001BF8 RID: 7160
	private readonly Rotator DefaultCameraRotation = Rotator.Create();

	// Token: 0x04001BF9 RID: 7161
	private readonly List<ZoneSnapshot> CachedZoneConfigs = new List<ZoneSnapshot>();

	// Token: 0x04001BFA RID: 7162
	private float? TargetFov;

	// Token: 0x04001BFB RID: 7163
	private float? CurrentFov;

	// Token: 0x04001BFC RID: 7164
	private readonly Vector TargetCameraPosition = Vector.Create();

	// Token: 0x04001BFD RID: 7165
	private readonly Rotator TargetCameraRotation = Rotator.Create();

	// Token: 0x04001BFE RID: 7166
	private readonly Vector TempVec0 = Vector.Create();

	// Token: 0x04001BFF RID: 7167
	private readonly Vector TempVec1 = Vector.Create();

	// Token: 0x04001C00 RID: 7168
	private readonly Vector TempVec2 = Vector.Create();

	// Token: 0x04001C01 RID: 7169
	private readonly Vector TempVec3 = Vector.Create();

	// Token: 0x04001C02 RID: 7170
	private readonly Rotator TempRot0 = Rotator.Create();

	// Token: 0x04001C03 RID: 7171
	private readonly Vector CurPositionCache = Vector.Create();

	// Token: 0x04001C04 RID: 7172
	private readonly Rotator CurRotationCache = Rotator.Create();

	// Token: 0x04001C05 RID: 7173
	private readonly List<int> ZoneIndexListCache = new List<int>();

	// Token: 0x04001C06 RID: 7174
	private readonly List<float> DistanceListCache = new List<float>();

	// Token: 0x04001C07 RID: 7175
	private readonly Vector LastPlayerPosition = Vector.Create();

	// Token: 0x04001C08 RID: 7176
	private bool HasLastPlayerPosition;

	// Token: 0x04001C09 RID: 7177
	private readonly Vector ExternalPlayerPosition = Vector.Create();

	// Token: 0x04001C0A RID: 7178
	private bool UseExternalPlayerPosition;
}
