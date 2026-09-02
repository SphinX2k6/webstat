using System;

// Token: 0x020022A3 RID: 8867
public interface IMotorLevelAttrData
{
	// Token: 0x1700149F RID: 5279
	// (get) Token: 0x06010C30 RID: 68656
	// (set) Token: 0x06010C31 RID: 68657
	int AttrId { get; set; }

	// Token: 0x170014A0 RID: 5280
	// (get) Token: 0x06010C32 RID: 68658
	// (set) Token: 0x06010C33 RID: 68659
	int Level { get; set; }

	// Token: 0x170014A1 RID: 5281
	// (get) Token: 0x06010C34 RID: 68660
	// (set) Token: 0x06010C35 RID: 68661
	bool IsShowBg { get; set; }

	// Token: 0x170014A2 RID: 5282
	// (get) Token: 0x06010C36 RID: 68662
	// (set) Token: 0x06010C37 RID: 68663
	bool IsSpecial { get; set; }
}
