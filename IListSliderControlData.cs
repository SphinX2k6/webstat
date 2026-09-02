using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200206C RID: 8300
[NullableContext(1)]
public interface IListSliderControlData<[Nullable(0)] T> where T : SliderItem
{
	// Token: 0x170012BE RID: 4798
	// (get) Token: 0x0600FCFD RID: 64765
	UUIItem ParentUi { get; }

	// Token: 0x170012BF RID: 4799
	// (get) Token: 0x0600FCFE RID: 64766
	Func<T> CreateProxyFunction { get; }

	// Token: 0x170012C0 RID: 4800
	// (get) Token: 0x0600FCFF RID: 64767
	Func<bool> CheckNext { get; }

	// Token: 0x170012C1 RID: 4801
	// (get) Token: 0x0600FD00 RID: 64768
	[Nullable(2)]
	UUIItem ChildTemplate { [NullableContext(2)] get; }

	// Token: 0x170012C2 RID: 4802
	// (get) Token: 0x0600FD01 RID: 64769
	[Nullable(2)]
	string ChildResourceId { [NullableContext(2)] get; }

	// Token: 0x170012C3 RID: 4803
	// (get) Token: 0x0600FD02 RID: 64770
	int? MaxShowCount { get; }

	// Token: 0x170012C4 RID: 4804
	// (get) Token: 0x0600FD03 RID: 64771
	float? AddItemTime { get; }

	// Token: 0x170012C5 RID: 4805
	// (get) Token: 0x0600FD04 RID: 64772
	float? ItemSliderTime { get; }

	// Token: 0x170012C6 RID: 4806
	// (get) Token: 0x0600FD05 RID: 64773
	float? ItemShowTime { get; }

	// Token: 0x170012C7 RID: 4807
	// (get) Token: 0x0600FD06 RID: 64774
	ESliderMode? SliderMode { get; }

	// Token: 0x170012C8 RID: 4808
	// (get) Token: 0x0600FD07 RID: 64775
	ETickItemMode? TickMode { get; }

	// Token: 0x170012C9 RID: 4809
	// (get) Token: 0x0600FD08 RID: 64776
	[Nullable(2)]
	Action FinishCallback { [NullableContext(2)] get; }
}
