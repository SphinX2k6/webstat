using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020014B6 RID: 5302
[NullableContext(1)]
public interface IPinballSettleResultViewContext
{
	// Token: 0x06009474 RID: 38004
	void ShowStarLayout(bool[] starInfo);

	// Token: 0x06009475 RID: 38005
	bool GetNeedAdjustFormation();

	// Token: 0x06009476 RID: 38006
	void ShowRewards(List<TItem> rewardList);

	// Token: 0x06009477 RID: 38007
	void ShowRewardsGot();

	// Token: 0x06009478 RID: 38008
	void ShowProgressRewardList(int score, int[] scoreLevel, int[] scoreLevelDropId);

	// Token: 0x06009479 RID: 38009
	void ShowSuccessTips(string successTitle);

	// Token: 0x0600947A RID: 38010
	void BindRestartButton();

	// Token: 0x0600947B RID: 38011
	void BindNextButton();

	// Token: 0x0600947C RID: 38012
	void BindBackButton();

	// Token: 0x0600947D RID: 38013
	IPinballSettleResultViewParam GetOpenParam();
}
