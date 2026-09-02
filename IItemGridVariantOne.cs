using System;
using System.Runtime.CompilerServices;

// Token: 0x0200196B RID: 6507
[NullableContext(2)]
public interface IItemGridVariantOne
{
	// Token: 0x17000F26 RID: 3878
	// (get) Token: 0x0600BAF2 RID: 47858
	bool IsItemGridVariantOne { get; }

	// Token: 0x0600BAF3 RID: 47859
	void RefreshStar(int[] starNum);

	// Token: 0x0600BAF4 RID: 47860
	void RefreshRecoverSprite(bool showState);

	// Token: 0x0600BAF5 RID: 47861
	void RefreshRightDownLockSprite(bool showState);

	// Token: 0x0600BAF6 RID: 47862
	void RefreshUpgradePanel(bool showState, string showText);
}
