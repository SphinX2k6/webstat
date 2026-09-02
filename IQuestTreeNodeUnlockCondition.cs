using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020026A4 RID: 9892
[NullableContext(1)]
public interface IQuestTreeNodeUnlockCondition
{
	// Token: 0x17001897 RID: 6295
	// (get) Token: 0x06013827 RID: 79911
	bool IsFinished { get; }

	// Token: 0x17001898 RID: 6296
	// (get) Token: 0x06013828 RID: 79912
	string Text { get; }

	// Token: 0x17001899 RID: 6297
	// (get) Token: 0x06013829 RID: 79913
	int HelpId { get; }

	// Token: 0x1700189A RID: 6298
	// (get) Token: 0x0601382A RID: 79914
	List<object> TextParam { get; }

	// Token: 0x1700189B RID: 6299
	// (get) Token: 0x0601382B RID: 79915
	bool HasGoto { get; }

	// Token: 0x0601382C RID: 79916
	void Goto();
}
