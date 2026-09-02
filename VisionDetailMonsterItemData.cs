using System;

// Token: 0x0200248E RID: 9358
public class VisionDetailMonsterItemData
{
	// Token: 0x0601229B RID: 74395 RVA: 0x004FEF19 File Offset: 0x004FD119
	public VisionDetailMonsterItemData(int monsterId = 0, int qualityId = 0, int roleId = 0)
	{
		this.MonsterId = monsterId;
		this.QualityId = qualityId;
		this.RoleId = roleId;
	}

	// Token: 0x04008DC2 RID: 36290
	public int MonsterId;

	// Token: 0x04008DC3 RID: 36291
	public int QualityId;

	// Token: 0x04008DC4 RID: 36292
	public int RoleId;
}
