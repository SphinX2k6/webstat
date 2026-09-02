using System;
using System.Runtime.CompilerServices;

// Token: 0x02002908 RID: 10504
[NullableContext(2)]
public interface IExtraItemIdProxy
{
	// Token: 0x06014DC2 RID: 85442
	int GetExtraItemId();

	// Token: 0x06014DC3 RID: 85443
	void SetExtraItemId(int itemId, Action<bool> callback = null);

	// Token: 0x06014DC4 RID: 85444
	void ApplyServerSnapshot(int itemId);
}
