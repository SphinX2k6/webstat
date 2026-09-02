using System;

// Token: 0x02001730 RID: 5936
public class RedDotActivityEntrance : RedDotBase
{
	// Token: 0x0600A595 RID: 42389 RVA: 0x002BC6EF File Offset: 0x002BA8EF
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}
}
