using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200190B RID: 6411
[NullableContext(2)]
[Nullable(0)]
public class PhantomConfirmPopupViewData : IPhantomConfirmPopupViewData
{
	// Token: 0x17000F07 RID: 3847
	// (get) Token: 0x0600B829 RID: 47145 RVA: 0x0030F3C4 File Offset: 0x0030D5C4
	// (set) Token: 0x0600B82A RID: 47146 RVA: 0x0030F3CC File Offset: 0x0030D5CC
	[Nullable(1)]
	public string Title { [NullableContext(1)] get; [NullableContext(1)] set; } = "";

	// Token: 0x17000F08 RID: 3848
	// (get) Token: 0x0600B82B RID: 47147 RVA: 0x0030F3D5 File Offset: 0x0030D5D5
	// (set) Token: 0x0600B82C RID: 47148 RVA: 0x0030F3DD File Offset: 0x0030D5DD
	[Nullable(1)]
	public string SubTitle { [NullableContext(1)] get; [NullableContext(1)] set; } = "";

	// Token: 0x17000F09 RID: 3849
	// (get) Token: 0x0600B82D RID: 47149 RVA: 0x0030F3E6 File Offset: 0x0030D5E6
	// (set) Token: 0x0600B82E RID: 47150 RVA: 0x0030F3EE File Offset: 0x0030D5EE
	[Nullable(1)]
	public List<int> PhantomUniqueIdList { [NullableContext(1)] get; [NullableContext(1)] set; } = new List<int>();

	// Token: 0x17000F0A RID: 3850
	// (get) Token: 0x0600B82F RID: 47151 RVA: 0x0030F3F7 File Offset: 0x0030D5F7
	// (set) Token: 0x0600B830 RID: 47152 RVA: 0x0030F3FF File Offset: 0x0030D5FF
	public Action OnRight { get; set; }

	// Token: 0x17000F0B RID: 3851
	// (get) Token: 0x0600B831 RID: 47153 RVA: 0x0030F408 File Offset: 0x0030D608
	// (set) Token: 0x0600B832 RID: 47154 RVA: 0x0030F410 File Offset: 0x0030D610
	public Action OnMiddle { get; set; }

	// Token: 0x17000F0C RID: 3852
	// (get) Token: 0x0600B833 RID: 47155 RVA: 0x0030F419 File Offset: 0x0030D619
	// (set) Token: 0x0600B834 RID: 47156 RVA: 0x0030F421 File Offset: 0x0030D621
	public Action OnLeft { get; set; }

	// Token: 0x17000F0D RID: 3853
	// (get) Token: 0x0600B835 RID: 47157 RVA: 0x0030F42A File Offset: 0x0030D62A
	// (set) Token: 0x0600B836 RID: 47158 RVA: 0x0030F432 File Offset: 0x0030D632
	public string MiddleTxtKey { get; set; } = "";

	// Token: 0x17000F0E RID: 3854
	// (get) Token: 0x0600B837 RID: 47159 RVA: 0x0030F43B File Offset: 0x0030D63B
	// (set) Token: 0x0600B838 RID: 47160 RVA: 0x0030F443 File Offset: 0x0030D643
	public string RightTxtKey { get; set; } = "";

	// Token: 0x17000F0F RID: 3855
	// (get) Token: 0x0600B839 RID: 47161 RVA: 0x0030F44C File Offset: 0x0030D64C
	// (set) Token: 0x0600B83A RID: 47162 RVA: 0x0030F454 File Offset: 0x0030D654
	public string LeftTxtKey { get; set; } = "";
}
