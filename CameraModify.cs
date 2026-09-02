using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02000E2D RID: 3629
[NullableContext(2)]
[Nullable(0)]
public class CameraModify
{
	// Token: 0x060055B3 RID: 21939 RVA: 0x000E1A78 File Offset: 0x000DFC78
	[NullableContext(1)]
	public CameraModify(SCameraModifier_Settings cameraModify)
	{
		this.Name = cameraModify.ModifySettingsAdditional.Name;
		this.ArmLength = cameraModify.ArmLength;
		this.ArmLengthAdditional = cameraModify.ArmLengthAdditional;
		this.ArmRotation = Rotator.Create(cameraModify.ArmRotation);
		this.ArmRotationAdditional = Rotator.Create(cameraModify.ArmRotationAdditional);
		this.CameraFov = cameraModify.CameraFov;
		this.CameraOffset = Vector.Create(cameraModify.CameraOffset);
		this.CameraOffsetAdditional = Vector.Create(cameraModify.CameraOffsetAdditional);
		this.IsLockInput = cameraModify.IsLockInput;
		this.IsModifiedArmLength = cameraModify.IsModifiedArmLength;
		this.IsModifiedArmRotation = cameraModify.IsModifiedArmRotation;
		this.IsModifiedArmRotationPitch = cameraModify.IsModifiedArmRotationPitch;
		this.IsModifiedArmRotationRoll = cameraModify.IsModifiedArmRotationRoll;
		this.IsModifiedArmRotationYaw = cameraModify.IsModifiedArmRotationYaw;
		this.IsModifiedCameraFov = cameraModify.IsModifiedCameraFov;
		this.IsModifiedCameraOffset = cameraModify.IsModifiedCameraOffset;
		this.IsModifiedCameraOffsetX = cameraModify.IsModifiedCameraOffsetX;
		this.IsModifiedCameraOffsetY = cameraModify.IsModifiedCameraOffsetY;
		this.IsModifiedCameraOffsetZ = cameraModify.IsModifiedCameraOffsetZ;
		this.IsModifiedCameraLens = cameraModify.ModifySettingsAdditional.IsModifiedCameraLens;
		this.OverrideCameraInput = cameraModify.OverrideCameraInput;
		this.ResetFinalArmLength = cameraModify.ResetFinalArmLength;
		this.IsResetFinalArmLengthToSpecificValue = cameraModify.IsResetFinalArmLengthToSpecificValue;
		this.ResetFinalArmLengthToSpecificValue = cameraModify.ResetFinalArmLengthToSpecificValue;
		this.IsResetFinalArmLengthToDynamicValue = cameraModify.IsResetFinalArmLengthToDynamicValue;
		this.ResetFinalArmLengthToDynamicValueList.Clear();
		for (int i = 0; i < cameraModify.ResetFinalArmLengthToDynamicValue.Num(); i++)
		{
			this.ResetFinalArmLengthToDynamicValueList.Add(new ResetFinalArmLengthToDynamicValueData(cameraModify.ResetFinalArmLengthToDynamicValue.Get(i)));
		}
		this.ResetFinalArmRotation = cameraModify.ResetFinalArmRotation;
		this.IsResetFinalArmRotationToSpecificPitch = cameraModify.IsResetFinalArmRotationToSpecificPitch;
		this.ResetFinalArmRotationToSpecificPitch = cameraModify.ResetFinalArmRotationToSpecificPitch;
		this.IsResetFinalArmRotationToSpecificYaw = cameraModify.IsResetFinalArmRotationToSpecificYaw;
		this.ResetFinalArmRotationToSpecificYaw = cameraModify.ResetFinalArmRotationToSpecificYaw;
		this.StopModifyOnMontageEnd = cameraModify.StopModifyOnMontageEnd;
		this.StopModifyOnZoomInput = cameraModify.StopModifyOnZoomInput;
		this.IsLerpArmLocation = cameraModify.IsLerpArmLocation;
		this.IsSwitchModifier = cameraModify.IsSwitchModifier;
		this.IsUseArmLengthFloatCurve = cameraModify.ModifySettingsAdditional.IsUseArmLengthFloatCurve;
		if (this.IsUseArmLengthFloatCurve)
		{
			this.ArmLengthFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.ArmLengthFloatCurve);
		}
		this.IsUseArmRotationFloatCurve = cameraModify.ModifySettingsAdditional.IsUseArmRotationFloatCurve;
		if (this.IsUseArmRotationFloatCurve)
		{
			this.ArmRotationFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.ArmRotationFloatCurve);
		}
		this.IsUseFovFloatCurve = cameraModify.ModifySettingsAdditional.IsUseFovFloatCurve;
		if (this.IsUseFovFloatCurve)
		{
			this.FovFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.FovFloatCurve);
		}
		this.IsUseLensFloatCurve = cameraModify.ModifySettingsAdditional.IsUseLensFloatCurve;
		if (this.IsUseLensFloatCurve)
		{
			this.LensFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.LensFloatCurve);
		}
		this.CameraLens = cameraModify.ModifySettingsAdditional.CameraLens;
		this.IsForcePlayModify = cameraModify.IsForcePlayModify;
		this.IsUseCameraOffsetFloatCurve = cameraModify.ModifySettingsAdditional.IsUseCameraOffsetFloatCurve;
		if (this.IsUseCameraOffsetFloatCurve)
		{
			this.CameraOffsetFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.CameraOffsetFloatCurve);
		}
		this.IsModifiedArmOffset = cameraModify.ModifySettingsAdditional.IsModifiedArmOffset;
		Vector armOffset = this.ArmOffset;
		FVector armOffset2 = cameraModify.ModifySettingsAdditional.ArmOffset;
		FVectorDouble fvectorDouble = armOffset2;
		armOffset.DeepCopy(fvectorDouble);
		this.IsUseArmOffsetFloatCurve = cameraModify.ModifySettingsAdditional.IsUseArmOffsetFloatCurve;
		if (this.IsUseArmOffsetFloatCurve)
		{
			this.ArmOffsetFloatCurve = CurveUtils.CreateCurveByStruct(cameraModify.ModifySettingsAdditional.ArmOffsetFloatCurve);
		}
		if (cameraModify.ArmRotationType == ECameraModifyParamType.曲线 && cameraModify.ArmRotationCurve != null)
		{
			this.ArmRotationPitchEval = new CurveFloatEvaluator(cameraModify.ArmRotationCurve, "Y");
			this.ArmRotationYawEval = new CurveFloatEvaluator(cameraModify.ArmRotationCurve, "Z");
			this.ArmRotationRollEval = new CurveFloatEvaluator(cameraModify.ArmRotationCurve, "X");
		}
		else
		{
			this.ArmRotationPitchEval = new ConstEvaluator(cameraModify.ArmRotation.Pitch);
			this.ArmRotationYawEval = new ConstEvaluator(cameraModify.ArmRotation.Yaw);
			this.ArmRotationRollEval = new ConstEvaluator(cameraModify.ArmRotation.Roll);
		}
		if (cameraModify.ArmRotationAdditionalType == ECameraModifyParamType.曲线 && cameraModify.ArmRotationAdditionalCurve != null)
		{
			this.ArmRotationAdditionalPitchEval = new CurveFloatEvaluator(cameraModify.ArmRotationAdditionalCurve, "Y");
			this.ArmRotationAdditionalYawEval = new CurveFloatEvaluator(cameraModify.ArmRotationAdditionalCurve, "Z");
			this.ArmRotationAdditionalRollEval = new CurveFloatEvaluator(cameraModify.ArmRotationAdditionalCurve, "X");
		}
		else
		{
			this.ArmRotationAdditionalPitchEval = new ConstEvaluator(cameraModify.ArmRotationAdditional.Pitch);
			this.ArmRotationAdditionalYawEval = new ConstEvaluator(cameraModify.ArmRotationAdditional.Yaw);
			this.ArmRotationAdditionalRollEval = new ConstEvaluator(cameraModify.ArmRotationAdditional.Roll);
		}
		if (cameraModify.CameraOffsetType == ECameraModifyParamType.曲线 && cameraModify.CameraOffsetCurve != null)
		{
			this.CameraOffsetEval = new CurveVectorEvaluator(cameraModify.CameraOffsetCurve);
		}
		else
		{
			this.CameraOffsetEval = new ConstVectorEvaluator(cameraModify.CameraOffset);
		}
		if (cameraModify.CameraOffsetAdditionalType == ECameraModifyParamType.曲线 && cameraModify.CameraOffsetAdditionalCurve != null)
		{
			this.CameraOffsetAdditionalEval = new CurveVectorEvaluator(cameraModify.CameraOffsetAdditionalCurve);
			return;
		}
		this.CameraOffsetAdditionalEval = new ConstVectorEvaluator(cameraModify.CameraOffsetAdditional);
	}

	// Token: 0x04001B21 RID: 6945
	[Nullable(1)]
	public string Name;

	// Token: 0x04001B22 RID: 6946
	public float ArmLength;

	// Token: 0x04001B23 RID: 6947
	public float ArmLengthAdditional;

	// Token: 0x04001B24 RID: 6948
	[Nullable(1)]
	public Rotator ArmRotation;

	// Token: 0x04001B25 RID: 6949
	[Nullable(1)]
	public Rotator ArmRotationAdditional;

	// Token: 0x04001B26 RID: 6950
	public float CameraFov;

	// Token: 0x04001B27 RID: 6951
	[Nullable(1)]
	public Vector CameraOffset;

	// Token: 0x04001B28 RID: 6952
	[Nullable(1)]
	public Vector CameraOffsetAdditional;

	// Token: 0x04001B29 RID: 6953
	public bool IsLockInput;

	// Token: 0x04001B2A RID: 6954
	public bool IsModifiedArmLength;

	// Token: 0x04001B2B RID: 6955
	public bool IsModifiedArmRotation;

	// Token: 0x04001B2C RID: 6956
	public bool IsModifiedArmRotationPitch;

	// Token: 0x04001B2D RID: 6957
	public bool IsModifiedArmRotationRoll;

	// Token: 0x04001B2E RID: 6958
	public bool IsModifiedArmRotationYaw;

	// Token: 0x04001B2F RID: 6959
	public bool IsModifiedCameraFov;

	// Token: 0x04001B30 RID: 6960
	public bool IsModifiedCameraOffset;

	// Token: 0x04001B31 RID: 6961
	public bool IsModifiedCameraOffsetX;

	// Token: 0x04001B32 RID: 6962
	public bool IsModifiedCameraOffsetY;

	// Token: 0x04001B33 RID: 6963
	public bool IsModifiedCameraOffsetZ;

	// Token: 0x04001B34 RID: 6964
	public bool IsModifiedCameraLens;

	// Token: 0x04001B35 RID: 6965
	public bool OverrideCameraInput;

	// Token: 0x04001B36 RID: 6966
	public bool ResetFinalArmLength;

	// Token: 0x04001B37 RID: 6967
	public bool IsResetFinalArmLengthToSpecificValue;

	// Token: 0x04001B38 RID: 6968
	public float ResetFinalArmLengthToSpecificValue;

	// Token: 0x04001B39 RID: 6969
	public bool IsResetFinalArmLengthToDynamicValue;

	// Token: 0x04001B3A RID: 6970
	[Nullable(1)]
	public List<ResetFinalArmLengthToDynamicValueData> ResetFinalArmLengthToDynamicValueList = new List<ResetFinalArmLengthToDynamicValueData>();

	// Token: 0x04001B3B RID: 6971
	public bool ResetFinalArmRotation;

	// Token: 0x04001B3C RID: 6972
	public bool IsResetFinalArmRotationToSpecificPitch;

	// Token: 0x04001B3D RID: 6973
	public float ResetFinalArmRotationToSpecificPitch;

	// Token: 0x04001B3E RID: 6974
	public bool IsResetFinalArmRotationToSpecificYaw;

	// Token: 0x04001B3F RID: 6975
	public float ResetFinalArmRotationToSpecificYaw;

	// Token: 0x04001B40 RID: 6976
	public bool StopModifyOnMontageEnd;

	// Token: 0x04001B41 RID: 6977
	public bool StopModifyOnZoomInput;

	// Token: 0x04001B42 RID: 6978
	public bool IsLerpArmLocation;

	// Token: 0x04001B43 RID: 6979
	public bool IsSwitchModifier;

	// Token: 0x04001B44 RID: 6980
	public bool IsUseArmLengthFloatCurve;

	// Token: 0x04001B45 RID: 6981
	public CurveBase ArmLengthFloatCurve;

	// Token: 0x04001B46 RID: 6982
	public bool IsUseArmRotationFloatCurve;

	// Token: 0x04001B47 RID: 6983
	public CurveBase ArmRotationFloatCurve;

	// Token: 0x04001B48 RID: 6984
	public bool IsUseFovFloatCurve;

	// Token: 0x04001B49 RID: 6985
	public CurveBase FovFloatCurve;

	// Token: 0x04001B4A RID: 6986
	public bool IsUseLensFloatCurve;

	// Token: 0x04001B4B RID: 6987
	public CurveBase LensFloatCurve;

	// Token: 0x04001B4C RID: 6988
	public SCameraModifier_Lens CameraLens;

	// Token: 0x04001B4D RID: 6989
	public bool IsForcePlayModify;

	// Token: 0x04001B4E RID: 6990
	public bool IsUseCameraOffsetFloatCurve;

	// Token: 0x04001B4F RID: 6991
	public CurveBase CameraOffsetFloatCurve;

	// Token: 0x04001B50 RID: 6992
	public bool IsModifiedArmOffset;

	// Token: 0x04001B51 RID: 6993
	[Nullable(1)]
	public Vector ArmOffset = Vector.Create();

	// Token: 0x04001B52 RID: 6994
	public bool IsUseArmOffsetFloatCurve;

	// Token: 0x04001B53 RID: 6995
	public CurveBase ArmOffsetFloatCurve;

	// Token: 0x04001B54 RID: 6996
	public IModifyParamEvaluator ArmRotationPitchEval;

	// Token: 0x04001B55 RID: 6997
	public IModifyParamEvaluator ArmRotationYawEval;

	// Token: 0x04001B56 RID: 6998
	public IModifyParamEvaluator ArmRotationRollEval;

	// Token: 0x04001B57 RID: 6999
	public IModifyParamEvaluator ArmRotationAdditionalPitchEval;

	// Token: 0x04001B58 RID: 7000
	public IModifyParamEvaluator ArmRotationAdditionalYawEval;

	// Token: 0x04001B59 RID: 7001
	public IModifyParamEvaluator ArmRotationAdditionalRollEval;

	// Token: 0x04001B5A RID: 7002
	public IVectorParamEvaluator CameraOffsetEval;

	// Token: 0x04001B5B RID: 7003
	public IVectorParamEvaluator CameraOffsetAdditionalEval;
}
