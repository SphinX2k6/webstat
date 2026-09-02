using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

// Token: 0x02001D94 RID: 7572
[NullableContext(1)]
[Nullable(0)]
public class TrapDefensePlayerMarkView : TrapDefenseMarkView
{
	// Token: 0x0600DF26 RID: 57126 RVA: 0x003C0A0C File Offset: 0x003BEC0C
	public TrapDefensePlayerMarkView(int markId, UUISprite playerSight) : base(markId)
	{
		this.PlayerSight = playerSight;
		this.NeedUpdatePositionInner = true;
	}

	// Token: 0x0600DF27 RID: 57127 RVA: 0x003C0A62 File Offset: 0x003BEC62
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DF28 RID: 57128 RVA: 0x003C0A88 File Offset: 0x003BEC88
	public override void UpdatePosition(float scale, Vector2D centerOffset)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || !getCurrentEntity.Valid)
		{
			return;
		}
		CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return;
		}
		TrapDefenseMarkItem markData = base.GetMarkData();
		if (markData == null)
		{
			return;
		}
		Vector uiPosition = markData.UiPosition;
		Vector2D vector2D = Vector2D.Create(uiPosition.X, uiPosition.Y);
		Vector2D vector2D2 = Vector2D.Create();
		vector2D.Multiply((double)scale, vector2D2).Subtraction(centerOffset, vector2D2);
		Vector2D value = vector2D2;
		UUIItem[] relativeItems = new UUISprite[]
		{
			this.PlayerSight
		};
		base.SetAnchorOffset(value, relativeItems);
		UUIItem item = base.GetItem(0);
		float num = -(component.ActorRotationProxy.Yaw + 90f);
		if (Math.Abs(this.TempPlayerRotator.Yaw - num) > 10f)
		{
			this.TempPlayerRotator.Yaw = num;
			item.SetUIRelativeRotation(this.TempPlayerRotator);
		}
		float desiredYaw = -(ModelBase<CameraModel>.Instance.MainModel.CameraRotator.Yaw + 90f);
		this.TempSightRotator.Yaw = this.ClampCameraYaw(desiredYaw);
		this.PlayerSight.SetUIRelativeRotation(this.TempSightRotator);
	}

	// Token: 0x0600DF29 RID: 57129 RVA: 0x003C0BAC File Offset: 0x003BEDAC
	private float ClampCameraYaw(float desiredYaw)
	{
		ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
		ECustomCameraMode ecustomCameraMode = ECustomCameraMode.LockOn;
		if ((cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null) && ModelBase<CameraModel>.Instance.MainModel.FightCamera != null && ModelBase<CameraModel>.Instance.MainModel.FightCamera.LogicComponent != null)
		{
			VirtualCamera currentCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera.LogicComponent.CurrentCamera;
			float yawLimitMin = currentCamera.YawLimitMin;
			float num = (currentCamera.YawLimitMax - yawLimitMin) % 360f;
			if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, 360.0, null))
			{
				return Singleton<MathUtils>.Instance.Clamp(Singleton<MathUtils>.Instance.WrapAngle(desiredYaw), currentCamera.WorldYawMin, currentCamera.WorldYawMax);
			}
		}
		return desiredYaw;
	}

	// Token: 0x04006B4F RID: 27471
	private const float PLAYER_ROTATE_UPDATE_THRESHOLD = 10f;

	// Token: 0x04006B50 RID: 27472
	private FRotator TempSightRotator = new FRotator(0f, 0f, 0f);

	// Token: 0x04006B51 RID: 27473
	private FRotator TempPlayerRotator = new FRotator(0f, 0f, 0f);

	// Token: 0x04006B52 RID: 27474
	private readonly UUISprite PlayerSight;

	// Token: 0x02008129 RID: 33065
	[NullableContext(0)]
	private static class EChildComponentType
	{
		// Token: 0x0402BE80 RID: 179840
		public const int PlayerItem = 0;
	}
}
