using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Input;
using UnrealEngine;

// Token: 0x0200259E RID: 9630
public class FightCameraHandler : PhotoCameraHandler
{
	// Token: 0x06012C44 RID: 76868 RVA: 0x0052D640 File Offset: 0x0052B840
	[NullableContext(1)]
	public void Init(ACameraActor cameraActor)
	{
		UCameraComponent cameraComponent = cameraActor.CameraComponent;
		this.CameraInitializeFovInner = cameraComponent.FieldOfView;
		this.SourceMaxPitch = ConfigCommonParamById.GetIntConfig("CameraSourceMaxPitch").Value;
		this.SourceMinPitch = ConfigCommonParamById.GetIntConfig("CameraSourceMinPitch").Value;
		this.MinFov = ConfigCommonParamById.GetIntConfig("CaptureCollectCameraMinFov").Value;
		this.MaxFov = ConfigCommonParamById.GetIntConfig("CaptureCollectCameraMaxFov").Value;
	}

	// Token: 0x06012C45 RID: 76869 RVA: 0x0052D6C0 File Offset: 0x0052B8C0
	public override void Clear()
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.DesiredCamera.Fov = this.CameraInitializeFovInner;
		this.ClearInput();
	}

	// Token: 0x06012C46 RID: 76870 RVA: 0x0052D6EC File Offset: 0x0052B8EC
	public override float GetCameraInitializeFov()
	{
		return this.CameraInitializeFovInner;
	}

	// Token: 0x06012C47 RID: 76871 RVA: 0x0052D6F4 File Offset: 0x0052B8F4
	public override void SetFov(float fov)
	{
		float fov2 = Singleton<MathUtils>.Instance.Clamp(fov, (float)this.MinFov, (float)this.MaxFov);
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.DesiredCamera.Fov = fov2;
	}

	// Token: 0x06012C48 RID: 76872 RVA: 0x0052D73C File Offset: 0x0052B93C
	public override void AddPitchInput(float pitch)
	{
		if (pitch == 0f)
		{
			return;
		}
		float pitch2 = ControllerBase<CameraController>.Instance.GetMainPlayerCameraManager().GetCameraRotation().Pitch;
		if (pitch > 0f && pitch2 >= (float)this.SourceMaxPitch)
		{
			return;
		}
		if (pitch < 0f && pitch2 <= (float)this.SourceMinPitch)
		{
			return;
		}
		this.PitchInput = pitch;
	}

	// Token: 0x06012C49 RID: 76873 RVA: 0x0052D794 File Offset: 0x0052B994
	public override void AddYawInput(float yaw)
	{
		if (yaw == 0f)
		{
			return;
		}
		this.YawInput = yaw;
	}

	// Token: 0x06012C4A RID: 76874 RVA: 0x0052D7A8 File Offset: 0x0052B9A8
	public override void ApplyCameraDelta()
	{
		if (this.PitchInput == 0f && this.YawInput == 0f)
		{
			return;
		}
		if (Global.BaseCharacter == null)
		{
			return;
		}
		Entity entityNoBlueprint = Global.BaseCharacter.GetEntityNoBlueprint();
		CharacterInputComponent characterInputComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterInputComponent>() : null;
		if (characterInputComponent != null)
		{
			characterInputComponent.HandleInputAxis(EInputAxis.LookUp, -this.PitchInput);
			characterInputComponent.HandleInputAxis(EInputAxis.Turn, this.YawInput);
		}
		this.PitchInput = 0f;
		this.YawInput = 0f;
	}

	// Token: 0x06012C4B RID: 76875 RVA: 0x0052D82C File Offset: 0x0052BA2C
	public override void ClearInput()
	{
		this.PitchInput = 0f;
		this.YawInput = 0f;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterInputComponent characterInputComponent;
		if (baseCharacter == null)
		{
			characterInputComponent = null;
		}
		else
		{
			Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
			characterInputComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterInputComponent>() : null);
		}
		CharacterInputComponent characterInputComponent2 = characterInputComponent;
		if (characterInputComponent2 != null)
		{
			characterInputComponent2.ClearSingleAxisInput(EInputAxis.LookUp, false);
			characterInputComponent2.ClearSingleAxisInput(EInputAxis.Turn, false);
		}
	}

	// Token: 0x0400927E RID: 37502
	private float CameraInitializeFovInner;

	// Token: 0x0400927F RID: 37503
	private int MinFov = 60;

	// Token: 0x04009280 RID: 37504
	private int MaxFov = 90;

	// Token: 0x04009281 RID: 37505
	private float PitchInput;

	// Token: 0x04009282 RID: 37506
	private float YawInput;

	// Token: 0x04009283 RID: 37507
	private int SourceMaxPitch;

	// Token: 0x04009284 RID: 37508
	private int SourceMinPitch;
}
