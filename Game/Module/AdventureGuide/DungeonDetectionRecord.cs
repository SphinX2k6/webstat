using System;
using Aki.Config;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006192 RID: 24978
	public class DungeonDetectionRecord : DetectionRecord<DungeonDetection>
	{
		// Token: 0x0603F1A2 RID: 258466 RVA: 0x0102EAB4 File Offset: 0x0102CCB4
		public DungeonDetectionRecord(DungeonDetection conf, bool isLock, long? refreshTime) : base(conf, isLock, refreshTime)
		{
		}
	}
}
