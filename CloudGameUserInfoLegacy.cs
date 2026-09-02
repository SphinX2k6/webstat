using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E5B RID: 3675
[NullableContext(1)]
[Nullable(0)]
public class CloudGameUserInfoLegacy : ICloudGameUserInfoLegacy, ILoginInfo
{
	// Token: 0x17000637 RID: 1591
	// (get) Token: 0x06005872 RID: 22642 RVA: 0x00106BD4 File Offset: 0x00104DD4
	// (set) Token: 0x06005873 RID: 22643 RVA: 0x00106BDC File Offset: 0x00104DDC
	public string TraceId { get; set; }

	// Token: 0x17000638 RID: 1592
	// (get) Token: 0x06005874 RID: 22644 RVA: 0x00106BE5 File Offset: 0x00104DE5
	// (set) Token: 0x06005875 RID: 22645 RVA: 0x00106BED File Offset: 0x00104DED
	public int LoginCode { get; set; }

	// Token: 0x17000639 RID: 1593
	// (get) Token: 0x06005876 RID: 22646 RVA: 0x00106BF6 File Offset: 0x00104DF6
	// (set) Token: 0x06005877 RID: 22647 RVA: 0x00106BFE File Offset: 0x00104DFE
	public string Uid { get; set; }

	// Token: 0x1700063A RID: 1594
	// (get) Token: 0x06005878 RID: 22648 RVA: 0x00106C07 File Offset: 0x00104E07
	// (set) Token: 0x06005879 RID: 22649 RVA: 0x00106C0F File Offset: 0x00104E0F
	public string UserName { get; set; }

	// Token: 0x1700063B RID: 1595
	// (get) Token: 0x0600587A RID: 22650 RVA: 0x00106C18 File Offset: 0x00104E18
	// (set) Token: 0x0600587B RID: 22651 RVA: 0x00106C20 File Offset: 0x00104E20
	public string Token { get; set; }
}
