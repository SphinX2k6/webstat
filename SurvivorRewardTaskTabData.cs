using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AC7 RID: 10951
public class SurvivorRewardTaskTabData
{
	// Token: 0x0400A852 RID: 43090
	[Nullable(2)]
	public string NameTextId;

	// Token: 0x0400A853 RID: 43091
	public int Index = -1;

	// Token: 0x0400A854 RID: 43092
	public int Type;

	// Token: 0x0400A855 RID: 43093
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<SurvivorRewardTaskTabData> ClickedCallback;

	// Token: 0x0400A856 RID: 43094
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<SurvivorRewardTaskTabData, bool> RefreshRedDot;
}
