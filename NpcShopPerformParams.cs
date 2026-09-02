using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x020031DD RID: 12765
[NullableContext(2)]
[Nullable(0)]
public class NpcShopPerformParams
{
	// Token: 0x0601A754 RID: 108372 RVA: 0x007CED34 File Offset: 0x007CCF34
	public void TryLoadAllMontage()
	{
		NpcSystemUiMontageInfo enterMontageInfo = this.EnterMontageInfo;
		if (enterMontageInfo != null)
		{
			enterMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo standByMontageInfo = this.StandByMontageInfo;
		if (standByMontageInfo != null)
		{
			standByMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo shopSuccessMontageInfo = this.ShopSuccessMontageInfo;
		if (shopSuccessMontageInfo != null)
		{
			shopSuccessMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo switchMusicMontageInfo = this.SwitchMusicMontageInfo;
		if (switchMusicMontageInfo != null)
		{
			switchMusicMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo exitMontageInfo = this.ExitMontageInfo;
		if (exitMontageInfo != null)
		{
			exitMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo completeMontageInfo = this.CompleteMontageInfo;
		if (completeMontageInfo != null)
		{
			completeMontageInfo.TryLoadAsset();
		}
		NpcSystemUiMontageInfo deliverSuccessMontageInfo = this.DeliverSuccessMontageInfo;
		if (deliverSuccessMontageInfo == null)
		{
			return;
		}
		deliverSuccessMontageInfo.TryLoadAsset();
	}

	// Token: 0x0400D5C7 RID: 54727
	public NpcSystemUiMontageInfo EnterMontageInfo;

	// Token: 0x0400D5C8 RID: 54728
	public NpcSystemUiMontageInfo StandByMontageInfo;

	// Token: 0x0400D5C9 RID: 54729
	public NpcSystemUiMontageInfo ShopSuccessMontageInfo;

	// Token: 0x0400D5CA RID: 54730
	public NpcSystemUiMontageInfo SwitchMusicMontageInfo;

	// Token: 0x0400D5CB RID: 54731
	public NpcSystemUiMontageInfo ExitMontageInfo;

	// Token: 0x0400D5CC RID: 54732
	public NpcSystemUiMontageInfo DeliverSuccessMontageInfo;

	// Token: 0x0400D5CD RID: 54733
	public NpcSystemUiMontageInfo CompleteMontageInfo;

	// Token: 0x0400D5CE RID: 54734
	public NpcSystemUiMontageInfo FirstDollMontageInfo;

	// Token: 0x0400D5CF RID: 54735
	public NpcSystemUiMontageInfo SubsequentDollMontageInfo;

	// Token: 0x0400D5D0 RID: 54736
	public NpcSystemUiMontageInfo FirstDollPartMontageInfo;

	// Token: 0x0400D5D1 RID: 54737
	public NpcSystemUiMontageInfo SubsequentDollPartMontageInfo;

	// Token: 0x0400D5D2 RID: 54738
	public PlayFlow EnterFlow;

	// Token: 0x0400D5D3 RID: 54739
	public PlayFlow ShopSuccessFlow;

	// Token: 0x0400D5D4 RID: 54740
	public PlayFlow ShopFailedFlow;

	// Token: 0x0400D5D5 RID: 54741
	public PlayFlow UpgradeFlow;

	// Token: 0x0400D5D6 RID: 54742
	public PlayFlow DeliverSuccessFlow;

	// Token: 0x0400D5D7 RID: 54743
	public PlayFlow CompleteFlow;

	// Token: 0x0400D5D8 RID: 54744
	public PlayFlow FirstDollFlow;

	// Token: 0x0400D5D9 RID: 54745
	public PlayFlow SubsequentDollFlow;

	// Token: 0x0400D5DA RID: 54746
	public PlayFlow FirstDollPartFlow;

	// Token: 0x0400D5DB RID: 54747
	public PlayFlow SubsequentDollPartFlow;

	// Token: 0x0400D5DC RID: 54748
	public string UpgradeSequencePath;

	// Token: 0x0400D5DD RID: 54749
	[Nullable(1)]
	public string FinishDeliverySequence = "";

	// Token: 0x0400D5DE RID: 54750
	public bool ShowNpcWhilePlayingSequence;
}
