using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B2A RID: 23338
	public class ReachTargetData
	{
		// Token: 0x040214CD RID: 136397
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardExploreTargetReached> TargetReached;

		// Token: 0x040214CE RID: 136398
		public int FullScore;

		// Token: 0x040214CF RID: 136399
		public bool IfNewRecord;

		// Token: 0x040214D0 RID: 136400
		[Nullable(1)]
		public string RecordTextId = "";
	}
}
