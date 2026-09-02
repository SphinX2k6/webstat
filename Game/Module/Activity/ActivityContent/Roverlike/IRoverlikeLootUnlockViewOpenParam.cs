using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006455 RID: 25685
	[NullableContext(1)]
	public interface IRoverlikeLootUnlockViewOpenParam
	{
		// Token: 0x17009E2C RID: 40492
		// (get) Token: 0x06040763 RID: 264035
		// (set) Token: 0x06040764 RID: 264036
		List<RoverRogueGainEntry> Loots { get; set; }

		// Token: 0x17009E2D RID: 40493
		// (get) Token: 0x06040765 RID: 264037
		// (set) Token: 0x06040766 RID: 264038
		[Nullable(2)]
		Action OnClosed { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
