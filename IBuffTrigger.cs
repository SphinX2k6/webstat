using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E71 RID: 11889
[NullableContext(2)]
public interface IBuffTrigger
{
	// Token: 0x170020E6 RID: 8422
	// (get) Token: 0x06018715 RID: 100117
	int ActiveHandleId { get; }

	// Token: 0x170020E7 RID: 8423
	// (get) Token: 0x06018716 RID: 100118
	BaseBuffComponent InstigatorBuffComponent { get; }

	// Token: 0x06018717 RID: 100119
	[NullableContext(1)]
	bool TryExecute(Partial_RequirementPayload payload, IBuffComponent opponentBuffComp);
}
