using System;
using Aki.Config;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006191 RID: 24977
	public class MonsterDetectionRecord : DetectionRecord<MonsterDetection>
	{
		// Token: 0x0603F1A1 RID: 258465 RVA: 0x0102EAA8 File Offset: 0x0102CCA8
		public MonsterDetectionRecord(MonsterDetection conf, bool isLock, long? refreshTime) : base(conf, isLock, refreshTime)
		{
		}
	}
}
