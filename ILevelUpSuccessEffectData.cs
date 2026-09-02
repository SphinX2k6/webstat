using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002891 RID: 10385
[NullableContext(2)]
public interface ILevelUpSuccessEffectData
{
	// Token: 0x17001AEB RID: 6891
	// (get) Token: 0x06014903 RID: 84227
	// (set) Token: 0x06014904 RID: 84228
	string Title { get; set; }

	// Token: 0x17001AEC RID: 6892
	// (get) Token: 0x06014905 RID: 84229
	// (set) Token: 0x06014906 RID: 84230
	string AudioId { get; set; }

	// Token: 0x17001AED RID: 6893
	// (get) Token: 0x06014907 RID: 84231
	// (set) Token: 0x06014908 RID: 84232
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<SingleText> TextList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001AEE RID: 6894
	// (get) Token: 0x06014909 RID: 84233
	// (set) Token: 0x0601490A RID: 84234
	string ClickText { get; set; }

	// Token: 0x17001AEF RID: 6895
	// (get) Token: 0x0601490B RID: 84235
	// (set) Token: 0x0601490C RID: 84236
	Action ClickFunction { get; set; }
}
