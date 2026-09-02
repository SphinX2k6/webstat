using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B0C RID: 23308
	[NullableContext(2)]
	public interface ICompositeRewardInfo : IRewardInfo
	{
		// Token: 0x17009669 RID: 38505
		// (get) Token: 0x0603AF8D RID: 241549
		// (set) Token: 0x0603AF8E RID: 241550
		ERewardInfoType Type { get; set; }

		// Token: 0x1700966A RID: 38506
		// (get) Token: 0x0603AF8F RID: 241551
		// (set) Token: 0x0603AF90 RID: 241552
		int Id { get; set; }

		// Token: 0x1700966B RID: 38507
		// (get) Token: 0x0603AF91 RID: 241553
		// (set) Token: 0x0603AF92 RID: 241554
		bool IsSuccess { get; set; }

		// Token: 0x1700966C RID: 38508
		// (get) Token: 0x0603AF93 RID: 241555
		// (set) Token: 0x0603AF94 RID: 241556
		string Title { get; set; }

		// Token: 0x1700966D RID: 38509
		// (get) Token: 0x0603AF95 RID: 241557
		// (set) Token: 0x0603AF96 RID: 241558
		string ContinueText { get; set; }

		// Token: 0x1700966E RID: 38510
		// (get) Token: 0x0603AF97 RID: 241559
		// (set) Token: 0x0603AF98 RID: 241560
		string TitleIconPath { get; set; }

		// Token: 0x1700966F RID: 38511
		// (get) Token: 0x0603AF99 RID: 241561
		// (set) Token: 0x0603AF9A RID: 241562
		bool IsProgressVisible { get; set; }

		// Token: 0x17009670 RID: 38512
		// (get) Token: 0x0603AF9B RID: 241563
		// (set) Token: 0x0603AF9C RID: 241564
		[Nullable(1)]
		string ProgressBarTitle { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009671 RID: 38513
		// (get) Token: 0x0603AF9D RID: 241565
		// (set) Token: 0x0603AF9E RID: 241566
		int ProgressBarAnimationTime { get; set; }

		// Token: 0x17009672 RID: 38514
		// (get) Token: 0x0603AF9F RID: 241567
		// (set) Token: 0x0603AFA0 RID: 241568
		bool IsItemVisible { get; set; }
	}
}
