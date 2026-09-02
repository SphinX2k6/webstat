using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002313 RID: 8979
[NullableContext(1)]
[Nullable(0)]
public class AlbumTimeInfo : IAlbumTimeInfo
{
	// Token: 0x17001517 RID: 5399
	// (get) Token: 0x060110F4 RID: 69876 RVA: 0x004AF23B File Offset: 0x004AD43B
	// (set) Token: 0x060110F5 RID: 69877 RVA: 0x004AF243 File Offset: 0x004AD443
	public int AlbumId { get; set; }

	// Token: 0x17001518 RID: 5400
	// (get) Token: 0x060110F6 RID: 69878 RVA: 0x004AF24C File Offset: 0x004AD44C
	// (set) Token: 0x060110F7 RID: 69879 RVA: 0x004AF254 File Offset: 0x004AD454
	public long BeginTime { get; set; }

	// Token: 0x17001519 RID: 5401
	// (get) Token: 0x060110F8 RID: 69880 RVA: 0x004AF25D File Offset: 0x004AD45D
	// (set) Token: 0x060110F9 RID: 69881 RVA: 0x004AF265 File Offset: 0x004AD465
	public long EndTime { get; set; }

	// Token: 0x1700151A RID: 5402
	// (get) Token: 0x060110FA RID: 69882 RVA: 0x004AF26E File Offset: 0x004AD46E
	// (set) Token: 0x060110FB RID: 69883 RVA: 0x004AF276 File Offset: 0x004AD476
	public HashSet<int> MusicIds { get; set; } = new HashSet<int>();

	// Token: 0x1700151B RID: 5403
	// (get) Token: 0x060110FC RID: 69884 RVA: 0x004AF27F File Offset: 0x004AD47F
	// (set) Token: 0x060110FD RID: 69885 RVA: 0x004AF287 File Offset: 0x004AD487
	public HashSet<int> CollectMusicIds { get; set; } = new HashSet<int>();
}
