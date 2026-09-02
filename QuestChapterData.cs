using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200266E RID: 9838
[NullableContext(1)]
[Nullable(0)]
public class QuestChapterData : IQuestChapterData
{
	// Token: 0x17001813 RID: 6163
	// (get) Token: 0x06013611 RID: 79377 RVA: 0x00565971 File Offset: 0x00563B71
	// (set) Token: 0x06013612 RID: 79378 RVA: 0x00565979 File Offset: 0x00563B79
	public int ChapterId { get; set; }

	// Token: 0x17001814 RID: 6164
	// (get) Token: 0x06013613 RID: 79379 RVA: 0x00565982 File Offset: 0x00563B82
	// (set) Token: 0x06013614 RID: 79380 RVA: 0x0056598A File Offset: 0x00563B8A
	public int QuestType { get; set; }

	// Token: 0x17001815 RID: 6165
	// (get) Token: 0x06013615 RID: 79381 RVA: 0x00565993 File Offset: 0x00563B93
	// (set) Token: 0x06013616 RID: 79382 RVA: 0x0056599B File Offset: 0x00563B9B
	public List<int> QuestList { get; set; } = new List<int>();
}
