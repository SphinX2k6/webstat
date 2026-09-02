using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF5 RID: 27637
	public class LevelEventSetupSeqCamera : LevelEventBase
	{
		// Token: 0x0604410B RID: 278795 RVA: 0x011AB861 File Offset: 0x011A9A61
		public LevelEventSetupSeqCamera(int id) : base(id)
		{
		}

		// Token: 0x0604410C RID: 278796 RVA: 0x011AB86C File Offset: 0x011A9A6C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				return;
			}
			ECustomCameraMode? cameraMode = ModelBase<CameraModel>.Instance.MainModel.CameraMode;
			ECustomCameraMode ecustomCameraMode = ECustomCameraMode.Sequence;
			if (!(cameraMode.GetValueOrDefault() == ecustomCameraMode & cameraMode != null))
			{
				return;
			}
			ActionSetSeqCameraTransform actionSetSeqCameraTransform = inParams as ActionSetSeqCameraTransform;
			BP_CineCamera_C cineCamera = ControllerBase<CameraController>.Instance.MainModel.SequenceCamera.GetComponent<SequenceCameraDisplayComponent>().CineCamera;
			UCineCameraComponent ucineCameraComponent = cineCamera.CameraComponent as UCineCameraComponent;
			if (!ObjectUtils.IsValid(cineCamera))
			{
				return;
			}
			AActor actor = cineCamera;
			FTransformDouble ftransformDouble = actionSetSeqCameraTransform.Transform.ToUeTransform();
			actor.D_K2_SetActorTransform(ftransformDouble, false, null, false);
			if (actionSetSeqCameraTransform.Aperture != null)
			{
				ucineCameraComponent.CurrentAperture = actionSetSeqCameraTransform.Aperture.Value;
			}
			if (actionSetSeqCameraTransform.FocalLength != null)
			{
				ucineCameraComponent.CurrentFocalLength = actionSetSeqCameraTransform.FocalLength.Value;
			}
			if (actionSetSeqCameraTransform.FocusDistance != null)
			{
				ucineCameraComponent.FocusSettings.ManualFocusDistance = actionSetSeqCameraTransform.FocusDistance.Value;
			}
		}
	}
}
