using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Movement;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA3 RID: 19107
	[NullableContext(1)]
	public interface IWuWaGoGridRelocationRequest : IWuWaGoGridRelocationContext
	{
		// Token: 0x170084D3 RID: 34003
		// (get) Token: 0x06031D33 RID: 204083
		WuWaGoGridController GridController { get; }

		// Token: 0x170084D4 RID: 34004
		// (get) Token: 0x06031D34 RID: 204084
		string OldKey { get; }

		// Token: 0x170084D5 RID: 34005
		// (get) Token: 0x06031D35 RID: 204085
		string TargetKey { get; }

		// Token: 0x170084D6 RID: 34006
		// (get) Token: 0x06031D36 RID: 204086
		IReadOnlyList<IWuWaGoGridMoveParticipant> Participants { get; }
	}
}
