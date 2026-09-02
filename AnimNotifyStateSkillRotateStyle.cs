using System;

// Token: 0x02003110 RID: 12560
public class AnimNotifyStateSkillRotateStyle
{
	// Token: 0x06019F8D RID: 106381 RVA: 0x0079A359 File Offset: 0x00798559
	public void Reset()
	{
		this.IsUseAnsRotateOffset = false;
		this.AnsRotateOffset = 0f;
		this.PauseRotateThreshold = 0f;
		this.ResumeRotateThreshold = 0f;
		this.IsPaused = false;
	}

	// Token: 0x0400D04D RID: 53325
	public bool IsUseAnsRotateOffset;

	// Token: 0x0400D04E RID: 53326
	public float AnsRotateOffset;

	// Token: 0x0400D04F RID: 53327
	public float PauseRotateThreshold;

	// Token: 0x0400D050 RID: 53328
	public float ResumeRotateThreshold;

	// Token: 0x0400D051 RID: 53329
	public bool IsPaused;
}
