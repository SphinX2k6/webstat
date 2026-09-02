using System;
using System.Runtime.CompilerServices;

// Token: 0x020023BC RID: 9148
[NullableContext(1)]
[Nullable(0)]
public class PreviewPayGiftEntry : IPreviewPayGiftEntry
{
	// Token: 0x1700166A RID: 5738
	// (get) Token: 0x06011A5F RID: 72287 RVA: 0x004D82E4 File Offset: 0x004D64E4
	// (set) Token: 0x06011A60 RID: 72288 RVA: 0x004D82EC File Offset: 0x004D64EC
	public long EndStampSec { get; set; }

	// Token: 0x1700166B RID: 5739
	// (get) Token: 0x06011A61 RID: 72289 RVA: 0x004D82F5 File Offset: 0x004D64F5
	// (set) Token: 0x06011A62 RID: 72290 RVA: 0x004D82FD File Offset: 0x004D64FD
	public string Title { get; set; }

	// Token: 0x1700166C RID: 5740
	// (get) Token: 0x06011A63 RID: 72291 RVA: 0x004D8306 File Offset: 0x004D6506
	// (set) Token: 0x06011A64 RID: 72292 RVA: 0x004D830E File Offset: 0x004D650E
	public string RewardListDesc { get; set; }
}
