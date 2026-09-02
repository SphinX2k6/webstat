using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020031E1 RID: 12769
[NullableContext(1)]
[Nullable(0)]
public class LimitTagHandler
{
	// Token: 0x0601A792 RID: 108434 RVA: 0x007D1DEA File Offset: 0x007CFFEA
	public LimitTagHandler(int tagId, int priority, bool tagExist, Action<bool> callBack)
	{
		this.TagId = tagId;
		this.Priority = (double)Singleton<MathUtils>.Instance.Clamp(priority, 0, 3);
		this.TagExist = tagExist;
		this.CallBack = callBack;
	}

	// Token: 0x0400D5FB RID: 54779
	private const int MAX_PRIORITY = 3;

	// Token: 0x0400D5FC RID: 54780
	public int TagId;

	// Token: 0x0400D5FD RID: 54781
	public double Priority;

	// Token: 0x0400D5FE RID: 54782
	public bool TagExist;

	// Token: 0x0400D5FF RID: 54783
	public Action<bool> CallBack;

	// Token: 0x0400D600 RID: 54784
	public List<int> MutuallyTags = new List<int>();

	// Token: 0x0400D601 RID: 54785
	public bool Active;
}
