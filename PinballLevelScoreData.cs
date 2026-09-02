using System;

// Token: 0x020014A9 RID: 5289
public class PinballLevelScoreData : IPinballLevelScoreData
{
	// Token: 0x17000C58 RID: 3160
	// (get) Token: 0x06009435 RID: 37941 RVA: 0x0027042A File Offset: 0x0026E62A
	// (set) Token: 0x06009436 RID: 37942 RVA: 0x00270432 File Offset: 0x0026E632
	public int CurScore { get; set; }

	// Token: 0x17000C59 RID: 3161
	// (get) Token: 0x06009437 RID: 37943 RVA: 0x0027043B File Offset: 0x0026E63B
	// (set) Token: 0x06009438 RID: 37944 RVA: 0x00270443 File Offset: 0x0026E643
	public int ConfigScore { get; set; }

	// Token: 0x17000C5A RID: 3162
	// (get) Token: 0x06009439 RID: 37945 RVA: 0x0027044C File Offset: 0x0026E64C
	// (set) Token: 0x0600943A RID: 37946 RVA: 0x00270454 File Offset: 0x0026E654
	public int ConfigDropId { get; set; }
}
