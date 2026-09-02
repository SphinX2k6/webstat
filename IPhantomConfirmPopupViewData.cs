using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200190A RID: 6410
[NullableContext(2)]
public interface IPhantomConfirmPopupViewData
{
	// Token: 0x17000EFE RID: 3838
	// (get) Token: 0x0600B817 RID: 47127
	// (set) Token: 0x0600B818 RID: 47128
	[Nullable(1)]
	string Title { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000EFF RID: 3839
	// (get) Token: 0x0600B819 RID: 47129
	// (set) Token: 0x0600B81A RID: 47130
	[Nullable(1)]
	string SubTitle { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000F00 RID: 3840
	// (get) Token: 0x0600B81B RID: 47131
	// (set) Token: 0x0600B81C RID: 47132
	[Nullable(1)]
	List<int> PhantomUniqueIdList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000F01 RID: 3841
	// (get) Token: 0x0600B81D RID: 47133
	// (set) Token: 0x0600B81E RID: 47134
	Action OnRight { get; set; }

	// Token: 0x17000F02 RID: 3842
	// (get) Token: 0x0600B81F RID: 47135
	// (set) Token: 0x0600B820 RID: 47136
	Action OnMiddle { get; set; }

	// Token: 0x17000F03 RID: 3843
	// (get) Token: 0x0600B821 RID: 47137
	// (set) Token: 0x0600B822 RID: 47138
	Action OnLeft { get; set; }

	// Token: 0x17000F04 RID: 3844
	// (get) Token: 0x0600B823 RID: 47139
	// (set) Token: 0x0600B824 RID: 47140
	string MiddleTxtKey { get; set; }

	// Token: 0x17000F05 RID: 3845
	// (get) Token: 0x0600B825 RID: 47141
	// (set) Token: 0x0600B826 RID: 47142
	string RightTxtKey { get; set; }

	// Token: 0x17000F06 RID: 3846
	// (get) Token: 0x0600B827 RID: 47143
	// (set) Token: 0x0600B828 RID: 47144
	string LeftTxtKey { get; set; }
}
