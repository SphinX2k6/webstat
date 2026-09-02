using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FD RID: 21757
	[NullableContext(1)]
	[Nullable(0)]
	public class SlotAreaInfo
	{
		// Token: 0x0401FD39 RID: 130361
		public EPhantomArenaDeckSlotType SlotType;

		// Token: 0x0401FD3A RID: 130362
		public UUIExtendToggle Toggle;

		// Token: 0x0401FD3B RID: 130363
		public UUIItem MaskItem;

		// Token: 0x0401FD3C RID: 130364
		public bool Enabled;
	}
}
