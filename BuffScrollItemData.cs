using System;
using System.Runtime.CompilerServices;

// Token: 0x02001427 RID: 5159
internal class BuffScrollItemData
{
	// Token: 0x04004290 RID: 17040
	public int BuffId;

	// Token: 0x04004291 RID: 17041
	public bool ChangeAble = true;

	// Token: 0x04004292 RID: 17042
	public bool Selected;

	// Token: 0x04004293 RID: 17043
	public bool SelectedAtStart;

	// Token: 0x04004294 RID: 17044
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<BuffScrollItemData> OnClickToggle;

	// Token: 0x04004295 RID: 17045
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<BuffScrollItemData, bool> CheckClickAble;
}
