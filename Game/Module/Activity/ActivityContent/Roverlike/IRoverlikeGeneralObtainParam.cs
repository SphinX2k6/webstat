using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063C8 RID: 25544
	[NullableContext(1)]
	public interface IRoverlikeGeneralObtainParam
	{
		// Token: 0x17009DA9 RID: 40361
		// (get) Token: 0x06040233 RID: 262707
		// (set) Token: 0x06040234 RID: 262708
		List<RoverlikeGainEntry> Entries { get; set; }

		// Token: 0x17009DAA RID: 40362
		// (get) Token: 0x06040235 RID: 262709
		// (set) Token: 0x06040236 RID: 262710
		bool IsLose { get; set; }
	}
}
