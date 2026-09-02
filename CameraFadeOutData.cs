using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E29 RID: 3625
[NullableContext(1)]
[Nullable(0)]
public class CameraFadeOutData
{
	// Token: 0x04001AF5 RID: 6901
	public bool ModifyArmLength;

	// Token: 0x04001AF6 RID: 6902
	public float StartArmLength;

	// Token: 0x04001AF7 RID: 6903
	public float ArmLength;

	// Token: 0x04001AF8 RID: 6904
	public bool ModifyArmOffset;

	// Token: 0x04001AF9 RID: 6905
	public Vector StartArmOffset = Vector.Create();

	// Token: 0x04001AFA RID: 6906
	public Vector ArmOffset = Vector.Create();

	// Token: 0x04001AFB RID: 6907
	public bool ModifyCameraOffset;

	// Token: 0x04001AFC RID: 6908
	public Vector StartCameraOffset = Vector.Create();

	// Token: 0x04001AFD RID: 6909
	public Vector CameraOffset = Vector.Create();

	// Token: 0x04001AFE RID: 6910
	public bool ModifyZoomModifier;

	// Token: 0x04001AFF RID: 6911
	public float StartFinalArmLength;

	// Token: 0x04001B00 RID: 6912
	public float FinalArmLength;

	// Token: 0x04001B01 RID: 6913
	public bool ModifyFov;

	// Token: 0x04001B02 RID: 6914
	public float StartFov;

	// Token: 0x04001B03 RID: 6915
	public float Fov;

	// Token: 0x04001B04 RID: 6916
	public bool ModifyArmRotationPitch;

	// Token: 0x04001B05 RID: 6917
	public bool ModifyArmRotationYaw;

	// Token: 0x04001B06 RID: 6918
	public bool ModifyArmRotationRoll;

	// Token: 0x04001B07 RID: 6919
	public float StartArmRotationPitch;

	// Token: 0x04001B08 RID: 6920
	public float StartArmRotationYaw;

	// Token: 0x04001B09 RID: 6921
	public float StartArmRotationRoll;

	// Token: 0x04001B0A RID: 6922
	public float ArmRotationPitch;

	// Token: 0x04001B0B RID: 6923
	public float ArmRotationYaw;

	// Token: 0x04001B0C RID: 6924
	public float ArmRotationRoll;

	// Token: 0x04001B0D RID: 6925
	public bool ModifyPlayerLocation;

	// Token: 0x04001B0E RID: 6926
	public Vector StartPlayerLocation = Vector.Create();

	// Token: 0x04001B0F RID: 6927
	public Vector PlayerLocation = Vector.Create();

	// Token: 0x04001B10 RID: 6928
	public float ElapsedTime;

	// Token: 0x04001B11 RID: 6929
	public float FadeOutTotalTime;

	// Token: 0x04001B12 RID: 6930
	public bool UseFadeOutTimeLerp;

	// Token: 0x04001B13 RID: 6931
	[Nullable(2)]
	public CurveBase BlendOutCurve;
}
