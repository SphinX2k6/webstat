using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001458 RID: 5208
public class NewcomerJourneyTaskData
{
	// Token: 0x0600913C RID: 37180 RVA: 0x00263F07 File Offset: 0x00262107
	public NewcomerJourneyTaskData(int id)
	{
		this.Id = id;
	}

	// Token: 0x04004357 RID: 17239
	public int Id;

	// Token: 0x04004358 RID: 17240
	[Nullable(2)]
	public ConditionTask TaskData;

	// Token: 0x04004359 RID: 17241
	public AdventureTaskV2? Config;

	// Token: 0x0400435A RID: 17242
	public int ChapterId = -1;
}
