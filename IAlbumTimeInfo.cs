using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002312 RID: 8978
[NullableContext(1)]
public interface IAlbumTimeInfo
{
	// Token: 0x17001512 RID: 5394
	// (get) Token: 0x060110EA RID: 69866
	// (set) Token: 0x060110EB RID: 69867
	int AlbumId { get; set; }

	// Token: 0x17001513 RID: 5395
	// (get) Token: 0x060110EC RID: 69868
	// (set) Token: 0x060110ED RID: 69869
	long BeginTime { get; set; }

	// Token: 0x17001514 RID: 5396
	// (get) Token: 0x060110EE RID: 69870
	// (set) Token: 0x060110EF RID: 69871
	long EndTime { get; set; }

	// Token: 0x17001515 RID: 5397
	// (get) Token: 0x060110F0 RID: 69872
	// (set) Token: 0x060110F1 RID: 69873
	HashSet<int> MusicIds { get; set; }

	// Token: 0x17001516 RID: 5398
	// (get) Token: 0x060110F2 RID: 69874
	// (set) Token: 0x060110F3 RID: 69875
	HashSet<int> CollectMusicIds { get; set; }
}
