using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A64 RID: 6756
public class CommonTabItemData
{
	// Token: 0x04005A87 RID: 23175
	public int Index;

	// Token: 0x04005A88 RID: 23176
	[Nullable(2)]
	public CommonTabData Data;

	// Token: 0x04005A89 RID: 23177
	public ERedDotName? RedDotName;

	// Token: 0x04005A8A RID: 23178
	public int? RedDotUid;

	// Token: 0x04005A8B RID: 23179
	public bool NeedUnBindAllRedDot = true;
}
