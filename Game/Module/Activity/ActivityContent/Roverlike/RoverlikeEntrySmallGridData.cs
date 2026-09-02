using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006458 RID: 25688
	public class RoverlikeEntrySmallGridData : IRoverlikeEntrySmallGridData
	{
		// Token: 0x17009E32 RID: 40498
		// (get) Token: 0x06040770 RID: 264048 RVA: 0x0108545C File Offset: 0x0108365C
		// (set) Token: 0x06040771 RID: 264049 RVA: 0x01085464 File Offset: 0x01083664
		public int ConfigId { get; set; }

		// Token: 0x17009E33 RID: 40499
		// (get) Token: 0x06040772 RID: 264050 RVA: 0x0108546D File Offset: 0x0108366D
		// (set) Token: 0x06040773 RID: 264051 RVA: 0x01085475 File Offset: 0x01083675
		public RoverRogueGainDataType Type { get; set; } = RoverRogueGainDataType.RoverRogueGainBless;
	}
}
