using System;
using Aki.Config;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x02006193 RID: 24979
	public class SilentAreaDetectionRecord : DetectionRecord<SilentAreaDetection>
	{
		// Token: 0x0603F1A3 RID: 258467 RVA: 0x0102EAC0 File Offset: 0x0102CCC0
		public SilentAreaDetectionRecord(SilentAreaDetection conf, bool isLock, long? refreshTime) : base(conf, isLock, refreshTime)
		{
		}
	}
}
