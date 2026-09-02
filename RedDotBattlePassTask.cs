using System;

// Token: 0x02003307 RID: 13063
public class RedDotBattlePassTask : RedDotBase
{
	// Token: 0x0601B5A5 RID: 112037 RVA: 0x00834EA4 File Offset: 0x008330A4
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePass);
	}
}
