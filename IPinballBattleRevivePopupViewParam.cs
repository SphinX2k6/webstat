using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D75 RID: 7541
[NullableContext(2)]
public interface IPinballBattleRevivePopupViewParam
{
	// Token: 0x17001175 RID: 4469
	// (get) Token: 0x0600DDD5 RID: 56789
	Action ConfirmCallback { get; }

	// Token: 0x17001176 RID: 4470
	// (get) Token: 0x0600DDD6 RID: 56790
	Action CancelCallback { get; }
}
