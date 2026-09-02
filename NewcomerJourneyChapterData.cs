using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001459 RID: 5209
public class NewcomerJourneyChapterData
{
	// Token: 0x0600913D RID: 37181 RVA: 0x00263F1D File Offset: 0x0026211D
	public NewcomerJourneyChapterData(int id)
	{
		this.Id = id;
	}

	// Token: 0x0400435B RID: 17243
	public int Id;

	// Token: 0x0400435C RID: 17244
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<NewcomerJourneyTaskData> TaskDataList;

	// Token: 0x0400435D RID: 17245
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, NewcomerJourneyTaskData> TaskDataMap;

	// Token: 0x0400435E RID: 17246
	[Nullable(2)]
	public NewbieAdventureV2ChapterPb Data;

	// Token: 0x0400435F RID: 17247
	public int ChapterId = -1;
}
