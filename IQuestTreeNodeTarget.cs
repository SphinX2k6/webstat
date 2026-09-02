using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200269B RID: 9883
[NullableContext(2)]
public interface IQuestTreeNodeTarget
{
	// Token: 0x17001885 RID: 6277
	// (get) Token: 0x060137F6 RID: 79862
	// (set) Token: 0x060137F7 RID: 79863
	EQuestTreeNodeTargetType Type { get; set; }

	// Token: 0x17001886 RID: 6278
	// (get) Token: 0x060137F8 RID: 79864
	// (set) Token: 0x060137F9 RID: 79865
	string Text { get; set; }

	// Token: 0x17001887 RID: 6279
	// (get) Token: 0x060137FA RID: 79866
	// (set) Token: 0x060137FB RID: 79867
	string TextKey { get; set; }

	// Token: 0x17001888 RID: 6280
	// (get) Token: 0x060137FC RID: 79868
	// (set) Token: 0x060137FD RID: 79869
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<object> TextParam { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001889 RID: 6281
	// (get) Token: 0x060137FE RID: 79870
	// (set) Token: 0x060137FF RID: 79871
	bool? IsFinished { get; set; }

	// Token: 0x1700188A RID: 6282
	// (get) Token: 0x06013800 RID: 79872
	// (set) Token: 0x06013801 RID: 79873
	int? HelpId { get; set; }

	// Token: 0x1700188B RID: 6283
	// (get) Token: 0x06013802 RID: 79874
	// (set) Token: 0x06013803 RID: 79875
	int? GotoId { get; set; }

	// Token: 0x1700188C RID: 6284
	// (get) Token: 0x06013804 RID: 79876
	// (set) Token: 0x06013805 RID: 79877
	Action OnGoto { get; set; }
}
