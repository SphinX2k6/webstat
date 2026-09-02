using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BC2 RID: 7106
public class FloroRanchEvolveData
{
	// Token: 0x0600CECE RID: 52942 RVA: 0x00371220 File Offset: 0x0036F420
	[NullableContext(1)]
	public FloroRanchEvolveData(FREvolveData evolveData)
	{
		this.CurExp = evolveData.CurExp;
		this.CurLevel = evolveData.CurLevel;
		this.ExpPerLevel = evolveData.ExpPerLevel;
		this.IsValid = true;
	}

	// Token: 0x0600CECF RID: 52943 RVA: 0x0037125B File Offset: 0x0036F45B
	[NullableContext(2)]
	public void Refresh(FREvolveData evolveData)
	{
		if (evolveData != null)
		{
			this.CurExp = evolveData.CurExp;
			this.CurLevel = evolveData.CurLevel;
			this.ExpPerLevel = evolveData.ExpPerLevel;
			this.IsValid = true;
			return;
		}
		this.IsValid = false;
	}

	// Token: 0x0400628F RID: 25231
	public int CurExp;

	// Token: 0x04006290 RID: 25232
	public int CurLevel;

	// Token: 0x04006291 RID: 25233
	public int MaxLevel = 100;

	// Token: 0x04006292 RID: 25234
	public int ExpPerLevel;

	// Token: 0x04006293 RID: 25235
	public bool IsValid;
}
