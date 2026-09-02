using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.LevelRangeDebug
{
	// Token: 0x02004710 RID: 18192
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class LevelRangeDebugDrawModel : ModelBase<LevelRangeDebugDrawModel>
	{
		// Token: 0x0401AEFF RID: 110335
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<ELevelRangeType, LevelRangeDrawData> DrawDataMap;

		// Token: 0x0401AF00 RID: 110336
		public EDebugDrawMode DrawMode;

		// Token: 0x0401AF01 RID: 110337
		public float DrawRemainTime;

		// Token: 0x0401AF02 RID: 110338
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, LevelRangeTreeReferenceData> QuestReferenceDataMap;

		// Token: 0x0401AF03 RID: 110339
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, LevelRangeTreeReferenceData> LevelPlayReferenceDataMap;

		// Token: 0x0401AF04 RID: 110340
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Queue<LevelRangeDrawVolumeCache> DrawVolumeCache;
	}
}
