using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E2A RID: 3626
[NullableContext(1)]
[Nullable(0)]
public class CameraBlendOutData
{
	// Token: 0x060055AA RID: 21930 RVA: 0x000E199D File Offset: 0x000DFB9D
	public void Reset()
	{
		this.IsInitializedArmRotationPitch = false;
		this.IsInitializedArmRotationYaw = false;
		this.IsInitializedArmRotationRoll = false;
		this.IsInitializedCameraOffset = false;
	}

	// Token: 0x060055AB RID: 21931 RVA: 0x000E19BB File Offset: 0x000DFBBB
	public void SetBlendOutArmRotationPitch(float pitch)
	{
		if (!this.IsInitializedArmRotationPitch)
		{
			this.ArmRotationPitch = pitch;
			this.IsInitializedArmRotationPitch = true;
		}
	}

	// Token: 0x060055AC RID: 21932 RVA: 0x000E19D3 File Offset: 0x000DFBD3
	public void SetBlendOutArmRotationYaw(float yaw)
	{
		if (!this.IsInitializedArmRotationYaw)
		{
			this.ArmRotationYaw = yaw;
			this.IsInitializedArmRotationYaw = true;
		}
	}

	// Token: 0x060055AD RID: 21933 RVA: 0x000E19EB File Offset: 0x000DFBEB
	public void SetBlendOutArmRotationRoll(float roll)
	{
		if (!this.IsInitializedArmRotationRoll)
		{
			this.ArmRotationRoll = roll;
			this.IsInitializedArmRotationRoll = true;
		}
	}

	// Token: 0x060055AE RID: 21934 RVA: 0x000E1A03 File Offset: 0x000DFC03
	public void SetBlendOutCameraOffset(Vector offset)
	{
		if (!this.IsInitializedCameraOffset)
		{
			this.CameraOffset.DeepCopy(offset);
			this.IsInitializedCameraOffset = true;
		}
	}

	// Token: 0x04001B14 RID: 6932
	public bool IsInitializedArmRotationPitch;

	// Token: 0x04001B15 RID: 6933
	public float ArmRotationPitch;

	// Token: 0x04001B16 RID: 6934
	public bool IsInitializedArmRotationYaw;

	// Token: 0x04001B17 RID: 6935
	public float ArmRotationYaw;

	// Token: 0x04001B18 RID: 6936
	public bool IsInitializedArmRotationRoll;

	// Token: 0x04001B19 RID: 6937
	public float ArmRotationRoll;

	// Token: 0x04001B1A RID: 6938
	public bool IsInitializedCameraOffset;

	// Token: 0x04001B1B RID: 6939
	public Vector CameraOffset = Vector.Create();
}
