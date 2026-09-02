using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EEB RID: 7915
[NullableContext(1)]
public interface IHonamiStoryGridItemData
{
	// Token: 0x0600EA84 RID: 60036
	int GetIncId();

	// Token: 0x0600EA85 RID: 60037
	int GetPosition();

	// Token: 0x0600EA86 RID: 60038
	int GetGridHeight();

	// Token: 0x0600EA87 RID: 60039
	int GetGridWidth();

	// Token: 0x0600EA88 RID: 60040
	int GetRow();

	// Token: 0x0600EA89 RID: 60041
	int GetColumn();

	// Token: 0x0600EA8A RID: 60042
	List<int> GetGridFillPositionList();
}
