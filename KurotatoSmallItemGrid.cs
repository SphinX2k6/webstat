using System;
using CSharpScript.Game.Module.Kurotato;

// Token: 0x02001A4E RID: 6734
public class KurotatoSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FCB RID: 4043
	// (get) Token: 0x0600C09E RID: 49310 RVA: 0x0032D58F File Offset: 0x0032B78F
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.Kurotato;
		}
	}

	// Token: 0x04005A37 RID: 23095
	public int Id;

	// Token: 0x04005A38 RID: 23096
	public EKurotatoCardType CardType;

	// Token: 0x04005A39 RID: 23097
	public bool? IsReceivedVisible;
}
