using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002AC8 RID: 10952
public class SurvivorsActivityDefine
{
	// Token: 0x0400A857 RID: 43095
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static Dictionary<ESurvivorsTalentEffectShowType, string> effectShowTypeColorRecord = new Dictionary<ESurvivorsTalentEffectShowType, string>
	{
		{
			ESurvivorsTalentEffectShowType.Tips,
			"364c83ff"
		},
		{
			ESurvivorsTalentEffectShowType.Desc,
			"603683ff"
		},
		{
			ESurvivorsTalentEffectShowType.Item,
			"36837dff"
		}
	};

	// Token: 0x02008E33 RID: 36403
	public class SurvivorsLevelInfo
	{
		// Token: 0x0402FD4A RID: 195914
		public int LevelId;

		// Token: 0x0402FD4B RID: 195915
		public int InstId;

		// Token: 0x0402FD4C RID: 195916
		public int RoleId;

		// Token: 0x0402FD4D RID: 195917
		public bool IsEndless;

		// Token: 0x0402FD4E RID: 195918
		public bool IsSaveFile;

		// Token: 0x0402FD4F RID: 195919
		public int Batch;

		// Token: 0x0402FD50 RID: 195920
		public int MaxBatch;
	}
}
