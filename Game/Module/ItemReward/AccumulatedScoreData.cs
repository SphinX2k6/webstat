using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B2D RID: 23341
	public class AccumulatedScoreData
	{
		// Token: 0x040214D3 RID: 136403
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IAccumulatedScoreLineData> DetailScoreDataList;

		// Token: 0x040214D4 RID: 136404
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IAccumulatedScoreLineData> TotalScoreDataList;

		// Token: 0x040214D5 RID: 136405
		public int CurScore;

		// Token: 0x040214D6 RID: 136406
		public int MaxScore;
	}
}
