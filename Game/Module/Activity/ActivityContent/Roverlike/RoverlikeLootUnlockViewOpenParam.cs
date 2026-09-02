using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006456 RID: 25686
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLootUnlockViewOpenParam : IRoverlikeLootUnlockViewOpenParam
	{
		// Token: 0x17009E2E RID: 40494
		// (get) Token: 0x06040767 RID: 264039 RVA: 0x01085427 File Offset: 0x01083627
		// (set) Token: 0x06040768 RID: 264040 RVA: 0x0108542F File Offset: 0x0108362F
		public List<RoverRogueGainEntry> Loots { get; set; } = new List<RoverRogueGainEntry>();

		// Token: 0x17009E2F RID: 40495
		// (get) Token: 0x06040769 RID: 264041 RVA: 0x01085438 File Offset: 0x01083638
		// (set) Token: 0x0604076A RID: 264042 RVA: 0x01085440 File Offset: 0x01083640
		[Nullable(2)]
		public Action OnClosed { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
