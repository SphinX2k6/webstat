using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002C4D RID: 11341
[NullableContext(2)]
[Nullable(0)]
public class UiCameraPhotographerStructure : UiCameraStructure
{
	// Token: 0x06016B93 RID: 93075 RVA: 0x0064EC34 File Offset: 0x0064CE34
	protected override AActor OnSpawnStructureActor()
	{
		FQuat fquat = new FQuat(0f, 0f, 0f, 0f);
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
		FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
		FVector fvector = fvectorDouble2;
		FTransformDouble transform = new FTransformDouble(ref fquat, ref fvectorDouble, ref fvector);
		this.Photographer = Singleton<ActorSystem>.Instance.Get<TsPhotographer>(TsPhotographer.StaticClass(), transform, null, true);
		this.Photographer.SetTickableWhenPaused(true);
		this.Photographer.SetActorTickEnabled(true);
		this.Photographer.Initialize();
		this.Photographer.CameraArm.SetTickableWhenPaused(true);
		return this.Photographer;
	}

	// Token: 0x06016B94 RID: 93076 RVA: 0x0064ED04 File Offset: 0x0064CF04
	protected override USpringArmComponent OnSetSpringArmComponent()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return null;
		}
		return photographer.CameraArm;
	}

	// Token: 0x06016B95 RID: 93077 RVA: 0x0064ED17 File Offset: 0x0064CF17
	protected override void OnDestroy()
	{
		this.DestroyPhotographer();
	}

	// Token: 0x06016B96 RID: 93078 RVA: 0x0064ED20 File Offset: 0x0064CF20
	protected override void OnActivate()
	{
		AActor fightCameraActor = this.GetFightCameraActor();
		FightCameraLogicComponent fightCameraLogicComponent = this.GetFightCameraLogicComponent();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		fightCameraLogicComponent.SetIsDitherEffectEnable(false);
		baseCharacter.SetDitherEffect(1f, ECharacterDitherType.Fight);
		FVectorDouble playerSourceLocation = baseCharacter.Mesh.D_GetSocketLocation(PhotographDefine.SPAWN_SOCKET_NAME);
		FTransformDouble cameraInitializeTransform = fightCameraActor.D_GetTransform();
		this.Photographer.SetPlayerSourceLocation(playerSourceLocation);
		this.Photographer.SetCameraInitializeTransform(cameraInitializeTransform);
		this.Photographer.ActivateCamera(this.CameraActor);
	}

	// Token: 0x06016B97 RID: 93079 RVA: 0x0064ED91 File Offset: 0x0064CF91
	protected override void OnDeactivate()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.DeactivateCamera();
	}

	// Token: 0x06016B98 RID: 93080 RVA: 0x0064EDA3 File Offset: 0x0064CFA3
	private void DestroyPhotographer()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer != null && photographer.IsValid())
		{
			this.Photographer.DeactivateCamera();
			Singleton<ActorSystem>.Instance.Put("UiCameraPhotographerStructure.DestroyPhotographer", this.Photographer, null);
		}
		this.Photographer = null;
	}

	// Token: 0x06016B99 RID: 93081 RVA: 0x0064EDE4 File Offset: 0x0064CFE4
	private FightCameraLogicComponent GetFightCameraLogicComponent()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return null;
		}
		return fightCamera.GetComponent<FightCameraLogicComponent>();
	}

	// Token: 0x06016B9A RID: 93082 RVA: 0x0064EE0C File Offset: 0x0064D00C
	private ACameraActor GetFightCameraActor()
	{
		FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
		if (fightCamera == null)
		{
			return null;
		}
		FightCameraDisplayComponent component = fightCamera.GetComponent<FightCameraDisplayComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		return component.CameraActor;
	}

	// Token: 0x06016B9B RID: 93083 RVA: 0x0064EE4E File Offset: 0x0064D04E
	public void SetPlayerSourceLocation(FVectorDouble location)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetPlayerSourceLocation(location);
	}

	// Token: 0x06016B9C RID: 93084 RVA: 0x0064EE61 File Offset: 0x0064D061
	public void SetCameraInitializeTransform(FTransformDouble transform)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraInitializeTransform(transform);
	}

	// Token: 0x06016B9D RID: 93085 RVA: 0x0064EE74 File Offset: 0x0064D074
	public FTransformDouble GetCameraInitializeTransform()
	{
		return this.Photographer.GetCameraInitializeTransform();
	}

	// Token: 0x06016B9E RID: 93086 RVA: 0x0064EE81 File Offset: 0x0064D081
	public void SetCameraInitializeFov(int fov)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraInitializeFov((float)fov);
	}

	// Token: 0x06016B9F RID: 93087 RVA: 0x0064EE95 File Offset: 0x0064D095
	public float GetCameraInitialFov()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return 0f;
		}
		return photographer.GetCameraInitializeFov();
	}

	// Token: 0x06016BA0 RID: 93088 RVA: 0x0064EEAC File Offset: 0x0064D0AC
	public void SetCameraTransform(FTransform transform)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraTransform(transform);
	}

	// Token: 0x06016BA1 RID: 93089 RVA: 0x0064EEBF File Offset: 0x0064D0BF
	public void MoveUp(float addValue)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.MoveUp(addValue);
	}

	// Token: 0x06016BA2 RID: 93090 RVA: 0x0064EED2 File Offset: 0x0064D0D2
	public void MoveRight(float addValue)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.MoveRight(addValue);
	}

	// Token: 0x06016BA3 RID: 93091 RVA: 0x0064EEE5 File Offset: 0x0064D0E5
	public void MoveForward(float addValue)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.MoveForward(addValue);
	}

	// Token: 0x06016BA4 RID: 93092 RVA: 0x0064EEF8 File Offset: 0x0064D0F8
	public void AddCameraArmPitchInput(float pitch)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.AddCameraArmPitchInput(pitch);
	}

	// Token: 0x06016BA5 RID: 93093 RVA: 0x0064EF0B File Offset: 0x0064D10B
	public void AddCameraArmYawInput(float yaw)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.AddCameraArmYawInput(yaw);
	}

	// Token: 0x06016BA6 RID: 93094 RVA: 0x0064EF1E File Offset: 0x0064D11E
	public void SetCameraArmRoll(float roll)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraArmRoll(roll);
	}

	// Token: 0x06016BA7 RID: 93095 RVA: 0x0064EF31 File Offset: 0x0064D131
	public void SetFov(int fov)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetFov((float)fov);
	}

	// Token: 0x06016BA8 RID: 93096 RVA: 0x0064EF45 File Offset: 0x0064D145
	public float GetFov()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return 0f;
		}
		return photographer.GetFov();
	}

	// Token: 0x06016BA9 RID: 93097 RVA: 0x0064EF5C File Offset: 0x0064D15C
	public void ResetCamera()
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.ResetCamera();
	}

	// Token: 0x06016BAA RID: 93098 RVA: 0x0064EF6E File Offset: 0x0064D16E
	public void SetCameraArmTargetOffset(FVectorDouble cameraLocation, bool isInit = false)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraArmTargetOffset(cameraLocation, isInit);
	}

	// Token: 0x06016BAB RID: 93099 RVA: 0x0064EF82 File Offset: 0x0064D182
	[NullableContext(1)]
	public void SetCameraLUT(string texturePath)
	{
		TsPhotographer photographer = this.Photographer;
		if (photographer == null)
		{
			return;
		}
		photographer.SetCameraLUT(texturePath);
	}

	// Token: 0x0400AF3E RID: 44862
	private TsPhotographer Photographer;
}
