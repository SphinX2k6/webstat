using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200269C RID: 9884
[NullableContext(2)]
[Nullable(0)]
public class QuestTreeNodeTarget : IQuestTreeNodeTarget
{
	// Token: 0x1700188D RID: 6285
	// (get) Token: 0x06013806 RID: 79878 RVA: 0x0057044D File Offset: 0x0056E64D
	// (set) Token: 0x06013807 RID: 79879 RVA: 0x00570455 File Offset: 0x0056E655
	public EQuestTreeNodeTargetType Type { get; set; }

	// Token: 0x1700188E RID: 6286
	// (get) Token: 0x06013808 RID: 79880 RVA: 0x0057045E File Offset: 0x0056E65E
	// (set) Token: 0x06013809 RID: 79881 RVA: 0x00570466 File Offset: 0x0056E666
	public string Text { get; set; }

	// Token: 0x1700188F RID: 6287
	// (get) Token: 0x0601380A RID: 79882 RVA: 0x0057046F File Offset: 0x0056E66F
	// (set) Token: 0x0601380B RID: 79883 RVA: 0x00570477 File Offset: 0x0056E677
	public string TextKey { get; set; }

	// Token: 0x17001890 RID: 6288
	// (get) Token: 0x0601380C RID: 79884 RVA: 0x00570480 File Offset: 0x0056E680
	// (set) Token: 0x0601380D RID: 79885 RVA: 0x00570488 File Offset: 0x0056E688
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<object> TextParam { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17001891 RID: 6289
	// (get) Token: 0x0601380E RID: 79886 RVA: 0x00570491 File Offset: 0x0056E691
	// (set) Token: 0x0601380F RID: 79887 RVA: 0x00570499 File Offset: 0x0056E699
	public bool? IsFinished { get; set; }

	// Token: 0x17001892 RID: 6290
	// (get) Token: 0x06013810 RID: 79888 RVA: 0x005704A2 File Offset: 0x0056E6A2
	// (set) Token: 0x06013811 RID: 79889 RVA: 0x005704AA File Offset: 0x0056E6AA
	public int? HelpId { get; set; }

	// Token: 0x17001893 RID: 6291
	// (get) Token: 0x06013812 RID: 79890 RVA: 0x005704B3 File Offset: 0x0056E6B3
	// (set) Token: 0x06013813 RID: 79891 RVA: 0x005704BB File Offset: 0x0056E6BB
	public int? GotoId { get; set; }

	// Token: 0x17001894 RID: 6292
	// (get) Token: 0x06013814 RID: 79892 RVA: 0x005704C4 File Offset: 0x0056E6C4
	// (set) Token: 0x06013815 RID: 79893 RVA: 0x005704CC File Offset: 0x0056E6CC
	public Action OnGoto { get; set; }
}
