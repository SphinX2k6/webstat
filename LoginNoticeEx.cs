using System;
using System.Runtime.CompilerServices;

// Token: 0x020020FA RID: 8442
[NullableContext(1)]
[Nullable(0)]
public class LoginNoticeEx
{
	// Token: 0x04007BC4 RID: 31684
	public string title = string.Empty;

	// Token: 0x04007BC5 RID: 31685
	public string content = string.Empty;

	// Token: 0x04007BC6 RID: 31686
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] whiteList;

	// Token: 0x04007BC7 RID: 31687
	public double startTimeMs;

	// Token: 0x04007BC8 RID: 31688
	public double endTimeMs;
}
