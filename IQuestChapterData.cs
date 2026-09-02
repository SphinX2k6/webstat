using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200266D RID: 9837
[NullableContext(1)]
public interface IQuestChapterData
{
	// Token: 0x17001810 RID: 6160
	// (get) Token: 0x0601360E RID: 79374
	int ChapterId { get; }

	// Token: 0x17001811 RID: 6161
	// (get) Token: 0x0601360F RID: 79375
	int QuestType { get; }

	// Token: 0x17001812 RID: 6162
	// (get) Token: 0x06013610 RID: 79376
	List<int> QuestList { get; }
}
