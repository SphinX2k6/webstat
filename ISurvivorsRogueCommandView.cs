using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B8C RID: 11148
[NullableContext(1)]
public interface ISurvivorsRogueCommandView
{
	// Token: 0x17001CF2 RID: 7410
	// (get) Token: 0x06016363 RID: 90979
	SurvivorsRogueCommandBase Command { get; }

	// Token: 0x17001CF3 RID: 7411
	// (get) Token: 0x06016364 RID: 90980
	int CommandIncId { get; }

	// Token: 0x06016365 RID: 90981
	void Refresh();

	// Token: 0x06016366 RID: 90982
	void CloseView();
}
