using System;

// Token: 0x02001A50 RID: 6736
public class CharacterOrnamentSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FCD RID: 4045
	// (get) Token: 0x0600C0A2 RID: 49314 RVA: 0x0032D5A5 File Offset: 0x0032B7A5
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.CharacterOrnament;
		}
	}

	// Token: 0x04005A49 RID: 23113
	public bool? IsLockVisibleBlack;

	// Token: 0x04005A4A RID: 23114
	public bool? IsReceivableVisible;

	// Token: 0x04005A4B RID: 23115
	public bool? IsReceivedVisible;

	// Token: 0x04005A4C RID: 23116
	public bool? IsSelectedFlag;

	// Token: 0x04005A4D RID: 23117
	public bool? IsOrnamentConflictVisible;
}
