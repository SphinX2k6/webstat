using System;
using System.Runtime.CompilerServices;

// Token: 0x02001164 RID: 4452
[NullableContext(2)]
public interface IActivityRewardData
{
	// Token: 0x170009AB RID: 2475
	// (get) Token: 0x06007514 RID: 29972
	// (set) Token: 0x06007515 RID: 29973
	int? Id { get; set; }

	// Token: 0x170009AC RID: 2476
	// (get) Token: 0x06007516 RID: 29974
	// (set) Token: 0x06007517 RID: 29975
	[Nullable(1)]
	string NameText { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170009AD RID: 2477
	// (get) Token: 0x06007518 RID: 29976
	// (set) Token: 0x06007519 RID: 29977
	string NameTextId { get; set; }

	// Token: 0x170009AE RID: 2478
	// (get) Token: 0x0600751A RID: 29978
	// (set) Token: 0x0600751B RID: 29979
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] NameTextArgs { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170009AF RID: 2479
	// (get) Token: 0x0600751C RID: 29980
	// (set) Token: 0x0600751D RID: 29981
	TItem[] RewardList { get; set; }

	// Token: 0x170009B0 RID: 2480
	// (get) Token: 0x0600751E RID: 29982
	// (set) Token: 0x0600751F RID: 29983
	EActivityRewardState RewardState { get; set; }

	// Token: 0x170009B1 RID: 2481
	// (get) Token: 0x06007520 RID: 29984
	// (set) Token: 0x06007521 RID: 29985
	string RewardButtonTextId { get; set; }

	// Token: 0x170009B2 RID: 2482
	// (get) Token: 0x06007522 RID: 29986
	// (set) Token: 0x06007523 RID: 29987
	string RewardButtonText { get; set; }

	// Token: 0x170009B3 RID: 2483
	// (get) Token: 0x06007524 RID: 29988
	// (set) Token: 0x06007525 RID: 29989
	bool? RewardButtonRedDot { get; set; }

	// Token: 0x170009B4 RID: 2484
	// (get) Token: 0x06007526 RID: 29990
	// (set) Token: 0x06007527 RID: 29991
	Action ClickFunction { get; set; }

	// Token: 0x170009B5 RID: 2485
	// (get) Token: 0x06007528 RID: 29992
	// (set) Token: 0x06007529 RID: 29993
	bool? ClickFunctionAndCloseSelf { get; set; }

	// Token: 0x170009B6 RID: 2486
	// (get) Token: 0x0600752A RID: 29994
	// (set) Token: 0x0600752B RID: 29995
	string ProgressText { get; set; }
}
