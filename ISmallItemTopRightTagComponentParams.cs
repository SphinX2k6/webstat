using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A44 RID: 6724
[NullableContext(2)]
public interface ISmallItemTopRightTagComponentParams
{
	// Token: 0x17000FBB RID: 4027
	// (get) Token: 0x0600C079 RID: 49273
	// (set) Token: 0x0600C07A RID: 49274
	string TopRightTextBgColor { get; set; }

	// Token: 0x17000FBC RID: 4028
	// (get) Token: 0x0600C07B RID: 49275
	// (set) Token: 0x0600C07C RID: 49276
	string TopRightTextColor { get; set; }

	// Token: 0x17000FBD RID: 4029
	// (get) Token: 0x0600C07D RID: 49277
	// (set) Token: 0x0600C07E RID: 49278
	string TopRightTextId { get; set; }

	// Token: 0x17000FBE RID: 4030
	// (get) Token: 0x0600C07F RID: 49279
	// (set) Token: 0x0600C080 RID: 49280
	string TopRightText { get; set; }

	// Token: 0x17000FBF RID: 4031
	// (get) Token: 0x0600C081 RID: 49281
	// (set) Token: 0x0600C082 RID: 49282
	[Nullable(new byte[]
	{
		2,
		1
	})]
	object[] TopRightTextParameter { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
