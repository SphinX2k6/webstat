using System;

// Token: 0x0200259D RID: 9629
public class PhotoCameraHandler
{
	// Token: 0x06012C3C RID: 76860 RVA: 0x0052D624 File Offset: 0x0052B824
	public virtual void Clear()
	{
	}

	// Token: 0x06012C3D RID: 76861 RVA: 0x0052D626 File Offset: 0x0052B826
	public virtual void AddPitchInput(float pitch)
	{
	}

	// Token: 0x06012C3E RID: 76862 RVA: 0x0052D628 File Offset: 0x0052B828
	public virtual void AddYawInput(float yaw)
	{
	}

	// Token: 0x06012C3F RID: 76863 RVA: 0x0052D62A File Offset: 0x0052B82A
	public virtual void ApplyCameraDelta()
	{
	}

	// Token: 0x06012C40 RID: 76864 RVA: 0x0052D62C File Offset: 0x0052B82C
	public virtual void SetFov(float fov)
	{
	}

	// Token: 0x06012C41 RID: 76865 RVA: 0x0052D62E File Offset: 0x0052B82E
	public virtual float GetCameraInitializeFov()
	{
		return 0f;
	}

	// Token: 0x06012C42 RID: 76866 RVA: 0x0052D635 File Offset: 0x0052B835
	public virtual void ClearInput()
	{
	}
}
