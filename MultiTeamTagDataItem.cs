using System;
using System.Runtime.CompilerServices;

// Token: 0x02002794 RID: 10132
[NullableContext(1)]
[Nullable(0)]
public class MultiTeamTagDataItem
{
	// Token: 0x06013FE8 RID: 81896 RVA: 0x00592378 File Offset: 0x00590578
	public static MultiTeamTagDataItem Phrase(int[] initSelectedTagList, ESkillBranchCacheType gameplayType)
	{
		return new MultiTeamTagDataItem
		{
			InitSelectedTagList = initSelectedTagList,
			GamePlayType = gameplayType
		};
	}

	// Token: 0x04009BAF RID: 39855
	public int[] InitSelectedTagList;

	// Token: 0x04009BB0 RID: 39856
	public ESkillBranchCacheType GamePlayType = ESkillBranchCacheType.BossPiling;
}
