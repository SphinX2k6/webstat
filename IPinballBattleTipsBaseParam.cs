using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D70 RID: 7536
[NullableContext(2)]
public interface IPinballBattleTipsBaseParam
{
	// Token: 0x17001170 RID: 4464
	// (get) Token: 0x0600DDA9 RID: 56745
	Action CloseCallback { get; }

	// Token: 0x17001171 RID: 4465
	// (get) Token: 0x0600DDAA RID: 56746
	bool? AddMask { get; }

	// Token: 0x17001172 RID: 4466
	// (get) Token: 0x0600DDAB RID: 56747
	int? CloseTime { get; }

	// Token: 0x17001173 RID: 4467
	// (get) Token: 0x0600DDAC RID: 56748
	bool? MoveToBehind { get; }
}
