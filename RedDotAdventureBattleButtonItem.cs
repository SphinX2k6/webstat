using System;

// Token: 0x020032F4 RID: 13044
public class RedDotAdventureBattleButtonItem : RedDotBase
{
	// Token: 0x0601B54B RID: 111947 RVA: 0x0083439E File Offset: 0x0083259E
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}
}
