using System;
using System.Runtime.CompilerServices;

// Token: 0x0200140F RID: 5135
[NullableContext(2)]
[Nullable(0)]
public class RewardTabData
{
	// Token: 0x04004253 RID: 16979
	public string NameTextId;

	// Token: 0x04004254 RID: 16980
	public int Index = -1;

	// Token: 0x04004255 RID: 16981
	public Action<int> ClickedCallback;

	// Token: 0x04004256 RID: 16982
	public Func<int, bool> RefreshRedDot;
}
