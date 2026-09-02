using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200276E RID: 10094
[NullableContext(2)]
[Nullable(0)]
public class RoleBuyInfoGroupData
{
	// Token: 0x06013EBB RID: 81595 RVA: 0x0058D3FA File Offset: 0x0058B5FA
	public RoleBuyInfoGroupData(RogueResGainData data1 = null, RogueResGainData data2 = null)
	{
		this.Data1 = data1;
		this.Data2 = data2;
	}

	// Token: 0x04009AF4 RID: 39668
	public RogueResGainData Data1;

	// Token: 0x04009AF5 RID: 39669
	public RogueResGainData Data2;
}
