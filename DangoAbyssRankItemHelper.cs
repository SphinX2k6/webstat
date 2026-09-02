using System;
using System.Runtime.CompilerServices;

// Token: 0x02001AF6 RID: 6902
[NullableContext(1)]
[Nullable(0)]
public static class DangoAbyssRankItemHelper
{
	// Token: 0x0600C6D2 RID: 50898 RVA: 0x003491B7 File Offset: 0x003473B7
	public static string GetPosTexture(int index)
	{
		if (index == 0)
		{
			return "FormationOnline1PIcon";
		}
		if (index == 1)
		{
			return "FormationOnline2PIcon";
		}
		return "FormationOnline3PIcon";
	}

	// Token: 0x04005F39 RID: 24377
	private const string FIRSTPLAYER_ICON = "FormationOnline1PIcon";

	// Token: 0x04005F3A RID: 24378
	private const string SECONDPLAYER_ICON = "FormationOnline2PIcon";

	// Token: 0x04005F3B RID: 24379
	private const string THIRDPLAYER_ICON = "FormationOnline3PIcon";
}
