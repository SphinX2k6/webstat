using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E59 RID: 3673
[NullableContext(1)]
[Nullable(0)]
public class CloudGameUserInfo : ICloudGameUserInfo
{
	// Token: 0x1700062D RID: 1581
	// (get) Token: 0x0600585D RID: 22621 RVA: 0x00106B33 File Offset: 0x00104D33
	// (set) Token: 0x0600585E RID: 22622 RVA: 0x00106B3B File Offset: 0x00104D3B
	public LoginInfo LoginInfo { get; set; }

	// Token: 0x1700062E RID: 1582
	// (get) Token: 0x0600585F RID: 22623 RVA: 0x00106B44 File Offset: 0x00104D44
	// (set) Token: 0x06005860 RID: 22624 RVA: 0x00106B4C File Offset: 0x00104D4C
	public string TraceId { get; set; }

	// Token: 0x1700062F RID: 1583
	// (get) Token: 0x06005861 RID: 22625 RVA: 0x00106B55 File Offset: 0x00104D55
	// (set) Token: 0x06005862 RID: 22626 RVA: 0x00106B5D File Offset: 0x00104D5D
	public string Platform { get; set; }

	// Token: 0x17000630 RID: 1584
	// (get) Token: 0x06005863 RID: 22627 RVA: 0x00106B66 File Offset: 0x00104D66
	// (set) Token: 0x06005864 RID: 22628 RVA: 0x00106B6E File Offset: 0x00104D6E
	public int Fps { get; set; }

	// Token: 0x17000631 RID: 1585
	// (get) Token: 0x06005865 RID: 22629 RVA: 0x00106B77 File Offset: 0x00104D77
	// (set) Token: 0x06005866 RID: 22630 RVA: 0x00106B7F File Offset: 0x00104D7F
	public int Dpi { get; set; }

	// Token: 0x17000632 RID: 1586
	// (get) Token: 0x06005867 RID: 22631 RVA: 0x00106B88 File Offset: 0x00104D88
	// (set) Token: 0x06005868 RID: 22632 RVA: 0x00106B90 File Offset: 0x00104D90
	public ResolutionInfo DeviceResolution { get; set; }

	// Token: 0x17000633 RID: 1587
	// (get) Token: 0x06005869 RID: 22633 RVA: 0x00106B99 File Offset: 0x00104D99
	// (set) Token: 0x0600586A RID: 22634 RVA: 0x00106BA1 File Offset: 0x00104DA1
	public ResolutionInfo ScreenResolution { get; set; }

	// Token: 0x17000634 RID: 1588
	// (get) Token: 0x0600586B RID: 22635 RVA: 0x00106BAA File Offset: 0x00104DAA
	// (set) Token: 0x0600586C RID: 22636 RVA: 0x00106BB2 File Offset: 0x00104DB2
	public string ServerTag { get; set; }

	// Token: 0x17000635 RID: 1589
	// (get) Token: 0x0600586D RID: 22637 RVA: 0x00106BBB File Offset: 0x00104DBB
	// (set) Token: 0x0600586E RID: 22638 RVA: 0x00106BC3 File Offset: 0x00104DC3
	public string Device { get; set; }
}
