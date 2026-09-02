using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200205E RID: 8286
[NullableContext(2)]
public interface IItemHintPanelData<[Nullable(0)] T, TData> where T : ItemHintItemBase<TData>
{
	// Token: 0x170012A2 RID: 4770
	// (get) Token: 0x0600FC83 RID: 64643
	// (set) Token: 0x0600FC84 RID: 64644
	[Nullable(1)]
	Func<TData> ShiftItem { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012A3 RID: 4771
	// (get) Token: 0x0600FC85 RID: 64645
	// (set) Token: 0x0600FC86 RID: 64646
	[Nullable(1)]
	Func<bool> CheckNext { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012A4 RID: 4772
	// (get) Token: 0x0600FC87 RID: 64647
	// (set) Token: 0x0600FC88 RID: 64648
	[Nullable(1)]
	Func<T> CreateProxyFunction { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012A5 RID: 4773
	// (get) Token: 0x0600FC89 RID: 64649
	// (set) Token: 0x0600FC8A RID: 64650
	UUIItem ChildTemplate { get; set; }

	// Token: 0x170012A6 RID: 4774
	// (get) Token: 0x0600FC8B RID: 64651
	// (set) Token: 0x0600FC8C RID: 64652
	string ChildResourceId { get; set; }

	// Token: 0x170012A7 RID: 4775
	// (get) Token: 0x0600FC8D RID: 64653
	// (set) Token: 0x0600FC8E RID: 64654
	string TitleTextId { get; set; }

	// Token: 0x170012A8 RID: 4776
	// (get) Token: 0x0600FC8F RID: 64655
	// (set) Token: 0x0600FC90 RID: 64656
	int? MaxShowCount { get; set; }

	// Token: 0x170012A9 RID: 4777
	// (get) Token: 0x0600FC91 RID: 64657
	// (set) Token: 0x0600FC92 RID: 64658
	int? AddItemTime { get; set; }

	// Token: 0x170012AA RID: 4778
	// (get) Token: 0x0600FC93 RID: 64659
	// (set) Token: 0x0600FC94 RID: 64660
	int? ItemSliderTime { get; set; }

	// Token: 0x170012AB RID: 4779
	// (get) Token: 0x0600FC95 RID: 64661
	// (set) Token: 0x0600FC96 RID: 64662
	int? ItemShowTime { get; set; }

	// Token: 0x170012AC RID: 4780
	// (get) Token: 0x0600FC97 RID: 64663
	// (set) Token: 0x0600FC98 RID: 64664
	ESliderMode? SliderMode { get; set; }

	// Token: 0x170012AD RID: 4781
	// (get) Token: 0x0600FC99 RID: 64665
	// (set) Token: 0x0600FC9A RID: 64666
	ETickItemMode? TickMode { get; set; }

	// Token: 0x170012AE RID: 4782
	// (get) Token: 0x0600FC9B RID: 64667
	// (set) Token: 0x0600FC9C RID: 64668
	Action FinishCallback { get; set; }
}
