using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0A RID: 23306
	[NullableContext(2)]
	public interface ICommonRewardInfo : IRewardInfo
	{
		// Token: 0x17009653 RID: 38483
		// (get) Token: 0x0603AF60 RID: 241504
		// (set) Token: 0x0603AF61 RID: 241505
		ERewardInfoType Type { get; set; }

		// Token: 0x17009654 RID: 38484
		// (get) Token: 0x0603AF62 RID: 241506
		// (set) Token: 0x0603AF63 RID: 241507
		string Title { get; set; }

		// Token: 0x17009655 RID: 38485
		// (get) Token: 0x0603AF64 RID: 241508
		// (set) Token: 0x0603AF65 RID: 241509
		string ContinueText { get; set; }

		// Token: 0x17009656 RID: 38486
		// (get) Token: 0x0603AF66 RID: 241510
		// (set) Token: 0x0603AF67 RID: 241511
		bool IsItemVisible { get; set; }

		// Token: 0x17009657 RID: 38487
		// (get) Token: 0x0603AF68 RID: 241512
		// (set) Token: 0x0603AF69 RID: 241513
		Action OnCloseCallback { get; set; }

		// Token: 0x17009658 RID: 38488
		// (get) Token: 0x0603AF6A RID: 241514
		// (set) Token: 0x0603AF6B RID: 241515
		string LeftBtnTextId { get; set; }

		// Token: 0x17009659 RID: 38489
		// (get) Token: 0x0603AF6C RID: 241516
		// (set) Token: 0x0603AF6D RID: 241517
		string RightBtnTextId { get; set; }

		// Token: 0x1700965A RID: 38490
		// (get) Token: 0x0603AF6E RID: 241518
		// (set) Token: 0x0603AF6F RID: 241519
		Action LeftAction { get; set; }

		// Token: 0x1700965B RID: 38491
		// (get) Token: 0x0603AF70 RID: 241520
		// (set) Token: 0x0603AF71 RID: 241521
		Action RightAction { get; set; }

		// Token: 0x1700965C RID: 38492
		// (get) Token: 0x0603AF72 RID: 241522
		// (set) Token: 0x0603AF73 RID: 241523
		bool? DisableMaskClose { get; set; }

		// Token: 0x1700965D RID: 38493
		// (get) Token: 0x0603AF74 RID: 241524
		// (set) Token: 0x0603AF75 RID: 241525
		bool? TipsCanSkip { get; set; }
	}
}
