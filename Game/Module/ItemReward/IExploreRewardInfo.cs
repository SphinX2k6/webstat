using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0E RID: 23310
	[NullableContext(2)]
	public interface IExploreRewardInfo : IRewardInfo
	{
		// Token: 0x1700967D RID: 38525
		// (get) Token: 0x0603AFB6 RID: 241590
		// (set) Token: 0x0603AFB7 RID: 241591
		ERewardInfoType Type { get; set; }

		// Token: 0x1700967E RID: 38526
		// (get) Token: 0x0603AFB8 RID: 241592
		// (set) Token: 0x0603AFB9 RID: 241593
		bool IsSuccess { get; set; }

		// Token: 0x1700967F RID: 38527
		// (get) Token: 0x0603AFBA RID: 241594
		// (set) Token: 0x0603AFBB RID: 241595
		string Title { get; set; }

		// Token: 0x17009680 RID: 38528
		// (get) Token: 0x0603AFBC RID: 241596
		// (set) Token: 0x0603AFBD RID: 241597
		string TitleHexColor { get; set; }

		// Token: 0x17009681 RID: 38529
		// (get) Token: 0x0603AFBE RID: 241598
		// (set) Token: 0x0603AFBF RID: 241599
		string TitleIconPath { get; set; }

		// Token: 0x17009682 RID: 38530
		// (get) Token: 0x0603AFC0 RID: 241600
		// (set) Token: 0x0603AFC1 RID: 241601
		string TitleIconHexColor { get; set; }

		// Token: 0x17009683 RID: 38531
		// (get) Token: 0x0603AFC2 RID: 241602
		// (set) Token: 0x0603AFC3 RID: 241603
		bool IsRecordVisible { get; set; }

		// Token: 0x17009684 RID: 38532
		// (get) Token: 0x0603AFC4 RID: 241604
		// (set) Token: 0x0603AFC5 RID: 241605
		bool IsItemVisible { get; set; }

		// Token: 0x17009685 RID: 38533
		// (get) Token: 0x0603AFC6 RID: 241606
		// (set) Token: 0x0603AFC7 RID: 241607
		bool IsExploreProgressVisible { get; set; }

		// Token: 0x17009686 RID: 38534
		// (get) Token: 0x0603AFC8 RID: 241608
		// (set) Token: 0x0603AFC9 RID: 241609
		string ExploreBarTipsTextId { get; set; }

		// Token: 0x17009687 RID: 38535
		// (get) Token: 0x0603AFCA RID: 241610
		// (set) Token: 0x0603AFCB RID: 241611
		bool IsDescription { get; set; }

		// Token: 0x17009688 RID: 38536
		// (get) Token: 0x0603AFCC RID: 241612
		// (set) Token: 0x0603AFCD RID: 241613
		string Description { get; set; }

		// Token: 0x17009689 RID: 38537
		// (get) Token: 0x0603AFCE RID: 241614
		// (set) Token: 0x0603AFCF RID: 241615
		bool? IsShowOnlineChallengePlayer { get; set; }

		// Token: 0x1700968A RID: 38538
		// (get) Token: 0x0603AFD0 RID: 241616
		// (set) Token: 0x0603AFD1 RID: 241617
		string Tip { get; set; }

		// Token: 0x1700968B RID: 38539
		// (get) Token: 0x0603AFD2 RID: 241618
		// (set) Token: 0x0603AFD3 RID: 241619
		bool? IsRewardMultiLine { get; set; }

		// Token: 0x1700968C RID: 38540
		// (get) Token: 0x0603AFD4 RID: 241620
		// (set) Token: 0x0603AFD5 RID: 241621
		Action OnCloseCallback { get; set; }

		// Token: 0x1700968D RID: 38541
		// (get) Token: 0x0603AFD6 RID: 241622
		// (set) Token: 0x0603AFD7 RID: 241623
		bool? IsBagFull { get; set; }
	}
}
