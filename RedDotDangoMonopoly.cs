using System;

// Token: 0x02003321 RID: 13089
public class RedDotDangoMonopoly : RedDotBase
{
	// Token: 0x0601B61C RID: 112156 RVA: 0x00835DF8 File Offset: 0x00833FF8
	protected override ERedDotName? OnGetParentName()
	{
		return null;
	}

	// Token: 0x0601B61D RID: 112157 RVA: 0x00835E0E File Offset: 0x0083400E
	protected override void AddCheckEvent()
	{
	}

	// Token: 0x0601B61E RID: 112158 RVA: 0x00835E10 File Offset: 0x00834010
	protected override void RemoveCheckEvent()
	{
	}

	// Token: 0x0601B61F RID: 112159 RVA: 0x00835E12 File Offset: 0x00834012
	protected override bool OnCheck(int uId = 0)
	{
		return false;
	}
}
