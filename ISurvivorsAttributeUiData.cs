using System;

// Token: 0x02002B00 RID: 11008
public interface ISurvivorsAttributeUiData
{
	// Token: 0x17001CAE RID: 7342
	// (get) Token: 0x0601601D RID: 90141
	int AttrId { get; }

	// Token: 0x17001CAF RID: 7343
	// (get) Token: 0x0601601E RID: 90142
	double Value { get; }

	// Token: 0x17001CB0 RID: 7344
	// (get) Token: 0x0601601F RID: 90143
	bool IsRecommend { get; }

	// Token: 0x17001CB1 RID: 7345
	// (get) Token: 0x06016020 RID: 90144
	bool? IsAddition { get; }
}
