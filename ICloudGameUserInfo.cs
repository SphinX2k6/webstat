using System;
using System.Runtime.CompilerServices;

// Token: 0x02000E58 RID: 3672
[NullableContext(1)]
public interface ICloudGameUserInfo
{
	// Token: 0x17000624 RID: 1572
	// (get) Token: 0x0600584B RID: 22603
	// (set) Token: 0x0600584C RID: 22604
	LoginInfo LoginInfo { get; set; }

	// Token: 0x17000625 RID: 1573
	// (get) Token: 0x0600584D RID: 22605
	// (set) Token: 0x0600584E RID: 22606
	string TraceId { get; set; }

	// Token: 0x17000626 RID: 1574
	// (get) Token: 0x0600584F RID: 22607
	// (set) Token: 0x06005850 RID: 22608
	string Platform { get; set; }

	// Token: 0x17000627 RID: 1575
	// (get) Token: 0x06005851 RID: 22609
	// (set) Token: 0x06005852 RID: 22610
	int Fps { get; set; }

	// Token: 0x17000628 RID: 1576
	// (get) Token: 0x06005853 RID: 22611
	// (set) Token: 0x06005854 RID: 22612
	int Dpi { get; set; }

	// Token: 0x17000629 RID: 1577
	// (get) Token: 0x06005855 RID: 22613
	// (set) Token: 0x06005856 RID: 22614
	ResolutionInfo DeviceResolution { get; set; }

	// Token: 0x1700062A RID: 1578
	// (get) Token: 0x06005857 RID: 22615
	// (set) Token: 0x06005858 RID: 22616
	ResolutionInfo ScreenResolution { get; set; }

	// Token: 0x1700062B RID: 1579
	// (get) Token: 0x06005859 RID: 22617
	// (set) Token: 0x0600585A RID: 22618
	string ServerTag { get; set; }

	// Token: 0x1700062C RID: 1580
	// (get) Token: 0x0600585B RID: 22619
	// (set) Token: 0x0600585C RID: 22620
	string Device { get; set; }
}
