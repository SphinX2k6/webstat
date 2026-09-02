using System;

// Token: 0x0200332C RID: 13100
public class FishingTechRoleRedDot : RedDotBase
{
	// Token: 0x0601B64B RID: 112203 RVA: 0x008361E9 File Offset: 0x008343E9
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FishingTech);
	}
}
