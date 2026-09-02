using System;

// Token: 0x0200338D RID: 13197
public class RedDotPhantomArenaCollect : RedDotBase
{
	// Token: 0x0601B7FD RID: 112637 RVA: 0x008398AD File Offset: 0x00837AAD
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaActivity);
	}

	// Token: 0x0601B7FE RID: 112638 RVA: 0x008398B9 File Offset: 0x00837AB9
	protected override bool IsMultiple()
	{
		return true;
	}
}
