using System;
using System.Runtime.CompilerServices;

// Token: 0x020011AF RID: 4527
[NullableContext(1)]
[Nullable(0)]
public class ArtemisChatItemData : IArtemisChatItemData
{
	// Token: 0x17000A0B RID: 2571
	// (get) Token: 0x0600772E RID: 30510 RVA: 0x001F309D File Offset: 0x001F129D
	// (set) Token: 0x0600772F RID: 30511 RVA: 0x001F30A5 File Offset: 0x001F12A5
	public string Content { get; set; } = "";

	// Token: 0x17000A0C RID: 2572
	// (get) Token: 0x06007730 RID: 30512 RVA: 0x001F30AE File Offset: 0x001F12AE
	// (set) Token: 0x06007731 RID: 30513 RVA: 0x001F30B6 File Offset: 0x001F12B6
	public string PicturePath { get; set; } = "";

	// Token: 0x17000A0D RID: 2573
	// (get) Token: 0x06007732 RID: 30514 RVA: 0x001F30BF File Offset: 0x001F12BF
	// (set) Token: 0x06007733 RID: 30515 RVA: 0x001F30C7 File Offset: 0x001F12C7
	public bool IsLock { get; set; }

	// Token: 0x17000A0E RID: 2574
	// (get) Token: 0x06007734 RID: 30516 RVA: 0x001F30D0 File Offset: 0x001F12D0
	// (set) Token: 0x06007735 RID: 30517 RVA: 0x001F30D8 File Offset: 0x001F12D8
	public bool IsShowEffect { get; set; }
}
