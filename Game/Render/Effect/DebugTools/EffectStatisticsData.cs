using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics;

namespace CSharpScript.Game.Render.Effect.DebugTools
{
	// Token: 0x0200479D RID: 18333
	public class EffectStatisticsData
	{
		// Token: 0x0401B35A RID: 111450
		public int RegisteredCountInterval;

		// Token: 0x0401B35B RID: 111451
		public int ReleasedCountInterval;

		// Token: 0x0401B35C RID: 111452
		public int CurrentCount;

		// Token: 0x0401B35D RID: 111453
		public int TickInFrameCount;

		// Token: 0x0401B35E RID: 111454
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<UEffectStatisticsEntryData_C> Entries;
	}
}
