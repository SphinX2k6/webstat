using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002062 RID: 8290
[NullableContext(2)]
[Nullable(0)]
public class ItemHintViewNewData : UiViewData
{
	// Token: 0x0400792F RID: 31023
	public string TitleTextId;

	// Token: 0x04007930 RID: 31024
	public Func<bool> CheckNext;

	// Token: 0x04007931 RID: 31025
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<ItemRewardInfo> ShiftItem;

	// Token: 0x04007932 RID: 31026
	public int? MaxShowCount;

	// Token: 0x04007933 RID: 31027
	public int? AddItemTime;

	// Token: 0x04007934 RID: 31028
	public int? ItemSliderTime;

	// Token: 0x04007935 RID: 31029
	public int? ItemShowTime;

	// Token: 0x04007936 RID: 31030
	public string SlotResourceId;

	// Token: 0x04007937 RID: 31031
	public Func<bool> CheckPriorNext;

	// Token: 0x04007938 RID: 31032
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<ItemRewardInfo> ShiftPriorItem;

	// Token: 0x04007939 RID: 31033
	public int? PriorMaxShowCount;

	// Token: 0x0400793A RID: 31034
	public int? AddPriorItemTime;

	// Token: 0x0400793B RID: 31035
	public int? PriorItemSliderTime;

	// Token: 0x0400793C RID: 31036
	public int? PriorItemShowTime;

	// Token: 0x0400793D RID: 31037
	public string PriorSlotResourceId;
}
