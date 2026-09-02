using System;

// Token: 0x02001A4D RID: 6733
public class ForecastCharacterSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FCA RID: 4042
	// (get) Token: 0x0600C09C RID: 49308 RVA: 0x0032D584 File Offset: 0x0032B784
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.ForecastCharacter;
		}
	}

	// Token: 0x04005A36 RID: 23094
	public int? RoleId;
}
