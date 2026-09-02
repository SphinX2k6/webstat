using System;
using System.Runtime.CompilerServices;

// Token: 0x020014B5 RID: 5301
[NullableContext(1)]
public interface IPinballSettleResultStrategy
{
	// Token: 0x17000C6B RID: 3179
	// (get) Token: 0x06009462 RID: 37986
	// (set) Token: 0x06009463 RID: 37987
	IPinballSettleResultViewContext Context { get; set; }

	// Token: 0x06009464 RID: 37988
	void RefreshStarLayout();

	// Token: 0x06009465 RID: 37989
	void RefreshRewards();

	// Token: 0x06009466 RID: 37990
	void RefreshButtons();

	// Token: 0x06009467 RID: 37991
	void RefreshProgressRewards();

	// Token: 0x06009468 RID: 37992
	void RefreshUnlockTips();

	// Token: 0x06009469 RID: 37993
	void RefreshFailTips();

	// Token: 0x0600946A RID: 37994
	void RefreshDialog();

	// Token: 0x0600946B RID: 37995
	void RefreshTitle();

	// Token: 0x0600946C RID: 37996
	void OnClickBtnRestart(Action callback);

	// Token: 0x0600946D RID: 37997
	void OnClickBtnNext(Action callback);

	// Token: 0x0600946E RID: 37998
	void OnClickBtnBack(Action callback);

	// Token: 0x0600946F RID: 37999
	bool GetIsNeedRewardView();

	// Token: 0x06009470 RID: 38000
	bool GetIsNeedProgressRewardView();

	// Token: 0x06009471 RID: 38001
	bool GetIsNeedFailTipsView();

	// Token: 0x06009472 RID: 38002
	bool GetIsNeedUnlockTipsView();

	// Token: 0x06009473 RID: 38003
	bool GetIsNeedDialogView();
}
