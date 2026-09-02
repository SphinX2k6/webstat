using System;

// Token: 0x02003391 RID: 13201
public class RedDotPhantomArenaMapUnlock : RedDotBase
{
	// Token: 0x0601B80C RID: 112652 RVA: 0x0083998A File Offset: 0x00837B8A
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaActivity);
	}

	// Token: 0x0601B80D RID: 112653 RVA: 0x00839996 File Offset: 0x00837B96
	protected override bool IsMultiple()
	{
		return true;
	}
}
