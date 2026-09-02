using System;

// Token: 0x020022A4 RID: 8868
public class MotorLevelAttrData : IMotorLevelAttrData
{
	// Token: 0x170014A3 RID: 5283
	// (get) Token: 0x06010C38 RID: 68664 RVA: 0x00497E4D File Offset: 0x0049604D
	// (set) Token: 0x06010C39 RID: 68665 RVA: 0x00497E55 File Offset: 0x00496055
	public int AttrId { get; set; }

	// Token: 0x170014A4 RID: 5284
	// (get) Token: 0x06010C3A RID: 68666 RVA: 0x00497E5E File Offset: 0x0049605E
	// (set) Token: 0x06010C3B RID: 68667 RVA: 0x00497E66 File Offset: 0x00496066
	public int Level { get; set; }

	// Token: 0x170014A5 RID: 5285
	// (get) Token: 0x06010C3C RID: 68668 RVA: 0x00497E6F File Offset: 0x0049606F
	// (set) Token: 0x06010C3D RID: 68669 RVA: 0x00497E77 File Offset: 0x00496077
	public bool IsShowBg { get; set; }

	// Token: 0x170014A6 RID: 5286
	// (get) Token: 0x06010C3E RID: 68670 RVA: 0x00497E80 File Offset: 0x00496080
	// (set) Token: 0x06010C3F RID: 68671 RVA: 0x00497E88 File Offset: 0x00496088
	public bool IsSpecial { get; set; }
}
