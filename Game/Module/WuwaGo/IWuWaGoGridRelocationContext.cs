using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A9F RID: 19103
	[NullableContext(1)]
	public interface IWuWaGoGridRelocationContext
	{
		// Token: 0x170084C1 RID: 33985
		// (get) Token: 0x06031D12 RID: 204050
		WuWaGoGrid Grid { get; }

		// Token: 0x170084C2 RID: 33986
		// (get) Token: 0x06031D13 RID: 204051
		Vector StartCoordinate { get; }

		// Token: 0x170084C3 RID: 33987
		// (get) Token: 0x06031D14 RID: 204052
		Vector TargetCoordinate { get; }
	}
}
