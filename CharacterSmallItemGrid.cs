using System;

// Token: 0x02001A4C RID: 6732
public class CharacterSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FC9 RID: 4041
	// (get) Token: 0x0600C09A RID: 49306 RVA: 0x0032D579 File Offset: 0x0032B779
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.Character;
		}
	}

	// Token: 0x04005A2F RID: 23087
	public int? ElementId;

	// Token: 0x04005A30 RID: 23088
	public bool? IsLockVisible;

	// Token: 0x04005A31 RID: 23089
	public bool? IsReceivableVisible;

	// Token: 0x04005A32 RID: 23090
	public bool? IsReceivedVisible;

	// Token: 0x04005A33 RID: 23091
	public bool? IsSelectedFlag;

	// Token: 0x04005A34 RID: 23092
	public bool? IsCookUp;

	// Token: 0x04005A35 RID: 23093
	public bool? IsBlack;
}
